using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Doozy.Engine.Progress;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Doozy.Engine.SceneManagement
{
	[AddComponentMenu("Doozy/SceneManagement/Scene Loader", 13)]
	[DefaultExecutionOrder(-100)]
	public class SceneLoader : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CAsynchronousLoad_003Ed__59 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public SceneLoader _003C_003E4__this;

			public string sceneName;

			public LoadSceneMode mode;

			private bool _003CsceneLoadedAndReady_003E5__2;

			private bool _003CactivatingScene_003E5__3;

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
			public _003CAsynchronousLoad_003Ed__59(int _003C_003E1__state)
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
		private sealed class _003CAsynchronousLoad_003Ed__60 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public SceneLoader _003C_003E4__this;

			public int sceneBuildIndex;

			public LoadSceneMode mode;

			private bool _003CsceneLoadedAndReady_003E5__2;

			private bool _003CactivatingScene_003E5__3;

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
			public _003CAsynchronousLoad_003Ed__60(int _003C_003E1__state)
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
		private sealed class _003CSelfDestruct_003Ed__61 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public SceneLoader _003C_003E4__this;

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
			public _003CSelfDestruct_003Ed__61(int _003C_003E1__state)
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

		public const GetSceneBy DEFAULT_GET_SCENE_BY = GetSceneBy.Name;

		public const LoadSceneMode DEFAULT_LOAD_SCENE_MODE = LoadSceneMode.Single;

		public const bool DEFAULT_AUTO_SCENE_ACTIVATION = true;

		public const bool DEFAULT_SELF_DESTRUCT_AFTER_SCENE_LOADED = false;

		public const float DEFAULT_SCENE_ACTIVATION_DELAY = 0.2f;

		public const int DEFAULT_BUILD_INDEX = 0;

		public const string DEFAULT_SCENE_NAME = "";

		public static readonly List<SceneLoader> Database;

		public bool AllowSceneActivation;

		public bool DebugMode;

		public SceneLoadBehavior LoadBehavior;

		public GetSceneBy GetSceneBy;

		public LoadSceneMode LoadSceneMode;

		public ProgressEvent OnProgressChanged;

		public ProgressEvent OnInverseProgressChanged;

		public Progressor Progressor;

		public float SceneActivationDelay;

		public int SceneBuildIndex;

		public string SceneName;

		public bool SelfDestructAfterSceneLoaded;

		private bool m_loadInProgress;

		private bool m_sceneLoadedAndReady;

		private bool m_activatingScene;

		private float m_sceneLoadedAndReadyTime;

		private float m_progress;

		public AsyncOperation CurrentAsyncOperation { get; private set; }

		public float InverseProgress => 0f;

		public float Progress
		{
			get
			{
				return 0f;
			}
			private set
			{
			}
		}

		private bool DebugComponent => false;

		private void Reset()
		{
		}

		private void Awake()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDestroy()
		{
		}

		private void Update()
		{
		}

		public void ActivateLoadedScene()
		{
		}

		public void LoadSceneAsync()
		{
		}

		public Progressor LoadSceneAsync(int sceneBuildIndex, LoadSceneMode mode)
		{
			return null;
		}

		public Progressor LoadSceneAsync(string sceneName, LoadSceneMode mode)
		{
			return null;
		}

		public void LoadSceneAsyncAdditive(int sceneBuildIndex)
		{
		}

		public void LoadSceneAsyncAdditive(string sceneName)
		{
		}

		public void LoadSceneAsyncSingle(int sceneBuildIndex)
		{
		}

		public void LoadSceneAsyncSingle(string sceneName)
		{
		}

		public SceneLoader SetAllowSceneActivation(bool allowSceneActivation)
		{
			return null;
		}

		public SceneLoader SetLoadSceneBy(GetSceneBy getSceneBy)
		{
			return null;
		}

		public SceneLoader SetLoadSceneMode(LoadSceneMode loadSceneMode)
		{
			return null;
		}

		public SceneLoader SetProgressor(Progressor progressor)
		{
			return null;
		}

		public SceneLoader SetSceneActivationDelay(float sceneActivationDelay)
		{
			return null;
		}

		public SceneLoader SetSceneBuildIndex(int sceneBuildIndex)
		{
			return null;
		}

		public SceneLoader SetSceneName(string sceneName)
		{
			return null;
		}

		public SceneLoader SetSelfDestructAfterSceneLoaded(bool selfDestruct)
		{
			return null;
		}

		private void ResetProgress()
		{
		}

		private void StartSceneLoad()
		{
		}

		[IteratorStateMachine(typeof(_003CAsynchronousLoad_003Ed__59))]
		private IEnumerator AsynchronousLoad(string sceneName, LoadSceneMode mode)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CAsynchronousLoad_003Ed__60))]
		private IEnumerator AsynchronousLoad(int sceneBuildIndex, LoadSceneMode mode)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CSelfDestruct_003Ed__61))]
		private IEnumerator SelfDestruct()
		{
			return null;
		}

		public static void ActivateLoadedScenes()
		{
		}

		public static SceneLoader GetLoader(Transform parent = null)
		{
			return null;
		}

		private static SceneLoader AddToScene(bool selectGameObjectAfterCreation = false)
		{
			return null;
		}

		private static void RemoveNullReferencesFromDatabase()
		{
		}
	}
}
