using System;
using Restory.Gameplay.Common;
using Restory.Gameplay.Tooltips;
using UnityEngine;

namespace Restory.Gameplay.InteractiveObjects
{
	public class InteractiveObject : MonoBehaviour
	{
		[SerializeField]
		protected InteractionTrigger interactionTrigger;

		[SerializeField]
		private float rotationSpeed = 400f;

		[SerializeField]
		private TooltipIndicator tooltipIndicator;

		[SerializeField]
		private Transform tooltipTargetTransform;

		private InteractiveObjectDragState dragState;

		private InteractiveObjectPackage package;

		public virtual bool IsPlaceable => false;

		public virtual bool IsActivatable { get; set; }

		public float RotationSpeed => rotationSpeed;

		public Transform TooltipTargetTransform
		{
			get
			{
				if ((bool)tooltipTargetTransform)
				{
					return tooltipTargetTransform;
				}
				return base.transform;
			}
		}

		public InteractiveObjectPackage Package => package;

		public InteractiveObjectStoreDimensions StoreDimensions
		{
			get
			{
				if (!package)
				{
					return GetStoreDimensions();
				}
				return package.GetStoreDimensions();
			}
		}

		public string UniqueId { get; private set; }

		public InteractiveObjectState State { get; private set; }

		public bool HasChanged { get; set; }

		public bool IsInteractable { get; set; }

		public InteractiveObjectDragState DragState
		{
			get
			{
				return dragState;
			}
			set
			{
				if (dragState != value)
				{
					dragState = value;
					this.OnDragStateChanged?.Invoke(dragState);
				}
			}
		}

		public InteractiveObjectAdditionalProperties AdditionalProperties { get; private set; } = new InteractiveObjectAdditionalProperties();

		public event Action OnInitialized;

		public event Action OnSelected;

		public event Action OnDeselected;

		public event Action OnActivated;

		public event Action OnDragStarted;

		public event Action OnDragComplete;

		public event Action OnDragCanceled;

		public event Action OnRemove;

		public event Action<InteractiveObjectDragState> OnDragStateChanged;

		private void Start()
		{
			IsInteractable = true;
		}

		public void Init(InteractiveObjectState state, string uniqueId, bool hasChanged, params InteractiveObjectAdditionalProperty[] additionalProperties)
		{
			SetState(state);
			SetUniqueID(uniqueId);
			HasChanged = hasChanged;
			SetUpAdditionalProperties(additionalProperties);
			this.OnInitialized?.Invoke();
		}

		public void Init(InteractiveObjectState state, string uniqueId, bool hasChanged, InteractiveObjectAdditionalProperties additionalProperties)
		{
			SetState(state);
			SetUniqueID(uniqueId);
			HasChanged = hasChanged;
			if (additionalProperties != null)
			{
				SetUpAdditionalProperties(additionalProperties);
			}
			this.OnInitialized?.Invoke();
		}

		protected void SetUniqueID(string uniqueId)
		{
			UniqueId = uniqueId;
		}

		protected void SetUpAdditionalProperties(InteractiveObjectAdditionalProperty[] additionalProperties)
		{
			AdditionalProperties = new InteractiveObjectAdditionalProperties(additionalProperties);
		}

		protected void SetUpAdditionalProperties(InteractiveObjectAdditionalProperties additionalProperties)
		{
			AdditionalProperties = additionalProperties.Clone() as InteractiveObjectAdditionalProperties;
		}

		public virtual void Select()
		{
			this.OnSelected?.Invoke();
		}

		public virtual void Deselect()
		{
			this.OnDeselected?.Invoke();
		}

		public virtual void Activate()
		{
			if (!IsActivatable)
			{
				Debug.LogError("Failed to activate non activatable object " + base.gameObject.name);
			}
			else
			{
				this.OnActivated?.Invoke();
			}
		}

		public virtual void SetState(InteractiveObjectState state)
		{
			State = state;
		}

		public virtual void StartDrag()
		{
			DragState = InteractiveObjectDragState.FreeSoared;
			this.OnDragStarted?.Invoke();
		}

		public virtual void CompleteDrag()
		{
			DragState = InteractiveObjectDragState.None;
			this.OnDragComplete?.Invoke();
		}

		public virtual void CancelDrag()
		{
			DragState = InteractiveObjectDragState.None;
			this.OnDragCanceled?.Invoke();
		}

		public virtual void SetPackage(InteractiveObjectPackage package)
		{
			this.package = package;
			this.package.transform.SetParent(base.transform);
			this.package.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
			interactionTrigger.gameObject.SetActive(value: false);
		}

		public virtual InteractiveObjectPackage RemovePackage()
		{
			InteractiveObjectPackage result = package;
			package = null;
			interactionTrigger.gameObject.SetActive(value: true);
			return result;
		}

		public bool HasCollision()
		{
			if (!package)
			{
				return interactionTrigger.HasCollision();
			}
			return package.HasCollision();
		}

		public void ToggleIndicator(bool isActive)
		{
			if ((bool)tooltipIndicator)
			{
				tooltipIndicator.gameObject.SetActive(isActive);
			}
		}

		public void Remove()
		{
			this.OnRemove?.Invoke();
		}

		protected virtual InteractiveObjectStoreDimensions GetStoreDimensions()
		{
			return new InteractiveObjectStoreDimensions
			{
				Size = interactionTrigger.Collider.size,
				Center = interactionTrigger.Collider.center,
				Rotation = Quaternion.identity
			};
		}
	}
}
