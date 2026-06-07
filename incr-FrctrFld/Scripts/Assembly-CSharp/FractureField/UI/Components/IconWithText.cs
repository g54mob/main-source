using System;
using FractureField.Shared.Enums;
using Reactivity.Unity.Components;
using UnityEngine;

namespace FractureField.UI.Components
{
	public class IconWithText : RComponent
	{
		[Header("References")]
		public Icon Icon;

		public RText Text;

		public void SetIcon(Sprite sprite)
		{
		}

		public void SetIcon(Func<Sprite> getter)
		{
		}

		public void SetCurrency(CurrencyType currencyType)
		{
		}

		public void SetText(string text)
		{
		}

		public void SetText(Func<string> getter)
		{
		}
	}
}
