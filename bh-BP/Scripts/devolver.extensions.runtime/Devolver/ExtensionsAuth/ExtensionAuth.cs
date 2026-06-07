using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Devolver.ExtensionsAuth
{
	public class ExtensionAuth : MonoBehaviour
	{
		public delegate void AuthCompletion(Response response);

		[CompilerGenerated]
		private sealed class _003CWritePreferences_003Ed__14 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public ExtensionAuth _003C_003E4__this;

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
			public _003CWritePreferences_003Ed__14(int _003C_003E1__state)
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

		public static string devolverApiUrl;

		private int callbackPort;

		private string callbackURL;

		private bool awaitingResponse;

		public Response authData;

		private HttpListener authListener;

		public static event AuthCompletion OnComplete
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		private void Start()
		{
		}

		public void StartAuth(string appID)
		{
		}

		private void createWebListener()
		{
		}

		private void APIResponse(IAsyncResult res)
		{
		}

		[IteratorStateMachine(typeof(_003CWritePreferences_003Ed__14))]
		private IEnumerator WritePreferences()
		{
			return null;
		}

		private void SetPlayerPrefs()
		{
		}

		public static int GetRandomUnusedPort()
		{
			return 0;
		}

		public void DisconnectAuth()
		{
		}
	}
}
