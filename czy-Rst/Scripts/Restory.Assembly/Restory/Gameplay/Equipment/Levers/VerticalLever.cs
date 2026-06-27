using System;
using System.Collections;
using Restory.Gameplay.Common;
using Restory.Gameplay.DetectableObjects;
using Restory.Gameplay.Tooltips;
using Restory.Utils;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Restory.Gameplay.Equipment.Levers
{
	public class VerticalLever : MonoBehaviour, IDetectableObject, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		[SerializeField]
		private TooltipIndicator tooltipIndicator;

		[SerializeField]
		private OutlinableAdapter outlinableAdapter;

		[SerializeField]
		private BoxCollider boxCollider;

		[SerializeField]
		private LeverMovementVisualizer leverMovementVisualizer;

		[SerializeField]
		private LeverPositions initialPosition = LeverPositions.Top;

		private bool isActive;

		private bool isUnderCursor;

		private LeverPositions currentPosition;

		private readonly ActiveStateSwitcher activeStateSwitcher = new ActiveStateSwitcher(ActiveStateSwitcher.WorkMode.ActiveByDefaultAndRequestersMakeItInactive);

		private Coroutine doCallbackAfterOneFrameCoroutine;

		public bool CanBeDetected
		{
			set
			{
				base.enabled = value;
			}
		}

		public bool IsActive
		{
			get
			{
				return isActive;
			}
			private set
			{
				boxCollider.enabled = value;
				if (value != isActive)
				{
					isActive = value;
					this.OnActiveStateChanged?.Invoke();
				}
			}
		}

		public LeverPositions CurrentPosition
		{
			get
			{
				return currentPosition;
			}
			private set
			{
				if (value != currentPosition)
				{
					currentPosition = value;
					this.OnPositionChanged?.Invoke();
				}
			}
		}

		public event Action OnPositionChanged;

		public event Action OnActiveStateChanged;

		public event Action OnPointerEntered;

		public event Action OnPointerExited;

		private void OnEnable()
		{
			RefreshActiveStatus();
			activeStateSwitcher.OnActiveStatusSwitchRequested += ResolveActiveStatusSwitchRequested;
		}

		private void OnDisable()
		{
			if (activeStateSwitcher != null)
			{
				activeStateSwitcher.OnActiveStatusSwitchRequested -= ResolveActiveStatusSwitchRequested;
			}
			if (doCallbackAfterOneFrameCoroutine != null)
			{
				StopCoroutine(doCallbackAfterOneFrameCoroutine);
				doCallbackAfterOneFrameCoroutine = null;
			}
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			isUnderCursor = true;
			outlinableAdapter.IsActive = true;
			this.OnPointerEntered?.Invoke();
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			isUnderCursor = false;
			outlinableAdapter.IsActive = false;
			this.OnPointerExited?.Invoke();
		}

		public void SetInitialState(bool isWindowOpen, bool wasWindowOpenAtLeastOnce)
		{
			currentPosition = (isWindowOpen ? LeverPositions.Bottom : LeverPositions.Top);
			if (leverMovementVisualizer.MonoShellExists())
			{
				leverMovementVisualizer.SetLeverToPosition(currentPosition, animate: false);
			}
			tooltipIndicator.gameObject.SetActive(!wasWindowOpenAtLeastOnce);
		}

		public bool TryToSwitchLeverPosition()
		{
			if (!isActive)
			{
				return false;
			}
			if (tooltipIndicator.gameObject.activeSelf)
			{
				tooltipIndicator.gameObject.SetActive(value: false);
			}
			CurrentPosition = currentPosition switch
			{
				LeverPositions.Top => LeverPositions.Bottom, 
				LeverPositions.Bottom => LeverPositions.Top, 
				_ => initialPosition, 
			};
			if (leverMovementVisualizer.MonoShellExists())
			{
				leverMovementVisualizer.SetLeverToPosition(currentPosition);
			}
			return true;
		}

		public void BlockLever(IActiveStateSwitchRequester blockingSource)
		{
			activeStateSwitcher.AddRequester(blockingSource);
		}

		public void UnblockLever(IActiveStateSwitchRequester blockingSource)
		{
			activeStateSwitcher.RemoveRequester(blockingSource);
		}

		public void RefreshActiveStatus()
		{
			IsActive = activeStateSwitcher.ShouldSystemBeActive;
		}

		private void ResolveActiveStatusSwitchRequested()
		{
			if (activeStateSwitcher.ShouldSystemBeActive)
			{
				if (doCallbackAfterOneFrameCoroutine == null)
				{
					doCallbackAfterOneFrameCoroutine = StartCoroutine(DoCallbackAfterOneFrameCoroutine(RefreshActiveStatus));
				}
			}
			else
			{
				RefreshActiveStatus();
			}
		}

		private IEnumerator DoCallbackAfterOneFrameCoroutine(Action callback)
		{
			yield return null;
			doCallbackAfterOneFrameCoroutine = null;
			callback?.Invoke();
		}
	}
}
