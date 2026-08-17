using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Rewired;
using UnityEngine;
using UnityEngine.UI;

namespace VampireSurvivors.UI;

public class UIHelper : MonoBehaviour
{
	public delegate void OnInputMethodChanged(ActiveInputType newInput);

	public enum ActiveInputType
	{
		VOID,
		MOUSE,
		KEYBOARD,
		CONTROLLER
	}

	private bool _ForceAspectRatio;

	private RectTransform _SafeArea;

	private RectTransform _AspectMask;

	private bool _DisablePixelPerfectOnLowEndDevices;

	private Vector3 _prevMousePos;

	private ActiveInputType _prevInput;

	private static OnInputMethodChanged m_InputMethodChanged;

	private Canvas _canvas;

	private ActiveInputType _currentInput;

	private static UIHelper Instance;

	private static float _scaleFactor = 1f;

	public static float JS_MAGIC_SCALE_NUMBER = 1.6f;

	public static Canvas Canvas
	{
		get
		{
			UIHelper instance = Instance;
			if ((object)Instance != null && ((UnityEngine.Object)instance).m_CachedPtr != (IntPtr)0)
			{
				UIHelper instance2 = Instance;
				if ((object)Instance != null)
				{
					return instance2._canvas;
				}
				return (Canvas)(object)new NullReferenceException();
			}
			return null;
		}
	}

	public static ActiveInputType ActiveInput
	{
		get
		{
			//IL_008e: Expected I4, but got O
			UIHelper instance = Instance;
			if ((object)Instance != null && ((UnityEngine.Object)instance).m_CachedPtr != (IntPtr)0)
			{
				UIHelper instance2 = Instance;
				if ((object)Instance != null)
				{
					return instance2._currentInput;
				}
				NullReferenceException ex = new NullReferenceException();
				return (ActiveInputType)ex;
			}
			return ActiveInputType.VOID;
		}
	}

	public static float ScaleFactor
	{
		get
		{
			UIHelper instance = Instance;
			if ((object)Instance != null && ((UnityEngine.Object)instance).m_CachedPtr != (IntPtr)0)
			{
				UIHelper instance2 = Instance;
				if ((object)Instance != null && (object)instance2._canvas != null)
				{
					RenderMode renderMode = instance2._canvas.renderMode;
					if (renderMode == RenderMode.WorldSpace)
					{
						return _scaleFactor;
					}
					UIHelper instance3 = Instance;
					if ((object)Instance != null && (object)instance3._canvas != null)
					{
						float scaleFactor = instance3._canvas.scaleFactor;
						_scaleFactor = scaleFactor;
						UIHelper instance4 = Instance;
						if ((object)Instance != null && (object)instance4._canvas != null)
						{
							return instance4._canvas.scaleFactor;
						}
					}
				}
				throw new NullReferenceException();
			}
			return _scaleFactor;
		}
	}

	public static float ScreenHeight
	{
		get
		{
			//IL_00be: Expected F4, but got I4
			//IL_00b0: Expected O, but got I4
			UIHelper instance = Instance;
			if ((object)Instance != null && ((UnityEngine.Object)instance).m_CachedPtr != (IntPtr)0)
			{
				object obj = Screen.height;
				float scaleFactor = ScaleFactor;
				float num = scaleFactor * 100f;
				float num2 = (float)obj / num;
				return num2 * 100f;
			}
			return Screen.height;
		}
	}

	public unsafe static float SafeScreenHeight
	{
		get
		{
			UIHelper instance = Instance;
			float ret;
			float num3 = default(float);
			if ((object)Instance != null && ((UnityEngine.Object)instance).m_CachedPtr != (IntPtr)0)
			{
				Screen.get_safeArea_Injected(out *(Rect*)(&ret));
				float scaleFactor = ScaleFactor;
				float num = scaleFactor * 100f;
				float num2 = num3 / num;
				return num2 * 100f;
			}
			Screen.get_safeArea_Injected(out *(Rect*)(&ret));
			return num3;
		}
	}

	public unsafe static float SafeScreenWidth
	{
		get
		{
			UIHelper instance = Instance;
			float ret;
			float num3 = default(float);
			if ((object)Instance != null && ((UnityEngine.Object)instance).m_CachedPtr != (IntPtr)0)
			{
				Screen.get_safeArea_Injected(out *(Rect*)(&ret));
				float scaleFactor = ScaleFactor;
				float num = scaleFactor * 100f;
				float num2 = num3 / num;
				return num2 * 100f;
			}
			Screen.get_safeArea_Injected(out *(Rect*)(&ret));
			return num3;
		}
	}

	public static bool IsPortrait
	{
		get
		{
			//IL_0071: Expected O, but got I4
			//IL_00c7: Expected O, but got I4
			//IL_0092->IL003a: Incompatible stack heights: 1 vs 0
			Camera main = Camera.main;
			if ((object)main != null)
			{
				bool flag = ((UnityEngine.Object)main).m_CachedPtr == (IntPtr)0;
				object obj = Camera.get_pixelHeight_Injected(((UnityEngine.Object)main).m_CachedPtr);
				Camera main2 = Camera.main;
				if ((object)main2 != null)
				{
					bool flag2 = ((UnityEngine.Object)main2).m_CachedPtr == (IntPtr)0;
					object obj2 = Camera.get_pixelWidth_Injected(((UnityEngine.Object)main2).m_CachedPtr);
					object obj3 = obj - obj2;
					object obj4 = obj ^ obj2;
					object obj5 = obj ^ obj3;
					object obj6 = obj4 & obj5;
					bool flag3 = (nint)obj6 < 0;
					bool flag4 = (nint)obj3 < 0;
					bool flag5 = obj3 == null;
					bool flag6 = flag4 == flag3;
					bool flag7 = !flag5;
					return flag7 & flag6;
				}
			}
			throw new NullReferenceException();
		}
	}

	public static float WidthToHeightRatio
	{
		get
		{
			//IL_0071: Expected O, but got I4
			//IL_00c7: Expected O, but got I4
			//IL_0092->IL003a: Incompatible stack heights: 1 vs 0
			Camera main = Camera.main;
			if ((object)main != null)
			{
				bool flag = ((UnityEngine.Object)main).m_CachedPtr == (IntPtr)0;
				object obj = Camera.get_pixelHeight_Injected(((UnityEngine.Object)main).m_CachedPtr);
				Camera main2 = Camera.main;
				if ((object)main2 != null)
				{
					bool flag2 = ((UnityEngine.Object)main2).m_CachedPtr == (IntPtr)0;
					object obj2 = Camera.get_pixelWidth_Injected(((UnityEngine.Object)main2).m_CachedPtr);
					return (float)obj / (float)obj2;
				}
			}
			throw new NullReferenceException();
		}
	}

	public static bool IsPortraitAndMobile => false;

	public static float ScreenWidth
	{
		get
		{
			//IL_00be: Expected F4, but got I4
			//IL_00b0: Expected O, but got I4
			UIHelper instance = Instance;
			if ((object)Instance != null && ((UnityEngine.Object)instance).m_CachedPtr != (IntPtr)0)
			{
				object obj = Screen.width;
				float scaleFactor = ScaleFactor;
				float num = scaleFactor * 100f;
				float num2 = (float)obj / num;
				return num2 * 100f;
			}
			return Screen.width;
		}
	}

	public static Vector2 SafeArea
	{
		get
		{
			UIHelper instance = Instance;
			Rect ret;
			Rect ret2;
			Vector2 result = default(Vector2);
			if ((object)Instance != null && ((UnityEngine.Object)instance).m_CachedPtr != (IntPtr)0)
			{
				Screen.get_safeArea_Injected(out ret);
				float scaleFactor = ScaleFactor;
				Screen.get_safeArea_Injected(out ret2);
				float scaleFactor2 = ScaleFactor;
				return result;
			}
			Screen.get_safeArea_Injected(out ret);
			Screen.get_safeArea_Injected(out ret2);
			return result;
		}
	}

	public static float AspectRatio
	{
		get
		{
			//IL_000e: Expected O, but got I4
			//IL_001c: Expected O, but got I4
			object obj = Screen.width;
			object obj2 = Screen.height;
			return (float)obj / (float)obj2;
		}
	}

	public static event OnInputMethodChanged InputMethodChanged
	{
		add
		{
			Delegate obj = UIHelper.m_InputMethodChanged;
			while (true)
			{
				Delegate obj2 = Delegate.Combine(obj, value);
				bool flag = (object)obj2 == null;
				Delegate obj3 = null;
				if (!flag)
				{
					bool flag2 = (object)obj2.GetType() != typeof(OnInputMethodChanged);
					obj3 = null;
					if (!flag2)
					{
						obj3 = obj2;
					}
					if ((object)obj3 == null)
					{
						break;
					}
				}
				bool flag3 = (object)obj == UIHelper.m_InputMethodChanged;
				Delegate obj4;
				if ((object)obj == UIHelper.m_InputMethodChanged)
				{
					UIHelper.m_InputMethodChanged = (OnInputMethodChanged)obj3;
					obj4 = obj;
				}
				else
				{
					obj4 = UIHelper.m_InputMethodChanged;
				}
				Delegate obj5 = obj;
				if (!flag3)
				{
					obj5 = obj4;
				}
				bool flag4 = (object)obj5 != obj;
				obj = obj5;
				if (!flag4)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
		remove
		{
			Delegate obj = UIHelper.m_InputMethodChanged;
			while (true)
			{
				Delegate obj2 = Delegate.Remove(obj, value);
				bool flag = (object)obj2 == null;
				Delegate obj3 = null;
				if (!flag)
				{
					bool flag2 = (object)obj2.GetType() != typeof(OnInputMethodChanged);
					obj3 = null;
					if (!flag2)
					{
						obj3 = obj2;
					}
					if ((object)obj3 == null)
					{
						break;
					}
				}
				bool flag3 = (object)obj == UIHelper.m_InputMethodChanged;
				Delegate obj4;
				if ((object)obj == UIHelper.m_InputMethodChanged)
				{
					UIHelper.m_InputMethodChanged = (OnInputMethodChanged)obj3;
					obj4 = obj;
				}
				else
				{
					obj4 = UIHelper.m_InputMethodChanged;
				}
				Delegate obj5 = obj;
				if (!flag3)
				{
					obj5 = obj4;
				}
				bool flag4 = (object)obj5 != obj;
				obj = obj5;
				if (!flag4)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
	}

	public static float GetAspectLockedWidth()
	{
		//IL_00d8: Expected O, but got I4
		//IL_0094: Expected O, but got I4
		//IL_00aa: Invalid comparison between O and F4
		object obj = Screen.width;
		object obj2 = Screen.height;
		object obj3 = obj / obj2;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.5625f))
		{
			return ScreenWidth;
		}
		float num = 0.5625f / (float)obj3;
		float screenWidth = ScreenWidth;
		float num2 = screenWidth * num;
		NumberFormatInfo currentInfo = NumberFormatInfo.CurrentInfo;
		string text = System.Number.FormatSingle(num2, null, currentInfo);
		string message = "Aspect locked screen width : " + text;
		Debug.Log(message);
		return num2;
	}

	public static RectTransform GetSafeAreaObject()
	{
		UIHelper instance = Instance;
		if ((object)Instance != null)
		{
			return instance._SafeArea;
		}
		return (RectTransform)(object)new NullReferenceException();
	}

	private void Awake()
	{
		Instance = this;
		Canvas component = GetComponent<Canvas>();
		_canvas = component;
		if (!IsPortrait)
		{
			SetUpLandscape();
		}
	}

	private unsafe void Update()
	{
		//IL_00d2: Expected O, but got I
		//IL_0118: Invalid comparison between F4 and I4
		//IL_0150: Expected O, but got I
		//IL_01b8: Expected O, but got I
		//IL_0220: Expected O, but got I
		//IL_027a: Expected O, but got I
		//IL_02ad: Expected O, but got Ref
		//IL_032f: Expected I, but got O
		//IL_0377: Expected O, but got I
		//IL_03aa: Expected O, but got Ref
		//IL_04b1: Invalid comparison between F4 and I4
		ReInput.PlayerHelper players = ReInput.players;
		bool flag = players == null;
		ReInput.PlayerHelper playerHelper = null;
		if (!flag)
		{
			IList<Rewired.Player> players2 = players.Players;
			if (players2 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809BC2D0");
				object obj = default(object);
				if (obj != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v242 @ rax_v26+50]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v242 @ rax_v26+50]");
						Mouse mouse = ((Rewired.Player.ControllerHelper)0).Mouse;
						if (mouse != null)
						{
							Vector2 screenPositionDelta = mouse.screenPositionDelta;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1829A85B0");
							float num = default(float);
							if (num > 0f)
							{
								_currentInput = ActiveInputType.MOUSE;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v242 @ rax_v26+50]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v242 @ rax_v26+50]");
								Keyboard keyboard = ((Rewired.Player.ControllerHelper)0).Keyboard;
								if (keyboard != null)
								{
									if (keyboard.GetAnyButton())
									{
										_currentInput = ActiveInputType.KEYBOARD;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v242 @ rax_v26+50]");
									if ((nint)0 != 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v242 @ rax_v26+50]");
										Mouse mouse2 = ((Rewired.Player.ControllerHelper)0).Mouse;
										if (mouse2 != null)
										{
											if (mouse2.GetAnyButton())
											{
												_currentInput = ActiveInputType.MOUSE;
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v242 @ rax_v26+50]");
											if ((nint)0 != 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v242 @ rax_v26+50]");
												int joystickCount = ((Rewired.Player.ControllerHelper)0).joystickCount;
												if (joystickCount <= 0)
												{
													goto IL_054b;
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v242 @ rax_v26+50]");
												if ((nint)0 != 0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v242 @ rax_v26+50]");
													IList<Joystick> joysticks = ((Rewired.Player.ControllerHelper)0).Joysticks;
													if (joysticks != null)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
														object obj3 = default(object);
														object obj2 = (object)(&obj3);
														playerHelper = null;
														object obj4 = default(object);
														ReInput.PlayerHelper playerHelper2 = default(ReInput.PlayerHelper);
														object obj5 = default(object);
														object obj7 = default(object);
														object obj8 = default(object);
														ControllerWithAxes controllerWithAxes = default(ControllerWithAxes);
														while (true)
														{
															if (obj3 != null)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
																if (obj4 == null)
																{
																	break;
																}
																bool flag2 = obj3 == null;
																playerHelper = null;
																if (!flag2)
																{
																	Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809C6E70");
																	if (playerHelper2 != null)
																	{
																		nint num2 = (nint)playerHelper2;
																		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v949 @ rdx_v29 (Il2CppClass<Rewired.ReInput+PlayerHelper>)+298] (should have been resolved before IL gen)");
																		if (obj5 != null)
																		{
																			_currentInput = ActiveInputType.CONTROLLER;
																		}
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v242 @ rax_v26+50]");
																		if ((nint)0 != 0)
																		{
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v242 @ rax_v26+50]");
																			IList<Joystick> joysticks2 = ((Rewired.Player.ControllerHelper)0).Joysticks;
																			if (joysticks2 != null)
																			{
																				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
																				object obj6 = (object)(&obj7);
																				playerHelper = null;
																				while (true)
																				{
																					if (obj7 != null)
																					{
																						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
																						if (obj8 == null)
																						{
																							break;
																						}
																						bool flag3 = obj7 == null;
																						playerHelper = null;
																						if (!flag3)
																						{
																							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809C6E70");
																							bool flag4 = controllerWithAxes == null;
																							playerHelper = null;
																							if (!flag4)
																							{
																								float axis = controllerWithAxes.GetAxis(0);
																								float axis2 = controllerWithAxes.GetAxis(1);
																								float axis3 = controllerWithAxes.GetAxis(2);
																								num = controllerWithAxes.GetAxis(3);
																								float num3 = axis + axis2;
																								float num4 = num3 + axis3;
																								float num5 = num4 + num;
																								bool flag5 = num5 == 0f;
																								Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186DFDD8Eh\"");
																								if (!flag5)
																								{
																									_currentInput = ActiveInputType.CONTROLLER;
																								}
																								continue;
																							}
																							throw new NullReferenceException();
																						}
																						throw new NullReferenceException();
																					}
																					throw new NullReferenceException();
																				}
																				bool flag6 = obj6 == null;
																				playerHelper = null;
																				if (!flag6)
																				{
																					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
																					playerHelper = null;
																				}
																				continue;
																			}
																			throw new NullReferenceException();
																		}
																		throw new NullReferenceException();
																	}
																	throw new NullReferenceException();
																}
																throw new NullReferenceException();
															}
															throw new NullReferenceException();
														}
														if (obj2 != null)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
														}
														goto IL_054b;
													}
												}
											}
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
		IL_054b:
		ActiveInputType activeInput = ActiveInput;
		if (activeInput != _prevInput)
		{
			OnInputMethodChanged inputMethodChanged = UIHelper.m_InputMethodChanged;
			if (UIHelper.m_InputMethodChanged != null)
			{
				ActiveInputType activeInput2 = ActiveInput;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v855.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		}
		ActiveInputType activeInput3 = ActiveInput;
		_prevInput = activeInput3;
	}

	private void OnDestroy()
	{
		//IL_00f1: Expected O, but got I4
		//IL_010b: Expected O, but got I4
		UIHelper instance = Instance;
		bool flag = (object)Instance == null;
		bool flag2 = (object)this == null;
		object obj = flag2 & flag;
		bool flag3 = obj == null;
		object obj2 = !flag3;
		if (obj2 == null)
		{
			bool flag4;
			if ((object)this != null)
			{
				if ((object)Instance != null)
				{
					object obj3 = (object)Instance - (object)this;
					flag4 = obj3 == null;
				}
				else
				{
					flag4 = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
				}
			}
			else
			{
				flag4 = ((UnityEngine.Object)instance).m_CachedPtr == (IntPtr)0;
			}
			if (!flag4)
			{
				return;
			}
		}
		Instance = null;
	}

	private unsafe void SetUpLandscape()
	{
		//IL_012f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0134: Expected Ref, but got Unknown
		//IL_0171: Unknown result type (might be due to invalid IL or missing references)
		//IL_0176: Expected Ref, but got Unknown
		//IL_008f: Invalid comparison between F4 and O
		GameObject gameObject = _SafeArea.gameObject;
		AspectRatioFitter aspectRatioFitter = gameObject.AddComponent<AspectRatioFitter>();
		bool flag = UnityEngine.UI.SetPropertyUtility.SetStruct(ref *(System.Int32Enum*)(aspectRatioFitter + 32), (System.Int32Enum)3);
		bool flag2 = !flag;
		AspectRatioFitter.AspectMode newValue = AspectRatioFitter.AspectMode.FitInParent;
		if (!flag2)
		{
			aspectRatioFitter.UpdateRect();
			newValue = AspectRatioFitter.AspectMode.None;
		}
		if (UnityEngine.UI.SetPropertyUtility.SetStruct(ref *(AspectRatioFitter.AspectMode*)(aspectRatioFitter + 36), newValue))
		{
			aspectRatioFitter.UpdateRect();
		}
		CanvasScaler component = GetComponent<CanvasScaler>();
		component.m_ScreenMatchMode = CanvasScaler.ScreenMatchMode.Expand;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1851B10F0");
		object obj = default(object);
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1.6f) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) && !_ForceAspectRatio)
		{
			RectTransform component2 = aspectRatioFitter.GetComponent<RectTransform>();
			aspectRatioFitter.enabled = false;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182B07BB0");
			Vector2 offsetMax = default(Vector2);
			component2.offsetMax = offsetMax;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182B07BB0");
			Vector2 offsetMin = default(Vector2);
			component2.offsetMin = offsetMin;
		}
	}

	public UIHelper()
	{
		//IL_0020: Expected I, but got O
		//IL_005b: Expected I, but got O
		_ForceAspectRatio = true;
		nint num = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rax_v2 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num2 = 0;
		_prevMousePos = Vector3.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rdx_v1 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
		_ = 0;
		nint num3 = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ rcx_v3 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
