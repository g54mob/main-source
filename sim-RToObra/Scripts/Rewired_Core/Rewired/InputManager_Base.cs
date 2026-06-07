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
	[AddComponentMenu("")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[ExecuteInEditMode]
	[Browsable(false)]
	public abstract class InputManager_Base : MonoBehaviour
	{
		private enum ExceptionPoint
		{
			Initialization = 0,
			Update = 1,
			Destroy = 2
		}

		[CustomObfuscation(rename = false)]
		[SerializeField]
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
				if (Application.isPlaying)
				{
					return;
				}
				while (true)
				{
					int num;
					int num2;
					if (UnityTools.IsActiveAndEnabled(this))
					{
						num = -802506611;
						num2 = num;
					}
					else
					{
						num = -802506616;
						num2 = num;
					}
					while (true)
					{
						switch (num ^ -802506616)
						{
						case 2:
							goto IL_0019;
						case 5:
							if (!UnityTools.IsObjectInScene(this))
							{
								return;
							}
							goto case 4;
						case 0:
							return;
						case 4:
							if (value)
							{
								TryStartRunInEditMode();
								return;
							}
							goto default;
						case 3:
							break;
						default:
							TryStopRunInEditMode();
							return;
						}
						break;
						IL_0019:
						num = -802506613;
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
			if (!Application.isPlaying && !_userData.ConfigVars.runInEditMode)
			{
				goto IL_0020;
			}
			goto IL_005b;
			IL_004e:
			Initialize();
			int num = 75252808;
			goto IL_0025;
			IL_0020:
			num = 75252809;
			goto IL_0025;
			IL_0025:
			switch (num ^ 0x47C444A)
			{
			case 4:
				break;
			default:
				return;
			case 3:
				return;
			case 1:
				goto IL_004e;
			case 0:
				goto IL_005b;
			case 2:
				return;
			}
			goto IL_0020;
			IL_005b:
			if (!base.enabled)
			{
				return;
			}
			goto IL_004e;
		}

		[CustomObfuscation(rename = false)]
		private void OnEnable()
		{
			if (!Application.isPlaying && !_userData.ConfigVars.runInEditMode)
			{
				return;
			}
			while (true)
			{
				int num;
				int num2;
				if (!Application.isPlaying)
				{
					num = -1690185783;
					num2 = num;
				}
				else
				{
					num = -1690185784;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -1690185780)
					{
					case 0:
						num = -1690185779;
						continue;
					case 5:
						if (!initialized)
						{
							int num3;
							if (!criticalError)
							{
								num = -1690185778;
								num3 = num;
							}
							else
							{
								num = -1690185777;
								num3 = num;
							}
							continue;
						}
						return;
					case 4:
						if (!_isAwake)
						{
							return;
						}
						goto case 5;
					case 1:
						break;
					case 3:
						return;
					default:
						ManualInitialize();
						return;
					}
					break;
				}
			}
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
			int num = -291768546;
			goto IL_001e;
			IL_0019:
			num = -291768547;
			goto IL_001e;
			IL_001e:
			switch (num ^ -291768545)
			{
			case 0:
				break;
			default:
				return;
			case 2:
				return;
			case 3:
				goto IL_0043;
			case 1:
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
					ReInput.unwXDbTGcreCTKEOFdJSrnMHNGeK();
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
			if (!_duplicateRIMError)
			{
				ReInput.EDMLfpLtLFmhqzkIkCmkCoWTnga(isFocused);
				bool initialized2 = initialized;
			}
		}

		[CustomObfuscation(rename = false)]
		private void Start()
		{
			if (UnityTools.isEditor)
			{
				goto IL_0007;
			}
			goto IL_0069;
			IL_0007:
			int num = -876662600;
			goto IL_000c;
			IL_000c:
			while (true)
			{
				switch (num ^ -876662598)
				{
				case 6:
					break;
				default:
					return;
				case 2:
					goto IL_0035;
				case 4:
					return;
				case 1:
					return;
				case 0:
					ReInput.HTeWiJSswgFIFVAtPBCSclhPFDl();
					num = -876662593;
					continue;
				case 3:
					goto IL_0069;
				case 5:
					return;
				}
				break;
				IL_0035:
				int num2;
				if (Application.isPlaying)
				{
					num = -876662599;
					num2 = num;
				}
				else
				{
					num = -876662594;
					num2 = num;
				}
			}
			goto IL_0007;
			IL_0069:
			if (!initialized)
			{
				return;
			}
			int num3;
			if (criticalError)
			{
				num = -876662597;
				num3 = num;
			}
			else
			{
				num = -876662598;
				num3 = num;
			}
			goto IL_000c;
		}

		[CustomObfuscation(rename = false)]
		private void Update()
		{
			if (!initialized)
			{
				return;
			}
			while (true)
			{
				int num = 1224361856;
				while (true)
				{
					switch (num ^ 0x48FA4781)
					{
					case 4:
						break;
					default:
						return;
					case 1:
					{
						int num2;
						if (!criticalError)
						{
							num = 1224361857;
							num2 = num;
						}
						else
						{
							num = 1224361859;
							num2 = num;
						}
						continue;
					}
					case 3:
						DoUpdate(UpdateLoopType.Update, UpdateLoopSetting.Update);
						num = 1224361860;
						continue;
					case 0:
						if (UnityTools.isEditor && !Application.isPlaying)
						{
							return;
						}
						goto case 3;
					case 2:
						return;
					case 5:
						return;
					}
					break;
				}
			}
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
				goto IL_0042;
			}
			return;
			IL_0042:
			int num;
			int num2;
			if (UnityTools.isEditor)
			{
				num = 1726054390;
				num2 = num;
			}
			else
			{
				num = 1726054391;
				num2 = num;
			}
			goto IL_0015;
			IL_0010:
			num = 1726054389;
			goto IL_0015;
			IL_0015:
			while (true)
			{
				switch (num ^ 0x66E17FF7)
				{
				case 5:
					break;
				case 2:
					return;
				case 3:
					goto IL_0042;
				case 1:
					goto IL_005a;
				case 4:
					return;
				default:
					DoUpdate(UpdateLoopType.FixedUpdate, UpdateLoopSetting.FixedUpdate);
					return;
				}
				break;
				IL_005a:
				int num3;
				if (!Application.isPlaying)
				{
					num = 1726054387;
					num3 = num;
				}
				else
				{
					num = 1726054391;
					num3 = num;
				}
			}
			goto IL_0010;
		}

		[CustomObfuscation(rename = false)]
		private void LateUpdate()
		{
			if (initialized)
			{
				if (criticalError)
				{
					goto IL_0010;
				}
				goto IL_0044;
			}
			return;
			IL_005b:
			try
			{
				ReInput.SAOvBBbpeoGAhEwYskaoZLmoMij();
				return;
			}
			catch (Exception exception)
			{
				while (true)
				{
					int num = 1121342811;
					while (true)
					{
						switch (num ^ 0x42D65559)
						{
						case 0:
							break;
						default:
							return;
						case 2:
							goto IL_0081;
						case 1:
							return;
						}
						break;
						IL_0081:
						HandleException(ExceptionPoint.Update, "update (Late Update)", exception);
						num = 1121342808;
					}
				}
			}
			IL_0010:
			int num2 = 1121342808;
			goto IL_0015;
			IL_0015:
			while (true)
			{
				switch (num2 ^ 0x42D65559)
				{
				case 4:
					break;
				default:
					return;
				case 0:
					goto IL_0036;
				case 3:
					goto IL_0044;
				case 1:
					return;
				case 2:
					return;
				}
				break;
				IL_0036:
				if (!Application.isPlaying)
				{
					num2 = 1121342811;
					continue;
				}
				goto IL_005b;
			}
			goto IL_0010;
			IL_0044:
			if (UnityTools.isEditor)
			{
				num2 = 1121342809;
				goto IL_0015;
			}
			goto IL_005b;
		}

		internal void OnGUIUpdate()
		{
			if (initialized)
			{
				if (criticalError)
				{
					goto IL_0010;
				}
				goto IL_0046;
			}
			return;
			IL_0065:
			DoUpdate(UpdateLoopType.OnGUI, UpdateLoopSetting.OnGUI);
			return;
			IL_0010:
			int num = -454615282;
			goto IL_0015;
			IL_0015:
			switch (num ^ -454615286)
			{
			case 2:
				break;
			case 4:
				return;
			case 3:
				return;
			case 0:
				goto IL_0046;
			default:
				goto IL_0065;
			}
			goto IL_0010;
			IL_0046:
			if (UnityTools.isEditor)
			{
				int num2;
				if (Application.isPlaying)
				{
					num = -454615285;
					num2 = num;
				}
				else
				{
					num = -454615287;
					num2 = num;
				}
				goto IL_0015;
			}
			goto IL_0065;
		}

		internal void DoUpdate(UpdateLoopType updateLoopType, UpdateLoopSetting updateLoopSettingBit)
		{
			if (!initialized)
			{
				return;
			}
			while (true)
			{
				int num = 250200898;
				while (true)
				{
					switch (num ^ 0xEE9C343)
					{
					case 0:
						break;
					default:
						return;
					case 1:
						if (criticalError)
						{
							goto IL_002e;
						}
						try
						{
							CheckRecompile();
							ReInput.mHzPvDIYDGoChNcnPSzgyYaRzPK(updateLoopType);
							if ((_userData.ConfigVars.updateLoop & updateLoopSettingBit) != UpdateLoopSetting.None)
							{
								ReInput.UZSQFwoMfSAzsmmSKmseCCiJWWD(updateLoopType);
							}
							return;
						}
						catch (Exception exception)
						{
							HandleException(ExceptionPoint.Update, "update (" + updateLoopType.ToString() + ")", exception);
							return;
						}
					case 2:
						return;
					}
					break;
					IL_002e:
					num = 250200897;
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
			bool joystickSupported = default(bool);
			bool mouseSupported = default(bool);
			while (Application.isEditor)
			{
				int num;
				int num2;
				if (!Application.isPlaying)
				{
					num = 593569244;
					num2 = num;
				}
				else
				{
					num = 593569223;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0x236125CD)
					{
					case 5:
						num = 593569216;
						continue;
					case 9:
						Logger.LogWarning("The current editor platform and/or input source settings do not support the following input devices in Edit mode:\n" + text);
						num = 593569228;
						continue;
					case 3:
						if (!IsEditModeSupported())
						{
							Logger.LogWarning("Rewired cannot run in Edit mode on this editor platform with the current settings.");
							return;
						}
						goto case 12;
					case 18:
						if (!joystickSupported)
						{
							if (!string.IsNullOrEmpty(text))
							{
								text += ", ";
								num = 593569226;
								continue;
							}
							goto case 7;
						}
						goto case 2;
					case 16:
						text += ", ";
						num = 593569219;
						continue;
					case 7:
						text += "Joystick";
						num = 593569231;
						continue;
					case 10:
						return;
					case 12:
					{
						text = null;
						bool keyboardSupported;
						GetSupportedEditModeControllerTypes(out keyboardSupported, out mouseSupported, out joystickSupported);
						if (!keyboardSupported)
						{
							int num5;
							if (!string.IsNullOrEmpty(text))
							{
								num = 593569245;
								num5 = num;
							}
							else
							{
								num = 593569219;
								num5 = num;
							}
							continue;
						}
						goto case 6;
					}
					case 4:
						Logger.LogWarning("Rewired cannot run in Edit mode when native input is disabled.");
						num = 593569229;
						continue;
					case 15:
						text += "Mouse";
						num = 593569247;
						continue;
					case 11:
						text += ", ";
						num = 593569218;
						continue;
					case 17:
						if (ReInput.isReady)
						{
							Logger.LogWarning("Rewired is already running in Edit mode. Do you have multiple Rewired Input Managers in the scene? If you want to run this Rewired Input Manager, you must stop the one currently running first.");
							return;
						}
						goto case 8;
					case 6:
						if (!mouseSupported)
						{
							int num4;
							if (string.IsNullOrEmpty(text))
							{
								num = 593569218;
								num4 = num;
							}
							else
							{
								num = 593569222;
								num4 = num;
							}
							continue;
						}
						goto case 18;
					case 14:
						text += "Keyboard";
						num = 593569227;
						continue;
					case 8:
					{
						int num3;
						if (!_userData.ConfigVars.alwaysUseUnityInput)
						{
							num = 593569230;
							num3 = num;
						}
						else
						{
							num = 593569225;
							num3 = num;
						}
						continue;
					}
					case 0:
						return;
					case 2:
					{
						int num6;
						if (!string.IsNullOrEmpty(text))
						{
							num = 593569220;
							num6 = num;
						}
						else
						{
							num = 593569228;
							num6 = num;
						}
						continue;
					}
					case 13:
						break;
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
			if (Application.isPlaying)
			{
				while (true)
				{
					switch (0x68BFDF53 ^ 0x68BFDF52)
					{
					case 0:
						break;
					case 1:
						return;
					case 3:
						goto end_IL_000e;
					default:
						goto IL_0047;
					}
					continue;
					end_IL_000e:
					break;
				}
			}
			if (!ReInput.isReady)
			{
				return;
			}
			goto IL_0047;
			IL_0047:
			OnDestroy();
		}

		private bool ManualInitialize()
		{
			if (initialized)
			{
				return true;
			}
			Initialize();
			if (initialized)
			{
				while (true)
				{
					int num = -654014657;
					while (true)
					{
						switch (num ^ -654014659)
						{
						case 0:
							break;
						case 2:
							ReInput.HTeWiJSswgFIFVAtPBCSclhPFDl();
							num = -654014660;
							continue;
						default:
							goto end_IL_0018;
						}
						break;
					}
					continue;
					end_IL_0018:
					break;
				}
			}
			return initialized;
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
					return;
				}
				string text = default(string);
				while (true)
				{
					int num;
					int num2;
					if (!_dontDestroyOnLoad)
					{
						num = -266555569;
						num2 = num;
					}
					else
					{
						num = -266555581;
						num2 = num;
					}
					while (true)
					{
						switch (num ^ -266555582)
						{
						case 7:
							num = -266555577;
							continue;
						default:
							return;
						case 13:
							DetectPlatform();
							if (_userData != null && _userData.ConfigVars != null)
							{
								int num5;
								if (_controllerDataFiles == null)
								{
									num = -266555583;
									num5 = num;
								}
								else
								{
									num = -266555572;
									num5 = num;
								}
								continue;
							}
							goto case 3;
						case 12:
						{
							int num4;
							if (string.IsNullOrEmpty(text))
							{
								num = -266555576;
								num4 = num;
							}
							else
							{
								num = -266555584;
								num4 = num;
							}
							continue;
						}
						case 9:
							initialized = true;
							num = -266555580;
							continue;
						case 6:
							criticalError = false;
							num = -266555570;
							continue;
						case 10:
							OnInitialized();
							num = -266555575;
							continue;
						case 4:
							if ((_userData.ConfigVars.updateLoop & UpdateLoopSetting.OnGUI) == UpdateLoopSetting.OnGUI && base.gameObject.GetComponent<OnGUIHelper>() == null)
							{
								base.gameObject.AddComponent<OnGUIHelper>();
								num = -266555574;
								continue;
							}
							goto case 8;
						case 8:
							text = SetPlatformToEditorPlatform();
							UnityTools.YJaAHaimrHWIfKrgfWxeihnqrcza(platform, editorPlatform, isEditor, webplayerPlatform, scriptingBackend, scriptingAPILevel, GetExternalTools());
							ReInput.YJaAHaimrHWIfKrgfWxeihnqrcza(this, InitializePlatform, _userData.ConfigVars, _controllerDataFiles, _userData);
							num = -266555573;
							continue;
						case 14:
						{
							int num3;
							if ((_userData.ConfigVars.updateLoop & UpdateLoopSetting.Update) != UpdateLoopSetting.None)
							{
								num = -266555578;
								num3 = num;
							}
							else
							{
								num = -266555582;
								num3 = num;
							}
							continue;
						}
						case 2:
							Logger.LogWarning(text);
							num = -266555576;
							continue;
						case 0:
							userData.ConfigVars.updateLoop |= UpdateLoopSetting.Update;
							num = -266555578;
							continue;
						case 1:
							if (Application.isPlaying)
							{
								UnityEngine.Object.DontDestroyOnLoad(base.transform.root.gameObject);
								num = -266555569;
								continue;
							}
							goto case 13;
						case 5:
							break;
						case 3:
							Logger.LogError("Error! DataFiles is missing or corrupt! Make sure you have the DataFiles file linked in the inspector.");
							return;
						case 11:
							return;
						}
						break;
					}
				}
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
				goto IL_0010;
			}
			goto IL_0039;
			IL_0039:
			list = null;
			int num = 1062178620;
			goto IL_0015;
			IL_0010:
			num = 1062178623;
			goto IL_0015;
			IL_0015:
			while (true)
			{
				switch (num ^ 0x3F4F8F3D)
				{
				case 0:
					break;
				case 2:
					num = 1062178620;
					continue;
				case 3:
					goto IL_0039;
				default:
					return bGFFlqWHmLhYQxaMwARBAauOhZKw.YJaAHaimrHWIfKrgfWxeihnqrcza(GetPlatformSpecificAssemblyName(), list, configVars);
				}
				break;
			}
			goto IL_0010;
		}

		private List<Assembly> GetNativeAssembliesFromResources()
		{
			List<TextAsset> list = new List<TextAsset>();
			int num2 = default(int);
			List<Assembly> list2 = default(List<Assembly>);
			int count = default(int);
			while (true)
			{
				int num = -889725757;
				while (true)
				{
					switch (num ^ -889725755)
					{
					case 5:
						break;
					case 3:
						if (!(list[num2] == null))
						{
							Assembly item = Assembly.Load(list[num2].bytes);
							list2.Add(item);
							num = -889725758;
							continue;
						}
						goto case 7;
					case 7:
						num2++;
						num = -889725759;
						continue;
					case 2:
						if (list2 != null)
						{
							if (list2.Count == 0)
							{
								num = -889725755;
								continue;
							}
							return list2;
						}
						goto default;
					case 6:
						AddTextAssetInResourcesToList(list, UnityTools.GetCurrentPlatformResourecesDLLPaths());
						list2 = new List<Assembly>();
						num = -889725747;
						continue;
					case 8:
						count = list.Count;
						num = -889725756;
						continue;
					case 4:
					{
						int num3;
						if (num2 >= count)
						{
							num = -889725753;
							num3 = num;
						}
						else
						{
							num = -889725754;
							num3 = num;
						}
						continue;
					}
					case 1:
						num2 = 0;
						num = -889725759;
						continue;
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
				Assembly assembly = default(Assembly);
				Assembly[] assemblies = default(Assembly[]);
				while (true)
				{
					int num = -818327665;
					while (true)
					{
						switch (num ^ -818327667)
						{
						case 5:
							break;
						case 2:
							if (string.IsNullOrEmpty(platformSpecificAssemblyName))
							{
								return null;
							}
							goto case 4;
						case 1:
							flag = true;
							throw new Exception();
						case 3:
							assembly = Array.Find(assemblies, (Assembly x) => string.Equals(x.GetName().Name, GetPlatformSpecificAssemblyName(), StringComparison.OrdinalIgnoreCase));
							if (assembly == null)
							{
								flag = true;
								throw new Exception();
							}
							goto default;
						case 4:
						{
							assemblies = AppDomain.CurrentDomain.GetAssemblies();
							int num2;
							if (assemblies != null)
							{
								num = -818327666;
								num2 = num;
							}
							else
							{
								num = -818327668;
								num2 = num;
							}
							continue;
						}
						default:
						{
							List<Assembly> list = new List<Assembly>();
							list.Add(assembly);
							return list;
						}
						}
						break;
					}
				}
			}
			catch
			{
				if (flag)
				{
					while (true)
					{
						int num3 = -818327668;
						while (true)
						{
							switch (num3 ^ -818327667)
							{
							case 0:
								break;
							case 1:
								Logger.LogError("Failed to initialize native input libraries. Falling back to Unity input. Controllers support will be limited and many special features will not be available. " + (UnityTools.isStandalonePlatform ? "If this is an IL2CPP build, Rewired does not support native input in an IL2CPP Standalone build at this time due to technical issues. This issue is being worked on." : ""));
								num3 = -818327665;
								continue;
							default:
								goto end_IL_00c4;
							}
							break;
						}
						continue;
						end_IL_00c4:
						break;
					}
				}
				return null;
			}
		}

		private byte[] GetNativeDLLBytesByReflection()
		{
			byte[] result;
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
						IL_0062:
						string assemblyName = platformSpecificAssemblyName + "_Lib";
						string classPath = "Rewired.Internal.PlatformDLL";
						int num;
						if (!ReflectionTools.IsAssemblyLoaded(assemblyName, true, true))
						{
							result = null;
							num = 900005080;
							goto IL_001c;
						}
						goto IL_0041;
						IL_0088:
						result = typeInAssembly.InvokeMember("GetBytes", BindingFlags.Static | BindingFlags.Public | BindingFlags.InvokeMethod, null, null, null) as byte[];
						num = 900005083;
						goto IL_001c;
						IL_0041:
						typeInAssembly = ReflectionTools.GetTypeInAssembly(classPath, assemblyName);
						if (typeInAssembly == null)
						{
							result = null;
							break;
						}
						goto IL_0088;
						IL_001c:
						while (true)
						{
							switch (num ^ 0x35A4FCDA)
							{
							case 0:
								num = 900005087;
								continue;
							case 3:
								goto IL_0041;
							case 2:
								break;
							case 5:
								goto IL_0062;
							case 4:
								goto IL_0088;
							case 1:
								break;
							}
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
					goto IL_0009;
				}
				goto IL_0064;
			}
			return;
			IL_0064:
			int num = 0;
			int num2 = -1178904139;
			goto IL_000e;
			IL_0009:
			num2 = -1178904131;
			goto IL_000e;
			IL_000e:
			TextAsset textAsset = default(TextAsset);
			string text = default(string);
			while (true)
			{
				switch (num2 ^ -1178904140)
				{
				case 7:
					break;
				default:
					return;
				case 3:
					goto IL_004a;
				case 0:
					goto IL_0064;
				case 8:
					goto IL_006d;
				case 10:
					textAsset = (TextAsset)Resources.Load(text);
					if (textAsset == null)
					{
						Logger.LogError(dllPaths[num] + " not found in Resources!");
						num2 = -1178904142;
						continue;
					}
					goto case 5;
				case 5:
					list.Add(textAsset);
					num2 = -1178904138;
					continue;
				case 9:
					return;
				case 2:
					num++;
					num2 = -1178904137;
					continue;
				case 1:
					num2 = -1178904137;
					continue;
				case 6:
					return;
				case 4:
					return;
				}
				break;
				IL_006d:
				text = dllPaths[num];
				int num3;
				if (string.IsNullOrEmpty(text))
				{
					num2 = -1178904138;
					num3 = num2;
				}
				else
				{
					num2 = -1178904130;
					num3 = num2;
				}
				continue;
				IL_004a:
				int num4;
				if (num >= dllPaths.Count)
				{
					num2 = -1178904144;
					num4 = num2;
				}
				else
				{
					num2 = -1178904132;
					num4 = num2;
				}
			}
			goto IL_0009;
		}

		private string SetPlatformToEditorPlatform()
		{
			if (editorPlatform == EditorPlatform.None)
			{
				return null;
			}
			if (CheckEditorPlatformMatches())
			{
				goto IL_0012;
			}
			string result = string.Format("The current build target is set to {0}. Controller capabilities in the Unity editor may not accurately reflect those in a {0} build.", platform.ToString());
			switch (editorPlatform)
			{
			case EditorPlatform.OSX:
				goto IL_0086;
			case EditorPlatform.Linux:
				goto IL_0094;
			case EditorPlatform.Windows:
				goto IL_00a5;
			}
			int num = 1210686743;
			goto IL_0017;
			IL_0094:
			platform = Platform.Linux;
			num = 1210686739;
			goto IL_0017;
			IL_00a5:
			platform = Platform.Windows;
			num = 1210686740;
			goto IL_0017;
			IL_0086:
			platform = Platform.OSX;
			num = 1210686740;
			goto IL_0017;
			IL_0012:
			num = 1210686741;
			goto IL_0017;
			IL_0017:
			while (true)
			{
				switch (num ^ 0x48299D14)
				{
				case 4:
					break;
				case 1:
					return null;
				case 5:
					goto IL_0086;
				case 2:
					goto IL_0094;
				case 6:
					goto IL_00a5;
				case 3:
					result = "Unsupported Unity editor platform detected. Input is not guarateed to function in the editor.";
					num = 1210686740;
					continue;
				case 7:
					num = 1210686740;
					continue;
				default:
					return result;
				}
				break;
			}
			goto IL_0012;
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

		private string GetPlatformSpecificAssemblyName()
		{
			if (!ReInput.isEditor && ReInput.webplayerPlatform != WebplayerPlatform.None)
			{
				return string.Empty;
			}
			switch (ReInput.currentPlatform)
			{
			case Platform.Windows:
				return "Rewired_Windows";
			case Platform.OSX:
				return "Rewired_OSX";
			case Platform.Linux:
				return "Rewired_Linux";
			default:
				return string.Empty;
			}
		}

		private bool IsOnlyManagerInScene()
		{
			_duplicateRIMError = false;
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
				_duplicateRIMError = true;
				Logger.LogWarning("Only one Rewired Input Manager may exist in a scene.");
				return false;
			}
			return true;
		}

		protected void RecompileStart()
		{
			ReInput.CNeIVVuWULdFyKFIYCKvjGpjiyJy();
			ReInput.unwXDbTGcreCTKEOFdJSrnMHNGeK();
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
			if (!ReInput.isReady)
			{
				return;
			}
			while (true)
			{
				int num = -19712301;
				while (true)
				{
					switch (num ^ -19712303)
					{
					case 0:
						break;
					default:
						return;
					case 2:
						goto IL_0025;
					case 1:
						return;
					}
					break;
					IL_0025:
					ReInput.EgYgUWpmpSSstJYXGSMKUkAFAed();
					num = -19712304;
				}
			}
		}

		private void HandleException(ExceptionPoint location, string message, Exception exception)
		{
			message = "Rewired: An exception occurred during " + message + ".";
			bool flag = false;
			if (location != ExceptionPoint.Initialization)
			{
				goto IL_0017;
			}
			goto IL_006a;
			IL_0017:
			int num = 184718711;
			goto IL_001c;
			IL_001c:
			while (true)
			{
				switch (num ^ 0xB029576)
				{
				case 4:
					break;
				default:
					return;
				case 1:
					goto IL_0041;
				case 2:
					message += " Rewired will attempt to continue running.";
					num = 184718707;
					continue;
				case 0:
					goto IL_006a;
				case 5:
					Logger.LogError(message + "\n\nException:\n" + exception);
					if (flag)
					{
						criticalError = true;
						num = 184718709;
						continue;
					}
					return;
				case 3:
					return;
				}
				break;
				IL_0041:
				int num2;
				if (location == ExceptionPoint.Destroy)
				{
					num = 184718710;
					num2 = num;
				}
				else
				{
					num = 184718708;
					num2 = num;
				}
			}
			goto IL_0017;
			IL_006a:
			message += " Input will not function.";
			flag = true;
			num = 184718707;
			goto IL_001c;
		}

		[CustomObfuscation(rename = false)]
		internal void ResetAll()
		{
			OnDestroy();
			ManualInitialize();
		}

		[CustomObfuscation(rename = false)]
		internal EditorPlatform GetEditorPlatform()
		{
			if (!initialized && !_detectedPlatformInEditor)
			{
				while (true)
				{
					int num = 1446411052;
					while (true)
					{
						switch (num ^ 0x56367B2D)
						{
						case 2:
							break;
						case 1:
							DetectPlatform();
							num = 1446411053;
							continue;
						default:
							goto end_IL_0010;
						}
						break;
					}
					continue;
					end_IL_0010:
					break;
				}
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
			goto IL_0040;
			IL_0008:
			int num = -1542927519;
			goto IL_000d;
			IL_000d:
			bool result = default(bool);
			bool flag = default(bool);
			bool flag2 = default(bool);
			while (true)
			{
				switch (num ^ -1542927518)
				{
				case 5:
					break;
				case 3:
					GetEditorPlatform();
					num = -1542927514;
					continue;
				case 4:
					goto IL_0040;
				case 1:
					result = _userData.ConfigVars.IsEditModeInputSupported(ControllerType.Joystick, editorPlatform);
					num = -1542927518;
					continue;
				case 0:
					goto IL_0099;
				default:
					return result;
				}
				break;
				IL_0099:
				if (!flag && !flag2)
				{
					num = -1542927520;
					continue;
				}
				return true;
			}
			goto IL_0008;
			IL_0040:
			flag = _userData.ConfigVars.IsEditModeInputSupported(ControllerType.Keyboard, editorPlatform);
			flag2 = _userData.ConfigVars.IsEditModeInputSupported(ControllerType.Mouse, editorPlatform);
			num = -1542927517;
			goto IL_000d;
		}

		protected abstract void OnInitialized();

		protected abstract void OnDeinitialized();

		protected abstract void DetectPlatform();

		protected abstract void CheckRecompile();

		protected abstract IExternalTools GetExternalTools();
	}
}
