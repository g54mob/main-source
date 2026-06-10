using System;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.State;
using UnityEngine;

namespace NSMedieval.FloatingOverlaySystem
{
	public abstract class FloatingElementBase : MonoBehaviour, IGameDisposable, IDisposable
	{
		[SerializeField]
		private float fadeOutCameraDistance = 100f;

		[SerializeField]
		private float fadeoutDuration = 3f;

		private Vector3 localPosOverride = Vector3.zero;

		private float currentOpacity = 1f;

		private FloatingElementHolder holder;

		private Transform cameraTransform;

		private CanvasGroup canvasGroup;

		public bool HasDisposed { get; private set; }

		public FloatingElementHolderType HolderType => Holder.Type;

		internal Vector3 LocalPosOverride
		{
			get
			{
				return localPosOverride;
			}
			set
			{
				localPosOverride = value;
			}
		}

		protected FloatingElementHolder Holder => holder;

		protected CanvasGroup CanvasGroup => canvasGroup;

		public event Action<IGameDisposable> OnDisposedEvent;

		public void SetIndex(int index)
		{
			holder.ChangeElementIndex(this, index);
		}

		public int GetIndex()
		{
			return base.transform.GetSiblingIndex();
		}

		public virtual void Dispose()
		{
			if (!HasDisposed)
			{
				HasDisposed = true;
				if (!LoadingController.IsLeavingMainScene)
				{
					this.OnDisposedEvent?.Invoke(this);
				}
				if (holder != null)
				{
					holder.RemoveElement(this);
				}
				this.OnDisposedEvent = null;
				holder = null;
				cameraTransform = null;
				canvasGroup = null;
			}
		}

		internal void SetHolder(FloatingElementHolder holder)
		{
			this.holder = holder;
		}

		protected virtual void Awake()
		{
		}

		protected virtual void Start()
		{
			cameraTransform = MonoSingleton<CameraManager>.Instance.GameplayCamera.transform;
			canvasGroup = GetComponent<CanvasGroup>();
			HandleFadeout(Vector3.Distance(holder.FollowingToTransform.position, cameraTransform.position + LocalPosOverride));
		}

		protected virtual void Update()
		{
			HandleFadeout(Vector3.Distance(holder.FollowingToTransform.position, cameraTransform.position + LocalPosOverride));
		}

		private void HandleFadeout(float distanceFromCamera)
		{
			if (fadeOutCameraDistance <= 0f || fadeoutDuration <= 0f)
			{
				return;
			}
			if (distanceFromCamera <= fadeOutCameraDistance)
			{
				if (currentOpacity < 1f)
				{
					currentOpacity = 1f;
					RefreshOpacity();
				}
				return;
			}
			float num = distanceFromCamera - fadeOutCameraDistance;
			if (num < fadeoutDuration)
			{
				currentOpacity = 1f - num / fadeoutDuration;
				RefreshOpacity();
			}
			else if (!Mathf.Approximately(currentOpacity, 0f))
			{
				currentOpacity = 0f;
				RefreshOpacity();
			}
		}

		private void RefreshOpacity()
		{
			if (!(canvasGroup == null))
			{
				canvasGroup.alpha = currentOpacity;
				_ = currentOpacity;
				_ = 0f;
			}
		}

		protected virtual void OnDestroy()
		{
			if (!MonoSingleton<FloatingOverlayManager>.IsApplicationIsQuitting())
			{
				Dispose();
			}
		}
	}
}
