using System;
using UnityEngine;
using UnityEngine.UI;

public class AddonFeatureCard : MonoBehaviour
{
	private static Color[] _marketBarColors;

	public Text NameLabel;

	public Text SpecLabel;

	public Text DescLabel;

	public Text AmountLabel;

	public GUIProgressBar[] MarketBars;

	public Text[] MarketLabels;

	public GameObject[] Stars;

	public Toggle MainToggle;

	public Button SubButton;

	public Button AddButton;

	public SimpleSlider Slider;

	public uint Amount = 1u;

	public RectTransform Self;

	[NonSerialized]
	public AddOnFeature Feature;

	[NonSerialized]
	public AddonDesignWindow ParentWindow;

	public void OnToggle()
	{
		ParentWindow.RefreshTools();
		ParentWindow.RefreshData();
		RefreshEnabled();
	}

	public void SliderChanged()
	{
		Amount = (uint)Slider.Value;
		UpdateAmountLabel();
		if (MainToggle.isOn)
		{
			ParentWindow.RefreshData();
		}
	}

	public void ChangeAmount(int change)
	{
		Slider.Value += change;
	}

	private void UpdateAmountLabel()
	{
		AmountLabel.text = Feature.GetAmount(Amount);
	}

	private void RefreshEnabled()
	{
		for (int i = 0; i < MarketBars.Length; i++)
		{
			MarketBars[i].StartColor = (MainToggle.isOn ? _marketBarColors[i] : Color.gray);
			MarketBars[i].SetDirty();
		}
		AddButton.interactable = MainToggle.isOn;
		SubButton.interactable = MainToggle.isOn;
	}

	public void Init(AddOnFeature feature, AddonDesignWindow parent)
	{
		if (_marketBarColors == null)
		{
			_marketBarColors = MarketBars.SelectInPlace((GUIProgressBar x) => x.StartColor);
		}
		ParentWindow = parent;
		Feature = feature;
		SpecLabel.text = Feature.Spec.Loc();
		string[] feature2 = Localization.GetFeature(Feature.Software, Feature.Name);
		NameLabel.text = feature2[0];
		MainToggle.isOn = feature.IsForced;
		MainToggle.interactable = !feature.IsForced;
		Slider.MaxValue = feature.MaxFactor;
		Slider.Value = 1f;
		SoftwareType softwareType = MarketSimulation.Active.SoftwareTypes[feature.Software];
		for (int num = 0; num < 3; num++)
		{
			MarketBars[num].Value = (float)feature.Submarkets[num];
			MarketLabels[num].text = softwareType.SubMarkets[num].Loc();
		}
		if (feature2.Length > 1 && !string.IsNullOrEmpty(feature2[1]))
		{
			DescLabel.text = feature2[1];
		}
		else
		{
			DescLabel.gameObject.SetActive(false);
		}
		if (Feature.MaxFactor > 1)
		{
			UpdateAmountLabel();
		}
		else
		{
			AmountLabel.transform.parent.gameObject.SetActive(false);
		}
		Stars[0].gameObject.SetActive(feature.Level > 0);
		Stars[1].gameObject.SetActive(feature.Level > 1);
		RefreshEnabled();
	}
}
