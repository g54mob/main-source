using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using DG.Tweening;
using Libs;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace SceneFocus
{
	public class SceneFocusManager : SingletonMonoBehaviour<SceneFocusManager>
	{
		private enum eFocusScene
		{
			FactoryScene = 1,
			BattleScene = 2
		}

		public enum MoveFactoryOperation
		{
			None = 0,
			System = 1,
			SwitchButton = 2,
			ScrollButton = 3,
			ScrollExtend = 4
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CLoadTutorialOnInGame_003Ed__16 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public SceneFocusManager _003C_003E4__this;

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

		public const string FactorySceneMenuPath = "Development/SceneFocus/FactoryScene";

		public const string BattleSceneMenuPath = "Development/SceneFocus/BattleScene";

		private readonly Dictionary<eFocusScene, bool> _sceneLoads;

		private Dictionary<eFocusScene, SceneFocusInfo> _sceneInfos;

		private eFocusScene _activeFocusScene;

		private bool _factoryOrtho;

		private GameObject _moveCamera;

		private Camera _cameraComponent;

		public static bool IsSceneLock;

		private void Awake()
		{
		}

		private void Start()
		{
		}

		public void LoadScene(string sceneName)
		{
		}

		private void SwitchLoadSceneAtPlatform(string sceneName, LoadSceneMode mode = LoadSceneMode.Single)
		{
		}

		private void OutGameSceneLoaded(Scene thisScene, LoadSceneMode mode)
		{
		}

		public void LoadInGame()
		{
		}

		[AsyncStateMachine(typeof(_003CLoadTutorialOnInGame_003Ed__16))]
		public void LoadTutorialOnInGame()
		{
		}

		private void SceneLoaded(Scene thisScene, LoadSceneMode mode)
		{
		}

		private void SceneUnloaded(Scene prevScene)
		{
		}

		private void ActiveSceneChanged(Scene thisScene, Scene nextScene)
		{
		}

		private void LoadSceneAdditiveIfNotLoaded(string sceneName)
		{
		}

		private void AddSceneInfo(Scene scene)
		{
		}

		private void UpdateSceneFocus()
		{
		}

		private void SwitchUI()
		{
		}

		public string GetActiveScene()
		{
			return null;
		}

		private SceneFocusInfo GetActiveSceneInfo()
		{
			return null;
		}

		private SceneFocusInfo GetSceneInfo(eFocusScene focusScene)
		{
			return null;
		}

		private SceneFocusInfo GetSceneInfo(Scene scene)
		{
			return null;
		}

		public static bool IsFocusScene(Scene scene)
		{
			return false;
		}

		public static bool IsFocusScene(string sceneName)
		{
			return false;
		}

		public static Canvas GetUICanvas(Scene scene = default(Scene))
		{
			return null;
		}

		public static Canvas GetOutGameSceneCanvas()
		{
			return null;
		}

		public void ToggleFocusScene()
		{
		}

		private TransitionCameraInfo GetTransitionCameraInfo(eFocusScene focusName)
		{
			return null;
		}

		public void TransitionCamera(TransitionCameraInfo fromCamera, TransitionCameraInfo toCamera, float duration, float upHeight, UnityAction callback = null, Ease ease = Ease.InOutSine, bool isBackGround = false)
		{
		}

		public void TransitionCamera(ref Sequence sequence, TransitionCameraInfo fromCamera, TransitionCameraInfo toCamera, float duration, float upHeight, UnityAction callback = null, Ease ease = Ease.InOutSine, bool isBackground = false)
		{
		}

		public void TransitionScene(float duration, float upHeight, UnityAction callback = null)
		{
		}

		public Camera GetActiveSceneCamera()
		{
			return null;
		}

		public void MoveBattleScene(float duration = 0f, float upHeight = 0f, UnityAction callback = null)
		{
		}

		public void MoveFactoryScene(float duration = 0f, float upHeight = 0f, UnityAction callback = null)
		{
		}

		public static Vector2 GetResolutionRatio()
		{
			return default(Vector2);
		}
	}
}
