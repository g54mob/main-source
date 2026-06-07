using MalbersAnimations.Events;
using MalbersAnimations.Reactions;
using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations.Controller
{
	[AddComponentMenu("Malbers/Interaction/Pickable")]
	[SelectionBase]
	[HelpURL("https://malbersanimations.gitbook.io/animal-controller/secondary-components/pickable")]
	public class Pickable : MonoBehaviour, ICollectable, IObjectCore
	{
		public bool Align;

		[Min(0f)]
		public float AlignTime = 0.15f;

		[Tooltip("Delay time after calling the Pick() method. the item will be parented to the PickUp component after this time has passed")]
		public FloatReference PickDelay = new FloatReference(0f);

		[Tooltip("Delay time after calling the Drop() method. the item will be unparented from the PickUp component after this time has passed")]
		public FloatReference DropDelay = new FloatReference(0f);

		[Tooltip("Cooldown needed to pick or drop again the collectable")]
		public FloatReference coolDown = new FloatReference(0f);

		[Tooltip("When an Object is Collectable it means that the Picker can still pick objects, the item was collected by another component (E.g. Weapons or Inventory)")]
		public BoolReference m_Collectable = new BoolReference(value: false);

		[Tooltip("The Pick Up Drop Logic will be called via animator events/messages. Use These methods on the Animator: TryPick(), TryDrop(), TryPickUpDrop()")]
		public BoolReference m_ByAnimation = new BoolReference(value: false);

		[Tooltip("The Pick Up Drop Logic will be called via animator events/messages")]
		public BoolReference m_DestroyOnPick = new BoolReference(value: false);

		[Tooltip(" Amount Pickable Item can store.. that it can be use for anything")]
		public IntReference m_Amount = new IntReference(1);

		[Tooltip("The pickable can be picked. Set it to false to temporalry disabled the Pick method at runtime")]
		public BoolReference canBePicked = new BoolReference(value: true);

		[Tooltip("The pickable will be pick automatically when it enters the focus area from the picker")]
		public BoolReference m_AutoPick = new BoolReference(value: false);

		public IntReference m_ID = new IntReference();

		[Tooltip("What holder will the item be parent to. -1: Default Holder. >=0 : Index of the Extra Holder list")]
		public int holder = -1;

		public BoolEvent OnFocused = new BoolEvent();

		public GameObjectEvent OnFocusedBy = new GameObjectEvent();

		public GameObjectEvent OnUnfocusedBy = new GameObjectEvent();

		public GameObjectEvent OnPicked = new GameObjectEvent();

		public GameObjectEvent OnPickedFailed = new GameObjectEvent();

		public GameObjectEvent OnPrePicked = new GameObjectEvent();

		public GameObjectEvent OnDropped = new GameObjectEvent();

		public GameObjectEvent OnPreDropped = new GameObjectEvent();

		[SerializeReference]
		[SubclassSelector]
		public Reaction FocusedByReaction;

		[SerializeReference]
		[SubclassSelector]
		public Reaction UnFocusedByReaction;

		[SerializeReference]
		[SubclassSelector]
		public Reaction PickedReaction;

		[SerializeReference]
		[SubclassSelector]
		public Reaction PrePickedReaction;

		[SerializeReference]
		[SubclassSelector]
		public Reaction DroppedReaction;

		[SerializeReference]
		[SubclassSelector]
		public Reaction PreDroppedReaction;

		[SerializeField]
		private Rigidbody rb;

		[Tooltip("Destroys Rigidbody while picked. This will remove completely the rigidbody from the Pickable object and it will restore it after is dropped.")]
		public BoolReference DestroyRbOnPick = new BoolReference(value: false);

		[RequiredField]
		public Collider[] m_colliders;

		[Tooltip("If the item is picked it will be kinematic")]
		public BoolReference kinematicOnPick = new BoolReference(value: true);

		[Tooltip("Disable Colliders when the Item is picked (Colliders will be enabled back when the item is dropped")]
		public BoolReference disableColliders = new BoolReference(value: true);

		protected RigidbodyParameters rigidbodyParameters;

		protected bool defaultKinematic;

		protected RigidbodyConstraints defaultConstraints;

		protected float currentPickTime;

		protected Vector3 DefaultScale;

		private bool focused;

		[HideInInspector]
		public int EditorTabs;

		public MPickUp Picker { get; set; }

		public bool IsPicked { get; set; }

		public int Amount
		{
			get
			{
				return m_Amount.Value;
			}
			set
			{
				m_Amount.Value = value;
			}
		}

		public bool AutoPick
		{
			get
			{
				return m_AutoPick.Value;
			}
			set
			{
				m_AutoPick.Value = value;
			}
		}

		public bool CanBePicked
		{
			get
			{
				return canBePicked.Value;
			}
			set
			{
				canBePicked.Value = value;
			}
		}

		public bool Collectable
		{
			get
			{
				return m_Collectable.Value;
			}
			set
			{
				m_Collectable.Value = value;
			}
		}

		public Rigidbody RigidBody => rb;

		public bool ByAnimation
		{
			get
			{
				return m_ByAnimation.Value;
			}
			set
			{
				m_ByAnimation.Value = value;
			}
		}

		public bool DestroyOnPick
		{
			get
			{
				return m_DestroyOnPick.Value;
			}
			set
			{
				m_DestroyOnPick.Value = value;
			}
		}

		public bool InCoolDown => !MTools.ElapsedTime(CurrentPickTime, coolDown);

		public int ID
		{
			get
			{
				return m_ID.Value;
			}
			set
			{
				m_ID.Value = value;
			}
		}

		public virtual bool Focused
		{
			get
			{
				return focused;
			}
			private set
			{
				focused = value;
				OnFocused.Invoke(focused);
			}
		}

		public float CurrentPickTime
		{
			get
			{
				return currentPickTime;
			}
			set
			{
				currentPickTime = value;
			}
		}

		Transform IObjectCore.transform => base.transform;

		public virtual void SetFocused(GameObject FocusBy, bool isFocused)
		{
			Focused = isFocused;
			if (isFocused)
			{
				OnFocusedBy.Invoke(FocusBy);
				FocusedByReaction?.React(FocusBy);
				return;
			}
			OnFocusedBy.Invoke(null);
			FocusedByReaction?.React((Component)null);
			OnUnfocusedBy.Invoke(FocusBy);
			UnFocusedByReaction?.React(FocusBy);
		}

		protected void OnDisable()
		{
			Focused = false;
		}

		protected void Awake()
		{
			rb = GetComponent<Rigidbody>();
			if (m_colliders == null || m_colliders.Length == 0)
			{
				m_colliders = GetComponents<Collider>();
			}
			CurrentPickTime = 0f - (float)coolDown;
			DefaultScale = base.transform.localScale;
			if ((bool)rb)
			{
				defaultKinematic = rb.isKinematic;
				defaultConstraints = rb.constraints;
				rigidbodyParameters = new RigidbodyParameters(rb);
			}
		}

		public virtual void Pick()
		{
			OnPickDisablePhysics();
			IsPicked = !Collectable;
			GameObject gameObject = (Picker ? Picker.Root.gameObject : null);
			SetFocused(gameObject, isFocused: false);
			OnPicked.Invoke(gameObject);
			PickedReaction?.React(gameObject);
			CurrentPickTime = Time.time;
			if (Collectable)
			{
				base.enabled = false;
			}
			if (DestroyOnPick)
			{
				DestroyPickUp();
			}
		}

		protected virtual void DestroyPickUp()
		{
			Object.Destroy(base.gameObject);
		}

		public virtual void Drop()
		{
			OnDropEnablePhysics();
			IsPicked = false;
			base.enabled = true;
			base.transform.parent = null;
			base.transform.localScale = DefaultScale;
			GameObject gameObject = (Picker ? Picker.Root.gameObject : null);
			OnDropped.Invoke(gameObject);
			DroppedReaction?.React(gameObject);
			Picker = null;
			CurrentPickTime = Time.time;
		}

		public virtual void ForceDrop()
		{
			Picker?.DropItem();
		}

		public virtual void OnPickDisablePhysics()
		{
			if ((bool)DestroyRbOnPick)
			{
				Object.Destroy(rb);
				rb = null;
			}
			if ((bool)RigidBody)
			{
				RigidBody.useGravity = false;
				RigidBody.isKinematic = kinematicOnPick.Value;
				if (RigidBody.isKinematic)
				{
					RigidBody.collisionDetectionMode = CollisionDetectionMode.Discrete;
				}
				RigidBody.constraints = RigidbodyConstraints.FreezeAll;
			}
			if (!disableColliders.Value)
			{
				return;
			}
			Collider[] colliders = m_colliders;
			foreach (Collider collider in colliders)
			{
				if ((bool)collider)
				{
					collider.enabled = false;
				}
			}
		}

		public virtual void OnDropEnablePhysics()
		{
			if ((bool)RigidBody)
			{
				RigidBody.useGravity = true;
				RigidBody.isKinematic = defaultKinematic;
				if (!RigidBody.isKinematic)
				{
					RigidBody.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
				}
				RigidBody.constraints = defaultConstraints;
			}
			if ((bool)DestroyRbOnPick)
			{
				rb = base.gameObject.AddComponent<Rigidbody>();
				rigidbodyParameters.RestoreRigidBody(rb);
			}
			Collider[] colliders = m_colliders;
			for (int i = 0; i < colliders.Length; i++)
			{
				colliders[i].enabled = true;
			}
		}

		public void SetEnable(bool enable)
		{
			base.enabled = enable;
		}
	}
}
