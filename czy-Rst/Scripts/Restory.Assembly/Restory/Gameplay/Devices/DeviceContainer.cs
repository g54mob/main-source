using System;
using System.Collections.Generic;
using DG.Tweening;
using Mandragora.PWS;
using Restory.Data.Devices.Quality;
using Restory.Data.Elements;
using Restory.Data.Elements.Condition;
using Restory.Data.Equipment;
using Restory.Data.GameView;
using Restory.Data.SaveLoad.Containers;
using Restory.Gameplay.Effects;
using Restory.Gameplay.Elements;
using Restory.Gameplay.Equipment.DevicePaintingTools;
using Restory.Gameplay.Equipment.DevicePaintingTools.Calculations;
using Restory.Gameplay.Equipment.DevicePaintingTools.DeviceAdditionalProperties;
using Restory.Gameplay.GameView;
using Restory.Gameplay.InteractiveObjects;
using Restory.Gameplay.TextureMasks;
using Restory.Infrastructure.StateMachine;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Devices
{
	public class DeviceContainer : InteractiveObject
	{
		[SerializeField]
		private Device device;

		[SerializeField]
		private GameViewPreset gameViewPreset;

		[SerializeField]
		private Transform devicePlacementPoint;

		[SerializeField]
		private Transform deviceDisassemblePoint;

		[SerializeField]
		private Transform deviceStoragePoint;

		[SerializeField]
		private Transform checkVfxPoint;

		private Vector3 initDisassemblePointRotation;

		[SerializeField]
		private float transitionDuration = 1f;

		[SerializeField]
		private float fastTransitionDuration = 0.2f;

		private GlobalStateObserver globalStateObserver;

		private PaintingSettings paintingSettings;

		private TweenSequencesService tweenSequences;

		private GameViewController gameViewController;

		private ElementService elementService;

		private DeviceQualityDatabase deviceQualityDatabase;

		private TextureCacheService textureCacheService;

		private TextureSaveLoadService textureSaveLoadService;

		private PaintingColorCalculator paintingColorCalculator;

		private Sequence transitionSequence;

		private Action onTransferCompleteCallback;

		public override bool IsPlaceable => true;

		public override bool IsActivatable => base.State == InteractiveObjectState.Placed;

		public Transform DisassemblePoint => deviceDisassemblePoint;

		public Vector3 InitDisassemblePointRotation => initDisassemblePointRotation;

		public Transform CheckVfxPoint
		{
			get
			{
				if (!(checkVfxPoint == null))
				{
					return checkVfxPoint;
				}
				return base.transform;
			}
		}

		public Device Device => device;

		public GameViewPreset DevicePreset => gameViewPreset;

		public bool IsPacked
		{
			get
			{
				DismantledDevicePack component;
				return base.transform.parent.TryGetComponent<DismantledDevicePack>(out component);
			}
		}

		public bool HasCustomer
		{
			get
			{
				if (base.AdditionalProperties != null)
				{
					if (!base.AdditionalProperties.ContainsProperty<PartOfWorkOrderInteractiveObjectProperty>())
					{
						return base.AdditionalProperties.ContainsProperty<PartOfEmailOrderInteractiveObjectProperty>();
					}
					return true;
				}
				return false;
			}
		}

		public DeviceQualityBase Quality { get; private set; }

		public DeviceQualityBase PrevKnownQuality { get; private set; }

		public SerializableTransform CachedTransform { get; private set; }

		public ElementData[] CachedInstalledElements { get; private set; }

		public PlacedElementsData CachedPlacedElements { get; private set; } = new PlacedElementsData();

		public event Action OnTransferToOrFromDisassemblyPointStarted;

		public event Action OnDeviceSelected;

		public event Action OnDeviceDeselected;

		public event Action OnDeviceActivated;

		public event Action OnDeviceDeactivated;

		public event Action OnQualityChanged;

		[Inject]
		private void Construct(GlobalStateObserver globalStateObserver, PaintingSettings paintingSettings, TweenSequencesService tweenSequences, GameViewController gameViewController, ElementService elementService, DeviceQualityDatabase deviceQualityDatabase, TextureCacheService textureCacheService, TextureSaveLoadService textureSaveLoadService, PaintingColorCalculator paintingColorCalculator)
		{
			this.paintingColorCalculator = paintingColorCalculator;
			this.globalStateObserver = globalStateObserver;
			this.paintingSettings = paintingSettings;
			this.tweenSequences = tweenSequences;
			this.gameViewController = gameViewController;
			this.elementService = elementService;
			this.deviceQualityDatabase = deviceQualityDatabase;
			this.textureCacheService = textureCacheService;
			this.textureSaveLoadService = textureSaveLoadService;
		}

		private void Awake()
		{
			initDisassemblePointRotation = deviceDisassemblePoint.localEulerAngles;
		}

		private void OnEnable()
		{
			device.OnSelected += ResolveDeviceSelected;
			device.OnDeselected += ResolveDeviceDeselected;
			device.OnPowerUp += ResolvePowerUp;
		}

		private void OnDisable()
		{
			device.OnSelected -= ResolveDeviceSelected;
			device.OnDeselected -= ResolveDeviceDeselected;
			device.OnPowerUp -= ResolvePowerUp;
			Clear();
		}

		public void Init(DeviceData deviceData)
		{
			InitInstalledElements(deviceData.InstalledElements);
			Device.Init();
			SetUniqueID(deviceData.UniqueID);
			SetUpAdditionalProperties(deviceData.InteractiveObjectAdditionalProperties);
			RestorePaintingTexture(deviceData);
			if (!deviceData.Quality)
			{
				ActivateRestorationCheck();
			}
			else
			{
				UpdateQuality(deviceData.Quality, deviceData.PrevKnownQuality);
			}
		}

		public override void SetState(InteractiveObjectState state)
		{
			CachedTransform = new SerializableTransform(base.transform);
			base.SetState(state);
		}

		public void CachePlacedElements(PlacedElements placedElements)
		{
			CachedPlacedElements = placedElements.GetData();
		}

		public override void SetPackage(InteractiveObjectPackage package)
		{
			device.gameObject.SetActive(value: false);
			base.SetPackage(package);
		}

		public override InteractiveObjectPackage RemovePackage()
		{
			device.gameObject.SetActive(value: true);
			return base.RemovePackage();
		}

		public void CoupleSmallElements(PlacedElements placedElements)
		{
			List<ElementSocket> smallElementsEmptySockets = GetSmallElementsEmptySockets();
			if (placedElements.ElementsInBin.Count != smallElementsEmptySockets.Count)
			{
				Debug.LogError("Small empty sockets amount not match to elements in bin");
			}
			foreach (ElementTransformRecord item in placedElements.ElementsInBin)
			{
				if (!TryCoupleSmallElement(smallElementsEmptySockets, item.Element))
				{
					Debug.LogError("Element " + item.Element.Info.ID + " has not compatible empty socket");
				}
			}
			foreach (ElementSocket item2 in smallElementsEmptySockets)
			{
				Debug.LogError("Socket " + item2.CompatibleElementInfo.ID + " has not available element in bin");
			}
		}

		public override void Select()
		{
			device.Select();
			base.Select();
		}

		public override void Deselect()
		{
			device.Deselect();
			base.Deselect();
		}

		public override void Activate()
		{
			if (!globalStateObserver.IsInGameLoop)
			{
				base.IsInteractable = true;
				return;
			}
			if (TryGetComponent<BounceEffect>(out var component))
			{
				component.ForceStopAnimationAndRestoreSizeImmediately();
			}
			gameViewController.ApplyDisassembleViewPreset(gameViewPreset);
			this.OnDeviceActivated?.Invoke();
			device.transform.SetParent(deviceDisassemblePoint);
			TransferDeviceToDisassemblePoint();
		}

		public override void StartDrag()
		{
			base.IsInteractable = false;
			base.StartDrag();
		}

		public void SetPlacementPoint()
		{
			SetDevicePoint(devicePlacementPoint);
		}

		public void SetStoragePoint()
		{
			SetDevicePoint(deviceStoragePoint);
		}

		public void TransferDeviceToPlacementPoint(Action callback = null)
		{
			if (base.State != InteractiveObjectState.Placed)
			{
				return;
			}
			device.transform.SetParent(devicePlacementPoint);
			onTransferCompleteCallback = callback;
			TransferDeviceToPoint(transitionDuration, this.OnTransferToOrFromDisassemblyPointStarted);
			foreach (ElementSocket elementSocket in Device.ElementSockets)
			{
				elementSocket.OnNestedElementChanged -= ResolveNestedElementChanged;
			}
		}

		public void TransferDeviceToDisassemblePoint()
		{
			if (base.State != InteractiveObjectState.Placed)
			{
				return;
			}
			device.transform.SetParent(deviceDisassemblePoint);
			TransferDeviceToPoint(transitionDuration, this.OnTransferToOrFromDisassemblyPointStarted);
			foreach (ElementSocket elementSocket in Device.ElementSockets)
			{
				elementSocket.OnNestedElementChanged += ResolveNestedElementChanged;
			}
		}

		public bool HasQualityChanged()
		{
			return Quality != PrevKnownQuality;
		}

		private List<ElementSocket> GetSmallElementsEmptySockets()
		{
			List<ElementSocket> list = new List<ElementSocket>();
			foreach (ElementSocket elementSocket in Device.ElementSockets)
			{
				if (!elementSocket.IsCoupled && elementSocket.CompatibleElementInfo.Category == ElementCategory.Small)
				{
					list.Add(elementSocket);
				}
			}
			return list;
		}

		private bool TryCoupleSmallElement(List<ElementSocket> smallElementEmptySockets, ElementBase smallElement)
		{
			for (int i = 0; i < smallElementEmptySockets.Count; i++)
			{
				if (!(smallElement.Info != smallElementEmptySockets[i].CompatibleElementInfo))
				{
					smallElementEmptySockets[i].CoupleSmallElement(smallElement);
					smallElementEmptySockets.RemoveAt(i);
					return true;
				}
			}
			return false;
		}

		private void InitInstalledElements(ElementData[] installedElementsData)
		{
			for (int i = 0; i < device.ElementSockets.Count; i++)
			{
				ElementSocket elementSocket = device.ElementSockets[i];
				if (!elementSocket)
				{
					throw new InvalidOperationException("Socket is null");
				}
				ElementBase nestedElement = elementSocket.NestedElement;
				if (!nestedElement)
				{
					Debug.LogError("Socket " + elementSocket.CompatibleElementInfo.ID + " is empty");
					continue;
				}
				ElementData elementData = installedElementsData[i];
				InitInstalledElement(elementSocket, nestedElement, elementData);
			}
			CachedInstalledElements = installedElementsData;
		}

		private void InitInstalledElement(ElementSocket socket, ElementBase element, ElementData elementData)
		{
			if (elementData == null)
			{
				socket.DestroyNestedElement();
			}
			else if (elementData.Info.ID != socket.CompatibleElementInfo.ID)
			{
				Debug.LogError("Element data " + elementData.Info.ID + " not compatible for " + socket.CompatibleElementInfo.ID);
			}
			else if (!(element.ConditionHandler.ElementData.Condition is PerfectElementCondition))
			{
				Debug.LogError(element.name + " is not in perfect condition");
			}
			else if (element.Info.Category == ElementCategory.Small)
			{
				elementData.Condition = element.ConditionHandler.ElementData.Condition;
			}
			else
			{
				elementService.ApplyElementCondition(element, elementData, async: true);
			}
		}

		private void RestorePaintingTexture(DeviceData deviceData)
		{
			if (deviceData.PaintTextureId <= 0 || !Device.TryGetComponent<PaintableDevice>(out var component))
			{
				return;
			}
			component.SetPaintTextureId(deviceData.PaintTextureId);
			if (!textureCacheService.TryGetTextureData(deviceData.PaintTextureId, out var textureData))
			{
				component.ClearPaintTextureId();
				return;
			}
			Texture2D paintingTexture = textureSaveLoadService.ConvertDataToTexture(textureData, paintingSettings.TextureFormat, isTargetTextureLinear: true);
			component.SetPaintingTexture(paintingTexture);
			component.InitializePaintingMaskTexture(paintingSettings);
			PaintingProgressInPercentage paintingProgress = paintingColorCalculator.CalculateAdaptedProgress(component);
			component.SetPaintingProgress(paintingProgress);
			if (!base.AdditionalProperties.TryToGetProperty<DevicePaintedAdditionalProperty>(out var foundProperty))
			{
				return;
			}
			component.ClearRegisteredPalettes();
			foreach (KeyValuePair<PaintingPaletteInfo, int> item in foundProperty.UsedPalettesCount)
			{
				for (int i = 0; i < item.Value; i++)
				{
					component.IncreasePaintingUseCount(item.Key);
				}
			}
		}

		public void QuitDisassemblyMode()
		{
			gameViewController.ApplyDefaultViewPreset();
			device.transform.SetParent(devicePlacementPoint);
			device.PowerOff();
			TransferDeviceToPlacementPoint(ExitDisassemble);
			this.OnDeviceDeactivated?.Invoke();
		}

		private void TransferDeviceToPoint(float duration, Action onMovementStartedCallback = null)
		{
			if (transitionSequence != null)
			{
				tweenSequences.Kill(transitionSequence);
			}
			transitionSequence = tweenSequences.Create();
			transitionSequence.Append(device.transform.DOLocalMove(Vector3.zero, duration)).Join(device.transform.DOLocalRotate(Vector3.zero, duration)).SetEase(Ease.InQuad)
				.OnComplete(OnTransferComplete)
				.OnStart(delegate
				{
					onMovementStartedCallback?.Invoke();
				});
		}

		private void OnTransferComplete()
		{
			if (onTransferCompleteCallback != null)
			{
				onTransferCompleteCallback();
				onTransferCompleteCallback = null;
			}
		}

		private void SetDevicePoint(Transform devicePoint)
		{
			interactionTrigger.transform.SetParent(devicePoint);
			interactionTrigger.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
			device.transform.SetParent(devicePoint);
			TransferDeviceToPoint(fastTransitionDuration);
		}

		private void UpdateQuality(DeviceQualityBase quality, DeviceQualityBase prevKnownQuality = null)
		{
			if (!(Quality == quality))
			{
				if (prevKnownQuality == null)
				{
					prevKnownQuality = Quality;
				}
				Quality = quality;
				if (prevKnownQuality != deviceQualityDatabase.UnknownQuality)
				{
					PrevKnownQuality = prevKnownQuality;
				}
				device.PowerOff();
				this.OnQualityChanged?.Invoke();
			}
		}

		public void ForceCheckQuality()
		{
			ActivateRestorationCheck();
		}

		private void ActivateRestorationCheck()
		{
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			for (int i = 0; i < device.ElementSockets.Count; i++)
			{
				ElementData elementData = CachedInstalledElements[i];
				if (elementData == null)
				{
					UpdateQuality(deviceQualityDatabase.UnknownQuality);
					return;
				}
				if (elementData.Condition is DamagedElementCondition)
				{
					if (elementData.Info.IsCriticalElement)
					{
						flag = true;
					}
					else
					{
						flag2 = true;
					}
				}
				else if (elementData.Condition is DirtyElementCondition)
				{
					flag3 = true;
				}
			}
			if (flag)
			{
				UpdateQuality(deviceQualityDatabase.BrokenQuality);
			}
			else if (flag2 || flag3)
			{
				UpdateQuality(deviceQualityDatabase.WorkingQuality);
			}
			else
			{
				UpdateQuality(deviceQualityDatabase.IdealQuality);
			}
		}

		private void ExitDisassemble()
		{
			if (IsPacked)
			{
				base.gameObject.SetActive(value: false);
			}
		}

		private void Clear()
		{
			if (transitionSequence != null)
			{
				tweenSequences.Kill(transitionSequence);
			}
			transitionSequence = null;
			onTransferCompleteCallback = null;
			device.Clear();
		}

		private void ResolveDeviceSelected()
		{
			this.OnDeviceSelected?.Invoke();
		}

		private void ResolveDeviceDeselected()
		{
			this.OnDeviceDeselected?.Invoke();
		}

		private void ResolveNestedElementChanged(ElementSocket socket)
		{
			for (int i = 0; i < Device.ElementSockets.Count; i++)
			{
				if (Device.ElementSockets[i] != socket)
				{
					continue;
				}
				if (CachedInstalledElements.Length <= i)
				{
					Debug.LogError("Not enough installed element entries in device data");
					return;
				}
				CachedInstalledElements[i] = (socket.NestedElement ? socket.NestedElement.ConditionHandler.ElementData : null);
				if (CachedInstalledElements[i] == null)
				{
					UpdateQuality(deviceQualityDatabase.UnknownQuality);
				}
				else
				{
					ActivateRestorationCheck();
				}
				return;
			}
			Debug.LogError("Failed to find socked " + socket.CompatibleElementInfo.ID + " in device " + Device.Info.ID);
		}

		private void ResolvePowerUp()
		{
		}

		protected override InteractiveObjectStoreDimensions GetStoreDimensions()
		{
			return new InteractiveObjectStoreDimensions
			{
				Size = interactionTrigger.Collider.size,
				Center = deviceStoragePoint.localPosition + interactionTrigger.Collider.center,
				Rotation = deviceStoragePoint.localRotation
			};
		}
	}
}
