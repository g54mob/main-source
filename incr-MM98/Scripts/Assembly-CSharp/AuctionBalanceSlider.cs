using System;
using Cysharp.Text;
using R3;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AuctionBalanceSlider : MonoBehaviour
{
	[SerializeField]
	private LootItemQuality quality;

	[SerializeField]
	private Slider slider;

	[SerializeField]
	private TMP_Text valueText;

	private void Awake()
	{
		slider.onValueChanged.AddListener(delegate(float x)
		{
			Database.Commands.Auction.AdjustDropchance(quality, x);
		});
		GetQualityObservable(quality).DistinctUntilChanged().Subscribe((slider, valueText), UpdateSliderValue).AddTo(this);
	}

	private static void UpdateSliderValue(float value, (Slider slider, TMP_Text text) state)
	{
		state.slider.SetValueWithoutNotify(value);
		state.text.SetTextFormat(NumericFormat.Droprate.Value(), value * 100f);
	}

	private static Observable<float> GetQualityObservable(LootItemQuality quality)
	{
		return quality switch
		{
			LootItemQuality.Common => Database.State.Auction.CommonDropchance, 
			LootItemQuality.Uncommon => Database.State.Auction.UncommonDropchance, 
			LootItemQuality.Rare => Database.State.Auction.RareDropchance, 
			LootItemQuality.Legendary => Database.State.Auction.LegendaryDropchance, 
			_ => throw new ArgumentOutOfRangeException("quality", quality, null), 
		};
	}
}
