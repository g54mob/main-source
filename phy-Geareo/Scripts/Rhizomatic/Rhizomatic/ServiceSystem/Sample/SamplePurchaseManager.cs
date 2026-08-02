using System;
using TMPro;
using UnityEngine;

namespace Rhizomatic.ServiceSystem.Sample
{
	public class SamplePurchaseManager : MonoBehaviour
	{
		public TMP_Text productId;

		public GameObject canvas;

		public GameObject purchasePanel;

		public GameObject alreadyPurchasedPanel;

		public Action onSuccess;

		public Action onFail;

		private void Start()
		{
		}

		public void ShowPurchasePanel(string sku, Action onSuccess, Action onFail)
		{
		}

		public void ShowAlreadyPurchasedPanel(string sku, Action onSuccess, Action onFail)
		{
		}

		public void CloseAll()
		{
		}

		public void Purchase()
		{
		}

		public void Cancel()
		{
		}
	}
}
