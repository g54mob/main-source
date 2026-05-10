using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Photon.Realtime
{
	public class RegionPinger
	{
		[CompilerGenerated]
		private sealed class _003CRegionPingCoroutine_003Ed__22 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public RegionPinger _003C_003E4__this;

			private int _003CrttSum_003E5__2;

			private int _003CreplyCount_003E5__3;

			private Stopwatch _003Csw_003E5__4;

			private int _003Ci_003E5__5;

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
			public _003CRegionPingCoroutine_003Ed__22(int _003C_003E1__state)
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

		public static int Attempts;

		public static int MaxMillisecondsPerPing;

		public static int PingWhenFailed;

		public int CurrentAttempt;

		private Action<Region> onDoneCall;

		private PhotonPing ping;

		private List<int> rttResults;

		private Region region;

		private string regionAddress;

		public bool Done { get; private set; }

		public bool Aborted { get; internal set; }

		public RegionPinger(Region region, Action<Region> onDoneCallback)
		{
		}

		private PhotonPing GetPingImplementation()
		{
			return null;
		}

		public bool Start()
		{
			return false;
		}

		protected internal void Abort()
		{
		}

		protected internal bool RegionPingThreaded()
		{
			return false;
		}

		[IteratorStateMachine(typeof(_003CRegionPingCoroutine_003Ed__22))]
		protected internal IEnumerator RegionPingCoroutine()
		{
			return null;
		}

		public string GetResults()
		{
			return null;
		}

		public static string ResolveHost(string hostName)
		{
			return null;
		}
	}
}
