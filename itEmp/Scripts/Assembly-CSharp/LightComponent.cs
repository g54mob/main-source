using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(Light))]
public class LightComponent : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CAdjustLODQuality_003Ed__10 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public LightComponent _003C_003E4__this;

		private WaitForSeconds _003Cwait_003E5__2;

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
		public _003CAdjustLODQuality_003Ed__10(int _003C_003E1__state)
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
	public Light lightComponent;

	public bool LightShouldBeOn;

	public bool noShadown;

	[Range(0f, 1f)]
	[SerializeField]
	private float updateDelay;

	[SerializeField]
	[HideInInspector]
	private List<LightAdjustment> LODLevels;

	[HideInInspector]
	public Transform player;

	[HideInInspector]
	public float floorHeight;

	private void Reset()
	{
	}

	private void Awake()
	{
	}

	private void OnEnable()
	{
	}

	[IteratorStateMachine(typeof(_003CAdjustLODQuality_003Ed__10))]
	private IEnumerator AdjustLODQuality()
	{
		return null;
	}

	private void InitializeLODLevels()
	{
	}
}
