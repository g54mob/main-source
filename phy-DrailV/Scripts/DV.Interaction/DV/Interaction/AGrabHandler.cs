using System;
using System.Collections.Generic;
using UnityEngine;

namespace DV.Interaction
{
	public abstract class AGrabHandler : MonoBehaviour
	{
		public delegate bool InteractionPassThroughDelegate(Vector3 hitPoint);

		protected Grabber grabbedBy;

		public bool isUsable;

		public bool continuousUse;

		public bool interactionAllowed = true;

		public bool mustHoldButton;

		public HashSet<Collider> interactionColliders = new HashSet<Collider>();

		private InteractionPassThroughDelegate interactionPassThrough;

		public AGrabHandler ParentGrabHandler { get; private set; }

		public abstract bool IsItem { get; }

		public bool IsDraggable => !IsItem;

		public bool IsUsed { get; protected set; }

		public event Action Grabbed;

		public event Action UnGrabbed;

		public event Action Hovered;

		public event Action UnHovered;

		public event Action EndInteractionForced;

		public abstract Vector3 GetAxis();

		public abstract Vector3 GetAnchor();

		protected virtual void Start()
		{
			if (!IsItem)
			{
				ParentGrabHandler = base.transform.parent?.GetComponentInParentIncludingInactive<AGrabHandler>();
			}
		}

		public virtual void StartInteraction(Vector3 startWorldPosition, Grabber grabbedBy)
		{
			this.grabbedBy = grabbedBy;
			try
			{
				this.Grabbed?.Invoke();
			}
			catch (Exception message)
			{
				Debug.LogError("Caught the following error while doing StartInteraction", this);
				Debug.LogError(message);
			}
		}

		public abstract void FeedPosition(Vector3 worldPosition);

		public virtual void FeedValue(float value)
		{
		}

		public virtual bool AllowFeedValue()
		{
			return false;
		}

		public virtual void EndInteraction()
		{
			if (!IsGrabbed())
			{
				return;
			}
			grabbedBy = null;
			try
			{
				this.UnGrabbed?.Invoke();
			}
			catch (Exception message)
			{
				Debug.LogError("Caught the following error while doing EndInteraction", this);
				Debug.LogError(message);
			}
		}

		public void ForceEndInteraction()
		{
			if (IsGrabbed())
			{
				EndInteraction();
				try
				{
					this.EndInteractionForced?.Invoke();
				}
				catch (Exception message)
				{
					Debug.LogError("Caught the following error while doing EndInteractionForced", this);
					Debug.LogError(message);
				}
			}
		}

		public virtual bool AllowPickupAndThrow()
		{
			return false;
		}

		public virtual void Throw(Vector3 direction)
		{
		}

		public virtual void Use()
		{
		}

		public virtual void UnUse()
		{
		}

		public bool IsGrabbed()
		{
			return grabbedBy != null;
		}

		public Grabber GetGrabber()
		{
			return grabbedBy;
		}

		protected virtual void OnDestroy()
		{
			if (!UnloadWatcher.isUnloading)
			{
				ForceEndInteraction();
			}
		}

		private void SetInteractionColliders(GameObject[] colliderGameObjects)
		{
			foreach (GameObject gameObject in colliderGameObjects)
			{
				if (!(gameObject == null))
				{
					Collider[] components = gameObject.GetComponents<Collider>();
					foreach (Collider item in components)
					{
						interactionColliders.Add(item);
					}
				}
			}
			if (interactionColliders.Count == 0)
			{
				Debug.LogError("SetInteractionColliders found no colliders in colliderGameObjects. This should not happen. Interaction will probably be possible.", this);
			}
		}

		public static T AddGrabHandler<T>(GameObject go, GameObject[] colliderGameObjects) where T : AGrabHandler
		{
			if (go == null)
			{
				Debug.LogError("AddGrabHandler can't add T component to null GameObject. Aborting...");
				return null;
			}
			T val = go.AddComponent<T>();
			val.SetInteractionColliders(colliderGameObjects);
			return val;
		}

		public bool InteractionPassThrough(Vector3 hitPoint)
		{
			if (interactionPassThrough != null)
			{
				return interactionPassThrough(hitPoint);
			}
			return false;
		}

		public void AssignInteractionPassThrough(InteractionPassThroughDelegate passThrough)
		{
			interactionPassThrough = passThrough;
		}

		public void OnHovered()
		{
			this.Hovered?.Invoke();
		}

		public void OnUnhovered()
		{
			this.UnHovered?.Invoke();
		}
	}
}
