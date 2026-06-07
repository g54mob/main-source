using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Xml.Tags
{
	public class TextMeshProTagHandler : ElementTagHandler
	{
		public override MonoBehaviour primaryComponent
		{
			get
			{
				if (base.currentInstanceTransform == null)
				{
					return null;
				}
				return base.currentInstanceTransform.GetComponent<TextMeshProUGUI>();
			}
		}

		public override string prefabPath => null;

		public override bool isCustomElement => true;

		public override Dictionary<string, string> attributes
		{
			get
			{
				Dictionary<string, string> obj = new Dictionary<string, string>
				{
					{ "text", "xs:string" },
					{ "font", "xs:string" },
					{ "fontStyle", "xs:string" },
					{ "fontSize", "xs:float" },
					{ "fontWeight", "xs:int" },
					{ "fontSizeMin", "xs:float" },
					{ "fontSizeMax", "xs:float" },
					{ "fontScale", "xs:float" },
					{ "enableAutoSizing", "xs:boolean" },
					{ "characterSpacing", "xs:float" },
					{ "characterWidthAdjustment", "xs:float" },
					{ "alpha", "xs:float" },
					{ "autoSizeTextContainer", "xs:boolean" },
					{ "color", "xmlLayout:color" },
					{ "faceColor", "xmlLayout:color" },
					{ "outlineColor", "xmlLayout:color" },
					{ "outlineWidth", "xs:float" },
					{ "fontMaterial", "xs:string" },
					{ "enableWordWrapping", "xs:boolean" },
					{ "wordWrappingRatios", "xs:float" },
					{ "extraPadding", "xs:boolean" },
					{ "wordSpacing", "xs:float" },
					{ "lineSpacing", "xs:float" },
					{ "lineSpacingAdjustment", "xs:float" },
					{ "paragraphSpacing", "xs:float" },
					{ "margin", "xmlLayout:vector4" },
					{ "firstVisibleCharacter", "xs:int" },
					{ "maxVisibleWords", "xs:int" },
					{ "colorGradient", "xmlLayout:colorblock" },
					{ "overrideColorTags", "xs:boolean" },
					{ "enableKerning", "xs:boolean" },
					{ "geometrySorting", "Normal,Reverse" },
					{ "enableCulling", "xs:boolean" },
					{ "richText", "xs:boolean" },
					{ "useMaxVisibleDescender", "xs:boolean" },
					{ "tintAllSprites", "xs:boolean" },
					{ "spriteAsset", "xs:string" },
					{ "parseCtrlCharacters", "xs:boolean" },
					{ "pageToDisplay", "xs:int" },
					{ "pixelsPerUnit", "xs:float" },
					{ "raycastTarget", "xs:boolean" },
					{
						"alignment",
						string.Join(",", Enum.GetNames(typeof(TextAlignmentOptions)))
					}
				};
				string value = string.Join(",", Enum.GetNames(typeof(TextureMappingOptions)));
				obj.Add("horizontalMapping", value);
				obj.Add("verticalMapping", value);
				obj.Add("overflowMode", string.Join(",", Enum.GetNames(typeof(TextOverflowModes))));
				return obj;
			}
		}

		static TextMeshProTagHandler()
		{
			RegisterCustomTypeHandlers();
		}

		public override void ApplyAttributes(AttributeDictionary attributesToApply)
		{
			if (base.currentInstanceTransform == null)
			{
				return;
			}
			if (base.currentXmlElement.name == "GameObject" || base.currentXmlElement.name == "Xml Element")
			{
				base.currentXmlElement.name = "TextMesh Pro";
			}
			GameObject gameObject = base.currentInstanceTransform.gameObject;
			TextMeshProUGUI textMeshProUGUI = gameObject.GetComponent<TextMeshProUGUI>() ?? gameObject.AddComponent<TextMeshProUGUI>();
			if (textMeshProUGUI.GetComponent<LayoutElement>() == null)
			{
				textMeshProUGUI.gameObject.AddComponent<LayoutElement>();
			}
			if (!attributesToApply.ContainsKey("dontMatchParentDimensions") && !base.currentXmlElement.HasAttribute("delayedProcessingScheduled"))
			{
				MatchParentDimensions();
			}
			if (!attributesToApply.ContainsKey("alignment") && !base.currentXmlElement.attributes.ContainsKey("alignment"))
			{
				textMeshProUGUI.alignment = TextAlignmentOptions.Center;
			}
			if (!attributesToApply.ContainsKey("fontSize") && !base.currentXmlElement.attributes.ContainsKey("fontSize"))
			{
				textMeshProUGUI.fontSize = 14f;
			}
			Material material = null;
			if (attributesToApply.ContainsKey("fontMaterial") && base.currentXmlLayoutInstance.textMeshProMaterials.ContainsKey(attributesToApply["fontMaterial"]))
			{
				material = base.currentXmlLayoutInstance.textMeshProMaterials[attributesToApply["fontMaterial"]];
				attributesToApply.Remove("fontMaterial");
			}
			base.ApplyAttributes(attributesToApply);
			if (material != null)
			{
				textMeshProUGUI.fontMaterial = material;
			}
			if (attributesToApply.ContainsKey("colorGradient"))
			{
				textMeshProUGUI.enableVertexGradient = true;
			}
			if (attributesToApply.ContainsKey("text"))
			{
				textMeshProUGUI.text = StringExtensions.DecodeEncodedNonAsciiCharacters(attributesToApply["text"]);
			}
			if (!base.currentXmlElement.HasAttribute("delayedProcessingScheduled"))
			{
				XmlElement _currentElement = base.currentXmlElement;
				XmlLayoutTimer.AtEndOfFrame(delegate
				{
					if (_currentElement != null)
					{
						_currentElement.ApplyAttributes();
					}
				}, _currentElement, forceEvenIfObjectIsInactive: true);
				base.currentXmlElement.attributes.AddIfKeyNotExists("delayedProcessingScheduled", "true");
			}
			else
			{
				if (!attributesToApply.ContainsKey("color") || attributesToApply.ContainsKey("delayedColorSet"))
				{
					return;
				}
				XmlElement _currentElement2 = base.currentXmlElement;
				XmlLayoutTimer.AtEndOfFrame(delegate
				{
					if (!(_currentElement2 == null))
					{
						_currentElement2.ApplyAttributes(new Dictionary<string, string>
						{
							{
								"color",
								attributesToApply["color"]
							},
							{ "delayedColorSet", "1" }
						});
						_currentElement2.RemoveAttribute("delayedColorSet");
					}
				}, _currentElement2, forceEvenIfObjectIsInactive: true);
			}
		}

		private static void RegisterCustomTypeHandlers()
		{
			ConversionExtensions.RegisterCustomTypeConverter(typeof(TMP_FontAsset), delegate(string value, XmlLayout xmlLayout)
			{
				TMP_FontAsset tMP_FontAsset = XmlLayoutUtilities.LoadResource<TMP_FontAsset>(value);
				if (tMP_FontAsset == null)
				{
					Debug.LogWarning("[XmlLayout][TextMesh Pro] Unable to load TMP Font Asset '" + value + "'.");
				}
				return tMP_FontAsset;
			});
			ConversionExtensions.RegisterCustomTypeConverter(typeof(FontStyles), delegate(string value)
			{
				string[] array = value.Split('|');
				FontStyles fontStyles = FontStyles.Normal;
				string[] array2 = array;
				foreach (string value2 in array2)
				{
					try
					{
						FontStyles fontStyles2 = (FontStyles)Enum.Parse(typeof(FontStyles), value2);
						fontStyles |= fontStyles2;
					}
					catch
					{
					}
				}
				return fontStyles;
			});
			ConversionExtensions.RegisterCustomTypeConverter(typeof(VertexGradient), delegate(string value, XmlLayout xmlLayout)
			{
				ColorBlock colorBlock = value.ToColorBlock(xmlLayout);
				return new VertexGradient(colorBlock.normalColor, colorBlock.highlightedColor, colorBlock.pressedColor, colorBlock.disabledColor);
			});
			ConversionExtensions.RegisterCustomTypeConverter(typeof(TMP_SpriteAsset), delegate(string value)
			{
				TMP_SpriteAsset tMP_SpriteAsset = XmlLayoutUtilities.LoadResource<TMP_SpriteAsset>(value);
				if (tMP_SpriteAsset == null)
				{
					Debug.LogWarning("[XmlLayout][TextMesh Pro] Unable to load TMP Sprite Asset '" + value + "'.");
				}
				return tMP_SpriteAsset;
			});
		}
	}
}
