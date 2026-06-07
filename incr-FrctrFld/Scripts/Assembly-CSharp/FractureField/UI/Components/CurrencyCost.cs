using System;
using FractureField.Shared.Enums;
using Reactivity.Unity.Components;
using UnityEngine;

namespace FractureField.UI.Components
{
	public class CurrencyCost : RComponent
	{
		[Header("Variables")]
		public CurrencyType CurrencyType;

		public bool FreeWhenZero;

		public bool MaxWhenMax;

		[Header("References")]
		[SerializeField]
		private IconWithText _iconWithText;

		private float AvailableCurrency => 0f;

		public void SetCurrency(CurrencyType currencyType)
		{
		}

		public void SetCost(string cost)
		{
		}

		public void SetCost(Func<string> getter)
		{
		}

		private void Setup()
		{
		}

		public void Setup(CurrencyType currencyType, Func<float> costGetter, Func<float> availableGetter = null, bool freeWhenZero = true, bool maxWhenMax = false)
		{
		}

		private void OnValidate()
		{
		}
	}
}
