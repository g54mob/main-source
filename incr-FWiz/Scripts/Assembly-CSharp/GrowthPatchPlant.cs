using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using FMODUnity;
using OUSystems.Basics.Effects;
using UnityEngine;

public class GrowthPatchPlant : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CGrow_003Ed__17 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public GrowthPatchPlant _003C_003E4__this;

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
		public _003CGrow_003Ed__17(int _003C_003E1__state)
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
	private SpriteRenderer _spriteRenderer;

	[SerializeField]
	private List<GrowthPatchPlantPhase> _growthStages;

	[SerializeField]
	private float _growthPhaseDurationMin;

	[SerializeField]
	private float _growthPhaseDurationMax;

	private float _growthRateModifier;

	[SerializeField]
	private ShakeReceiver _shakeReceiver;

	public float ShakeLevel;

	[SerializeField]
	private ClickHitDummy _clickHitDummy;

	[SerializeField]
	private Collider2D _boxCollider;

	public EventReference GrowSound;

	public Action AnnounceProduceItem;

	[SerializeField]
	private int GrowthLevel;

	public TotemListener GrowthTotemListener;

	private const float GrowthTotemBoost = 0.4f;

	public void Start()
	{
	}

	public void Initiate()
	{
	}

	private void OnDestroy()
	{
	}

	[IteratorStateMachine(typeof(_003CGrow_003Ed__17))]
	public IEnumerator Grow()
	{
		return null;
	}

	public void AddGrowthRateModifier(float modifier)
	{
	}

	public void Harvest()
	{
	}

	public void ShowPhase(int index)
	{
	}
}
