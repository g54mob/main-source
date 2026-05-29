using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MiniGamePlayerController : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CAutoJumpRun_003Ed__26 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public MiniGamePlayerController _003C_003E4__this;

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
		public _003CAutoJumpRun_003Ed__26(int _003C_003E1__state)
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
	private sealed class _003CHorizontalValue_003Ed__34 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public MiniGamePlayerController _003C_003E4__this;

		public float value;

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
		public _003CHorizontalValue_003Ed__34(int _003C_003E1__state)
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
	private sealed class _003CWait_003Ed__15 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public MiniGamePlayerController _003C_003E4__this;

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
		public _003CWait_003Ed__15(int _003C_003E1__state)
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

	public ComputerStation computerStation;

	public static MiniGamePlayerController Instance;

	public Rigidbody2D rb;

	public Animator anim;

	public LayerMask layerMask;

	public Material PlayerMaterial;

	public float moveSpeed;

	public float jumpForce;

	public Vector2 velocity;

	public bool onGround;

	public bool CreativeMode;

	public string KeyHor;

	public float timeOfFalling;

	private Coroutine HorizontalCoroutine;

	private void Awake()
	{
	}

	private void Update()
	{
	}

	private void Start()
	{
	}

	[IteratorStateMachine(typeof(_003CWait_003Ed__15))]
	public IEnumerator Wait()
	{
		return null;
	}

	private void FixedUpdate()
	{
	}

	private void moveObject()
	{
	}

	private float jumpFors()
	{
		return 0f;
	}

	public void Zoom(float relativeChange)
	{
	}

	public bool FootRaycast()
	{
		return false;
	}

	public bool HeadRaycast()
	{
		return false;
	}

	public bool Head2blockRaycast()
	{
		return false;
	}

	public bool HeadUpRaycast()
	{
		return false;
	}

	public bool AutoJump()
	{
		return false;
	}

	[IteratorStateMachine(typeof(_003CAutoJumpRun_003Ed__26))]
	private IEnumerator AutoJumpRun()
	{
		return null;
	}

	private void OnTriggerStay2D(Collider2D col)
	{
	}

	public void OnTriggerExit2D(Collider2D col)
	{
	}

	public void HorizontalDown(int value)
	{
	}

	public void HorizontalUp()
	{
	}

	public void VerticalDown(int value)
	{
	}

	public void VerticalUp()
	{
	}

	[IteratorStateMachine(typeof(_003CHorizontalValue_003Ed__34))]
	private IEnumerator HorizontalValue(float value)
	{
		return null;
	}

	private bool IsNominalApprox(float nominal, float value)
	{
		return false;
	}

	public void LoadMainMenu()
	{
	}
}
