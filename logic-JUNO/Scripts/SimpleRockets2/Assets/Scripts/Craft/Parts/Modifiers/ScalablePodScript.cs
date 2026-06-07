using System.Collections.Generic;
using Assets.Scripts.Craft.Parts.Modifiers.Input;
using Assets.Scripts.Design;
using ModApi;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.GameLoop;
using ModApi.GameLoop.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class ScalablePodScript : PartModifierScript<ScalablePodData>, IFlightStart, IGameLoopItem, IModifierWaterPhysicsConfig
	{
		private Transform _attachPointPositions;

		private DetacherScript _detacher;

		private Transform _scalar;

		private InputControllerScript _throttleInput;

		float IModifierWaterPhysicsConfig.PartVolume => base.Data.TotalVolume;

		void IFlightStart.FlightStart(in FlightFrameData frame)
		{
			_throttleInput = GetInputController((CraftControls x) => x.Throttle) as InputControllerScript;
			SetEngineState(base.Data.EngineEnabled, updateCraftStructure: false);
			_detacher = base.PartScript.GetModifier<DetacherScript>();
			CommandPodScript modifier = base.PartScript.GetModifier<CommandPodScript>();
			modifier.StageActivated += OnCommandPodStageActivated;
			modifier.ActivationGroupChanged += OnCommandPodActivationGroupChanged;
			base.PartScript.Activate();
		}

		public void UpdateScale(float newScale, bool repositionAttachedParts = false, float heightStretch = 1f)
		{
			base.Data.UpdateOtherModifiersAndStuff();
			_scalar.localScale = new Vector3(newScale, newScale * heightStretch, newScale);
			Dictionary<int, bool> movedParts = new Dictionary<int, bool>();
			foreach (Transform attachPointPosition in _attachPointPositions)
			{
				foreach (AttachPoint attachPoint in base.Data.Part.AttachPoints)
				{
					if (!(attachPoint.Name == attachPointPosition.name))
					{
						continue;
					}
					attachPoint.Scale = 1f * base.Data.ScaledSize;
					Vector3 position = attachPoint.Position;
					attachPoint.Position = attachPointPosition.localPosition * newScale * heightStretch;
					attachPoint.Radius = attachPointPosition.localScale.y * newScale;
					if (!(attachPoint.AttachPointScript != null))
					{
						break;
					}
					if (repositionAttachedParts)
					{
						Vector3 position2 = attachPoint.Position;
						Vector3 delta = attachPoint.AttachPointScript.transform.parent.TransformVector(position2 - position);
						foreach (PartConnection partConnection in attachPoint.PartConnections)
						{
							DesignerUtilities.RepositionParts(base.Data.Part, partConnection, delta, movedParts);
							foreach (IConnectedAttachPointChangedHandler item in partConnection.GetOtherPart(base.Data.Part).PartScript.GetModifiersWithInterface<IConnectedAttachPointChangedHandler>())
							{
								foreach (PartConnection.Attachment attachment in partConnection.Attachments)
								{
									item.OnAttachPointRadiusChanged(attachment.GetOtherAttachPoint(attachPoint), attachPoint);
								}
							}
						}
					}
					attachPoint.AttachPointScript.transform.localPosition = attachPoint.Position;
					break;
				}
			}
		}

		protected override void OnInitialized()
		{
			base.OnInitialized();
			_scalar = Utilities.FindFirstGameObjectMyselfOrChildren("PodParent", base.PartScript.GameObject).transform;
			_attachPointPositions = Utilities.FindFirstGameObjectMyselfOrChildren("AttachPointPositions", _scalar.gameObject).transform;
			UpdateScale(base.Data.ScaledSize, repositionAttachedParts: false, base.Data.Height);
		}

		private void OnCommandPodActivationGroupChanged(ICommandPod source, int activationGroup, bool state)
		{
			InputControllerScript throttleInput = _throttleInput;
			if ((object)throttleInput != null && throttleInput.Data.ActivationGroup == activationGroup)
			{
				SetEngineState(state, updateCraftStructure: true);
			}
			if (base.Data.Part.ActivationGroup == activationGroup && state)
			{
				_detacher?.Detach();
			}
		}

		private void OnCommandPodStageActivated(ICommandPod source, int stageActivated)
		{
			if (stageActivated == base.PartScript.Data.ActivationStage)
			{
				SetEngineState(state: true, updateCraftStructure: true);
				_detacher?.Detach();
			}
		}

		private void SetEngineState(bool state, bool updateCraftStructure)
		{
			base.Data.EngineEnabled = state;
			if (_throttleInput != null && _throttleInput.ActiveOverride != state)
			{
				_throttleInput.ActiveOverride = state;
				if (updateCraftStructure)
				{
					base.PartScript.CraftScript.SetStructureChanged();
				}
			}
		}
	}
}
