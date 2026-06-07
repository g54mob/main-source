using FractureField.Shared.Enums;
using Reactivity.Unity.Components;
using UnityEngine;
using UnityEngine.UI;

namespace FractureField.UI.Components
{
	public class CurrencyIcon : RComponent
	{
		[Header("Variables")]
		public CurrencyType Type;

		[Header("References")]
		[SerializeField]
		private Image _image;

		protected override void Awake()
		{
		}

		public void Setup()
		{
		}

		public void Setup(CurrencyType type)
		{
		}

		private void OnValidate()
		{
		}
	}
}
