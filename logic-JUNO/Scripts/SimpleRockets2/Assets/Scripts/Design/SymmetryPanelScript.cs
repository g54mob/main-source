using System;
using System.Collections.Generic;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Design.Tools;
using Assets.Scripts.Ui;
using ModApi.Craft.Parts;
using ModApi.Design;
using ModApi.Ui;
using TMPro;
using UI.Xml;
using UnityEngine;

namespace Assets.Scripts.Design
{
	public class SymmetryPanelScript : DesignerFlyoutPanelScript
	{
		private class SymmetryOption
		{
			public string Description { get; set; }

			public SymmetryMode Mode { get; set; }

			public string Name { get; set; }

			public SymmetryOption(SymmetryMode mode, string name, string description)
			{
				Mode = mode;
				Name = name;
				Description = description;
			}
		}

		private GameObject _bakeSymmetryButton;

		private TextMeshProUGUI _messageText;

		private SpinnerScript _mirrorLocationSpinner;

		private SpinnerScript _mirrorRotationSpinner;

		private MirrorCraftTool _mirrorTool;

		private GameObject _mirrorToolPanel;

		private List<SymmetryOption> _options;

		private GameObject _quickMirrorPanel;

		private SpinnerScript _radialSpinner;

		private GameObject _selectRootButton;

		private GameObject _spinnerPanel;

		private GameObject _symmetryPanel;

		public override void Initialize(DesignerUiScript designerUi)
		{
			base.Initialize(designerUi);
			base.Flyout.Opening += OnFlyoutOpening;
			base.Flyout.Closing += OnFlyoutClosing;
			designerUi.Designer.SelectedPartChanged += OnSelectedPartChanged;
			designerUi.Designer.CraftStructureChanged += OnCraftStructureChanged;
			_mirrorTool = designerUi.Designer.MirrorTool;
		}

		public override void LayoutRebuilt(ParseXmlResult parseResult)
		{
			_bakeSymmetryButton = base.xmlLayout.GetElementById("bake-symmetry-button").gameObject;
			_messageText = base.xmlLayout.GetElementById<TextMeshProUGUI>("message-text");
			_selectRootButton = base.xmlLayout.GetElementById("select-root-button").gameObject;
			_spinnerPanel = base.xmlLayout.GetElementById("spinner").gameObject;
			_radialSpinner = base.xmlLayout.GetElementById<SpinnerScript>("radial-spinner");
			SpinnerScript radialSpinner = _radialSpinner;
			radialSpinner.OnValueChanged = (Action<string>)Delegate.Combine(radialSpinner.OnValueChanged, (Action<string>)delegate(string value)
			{
				OnSpinnerValueChanged(value);
			});
			_options = new List<SymmetryOption>
			{
				new SymmetryOption(SymmetryMode.None, "Disabled", "Symmetry is currently disabled for this part"),
				new SymmetryOption(SymmetryMode.Mirror, "Mirror", "Part is cloned across the mirror plane"),
				new SymmetryOption(SymmetryMode.Radial2, "Radial x 2", "Part is radially cloned twice around its root."),
				new SymmetryOption(SymmetryMode.Radial3, "Radial x 3", "Part is radially cloned 3x around its root."),
				new SymmetryOption(SymmetryMode.Radial4, "Radial x 4", "Part is radially cloned 4x around its root."),
				new SymmetryOption(SymmetryMode.Radial5, "Radial x 5", "Part is radially cloned 5x around its root."),
				new SymmetryOption(SymmetryMode.Radial6, "Radial x 6", "Part is radially cloned 6x around its root.")
			};
			foreach (SymmetryOption option in _options)
			{
				_radialSpinner.Values.Add(option.Name);
			}
			_symmetryPanel = base.xmlLayout.GetElementById("symmetry-panel").gameObject;
			_quickMirrorPanel = base.xmlLayout.GetElementById("quick-mirror-panel").gameObject;
			_mirrorToolPanel = base.xmlLayout.GetElementById("mirror-tool-panel").gameObject;
			_mirrorRotationSpinner = base.xmlLayout.GetElementById<SpinnerScript>("mirror-rotation-spinner");
			_mirrorLocationSpinner = base.xmlLayout.GetElementById<SpinnerScript>("mirror-location-spinner");
			_mirrorRotationSpinner.SetNumericValue(0f);
			_mirrorLocationSpinner.SetNumericValue(0f);
		}

		private void EndMirrorTool()
		{
			_mirrorTool.EndMirror();
			if (_mirrorTool.Active)
			{
				base.DesignerUi.Designer.SelectTool(base.DesignerUi.Designer.MovePartTool);
			}
			ShowMirrorToolPanel(show: false);
		}

		private SymmetryMode GetSelectedPartSymmetryMode()
		{
			IPartScript selectedPart = base.DesignerUi.Designer.SelectedPart;
			if (selectedPart != null)
			{
				PartScript partScript = selectedPart as PartScript;
				if (partScript.SymmetrySlice != null)
				{
					return partScript.SymmetrySlice.SymmetryGroup.SymmetryMode;
				}
			}
			return SymmetryMode.None;
		}

		private void OnBakeSymmetryButtonClicked()
		{
			ModApi.Ui.MessageDialogScript messageDialogScript = base.DesignerUi.Designer.UserInterface.CreateMessageDialog(MessageDialogType.OkayCancel);
			messageDialogScript.MessageText = "This will solidify the current symmetry and remove on-the-fly updating of symmetric parts.";
			messageDialogScript.OkayButtonText = "OKAY";
			messageDialogScript.CancelButtonText = "CANCEL";
			messageDialogScript.OkayClicked += OnBakeSymmetryConfirmed;
		}

		private void OnBakeSymmetryConfirmed(ModApi.Ui.MessageDialogScript messageDialog)
		{
			PartScript partScript = base.DesignerUi.Designer.SelectedPart as PartScript;
			if (partScript != null && partScript.SymmetrySlice != null)
			{
				base.DesignerUi.Designer.CreateUndoStep();
				Symmetry.RemoveSymmetryGroup(partScript.SymmetrySlice.SymmetryGroup);
				Refresh();
			}
			messageDialog.Close();
		}

		private void OnCraftStructureChanged()
		{
			if (base.Flyout.IsOpen)
			{
				Refresh();
			}
		}

		private void OnFlyoutClosing(IFlyout flyout)
		{
			base.DesignerUi.Designer.DesignerPlatform.MirrorPlaneEnabled = false;
			EndMirrorTool();
		}

		private void OnFlyoutOpening(IFlyout flyout)
		{
			Refresh();
		}

		private void OnMirrorConfigurationChanged()
		{
			StartMirrorTool();
		}

		private void OnMirrorCraftButtonClicked(bool mirrorToRight)
		{
			if (mirrorToRight)
			{
				_mirrorTool.QuickMirrorToRight();
			}
			else
			{
				_mirrorTool.QuickMirrorToLeft();
			}
		}

		private void OnMirrorPartButtonClicked()
		{
			_mirrorTool.QuickMirrorSelectedPart();
		}

		private void OnMirrorToolButton()
		{
			ShowMirrorToolPanel(show: true);
			StartMirrorTool();
		}

		private void OnMirrorToolCancelButtonClicked()
		{
			ShowMirrorToolPanel(show: false);
			EndMirrorTool();
		}

		private void OnMirrorToolOkayButtonClicked()
		{
			_mirrorTool.Mirror();
			EndMirrorTool();
			base.DesignerUi.Designer.CraftScript.SetStructureChanged();
		}

		private void OnSelectedPartChanged(IPartScript oldPart, IPartScript newPart)
		{
			if (base.Flyout.IsOpen)
			{
				Refresh();
			}
		}

		private void OnSelectRootButtonClicked()
		{
			PartScript partScript = base.DesignerUi.Designer.SelectedPart as PartScript;
			if (partScript != null && partScript.SymmetrySlice != null)
			{
				IPartScript partScript2 = partScript.SymmetrySlice.SliceRootPart.PartScript;
				base.DesignerUi.Designer.SelectPart(partScript2, null, justAdded: false);
			}
		}

		private void OnSpinnerValueChanged(string value)
		{
			foreach (SymmetryOption option in _options)
			{
				if (value == option.Name)
				{
					Symmetry.SetSymmetryMode(base.DesignerUi.Designer.SelectedPart, option.Mode, base.DesignerUi);
					return;
				}
			}
			if (!int.TryParse(value, out var index))
			{
				return;
			}
			if (index > 24)
			{
				ModApi.Ui.MessageDialogScript messageDialogScript = Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.OkayCancel);
				messageDialogScript.MessageText = $"You are trying to use symmetry x{index}.<br>Are you sure that's a good idea?";
				messageDialogScript.OkayButtonText = "Sure";
				messageDialogScript.OkayClicked += delegate(ModApi.Ui.MessageDialogScript d)
				{
					if (index > 100)
					{
						d.Close();
						ModApi.Ui.MessageDialogScript messageDialogScript2 = Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.OkayCancel);
						messageDialogScript2.MessageText = $"100% sure? {index} sounds like a lot.";
						messageDialogScript2.OkayButtonText = "Absolutely";
						messageDialogScript2.OkayClicked += delegate(ModApi.Ui.MessageDialogScript messageDialogScript3)
						{
							UpdateMode();
							messageDialogScript3.Close();
						};
						messageDialogScript2.CancelClicked += delegate(ModApi.Ui.MessageDialogScript messageDialogScript3)
						{
							Refresh();
							messageDialogScript3.Close();
						};
					}
					else
					{
						UpdateMode();
						d.Close();
					}
				};
				messageDialogScript.CancelClicked += delegate(ModApi.Ui.MessageDialogScript d)
				{
					Refresh();
					d.Close();
				};
			}
			else
			{
				UpdateMode();
			}
			void UpdateMode()
			{
				SymmetryMode symmetryMode = ((index >= 2) ? (index switch
				{
					2 => SymmetryMode.Radial2, 
					3 => SymmetryMode.Radial3, 
					4 => SymmetryMode.Radial4, 
					5 => SymmetryMode.Radial5, 
					6 => SymmetryMode.Radial6, 
					_ => SymmetryMode.Custom, 
				}) : SymmetryMode.None);
				SymmetryMode symmetryMode2 = symmetryMode;
				Symmetry.SetSymmetryMode(base.DesignerUi.Designer.SelectedPart, symmetryMode2, base.DesignerUi, index);
			}
		}

		private void Refresh()
		{
			IPartScript selectedPart = base.DesignerUi.Designer.SelectedPart;
			_bakeSymmetryButton.SetActive(value: false);
			_spinnerPanel.SetActive(value: false);
			_messageText.text = string.Empty;
			_selectRootButton.SetActive(value: false);
			if (selectedPart != null)
			{
				PartScript partScript = selectedPart as PartScript;
				if (partScript.Disconnected)
				{
					_messageText.gameObject.SetActive(value: true);
					_messageText.text = "The part must be connected to the surface of a part from the Primary craft.";
				}
				else if (partScript.SymmetrySlice != null)
				{
					if (partScript.SymmetrySlice.SliceRootPart == partScript.Data)
					{
						_bakeSymmetryButton.SetActive(value: true);
						ISymmetryGroup symmetryGroup = partScript.SymmetrySlice.SymmetryGroup;
						SetSymmetryModeOption(symmetryGroup.SymmetryMode, symmetryGroup.Count);
						_spinnerPanel.SetActive(value: true);
					}
					else
					{
						_selectRootButton.SetActive(value: true);
						_messageText.gameObject.SetActive(value: true);
						_messageText.text = "This part is inheriting symmetry from a part it is connected to. Changes can only be made at the root of its symmetry chain.";
					}
				}
				else
				{
					SetSymmetryModeOption(SymmetryMode.None);
					_spinnerPanel.SetActive(value: true);
				}
			}
			else
			{
				_messageText.gameObject.SetActive(value: true);
				_messageText.text = "No part selected.";
			}
		}

		private void SetSymmetryModeOption(SymmetryMode symmetryMode, int customCount = 0)
		{
			DesignerScript designer = base.DesignerUi.Designer;
			designer.DesignerPlatform.MirrorPlaneEnabled = false;
			switch (symmetryMode)
			{
			case SymmetryMode.None:
				_radialSpinner.Value = _options[0].Name;
				_messageText.text = _options[0].Description;
				break;
			case SymmetryMode.Mirror:
				_radialSpinner.Value = _options[1].Name;
				_messageText.text = _options[1].Description;
				designer.DesignerPlatform.MirrorPlaneEnabled = true;
				break;
			default:
				_radialSpinner.Value = $"Radial x {customCount}";
				_messageText.text = $"Part is radially cloned x{customCount} around its root.";
				break;
			}
		}

		private void ShowMirrorToolPanel(bool show)
		{
			_symmetryPanel.SetActive(!show);
			_quickMirrorPanel.SetActive(!show);
			_mirrorToolPanel.SetActive(show);
		}

		private void StartMirrorTool()
		{
			if (_mirrorRotationSpinner.NumericValue < -180f)
			{
				_mirrorRotationSpinner.SetNumericValue(180f);
			}
			else if (_mirrorRotationSpinner.NumericValue > 180f)
			{
				_mirrorRotationSpinner.SetNumericValue(-180f);
			}
			base.DesignerUi.Designer.SelectTool(_mirrorTool);
			_mirrorTool.Location = (int)_mirrorLocationSpinner.NumericValue;
			_mirrorTool.Rotation = (int)_mirrorRotationSpinner.NumericValue;
			_mirrorTool.StartMirror();
			_mirrorTool.IdentifyAffectedPartsFromMirrorPlane();
		}
	}
}
