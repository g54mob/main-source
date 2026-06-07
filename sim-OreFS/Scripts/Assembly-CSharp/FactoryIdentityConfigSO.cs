using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FactoryIdentityConfig", menuName = "Game/FactoryIdentityConfigSO")]
public class FactoryIdentityConfigSO : ScriptableObject
{
	[Serializable]
	public class ColorEntry
	{
		public Color color = Color.white;

		[Tooltip("I2 Localization key (örn: Color_Red)")]
		public string localizationKey;
	}

	[Header("Şirket İsimleri")]
	[Tooltip("Önceden tanımlanmış şirket isim listesi (random seçim için)")]
	public List<string> companyNames = new List<string>();

	[Header("Şirket Logoları")]
	[Tooltip("Seçilebilir logo listesi (index ile network sync)")]
	public List<Sprite> companyLogos = new List<Sprite>();

	[Header("Renk Paleti")]
	[Tooltip("Seçilebilir renk değerleri (OptionsButtonUGUI index'i ile eşleşir)")]
	public List<ColorEntry> colorEntries = new List<ColorEntry>();

	public int LogoCount => companyLogos?.Count ?? 0;

	public int ColorCount => colorEntries?.Count ?? 0;

	public string GetRandomName()
	{
		if (companyNames == null || companyNames.Count == 0)
		{
			return $"Company #{UnityEngine.Random.Range(1000, 9999)}";
		}
		return companyNames[UnityEngine.Random.Range(0, companyNames.Count)];
	}

	public Sprite GetLogoByIndex(int index)
	{
		if (companyLogos == null || companyLogos.Count == 0)
		{
			return null;
		}
		index = Mathf.Clamp(index, 0, companyLogos.Count - 1);
		return companyLogos[index];
	}

	public Color GetColorByIndex(int index)
	{
		if (colorEntries == null || colorEntries.Count == 0)
		{
			return Color.white;
		}
		index = Mathf.Clamp(index, 0, colorEntries.Count - 1);
		return colorEntries[index].color;
	}

	public string GetColorLocalizationKey(int index)
	{
		if (colorEntries == null || colorEntries.Count == 0)
		{
			return "";
		}
		index = Mathf.Clamp(index, 0, colorEntries.Count - 1);
		return colorEntries[index].localizationKey;
	}
}
