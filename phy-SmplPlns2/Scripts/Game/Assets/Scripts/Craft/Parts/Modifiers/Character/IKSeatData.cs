using System.Collections.Generic;
using System.Xml.Linq;
using Assets.Scripts.Craft.Parts.Modifiers.XR;
using Assets.Scripts.Design.PartProperties.Attributes;
using Assets.Scripts.Design.UI.PartProperties;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Character
{
	[PartModifierDesignerHeader("Seat IK")]
	public class IKSeatData : PartModifierData, ISelectPartPropertyModifier
	{
		[DesignerPropertyButton(Label = "Auto Assign Targets", Style = ButtonStyle.Primary, Order = 8)]
		private bool _autoAssignButton = true;

		private int _bodyTarget;

		[DesignerPropertyToggleButton(new string[] { "None" }, Label = "Designer Character", Order = 3)]
		private string _designerCharacter = "None";

		[DesignerPropertyToggleButton(new string[] { "No", "Yes" }, Label = "FPV Tracking", Tooltip = "Whether the seated Character First Person View camera will follow the head position as modified by the seat IK.", Order = 6)]
		private bool _fpvTracking = true;

		[DesignerPropertyPartId(Label = "Left Elbow", Order = 30, MustBeConnected = true, StartMessage = "Select a target for the Left Elbow.", NoOptionsMessage = "No targets available for this seat.")]
		private int _leftElbowTarget;

		[DesignerPropertyPartId(Label = "Left Foot", Order = 50, MustBeConnected = true, StartMessage = "Select a target for the Left Foot.", NoOptionsMessage = "No targets available for this seat.")]
		private int _leftFootTarget;

		[DesignerPropertyPartId(Label = "Left Hand", Order = 10, MustBeConnected = true, StartMessage = "Select a target for the Left Hand.", NoOptionsMessage = "No targets available for this seat.")]
		private int _leftHandTarget;

		[DesignerPropertyPartId(Label = "Left Knee", Order = 70, MustBeConnected = true, StartMessage = "Select a target for the Left Knee.", NoOptionsMessage = "No targets available for this seat.")]
		private int _leftKneeTarget;

		private int _leftShoulderTarget;

		[DesignerPropertySlider(MinValue = 0f, MaxValue = 1f, NumberOfSteps = 101, Label = "Maintain Head Rotation", Order = 5)]
		private float _maintainHeadRotation = 1f;

		[DesignerPropertyLabel(Order = 49)]
		private string _messageBottom = "Bottom";

		[DesignerPropertyLabel(Order = 9)]
		private string _messageTop = "Top";

		private bool _refreshUI;

		[DesignerPropertyPartId(Label = "Right Elbow", Order = 40, MustBeConnected = true, StartMessage = "Select a target for the Right Elbow.", NoOptionsMessage = "No targets available for this seat.")]
		private int _rightElbowTarget;

		[DesignerPropertyPartId(Label = "Right Foot", Order = 60, MustBeConnected = true, StartMessage = "Select a target for the Right Foot.", NoOptionsMessage = "No targets available for this seat.")]
		private int _rightFootTarget;

		[DesignerPropertyPartId(Label = "Right Hand", Order = 20, MustBeConnected = true, StartMessage = "Select a target for the Right Hand.", NoOptionsMessage = "No targets available for this seat.")]
		private int _rightHandTarget;

		[DesignerPropertyPartId(Label = "Right Knee", Order = 80, MustBeConnected = true, StartMessage = "Select a target for the Right Knee.", NoOptionsMessage = "No targets available for this seat.")]
		private int _rightKneeTarget;

		private int _rightShoulderTarget;

		private bool _selfAssignTargets;

		[DesignerPropertySlider(Label = "Snap Range", MinValue = 0.5f, MaxValue = 10f, NumberOfSteps = 39, Order = 90, Tooltip = "The distance beyond which the limb will snap back to the rest position and forget what it was trying to grab.")]
		private float _snapRange = 1f;

		public int BodyTarget
		{
			get
			{
				return _bodyTarget;
			}
			set
			{
				_bodyTarget = value;
			}
		}

		public Dictionary<string, string> CharacterPaths { get; } = new Dictionary<string, string>
		{
			{ "Chad (FS)", "Characters/Rigged/ChadFSRigged" },
			{ "Chad (WW1)", "Characters/Rigged/ChadWW1Rigged" }
		};

		public string DesignerCharacter
		{
			get
			{
				return _designerCharacter;
			}
			set
			{
				_designerCharacter = value;
			}
		}

		public bool FPVTracking => _fpvTracking;

		public int LeftElbowTarget
		{
			get
			{
				return _leftElbowTarget;
			}
			set
			{
				_leftElbowTarget = value;
			}
		}

		public int LeftFootTarget
		{
			get
			{
				return _leftFootTarget;
			}
			set
			{
				_leftFootTarget = value;
			}
		}

		public int LeftHandTarget
		{
			get
			{
				return _leftHandTarget;
			}
			set
			{
				_leftHandTarget = value;
			}
		}

		public int LeftKneeTarget
		{
			get
			{
				return _leftKneeTarget;
			}
			set
			{
				_leftKneeTarget = value;
			}
		}

		public int LeftShoulderTarget
		{
			get
			{
				return _leftShoulderTarget;
			}
			set
			{
				_leftShoulderTarget = value;
			}
		}

		public float MaintainHeadRotation => _maintainHeadRotation;

		public int RightElbowTarget
		{
			get
			{
				return _rightElbowTarget;
			}
			set
			{
				_rightElbowTarget = value;
			}
		}

		public int RightFootTarget
		{
			get
			{
				return _rightFootTarget;
			}
			set
			{
				_rightFootTarget = value;
			}
		}

		public int RightHandTarget
		{
			get
			{
				return _rightHandTarget;
			}
			set
			{
				_rightHandTarget = value;
			}
		}

		public int RightKneeTarget
		{
			get
			{
				return _rightKneeTarget;
			}
			set
			{
				_rightKneeTarget = value;
			}
		}

		public int RightShoulderTarget
		{
			get
			{
				return _rightShoulderTarget;
			}
			set
			{
				_rightShoulderTarget = value;
			}
		}

		public IKSeatScript Script { get; private set; }

		public bool SelfAssignTargets => _selfAssignTargets;

		public float SnapRange => _snapRange * _snapRange;

		public IKSeatData(XElement element)
			: base(element)
		{
			_selfAssignTargets = element.GetBoolAttribute("selfAssignTargets");
		}

		public override XElement GenerateStateXml()
		{
			XElement xElement = base.GenerateStateXml();
			if (_leftHandTarget != 0)
			{
				xElement.Add(new XAttribute("leftHandTarget", _leftHandTarget));
			}
			if (_rightHandTarget != 0)
			{
				xElement.Add(new XAttribute("rightHandTarget", _rightHandTarget));
			}
			if (_leftElbowTarget != 0)
			{
				xElement.Add(new XAttribute("leftElbowTarget", _leftElbowTarget));
			}
			if (_rightElbowTarget != 0)
			{
				xElement.Add(new XAttribute("rightElbowTarget", _rightElbowTarget));
			}
			if (_leftFootTarget != 0)
			{
				xElement.Add(new XAttribute("leftFootTarget", _leftFootTarget));
			}
			if (_rightFootTarget != 0)
			{
				xElement.Add(new XAttribute("rightFootTarget", _rightFootTarget));
			}
			if (_leftKneeTarget != 0)
			{
				xElement.Add(new XAttribute("leftKneeTarget", _leftKneeTarget));
			}
			if (_rightKneeTarget != 0)
			{
				xElement.Add(new XAttribute("rightKneeTarget", _rightKneeTarget));
			}
			if (_leftShoulderTarget != 0)
			{
				xElement.Add(new XAttribute("leftShoulderTarget", _leftShoulderTarget));
			}
			if (_rightShoulderTarget != 0)
			{
				xElement.Add(new XAttribute("rightShoulderTarget", _rightShoulderTarget));
			}
			if (_bodyTarget != 0)
			{
				xElement.Add(new XAttribute("bodyTarget", _bodyTarget));
			}
			xElement.Add(new XAttribute("maintainHeadRotation", _maintainHeadRotation.ToString("n2")));
			if (_designerCharacter != "None")
			{
				xElement.Add(new XAttribute("designerCharacter", _designerCharacter));
			}
			if (!Mathf.Approximately(_snapRange, 1f))
			{
				xElement.Add(new XAttribute("snapRange", _snapRange));
			}
			xElement.Add(new XAttribute("fpvTracking", _fpvTracking));
			xElement.Add(new XAttribute("selfAssignTargets", _selfAssignTargets));
			return xElement;
		}

		public override string GetGenericDesignerPropertySliderValueLabel(string propertyName, float sliderValue)
		{
			if (propertyName == "_maintainHeadRotation")
			{
				return sliderValue.ToString("P0");
			}
			return base.GetGenericDesignerPropertySliderValueLabel(propertyName, sliderValue);
		}

		public override PartModifierScript Initialize(GameObject parentGameObject, PartData.PartCreationInfo partCreationInfo, AircraftScript aircraftScript)
		{
			IKSeatScript iKSeatScript = parentGameObject.AddComponent<IKSeatScript>();
			iKSeatScript.Initialize(this);
			Script = iKSeatScript;
			return iKSeatScript;
		}

		public override void OnGenericDesignerPropertiesUpdate(IGenericPartProperties genericPartProperties)
		{
			base.OnGenericDesignerPropertiesUpdate(genericPartProperties);
			if (_refreshUI)
			{
				_refreshUI = false;
				genericPartProperties.RefreshUI();
			}
		}

		public override void OnGenericDesignerPropertiesVisible(IGenericPartProperties genericPartPropertiesScript)
		{
			base.OnGenericDesignerPropertiesVisible(genericPartPropertiesScript);
			DesignerPropertyToggleButtonAttribute buttonAttribute = genericPartPropertiesScript.GetProperty<ToggleButtonProperty>("_designerCharacter").ButtonAttribute;
			buttonAttribute.Values.Clear();
			buttonAttribute.Values.Add("None");
			buttonAttribute.Values.AddRange(CharacterPaths.Keys);
		}

		public override void OnGenericDesignerPropertyButtonClicked(IConfigurableProperty property)
		{
			base.OnGenericDesignerPropertyButtonClicked(property);
			if (property.Member.Name == "_autoAssignButton")
			{
				Script.AutoAssignTargets();
			}
		}

		public override void OnGenericDesignerPropertyChanged(string propertyName, string value)
		{
			base.OnGenericDesignerPropertyChanged(propertyName, value);
			if (propertyName == "_designerCharacter")
			{
				Script.SetDesignerCharacter(_designerCharacter);
			}
			if (propertyName == "_maintainHeadRotation")
			{
				Script.UpdateMaintainHeadRotation();
			}
		}

		public void OnPartSelectionToolClosed(string fieldName, PartData part)
		{
			if (_designerCharacter != "None")
			{
				Script.StartPose(Script.CharacterModel.transform);
			}
		}

		public bool OnPartSelectionToolFilterPart(string fieldName, PartData part)
		{
			PosedGripData modifier = part.GetModifier<PosedGripData>();
			if (part.GetModifier<IKTargetData>() == null)
			{
				if (modifier != null)
				{
					return fieldName.Contains("Hand");
				}
				return false;
			}
			return true;
		}

		public void QueueUIRefresh()
		{
			_refreshUI = true;
		}

		public override void RestoreFromState(XElement stateElement)
		{
			base.RestoreFromState(stateElement);
			_leftHandTarget = stateElement.GetIntAttribute("leftHandTarget");
			_rightHandTarget = stateElement.GetIntAttribute("rightHandTarget");
			_leftElbowTarget = stateElement.GetIntAttribute("leftElbowTarget");
			_rightElbowTarget = stateElement.GetIntAttribute("rightElbowTarget");
			_leftFootTarget = stateElement.GetIntAttribute("leftFootTarget");
			_rightFootTarget = stateElement.GetIntAttribute("rightFootTarget");
			_leftKneeTarget = stateElement.GetIntAttribute("leftKneeTarget");
			_rightKneeTarget = stateElement.GetIntAttribute("rightKneeTarget");
			_leftShoulderTarget = stateElement.GetIntAttribute("leftShoulderTarget");
			_rightShoulderTarget = stateElement.GetIntAttribute("rightShoulderTarget");
			_bodyTarget = stateElement.GetIntAttribute("bodyTarget");
			_maintainHeadRotation = stateElement.GetFloatAttribute("maintainHeadRotation", 1f);
			_designerCharacter = stateElement.GetStringAttribute("designerCharacter", "None");
			_snapRange = stateElement.GetFloatAttribute("snapRange", 1f);
			_fpvTracking = stateElement.GetBoolAttribute("fpvTracking", defaultValue: true);
			_selfAssignTargets = stateElement.GetBoolAttribute("selfAssignTargets", _selfAssignTargets);
			if (_designerCharacter != "None" && !CharacterPaths.ContainsKey(_designerCharacter))
			{
				_designerCharacter = "None";
			}
		}
	}
}
