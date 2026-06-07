using System.Collections.Generic;
using SettingScripts;
using SimulationScripts.BibiteScripts;
using UIScripts.SettingHandles;
using UIScripts.SettingHandles.References;
using UnityEngine;
using UnityEngine.UI;

namespace Utility
{
	public class InternalsAnimation : MonoBehaviour
	{
		public Image internals;

		private Material mat;

		private float time;

		private int step;

		public Transform sliderHolders;

		private List<FloatSettingSlider> waggSettings = new List<FloatSettingSlider>();

		public GameObject sliderPrefab;

		public float initialStomachVal;

		private void Start()
		{
			mat = internals.material;
			foreach (GeneSetting wAGGSetting in BibiteEditorSettings.WAGGSettings)
			{
				wAGGSetting.SetValue(wAGGSetting.DefaultValue * 2f);
				FloatSettingSlider floatSettingSlider = new FloatSettingSlider(wAGGSetting);
				floatSettingSlider.InitUIElement(Object.Instantiate(sliderPrefab, sliderHolders).GetComponent<SettingSliderReference>());
				floatSettingSlider.ShowUIElement();
				wAGGSetting.Subscribe(UpdateProportions);
			}
			initialStomachVal = BibiteEditorSettings.stomachWAG.val;
			UpdateProportions();
		}

		private void Update()
		{
			time += Time.deltaTime;
			if (step == 0)
			{
				if (time < 15f)
				{
					return;
				}
				time -= 15f;
				step++;
			}
			if (step == 1)
			{
				float t = Mathf.Clamp01(SmoothT(Mathf.InverseLerp(0f, 4f, time)));
				float t2 = Mathf.Clamp01(SmoothT(Mathf.InverseLerp(2f, 6f, time)));
				float t3 = Mathf.Clamp01(SmoothT(Mathf.InverseLerp(4f, 8f, time)));
				float t4 = Mathf.Clamp01(SmoothT(Mathf.InverseLerp(6f, 10f, time)));
				float t5 = Mathf.Clamp01(SmoothT(Mathf.InverseLerp(8f, 12f, time)));
				BibiteEditorSettings.stomachWAG.SetValue(Mathf.Lerp(4f, 7f, t));
				BibiteEditorSettings.wombWAG.SetValue(Mathf.Lerp(2f, 4f, t2));
				if (time < 4f)
				{
					return;
				}
				BibiteEditorSettings.stomachWAG.SetValue(Mathf.Lerp(7f, 4f, t3));
				BibiteEditorSettings.jawWAG.SetValue(Mathf.Lerp(2f, 6f, t4));
				BibiteEditorSettings.armorWAG.SetValue(Mathf.Lerp(0.3f, 9f, t5));
				if (time < 12f)
				{
					return;
				}
				time -= 12f;
				step++;
			}
			if (step == 1)
			{
				float t6 = SmoothT(time / 3f);
				BibiteEditorSettings.stomachWAG.SetValue(Mathf.Lerp(initialStomachVal, 2f * initialStomachVal, t6));
				if (!(time > 3f))
				{
					time -= 3f;
					step++;
				}
			}
		}

		private void UpdateProportions(float v = 0f)
		{
			float[] geneArray = BibiteEditorSettings.geneArray;
			mat.SetFloat("_WombPortion", BibiteGenes.WombAreaPortion(geneArray));
			mat.SetFloat("_ThroatPortion", BibiteGenes.ThroatAreaPortion(geneArray));
			mat.SetFloat("_StomachPortion", BibiteGenes.StomachAreaPortion(geneArray));
			mat.SetFloat("_MusclesPortion", BibiteGenes.MoveMusclesAreaPortion(geneArray));
			mat.SetFloat("_JawPortion", BibiteGenes.JawAreaPortion(geneArray));
			mat.SetFloat("_ArmorPortion", BibiteGenes.ArmorOrganAreaPortion(geneArray));
		}

		private void OnDestroy()
		{
			foreach (GeneSetting wAGGSetting in BibiteEditorSettings.WAGGSettings)
			{
				wAGGSetting.UnSubscribe(UpdateProportions);
			}
		}

		private float SmoothT(float t)
		{
			return t * t * (3f - 2f * t);
		}
	}
}
