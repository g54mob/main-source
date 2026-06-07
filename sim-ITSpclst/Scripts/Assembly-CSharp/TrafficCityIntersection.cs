using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class TrafficCityIntersection : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CLightSystemStage_003Ed__8 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public TrafficCityIntersection _003C_003E4__this;

		private int _003Ci_003E5__2;

		private TrafficCityIntersectionLightStage _003CcurrentStage_003E5__3;

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
		public _003CLightSystemStage_003Ed__8(int _003C_003E1__state)
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

	public Transform LightComponentPrefab;

	public List<TrafficCityIntersectionLightComponent> Lights;

	public List<TrafficCityIntersectionLightStage> LightStage;

	public bool viewTrafficLights;

	public bool viewSelectedLight;

	public bool viewTrafficLightStage;

	private void Reset()
	{
	}

	private void Start()
	{
	}

	[IteratorStateMachine(typeof(_003CLightSystemStage_003Ed__8))]
	private IEnumerator LightSystemStage()
	{
		return null;
	}
}
