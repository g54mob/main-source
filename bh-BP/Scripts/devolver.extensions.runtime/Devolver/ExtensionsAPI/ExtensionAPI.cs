using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.Networking;

namespace Devolver.ExtensionsAPI
{
	public class ExtensionAPI : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CGetFromAPI_003Ed__19 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public bool bypassAuth;

			public ExtensionAPI _003C_003E4__this;

			public string route;

			public Action<JObject> callback;

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
			public _003CGetFromAPI_003Ed__19(int _003C_003E1__state)
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
		private sealed class _003CGetFromAPINoAuth_003Ed__20 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public ExtensionAPI _003C_003E4__this;

			public string route;

			public Action<JObject> callback;

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
			public _003CGetFromAPINoAuth_003Ed__20(int _003C_003E1__state)
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
		private sealed class _003CPostToAPI_003Ed__17 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public bool bypassAuth;

			public ExtensionAPI _003C_003E4__this;

			public string route;

			public string apiBody;

			public Action<JObject> callback;

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
			public _003CPostToAPI_003Ed__17(int _003C_003E1__state)
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
		private sealed class _003CPostToAPIWithAuth_003Ed__18 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public ExtensionAPI _003C_003E4__this;

			public string route;

			public string apiBody;

			public string authID;

			public Action<JObject> callback;

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
			public _003CPostToAPIWithAuth_003Ed__18(int _003C_003E1__state)
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

		private string appID;

		private string devolverApiUrl;

		public void SetAppId(string newAppId)
		{
		}

		public Task<JObject> UpdateSettings(object settings)
		{
			return null;
		}

		public Task<JObject> GetSettings()
		{
			return null;
		}

		public Task<JObject> GetActiveViewerSettings(int userRequests = 30)
		{
			return null;
		}

		public Task<JObject> GetPoll(string pollID)
		{
			return null;
		}

		public Task<JObject> CreatePoll(object pollDetails)
		{
			return null;
		}

		public Task<JObject> ClosePoll(string pollID)
		{
			return null;
		}

		public Task<JObject> GetTwitchPoll(string pollID)
		{
			return null;
		}

		public Task<JObject> CreateTwitchPoll(object pollDetails)
		{
			return null;
		}

		public Task<JObject> SendTwitchMessage(object messageData)
		{
			return null;
		}

		public Task<JObject> GetTwitchReward(string rewardID)
		{
			return null;
		}

		public Task<JObject> CreateTwitchReward(object rewardDetails)
		{
			return null;
		}

		public Task<JObject> FulfillTwitchReward(object rewardDetails)
		{
			return null;
		}

		public Task<JObject> GetGameShareState(string shareStateID)
		{
			return null;
		}

		public Task<JObject> PostGameShareState(object shareState, string publicUserID)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CPostToAPI_003Ed__17))]
		private IEnumerator PostToAPI(string apiBody, string route, Action<JObject> callback, bool bypassAuth = false)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CPostToAPIWithAuth_003Ed__18))]
		private IEnumerator PostToAPIWithAuth(string apiBody, string route, Action<JObject> callback, string authID)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CGetFromAPI_003Ed__19))]
		private IEnumerator GetFromAPI(string route, Action<JObject> callback, bool bypassAuth = false)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CGetFromAPINoAuth_003Ed__20))]
		private IEnumerator GetFromAPINoAuth(string route, Action<JObject> callback)
		{
			return null;
		}
	}
}
