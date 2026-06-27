using System;
using System.Collections.Generic;
using Restory.Data.Devices;
using Restory.Data.Elements;
using Restory.Data.Elements.Condition;
using Restory.Data.SaveLoad;
using Restory.Gameplay.Delivery;
using Restory.Gameplay.Elements;
using Restory.Gameplay.InteractiveObjects;
using Restory.Gameplay.Inventory;
using Restory.Gameplay.Licenses;
using Restory.Gameplay.Statistics;
using Restory.Gameplay.WorkOrders.EmailOrders;
using UnityEngine;
using UnityEngine.Pool;
using Zenject;

namespace Restory.Gameplay.Competitions
{
	public class CompetitionsApp : MonoBehaviour
	{
		private const string GENERATED_DEVICE_CONDITION_PREFIX = "competitionGeneratedDevice_";

		private IDService idService;

		private Wallet wallet;

		private LicensesService licensesService;

		private DeliveryService deliveryService;

		private GameStatisticsService gameStatistics;

		private DefaultElementConditions defaultElementConditions;

		private DeviceInfoDatabase deviceInfoDatabase;

		private CompetitionsResultsTrackingService resultsTrackingService;

		public IReadOnlyCollection<IDeviceInfo> AvailableDevices => deviceInfoDatabase.Devices;

		public Wallet Wallet => wallet;

		public LicensesService LicensesService => licensesService;

		public CompetitionsResultsTrackingService ResultsTrackingService => resultsTrackingService;

		public event Action<CompetitionsApp, DeviceInfo> OnCompetitionRequestsChanged;

		[Inject]
		public void Construct(Wallet wallet, LicensesService licensesService, DeliveryService deliveryService, GameStatisticsService gameStatistics, DefaultElementConditions defaultElementConditions, IDService idService, DeviceInfoDatabase deviceInfoDatabase, CompetitionsResultsTrackingService resultsTrackingService)
		{
			this.wallet = wallet;
			this.licensesService = licensesService;
			this.deliveryService = deliveryService;
			this.gameStatistics = gameStatistics;
			this.defaultElementConditions = defaultElementConditions;
			this.idService = idService;
			this.deviceInfoDatabase = deviceInfoDatabase;
			this.resultsTrackingService = resultsTrackingService;
		}

		public bool TryCompleteRequestAndSubmitDevice(DeviceInfo device)
		{
			if (!wallet.TryToRemove(device.CompetitionParticipationPrice))
			{
				Debug.LogError($"[CompetitionsDevicesShopInteractor] Not enough money to purchase device {device}. Cannot submit a request and submit device.");
				return false;
			}
			deliveryService.SendToDelivery(GenerateCompetitionDeviceCondition(device, out var generatedId), new GeneratedDeviceProperty(generatedId, device.CompetitionReward));
			this.OnCompetitionRequestsChanged?.Invoke(this, device);
			gameStatistics.ProcessDevicesPurchasedInShop(device.CompetitionParticipationPrice);
			return true;
		}

		private RandomlyGeneratedDeviceCondition GenerateCompetitionDeviceCondition(DeviceInfo device, out string generatedId)
		{
			generatedId = "competitionGeneratedDevice_" + idService.GenerateNew();
			List<ElementData> value;
			using (CollectionPool<List<ElementData>, ElementData>.Get(out value))
			{
				foreach (IElementInfo element in device.Elements)
				{
					if (element is ElementInfo info)
					{
						value.Add(new ElementData
						{
							Info = info,
							Condition = defaultElementConditions.PerfectElementCondition
						});
					}
				}
				return new RandomlyGeneratedDeviceCondition(generatedId, device, null, value, isPartOfCompetition: true);
			}
		}
	}
}
