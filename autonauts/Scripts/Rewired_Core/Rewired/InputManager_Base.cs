using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using Rewired.Config;
using Rewired.Data;
using Rewired.Internal;
using Rewired.Platforms;
using Rewired.Utils;
using Rewired.Utils.Interfaces;
using UnityEngine;

namespace Rewired
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	[AddComponentMenu("")]
	[Browsable(false)]
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
		[CustomObfuscation(rename = false)]
		protected ScriptingBackend scriptingBackend = ScriptingBackend.DotNet;

		[NonSerialized]
		[CustomObfuscation(rename = false)]
		protected ScriptingAPILevel scriptingAPILevel;

		[NonSerialized]
		private bool _duplicateRIMError;

		private bool _isAwake;

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
				while (true)
				{
					int num = -847721856;
					while (true)
					{
						switch (num ^ -847721851)
						{
						case 0:
							break;
						default:
							return;
						case 3:
							return;
						case 4:
						{
							int num2;
							if (UnityTools.IsActiveAndEnabled(this))
							{
								num = -847721854;
								num2 = num;
							}
							else
							{
								num = -847721852;
								num2 = num;
							}
							continue;
						}
						case 7:
							if (!UnityTools.IsObjectInScene(this))
							{
								return;
							}
							goto case 6;
						case 1:
							return;
						case 5:
							if (Application.isPlaying)
							{
								return;
							}
							goto case 4;
						case 2:
							TryStopRunInEditMode();
							num = -847721843;
							continue;
						case 6:
							if (value)
							{
								TryStartRunInEditMode();
								num = -847721850;
								continue;
							}
							goto case 2;
						case 8:
							return;
						}
						break;
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
			_isAwake = true;
			while (true)
			{
				int num = -603737578;
				while (true)
				{
					switch (num ^ -603737582)
					{
					case 2:
						break;
					case 0:
						if (!base.enabled)
						{
							return;
						}
						goto default;
					case 3:
						if (!_userData.ConfigVars.runInEditMode)
						{
							return;
						}
						goto case 0;
					case 4:
					{
						int num2;
						if (Application.isPlaying)
						{
							num = -603737582;
							num2 = num;
						}
						else
						{
							num = -603737583;
							num2 = num;
						}
						continue;
					}
					default:
						Initialize();
						return;
					}
					break;
				}
			}
		}

		[CustomObfuscation(rename = false)]
		private void OnEnable()
		{
			if (!Application.isPlaying)
			{
				goto IL_0007;
			}
			goto IL_006e;
			IL_0007:
			int num = -452048468;
			goto IL_000c;
			IL_000c:
			while (true)
			{
				switch (num ^ -452048472)
				{
				case 0:
					break;
				case 7:
					goto IL_003c;
				case 6:
				{
					int num2;
					if (initialized)
					{
						num = -452048471;
						num2 = num;
					}
					else
					{
						num = -452048465;
						num2 = num;
					}
					continue;
				}
				case 5:
					goto IL_006e;
				case 3:
					if (!_isAwake)
					{
						return;
					}
					goto case 6;
				case 4:
					if (!_userData.ConfigVars.runInEditMode)
					{
						return;
					}
					goto IL_006e;
				case 1:
					return;
				default:
					ManualInitialize();
					return;
				}
				break;
				IL_003c:
				int num3;
				if (!criticalError)
				{
					num = -452048470;
					num3 = num;
				}
				else
				{
					num = -452048471;
					num3 = num;
				}
			}
			goto IL_0007;
			IL_006e:
			int num4;
			if (Application.isPlaying)
			{
				num = -452048469;
				num4 = num;
			}
			else
			{
				num = -452048466;
				num4 = num;
			}
			goto IL_000c;
		}

		[CustomObfuscation(rename = false)]
		private void OnDisable()
		{
			if (!Application.isPlaying && !_userData.ConfigVars.runInEditMode)
			{
				goto IL_0019;
			}
			goto IL_0043;
			IL_0043:
			OnDestroy();
			int num = -111878238;
			goto IL_001e;
			IL_0019:
			num = -111878237;
			goto IL_001e;
			IL_001e:
			switch (num ^ -111878240)
			{
			case 0:
				break;
			default:
				return;
			case 3:
				return;
			case 1:
				goto IL_0043;
			case 2:
				return;
			}
			goto IL_0019;
		}

		[CustomObfuscation(rename = false)]
		private void OnDestroy()
		{
			initialized = false;
			_duplicateRIMError = false;
			criticalError = false;
			try
			{
				if (ReInput.rewiredInputManager == this)
				{
					ReInput.JBwfYqGfajxfcWcHzCLWCKMjHVvs();
				}
			}
			catch (Exception exception)
			{
				HandleException(ExceptionPoint.Destroy, "destruction", exception);
			}
			OnDeinitialized();
		}

		[CustomObfuscation(rename = false)]
		private void OnApplicationFocus(bool isFocused)
		{
			if (_duplicateRIMError)
			{
				return;
			}
			while (true)
			{
				ReInput.xfVYforgrLHvQFdjgERarRwUcLx(isFocused);
				int num = 650374414;
				while (true)
				{
					switch (num ^ 0x26C3ED0C)
					{
					case 0:
						goto IL_0009;
					case 1:
						break;
					default:
					{
						bool initialized2 = initialized;
						return;
					}
					}
					break;
					IL_0009:
					num = 650374413;
				}
			}
		}

		[CustomObfuscation(rename = false)]
		private void Start()
		{
			if (UnityTools.isEditor && !Application.isPlaying)
			{
				return;
			}
			while (initialized)
			{
				int num;
				int num2;
				if (criticalError)
				{
					num = -1087876017;
					num2 = num;
				}
				else
				{
					num = -1087876018;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -1087876018)
					{
					case 3:
						goto IL_000f;
					case 2:
						break;
					case 1:
						return;
					default:
						ReInput.gvigjQaykylkiDxmhkUQKBzXkGmr();
						return;
					}
					break;
					IL_000f:
					num = -1087876020;
				}
			}
		}

		[CustomObfuscation(rename = false)]
		private void Update()
		{
			if (!initialized)
			{
				return;
			}
			if (criticalError)
			{
				while (true)
				{
					switch (-48498631 ^ -48498632)
					{
					case 2:
						break;
					case 1:
						return;
					case 3:
						goto end_IL_0010;
					default:
						goto IL_0050;
					}
					continue;
					end_IL_0010:
					break;
				}
			}
			if (UnityTools.isEditor && !Application.isPlaying)
			{
				return;
			}
			goto IL_0050;
			IL_0050:
			DoUpdate(UpdateLoopType.Update, UpdateLoopSetting.Update);
		}

		[CustomObfuscation(rename = false)]
		private void FixedUpdate()
		{
			if (initialized)
			{
				if (criticalError)
				{
					goto IL_0010;
				}
				goto IL_003e;
			}
			return;
			IL_0065:
			DoUpdate(UpdateLoopType.FixedUpdate, UpdateLoopSetting.FixedUpdate);
			return;
			IL_0010:
			int num = -732360692;
			goto IL_0015;
			IL_0015:
			switch (num ^ -732360691)
			{
			case 2:
				break;
			case 4:
				return;
			case 0:
				goto IL_003e;
			case 1:
				return;
			default:
				goto IL_0065;
			}
			goto IL_0010;
			IL_003e:
			if (UnityTools.isEditor)
			{
				int num2;
				if (!Application.isPlaying)
				{
					num = -732360695;
					num2 = num;
				}
				else
				{
					num = -732360690;
					num2 = num;
				}
				goto IL_0015;
			}
			goto IL_0065;
		}

		[CustomObfuscation(rename = false)]
		private void LateUpdate()
		{
			if (!initialized)
			{
				return;
			}
			if (criticalError)
			{
				while (true)
				{
					switch (-1574926297 ^ -1574926298)
					{
					case 0:
						continue;
					case 1:
						return;
					}
					break;
				}
			}
			if (UnityTools.isEditor && !Application.isPlaying)
			{
				return;
			}
			try
			{
				ReInput.jKEaAMFsgoDvEEkJWYugCiweHfww();
			}
			catch (Exception exception)
			{
				HandleException(ExceptionPoint.Update, "update (Late Update)", exception);
			}
		}

		internal void OnGUIUpdate()
		{
			if (!initialized)
			{
				return;
			}
			while (true)
			{
				int num = 427998926;
				while (true)
				{
					switch (num ^ 0x1982BEC8)
					{
					case 0:
						break;
					default:
						return;
					case 6:
					{
						int num3;
						if (criticalError)
						{
							num = 427998922;
							num3 = num;
						}
						else
						{
							num = 427998923;
							num3 = num;
						}
						continue;
					}
					case 1:
						if (!Application.isPlaying)
						{
							return;
						}
						goto case 4;
					case 2:
						return;
					case 4:
						DoUpdate(UpdateLoopType.OnGUI, UpdateLoopSetting.OnGUI);
						num = 427998925;
						continue;
					case 3:
					{
						int num2;
						if (!UnityTools.isEditor)
						{
							num = 427998924;
							num2 = num;
						}
						else
						{
							num = 427998921;
							num2 = num;
						}
						continue;
					}
					case 5:
						return;
					}
					break;
				}
			}
		}

		internal void DoUpdate(UpdateLoopType updateLoopType, UpdateLoopSetting updateLoopSettingBit)
		{
			if (!initialized || criticalError)
			{
				return;
			}
			try
			{
				CheckRecompile();
				ReInput.NLXCharbQHJjphZbJIgpHiAuksK(updateLoopType);
				while (true)
				{
					switch (-60483289 ^ -60483290)
					{
					case 2:
						continue;
					case 1:
						if ((_userData.ConfigVars.updateLoop & updateLoopSettingBit) == 0)
						{
							return;
						}
						break;
					}
					break;
				}
				ReInput.rdEJYvExbWYUXSDuseVgzyXPBhA(updateLoopType);
			}
			catch (Exception exception)
			{
				while (true)
				{
					int num = -60483289;
					while (true)
					{
						switch (num ^ -60483290)
						{
						case 2:
							break;
						default:
							return;
						case 1:
							goto IL_007f;
						case 0:
							return;
						}
						break;
						IL_007f:
						HandleException(ExceptionPoint.Update, "update (" + updateLoopType.ToString() + ")", exception);
						num = -60483290;
					}
				}
			}
		}

		internal void TryStartRunInEditMode()
		{
			if (initialized)
			{
				return;
			}
			string text = default(string);
			bool mouseSupported = default(bool);
			bool joystickSupported = default(bool);
			while (Application.isEditor)
			{
				int num;
				int num2;
				if (Application.isPlaying)
				{
					num = -1592193766;
					num2 = num;
				}
				else
				{
					num = -1592193769;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -1592193775)
					{
					case 5:
						num = -1592193765;
						continue;
					case 10:
						break;
					case 3:
						if (!string.IsNullOrEmpty(text))
						{
							Logger.LogWarning("The current editor platform and/or input source settings do not support the following input devices in Edit mode:\n" + text);
							num = -1592193775;
							continue;
						}
						goto default;
					case 2:
						text += "Joystick";
						num = -1592193774;
						continue;
					case 7:
						text += ", ";
						num = -1592193791;
						continue;
					case 4:
					{
						bool keyboardSupported;
						GetSupportedEditModeControllerTypes(out keyboardSupported, out mouseSupported, out joystickSupported);
						if (!keyboardSupported)
						{
							int num5;
							if (string.IsNullOrEmpty(text))
							{
								num = -1592193791;
								num5 = num;
							}
							else
							{
								num = -1592193770;
								num5 = num;
							}
							continue;
						}
						goto case 18;
					}
					case 17:
						if (!IsEditModeSupported())
						{
							Logger.LogWarning("Rewired cannot run in Edit mode on this editor platform with the current settings.");
							return;
						}
						goto case 9;
					case 15:
						text += ", ";
						num = -1592193767;
						continue;
					case 11:
						return;
					case 18:
						if (!mouseSupported)
						{
							int num3;
							if (string.IsNullOrEmpty(text))
							{
								num = -1592193767;
								num3 = num;
							}
							else
							{
								num = -1592193762;
								num3 = num;
							}
							continue;
						}
						goto case 13;
					case 9:
						text = null;
						num = -1592193771;
						continue;
					case 12:
						return;
					case 8:
						text += "Mouse";
						num = -1592193764;
						continue;
					case 6:
					{
						int num4;
						if (ReInput.isReady)
						{
							num = -1592193790;
							num4 = num;
						}
						else
						{
							num = -1592193761;
							num4 = num;
						}
						continue;
					}
					case 19:
						Logger.LogWarning("Rewired is already running in Edit mode. Do you have multiple Rewired Input Managers in the scene? If you want to run this Rewired Input Manager, you must stop the one currently running first.");
						num = -1592193763;
						continue;
					case 13:
						if (!joystickSupported)
						{
							int num6;
							if (string.IsNullOrEmpty(text))
							{
								num = -1592193773;
								num6 = num;
							}
							else
							{
								num = -1592193776;
								num6 = num;
							}
							continue;
						}
						goto case 3;
					case 16:
						text += "Keyboard";
						num = -1592193789;
						continue;
					case 14:
						if (_userData.ConfigVars.alwaysUseUnityInput)
						{
							Logger.LogWarning("Rewired cannot run in Edit mode when native input is disabled.");
							return;
						}
						goto case 17;
					case 1:
						text += ", ";
						num = -1592193773;
						continue;
					default:
						_duplicateRIMError = false;
						ManualInitialize();
						return;
					}
					break;
				}
			}
		}

		internal void TryStopRunInEditMode()
		{
			if (!Application.isEditor)
			{
				return;
			}
			while (true)
			{
				int num = 1375065905;
				while (true)
				{
					switch (num ^ 0x51F5D733)
					{
					case 4:
						break;
					case 1:
					{
						int num3;
						if (!ReInput.isReady)
						{
							num = 1375065910;
							num3 = num;
						}
						else
						{
							num = 1375065907;
							num3 = num;
						}
						continue;
					}
					case 5:
						return;
					case 2:
					{
						int num2;
						if (!Application.isPlaying)
						{
							num = 1375065906;
							num2 = num;
						}
						else
						{
							num = 1375065904;
							num2 = num;
						}
						continue;
					}
					case 3:
						return;
					default:
						OnDestroy();
						return;
					}
					break;
				}
			}
		}

		private bool ManualInitialize()
		{
			if (initialized)
			{
				return true;
			}
			Initialize();
			while (true)
			{
				int num = -1889693426;
				while (true)
				{
					switch (num ^ -1889693425)
					{
					case 2:
						break;
					case 1:
						if (initialized)
						{
							goto IL_0036;
						}
						goto default;
					default:
						return initialized;
					}
					break;
					IL_0036:
					ReInput.gvigjQaykylkiDxmhkUQKBzXkGmr();
					num = -1889693425;
				}
			}
		}

		private void Initialize()
		{
			if (_duplicateRIMError)
			{
				return;
			}
			try
			{
				if (!IsOnlyManagerInScene())
				{
					goto IL_0014;
				}
				goto IL_00f0;
				IL_0014:
				int num = 1227390274;
				goto IL_0019;
				IL_0019:
				string text = default(string);
				while (true)
				{
					switch (num ^ 0x49287D47)
					{
					case 12:
						break;
					case 6:
						if ((_userData.ConfigVars.updateLoop & UpdateLoopSetting.Update) == 0)
						{
							userData.ConfigVars.updateLoop |= UpdateLoopSetting.Update;
							num = 1227390278;
							continue;
						}
						goto case 1;
					case 13:
						DetectPlatform();
						if (_userData != null)
						{
							goto IL_00ac;
						}
						goto case 8;
					case 8:
						Logger.LogError("Error! DataFiles is missing or corrupt! Make sure you have the DataFiles file linked in the inspector.");
						num = 1227390277;
						continue;
					case 2:
						return;
					case 7:
						goto IL_00f0;
					case 0:
						UnityEngine.Object.DontDestroyOnLoad(base.transform.root.gameObject);
						num = 1227390282;
						continue;
					case 14:
						goto IL_012b;
					case 5:
						return;
					case 3:
						goto IL_0155;
					case 10:
						criticalError = false;
						if (!string.IsNullOrEmpty(text))
						{
							Logger.LogWarning(text);
							num = 1227390284;
							continue;
						}
						goto default;
					case 1:
						if ((_userData.ConfigVars.updateLoop & UpdateLoopSetting.OnGUI) == UpdateLoopSetting.OnGUI && base.gameObject.GetComponent<OnGUIHelper>() == null)
						{
							base.gameObject.AddComponent<OnGUIHelper>();
							num = 1227390275;
							continue;
						}
						goto case 4;
					case 9:
						ReInput.dFyvOnKBbTYzKLbxHBbiIGdcrpeH(this, InitializePlatform, _userData.ConfigVars, _controllerDataFiles, _userData);
						initialized = true;
						num = 1227390285;
						continue;
					case 4:
						text = SetPlatformToEditorPlatform();
						UnityTools.dFyvOnKBbTYzKLbxHBbiIGdcrpeH(platform, editorPlatform, isEditor, webplayerPlatform, scriptingBackend, scriptingAPILevel, GetExternalTools());
						num = 1227390286;
						continue;
					default:
						OnInitialized();
						return;
					}
					break;
					IL_0155:
					int num2;
					if (_controllerDataFiles == null)
					{
						num = 1227390287;
						num2 = num;
					}
					else
					{
						num = 1227390273;
						num2 = num;
					}
					continue;
					IL_012b:
					int num3;
					if (!Application.isPlaying)
					{
						num = 1227390282;
						num3 = num;
					}
					else
					{
						num = 1227390279;
						num3 = num;
					}
					continue;
					IL_00ac:
					int num4;
					if (_userData.ConfigVars == null)
					{
						num = 1227390287;
						num4 = num;
					}
					else
					{
						num = 1227390276;
						num4 = num;
					}
				}
				goto IL_0014;
				IL_00f0:
				int num5;
				if (_dontDestroyOnLoad)
				{
					num = 1227390281;
					num5 = num;
				}
				else
				{
					num = 1227390282;
					num5 = num;
				}
				goto IL_0019;
			}
			catch (Exception exception)
			{
				HandleException(ExceptionPoint.Initialization, "initialization", exception);
			}
		}

		private object InitializePlatform(ConfigVars configVars)
		{
			List<Assembly> list;
			if (UnityTools.unityVersion < UnityTools.UnityVersion.UNITY_5_0)
			{
				list = GetNativeAssembliesFromResources();
			}
			else
			{
				while (true)
				{
					list = null;
					int num = -45673833;
					while (true)
					{
						switch (num ^ -45673834)
						{
						case 0:
							num = -45673836;
							continue;
						case 2:
							break;
						default:
							goto end_IL_0030;
						}
						break;
					}
					continue;
					end_IL_0030:
					break;
				}
			}
			return IdRpivuosRElvZpXQUPVXhgAeUF.dFyvOnKBbTYzKLbxHBbiIGdcrpeH(GetPlatformSpecificAssemblyName(), list, configVars);
		}

		private List<Assembly> GetNativeAssembliesFromResources()
		{
			List<TextAsset> list = new List<TextAsset>();
			AddTextAssetInResourcesToList(list, UnityTools.GetCurrentPlatformResourecesDLLPaths());
			List<Assembly> list2 = new List<Assembly>();
			int count = list.Count;
			int num = 0;
			while (true)
			{
				int num2;
				int num3;
				if (num < count)
				{
					num2 = 440404088;
					num3 = num2;
				}
				else
				{
					num2 = 440404095;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ 0x1A400879)
					{
					case 2:
						num2 = 440404088;
						continue;
					case 3:
						if (list2.Count == 0)
						{
							num2 = 440404089;
							continue;
						}
						return list2;
					case 6:
					{
						int num4;
						if (list2 != null)
						{
							num2 = 440404090;
							num4 = num2;
						}
						else
						{
							num2 = 440404089;
							num4 = num2;
						}
						continue;
					}
					case 4:
						num++;
						num2 = 440404092;
						continue;
					case 5:
						break;
					case 1:
						if (!(list[num] == null))
						{
							Assembly item = Assembly.Load(list[num].bytes);
							list2.Add(item);
							num2 = 440404093;
							continue;
						}
						goto case 4;
					default:
						return null;
					}
					break;
				}
			}
		}

		private List<Assembly> GetNativeAssembliesByReflection()
		{
			bool flag = false;
			try
			{
				string platformSpecificAssemblyName = GetPlatformSpecificAssemblyName();
				if (string.IsNullOrEmpty(platformSpecificAssemblyName))
				{
					goto IL_0014;
				}
				goto IL_004d;
				IL_0014:
				int num = 39190271;
				goto IL_0019;
				IL_0019:
				Assembly assembly = default(Assembly);
				switch (num ^ 0x255FEFE)
				{
				case 5:
					break;
				case 1:
					return null;
				case 0:
					goto IL_004d;
				case 4:
					goto IL_006a;
				case 2:
					if ((object)assembly == null)
					{
						flag = true;
						throw new Exception();
					}
					goto default;
				default:
				{
					List<Assembly> list = new List<Assembly>();
					list.Add(assembly);
					return list;
				}
				}
				goto IL_0014;
				IL_004d:
				Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
				if (assemblies == null)
				{
					flag = true;
					throw new Exception();
				}
				goto IL_006a;
				IL_006a:
				assembly = Array.Find(assemblies, (Assembly x) => string.Equals(x.GetName().Name, GetPlatformSpecificAssemblyName(), StringComparison.OrdinalIgnoreCase));
				num = 39190268;
				goto IL_0019;
			}
			catch
			{
				while (true)
				{
					int num2 = 39190271;
					while (true)
					{
						string obj2;
						switch (num2 ^ 0x255FEFE)
						{
						case 2:
							break;
						case 1:
							if (flag)
							{
								obj2 = (UnityTools.isStandalonePlatform ? "If this is an IL2CPP build, Rewired does not support native input in an IL2CPP Standalone build at this time due to technical issues. This issue is being worked on." : "");
								goto IL_00f0;
							}
							goto default;
						default:
							return null;
						}
						break;
						IL_00f0:
						Logger.LogError("Failed to initialize native input libraries. Falling back to Unity input. Controllers support will be limited and many special features will not be available. " + obj2);
						num2 = 39190270;
					}
				}
			}
		}

		private byte[] GetNativeDLLBytesByReflection()
		{
			byte[] result = default(byte[]);
			try
			{
				string platformSpecificAssemblyName = GetPlatformSpecificAssemblyName();
				if (string.IsNullOrEmpty(platformSpecificAssemblyName))
				{
					result = null;
				}
				else
				{
					Type typeInAssembly = default(Type);
					while (true)
					{
						IL_0041:
						string assemblyName = platformSpecificAssemblyName + "_Lib";
						string classPath = "Rewired.Internal.PlatformDLL";
						int num = -1211190749;
						while (true)
						{
							switch (num ^ -1211190745)
							{
							case 0:
								num = -1211190747;
								continue;
							default:
								goto end_IL_001c;
							case 2:
								break;
							case 4:
								if (!ReflectionTools.IsAssemblyLoaded(assemblyName, true, true))
								{
									result = null;
									goto end_IL_001c;
								}
								goto case 5;
							case 5:
								typeInAssembly = ReflectionTools.GetTypeInAssembly(classPath, assemblyName);
								if ((object)typeInAssembly == null)
								{
									result = null;
									goto end_IL_001c;
								}
								goto case 1;
							case 1:
								result = typeInAssembly.InvokeMember("GetBytes", BindingFlags.Static | BindingFlags.Public | BindingFlags.InvokeMethod, null, null, null) as byte[];
								num = -1211190748;
								continue;
							case 3:
								goto end_IL_001c;
							}
							goto IL_0041;
							continue;
							end_IL_001c:
							break;
						}
						break;
					}
				}
			}
			catch (Exception)
			{
				throw;
			}
			return result;
		}

		private void AddTextAssetInResourcesToList(List<TextAsset> list, List<string> dllPaths)
		{
			if (list != null)
			{
				if (dllPaths == null)
				{
					goto IL_0006;
				}
				goto IL_0043;
			}
			return;
			IL_0043:
			int num = 0;
			int num2 = 464761500;
			goto IL_000b;
			IL_0006:
			num2 = 464761497;
			goto IL_000b;
			IL_000b:
			TextAsset textAsset = default(TextAsset);
			string text = default(string);
			while (true)
			{
				switch (num2 ^ 0x1BB3B29C)
				{
				case 2:
					break;
				case 6:
					num++;
					num2 = 464761500;
					continue;
				case 3:
					goto IL_0043;
				case 5:
					return;
				case 1:
					list.Add(textAsset);
					num2 = 464761498;
					continue;
				case 4:
					if (string.IsNullOrEmpty(text))
					{
						goto case 6;
					}
					textAsset = (TextAsset)Resources.Load(text);
					if (textAsset == null)
					{
						Logger.LogError(dllPaths[num] + " not found in Resources!");
						return;
					}
					goto case 1;
				case 7:
					text = dllPaths[num];
					num2 = 464761496;
					continue;
				default:
					if (num >= dllPaths.Count)
					{
						return;
					}
					goto case 7;
				}
				break;
			}
			goto IL_0006;
		}

		private string SetPlatformToEditorPlatform()
		{
			if (this.editorPlatform == EditorPlatform.None)
			{
				return null;
			}
			if (CheckEditorPlatformMatches())
			{
				return null;
			}
			string result = string.Format("The current build target is set to {0}. Controller capabilities in the Unity editor may not accurately reflect those in a {0} build.", platform.ToString());
			EditorPlatform editorPlatform = default(EditorPlatform);
			while (true)
			{
				int num = 1725508164;
				while (true)
				{
					switch (num ^ 0x66D92A46)
					{
					case 5:
						break;
					case 4:
						platform = Platform.OSX;
						num = 1725508174;
						continue;
					case 1:
						goto IL_0073;
					case 8:
						num = 1725508166;
						continue;
					case 3:
						goto IL_0088;
					case 7:
						result = "Unsupported Unity editor platform detected. Input is not guarateed to function in the editor.";
						num = 1725508166;
						continue;
					case 6:
						switch (editorPlatform)
						{
						case EditorPlatform.OSX:
							break;
						case EditorPlatform.Linux:
							goto IL_0073;
						case EditorPlatform.Windows:
							goto IL_0088;
						default:
							goto IL_00b7;
						}
						goto case 4;
					case 2:
						editorPlatform = this.editorPlatform;
						num = 1725508160;
						continue;
					default:
						{
							return result;
						}
						IL_00b7:
						num = 1725508161;
						continue;
						IL_0088:
						platform = Platform.Windows;
						num = 1725508166;
						continue;
						IL_0073:
						platform = Platform.Linux;
						num = 1725508166;
						continue;
					}
					break;
				}
			}
		}

		private bool CheckEditorPlatformMatches()
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
			{
				if (platform != Platform.OSX)
				{
					break;
				}
				int num = 1479553339;
				while (true)
				{
					switch (num ^ 0x5830313A)
					{
					case 0:
						goto IL_001d;
					case 2:
						break;
					default:
						return true;
					}
					break;
					IL_001d:
					num = 1479553336;
				}
				goto case EditorPlatform.Windows;
			}
			case EditorPlatform.Linux:
				if (platform == Platform.Linux)
				{
					return true;
				}
				break;
			}
			return false;
		}

		private string GetPlatformSpecificAssemblyName()
		{
			if (!ReInput.isEditor)
			{
				goto IL_0007;
			}
			goto IL_0036;
			IL_0007:
			int num = 1776573308;
			goto IL_000c;
			IL_000c:
			switch (num ^ 0x69E45B7E)
			{
			case 0:
				break;
			case 2:
				goto IL_0029;
			case 1:
				goto IL_0043;
			default:
				goto IL_0064;
			}
			goto IL_0007;
			IL_0043:
			Platform currentPlatform = default(Platform);
			switch (currentPlatform)
			{
			case Platform.Windows:
				break;
			case Platform.OSX:
				return "Rewired_OSX";
			case Platform.Linux:
				return "Rewired_Linux";
			default:
				return string.Empty;
			}
			goto IL_0064;
			IL_0036:
			currentPlatform = ReInput.currentPlatform;
			num = 1776573311;
			goto IL_000c;
			IL_0029:
			if (ReInput.webplayerPlatform != WebplayerPlatform.None)
			{
				return string.Empty;
			}
			goto IL_0036;
			IL_0064:
			return "Rewired_Windows";
		}

		private bool IsOnlyManagerInScene()
		{
			_duplicateRIMError = false;
			if (ReInput.isReady)
			{
				while (true)
				{
					int num = -200246307;
					while (true)
					{
						switch (num ^ -200246311)
						{
						case 0:
							break;
						case 2:
							UnityEngine.Object.Destroy(base.gameObject);
							num = -200246312;
							continue;
						case 3:
							if (Application.isEditor)
							{
								Logger.LogWarning("Only one Rewired Input Manager may exist in a scene. This additional Rewired Input Manager game object will be deleted. You may see this warning if you are loading a new level that contains a Rewired Input Manager. If that's the case, you can safely ignore this warning. This warning will never be logged in a build.");
								num = -200246309;
								continue;
							}
							goto case 2;
						case 4:
							if (Application.isPlaying)
							{
								num = -200246310;
								continue;
							}
							_duplicateRIMError = true;
							Logger.LogWarning("Only one Rewired Input Manager may exist in a scene.");
							return false;
						default:
							return false;
						}
						break;
					}
				}
			}
			return true;
		}

		protected void RecompileStart()
		{
			ReInput.vWcNAKGkGNNiFskZgGGhkhvxnhWh();
			ReInput.JBwfYqGfajxfcWcHzCLWCKMjHVvs();
		}

		protected void RecompileEnd()
		{
			if (!Application.isPlaying)
			{
				bool runInEditMode2 = userData.ConfigVars.runInEditMode;
			}
		}

		protected void OnSceneLoaded()
		{
			if (ReInput.isReady)
			{
				ReInput.lKgpRjXeIOxAYlPiJMYtfcBETiM();
			}
		}

		private void HandleException(ExceptionPoint location, string message, Exception exception)
		{
			message = "Rewired: An exception occurred during " + message + ".";
			bool flag = false;
			while (true)
			{
				int num = -647546983;
				while (true)
				{
					switch (num ^ -647546984)
					{
					case 5:
						break;
					default:
						return;
					case 1:
					{
						int num3;
						if (location == ExceptionPoint.Initialization)
						{
							num = -647546981;
							num3 = num;
						}
						else
						{
							num = -647546982;
							num3 = num;
						}
						continue;
					}
					case 6:
						Logger.LogError(message + "\n\nException:\n" + exception);
						if (flag)
						{
							criticalError = true;
							num = -647546980;
							continue;
						}
						return;
					case 0:
						message += " Rewired will attempt to continue running.";
						num = -647546978;
						continue;
					case 3:
						message += " Input will not function.";
						flag = true;
						num = -647546978;
						continue;
					case 2:
					{
						int num2;
						if (location != ExceptionPoint.Destroy)
						{
							num = -647546984;
							num2 = num;
						}
						else
						{
							num = -647546981;
							num2 = num;
						}
						continue;
					}
					case 4:
						return;
					}
					break;
				}
			}
		}

		[CustomObfuscation(rename = false)]
		internal void ResetAll()
		{
			OnDestroy();
			while (true)
			{
				int num = -202432194;
				while (true)
				{
					switch (num ^ -202432196)
					{
					case 0:
						break;
					default:
						return;
					case 2:
						goto IL_0024;
					case 1:
						return;
					}
					break;
					IL_0024:
					ManualInitialize();
					num = -202432195;
				}
			}
		}

		[CustomObfuscation(rename = false)]
		internal EditorPlatform GetEditorPlatform()
		{
			if (!initialized && !_detectedPlatformInEditor)
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
				goto IL_0008;
			}
			goto IL_0038;
			IL_0008:
			int num = -710379129;
			goto IL_000d;
			IL_000d:
			bool result = default(bool);
			while (true)
			{
				switch (num ^ -710379130)
				{
				case 0:
					break;
				case 1:
					GetEditorPlatform();
					num = -710379132;
					continue;
				case 2:
					goto IL_0038;
				default:
					return result;
				}
				break;
			}
			goto IL_0008;
			IL_0038:
			bool flag = _userData.ConfigVars.IsEditModeInputSupported(ControllerType.Keyboard, editorPlatform);
			bool flag2 = _userData.ConfigVars.IsEditModeInputSupported(ControllerType.Mouse, editorPlatform);
			result = _userData.ConfigVars.IsEditModeInputSupported(ControllerType.Joystick, editorPlatform);
			if (!flag && !flag2)
			{
				num = -710379131;
				goto IL_000d;
			}
			return true;
		}

		protected abstract void OnInitialized();

		protected abstract void OnDeinitialized();

		protected abstract void DetectPlatform();

		protected abstract void CheckRecompile();

		protected abstract IExternalTools GetExternalTools();
	}
}
