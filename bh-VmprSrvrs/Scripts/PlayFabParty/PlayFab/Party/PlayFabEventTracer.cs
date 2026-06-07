using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using PlayFab.EventsModels;
using PlayFab.Internal;
using UnityEngine;

namespace PlayFab.Party
{
	internal sealed class PlayFabEventTracer : SingletonMonoBehaviour<PlayFabEventTracer>
	{
		[CompilerGenerated]
		private sealed class _003CWaitUntilEntityLoggedIn_003Ed__14 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public float secondsBetweenWait;

			public PlayFabEventTracer _003C_003E4__this;

			private WaitForSeconds _003Cdelay_003E5__2;

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
			public _003CWaitUntilEntityLoggedIn_003Ed__14(int _003C_003E1__state)
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

		private Guid gameSessionID;

		private Queue<EventContents> eventsRequests;

		private Queue<EventContents> eventsPending;

		private EntityKey entityKey;

		private const string eventNamespace = "playfab.party";

		private const float delayBetweenEntityLoggedIn = 5f;

		private const int maxBatchSizeInEvents = 10;

		private long lastErrorTimeInMillisecond;

		private int retryCount;

		private PlayFabEventsInstanceAPI eventApi;

		private PlayFabEventTracer()
		{
		}

		private void SetCommonTelemetryProperties(Dictionary<string, object> payload)
		{
		}

		private static long GetCurrentTimeInMilliseconds()
		{
			return 0L;
		}

		public void OnPlayFabMultiPlayerManagerInitialize()
		{
		}

		[IteratorStateMachine(typeof(_003CWaitUntilEntityLoggedIn_003Ed__14))]
		private IEnumerator WaitUntilEntityLoggedIn(float secondsBetweenWait)
		{
			return null;
		}

		public void DoWork()
		{
		}

		private void EventSentSuccessfulCallback(WriteEventsResponse response)
		{
		}

		private void EventSentErrorCallback(PlayFabError response)
		{
		}

		public void OnEnable()
		{
		}

		public void OnDisable()
		{
		}

		public void OnDestroy()
		{
		}
	}
}
