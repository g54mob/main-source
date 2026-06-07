using System;
using FractureField.Shared.Enums;
using Reactivity.Unity.Components;
using UnityEngine;
using UnityEngine.UI;

namespace FractureField.UI.Components
{
	[Serializable]
	public class Icon : MonoBehaviour
	{
		[Header("References")]
		[SerializeField]
		private RImage _icon;

		[SerializeField]
		private CurrencyIcon _currencyIcon;

		[SerializeField]
		private LayoutElement _layoutElement;

		public void Sprite(Sprite sprite)
		{
		}

		public void Sprite(Func<Sprite> getter)
		{
		}

		public void Currency(CurrencyType currencyType)
		{
		}
	}
}
