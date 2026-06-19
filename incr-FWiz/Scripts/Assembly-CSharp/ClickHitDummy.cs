using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using FMODUnity;
using UnityEngine;

public class ClickHitDummy : ClickHoldActionHandler
{
	public enum HitDummyType
	{
		Object = 0,
		Rock = 1,
		Creature = 2,
		Plant = 3
	}

	[CompilerGenerated]
	private sealed class _003CDelayedHit_003Ed__41 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public float delay;

		public ClickHitDummy _003C_003E4__this;

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
		public _003CDelayedHit_003Ed__41(int _003C_003E1__state)
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

	[SerializeField]
	private float _baseHitRate;

	[SerializeField]
	private float _baseDamagePerHit;

	private float _hitTimer;

	private float _lastTime;

	private float _hitRateModifier;

	private float _damageModifier;

	[SerializeField]
	private EventReference _hitSound;

	[SerializeField]
	private EventReference _finishingHitSound;

	private bool _hitSubsribed;

	public HitDummyType DummyType;

	public TotemListener ClickTotemListener;

	private const float TotemBoost = 0.3f;

	public static HashSet<ClickHitDummy> AllHitDummies;

	[field: SerializeField]
	public float CurrentDamage { get; private set; }

	[field: SerializeField]
	public bool Locked { get; private set; }

	public event Action<bool> AnnounceHit
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public event Action AnnounceFinishingHit
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	protected virtual void Start()
	{
	}

	private void Initiate()
	{
	}

	public override void OnEnable()
	{
	}

	public override void OnDisable()
	{
	}

	public void Unlock()
	{
	}

	private void UnsubscribeToHit()
	{
	}

	private void SubscribeToHit()
	{
	}

	public void AddHitRateModifier(float modifier)
	{
	}

	public void AddDamageModifier(float modifier)
	{
	}

	public float GetHitBuffer()
	{
		return 0f;
	}

	public float GetGeneralStrengthModifier()
	{
		return 0f;
	}

	public float GetGeneralHitRateModifier()
	{
		return 0f;
	}

	public void ApplyAOE()
	{
	}

	[IteratorStateMachine(typeof(_003CDelayedHit_003Ed__41))]
	public IEnumerator DelayedHit(float delay)
	{
		return null;
	}

	public virtual void OnClick()
	{
	}

	public void ApplyInitialHit()
	{
	}

	public virtual void OnHoldStart()
	{
	}

	public virtual void OnHold()
	{
	}

	public virtual void OnHoldEnd()
	{
	}

	public virtual void Hit()
	{
	}

	public virtual void OnFinishingHit()
	{
	}

	protected virtual void OnDestroy()
	{
	}
}
