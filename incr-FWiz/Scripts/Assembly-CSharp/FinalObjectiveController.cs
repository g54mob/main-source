using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using FMODUnity;
using UnityEngine;

public class FinalObjectiveController : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass24_0
	{
		public bool faded;

		internal void _003COpenVault_003Eb__0()
		{
		}

		internal void _003COpenVault_003Eb__1()
		{
		}

		internal void _003COpenVault_003Eb__2()
		{
		}

		internal void _003COpenVault_003Eb__3()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003COnCompleteLevel_003Ed__23 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public FinalObjectiveController _003C_003E4__this;

		private MapBarrierWall _003CmapBarrier_003E5__2;

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
		public _003COnCompleteLevel_003Ed__23(int _003C_003E1__state)
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
	private sealed class _003COpenVault_003Ed__24 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		private _003C_003Ec__DisplayClass24_0 _003C_003E8__1;

		public FinalObjectiveController _003C_003E4__this;

		private Vector3 _003CinitialPos_003E5__2;

		private float _003Ctimer_003E5__3;

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
		public _003COpenVault_003Ed__24(int _003C_003E1__state)
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

	public static FinalObjectiveController Instance;

	[SerializeField]
	private PaymentCollector _paymentCollector;

	[SerializeField]
	private FinalObjectiveUI _finalObjectiveUI;

	[SerializeField]
	private List<MapBarrierBrazier> _braziers;

	[SerializeField]
	private int _level;

	[SerializeField]
	private int _levelPart;

	[SerializeField]
	private PaymentGroup _payment;

	public EventReference CompleteLevelPartSound;

	public EventReference CompleteLevelSound;

	[SerializeField]
	private List<FinalObjectiveLevel> _levels;

	public float CameraPanToWallSpeed;

	public SpriteRenderer VaultDoorSpriteRenderer;

	public float VaultDoorSlideDuration;

	public float VaultOpenCameraShake;

	public float VaultOpenFadeTime;

	public float VaultOpenZoomModifier;

	public float VaultOpenEndBuffer;

	public float VaultOpenBlackDuration;

	public EventReference VaultOpenSound;

	public GameObject VaultDoorButton;

	private void Start()
	{
	}

	public void Initiate()
	{
	}

	public void OnCompleteLevelPart()
	{
	}

	[IteratorStateMachine(typeof(_003COnCompleteLevel_003Ed__23))]
	private IEnumerator OnCompleteLevel()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003COpenVault_003Ed__24))]
	private IEnumerator OpenVault()
	{
		return null;
	}

	public void SetVaultOpen()
	{
	}

	private void StartPayment()
	{
	}
}
