using Data.FactoryFloor.Resources;
using Data.SaveData.PersistentSOs;
using Logic.Threading.Events;
using TMPro;
using UnityEngine;

namespace Presentation.UI.HUD
{
	public class ExpansionPermitUI : MonoBehaviour
	{
		[SerializeField]
		private CurrencyPersistentSO _currentCurrency;

		[SerializeField]
		private MainThreadEventSO _currencyUpdatedEvent;

		[SerializeField]
		private ResourceDataSO _expansionPermitResource;

		[SerializeField]
		private TextMeshProUGUI _amountText;

		private void Awake()
		{
			_currencyUpdatedEvent.RegisterMainThread(UpdatePermit);
			UpdatePermit();
		}

		private void OnDestroy()
		{
			_currencyUpdatedEvent.UnRegisterMainThread(UpdatePermit);
		}

		private void UpdatePermit()
		{
			_amountText.SetText(_currentCurrency.GetResourceCount(_expansionPermitResource).ToString());
		}
	}
}
