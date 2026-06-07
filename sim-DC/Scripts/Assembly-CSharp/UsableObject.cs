using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using EPOOutline;
using UnityEngine;
using UnityEngine.InputSystem;

public class UsableObject : Interact
{
	[CompilerGenerated]
	private sealed class _003CCheckIfLost_003Ed__55 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public UsableObject _003C_003E4__this;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CCheckIfLost_003Ed__55(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CDisalowDrop_003Ed__51 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public UsableObject _003C_003E4__this;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CDisalowDrop_003Ed__51(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CMakeInteractableAgain_003Ed__48 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public UsableObject _003C_003E4__this;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CMakeInteractableAgain_003Ed__48(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	public InputController inputctrl;

	private Outlinable outlineEffect;

	public Rigidbody rb;

	public PlayerManager.ObjectInHand objectInHandType;

	public Vector3 offsetPivotPosition;

	public Vector3 secondPosition;

	public Vector3 thirdPosition;

	public Vector3 offsetPivotRotation;

	public Vector3 secondRotation;

	public Vector3 thirdRotation;

	public Item item;

	[SerializeField]
	private int maxInHand;

	[SerializeField]
	private int toolTipLocalisationID;

	[SerializeField]
	private int toolTipLocalisationIDDescription;

	public bool objectInHands;

	[SerializeField]
	private bool keepUpright;

	public int prefabID;

	[SerializeField]
	private AudioClip pickupItem;

	public bool isDropAllowed;

	[SerializeField]
	private bool freezeAllForcesInHands;

	public int storedPosition;

	public int storageUID;

	public int trolleySlotIndex;

	private GameObject secondActionHint;

	[SerializeField]
	private bool hasActionInHand;

	[SerializeField]
	private bool hasSecondActionInHand;

	[SerializeField]
	private float minImpactVelocity;

	[SerializeField]
	private float impactSoundCooldown;

	private float lastImpactSoundTime;

	[SerializeField]
	private float impactSoundVolume;

	private Action<InputAction.CallbackContext> actionInHandStarted;

	private Action<InputAction.CallbackContext> secondActionStarted;

	private Action<InputAction.CallbackContext> dropStarted;

	private int inHowManyFramesCanCheckDistance;

	private int currentFrame;

	private readonly float kMaxDistanceSqr;

	public bool isOnTrolley;

	public RackPosition currentRackPosition;

	public int rackPositionUID;

	public int sizeInU;

	public ShopItemSO shopItemSO;

	public string modFolderName;

	public bool isModObject;

	private WaitForSeconds wait3s;

	public override void Awake()
	{
	}

	private void FixedUpdate()
	{
	}

	public override void InteractOnClick()
	{
	}

	public virtual void DropObject()
	{
	}

	public virtual void ActionInHand()
	{
	}

	[IteratorStateMachine(typeof(_003CMakeInteractableAgain_003Ed__48))]
	private IEnumerator MakeInteractableAgain()
	{
		return null;
	}

	public void MoveBetweenPositions(Vector3 _position, Vector3 _rotation)
	{
	}

	public virtual void MoveToHand()
	{
	}

	[IteratorStateMachine(typeof(_003CDisalowDrop_003Ed__51))]
	private IEnumerator DisalowDrop()
	{
		return null;
	}

	public override void InteractOnHover(RaycastHit hit)
	{
	}

	public override void OnHoverOver()
	{
	}

	[IteratorStateMachine(typeof(_003CCheckIfLost_003Ed__55))]
	private IEnumerator CheckIfLost()
	{
		return null;
	}

	public virtual void OnDestroy()
	{
	}

	private void OnLoadDestroy()
	{
	}

	public virtual void MoveToStorage(Transform _pos, int _positionIndex, int _storageUid)
	{
	}

	private void OnCollisionEnter(Collision collision)
	{
	}
}
