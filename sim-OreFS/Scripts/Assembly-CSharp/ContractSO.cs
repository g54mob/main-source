using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ContractConfig", menuName = "Game/ContractSO")]
public class ContractSO : ScriptableObject
{
	[Serializable]
	public class ContractMaterial
	{
		[Tooltip("Gerekli item")]
		public T_ItemSO item;

		[Tooltip("Gerekli adet")]
		[Min(1f)]
		public int count = 1;
	}

	[Header("Temel Bilgiler")]
	[Tooltip("Bu contract config'inin benzersiz ID'si")]
	[SerializeField]
	private string contractId;

	[Header("Şirket Bilgileri")]
	[Tooltip("Contract'ı sunan şirket")]
	public CompanySO company;

	[Header("Fiyat Ayarları")]
	[Tooltip("Minimum fiyat")]
	[Min(0f)]
	public int priceMin = 500;

	[Tooltip("Maximum fiyat")]
	[Min(0f)]
	public int priceMax = 2000;

	[Tooltip("Fiyat yuvarlama değeri (100 = 100'ün katları)")]
	[Min(1f)]
	public int priceRoundingStep = 100;

	[Header("Teslimat Ayarları")]
	[Tooltip("Minimum teslimat günü")]
	[Min(1f)]
	public int deliveryDayMin = 1;

	[Tooltip("Maximum teslimat günü")]
	[Min(1f)]
	public int deliveryDayMax = 5;

	[Header("Gerekli Malzemeler")]
	[Tooltip("Bu contract için gerekli malzemeler listesi")]
	public List<ContractMaterial> requiredMaterials = new List<ContractMaterial>();

	[Header("Kısıtlamalar")]
	[Tooltip("Bu contract'a erişim için gerekli minimum fabrika seviyesi")]
	[Min(1f)]
	public int requiredLevel = 1;

	[Header("XP Ayarları")]
	[Tooltip("Contract zorluk seviyesi - XP kazanımını belirler (Tier1=200, Tier2=300, Tier3=400, Tier4=500)")]
	public ContractTier tier = ContractTier.Tier1;

	public string ContractId => contractId;

	public int TierXP => 100 + (int)tier * 100;

	public int GetRandomPrice()
	{
		int value = UnityEngine.Random.Range(priceMin, priceMax + 1);
		return RoundToStep(value, priceRoundingStep);
	}

	public int GetRandomDeliveryDays()
	{
		return UnityEngine.Random.Range(deliveryDayMin, deliveryDayMax + 1);
	}

	public bool HasValidMaterials()
	{
		if (requiredMaterials == null || requiredMaterials.Count == 0)
		{
			return false;
		}
		foreach (ContractMaterial requiredMaterial in requiredMaterials)
		{
			if (requiredMaterial == null || requiredMaterial.item == null || requiredMaterial.count <= 0)
			{
				return false;
			}
		}
		return true;
	}

	public int GetTotalMaterialCount()
	{
		int num = 0;
		if (requiredMaterials != null)
		{
			foreach (ContractMaterial requiredMaterial in requiredMaterials)
			{
				if (requiredMaterial != null && requiredMaterial.item != null)
				{
					num += requiredMaterial.count;
				}
			}
		}
		return num;
	}

	private int RoundToStep(int value, int step)
	{
		if (step <= 0)
		{
			return value;
		}
		return Mathf.RoundToInt((float)value / (float)step) * step;
	}

	[ContextMenu("Regenerate Contract ID")]
	private void RegenerateContractId()
	{
		contractId = Guid.NewGuid().ToString("N").Substring(0, 12)
			.ToUpper();
	}

	private void OnValidate()
	{
		if (priceMin > priceMax)
		{
			priceMax = priceMin;
		}
		if (deliveryDayMin > deliveryDayMax)
		{
			deliveryDayMax = deliveryDayMin;
		}
		if (string.IsNullOrEmpty(contractId))
		{
			RegenerateContractId();
		}
	}
}
