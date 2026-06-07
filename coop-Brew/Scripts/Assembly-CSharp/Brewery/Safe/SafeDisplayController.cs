using Brewery.Items;
using Brewery.Systems;
using UnityEngine;

namespace Brewery.Safe
{
	public class SafeDisplayController : MonoBehaviour
	{
		[Header("References")]
		[SerializeField]
		private SafeInventoryManager inventoryManager;

		[SerializeField]
		private MoneyConfig moneyConfig;

		[SerializeField]
		private MoneyStackDisplayController stackController;

		private bool subscribed;

		private void Awake()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void Subscribe()
		{
		}

		private void Unsubscribe()
		{
		}

		private void OnCurrencyChanged(int currency)
		{
		}

		private void RefreshDisplay(int currency)
		{
		}

		public void ForceRefresh()
		{
		}
	}
}
