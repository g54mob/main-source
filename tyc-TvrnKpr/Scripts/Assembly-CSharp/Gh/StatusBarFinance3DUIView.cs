using System;
using TMPro;
using UnityEngine;

namespace Gh
{
	public class StatusBarFinance3DUIView : MonoBehaviour
	{
		[SerializeField]
		private TextMeshPro _moneyValueText;

		private int _currentValue;

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		private void OnUIReset(object sender, EventArgs args)
		{
		}

		private void OnUITick(object sender, EventArgs args)
		{
		}

		protected void OnUpdateTick()
		{
		}

		private void OnEnable()
		{
		}

		private void UpdateMoneyText(bool forceUpdate = false)
		{
		}
	}
}
