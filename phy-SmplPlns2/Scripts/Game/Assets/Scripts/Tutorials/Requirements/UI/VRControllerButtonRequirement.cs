using System;
using System.Xml.Linq;
using Assets.Scripts.Input.XR;
using Assets.Scripts.Tutorials.Requirements.Attributes;
using Assets.Scripts.XR.UI;
using UnityEngine.InputSystem;

namespace Assets.Scripts.Tutorials.Requirements.UI
{
	[Serializable]
	[TutorialRequirement("VRControllerButton")]
	public class VRControllerButtonRequirement : TutorialRequirement
	{
		private bool _buttonPressed;

		public string InputActionId { get; set; }

		public bool RequiresLeftGrip { get; set; }

		public bool RequiresPress { get; set; }

		public bool RequiresRightGrip { get; set; }

		protected override float DefaultRequiredMetDuration => 0f;

		public VRControllerButtonRequirement()
		{
		}

		public VRControllerButtonRequirement(string inputActionId, bool requiresPress, bool requiresLeftGrip, bool requiresRightGrip, string message = null)
		{
			InputActionId = inputActionId;
			RequiresPress = requiresPress;
			RequiresLeftGrip = requiresLeftGrip;
			RequiresRightGrip = requiresRightGrip;
			base.RequirementNotMetMessage = message;
		}

		public override void OnStepCompleted(TutorialStepState state)
		{
			base.OnStepCompleted(state);
			SetHighlight(highlighted: false);
		}

		public override void OnStepStarted()
		{
			base.OnStepStarted();
			SetHighlight(highlighted: true);
		}

		protected override void GenerateXml(XElement xml)
		{
			xml.SetAttributeValue("inputId", InputActionId);
			xml.SetAttributeValue("requiresLeftGrip", RequiresLeftGrip);
			xml.SetAttributeValue("requiresRightGrip", RequiresRightGrip);
			xml.SetAttributeValue("requiresPress", RequiresPress);
			base.GenerateXml(xml);
		}

		protected override TutorialRequirementState OnRequirementUpdate()
		{
			InputAction inputAction = XRInputs.Flight.ActionMap.FindAction(InputActionId);
			if (inputAction == null)
			{
				return TutorialRequirementState.RequirementNotMet;
			}
			if (RequiresPress)
			{
				if (!_buttonPressed)
				{
					_buttonPressed = inputAction.IsPressed();
					if (_buttonPressed)
					{
						SetHighlight(highlighted: false);
					}
				}
				if (!_buttonPressed)
				{
					return TutorialRequirementState.RequirementNotMet;
				}
				return TutorialRequirementState.RequirementMet;
			}
			return TutorialRequirementState.RequirementMet;
		}

		protected override void RestoreFromXml(XElement xml)
		{
			base.RestoreFromXml(xml);
			InputActionId = (string)xml.Attribute("inputId");
			RequiresLeftGrip = (bool?)xml.Attribute("requiresLeftGrip") == true;
			RequiresRightGrip = (bool?)xml.Attribute("requiresRightGrip") == true;
			RequiresPress = (bool?)xml.Attribute("requiresPress") == true;
		}

		private void SetHighlight(bool highlighted)
		{
			foreach (FlightMenuScript instance in FlightMenuScript.Instances)
			{
				instance.controllerLayout.SetHighlightedActionId(InputActionId, highlighted);
				if (RequiresLeftGrip)
				{
					instance.controllerLayout.SetHighlightedActionId(XRInputs.Flight.GripPressedLeft.name, highlighted);
				}
				else if (RequiresRightGrip)
				{
					instance.controllerLayout.SetHighlightedActionId(XRInputs.Flight.GripPressedRight.name, highlighted);
				}
			}
		}
	}
}
