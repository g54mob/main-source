using FractureField.Shared.Enums;
using FractureField.UI.Components;
using TMPro;
using UnityEngine;

namespace FractureField.DevTools.UI
{
	public class DevToolsCurrencyCheat : MonoBehaviour
	{
		[Header("Variables")]
		[SerializeField]
		private CurrencyType _currencyType;

		[Header("References")]
		[SerializeField]
		private CurrencyIcon _currencyIcon;

		[SerializeField]
		private TMP_Text _title;

		[SerializeField]
		private TMP_InputField _input;

		private void Awake()
		{
		}

		public void Setup(CurrencyType currencyType)
		{
		}

		public void Setup()
		{
		}

		public void ClickedAdd()
		{
		}

		private void OnValidate()
		{
		}
	}
}
