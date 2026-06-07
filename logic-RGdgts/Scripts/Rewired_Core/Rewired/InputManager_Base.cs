using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using Rewired.Config;
using Rewired.Data;
using Rewired.Platforms;
using Rewired.Utils.Interfaces;
using UnityEngine;

namespace Rewired
{
	[ExecuteInEditMode]
	[CustomClassObfuscation]
	public abstract class InputManager_Base : MonoBehaviour
	{
		private enum thzaoRJnuxVjvmKWTlrsyfNPMaxo
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
		private bool qumTafanxrjKbDduWdypwIzXqmiP;

		[NonSerialized]
		private bool sGaDvFbNLfpBsBJIferlEnsEIsYbB;

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
		private bool fzSBHdEeAXyyqDrZBJULNfpVFNdo;

		private bool QrYfdYHdSqNhzyhPeEFnQGBvvQjUA;

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

		internal void DontDestroyOnLoad()
		{
		}

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

		private bool WXwCRINPoxizDNwFTMFIGjmeZxX()
		{
			return false;
		}

		private void gUxczTgMdKUcYRnCXamteWaCXJodc()
		{
		}

		private void yvdRLahAddvVsmRrdauiQLnpgsAr(Platform P_0)
		{
		}

		private object MSVcyNVXGaAiTeNOXFFTgXVSChPZA(ConfigVars P_0)
		{
			return null;
		}

		private List<Assembly> IXOSEThGkbMzpWFRlxYKDPGAMgPH()
		{
			return null;
		}

		private List<Assembly> pispvgdVkDqHMlPWXoOaSGeixyrm()
		{
			return null;
		}

		private byte[] KDHdDnjCGnudZgSfCMuvsRUNQzIe()
		{
			return null;
		}

		private void tXvcJmkrEOWjRxyTAEpBILGpNdtx(List<TextAsset> P_0, List<string> P_1)
		{
		}

		private string NyAGZKiLivulNgrHlEpHtTQmSOzv()
		{
			return null;
		}

		private bool mGmPRxlUzHWdSsWGraTTCUNqRaQl()
		{
			return false;
		}

		private string SdnIpNNAISmjUYLdzIPxckXRgLLTA()
		{
			return null;
		}

		private bool hyHcuKoyFMLWkhzKPFpclzsiJQiB()
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

		private void dEOSZfMrSdahsbvreYeeAqIuwEad(thzaoRJnuxVjvmKWTlrsyfNPMaxo P_0, string P_1, Exception P_2)
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

		[CompilerGenerated]
		private bool MMnQcuwljlegpihdmgxwdqRKZDozA(Assembly P_0)
		{
			return false;
		}
	}
}
