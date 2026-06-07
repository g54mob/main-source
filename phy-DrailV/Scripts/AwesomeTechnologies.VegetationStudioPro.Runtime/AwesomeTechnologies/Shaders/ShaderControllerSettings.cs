using System;
using AwesomeTechnologies.Common;
using AwesomeTechnologies.VegetationSystem;
using UnityEngine;

namespace AwesomeTechnologies.Shaders
{
	[Serializable]
	public class ShaderControllerSettings : BaseControllerSettings
	{
		public string Heading;

		public string Description;

		public bool SupportsInstantIndirect;

		public bool LODFadeCrossfade;

		public bool LODFadePercentage;

		public bool SampleWind;

		public bool UpdateWind;

		public bool DynamicHUE;

		public bool BillboardSnow;

		public bool BillboardHDWind;

		public string OverrideBillboardAtlasShader = "";

		public string OverrideBillboardAtlasNormalShader = "";

		public BillboardRenderMode BillboardRenderMode = BillboardRenderMode.Specular;

		public ShaderControllerSettings()
		{
		}

		public ShaderControllerSettings(ShaderControllerSettings source)
		{
			Heading = source.Heading;
			Description = source.Description;
			SupportsInstantIndirect = source.SupportsInstantIndirect;
			LODFadeCrossfade = source.LODFadeCrossfade;
			LODFadePercentage = source.LODFadePercentage;
			SampleWind = source.SampleWind;
			UpdateWind = source.UpdateWind;
			BillboardSnow = source.BillboardSnow;
			DynamicHUE = source.DynamicHUE;
			for (int i = 0; i <= source.ControlerPropertyList.Count - 1; i++)
			{
				ControlerPropertyList.Add(new SerializedControllerProperty(source.ControlerPropertyList[i]));
			}
		}

		public static bool HasShader(Material material, string[] shaderNames)
		{
			string name = material.shader.name;
			for (int i = 0; i <= shaderNames.Length - 1; i++)
			{
				if (name.Equals(shaderNames[i]))
				{
					return true;
				}
			}
			return false;
		}

		public static float GetFloatFromMaterials(Material[] materials, string propertyName)
		{
			for (int i = 0; i <= materials.Length - 1; i++)
			{
				if (materials[i].HasProperty(propertyName))
				{
					return materials[i].GetFloat(propertyName);
				}
			}
			return 1f;
		}

		public static float GetFloatFromMaterials(Material[] materials, string propertyName, string[] shaderNames)
		{
			for (int i = 0; i <= materials.Length - 1; i++)
			{
				if (materials[i].HasProperty(propertyName) && HasShader(materials[i], shaderNames))
				{
					return materials[i].GetFloat(propertyName);
				}
			}
			return 1f;
		}

		public static Vector4 GetVector4FromMaterials(Material[] materials, string propertyName)
		{
			for (int i = 0; i <= materials.Length - 1; i++)
			{
				if (materials[i].HasProperty(propertyName))
				{
					return materials[i].GetVector(propertyName);
				}
			}
			return Vector4.zero;
		}

		public static Color GetColorFromMaterials(Material[] materials, string propertyName, string[] shaderNames)
		{
			for (int i = 0; i <= materials.Length - 1; i++)
			{
				if (materials[i].HasProperty(propertyName) && HasShader(materials[i], shaderNames))
				{
					return materials[i].GetColor(propertyName);
				}
			}
			return Color.white;
		}

		public static Color GetColorFromMaterials(Material[] materials, string propertyName)
		{
			for (int i = 0; i <= materials.Length - 1; i++)
			{
				if (materials[i].HasProperty(propertyName))
				{
					return materials[i].GetColor(propertyName);
				}
			}
			return Color.white;
		}
	}
}
