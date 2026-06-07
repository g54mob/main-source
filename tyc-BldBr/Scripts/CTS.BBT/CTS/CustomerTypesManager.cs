using System.Collections.Generic;
using System.Linq;
using CTS.Core;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace CTS
{
	public class CustomerTypesManager : MonoSingleton<CustomerTypesManager>
	{
		[SerializeField]
		private bool _debug;

		[SerializeField]
		private BarStyleInfluence _barStyleInfluence;

		[SerializeField]
		private HumanStyleInfluence _humanStyleInfluence;

		[SerializeField]
		private BarStyleParameters _defaultBarStyleParameters;

		[SerializeField]
		private CustomerParameters _defaultCustomerParameters;

		[SerializeField]
		private CustomerParameters _defaultVampireParameters;

		public List<CustomerParameters> Customers { get; private set; }

		[field: SerializeField]
		public SerializableDictionary<EBarStyle, BarStyleParameters> BarStyles { get; private set; } = new SerializableDictionary<EBarStyle, BarStyleParameters>();

		[field: SerializeField]
		public SerializableDictionary<ESubSpecies, HumanStyleParameters> HumanTypes { get; private set; } = new SerializableDictionary<ESubSpecies, HumanStyleParameters>();

		[field: SerializeField]
		public SerializableDictionary<ESubSpecies, CustomerParameters> CustomersByType { get; private set; } = new SerializableDictionary<ESubSpecies, CustomerParameters>();

		protected override void SingletonAwake()
		{
			BarStyles.Clear();
			BarStyleParameters[] array = Resources.LoadAll<BarStyleParameters>("Scriptables/Influence/Bar Styles");
			foreach (BarStyleParameters barStyleParameters in array)
			{
				if (!BarStyles.ContainsKey(barStyleParameters.BarStyle) && barStyleParameters.BarStyle != EBarStyle.None)
				{
					BarStyles.Add(barStyleParameters.BarStyle, barStyleParameters);
				}
			}
			HumanTypes.Clear();
			HumanStyleParameters[] array2 = Resources.LoadAll<HumanStyleParameters>("Scriptables/Influence/Human Types");
			foreach (HumanStyleParameters humanStyleParameters in array2)
			{
				if (!HumanTypes.ContainsKey(humanStyleParameters.HumanType) && humanStyleParameters.HumanType != 0 && humanStyleParameters.IsUnlocked)
				{
					HumanTypes.Add(humanStyleParameters.HumanType, humanStyleParameters);
				}
			}
			CustomersByType.Clear();
			CustomerParameters[] array3 = Addressables.LoadAssetsAsync<CustomerParameters>("Customers").WaitForCompletion().ToArray();
			Customers = new List<CustomerParameters>();
			CustomerParameters[] array4 = array3;
			foreach (CustomerParameters customerParameters in array4)
			{
				if (customerParameters.CanSpawnNaturally && customerParameters.GetValidationState == AbsLockableItemSO.ELockState.Validated)
				{
					Customers.Add(customerParameters);
					if (!CustomersByType.ContainsKey(customerParameters.Type) && customerParameters.Type != 0)
					{
						CustomersByType.Add(customerParameters.Type, customerParameters);
					}
				}
			}
		}

		protected override void OnSingletonDestroy()
		{
		}

		public ESubSpecies SelectCustomerTypeByInfluence()
		{
			EBarStyle eBarStyle = _barStyleInfluence.SelectStyle();
			if (eBarStyle == EBarStyle.None)
			{
				eBarStyle = _defaultBarStyleParameters.BarStyle;
			}
			return BarStyles[eBarStyle].SelectCustomerType();
		}

		public ESubSpecies SelectVampireTypeByInfluence()
		{
			ESubSpecies eSubSpecies = _humanStyleInfluence.SelectStyle();
			if (eSubSpecies == (ESubSpecies)0)
			{
				eSubSpecies = _defaultCustomerParameters.Type;
			}
			return HumanTypes[eSubSpecies].SelectCustomerType();
		}

		public CustomerParameters GetCustomerByInfluence()
		{
			return GetCustomerParametersByCustomerType(SelectCustomerTypeByInfluence());
		}

		public CustomerParameters GetVampireByInfluence()
		{
			return GetVampireParametersByCustomerType(SelectVampireTypeByInfluence());
		}

		public ESubSpecies SelectRandomCustomerType()
		{
			return _defaultBarStyleParameters.SelectCustomerType();
		}

		public CustomerParameters GetCustomerParametersByCustomerType(ESubSpecies customerTypeToSpawn)
		{
			if (!CustomersByType.ContainsKey(customerTypeToSpawn) || !CustomersByType[customerTypeToSpawn].IsValid)
			{
				return _defaultCustomerParameters;
			}
			return CustomersByType[customerTypeToSpawn];
		}

		public CustomerParameters GetVampireParametersByCustomerType(ESubSpecies customerTypeToSpawn)
		{
			if (!CustomersByType.ContainsKey(customerTypeToSpawn) || !CustomersByType[customerTypeToSpawn].IsValid)
			{
				return _defaultVampireParameters;
			}
			return CustomersByType[customerTypeToSpawn];
		}

		public CustomerParameters GetCustomerDatasFromCustomerType(string p_customerTypeToSpawn)
		{
			CustomerParameters[] array = Customers.Where((CustomerParameters x) => x.name == p_customerTypeToSpawn).ToArray();
			if (array.Length == 0)
			{
				Debug.LogError("[CustomerRulesManager] customerData : " + p_customerTypeToSpawn.ToString() + " Not found");
				return null;
			}
			if (array.Length > 1)
			{
				Debug.LogError("[CustomerRulesManager] Too many customerData found, only the first was used");
			}
			return array[0];
		}

		public CustomerParameters GetCustomerDatasFromCustomerType(int p_customerTypeToSpawn)
		{
			return Customers[p_customerTypeToSpawn];
		}
	}
}
