using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using Rewired.Config;
using Rewired.Data;
using Rewired.Platforms;
using Rewired.Utils.Interfaces;
using UnityEngine;

namespace Rewired
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	[AddComponentMenu(null)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	[ExecuteInEditMode]
	public abstract class InputManager_Base : MonoBehaviour
	{
		private enum vSlpBALotLzaTayEYTspieQSXNk
		{
			DFVejmDoGBnCUpoxERTmrmbqALm = 0,
			oDVbwUgIfbSDvfmIInVcyfSKnKRm = 1,
			RYlaFMvCJnQGkygVuIgNKJLLfMA = 2
		}

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private bool _dontDestroyOnLoad;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private UserData _userData;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private ControllerDataFiles _controllerDataFiles;

		protected bool isCompiling;

		[NonSerialized]
		private bool yguPpeqEjThrBNXEFhOahcAYtXtO;

		[NonSerialized]
		private bool kSmIeORmPDaJIEDwqJRuefDHeRBD;

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
		private bool xIQUatGYulgQQJnHEdAsPEBKubc;

		private bool SAWHgPpnCSCbPrBntAnmYRseBpwI;

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

		[CustomObfuscation(rename = false)]
		private void OnApplicationFocus(bool isFocused)
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

		private bool UaJBVQOUDUjqFLAKOAgEkAAtpuwy()
		{
			return false;
		}

		private void yevEaEOpxaTseresMwWwEaZGFmnj()
		{
		}

		private object ECLrUsNMFActyeaQIdGtJwwXMUY(ConfigVars P_0)
		{
			return null;
		}

		private List<Assembly> OkGTZStboFEWBWSloHcXRkfDdmK()
		{
			return null;
		}

		private List<Assembly> jVgycbbNcxQTcxFaCIavaQXjBZsk()
		{
			return null;
		}

		private byte[] UrVusqjxKRcbpcIJRDamcnsQJjP()
		{
			return null;
		}

		private void lHlKfsmIIkdbfftERFFYEnZqWqr(List<TextAsset> P_0, List<string> P_1)
		{
		}

		private string XNObOFAwaRNbpigbiFVMgflJpzqL()
		{
			return null;
		}

		private bool guwQkghfpzKOocsVmWIWYfopkfN()
		{
			return false;
		}

		private string MSdbkWkBYielebABhwtkjyweIuCk()
		{
			return null;
		}

		private bool pmVpKlmzeyPssdHPOhpsrTQtudX()
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

		private void pTYCVUSxrLgmJrXTbmxhYgTdjHh(vSlpBALotLzaTayEYTspieQSXNk P_0, string P_1, Exception P_2)
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
		private bool VNTQGFUjuKqhnzDtfJqRfZkysIb(Assembly P_0)
		{
			return false;
		}
	}
}
