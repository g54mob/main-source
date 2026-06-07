using System;
using UnityEngine;
using UnityEngine.UI;

public class UIPrintMarkup : MonoBehaviour
{
	public Toggle MainToggle;

	public Text MainLabel;

	public Slider MarkupSlider;

	public Text MarkupText;

	[NonSerialized]
	public bool Software;

	[NonSerialized]
	public IManufacturable Manufacturable;

	[NonSerialized]
	private float _nextUpdate;

	[NonSerialized]
	private bool _disableUpdate;

	public void Init(bool software, IManufacturable man)
	{
		_disableUpdate = true;
		Company myCompany = GameSettings.Instance.MyCompany;
		Software = software;
		Manufacturable = man;
		if (software)
		{
			MainLabel.text = "Software".Loc();
			MainToggle.isOn = myCompany.SoftwarePrintMarkup.HasValue;
			MarkupSlider.value = (myCompany.SoftwarePrintMarkup ?? 0f) * 100f;
		}
		else
		{
			MainLabel.text = man.GetPrettyName();
			float value;
			MainToggle.isOn = myCompany.HardwarePrintMarkup.TryGetValue(man, out value);
			MarkupSlider.value = value * 100f;
		}
		_disableUpdate = false;
	}

	public void MarkupChanged()
	{
		MarkupText.text = (MarkupSlider.value / 100f).ToPercent(false);
		float? num = (Software ? GameSettings.Instance.MyCompany.SoftwarePrintMarkup : GameSettings.Instance.MyCompany.HardwarePrintMarkup.GetOrNullable(Manufacturable));
		float? min = GetMin();
		if (min.HasValue && (!num.HasValue || min.Value < num.Value))
		{
			Text markupText = MarkupText;
			markupText.text = markupText.text + " - " + "Competition".Loc() + ": " + min.Value.ToPercent(false);
		}
	}

	public float? GetMin()
	{
		float? result = null;
		foreach (Company playerCompany in MarketSimulation.Active.GetPlayerCompanies())
		{
			if (!playerCompany.LocalPlayer)
			{
				float? num = (Software ? playerCompany.SoftwarePrintMarkup : playerCompany.HardwarePrintMarkup.GetOrNullable(Manufacturable));
				if (num.HasValue && (!result.HasValue || num.Value < result.Value))
				{
					result = num;
				}
			}
		}
		return result;
	}

	public void PropertyChanged()
	{
		if (!_disableUpdate)
		{
			if (_nextUpdate <= 0f)
			{
				GameSettings.Instance.MyCompany.SetPrintMarkup(Manufacturable, MainToggle.isOn ? (MarkupSlider.value / 100f) : (-1f));
				_nextUpdate = 0.5f;
			}
			else
			{
				_nextUpdate = 0.5f;
			}
		}
	}

	private void Update()
	{
		MarkupChanged();
		if (_nextUpdate > 0f)
		{
			_nextUpdate -= Time.deltaTime;
			if (_nextUpdate <= 0f)
			{
				PropertyChanged();
			}
		}
	}
}
