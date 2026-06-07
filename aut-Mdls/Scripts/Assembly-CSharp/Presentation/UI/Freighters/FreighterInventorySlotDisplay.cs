using Data.FactoryFloor.Freighter;
using Data.FactoryFloor.Freighter.Actions;
using Data.FactoryFloor.Resources;
using Data.Variables;
using UnityEngine;

namespace Presentation.UI.Freighters
{
	public class FreighterInventorySlotDisplay : MonoBehaviour
	{
		[SerializeField]
		private SettableResourceImage _settableResourceImage;

		[SerializeField]
		private int _slotIndex;

		[SerializeField]
		private IntVariableSO _maxFreighterCapacity;

		[SerializeField]
		private ResourceInfoPanelContent _resourceInfoPanelContent;

		protected FreighterObject _freighter;

		private int _amount;

		private int _maxAmount;

		private void OnEnable()
		{
			if ((bool)_resourceInfoPanelContent)
			{
				_resourceInfoPanelContent.OnShow += UpdateAmountInfo;
			}
		}

		private void OnDisable()
		{
			if ((bool)_resourceInfoPanelContent)
			{
				_resourceInfoPanelContent.OnShow -= UpdateAmountInfo;
			}
		}

		private void UpdateAmountInfo()
		{
			if ((bool)_resourceInfoPanelContent)
			{
				_resourceInfoPanelContent.UpdateAmountInfo(_amount, _maxAmount);
			}
		}

		protected virtual void OnDestroy()
		{
			Unsubscribe();
		}

		protected void Unsubscribe()
		{
			if (_freighter != null)
			{
				_freighter.Slots.OnFreighterSlotAction.UnRegisterMainThread(OnFreighterSlotAction);
			}
		}

		public void SelectFreighter(FreighterObject freighterObject)
		{
			Unsubscribe();
			_freighter = freighterObject;
			_freighter.Slots.OnFreighterSlotAction.RegisterMainThread(OnFreighterSlotAction);
			for (int i = 0; i < 4; i++)
			{
				OnFreighterSlotAction(i, null, 0);
			}
		}

		protected void OnFreighterSlotAction(int slotIndex, FreighterSlotAction _, int amountBeforeAction)
		{
			if (_slotIndex != slotIndex)
			{
				return;
			}
			if (!_freighter.Slots.StorageSlots[slotIndex].HasResource)
			{
				_settableResourceImage.Reset();
				return;
			}
			_amount = _freighter.Slots.StorageSlots[slotIndex].Amount;
			_maxAmount = _maxFreighterCapacity.Value;
			if (_freighter.Slots.StorageSlots[slotIndex].Resource is ShapeResource shapeResource)
			{
				_settableResourceImage.SetShapeData(shapeResource.ShapeData);
			}
			else if (_freighter.Slots.StorageSlots[slotIndex].Resource.Data is NonShapeResourceDataSO resourceData)
			{
				_settableResourceImage.SetResourceData(resourceData);
			}
			UpdateAmountInfo();
		}
	}
}
