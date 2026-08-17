using System;
using System.Collections.Generic;
using Assets.Scripts.UI.Localization;
using Cpp2ILInjected;
using Rewired;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Localization;
using UnityEngine.UI;

public class KeyListener : MonoBehaviour
{
	public InputSettingNew currentlyChanging;

	public TextMeshProUGUI alertText;

	public TextMeshProUGUI t_countdown;

	public RawImage overlay;

	private bool _003CjustClosed_003Ek__BackingField;

	private float readyForKeyTime;

	private List<InputMapper.Context> contexts;

	public GameObject window;

	private bool result;

	private float timeout;

	public static KeyListener Instance;

	private List<InputMapper> mappers;

	private bool _003CisListening_003Ek__BackingField;

	private EventSystem eventSystem;

	private GameObject focusedObject;

	private bool hasSet;

	public static Action A_MapChanged;

	public static bool hasChangedKey;

	public bool justClosed
	{
		get
		{
			return _003CjustClosed_003Ek__BackingField;
		}
		set
		{
			_003CjustClosed_003Ek__BackingField = value;
		}
	}

	public bool isListening
	{
		get
		{
			return _003CisListening_003Ek__BackingField;
		}
		private set
		{
			_003CisListening_003Ek__BackingField = value;
		}
	}

	private void Awake()
	{
		if (!Instance)
		{
			Instance = this;
			window.SetActive(value: false);
			hasChangedKey = false;
		}
		else
		{
			GameObject obj = base.gameObject;
			UnityEngine.Object.Destroy(obj);
		}
	}

	public void StartListening(InputSettingNew listener, List<InputMapper.Context> contexts)
	{
		//IL_03dd: Expected I, but got O
		//IL_0063: Expected I, but got O
		//IL_0111: Expected I, but got O
		//IL_0149: Expected I, but got O
		//IL_01e9: Expected I, but got O
		//IL_01ff: Expected O, but got I
		//IL_0248: Unknown result type (might be due to invalid IL or missing references)
		//IL_024d: Expected O, but got Unknown
		//IL_0281: Expected I, but got O
		//IL_02db: Expected I, but got O
		//IL_02fa: Expected I, but got O
		//IL_030a: Expected O, but got I
		//IL_0342: Expected I, but got O
		bool flag = (object)overlay == null;
		nint num = (nint)listener;
		GameObject gameObject = (GameObject)(object)overlay;
		if (!flag)
		{
			bool flag2 = overlay.enabled;
			if (flag2 || _003CjustClosed_003Ek__BackingField != flag2)
			{
				return;
			}
			gameObject = window;
			bool flag3 = (object)window == null;
			num = unchecked((nint)null);
			if (!flag3)
			{
				window.SetActive(value: true);
				List<InputMapper.Context> list = default(List<InputMapper.Context>);
				this.contexts = list;
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				bool flag4 = (object)listener == null;
				list = null;
				num = 0;
				gameObject = (GameObject)(object)dictionary;
				if (!flag4)
				{
					gameObject = (GameObject)(object)listener.settingName;
					bool flag5 = (object)listener.settingName == null;
					list = null;
					num = 0;
					if (!flag5)
					{
						nint num2 = (nint)gameObject;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v351 @ r8_v6 (Il2CppClass<UnityEngine.GameObject>)+548] (should have been resolved before IL gen)");
						string text = default(string);
						string value = "</size>\n" + text;
						bool flag6 = dictionary == null;
						list = null;
						num = (nint)text;
						gameObject = (GameObject)(object)"</size>\n";
						if (!flag6)
						{
							((Dictionary<object, object>)(object)dictionary).Add((object)"action", (object)value);
							TextMeshProUGUI textMeshProUGUI = alertText;
							LocalizedString localizedStringReference = LocalizationUtility.GetLocalizedStringReference("SettingsUi", "INPUT_LISTENER");
							object[] array = new object[1];
							bool flag7 = array == null;
							nint num3 = 0;
							list = null;
							num = 1;
							gameObject = (GameObject)(object)typeof(object[]);
							if (!flag7)
							{
								nint num4 = (nint)array;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v360 @ rdx_v15 (Il2CppClass<System.Object[]>)+40]");
								dictionary.Add((string)0, null);
								object obj = default(object);
								bool flag8 = obj == null;
								num3 = 0;
								list = null;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v360 @ rdx_v15 (Il2CppClass<System.Object[]>)+40]");
								num = 0;
								gameObject = (GameObject)(object)dictionary;
								if (flag8)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180269410");
									object obj2 = default(object);
									throw obj2;
								}
								gameObject = (GameObject)(array + 32);
								array[0] = dictionary;
								bool flag9 = localizedStringReference == null;
								num3 = 0;
								list = null;
								num = (nint)dictionary;
								if (!flag9)
								{
									string localizedString = localizedStringReference.GetLocalizedString(array);
									string text2 = "<size=70%>" + localizedString;
									bool flag10 = (object)alertText == null;
									num3 = 0;
									list = null;
									num = (nint)localizedString;
									gameObject = (GameObject)(object)"<size=70%>";
									if (!flag10)
									{
										num3 = (nint)textMeshProUGUI;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v249 @ r9_v2 (Il2CppMethodInfo)+560]");
										list = (List<InputMapper.Context>)0;
										Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v249 @ r9_v2 (Il2CppMethodInfo)+558] (should have been resolved before IL gen)");
										result = false;
										currentlyChanging = listener;
										bool flag11 = (object)overlay == null;
										num = (nint)listener;
										gameObject = (GameObject)(object)overlay;
										if (!flag11)
										{
											overlay.enabled = true;
											hasSet = false;
											float time = Time.time;
											float num5 = time + 0.2f;
											_003CisListening_003Ek__BackingField = false;
											timeout = 5f;
											readyForKeyTime = num5;
											return;
										}
									}
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private bool CanChange()
	{
		float time = Time.time;
		if (!(readyForKeyTime > time))
		{
			return !hasSet;
		}
		return false;
	}

	private void OnInputMapped(InputMapper.InputMappedEventData mapEvent)
	{
		result = true;
		CloseListener(mapEvent.actionElementMap);
		Action a_MapChanged = A_MapChanged;
		if (A_MapChanged != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v46.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	private void StopMappers()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
		List<object>.Enumerator enumerator = default(List<object>.Enumerator);
		InputMapper inputMapper = default(InputMapper);
		while (true)
		{
			if (enumerator.MoveNext())
			{
				if (inputMapper == null)
				{
					break;
				}
				inputMapper.Stop();
				continue;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
			return;
		}
		throw new NullReferenceException();
	}

	private unsafe bool OnIsElementAllowed(ControllerPollingInfo info)
	{
		//IL_0170: Expected O, but got Ref
		//IL_0297: Expected O, but got Ref
		//IL_02da: Expected O, but got I
		//IL_02ea: Expected O, but got I
		//IL_031f: Expected O, but got I
		//IL_033c: Expected O, but got I
		//IL_036f: Expected O, but got I
		//IL_03a4: Expected O, but got I
		//IL_03db: Expected O, but got I
		//IL_0415: Expected O, but got I
		//IL_0428: Expected O, but got Ref
		ReInput.MappingHelper mapping = ReInput.mapping;
		if (mapping != null)
		{
			int actionId = mapping.GetActionId("UIAbort");
			ReInput.PlayerHelper players = ReInput.players;
			if (players != null)
			{
				Player player = players.GetPlayer(0);
				if (player != null)
				{
					Player.ControllerHelper controllers = player.controllers;
					if (player.controllers != null)
					{
						Controller controller = ((ControllerPollingInfo*)info)->controller;
						if (controllers.maps != null)
						{
							ControllerMap map = controllers.maps.GetMap(controller, "UI", "Default");
							if (map != null)
							{
								IList<ActionElementMap> elementMaps = map.ElementMaps;
								if (elementMaps == null)
								{
									goto IL_0500;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
								object obj2 = default(object);
								object obj = (object)(&obj2);
								ControllerMap controllerMap = null;
								object obj3 = default(object);
								object obj4 = default(object);
								List<object>.Enumerator enumerator = default(List<object>.Enumerator);
								object obj5 = default(object);
								object obj9 = default(object);
								while (true)
								{
									if (obj2 != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
										if (obj3 == null)
										{
											break;
										}
										bool flag = obj2 == null;
										controllerMap = null;
										if (!flag)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
											bool flag2 = obj4 == null;
											controllerMap = null;
											if (!flag2)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v793 @ rax_v48+14]");
												bool flag3 = (nint)0 != actionId;
												controllerMap = null;
												if (flag3)
												{
													continue;
												}
												int suMCypVLKCBKCafNdvGgrkCablSoA = info.SuMCypVLKCBKCafNdvGgrkCablSoA;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v793 @ rax_v48+1C]");
												bool flag4 = (nint)suMCypVLKCBKCafNdvGgrkCablSoA != 0;
												controllerMap = null;
												if (flag4)
												{
													continue;
												}
												bool flag5 = contexts == null;
												controllerMap = null;
												if (flag5)
												{
													throw new NullReferenceException();
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
												while (true)
												{
													if (enumerator.MoveNext())
													{
														bool flag6 = obj5 == null;
														controllerMap = (ControllerMap)(&enumerator);
														if (!flag6)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1014 @ stack_-48+20]");
															if ((nint)0 != 0)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1014 @ stack_-48+20]");
																object obj6 = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v430 @ rax_v61+40]");
																controllerMap = (ControllerMap)0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v430 @ rax_v61+40]");
																if ((nint)0 == 0)
																{
																	throw new NullReferenceException();
																}
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1014 @ stack_-48+20]");
																object obj7 = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v430 @ rax_v61+40]");
																nint num = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1058 @ rdx_v34+50]");
																bool flag7 = ((ControllerMap)num).DeleteElementMap(0);
																if ((object)currentlyChanging == null)
																{
																	throw new NullReferenceException();
																}
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1014 @ stack_-48+20]");
																object obj8 = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1014 @ stack_-48+20]");
																if ((nint)0 == 0)
																{
																	throw new NullReferenceException();
																}
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v218 @ rsi_v19+40]");
																controllerMap = (ControllerMap)0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v218 @ rsi_v19+40]");
																if ((nint)0 == 0)
																{
																	throw new NullReferenceException();
																}
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v218 @ rsi_v19+40]");
																ControllerType controllerType = ((ControllerMap)0).controllerType;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v218 @ rsi_v19+40]");
																if ((nint)0 == 0)
																{
																	break;
																}
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v218 @ rsi_v19+40]");
																int controllerId = ((ControllerMap)0).controllerId;
																currentlyChanging.TryRemoveInputKey((InputSettingNew.InputKey)(&obj9));
															}
															continue;
														}
														throw new NullReferenceException();
													}
													((List<InputMapper.Context>.Enumerator*)(&enumerator))->Dispose();
													AudioManager instance = AudioManager.Instance;
													if ((object)AudioManager.Instance != null)
													{
														if ((object)instance.uiAbort != null)
														{
															instance.uiAbort.Play();
															CloseListener(null);
															if (obj != null)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002530");
															}
															return false;
														}
														throw new NullReferenceException();
													}
													throw new NullReferenceException();
												}
											}
											throw new NullReferenceException();
										}
										throw new NullReferenceException();
									}
									throw new NullReferenceException();
								}
								if (obj != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002530");
								}
							}
							return true;
						}
					}
				}
			}
		}
		goto IL_0500;
		IL_0500:
		throw new NullReferenceException();
	}

	private void Update()
	{
		//IL_00d1: Invalid comparison between I4 and F4
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172082]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (!window.activeInHierarchy)
		{
			return;
		}
		float deltaTime = Time.deltaTime;
		double num = Math.Ceiling(timeout -= deltaTime);
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
		object arg = default(object);
		string text = $"{arg}";
		t_countdown.text = text;
		if (0f < timeout)
		{
			float time = Time.time;
			if ((readyForKeyTime > time || hasSet) && !_003CisListening_003Ek__BackingField)
			{
				_003CisListening_003Ek__BackingField = true;
				StartMappers();
			}
		}
		else
		{
			CloseListener(null);
		}
	}

	private void StartMappers()
	{
		//IL_041b: Expected I, but got O
		//IL_00a2: Expected I, but got O
		//IL_0454: Expected I, but got O
		//IL_04a5: Expected I, but got O
		//IL_00e7: Expected I, but got O
		//IL_04bc: Expected I, but got O
		//IL_0146: Expected I, but got O
		//IL_018c: Expected I, but got O
		//IL_01a2: Expected I, but got O
		//IL_0518: Expected O, but got I
		List<InputMapper.Context> list = contexts;
		_003CisListening_003Ek__BackingField = true;
		if (contexts != null)
		{
			int num = 0;
			int num2 = 0;
			while (true)
			{
				if (num2 >= list._size)
				{
					return;
				}
				List<InputMapper> list2 = mappers;
				if (mappers == null)
				{
					break;
				}
				nint num3;
				if (list2._size <= num)
				{
					InputMapper inputMapper = new InputMapper();
					Action<InputMapper.InputMappedEventData> action = OnInputMapped;
					bool flag = inputMapper == null;
					num3 = (nint)action;
					if (flag)
					{
						break;
					}
					inputMapper.InputMappedEvent += action;
					InputMapper.Options options = inputMapper.options;
					bool flag2 = options == null;
					num3 = (nint)action;
					if (flag2)
					{
						break;
					}
					Predicate<ControllerPollingInfo> isElementAllowedCallback = options.isElementAllowedCallback;
					Predicate<ControllerPollingInfo> predicate = OnIsElementAllowed;
					Delegate obj = Delegate.Combine(isElementAllowedCallback, predicate);
					bool flag3 = (object)obj == null;
					nint num4 = (nint)predicate;
					Delegate obj2 = obj;
					Delegate obj3;
					if (!flag3)
					{
						((KeyListener)(object)obj).OnInputMapped((InputMapper.InputMappedEventData)(object)typeof(Predicate<ControllerPollingInfo>));
						bool flag4 = (object)obj2 == null;
						num4 = (nint)typeof(Predicate<ControllerPollingInfo>);
						obj3 = obj;
						num3 = (nint)typeof(Predicate<ControllerPollingInfo>);
						if (flag4)
						{
							((KeyListener)(object)obj3).OnInputMapped((InputMapper.InputMappedEventData)num3);
							return;
						}
					}
					options.isElementAllowedCallback = (Predicate<ControllerPollingInfo>)obj2;
					InputMapper.Options options2 = inputMapper.options;
					bool flag5 = options2 == null;
					obj3 = obj;
					num3 = num4;
					if (flag5)
					{
						break;
					}
					options2.XQybKHKbxTzhukVtalxsTTXvNRBhA = false;
					InputMapper.Options options3 = inputMapper.options;
					bool flag6 = options3 == null;
					obj3 = obj;
					num3 = num4;
					if (flag6)
					{
						break;
					}
					options3.QOfTqopEudSGAochEcPCfqsnnGUG = true;
					InputMapper.Options options4 = inputMapper.options;
					bool flag7 = options4 == null;
					obj3 = obj;
					num3 = num4;
					if (flag7)
					{
						break;
					}
					options4.QgsQXttsPZtJziUKOkPKlxTetLwX = true;
					InputMapper.Options options5 = inputMapper.options;
					bool flag8 = options5 == null;
					obj3 = obj;
					num3 = num4;
					if (flag8)
					{
						break;
					}
					options5.gHJBCscfexewlslMphVtnAIzpwAGA = true;
					InputMapper.Options options6 = inputMapper.options;
					bool flag9 = options6 == null;
					obj3 = obj;
					num3 = num4;
					if (flag9)
					{
						break;
					}
					options6.mhBZabjWcbNFfxZWAkLOdOYmVbxg = true;
					InputMapper.Options options7 = inputMapper.options;
					bool flag10 = options7 == null;
					obj3 = obj;
					num3 = num4;
					if (flag10)
					{
						break;
					}
					options7.timeout = 5f;
					bool flag11 = mappers == null;
					obj3 = obj;
					num3 = num4;
					if (flag11)
					{
						break;
					}
					mappers.Add(inputMapper);
					obj3 = obj;
					num3 = num4;
				}
				if (mappers == null)
				{
					break;
				}
				InputMapper inputMapper2 = mappers.get_Item(num);
				bool flag12 = contexts == null;
				num3 = (nint)inputMapper2;
				if (flag12)
				{
					break;
				}
				InputMapper.Context mappingContext = contexts.get_Item(num);
				bool flag13 = inputMapper2 == null;
				num3 = (nint)inputMapper2;
				if (flag13)
				{
					break;
				}
				bool flag14 = inputMapper2.Start(mappingContext);
				list = contexts;
				num++;
				bool flag15 = contexts == null;
				num3 = (nint)inputMapper2;
				if (flag15)
				{
					break;
				}
				num3 = (nint)inputMapper2;
				num2 = num;
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void OnDestroy()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
		List<object>.Enumerator enumerator = default(List<object>.Enumerator);
		InputMapper inputMapper = default(InputMapper);
		while (true)
		{
			InputMapper.Options options;
			Delegate obj2;
			if (enumerator.MoveNext())
			{
				Action<InputMapper.InputMappedEventData> value = OnInputMapped;
				if (inputMapper == null)
				{
					break;
				}
				inputMapper.InputMappedEvent -= value;
				options = inputMapper.options;
				if (options != null)
				{
					Predicate<ControllerPollingInfo> isElementAllowedCallback = options.isElementAllowedCallback;
					Predicate<ControllerPollingInfo> value2 = OnIsElementAllowed;
					Delegate obj = Delegate.Remove(isElementAllowedCallback, value2);
					bool flag = (object)obj == null;
					obj2 = obj;
					if (flag)
					{
						goto IL_0109;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
					if ((object)obj2 != null)
					{
						goto IL_0109;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				}
				throw new NullReferenceException();
			}
			((List<InputMapper>.Enumerator*)(&enumerator))->Dispose();
			return;
			IL_0109:
			options.isElementAllowedCallback = (Predicate<ControllerPollingInfo>)obj2;
		}
		throw new NullReferenceException();
	}

	private void CloseListener(ActionElementMap newActionElementMap)
	{
		if (hasSet || _003CjustClosed_003Ek__BackingField || !window.activeInHierarchy || !(currentlyChanging != null))
		{
			return;
		}
		currentlyChanging.UpdateMapping(result, newActionElementMap);
		StopMappers();
		if (result)
		{
			AudioManager instance = AudioManager.Instance;
			instance.uiInputSet.Play();
			if (result)
			{
				hasChangedKey = true;
			}
		}
		hasSet = true;
		currentlyChanging = null;
		_003CjustClosed_003Ek__BackingField = true;
		Invoke("Close", 0.1f);
		Invoke("Cooldown", 0.25f);
	}

	private void Close()
	{
		window.SetActive(value: false);
		overlay.enabled = false;
		_003CisListening_003Ek__BackingField = false;
	}

	private void Cooldown()
	{
		_003CjustClosed_003Ek__BackingField = false;
	}

	public bool IsListening()
	{
		bool flag = _003CisListening_003Ek__BackingField;
		bool flag2 = true;
		if (!flag)
		{
			flag2 = _003CjustClosed_003Ek__BackingField;
		}
		return flag2;
	}

	public KeyListener()
	{
		List<InputMapper> list = new List<InputMapper>();
		mappers = list;
		hasSet = true;
		base._002Ector();
	}
}
