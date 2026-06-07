using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class Obj_BossTrainWeightDisplayBoard : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CCR_LerpNumber_003Ed__18 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public int to;

		public int from;

		public Obj_BossTrainWeightDisplayBoard _003C_003E4__this;

		public int maxWeight;

		public float duration;

		private float _003CelapsedTime_003E5__2;

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
		public _003CCR_LerpNumber_003Ed__18(int _003C_003E1__state)
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
	private List<ParticleSystem> list_WarningParticles;

	[SerializeField]
	private TMP_Text text_Title;

	[SerializeField]
	private TMP_Text text_Weight;

	[SerializeField]
	private LineRenderer lineRenderer_OverWeightEffect;

	[SerializeField]
	private List<Transform> list_CircuitPoints;

	[SerializeField]
	private Vector3 circuitPointOffset;

	private bool isOverWeight;

	private int currentWeight;

	private Coroutine coroutine_LerpWeight;

	private float updateOverweightEffectInterval;

	private float updateOverweightEffectTimer;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void Start()
	{
	}

	private void OnLanguageChanged()
	{
	}

	public void SetWeight(int weight, int maxWeight)
	{
	}

	private void Update()
	{
	}

	private void UpdateLineRenderer()
	{
	}

	[IteratorStateMachine(typeof(_003CCR_LerpNumber_003Ed__18))]
	private IEnumerator CR_LerpNumber(int from, int to, int maxWeight, float duration)
	{
		return null;
	}
}
