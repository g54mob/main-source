using Data.Variables;
using Events;
using UnityEngine;

namespace Data.Quests.Validators
{
	[CreateAssetMenu(menuName = "Quests/Validators/Has Crane Been Placed", fileName = "HasCraneBeenPlaced", order = 3)]
	public class HasCraneBeenPlacedSubQuestValidatorSO : AbstractSubQuestValidatorSO
	{
		[SerializeField]
		private BaseEvent _placeBuildingCraneEvent;

		[SerializeField]
		private CranesLibrarySO _cranesLibrary;

		[SerializeField]
		private int _requiredAmount = 1;

		private bool _init;

		private bool _enoughCranesPlaced;

		public override bool IsValid()
		{
			if (!_init)
			{
				if (EnoughCranes())
				{
					return true;
				}
				_placeBuildingCraneEvent.Register(OnPlaceBuildingCraneEvent);
				_init = true;
			}
			return _enoughCranesPlaced;
		}

		private void OnPlaceBuildingCraneEvent()
		{
			_enoughCranesPlaced = EnoughCranes();
		}

		private bool EnoughCranes()
		{
			return _cranesLibrary.GetUniqueCranesAmount() >= _requiredAmount;
		}

		public override void Reset()
		{
			_placeBuildingCraneEvent.UnRegister(OnPlaceBuildingCraneEvent);
			_init = false;
			_enoughCranesPlaced = false;
		}
	}
}
