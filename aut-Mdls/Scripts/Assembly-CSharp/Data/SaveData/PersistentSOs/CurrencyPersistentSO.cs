using System.Collections.Generic;
using System.Linq;
using Data.FactoryFloor.Behaviours;
using Data.FactoryFloor.Resources;
using Data.FeatureFlags.Validators;
using Events;
using Events.FactoryFloor;
using Logic.Threading.Events;
using UnityEngine;

namespace Data.SaveData.PersistentSOs
{
	[CreateAssetMenu(menuName = "PersistentSOs/Currency", fileName = "CurrencyPersistentSO", order = 0)]
	public class CurrencyPersistentSO : AbstractPersistentSO
	{
		[SerializeField]
		private ResourceDatabaseSO _resourceDatabase;

		[SerializeField]
		private ResourceDeliveredEventSO _resourceDeliveredEvent;

		[SerializeField]
		private AddCurrencyEvent _addCurrencyEvent;

		[SerializeField]
		private MainThreadEventSO _currencyUpdatedEvent;

		[SerializeField]
		private MainThreadEventSO _currencyRanOutEvent;

		[SerializeField]
		private BaseEvent _currencyGainedEvent;

		[SerializeField]
		private List<ResourceDataSO> _currencyResourceTypes = new List<ResourceDataSO>();

		[SerializeField]
		private ExoportBehaviour _exoportBehaviour;

		[SerializeField]
		private EnableDataShardsValidator _enableDataShardsValidator;

		private readonly Dictionary<int, int> _resourceCounts = new Dictionary<int, int>();

		private void OnEnable()
		{
			_resourceDeliveredEvent.RegisterMainThread(OnResourceDelivered);
			_addCurrencyEvent.Register(HandleAddCurrency);
		}

		private void OnDisable()
		{
			_resourceDeliveredEvent.UnRegisterMainThread(OnResourceDelivered);
			_addCurrencyEvent.UnRegister(HandleAddCurrency);
		}

		private void HandleAddCurrency(AddCurrencyEventDto dto)
		{
			AddResources(dto.CurrencyType, dto.Amount);
		}

		private void OnResourceDelivered(Resource resource)
		{
			if (_currencyResourceTypes.Contains(resource.Data))
			{
				AddResources(resource.Data, 1);
			}
		}

		private bool IsValidResource(ResourceDataSO resourceData)
		{
			if (resourceData == null || !_currencyResourceTypes.Contains(resourceData))
			{
				return false;
			}
			if (!_resourceCounts.ContainsKey(resourceData.ID))
			{
				_resourceCounts[resourceData.ID] = 0;
			}
			return true;
		}

		public void AddResourceType(ResourceDataSO resourceType)
		{
			if (!IsValidResource(resourceType))
			{
				_currencyResourceTypes.Add(resourceType);
				_resourceCounts[resourceType.ID] = 0;
			}
		}

		public int GetResourceCount(ResourceDataSO resourceData)
		{
			return _resourceCounts.GetValueOrDefault(resourceData.ID, 0);
		}

		public void AddResources(ResourceDataSO resourceData, int amount)
		{
			if (amount < 0 || !IsValidResource(resourceData) || !_exoportBehaviour.AllowedResourcesMaxAmountsDemo.ContainsKey(resourceData))
			{
				return;
			}
			int num = _exoportBehaviour.AllowedResourcesMaxAmountsDemo[resourceData];
			if (_resourceCounts[resourceData.ID] + amount > num)
			{
				if (_resourceCounts[resourceData.ID] < num)
				{
					_resourceCounts[resourceData.ID] = num;
					_currencyUpdatedEvent.Fire();
					_currencyGainedEvent.Fire();
				}
			}
			else
			{
				_resourceCounts[resourceData.ID] += amount;
				_currencyUpdatedEvent.Fire();
				_currencyGainedEvent.Fire();
			}
		}

		public void RemoveResources(ResourceDataSO resourceData, int amount)
		{
			if (amount >= 0 && IsValidResource(resourceData))
			{
				int num = Mathf.Max(0, _resourceCounts[resourceData.ID] - amount);
				_resourceCounts[resourceData.ID] = num;
				_currencyUpdatedEvent.Fire();
				if (num == 0)
				{
					_currencyRanOutEvent.Fire();
				}
			}
		}

		public void SetResources(ResourceDataSO resourceData, int amount)
		{
			if (IsValidResource(resourceData) && _exoportBehaviour.AllowedResourcesMaxAmountsDemo.ContainsKey(resourceData))
			{
				int max = _exoportBehaviour.AllowedResourcesMaxAmountsDemo[resourceData];
				int value = Mathf.Clamp(amount, 0, max);
				_resourceCounts[resourceData.ID] = value;
				_currencyUpdatedEvent.Fire();
			}
		}

		public void AddResources(List<ResourceDataSO> resourceData, int amount)
		{
			foreach (ResourceDataSO resourceDatum in resourceData)
			{
				AddResources(resourceDatum, amount);
			}
		}

		public void RemoveResources(List<ResourceDataSO> resourceData, int amount)
		{
			foreach (ResourceDataSO resourceDatum in resourceData)
			{
				RemoveResources(resourceDatum, amount);
			}
		}

		public void SetResources(List<ResourceDataSO> resourceData, int amount)
		{
			foreach (ResourceDataSO resourceDatum in resourceData)
			{
				SetResources(resourceDatum, amount);
			}
		}

		public bool HasEnoughResources(List<ResourceDataSO> resourceData, int amount)
		{
			if (amount < 0)
			{
				return false;
			}
			foreach (ResourceDataSO resourceDatum in resourceData)
			{
				if (!IsValidResource(resourceDatum))
				{
					return false;
				}
				if (_resourceCounts.GetValueOrDefault(resourceDatum.ID, 0) < amount)
				{
					return false;
				}
			}
			return true;
		}

		public bool TryBuy(List<ResourceDataSO> resourceData, int amount)
		{
			if (!_enableDataShardsValidator.IsEnabledFeatureFlag())
			{
				return true;
			}
			if (!HasEnoughResources(resourceData, amount))
			{
				return false;
			}
			RemoveResources(resourceData, amount);
			return true;
		}

		public void AddResources(ResourceCost resourceCost)
		{
			foreach (KeyValuePair<ResourceDataSO, int> allCost in resourceCost.GetAllCosts())
			{
				AddResources(allCost.Key, allCost.Value);
			}
		}

		public void RemoveResources(ResourceCost resourceCost)
		{
			foreach (KeyValuePair<ResourceDataSO, int> allCost in resourceCost.GetAllCosts())
			{
				RemoveResources(allCost.Key, allCost.Value);
			}
		}

		public bool HasEnoughResources(ResourceCost cost)
		{
			foreach (KeyValuePair<ResourceDataSO, int> allCost in cost.GetAllCosts())
			{
				if (!_resourceCounts.TryGetValue(allCost.Key.ID, out var value) || value < allCost.Value)
				{
					return false;
				}
			}
			return true;
		}

		public bool TryBuy(ResourceCost cost)
		{
			if (!_enableDataShardsValidator.IsEnabledFeatureFlag())
			{
				return true;
			}
			if (!HasEnoughResources(cost))
			{
				return false;
			}
			RemoveResources(cost);
			return true;
		}

		public override void ResetToDefaults()
		{
			foreach (int item in _resourceCounts.Keys.ToList())
			{
				_resourceCounts[item] = 0;
			}
		}

		public override AbstractSaveData GetSaveData()
		{
			return new CurrencySaveData(_resourceCounts);
		}

		protected override void ApplyLoadedSaveData(AbstractSaveData saveData)
		{
			ResetToDefaults();
			if (saveData is CurrencySaveData { ResourceCounts: not null } currencySaveData)
			{
				foreach (KeyValuePair<int, int> resourceCount in currencySaveData.ResourceCounts)
				{
					ResourceDataSO resourceDataFromID = _resourceDatabase.GetResourceDataFromID(resourceCount.Key);
					if (resourceDataFromID != null)
					{
						SetResources(resourceDataFromID, resourceCount.Value);
					}
				}
			}
			_currencyUpdatedEvent.Fire();
		}

		public override bool TryLoadSaveData(string fullPath)
		{
			return TryLoadSaveDataInternal<CurrencySaveData>(fullPath);
		}
	}
}
