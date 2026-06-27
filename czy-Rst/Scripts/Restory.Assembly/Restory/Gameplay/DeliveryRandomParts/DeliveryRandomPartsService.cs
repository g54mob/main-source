using System;
using System.Collections.Generic;
using System.Linq;
using Restory.Data.Devices;
using Restory.Data.Elements;
using Restory.Data.Elements.Condition;
using Restory.Data.SaveLoad;
using Restory.Data.SaveLoad.Containers;
using Restory.Data.SaveLoad.DataMigration;
using Restory.Gameplay.Delivery;
using Restory.Gameplay.Elements;
using Restory.Gameplay.SaveLoad.Exceptions;
using Restory.Gameplay.Shops.Devices;
using Restory.Gameplay.TextureMasks;
using Restory.Gameplay.TimeSystems;
using Restory.Gameplay.WorkOrders.EmailOrders;
using Restory.Utils;
using UnityEngine;
using UnityEngine.Pool;
using Zenject;

namespace Restory.Gameplay.DeliveryRandomParts
{
	public class DeliveryRandomPartsService : MonoBehaviour, IInitializable, IDisposable, ISaveableComponent, ISaveableComponentReader, ISaveableComponentWriter, ITimeChangeReceiver
	{
		[SerializeField]
		private ElementsBoxInfo elementsBoxInfo;

		private bool isRunning;

		private DeliveryRandomPartsSettings settings;

		private int lastDayDeliveryWasSent = -1;

		private int startDayDelivery = -1;

		private ElementService elementService;

		private DeliveryService deliveryService;

		private GameCalendar gameCalendar;

		private AvailableDevicesListTrackingService availableDevicesListTrackingService;

		private AvailableDevicesWorkTypesTrackingService availableWorkTypesTrackingService;

		private DefaultElementConditions defaultElementConditions;

		private ElementDirtMaskPresetSelectionService elementDirtMaskPresetSelectionService;

		private TextureMaskCreationService textureMaskCreator;

		public bool IsRunning => isRunning;

		[Inject]
		private void Construct(DeliveryRandomPartsSettings settings, ElementService elementService, DeliveryService deliveryService, GameCalendar gameCalendar, AvailableDevicesListTrackingService availableDevicesListTrackingService, AvailableDevicesWorkTypesTrackingService availableWorkTypesTrackingService, DefaultElementConditions defaultElementConditions, ElementDirtMaskPresetSelectionService elementDirtMaskPresetSelectionService, TextureMaskCreationService textureMaskCreator)
		{
			this.settings = settings;
			this.elementService = elementService;
			this.deliveryService = deliveryService;
			this.gameCalendar = gameCalendar;
			this.availableDevicesListTrackingService = availableDevicesListTrackingService;
			this.availableWorkTypesTrackingService = availableWorkTypesTrackingService;
			this.defaultElementConditions = defaultElementConditions;
			this.elementDirtMaskPresetSelectionService = elementDirtMaskPresetSelectionService;
			this.textureMaskCreator = textureMaskCreator;
		}

		public void Initialize()
		{
			if (gameCalendar.MonoShellExists())
			{
				gameCalendar.AddSubscriber(this);
			}
		}

		public void Dispose()
		{
			isRunning = false;
			if (gameCalendar.MonoShellExists())
			{
				gameCalendar.RemoveSubscriber(this);
			}
		}

		void ITimeChangeReceiver.ProcessTimeChanged()
		{
			if (isRunning && gameCalendar.CurrentDayNumber >= startDayDelivery && gameCalendar.CurrentDayNumber - lastDayDeliveryWasSent >= settings.DeliveryFrequencyInDays && !(gameCalendar.CurrentDateTime.TimeOfDay < settings.DeliveryTimeOfDay.InTimeSpan()))
			{
				SendToDelivery(updateLastDayDeliveryWasSent: true);
			}
		}

		public void StartDeliveryNextDay()
		{
			if (gameCalendar.MonoShellExists())
			{
				StartDelivery(gameCalendar.CurrentDayNumber + 1);
			}
		}

		public void StartDelivery(int startDayDelivery)
		{
			if (!isRunning)
			{
				isRunning = true;
				this.startDayDelivery = startDayDelivery;
				lastDayDeliveryWasSent = this.startDayDelivery - settings.DeliveryFrequencyInDays;
			}
		}

		public void StopDelivery()
		{
			if (isRunning)
			{
				isRunning = false;
			}
		}

		public void SendToDelivery(bool updateLastDayDeliveryWasSent)
		{
			if (updateLastDayDeliveryWasSent)
			{
				lastDayDeliveryWasSent = gameCalendar.CurrentDayNumber;
			}
			List<ElementData> value;
			using (CollectionPool<List<ElementData>, ElementData>.Get(out value))
			{
				GenerateRandomParts(value);
				deliveryService.SendToDelivery(new ElementsBoxData(elementsBoxInfo, value));
			}
		}

		public void ForcedDelivery(bool updateLastDayDeliveryWasSent)
		{
			if (updateLastDayDeliveryWasSent)
			{
				lastDayDeliveryWasSent = gameCalendar.CurrentDayNumber;
			}
			List<ElementData> value;
			using (CollectionPool<List<ElementData>, ElementData>.Get(out value))
			{
				GenerateRandomParts(value);
				deliveryService.ForcedDelivery(new ElementsBoxData(elementsBoxInfo, value));
			}
		}

		private void GenerateRandomParts(List<ElementData> resultList)
		{
			if (resultList == null)
			{
				return;
			}
			resultList.Clear();
			List<ElementInfo> value;
			using (CollectionPool<List<ElementInfo>, ElementInfo>.Get(out value))
			{
				HashSet<ElementInfo> value2;
				using (CollectionPool<HashSet<ElementInfo>, ElementInfo>.Get(out value2))
				{
					foreach (AvailableDevicesListEntry availableDevices in availableDevicesListTrackingService.GetAvailableDevicesList())
					{
						if (!(availableDevices.Device != null) || availableDevices.Device.Elements == null)
						{
							continue;
						}
						foreach (IElementInfo element in availableDevices.Device.Elements)
						{
							if (element is ElementInfo { Category: ElementCategory.Draggable } elementInfo && value2.Add(elementInfo))
							{
								value.Add(elementInfo);
							}
						}
					}
				}
				if (value.Count == 0)
				{
					Debug.LogWarning("No available elements to generate parts from. Player may not have any available devices.");
					return;
				}
				int num = settings.NumberPartsInPack.GetRandom();
				if (settings.UniquePartsInPack)
				{
					num = Mathf.Min(num, value.Count);
				}
				for (int i = 0; i < num; i++)
				{
					int index = UnityEngine.Random.Range(0, value.Count);
					ElementInfo info = value[index];
					if (settings.UniquePartsInPack)
					{
						List<ElementInfo> list = value;
						List<ElementInfo> list2 = value;
						list[index] = list2[list2.Count - 1];
						value.RemoveAt(value.Count - 1);
					}
					ElementData elementData = new ElementData
					{
						Info = info,
						Condition = defaultElementConditions.PerfectElementCondition,
						IsInspected = false
					};
					IReadOnlyList<MaskPresetInfoBase> allApplicableDirtMaskPresetsByElementType = elementDirtMaskPresetSelectionService.GetAllApplicableDirtMaskPresetsByElementType(elementData.Info.ElementMaterialType);
					List<MaskPresetInfoBase> list3 = null;
					bool num2 = availableWorkTypesTrackingService.IsCleaningWorkTypeAvailable(settings.DirtTypeForSoldering) && UnityEngine.Random.Range(0f, 1f) < settings.ChanceSoldering;
					bool flag = elementData.Info.CanBeDirty && UnityEngine.Random.Range(0f, 1f) < settings.ChanceContamination;
					if (num2)
					{
						list3 = allApplicableDirtMaskPresetsByElementType.Where((MaskPresetInfoBase x) => x is ScorchedCircuitPresetInfo).ToList();
					}
					else if (flag)
					{
						list3 = allApplicableDirtMaskPresetsByElementType.Where((MaskPresetInfoBase x) => !(x is ScorchedCircuitPresetInfo)).ToList();
					}
					if (list3 != null && list3.Count > 0)
					{
						MaskPresetInfoBase maskPresetInfoBase = list3[UnityEngine.Random.Range(0, list3.Count)];
						elementData.Condition = defaultElementConditions.DirtyElementCondition;
						elementData.DirtMaskPresetOverride = maskPresetInfoBase;
						elementData.NoiseSeed = textureMaskCreator.GetRandomOrDebugNoiseSeed(maskPresetInfoBase, elementData.Info);
						elementData.DirtMaskTextureSize = (elementData.Info.SourceDevice as DeviceInfo).GeneratedDirtMaskTextureSize;
					}
					resultList.Add(elementData);
				}
			}
		}

		public object CaptureState()
		{
			try
			{
				return new DeliveryRandomPartsServiceSaveData
				{
					IsRunning = isRunning,
					LastDayDeliveryWasSent = lastDayDeliveryWasSent,
					StartDayDelivery = startDayDelivery
				};
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
				DeliveryRandomPartsServiceSaveData deliveryRandomPartsServiceSaveData = DataMigrationWizard.Migrate<DeliveryRandomPartsServiceSaveData>(state, base.gameObject);
				isRunning = deliveryRandomPartsServiceSaveData.IsRunning;
				lastDayDeliveryWasSent = deliveryRandomPartsServiceSaveData.LastDayDeliveryWasSent;
				startDayDelivery = deliveryRandomPartsServiceSaveData.StartDayDelivery;
			}
			catch (Exception innerException)
			{
				Debug.LogException(new RestoreProgressException(base.gameObject, state, innerException));
			}
		}
	}
}
