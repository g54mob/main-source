using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace MyStuff.UI.Notifications
{
	public class GameNotificationService : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CInitializeDelayed_003Ed__19 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public GameNotificationService _003C_003E4__this;

			private float _003CmaxWait_003E5__2;

			private float _003Celapsed_003E5__3;

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
			public _003CInitializeDelayed_003Ed__19(int _003C_003E1__state)
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

		[Header("UI Settings")]
		[SerializeField]
		private PanelSettings panelSettings;

		[SerializeField]
		private VisualTreeAsset sourceAsset;

		[SerializeField]
		private int sortOrder;

		[SerializeField]
		private StyleSheet styleSheet;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		private UIDocument uiDocument;

		private VisualElement notificationContainer;

		private bool isInitialized;

		private static readonly string[] GameScenes;

		private static bool _logAllNotifications;

		private static float _gameStartTime;

		private static float _networkReadyTime;

		private const float INITIALIZATION_GRACE_PERIOD = 3f;

		public static GameNotificationService Instance { get; private set; }

		private void Awake()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void OnDestroy()
		{
		}

		private void Start()
		{
		}

		private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
		{
		}

		[IteratorStateMachine(typeof(_003CInitializeDelayed_003Ed__19))]
		private IEnumerator InitializeDelayed()
		{
			return null;
		}

		private void InitializeUI()
		{
		}

		private void BuildNotificationUI()
		{
		}

		private void ApplyContainerStyles(VisualElement container)
		{
		}

		private void InitializeNotificationManager()
		{
		}

		private void CleanupUI()
		{
		}

		private static bool CanShowNotifications()
		{
			return false;
		}

		public static void ResetGracePeriod()
		{
		}

		private static void LogNotification(string type, string title, string message)
		{
		}

		public static void ShowSuccess(string message, float duration = 3f)
		{
		}

		public static void ShowSuccess(string title, string message, float duration = 3f)
		{
		}

		public static void ShowError(string message, float duration = 3f)
		{
		}

		public static void ShowError(string title, string message, float duration = 3f)
		{
		}

		public static void ShowWarning(string message, float duration = 3f)
		{
		}

		public static void ShowWarning(string title, string message, float duration = 3f)
		{
		}

		public static void ShowInfo(string message, float duration = 3f)
		{
		}

		public static void ShowInfo(string title, string message, float duration = 3f)
		{
		}

		public static void ClearAll()
		{
		}

		private bool IsGameScene(string sceneName)
		{
			return false;
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
		private static void AutoCreate()
		{
		}
	}
}
