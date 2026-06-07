using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SnowfallControllerUI : MonoBehaviour
{
	[SerializeField]
	private ThermometerUI thermometerUI;

	[SerializeField]
	private TextMeshProUGUI totalSnowfallLevelText;

	[SerializeField]
	private TextMeshProUGUI snowfallIntensityText;

	[SerializeField]
	private TextMeshProUGUI activeBeaconsText;

	[SerializeField]
	private UIList effectsList;

	private SnowfallController snowfallController;

	public SnowfallController SnowfallController => snowfallController;

	private void Start()
	{
		if (!LTFunctionLibrary.GetLTLevelController().TryGetComponent<SnowfallController>(out snowfallController))
		{
			Object.Destroy(base.gameObject);
			return;
		}
		SnowfallController.onSnowfallLevelChanged += OnSnowfallLevelChanged;
		SnowfallController.onSnowfallIntensityChanged += OnSnowfallIntensityChanged;
		SnowfallController.onActiveBeaconsChanged += OnActiveBeaconsChanged;
		OnSnowfallLevelChanged(SnowfallController.CurrentSnowfallLevel);
		OnSnowfallIntensityChanged(SnowfallController.SnowfallIntensity);
		OnActiveBeaconsChanged(SnowfallController.ActiveBeacons);
	}

	private void OnSnowfallLevelChanged(int snowfallLevel)
	{
		totalSnowfallLevelText.text = (snowfallLevel * -1).ToString();
		thermometerUI.SetLevel(snowfallLevel);
		List<SnowfallEffectUI.FSnowfallEffectUIData> list = new List<SnowfallEffectUI.FSnowfallEffectUIData>();
		GameplayEffectData[] gEToApply = SnowfallController.CurrentSnowfallLevelInfo.GEToApply;
		for (int i = 0; i < gEToApply.Length; i++)
		{
			GameplayEffectData[] effectsToApply = (gEToApply[i] as GE_GiveEffectToBuildingData).EffectsToApply;
			foreach (GameplayEffectData geData in effectsToApply)
			{
				list.Add(new SnowfallEffectUI.FSnowfallEffectUIData(geData, snowfallLevel < 0));
			}
		}
		effectsList.LoadList(list);
	}

	private void OnSnowfallIntensityChanged(int snowfallIntensity)
	{
		snowfallIntensityText.text = snowfallIntensity.ToString();
	}

	private void OnActiveBeaconsChanged(int activeBeacons)
	{
		activeBeaconsText.text = activeBeacons.ToString();
	}
}
