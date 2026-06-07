using System;
using System.Collections.Generic;
using System.Reflection;
using Rewired.Config;
using Rewired.Data;
using Rewired.Platforms;
using Rewired.Utils.Interfaces;
using UnityEngine;

namespace Rewired
{
	[ExecuteInEditMode]
	public abstract class InputManager_Base : MonoBehaviour
	{
		private enum ExceptionPoint
		{
			Initialization = 0,
			Update = 1,
			Destroy = 2
		}

		[SerializeField]
		[CustomObfuscation]
		private bool _dontDestroyOnLoad;

		[SerializeField]
		[CustomObfuscation]
		private UserData _userData;

		[CustomObfuscation]
		[SerializeField]
		private ControllerDataFiles _controllerDataFiles;

		protected bool isCompiling;

		[NonSerialized]
		private bool initialized;

		[NonSerialized]
		private bool criticalError;

		[NonSerialized]
		protected EditorPlatform editorPlatform;

		[NonSerialized]
		protected Platform platform;

		[NonSerialized]
		protected WebplayerPlatform webplayerPlatform;

		[NonSerialized]
		protected bool isEditor;

		[NonSerialized]
		protected bool _detectedPlatformInEditor;

		[NonSerialized]
		[CustomObfuscation]
		protected ScriptingBackend scriptingBackend;

		[NonSerialized]
		[CustomObfuscation]
		protected ScriptingAPILevel scriptingAPILevel;

		[NonSerialized]
		private bool _duplicateRIMError;

		private bool _isAwake;

		public UserData userData
		{
			get
			{
				return null;
			}
			internal set
			{
			}
		}

		public ControllerDataFiles dataFiles
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool runInEditMode
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		internal bool isRunningInEditMode => false;

		[CustomObfuscation]
		private void Awake()
		{
		}

		[CustomObfuscation]
		private void OnEnable()
		{
		}

		[CustomObfuscation]
		private void OnDisable()
		{
		}

		[CustomObfuscation]
		private void OnDestroy()
		{
		}

		[CustomObfuscation]
		private void OnApplicationFocus(bool isFocused)
		{
		}

		[CustomObfuscation]
		private void Start()
		{
		}

		[CustomObfuscation]
		private void Update()
		{
		}

		[CustomObfuscation]
		private void FixedUpdate()
		{
		}

		[CustomObfuscation]
		private void LateUpdate()
		{
		}

		internal void OnGUIUpdate()
		{
		}

		internal void DoUpdate(UpdateLoopType updateLoopType, UpdateLoopSetting updateLoopSettingBit)
		{
		}

		internal void TryStartRunInEditMode()
		{
		}

		internal void TryStopRunInEditMode()
		{
		}

		private bool ManualInitialize()
		{
			return false;
		}

		private void Initialize()
		{
		}

		private object InitializePlatform(ConfigVars configVars)
		{
			return null;
		}

		private List<Assembly> GetNativeAssembliesFromResources()
		{
			return null;
		}

		private List<Assembly> GetNativeAssembliesByReflection()
		{
			return null;
		}

		private byte[] GetNativeDLLBytesByReflection()
		{
			return null;
		}

		private void AddTextAssetInResourcesToList(List<TextAsset> list, List<string> dllPaths)
		{
		}

		private string SetPlatformToEditorPlatform()
		{
			return null;
		}

		private bool CheckEditorPlatformMatches()
		{
			return false;
		}

		private string GetPlatformSpecificAssemblyName()
		{
			return null;
		}

		private bool IsOnlyManagerInScene()
		{
			return false;
		}

		protected void RecompileStart()
		{
		}

		protected void RecompileEnd()
		{
		}

		protected void OnSceneLoaded()
		{
		}

		private void HandleException(ExceptionPoint location, string message, Exception exception)
		{
		}

		[CustomObfuscation]
		internal void ResetAll()
		{
		}

		[CustomObfuscation]
		internal EditorPlatform GetEditorPlatform()
		{
			return default(EditorPlatform);
		}

		[CustomObfuscation]
		internal void GetSupportedEditModeControllerTypes(out bool keyboardSupported, out bool mouseSupported, out bool joystickSupported)
		{
			keyboardSupported = default(bool);
			mouseSupported = default(bool);
			joystickSupported = default(bool);
		}

		[CustomObfuscation]
		internal bool IsEditModeSupported()
		{
			return false;
		}

		protected abstract void OnInitialized();

		protected abstract void OnDeinitialized();

		protected abstract void DetectPlatform();

		protected abstract void CheckRecompile();

		protected abstract IExternalTools GetExternalTools();
	}
}
