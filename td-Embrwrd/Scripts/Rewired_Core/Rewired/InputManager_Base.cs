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
	[ExecuteInEditMode]
	[AddComponentMenu(null)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public abstract class InputManager_Base : MonoBehaviour
	{
		private enum DHnQRJvDeZFVwAZSJqSKNWvmXHSE
		{
			Initialization = 0,
			Update = 1,
			Destroy = 2
		}

		internal struct rxrZVQSepEQagapnoyyHzwwHNuS
		{
			public Platform fbxdGPeSCqGNRdmkgoImouqqlEmUb;

			public EditorPlatform sicctQAFhxIxGApXLEYzgbUiTJPxb;

			public WebplayerPlatform cKImsnChvVVxFvLJUMbRoacGLSit;
		}

		private sealed class lgxStpPRsgLzFEbANhqfJDaKRBWp
		{
			public InputManager_Base zDiriGDuLXbkEeGSCDKhvAKIFicaA;

			public UnityTools.PiLPbHlhwYsdUvbqAeFitwleenxJ QGLdTCoVIjigCgwBcpNbOFTwdbjl;

			public string wWlbYaixrOhufDsqRgpsBoyJipZV;

			internal void jYJGtcOMFtPsxyglppbqwWdFvExX(rxrZVQSepEQagapnoyyHzwwHNuS P_0)
			{
			}

			internal UnityTools.PiLPbHlhwYsdUvbqAeFitwleenxJ ELZPKgLyKwayaMEjZBlIsScsgNXGA()
			{
				return default(UnityTools.PiLPbHlhwYsdUvbqAeFitwleenxJ);
			}
		}

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private bool _dontDestroyOnLoad;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private UserData _userData;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private ControllerDataFiles _controllerDataFiles;

		protected bool isCompiling;

		[NonSerialized]
		private bool zwgayQsPpLmLtPqYlBWuIlewALIi;

		[NonSerialized]
		private bool TlwhObjqmsZhDARUUrKVzgcPjLcD;

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
		private bool ZiZytcFlIVMlJgAaMzgVbZtYdOSy;

		private bool cDbIlLfgDpOBZlIxunRmjkrYVutd;

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

		private void tlkBfQXKfQgEPWjIezTwQMatRmKw(bool P_0)
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

		private bool bvZIOxkPxNJNpMawYYLxvrZdBmeu()
		{
			return false;
		}

		private void WzzkvkqOaXenjAqGXKrQoWHbqIAUA()
		{
		}

		private void SadWngSlzOiVNNxANDSWKlPFXtLm(Platform P_0)
		{
		}

		private object lovgEzCcsqZClsIpGWKNuAYPopucb(ConfigVars P_0)
		{
			return null;
		}

		private List<Assembly> lYHDJrqAujOmRkIeJzOOclTIlrPb()
		{
			return null;
		}

		private List<Assembly> eiIgDdhlXBMUxNDvLuItDQPZOjoHb()
		{
			return null;
		}

		private byte[] sbjiCqCvxmtqkpnUBJGryNdmkQzN()
		{
			return null;
		}

		private void JdABLlIVACZohtaHEStpYrDYaNqI(List<TextAsset> P_0, List<string> P_1)
		{
		}

		private string LFODFaBXjOFqqcevOgIcRCeKEMzi()
		{
			return null;
		}

		private bool tRrUjKOKPvHOpUPhSGlpkgblgUveA()
		{
			return false;
		}

		private string guVXWcVtjYgeUmoQZZlYdugWhART()
		{
			return null;
		}

		private bool qQuwkjudhOZjMBknjMMepRXVwFBb()
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

		private void pLpNUUfxlQEOzyCABtIYjEXTmAkp(DHnQRJvDeZFVwAZSJqSKNWvmXHSE P_0, string P_1, Exception P_2)
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
		private bool jPjmyXkBGAysszeEeSZlCzWLEXjO(Assembly P_0)
		{
			return false;
		}
	}
}
