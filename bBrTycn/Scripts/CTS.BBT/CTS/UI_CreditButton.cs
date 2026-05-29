using System;
using CTS.UI;
using UnityEngine;

namespace CTS
{
	public class UI_CreditButton : MonoBehaviour
	{
		private CTSButton _creditButton;

		public static event Action ClickButton;

		private void Awake()
		{
			_creditButton = GetComponent<CTSButton>();
			_creditButton.onClick.AddListener(ActiveButton);
		}

		private void OnDestroy()
		{
			_creditButton.onClick.RemoveAllListeners();
		}

		private void ActiveButton()
		{
			UI_CreditButton.ClickButton?.Invoke();
		}
	}
}
