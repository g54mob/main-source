using Data.FactoryFloor.FactoryObjectBehaviours;
using Data.FactoryFloor.Resources;
using UnityEngine;

namespace Presentation.UI.Freighters
{
	public class FreightHubInventorySlotDisplay : MonoBehaviour
	{
		[SerializeField]
		private SettableResourceImage _settableResourceImage;

		[SerializeField]
		private int _slotIndex;

		[SerializeField]
		private ResourceInfoPanelContent _resourceInfoPanelContent;

		private FreightHubBehaviour _freightHub;

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

		private void OnDestroy()
		{
			Unsubscribe();
		}

		private void Unsubscribe()
		{
			if (_freightHub != null)
			{
				_freightHub.OnInSlotChanged.UnRegisterMainThread(OnFreightHubSlotAction);
			}
		}

		public void SetFreightHub(FreightHubBehaviour freightHubBehaviour)
		{
			Unsubscribe();
			_freightHub = freightHubBehaviour;
			_freightHub.OnInSlotChanged.RegisterMainThread(OnFreightHubSlotAction);
			OnFreightHubSlotAction(_slotIndex, _freightHub.GetInSlot(_slotIndex));
		}

		public void Reset()
		{
			Unsubscribe();
			_freightHub = null;
			_settableResourceImage.Reset();
		}

		private void OnFreightHubSlotAction(int slotIndex, FreightHubBehaviour.FreightHubSlot slot)
		{
			if (_slotIndex != slotIndex)
			{
				return;
			}
			if (!slot.HasResource)
			{
				_settableResourceImage.Reset();
				return;
			}
			_amount = slot.Amount;
			_maxAmount = _freightHub.MaxInStorage;
			if (slot.Resource is ShapeResource shapeResource)
			{
				_settableResourceImage.SetShapeData(shapeResource.ShapeData);
			}
			else if (slot.Resource.Data is NonShapeResourceDataSO resourceData)
			{
				_settableResourceImage.SetResourceData(resourceData);
			}
			UpdateAmountInfo();
		}
	}
}
