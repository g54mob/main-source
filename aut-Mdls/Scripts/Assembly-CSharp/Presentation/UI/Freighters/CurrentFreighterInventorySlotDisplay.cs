using Data.Variables;
using Presentation.Locators;
using UnityEngine;

namespace Presentation.UI.Freighters
{
	public class CurrentFreighterInventorySlotDisplay : FreighterInventorySlotDisplay
	{
		[SerializeField]
		private FreightersManagerLocator _freightersManagerLocator;

		[SerializeField]
		private IntVariableSO _selectedFreighterInUI;

		private void Start()
		{
			_selectedFreighterInUI.ValueChanged += OnSelectedFreighterChanged;
			OnSelectedFreighterChanged(_selectedFreighterInUI.Value);
		}

		protected override void OnDestroy()
		{
			_selectedFreighterInUI.ValueChanged -= OnSelectedFreighterChanged;
			base.OnDestroy();
		}

		private void OnSelectedFreighterChanged(int createdId)
		{
			Unsubscribe();
			if (_freightersManagerLocator.Manager.TryGetFreighter(createdId, out _freighter))
			{
				SelectFreighter(_freighter);
			}
		}
	}
}
