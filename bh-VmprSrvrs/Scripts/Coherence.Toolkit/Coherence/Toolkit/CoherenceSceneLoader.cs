using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Coherence.Connection;
using Coherence.Log;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Coherence.Toolkit
{
	[AddComponentMenu("coherence/Scene Loading/Coherence Scene Loader")]
	[NonBindable]
	public sealed class CoherenceSceneLoader : CoherenceBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CDoLoadScene_003Ed__51 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public CoherenceSceneLoader _003C_003E4__this;

			public CoherenceSceneData data;

			private int _003Cidx_003E5__2;

			private AsyncOperation _003Cop_003E5__3;

			private int _003Ci_003E5__4;

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
			public _003CDoLoadScene_003Ed__51(int _003C_003E1__state)
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
		private sealed class _003CDoUnloadScene_003Ed__50 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public CoherenceSceneLoader _003C_003E4__this;

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
			public _003CDoUnloadScene_003Ed__50(int _003C_003E1__state)
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

		private readonly Coherence.Log.Logger logger;

		private static EndpointData lastEndpointData;

		private static int loadOperations;

		internal static bool loading;

		internal static Dictionary<Scene, CoherenceSceneData> dataMap;

		internal static Dictionary<Scene, CoherenceSceneLoader> loaderMap;

		public static List<Scene> scenes;

		private Scene scene;

		[Tooltip("If enabled, the loader will load/unload on CohereceBridge connections/disconnections. Otherwise, the loader only responds to the Load/Unload API.")]
		[SerializeField]
		private bool attach;

		[Header("Scene Loading Settings")]
		public ConnectionType connectionType;

		public string sceneName;

		public LocalPhysicsMode localPhysicsMode;

		public UnloadSceneOptions unloadSceneOptions;

		public UnityEvent<CoherenceBridge> onLoaded;

		public UnityEvent<CoherenceBridge> onBeforeUnload;

		private CoherenceBridge bridge;

		private bool isEnabled;

		public bool Attach
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public Coroutine LoadingCoroutine { get; private set; }

		public Coroutine UnloadingCoroutine { get; private set; }

		public Scene Scene => default(Scene);

		private bool IsLoaded => false;

		private CoherenceSceneLoader()
		{
		}

		public static CoherenceSceneLoader CreateInstance()
		{
			return null;
		}

		public static CoherenceSceneLoader CreateInstance(string name)
		{
			return null;
		}

		public static CoherenceSceneLoader CreateInstance(GameObject go)
		{
			return null;
		}

		public CoherenceSceneLoader Configure(CoherenceSceneLoaderConfig config)
		{
			return null;
		}

		public CoherenceSceneLoader Configure(string sceneName)
		{
			return null;
		}

		public CoherenceSceneLoader Configure(string sceneName, ConnectionType connectionType)
		{
			return null;
		}

		public CoherenceSceneLoader Load(EndpointData endpointData)
		{
			return null;
		}

		public CoherenceSceneLoader Unload()
		{
			return null;
		}

		private void OnValidate()
		{
		}

		protected override void Reset()
		{
		}

		private void UpdateAttachState()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void OnConnect(ClientID _)
		{
		}

		private void OnDisconnect(ConnectionCloseReason closeReason)
		{
		}

		private void OnConnectionError(ConnectionException exception)
		{
		}

		private void OnConnectedEndpoint(EndpointData endpointData)
		{
		}

		[IteratorStateMachine(typeof(_003CDoUnloadScene_003Ed__50))]
		private IEnumerator DoUnloadScene()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CDoLoadScene_003Ed__51))]
		private IEnumerator DoLoadScene(CoherenceSceneData data)
		{
			return null;
		}
	}
}
