using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace __Project__.Scripts.ReflectionProbe
{
	public class ReflectionProbeManager : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CDelayedInitialize_003Ed__9 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public ReflectionProbeManager _003C_003E4__this;

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
			public _003CDelayedInitialize_003Ed__9(int _003C_003E1__state)
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
		private List<float> m_PercentageList;

		private int m_CurrentIndex;

		[SerializeField]
		private List<ReflectionProbeRefresh> m_RefreshList;

		[SerializeField]
		private List<ReflectionProbeRefresh> m_AutoUpdatedProbesList;

		public List<float> PercentageList => null;

		public List<ReflectionProbeRefresh> RefreshList => null;

		private void Start()
		{
		}

		[IteratorStateMachine(typeof(_003CDelayedInitialize_003Ed__9))]
		private IEnumerator DelayedInitialize()
		{
			return null;
		}

		private void Update()
		{
		}

		public void CheckPercentage()
		{
		}

		private void RefreshProbes(int index)
		{
		}

		private int GetProbeDataIndex(float percentage)
		{
			return 0;
		}
	}
}
