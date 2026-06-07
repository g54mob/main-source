using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Coherence.Connection;
using Coherence.Entities;
using Coherence.Log;
using UnityEngine;

namespace Coherence.Toolkit
{
	public class CoherenceClientConnectionManager : IClientConnectionManager
	{
		[CompilerGenerated]
		private sealed class _003CGetAllClients_003Ed__36 : IEnumerable<CoherenceClientConnection>, IEnumerable, IEnumerator<CoherenceClientConnection>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private CoherenceClientConnection _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public CoherenceClientConnectionManager _003C_003E4__this;

			private Dictionary<Entity, CoherenceClientConnection>.ValueCollection.Enumerator _003Cconnections_003E5__2;

			CoherenceClientConnection IEnumerator<CoherenceClientConnection>.Current
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
			public _003CGetAllClients_003Ed__36(int _003C_003E1__state)
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

			[DebuggerHidden]
			IEnumerator<CoherenceClientConnection> IEnumerable<CoherenceClientConnection>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		[CompilerGenerated]
		private sealed class _003CGetAllSimulators_003Ed__37 : IEnumerable<CoherenceClientConnection>, IEnumerable, IEnumerator<CoherenceClientConnection>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private CoherenceClientConnection _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public CoherenceClientConnectionManager _003C_003E4__this;

			private Dictionary<Entity, CoherenceClientConnection>.ValueCollection.Enumerator _003Cconnections_003E5__2;

			CoherenceClientConnection IEnumerator<CoherenceClientConnection>.Current
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
			public _003CGetAllSimulators_003Ed__37(int _003C_003E1__state)
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

			[DebuggerHidden]
			IEnumerator<CoherenceClientConnection> IEnumerable<CoherenceClientConnection>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		[CompilerGenerated]
		private sealed class _003CGetOther_003Ed__38 : IEnumerable<CoherenceClientConnection>, IEnumerable, IEnumerator<CoherenceClientConnection>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private CoherenceClientConnection _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public CoherenceClientConnectionManager _003C_003E4__this;

			private Dictionary<Entity, CoherenceClientConnection>.ValueCollection.Enumerator _003Cconnections_003E5__2;

			CoherenceClientConnection IEnumerator<CoherenceClientConnection>.Current
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
			public _003CGetOther_003Ed__38(int _003C_003E1__state)
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

			[DebuggerHidden]
			IEnumerator<CoherenceClientConnection> IEnumerable<CoherenceClientConnection>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		[CompilerGenerated]
		private sealed class _003CGetOtherClients_003Ed__39 : IEnumerable<CoherenceClientConnection>, IEnumerable, IEnumerator<CoherenceClientConnection>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private CoherenceClientConnection _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public CoherenceClientConnectionManager _003C_003E4__this;

			private Dictionary<Entity, CoherenceClientConnection>.ValueCollection.Enumerator _003Cconnections_003E5__2;

			CoherenceClientConnection IEnumerator<CoherenceClientConnection>.Current
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
			public _003CGetOtherClients_003Ed__39(int _003C_003E1__state)
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

			[DebuggerHidden]
			IEnumerator<CoherenceClientConnection> IEnumerable<CoherenceClientConnection>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		[CompilerGenerated]
		private sealed class _003CGetOtherSimulators_003Ed__40 : IEnumerable<CoherenceClientConnection>, IEnumerable, IEnumerator<CoherenceClientConnection>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private CoherenceClientConnection _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public CoherenceClientConnectionManager _003C_003E4__this;

			private Dictionary<Entity, CoherenceClientConnection>.ValueCollection.Enumerator _003Cconnections_003E5__2;

			CoherenceClientConnection IEnumerator<CoherenceClientConnection>.Current
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
			public _003CGetOtherSimulators_003Ed__40(int _003C_003E1__state)
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

			[DebuggerHidden]
			IEnumerator<CoherenceClientConnection> IEnumerable<CoherenceClientConnection>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		private CoherenceClientConnection myClientConnection;

		private CoherenceClientConnection simulatorConnection;

		private readonly ICoherenceBridge bridge;

		private readonly Coherence.Log.Logger logger;

		private readonly Dictionary<Entity, CoherenceClientConnection> connectionsByEntityId;

		private readonly Dictionary<ClientID, Entity> entityIdByClientId;

		internal Action<CoherenceClientConnection> OnMyClientConnection;

		public int ClientConnectionCount => 0;

		public event ClientConnectionPrefabProvider ProvidePrefab
		{
			add
			{
			}
			remove
			{
			}
		}

		private event ClientConnectionPrefabProvider providePrefab
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

		public event Action<CoherenceClientConnection> OnCreated
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

		public event Action<CoherenceClientConnection> OnDestroyed
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

		public event Action<CoherenceClientConnectionManager> OnSynced
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

		internal CoherenceClientConnectionManager(ICoherenceBridge bridge, Coherence.Log.Logger logger)
		{
		}

		internal void PrintConnectionWithoutQueryError(string cause)
		{
		}

		public void GetPrefab(ClientID clientId, ConnectionType connectionType, Action<ICoherenceSync> onLoaded)
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Add(CoherenceClientConnection connection)
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool Remove(Entity entityID)
		{
			return false;
		}

		internal void CleanUp()
		{
		}

		internal void HandleGlobalQuerySynced()
		{
		}

		public CoherenceClientConnection GetMine()
		{
			return null;
		}

		public CoherenceClientConnection GetSimulator()
		{
			return null;
		}

		public CoherenceClientConnection Get(ClientID clientId)
		{
			return null;
		}

		public CoherenceClientConnection Get(Entity entityId)
		{
			return null;
		}

		public IEnumerable<CoherenceClientConnection> GetAll()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CGetAllClients_003Ed__36))]
		public IEnumerable<CoherenceClientConnection> GetAllClients()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CGetAllSimulators_003Ed__37))]
		public IEnumerable<CoherenceClientConnection> GetAllSimulators()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CGetOther_003Ed__38))]
		public IEnumerable<CoherenceClientConnection> GetOther()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CGetOtherClients_003Ed__39))]
		public IEnumerable<CoherenceClientConnection> GetOtherClients()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CGetOtherSimulators_003Ed__40))]
		public IEnumerable<CoherenceClientConnection> GetOtherSimulators()
		{
			return null;
		}

		public bool SendMessage<TTarget>(string methodName, Entity entityId, MessageTarget target, params object[] args) where TTarget : UnityEngine.Component
		{
			return false;
		}

		public bool SendMessage(Type targetType, string methodName, Entity entityId, MessageTarget target, params object[] args)
		{
			return false;
		}

		public bool SendMessage<TTarget>(string methodName, ClientID clientId, MessageTarget target, params object[] args) where TTarget : UnityEngine.Component
		{
			return false;
		}

		public bool SendMessage(Type targetType, string methodName, ClientID clientId, MessageTarget target, params object[] args)
		{
			return false;
		}

		public bool SendMessageToAll<TTarget>(string methodName, MessageTarget target, bool sendToSelf, params object[] args) where TTarget : UnityEngine.Component
		{
			return false;
		}

		public bool SendMessageToAll(Type targetType, string methodName, MessageTarget target, bool sendToSelf, params object[] args)
		{
			return false;
		}

		public bool SendMessageToAllClients<TTarget>(string methodName, MessageTarget target, bool sendToSelf, params object[] args) where TTarget : UnityEngine.Component
		{
			return false;
		}

		public bool SendMessageToAllClients(Type targetType, string methodName, MessageTarget target, bool sendToSelf, params object[] args)
		{
			return false;
		}

		public bool SendMessageToAllSimulators<TTarget>(string methodName, MessageTarget target, bool sendToSelf, params object[] args) where TTarget : UnityEngine.Component
		{
			return false;
		}

		public bool SendMessageToAllSimulators(Type targetType, string methodName, MessageTarget target, bool sendToSelf, params object[] args)
		{
			return false;
		}
	}
}
