using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using VoxelBusters.CoreLibrary.NativePlugins;

namespace VoxelBusters.EssentialKit.NetworkServicesCore
{
	internal sealed class UnityNetworkServicesInterface : NativeNetworkServicesInterfaceBase, INativeNetworkServicesInterface, INativeFeatureInterface, INativeObject, IDisposable
	{
		[CompilerGenerated]
		private sealed class _003CStatusCheckScheduler_003Ed__6 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public UnityNetworkServicesInterface _003C_003E4__this;

			private string _003CpingAddress_003E5__2;

			private int _003CmaxRetryCount_003E5__3;

			private float _003Cdt_003E5__4;

			private float _003CtimeOutPeriod_003E5__5;

			private bool _003CisConnected_003E5__6;

			private bool _003CnowConnected_003E5__7;

			private int _003Citer_003E5__8;

			private Ping _003Cping_003E5__9;

			private float _003CelapsedTime_003E5__10;

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
			public _003CStatusCheckScheduler_003Ed__6(int _003C_003E1__state)
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
		private IEnumerator m_activeScheduler;

		private bool m_sendEventsOnStart;

		private bool m_isConnected;

		public UnityNetworkServicesInterface()
			: base(isAvailable: false)
		{
		}

		public override void StartNotifier()
		{
		}

		public override void StopNotifier()
		{
		}

		[IteratorStateMachine(typeof(_003CStatusCheckScheduler_003Ed__6))]
		private IEnumerator StatusCheckScheduler()
		{
			return null;
		}

		private void OnPingStatusChange(bool newStatus)
		{
		}
	}
}
