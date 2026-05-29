using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using FishNet.Connection;
using FishNet.Managing.Client;
using FishNet.Managing.Server;
using FishNet.Object;
using FishNet.Transporting;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FishNet.Managing.Scened
{
	[DisallowMultipleComponent]
	[AddComponentMenu("FishNet/Manager/SceneManager")]
	public sealed class SceneManager : MonoBehaviour
	{
		internal enum LightProbeUpdateType
		{
			Asynchronous = 0,
			BlockThread = 1,
			Off = 2
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003C_003Ec__DisplayClass107_0
		{
			public LoadQueueData data;

			public List<Scene> loadedScenes;

			public SceneLoadData sceneLoadData;

			public SceneLookupData[] broadcastLookupDatas;
		}

		[CompilerGenerated]
		private sealed class _003C__LoadScenes_003Ed__107 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public SceneManager _003C_003E4__this;

			private _003C_003Ec__DisplayClass107_0 _003C_003E8__1;

			private bool _003CasServer_003E5__2;

			private bool _003CasHost_003E5__3;

			private NetworkConnection _003ClocalConnection_003E5__4;

			private List<string> _003CrequestedLoadSceneNames_003E5__5;

			private List<SceneLookupData> _003CloadableScenes_003E5__6;

			private List<Scene> _003CunloadableScenes_003E5__7;

			private string[] _003CunloadedNames_003E5__8;

			private bool _003CallScenesLoaded_003E5__9;

			private int _003Ci_003E5__10;

			private float _003CmaximumIndexWorth_003E5__11;

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
			public _003C__LoadScenes_003Ed__107(int _003C_003E1__state)
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

		[CompilerGenerated]
		private sealed class _003C__ProcessSceneQueue_003Ed__98 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public SceneManager _003C_003E4__this;

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
			public _003C__ProcessSceneQueue_003Ed__98(int _003C_003E1__state)
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
		private sealed class _003C__UnloadScenes_003Ed__115 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public SceneManager _003C_003E4__this;

			private UnloadQueueData _003Cdata_003E5__2;

			private SceneUnloadData _003CsceneUnloadData_003E5__3;

			private bool _003CasServer_003E5__4;

			private List<Scene> _003CunloadableScenes_003E5__5;

			private List<UnloadedScene> _003CunloadedScenes_003E5__6;

			private List<Scene>.Enumerator _003C_003E7__wrap6;

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
			public _003C__UnloadScenes_003Ed__115(int _003C_003E1__state)
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

		[SerializeField]
		[Tooltip("Script to handle addressables loading and unloading. This field may be blank if addressables are not being used.")]
		private SceneProcessorBase _sceneProcessor;

		[SerializeField]
		[Tooltip("How to update light probes after loading or unloading scenes.")]
		private LightProbeUpdateType _lightProbeUpdating;

		[SerializeField]
		[Tooltip("True to move objects visible to clientHost that are within an unloading scene. This ensures the objects are despawned on the client side rather than when the scene is destroyed.")]
		private bool _moveClientHostObjects;

		[Tooltip("True to automatically set active scenes when loading and unloading scenes.")]
		[SerializeField]
		private bool _setActiveScene;

		private string[] _globalScenes;

		private SceneLoadData _globalSceneLoadData;

		private List<object> _queuedOperations;

		private HashSet<Scene> _manualUnloadScenes;

		private Scene _movedObjectsScene;

		private Scene _delayedDestroyScene;

		private Scene _fallbackActiveScene;

		private bool _sceneQueueStartInvoked;

		private List<GameObject> _movingObjects;

		private Dictionary<NetworkConnection, int> _pendingClientSceneChanges;

		private HashSet<string> _serverGlobalScenesLoading;

		private const string INVALID_SCENELOADDATA = "One or more datas in SceneLoadData are invalid.This generally occurs when calling this method without specifying any scenes or when data fields are null.";

		private const string INVALID_SCENEUNLOADDATA = "One or more datas in SceneLoadData are invalid.This generally occurs when calling this method without specifying any scenes or when data fields are null.";

		public Dictionary<Scene, HashSet<NetworkConnection>> SceneConnections { get; private set; }

		public NetworkManager NetworkManager { get; private set; }

		internal bool IteratingQueue { get; private set; }

		internal float QueueCompleteTime { get; private set; }

		private ServerManager _serverManager => null;

		private ClientManager _clientManager => null;

		public event Action<bool> OnActiveSceneSet
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

		public event Action<NetworkConnection, bool> OnClientLoadedStartScenes
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

		public event Action OnQueueStart
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

		public event Action OnQueueEnd
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

		public event Action<SceneLoadStartEventArgs> OnLoadStart
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

		public event Action<SceneLoadPercentEventArgs> OnLoadPercentChange
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

		public event Action<SceneLoadEndEventArgs> OnLoadEnd
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

		public event Action<SceneUnloadStartEventArgs> OnUnloadStart
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

		public event Action<SceneUnloadEndEventArgs> OnUnloadEnd
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

		public event Action<ClientPresenceChangeEventArgs> OnClientPresenceChangeStart
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

		public event Action<ClientPresenceChangeEventArgs> OnClientPresenceChangeEnd
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

		internal event Action OnActiveSceneSetInternal
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

		public SceneProcessorBase GetSceneProcessor()
		{
			return null;
		}

		public void SetSceneProcessor(SceneProcessorBase value)
		{
		}

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void OnDestroy()
		{
		}

		private void ServerManager_OnServerConnectionState(ServerConnectionStateArgs obj)
		{
		}

		private void ResetValues()
		{
		}

		private void ServerManager_OnRemoteConnectionState(NetworkConnection arg1, RemoteConnectionStateArgs arg2)
		{
		}

		internal void InitializeOnce_Internal(NetworkManager manager)
		{
		}

		private void SceneManager_SceneUnloaded(Scene scene)
		{
		}

		private void TryInvokeLoadedStartScenes(NetworkConnection connection, bool asServer)
		{
		}

		internal void OnClientAuthenticated(NetworkConnection connection)
		{
		}

		private void OnClientEmptyStartScenes(EmptyStartScenesBroadcast msg)
		{
		}

		private void OnServerEmptyStartScenes(NetworkConnection conn, EmptyStartScenesBroadcast msg)
		{
		}

		private void ClientDisconnected(NetworkConnection conn)
		{
		}

		private void OnClientLoadedScenes(NetworkConnection conn, ClientScenesLoadedBroadcast msg)
		{
		}

		private void TryInvokeOnQueueStart()
		{
		}

		private void TryInvokeOnQueueEnd()
		{
		}

		private void InvokeOnSceneLoadStart(LoadQueueData qd)
		{
		}

		private void InvokeOnSceneLoadEnd(LoadQueueData qd, List<string> requestedLoadScenes, List<Scene> loadedScenes, string[] unloadedSceneNames)
		{
		}

		private void InvokeOnSceneUnloadStart(UnloadQueueData sqd)
		{
		}

		private void InvokeOnSceneUnloadEnd(UnloadQueueData sqd, List<Scene> unloadedScenes, List<UnloadedScene> newUnloadedScenes)
		{
		}

		private void InvokeOnScenePercentChange(LoadQueueData qd, float value)
		{
		}

		private void QueueOperation(object data)
		{
		}

		[IteratorStateMachine(typeof(_003C__ProcessSceneQueue_003Ed__98))]
		private IEnumerator __ProcessSceneQueue()
		{
			return null;
		}

		private string[] GlobalScenesExcludingLoading()
		{
			return null;
		}

		public void LoadGlobalScenes(SceneLoadData sceneLoadData)
		{
		}

		private void LoadGlobalScenes_Internal(SceneLoadData sceneLoadData, string[] globalScenes, bool asServer)
		{
		}

		public void LoadConnectionScenes(NetworkConnection conn, SceneLoadData sceneLoadData)
		{
		}

		public void LoadConnectionScenes(NetworkConnection[] conns, SceneLoadData sceneLoadData)
		{
		}

		public void LoadConnectionScenes(SceneLoadData sceneLoadData)
		{
		}

		private void LoadConnectionScenes_Internal(NetworkConnection[] conns, SceneLoadData sceneLoadData, string[] globalScenes, bool asServer)
		{
		}

		private bool CanMoveNetworkObject(NetworkObject nob, bool warn)
		{
			return false;
		}

		[IteratorStateMachine(typeof(_003C__LoadScenes_003Ed__107))]
		private IEnumerator __LoadScenes()
		{
			return null;
		}

		private void OnLoadScenes(LoadScenesBroadcast msg)
		{
		}

		public void UnloadGlobalScenes(SceneUnloadData sceneUnloadData)
		{
		}

		private void UnloadGlobalScenes_Internal(SceneUnloadData sceneUnloadData, string[] globalScenes, bool asServer)
		{
		}

		public void UnloadConnectionScenes(NetworkConnection connection, SceneUnloadData sceneUnloadData)
		{
		}

		public void UnloadConnectionScenes(NetworkConnection[] connections, SceneUnloadData sceneUnloadData)
		{
		}

		public void UnloadConnectionScenes(SceneUnloadData sceneUnloadData)
		{
		}

		private void UnloadConnectionScenes_Internal(NetworkConnection[] connections, SceneUnloadData sceneUnloadData, string[] globalScenes, bool asServer)
		{
		}

		[IteratorStateMachine(typeof(_003C__UnloadScenes_003Ed__115))]
		private IEnumerator __UnloadScenes()
		{
			return null;
		}

		private void OnUnloadScenes(UnloadScenesBroadcast msg)
		{
		}

		private void MoveClientHostObjects(Scene scene, bool asServer)
		{
		}

		internal bool InSceneConnections(NetworkConnection conn, Scene scene)
		{
			return false;
		}

		public void AddOwnerToDefaultScene(NetworkObject nob)
		{
		}

		public void AddConnectionToScene(NetworkConnection conn, Scene scene)
		{
		}

		public void RemoveConnectionsFromNonGlobalScenes(NetworkConnection[] conns)
		{
		}

		public void RemoveConnectionsFromScene(NetworkConnection[] conns, Scene scene)
		{
		}

		public void RemoveAllConnectionsFromScene(Scene scene)
		{
		}

		private bool CanLoadScene(LoadQueueData qd, SceneLookupData sld)
		{
			return false;
		}

		private void RebuildObservers(IList<NetworkObject> networkObjects)
		{
		}

		internal void RebuildObservers(NetworkConnection connection)
		{
		}

		internal void RebuildObservers(IList<NetworkConnection> connections)
		{
		}

		private void InvokeClientPresenceChange(Scene scene, IList<NetworkConnection> conns, bool added, bool start)
		{
		}

		private Scene[] GetScenes(SceneLookupData[] datas)
		{
			return null;
		}

		public static Scene GetScene(string sceneName, NetworkManager nm = null, bool warnIfDuplicates = true)
		{
			return default(Scene);
		}

		public static Scene GetScene(int sceneHandle)
		{
			return default(Scene);
		}

		private bool IsGlobalScene(Scene scene)
		{
			return false;
		}

		private void CheckForDuplicateGlobalSceneNames()
		{
		}

		private void RemoveFromGlobalScenes(Scene scene)
		{
		}

		private void RemoveFromGlobalScenes(SceneLookupData[] datas)
		{
		}

		private void RemoveGlobalScenes(List<Scene> scenes)
		{
		}

		private void RemoveOccupiedScenes(List<Scene> scenes)
		{
		}

		private void AddPendingLoad(NetworkConnection conn)
		{
		}

		private void AddPendingLoad(NetworkConnection[] conns)
		{
		}

		private void SetActiveScene(Scene preferredScene = default(Scene), bool byUser = false)
		{
		}

		private Scene GetFallbackActiveScene()
		{
			return default(Scene);
		}

		private Scene GetMovedObjectsScene()
		{
			return default(Scene);
		}

		private Scene GetDelayedDestroyScene()
		{
			return default(Scene);
		}

		private Scene GetUserPreferredActiveScene(SceneLookupData sld, out bool byUser)
		{
			byUser = default(bool);
			return default(Scene);
		}

		internal bool IsIteratingQueue(float completionTimeRequirement = 0f)
		{
			return false;
		}

		private bool SceneDataInvalid(SceneLoadData data, bool error)
		{
			return false;
		}

		private bool SceneDataInvalid(SceneUnloadData data, bool error)
		{
			return false;
		}

		private bool ConnectionActive(bool asServer)
		{
			return false;
		}

		private bool CanExecute(bool asServer, bool warn)
		{
			return false;
		}
	}
}
