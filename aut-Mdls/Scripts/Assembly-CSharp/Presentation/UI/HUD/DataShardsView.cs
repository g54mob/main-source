using System.Collections.Generic;
using Data.FactoryFloor.Resources;
using Data.SaveData.PersistentSOs;
using Logic.Threading.Events;
using UnityEngine;

namespace Presentation.UI.HUD
{
	public class DataShardsView : MonoBehaviour
	{
		[SerializeField]
		private CurrencyPersistentSO _currentCurrency;

		[SerializeField]
		private MainThreadEventSO _currencyUpdatedEvent;

		[SerializeField]
		private List<ResourceDataSO> _resources;

		[SerializeField]
		private List<DataShardCostUI> _costUIs;

		private void Awake()
		{
			_currencyUpdatedEvent.RegisterMainThread(UpdateCurrency);
			UpdateCurrency();
		}

		private void OnDestroy()
		{
			_currencyUpdatedEvent.UnRegisterMainThread(UpdateCurrency);
		}

		private void UpdateCurrency()
		{
			for (int i = 0; i < _resources.Count; i++)
			{
				_costUIs[i].SetAmount(_currentCurrency.GetResourceCount(_resources[i]));
			}
		}
	}
}
