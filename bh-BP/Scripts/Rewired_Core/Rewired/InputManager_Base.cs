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
		private enum XlNZamiOtDjbPniLXjsqlteBHoyiA
		{
			Initialization = 0,
			Update = 1,
			Destroy = 2
		}

		internal struct rmNSveHrOvbaVJVjdcwGabOiRcCeB
		{
			public Platform xvBiMyTsTwpisPuFqShSSGmMdFED;

			public EditorPlatform oIGsXrVKPpKLpOtNRQSFLameGgjZ;

			public WebplayerPlatform shmOEEBZNZPJiSFRYxKzALUvfSUf;
		}

		private sealed class NuREWFOemLippUVMeDrHEjoago
		{
			public InputManager_Base lEEHDdSmjRIXdhNMMSCLuBixuNYLA;

			public UnityTools.PLjezcBkFGJQfWOkGFiEWPRPdDHUA AkpJZjlEirpInTWRsPbBkUpHvSRs;

			public string mXHraPhVBAWGGwWkXobSjwIcJKxr;

			internal void zylVqZDNxnAwUTgtbjbKCZFstNZk(rmNSveHrOvbaVJVjdcwGabOiRcCeB P_0)
			{
			}

			internal UnityTools.PLjezcBkFGJQfWOkGFiEWPRPdDHUA KLtcmNMFwqJMJlWrDHbgMmOVDklS()
			{
				return default(UnityTools.PLjezcBkFGJQfWOkGFiEWPRPdDHUA);
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
		private bool jWKKMvlBNZCOEjqUbxVYGkSDjpqbb;

		[NonSerialized]
		private bool HRUBHUbeMsWhgmpBYDjnvFYcCYKOA;

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
		private bool LcbZJuKiETZIeHwGUmQrJTpxddmC;

		private bool uJJVoGwWIdEuoOsKsRfKLOMtCgDkA;

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

		private void fmORTtWSHYsswlBEiTPIsiEAoZgw(bool P_0)
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

		private bool fUbycKpGLTabYnYeUiZLBelGCNMt()
		{
			return false;
		}

		private void GYDXxLbWUVPEARnWNfyswLtKzMgk()
		{
		}

		private void GVxXTsLNSfdaxiQBpQuxsbuxinY(Platform P_0)
		{
		}

		private object tHPuKEpjKyuuQrMhSYAraCuaHESV(ConfigVars P_0)
		{
			return null;
		}

		private List<Assembly> pcdZfehNajSkHFdUPShsMCBvFEHhA()
		{
			return null;
		}

		private List<Assembly> oekzkGicxHwHCyvzZIhZwnhcGqCL()
		{
			return null;
		}

		private byte[] kYPszVDdXyEUBQoSDMiXALHDbhJK()
		{
			return null;
		}

		private void BFeivOLriGMlKUrHCWUFuqhnNHSn(List<TextAsset> P_0, List<string> P_1)
		{
		}

		private string TikmjPGyDMatHNucOCmSjSEnPpZx()
		{
			return null;
		}

		private bool fLRTjPZzprkQmbvhGxATONxWlaBe()
		{
			return false;
		}

		private string cQvuiXAZFSIVxBQQLvBgBEExzJrE()
		{
			return null;
		}

		private bool eawVWLvXPnrpMyyqbVOcHpbipLtp()
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

		private void bJJaejayVERaIHKUPxMaLexaIbSo(XlNZamiOtDjbPniLXjsqlteBHoyiA P_0, string P_1, Exception P_2)
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
		private bool rnNCEmjcyESlTGxOeFnVwaawyBZJ(Assembly P_0)
		{
			return false;
		}
	}
}
