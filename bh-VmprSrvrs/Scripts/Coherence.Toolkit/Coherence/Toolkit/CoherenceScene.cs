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
	[AddComponentMenu("coherence/Scene Loading/Coherence Scene")]
	[NonBindable]
	public sealed class CoherenceScene : CoherenceBehaviour
	{
		private enum EditorSceneVisibility
		{
			[InspectorName("Don't Show")]
			DontShow = 0,
			ShowOnAwake = 1,
			ShowOnConnect = 2
		}

		[CompilerGenerated]
		private sealed class _003CDoReconnect_003Ed__33 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public CoherenceScene _003C_003E4__this;

			public float delay;

			private int _003CretryCount_003E5__2;

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
			public _003CDoReconnect_003Ed__33(int _003C_003E1__state)
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

		internal static Dictionary<Scene, CoherenceScene> map;

		private PhysicsScene physicsScene;

		private PhysicsScene2D physicsScene2d;

		internal CoherenceBridge bridge;

		[Tooltip("Once enabled, connect to the replication server using the loader's provided endpoint.")]
		public bool connect;

		public float reconnectDelay;

		public int maxRetries;

		[Header("Editor Scene Visibility")]
		[SerializeField]
		private EditorSceneVisibility sceneVisibilityForClient;

		[SerializeField]
		private EditorSceneVisibility sceneVisibilityForSimulator;

		[SerializeField]
		private bool hideEditorSceneOnDisconnect;

		[Tooltip("List of GameObjects to deactivate when this CoherenceScene completes loading through a CoherenceSceneLoader.")]
		public GameObject[] deactivateOnLoad;

		public UnityEvent onLoaded;

		private Coroutine reconnectCoroutine;

		private bool connecting;

		internal bool Active => false;

		private IClient Client => null;

		public bool IsConnected => false;

		private CoherenceScene()
		{
		}

		private void Awake()
		{
		}

		private void OnEnable()
		{
		}

		private void Start()
		{
		}

		private void FixedUpdate()
		{
		}

		private void FetchPhysics()
		{
		}

		private void TryConnect()
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

		[IteratorStateMachine(typeof(_003CDoReconnect_003Ed__33))]
		private IEnumerator DoReconnect(float delay)
		{
			return null;
		}
	}
}
