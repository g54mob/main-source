using System;
using System.Collections.Generic;
using Restory.Data.SaveLoad;
using Restory.Data.SaveLoad.Containers;
using Restory.Data.SaveLoad.DataMigration;
using Restory.Gameplay.Effects;
using Restory.Gameplay.InteractiveObjects;
using Restory.Gameplay.Inventory;
using Restory.Gameplay.SaveLoad.Exceptions;
using UnityEngine;
using UnityEngine.Pool;
using Zenject;

namespace Restory.Gameplay.MoneyCash
{
	public class CashMoneyService : MonoBehaviour, ISaveableComponent, ISaveableComponentReader, ISaveableComponentWriter, IPostRestoreComponent
	{
		private Wallet wallet;

		private MoneyFromNpcReceivingSpace moneyFromNpcReceivingSpace;

		private CashMoneyObjectFactory factory;

		private CashMoneyObjectRegistry registry;

		private InteractiveObjectRegistry interactiveObjectRegistry;

		private VfxService vfxService;

		private IDService idService;

		private CashMoneyObject cashMoneyObjectCurrentlyInReceivingFromNpcsSpace;

		private CashMoneyServiceSaveData restoredState;

		[Inject]
		private void Construct(Wallet wallet, CashMoneyObjectFactory factory, CashMoneyObjectRegistry registry, InteractiveObjectRegistry interactiveObjectRegistry, MoneyFromNpcReceivingSpace moneyFromNpcReceivingSpace, VfxService vfxService, IDService idService)
		{
			this.moneyFromNpcReceivingSpace = moneyFromNpcReceivingSpace;
			this.wallet = wallet;
			this.factory = factory;
			this.registry = registry;
			this.interactiveObjectRegistry = interactiveObjectRegistry;
			this.vfxService = vfxService;
			this.idService = idService;
		}

		public void AddMoneyFromNpcToWindowSpace(int moneyAmount)
		{
			if ((bool)cashMoneyObjectCurrentlyInReceivingFromNpcsSpace)
			{
				cashMoneyObjectCurrentlyInReceivingFromNpcsSpace.AddMoney(moneyAmount);
				vfxService.PlayPlacementEffect(moneyFromNpcReceivingSpace.ParentForMoneyItems);
				return;
			}
			CashMoneyObject cashMoneyObject = factory.Create(moneyAmount, moneyFromNpcReceivingSpace.ParentForMoneyItems);
			cashMoneyObject.InteractiveObject.Init(InteractiveObjectState.Stored, idService.GenerateNew(), false);
			registry.Register(cashMoneyObject);
			interactiveObjectRegistry.Register(cashMoneyObject.InteractiveObject, factory.CashMoneyItemInfo);
			vfxService.PlayPlacementEffect(moneyFromNpcReceivingSpace.ParentForMoneyItems);
			cashMoneyObject.transform.Rotate(Vector3.up, UnityEngine.Random.Range(0, 359));
			cashMoneyObjectCurrentlyInReceivingFromNpcsSpace = cashMoneyObject;
			cashMoneyObject.InteractiveObject.OnDragComplete += RemoveMoneyFromNpcReceivingSpace;
		}

		public void TransferMoneyToWallet(CashMoneyObject moneyItemToTransfer)
		{
			if ((bool)moneyItemToTransfer && wallet.TryToAdd(moneyItemToTransfer.MoneyAmountHeld))
			{
				if (moneyItemToTransfer == cashMoneyObjectCurrentlyInReceivingFromNpcsSpace)
				{
					cashMoneyObjectCurrentlyInReceivingFromNpcsSpace.InteractiveObject.OnDragComplete -= RemoveMoneyFromNpcReceivingSpace;
					cashMoneyObjectCurrentlyInReceivingFromNpcsSpace = null;
				}
				registry.Unregister(moneyItemToTransfer);
				interactiveObjectRegistry.Unregister(moneyItemToTransfer.InteractiveObject);
				factory.Destroy(moneyItemToTransfer);
			}
		}

		private void RemoveMoneyFromNpcReceivingSpace()
		{
			if ((bool)cashMoneyObjectCurrentlyInReceivingFromNpcsSpace)
			{
				cashMoneyObjectCurrentlyInReceivingFromNpcsSpace.InteractiveObject.OnDragComplete -= RemoveMoneyFromNpcReceivingSpace;
				cashMoneyObjectCurrentlyInReceivingFromNpcsSpace = null;
			}
		}

		public object CaptureState()
		{
			try
			{
				List<MoneyItemSaveData> list = CollectionPool<List<MoneyItemSaveData>, MoneyItemSaveData>.Get();
				foreach (CashMoneyObject item in registry.All)
				{
					if ((bool)item && !(item == cashMoneyObjectCurrentlyInReceivingFromNpcsSpace))
					{
						list.Add(new MoneyItemSaveData
						{
							ID = item.InteractiveObject.UniqueId,
							MoneyAmount = item.MoneyAmountHeld
						});
					}
				}
				CashMoneyServiceSaveData result = new CashMoneyServiceSaveData
				{
					MoneyOnDesk = (cashMoneyObjectCurrentlyInReceivingFromNpcsSpace ? new MoneyItemSaveData
					{
						ID = cashMoneyObjectCurrentlyInReceivingFromNpcsSpace.InteractiveObject.UniqueId,
						MoneyAmount = cashMoneyObjectCurrentlyInReceivingFromNpcsSpace.MoneyAmountHeld
					} : null),
					OtherMoneyItems = list.ToArray()
				};
				CollectionPool<List<MoneyItemSaveData>, MoneyItemSaveData>.Release(list);
				return result;
			}
			catch (Exception innerException)
			{
				Debug.LogException(new CaptureProgressException(base.gameObject, innerException));
				return null;
			}
		}

		public void RestoreState(object state)
		{
			try
			{
				restoredState = DataMigrationWizard.Migrate<CashMoneyServiceSaveData>(state, base.gameObject);
			}
			catch (Exception innerException)
			{
				Debug.LogException(new RestoreProgressException(base.gameObject, state, innerException));
			}
		}

		public void PostRestore()
		{
			if (restoredState == null)
			{
				return;
			}
			List<CashMoneyObject> list = CollectionPool<List<CashMoneyObject>, CashMoneyObject>.Get();
			foreach (InteractiveObject key in interactiveObjectRegistry.All.Keys)
			{
				if (key.TryGetComponent<CashMoneyObject>(out var component))
				{
					list.Add(component);
				}
			}
			if (restoredState.MoneyOnDesk != null)
			{
				foreach (CashMoneyObject item in list)
				{
					if (item.InteractiveObject.UniqueId == restoredState.MoneyOnDesk.ID)
					{
						item.SetUp(restoredState.MoneyOnDesk.MoneyAmount);
						cashMoneyObjectCurrentlyInReceivingFromNpcsSpace = item;
						registry.Register(item);
						break;
					}
				}
			}
			MoneyItemSaveData[] otherMoneyItems = restoredState.OtherMoneyItems;
			foreach (MoneyItemSaveData moneyItemSaveData in otherMoneyItems)
			{
				foreach (CashMoneyObject item2 in list)
				{
					if (item2.InteractiveObject.UniqueId == moneyItemSaveData.ID)
					{
						item2.SetUp(moneyItemSaveData.MoneyAmount);
						registry.Register(item2);
					}
				}
			}
			CollectionPool<List<CashMoneyObject>, CashMoneyObject>.Release(list);
		}
	}
}
