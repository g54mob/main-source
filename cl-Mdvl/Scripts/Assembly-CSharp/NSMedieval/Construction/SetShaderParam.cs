using System;
using NSEipix.Base;
using NSMedieval.Manager;
using UnityEngine;

namespace NSMedieval.Construction
{
	[Serializable]
	public class SetShaderParam
	{
		[SerializeField]
		private string variableName;

		[SerializeField]
		private float floatValue = float.MaxValue;

		[SerializeField]
		private int intValue = int.MaxValue;

		[SerializeField]
		private Vector2 vector2Value = Vector2.positiveInfinity;

		[SerializeField]
		private Vector3 vector3Value = Vector3.positiveInfinity;

		[SerializeField]
		private string colorValue;

		[NonSerialized]
		private Color color;

		[NonSerialized]
		private bool colorInitDone;

		private Color Color
		{
			get
			{
				if (!colorInitDone)
				{
					colorInitDone = true;
					ColorUtility.TryParseHtmlString(colorValue, out color);
				}
				return color;
			}
		}

		public void TryApply(Renderer renderer)
		{
			MaterialPropertyBlockManager instance = MonoSingleton<MaterialPropertyBlockManager>.Instance;
			Material[] sharedMaterials = renderer.sharedMaterials;
			for (int i = 0; i < sharedMaterials.Length; i++)
			{
				if (sharedMaterials[i].HasProperty(variableName))
				{
					if (floatValue < float.MaxValue)
					{
						MaterialPropertyBlock materialPropertyBlock = instance.GetMaterialPropertyBlock(renderer);
						materialPropertyBlock.SetFloat(variableName, floatValue);
						renderer.SetPropertyBlock(materialPropertyBlock);
					}
					else if (!intValue.Equals(int.MaxValue))
					{
						MaterialPropertyBlock materialPropertyBlock2 = instance.GetMaterialPropertyBlock(renderer);
						materialPropertyBlock2.SetInt(variableName, intValue);
						renderer.SetPropertyBlock(materialPropertyBlock2);
					}
					else if (!vector2Value.Equals(Vector2.positiveInfinity))
					{
						MaterialPropertyBlock materialPropertyBlock3 = instance.GetMaterialPropertyBlock(renderer);
						materialPropertyBlock3.SetVector(variableName, vector2Value);
						renderer.SetPropertyBlock(materialPropertyBlock3);
					}
					else if (!vector3Value.Equals(Vector3.positiveInfinity))
					{
						MaterialPropertyBlock materialPropertyBlock4 = instance.GetMaterialPropertyBlock(renderer);
						materialPropertyBlock4.SetVector(variableName, vector3Value);
						renderer.SetPropertyBlock(materialPropertyBlock4);
					}
					else
					{
						MaterialPropertyBlock materialPropertyBlock5 = instance.GetMaterialPropertyBlock(renderer);
						materialPropertyBlock5.SetColor(variableName, Color);
						renderer.SetPropertyBlock(materialPropertyBlock5);
					}
				}
			}
		}
	}
}
