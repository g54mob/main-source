using System;
using Assets.Scripts.Ui;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.Ui;
using UI.Xml;
using UnityEngine;

namespace Assets.Scripts.Design.Paint
{
	public class PaintPanelScript : DesignerSubPanelScript
	{
		[SerializeField]
		private ColorButtonsPanelScript _colorButtonsPanel;

		private XmlElement _customizeButton;

		private DesignerScript _designer;

		private EditColorPanelScript _editColorPanel;

		private SpinnerScript _themeSpinner;

		public override void Initialize(DesignerUiScript designerUi)
		{
			base.Initialize(designerUi);
			_colorButtonsPanel = new ColorButtonsPanelScript();
			_colorButtonsPanel.ColorSelected += OnColorSelected;
			_editColorPanel = new EditColorPanelScript();
			_editColorPanel.ColorUpdated += OnColorUpdated;
			_designer = designerUi.Designer;
			RefreshUi();
		}

		public override void LayoutRebuilt(ParseXmlResult parseResult)
		{
			base.LayoutRebuilt(parseResult);
			if (base.DesignerUi != null)
			{
				RefreshUi();
			}
		}

		public override void OnClosed()
		{
			_colorButtonsPanel.DeselectColor();
		}

		public void OnColorPickerClicked()
		{
			_editColorPanel.ColorPicker();
		}

		public override void OnOpened()
		{
			_themeSpinner.Value = _designer.CraftScript.Data.DesignerSettings.CurrentThemeName;
			OnThemeSpinnerChanged(_themeSpinner.Value);
			_colorButtonsPanel.DeselectColor();
		}

		protected virtual void OnDestroy()
		{
			_editColorPanel?.Cleanup();
		}

		private void OnColorSelected(ColorButtonScript colorButtonScript)
		{
			_designer.PaintTool.MaterialId = ((colorButtonScript == null) ? (-1) : colorButtonScript.PartMaterial.Id);
			string currentThemeName = _designer.CraftScript.Data.DesignerSettings.CurrentThemeName;
			bool flag = colorButtonScript != null && currentThemeName == "Custom";
			_editColorPanel.Visible = flag;
			_editColorPanel.OnColorSelected(flag ? colorButtonScript : null);
		}

		private void OnColorUpdated(ColorButtonScript colorButton, bool transparencyChanged)
		{
			CraftData data = _designer.CraftScript.Data;
			data.Themes[0].Theme.UpdateThemeMaterial(colorButton.PartMaterial.Id);
			if (data.DesignerSettings.CurrentThemeName == "Custom")
			{
				data.DesignerSettings.CustomTheme.UpdateFromTheme(data.Themes[0]);
			}
			data.Themes[0].Id = Guid.NewGuid();
			if (!transparencyChanged)
			{
				return;
			}
			int id = colorButton.PartMaterial.Id;
			foreach (PartData part in Game.Instance.Designer.CraftScript.Data.Assembly.Parts)
			{
				if (part.MaterialIds.Contains(id))
				{
					part.PartScript.PartMaterialScript.OnMaterialsChanged();
				}
			}
		}

		private void OnCustomizedButtonClicked()
		{
			base.DesignerUi.Designer.CreateUndoStep("CustomizeTheme");
			ThemeData theme = Game.Instance.CraftThemes.GetTheme(_themeSpinner.Value);
			_designer.CraftScript.Data.DesignerSettings.CustomTheme.UpdateFromTheme(theme, materialsOnly: true);
			_themeSpinner.Value = "Custom";
			OnThemeSpinnerChanged(_themeSpinner.Value);
		}

		private void OnTargetSpinnerChanged(string target)
		{
			int materialLevel = 0;
			switch (target)
			{
			case "Primary":
				materialLevel = 0;
				break;
			case "Trim 1":
				materialLevel = 1;
				break;
			case "Trim 2":
				materialLevel = 2;
				break;
			case "Trim 3":
				materialLevel = 3;
				break;
			case "Trim 4":
				materialLevel = 4;
				break;
			case "All":
				materialLevel = -1;
				break;
			}
			_designer.PaintTool.MaterialLevel = materialLevel;
		}

		private void OnThemeSpinnerChanged(string themeName)
		{
			ThemeData themeData = ((themeName == "Custom") ? _designer.CraftScript.Data.DesignerSettings.CustomTheme : Game.Instance.CraftThemes.GetTheme(themeName));
			if (themeData == null)
			{
				Debug.LogErrorFormat("Theme '{0}' could not be found.", themeName ?? "null");
				return;
			}
			ICraftScript craftScript = _designer.CraftScript;
			craftScript.Data.DesignerSettings.CurrentThemeName = themeData.Name;
			craftScript.Data.Themes[0].UpdateFromTheme(themeData);
			craftScript.Data.Themes[0].Theme.RefreshAll();
			foreach (PartData part in Game.Instance.Designer.CraftScript.Data.Assembly.Parts)
			{
				part.PartScript.PartMaterialScript.OnMaterialsChanged();
			}
			_colorButtonsPanel.OnThemeChanged(themeData);
			_customizeButton.SetActive(themeName != "Custom");
		}

		private void OnUnlockTransparencyButtonClicked()
		{
			ModApi.Ui.MessageDialogScript messageDialogScript = Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.OkayCancel);
			messageDialogScript.MessageText = "Transparency is fun, but it can cause parts to render in unexpected ways, so we advise using it sparingly. Do you want to enable the transparency slider?";
			messageDialogScript.OkayClicked += delegate(ModApi.Ui.MessageDialogScript d)
			{
				d.Close();
				Game.Instance.Settings.Game.Designer.UnlockTransparencySlider.UpdateAndCommit(value: true);
				_editColorPanel.Refresh();
			};
		}

		private void RefreshUi()
		{
			_customizeButton = base.xmlLayout.GetElementById("customize-button");
			_themeSpinner = base.xmlLayout.GetElementById<SpinnerScript>("theme-spinner");
			foreach (ThemeData theme in Game.Instance.CraftThemes.Themes)
			{
				if (!theme.Hidden)
				{
					_themeSpinner.Values.Add(theme.Name);
				}
			}
			_colorButtonsPanel.OnLayoutRebuilt(base.xmlLayout);
			_editColorPanel.OnLayoutRebuilt(base.xmlLayout);
		}
	}
}
