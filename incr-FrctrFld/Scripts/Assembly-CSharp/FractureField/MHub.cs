using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using FractureField.Managers;
using FractureField.UI;
using Reactivity;
using UnityEngine;
using UnityEngine.Localization.Settings;

namespace FractureField
{
	public class MHub : Singleton<MHub>
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CAwake_003Ed__0 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public MHub _003C_003E4__this;

			private TaskAwaiter _003C_003Eu__1;

			private TaskAwaiter<LocalizationSettings> _003C_003Eu__2;

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

		public static RBool IsPaused;

		private UnityServicesManager _unityServicesManager;

		private ClickManager _clickManager;

		private Localization _localizationManager;

		private KeyboardManager _keyboardManager;

		private ThreadManager _threadManager;

		private ExceptionManager _exceptionManager;

		private SceneManager _sceneManager;

		private PlayerPrefsManager _playerPrefsManager;

		private SoundManager _soundManager;

		private ChangelogManager _changelogManager;

		private AuthManager _authManager;

		private GameDataManager _gameDataManager;

		[SerializeField]
		private FontManager _fontManager;

		public static RBool IsInitialized { get; }

		public static DateTime LastActivity { get; set; }

		public static UnityServicesManager UnityServicesManager => null;

		public static ClickManager ClickManager => null;

		public static Localization Localization => null;

		public static KeyboardManager KeyboardManager => null;

		public static ThreadManager ThreadManager => null;

		public static ExceptionManager ExceptionManager => null;

		public static SceneManager SceneManager => null;

		public static PlayerPrefsManager PlayerPrefsManager => null;

		public static SoundManager SoundManager => null;

		public static ChangelogManager ChangelogManager => null;

		public static AuthManager AuthManager => null;

		public static GameDataManager GameDataManager => null;

		public static FontManager FontManager => null;

		[AsyncStateMachine(typeof(_003CAwake_003Ed__0))]
		protected override void Awake()
		{
		}

		private void Init()
		{
		}

		private void Update()
		{
		}

		private void FixedUpdate()
		{
		}

		private void SetLogLevels()
		{
		}

		private void OnApplicationFocus(bool hasFocus)
		{
		}

		public static void HadActivity()
		{
		}

		private static T GetStandardInstance<T>(ref T instance) where T : new()
		{
			return default(T);
		}

		private static T GetMonoInstance<T>(ref T instance) where T : Component
		{
			return null;
		}

		private static T GetInitableInstance<T>(ref T instance) where T : InitableMonoBehaviour
		{
			return null;
		}
	}
}
