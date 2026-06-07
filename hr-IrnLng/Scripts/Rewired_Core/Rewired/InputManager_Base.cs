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
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	[AddComponentMenu("")]
	[Browsable(false)]
	[ExecuteInEditMode]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public abstract class InputManager_Base : MonoBehaviour
	{
		private enum hKXrAbEGVBtuIJoCgjywhIXTpuzB
		{
			VWvbFTaEfPliPjIVkskpJFCBdbax = 0,
			iAnBBfDdWbgOiFHwNWqxFDtiXzYA = 1,
			JnBywxiMyhDHrRMjKNXSooyKbFF = 2
		}

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _dontDestroyOnLoad = true;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private UserData _userData = new UserData();

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private ControllerDataFiles _controllerDataFiles;

		protected bool isCompiling;

		[NonSerialized]
		private bool iTMWkJzAQHobYymwbflfUznXqqe;

		[NonSerialized]
		private bool yOENIfIdgTGaPeWGYkHfLcaSqSS;

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
		private bool xqwlxDLbpdtlTwWFoWSJpqxJXkt;

		private bool YGyTLoahjIowSAHmDSFheJNtEkf;

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

		[CustomObfuscation(rename = false)]
		private void Awake()
		{
			YGyTLoahjIowSAHmDSFheJNtEkf = true;
			if ((Application.isPlaying || _userData.ConfigVars.runInEditMode) && base.enabled)
			{
				iDBXctPcOcjjzWbKaCnxuPiVNUc();
			}
		}

		[CustomObfuscation(rename = false)]
		private void OnEnable()
		{
			if ((Application.isPlaying || _userData.ConfigVars.runInEditMode) && (!Application.isPlaying || YGyTLoahjIowSAHmDSFheJNtEkf) && !iTMWkJzAQHobYymwbflfUznXqqe && !yOENIfIdgTGaPeWGYkHfLcaSqSS)
			{
				CehBetADkUTtMIcseUXTactmHVhB();
			}
		}

		[CustomObfuscation(rename = false)]
		private void OnDisable()
		{
			if (Application.isPlaying || _userData.ConfigVars.runInEditMode)
			{
				OnDestroy();
			}
		}

		[CustomObfuscation(rename = false)]
		private void OnDestroy()
		{
			iTMWkJzAQHobYymwbflfUznXqqe = false;
			xqwlxDLbpdtlTwWFoWSJpqxJXkt = false;
			yOENIfIdgTGaPeWGYkHfLcaSqSS = false;
			try
			{
				if (ReInput.rewiredInputManager == this)
				{
					ReInput.QuXVmZoTaWlRqdcUSBPouNfytdU();
				}
			}
			catch (Exception ex)
			{
				xjkXgzBOEFjbQMofHQVscbwyKow(hKXrAbEGVBtuIJoCgjywhIXTpuzB.JnBywxiMyhDHrRMjKNXSooyKbFF, "destruction", ex);
			}
			OnDeinitialized();
		}

		[CustomObfuscation(rename = false)]
		private void OnApplicationFocus(bool isFocused)
		{
			if (!xqwlxDLbpdtlTwWFoWSJpqxJXkt)
			{
				ReInput.ilyWTiyFMoFXpfCCLKAjzNlzcEtC(isFocused);
				_ = iTMWkJzAQHobYymwbflfUznXqqe;
			}
		}

		[CustomObfuscation(rename = false)]
		private void Start()
		{
			if ((!UnityTools.isEditor || Application.isPlaying) && iTMWkJzAQHobYymwbflfUznXqqe && !yOENIfIdgTGaPeWGYkHfLcaSqSS)
			{
				ReInput.xNRqfCbZrFcpJcVLMCeHrbgeubc();
			}
		}

		[CustomObfuscation(rename = false)]
		private void Update()
		{
			if (iTMWkJzAQHobYymwbflfUznXqqe && !yOENIfIdgTGaPeWGYkHfLcaSqSS && (!UnityTools.isEditor || Application.isPlaying))
			{
				DoUpdate(UpdateLoopType.Update, UpdateLoopSetting.Update);
			}
		}

		[CustomObfuscation(rename = false)]
		private void FixedUpdate()
		{
			if (iTMWkJzAQHobYymwbflfUznXqqe && !yOENIfIdgTGaPeWGYkHfLcaSqSS && (!UnityTools.isEditor || Application.isPlaying))
			{
				DoUpdate(UpdateLoopType.FixedUpdate, UpdateLoopSetting.FixedUpdate);
			}
		}

		[CustomObfuscation(rename = false)]
		private void LateUpdate()
		{
			if (!iTMWkJzAQHobYymwbflfUznXqqe || yOENIfIdgTGaPeWGYkHfLcaSqSS || (UnityTools.isEditor && !Application.isPlaying))
			{
				return;
			}
			try
			{
				ReInput.uhNFICcRFahphhyfYyrDCjJvJsh();
			}
			catch (Exception ex)
			{
				xjkXgzBOEFjbQMofHQVscbwyKow(hKXrAbEGVBtuIJoCgjywhIXTpuzB.iAnBBfDdWbgOiFHwNWqxFDtiXzYA, "update (Late Update)", ex);
			}
		}

		internal void OnGUIUpdate()
		{
			if (iTMWkJzAQHobYymwbflfUznXqqe && !yOENIfIdgTGaPeWGYkHfLcaSqSS && (!UnityTools.isEditor || Application.isPlaying))
			{
				DoUpdate(UpdateLoopType.OnGUI, UpdateLoopSetting.OnGUI);
			}
		}

		internal void DoUpdate(UpdateLoopType updateLoopType, UpdateLoopSetting updateLoopSettingBit)
		{
			if (!iTMWkJzAQHobYymwbflfUznXqqe || yOENIfIdgTGaPeWGYkHfLcaSqSS)
			{
				return;
			}
			try
			{
				CheckRecompile();
				ReInput.ONaxTkghfgMZEieKyHYobhVZYEC(updateLoopType);
				if ((_userData.ConfigVars.updateLoop & updateLoopSettingBit) != UpdateLoopSetting.None)
				{
					ReInput.iAnBBfDdWbgOiFHwNWqxFDtiXzYA(updateLoopType);
				}
			}
			catch (Exception ex)
			{
				xjkXgzBOEFjbQMofHQVscbwyKow(hKXrAbEGVBtuIJoCgjywhIXTpuzB.iAnBBfDdWbgOiFHwNWqxFDtiXzYA, "update (" + updateLoopType.ToString() + ")", ex);
			}
		}

		internal void TryStartRunInEditMode()
		{
			if (iTMWkJzAQHobYymwbflfUznXqqe || !Application.isEditor || Application.isPlaying)
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
			xqwlxDLbpdtlTwWFoWSJpqxJXkt = false;
			CehBetADkUTtMIcseUXTactmHVhB();
		}

		internal void TryStopRunInEditMode()
		{
			if (Application.isEditor && !Application.isPlaying && ReInput.isReady)
			{
				OnDestroy();
			}
		}

		private bool CehBetADkUTtMIcseUXTactmHVhB()
		{
			if (iTMWkJzAQHobYymwbflfUznXqqe)
			{
				return true;
			}
			iDBXctPcOcjjzWbKaCnxuPiVNUc();
			if (iTMWkJzAQHobYymwbflfUznXqqe)
			{
				ReInput.xNRqfCbZrFcpJcVLMCeHrbgeubc();
			}
			return iTMWkJzAQHobYymwbflfUznXqqe;
		}

		private void iDBXctPcOcjjzWbKaCnxuPiVNUc()
		{
			if (xqwlxDLbpdtlTwWFoWSJpqxJXkt)
			{
				return;
			}
			try
			{
				if (!tPvVYGdCNyYItIUzyTArDRxkFLI())
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
				if ((_userData.ConfigVars.updateLoop & UpdateLoopSetting.OnGUI) == UpdateLoopSetting.OnGUI && base.gameObject.GetComponent<OnGUIHelper>() == null)
				{
					base.gameObject.AddComponent<OnGUIHelper>();
				}
				string text = DwchzmnaBZarqHNBWyWHVSGyUCx();
				UnityTools.iDBXctPcOcjjzWbKaCnxuPiVNUc(platform, editorPlatform, isEditor, webplayerPlatform, scriptingBackend, scriptingAPILevel, GetExternalTools());
				ReInput.iDBXctPcOcjjzWbKaCnxuPiVNUc(this, CFlnArExnIUxaPXGkSVTjaXWdxH, _userData.ConfigVars, _controllerDataFiles, _userData);
				iTMWkJzAQHobYymwbflfUznXqqe = true;
				yOENIfIdgTGaPeWGYkHfLcaSqSS = false;
				if (!string.IsNullOrEmpty(text))
				{
					Logger.LogWarning(text);
				}
				OnInitialized();
			}
			catch (Exception ex)
			{
				xjkXgzBOEFjbQMofHQVscbwyKow(hKXrAbEGVBtuIJoCgjywhIXTpuzB.VWvbFTaEfPliPjIVkskpJFCBdbax, "initialization", ex);
			}
		}

		private object CFlnArExnIUxaPXGkSVTjaXWdxH(ConfigVars P_0)
		{
			List<Assembly> list = ((UnityTools.unityVersion >= UnityTools.UnityVersion.UNITY_5_0) ? null : GAqDwthmLPoDGvrXKFmWZnMCsOLC());
			return JCgnTfxtFodHUKJsjLoIpGzzqJB.iDBXctPcOcjjzWbKaCnxuPiVNUc(GKVHmlYlvosahvxbSUXpKhXTJRD(), list, P_0);
		}

		private List<Assembly> GAqDwthmLPoDGvrXKFmWZnMCsOLC()
		{
			List<TextAsset> list = new List<TextAsset>();
			huLnlGvaruzueSBDlbyXkFKtglxi(list, UnityTools.GetCurrentPlatformResourecesDLLPaths());
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

		private List<Assembly> nhKCZSwbRxbSrAJCcgBckmmeLkhO()
		{
			bool flag = false;
			try
			{
				string value = GKVHmlYlvosahvxbSUXpKhXTJRD();
				if (string.IsNullOrEmpty(value))
				{
					return null;
				}
				Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
				if (assemblies == null)
				{
					flag = true;
					throw new Exception();
				}
				Assembly assembly = Array.Find(assemblies, (Assembly P_0) => string.Equals(P_0.GetName().Name, GKVHmlYlvosahvxbSUXpKhXTJRD(), StringComparison.OrdinalIgnoreCase));
				if ((object)assembly == null)
				{
					flag = true;
					throw new Exception();
				}
				List<Assembly> list = new List<Assembly>();
				list.Add(assembly);
				return list;
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

		private byte[] EUrePNbujLdpwQVrfrZlhINLwIOS()
		{
			try
			{
				string text = GKVHmlYlvosahvxbSUXpKhXTJRD();
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
				if ((object)typeInAssembly == null)
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

		private void huLnlGvaruzueSBDlbyXkFKtglxi(List<TextAsset> P_0, List<string> P_1)
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

		private string DwchzmnaBZarqHNBWyWHVSGyUCx()
		{
			if (editorPlatform == EditorPlatform.None)
			{
				return null;
			}
			if (kJKkpLcpYdZQzLeAUFhDiOXgFtE())
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

		private bool kJKkpLcpYdZQzLeAUFhDiOXgFtE()
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

		private string GKVHmlYlvosahvxbSUXpKhXTJRD()
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

		private bool tPvVYGdCNyYItIUzyTArDRxkFLI()
		{
			xqwlxDLbpdtlTwWFoWSJpqxJXkt = false;
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
				xqwlxDLbpdtlTwWFoWSJpqxJXkt = true;
				Logger.LogWarning("Only one Rewired Input Manager may exist in a scene.");
				return false;
			}
			return true;
		}

		protected void RecompileStart()
		{
			ReInput.qwDHkKVvhosbitdsRJOyDiqOFHU();
			ReInput.QuXVmZoTaWlRqdcUSBPouNfytdU();
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
				ReInput.oZdcqZbQHvJfzLoyDHWTkZjuotaC();
			}
		}

		private void xjkXgzBOEFjbQMofHQVscbwyKow(hKXrAbEGVBtuIJoCgjywhIXTpuzB P_0, string P_1, Exception P_2)
		{
			P_1 = "Rewired: An exception occurred during " + P_1 + ".";
			bool flag = false;
			if (P_0 == hKXrAbEGVBtuIJoCgjywhIXTpuzB.VWvbFTaEfPliPjIVkskpJFCBdbax || P_0 == hKXrAbEGVBtuIJoCgjywhIXTpuzB.JnBywxiMyhDHrRMjKNXSooyKbFF)
			{
				P_1 += " Input will not function.";
				flag = true;
			}
			else
			{
				P_1 += " Rewired will attempt to continue running.";
			}
			Logger.LogError(P_1 + "\n\nException:\n" + ((P_2.InnerException != null) ? P_2.InnerException : P_2));
			if (flag)
			{
				yOENIfIdgTGaPeWGYkHfLcaSqSS = true;
			}
		}

		[CustomObfuscation(rename = false)]
		internal void ResetAll()
		{
			OnDestroy();
			CehBetADkUTtMIcseUXTactmHVhB();
		}

		[CustomObfuscation(rename = false)]
		internal EditorPlatform GetEditorPlatform()
		{
			if (!iTMWkJzAQHobYymwbflfUznXqqe && !_detectedPlatformInEditor)
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
			bool flag = _userData.ConfigVars.IsEditModeInputSupported(ControllerType.Keyboard, editorPlatform);
			bool flag2 = _userData.ConfigVars.IsEditModeInputSupported(ControllerType.Mouse, editorPlatform);
			bool result = _userData.ConfigVars.IsEditModeInputSupported(ControllerType.Joystick, editorPlatform);
			if (!flag && !flag2)
			{
				return result;
			}
			return true;
		}

		protected abstract void OnInitialized();

		protected abstract void OnDeinitialized();

		protected abstract void DetectPlatform();

		protected abstract void CheckRecompile();

		protected abstract IExternalTools GetExternalTools();

		[CompilerGenerated]
		private bool DSzrdvLSEQWxcGojXKgxHkgjFTZ(Assembly P_0)
		{
			return string.Equals(P_0.GetName().Name, GKVHmlYlvosahvxbSUXpKhXTJRD(), StringComparison.OrdinalIgnoreCase);
		}
	}
}
