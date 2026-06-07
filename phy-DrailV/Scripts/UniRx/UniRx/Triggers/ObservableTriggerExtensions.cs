using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UniRx.Triggers
{
	public static class ObservableTriggerExtensions
	{
		public static IObservable<int> OnAnimatorIKAsObservable(this Component component)
		{
			if (component == null || component.gameObject == null)
			{
				return Observable.Empty<int>();
			}
			return GetOrAddComponent<ObservableAnimatorTrigger>(component.gameObject).OnAnimatorIKAsObservable();
		}

		public static IObservable<Unit> OnAnimatorMoveAsObservable(this Component component)
		{
			if (component == null || component.gameObject == null)
			{
				return Observable.Empty<Unit>();
			}
			return GetOrAddComponent<ObservableAnimatorTrigger>(component.gameObject).OnAnimatorMoveAsObservable();
		}

		public static IObservable<Collision2D> OnCollisionEnter2DAsObservable(this Component component)
		{
			if (component == null || component.gameObject == null)
			{
				return Observable.Empty<Collision2D>();
			}
			return GetOrAddComponent<ObservableCollision2DTrigger>(component.gameObject).OnCollisionEnter2DAsObservable();
		}

		public static IObservable<Collision2D> OnCollisionExit2DAsObservable(this Component component)
		{
			if (component == null || component.gameObject == null)
			{
				return Observable.Empty<Collision2D>();
			}
			return GetOrAddComponent<ObservableCollision2DTrigger>(component.gameObject).OnCollisionExit2DAsObservable();
		}

		public static IObservable<Collision2D> OnCollisionStay2DAsObservable(this Component component)
		{
			if (component == null || component.gameObject == null)
			{
				return Observable.Empty<Collision2D>();
			}
			return GetOrAddComponent<ObservableCollision2DTrigger>(component.gameObject).OnCollisionStay2DAsObservable();
		}

		public static IObservable<Collision> OnCollisionEnterAsObservable(this Component component)
		{
			if (component == null || component.gameObject == null)
			{
				return Observable.Empty<Collision>();
			}
			return GetOrAddComponent<ObservableCollisionTrigger>(component.gameObject).OnCollisionEnterAsObservable();
		}

		public static IObservable<Collision> OnCollisionExitAsObservable(this Component component)
		{
			if (component == null || component.gameObject == null)
			{
				return Observable.Empty<Collision>();
			}
			return GetOrAddComponent<ObservableCollisionTrigger>(component.gameObject).OnCollisionExitAsObservable();
		}

		public static IObservable<Collision> OnCollisionStayAsObservable(this Component component)
		{
			if (component == null || component.gameObject == null)
			{
				return Observable.Empty<Collision>();
			}
			return GetOrAddComponent<ObservableCollisionTrigger>(component.gameObject).OnCollisionStayAsObservable();
		}

		public static IObservable<Unit> OnDestroyAsObservable(this Component component)
		{
			if (component == null || component.gameObject == null)
			{
				return Observable.Return(Unit.Default);
			}
			return GetOrAddComponent<ObservableDestroyTrigger>(component.gameObject).OnDestroyAsObservable();
		}

		public static IObservable<Unit> OnEnableAsObservable(this Component component)
		{
			if (component == null || component.gameObject == null)
			{
				return Observable.Empty<Unit>();
			}
			return GetOrAddComponent<ObservableEnableTrigger>(component.gameObject).OnEnableAsObservable();
		}

		public static IObservable<Unit> OnDisableAsObservable(this Component component)
		{
			if (component == null || component.gameObject == null)
			{
				return Observable.Empty<Unit>();
			}
			return GetOrAddComponent<ObservableEnableTrigger>(component.gameObject).OnDisableAsObservable();
		}

		public static IObservable<Unit> FixedUpdateAsObservable(this Component component)
		{
			if (component == null || component.gameObject == null)
			{
				return Observable.Empty<Unit>();
			}
			return GetOrAddComponent<ObservableFixedUpdateTrigger>(component.gameObject).FixedUpdateAsObservable();
		}

		public static IObservable<Unit> LateUpdateAsObservable(this Component component)
		{
			if (component == null || component.gameObject == null)
			{
				return Observable.Empty<Unit>();
			}
			return GetOrAddComponent<ObservableLateUpdateTrigger>(component.gameObject).LateUpdateAsObservable();
		}

		public static IObservable<Unit> OnMouseDownAsObservable(this Component component)
		{
			if (component == null || component.gameObject == null)
			{
				return Observable.Empty<Unit>();
			}
			return GetOrAddComponent<ObservableMouseTrigger>(component.gameObject).OnMouseDownAsObservable();
		}

		public static IObservable<Unit> OnMouseDragAsObservable(this Component component)
		{
			if (component == null || component.gameObject == null)
			{
				return Observable.Empty<Unit>();
			}
			return GetOrAddComponent<ObservableMouseTrigger>(component.gameObject).OnMouseDragAsObservable();
		}

		public static IObservable<Unit> OnMouseEnterAsObservable(this Component component)
		{
			if (component == null || component.gameObject == null)
			{
				return Observable.Empty<Unit>();
			}
			return GetOrAddComponent<ObservableMouseTrigger>(component.gameObject).OnMouseEnterAsObservable();
		}

		public static IObservable<Unit> OnMouseExitAsObservable(this Component component)
		{
			if (component == null || component.gameObject == null)
			{
				return Observable.Empty<Unit>();
			}
			return GetOrAddComponent<ObservableMouseTrigger>(component.gameObject).OnMouseExitAsObservable();
		}

		public static IObservable<Unit> OnMouseOverAsObservable(this Component component)
		{
			if (component == null || component.gameObject == null)
			{
				return Observable.Empty<Unit>();
			}
			return GetOrAddComponent<ObservableMouseTrigger>(component.gameObject).OnMouseOverAsObservable();
		}

		public static IObservable<Unit> OnMouseUpAsObservable(this Component component)
		{
			if (component == null || component.gameObject == null)
			{
				return Observable.Empty<Unit>();
			}
			return GetOrAddComponent<ObservableMouseTrigger>(component.gameObject).OnMouseUpAsObservable();
		}

		public static IObservable<Unit> OnMouseUpAsButtonAsObservable(this Component component)
		{
			if (component == null || component.gameObject == null)
			{
				return Observable.Empty<Unit>();
			}
			return GetOrAddComponent<ObservableMouseTrigger>(component.gameObject).OnMouseUpAsButtonAsObservable();
		}

		public static IObservable<Collider2D> OnTriggerEnter2DAsObservable(this Component component)
		{
			if (component == null || component.gameObject == null)
			{
				return Observable.Empty<Collider2D>();
			}
			return GetOrAddComponent<ObservableTrigger2DTrigger>(component.gameObject).OnTriggerEnter2DAsObservable();
		}

		public static IObservable<Collider2D> OnTriggerExit2DAsObservable(this Component component)
		{
			if (component == null || component.gameObject == null)
			{
				return Observable.Empty<Collider2D>();
			}
			return GetOrAddComponent<ObservableTrigger2DTrigger>(component.gameObject).OnTriggerExit2DAsObservable();
		}

		public static IObservable<Collider2D> OnTriggerStay2DAsObservable(this Component component)
		{
			if (component == null || component.gameObject == null)
			{
				return Observable.Empty<Collider2D>();
			}
			return GetOrAddComponent<ObservableTrigger2DTrigger>(component.gameObject).OnTriggerStay2DAsObservable();
		}

		public static IObservable<Collider> OnTriggerEnterAsObservable(this Component component)
		{
			if (component == null || component.gameObject == null)
			{
				return Observable.Empty<Collider>();
			}
			return GetOrAddComponent<ObservableTriggerTrigger>(component.gameObject).OnTriggerEnterAsObservable();
		}

		public static IObservable<Collider> OnTriggerExitAsObservable(this Component component)
		{
			if (component == null || component.gameObject == null)
			{
				return Observable.Empty<Collider>();
			}
			return GetOrAddComponent<ObservableTriggerTrigger>(component.gameObject).OnTriggerExitAsObservable();
		}

		public static IObservable<Collider> OnTriggerStayAsObservable(this Component component)
		{
			if (component == null || component.gameObject == null)
			{
				return Observable.Empty<Collider>();
			}
			return GetOrAddComponent<ObservableTriggerTrigger>(component.gameObject).OnTriggerStayAsObservable();
		}

		public static IObservable<Unit> UpdateAsObservable(this Component component)
		{
			if (component == null || component.gameObject == null)
			{
				return Observable.Empty<Unit>();
			}
			return GetOrAddComponent<ObservableUpdateTrigger>(component.gameObject).UpdateAsObservable();
		}

		public static IObservable<Unit> OnBecameInvisibleAsObservable(this Component component)
		{
			if (component == null || component.gameObject == null)
			{
				return Observable.Empty<Unit>();
			}
			return GetOrAddComponent<ObservableVisibleTrigger>(component.gameObject).OnBecameInvisibleAsObservable();
		}

		public static IObservable<Unit> OnBecameVisibleAsObservable(this Component component)
		{
			if (component == null || component.gameObject == null)
			{
				return Observable.Empty<Unit>();
			}
			return GetOrAddComponent<ObservableVisibleTrigger>(component.gameObject).OnBecameVisibleAsObservable();
		}

		public static IObservable<Unit> OnBeforeTransformParentChangedAsObservable(this Component component)
		{
			if (component == null || component.gameObject == null)
			{
				return Observable.Empty<Unit>();
			}
			return GetOrAddComponent<ObservableTransformChangedTrigger>(component.gameObject).OnBeforeTransformParentChangedAsObservable();
		}

		public static IObservable<Unit> OnTransformParentChangedAsObservable(this Component component)
		{
			if (component == null || component.gameObject == null)
			{
				return Observable.Empty<Unit>();
			}
			return GetOrAddComponent<ObservableTransformChangedTrigger>(component.gameObject).OnTransformParentChangedAsObservable();
		}

		public static IObservable<Unit> OnTransformChildrenChangedAsObservable(this Component component)
		{
			if (component == null || component.gameObject == null)
			{
				return Observable.Empty<Unit>();
			}
			return GetOrAddComponent<ObservableTransformChangedTrigger>(component.gameObject).OnTransformChildrenChangedAsObservable();
		}

		public static IObservable<Unit> OnCanvasGroupChangedAsObservable(this Component component)
		{
			if (component == null || component.gameObject == null)
			{
				return Observable.Empty<Unit>();
			}
			return GetOrAddComponent<ObservableCanvasGroupChangedTrigger>(component.gameObject).OnCanvasGroupChangedAsObservable();
		}

		public static IObservable<Unit> OnRectTransformDimensionsChangeAsObservable(this Component component)
		{
			if (component == null || component.gameObject == null)
			{
				return Observable.Empty<Unit>();
			}
			return GetOrAddComponent<ObservableRectTransformTrigger>(component.gameObject).OnRectTransformDimensionsChangeAsObservable();
		}

		public static IObservable<Unit> OnRectTransformRemovedAsObservable(this Component component)
		{
			if (component == null || component.gameObject == null)
			{
				return Observable.Empty<Unit>();
			}
			return GetOrAddComponent<ObservableRectTransformTrigger>(component.gameObject).OnRectTransformRemovedAsObservable();
		}

		public static IObservable<BaseEventData> OnDeselectAsObservable(this UIBehaviour component)
		{
			if (component == null || component.gameObject == null)
			{
				return Observable.Empty<BaseEventData>();
			}
			return GetOrAddComponent<ObservableDeselectTrigger>(component.gameObject).OnDeselectAsObservable();
		}

		public static IObservable<AxisEventData> OnMoveAsObservable(this UIBehaviour component)
		{
			if (component == null || component.gameObject == null)
			{
				return Observable.Empty<AxisEventData>();
			}
			return GetOrAddComponent<ObservableMoveTrigger>(component.gameObject).OnMoveAsObservable();
		}

		public static IObservable<PointerEventData> OnPointerDownAsObservable(this UIBehaviour component)
		{
			if (component == null || component.gameObject == null)
			{
				return Observable.Empty<PointerEventData>();
			}
			return GetOrAddComponent<ObservablePointerDownTrigger>(component.gameObject).OnPointerDownAsObservable();
		}

		public static IObservable<PointerEventData> OnPointerEnterAsObservable(this UIBehaviour component)
		{
			if (component == null || component.gameObject == null)
			{
				return Observable.Empty<PointerEventData>();
			}
			return GetOrAddComponent<ObservablePointerEnterTrigger>(component.gameObject).OnPointerEnterAsObservable();
		}

		public static IObservable<PointerEventData> OnPointerExitAsObservable(this UIBehaviour component)
		{
			if (component == null || component.gameObject == null)
			{
				return Observable.Empty<PointerEventData>();
			}
			return GetOrAddComponent<ObservablePointerExitTrigger>(component.gameObject).OnPointerExitAsObservable();
		}

		public static IObservable<PointerEventData> OnPointerUpAsObservable(this UIBehaviour component)
		{
			if (component == null || component.gameObject == null)
			{
				return Observable.Empty<PointerEventData>();
			}
			return GetOrAddComponent<ObservablePointerUpTrigger>(component.gameObject).OnPointerUpAsObservable();
		}

		public static IObservable<BaseEventData> OnSelectAsObservable(this UIBehaviour component)
		{
			if (component == null || component.gameObject == null)
			{
				return Observable.Empty<BaseEventData>();
			}
			return GetOrAddComponent<ObservableSelectTrigger>(component.gameObject).OnSelectAsObservable();
		}

		public static IObservable<PointerEventData> OnPointerClickAsObservable(this UIBehaviour component)
		{
			if (component == null || component.gameObject == null)
			{
				return Observable.Empty<PointerEventData>();
			}
			return GetOrAddComponent<ObservablePointerClickTrigger>(component.gameObject).OnPointerClickAsObservable();
		}

		public static IObservable<BaseEventData> OnSubmitAsObservable(this UIBehaviour component)
		{
			if (component == null || component.gameObject == null)
			{
				return Observable.Empty<BaseEventData>();
			}
			return GetOrAddComponent<ObservableSubmitTrigger>(component.gameObject).OnSubmitAsObservable();
		}

		public static IObservable<PointerEventData> OnDragAsObservable(this UIBehaviour component)
		{
			if (component == null || component.gameObject == null)
			{
				return Observable.Empty<PointerEventData>();
			}
			return GetOrAddComponent<ObservableDragTrigger>(component.gameObject).OnDragAsObservable();
		}

		public static IObservable<PointerEventData> OnBeginDragAsObservable(this UIBehaviour component)
		{
			if (component == null || component.gameObject == null)
			{
				return Observable.Empty<PointerEventData>();
			}
			return GetOrAddComponent<ObservableBeginDragTrigger>(component.gameObject).OnBeginDragAsObservable();
		}

		public static IObservable<PointerEventData> OnEndDragAsObservable(this UIBehaviour component)
		{
			if (component == null || component.gameObject == null)
			{
				return Observable.Empty<PointerEventData>();
			}
			return GetOrAddComponent<ObservableEndDragTrigger>(component.gameObject).OnEndDragAsObservable();
		}

		public static IObservable<PointerEventData> OnDropAsObservable(this UIBehaviour component)
		{
			if (component == null || component.gameObject == null)
			{
				return Observable.Empty<PointerEventData>();
			}
			return GetOrAddComponent<ObservableDropTrigger>(component.gameObject).OnDropAsObservable();
		}

		public static IObservable<BaseEventData> OnUpdateSelectedAsObservable(this UIBehaviour component)
		{
			if (component == null || component.gameObject == null)
			{
				return Observable.Empty<BaseEventData>();
			}
			return GetOrAddComponent<ObservableUpdateSelectedTrigger>(component.gameObject).OnUpdateSelectedAsObservable();
		}

		public static IObservable<PointerEventData> OnInitializePotentialDragAsObservable(this UIBehaviour component)
		{
			if (component == null || component.gameObject == null)
			{
				return Observable.Empty<PointerEventData>();
			}
			return GetOrAddComponent<ObservableInitializePotentialDragTrigger>(component.gameObject).OnInitializePotentialDragAsObservable();
		}

		public static IObservable<BaseEventData> OnCancelAsObservable(this UIBehaviour component)
		{
			if (component == null || component.gameObject == null)
			{
				return Observable.Empty<BaseEventData>();
			}
			return GetOrAddComponent<ObservableCancelTrigger>(component.gameObject).OnCancelAsObservable();
		}

		public static IObservable<PointerEventData> OnScrollAsObservable(this UIBehaviour component)
		{
			if (component == null || component.gameObject == null)
			{
				return Observable.Empty<PointerEventData>();
			}
			return GetOrAddComponent<ObservableScrollTrigger>(component.gameObject).OnScrollAsObservable();
		}

		public static IObservable<GameObject> OnParticleCollisionAsObservable(this Component component)
		{
			if (component == null || component.gameObject == null)
			{
				return Observable.Empty<GameObject>();
			}
			return GetOrAddComponent<ObservableParticleTrigger>(component.gameObject).OnParticleCollisionAsObservable();
		}

		public static IObservable<Unit> OnParticleTriggerAsObservable(this Component component)
		{
			if (component == null || component.gameObject == null)
			{
				return Observable.Empty<Unit>();
			}
			return GetOrAddComponent<ObservableParticleTrigger>(component.gameObject).OnParticleTriggerAsObservable();
		}

		public static IObservable<int> OnAnimatorIKAsObservable(this GameObject gameObject)
		{
			if (gameObject == null)
			{
				return Observable.Empty<int>();
			}
			return GetOrAddComponent<ObservableAnimatorTrigger>(gameObject).OnAnimatorIKAsObservable();
		}

		public static IObservable<Unit> OnAnimatorMoveAsObservable(this GameObject gameObject)
		{
			if (gameObject == null)
			{
				return Observable.Empty<Unit>();
			}
			return GetOrAddComponent<ObservableAnimatorTrigger>(gameObject).OnAnimatorMoveAsObservable();
		}

		public static IObservable<Collision2D> OnCollisionEnter2DAsObservable(this GameObject gameObject)
		{
			if (gameObject == null)
			{
				return Observable.Empty<Collision2D>();
			}
			return GetOrAddComponent<ObservableCollision2DTrigger>(gameObject).OnCollisionEnter2DAsObservable();
		}

		public static IObservable<Collision2D> OnCollisionExit2DAsObservable(this GameObject gameObject)
		{
			if (gameObject == null)
			{
				return Observable.Empty<Collision2D>();
			}
			return GetOrAddComponent<ObservableCollision2DTrigger>(gameObject).OnCollisionExit2DAsObservable();
		}

		public static IObservable<Collision2D> OnCollisionStay2DAsObservable(this GameObject gameObject)
		{
			if (gameObject == null)
			{
				return Observable.Empty<Collision2D>();
			}
			return GetOrAddComponent<ObservableCollision2DTrigger>(gameObject).OnCollisionStay2DAsObservable();
		}

		public static IObservable<Collision> OnCollisionEnterAsObservable(this GameObject gameObject)
		{
			if (gameObject == null)
			{
				return Observable.Empty<Collision>();
			}
			return GetOrAddComponent<ObservableCollisionTrigger>(gameObject).OnCollisionEnterAsObservable();
		}

		public static IObservable<Collision> OnCollisionExitAsObservable(this GameObject gameObject)
		{
			if (gameObject == null)
			{
				return Observable.Empty<Collision>();
			}
			return GetOrAddComponent<ObservableCollisionTrigger>(gameObject).OnCollisionExitAsObservable();
		}

		public static IObservable<Collision> OnCollisionStayAsObservable(this GameObject gameObject)
		{
			if (gameObject == null)
			{
				return Observable.Empty<Collision>();
			}
			return GetOrAddComponent<ObservableCollisionTrigger>(gameObject).OnCollisionStayAsObservable();
		}

		public static IObservable<Unit> OnDestroyAsObservable(this GameObject gameObject)
		{
			if (gameObject == null)
			{
				return Observable.Return(Unit.Default);
			}
			return GetOrAddComponent<ObservableDestroyTrigger>(gameObject).OnDestroyAsObservable();
		}

		public static IObservable<Unit> OnEnableAsObservable(this GameObject gameObject)
		{
			if (gameObject == null)
			{
				return Observable.Empty<Unit>();
			}
			return GetOrAddComponent<ObservableEnableTrigger>(gameObject).OnEnableAsObservable();
		}

		public static IObservable<Unit> OnDisableAsObservable(this GameObject gameObject)
		{
			if (gameObject == null)
			{
				return Observable.Empty<Unit>();
			}
			return GetOrAddComponent<ObservableEnableTrigger>(gameObject).OnDisableAsObservable();
		}

		public static IObservable<Unit> FixedUpdateAsObservable(this GameObject gameObject)
		{
			if (gameObject == null)
			{
				return Observable.Empty<Unit>();
			}
			return GetOrAddComponent<ObservableFixedUpdateTrigger>(gameObject).FixedUpdateAsObservable();
		}

		public static IObservable<Unit> LateUpdateAsObservable(this GameObject gameObject)
		{
			if (gameObject == null)
			{
				return Observable.Empty<Unit>();
			}
			return GetOrAddComponent<ObservableLateUpdateTrigger>(gameObject).LateUpdateAsObservable();
		}

		public static IObservable<Unit> OnMouseDownAsObservable(this GameObject gameObject)
		{
			if (gameObject == null)
			{
				return Observable.Empty<Unit>();
			}
			return GetOrAddComponent<ObservableMouseTrigger>(gameObject).OnMouseDownAsObservable();
		}

		public static IObservable<Unit> OnMouseDragAsObservable(this GameObject gameObject)
		{
			if (gameObject == null)
			{
				return Observable.Empty<Unit>();
			}
			return GetOrAddComponent<ObservableMouseTrigger>(gameObject).OnMouseDragAsObservable();
		}

		public static IObservable<Unit> OnMouseEnterAsObservable(this GameObject gameObject)
		{
			if (gameObject == null)
			{
				return Observable.Empty<Unit>();
			}
			return GetOrAddComponent<ObservableMouseTrigger>(gameObject).OnMouseEnterAsObservable();
		}

		public static IObservable<Unit> OnMouseExitAsObservable(this GameObject gameObject)
		{
			if (gameObject == null)
			{
				return Observable.Empty<Unit>();
			}
			return GetOrAddComponent<ObservableMouseTrigger>(gameObject).OnMouseExitAsObservable();
		}

		public static IObservable<Unit> OnMouseOverAsObservable(this GameObject gameObject)
		{
			if (gameObject == null)
			{
				return Observable.Empty<Unit>();
			}
			return GetOrAddComponent<ObservableMouseTrigger>(gameObject).OnMouseOverAsObservable();
		}

		public static IObservable<Unit> OnMouseUpAsObservable(this GameObject gameObject)
		{
			if (gameObject == null)
			{
				return Observable.Empty<Unit>();
			}
			return GetOrAddComponent<ObservableMouseTrigger>(gameObject).OnMouseUpAsObservable();
		}

		public static IObservable<Unit> OnMouseUpAsButtonAsObservable(this GameObject gameObject)
		{
			if (gameObject == null)
			{
				return Observable.Empty<Unit>();
			}
			return GetOrAddComponent<ObservableMouseTrigger>(gameObject).OnMouseUpAsButtonAsObservable();
		}

		public static IObservable<Collider2D> OnTriggerEnter2DAsObservable(this GameObject gameObject)
		{
			if (gameObject == null)
			{
				return Observable.Empty<Collider2D>();
			}
			return GetOrAddComponent<ObservableTrigger2DTrigger>(gameObject).OnTriggerEnter2DAsObservable();
		}

		public static IObservable<Collider2D> OnTriggerExit2DAsObservable(this GameObject gameObject)
		{
			if (gameObject == null)
			{
				return Observable.Empty<Collider2D>();
			}
			return GetOrAddComponent<ObservableTrigger2DTrigger>(gameObject).OnTriggerExit2DAsObservable();
		}

		public static IObservable<Collider2D> OnTriggerStay2DAsObservable(this GameObject gameObject)
		{
			if (gameObject == null)
			{
				return Observable.Empty<Collider2D>();
			}
			return GetOrAddComponent<ObservableTrigger2DTrigger>(gameObject).OnTriggerStay2DAsObservable();
		}

		public static IObservable<Collider> OnTriggerEnterAsObservable(this GameObject gameObject)
		{
			if (gameObject == null)
			{
				return Observable.Empty<Collider>();
			}
			return GetOrAddComponent<ObservableTriggerTrigger>(gameObject).OnTriggerEnterAsObservable();
		}

		public static IObservable<Collider> OnTriggerExitAsObservable(this GameObject gameObject)
		{
			if (gameObject == null)
			{
				return Observable.Empty<Collider>();
			}
			return GetOrAddComponent<ObservableTriggerTrigger>(gameObject).OnTriggerExitAsObservable();
		}

		public static IObservable<Collider> OnTriggerStayAsObservable(this GameObject gameObject)
		{
			if (gameObject == null)
			{
				return Observable.Empty<Collider>();
			}
			return GetOrAddComponent<ObservableTriggerTrigger>(gameObject).OnTriggerStayAsObservable();
		}

		public static IObservable<Unit> UpdateAsObservable(this GameObject gameObject)
		{
			if (gameObject == null)
			{
				return Observable.Empty<Unit>();
			}
			return GetOrAddComponent<ObservableUpdateTrigger>(gameObject).UpdateAsObservable();
		}

		public static IObservable<Unit> OnBecameInvisibleAsObservable(this GameObject gameObject)
		{
			if (gameObject == null)
			{
				return Observable.Empty<Unit>();
			}
			return GetOrAddComponent<ObservableVisibleTrigger>(gameObject).OnBecameInvisibleAsObservable();
		}

		public static IObservable<Unit> OnBecameVisibleAsObservable(this GameObject gameObject)
		{
			if (gameObject == null)
			{
				return Observable.Empty<Unit>();
			}
			return GetOrAddComponent<ObservableVisibleTrigger>(gameObject).OnBecameVisibleAsObservable();
		}

		public static IObservable<Unit> OnBeforeTransformParentChangedAsObservable(this GameObject gameObject)
		{
			if (gameObject == null)
			{
				return Observable.Empty<Unit>();
			}
			return GetOrAddComponent<ObservableTransformChangedTrigger>(gameObject).OnBeforeTransformParentChangedAsObservable();
		}

		public static IObservable<Unit> OnTransformParentChangedAsObservable(this GameObject gameObject)
		{
			if (gameObject == null)
			{
				return Observable.Empty<Unit>();
			}
			return GetOrAddComponent<ObservableTransformChangedTrigger>(gameObject).OnTransformParentChangedAsObservable();
		}

		public static IObservable<Unit> OnTransformChildrenChangedAsObservable(this GameObject gameObject)
		{
			if (gameObject == null)
			{
				return Observable.Empty<Unit>();
			}
			return GetOrAddComponent<ObservableTransformChangedTrigger>(gameObject).OnTransformChildrenChangedAsObservable();
		}

		public static IObservable<Unit> OnCanvasGroupChangedAsObservable(this GameObject gameObject)
		{
			if (gameObject == null)
			{
				return Observable.Empty<Unit>();
			}
			return GetOrAddComponent<ObservableCanvasGroupChangedTrigger>(gameObject).OnCanvasGroupChangedAsObservable();
		}

		public static IObservable<Unit> OnRectTransformDimensionsChangeAsObservable(this GameObject gameObject)
		{
			if (gameObject == null)
			{
				return Observable.Empty<Unit>();
			}
			return GetOrAddComponent<ObservableRectTransformTrigger>(gameObject).OnRectTransformDimensionsChangeAsObservable();
		}

		public static IObservable<Unit> OnRectTransformRemovedAsObservable(this GameObject gameObject)
		{
			if (gameObject == null)
			{
				return Observable.Empty<Unit>();
			}
			return GetOrAddComponent<ObservableRectTransformTrigger>(gameObject).OnRectTransformRemovedAsObservable();
		}

		public static IObservable<GameObject> OnParticleCollisionAsObservable(this GameObject gameObject)
		{
			if (gameObject == null)
			{
				return Observable.Empty<GameObject>();
			}
			return GetOrAddComponent<ObservableParticleTrigger>(gameObject).OnParticleCollisionAsObservable();
		}

		public static IObservable<Unit> OnParticleTriggerAsObservable(this GameObject gameObject)
		{
			if (gameObject == null)
			{
				return Observable.Empty<Unit>();
			}
			return GetOrAddComponent<ObservableParticleTrigger>(gameObject).OnParticleTriggerAsObservable();
		}

		private static T GetOrAddComponent<T>(GameObject gameObject) where T : Component
		{
			T val = gameObject.GetComponent<T>();
			if (val == null)
			{
				val = gameObject.AddComponent<T>();
			}
			return val;
		}
	}
}
