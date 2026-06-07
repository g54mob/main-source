using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Craft.Parts.Modifiers.Eva;
using Assets.Scripts.Design;
using Assets.Scripts.State;
using ModApi.Audio;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.Math;
using ModApi.Scripts.State.Validation;
using ModApi.Ui;
using TMPro;
using UI.Xml;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Ui.Crew
{
	public class CrewAssignmentDialogScript : DialogScript
	{
		private XmlElement _buttonAll;

		private XmlElement _buttonAvailable;

		private ICraftScript _craft;

		private DesignerScript _designer;

		private CrewItem _dragSource;

		private DesignerPart _droodDesignerPart;

		private DropTargetScript _dropTarget;

		private XmlElement _parentSource;

		private XmlElement _parentTargets;

		private DropTargetScript _restoreDropTarget;

		private bool _showAll;

		private List<CrewItem> _sources = new List<CrewItem>();

		private List<CompartmentTarget> _targets = new List<CompartmentTarget>();

		private XmlElement _templateCrewItem;

		private XmlElement _templatePartHeader;

		public Transform DragParent { get; private set; }

		public bool HasChanges { get; private set; }

		public bool IsDragging => _dragSource != null;

		public static CrewAssignmentDialogScript Create(ICraftScript craft, Transform parent, DesignerScript designer)
		{
			CrewAssignmentDialogScript crewAssignmentDialogScript = Game.Instance.UserInterface.CreateDialog("Ui/Xml/CrewAssignmentDialog", parent, delegate(CrewAssignmentDialogScript d, IXmlLayoutController c)
			{
				d.OnLayoutRebuilt((XmlLayout)c.XmlLayout);
			});
			crewAssignmentDialogScript.Initialize(craft, designer);
			return crewAssignmentDialogScript;
		}

		public override void Close()
		{
			base.Close();
			base.gameObject.SetActive(value: false);
			Object.Destroy(base.gameObject);
		}

		public void Dragging()
		{
		}

		public void EndDrag()
		{
			if (_dropTarget != null)
			{
				HasChanges = true;
				_dropTarget.Selected = false;
				Game.Instance.AudioPlayer.PlaySound(AudioLibrary.Design.StagingDropPart);
				_dropTarget.OnDragEnd(_dragSource);
			}
			_dragSource = null;
			_dropTarget = null;
		}

		public void EnterDropTarget(DropTargetScript dropTarget, PointerEventData eventData)
		{
			if (_dropTarget != null)
			{
				_dropTarget.Selected = false;
			}
			_dropTarget = null;
			if (_dragSource != null && _dragSource != dropTarget.CrewItem)
			{
				_dropTarget = dropTarget;
				_dropTarget.Selected = true;
			}
		}

		public void ExitDropTarget(DropTargetScript dropTarget)
		{
			if (_dropTarget != null)
			{
				_dropTarget.Selected = false;
				_dropTarget = null;
			}
		}

		public void OnFilterCrewButtonClicked(bool showAll)
		{
			_showAll = showAll;
			RefreshSourceCrewVisibility();
		}

		public void OnOkayButtonClicked()
		{
			Close();
			foreach (CrewItem source in _sources)
			{
				if (source.OriginalEva != null && !source.OriginalEva.Part.IsRootPart)
				{
					_craft.DestroyPart(source.OriginalEva.Part, destroyPartGameObject: true);
				}
			}
			foreach (CompartmentTarget target in _targets)
			{
				if (target.Compartment != null)
				{
					AttachPointScript attachPointScript = target.Compartment.Part.AttachPoints.Where((AttachPoint x) => x.ConnectionType == AttachPointConnectionType.Eva).First().AttachPointScript;
					foreach (CrewItem item in target.Crew)
					{
						IPartScript partScript = item.OriginalEva?.Part?.PartScript;
						if (item.OriginalEva == null)
						{
							partScript = CreateEvaPart(item);
						}
						else
						{
							if (!(item.OriginalEva.Script.CrewCompartment == null) && !(item.OriginalEva.Script.CrewCompartment.PartScript.Data != target.Compartment.Part))
							{
								continue;
							}
							DisconnectEva(item.OriginalEva);
							item.OriginalEva.AssignCrewMember(item.Crew);
						}
						PartScript.ConnectParts(partScript.Data.AttachPoints.Where((AttachPoint x) => x.ConnectionType == AttachPointConnectionType.Eva).First().AttachPointScript, attachPointScript, processingSymmetry: false);
					}
					continue;
				}
				Bounds bounds = _designer.CraftScript.CalculateBounds(includeDisconnected: true);
				Vector3 position = new Vector3(bounds.max.x + 1f, bounds.center.y, bounds.center.z);
				foreach (CrewItem item2 in target.Crew)
				{
					bool flag = false;
					IPartScript partScript2 = null;
					if (item2.OriginalEva == null)
					{
						partScript2 = CreateEvaPart(item2);
						flag = true;
					}
					else
					{
						partScript2 = item2.OriginalEva.Part.PartScript;
						if (partScript2.Data.PartConnections.Count > 0)
						{
							DisconnectEva(item2.OriginalEva);
							flag = true;
						}
					}
					if (flag)
					{
						partScript2.Transform.position = position;
						position += new Vector3(0f, 0f, 1f);
					}
				}
			}
		}

		public void StartDragging(CrewItem crewItem)
		{
			_dragSource = crewItem;
			Game.Instance.AudioPlayer.PlaySound(AudioLibrary.Design.StagingDragPart);
		}

		protected override void Start()
		{
			base.Start();
		}

		private static void DisconnectEva(EvaData eva)
		{
			while (eva.Part.PartConnections.Count > 0)
			{
				eva.Part.PartConnections[0].DestroyConnection();
			}
		}

		private CompartmentTarget AddCompartmentTarget(XmlElement parent, CrewCompartmentData compartment)
		{
			XmlElement xmlElement = UiUtilities.CloneTemplate(_templatePartHeader, parent);
			TextMeshProUGUI elementByInternalId = xmlElement.GetElementByInternalId<TextMeshProUGUI>("name");
			if (compartment?.Part != null)
			{
				elementByInternalId.text = $"{compartment.Part.Name}#{compartment.Part.Id}";
			}
			else
			{
				elementByInternalId.text = "Floating";
			}
			DropTargetScript dropTargetScript = xmlElement.gameObject.AddComponent<DropTargetScript>();
			dropTargetScript.Dialog = this;
			CompartmentTarget compartmentTarget = new CompartmentTarget(xmlElement, compartment);
			dropTargetScript.OnDragEnd = delegate(CrewItem x)
			{
				if (compartmentTarget.Compartment == null || compartmentTarget.Crew.Count < compartmentTarget.Compartment.Capacity)
				{
					x.Compartment?.RemoveCrew(x);
					_sources.Remove(x);
					compartmentTarget.AddCrew(x);
					compartmentTarget.Refresh();
				}
			};
			xmlElement.AddOnClickEvent(delegate
			{
				compartmentTarget.IsExpanded = !compartmentTarget.IsExpanded;
			});
			return compartmentTarget;
		}

		private CrewItem AddCrew(XmlElement parent, CrewMember crewMember)
		{
			XmlElement element = UiUtilities.CloneTemplate(_templateCrewItem, parent);
			CrewItem crewItem = new CrewItem(element, crewMember, this);
			DropTargetScript dropTargetScript = crewItem.Element.gameObject.AddComponent<DropTargetScript>();
			dropTargetScript.Dialog = this;
			dropTargetScript.OnDragEnd = delegate(CrewItem x)
			{
				CompartmentTarget compartment = crewItem.Compartment;
				if (compartment != null)
				{
					EvaData originalEva = crewItem.OriginalEva;
					if (originalEva != null && originalEva.Part.IsRootPart)
					{
						x.OriginalEva = crewItem.OriginalEva;
						crewItem.OriginalEva = null;
					}
					x.Compartment?.RemoveCrew(x);
					_sources.Remove(x);
					compartment.RemoveCrew(crewItem);
					AddCrewToSources(crewItem);
					compartment.AddCrew(x);
					compartment.Refresh();
				}
			};
			return crewItem;
		}

		private void AddCrewToSources(CrewItem crewItem)
		{
			int num = -1;
			for (int i = 0; i < _sources.Count; i++)
			{
				CrewItem crewItem2 = _sources[i];
				if (string.Compare(crewItem.CrewName, crewItem2.CrewName) <= 0)
				{
					_sources.Insert(i, crewItem);
					num = crewItem2.Element.transform.GetSiblingIndex();
					break;
				}
			}
			if (num == -1)
			{
				_sources.Add(crewItem);
			}
			crewItem.Element.transform.SetParent(_parentSource.transform);
			if (num >= 0)
			{
				crewItem.Element.transform.SetSiblingIndex(num);
			}
			else
			{
				crewItem.Element.transform.SetAsLastSibling();
			}
		}

		private IPartScript CreateEvaPart(CrewItem crewItem)
		{
			List<IPartScript> list = new List<IPartScript>();
			_designer.InstantiatePart(_droodDesignerPart, list);
			IPartScript partScript = list.First();
			partScript.GetModifier<EvaScript>().Data.AssignCrewMember(crewItem.Crew);
			return partScript;
		}

		private void Initialize(ICraftScript craft, DesignerScript designer)
		{
			_craft = craft;
			_designer = designer;
			PartListPanelScript componentInChildren = _designer.DesignerUi.Flyouts.PartList.Transform.GetComponentInChildren<PartListPanelScript>();
			_droodDesignerPart = componentInChildren.DesignerParts.DroodDesignerPart;
			foreach (CrewMember item in Game.Instance.GameState.Crew.Members.OrderBy((CrewMember x) => x.Name))
			{
				_sources.Add(AddCrew(_parentSource, item));
			}
			List<CrewCompartmentData> list = new List<CrewCompartmentData>();
			List<EvaData> list2 = new List<EvaData>();
			foreach (PartData part in craft.Data.Assembly.Parts)
			{
				CrewCompartmentData modifier = part.GetModifier<CrewCompartmentData>();
				if (modifier != null && modifier.Capacity > 0)
				{
					if (!modifier.Part.SymmetryId.HasValue)
					{
						list.Add(modifier);
					}
				}
				else if (part.PartConnections.Count == 0)
				{
					EvaData modifier2 = part.GetModifier<EvaData>();
					if (modifier2 != null)
					{
						list2.Add(modifier2);
					}
				}
			}
			CompartmentTarget compartmentTarget = AddCompartmentTarget(_parentTargets, null);
			_targets.Add(compartmentTarget);
			foreach (EvaData eva in list2)
			{
				CrewItem crewItem = _sources.Where((CrewItem x) => x.Crew.Id == eva.CrewId).FirstOrDefault();
				if (crewItem != null)
				{
					_sources.Remove(crewItem);
				}
				else
				{
					crewItem = AddCrew(_parentTargets, null);
				}
				if (crewItem != null)
				{
					crewItem.OriginalEva = eva;
					compartmentTarget.AddCrew(crewItem);
				}
			}
			compartmentTarget.Refresh();
			foreach (CrewCompartmentData item2 in list)
			{
				CompartmentTarget compartmentTarget2 = AddCompartmentTarget(_parentTargets, item2);
				_targets.Add(compartmentTarget2);
				foreach (PartConnection partConnection in item2.Part.PartConnections)
				{
					PartData otherPart = partConnection.GetOtherPart(item2.Part);
					EvaData eva2 = otherPart.GetModifier<EvaData>();
					if (eva2 != null)
					{
						CrewItem crewItem2 = _sources.Where((CrewItem x) => x.Crew.Id == eva2.CrewId).FirstOrDefault();
						if (crewItem2 != null)
						{
							_sources.Remove(crewItem2);
						}
						else
						{
							crewItem2 = AddCrew(_parentTargets, null);
						}
						crewItem2.OriginalEva = eva2;
						compartmentTarget2.AddCrew(crewItem2);
					}
				}
				compartmentTarget2.Refresh();
			}
			RefreshSourceCrewVisibility();
		}

		private void OnHireButtonClicked()
		{
			int hireCostScaled = 6000000 * Game.Instance.GameState.Crew.Members.Count() * Game.Instance.GameState.Crew.Members.Count();
			IGameStateValidator validator = Game.Instance.GameState.Validator;
			if (Game.IsCareer && !CareerState.IsDebugMode && !Game.Instance.GameState.Validator.IsItemAvailable("Cheats.SkipValidation") && Game.Instance.GameState.AvailableFunds < hireCostScaled)
			{
				Game.Instance.UserInterface.CreateMessageDialog().MessageText = "You do not have enough money to hire a new astronaut. You currently have " + Units.GetMoneyString(Game.Instance.GameState.AvailableFunds) + " and it costs " + Units.GetMoneyString(hireCostScaled) + " to hire a new astronaut.";
				return;
			}
			if (Game.IsCareer && !CareerState.IsDebugMode && (float)_sources.Count >= validator.ItemValue("Crew"))
			{
				Game.Instance.UserInterface.CreateMessageDialog().MessageText = "Your crew is already as large as it can get. You can unlock larger crews in the Tech Tree.";
				return;
			}
			ModApi.Ui.MessageDialogScript messageDialogScript = Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.OkayCancel);
			messageDialogScript.MessageText = "Do you want to hire a new astronaut for " + Units.GetMoneyString(hireCostScaled) + "?";
			messageDialogScript.OkayClicked += delegate(ModApi.Ui.MessageDialogScript d)
			{
				d.Close();
				CrewMember crewMember = Game.Instance.GameState.Crew.CreateCrewMember();
				Game.Instance.GameState.Career?.SpendMoney(hireCostScaled);
				_sources.Add(AddCrew(_parentSource, crewMember));
			};
		}

		private void OnLayoutRebuilt(XmlLayout xmlLayout)
		{
			_templateCrewItem = xmlLayout.GetElementById("crew-item-template");
			_parentSource = xmlLayout.GetElementById("source-parent");
			_parentTargets = xmlLayout.GetElementById("targets-parent");
			_templatePartHeader = xmlLayout.GetElementById("template-part-header");
			DragParent = xmlLayout.GetElementById<Transform>("drag-parent");
			XmlElement elementById = xmlLayout.GetElementById("restore-crew-drop-target");
			_restoreDropTarget = elementById.gameObject.AddComponent<DropTargetScript>();
			_restoreDropTarget.Dialog = this;
			_restoreDropTarget.OnDragEnd = delegate(CrewItem x)
			{
				x.Compartment?.RemoveCrew(x);
				AddCrewToSources(x);
			};
			_buttonAvailable = xmlLayout.GetElementById("filter-source-available");
			_buttonAll = xmlLayout.GetElementById("filter-source-all");
		}

		private void OnRemoveCrewClicked(XmlElement element)
		{
			if (element.GetComponentInParent<DragHandlerScript>()?.Item is CrewItem crewItem)
			{
				crewItem.Compartment.RemoveCrew(crewItem);
				AddCrewToSources(crewItem);
			}
		}

		private void RefreshSourceCrewVisibility()
		{
			_buttonAll.RemoveClass("btn-primary");
			_buttonAvailable.RemoveClass("btn-primary");
			if (_showAll)
			{
				_buttonAll.AddClass("btn-primary");
			}
			else
			{
				_buttonAvailable.AddClass("btn-primary");
			}
			foreach (CrewItem source in _sources)
			{
				source.Visible = source.Crew.State == CrewMemberState.Available || _showAll;
				source.RefreshUI();
			}
		}

		private void Update()
		{
			if (UnityEngine.Input.GetKeyDown(KeyCode.Escape) && Game.Instance.UserInterface.ActiveDialog is CrewAssignmentDialogScript)
			{
				OnOkayButtonClicked();
			}
		}
	}
}
