using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

namespace UI.Xml.Tags
{
	public class TextMeshProMaterialTagHandler : ElementTagHandler
	{
		private enum BevelType
		{
			OuterBevel = 0,
			InnerBevel = 1
		}

		private static string[] floatProperties = new string[14]
		{
			"Softness", "Dilate", "Thickness", "SpeedX", "SpeedY", "Width", "Amount", "Roundness", "Clamp", "Offset",
			"OffsetX", "OffsetY", "Angle", "Power"
		};

		private static Dictionary<string, string> _shaderPropertyNames = new Dictionary<string, string>();

		public override MonoBehaviour primaryComponent => null;

		public override string prefabPath => null;

		public override bool isCustomElement => true;

		public override bool renderElement => false;

		public override string elementGroup => "defaultsOnly";

		public override string elementChildType => "none";

		public override string extension => "blank";

		public override Dictionary<string, string> attributes => new Dictionary<string, string>
		{
			{ "name", "xs:string" },
			{ "font", "xs:string" },
			{ "shader", "xs:string" },
			{ "baseMaterial", "xs:string" },
			{ "faceColor", "xmlLayout:color" },
			{ "faceSoftness", "xs:float" },
			{ "faceDilate", "xs:float" },
			{ "faceTexture", "xs:string" },
			{ "faceUVSpeedX", "xs:float" },
			{ "faceUVSpeedY", "xs:float" },
			{ "faceTextureOffset", "xmlLayout:vector2" },
			{ "faceTextureTiling", "xmlLayout:vector2" },
			{ "outlineColor", "xmlLayout:color" },
			{ "outlineTexture", "xs:string" },
			{ "outlineTextureOffset", "xmlLayout:vector2" },
			{ "outlineTextureTiling", "xmlLayout:vector2" },
			{ "outlineUVSpeedX", "xs:float" },
			{ "outlineUVSpeedY", "xs:float" },
			{ "outlineThickness", "xs:float" },
			{ "outlineSoftness", "xs:float" },
			{ "bevelType", "InnerBevel,OuterBevel" },
			{ "bevelAmount", "xs:float" },
			{ "bevelWidth", "xs:float" },
			{ "bevelOffset", "xs:float" },
			{ "bevelClamp", "xs:float" },
			{ "bevelRoundness", "xs:float" },
			{ "lightAngle", "xs:float" },
			{ "lightSpecularColor", "xmlLayout:color" },
			{ "lightSpecularPower", "xs:float" },
			{ "lightReflectivity", "xs:float" },
			{ "lightDiffuseShadow", "xs:float" },
			{ "lightAmbientShadow", "xs:float" },
			{ "bumpMapTexture", "xs:string" },
			{ "bumpMapOutlineAmount", "xs:float" },
			{ "bumpMapFaceAmount", "xs:float" },
			{ "envMapFaceColor", "xmlLayout:color" },
			{ "envMapOutlineColor", "xmlLayout:color" },
			{ "envMapCubemap", "xs:string" },
			{ "envMapMatrixRotation", "xmlLayout:vector4" },
			{ "underlayType", "None,Normal,Inner" },
			{ "underlayColor", "xmlLayout:color" },
			{ "underlayOffsetX", "xs:float" },
			{ "underlayOffsetY", "xs:float" },
			{ "underlayDilate", "xs:float" },
			{ "underlaySoftness", "xs:float" },
			{ "glowColor", "xmlLayout:color" },
			{ "glowOffset", "xs:float" },
			{ "glowInnerAmount", "xs:float" },
			{ "glowOuterAmount", "xs:float" },
			{ "glowPower", "xs:float" }
		};

		public static Material CreateMaterial(XmlLayout xmlLayout, AttributeDictionary materialAttributes)
		{
			if (!materialAttributes.ContainsKey("name"))
			{
				Debug.LogError("[XmlLayout][TextMeshProMaterial] Warning: no name defined.");
				return null;
			}
			if (!materialAttributes.ContainsKey("font") && !materialAttributes.ContainsKey("baseMaterial"))
			{
				Debug.LogError("[XmlLayout][TextMeshProMaterial] Warning: no font or baseMaterial defined.");
				return null;
			}
			Material source = null;
			if (materialAttributes.ContainsKey("font"))
			{
				TMP_FontAsset tMP_FontAsset = materialAttributes["font"].ChangeToType<TMP_FontAsset>();
				if (tMP_FontAsset == null)
				{
					return null;
				}
				source = tMP_FontAsset.material;
			}
			if (materialAttributes.ContainsKey("baseMaterial"))
			{
				source = ((!xmlLayout.textMeshProMaterials.ContainsKey(materialAttributes["baseMaterial"])) ? materialAttributes["baseMaterial"].ToMaterial() : xmlLayout.textMeshProMaterials[materialAttributes["baseMaterial"]]);
			}
			Material material = new Material(source);
			material.shaderKeywords = material.shaderKeywords;
			material.name = materialAttributes["name"];
			if (materialAttributes.ContainsKey("shader"))
			{
				material.shader = Shader.Find(materialAttributes["shader"]);
			}
			HandleShaderProperties(xmlLayout, material, materialAttributes);
			HandleShaderKeywords(material, materialAttributes);
			return material;
		}

		private static void HandleShaderProperties(XmlLayout xmlLayout, Material material, AttributeDictionary materialAttributes)
		{
			foreach (KeyValuePair<string, string> materialAttribute in materialAttributes)
			{
				if (materialAttribute.Key.EndsWith("Color"))
				{
					material.SetColor(GetShaderPropertyName(materialAttribute.Key), materialAttribute.Value.ToColor(xmlLayout));
				}
				else if (materialAttribute.Key.EndsWith("Texture"))
				{
					material.SetTexture(GetShaderPropertyName(materialAttribute.Key), materialAttribute.Value.ToTexture());
				}
				else if (materialAttribute.Key.EndsWith("TextureOffset"))
				{
					string name = GetShaderPropertyName(materialAttribute.Key).Replace("Offset", "");
					material.SetTextureOffset(name, materialAttribute.Value.ToVector2());
				}
				else if (materialAttribute.Key.EndsWith("Tiling"))
				{
					string name2 = GetShaderPropertyName(materialAttribute.Key).Replace("Tiling", "");
					material.SetTextureScale(name2, materialAttribute.Value.ToVector2());
				}
				else if (materialAttribute.Key.EndsWith("Rotation"))
				{
					material.SetVector(GetShaderPropertyName(materialAttribute.Key), materialAttribute.Value.ToVector4());
				}
				else if (materialAttribute.Key.EndsWith("Cubemap"))
				{
					material.SetTexture(GetShaderPropertyName(materialAttribute.Key), materialAttribute.Value.ToCubeMap());
				}
				else if (materialAttribute.Key.EndsWithAny(floatProperties) || materialAttribute.Key.StartsWith("light"))
				{
					material.SetFloat(GetShaderPropertyName(materialAttribute.Key), materialAttribute.Value.ToFloat());
				}
			}
		}

		private static void HandleShaderKeywords(Material material, AttributeDictionary materialAttributes)
		{
			if (materialAttributes.Any((KeyValuePair<string, string> a) => a.Key.Contains("bevel")))
			{
				material.EnableKeyword("BEVEL_ON");
			}
			if (materialAttributes.Any((KeyValuePair<string, string> a) => a.Key.StartsWith("underlay")))
			{
				string value = materialAttributes.GetValue("underlayType");
				if (value == "Inner")
				{
					material.EnableKeyword("UNDERLAY_INNER");
				}
				else if (value != "None")
				{
					material.EnableKeyword("UNDERLAY_ON");
				}
			}
			if (materialAttributes.Any((KeyValuePair<string, string> a) => a.Key.StartsWith("glow")))
			{
				material.EnableKeyword("GLOW_ON");
			}
			if (materialAttributes.ContainsKey("bevelType"))
			{
				object obj = Enum.Parse(typeof(BevelType), materialAttributes["bevelType"]);
				material.SetFloat("_ShaderFlags", (int)obj);
			}
		}

		private static string GetShaderPropertyName(string attributeName)
		{
			if (_shaderPropertyNames.ContainsKey(attributeName))
			{
				return _shaderPropertyNames[attributeName];
			}
			string text = attributeName;
			switch (text)
			{
			case "faceSoftness":
				text = "outlineSoftness";
				break;
			case "outlineThickness":
				text = "outlineWidth";
				break;
			case "bevelAmount":
				text = "bevel";
				break;
			case "bumpMapTexture":
				text = "bumpMap";
				break;
			case "bumpMapOutlineAmount":
				text = "bumpOutline";
				break;
			case "bumpMapFaceAmount":
				text = "bumpFace";
				break;
			case "envMapFaceColor":
				text = "reflectFaceColor";
				break;
			case "envMapOutlineColor":
				text = "reflectOutlineColor";
				break;
			case "envMapCubemap":
				text = "cube";
				break;
			case "envMapMatrixRotation":
				text = "envMatrixRotation";
				break;
			case "glowInnerAmount":
				text = "glowInner";
				break;
			case "glowOuterAmount":
				text = "glowOuter";
				break;
			}
			text = text.Replace("Texture", "Tex");
			if (text != "lightAngle")
			{
				text = text.Replace("light", "");
			}
			text = text.Replace("Shadow", "");
			text = "_" + text[0].ToString().ToUpper() + text.Substring(1);
			_shaderPropertyNames.Add(attributeName, text);
			return text;
		}
	}
}
