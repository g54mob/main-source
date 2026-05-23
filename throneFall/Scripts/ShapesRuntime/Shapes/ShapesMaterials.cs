using System;
using UnityEngine;

namespace Shapes
{
	internal class ShapesMaterials
	{
		private const bool USE_INSTANCING = true;

		public const string SHAPES_SHADER_PATH_PREFIX = "Shapes/";

		private readonly Material[] materials;

		public Material this[ShapesBlendMode type] => materials[(int)type];

		public ShapesMaterials(string shaderName, params string[] keywords)
		{
			int num = Enum.GetNames(typeof(ShapesBlendMode)).Length;
			materials = new Material[num];
			for (int i = 0; i < num; i++)
			{
				Material[] array = materials;
				int num2 = i;
				ShapesBlendMode shapesBlendMode = (ShapesBlendMode)i;
				array[num2] = InitMaterial(shaderName, shapesBlendMode.ToString(), keywords);
			}
		}

		public static string GetMaterialName(string shaderName, string blendModeSuffix, params string[] keywords)
		{
			string text = "";
			if (keywords != null && keywords.Length != 0)
			{
				text = " [" + string.Join("][", keywords) + "]";
			}
			return shaderName + " " + blendModeSuffix + text;
		}

		public static void ApplyDefaultGlobalProperties(Material mat)
		{
			mat.SetInt_Shapes(ShapesMaterialUtils.propZTest, 4);
			mat.SetFloat(ShapesMaterialUtils.propZOffsetFactor, 0f);
			mat.SetInt_Shapes(ShapesMaterialUtils.propZOffsetUnits, 0);
			mat.SetInt_Shapes(ShapesMaterialUtils.propColorMask, 15);
		}

		private static Material CreateShapesMaterial(Shader shader, HideFlags hideFlags, params string[] keywords)
		{
			Material material = new Material(shader)
			{
				hideFlags = hideFlags,
				enableInstancing = true
			};
			if (keywords != null)
			{
				foreach (string keyword in keywords)
				{
					material.EnableKeyword(keyword);
				}
			}
			ApplyDefaultGlobalProperties(material);
			return material;
		}

		private static Material InitMaterial(string shaderName, string blendModeSuffix, params string[] keywords)
		{
			shaderName = "Shapes/" + shaderName + " " + blendModeSuffix;
			Shader shader = Shader.Find(shaderName);
			if (shader == null)
			{
				Debug.LogError("Could not find shader " + shaderName);
				return null;
			}
			return CreateShapesMaterial(shader, HideFlags.HideAndDontSave, keywords);
		}
	}
}
