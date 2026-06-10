using System;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using NSEipix;
using NSEipix.Base;
using NSMedieval.State;
using UnityEngine;

namespace NSMedieval.FloatingOverlaySystem
{
	public class FloatingElementHolder : MonoBehaviour, IGameDisposable, IDisposable
	{
		private List<FloatingElementBase> elements;

		private FloatingElementHolderType type;

		private Transform followingToTransform;

		private bool holdPosition;

		private Camera mainCamera;

		private bool isSetup;

		public FloatingElementHolderType Type => type;

		public bool HasDisposed { get; private set; }

		public int ElementsCount => elements.Count;

		public Transform FollowingToTransform => followingToTransform;

		public bool HoldPosition
		{
			get
			{
				return holdPosition;
			}
			set
			{
				holdPosition = value;
			}
		}

		public event Action<IGameDisposable> OnDisposedEvent;

		public event Action<FloatingElementBase> OnNewElementAddedEvent;

		public event Action<FloatingElementBase> OnElementIndexChangedEvent;

		public event Action<FloatingElementBase> OnNewElementRemovedEvent;

		public void AddElement(FloatingElementBase element, int index = -1)
		{
			element.SetHolder(this);
			Transform transform = element.transform;
			Vector3 localPosition = transform.localPosition;
			if (element.LocalPosOverride != Vector3.zero)
			{
				localPosition = element.LocalPosOverride;
			}
			if (index < 0 || index >= elements.Count)
			{
				elements.Add(element);
				transform.localPosition = localPosition;
				SetElementActiveDelayed(element);
			}
			else
			{
				elements.Insert(index, element);
				transform.localPosition = localPosition;
				transform.SetSiblingIndex(index);
				SetElementActiveDelayed(element);
			}
		}

		private void SetElementActiveDelayed(FloatingElementBase element)
		{
			MonoSingleton<TaskController>.Instance.WaitForNextFrameUnscaled().Then(delegate
			{
				if (element != null)
				{
					element.gameObject.SetActive(value: true);
					this.OnNewElementAddedEvent?.Invoke(element);
				}
			});
		}

		public void RemoveElement(FloatingElementBase element)
		{
			if (!HasDisposed && elements.Contains(element))
			{
				elements.Remove(element);
				this.OnNewElementRemovedEvent?.Invoke(element);
				UnityEngine.Object.Destroy(element.gameObject);
			}
		}

		public void ChangeElementIndex(FloatingElementBase element, int newIndex)
		{
			int num = elements.IndexOf(element);
			if (num >= 0 && num != newIndex && newIndex >= 0)
			{
				elements.Remove(element);
				if (newIndex >= elements.Count)
				{
					elements.Add(element);
					element.transform.SetSiblingIndex(elements.Count - 1);
					this.OnElementIndexChangedEvent?.Invoke(element);
				}
				else
				{
					elements.Insert(newIndex, element);
					element.transform.SetSiblingIndex(newIndex);
					this.OnElementIndexChangedEvent?.Invoke(element);
				}
			}
		}

		public void Dispose()
		{
			if (HasDisposed)
			{
				return;
			}
			this.OnDisposedEvent?.Invoke(this);
			this.OnDisposedEvent = null;
			HasDisposed = true;
			for (int num = elements.Count; num >= 0; num--)
			{
				if (num < elements.Count)
				{
					FloatingElementBase element = elements[num];
					RemoveElement(element);
				}
			}
			followingToTransform = null;
			mainCamera = null;
			elements.Clear();
			elements = null;
			this.OnNewElementAddedEvent = null;
			this.OnElementIndexChangedEvent = null;
			this.OnNewElementRemovedEvent = null;
		}

		public void RefreshPosition()
		{
			if (mainCamera == null)
			{
				mainCamera = MonoSingleton<CameraManager>.Instance.GameplayCamera;
			}
			else
			{
				base.transform.position = mainCamera.WorldToScreenPoint(followingToTransform.position);
			}
		}

		internal void Setup(FloatingElementHolderType type, Transform transform)
		{
			if (!isSetup)
			{
				isSetup = true;
				HasDisposed = false;
				this.type = type;
				followingToTransform = transform;
				if (elements == null)
				{
					elements = new List<FloatingElementBase>();
				}
				else
				{
					elements.Clear();
				}
				RefreshPosition();
			}
		}

		private void Update()
		{
			if (!HasDisposed && !holdPosition)
			{
				if (followingToTransform == null)
				{
					Log.Debug("Destroying FloatingElementHolder, followingToTransform not found.", "C:\\GIT\\dev\\Assets\\Scripts\\FloatingOverlaySystem\\Core\\FloatingElementHolder.cs");
					UnityEngine.Object.Destroy(base.gameObject);
				}
				else
				{
					RefreshPosition();
				}
			}
		}

		private void OnDestroy()
		{
			if (!MonoSingleton<FloatingOverlayManager>.IsApplicationIsQuitting())
			{
				Dispose();
			}
		}
	}
}
