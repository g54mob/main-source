using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace ModIO.Util
{
	internal class SimpleMessageHubTester : SelfInstancingMonoSingleton<SimpleMessageHubTester>
	{
		[CompilerGenerated]
		private sealed class _003CPokeMessages_003Ed__2 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public SimpleMessageHubTester _003C_003E4__this;

			private int _003Ci_003E5__2;

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
			public _003CPokeMessages_003Ed__2(int _003C_003E1__state)
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

		private SimpleMessageUnsubscribeToken subToken;

		public void RunTest()
		{
		}

		[IteratorStateMachine(typeof(_003CPokeMessages_003Ed__2))]
		private IEnumerator PokeMessages()
		{
			return null;
		}
	}
}
