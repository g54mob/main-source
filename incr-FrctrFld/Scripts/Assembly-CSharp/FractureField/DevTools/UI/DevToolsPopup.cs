using FractureField.UI.Popups;
using Reactivity;
using Reactivity.Unity.Components;
using TMPro;
using UnityEngine;

namespace FractureField.DevTools.UI
{
	public class DevToolsPopup : Popup
	{
		[Header("Locked References")]
		[SerializeField]
		private RComponent _lockedPanel;

		[SerializeField]
		private TMP_InputField _passwordInput;

		[Header("Unlocked References")]
		[SerializeField]
		private RComponent _unlockedPanel;

		[SerializeField]
		private Transform _currencyCheatsParent;

		[SerializeField]
		private DevToolsCurrencyCheat _pfCurrencyCheat;

		private RBool IsUnlocked { get; }

		protected override void Awake()
		{
		}

		public void ClickedUnlock()
		{
		}
	}
}
