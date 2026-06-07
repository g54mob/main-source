using System;
using System.Collections.Generic;
using Assets.Scripts.Craft.Parts.Modifiers.Propulsion;
using Assets.Scripts.Design.PartProperties;
using Assets.Scripts.Flight.UI;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.GameLoop;
using ModApi.GameLoop.Interfaces;
using ModApi.Math;
using ModApi.Ui.Inspector;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Eva
{
	public class CrewCompartmentScript : PartModifierScript<CrewCompartmentData>, IAnalyzePerformance, IFlightStart, IGameLoopItem, IFlightUpdate
	{
		public delegate void CrewEnterExitHandler(EvaScript crew);

		public delegate void CrewPropertyChangedHandler(CrewCompartmentScript source);

		private const float MaxDistToEnterAirborne = 2f;

		private const float MaxDistToEnterGrounded = 10f;

		private EvaScript _currentCrewEva;

		private FlightSceneUiController _flightSceneUiController;

		public List<EvaScript> Crew { get; private set; } = new List<EvaScript>();

		public string CrewLoadedAnimationControllerPath { get; private set; }

		public Vector3 CrewPosition { get; set; }

		public Vector3 CrewRotation { get; set; }

		public EvaScript DesignerCrewHighlight { get; set; }

		public bool IsFull => Crew.Count >= base.Data.Capacity;

		public bool RefreshPartPropertiesUI { get; set; }

		public bool UsesMachNumber => false;

		public event CrewPropertyChangedHandler CrewAnimationChanged;

		public event CrewEnterExitHandler CrewEnter;

		public event CrewEnterExitHandler CrewExit;

		public event CrewPropertyChangedHandler CrewOrientationChanged;

		void IFlightStart.FlightStart(in FlightFrameData frame)
		{
			OnActiveCommandPodChanged(Game.Instance.FlightScene.CraftNode);
		}

		void IFlightUpdate.FlightUpdate(in FlightFrameData frame)
		{
			float airPressure = base.PartScript.CraftScript.AtmosphereSample.AirPressure;
			base.PartScript.TakeDamage(Mathf.Max(0f, 0.01f * frame.DeltaTime * Mathf.Max((base.Data.MinPressure > 0f) ? (base.Data.MinPressure - airPressure) : 0f, (base.Data.MaxPressure > 0f) ? (airPressure - base.Data.MaxPressure) : 0f)), PartDamageType.Pressure);
		}

		public List<CrewCompartmentScript> GetAccessibleCrewCompartments()
		{
			List<CrewCompartmentScript> list = new List<CrewCompartmentScript>();
			new List<IBodyScript>();
			foreach (PartData part in new PartGraph(base.PartScript.Data, breakOnRigidBodyBoundary: false, captureRigidBodyBoundries: false, delegate(PartConnection x)
			{
				foreach (PartConnection.Attachment attachment in x.Attachments)
				{
					if (attachment.AttachPointA.CrewTraversable && attachment.AttachPointB.CrewTraversable)
					{
						return false;
					}
				}
				return true;
			}).Parts)
			{
				CrewCompartmentScript modifier = part.PartScript.GetModifier<CrewCompartmentScript>();
				if (modifier != null && modifier != this && !modifier.IsFull)
				{
					list.Add(modifier);
				}
			}
			return list;
		}

		public bool IsCloseEnoughToEnterCompartment(EvaScript crew)
		{
			return GetDistanceFromCrewCompartment(crew) < GetMaxDistanceToEnterCrewCompartment(crew);
		}

		public override void OnCraftLoaded(ICraftScript craftScript, bool movedToNewCraft)
		{
			base.OnCraftLoaded(craftScript, movedToNewCraft);
			if (Game.InFlightScene)
			{
				Game.Instance.FlightScene.ActiveCommandPodChanged += OnActiveCommandPodChanged;
			}
		}

		public void OnCrewMemberLoaded(EvaScript crew)
		{
			if (Game.InDesignerScene)
			{
				DesignerCrewHighlight = crew;
			}
			Crew.Add(crew);
			crew.PartScript.PartDestroyed += OnCrewDestroyed;
			if (Game.InDesignerScene)
			{
				Game.Instance.Designer.DesignerUi.Transform.GetComponentInChildren<CrewCompartmentPartProperties>(includeInactive: true).RefreshList();
				foreach (PartConnection partConnectionsBetweenPart in PartConnection.GetPartConnectionsBetweenParts(crew.PartScript.Data, base.PartScript.Data))
				{
					partConnectionsBetweenPart.AllowManualDelete = false;
					partConnectionsBetweenPart.Destroyed += OnCrewPartConnectionDestroyed;
				}
			}
			this.CrewEnter?.Invoke(crew);
		}

		public override void OnGenerateInspectorModel(PartInspectorModel model)
		{
			base.OnGenerateInspectorModel(model);
			GroupModel groupModel = new GroupModel("Crew");
			FlightSceneInterfaceScript ui = Game.Instance.FlightScene.FlightSceneUI as FlightSceneInterfaceScript;
			foreach (EvaScript crew in Crew)
			{
				IconButtonRowModel rowModel = new IconButtonRowModel();
				rowModel.Label = crew.Data.CrewName;
				IconButtonModel iconButtonModel = new IconButtonModel("Ui/Sprites/Flight/IconCrewExit", delegate
				{
					OnUnloadCrewButtonClicked(model, rowModel, crew);
				});
				iconButtonModel.Style = ButtonModel.ButtonStyle.Primary;
				iconButtonModel.Tooltip = "EVA";
				IconButtonModel moveButton = new IconButtonModel("Ui/Sprites/Flight/IconCrewTransfer", delegate
				{
					OnMoveCrewButtonClicked(model, rowModel, crew);
				});
				moveButton.Style = ((ui.ActiveMoveCrewRequest != null) ? (ui.ActiveMoveCrewRequest.Crew.Contains(crew) ? ButtonModel.ButtonStyle.Primary : ButtonModel.ButtonStyle.Default) : ButtonModel.ButtonStyle.Default);
				moveButton.Tooltip = "Move to another crew compartment";
				rowModel.Add(moveButton);
				rowModel.Add(iconButtonModel);
				IconButtonRowModel iconButtonRowModel = rowModel;
				iconButtonRowModel.UpdateAction = (Action<ItemModel>)Delegate.Combine(iconButtonRowModel.UpdateAction, (Action<ItemModel>)delegate
				{
					moveButton.Style = ((ui.ActiveMoveCrewRequest != null) ? (ui.ActiveMoveCrewRequest.Crew.Contains(crew) ? ButtonModel.ButtonStyle.Primary : ButtonModel.ButtonStyle.Default) : ButtonModel.ButtonStyle.Default);
				});
				groupModel.Add(rowModel);
				groupModel.Add(new TextModel("Current Gs", () => crew.Gs.ToString("n1"), null, "The G forces experienced by " + crew.Data.CrewName));
			}
			TextButtonModel item = new TextButtonModel("Move Here", delegate
			{
				int num = Crew.Count;
				bool flag = false;
				int num2 = 0;
				while (ui.ActiveMoveCrewRequest.Crew.Count > 0 && num2 < ui.ActiveMoveCrewRequest.Crew.Count)
				{
					if (num >= base.Data.Capacity)
					{
						flag = true;
						break;
					}
					EvaScript crew2 = ui.ActiveMoveCrewRequest.Crew[num2];
					if (ui.ActiveMoveCrewRequest.CrewCompartment != null || IsCloseEnoughToEnterCompartment(crew2))
					{
						LoadCrewMember(crew2, delegate
						{
							if (crew2 != null && !crew2.ActiveWhileInCrewCompartment)
							{
								_flightSceneUiController.ClosePartInspectorPanel(crew2.PartScript);
							}
							RefreshInspectorPanel();
						}, announceBoarding: false);
						ui.ActiveMoveCrewRequest.RemoveCrew(crew2);
						num++;
					}
					else
					{
						num2++;
					}
				}
				if (ui.ActiveMoveCrewRequest.Crew.Count > 0)
				{
					string arg = (flag ? "Compartment Capacity" : "Distance");
					ui.ShowMessage($"Crew Moved\n\nMovement of {ui.ActiveMoveCrewRequest.Crew.Count} Crew Member(s) Incomplete due to {arg}");
					ui.ActiveMoveCrewRequest.CrewCompartment?.RefreshInspectorPanel(createIfClosed: false);
				}
				else
				{
					ui.ActiveMoveCrewRequest.CompleteRequest(this);
				}
			}, null, delegate
			{
				MoveCrewRequest activeMoveCrewRequest = ui.ActiveMoveCrewRequest;
				return (activeMoveCrewRequest != null && activeMoveCrewRequest.CrewCompartment != this && !IsFull && activeMoveCrewRequest.AccessibleCrewCompartments.Contains(this)) ? true : false;
			});
			groupModel.Add(item);
			TextButtonModel item2 = new TextButtonModel("Cancel Move", delegate
			{
				ui.ActiveMoveCrewRequest.EndCrewMove("Crew Move Canceled");
			}, null, () => ui.ActiveMoveCrewRequest != null);
			groupModel.Add(item2);
			TextButtonModel enterCompartmentButton = null;
			enterCompartmentButton = new TextButtonModel("Enter", delegate
			{
				OnLoadCrewIntoCompartmentButtonClicked(_currentCrewEva);
			}, null, delegate
			{
				int num;
				if (_currentCrewEva != null)
				{
					num = ((!_currentCrewEva.ActiveWhileInCrewCompartment) ? 1 : 0);
					if (num != 0)
					{
						string text = (IsCloseEnoughToEnterCompartment(_currentCrewEva) ? "Enter" : "Too Far Away");
						text = (IsFull ? "Full" : text);
						if (text != enterCompartmentButton.Label)
						{
							enterCompartmentButton.Label = text;
						}
					}
				}
				else
				{
					num = 0;
				}
				return (byte)num != 0;
			});
			enterCompartmentButton.Tooltip = "Press this button to board the crew compartment. You must be within range.";
			groupModel.Add(enterCompartmentButton);
			model.AddGroup(groupModel);
		}

		public void OnGeneratePerformanceAnalysisModel(GroupModel groupModel)
		{
			TextModel textModel = groupModel.Add(new TextModel("Max Pressure", () => Units.GetPressureString(base.Data.MaxPressure), null, "The maximum pressure the part can support before taking damage."));
			TextModel textModel2 = groupModel.Add(new TextModel("Min Pressure", () => Units.GetPressureString(base.Data.MinPressure), null, "The minimum pressure the part can support before taking damage."));
			textModel.DetermineVisibility = () => base.Data.MaxPressure > 0f;
			textModel2.DetermineVisibility = () => base.Data.MinPressure > 0f;
		}

		public override void OnPartDestroyed()
		{
			base.OnPartDestroyed();
			if (!Game.InFlightScene)
			{
				return;
			}
			foreach (EvaScript item in Crew)
			{
				item.PartScript.TakeDamage(100f);
			}
			Game.Instance.FlightScene.ActiveCommandPodChanged -= OnActiveCommandPodChanged;
		}

		public void RefreshInspectorPanel(bool createIfClosed = true)
		{
			_flightSceneUiController.RegeneratePartInspectorPanel(base.PartScript, createIfClosed);
		}

		public void SetCrewLoadedAnimation(string animationControllerPath)
		{
			CrewLoadedAnimationControllerPath = animationControllerPath;
			this.CrewAnimationChanged?.Invoke(this);
		}

		public void SetCrewOrientation(Vector3 relativePosition, Vector3 relativeRotation)
		{
			CrewPosition = relativePosition;
			CrewRotation = relativeRotation;
			this.CrewOrientationChanged?.Invoke(this);
		}

		public void UnloadCrewMember(EvaScript crew, bool takeControl)
		{
			Crew.Remove(crew);
			crew.PartScript.PartDestroyed -= OnCrewDestroyed;
			if (takeControl)
			{
				crew.TakeControl();
			}
			this.CrewExit?.Invoke(crew);
		}

		protected override void OnInitialized()
		{
			base.OnInitialized();
			if (Game.InFlightScene)
			{
				_flightSceneUiController = (Game.Instance.FlightScene.FlightSceneUI as FlightSceneInterfaceScript).UiController;
			}
			CrewPosition = base.PartScript.Data.Config.CenterOfMass;
		}

		private float GetDistanceFromCrewCompartment(EvaScript crew)
		{
			return Vector3.Distance(crew.transform.position, base.transform.position);
		}

		private float GetMaxDistanceToEnterCrewCompartment(EvaScript crew)
		{
			return base.Data.Radius + (crew.IsGrounded ? 10f : 2f);
		}

		private void LoadCrewMember(EvaScript crew, Action onCompleted, bool announceBoarding = true)
		{
			if (crew.CrewCompartment != null)
			{
				crew.CrewCompartment.UnloadCrewMember(crew, takeControl: false);
			}
			crew.LoadIntoCrewCompartment(this, onCompleted, announceBoarding);
		}

		private void OnActiveCommandPodChanged(ICraftNode craftNode)
		{
			_currentCrewEva = craftNode?.CraftScript?.ActiveCommandPod.EvaScript as EvaScript;
		}

		private void OnCrewDestroyed(IPartScript partScript)
		{
			UnloadCrewMember(partScript.CommandPod.EvaScript as EvaScript, takeControl: false);
		}

		private void OnCrewPartConnectionDestroyed(PartConnection partConnection)
		{
			RefreshPartPropertiesUI = true;
			EvaScript crew = partConnection.GetOtherPart(base.PartScript.Data)?.PartScript.GetModifier<EvaScript>();
			base.Data.Script.UnloadCrewMember(crew, takeControl: true);
		}

		private void OnLoadCrewIntoCompartmentButtonClicked(EvaScript crew)
		{
			if (IsCloseEnoughToEnterCompartment(crew) || !crew.EvaActive)
			{
				if (!IsFull)
				{
					EvaScript evaToLoad = crew;
					LoadCrewMember(evaToLoad, delegate
					{
						if (evaToLoad != null && !evaToLoad.ActiveWhileInCrewCompartment)
						{
							_flightSceneUiController.ClosePartInspectorPanel(evaToLoad.PartScript);
						}
						RefreshInspectorPanel();
					});
				}
				else if (Crew.Count > 0)
				{
					Game.Instance.FlightScene.FlightSceneUI.ShowMessage($"The crew compartment is full with {Crew.Count} astronauts.");
				}
				else
				{
					Game.Instance.FlightScene.FlightSceneUI.ShowMessage("<color=\"red\">The crew compartment has no room for astronauts.</color>");
				}
			}
			else
			{
				Game.Instance.FlightScene.FlightSceneUI.ShowMessage($"You're too far away ({GetDistanceFromCrewCompartment(crew):0.0}m) to enter the crew compartment. You must be within {(int)GetMaxDistanceToEnterCrewCompartment(crew)}m.");
			}
		}

		private void OnMoveCrewButtonClicked(PartInspectorModel model, IconButtonRowModel rowModel, EvaScript crew)
		{
			FlightSceneInterfaceScript flightSceneInterfaceScript = Game.Instance.FlightScene.FlightSceneUI as FlightSceneInterfaceScript;
			if (flightSceneInterfaceScript.ActiveMoveCrewRequest == null || !flightSceneInterfaceScript.ActiveMoveCrewRequest.Crew.Contains(crew))
			{
				if (flightSceneInterfaceScript.ActiveMoveCrewRequest != null && flightSceneInterfaceScript.ActiveMoveCrewRequest.CrewCompartment != this)
				{
					string arg = ((flightSceneInterfaceScript.ActiveMoveCrewRequest.CrewCompartment == null) ? "you are transfering external crew" : $"you are moving crew from {flightSceneInterfaceScript.ActiveMoveCrewRequest.CrewCompartment.Data.Part.Name}#{flightSceneInterfaceScript.ActiveMoveCrewRequest.CrewCompartment.Data.Part.Id}");
					flightSceneInterfaceScript.ShowMessage($"Cannot move crew from {base.Data.Part.Name}#{base.Data.Part.Id}, because {arg}");
				}
				else
				{
					flightSceneInterfaceScript.AddMoveCrewRequest(crew);
					rowModel.Update();
				}
			}
			else
			{
				flightSceneInterfaceScript.CancelMoveCrewRequest(crew);
				rowModel.Update();
			}
		}

		private void OnUnloadCrewButtonClicked(PartInspectorModel model, IconButtonRowModel rowModel, EvaScript crew)
		{
			UnloadCrewMember(model, rowModel, crew);
			RefreshInspectorPanel();
		}

		private void UnloadCrewMember(PartInspectorModel model, IconButtonRowModel rowModel, EvaScript crew)
		{
			model.Remove(rowModel);
			UnloadCrewMember(crew, takeControl: true);
		}
	}
}
