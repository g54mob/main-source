using Assets.Scripts.Craft.Parts.Modifiers.Wing;
using Assets.Scripts.Tools.ObjectTransform;
using Assets.Scripts.Ui;
using ModApi.Craft.Parts;
using ModApi.Design;
using ModApi.Ui;
using UI.Xml;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Design
{
	public class ViewOptionsPanelScript : DesignerFlyoutPanelScript
	{
		private const string ToggledClass = "toggled";

		private DesignerCameraScript _camera;

		private RotateGizmoWrapper _pilotOrientationAdjustor;

		private ICommandPod _pilotOrientationCommandPod;

		private XmlElement _selectCommandPodPanel;

		private Toggle _showLiftButton;

		private Toggle _showPilotButton;

		private SpinnerScript _stageSpinner;

		public override void Initialize(DesignerUiScript designerUi)
		{
			base.Initialize(designerUi);
			_camera = base.DesignerUi.Designer.DesignerCamera as DesignerCameraScript;
			_pilotOrientationAdjustor = new RotateGizmoWrapper(base.DesignerUi.Designer.GizmoCamera, Game.Instance.ResourceLoader.InstantiatePrefab("Craft/Parts/Prefabs/TestPilotSitting"));
			base.Flyout.Opened += OnFlyoutOpened;
			designerUi.Designer.SelectedPartChanged += OnSelectedPartChanged;
			designerUi.Designer.CraftLoaded += OnCraftLoaded;
		}

		public override void LayoutRebuilt(ParseXmlResult parseResult)
		{
			base.LayoutRebuilt(parseResult);
			_stageSpinner = base.xmlLayout.GetElementById<SpinnerScript>("stage-spinner");
			_stageSpinner.NextButton.onClick.AddListener(delegate
			{
				OnStageSpinnerClicked(1);
			});
			_stageSpinner.PrevButton.onClick.AddListener(delegate
			{
				OnStageSpinnerClicked(-1);
			});
			XmlElement elementById = base.xmlLayout.GetElementById("show-pilot-panel");
			_showPilotButton = elementById.GetElementByInternalId<Toggle>("show-pilot-button");
			XmlElement elementById2 = base.xmlLayout.GetElementById("show-lift-panel");
			_showLiftButton = elementById2.GetElementByInternalId<Toggle>("show-lift-button");
			_selectCommandPodPanel = base.xmlLayout.GetElementById("select-command-pod-panel");
		}

		public void OnBackgroundColorClicked()
		{
			Game.Instance.UserInterface.CreateColorPicker(allowTransparency: false, _camera.Camera.backgroundColor, Callback, Callback);
			void Callback(Color c)
			{
				_camera.Camera.backgroundColor = c;
			}
		}

		public void OnCameraClicked(string directionName)
		{
			DesignerCameraScript camera = _camera;
			camera.SetViewDirection(directionName switch
			{
				"front" => (_camera.ViewDirection == DesignerCameraViewDirection.Front) ? DesignerCameraViewDirection.Back : DesignerCameraViewDirection.Front, 
				"side" => (_camera.ViewDirection == DesignerCameraViewDirection.Right) ? DesignerCameraViewDirection.Left : DesignerCameraViewDirection.Right, 
				"top" => (_camera.ViewDirection == DesignerCameraViewDirection.Top) ? DesignerCameraViewDirection.Bottom : DesignerCameraViewDirection.Top, 
				_ => DesignerCameraViewDirection.None, 
			});
		}

		private void OnCenterGizmoClicked(XmlElement element)
		{
			element.ToggleClass("toggled");
			UpdateGizmos();
		}

		private void OnCraftLoaded()
		{
			UpdatePilotVisibility(_showPilotButton.isOn);
			if (_showLiftButton.isOn)
			{
				UpdateWingAerodnamicCenters();
			}
		}

		private void OnFlyoutOpened(IFlyout flyout)
		{
			OnStageSpinnerClicked(0);
		}

		private void OnSelectedPartChanged(IPartScript oldPart, IPartScript newPart)
		{
			if (_pilotOrientationAdjustor.IsShowing)
			{
				UpdatePilotVisibility(_pilotOrientationAdjustor.IsShowing);
			}
		}

		private void OnSelectPartsAssociatedCommandPodClicked(Button button)
		{
			base.DesignerUi.Designer.SelectPart(_pilotOrientationCommandPod.Part.PartScript, null, justAdded: false);
			base.DesignerUi.Flyouts.PartProperties.Open();
		}

		private void OnShowLiftVectorChanged(Toggle button)
		{
			WingScript.ShowLiftVectorGlobal = button.isOn;
			if (WingScript.ShowLiftVectorGlobal)
			{
				UpdateWingAerodnamicCenters();
			}
		}

		private void OnShowPilotChanged(Toggle button)
		{
			UpdatePilotVisibility(button.isOn);
			_selectCommandPodPanel.SetActive(button.isOn);
		}

		private void OnStageSpinnerClicked(int direction)
		{
			base.DesignerUi.Designer.Gizmos.SetReferenceStage(base.DesignerUi.Designer.Gizmos.ReferenceStage + direction);
			if (base.DesignerUi.Designer.Gizmos.ReferenceStage == -1)
			{
				_stageSpinner.Value = "ALL";
			}
			else
			{
				_stageSpinner.Value = (base.DesignerUi.Designer.Gizmos.ReferenceStage + 1).ToString();
			}
		}

		private void UpdateGizmos()
		{
			base.DesignerUi.Designer.Gizmos.CenterOfMassGizmoEnabled = base.xmlLayout.GetElementById("gizmo-com").HasClass("toggled");
			base.DesignerUi.Designer.Gizmos.CenterOfLiftGizmoEnabled = base.xmlLayout.GetElementById("gizmo-col").HasClass("toggled");
			base.DesignerUi.Designer.Gizmos.CenterOfThrustGizmoEnabled = base.xmlLayout.GetElementById("gizmo-cot").HasClass("toggled");
		}

		private void UpdatePilotVisibility(bool show)
		{
			if (show)
			{
				if (_pilotOrientationAdjustor.IsShowing)
				{
					_pilotOrientationAdjustor.Stop();
				}
				IPartScript selectedPart = base.DesignerUi.Designer.SelectedPart;
				if (selectedPart != null)
				{
					_pilotOrientationCommandPod = selectedPart.CommandPod;
				}
				else
				{
					_pilotOrientationCommandPod = base.DesignerUi.Designer.CraftScript.RootPart.CommandPod;
				}
				_pilotOrientationAdjustor.Start(_pilotOrientationCommandPod.PilotSeatOrientation, showAdjustmentGizmo: false);
			}
			else
			{
				_pilotOrientationAdjustor.Stop();
			}
		}

		private void UpdateWingAerodnamicCenters()
		{
			foreach (PartData part in base.DesignerUi.Designer.CraftScript.Data.Assembly.Parts)
			{
				WingScript modifier = part.PartScript.GetModifier<WingScript>();
				if (modifier != null && modifier.WingPhysicsScript != null)
				{
					modifier.WingPhysicsScript.UpdateStaticAerodynamicCenter();
				}
			}
		}
	}
}
