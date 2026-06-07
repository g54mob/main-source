using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using Coherence.Log;
using Coherence.Runtime;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Coherence.Cloud
{
	public class KvStoreClient : IUpdatable, IDisposable
	{
		private enum DataOperationType
		{
			[EnumMember(Value = "set")]
			Set = 0,
			[EnumMember(Value = "del")]
			Delete = 1
		}

		private struct DataSyncItem
		{
			[JsonProperty("key")]
			public string Key;

			[JsonProperty("val")]
			public string Value;

			[JsonProperty("op")]
			[JsonConverter(typeof(StringEnumConverter))]
			public DataOperationType Operation;

			[JsonIgnore]
			public bool Dirty;
		}

		private struct DataSync
		{
			[JsonProperty("kv")]
			public List<DataSyncItem> Data;
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CUpdate_003Ed__20 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public KvStoreClient _003C_003E4__this;

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

		private bool dirty;

		private bool isSyncing;

		private IRequestFactory requestFactory;

		private IAuthClientInternal authClient;

		private readonly Stopwatch syncBackoffStopwatch;

		private TimeSpan syncBackoff;

		private readonly Logger logger;

		private readonly List<DataSyncItem> syncPoint;

		private readonly Dictionary<string, DataSyncItem> dataItemByKey;

		private HashSet<string> invalidKeys;

		private readonly bool registerForUpdate;

		public KvStoreClient(RequestFactory requestFactory, AuthClient authClient)
		{
		}

		internal KvStoreClient(IRequestFactory requestFactory, IAuthClientInternal authClient, bool registerForUpdate = true)
		{
		}

		public void Dispose()
		{
		}

		public bool Set(string key, string value)
		{
			return false;
		}

		public bool Unset(string key)
		{
			return false;
		}

		public string Get(string key, string defaultValue = null)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CUpdate_003Ed__20))]
		public void Update()
		{
		}

		private void Clear()
		{
		}

		private void OnLogin(IEnumerable<KvPair> kv)
		{
		}

		private void OnLogout()
		{
		}

		private bool CheckKeyValidity(string key)
		{
			return false;
		}

		private void SyncWithLogin(LoginResponse loginResponse)
		{
		}
	}
}
