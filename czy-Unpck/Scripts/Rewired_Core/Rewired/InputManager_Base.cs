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
	[ExecuteInEditMode]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
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

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private UserData _userData = new UserData();

		[CustomObfuscation(rename = false)]
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
			set
			{
				if (ReInput.isReady)
				{
					Logger.LogError("Controller Data Files cannot be set while Rewired is initialized. Disable the GameObject or the Input Manager component before setting this value.");
					return;
				}
				while (true)
				{
					_controllerDataFiles = value;
					int num = 788478608;
					while (true)
					{
						switch (num ^ 0x2EFF3A92)
						{
						case 0:
							goto IL_0012;
						default:
							return;
						case 1:
							break;
						case 2:
							return;
						}
						break;
						IL_0012:
						num = 788478611;
					}
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
				if (Application.isPlaying)
				{
					return;
				}
				while (UnityTools.IsActiveAndEnabled(this))
				{
					while (true)
					{
						if (!UnityTools.IsObjectInScene(this))
						{
							return;
						}
						while (true)
						{
							IL_0061:
							int num;
							int num2;
							if (value)
							{
								num = 496786860;
								num2 = num;
							}
							else
							{
								num = 496786858;
								num2 = num;
							}
							while (true)
							{
								switch (num ^ 0x1D9C5DAE)
								{
								case 3:
									num = 496786859;
									continue;
								case 2:
									TryStartRunInEditMode();
									return;
								case 1:
									break;
								case 0:
									goto IL_0061;
								case 5:
									goto end_IL_0051;
								default:
									TryStopRunInEditMode();
									return;
								}
								break;
							}
							break;
						}
						continue;
						end_IL_0051:
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
			if (!Application.isPlaying && !_userData.ConfigVars.runInEditMode)
			{
				return;
			}
			while (true)
			{
				int num;
				int num2;
				if (!base.enabled)
				{
					num = -1122437845;
					num2 = num;
				}
				else
				{
					num = -1122437846;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -1122437847)
					{
					case 0:
						goto IL_0021;
					case 1:
						break;
					case 2:
						return;
					default:
						Initialize();
						return;
					}
					break;
					IL_0021:
					num = -1122437848;
				}
			}
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
				if (Application.isPlaying)
				{
					num = -1160728817;
					num2 = num;
				}
				else
				{
					num = -1160728821;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -1160728821)
					{
					case 2:
						num = -1160728819;
						continue;
					case 3:
						return;
					case 4:
						if (!_isAwake)
						{
							return;
						}
						goto case 0;
					case 5:
					{
						int num3;
						if (criticalError)
						{
							num = -1160728824;
							num3 = num;
						}
						else
						{
							num = -1160728822;
							num3 = num;
						}
						continue;
					}
					case 0:
					{
						int num4;
						if (!initialized)
						{
							num = -1160728818;
							num4 = num;
						}
						else
						{
							num = -1160728824;
							num4 = num;
						}
						continue;
					}
					case 6:
						break;
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
			if (!Application.isPlaying)
			{
				while (true)
				{
					switch (-2021446181 ^ -2021446182)
					{
					case 2:
						continue;
					case 1:
						if (!_userData.ConfigVars.runInEditMode)
						{
							return;
						}
						break;
					}
					break;
				}
			}
			OnDestroy();
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
					ReInput.quspWzJVXrmjPHcaqaRsQonICCC();
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
				ReInput.UmVdrbCFKTwOPTuExwjdgfMPOzM(isFocused);
				int num = -1120066221;
				while (true)
				{
					switch (num ^ -1120066223)
					{
					case 0:
						goto IL_0009;
					case 1:
						break;
					default:
						_ = initialized;
						return;
					}
					break;
					IL_0009:
					num = -1120066224;
				}
			}
		}

		[CustomObfuscation(rename = false)]
		private void Start()
		{
			if (UnityTools.isEditor)
			{
				goto IL_0007;
			}
			goto IL_0054;
			IL_0007:
			int num = -729029349;
			goto IL_000c;
			IL_000c:
			while (true)
			{
				switch (num ^ -729029345)
				{
				case 2:
					break;
				default:
					return;
				case 4:
					if (!Application.isPlaying)
					{
						return;
					}
					goto IL_0054;
				case 3:
					ReInput.NoiITHOkBgdirKSZopWLLfLYZOJ();
					num = -729029345;
					continue;
				case 1:
					return;
				case 5:
					goto IL_0054;
				case 0:
					return;
				}
				break;
			}
			goto IL_0007;
			IL_0054:
			if (!initialized)
			{
				return;
			}
			int num2;
			if (!criticalError)
			{
				num = -729029348;
				num2 = num;
			}
			else
			{
				num = -729029346;
				num2 = num;
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
			if (criticalError)
			{
				while (true)
				{
					switch (0x11B8B390 ^ 0x11B8B393)
					{
					case 2:
						break;
					case 3:
						return;
					case 0:
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
			if (!initialized)
			{
				return;
			}
			if (criticalError)
			{
				while (true)
				{
					switch (-1003927234 ^ -1003927233)
					{
					case 2:
						break;
					case 1:
						return;
					case 0:
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
			DoUpdate(UpdateLoopType.FixedUpdate, UpdateLoopSetting.FixedUpdate);
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
				goto IL_003a;
			}
			return;
			IL_0048:
			if (!Application.isPlaying)
			{
				return;
			}
			goto IL_0050;
			IL_0010:
			int num = 684145202;
			goto IL_0015;
			IL_0015:
			switch (num ^ 0x28C73A33)
			{
			case 2:
				break;
			case 1:
				return;
			case 0:
				goto IL_003a;
			default:
				goto IL_0048;
			}
			goto IL_0010;
			IL_003a:
			if (UnityTools.isEditor)
			{
				num = 684145200;
				goto IL_0015;
			}
			goto IL_0050;
			IL_0050:
			try
			{
				ReInput.KIEzPRxRUsoFFHqeHJExqHIpqcR();
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
				int num = -725432324;
				while (true)
				{
					switch (num ^ -725432323)
					{
					case 2:
						break;
					case 3:
						if (UnityTools.isEditor && !Application.isPlaying)
						{
							return;
						}
						goto default;
					case 4:
						return;
					case 1:
					{
						int num2;
						if (criticalError)
						{
							num = -725432327;
							num2 = num;
						}
						else
						{
							num = -725432322;
							num2 = num;
						}
						continue;
					}
					default:
						DoUpdate(UpdateLoopType.OnGUI, UpdateLoopSetting.OnGUI);
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
				ReInput.eoBDrzjTxJPKesIEIdxkrHuzYrvL(updateLoopType);
				if ((_userData.ConfigVars.updateLoop & updateLoopSettingBit) != UpdateLoopSetting.None)
				{
					ReInput.GzCliicOSMFLMvKajLgvnmGSSrh(updateLoopType);
				}
			}
			catch (Exception exception)
			{
				HandleException(ExceptionPoint.Update, "update (" + updateLoopType.ToString() + ")", exception);
			}
		}

		internal void TryStartRunInEditMode()
		{
			if (initialized)
			{
				goto IL_000b;
			}
			goto IL_0105;
			IL_000b:
			int num = 1143308856;
			goto IL_0010;
			IL_0010:
			string text = default(string);
			bool mouseSupported = default(bool);
			bool keyboardSupported = default(bool);
			bool joystickSupported = default(bool);
			while (true)
			{
				switch (num ^ 0x4425822A)
				{
				case 3:
					break;
				case 5:
					goto IL_007c;
				case 19:
					text += "Joystick";
					num = 1143308847;
					continue;
				case 7:
					Logger.LogWarning("The current editor platform and/or input source settings do not support the following input devices in Edit mode:\n" + text);
					num = 1143308840;
					continue;
				case 12:
					if (mouseSupported)
					{
						goto IL_0196;
					}
					if (!string.IsNullOrEmpty(text))
					{
						text += ", ";
						num = 1143308836;
						continue;
					}
					goto case 14;
				case 16:
					text += "Keyboard";
					num = 1143308838;
					continue;
				case 10:
					goto IL_0105;
				case 11:
					if (keyboardSupported)
					{
						goto case 12;
					}
					goto IL_0123;
				case 22:
					GetSupportedEditModeControllerTypes(out keyboardSupported, out mouseSupported, out joystickSupported);
					num = 1143308833;
					continue;
				case 0:
					goto IL_0155;
				case 1:
					goto IL_0170;
				case 4:
					goto IL_0196;
				case 21:
					if (!string.IsNullOrEmpty(text))
					{
						text += ", ";
						num = 1143308857;
						continue;
					}
					goto case 19;
				case 6:
					text += ", ";
					num = 1143308858;
					continue;
				case 18:
					return;
				case 9:
					text = null;
					num = 1143308860;
					continue;
				case 15:
					if (ReInput.isReady)
					{
						Logger.LogWarning("Rewired is already running in Edit mode. Do you have multiple Rewired Input Managers in the scene? If you want to run this Rewired Input Manager, you must stop the one currently running first.");
						return;
					}
					goto IL_0170;
				case 20:
					return;
				case 13:
					if (!IsEditModeSupported())
					{
						Logger.LogWarning("Rewired cannot run in Edit mode on this editor platform with the current settings.");
						return;
					}
					goto case 9;
				case 8:
					return;
				case 14:
					text += "Mouse";
					num = 1143308846;
					continue;
				case 17:
					Logger.LogWarning("Rewired cannot run in Edit mode when native input is disabled.");
					num = 1143308862;
					continue;
				default:
					_duplicateRIMError = false;
					ManualInitialize();
					return;
				}
				break;
				IL_0170:
				int num2;
				if (!_userData.ConfigVars.alwaysUseUnityInput)
				{
					num = 1143308839;
					num2 = num;
				}
				else
				{
					num = 1143308859;
					num2 = num;
				}
				continue;
				IL_0196:
				int num3;
				if (joystickSupported)
				{
					num = 1143308847;
					num3 = num;
				}
				else
				{
					num = 1143308863;
					num3 = num;
				}
				continue;
				IL_007c:
				int num4;
				if (!string.IsNullOrEmpty(text))
				{
					num = 1143308845;
					num4 = num;
				}
				else
				{
					num = 1143308840;
					num4 = num;
				}
				continue;
				IL_0155:
				int num5;
				if (Application.isPlaying)
				{
					num = 1143308834;
					num5 = num;
				}
				else
				{
					num = 1143308837;
					num5 = num;
				}
				continue;
				IL_0123:
				int num6;
				if (!string.IsNullOrEmpty(text))
				{
					num = 1143308844;
					num6 = num;
				}
				else
				{
					num = 1143308858;
					num6 = num;
				}
			}
			goto IL_000b;
			IL_0105:
			int num7;
			if (!Application.isEditor)
			{
				num = 1143308834;
				num7 = num;
			}
			else
			{
				num = 1143308842;
				num7 = num;
			}
			goto IL_0010;
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
					switch (0x5DE60E7D ^ 0x5DE60E7C)
					{
					case 3:
						break;
					case 1:
						return;
					case 2:
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
					int num = -1735717163;
					while (true)
					{
						switch (num ^ -1735717164)
						{
						case 2:
							break;
						case 1:
							ReInput.NoiITHOkBgdirKSZopWLLfLYZOJ();
							num = -1735717164;
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
					IL_0191:
					int num;
					if (_dontDestroyOnLoad && Application.isPlaying)
					{
						UnityEngine.Object.DontDestroyOnLoad(base.transform.root.gameObject);
						num = -1301403735;
						goto IL_001e;
					}
					goto IL_0148;
					IL_0148:
					DetectPlatform();
					num = -1301403744;
					goto IL_001e;
					IL_001e:
					while (true)
					{
						switch (num ^ -1301403739)
						{
						case 2:
							num = -1301403740;
							continue;
						case 13:
							break;
						case 0:
							if ((_userData.ConfigVars.updateLoop & UpdateLoopSetting.OnGUI) == UpdateLoopSetting.OnGUI && base.gameObject.GetComponent<OnGUIHelper>() == null)
							{
								base.gameObject.AddComponent<OnGUIHelper>();
								num = -1301403732;
								continue;
							}
							goto case 9;
						case 4:
							Logger.LogError("Error! DataFiles is missing or corrupt! Make sure you have the DataFiles file linked in the inspector.");
							num = -1301403738;
							continue;
						case 10:
							ReInput.SdmfoteCDVoXNaSlWEvRMBbwmDy(this, InitializePlatform, _userData.ConfigVars, _controllerDataFiles, _userData);
							initialized = true;
							num = -1301403742;
							continue;
						case 5:
							if (_userData == null || _userData.ConfigVars == null)
							{
								goto case 4;
							}
							goto IL_0126;
						case 12:
							goto end_IL_001e;
						case 11:
							if ((_userData.ConfigVars.updateLoop & UpdateLoopSetting.Update) == 0)
							{
								userData.ConfigVars.updateLoop |= UpdateLoopSetting.Update;
								num = -1301403739;
								continue;
							}
							goto case 0;
						case 1:
							goto IL_0191;
						case 8:
							Logger.LogWarning(text);
							num = -1301403741;
							continue;
						case 9:
							text = SetPlatformToEditorPlatform();
							UnityTools.SdmfoteCDVoXNaSlWEvRMBbwmDy(platform, editorPlatform, isEditor, webplayerPlatform, scriptingBackend, scriptingAPILevel, GetExternalTools());
							num = -1301403729;
							continue;
						case 7:
							criticalError = false;
							num = -1301403736;
							continue;
						case 3:
							return;
						default:
							OnInitialized();
							return;
						}
						int num2;
						if (!string.IsNullOrEmpty(text))
						{
							num = -1301403731;
							num2 = num;
						}
						else
						{
							num = -1301403741;
							num2 = num;
						}
						continue;
						IL_0126:
						int num3;
						if (!(_controllerDataFiles == null))
						{
							num = -1301403730;
							num3 = num;
						}
						else
						{
							num = -1301403743;
							num3 = num;
						}
						continue;
						end_IL_001e:
						break;
					}
					goto IL_0148;
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
			}
			else
			{
				while (true)
				{
					list = null;
					int num = -1994373003;
					while (true)
					{
						switch (num ^ -1994373004)
						{
						case 0:
							num = -1994373002;
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
			return leHaHiGKLRfwikIkRPeWBAYNSTq.SdmfoteCDVoXNaSlWEvRMBbwmDy(GetPlatformSpecificAssemblyName(), list, configVars);
		}

		private List<Assembly> GetNativeAssembliesFromResources()
		{
			List<TextAsset> list = new List<TextAsset>();
			AddTextAssetInResourcesToList(list, UnityTools.GetCurrentPlatformResourecesDLLPaths());
			List<Assembly> list2 = default(List<Assembly>);
			int num2 = default(int);
			int count = default(int);
			while (true)
			{
				int num = 1558864167;
				while (true)
				{
					switch (num ^ 0x5CEA6126)
					{
					case 4:
						break;
					case 6:
						if (list2.Count == 0)
						{
							num = 1558864163;
							continue;
						}
						return list2;
					case 2:
					{
						int num4;
						if (num2 < count)
						{
							num = 1558864161;
							num4 = num;
						}
						else
						{
							num = 1558864165;
							num4 = num;
						}
						continue;
					}
					case 8:
						count = list.Count;
						num = 1558864166;
						continue;
					case 9:
						num2++;
						num = 1558864164;
						continue;
					case 1:
						list2 = new List<Assembly>();
						num = 1558864174;
						continue;
					case 3:
					{
						int num3;
						if (list2 != null)
						{
							num = 1558864160;
							num3 = num;
						}
						else
						{
							num = 1558864163;
							num3 = num;
						}
						continue;
					}
					case 0:
						num2 = 0;
						num = 1558864164;
						continue;
					case 7:
						if (!(list[num2] == null))
						{
							Assembly item = Assembly.Load(list[num2].bytes);
							list2.Add(item);
							num = 1558864175;
							continue;
						}
						goto case 9;
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
				goto IL_006a;
				IL_0014:
				int num = -1772438421;
				goto IL_0019;
				IL_0019:
				Assembly assembly = default(Assembly);
				List<Assembly> list = default(List<Assembly>);
				while (true)
				{
					switch (num ^ -1772438417)
					{
					case 5:
						break;
					case 1:
						if ((object)assembly == null)
						{
							flag = true;
							throw new Exception();
						}
						goto case 3;
					case 6:
						list.Add(assembly);
						num = -1772438424;
						continue;
					case 0:
						goto IL_006a;
					case 3:
						list = new List<Assembly>();
						num = -1772438423;
						continue;
					case 4:
						return null;
					case 2:
						goto IL_00a4;
					default:
						return list;
					}
					break;
				}
				goto IL_0014;
				IL_006a:
				Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
				if (assemblies == null)
				{
					flag = true;
					throw new Exception();
				}
				goto IL_00a4;
				IL_00a4:
				assembly = Array.Find(assemblies, (Assembly x) => string.Equals(x.GetName().Name, GetPlatformSpecificAssemblyName(), StringComparison.OrdinalIgnoreCase));
				num = -1772438418;
				goto IL_0019;
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

		private byte[] GetNativeDLLBytesByReflection()
		{
			byte[] result = default(byte[]);
			try
			{
				string platformSpecificAssemblyName = GetPlatformSpecificAssemblyName();
				string assemblyName = default(string);
				string classPath = default(string);
				Type typeInAssembly = default(Type);
				while (true)
				{
					IL_0007:
					int num = 2118954465;
					while (true)
					{
						switch (num ^ 0x7E4CADE9)
						{
						case 6:
							break;
						case 7:
							assemblyName = platformSpecificAssemblyName + "_Lib";
							classPath = "Rewired.Internal.PlatformDLL";
							num = 2118954475;
							continue;
						case 1:
							result = null;
							goto end_IL_000c;
						case 2:
						{
							int num2;
							if (!ReflectionTools.IsAssemblyLoaded(assemblyName, useShortName: true, ignoreCase: true))
							{
								num = 2118954476;
								num2 = num;
							}
							else
							{
								num = 2118954473;
								num2 = num;
							}
							continue;
						}
						case 4:
							goto end_IL_000c;
						case 8:
						{
							int num3;
							if (!string.IsNullOrEmpty(platformSpecificAssemblyName))
							{
								num = 2118954478;
								num3 = num;
							}
							else
							{
								num = 2118954472;
								num3 = num;
							}
							continue;
						}
						case 0:
							typeInAssembly = ReflectionTools.GetTypeInAssembly(classPath, assemblyName);
							if ((object)typeInAssembly == null)
							{
								result = null;
								num = 2118954477;
								continue;
							}
							goto default;
						case 5:
							result = null;
							goto end_IL_000c;
						default:
							result = typeInAssembly.InvokeMember("GetBytes", BindingFlags.Static | BindingFlags.Public | BindingFlags.InvokeMethod, null, null, null) as byte[];
							goto end_IL_000c;
						}
						goto IL_0007;
						continue;
						end_IL_000c:
						break;
					}
					break;
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
				goto IL_0046;
			}
			return;
			IL_0046:
			int num = 0;
			int num2 = -534235025;
			goto IL_000e;
			IL_0009:
			num2 = -534235032;
			goto IL_000e;
			IL_000e:
			TextAsset textAsset = default(TextAsset);
			while (true)
			{
				switch (num2 ^ -534235027)
				{
				case 7:
					break;
				case 6:
					num++;
					num2 = -534235025;
					continue;
				case 4:
					goto IL_0046;
				case 1:
					list.Add(textAsset);
					num2 = -534235029;
					continue;
				case 3:
					return;
				case 0:
				{
					string text = dllPaths[num];
					if (string.IsNullOrEmpty(text))
					{
						goto case 6;
					}
					textAsset = (TextAsset)Resources.Load(text);
					if (textAsset == null)
					{
						Logger.LogError(dllPaths[num] + " not found in Resources!");
						num2 = -534235026;
						continue;
					}
					goto case 1;
				}
				case 5:
					return;
				default:
					if (num >= dllPaths.Count)
					{
						return;
					}
					goto case 0;
				}
				break;
			}
			goto IL_0009;
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
				int num = -1720263483;
				while (true)
				{
					switch (num ^ -1720263484)
					{
					case 5:
						break;
					case 6:
						platform = Platform.OSX;
						num = -1720263485;
						continue;
					case 2:
						goto IL_006f;
					case 0:
						goto IL_007d;
					case 3:
						result = "Unsupported Unity editor platform detected. Input is not guarateed to function in the editor.";
						num = -1720263485;
						continue;
					case 4:
						switch (editorPlatform)
						{
						case EditorPlatform.OSX:
							break;
						case EditorPlatform.Windows:
							goto IL_006f;
						case EditorPlatform.Linux:
							goto IL_007d;
						default:
							goto IL_00ac;
						}
						goto case 6;
					case 1:
						editorPlatform = this.editorPlatform;
						num = -1720263488;
						continue;
					default:
						{
							return result;
						}
						IL_00ac:
						num = -1720263481;
						continue;
						IL_007d:
						platform = Platform.Linux;
						num = -1720263485;
						continue;
						IL_006f:
						platform = Platform.Windows;
						num = -1720263485;
						continue;
					}
					break;
				}
			}
		}

		private bool CheckEditorPlatformMatches()
		{
			EditorPlatform editorPlatform = this.editorPlatform;
			while (true)
			{
				int num = -988757100;
				while (true)
				{
					switch (num ^ -988757097)
					{
					case 0:
						break;
					case 3:
						switch (editorPlatform)
						{
						case EditorPlatform.Windows:
							goto IL_0051;
						case EditorPlatform.OSX:
							goto IL_0063;
						case EditorPlatform.Linux:
							goto IL_006e;
						}
						num = -988757098;
						continue;
					case 2:
						goto IL_0051;
					default:
						return true;
					case 1:
						{
							return false;
						}
						IL_006e:
						if (platform == Platform.Linux)
						{
							return true;
						}
						goto case 1;
						IL_0051:
						if (platform == Platform.Windows)
						{
							num = -988757101;
							continue;
						}
						goto case 1;
						IL_0063:
						if (platform == Platform.OSX)
						{
							return true;
						}
						goto case 1;
					}
					break;
				}
			}
		}

		private string GetPlatformSpecificAssemblyName()
		{
			if (!ReInput.isEditor && ReInput.webplayerPlatform != WebplayerPlatform.None)
			{
				while (true)
				{
					switch (-1809699687 ^ -1809699688)
					{
					case 0:
						continue;
					case 1:
						return string.Empty;
					}
					break;
				}
			}
			else
			{
				switch (ReInput.currentPlatform)
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
			}
			return "Rewired_Windows";
		}

		private bool IsOnlyManagerInScene()
		{
			_duplicateRIMError = false;
			if (ReInput.isReady)
			{
				if (Application.isPlaying)
				{
					while (true)
					{
						int num = -371654940;
						while (true)
						{
							switch (num ^ -371654939)
							{
							case 0:
								break;
							case 1:
								if (Application.isEditor)
								{
									goto IL_003a;
								}
								goto default;
							default:
								UnityEngine.Object.Destroy(base.gameObject);
								return false;
							}
							break;
							IL_003a:
							Logger.LogWarning("Only one Rewired Input Manager may exist in a scene. This additional Rewired Input Manager game object will be deleted. You may see this warning if you are loading a new level that contains a Rewired Input Manager. If that's the case, you can safely ignore this warning. This warning will never be logged in a build.");
							num = -371654937;
						}
					}
				}
				_duplicateRIMError = true;
				Logger.LogWarning("Only one Rewired Input Manager may exist in a scene.");
				return false;
			}
			return true;
		}

		protected void RecompileStart()
		{
			ReInput.SXofuRsarRbvQZOgnqnsdRXgTwh();
			ReInput.quspWzJVXrmjPHcaqaRsQonICCC();
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
				ReInput.CYKTSYbnXKEiLBWozMzHDlAGJERW();
			}
		}

		private void HandleException(ExceptionPoint location, string message, Exception exception)
		{
			message = "Rewired: An exception occurred during " + message + ".";
			bool flag = default(bool);
			while (true)
			{
				int num = 177927540;
				while (true)
				{
					switch (num ^ 0xA9AF575)
					{
					case 2:
						break;
					default:
						return;
					case 1:
					{
						flag = false;
						int num2;
						switch (location)
						{
						default:
							num = 177927542;
							num2 = num;
							continue;
						case ExceptionPoint.Destroy:
							num = 177927539;
							num2 = num;
							continue;
						case ExceptionPoint.Initialization:
							break;
						}
						goto case 6;
					}
					case 3:
						message += " Rewired will attempt to continue running.";
						num = 177927541;
						continue;
					case 0:
						Logger.LogError(message + "\n\nException:\n" + ((exception.InnerException != null) ? exception.InnerException : exception));
						num = 177927537;
						continue;
					case 6:
						message += " Input will not function.";
						flag = true;
						num = 177927536;
						continue;
					case 5:
						num = 177927541;
						continue;
					case 4:
						if (flag)
						{
							criticalError = true;
							num = 177927538;
							continue;
						}
						return;
					case 7:
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
			ManualInitialize();
		}

		[CustomObfuscation(rename = false)]
		internal EditorPlatform GetEditorPlatform()
		{
			if (!initialized && !_detectedPlatformInEditor)
			{
				goto IL_0010;
			}
			goto IL_003f;
			IL_003f:
			_detectedPlatformInEditor = true;
			int num = 1525211922;
			goto IL_0015;
			IL_0010:
			num = 1525211921;
			goto IL_0015;
			IL_0015:
			while (true)
			{
				switch (num ^ 0x5AE8E310)
				{
				case 0:
					break;
				case 1:
					DetectPlatform();
					num = 1525211923;
					continue;
				case 3:
					goto IL_003f;
				default:
					return editorPlatform;
				}
				break;
			}
			goto IL_0010;
		}

		[CustomObfuscation(rename = false)]
		internal void GetSupportedEditModeControllerTypes(out bool keyboardSupported, out bool mouseSupported, out bool joystickSupported)
		{
			keyboardSupported = _userData.ConfigVars.IsEditModeInputSupported(ControllerType.Keyboard, editorPlatform);
			while (true)
			{
				int num = 1413966568;
				while (true)
				{
					switch (num ^ 0x54476AE9)
					{
					case 2:
						break;
					case 1:
						goto IL_0037;
					default:
						joystickSupported = _userData.ConfigVars.IsEditModeInputSupported(ControllerType.Joystick, editorPlatform);
						return;
					}
					break;
					IL_0037:
					mouseSupported = _userData.ConfigVars.IsEditModeInputSupported(ControllerType.Mouse, editorPlatform);
					num = 1413966569;
				}
			}
		}

		[CustomObfuscation(rename = false)]
		internal bool IsEditModeSupported()
		{
			if (editorPlatform == EditorPlatform.None)
			{
				GetEditorPlatform();
				goto IL_000f;
			}
			goto IL_0031;
			IL_0087:
			bool flag = default(bool);
			bool flag2 = default(bool);
			bool result = default(bool);
			if (!flag && !flag2)
			{
				return result;
			}
			return true;
			IL_000f:
			int num = 1913926877;
			goto IL_0014;
			IL_0014:
			while (true)
			{
				switch (num ^ 0x721434DC)
				{
				case 0:
					break;
				case 1:
					goto IL_0031;
				case 3:
					flag2 = _userData.ConfigVars.IsEditModeInputSupported(ControllerType.Mouse, editorPlatform);
					result = _userData.ConfigVars.IsEditModeInputSupported(ControllerType.Joystick, editorPlatform);
					num = 1913926878;
					continue;
				default:
					goto IL_0087;
				}
				break;
			}
			goto IL_000f;
			IL_0031:
			flag = _userData.ConfigVars.IsEditModeInputSupported(ControllerType.Keyboard, editorPlatform);
			num = 1913926879;
			goto IL_0014;
		}

		protected abstract void OnInitialized();

		protected abstract void OnDeinitialized();

		protected abstract void DetectPlatform();

		protected abstract void CheckRecompile();

		protected abstract IExternalTools GetExternalTools();
	}
}
