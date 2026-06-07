using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using Rewired.Config;
using Rewired.Data;
using Rewired.Platforms;
using Rewired.Utils;
using Rewired.Utils.Interfaces;
using UnityEngine;

namespace Rewired
{
	[AddComponentMenu(null)]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[ExecuteInEditMode]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	public abstract class InputManager_Base : MonoBehaviour
	{
		private enum QUoxAJmttWIyokUYauKeHTWUhRXw
		{
			Initialization = 0,
			Update = 1,
			Destroy = 2
		}

		internal struct cTcfTFkZGmYbaxIwAeCKOJmCeHrfb
		{
			public Platform wreCBRLwIbyBVGlCLaUQcsqZQxRb;

			public EditorPlatform lNpixMBnPuKIQZWWiqoJvhOjiHKZ;

			public WebplayerPlatform zRPyshZnNAOmTDJAfDcrcCgeKxpk;
		}

		private sealed class qmmpRbWiSxOnJwjLgEPHBdcaDsXI
		{
			public InputManager_Base cYzOdCKPjSIYIgAJxVuZehGiqmbmA;

			public UnityTools.EeMzBLeLNTmTALqdvIAKIfdYhceUA PMKOzIzBiopLSGVIZSVBKnNOTtos;

			public string ppqEAkxyBDWFzntdmqFOZOwzHlQr;

			internal void mbEArgLyviBJbASiWkRYqMfvUGcx(cTcfTFkZGmYbaxIwAeCKOJmCeHrfb P_0)
			{
			}

			internal UnityTools.EeMzBLeLNTmTALqdvIAKIfdYhceUA ZeCCckCPadPpmidksHOikhiYhLAS()
			{
				return default(UnityTools.EeMzBLeLNTmTALqdvIAKIfdYhceUA);
			}
		}

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _dontDestroyOnLoad;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private UserData _userData;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private ControllerDataFiles _controllerDataFiles;

		protected bool isCompiling;

		[NonSerialized]
		private bool mPjnmUdcNAdNdjdLQJnWIScJMKDaB;

		[NonSerialized]
		private bool CYxzjvczYzAmRgjUhDDfbMilcbzEA;

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
		[CustomObfuscation(rename = false)]
		protected ScriptingBackend scriptingBackend;

		[NonSerialized]
		[CustomObfuscation(rename = false)]
		protected ScriptingAPILevel scriptingAPILevel;

		[NonSerialized]
		private bool ENWhVqIeJMWIDUzZbYjlldowOuZc;

		private bool lgaFMjcuYeLtXtZRBOHSVvwqQHmkA;

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

		[CustomObfuscation(rename = false)]
		private void Awake()
		{
		}

		[CustomObfuscation(rename = false)]
		private void OnEnable()
		{
		}

		[CustomObfuscation(rename = false)]
		private void OnDisable()
		{
		}

		[CustomObfuscation(rename = false)]
		private void OnDestroy()
		{
		}

		private void qhzftSMVHFSrPufVPRpAUzyRPyTV(bool P_0)
		{
		}

		[CustomObfuscation(rename = false)]
		private void OnApplicationFocus(bool isFocused)
		{
		}

		[CustomObfuscation(rename = false)]
		private void OnApplicationPause(bool isPaused)
		{
		}

		[CustomObfuscation(rename = false)]
		private void Start()
		{
		}

		[CustomObfuscation(rename = false)]
		private void Update()
		{
		}

		[CustomObfuscation(rename = false)]
		private void FixedUpdate()
		{
		}

		[CustomObfuscation(rename = false)]
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

		private bool uOYQmplcLUacpcvjtfzLfLXTbmlt()
		{
			return false;
		}

		private void JuanJwxCSEdCpEyDivLkYBNFSMNr()
		{
		}

		private void JsqpzmVNCVaUVlFMiyKkUPUjJlGC(Platform P_0)
		{
		}

		private object qiQVhbuKtxujcokzwQzUlQzxFpm(ConfigVars P_0)
		{
			return null;
		}

		private List<Assembly> iNYeDHFfoemdacAZFeLmNerOaxoBB()
		{
			return null;
		}

		private List<Assembly> jLTNpmsbESxjPpqgqmCBQVgbhefG()
		{
			return null;
		}

		private byte[] rrgEWqHXXfBxyFnPiaXVmqdEWLcK()
		{
			return null;
		}

		private void UWZpVzRliNMmxLNOnUaJIXBqrgvn(List<TextAsset> P_0, List<string> P_1)
		{
		}

		private string SkNJJkUyDLauiCQzxdQYTNyeoOeX()
		{
			return null;
		}

		private bool keifQOBCdclsxiyefVNRoIfBYAiL()
		{
			return false;
		}

		private string xFSKUwWThBPLKKPHeTLglwngGgIh()
		{
			return null;
		}

		private bool vwRdueGlHeOizsprArmwgrTzWgKNA()
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

		private void eAmAbQiYZBdRfElJwaKelHwhIEtG(QUoxAJmttWIyokUYauKeHTWUhRXw P_0, string P_1, Exception P_2)
		{
		}

		[CustomObfuscation(rename = false)]
		internal void ResetAll()
		{
		}

		[CustomObfuscation(rename = false)]
		internal EditorPlatform GetEditorPlatform()
		{
			return default(EditorPlatform);
		}

		[CustomObfuscation(rename = false)]
		internal void GetSupportedEditModeControllerTypes(out bool keyboardSupported, out bool mouseSupported, out bool joystickSupported)
		{
			keyboardSupported = default(bool);
			mouseSupported = default(bool);
			joystickSupported = default(bool);
		}

		[CustomObfuscation(rename = false)]
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
		private bool kWomsPbUaTFogJEFBlkTIfWdNKcH(Assembly P_0)
		{
			return false;
		}
	}
}
