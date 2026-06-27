using System;
using Restory.Gameplay.Common;
using Restory.Gameplay.DetectableObjects;
using Restory.Gameplay.Elements;
using Restory.Gameplay.InteractiveObjects;
using Restory.Gameplay.Tooltips;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Restory.Gameplay.Equipment
{
	public class Shredder : MonoBehaviour, IInitializable, IDisposable, IDetectableObject, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		[SerializeField]
		private Transform effectPoint;

		[SerializeField]
		private OutlinableAdapter outlinableAdapter;

		[SerializeField]
		private TooltipIndicator tooltipIndicator;

		private bool isActive;

		private DragObjectRegistrator dragObjectRegistrator;

		private DragElementRegistrator dragElementRegistrator;

		private bool isInitialized;

		public bool CanBeDetected
		{
			set
			{
				base.enabled = value;
			}
		}

		public bool IsDetected { get; private set; }

		public bool IsActive
		{
			get
			{
				return isActive;
			}
			private set
			{
				if (isActive != value)
				{
					isActive = value;
					UpdateOutline();
					UpdateTooltipIndicator();
				}
			}
		}

		public Transform EffectPoint => effectPoint;

		[Inject]
		private void Construct(DragObjectRegistrator dragObjectRegistrator, DragElementRegistrator dragElementRegistrator)
		{
			this.dragObjectRegistrator = dragObjectRegistrator;
			this.dragElementRegistrator = dragElementRegistrator;
			tooltipIndicator.gameObject.SetActive(value: false);
		}

		public void Initialize()
		{
			dragObjectRegistrator.OnTrashObjectStartDrag += ResolveDiscardableObjectStartDrag;
			dragObjectRegistrator.OnInteractiveObjectStopDrag += ResolveObjectStopDrag;
			dragElementRegistrator.OnElementStartDrag += ResolveDiscardableObjectStartDrag;
			dragElementRegistrator.OnElementStopDrag += ResolveObjectStopDrag;
			isInitialized = true;
		}

		public void Dispose()
		{
			dragObjectRegistrator.OnTrashObjectStartDrag -= ResolveDiscardableObjectStartDrag;
			dragObjectRegistrator.OnInteractiveObjectStopDrag -= ResolveObjectStopDrag;
			dragElementRegistrator.OnElementStartDrag -= ResolveDiscardableObjectStartDrag;
			dragElementRegistrator.OnElementStopDrag -= ResolveObjectStopDrag;
		}

		private void UpdateOutline()
		{
			bool flag = isActive && IsDetected;
			if (outlinableAdapter.IsActive != flag)
			{
				outlinableAdapter.IsActive = flag;
			}
		}

		private void UpdateTooltipIndicator()
		{
			tooltipIndicator.gameObject.SetActive(isActive);
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			if (isInitialized)
			{
				IsDetected = true;
				UpdateOutline();
			}
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			if (isInitialized)
			{
				IsDetected = false;
				UpdateOutline();
			}
		}

		private void ResolveDiscardableObjectStartDrag()
		{
			IsDetected = false;
			IsActive = true;
		}

		private void ResolveObjectStopDrag()
		{
			IsActive = false;
		}
	}
}
