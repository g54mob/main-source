using System;
using System.Linq;
using Restory.Audio;
using Restory.Data.Elements.Condition;
using Restory.Data.Equipment;
using Restory.Gameplay.Devices;
using Restory.Gameplay.Effects;
using Restory.Gameplay.Elements;
using Restory.Gameplay.Equipment;
using Restory.Gameplay.InteractiveObjects;
using Restory.Gameplay.Inventory;
using Restory.UI.Presenters.Shredders;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Shredders
{
	public class ShredderService : MonoBehaviour
	{
		private Shredder shredder;

		private ElementService elementService;

		private DeviceService deviceService;

		private InteractiveObjectRegistry interactiveObjectRegistry;

		private InteractiveObjectFactory interactiveObjectFactory;

		private VfxService vfxService;

		private IAudioPlayerService audioService;

		private GUI_ShredderRewardsNotificationCanvas notificationCanvas;

		private Wallet wallet;

		private AvailableToolsTrackingService availableToolsTrackingService;

		private IShredRequest activeRequest;

		public bool IsReadyToShred
		{
			get
			{
				if (shredder.IsDetected)
				{
					return shredder.IsActive;
				}
				return false;
			}
		}

		public event Action<ShredderService> OnShredded;

		public event Action<ShredderService> OnElementShredded;

		public event Action<ShredderService> OnInteractiveObjectShredded;

		public event Action<ShredderRewardResult> OnRewardCalculated;

		[Inject]
		public void Construct(Shredder shredder, ElementService elementService, DeviceService deviceService, InteractiveObjectRegistry interactiveObjectRegistry, InteractiveObjectFactory interactiveObjectFactory, VfxService vfxService, IAudioPlayerService audioService, GUI_ShredderRewardsNotificationCanvas notificationCanvas, Wallet wallet, AvailableToolsTrackingService availableToolsTrackingService)
		{
			this.shredder = shredder;
			this.elementService = elementService;
			this.deviceService = deviceService;
			this.interactiveObjectRegistry = interactiveObjectRegistry;
			this.interactiveObjectFactory = interactiveObjectFactory;
			this.vfxService = vfxService;
			this.audioService = audioService;
			this.notificationCanvas = notificationCanvas;
			this.wallet = wallet;
			this.availableToolsTrackingService = availableToolsTrackingService;
		}

		public bool TryToShredInteractiveObject(InteractiveObject interactiveObject)
		{
			if (!IsReadyToShred)
			{
				return false;
			}
			if (!TryGetShredderInfo(out var shredderInfo))
			{
				return false;
			}
			ShredInteractiveObject(interactiveObject, shredderInfo);
			return true;
		}

		public bool CanSendShredRequest(IShredRequest request)
		{
			if (!(request is ShredElementRequest shredElementRequest))
			{
				if (request is ShredInteractiveObjectRequest shredInteractiveObjectRequest)
				{
					TrashObject component;
					return shredInteractiveObjectRequest.InteractiveObject.TryGetComponent<TrashObject>(out component);
				}
				return false;
			}
			if ((bool)shredElementRequest.Element)
			{
				return shredElementRequest.Element.ConditionHandler.ElementData.Condition is DamagedElementCondition;
			}
			return false;
		}

		public void SendShredRequest(IShredRequest request)
		{
			if (activeRequest != null)
			{
				Debug.LogError(string.Format("{0} has active request already from {1}", "ShredderService", activeRequest.Requester.GetType()));
				request.Requester.OnShredResponse(isCompleted: false);
				return;
			}
			if (!CanSendShredRequest(request))
			{
				request.Requester.OnShredResponse(isCompleted: false);
				return;
			}
			if (!TryGetShredderInfo(out var shredderInfo))
			{
				request.Requester.OnShredResponse(isCompleted: false);
				return;
			}
			activeRequest = request;
			IShredRequest shredRequest = activeRequest;
			if (!(shredRequest is ShredElementRequest shredElementRequest))
			{
				if (!(shredRequest is ShredInteractiveObjectRequest shredInteractiveObjectRequest))
				{
					throw new NotImplementedException("activeRequest processing is not implemented");
				}
				ShredInteractiveObject(shredInteractiveObjectRequest.InteractiveObject, shredderInfo);
				ResponseToRequester(isCompleted: true);
			}
			else
			{
				ShredElement(shredElementRequest.Element, shredderInfo);
				ResponseToRequester(isCompleted: true);
			}
		}

		private void ShredElement(ElementBase element, ShredderToolInfo shredderInfo)
		{
			elementService.DestroyElement(element);
			vfxService.PlayPlacementEffect(shredder.EffectPoint);
			audioService.PlaySoundEventOneShot(shredderInfo.ObjectShreddedSound, shredder.gameObject);
			AwardCoinsToPlayer(shredderInfo);
			this.OnElementShredded?.Invoke(this);
			this.OnShredded?.Invoke(this);
		}

		private void ShredInteractiveObject(InteractiveObject interactiveObject, ShredderToolInfo shredderInfo)
		{
			interactiveObject.Remove();
			if (!(interactiveObject is DeviceContainer deviceContainer))
			{
				if (interactiveObject is DevicePack devicePack)
				{
					deviceService.DestroyPackedDeviceContainer(devicePack);
				}
				else
				{
					interactiveObjectRegistry.Unregister(interactiveObject);
					interactiveObjectFactory.DestroyInteractiveObject(interactiveObject);
				}
			}
			else
			{
				deviceService.DestroyDeviceContainer(deviceContainer);
			}
			vfxService.PlayPlacementEffect(shredder.EffectPoint);
			audioService.PlaySoundEventOneShot(shredderInfo.ObjectShreddedSound, shredder.gameObject);
			this.OnInteractiveObjectShredded?.Invoke(this);
			this.OnShredded?.Invoke(this);
		}

		private void ResponseToRequester(bool isCompleted)
		{
			if (activeRequest == null)
			{
				Debug.LogError("Shred request was lost in ShredderService");
				return;
			}
			activeRequest.Requester.OnShredResponse(isCompleted);
			activeRequest = null;
		}

		private void AwardCoinsToPlayer(ShredderToolInfo shredderInfo)
		{
			int minInclusive = Mathf.Min(shredderInfo.MinReward, shredderInfo.MaxReward);
			int num = Mathf.Max(shredderInfo.MinReward, shredderInfo.MaxReward);
			int num2 = UnityEngine.Random.Range(minInclusive, num + 1);
			if (num2 < shredderInfo.CritFailBarrier)
			{
				notificationCanvas.Show(0, isCriticalSuccess: false, shredder.EffectPoint);
				this.OnRewardCalculated?.Invoke(new ShredderRewardResult(0, isCriticalSuccess: false, isZeroedOut: true));
				Debug.Log($"Player was zeroed out for shredding. (Rolled reward: {num2})");
				return;
			}
			bool flag = false;
			if (num2 > shredderInfo.CritSuccessBarrier)
			{
				num2 = Mathf.RoundToInt((float)num2 * shredderInfo.CritSuccessMod);
				flag = true;
			}
			int num3 = (wallet.TryToAdd(num2) ? num2 : 0);
			notificationCanvas.Show(num3, flag, shredder.EffectPoint);
			this.OnRewardCalculated?.Invoke(new ShredderRewardResult(num3, flag, isZeroedOut: false));
			Debug.Log($"Player was awarded with {num3} coins for shredding. " + $"(Rolled reward: {num2}, Critical success: {flag})");
		}

		private bool TryGetShredderInfo(out ShredderToolInfo shredderInfo)
		{
			shredderInfo = (from x in availableToolsTrackingService.AvailableTools.OfType<ShredderToolInfo>()
				orderby x.ToolLevel descending
				select x).FirstOrDefault();
			if (shredderInfo != null)
			{
				return true;
			}
			Debug.LogError("ShredderService could not find any available ShredderToolInfo");
			return false;
		}
	}
}
