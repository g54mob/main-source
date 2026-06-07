using System.Collections.Generic;
using FractureField.UI.Components;
using Reactivity.Unity.Components;
using UnityEngine;

namespace FractureField.UI.Popups.QuarryForeman
{
	public class QuarryForemanPopup : Popup
	{
		[Header("References")]
		[SerializeField]
		private ToggleWithLabel _isEnabledToggle;

		[SerializeField]
		private RText _availableCoreFragmentsText;

		[SerializeField]
		private List<QuarryForemanPriorityRow> _generalRows;

		protected override void Awake()
		{
		}

		private void Setup()
		{
		}

		public void ClickedUpgradeInterval()
		{
		}
	}
}
