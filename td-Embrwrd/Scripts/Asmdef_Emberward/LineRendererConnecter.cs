using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LineRendererConnecter : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CTimedUpdateCoroutine_003Ed__11 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public LineRendererConnecter _003C_003E4__this;

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
		public _003CTimedUpdateCoroutine_003Ed__11(int _003C_003E1__state)
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
	private LineRenderer lineRenderer;

	[SerializeField]
	[Tooltip("線段的起點目標。")]
	[Header("目標節點設定")]
	private Transform node_TargetA;

	[SerializeField]
	[Tooltip("線段的終點目標。")]
	private Transform node_TargetB;

	[Header("線段細節")]
	[Tooltip("起點和終點之間的中間頂點數量 (不包含起點和終點)。")]
	[Min(0f)]
	[SerializeField]
	private int innerPointCount;

	[Min(0f)]
	[SerializeField]
	[Tooltip("更新所有點位置的時間間隔 (秒)。0 表示每幀更新 (Update)。")]
	[Header("更新頻率")]
	private float updateInterval;

	private int totalPointCount;

	private Coroutine updateCoroutine;

	private void Start()
	{
	}

	private void OnValidate()
	{
	}

	private void StartUpdateMechanism()
	{
	}

	private void Update()
	{
	}

	[IteratorStateMachine(typeof(_003CTimedUpdateCoroutine_003Ed__11))]
	private IEnumerator TimedUpdateCoroutine()
	{
		return null;
	}

	public void UpdatePointCount()
	{
	}

	public void UpdateLinePositions()
	{
	}

	private void OnDisable()
	{
	}

	private void OnEnable()
	{
	}

	private void UpdateNow()
	{
	}
}
