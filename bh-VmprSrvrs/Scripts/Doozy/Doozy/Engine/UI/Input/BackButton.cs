using UnityEngine;

namespace Doozy.Engine.UI.Input
{
	[AddComponentMenu("Doozy/Input/Back Button", 13)]
	[DisallowMultipleComponent]
	[DefaultExecutionOrder(-200)]
	public class BackButton : MonoBehaviour
	{
		private static BackButton s_instance;

		public const bool DEFAULT_ENABLE_ALTERNATE_INPUTS = false;

		public const float BACK_BUTTON_DETECTION_DISABLE_INTERVAL = 0.2f;

		public const InputMode DEFAULT_INPUT_MODE = InputMode.VirtualButton;

		public const KeyCode DEFAULT_BACK_BUTTON_KEY_CODE = KeyCode.Escape;

		public const KeyCode DEFAULT_BACK_BUTTON_KEY_CODE_ALT = KeyCode.Backspace;

		public const string DEFAULT_BACK_BUTTON_VIRTUAL_BUTTON_NAME = "Cancel";

		public const string DEFAULT_BACK_BUTTON_VIRTUAL_BUTTON_NAME_ALT = "Cancel";

		public const string NAME = "Back";

		private static bool s_applicationIsQuitting;

		private static bool s_initialized;

		public InputData BackButtonInputData;

		public bool DebugMode;

		private int m_backButtonDisableLevel;

		private double m_lastBackButtonPressTime;

		public static BackButton Instance => null;

		public bool BackButtonDisabled => false;

		public bool CanExecuteBackButton => false;

		private bool DebugComponent => false;

		protected BackButton()
		{
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void RunOnStart()
		{
		}

		private void Reset()
		{
		}

		private void Awake()
		{
		}

		private void Update()
		{
		}

		private void OnApplicationQuit()
		{
		}

		public void Execute()
		{
		}

		public static BackButton AddToScene(bool selectGameObjectAfterCreation = false)
		{
			return null;
		}

		public static void Disable()
		{
		}

		public static void Enable()
		{
		}

		public static void EnableByForce()
		{
		}

		public static void Init()
		{
		}

		private static InputData GetBackButtonInputData()
		{
			return null;
		}
	}
}
