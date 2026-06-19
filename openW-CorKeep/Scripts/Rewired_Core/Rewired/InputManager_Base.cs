using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using Rewired.Config;
using Rewired.Data;
using Rewired.Internal;
using Rewired.Platforms;
using Rewired.Utils;
using Rewired.Utils.Interfaces;
using UnityEngine;

namespace Rewired
{
	[AddComponentMenu("")]
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
				lEEHDdSmjRIXdhNMMSCLuBixuNYLA.platform = P_0.xvBiMyTsTwpisPuFqShSSGmMdFED;
				lEEHDdSmjRIXdhNMMSCLuBixuNYLA.editorPlatform = P_0.oIGsXrVKPpKLpOtNRQSFLameGgjZ;
				lEEHDdSmjRIXdhNMMSCLuBixuNYLA.webplayerPlatform = P_0.shmOEEBZNZPJiSFRYxKzALUvfSUf;
				AkpJZjlEirpInTWRsPbBkUpHvSRs.YcIFSYCNiADtdLnKqTzbFXaOBVMmA = P_0.xvBiMyTsTwpisPuFqShSSGmMdFED;
				AkpJZjlEirpInTWRsPbBkUpHvSRs.GEghAnAkLKBSIPlsUnModuFNbQpLA = P_0.oIGsXrVKPpKLpOtNRQSFLameGgjZ;
				AkpJZjlEirpInTWRsPbBkUpHvSRs.bRXuMJVZiPPbIwEwImjSmkSmlsGH = P_0.shmOEEBZNZPJiSFRYxKzALUvfSUf;
				UnityTools.mpTsyjCONOEMkUHJcHNjQreTdBSb(AkpJZjlEirpInTWRsPbBkUpHvSRs);
				mXHraPhVBAWGGwWkXobSjwIcJKxr = null;
			}

			internal UnityTools.PLjezcBkFGJQfWOkGFiEWPRPdDHUA KLtcmNMFwqJMJlWrDHbgMmOVDklS()
			{
				return AkpJZjlEirpInTWRsPbBkUpHvSRs;
			}
		}

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _dontDestroyOnLoad = true;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private UserData _userData = new UserData();

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
		protected ScriptingBackend scriptingBackend = ScriptingBackend.DotNet;

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
				return _userData;
			}
			internal set
			{
				_userData = value;
			}
		}

		public ControllerDataFiles dataFiles
		{
			get
			{
				return _controllerDataFiles;
			}
			set
			{
				if (ReInput.isReady)
				{
					Logger.LogError("Controller Data Files cannot be set while Rewired is initialized. Disable the GameObject or the Input Manager component before setting this value.");
				}
				else
				{
					_controllerDataFiles = value;
				}
			}
		}

		public bool runInEditMode
		{
			get
			{
				return _userData.ConfigVars.runInEditMode;
			}
			set
			{
				_userData.ConfigVars.runInEditMode = value;
				if (!Application.isPlaying && UnityTools.IsActiveAndEnabled(this) && UnityTools.IsObjectInScene(this))
				{
					if (value)
					{
						TryStartRunInEditMode();
					}
					else
					{
						TryStopRunInEditMode();
					}
				}
			}
		}

		internal bool isRunningInEditMode
		{
			get
			{
				if (ReInput.isRunningInEditMode)
				{
					return ReInput.rewiredInputManager == this;
				}
				return false;
			}
		}

		internal void DontDestroyOnLoad()
		{
			_dontDestroyOnLoad = true;
			if (_dontDestroyOnLoad && Application.isPlaying)
			{
				UnityEngine.Object.DontDestroyOnLoad(base.transform.root.gameObject);
			}
		}

		[CustomObfuscation(rename = false)]
		private void Awake()
		{
			uJJVoGwWIdEuoOsKsRfKLOMtCgDkA = true;
			if ((Application.isPlaying || _userData.ConfigVars.runInEditMode) && base.enabled)
			{
				GYDXxLbWUVPEARnWNfyswLtKzMgk();
			}
		}

		[CustomObfuscation(rename = false)]
		private void OnEnable()
		{
			if ((Application.isPlaying || _userData.ConfigVars.runInEditMode) && (!Application.isPlaying || uJJVoGwWIdEuoOsKsRfKLOMtCgDkA) && !jWKKMvlBNZCOEjqUbxVYGkSDjpqbb && !HRUBHUbeMsWhgmpBYDjnvFYcCYKOA)
			{
				fUbycKpGLTabYnYeUiZLBelGCNMt();
			}
		}

		[CustomObfuscation(rename = false)]
		private void OnDisable()
		{
			if (Application.isPlaying || _userData.ConfigVars.runInEditMode)
			{
				fmORTtWSHYsswlBEiTPIsiEAoZgw(true);
			}
		}

		[CustomObfuscation(rename = false)]
		private void OnDestroy()
		{
			fmORTtWSHYsswlBEiTPIsiEAoZgw(false);
		}

		private void fmORTtWSHYsswlBEiTPIsiEAoZgw(bool P_0)
		{
			jWKKMvlBNZCOEjqUbxVYGkSDjpqbb = false;
			LcbZJuKiETZIeHwGUmQrJTpxddmC = false;
			HRUBHUbeMsWhgmpBYDjnvFYcCYKOA = false;
			try
			{
				if (ReInput.rewiredInputManager == this)
				{
					ReInput.irGsUSXAeSTYWVGMphFsSmZHHAEL();
				}
			}
			catch (Exception ex)
			{
				bJJaejayVERaIHKUPxMaLexaIbSo(XlNZamiOtDjbPniLXjsqlteBHoyiA.Destroy, "destruction", ex);
			}
			OnDeinitialized();
		}

		[CustomObfuscation(rename = false)]
		private void OnApplicationFocus(bool isFocused)
		{
			if (!LcbZJuKiETZIeHwGUmQrJTpxddmC)
			{
				ReInput.dVKBDhAmhophYPUjjfFFSpDcBCMYA(isFocused);
				_ = jWKKMvlBNZCOEjqUbxVYGkSDjpqbb;
			}
		}

		[CustomObfuscation(rename = false)]
		private void OnApplicationPause(bool isPaused)
		{
			if (!LcbZJuKiETZIeHwGUmQrJTpxddmC)
			{
				ReInput.ZEDceSIrGxKKKNrCZZjurBLuhodsA(isPaused);
				_ = jWKKMvlBNZCOEjqUbxVYGkSDjpqbb;
			}
		}

		[CustomObfuscation(rename = false)]
		private void Start()
		{
			if ((!UnityTools.isEditor || Application.isPlaying) && jWKKMvlBNZCOEjqUbxVYGkSDjpqbb && !HRUBHUbeMsWhgmpBYDjnvFYcCYKOA)
			{
				ReInput.AMdXkHmanjgfeVCMqEbzckEPNxAF();
			}
		}

		[CustomObfuscation(rename = false)]
		private void Update()
		{
			if (jWKKMvlBNZCOEjqUbxVYGkSDjpqbb && !HRUBHUbeMsWhgmpBYDjnvFYcCYKOA && (!UnityTools.isEditor || Application.isPlaying) && _userData.ConfigVars.updateMode != UpdateMode.Manual)
			{
				DoUpdate(UpdateLoopType.Update, UpdateLoopSetting.Update);
			}
		}

		[CustomObfuscation(rename = false)]
		private void FixedUpdate()
		{
			if (jWKKMvlBNZCOEjqUbxVYGkSDjpqbb && !HRUBHUbeMsWhgmpBYDjnvFYcCYKOA && (!UnityTools.isEditor || Application.isPlaying) && _userData.ConfigVars.updateMode != UpdateMode.Manual)
			{
				DoUpdate(UpdateLoopType.FixedUpdate, UpdateLoopSetting.FixedUpdate);
			}
		}

		[CustomObfuscation(rename = false)]
		private void LateUpdate()
		{
			if (!jWKKMvlBNZCOEjqUbxVYGkSDjpqbb || HRUBHUbeMsWhgmpBYDjnvFYcCYKOA || (UnityTools.isEditor && !Application.isPlaying))
			{
				return;
			}
			try
			{
				ReInput.SalZczvFHhxhnRCskmYPUpRyinWp();
			}
			catch (Exception ex)
			{
				bJJaejayVERaIHKUPxMaLexaIbSo(XlNZamiOtDjbPniLXjsqlteBHoyiA.Update, "update (Late Update)", ex);
			}
		}

		internal void OnGUIUpdate()
		{
			if (jWKKMvlBNZCOEjqUbxVYGkSDjpqbb && !HRUBHUbeMsWhgmpBYDjnvFYcCYKOA && (!UnityTools.isEditor || Application.isPlaying) && _userData.ConfigVars.updateMode != UpdateMode.Manual && (_userData.ConfigVars.updateLoop & UpdateLoopSetting.OnGUI) != UpdateLoopSetting.None)
			{
				DoUpdate(UpdateLoopType.OnGUI, UpdateLoopSetting.OnGUI);
			}
		}

		internal void DoUpdate(UpdateLoopType updateLoopType, UpdateLoopSetting updateLoopSettingBit)
		{
			if (!jWKKMvlBNZCOEjqUbxVYGkSDjpqbb || HRUBHUbeMsWhgmpBYDjnvFYcCYKOA)
			{
				return;
			}
			try
			{
				CheckRecompile();
				ReInput.msFBLZCqCBXHhLrSqeceZsenpLKHA(updateLoopType);
				if ((_userData.ConfigVars.updateLoop & updateLoopSettingBit) != UpdateLoopSetting.None)
				{
					ReInput.wRaTeXGcZHEYBNqBWGQxftVeUUbFA(updateLoopType);
				}
			}
			catch (Exception ex)
			{
				bJJaejayVERaIHKUPxMaLexaIbSo(XlNZamiOtDjbPniLXjsqlteBHoyiA.Update, "update (" + updateLoopType.ToString() + ")", ex);
			}
		}

		internal void TryStartRunInEditMode()
		{
			if (jWKKMvlBNZCOEjqUbxVYGkSDjpqbb || !Application.isEditor || Application.isPlaying)
			{
				return;
			}
			if (ReInput.isReady)
			{
				Logger.LogWarning("Rewired is already running in Edit mode. Do you have multiple Rewired Input Managers in the scene? If you want to run this Rewired Input Manager, you must stop the one currently running first.");
				return;
			}
			if (_userData.ConfigVars.alwaysUseUnityInput)
			{
				Logger.LogWarning("Rewired cannot run in Edit mode when native input is disabled.");
				return;
			}
			if (!IsEditModeSupported())
			{
				Logger.LogWarning("Rewired cannot run in Edit mode on this editor platform with the current settings.");
				return;
			}
			string text = null;
			GetSupportedEditModeControllerTypes(out var keyboardSupported, out var mouseSupported, out var joystickSupported);
			if (!keyboardSupported)
			{
				if (!string.IsNullOrEmpty(text))
				{
					text += ", ";
				}
				text += "Keyboard";
			}
			if (!mouseSupported)
			{
				if (!string.IsNullOrEmpty(text))
				{
					text += ", ";
				}
				text += "Mouse";
			}
			if (!joystickSupported)
			{
				if (!string.IsNullOrEmpty(text))
				{
					text += ", ";
				}
				text += "Joystick";
			}
			if (!string.IsNullOrEmpty(text))
			{
				Logger.LogWarning("The current editor platform and/or input source settings do not support the following input devices in Edit mode:\n" + text);
			}
			LcbZJuKiETZIeHwGUmQrJTpxddmC = false;
			fUbycKpGLTabYnYeUiZLBelGCNMt();
		}

		internal void TryStopRunInEditMode()
		{
			if (Application.isEditor && !Application.isPlaying && ReInput.isReady)
			{
				fmORTtWSHYsswlBEiTPIsiEAoZgw(false);
			}
		}

		private bool fUbycKpGLTabYnYeUiZLBelGCNMt()
		{
			if (jWKKMvlBNZCOEjqUbxVYGkSDjpqbb)
			{
				return true;
			}
			GYDXxLbWUVPEARnWNfyswLtKzMgk();
			if (jWKKMvlBNZCOEjqUbxVYGkSDjpqbb)
			{
				ReInput.AMdXkHmanjgfeVCMqEbzckEPNxAF();
			}
			return jWKKMvlBNZCOEjqUbxVYGkSDjpqbb;
		}

		private void GYDXxLbWUVPEARnWNfyswLtKzMgk()
		{
			NuREWFOemLippUVMeDrHEjoago nuREWFOemLippUVMeDrHEjoago = new NuREWFOemLippUVMeDrHEjoago();
			nuREWFOemLippUVMeDrHEjoago.lEEHDdSmjRIXdhNMMSCLuBixuNYLA = this;
			if (LcbZJuKiETZIeHwGUmQrJTpxddmC)
			{
				return;
			}
			try
			{
				if (!eawVWLvXPnrpMyyqbVOcHpbipLtp())
				{
					return;
				}
				if (_dontDestroyOnLoad && Application.isPlaying)
				{
					UnityEngine.Object.DontDestroyOnLoad(base.transform.root.gameObject);
				}
				DetectPlatform();
				if (_userData == null || _userData.ConfigVars == null || _controllerDataFiles == null)
				{
					Logger.LogError("Error! DataFiles is missing or corrupt! Make sure you have the DataFiles file linked in the inspector.");
					return;
				}
				if ((_userData.ConfigVars.updateLoop & UpdateLoopSetting.Update) == 0)
				{
					userData.ConfigVars.updateLoop |= UpdateLoopSetting.Update;
				}
				if (_userData.ConfigVars.updateMode == UpdateMode.Manual)
				{
					userData.ConfigVars.updateLoop = UpdateLoopSetting.Update;
				}
				if ((_userData.ConfigVars.updateLoop & UpdateLoopSetting.OnGUI) == UpdateLoopSetting.OnGUI && base.gameObject.GetComponent<OnGUIHelper>() == null)
				{
					OnGUIHelper onGUIHelper = base.gameObject.AddComponent<OnGUIHelper>();
					onGUIHelper.hideFlags = HideFlags.HideAndDontSave;
					onGUIHelper.hideFlags |= HideFlags.HideInInspector;
				}
				Platform platform = this.platform;
				nuREWFOemLippUVMeDrHEjoago.mXHraPhVBAWGGwWkXobSjwIcJKxr = TikmjPGyDMatHNucOCmSjSEnPpZx();
				nuREWFOemLippUVMeDrHEjoago.AkpJZjlEirpInTWRsPbBkUpHvSRs = new UnityTools.PLjezcBkFGJQfWOkGFiEWPRPdDHUA(platform, this.platform, editorPlatform, isEditor, webplayerPlatform, scriptingBackend, scriptingAPILevel, GetExternalTools());
				Action<rmNSveHrOvbaVJVjdcwGabOiRcCeB> action = nuREWFOemLippUVMeDrHEjoago.zylVqZDNxnAwUTgtbjbKCZFstNZk;
				UnityTools.mpTsyjCONOEMkUHJcHNjQreTdBSb(nuREWFOemLippUVMeDrHEjoago.AkpJZjlEirpInTWRsPbBkUpHvSRs);
				ReInput.ITYVXfWNUvZsqgBWGBmwuEziMFDL(this, tHPuKEpjKyuuQrMhSYAraCuaHESV, _userData.ConfigVars, _controllerDataFiles, _userData, nuREWFOemLippUVMeDrHEjoago.KLtcmNMFwqJMJlWrDHbgMmOVDklS, GVxXTsLNSfdaxiQBpQuxsbuxinY, action);
				jWKKMvlBNZCOEjqUbxVYGkSDjpqbb = true;
				HRUBHUbeMsWhgmpBYDjnvFYcCYKOA = false;
				if (!string.IsNullOrEmpty(nuREWFOemLippUVMeDrHEjoago.mXHraPhVBAWGGwWkXobSjwIcJKxr))
				{
					Logger.LogWarning(nuREWFOemLippUVMeDrHEjoago.mXHraPhVBAWGGwWkXobSjwIcJKxr);
				}
				OnInitialized();
			}
			catch (Exception ex)
			{
				bJJaejayVERaIHKUPxMaLexaIbSo(XlNZamiOtDjbPniLXjsqlteBHoyiA.Initialization, "initialization", ex);
			}
		}

		private void GVxXTsLNSfdaxiQBpQuxsbuxinY(Platform P_0)
		{
			platform = P_0;
		}

		private object tHPuKEpjKyuuQrMhSYAraCuaHESV(ConfigVars P_0)
		{
			List<Assembly> list = ((UnityTools.unityVersion >= UnityTools.UnityVersion.UNITY_5_0) ? null : pcdZfehNajSkHFdUPShsMCBvFEHhA());
			return nxoVcwPrvygPTyngCHqYYYXbiBMC.wxxMYQrsAkYJzqBMnKZWJhItsNTR(cQvuiXAZFSIVxBQQLvBgBEExzJrE(), list, P_0);
		}

		private List<Assembly> pcdZfehNajSkHFdUPShsMCBvFEHhA()
		{
			List<TextAsset> list = new List<TextAsset>();
			BFeivOLriGMlKUrHCWUFuqhnNHSn(list, UnityTools.GetCurrentPlatformResourecesDLLPaths());
			List<Assembly> list2 = new List<Assembly>();
			int count = list.Count;
			for (int i = 0; i < count; i++)
			{
				if (!(list[i] == null))
				{
					Assembly item = Assembly.Load(list[i].bytes);
					list2.Add(item);
				}
			}
			if (list2 == null || list2.Count == 0)
			{
				return null;
			}
			return list2;
		}

		private List<Assembly> oekzkGicxHwHCyvzZIhZwnhcGqCL()
		{
			bool flag = false;
			try
			{
				if (string.IsNullOrEmpty(cQvuiXAZFSIVxBQQLvBgBEExzJrE()))
				{
					return null;
				}
				Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
				if (assemblies == null)
				{
					flag = true;
					throw new Exception();
				}
				Assembly assembly = Array.Find(assemblies, (Assembly P_0) => string.Equals(P_0.GetName().Name, cQvuiXAZFSIVxBQQLvBgBEExzJrE(), StringComparison.OrdinalIgnoreCase));
				if (assembly == null)
				{
					flag = true;
					throw new Exception();
				}
				return new List<Assembly> { assembly };
			}
			catch
			{
				if (flag)
				{
					Logger.LogError("Failed to initialize native input libraries. Falling back to Unity input. Controllers support will be limited and many special features will not be available. " + (UnityTools.isStandalonePlatform ? "If this is an IL2CPP build, Rewired does not support native input in an IL2CPP Standalone build at this time due to technical issues. This issue is being worked on." : ""));
				}
				return null;
			}
		}

		private byte[] kYPszVDdXyEUBQoSDMiXALHDbhJK()
		{
			try
			{
				string text = cQvuiXAZFSIVxBQQLvBgBEExzJrE();
				if (string.IsNullOrEmpty(text))
				{
					return null;
				}
				string assemblyName = text + "_Lib";
				string classPath = "Rewired.Internal.PlatformDLL";
				if (!ReflectionTools.IsAssemblyLoaded(assemblyName, useShortName: true, ignoreCase: true))
				{
					return null;
				}
				Type typeInAssembly = ReflectionTools.GetTypeInAssembly(classPath, assemblyName);
				if (typeInAssembly == null)
				{
					return null;
				}
				return typeInAssembly.InvokeMember("GetBytes", BindingFlags.Static | BindingFlags.Public | BindingFlags.InvokeMethod, null, null, null) as byte[];
			}
			catch (Exception)
			{
				throw;
			}
		}

		private void BFeivOLriGMlKUrHCWUFuqhnNHSn(List<TextAsset> P_0, List<string> P_1)
		{
			if (P_0 == null || P_1 == null)
			{
				return;
			}
			for (int i = 0; i < P_1.Count; i++)
			{
				string text = P_1[i];
				if (!string.IsNullOrEmpty(text))
				{
					TextAsset textAsset = (TextAsset)Resources.Load(text);
					if (textAsset == null)
					{
						Logger.LogError(P_1[i] + " not found in Resources!");
						break;
					}
					P_0.Add(textAsset);
				}
			}
		}

		private string TikmjPGyDMatHNucOCmSjSEnPpZx()
		{
			if (editorPlatform == EditorPlatform.None)
			{
				return null;
			}
			if (fLRTjPZzprkQmbvhGxATONxWlaBe())
			{
				return null;
			}
			string result = string.Format("The current build target is set to {0}. Controller capabilities in the Unity editor may not accurately reflect those in a {0} build.", platform.ToString());
			switch (editorPlatform)
			{
			case EditorPlatform.Windows:
				platform = Platform.Windows;
				break;
			case EditorPlatform.OSX:
				platform = Platform.OSX;
				break;
			case EditorPlatform.Linux:
				platform = Platform.Linux;
				break;
			default:
				result = "Unsupported Unity editor platform detected. Input is not guarateed to function in the editor.";
				break;
			}
			return result;
		}

		private bool fLRTjPZzprkQmbvhGxATONxWlaBe()
		{
			switch (editorPlatform)
			{
			case EditorPlatform.Windows:
				if (platform == Platform.Windows)
				{
					return true;
				}
				break;
			case EditorPlatform.OSX:
				if (platform == Platform.OSX)
				{
					return true;
				}
				break;
			case EditorPlatform.Linux:
				if (platform == Platform.Linux)
				{
					return true;
				}
				break;
			}
			return false;
		}

		private string cQvuiXAZFSIVxBQQLvBgBEExzJrE()
		{
			if (!ReInput.isEditor && ReInput.webplayerPlatform != WebplayerPlatform.None)
			{
				return string.Empty;
			}
			return ReInput.currentPlatform switch
			{
				Platform.Windows => "Rewired_Windows", 
				Platform.OSX => "Rewired_OSX", 
				Platform.Linux => "Rewired_Linux", 
				_ => string.Empty, 
			};
		}

		private bool eawVWLvXPnrpMyyqbVOcHpbipLtp()
		{
			LcbZJuKiETZIeHwGUmQrJTpxddmC = false;
			if (ReInput.isReady)
			{
				if (Application.isPlaying)
				{
					if (Application.isEditor)
					{
						Logger.LogWarning("Only one Rewired Input Manager may exist in a scene. This additional Rewired Input Manager game object will be deleted. You may see this warning if you are loading a new level that contains a Rewired Input Manager. If that's the case, you can safely ignore this warning. This warning will never be logged in a build.");
					}
					UnityEngine.Object.Destroy(base.gameObject);
					return false;
				}
				LcbZJuKiETZIeHwGUmQrJTpxddmC = true;
				Logger.LogWarning("Only one Rewired Input Manager may exist in a scene.");
				return false;
			}
			return true;
		}

		protected void RecompileStart()
		{
			ReInput.WrdBaqdyjTeTLorpMNdmtFXQcztaA();
			ReInput.irGsUSXAeSTYWVGMphFsSmZHHAEL();
		}

		protected void RecompileEnd()
		{
			if (!Application.isPlaying)
			{
				_ = userData.ConfigVars.runInEditMode;
			}
		}

		protected void OnSceneLoaded()
		{
			if (ReInput.isReady)
			{
				ReInput.CclSeDWfShQEfWVXjoENaKzLxLWW();
			}
		}

		private void bJJaejayVERaIHKUPxMaLexaIbSo(XlNZamiOtDjbPniLXjsqlteBHoyiA P_0, string P_1, Exception P_2)
		{
			P_1 = "An exception occurred during " + P_1 + ".";
			bool flag = false;
			if (P_0 == XlNZamiOtDjbPniLXjsqlteBHoyiA.Initialization || P_0 == XlNZamiOtDjbPniLXjsqlteBHoyiA.Destroy)
			{
				P_1 += " Input will not function.";
				flag = true;
			}
			else
			{
				P_1 += " Rewired will attempt to continue running.";
			}
			Logger.LogException((P_2.InnerException != null) ? P_2.InnerException : P_2, P_1 + "\n\nException:\n" + ((P_2.InnerException != null) ? P_2.InnerException : P_2));
			if (flag)
			{
				HRUBHUbeMsWhgmpBYDjnvFYcCYKOA = true;
			}
		}

		[CustomObfuscation(rename = false)]
		internal void ResetAll()
		{
			fmORTtWSHYsswlBEiTPIsiEAoZgw(false);
			fUbycKpGLTabYnYeUiZLBelGCNMt();
		}

		[CustomObfuscation(rename = false)]
		internal EditorPlatform GetEditorPlatform()
		{
			if (!jWKKMvlBNZCOEjqUbxVYGkSDjpqbb && !_detectedPlatformInEditor)
			{
				DetectPlatform();
			}
			_detectedPlatformInEditor = true;
			return editorPlatform;
		}

		[CustomObfuscation(rename = false)]
		internal void GetSupportedEditModeControllerTypes(out bool keyboardSupported, out bool mouseSupported, out bool joystickSupported)
		{
			keyboardSupported = _userData.ConfigVars.IsEditModeInputSupported(ControllerType.Keyboard, editorPlatform);
			mouseSupported = _userData.ConfigVars.IsEditModeInputSupported(ControllerType.Mouse, editorPlatform);
			joystickSupported = _userData.ConfigVars.IsEditModeInputSupported(ControllerType.Joystick, editorPlatform);
		}

		[CustomObfuscation(rename = false)]
		internal bool IsEditModeSupported()
		{
			if (editorPlatform == EditorPlatform.None)
			{
				GetEditorPlatform();
			}
			bool num = _userData.ConfigVars.IsEditModeInputSupported(ControllerType.Keyboard, editorPlatform);
			bool flag = _userData.ConfigVars.IsEditModeInputSupported(ControllerType.Mouse, editorPlatform);
			bool flag2 = _userData.ConfigVars.IsEditModeInputSupported(ControllerType.Joystick, editorPlatform);
			return num || flag || flag2;
		}

		protected abstract void OnInitialized();

		protected abstract void OnDeinitialized();

		protected abstract void DetectPlatform();

		protected abstract void CheckRecompile();

		protected abstract IExternalTools GetExternalTools();

		[CompilerGenerated]
		private bool rnNCEmjcyESlTGxOeFnVwaawyBZJ(Assembly P_0)
		{
			return string.Equals(P_0.GetName().Name, cQvuiXAZFSIVxBQQLvBgBEExzJrE(), StringComparison.OrdinalIgnoreCase);
		}
	}
}
