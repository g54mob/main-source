using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PropertyConfig", menuName = "Game/PropertyConfigSO")]
public class PropertyConfigSO : ScriptableObject
{
	[Header("Temel Bilgiler")]
	[Tooltip("Bu emlak config'inin benzersiz ID'si")]
	[SerializeField]
	private string configId;

	[Tooltip("Emlak türünün gösterim ismi - I2 Localization Term Key (Level Up panelinde gösterilir)")]
	public string displayName;

	[Tooltip("Emlak için kullanılabilecek isim listesi - I2 Localization Term Key'leri (random seçilecek)")]
	public List<string> propertyNames = new List<string>();

	[Tooltip("Emlak türü")]
	public PropertyType propertyType;

	[Tooltip("Emlak seviyesi (level-based sıralama için)")]
	[Min(0f)]
	public int propertyLevel = 1;

	[Header("Fiyat Ayarları")]
	[Tooltip("Minimum fiyat")]
	[Min(0f)]
	public int minPrice = 1000;

	[Tooltip("Maximum fiyat")]
	[Min(0f)]
	public int maxPrice = 5000;

	[Tooltip("Fiyat yuvarlama değeri (100 = 100'ün katları)")]
	[Min(1f)]
	public int priceRoundingStep = 100;

	[Header("Adres Listesi")]
	[Tooltip("Emlak adresleri listesi - I2 Localization Term Key'leri (random seçilecek)")]
	public List<string> propertyAddresses = new List<string>();

	[Header("Boyut Listesi")]
	[Tooltip("Emlak boyutları listesi - m² (random seçilecek)")]
	public List<int> propertySizes = new List<int>();

	[Header("Görsel Listesi")]
	[Tooltip("Emlak görselleri listesi (random seçilecek)")]
	public List<Sprite> propertyVisuals = new List<Sprite>();

	[Header("Bağlantılı Scene")]
	[Tooltip("Bu emlak satın alındığında yüklenecek scene adı")]
	public string linkedSceneName;

	[Header("Katman Profilleri")]
	[Tooltip("Bu property için kullanılabilecek item spawn profilleri listesi (random seçilecek)")]
	public List<T_ItemSpawnProfile> itemSpawnProfiles = new List<T_ItemSpawnProfile>();

	[Header("Kontratlar")]
	[Tooltip("Bu property'den alınabilecek contract'lar listesi")]
	public List<ContractSO> contracts = new List<ContractSO>();

	public string ConfigId => configId;

	public string GetRandomPropertyName()
	{
		if (propertyNames == null || propertyNames.Count == 0)
		{
			return $"Emlak #{UnityEngine.Random.Range(1, 1000)}";
		}
		return propertyNames[UnityEngine.Random.Range(0, propertyNames.Count)];
	}

	public int GetRandomPrice()
	{
		int value = UnityEngine.Random.Range(minPrice, maxPrice + 1);
		return RoundToStep(value, priceRoundingStep);
	}

	public int GetRandomSize()
	{
		if (propertySizes == null || propertySizes.Count == 0)
		{
			return 100;
		}
		return propertySizes[UnityEngine.Random.Range(0, propertySizes.Count)];
	}

	public string GetRandomAddress()
	{
		if (propertyAddresses == null || propertyAddresses.Count == 0)
		{
			return $"Bilinmeyen Adres #{UnityEngine.Random.Range(1, 100)}";
		}
		return propertyAddresses[UnityEngine.Random.Range(0, propertyAddresses.Count)];
	}

	public Sprite GetRandomVisual()
	{
		if (propertyVisuals == null || propertyVisuals.Count == 0)
		{
			return null;
		}
		return propertyVisuals[UnityEngine.Random.Range(0, propertyVisuals.Count)];
	}

	public T_ItemSpawnProfile GetRandomSpawnProfile()
	{
		if (itemSpawnProfiles == null || itemSpawnProfiles.Count == 0)
		{
			return null;
		}
		return itemSpawnProfiles[UnityEngine.Random.Range(0, itemSpawnProfiles.Count)];
	}

	private int RoundToStep(int value, int step)
	{
		if (step <= 0)
		{
			return value;
		}
		return Mathf.RoundToInt((float)value / (float)step) * step;
	}

	[ContextMenu("Regenerate Config ID")]
	private void RegenerateConfigId()
	{
		configId = Guid.NewGuid().ToString("N").Substring(0, 12)
			.ToUpper();
	}

	private void OnValidate()
	{
		if (minPrice > maxPrice)
		{
			maxPrice = minPrice;
		}
		if (string.IsNullOrEmpty(configId))
		{
			RegenerateConfigId();
		}
	}
}
