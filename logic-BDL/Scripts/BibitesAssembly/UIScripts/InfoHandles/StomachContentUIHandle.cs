using System;
using ManagementScripts;
using SimulationScripts;
using SimulationScripts.BibiteScripts;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UIScripts.InfoHandles
{
	public class StomachContentUIHandle : MonoBehaviour
	{
		public Image pelletImage;

		public TextMeshProUGUI materialNameText;

		public FloatValueTextHandle matterAmountText;

		public ValueSliderHandle proportionSlider;

		public ValueSliderHandle digestionRateSlider;

		public RateSliderHandle efficiencySlider;

		public RateSliderHandle energyGainSlider;

		[NonSerialized]
		public readonly UnityEvent<float> OnDigestionScaleUpdate = new UnityEvent<float>();

		[NonSerialized]
		public readonly UnityEvent<float> OnEnergyGainScaleUpdate = new UnityEvent<float>();

		[NonSerialized]
		public MatterMaterial Material;

		public void InitContentHandle(StomachContent matter)
		{
			Material = matter.material;
			pelletImage.sprite = ProceduralSpriteManager.Instance.RequestPelletSpriteOfMaterial(Material, 0);
			materialNameText.text = Material.Name;
			matterAmountText.UpdateValue(matter.amount, check: false);
			proportionSlider.InitSliderHandle(1f, updatableScale: false);
			digestionRateSlider.InitSliderHandle(1f);
			efficiencySlider.InitSliderHandle(1f, updatableScale: false);
			energyGainSlider.InitSliderHandle(1f);
			digestionRateSlider.OnScaleRaised.AddListener(delegate(float arg)
			{
				OnDigestionScaleUpdate.Invoke(arg);
			});
			energyGainSlider.OnScaleRaised.AddListener(delegate(float arg)
			{
				OnEnergyGainScaleUpdate.Invoke(arg);
			});
			UpdateContent(matter, matter.amount);
		}

		public void UpdateContent(StomachContent matter, float totalAmount)
		{
			if (!(matter.material != Material))
			{
				matterAmountText.UpdateValue(matter.amount, check: false);
				proportionSlider.UpdateValue(matter.amount / totalAmount);
				digestionRateSlider.UpdateValue(matter.digestionRate);
				efficiencySlider.UpdateValue(matter.lastConversionEfficiency);
				energyGainSlider.UpdateValue(matter.digestionRate * matter.efficiency * Material.EnergyDensity);
			}
		}

		public void UpdateDigestionScale(float scale)
		{
			digestionRateSlider.scale = scale;
		}

		public void UpdateEnergyScale(float scale)
		{
			energyGainSlider.scale = scale;
		}
	}
}
