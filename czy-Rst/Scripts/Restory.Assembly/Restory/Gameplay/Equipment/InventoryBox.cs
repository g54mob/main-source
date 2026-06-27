using System;
using Restory.Data.Outline;
using Restory.Gameplay.Effects;
using Restory.Gameplay.Elements;
using Restory.Gameplay.InteractiveObjects;
using Restory.Gameplay.Tooltips;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Equipment
{
	public class InventoryBox : MonoBehaviour, IElementInteractionEquipment, IInitializable, IDisposable
	{
		[SerializeField]
		private ClickableTrigger clickableTrigger;

		[SerializeField]
		private Transform holderPoint;

		[SerializeField]
		private TooltipIndicator tooltipIndicator;

		[SerializeField]
		private BounceEffect bounceEffect;

		[SerializeField]
		private OutlineSettingsPreset brokenElementOutlinePreset;

		private DragObjectRegistrator dragObjectRegistrator;

		private DragElementRegistrator dragElementRegistrator;

		public ClickableTrigger Trigger => clickableTrigger;

		public event Action OnItemAdded;

		[Inject]
		private void Construct(DragObjectRegistrator dragObjectRegistrator, DragElementRegistrator dragElementRegistrator)
		{
			this.dragObjectRegistrator = dragObjectRegistrator;
			this.dragElementRegistrator = dragElementRegistrator;
		}

		public void Initialize()
		{
			dragObjectRegistrator.OnInteractiveObjectStartDrag += ResolveInteractiveObjectStartedDragging;
			dragObjectRegistrator.OnInteractiveObjectStopDrag += ResolveOnInteractiveObjectStopDrag;
			dragElementRegistrator.OnBrokenElementStartDrag += ResolveBrokenElementStartedDragging;
			dragElementRegistrator.OnElementStopDrag += ResolveElementStopDrag;
		}

		public void Dispose()
		{
			dragObjectRegistrator.OnInteractiveObjectStartDrag -= ResolveInteractiveObjectStartedDragging;
			dragObjectRegistrator.OnInteractiveObjectStopDrag -= ResolveOnInteractiveObjectStopDrag;
			dragElementRegistrator.OnBrokenElementStartDrag -= ResolveBrokenElementStartedDragging;
			dragElementRegistrator.OnElementStopDrag -= ResolveElementStopDrag;
		}

		public void ToggleIndicator(bool isActive)
		{
			if (tooltipIndicator.MonoShellExists())
			{
				tooltipIndicator.gameObject.SetActive(isActive);
			}
		}

		public void HandleItemAdded()
		{
			this.OnItemAdded?.Invoke();
			bounceEffect.PlayBounce();
		}

		private void ResolveInteractiveObjectStartedDragging()
		{
			if (dragObjectRegistrator.DraggingObject.TryGetComponent<ElementsContainer>(out var _) || dragObjectRegistrator.DraggingObject.TryGetComponent<ElementsBox>(out var _))
			{
				ToggleIndicator(isActive: true);
			}
		}

		private void ResolveOnInteractiveObjectStopDrag()
		{
			if (tooltipIndicator.gameObject.activeSelf)
			{
				ToggleIndicator(isActive: false);
			}
		}

		private void ResolveBrokenElementStartedDragging()
		{
			clickableTrigger.SetOutlinePreset(brokenElementOutlinePreset);
		}

		private void ResolveElementStopDrag()
		{
			clickableTrigger.ResetOutlinePreset();
		}
	}
}
