using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Steamworks;
using UnityEngine;
using UnityEngine.Networking;

namespace ScheduleOne.Polling
{
	public class PollManager : MonoBehaviour
	{
		public enum EPollSubmissionResult
		{
			InProgress = 0,
			Success = 1,
			Failed = 2
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CInitAppTicket_003Ed__30 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public PollManager _003C_003E4__this;

			private TaskAwaiter<string> _003C_003Eu__1;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[CompilerGenerated]
		private sealed class _003CRequestPoll_003Ed__32 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public string url;

			public Action<string> callback;

			private UnityWebRequest _003Crequest_003E5__2;

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
			public _003CRequestPoll_003Ed__32(int _003C_003E1__state)
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

		[CompilerGenerated]
		private sealed class _003CSubmitAnswerToServer_003Ed__31 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public PollAnswer answer;

			public PollManager _003C_003E4__this;

			private UnityWebRequest _003Creq_003E5__2;

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
			public _003CSubmitAnswerToServer_003Ed__31(int _003C_003E1__state)
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

			private void _003C_003Em__Finally1()
			{
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		public const string SERVER_URL = "https://us-central1-s1-polling-987345.cloudfunctions.net/poll";

		private CallResult<EncryptedAppTicketResponse_t> appTicketCallbackResponse;

		private TaskCompletionSource<string> tokenCompletion;

		private PollResponse receivedPollResponse;

		private int sentResponse;

		private string appTicket;

		public Action<PollData> onActivePollReceived;

		public Action<PollData> onConfirmedPollReceived;

		private bool appTicketRequested;

		public PollData ActivePoll { get; private set; }

		public PollData ConfirmedPoll { get; private set; }

		public EPollSubmissionResult SubmissionResult { get; private set; }

		public string SubmisssionFailedMesssage { get; private set; }

		private void Start()
		{
		}

		private void Update()
		{
		}

		public void GenerateAppTicket()
		{
		}

		public void SelectPollResponse(int responseIndex)
		{
		}

		[AsyncStateMachine(typeof(_003CInitAppTicket_003Ed__30))]
		private Task InitAppTicket()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CSubmitAnswerToServer_003Ed__31))]
		private IEnumerator SubmitAnswerToServer(PollAnswer answer)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CRequestPoll_003Ed__32))]
		private IEnumerator RequestPoll(string url, Action<string> callback = null)
		{
			return null;
		}

		private void ResponseCallback(string data)
		{
		}

		private void OnEncryptedAppTicketResponse(EncryptedAppTicketResponse_t response, bool ioFailure)
		{
		}

		private Task<string> GetAppTicket()
		{
			return null;
		}

		private static string CleanTicket(string ticket)
		{
			return null;
		}

		public static bool TryGetExistingPollResponse(int pollId, out int response)
		{
			response = default(int);
			return false;
		}

		private static void RecordSubmission(int pollId, int response)
		{
		}
	}
}
