using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class FeatureTipper : MonoBehaviour
{
	public static FeatureTipper Instance;

	public GameObject SubmarketPanel;

	public GameObject ModifierPanel;

	public GameObject DescPanel;

	public GameObject WarningSpacing;

	public GameObject WarningPanel;

	public GameObject Padding;

	public Text[] SubmarkeTexts;

	public GUIProgressBar[] SubmarketBars;

	public Text WarningText;

	public Text DescText;

	public Text SpeedModifierText;

	public RectTransform Target;

	public RectTransform Self;

	public RectTransform WarningRect;

	public RectTransform WarningPlaceRect;

	private void Start()
	{
		Instance = this;
		base.gameObject.SetActive(false);
	}

	private string GetFeatureAddons(FeatureBase f, SoftwareCategory cat)
	{
		StringBuilder stringBuilder = null;
		int year = SDateTime.Now().Year;
		foreach (SoftwareAddOn value in cat.Parent.AddOns.Values)
		{
			if (!value.Valid(cat) || !value.IsUnlocked(year))
			{
				continue;
			}
			foreach (AddOnFeature value2 in value.Features.Values)
			{
				if (value2.IsCompatible(cat.Name) && ((value2.FeatureDependency != null && value2.FeatureDependency.Equals(f.Name)) || (f is SpecFeature && !f.IsForced(cat.Name) && f.Spec.Equals(value2.Spec))))
				{
					if (stringBuilder == null)
					{
						stringBuilder = new StringBuilder();
					}
					stringBuilder.AppendLine("+" + value.GetPrettyName() + " / " + value2.GetLocalizedName());
				}
			}
		}
		if (stringBuilder == null)
		{
			return null;
		}
		return stringBuilder.ToString().TrimEnd().BlueHighlight();
	}

	public void Set(RectTransform target, SoftwareType t, SoftwareCategory cat, FeatureBase feature, string warning, List<KeyValuePair<string, float>> boosts, bool simple)
	{
		bool flag = !string.IsNullOrEmpty(warning);
		bool flag2 = flag;
		WarningText.text = warning;
		WarningSpacing.SetActive(flag);
		WarningPanel.SetActive(flag);
		Padding.SetActive(false);
		string featureAddons = GetFeatureAddons(feature, cat);
		if (featureAddons == null && feature is SpecFeature)
		{
			DescPanel.SetActive(false);
		}
		else
		{
			string text = null;
			if (!(feature is SpecFeature))
			{
				string[] feature2 = Localization.GetFeature(feature);
				if (feature2.Length > 1 && !string.IsNullOrEmpty(feature2[1]))
				{
					text = feature2[1].Format();
				}
			}
			if (featureAddons != null)
			{
				text = ((text != null) ? (text + "\n" + featureAddons) : featureAddons);
			}
			if (text != null)
			{
				DescText.text = text;
				DescPanel.SetActive(true);
				flag2 = true;
			}
			else
			{
				DescPanel.SetActive(false);
			}
		}
		if (!simple && boosts.Count > 0)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine(("SpeedModifiers".Loc() + ":").FontBold());
			for (int i = 0; i < boosts.Count; i++)
			{
				KeyValuePair<string, float> keyValuePair = boosts[i];
				stringBuilder.AppendLine((keyValuePair.Key.Loc() + ": " + keyValuePair.Value.ToPercent(true, true)).FontColor((keyValuePair.Value > 0f) ? new Color(0f, 0.6f, 0f) : new Color(0.6f, 0f, 0f)));
			}
			SpeedModifierText.text = stringBuilder.ToString().Trim();
			ModifierPanel.SetActive(true);
		}
		else
		{
			ModifierPanel.SetActive(false);
		}
		SubFeature subFeature = feature as SubFeature;
		if (!simple && (subFeature == null || subFeature.Level < 3) && feature.Submarkets[0] + feature.Submarkets[1] + feature.Submarkets[2] > 0.0)
		{
			flag2 = true;
			for (int j = 0; j < 3; j++)
			{
				SubmarketBars[j].Value = (float)feature.Submarkets[j];
				SubmarkeTexts[j].text = t.SubMarkets[j].LocTry();
			}
			SubmarketPanel.SetActive(true);
		}
		else
		{
			SubmarketPanel.SetActive(false);
		}
		if (!flag2)
		{
			return;
		}
		float num = 0f;
		if (DescPanel.activeSelf)
		{
			num = 300f;
		}
		else
		{
			if (SubmarketPanel.activeSelf)
			{
				num = 150f;
			}
			if (ModifierPanel.activeSelf)
			{
				num += 150f;
			}
		}
		if (flag)
		{
			if (num == 0f)
			{
				Padding.SetActive(true);
				num = 300f;
			}
			int num2 = Mathf.CeilToInt((float)WarningText.GetLineWidth(warning) / num) * 14 + 10;
			WarningRect.sizeDelta = new Vector2(WarningRect.sizeDelta.x, num2);
			WarningPlaceRect.sizeDelta = new Vector2(WarningPlaceRect.sizeDelta.x, num2);
		}
		Target = target;
		base.gameObject.SetActive(true);
		Self.anchoredPosition = target.GetUIScreenPosition() * (1f / Options.UISize) + new Vector2(0f, (0f - target.rect.height) / 2f - (float)Screen.height / Options.UISize);
	}

	private void Update()
	{
		if (Target == null || !Target.gameObject.activeInHierarchy || !RectTransformUtility.RectangleContainsScreenPoint(Target, Input.mousePosition, UICamSize.GetUICam()))
		{
			Target = null;
			base.gameObject.SetActive(false);
		}
	}
}
