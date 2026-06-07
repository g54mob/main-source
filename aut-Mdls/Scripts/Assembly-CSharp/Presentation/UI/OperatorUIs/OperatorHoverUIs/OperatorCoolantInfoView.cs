using Data.FactoryFloor;
using Data.FactoryFloor.Drones;
using Data.FactoryFloor.Resources;
using TMPro;
using UnityEngine;

namespace Presentation.UI.OperatorUIs.OperatorHoverUIs
{
	public class OperatorCoolantInfoView : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI _currentCoolantText;

		[SerializeField]
		private TextMeshProUGUI _currentOperationsText;

		[SerializeField]
		[LocaKey]
		private string _coolantLocaKey;

		[SerializeField]
		[LocaKey]
		private string _operationsLocaKey;

		private SupplyTankRecipientBehaviour _supplyTankRecipientBehaviour;

		private void OnEnable()
		{
			if ((bool)_supplyTankRecipientBehaviour)
			{
				_supplyTankRecipientBehaviour.OnCapsuleFillPercChanged.UnRegisterMainThread(UpdateCoolantAndOperationCounts);
				_supplyTankRecipientBehaviour.OnReceiveCapsule.UnRegisterMainThread(UpdateCoolantAndOperationCounts);
				_supplyTankRecipientBehaviour.OnCapsuleFillPercChanged.RegisterMainThread(UpdateCoolantAndOperationCounts);
				_supplyTankRecipientBehaviour.OnReceiveCapsule.RegisterMainThread(UpdateCoolantAndOperationCounts);
			}
		}

		private void OnDisable()
		{
			if ((bool)_supplyTankRecipientBehaviour)
			{
				_supplyTankRecipientBehaviour.OnCapsuleFillPercChanged.UnRegisterMainThread(UpdateCoolantAndOperationCounts);
				_supplyTankRecipientBehaviour.OnReceiveCapsule.UnRegisterMainThread(UpdateCoolantAndOperationCounts);
			}
		}

		public bool SetContent(FactoryObject factoryObject)
		{
			int num;
			if (factoryObject.TryGetFactoryObjectBehaviour<SupplyTankRecipientBehaviour>(out _supplyTankRecipientBehaviour))
			{
				num = (_supplyTankRecipientBehaviour.NeedsSupplyTank ? 1 : 0);
				if (num != 0)
				{
					UpdateCoolantAndOperationCounts(_supplyTankRecipientBehaviour);
				}
			}
			else
			{
				num = 0;
			}
			return (byte)num != 0;
		}

		private void UpdateCoolantAndOperationCounts(SupplyTankRecipientBehaviour supplyTankRecipientBehaviour)
		{
			string text = (supplyTankRecipientBehaviour.HasCapsule ? "1" : "<style=\"Error\">0</style>");
			string arg = ((supplyTankRecipientBehaviour.CurrentResourceAmount == 0) ? "<style=\"Error\">0</style>" : supplyTankRecipientBehaviour.CurrentResourceAmount.ToString());
			string text2 = $"{arg}/{supplyTankRecipientBehaviour.OperationsPerResource}";
			_currentCoolantText.SetText(LocalizationUtility.GetLocalizedText(_coolantLocaKey) + "\n" + text + "/1");
			_currentOperationsText.SetText(LocalizationUtility.GetLocalizedText(_operationsLocaKey) + "\n" + text2);
		}

		private void UpdateCoolantAndOperationCounts(float _)
		{
			if (!(_supplyTankRecipientBehaviour == null))
			{
				UpdateCoolantAndOperationCounts(_supplyTankRecipientBehaviour);
			}
		}

		private void UpdateCoolantAndOperationCounts(ResourceDataSO _)
		{
			if (!(_supplyTankRecipientBehaviour == null))
			{
				UpdateCoolantAndOperationCounts(_supplyTankRecipientBehaviour);
			}
		}
	}
}
