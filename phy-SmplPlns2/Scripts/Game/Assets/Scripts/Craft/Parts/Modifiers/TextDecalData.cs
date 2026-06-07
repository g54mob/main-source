using System.Xml.Linq;
using Assets.Scripts.Craft.Decals;
using Assets.Scripts.Design.PartProperties.Attributes;
using Jundroo.Common.Attributes;
using Jundroo.Common.DataTypes;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	[PartModifierDesignerHeader("Text Decal")]
	public class TextDecalData : DecalData, ICraftTextDecal, ICraftDecal
	{
		public enum FontStyle
		{
			[DisplayName("Default")]
			Default = 0,
			[DisplayName("Roboto")]
			Roboto = 1,
			[DisplayName("Military")]
			Military = 2,
			[DisplayName("14 Segment")]
			FourteenSegment = 3,
			[DisplayName("Stencil")]
			Stencil = 4
		}

		public enum HorizontalTextAlignment
		{
			Center = 2,
			Left = 1,
			Right = 4,
			Stretch = 16
		}

		public enum VerticalTextAlignment
		{
			Center = 512,
			Top = 256,
			Bottom = 1024
		}

		private class FontStyleData
		{
			public string AssetPath { get; }

			public TMP_FontAsset Font { get; }

			public Material Material { get; }

			public string MaterialPath { get; }

			public FontStyle Style { get; }

			public FontStyleData(FontStyle style, string assetPath, string materialPath)
			{
				Style = style;
				AssetPath = assetPath;
				MaterialPath = materialPath;
				Font = Game.Instance.ResourceLoader.Load<TMP_FontAsset>(assetPath);
				Material = Game.Instance.ResourceLoader.LoadMaterial(materialPath);
			}
		}

		private FontStyle _font;

		private EnumDictionary<FontStyle, FontStyleData> _fontData;

		private float _fontSize;

		private HorizontalTextAlignment _horizontalAlignment;

		private TextDecalScript _script;

		private string _text;

		private VerticalTextAlignment _verticalAlignment;

		public override CraftDecalType DecalType => CraftDecalType.Text;

		[DesignerPropertyToggleButton(new string[] { }, Label = "Font", Order = 2)]
		public FontStyle Font
		{
			get
			{
				return _font;
			}
			set
			{
				if (_font != value)
				{
					_font = value;
					SetDirty();
				}
			}
		}

		[DesignerPropertySpinner(0.5f, 1024f, 0.5f, Label = "Font Size", AllowManualEntry = true, Order = 3)]
		public float FontSize
		{
			get
			{
				return _fontSize;
			}
			set
			{
				if (_fontSize != value)
				{
					_fontSize = value;
					SetDirty();
				}
			}
		}

		[DesignerPropertyToggleButton(new string[] { }, Label = "H. Align", Order = 4)]
		public HorizontalTextAlignment HorizontalAlignment
		{
			get
			{
				return _horizontalAlignment;
			}
			set
			{
				if (_horizontalAlignment != value)
				{
					_horizontalAlignment = value;
					SetDirty();
				}
			}
		}

		HorizontalAlignmentOptions ICraftTextDecal.HorizontalAlignment => (HorizontalAlignmentOptions)HorizontalAlignment;

		[DesignerPropertyTextInput(Label = "Text", SupportsInputDialog = true, ExtraWidth = 50, Order = 1)]
		public string Text
		{
			get
			{
				return _text;
			}
			set
			{
				if (_text != value)
				{
					_text = value;
					SetDirty();
				}
			}
		}

		[DesignerPropertyToggleButton(new string[] { }, Label = "V. Align", Order = 5)]
		public VerticalTextAlignment VerticalAlignment
		{
			get
			{
				return _verticalAlignment;
			}
			set
			{
				if (_verticalAlignment != value)
				{
					_verticalAlignment = value;
					SetDirty();
				}
			}
		}

		VerticalAlignmentOptions ICraftTextDecal.VerticalAlignment => (VerticalAlignmentOptions)VerticalAlignment;

		public TextDecalData(XElement element)
			: base(element)
		{
			_fontSize = 2.5f;
		}

		public override XElement GenerateStateXml()
		{
			XElement xElement = base.GenerateStateXml();
			xElement.SetAttributeValue("text", _text);
			xElement.SetAttributeValue("font", _font);
			xElement.SetAttributeValue("fontSize", _fontSize);
			xElement.SetAttributeValue("alignV", _verticalAlignment);
			xElement.SetAttributeValue("alignH", _horizontalAlignment);
			return xElement;
		}

		public TMP_FontAsset GetFont()
		{
			return GetFontData(Font).Font;
		}

		public Material GetFontMaterial()
		{
			return GetFontData(Font).Material;
		}

		public override void RestoreFromState(XElement stateElement)
		{
			base.RestoreFromState(stateElement);
			_text = stateElement.GetStringAttribute("text");
			_font = stateElement.GetEnumAttribute("font", FontStyle.Default);
			_fontSize = stateElement.GetFloatAttribute("fontSize", 2.5f);
			_verticalAlignment = stateElement.GetEnumAttribute("alignV", VerticalTextAlignment.Center);
			_horizontalAlignment = stateElement.GetEnumAttribute("alignH", HorizontalTextAlignment.Center);
		}

		protected override DecalScript CreateAndInitializeScript(GameObject gameObject)
		{
			_script = gameObject.AddComponent<TextDecalScript>();
			_script.Initialize(this);
			return _script;
		}

		private FontStyleData GetFontData(FontStyle style)
		{
			if (_fontData == null)
			{
				_fontData = new EnumDictionary<FontStyle, FontStyleData>();
				_fontData[FontStyle.Default] = new FontStyleData(FontStyle.Default, "Fonts/Parts/LiberationSans/LiberationSans SDF (Surface)", "Fonts/Parts/LiberationSans/LiberationSans SDF (Surface) - Decal");
				_fontData[FontStyle.Roboto] = new FontStyleData(FontStyle.Roboto, "Fonts/Parts/Roboto/PartMaterial-Roboto-Regular SDF", "Fonts/Parts/Roboto/PartMaterial-Roboto-Regular SDF - Decal");
				_fontData[FontStyle.Military] = new FontStyleData(FontStyle.Military, "Fonts/Parts/PS_Jefferies/Jefferies SDF", "Fonts/Parts/PS_Jefferies/Jefferies SDF - Decal");
				_fontData[FontStyle.FourteenSegment] = new FontStyleData(FontStyle.FourteenSegment, "Fonts/Parts/DSEG-14-Classic/DSEG14Classic-Regular SDF", "Fonts/Parts/DSEG-14-Classic/DSEG14Classic-Regular SDF - Decal");
				_fontData[FontStyle.Stencil] = new FontStyleData(FontStyle.Stencil, "Fonts/Parts/AngkatanBersenjata/AngkatanBersenjata-2OD4o SDF", "Fonts/Parts/AngkatanBersenjata/AngkatanBersenjata-2OD4o SDF - Decal");
			}
			return _fontData[style];
		}
	}
}
