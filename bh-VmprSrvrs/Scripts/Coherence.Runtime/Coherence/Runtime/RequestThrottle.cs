using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Coherence.Common;
using Coherence.Log;
using UnityEngine;

namespace Coherence.Runtime
{
	internal class RequestThrottle
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CWaitForCooldown_003Ed__8 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public RequestThrottle _003C_003E4__this;

			public string basePath;

			public string method;

			public CancellationToken cancellationToken;

			private Awaitable.Awaiter _003C_003Eu__1;

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

		public TimeSpan RequestInterval;

		private readonly Coherence.Log.Logger logger;

		private readonly Dictionary<(string basePath, string method), DateTime> requestTimeByPath;

		private readonly IDateTimeProvider dateTimeProvider;

		public RequestThrottle(TimeSpan requestInterval)
		{
		}

		internal RequestThrottle(TimeSpan requestInterval, IDateTimeProvider dateTimeProvider)
		{
		}

		public TimeSpan RequestCooldown(string basePath, string method)
		{
			return default(TimeSpan);
		}

		public bool HandleTooManyRequests(string basePath, string method, string requestName)
		{
			return false;
		}

		[AsyncStateMachine(typeof(_003CWaitForCooldown_003Ed__8))]
		public virtual Task WaitForCooldown(string basePath, string method, CancellationToken cancellationToken)
		{
			return null;
		}
	}
}
