using System;
using System.Collections.Generic;
using System.Linq;
using Restory.Data.SaveLoad;
using Restory.Data.SaveLoad.Containers;
using Restory.Data.SaveLoad.DataMigration;
using Restory.Data.Shops.Devices;
using Restory.Gameplay.SaveLoad.Exceptions;
using Restory.Gameplay.TimeSystems;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Shops.Devices
{
	public class DeviceShopSupplier : MonoBehaviour, ISaveableComponent, ISaveableComponentReader, ISaveableComponentWriter, ITimeChangeReceiver
	{
		[SerializeField]
		private List<DeviceShopBatch> batches;

		[SerializeField]
		[Min(1f)]
		private int maxDevicesCountInShop = 15;

		[SerializeField]
		[Min(0f)]
		private int maxElementsBoxesCountInShop = 15;

		private GameCalendar gameCalendar;

		private ShopsService shopsService;

		private DeviceShopRandomDevicesGenerationService randomDevicesGenerator;

		private DeviceShopRandomElementsBoxesGenerationService randomElementsBoxesGenerator;

		private int suppliedBatchCount;

		private int lastSupplyDayNumber;

		private readonly List<IDeviceShopLot> lotsForToday = new List<IDeviceShopLot>();

		private readonly List<IElementsBoxLot> elementsBoxesForToday = new List<IElementsBoxLot>();

		private DateTime firstDayMidnightTime;

		[Inject]
		private void Construct(GameCalendar gameCalendar, ShopsService shopsService, DeviceShopRandomDevicesGenerationService randomDevicesGenerator, DeviceShopRandomElementsBoxesGenerationService randomElementsBoxesGenerator)
		{
			this.gameCalendar = gameCalendar;
			this.shopsService = shopsService;
			this.randomDevicesGenerator = randomDevicesGenerator;
			this.randomElementsBoxesGenerator = randomElementsBoxesGenerator;
			if (base.isActiveAndEnabled)
			{
				Init();
			}
		}

		private void OnEnable()
		{
			if ((bool)gameCalendar)
			{
				Init();
			}
		}

		private void Init()
		{
			firstDayMidnightTime = gameCalendar.StartingTime - gameCalendar.StartingTime.TimeOfDay;
			gameCalendar.AddSubscriber(this);
		}

		private void OnDisable()
		{
			if (gameCalendar.MonoShellExists())
			{
				gameCalendar.RemoveSubscriber(this);
			}
		}

		public void SupplyNextBatchIfNecessary()
		{
			if (lastSupplyDayNumber < gameCalendar.CurrentDayNumber)
			{
				SupplyNextBatch();
			}
		}

		private void SupplyNextBatch()
		{
			lastSupplyDayNumber = gameCalendar.CurrentDayNumber;
			bool flag = batches.Count == 0 || suppliedBatchCount >= batches.Count;
			if (shopsService.Lots.Count((ILot l) => l is IDeviceShopLot) < maxDevicesCountInShop)
			{
				if (flag)
				{
					lotsForToday.AddRange(randomDevicesGenerator.GetRandomlyGeneratedDeviceShopLots());
				}
				else
				{
					int index = suppliedBatchCount % batches.Count;
					lotsForToday.AddRange(batches[index].Lots);
					suppliedBatchCount++;
				}
			}
			if (flag && shopsService.Lots.Count((ILot l) => l is IElementsBoxLot) < maxElementsBoxesCountInShop)
			{
				elementsBoxesForToday.AddRange(randomElementsBoxesGenerator.GetRandomlyGeneratedElementsBoxes());
			}
		}

		public void ProcessTimeChanged()
		{
			for (int num = lotsForToday.Count - 1; num >= 0; num--)
			{
				IDeviceShopLot deviceShopLot = lotsForToday[num];
				if (!(deviceShopLot is RandomlyGeneratedDeviceShopLot randomlyGeneratedDeviceShopLot))
				{
					if (!(deviceShopLot is DeviceShopLot { PublicationTime: var publicationTime } deviceShopLot2))
					{
						throw new NotImplementedException();
					}
					TimeSpan timeSpan = publicationTime.InTimeSpan();
					if (deviceShopLot2.PublicationTime.Hours < gameCalendar.StartingTime.Hour)
					{
						timeSpan += TimeSpan.FromDays(1.0);
					}
					if (firstDayMidnightTime + TimeSpan.FromDays(deviceShopLot2.Day) + timeSpan < gameCalendar.CurrentDateTime)
					{
						shopsService.SupplyDeviceLot(deviceShopLot);
						lotsForToday.RemoveAt(num);
					}
				}
				else if (randomlyGeneratedDeviceShopLot.PostedDateTime < gameCalendar.CurrentDateTime)
				{
					shopsService.SupplyDeviceLot(deviceShopLot);
					lotsForToday.RemoveAt(num);
				}
			}
			for (int num2 = elementsBoxesForToday.Count - 1; num2 >= 0; num2--)
			{
				IElementsBoxLot elementsBoxLot = elementsBoxesForToday[num2];
				if (((elementsBoxLot as RandomlyGeneratedElementsBoxLot) ?? throw new NotImplementedException()).PostedDateTime < gameCalendar.CurrentDateTime)
				{
					shopsService.SupplyDeviceLot(elementsBoxLot);
					elementsBoxesForToday.RemoveAt(num2);
				}
			}
		}

		public void RestoreState(object state)
		{
			try
			{
				DeviceShopSupplierSaveData deviceShopSupplierSaveData = DataMigrationWizard.Migrate<DeviceShopSupplierSaveData>(state, base.gameObject);
				suppliedBatchCount = deviceShopSupplierSaveData.SuppliedBatchCount;
				lastSupplyDayNumber = deviceShopSupplierSaveData.LastSupplyDayNumber;
				lotsForToday.Clear();
				if (deviceShopSupplierSaveData.RemainingLotsForToday != null)
				{
					lotsForToday.AddRange(deviceShopSupplierSaveData.RemainingLotsForToday);
					RestoreBackgroundIconsInRandomlyGeneratedLots(lotsForToday);
				}
				elementsBoxesForToday.Clear();
				if (deviceShopSupplierSaveData.RemainingElementsBoxesForToday != null)
				{
					elementsBoxesForToday.AddRange(deviceShopSupplierSaveData.RemainingElementsBoxesForToday);
					RestoreBackgroundIconsInRandomlyGeneratedElementsBoxes(elementsBoxesForToday);
				}
				if (deviceShopSupplierSaveData.ActiveLots != null)
				{
					RestoreBackgroundIconsInRandomlyGeneratedLots(deviceShopSupplierSaveData.ActiveLots);
					shopsService.SupplyDeviceLots(deviceShopSupplierSaveData.ActiveLots);
				}
				if (deviceShopSupplierSaveData.ActiveElementsBoxes != null)
				{
					RestoreBackgroundIconsInRandomlyGeneratedElementsBoxes(deviceShopSupplierSaveData.ActiveElementsBoxes);
					shopsService.SupplyDeviceLots(deviceShopSupplierSaveData.ActiveElementsBoxes);
				}
			}
			catch (Exception innerException)
			{
				Debug.LogException(new RestoreProgressException(base.gameObject, state, innerException));
			}
		}

		private void RestoreBackgroundIconsInRandomlyGeneratedLots(List<IDeviceShopLot> lots)
		{
			foreach (IDeviceShopLot lot in lots)
			{
				if (lot is RandomlyGeneratedDeviceShopLot randomlyGeneratedDeviceShopLot)
				{
					RestoreBackgroundIcon(randomlyGeneratedDeviceShopLot);
				}
			}
		}

		private void RestoreBackgroundIcon(RandomlyGeneratedDeviceShopLot randomlyGeneratedDeviceShopLot)
		{
			if (randomDevicesGenerator.TryGetBackgroundIconByID(randomlyGeneratedDeviceShopLot.Device.DeviceInfo, randomlyGeneratedDeviceShopLot.BackgroundIconID, out var foundIcon))
			{
				randomlyGeneratedDeviceShopLot.SetBackgroundIcon(randomlyGeneratedDeviceShopLot.BackgroundIconID, foundIcon);
				return;
			}
			randomDevicesGenerator.PickRandomBackgroundIcon(randomlyGeneratedDeviceShopLot.Device.DeviceInfo, out var iconID, out var icon);
			randomlyGeneratedDeviceShopLot.SetBackgroundIcon(iconID, icon);
		}

		private void RestoreBackgroundIconsInRandomlyGeneratedElementsBoxes(List<IElementsBoxLot> elementsBoxes)
		{
			foreach (IElementsBoxLot elementsBox in elementsBoxes)
			{
				if (elementsBox is RandomlyGeneratedElementsBoxLot randomlyGeneratedElementsBox)
				{
					RestoreBackgroundIcon(randomlyGeneratedElementsBox);
				}
			}
		}

		private void RestoreBackgroundIcon(RandomlyGeneratedElementsBoxLot randomlyGeneratedElementsBox)
		{
			if (randomElementsBoxesGenerator.TryGetBackgroundIconByID(randomlyGeneratedElementsBox.BackgroundIconID, out var foundIcon))
			{
				randomlyGeneratedElementsBox.SetBackgroundIcon(randomlyGeneratedElementsBox.BackgroundIconID, foundIcon);
				return;
			}
			randomElementsBoxesGenerator.PickRandomBackgroundIcon(out var iconID, out var icon);
			randomlyGeneratedElementsBox.SetBackgroundIcon(iconID, icon);
		}

		public object CaptureState()
		{
			try
			{
				return new DeviceShopSupplierSaveData
				{
					ActiveLots = shopsService.Lots.OfType<IDeviceShopLot>().ToList(),
					ActiveElementsBoxes = shopsService.Lots.OfType<IElementsBoxLot>().ToList(),
					SuppliedBatchCount = suppliedBatchCount,
					LastSupplyDayNumber = lastSupplyDayNumber,
					RemainingLotsForToday = lotsForToday.ToList(),
					RemainingElementsBoxesForToday = elementsBoxesForToday.ToList()
				};
			}
			catch (Exception innerException)
			{
				Debug.LogException(new CaptureProgressException(base.gameObject, innerException));
				return null;
			}
		}
	}
}
