using System;
using System.Collections.Generic;
using Assets.Scripts.Ui;
using ModApi;
using ModApi.Common.Collections;
using ModApi.Craft.Parts;
using ModApi.Craft.Parts.Styles;
using ModApi.Design;
using ModApi.Design.PartProperties;
using TMPro;
using UI.Xml;
using UnityEngine;

namespace Assets.Scripts.Design.PartProperties
{
	public class StylePartProperties : PartPropertiesScript
	{
		private IPartStyle _customStyle;

		private IPartTextureStyle _customTextureStyle;

		private Dictionary<string, Vector4> _defaultStyleData;

		private PartPropertiesFlyoutScript _flyout;

		private TextMeshProUGUI _header;

		private int _numLockedPartStyles;

		private IPartScript _selectedPart;

		private SpinnerScript _styleSpinner;

		private TextMeshProUGUI _styleSpinnerLabel;

		private bool _styleSpinnerVisible;

		private bool _textureDataVisible;

		private SpinnerScript _textureOffsetXSpinner;

		private SpinnerScript _textureOffsetYSpinner;

		private bool _textureSpinnerVisible;

		private SpinnerScript _textureStyleSpinner;

		private TextMeshProUGUI _textureStyleSpinnerLabel;

		private SpinnerScript _textureTileXSpinner;

		private SpinnerScript _textureTileYSpinner;

		public int SubpartIndex => base.ModifierIndex;

		public override void OnPartDeselected(IPartScript part)
		{
			base.OnPartDeselected(part);
			_selectedPart = null;
			_customStyle = null;
			_customTextureStyle = null;
			_defaultStyleData.Clear();
		}

		public override bool OnPartSelected(IPartScript part)
		{
			if (SubpartIndex >= part.Data.Styles.Count)
			{
				return false;
			}
			_selectedPart = part;
			PartStyleData partStyleData = part.Data.Styles[SubpartIndex];
			bool subpartsSharePartStyle = part.Data.PartType.SubpartsSharePartStyle;
			_header.text = (subpartsSharePartStyle ? "Part" : part.Data.PartType.Subparts[SubpartIndex].DisplayName) + " Style";
			_header.transform.parent.parent.gameObject.SetActive(!subpartsSharePartStyle || SubpartIndex == 0);
			_styleSpinnerLabel.text = "Style";
			_textureStyleSpinnerLabel.text = (subpartsSharePartStyle ? part.Data.PartType.Subparts[SubpartIndex].DisplayName : "Texture");
			UpdateStyleSpinner(keepCurrentSelection: true);
			UpdateTextureStyleSpinner(keepCurrentSelection: true);
			if (!UpdateVisibilities(partStyleData))
			{
				return false;
			}
			_textureTileXSpinner.SetNumericValue(partStyleData.TextureTiling.x);
			_textureTileYSpinner.SetNumericValue(partStyleData.TextureTiling.y);
			_textureOffsetXSpinner.SetNumericValue(partStyleData.TextureOffset.x);
			_textureOffsetYSpinner.SetNumericValue(partStyleData.TextureOffset.y);
			return true;
		}

		public void RefreshTextureStyles()
		{
			if (_selectedPart != null)
			{
				UpdateTextureStyleSpinner(keepCurrentSelection: false);
				UpdateTextureStyle(_textureStyleSpinner.Value);
				bool visible = UpdateVisibilities(_selectedPart.Data.Styles[SubpartIndex]);
				SetVisible(visible);
			}
		}

		protected virtual void OnDestroy()
		{
			if (SubpartIndex == 0)
			{
				PartPropertiesFlyoutScript partPropertiesFlyoutScript = base.Flyout as PartPropertiesFlyoutScript;
				if (partPropertiesFlyoutScript != null)
				{
					partPropertiesFlyoutScript.PartSelectionComplete -= OnPartSelectionCompleted;
				}
			}
		}

		protected override void OnInitialized()
		{
			base.OnInitialized();
			_flyout = (PartPropertiesFlyoutScript)base.Flyout;
			XmlLayout xmlLayout = _flyout.xmlLayout;
			XmlElement elementById = xmlLayout.GetElementById("style-header");
			_header = elementById.GetElementByInternalId<TextMeshProUGUI>("label");
			elementById.gameObject.AddComponent<HeaderScript>().Initialize(elementById);
			_defaultStyleData = new Dictionary<string, Vector4>();
			InitializeTextSpinner(xmlLayout, "style", UpdateStyle, GetStyleDisplayName, ref _styleSpinner, ref _styleSpinnerLabel);
			InitializeTextSpinner(xmlLayout, "texture-style", UpdateTextureStyle, GetTextureStyleDisplayName, ref _textureStyleSpinner, ref _textureStyleSpinnerLabel);
			_textureTileXSpinner = InitializeNumericSpinner(xmlLayout, "texture-tile-x", UpdateTilingX);
			_textureTileYSpinner = InitializeNumericSpinner(xmlLayout, "texture-tile-y", UpdateTilingY);
			_textureOffsetXSpinner = InitializeNumericSpinner(xmlLayout, "texture-offset-x", UpdateOffsetX);
			_textureOffsetYSpinner = InitializeNumericSpinner(xmlLayout, "texture-offset-y", UpdateOffsetY);
			if (SubpartIndex == 0)
			{
				_flyout.PartSelectionComplete += OnPartSelectionCompleted;
			}
		}

		private IPartStyle GetStyle(string styleId)
		{
			if (_customStyle != null && _customStyle.Id == styleId)
			{
				return _customStyle;
			}
			return Game.Instance.PartStyleManager.GetStyle(_selectedPart.Data.PartType.Id, SubpartIndex, styleId);
		}

		private string GetStyleDisplayName(string styleId)
		{
			return GetStyle(styleId).DisplayName;
		}

		private IPartTextureStyle GetTextureStyle(string styleId)
		{
			if (_customTextureStyle != null && _customTextureStyle.Id == styleId)
			{
				return _customTextureStyle;
			}
			IPartStyleManager partStyleManager = Game.Instance.PartStyleManager;
			return partStyleManager.GetTextureStyle(styleId) ?? partStyleManager.DefaultTextureStyle;
		}

		private string GetTextureStyleDisplayName(string styleId)
		{
			if (_customTextureStyle != null && _customTextureStyle.Id == styleId)
			{
				return styleId;
			}
			return GetTextureStyle(styleId).DisplayName;
		}

		private SpinnerScript InitializeNumericSpinner(XmlLayout layout, string id, Action<float> onValueChanged)
		{
			XmlElement elementById = layout.GetElementById(id);
			SpinnerScript elementByInternalId = elementById.GetElementByInternalId<SpinnerScript>("spinner");
			elementByInternalId.SpinnerType = SpinnerType.Numeric;
			elementByInternalId.OnNumericValueChanged = onValueChanged;
			elementById.gameObject.AddComponent<PropertyRowScript>();
			return elementByInternalId;
		}

		private void InitializeTextSpinner(XmlLayout layout, string id, Action<string> onValueChanged, Func<string, string> onLabelRequested, ref SpinnerScript spinner, ref TextMeshProUGUI label)
		{
			XmlElement elementById = layout.GetElementById(id);
			spinner = elementById.GetElementByInternalId<SpinnerScript>("spinner");
			label = elementById.GetElementByInternalId<TextMeshProUGUI>("label");
			spinner.SpinnerType = SpinnerType.Text;
			spinner.OnValueChanged = onValueChanged;
			spinner.OnLabelRequested = onLabelRequested;
			elementById.gameObject.AddComponent<PropertyRowScript>();
		}

		private void OnPartSelectionCompleted(IReadOnlyList<PartPropertiesScript> visiblePartProperties)
		{
			if (_selectedPart == null || _selectedPart.Data.Styles.Count <= 1 || _selectedPart.Data.PartType.SubpartsSharePartStyle || !_selectedPart.Data.PartType.StylesShareHeader)
			{
				return;
			}
			bool flag = false;
			for (int i = 0; i < visiblePartProperties.Count; i++)
			{
				StylePartProperties stylePartProperties = visiblePartProperties[i] as StylePartProperties;
				if (!(stylePartProperties == null))
				{
					if (flag)
					{
						stylePartProperties._header.transform.parent.gameObject.SetActive(value: false);
					}
					else
					{
						stylePartProperties._header.text = "Part Style";
						stylePartProperties._header.transform.parent.gameObject.SetActive(value: true);
						flag = true;
					}
					SubpartType subpartType = stylePartProperties._selectedPart.Data.PartType.Subparts[stylePartProperties.SubpartIndex];
					if (stylePartProperties._styleSpinnerVisible)
					{
						stylePartProperties._styleSpinnerLabel.text = subpartType.DisplayName;
					}
					else if (stylePartProperties._textureSpinnerVisible)
					{
						stylePartProperties._textureStyleSpinnerLabel.text = subpartType.DisplayName;
					}
				}
			}
		}

		private void RaiseOnStyleChanged(IPartStyle previousStyle, IPartStyle newStyle)
		{
			foreach (PartModifierData modifier in _selectedPart.Data.Modifiers)
			{
				((IDesignerPartModifierData)modifier).DesignerPartProperties.OnPartStyleChanged(previousStyle, newStyle);
			}
		}

		private void RaiseOnTextureStyleChanged(IPartTextureStyle previousStyle, IPartTextureStyle newStyle)
		{
			foreach (PartModifierData modifier in _selectedPart.Data.Modifiers)
			{
				((IDesignerPartModifierData)modifier).DesignerPartProperties.OnPartTextureStyleChanged(previousStyle, newStyle);
			}
		}

		private void SetDefaultTextureTilingAndOffset(PartStyleData styleData)
		{
			Vector4 vector = new Vector4(1f, 1f, 0f, 0f);
			if (_defaultStyleData.ContainsKey(styleData.TextureStyle.Id))
			{
				vector = _defaultStyleData[styleData.TextureStyle.Id];
			}
			styleData.TextureTiling = new Vector2(vector.x, vector.y);
			styleData.TextureOffset = new Vector2(vector.z, vector.w);
			_textureTileXSpinner.SetNumericValue(vector.x);
			_textureTileYSpinner.SetNumericValue(vector.y);
			_textureOffsetXSpinner.SetNumericValue(vector.z);
			_textureOffsetYSpinner.SetNumericValue(vector.w);
		}

		private void UpdateDefaultTextureTilingAndOffset(PartStyleData styleData)
		{
			_defaultStyleData[styleData.TextureStyle.Id] = new Vector4(styleData.TextureTiling.x, styleData.TextureTiling.y, styleData.TextureOffset.x, styleData.TextureOffset.y);
		}

		private void UpdateOffsetX(float value)
		{
			PartStyleData partStyleData = _selectedPart.Data.Styles[SubpartIndex];
			partStyleData.TextureOffset = new Vector2(value, partStyleData.TextureOffset.y);
			UpdatePartMaterials();
			Symmetry.SynchronizePartStyles(_selectedPart, null);
		}

		private void UpdateOffsetY(float value)
		{
			PartStyleData partStyleData = _selectedPart.Data.Styles[SubpartIndex];
			partStyleData.TextureOffset = new Vector2(partStyleData.TextureOffset.x, value);
			UpdatePartMaterials();
			Symmetry.SynchronizePartStyles(_selectedPart, null);
		}

		private void UpdatePartMaterials()
		{
			PartPropertiesFlyoutScript.ChangesSinceLastUndoStep = true;
			_selectedPart.PartMaterialScript.UpdateTextureData();
		}

		private void UpdateStyle(string styleId)
		{
			PartData data = _selectedPart.Data;
			PartType partType = data.PartType;
			PartStyleData partStyleData = data.Styles[SubpartIndex];
			IPartStyle style = partStyleData.Style;
			IPartTextureStyle textureStyle = partStyleData.TextureStyle;
			IPartStyle newStyle = (partStyleData.Style = GetStyle(styleId));
			UpdateTextureStyleSpinner(keepCurrentSelection: false);
			IPartTextureStyle partTextureStyle = (partStyleData.TextureStyle = GetTextureStyle(_textureStyleSpinner.Value));
			UpdateTextureDataVisibility(partStyleData);
			RaiseOnStyleChanged(style, newStyle);
			if (textureStyle != partTextureStyle)
			{
				RaiseOnTextureStyleChanged(textureStyle, partTextureStyle);
			}
			if (partType.SubpartsSharePartStyle)
			{
				if (SubpartIndex != 0)
				{
					return;
				}
				IReadOnlyList<StylePartProperties> stylePartProperties = _flyout.StylePartProperties;
				for (int i = 1; i < partType.Subparts.Count; i++)
				{
					stylePartProperties[i].UpdateStyle(styleId);
					stylePartProperties[i].UpdateStyleSpinner(keepCurrentSelection: false);
				}
			}
			UpdatePartMaterials();
			UpdateVisibilities(_selectedPart.Data.Styles[SubpartIndex]);
			Symmetry.SynchronizePartStyles(_selectedPart, null);
		}

		private void UpdateStyleSpinner(bool keepCurrentSelection)
		{
			IPartStyleManager partStyleManager = Game.Instance.PartStyleManager;
			PartData data = _selectedPart.Data;
			PartStyleData partStyleData = data.Styles[SubpartIndex];
			CircularList<string> values = _styleSpinner.Values;
			values.Clear();
			_numLockedPartStyles = 0;
			foreach (IPartStyle style in partStyleManager.GetStyles(data.PartType.Id, SubpartIndex))
			{
				if (!style.Hidden)
				{
					if (Game.Instance.GameState.Validator.IsPartStyleAvailable(data, style))
					{
						values.Add(style.Id);
					}
					else
					{
						_numLockedPartStyles++;
					}
				}
			}
			string text = partStyleData.Style.Id;
			if (values.GetIndexOfValue(text) < 0)
			{
				if (keepCurrentSelection)
				{
					_customStyle = partStyleData.Style;
					values.Add(text);
				}
				else
				{
					text = ((values.Count > 0) ? values[0] : partStyleManager.DefaultStyle.Id);
				}
			}
			_styleSpinner.Value = text;
		}

		private bool UpdateTextureDataVisibility(PartStyleData styleData)
		{
			bool flag = _textureSpinnerVisible && (styleData.TextureStyle.Options.HasFlag(PartTextureStyleOptions.DesignerTileableX) || !Mathf.Approximately(styleData.TextureTiling.x, 1f) || !Mathf.Approximately(styleData.TextureOffset.x, 0f));
			bool flag2 = _textureSpinnerVisible && (styleData.TextureStyle.Options.HasFlag(PartTextureStyleOptions.DesignerTileableY) || !Mathf.Approximately(styleData.TextureTiling.y, 1f) || !Mathf.Approximately(styleData.TextureOffset.y, 0f));
			Utilities.GetComponentInParent<PropertyRowScript>(_textureTileXSpinner.transform).Visible = flag;
			Utilities.GetComponentInParent<PropertyRowScript>(_textureOffsetXSpinner.transform).Visible = flag;
			Utilities.GetComponentInParent<PropertyRowScript>(_textureTileYSpinner.transform).Visible = flag2;
			Utilities.GetComponentInParent<PropertyRowScript>(_textureOffsetYSpinner.transform).Visible = flag2;
			return flag || flag2;
		}

		private void UpdateTextureStyle(string styleId)
		{
			PartStyleData partStyleData = _selectedPart.Data.Styles[SubpartIndex];
			IPartTextureStyle textureStyle = partStyleData.TextureStyle;
			UpdateDefaultTextureTilingAndOffset(partStyleData);
			IPartTextureStyle newStyle = (partStyleData.TextureStyle = GetTextureStyle(styleId));
			SetDefaultTextureTilingAndOffset(partStyleData);
			UpdateTextureDataVisibility(partStyleData);
			RaiseOnTextureStyleChanged(textureStyle, newStyle);
			UpdatePartMaterials();
			Symmetry.SynchronizePartStyles(_selectedPart, null);
		}

		private void UpdateTextureStyleSpinner(bool keepCurrentSelection)
		{
			IPartStyleManager partStyleManager = Game.Instance.PartStyleManager;
			PartData data = _selectedPart.Data;
			PartStyleData partStyleData = data.Styles[SubpartIndex];
			CircularList<string> values = _textureStyleSpinner.Values;
			values.Clear();
			foreach (IPartTextureStyle textureStyle in partStyleManager.GetTextureStyles(data.PartType.Id, SubpartIndex, partStyleData.Style.Id))
			{
				values.Add(textureStyle.Id);
			}
			foreach (PartModifierData modifier in _selectedPart.Data.Modifiers)
			{
				if (!(modifier is IPartTextureStyleProvider partTextureStyleProvider))
				{
					continue;
				}
				IReadOnlyList<IPartTextureStyle> availablePartTextureStyles = partTextureStyleProvider.GetAvailablePartTextureStyles(data.PartType.Id, SubpartIndex, partStyleData.Style.Id);
				if (availablePartTextureStyles == null)
				{
					continue;
				}
				foreach (IPartTextureStyle item in availablePartTextureStyles)
				{
					values.Add(item.Id);
				}
			}
			string text = partStyleData.TextureStyle.Id;
			if (values.GetIndexOfValue(text) < 0)
			{
				if (keepCurrentSelection)
				{
					_customTextureStyle = partStyleData.TextureStyle;
					values.Add(text);
				}
				else
				{
					text = ((values.Count > 0) ? values[0] : partStyleManager.DefaultTextureStyle.Id);
				}
			}
			_textureStyleSpinner.Value = text;
		}

		private void UpdateTilingX(float value)
		{
			PartStyleData partStyleData = _selectedPart.Data.Styles[SubpartIndex];
			partStyleData.TextureTiling = new Vector2(value, partStyleData.TextureTiling.y);
			UpdatePartMaterials();
			Symmetry.SynchronizePartStyles(_selectedPart, null);
		}

		private void UpdateTilingY(float value)
		{
			PartStyleData partStyleData = _selectedPart.Data.Styles[SubpartIndex];
			partStyleData.TextureTiling = new Vector2(partStyleData.TextureTiling.x, value);
			UpdatePartMaterials();
			Symmetry.SynchronizePartStyles(_selectedPart, null);
		}

		private bool UpdateVisibilities(PartStyleData styleData)
		{
			if (!_selectedPart.Data.PartStyleEnabled)
			{
				return _textureDataVisible = (_textureSpinnerVisible = (_styleSpinnerVisible = false));
			}
			bool flag = _selectedPart.Data.PartType.SubpartsSharePartStyle && SubpartIndex > 0;
			_styleSpinnerVisible = !flag && (_styleSpinner.Values.Count > 1 || _numLockedPartStyles > 0);
			_textureSpinnerVisible = _textureStyleSpinner.Values.Count > 1;
			_textureDataVisible = UpdateTextureDataVisibility(styleData);
			Utilities.GetComponentInParent<PropertyRowScript>(_styleSpinner.transform).Visible = _styleSpinnerVisible;
			Utilities.GetComponentInParent<PropertyRowScript>(_textureStyleSpinner.transform).Visible = _textureSpinnerVisible;
			if (!_styleSpinnerVisible && !_textureSpinnerVisible)
			{
				return _textureDataVisible;
			}
			return true;
		}
	}
}
