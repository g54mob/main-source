using System;
using System.Collections.Generic;
using Restory.Gameplay.DetectableObjects;
using Restory.Gameplay.Elements;
using Restory.Gameplay.Equipment;
using Restory.Gameplay.Tooltips;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Restory.Gameplay.Workplace
{
	public class WorkSurface : MonoBehaviour, IInitializable, IDisposable, IDetectableObject
	{
		[SerializeField]
		private ClickableTrigger clickableTrigger;

		[SerializeField]
		private Transform deviceSpawnPoint;

		[SerializeField]
		private Transform defaultPlacementPoint;

		[SerializeField]
		private Transform cleanedElementPlacementPoint;

		[SerializeField]
		private TooltipIndicator tooltipIndicator;

		[FormerlySerializedAs("tooltipSign")]
		[SerializeField]
		private GameObject noDeviceOnSurfaceSign;

		[SerializeField]
		private GameObject disassembleControlsAdviceSign;

		[SerializeField]
		private WorkPlaceRugVisualizer workPlaceRugVisualizer;

		[SerializeField]
		private float minPlacedDeviceDetectionSqrDistance = 0.2f;

		private readonly List<ElementBase> placedElements = new List<ElementBase>();

		public bool CanBeDetected
		{
			set
			{
				clickableTrigger.gameObject.SetActive(value);
			}
		}

		public Transform DeviceSpawnPoint => deviceSpawnPoint;

		public Vector3 DefaultPlacementPosition => defaultPlacementPoint.position;

		public Vector3 CleanedElementPlacementPosition => cleanedElementPlacementPoint.position;

		public float MinPlacedDeviceDetectionSqrDistance => minPlacedDeviceDetectionSqrDistance;

		public IReadOnlyList<ElementBase> PlacedElements => placedElements;

		public event Action OnPlacedElementsChanged = delegate
		{
		};

		public event Action OnClick;

		public void Initialize()
		{
			workPlaceRugVisualizer.Init();
			clickableTrigger.OnClick += ResolveOnClick;
		}

		public void Dispose()
		{
			workPlaceRugVisualizer.Cleanup();
			clickableTrigger.OnClick -= ResolveOnClick;
		}

		public void ToggleIndicator(bool isActive)
		{
			tooltipIndicator.gameObject.SetActive(isActive);
		}

		public void ToggleNoDeviceOnSurfaceSign(bool isActive)
		{
			noDeviceOnSurfaceSign.SetActive(isActive);
		}

		public void ToggleDisassembleControlsAdvices(bool isActive)
		{
			disassembleControlsAdviceSign.SetActive(isActive);
		}

		public void AddElement(ElementBase element, bool silent = false)
		{
			element.transform.SetParent(base.transform);
			if (!placedElements.Contains(element))
			{
				placedElements.Add(element);
				element.IsOnSurface = true;
				if (!silent)
				{
					this.OnPlacedElementsChanged();
				}
			}
		}

		public void RemoveElement(ElementBase element, bool silent = false)
		{
			if (placedElements.Contains(element))
			{
				placedElements.Remove(element);
				element.IsOnSurface = false;
				if (!silent)
				{
					this.OnPlacedElementsChanged();
				}
			}
		}

		public void ClearElements()
		{
			foreach (ElementBase placedElement in placedElements)
			{
				if ((bool)placedElement)
				{
					UnityEngine.Object.Destroy(placedElement.gameObject);
				}
			}
			placedElements.Clear();
		}

		public void ActivatePlacedElements()
		{
			foreach (ElementBase placedElement in placedElements)
			{
				placedElement.Activate();
			}
		}

		public void DeactivatePlacedElements()
		{
			foreach (ElementBase placedElement in placedElements)
			{
				placedElement.Deactivate();
			}
		}

		private void ResolveOnClick()
		{
			this.OnClick?.Invoke();
		}
	}
}
