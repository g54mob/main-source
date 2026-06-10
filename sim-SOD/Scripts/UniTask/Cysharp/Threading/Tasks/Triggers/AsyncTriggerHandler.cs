using System;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.ParticleSystemJobs;

namespace Cysharp.Threading.Tasks.Triggers
{
	public sealed class AsyncTriggerHandler<T> : IAsyncOneShotTrigger, IUniTaskSource<T>, IUniTaskSource, ITriggerHandler<T>, IDisposable, IAsyncFixedUpdateHandler, IAsyncLateUpdateHandler, IAsyncOnAnimatorIKHandler, IAsyncOnAnimatorMoveHandler, IAsyncOnApplicationFocusHandler, IAsyncOnApplicationPauseHandler, IAsyncOnApplicationQuitHandler, IAsyncOnAudioFilterReadHandler, IAsyncOnBecameInvisibleHandler, IAsyncOnBecameVisibleHandler, IAsyncOnBeforeTransformParentChangedHandler, IAsyncOnCanvasGroupChangedHandler, IAsyncOnCollisionEnterHandler, IAsyncOnCollisionEnter2DHandler, IAsyncOnCollisionExitHandler, IAsyncOnCollisionExit2DHandler, IAsyncOnCollisionStayHandler, IAsyncOnCollisionStay2DHandler, IAsyncOnControllerColliderHitHandler, IAsyncOnDisableHandler, IAsyncOnDrawGizmosHandler, IAsyncOnDrawGizmosSelectedHandler, IAsyncOnEnableHandler, IAsyncOnGUIHandler, IAsyncOnJointBreakHandler, IAsyncOnJointBreak2DHandler, IAsyncOnMouseDownHandler, IAsyncOnMouseDragHandler, IAsyncOnMouseEnterHandler, IAsyncOnMouseExitHandler, IAsyncOnMouseOverHandler, IAsyncOnMouseUpHandler, IAsyncOnMouseUpAsButtonHandler, IAsyncOnParticleCollisionHandler, IAsyncOnParticleSystemStoppedHandler, IAsyncOnParticleTriggerHandler, IAsyncOnParticleUpdateJobScheduledHandler, IAsyncOnPostRenderHandler, IAsyncOnPreCullHandler, IAsyncOnPreRenderHandler, IAsyncOnRectTransformDimensionsChangeHandler, IAsyncOnRectTransformRemovedHandler, IAsyncOnRenderImageHandler, IAsyncOnRenderObjectHandler, IAsyncOnServerInitializedHandler, IAsyncOnTransformChildrenChangedHandler, IAsyncOnTransformParentChangedHandler, IAsyncOnTriggerEnterHandler, IAsyncOnTriggerEnter2DHandler, IAsyncOnTriggerExitHandler, IAsyncOnTriggerExit2DHandler, IAsyncOnTriggerStayHandler, IAsyncOnTriggerStay2DHandler, IAsyncOnValidateHandler, IAsyncOnWillRenderObjectHandler, IAsyncResetHandler, IAsyncUpdateHandler, IAsyncOnBeginDragHandler, IAsyncOnCancelHandler, IAsyncOnDeselectHandler, IAsyncOnDragHandler, IAsyncOnDropHandler, IAsyncOnEndDragHandler, IAsyncOnInitializePotentialDragHandler, IAsyncOnMoveHandler, IAsyncOnPointerClickHandler, IAsyncOnPointerDownHandler, IAsyncOnPointerEnterHandler, IAsyncOnPointerExitHandler, IAsyncOnPointerUpHandler, IAsyncOnScrollHandler, IAsyncOnSelectHandler, IAsyncOnSubmitHandler, IAsyncOnUpdateSelectedHandler
	{
		private static Action<object> cancellationCallback;

		private readonly AsyncTriggerBase<T> trigger;

		private CancellationToken cancellationToken;

		private CancellationTokenRegistration registration;

		private bool isDisposed;

		private bool callOnce;

		private UniTaskCompletionSourceCore<T> core;

		[CompilerGenerated]
		private ITriggerHandler<T> _003CCysharp_002EThreading_002ETasks_002EITriggerHandler_003CT_003E_002EPrev_003Ek__BackingField;

		[CompilerGenerated]
		private ITriggerHandler<T> _003CCysharp_002EThreading_002ETasks_002EITriggerHandler_003CT_003E_002ENext_003Ek__BackingField;

		ITriggerHandler<T> ITriggerHandler<T>.Prev
		{
			[CompilerGenerated]
			get
			{
				return null;
			}
			[CompilerGenerated]
			set
			{
			}
		}

		ITriggerHandler<T> ITriggerHandler<T>.Next
		{
			[CompilerGenerated]
			get
			{
				return null;
			}
			[CompilerGenerated]
			set
			{
			}
		}

		UniTask IAsyncOneShotTrigger.OneShotAsync()
		{
			return default(UniTask);
		}

		internal AsyncTriggerHandler(AsyncTriggerBase<T> trigger, bool callOnce)
		{
		}

		internal AsyncTriggerHandler(AsyncTriggerBase<T> trigger, CancellationToken cancellationToken, bool callOnce)
		{
		}

		private static void CancellationCallback(object state)
		{
		}

		public void Dispose()
		{
		}

		T IUniTaskSource<T>.GetResult(short token)
		{
			return default(T);
		}

		void ITriggerHandler<T>.OnNext(T value)
		{
		}

		void ITriggerHandler<T>.OnCompleted()
		{
		}

		void IUniTaskSource.GetResult(short token)
		{
		}

		UniTaskStatus IUniTaskSource.GetStatus(short token)
		{
			return default(UniTaskStatus);
		}

		UniTaskStatus IUniTaskSource.UnsafeGetStatus()
		{
			return default(UniTaskStatus);
		}

		void IUniTaskSource.OnCompleted(Action<object> continuation, object state, short token)
		{
		}

		UniTask IAsyncFixedUpdateHandler.FixedUpdateAsync()
		{
			return default(UniTask);
		}

		UniTask IAsyncLateUpdateHandler.LateUpdateAsync()
		{
			return default(UniTask);
		}

		UniTask<int> IAsyncOnAnimatorIKHandler.OnAnimatorIKAsync()
		{
			return default(UniTask<int>);
		}

		UniTask IAsyncOnAnimatorMoveHandler.OnAnimatorMoveAsync()
		{
			return default(UniTask);
		}

		UniTask<bool> IAsyncOnApplicationFocusHandler.OnApplicationFocusAsync()
		{
			return default(UniTask<bool>);
		}

		UniTask<bool> IAsyncOnApplicationPauseHandler.OnApplicationPauseAsync()
		{
			return default(UniTask<bool>);
		}

		UniTask IAsyncOnApplicationQuitHandler.OnApplicationQuitAsync()
		{
			return default(UniTask);
		}

		UniTask<(float[], int)> IAsyncOnAudioFilterReadHandler.OnAudioFilterReadAsync()
		{
			return default(UniTask<(float[], int)>);
		}

		UniTask IAsyncOnBecameInvisibleHandler.OnBecameInvisibleAsync()
		{
			return default(UniTask);
		}

		UniTask IAsyncOnBecameVisibleHandler.OnBecameVisibleAsync()
		{
			return default(UniTask);
		}

		UniTask IAsyncOnBeforeTransformParentChangedHandler.OnBeforeTransformParentChangedAsync()
		{
			return default(UniTask);
		}

		UniTask IAsyncOnCanvasGroupChangedHandler.OnCanvasGroupChangedAsync()
		{
			return default(UniTask);
		}

		UniTask<Collision> IAsyncOnCollisionEnterHandler.OnCollisionEnterAsync()
		{
			return default(UniTask<Collision>);
		}

		UniTask<Collision2D> IAsyncOnCollisionEnter2DHandler.OnCollisionEnter2DAsync()
		{
			return default(UniTask<Collision2D>);
		}

		UniTask<Collision> IAsyncOnCollisionExitHandler.OnCollisionExitAsync()
		{
			return default(UniTask<Collision>);
		}

		UniTask<Collision2D> IAsyncOnCollisionExit2DHandler.OnCollisionExit2DAsync()
		{
			return default(UniTask<Collision2D>);
		}

		UniTask<Collision> IAsyncOnCollisionStayHandler.OnCollisionStayAsync()
		{
			return default(UniTask<Collision>);
		}

		UniTask<Collision2D> IAsyncOnCollisionStay2DHandler.OnCollisionStay2DAsync()
		{
			return default(UniTask<Collision2D>);
		}

		UniTask<ControllerColliderHit> IAsyncOnControllerColliderHitHandler.OnControllerColliderHitAsync()
		{
			return default(UniTask<ControllerColliderHit>);
		}

		UniTask IAsyncOnDisableHandler.OnDisableAsync()
		{
			return default(UniTask);
		}

		UniTask IAsyncOnDrawGizmosHandler.OnDrawGizmosAsync()
		{
			return default(UniTask);
		}

		UniTask IAsyncOnDrawGizmosSelectedHandler.OnDrawGizmosSelectedAsync()
		{
			return default(UniTask);
		}

		UniTask IAsyncOnEnableHandler.OnEnableAsync()
		{
			return default(UniTask);
		}

		UniTask IAsyncOnGUIHandler.OnGUIAsync()
		{
			return default(UniTask);
		}

		UniTask<float> IAsyncOnJointBreakHandler.OnJointBreakAsync()
		{
			return default(UniTask<float>);
		}

		UniTask<Joint2D> IAsyncOnJointBreak2DHandler.OnJointBreak2DAsync()
		{
			return default(UniTask<Joint2D>);
		}

		UniTask IAsyncOnMouseDownHandler.OnMouseDownAsync()
		{
			return default(UniTask);
		}

		UniTask IAsyncOnMouseDragHandler.OnMouseDragAsync()
		{
			return default(UniTask);
		}

		UniTask IAsyncOnMouseEnterHandler.OnMouseEnterAsync()
		{
			return default(UniTask);
		}

		UniTask IAsyncOnMouseExitHandler.OnMouseExitAsync()
		{
			return default(UniTask);
		}

		UniTask IAsyncOnMouseOverHandler.OnMouseOverAsync()
		{
			return default(UniTask);
		}

		UniTask IAsyncOnMouseUpHandler.OnMouseUpAsync()
		{
			return default(UniTask);
		}

		UniTask IAsyncOnMouseUpAsButtonHandler.OnMouseUpAsButtonAsync()
		{
			return default(UniTask);
		}

		UniTask<GameObject> IAsyncOnParticleCollisionHandler.OnParticleCollisionAsync()
		{
			return default(UniTask<GameObject>);
		}

		UniTask IAsyncOnParticleSystemStoppedHandler.OnParticleSystemStoppedAsync()
		{
			return default(UniTask);
		}

		UniTask IAsyncOnParticleTriggerHandler.OnParticleTriggerAsync()
		{
			return default(UniTask);
		}

		UniTask<ParticleSystemJobData> IAsyncOnParticleUpdateJobScheduledHandler.OnParticleUpdateJobScheduledAsync()
		{
			return default(UniTask<ParticleSystemJobData>);
		}

		UniTask IAsyncOnPostRenderHandler.OnPostRenderAsync()
		{
			return default(UniTask);
		}

		UniTask IAsyncOnPreCullHandler.OnPreCullAsync()
		{
			return default(UniTask);
		}

		UniTask IAsyncOnPreRenderHandler.OnPreRenderAsync()
		{
			return default(UniTask);
		}

		UniTask IAsyncOnRectTransformDimensionsChangeHandler.OnRectTransformDimensionsChangeAsync()
		{
			return default(UniTask);
		}

		UniTask IAsyncOnRectTransformRemovedHandler.OnRectTransformRemovedAsync()
		{
			return default(UniTask);
		}

		UniTask<(RenderTexture, RenderTexture)> IAsyncOnRenderImageHandler.OnRenderImageAsync()
		{
			return default(UniTask<(RenderTexture, RenderTexture)>);
		}

		UniTask IAsyncOnRenderObjectHandler.OnRenderObjectAsync()
		{
			return default(UniTask);
		}

		UniTask IAsyncOnServerInitializedHandler.OnServerInitializedAsync()
		{
			return default(UniTask);
		}

		UniTask IAsyncOnTransformChildrenChangedHandler.OnTransformChildrenChangedAsync()
		{
			return default(UniTask);
		}

		UniTask IAsyncOnTransformParentChangedHandler.OnTransformParentChangedAsync()
		{
			return default(UniTask);
		}

		UniTask<Collider> IAsyncOnTriggerEnterHandler.OnTriggerEnterAsync()
		{
			return default(UniTask<Collider>);
		}

		UniTask<Collider2D> IAsyncOnTriggerEnter2DHandler.OnTriggerEnter2DAsync()
		{
			return default(UniTask<Collider2D>);
		}

		UniTask<Collider> IAsyncOnTriggerExitHandler.OnTriggerExitAsync()
		{
			return default(UniTask<Collider>);
		}

		UniTask<Collider2D> IAsyncOnTriggerExit2DHandler.OnTriggerExit2DAsync()
		{
			return default(UniTask<Collider2D>);
		}

		UniTask<Collider> IAsyncOnTriggerStayHandler.OnTriggerStayAsync()
		{
			return default(UniTask<Collider>);
		}

		UniTask<Collider2D> IAsyncOnTriggerStay2DHandler.OnTriggerStay2DAsync()
		{
			return default(UniTask<Collider2D>);
		}

		UniTask IAsyncOnValidateHandler.OnValidateAsync()
		{
			return default(UniTask);
		}

		UniTask IAsyncOnWillRenderObjectHandler.OnWillRenderObjectAsync()
		{
			return default(UniTask);
		}

		UniTask IAsyncResetHandler.ResetAsync()
		{
			return default(UniTask);
		}

		UniTask IAsyncUpdateHandler.UpdateAsync()
		{
			return default(UniTask);
		}

		UniTask<PointerEventData> IAsyncOnBeginDragHandler.OnBeginDragAsync()
		{
			return default(UniTask<PointerEventData>);
		}

		UniTask<BaseEventData> IAsyncOnCancelHandler.OnCancelAsync()
		{
			return default(UniTask<BaseEventData>);
		}

		UniTask<BaseEventData> IAsyncOnDeselectHandler.OnDeselectAsync()
		{
			return default(UniTask<BaseEventData>);
		}

		UniTask<PointerEventData> IAsyncOnDragHandler.OnDragAsync()
		{
			return default(UniTask<PointerEventData>);
		}

		UniTask<PointerEventData> IAsyncOnDropHandler.OnDropAsync()
		{
			return default(UniTask<PointerEventData>);
		}

		UniTask<PointerEventData> IAsyncOnEndDragHandler.OnEndDragAsync()
		{
			return default(UniTask<PointerEventData>);
		}

		UniTask<PointerEventData> IAsyncOnInitializePotentialDragHandler.OnInitializePotentialDragAsync()
		{
			return default(UniTask<PointerEventData>);
		}

		UniTask<AxisEventData> IAsyncOnMoveHandler.OnMoveAsync()
		{
			return default(UniTask<AxisEventData>);
		}

		UniTask<PointerEventData> IAsyncOnPointerClickHandler.OnPointerClickAsync()
		{
			return default(UniTask<PointerEventData>);
		}

		UniTask<PointerEventData> IAsyncOnPointerDownHandler.OnPointerDownAsync()
		{
			return default(UniTask<PointerEventData>);
		}

		UniTask<PointerEventData> IAsyncOnPointerEnterHandler.OnPointerEnterAsync()
		{
			return default(UniTask<PointerEventData>);
		}

		UniTask<PointerEventData> IAsyncOnPointerExitHandler.OnPointerExitAsync()
		{
			return default(UniTask<PointerEventData>);
		}

		UniTask<PointerEventData> IAsyncOnPointerUpHandler.OnPointerUpAsync()
		{
			return default(UniTask<PointerEventData>);
		}

		UniTask<PointerEventData> IAsyncOnScrollHandler.OnScrollAsync()
		{
			return default(UniTask<PointerEventData>);
		}

		UniTask<BaseEventData> IAsyncOnSelectHandler.OnSelectAsync()
		{
			return default(UniTask<BaseEventData>);
		}

		UniTask<BaseEventData> IAsyncOnSubmitHandler.OnSubmitAsync()
		{
			return default(UniTask<BaseEventData>);
		}

		UniTask<BaseEventData> IAsyncOnUpdateSelectedHandler.OnUpdateSelectedAsync()
		{
			return default(UniTask<BaseEventData>);
		}
	}
}
