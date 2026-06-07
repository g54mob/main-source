using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class playerDead : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CgameOverNoGranny_003Ed__47 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public playerDead _003C_003E4__this;

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
		public _003CgameOverNoGranny_003Ed__47(int _003C_003E1__state)
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
	private sealed class _003CstartEndScene2_003Ed__44 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public playerDead _003C_003E4__this;

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
		public _003CstartEndScene2_003Ed__44(int _003C_003E1__state)
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
	private sealed class _003CstartEndScene3_003Ed__45 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public playerDead _003C_003E4__this;

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
		public _003CstartEndScene3_003Ed__45(int _003C_003E1__state)
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
	private sealed class _003CstartEndScene_003Ed__43 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public playerDead _003C_003E4__this;

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
		public _003CstartEndScene_003Ed__43(int _003C_003E1__state)
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

	public Image blackScreenTexture;

	public float fadeBlackSpeed;

	public GameObject cam1;

	public GameObject cam2;

	public GameObject endScene2;

	public GameObject PlayerendScene3;

	public GameObject player;

	public GameObject granny;

	public GameObject grannyOverPlayer;

	public GameObject grannyOverPlayerAnim;

	public Transform GrannyEndPos;

	public GameObject cellarDoor;

	public GameObject gameController;

	public GameObject bloodscreenEnd;

	public GameObject gameOverText;

	public Image gameOverTexture;

	public GameObject soundHolder;

	public GameObject musicHolder;

	public GameObject musicHolderNM;

	public GameObject musicHolderHalloween;

	public GameObject musicHolderChristmas;

	public GameObject BGnoiceHolder;

	public GameObject carEngineSound;

	public GameObject carEngineStart;

	public GameObject carCrashSound;

	public GameObject grannyLaughSound;

	public GameObject playerInBed;

	public bool endSceneRunning;

	public bool endSceneRunning2;

	public bool endSceneRunning3;

	public GameObject giljoAnimHolder;

	public GameObject giljoSoundHolder;

	public GameObject grannyAnimHolder;

	public GameObject grannyInCar;

	public GameObject Motorhuv;

	public GameObject Car;

	public GameObject carReverseSound;

	public GameObject carForwardSound;

	public GameObject carSensors;

	public GameObject carBumper;

	public Transform CarStartPos;

	public GameObject GameOverScene4;

	public virtual void Start()
	{
	}

	[IteratorStateMachine(typeof(_003CstartEndScene_003Ed__43))]
	public virtual IEnumerator startEndScene()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CstartEndScene2_003Ed__44))]
	public virtual IEnumerator startEndScene2()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CstartEndScene3_003Ed__45))]
	public virtual IEnumerator startEndScene3()
	{
		return null;
	}

	public void startEndScene4()
	{
	}

	[IteratorStateMachine(typeof(_003CgameOverNoGranny_003Ed__47))]
	public virtual IEnumerator gameOverNoGranny()
	{
		return null;
	}
}
