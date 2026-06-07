using System.Linq;
using I2.Loc;
using UnityEngine;

namespace DV.Localization
{
	public class CJKFontMaterialDilateSetter : MonoBehaviour
	{
		private static readonly int DILATE = Shader.PropertyToID("_FaceDilate");

		private const float CJK_DILATE = 0f;

		private const float NON_CJK_DILATE = 0.27f;

		private readonly string[] CJK_CODES = new string[5] { "zh-CN", "zh-TW", "ja", "ko", "hi" };

		public Material[] materials;

		private float[] originalValues;

		private void Awake()
		{
			originalValues = materials.Select((Material m) => m.GetFloat(DILATE)).ToArray();
			LocalizationManager.OnLocalizeEvent += RefreshMaterials;
			RefreshMaterials();
		}

		private void OnDestroy()
		{
			LocalizationManager.OnLocalizeEvent -= RefreshMaterials;
			for (int i = 0; i < originalValues.Length; i++)
			{
				materials[i].SetFloat(DILATE, originalValues[i]);
			}
		}

		private void RefreshMaterials()
		{
			float value = (CJK_CODES.Contains(LocalizationManager.CurrentLanguageCode) ? 0f : 0.27f);
			for (int i = 0; i < originalValues.Length; i++)
			{
				materials[i].SetFloat(DILATE, value);
			}
		}
	}
}
