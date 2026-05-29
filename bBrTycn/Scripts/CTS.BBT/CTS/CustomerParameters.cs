using System.Collections.Generic;
using CTS.BBT;
using CTS.Utilities;
using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(fileName = "CustomerSpawnRules", menuName = "Customer/CustomerSpawnRules")]
	public class CustomerParameters : AbsLockableItemSO, IRevert
	{
		[field: SerializeField]
		public bool CanSpawnNaturally { get; private set; } = true;

		public bool IsValid
		{
			get
			{
				if (CharacterData.Gender != 0 && CharacterData.Species != 0 && CharacterData.Ethnics != 0)
				{
					return CharacterData.SubSpecies != (ESubSpecies)0;
				}
				return false;
			}
		}

		public bool IsVampire => CharacterData.Species == ESpecies.Vampire;

		public ESubSpecies Type => CharacterData.SubSpecies;

		[field: Header("Prestige")]
		[field: SerializeField]
		public int MinimumPrestigeRequired { get; private set; }

		[field: Header("Customer Visuals")]
		[field: SerializeField]
		public CharacterData CharacterData { get; private set; }

		[field: SerializeField]
		[field: MinMaxSlider(10f, 10000f)]
		public Vector2Int StartMoney { get; private set; } = new Vector2Int(10, 50);

		[field: SerializeField]
		[field: Range(0f, 100f)]
		public int Credibility { get; private set; }

		[field: SerializeField]
		public BloodQualityData BloodQuality { get; private set; }

		[field: SerializeField]
		[field: MinMaxSlider(1f, 15f)]
		public Vector2Int MaxDrinksPerLife { get; private set; } = new Vector2Int(3, 3);

		[field: SerializeField]
		public DrinkList AllDrinks { get; private set; }

		[field: SerializeField]
		public DrinkSO[] DrinksLiked { get; private set; }

		public List<DrinkSO> DrinksNormal { get; } = new List<DrinkSO>();

		[field: SerializeField]
		public DrinkSO[] DrinksHate { get; private set; }

		private void OnEnable()
		{
			DrinksNormal.Clear();
			if (AllDrinks == null)
			{
				return;
			}
			foreach (DrinkSO item in AllDrinks.List)
			{
				bool flag = true;
				DrinkSO[] drinksHate = DrinksHate;
				for (int i = 0; i < drinksHate.Length; i++)
				{
					if (drinksHate[i] == item)
					{
						flag = false;
						break;
					}
				}
				if (!flag)
				{
					continue;
				}
				drinksHate = DrinksLiked;
				for (int i = 0; i < drinksHate.Length; i++)
				{
					if (drinksHate[i] == item)
					{
						flag = false;
						break;
					}
				}
				if (flag)
				{
					DrinksNormal.Add(item);
				}
			}
		}

		public bool HaveNewValues(CustomerDataStruct p_data)
		{
			if (StartMoney != new Vector2Int(p_data.MinStartMoney, p_data.MaxStartMoney))
			{
				return true;
			}
			if (Credibility != p_data.Credibility)
			{
				return true;
			}
			return false;
		}

		public static CustomerParameters CreateCopyWithNewValues(CustomerParameters p_original, CustomerDataStruct p_data)
		{
			return new CustomerParameters
			{
				StartMoney = new Vector2Int(p_data.MinStartMoney, p_data.MaxStartMoney),
				Credibility = p_data.Credibility
			};
		}

		public void SetNewValues(CustomerDataStruct p_data)
		{
			StartMoney = new Vector2Int(p_data.MinStartMoney, p_data.MaxStartMoney);
			Credibility = p_data.Credibility;
		}

		public void ImportData(CustomerImportData data)
		{
			StartMoney = new Vector2Int(data.MinStartMoney, data.MaxStartMoney);
			Credibility = data.Credibility;
			MinimumPrestigeRequired = data.MinimumPrestigeRequired;
		}
	}
}
