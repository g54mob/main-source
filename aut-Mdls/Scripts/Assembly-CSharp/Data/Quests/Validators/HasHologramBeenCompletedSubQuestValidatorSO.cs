using Data.FactoryFloor;
using Data.Quests.QuestData;
using Data.Quests.SubQuestEvents;
using UnityEngine;

namespace Data.Quests.Validators
{
	[CreateAssetMenu(menuName = "Quests/Validators/Has Hologram Been Completed", fileName = "HasHologramBeenCompleted", order = 3)]
	public class HasHologramBeenCompletedSubQuestValidatorSO : AbstractSubQuestValidatorSO
	{
		[SerializeField]
		private ShowHologramSubQuestEventSO _hologramEvent;

		[SerializeField]
		private FactoryLayer _factoryLayer;

		private bool _init;

		private bool _allFactoryObjectWerePlaced;

		private int _correctlyCompletedHologramCount;

		public override bool IsValid()
		{
			if (!_init)
			{
				HandleObjectsChanged(_factoryLayer);
				_factoryLayer.OnObjectsInLayerChanged += HandleObjectsChanged;
				_init = true;
			}
			return _allFactoryObjectWerePlaced;
		}

		private void HandleObjectsChanged(FactoryLayer obj)
		{
			_correctlyCompletedHologramCount = 0;
			bool flag = true;
			foreach (HologramPlacementData hologramPlacementData in _hologramEvent.HologramPlacementDatas)
			{
				FactoryObject objectAt = _factoryLayer.GetObjectAt(hologramPlacementData.Position);
				if (objectAt == null || objectAt.FactoryObjectData != hologramPlacementData.OnboardingHologramView.FactoryObjectData || (hologramPlacementData.RotationRequired && objectAt.Rotation != hologramPlacementData.Rotation) || objectAt.Position != hologramPlacementData.Position)
				{
					flag = false;
				}
				else
				{
					_correctlyCompletedHologramCount++;
				}
			}
			if (flag)
			{
				_factoryLayer.OnObjectsInLayerChanged -= HandleObjectsChanged;
				_allFactoryObjectWerePlaced = true;
			}
		}

		public override float GetProgress()
		{
			return _correctlyCompletedHologramCount;
		}

		public override float GetProgressTarget()
		{
			return _hologramEvent.HologramPlacementDatas.Count;
		}

		public override void Reset()
		{
			_correctlyCompletedHologramCount = 0;
			_init = false;
			_allFactoryObjectWerePlaced = false;
			if (_factoryLayer != null)
			{
				_factoryLayer.OnObjectsInLayerChanged -= HandleObjectsChanged;
			}
		}
	}
}
