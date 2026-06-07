using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using Assets.Scripts.Design.Tools;
using Assets.Scripts.UI;
using Assets.Scripts.UI.Controls;
using Jundroo.Juicy.Widgets;
using SFB;
using UnityEngine;

namespace Assets.Scripts.Design.UI
{
	public class BlueprintsPanelScript : DesignerPanelScript, IBlueprintsPanel
	{
		private List<BlueprintScript> _blueprints = new List<BlueprintScript>();

		private HeaderScript _blueprintsHeader;

		private Designer _designer;

		private string _direction;

		private DragBlueprintTool _dragBlueprintTool;

		private NumericSpinnerControl _heightSpinner;

		private ButtonWidget _moveButton;

		private Widget _optionsIfImageSelected;

		private Widget _optionsIfNoImageSelected;

		private bool _settingsLoaded;

		private ButtonWidget _showButton;

		private BlueprintScript _trackedBlueprint;

		private NumericSpinnerControl _widthSpinner;

		public static string GetDirectionName(Vector3 dir)
		{
			Vector3 normalized = dir.normalized;
			if (normalized.x > 0.999f)
			{
				return "Right";
			}
			if (normalized.x < -0.999f)
			{
				return "Left";
			}
			if (normalized.y > 0.999f)
			{
				return "Top";
			}
			if (normalized.y < -0.999f)
			{
				return "Bottom";
			}
			if (normalized.z > 0.999f)
			{
				return "Front";
			}
			if (normalized.z < -0.999f)
			{
				return "Back";
			}
			return null;
		}

		public override void InitializeDesignerPanel(DesignerUIScript designerUI)
		{
			base.InitializeDesignerPanel(designerUI);
			_designer = Designer.Instance;
			base.Flyout.Opened += OnFlyoutOpened;
			_dragBlueprintTool = new DragBlueprintTool(_designer, _designer.CameraController);
			_dragBlueprintTool.ScaleChanged += delegate
			{
				UpdateSizeSpinners();
			};
			_widthSpinner = new NumericSpinnerControl(base.Widget.FindWidget("spinner-width"));
			_widthSpinner.MinValue = 0f;
			_widthSpinner.MaxValue = 1000f;
			_widthSpinner.StepSize = 1f;
			_widthSpinner.NumericFormat = "0.00";
			NumericSpinnerControl widthSpinner = _widthSpinner;
			widthSpinner.OnValueChanged = (OnValueChanged<float>)Delegate.Combine(widthSpinner.OnValueChanged, (OnValueChanged<float>)delegate(float _, float value)
			{
				OnWidthValueChange(value);
			});
			_heightSpinner = new NumericSpinnerControl(base.Widget.FindWidget("spinner-height"));
			_heightSpinner.MinValue = 0f;
			_heightSpinner.MaxValue = 1000f;
			_heightSpinner.StepSize = 1f;
			_heightSpinner.NumericFormat = "0.00";
			NumericSpinnerControl heightSpinner = _heightSpinner;
			heightSpinner.OnValueChanged = (OnValueChanged<float>)Delegate.Combine(heightSpinner.OnValueChanged, (OnValueChanged<float>)delegate(float _, float value)
			{
				OnHeightValueChange(value);
			});
			_moveButton = base.Widget.FindWidget<ButtonWidget>("move-button");
			_showButton = base.Widget.FindWidget<ButtonWidget>("show-button");
			_blueprintsHeader = base.Widget.FindWidget("blueprint-header").GetComponentInChildren<HeaderScript>();
			_optionsIfImageSelected = base.Widget.FindWidget("options-image");
			_optionsIfNoImageSelected = base.Widget.FindWidget("options-no-image");
			_optionsIfImageSelected.Visible = false;
			_optionsIfNoImageSelected.Visible = false;
			_blueprintsHeader.Widget.Visible = false;
			_designer.CraftSaved += OnCraftSaved;
		}

		public void SaveSettings()
		{
			if (!_settingsLoaded)
			{
				return;
			}
			try
			{
				XElement xElement = new XElement("BlueprintsSettings");
				XDocument xDocument = new XDocument(xElement);
				foreach (BlueprintScript blueprint in _blueprints)
				{
					xElement.Add(blueprint.CreateXml());
				}
				string pathForDocument = Game.Instance.GetPathForDocument("Blueprints");
				if (!Directory.Exists(pathForDocument))
				{
					Directory.CreateDirectory(pathForDocument);
				}
				string pathForDocument2 = Game.Instance.GetPathForDocument("Blueprints/config.xml");
				xDocument.Save(pathForDocument2);
			}
			catch (Exception ex)
			{
				Debug.LogError("Error saving blueprints:\n" + ex.ToString());
			}
		}

		public void ShowViewAngle(Vector3 direction, Vector3 up)
		{
			Transform transform = Camera.main.transform;
			transform.localPosition = direction * transform.localPosition.magnitude;
			transform.LookAt(transform.parent.position, up);
			_designer.Environment.ShowPlatform(direction.y >= 0f);
			_designer.CameraController.IsOrthographic = true;
			base.DesignerUI.UpdateOrthographicButton();
		}

		protected virtual void Update()
		{
			string directionName = GetDirectionName(Camera.main.transform.localPosition);
			BlueprintScript blueprintScript = null;
			SelectDirection(directionName);
			if (directionName != null)
			{
				blueprintScript = GetActiveBlueprintScript();
			}
			if (blueprintScript != _trackedBlueprint)
			{
				_trackedBlueprint = blueprintScript;
				UpdateButtonStates();
				UpdateSizeSpinners();
			}
			bool flag = _trackedBlueprint != null;
			_optionsIfImageSelected.Visible = flag && directionName != null;
			_optionsIfNoImageSelected.Visible = !flag && directionName != null;
			if (blueprintScript != null && blueprintScript.Name == "Top")
			{
				_designer.Environment.OverrideHidePlatform = true;
			}
			else
			{
				_designer.Environment.OverrideHidePlatform = false;
			}
		}

		private BlueprintScript GetActiveBlueprintScript()
		{
			foreach (BlueprintScript blueprint in _blueprints)
			{
				if (blueprint.IsAligned)
				{
					return blueprint;
				}
			}
			return null;
		}

		private Widget GetDirectionButton(string direction)
		{
			return base.Widget.FindWidget("view-" + _direction.ToLower());
		}

		private void Imagepicker_Completed(string path)
		{
			LoadImage(path, Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer);
		}

		private BlueprintScript LoadImage(string path, bool copy = false)
		{
			if (!string.IsNullOrEmpty(path))
			{
				BlueprintScript blueprintScript = new GameObject("Blueprint").AddComponent<BlueprintScript>();
				string directionName = GetDirectionName(Camera.main.transform.localPosition);
				blueprintScript.Setup(directionName, path, Camera.main.transform.rotation, this, copy);
				_blueprints.Add(blueprintScript);
				GetDirectionButton(directionName).AddClass("view-loaded");
				return blueprintScript;
			}
			return null;
		}

		private void OnCraftSaved()
		{
			SaveSettings();
		}

		private void OnDeleteButtonClicked(Widget widget)
		{
			if (_trackedBlueprint != null)
			{
				GetDirectionButton(_trackedBlueprint.Name).RemoveClass("btn-success");
				UnityEngine.Object.Destroy(_trackedBlueprint.gameObject);
				_blueprints.Remove(_trackedBlueprint);
			}
		}

		private void OnFlyoutOpened(IFlyout flyout)
		{
			if (!_settingsLoaded)
			{
				RestoreSettings();
				_settingsLoaded = true;
			}
		}

		private void OnHeightValueChange(float value)
		{
			if (_trackedBlueprint != null)
			{
				_trackedBlueprint.SetHeight(value);
				UpdateSizeSpinners(width: true, height: false);
			}
		}

		private void OnMirrorButtonClicked(Widget widget)
		{
			if (_trackedBlueprint != null)
			{
				_trackedBlueprint.Flipped = !_trackedBlueprint.Flipped;
			}
		}

		private void OnMoveButtonClicked(Widget widget)
		{
			if (_dragBlueprintTool.IsSelected)
			{
				_designer.Tools.SelectMovePartTool();
			}
			else
			{
				_dragBlueprintTool.Setup(_trackedBlueprint);
				_designer.Tools.SelectTool(_dragBlueprintTool);
			}
			UpdateButtonStates();
		}

		private void OnOpenImageButtonClicked(Widget widget)
		{
			if (GetDirectionName(Camera.main.transform.localPosition) == null)
			{
				return;
			}
			ExtensionFilter[] extensions = new ExtensionFilter[1]
			{
				new ExtensionFilter("Image", "png", "jpg", "jpeg")
			};
			StandaloneFileBrowser.OpenFilePanelAsync("Choose image", System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyPictures), extensions, multiselect: false, delegate(string[] paths)
			{
				if (paths.Length != 0)
				{
					LoadImage(paths[0], copy: true);
				}
			});
		}

		private void OnRotateButtonClicked(Widget widget)
		{
			if (_trackedBlueprint != null)
			{
				_trackedBlueprint.Rotation += 90f;
			}
		}

		private void OnShowBackButtonClicked(Widget widget)
		{
			ShowViewAngle(Vector3.back, Vector3.up);
		}

		private void OnShowBottomButtonClicked(Widget widget)
		{
			ShowViewAngle(Vector3.down, Vector3.forward);
		}

		private void OnShowButtonClicked(Widget widget)
		{
			if (_trackedBlueprint != null)
			{
				_trackedBlueprint.OverrideDisable = !_trackedBlueprint.OverrideDisable;
			}
			UpdateButtonStates();
		}

		private void OnShowFrontButtonClicked(Widget widget)
		{
			ShowViewAngle(Vector3.forward, Vector3.up);
		}

		private void OnShowLeftButtonClicked(Widget widget)
		{
			ShowViewAngle(Vector3.left, Vector3.up);
		}

		private void OnShowRightButtonClicked(Widget widget)
		{
			ShowViewAngle(Vector3.right, Vector3.up);
		}

		private void OnShowTopButtonClicked(Widget widget)
		{
			ShowViewAngle(Vector3.up, Vector3.forward);
		}

		private void OnWidthValueChange(float value)
		{
			if (_trackedBlueprint != null)
			{
				_trackedBlueprint.SetWidth(value);
				UpdateSizeSpinners(width: false);
			}
		}

		private void RestoreBlueprint(XElement xml)
		{
			GameObject gameObject = new GameObject("Blueprint");
			BlueprintScript blueprintScript = gameObject.AddComponent<BlueprintScript>();
			if (blueprintScript.Setup(xml, this))
			{
				_blueprints.Add(blueprintScript);
				return;
			}
			Debug.LogError("Blueprint failed to load:\n" + xml.ToString());
			UnityEngine.Object.Destroy(gameObject);
		}

		private void RestoreSettings()
		{
			string pathForDocument = Game.Instance.GetPathForDocument("Blueprints/config.xml");
			if (!File.Exists(pathForDocument))
			{
				return;
			}
			XElement xElement = XDocument.Load(pathForDocument).Element("BlueprintsSettings");
			if (xElement == null)
			{
				return;
			}
			foreach (XElement item in xElement.Elements("Blueprint"))
			{
				RestoreBlueprint(item);
			}
		}

		private void SelectDirection(string direction)
		{
			if (_direction != direction)
			{
				if (_direction != null)
				{
					GetDirectionButton(_direction).RemoveClass("view-selected");
				}
				_direction = direction;
				if (_direction != null)
				{
					GetDirectionButton(_direction).AddClass("view-selected");
					_blueprintsHeader.Widget.Visible = true;
					_blueprintsHeader.LabelText = direction;
				}
				else
				{
					_blueprintsHeader.Widget.Visible = false;
				}
			}
		}

		private void UpdateButtonStates()
		{
			_moveButton.EnableClass("btn-primary", _dragBlueprintTool.IsSelected);
			ButtonWidget showButton = _showButton;
			BlueprintScript trackedBlueprint = _trackedBlueprint;
			showButton.EnableClass("btn-primary", (object)trackedBlueprint == null || !trackedBlueprint.OverrideDisable);
		}

		private void UpdateSizeSpinners(bool width = true, bool height = true)
		{
			if (_trackedBlueprint != null)
			{
				if (width)
				{
					_widthSpinner.Value = _trackedBlueprint.Size.x;
				}
				if (height)
				{
					_heightSpinner.Value = _trackedBlueprint.Size.y;
				}
			}
		}
	}
}
