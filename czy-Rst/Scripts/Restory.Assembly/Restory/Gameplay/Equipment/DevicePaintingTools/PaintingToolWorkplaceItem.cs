using System;
using Restory.Gameplay.Effects;
using Restory.Gameplay.InteractiveObjects;
using Restory.Gameplay.Tooltips;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Equipment.DevicePaintingTools
{
	public class PaintingToolWorkplaceItem : MonoBehaviour
	{
		private bool isAvailable;

		[SerializeField]
		private ClickableTrigger clickableTrigger;

		[SerializeField]
		private Collider detectionCollider;

		[SerializeField]
		private TooltipIndicator tooltipIndicator;

		[SerializeField]
		private BounceEffect bounceEffect;

		private DragObjectRegistrator dragObjectRegistrator;

		public bool IsAvailable
		{
			get
			{
				return isAvailable;
			}
			private set
			{
				if (value != isAvailable)
				{
					isAvailable = value;
					detectionCollider.enabled = true;
				}
			}
		}

		public ClickableTrigger Trigger => clickableTrigger;

		public event Action OnNewPalettesAdded;

		[Inject]
		private void Construct(DragObjectRegistrator dragObjectRegistrator)
		{
			this.dragObjectRegistrator = dragObjectRegistrator;
			if (base.isActiveAndEnabled)
			{
				Init();
			}
		}

		private void Awake()
		{
			detectionCollider.enabled = false;
		}

		private void OnEnable()
		{
			if (dragObjectRegistrator != null)
			{
				Init();
			}
		}

		private void Init()
		{
			dragObjectRegistrator.OnInteractiveObjectStartDrag += ResolveInteractiveObjectStartedDragging;
			dragObjectRegistrator.OnInteractiveObjectStopDrag += ResolveOnInteractiveObjectStoppedDragging;
		}

		private void OnDisable()
		{
			if (dragObjectRegistrator != null)
			{
				dragObjectRegistrator.OnInteractiveObjectStartDrag -= ResolveInteractiveObjectStartedDragging;
				dragObjectRegistrator.OnInteractiveObjectStopDrag -= ResolveOnInteractiveObjectStoppedDragging;
			}
		}

		public void MakeAvailable()
		{
			IsAvailable = true;
		}

		public void ToggleIndicator(bool isActive)
		{
			if (tooltipIndicator.MonoShellExists())
			{
				tooltipIndicator.gameObject.SetActive(isActive);
			}
		}

		public void HandlePalettesAdded()
		{
			this.OnNewPalettesAdded?.Invoke();
			bounceEffect.PlayBounce();
		}

		private void ResolveInteractiveObjectStartedDragging()
		{
			if (isAvailable && (bool)dragObjectRegistrator.DraggingObject && dragObjectRegistrator.DraggingObject.TryGetComponent<PaintingPalettesContainer>(out var _))
			{
				ToggleIndicator(isActive: true);
			}
		}

		private void ResolveOnInteractiveObjectStoppedDragging()
		{
			if (tooltipIndicator.gameObject.activeSelf)
			{
				ToggleIndicator(isActive: false);
			}
		}
	}
}
