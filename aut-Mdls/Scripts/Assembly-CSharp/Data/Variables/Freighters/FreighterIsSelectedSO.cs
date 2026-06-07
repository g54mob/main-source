using Data.FactoryFloor.Freighter;
using Presentation.Locators;
using UnityEngine;

namespace Data.Variables.Freighters
{
	[CreateAssetMenu(menuName = "Variables/Freighters/FreighterIsSelectedSO", fileName = "FreighterIsSelectedSO", order = 0)]
	public class FreighterIsSelectedSO : BoolVariableSO
	{
		[SerializeField]
		private FreightersManagerLocator _freightersManagerLocator;

		[SerializeField]
		private IntVariableSO _selectedFreighterInUI;

		public override bool Value
		{
			get
			{
				FreighterObject freighterObject;
				return _freightersManagerLocator.Manager.TryGetFreighter(_selectedFreighterInUI.Value, out freighterObject);
			}
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			_selectedFreighterInUI.ValueChanged += OnValueChanged;
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			_selectedFreighterInUI.ValueChanged -= OnValueChanged;
		}

		private void OnValueChanged(int _)
		{
			SetValue(value: false);
		}
	}
}
