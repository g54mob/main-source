using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace CraftingAnims
{
	public class CrafterController : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003C_ChangeCharacterState_003Ed__68 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public float waitTime;

			public CrafterController _003C_003E4__this;

			public CrafterState state;

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
			public _003C_ChangeCharacterState_003Ed__68(int _003C_003E1__state)
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
		private sealed class _003C_LockMovement_003Ed__66 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public CrafterController _003C_003E4__this;

			public float locktime;

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
			public _003C_LockMovement_003Ed__66(int _003C_003E1__state)
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
		private sealed class _003C_RightArmBlend_003Ed__75 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public bool use;

			public CrafterController _003C_003E4__this;

			private float _003Ccounter_003E5__2;

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
			public _003C_RightArmBlend_003Ed__75(int _003C_003E1__state)
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
		private sealed class _003C_RightArmBlendOff_003Ed__73 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public CrafterController _003C_003E4__this;

			public float time;

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
			public _003C_RightArmBlendOff_003Ed__73(int _003C_003E1__state)
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
		private sealed class _003C_RightHandBlend_003Ed__71 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public bool use;

			public CrafterController _003C_003E4__this;

			private float _003Ccounter_003E5__2;

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
			public _003C_RightHandBlend_003Ed__71(int _003C_003E1__state)
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
		private sealed class _003C_RightHandBlendOff_003Ed__72 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public float time;

			public CrafterController _003C_003E4__this;

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
			public _003C_RightHandBlendOff_003Ed__72(int _003C_003E1__state)
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

		[HideInInspector]
		public Animator animator;

		[HideInInspector]
		public CrafterShowItem showItem;

		[HideInInspector]
		public CrafterIKHands crafterIKhands;

		[HideInInspector]
		public GUIControls guiControls;

		[HideInInspector]
		public Rigidbody rb;

		public CrafterState charState;

		public float animationSpeed;

		public GameObject hatchet;

		public GameObject hammer;

		public GameObject fishingpole;

		public GameObject shovel;

		public GameObject box;

		public GameObject food;

		public GameObject drink;

		public GameObject saw;

		public GameObject pickaxe;

		public GameObject sickle;

		public GameObject rake;

		public GameObject chair;

		public GameObject ladder;

		public GameObject lumber;

		public GameObject pushpull;

		public GameObject sphere;

		public GameObject cart;

		public GameObject paintbrush;

		public GameObject spear;

		[HideInInspector]
		public bool isMoving;

		[HideInInspector]
		public bool isLocked;

		[HideInInspector]
		public bool isGrounded;

		[HideInInspector]
		public bool isSpearfishing;

		private Coroutine coroutineLock;

		private Vector3 newVelocity;

		private bool isFacing;

		private bool isRunning;

		private float pushpullTime;

		private bool carryItem;

		private bool allowedInput;

		private Vector3 inputVec;

		private float inputHorizontal;

		private float inputVertical;

		private float inputHorizontal2;

		private float inputVertical2;

		private bool inputFacing;

		private bool inputRun;

		[Header("Movement")]
		public float rotationSpeed;

		public float runSpeed;

		public float walkSpeed;

		public float spearfishingSpeed;

		public float crawlSpeed;

		[Header("Navigation")]
		public bool useNavMeshNavigation;

		[HideInInspector]
		public CrafterNavigation crafterNavigation;

		[HideInInspector]
		public bool navMeshNavigation;

		[HideInInspector]
		public bool navMeshRun;

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void Inputs()
		{
		}

		private void Update()
		{
		}

		private void FixedUpdate()
		{
		}

		private void LateUpdate()
		{
		}

		private float UpdateMovement()
		{
			return 0f;
		}

		private void CheckForGrounded()
		{
		}

		private void CameraRelativeInput()
		{
		}

		private void PushPull()
		{
		}

		private void RotateTowardsMovementDir()
		{
		}

		private void Facing()
		{
		}

		public void LockMovement(float locktime)
		{
		}

		[IteratorStateMachine(typeof(_003C_LockMovement_003Ed__66))]
		private IEnumerator _LockMovement(float locktime)
		{
			return null;
		}

		public void ChangeCharacterState(float waitTime, CrafterState state)
		{
		}

		[IteratorStateMachine(typeof(_003C_ChangeCharacterState_003Ed__68))]
		private IEnumerator _ChangeCharacterState(float waitTime, CrafterState state)
		{
			return null;
		}

		public void TriggerAnimation(string trigger)
		{
		}

		public void RightHandBlend(bool use)
		{
		}

		[IteratorStateMachine(typeof(_003C_RightHandBlend_003Ed__71))]
		private IEnumerator _RightHandBlend(bool use)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003C_RightHandBlendOff_003Ed__72))]
		private IEnumerator _RightHandBlendOff(float time)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003C_RightArmBlendOff_003Ed__73))]
		private IEnumerator _RightArmBlendOff(float time)
		{
			return null;
		}

		public void RightArmBlend(bool use)
		{
		}

		[IteratorStateMachine(typeof(_003C_RightArmBlend_003Ed__75))]
		private IEnumerator _RightArmBlend(bool use)
		{
			return null;
		}

		public void CarryItem(bool carry)
		{
		}

		public void BlendOff(float time)
		{
		}

		public void IKBlendOn()
		{
		}

		public void IKBlendOff()
		{
		}
	}
}
