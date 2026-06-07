using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.Tools.ObjectTransform;
using ModApi;
using ModApi.Craft.Parts;
using TMPro;
using UI.Xml;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Design.PartProperties
{
	public class CommandPodPartProperties : GenericPartPropertiesScript
	{
		private const string StartChangePilotOrientationLabelText = "Adjust Pilot Orientation";

		private Toggle _changePilotOrientationButton;

		private TextMeshProUGUI _changePilotOrientationButtonLabel;

		private DesignerScript _designer;

		private bool _hasPilotAdjustmentOcurred;

		private RotateGizmoWrapper _pilotOrientationAdjustor;

		private Toggle _useDefaultOrientationButton;

		private CommandPodData Data => base.CurrentPartModifier as CommandPodData;

		public override void OnPartDeselected(IPartScript part)
		{
			base.OnPartDeselected(part);
			_changePilotOrientationButton.isOn = false;
		}

		public override bool OnPartSelected(IPartScript part)
		{
			bool result = base.OnPartSelected(part);
			_hasPilotAdjustmentOcurred = false;
			_changePilotOrientationButton.isOn = false;
			if (Data != null)
			{
				UpdateUi(Data.UseDefaultPilotSeatRotation);
			}
			return result;
		}

		protected override void OnInitialized()
		{
			base.OnInitialized();
			_designer = base.Designer as DesignerScript;
			PartPropertiesFlyoutScript obj = base.Flyout as PartPropertiesFlyoutScript;
			XmlElement xmlElement = obj.CloneTemplateElement("template-toggle", base.transform);
			int num = 100;
			xmlElement.transform.SetSiblingIndex(num);
			xmlElement.gameObject.AddComponent<PropertyRowScript>();
			xmlElement.GetElementByInternalId("toggle").Tooltip = "Automatically keep the pilot orientation at the default value whenever the part changes rotation.  Note: For this to work as expected, rockets need to be pointing up, and planes toward the white arrow.";
			_useDefaultOrientationButton = xmlElement.GetElementByInternalId<Toggle>("toggle");
			_useDefaultOrientationButton.onValueChanged.AddListener(OnUseDefaultOrientationButtonClicked);
			xmlElement.GetElementByInternalId<TextMeshProUGUI>("label").text = "Use Default Pilot Orientation";
			xmlElement = obj.CloneTemplateElement("template-toggle", base.transform);
			xmlElement.transform.SetSiblingIndex(num + 1);
			xmlElement.gameObject.AddComponent<PropertyRowScript>();
			xmlElement.GetElementByInternalId("toggle").Tooltip = "Allows adjusting the pilot orientation.  Wings, gyros, RCS, and auto control surfaces are configured using the pilots orientation.";
			_changePilotOrientationButton = xmlElement.GetElementByInternalId<Toggle>("toggle");
			_changePilotOrientationButton.onValueChanged.AddListener(OnChangePilotOrientationbuttonClicked);
			_changePilotOrientationButtonLabel = xmlElement.GetElementByInternalId<TextMeshProUGUI>("label");
			_changePilotOrientationButtonLabel.text = "Adjust Pilot Orientation";
			GameObject gameObject = Game.Instance.ResourceLoader.InstantiatePrefab("Craft/Parts/Prefabs/TestPilotSitting");
			Utilities.ChangeLayersOfGameObjectAndChildrenRecursive(gameObject, 11);
			_pilotOrientationAdjustor = new RotateGizmoWrapper(base.Designer.GizmoCamera, gameObject);
			_pilotOrientationAdjustor.Gizmo.AngleSnap = 15f;
			_pilotOrientationAdjustor.AdjustmentEnded += OnPilotSeatAdjustmentEnded;
			_pilotOrientationAdjustor.AdjustmentStarted += OnPilotSeatAdjustmentStarted;
		}

		private void OnChangePilotOrientationbuttonClicked(bool isChecked)
		{
			if (isChecked)
			{
				if (!_pilotOrientationAdjustor.IsShowing)
				{
					_pilotOrientationAdjustor.Start(Data.Script.PilotSeatOrientation, showAdjustmentGizmo: true);
				}
			}
			else if (_pilotOrientationAdjustor.IsShowing)
			{
				_pilotOrientationAdjustor.Stop();
			}
			UpdatePilotOrientationAdjustorGizmo();
		}

		private void OnPilotSeatAdjustmentEnded(MovementGizmoWrapper<RotateGizmo, RotateGizmoAxisScript> source, Vector3 finalEulerAngles)
		{
			Data.Script.SetPilotSeatRotation(finalEulerAngles, updatePartData: true);
		}

		private void OnPilotSeatAdjustmentStarted(MovementGizmoWrapper<RotateGizmo, RotateGizmoAxisScript> source)
		{
			if (!_hasPilotAdjustmentOcurred)
			{
				_hasPilotAdjustmentOcurred = true;
				Game.Instance.Designer.CreateUndoStep();
			}
		}

		private void OnResetPilotSeatRotation()
		{
			Game.Instance.Designer.CreateUndoStep();
			Data.Script.SetPilotSeatRotationToDefault(updatePartData: true);
		}

		private void OnUseDefaultOrientationButtonClicked(bool isChecked)
		{
			if (isChecked)
			{
				Game.Instance.Designer.CreateUndoStep();
			}
			UpdateUi(isChecked);
		}

		private void UpdateDefaultOrientationUi(bool useDefaultOrientation)
		{
			_useDefaultOrientationButton.isOn = useDefaultOrientation;
			_changePilotOrientationButton.isOn = false;
			_changePilotOrientationButton.gameObject.SetActive(!useDefaultOrientation);
			_changePilotOrientationButtonLabel.gameObject.SetActive(!useDefaultOrientation);
			if (useDefaultOrientation && _pilotOrientationAdjustor.IsShowing)
			{
				_pilotOrientationAdjustor.Stop();
			}
		}

		private void UpdatePilotOrientationAdjustorGizmo()
		{
			if (_pilotOrientationAdjustor.IsShowing)
			{
				DesignerScript designer = _designer;
				bool allowPartSelection = (_designer.AllowPartMovement = false);
				designer.AllowPartSelection = allowPartSelection;
			}
			else
			{
				DesignerScript designer2 = _designer;
				bool allowPartSelection = (_designer.AllowPartMovement = true);
				designer2.AllowPartSelection = allowPartSelection;
				_designer.AllowPartSelection = true;
			}
		}

		private void UpdateUi(bool useDefaultOrientation)
		{
			if (Data != null)
			{
				Data.UseDefaultPilotSeatRotation = useDefaultOrientation;
				UpdateDefaultOrientationUi(useDefaultOrientation);
			}
		}
	}
}
