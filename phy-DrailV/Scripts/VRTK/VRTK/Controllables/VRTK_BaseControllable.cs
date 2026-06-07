using System.Collections;
using UnityEngine;

namespace VRTK.Controllables
{
	public abstract class VRTK_BaseControllable : MonoBehaviour
	{
		public enum OperatingAxis
		{
			xAxis = 0,
			yAxis = 1,
			zAxis = 2
		}

		[Header("Controllable Settings")]
		[Tooltip("The local axis in which the Controllable will operate through.")]
		public OperatingAxis operateAxis = OperatingAxis.yAxis;

		[Tooltip("A collection of GameObjects to ignore collision events with.")]
		public GameObject[] ignoreCollisionsWith = new GameObject[0];

		[Tooltip("A collection of GameObjects to exclude when determining if a default collider should be created.")]
		public GameObject[] excludeColliderCheckOn = new GameObject[0];

		[Tooltip("The amount of fidelity when comparing the position of the control with the previous position. Determines if it's equal above a certain decimal place threshold.")]
		public float equalityFidelity = 0.001f;

		protected Vector3 originalLocalPosition;

		protected Quaternion originalLocalRotation;

		protected Vector3 actualTransformPosition;

		protected bool atMinLimit;

		protected bool atMaxLimit;

		protected Collider interactingCollider;

		protected VRTK_InteractTouch interactingTouchScript;

		protected Collider[] controlColliders = new Collider[0];

		protected bool createCustomCollider;

		protected Coroutine processAtEndOfFrame;

		protected float storedValue;

		public event ControllableEventHandler ValueChanged;

		public event ControllableEventHandler RestingPointReached;

		public event ControllableEventHandler MinLimitReached;

		public event ControllableEventHandler MinLimitExited;

		public event ControllableEventHandler MaxLimitReached;

		public event ControllableEventHandler MaxLimitExited;

		public virtual void OnValueChanged(ControllableEventArgs e)
		{
			if (this.ValueChanged != null)
			{
				this.ValueChanged(this, e);
			}
		}

		public virtual void OnRestingPointReached(ControllableEventArgs e)
		{
			if (this.RestingPointReached != null)
			{
				this.RestingPointReached(this, e);
			}
		}

		public virtual void OnMinLimitReached(ControllableEventArgs e)
		{
			if (this.MinLimitReached != null)
			{
				this.MinLimitReached(this, e);
			}
		}

		public virtual void OnMinLimitExited(ControllableEventArgs e)
		{
			if (this.MinLimitExited != null)
			{
				this.MinLimitExited(this, e);
			}
		}

		public virtual void OnMaxLimitReached(ControllableEventArgs e)
		{
			if (this.MaxLimitReached != null)
			{
				this.MaxLimitReached(this, e);
			}
		}

		public virtual void OnMaxLimitExited(ControllableEventArgs e)
		{
			if (this.MaxLimitExited != null)
			{
				this.MaxLimitExited(this, e);
			}
		}

		public abstract float GetValue();

		public abstract float GetNormalizedValue();

		public abstract void SetValue(float value);

		public abstract bool IsResting();

		public virtual bool AtMinLimit()
		{
			return atMinLimit;
		}

		public virtual bool AtMaxLimit()
		{
			return atMaxLimit;
		}

		public virtual Vector3 GetOriginalLocalPosition()
		{
			return originalLocalPosition;
		}

		public virtual Quaternion GetOriginalLocalRotation()
		{
			return originalLocalRotation;
		}

		public virtual Collider[] GetControlColliders()
		{
			return controlColliders;
		}

		public virtual Collider GetInteractingCollider()
		{
			return interactingCollider;
		}

		public virtual VRTK_InteractTouch GetInteractingTouch()
		{
			return interactingTouchScript;
		}

		protected abstract void EmitEvents();

		protected virtual void Awake()
		{
			originalLocalPosition = base.transform.localPosition;
			originalLocalRotation = base.transform.localRotation;
			storedValue = GetValue();
		}

		protected virtual void OnEnable()
		{
			atMinLimit = false;
			atMaxLimit = false;
			SetupCollider();
			processAtEndOfFrame = StartCoroutine(ProcessAtEndOfFrame());
		}

		protected virtual void OnDisable()
		{
			storedValue = GetValue();
			if (processAtEndOfFrame != null)
			{
				StopCoroutine(processAtEndOfFrame);
			}
			ManageCollisions(ignore: false);
			if (createCustomCollider)
			{
				for (int i = 0; i < controlColliders.Length; i++)
				{
					Object.Destroy(controlColliders[i]);
				}
			}
		}

		protected virtual void OnDrawGizmosSelected()
		{
			Gizmos.color = Color.yellow;
			actualTransformPosition = base.transform.position;
		}

		protected virtual void OnCollisionEnter(Collision collision)
		{
			OnTouched(collision.collider);
		}

		protected virtual void OnCollisionExit(Collision collision)
		{
			OnUntouched(collision.collider);
		}

		protected virtual void OnTriggerEnter(Collider collider)
		{
			OnTouched(collider);
		}

		protected virtual void OnTriggerExit(Collider collider)
		{
			OnUntouched(collider);
		}

		protected virtual void OnTouched(Collider collider)
		{
			interactingCollider = collider;
			interactingTouchScript = interactingCollider.GetComponentInParent<VRTK_InteractTouch>();
		}

		protected virtual void OnUntouched(Collider collider)
		{
			interactingCollider = null;
			interactingTouchScript = null;
		}

		protected virtual void SetupCollider()
		{
			controlColliders = VRTK_SharedMethods.ColliderExclude(GetComponentsInChildren<Collider>(), VRTK_SharedMethods.GetCollidersInGameObjects(excludeColliderCheckOn, searchChildren: true, includeInactive: true));
			createCustomCollider = false;
			if (controlColliders.Length == 0)
			{
				controlColliders = new Collider[1] { base.gameObject.AddComponent<BoxCollider>() };
				createCustomCollider = true;
				ConfigureColliders();
			}
		}

		protected virtual void ConfigureColliders()
		{
		}

		protected virtual IEnumerator ProcessAtEndOfFrame()
		{
			yield return new WaitForEndOfFrame();
			ManageCollisions(ignore: true);
			EmitEvents();
			processAtEndOfFrame = null;
		}

		protected virtual void ManageCollisions(bool ignore)
		{
			for (int i = 0; i < ignoreCollisionsWith.Length; i++)
			{
				if (ignoreCollisionsWith[i] == null)
				{
					continue;
				}
				Collider[] componentsInChildren = ignoreCollisionsWith[i].GetComponentsInChildren<Collider>();
				for (int j = 0; j < componentsInChildren.Length; j++)
				{
					for (int k = 0; k < controlColliders.Length; k++)
					{
						if (componentsInChildren[j] != null && controlColliders[k] != null)
						{
							Physics.IgnoreCollision(controlColliders[k], componentsInChildren[j], ignore);
						}
					}
				}
			}
		}

		protected virtual Vector3 AxisDirection(bool local = false)
		{
			return VRTK_SharedMethods.AxisDirection((int)operateAxis, local ? base.transform : null);
		}

		protected virtual ControllableEventArgs EventPayload()
		{
			ControllableEventArgs result = default(ControllableEventArgs);
			result.interactingCollider = interactingCollider;
			result.interactingTouchScript = interactingTouchScript;
			result.value = GetValue();
			result.normalizedValue = GetNormalizedValue();
			return result;
		}
	}
}
