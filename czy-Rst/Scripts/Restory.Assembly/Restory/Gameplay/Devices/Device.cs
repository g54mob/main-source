using System;
using System.Collections.Generic;
using Restory.Data.Devices;
using Restory.Data.Elements;
using Restory.Data.Outline;
using Restory.Gameplay.Common;
using Restory.Gameplay.Elements;
using Restory.Gameplay.Equipment;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Devices
{
	public class Device : MonoBehaviour
	{
		public enum AssembleStatus
		{
			None = 0,
			Disassembled = 1,
			Assembled = 2,
			NotScrewed = 3
		}

		[SerializeField]
		private DeviceInfo deviceInfo;

		[SerializeField]
		private OutlineSettingsPreset selectedPreset;

		[SerializeField]
		private OutlineSettingsPreset collidingPreset;

		[SerializeField]
		private OutlinableAdapter outlinableAdapter;

		[SerializeField]
		private DevicePowerUpVisualizer powerUpVisualizer;

		[Header("General settings")]
		[SerializeField]
		private List<ElementSocket> elementSockets = new List<ElementSocket>();

		private readonly List<ElementSocket> sortedSockets = new List<ElementSocket>();

		private readonly Dictionary<IElementInfo, int> elementsOrderMap = new Dictionary<IElementInfo, int>();

		private readonly List<IAnimatedElementGroup> animatedElementGroups = new List<IAnimatedElementGroup>();

		private SmallElementBin smallElementBin;

		private ElementPlacementController elementPlacementController;

		private PowerUpElementSocket powerUpSocket;

		private bool isActivated;

		private bool isPowered;

		public DeviceInfo Info => deviceInfo;

		public IReadOnlyList<ElementSocket> ElementSockets => elementSockets;

		public IReadOnlyList<ElementSocket> SortedSockets => sortedSockets;

		public IReadOnlyDictionary<IElementInfo, int> ElementsOrderMap => elementsOrderMap;

		public bool IsActivated => isActivated;

		public event Action OnSelected;

		public event Action OnDeselected;

		public event Action OnActivated;

		public event Action OnDeactivated;

		public event Action OnPowerUp;

		public event Action OnDisabled;

		[Inject]
		private void Construct(SmallElementBin smallElementBin, ElementPlacementController elementPlacementController)
		{
			this.smallElementBin = smallElementBin;
			this.elementPlacementController = elementPlacementController;
		}

		private void OnDisable()
		{
			this.OnDisabled?.Invoke();
		}

		public void Init()
		{
			outlinableAdapter.AddAllChildRenderersToRenderingList();
			InitPowerUpSocket();
			InitSortedSockets();
			InitAnimatedElementGroups();
		}

		public void Select()
		{
			outlinableAdapter.AddAllChildRenderersToRenderingList();
			this.OnSelected?.Invoke();
		}

		public void Deselect()
		{
			this.OnDeselected?.Invoke();
		}

		public void InitElements()
		{
			foreach (ElementSocket elementSocket in elementSockets)
			{
				if ((bool)elementSocket.NestedElement)
				{
					elementSocket.NestedElement.Init();
				}
			}
		}

		public void ThrowLooseElements(ElementBase exceptedElement = null)
		{
			foreach (ElementSocket elementSocket in elementSockets)
			{
				ElementBase nestedElement = elementSocket.NestedElement;
				if (nestedElement is ThreadedElement threadedElement && !(nestedElement == exceptedElement) && nestedElement.Progress != 0f)
				{
					threadedElement.CancelInteraction();
					elementSocket.DetachElement();
					ThrowLooseElement(threadedElement);
				}
			}
		}

		public void ResetElements()
		{
			foreach (ElementSocket elementSocket in elementSockets)
			{
				if ((bool)elementSocket.NestedElement)
				{
					elementSocket.NestedElement.Reset();
				}
			}
		}

		public bool CheckIntegrity()
		{
			foreach (ElementSocket elementSocket in elementSockets)
			{
				if (!elementSocket.NestedElement)
				{
					return false;
				}
			}
			return true;
		}

		public bool CheckIntegrityAndIsInstalling()
		{
			foreach (ElementSocket elementSocket in elementSockets)
			{
				if (!elementSocket.NestedElement || elementSocket.NestedElement.IsInstalling)
				{
					return false;
				}
			}
			return true;
		}

		public bool HasAnyInstalledElement()
		{
			foreach (ElementSocket elementSocket in elementSockets)
			{
				if ((bool)elementSocket.NestedElement)
				{
					return true;
				}
			}
			return false;
		}

		public AssembleStatus CheckAssembleStatus()
		{
			AssembleStatus result = AssembleStatus.Assembled;
			foreach (ElementSocket elementSocket in elementSockets)
			{
				if (!elementSocket.NestedElement)
				{
					if (elementSocket.CompatibleElementInfo.Category != ElementCategory.Small)
					{
						return AssembleStatus.Disassembled;
					}
					result = AssembleStatus.NotScrewed;
				}
			}
			return result;
		}

		public void Activate()
		{
			if (isActivated)
			{
				return;
			}
			isActivated = true;
			foreach (ElementSocket elementSocket in ElementSockets)
			{
				elementSocket.Activate();
			}
			foreach (IAnimatedElementGroup animatedElementGroup in animatedElementGroups)
			{
				animatedElementGroup.Activate();
			}
			this.OnActivated?.Invoke();
		}

		public void Deactivate(bool isDeviceCheck)
		{
			if (!isActivated)
			{
				return;
			}
			isActivated = false;
			foreach (ElementSocket elementSocket in ElementSockets)
			{
				elementSocket.Deactivate();
			}
			foreach (IAnimatedElementGroup animatedElementGroup in animatedElementGroups)
			{
				animatedElementGroup.Deactivate(isDeviceCheck);
			}
			this.OnDeactivated?.Invoke();
		}

		public void PowerUp()
		{
			if (!isPowered)
			{
				isPowered = true;
				powerUpVisualizer.OnPowerUp();
			}
		}

		public void PowerOff()
		{
			if (isPowered)
			{
				isPowered = false;
				powerUpVisualizer.OnPowerOff();
			}
		}

		private void InitPowerUpSocket()
		{
			if (powerUpSocket != null)
			{
				Debug.LogError("PowerUpElementSocket is initialized already");
				return;
			}
			foreach (ElementSocket elementSocket in ElementSockets)
			{
				if (elementSocket is PowerUpElementSocket powerUpElementSocket)
				{
					powerUpSocket = powerUpElementSocket;
					powerUpElementSocket.OnPowerUp += this.OnPowerUp;
					break;
				}
			}
		}

		private void InitSortedSockets()
		{
			elementsOrderMap.Clear();
			int num = 0;
			foreach (IElementInfo element in deviceInfo.Elements)
			{
				if (elementsOrderMap.TryAdd(element, num))
				{
					num++;
				}
			}
			sortedSockets.Clear();
			foreach (ElementSocket elementSocket in elementSockets)
			{
				if (elementSocket.CompatibleElementInfo.Category != ElementCategory.Small)
				{
					sortedSockets.Add(elementSocket);
				}
			}
			sortedSockets.Sort(delegate(ElementSocket a, ElementSocket b)
			{
				int valueOrDefault = elementsOrderMap.GetValueOrDefault(a.CompatibleElementInfo, int.MinValue);
				return elementsOrderMap.GetValueOrDefault(b.CompatibleElementInfo, int.MinValue).CompareTo(valueOrDefault);
			});
		}

		private void InitAnimatedElementGroups()
		{
			animatedElementGroups.Clear();
			animatedElementGroups.AddRange(GetComponentsInChildren<IAnimatedElementGroup>());
			foreach (IAnimatedElementGroup animatedElementGroup in animatedElementGroups)
			{
				animatedElementGroup.Init();
			}
		}

		private void ThrowLooseElement(ThreadedElement looseElement)
		{
			if (looseElement.Info.Category == ElementCategory.Small)
			{
				smallElementBin.PutElement(looseElement);
				return;
			}
			looseElement.IsBlocked = false;
			elementPlacementController.SetTargetElement(looseElement);
			if (!elementPlacementController.TrySetPlacementPositionAndDropToSurface())
			{
				Debug.LogError("No available placement position for element " + looseElement.name + " found");
			}
		}

		public void Clear()
		{
			isActivated = false;
			if (powerUpSocket != null)
			{
				powerUpSocket.OnPowerUp -= this.OnPowerUp;
				powerUpSocket = null;
			}
		}
	}
}
