using Mandragora.Utils;
using Restory.Data.Elements;
using Restory.Data.Equipment;
using Restory.SimpleTweeners;
using UnityEngine;
using UnityEngine.Events;

namespace Restory.Gameplay.Elements
{
	public abstract class ElementBase : MonoBehaviour
	{
		[SerializeField]
		private ElementInfo elementInfo;

		[SerializeField]
		private ElementConditionHandler conditionHandler;

		[SerializeField]
		protected PlacementPositionHandler placementPositionHandler;

		[SerializeField]
		protected ElementBehaviorSwitcher behaviorSwitcher;

		[Header("Tweening settings")]
		[SerializeField]
		protected ElementPositionTweener tweener;

		[Header("Zoom settings")]
		[SerializeField]
		private bool useCustomMaxZoom;

		[SerializeField]
		[Range(0.5f, 0.9f)]
		[Tooltip("If value is less than Max Zoom in parent Device Container, it be ignored.")]
		private float customMaxZoom = 0.75f;

		[Space]
		[SerializeField]
		[BoolButton(20, 0)]
		private bool detectableWhenBlocked = true;

		protected bool isInitialized;

		private bool isBlocked;

		private bool isSelected;

		private bool isHighlighted;

		private bool isDragging;

		private bool isOverCompatibleEquipment;

		private bool isOnSurface;

		public UnityEvent OnActivated { get; } = new UnityEvent();

		public UnityEvent OnDeactivated { get; } = new UnityEvent();

		public UnityEvent OnSelectionStateChanged { get; } = new UnityEvent();

		public UnityEvent OnHighlightedStateChanged { get; } = new UnityEvent();

		public UnityEvent OnBlockedStateChanged { get; } = new UnityEvent();

		public UnityEvent OnDetached { get; } = new UnityEvent();

		public UnityEvent OnInteractionComplete { get; } = new UnityEvent();

		public UnityEvent OnInteractionCanceled { get; } = new UnityEvent();

		public UnityEvent OnDragging { get; } = new UnityEvent();

		public UnityEvent OnInstalled { get; } = new UnityEvent();

		public UnityEvent OnOverCompatibleEquipmentStateChanged { get; } = new UnityEvent();

		public ElementInfo Info => elementInfo;

		public ElementConditionHandler ConditionHandler => conditionHandler;

		public PlacementPositionHandler PlacementPositionHandler => placementPositionHandler;

		public ElementBehaviorSwitcher BehaviorSwitcher => behaviorSwitcher;

		public Quaternion PlacementRotation => placementPositionHandler.PlacementPositionData.PlacementRotation;

		public float MaxZoom
		{
			get
			{
				if (!useCustomMaxZoom)
				{
					return 0f;
				}
				return customMaxZoom;
			}
		}

		protected virtual Vector3 AttachmentPosition => Vector3.zero;

		public ElementProjectionData ProjectionData { get; protected set; }

		public virtual bool InSocket { get; set; }

		public float Progress { get; protected set; }

		public bool IsInstalling { get; protected set; }

		public bool IsSelected
		{
			get
			{
				return isSelected;
			}
			set
			{
				if (isSelected != value)
				{
					isSelected = value;
					OnSelectionStateChanged.Invoke();
				}
			}
		}

		public bool IsHighlighted
		{
			get
			{
				return isHighlighted;
			}
			set
			{
				if (isHighlighted != value)
				{
					isHighlighted = value;
					OnHighlightedStateChanged.Invoke();
				}
			}
		}

		public bool IsBlocked
		{
			get
			{
				return isBlocked;
			}
			set
			{
				if (isBlocked != value)
				{
					isBlocked = value;
					OnBlockedStateChanged.Invoke();
					if (!detectableWhenBlocked)
					{
						behaviorSwitcher.SwitchDetectionCollider(!isBlocked);
					}
				}
			}
		}

		public bool IsDragging
		{
			get
			{
				return isDragging;
			}
			set
			{
				isDragging = value;
				if (isDragging)
				{
					behaviorSwitcher.SwitchToDraggingBehavior();
					OnDragging?.Invoke();
				}
			}
		}

		public bool IsOverCompatibleEquipment
		{
			get
			{
				return isOverCompatibleEquipment;
			}
			set
			{
				if (value != isOverCompatibleEquipment)
				{
					isOverCompatibleEquipment = value;
					OnOverCompatibleEquipmentStateChanged?.Invoke();
				}
			}
		}

		public bool IsOnSurface
		{
			get
			{
				return isOnSurface;
			}
			set
			{
				if (value != isOnSurface)
				{
					isOnSurface = value;
				}
			}
		}

		protected virtual void Awake()
		{
			conditionHandler.ElementData.Info = elementInfo;
		}

		public virtual void Init()
		{
			if (!isInitialized)
			{
				ProjectionData = new ElementProjectionData(base.transform, AttachmentPosition, behaviorSwitcher.CastCollider);
				placementPositionHandler.Init(behaviorSwitcher.CastCollider);
				isInitialized = true;
				IsSelected = false;
				Progress = 0f;
			}
		}

		public void Activate()
		{
			OnActivated.Invoke();
		}

		public void Deactivate()
		{
			OnDeactivated.Invoke();
		}

		public void SkipProgress()
		{
			Progress = 1f;
		}

		public virtual bool CanInteraction(ToolInfo toolInfo)
		{
			return true;
		}

		public virtual void InitInteraction(ToolInfo toolInfo)
		{
			tweener.TweenEvents.OnComplete.AddListener(CompleteInteraction);
		}

		public virtual void CancelInteraction()
		{
			tweener.TweenEvents.OnComplete.RemoveListener(CompleteInteraction);
		}

		public virtual void AttachToDevice()
		{
			IsSelected = false;
			IsDragging = false;
			tweener.TweenEvents.OnComplete.AddListener(CompleteSnap);
			tweener.PlaySnap(AttachmentPosition);
		}

		public void ResetInstalledBehavior()
		{
			behaviorSwitcher.SwitchToInstalledBehavior();
			if (isBlocked && !detectableWhenBlocked)
			{
				behaviorSwitcher.SwitchDetectionCollider(shouldColliderBeActive: false);
			}
		}

		public virtual void Reset()
		{
			IsInstalling = false;
			IsSelected = false;
		}

		protected virtual void CompleteInteraction()
		{
			tweener.TweenEvents.OnComplete.RemoveListener(CompleteInteraction);
			tweener.Stop();
			if (!IsInstalling)
			{
				OnDetached.Invoke();
			}
			else
			{
				IsInstalling = false;
				OnInstalled.Invoke();
			}
			OnInteractionComplete.Invoke();
			IsSelected = false;
		}

		private void CompleteSnap()
		{
			tweener.TweenEvents.OnComplete.RemoveListener(CompleteSnap);
			tweener.Stop();
			base.transform.localPosition = Vector3.zero;
			Progress = 0f;
			OnInstalled.Invoke();
		}
	}
}
