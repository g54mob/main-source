using System;
using System.Collections;
using System.Collections.Generic;
using Cpp2ILInjected;
using Doozy.Engine.Events;
using Doozy.Engine.Progress;
using Doozy.Engine.Settings;
using Doozy.Engine.UI.Animation;
using Doozy.Engine.UI.Base;
using Doozy.Engine.UI.Input;
using Doozy.Engine.UI.Settings;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Internal;
using UnityEngine.UI;

namespace Doozy.Engine.UI;

public class UIToggle : UIComponentBase<UIToggle>, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, IPointerClickHandler, ISelectHandler, IDeselectHandler
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003C_002Ecctor_003Eb__75_0(UIToggle _003Cp0_003E, UIToggleState _003Cp1_003E, UIToggleBehaviorType _003Cp2_003E)
		{
		}
	}

	private sealed class _003CDeselectToggleEnumerator_003Ed__70(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public float delay;

		public UIToggle _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_0087: Expected I4, but got I8
			//IL_00ca: Expected I4, but got O
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				WaitForSecondsRealtime waitForSecondsRealtime = null;
				waitForSecondsRealtime._003CwaitTime_003Ek__BackingField = delay;
				waitForSecondsRealtime.m_WaitUntilTime = -1f;
				_003C_003E2__current = waitForSecondsRealtime;
				_003C_003E1__state = 1;
				return true;
			}
			if (_003C_003E1__state == 1)
			{
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this == null)
				{
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
				_003C_003E4__this.DeselectToggle();
			}
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			NotSupportedException ex = new NotSupportedException();
			throw ex;
		}
	}

	private sealed class _003CDisableToggleBehaviorEnumerator_003Ed__73(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public UIToggleBehavior behavior;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_001e: Expected I4, but got I8
			//IL_00f4: Expected I4, but got I8
			//IL_0134: Expected I4, but got O
			if (_003C_003E1__state == 0)
			{
				UIToggleBehavior uIToggleBehavior = behavior;
				_003C_003E1__state = -1;
				if (behavior != null)
				{
					uIToggleBehavior.Ready = false;
					UIToggleBehavior uIToggleBehavior2 = behavior;
					if (behavior != null)
					{
						WaitForSecondsRealtime waitForSecondsRealtime = null;
						waitForSecondsRealtime._003CwaitTime_003Ek__BackingField = uIToggleBehavior2.DisableInterval;
						waitForSecondsRealtime.m_WaitUntilTime = -1f;
						_003C_003E2__current = waitForSecondsRealtime;
						_003C_003E1__state = 1;
						return true;
					}
				}
				goto IL_0126;
			}
			if (_003C_003E1__state == 1)
			{
				UIToggleBehavior uIToggleBehavior3 = behavior;
				_003C_003E1__state = -1;
				if (behavior == null)
				{
					goto IL_0126;
				}
				uIToggleBehavior3.Ready = true;
			}
			return false;
			IL_0126:
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			NotSupportedException ex = new NotSupportedException();
			throw ex;
		}
	}

	private sealed class _003CDisableToggleEnumerator_003Ed__72(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public UIToggle _003C_003E4__this;

		public float duration;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_00e5: Expected I4, but got I8
			//IL_0161: Expected I4, but got O
			UIToggle uIToggle = _003C_003E4__this;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this != null)
				{
					Toggle toggle = _003C_003E4__this.Toggle;
					if ((object)toggle != null)
					{
						toggle.interactable = false;
						WaitForSecondsRealtime waitForSecondsRealtime = null;
						waitForSecondsRealtime._003CwaitTime_003Ek__BackingField = duration;
						waitForSecondsRealtime.m_WaitUntilTime = -1f;
						_003C_003E2__current = waitForSecondsRealtime;
						_003C_003E1__state = 1;
						return true;
					}
				}
			}
			else
			{
				if (_003C_003E1__state != 1)
				{
					goto IL_014d;
				}
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this != null)
				{
					Toggle toggle2 = _003C_003E4__this.Toggle;
					if ((object)toggle2 != null)
					{
						toggle2.interactable = true;
						uIToggle.m_disableButtonCoroutine = null;
						goto IL_014d;
					}
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
			IL_014d:
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			NotSupportedException ex = new NotSupportedException();
			throw ex;
		}
	}

	private sealed class _003CExecuteToggleBehaviorEnumerator_003Ed__71(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public UIToggleBehavior behavior;

		public UIToggle _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_001e: Expected I4, but got I8
			//IL_07e9: Expected I4, but got O
			//IL_02cb: Expected O, but got I4
			//IL_06f7: Unknown result type (might be due to invalid IL or missing references)
			//IL_06fc: Expected O, but got Unknown
			//IL_076a: Unknown result type (might be due to invalid IL or missing references)
			//IL_076f: Expected O, but got Unknown
			//IL_048d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0492: Expected O, but got Unknown
			//IL_0500: Unknown result type (might be due to invalid IL or missing references)
			//IL_0505: Expected O, but got Unknown
			UIToggle uIToggle = _003C_003E4__this;
			if (_003C_003E1__state != 0)
			{
				goto IL_05b2;
			}
			UIToggleBehavior uIToggleBehavior = behavior;
			_003C_003E1__state = -1;
			if (behavior != null)
			{
				if (!uIToggleBehavior.Enabled)
				{
					goto IL_05b2;
				}
				if ((object)_003C_003E4__this != null)
				{
					if (!uIToggle.m_updateStartValuesRequired)
					{
						_003C_003E4__this.UpdateStartValues();
						uIToggle.m_updateStartValuesRequired = true;
					}
					UIToggleBehavior uIToggleBehavior2 = behavior;
					if (behavior != null)
					{
						if (uIToggleBehavior2.m_behaviorType <= UIToggleBehaviorType.OnPointerExit)
						{
							Toggle toggle = _003C_003E4__this.Toggle;
							if ((object)toggle == null)
							{
								goto IL_07db;
							}
							if (!((Selectable)toggle).m_Interactable || UIComponentBase<UIToggle>.UIInteractionsDisabled)
							{
								goto IL_05b2;
							}
						}
						if (behavior != null)
						{
							bool executeEffect = default(bool);
							bool executeAnimatorEvents = default(bool);
							bool sendGameEvents = default(bool);
							bool executeUnityEvent = default(bool);
							behavior.Invoke(_003C_003E4__this, playAnimation: true, playSound: true, executeEffect, executeAnimatorEvents, sendGameEvents, executeUnityEvent);
							Toggle toggle2 = _003C_003E4__this.Toggle;
							if ((object)toggle2 != null)
							{
								bool toggleState = !toggle2.m_IsOn;
								UIToggleBehavior uIToggleBehavior3 = behavior;
								if (behavior != null)
								{
									bool flag = OnUIToggleAction == null;
									bool flag2 = true;
									if (!flag)
									{
										Action<UIToggle, UIToggleState, UIToggleBehaviorType> onUIToggleAction = OnUIToggleAction;
										if (OnUIToggleAction == null)
										{
											goto IL_07db;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v243 @ r10_v4 (System.Action`3<Doozy.Engine.UI.UIToggle, Doozy.Engine.UI.UIToggleState, Doozy.Engine.UI.UIToggleBehaviorType>)+18] (should have been resolved before IL gen)");
										flag2 = (byte)uIToggleBehavior3.m_behaviorType != 0;
									}
									UIToggleMessage uIToggleMessage = null;
									uIToggleMessage.Toggle = _003C_003E4__this;
									uIToggleMessage.ToggleState = (toggleState ? UIToggleState.Off : UIToggleState.On);
									uIToggleMessage.Type = uIToggleBehavior3.m_behaviorType;
									Message.Send(uIToggleMessage);
									UIToggleBehavior uIToggleBehavior4 = behavior;
									if (behavior != null)
									{
										bool flag3 = uIToggleBehavior4.m_behaviorType == UIToggleBehaviorType.OnClick;
										object obj3 = default(object);
										bool flag5;
										if (!flag3)
										{
											object obj = uIToggleBehavior4.m_behaviorType - 1;
											if (flag3)
											{
												UIToggleBehavior uIToggleBehavior5 = behavior;
												if (behavior != null)
												{
													if (!uIToggleBehavior5.SelectButton)
													{
														goto IL_05b2;
													}
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rbx_v1 (Doozy.Engine.UI.UIToggle)+20]");
													if ((nint)0 == 0)
													{
														DoozySettings instance = DoozySettings.Instance;
														if ((object)instance == null)
														{
															goto IL_07db;
														}
														if (!instance.DebugUIToggle)
														{
															goto IL_0566;
														}
													}
													string[] array = new string[7];
													if (array != null)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
														string name = ((UnityEngine.Object)_003C_003E4__this).GetName();
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
														Toggle toggle3 = _003C_003E4__this.Toggle;
														if ((object)toggle3 != null)
														{
															bool flag4 = !toggle3.m_IsOn;
															_ = typeof(UIToggleState);
															Enum obj2 = (Enum)(obj3 - 48);
															_ = -1;
															string text = obj2.ToString();
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
															UIToggleBehavior uIToggleBehavior6 = behavior;
															if (behavior != null)
															{
																_ = typeof(UIToggleBehaviorType);
																Enum obj4 = (Enum)(obj3 - 48);
																_ = -1;
																_ = uIToggleBehavior6.m_behaviorType;
																string text2 = obj4.ToString();
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																string message = string.Concat(array);
																DDebug.Log(message, _003C_003E4__this);
																goto IL_0566;
															}
														}
													}
												}
												goto IL_07db;
											}
											if ((nint)obj != 1)
											{
												goto IL_05b2;
											}
											UIToggleBehavior uIToggleBehavior7 = behavior;
											flag5 = !uIToggleBehavior7.DeselectButton;
										}
										else
										{
											flag5 = !uIToggle.DeselectButtonAfterClick;
										}
										if (flag5)
										{
											goto IL_05b2;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rbx_v1 (Doozy.Engine.UI.UIToggle)+20]");
										if ((nint)0 == 0)
										{
											DoozySettings instance2 = DoozySettings.Instance;
											if ((object)instance2 == null)
											{
												goto IL_07db;
											}
											if (!instance2.DebugUIToggle)
											{
												goto IL_07cb;
											}
										}
										string[] array2 = new string[7];
										if (array2 != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
											string name2 = ((UnityEngine.Object)_003C_003E4__this).GetName();
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
											Toggle toggle4 = _003C_003E4__this.Toggle;
											if ((object)toggle4 != null)
											{
												bool flag6 = !toggle4.m_IsOn;
												_ = typeof(UIToggleState);
												Enum obj5 = (Enum)(obj3 - 48);
												_ = -1;
												string text3 = obj5.ToString();
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
												UIToggleBehavior uIToggleBehavior8 = behavior;
												if (behavior != null)
												{
													_ = typeof(UIToggleBehaviorType);
													Enum obj6 = (Enum)(obj3 - 48);
													_ = -1;
													_ = uIToggleBehavior8.m_behaviorType;
													string text4 = obj6.ToString();
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
													string message2 = string.Concat(array2);
													DDebug.Log(message2, _003C_003E4__this);
													goto IL_07cb;
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
			goto IL_07db;
			IL_07db:
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
			IL_07cb:
			_003C_003E4__this.DeselectToggle();
			goto IL_05b2;
			IL_0566:
			EventSystem unityEventSystem = UIComponentBase<UIToggle>.UnityEventSystem;
			GameObject gameObject = _003C_003E4__this.gameObject;
			if ((object)unityEventSystem != null)
			{
				unityEventSystem.SetSelectedGameObject(gameObject);
				goto IL_05b2;
			}
			goto IL_07db;
			IL_05b2:
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			NotSupportedException ex = new NotSupportedException();
			throw ex;
		}
	}

	public static Action<UIToggle, UIToggleState, UIToggleBehaviorType> OnUIToggleAction;

	public bool AllowMultipleClicks;

	public float DisableButtonBetweenClicksInterval;

	public bool DeselectButtonAfterClick;

	public InputData InputData;

	public UIToggleBehavior OnPointerEnter;

	public UIToggleBehavior OnPointerExit;

	public UIToggleBehavior OnClick;

	public UIToggleBehavior OnSelected;

	public UIToggleBehavior OnDeselected;

	public BoolEvent OnValueChanged;

	public TargetLabel TargetLabel;

	public Text TextLabel;

	public Progressor ToggleProgressor;

	private CanvasGroup m_canvasGroup;

	private Coroutine m_disableButtonCoroutine;

	private bool m_previousValue;

	private Toggle m_toggle;

	private bool m_updateStartValuesRequired;

	private bool m_initialized;

	public CanvasGroup CanvasGroup
	{
		get
		{
			CanvasGroup canvasGroup = m_canvasGroup;
			if ((object)m_canvasGroup != null && ((UnityEngine.Object)canvasGroup).m_CachedPtr != (IntPtr)0)
			{
				return m_canvasGroup;
			}
			CanvasGroup component = GetComponent<CanvasGroup>();
			m_canvasGroup = component;
			CanvasGroup canvasGroup2 = m_canvasGroup;
			if ((object)m_canvasGroup == null || ((UnityEngine.Object)canvasGroup2).m_CachedPtr == (IntPtr)0)
			{
				GameObject gameObject = base.gameObject;
				if ((object)gameObject == null)
				{
					return (CanvasGroup)(object)new NullReferenceException();
				}
				CanvasGroup canvasGroup3 = gameObject.AddComponent<CanvasGroup>();
				m_canvasGroup = canvasGroup3;
			}
			return m_canvasGroup;
		}
	}

	public bool HasLabel
	{
		get
		{
			if (TargetLabel != TargetLabel.None && TargetLabel == TargetLabel.Text)
			{
				Text textLabel = TextLabel;
				if ((object)TextLabel != null)
				{
					bool flag = ((UnityEngine.Object)textLabel).m_CachedPtr == (IntPtr)0;
					return !flag;
				}
			}
			return false;
		}
	}

	public bool Interactable
	{
		get
		{
			//IL_003f: Expected I4, but got O
			Toggle toggle = Toggle;
			if ((object)toggle != null)
			{
				return ((Selectable)toggle).m_Interactable;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
		set
		{
			Toggle toggle = Toggle;
			toggle.interactable = value;
		}
	}

	public bool IsOn
	{
		get
		{
			//IL_003f: Expected I4, but got O
			Toggle toggle = Toggle;
			if ((object)toggle != null)
			{
				return toggle.m_IsOn;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
		set
		{
			Toggle toggle = Toggle;
			toggle.Set(value, true);
		}
	}

	public bool IsSelected
	{
		get
		{
			//IL_0172: Expected I4, but got O
			//IL_01ce: Expected O, but got I4
			//IL_01e8: Expected O, but got I4
			EventSystem unityEventSystem = UIComponentBase<UIToggle>.UnityEventSystem;
			if ((object)unityEventSystem != null && ((UnityEngine.Object)unityEventSystem).m_CachedPtr != (IntPtr)0)
			{
				EventSystem unityEventSystem2 = UIComponentBase<UIToggle>.UnityEventSystem;
				if ((object)unityEventSystem2 != null)
				{
					GameObject currentSelected = unityEventSystem2.m_CurrentSelected;
					GameObject gameObject = base.gameObject;
					bool flag = (object)gameObject == null;
					bool flag2 = (object)unityEventSystem2.m_CurrentSelected == null;
					object obj = flag2 & flag;
					bool flag3 = obj == null;
					object obj2 = !flag3;
					if (obj2 != null)
					{
						return true;
					}
					if ((object)gameObject != null)
					{
						if ((object)unityEventSystem2.m_CurrentSelected != null)
						{
							object obj3 = (object)unityEventSystem2.m_CurrentSelected - (object)gameObject;
							return obj3 == null;
						}
						return ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
					}
					if ((object)unityEventSystem2.m_CurrentSelected != null)
					{
						return ((UnityEngine.Object)currentSelected).m_CachedPtr == (IntPtr)0;
					}
				}
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			return false;
		}
	}

	public Toggle Toggle
	{
		get
		{
			Toggle toggle = m_toggle;
			if ((object)m_toggle == null || ((UnityEngine.Object)toggle).m_CachedPtr == (IntPtr)0)
			{
				Toggle component = GetComponent<Toggle>();
				m_toggle = component;
			}
			return m_toggle;
		}
	}

	public bool UpdateStartValuesRequired
	{
		get
		{
			return m_updateStartValuesRequired;
		}
		set
		{
			m_updateStartValuesRequired = value;
		}
	}

	private bool DebugComponent
	{
		get
		{
			//IL_0069: Expected I4, but got O
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Doozy.Engine.UI.UIToggle)+20]");
			if ((nint)0 != 0)
			{
				return true;
			}
			DoozySettings instance = DoozySettings.Instance;
			if ((object)instance != null)
			{
				return instance.DebugUIToggle;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	protected override void Reset()
	{
		UIToggleSettings instance = UIToggleSettings.Instance;
		instance.ResetComponent(this);
		m_disableButtonCoroutine = null;
	}

	public override void Awake()
	{
		//IL_0226: Expected I4, but got O
		m_initialized = false;
		base.Awake();
		UIToggleBehavior onPointerEnter = OnPointerEnter;
		if (onPointerEnter.Enabled && onPointerEnter.LoadSelectedPresetAtRuntime)
		{
			onPointerEnter.LoadPreset();
		}
		UIToggleBehavior onPointerExit = OnPointerExit;
		if (onPointerExit.Enabled && onPointerExit.LoadSelectedPresetAtRuntime)
		{
			onPointerExit.LoadPreset();
		}
		UIToggleBehavior onClick = OnClick;
		if (onClick.Enabled && onClick.LoadSelectedPresetAtRuntime)
		{
			onClick.LoadPreset();
		}
		UIToggleBehavior onSelected = OnSelected;
		if (onSelected.Enabled && onSelected.LoadSelectedPresetAtRuntime)
		{
			onSelected.LoadPreset();
		}
		UIToggleBehavior onDeselected = OnDeselected;
		if (onDeselected.Enabled && onDeselected.LoadSelectedPresetAtRuntime)
		{
			onDeselected.LoadPreset();
		}
		Toggle toggle = Toggle;
		bool previousValue = !toggle.m_IsOn;
		m_previousValue = previousValue;
		Toggle toggle2 = Toggle;
		UnityAction<bool> unityAction = null;
		((UIToggle)(object)unityAction).ToggleOnValueChanged((byte)(int)this != 0);
		toggle2.onValueChanged.AddListener(unityAction);
	}

	public override void OnEnable()
	{
		if (!m_initialized)
		{
			if (!m_updateStartValuesRequired)
			{
				base.UpdateStartValues();
				m_updateStartValuesRequired = true;
			}
			bool executeEffect = default(bool);
			bool executeAnimatorEvents = default(bool);
			bool sendGameEvents = default(bool);
			bool executeUnityEvent = default(bool);
			OnClick.Invoke(this, playAnimation: false, playSound: false, executeEffect, executeAnimatorEvents, sendGameEvents, executeUnityEvent);
		}
	}

	public override void Start()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980750]");
		if ((nint)0 == 0)
		{
			_ = 1;
			m_initialized = true;
		}
		else
		{
			m_initialized = true;
		}
	}

	public override void OnDisable()
	{
		RectTransform rectTransform = base.RectTransform;
		UIAnimator.StopAnimations(rectTransform, AnimationType.Punch);
		RectTransform rectTransform2 = base.RectTransform;
		UIAnimator.StopAnimations(rectTransform2, AnimationType.State);
		base.ResetToStartValues();
		UIToggleBehavior onPointerEnter = OnPointerEnter;
		onPointerEnter.Ready = true;
		UIToggleBehavior onPointerExit = OnPointerExit;
		onPointerExit.Ready = true;
		UIToggleBehavior onClick = OnClick;
		onClick.Ready = true;
		UIToggleBehavior onSelected = OnSelected;
		onSelected.Ready = true;
		UIToggleBehavior onDeselected = OnDeselected;
		onDeselected.Ready = true;
		if (m_disableButtonCoroutine != null)
		{
			StopCoroutine(m_disableButtonCoroutine);
			m_disableButtonCoroutine = null;
			Toggle toggle = Toggle;
			toggle.interactable = true;
			Toggle toggle2 = Toggle;
			bool previousValue = !toggle2.m_IsOn;
			m_previousValue = previousValue;
		}
	}

	private void Update()
	{
		InputData inputData = InputData;
		if (inputData.InputMode == InputMode.None || !IsSelected)
		{
			return;
		}
		InputData inputData2 = InputData;
		if (inputData2.InputMode == InputMode.KeyCode)
		{
			if (!UnityEngine.Input.GetKeyDownInt(inputData2.KeyCode))
			{
				InputData inputData3 = InputData;
				if (!inputData3.EnableAlternateInputs || !UnityEngine.Input.GetKeyDownInt(inputData3.KeyCodeAlt))
				{
					return;
				}
			}
		}
		else
		{
			if (inputData2.InputMode != InputMode.VirtualButton)
			{
				return;
			}
			if (!UnityEngine.Internal.InputUnsafeUtility.GetButtonDown(inputData2.VirtualButtonName))
			{
				InputData inputData4 = InputData;
				if (!inputData4.EnableAlternateInputs || !UnityEngine.Internal.InputUnsafeUtility.GetButtonDown(inputData4.VirtualButtonNameAlt))
				{
					return;
				}
			}
		}
		ExecuteClick();
	}

	void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
	{
		TriggerToggleBehavior(OnPointerEnter);
	}

	void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
	{
		TriggerToggleBehavior(OnPointerExit);
	}

	void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
	{
		TriggerToggleBehavior(OnClick);
	}

	void ISelectHandler.OnSelect(BaseEventData eventData)
	{
		//IL_0159: Expected O, but got I4
		//IL_0173: Expected O, but got I4
		EventSystem eventSystem = eventData.m_EventSystem;
		GameObject currentSelected = eventSystem.m_CurrentSelected;
		GameObject gameObject = base.gameObject;
		bool flag = (object)gameObject == null;
		bool flag2 = (object)eventSystem.m_CurrentSelected == null;
		object obj = flag2 & flag;
		bool flag3 = obj == null;
		object obj2 = !flag3;
		if (obj2 == null)
		{
			bool flag4;
			if ((object)gameObject != null)
			{
				if ((object)eventSystem.m_CurrentSelected != null)
				{
					object obj3 = (object)eventSystem.m_CurrentSelected - (object)gameObject;
					flag4 = obj3 == null;
				}
				else
				{
					flag4 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
				}
			}
			else
			{
				flag4 = ((UnityEngine.Object)currentSelected).m_CachedPtr == (IntPtr)0;
			}
			if (!flag4)
			{
				return;
			}
		}
		UIToggleBehavior onSelected = OnSelected;
		if (onSelected.Enabled)
		{
			TriggerToggleBehavior(onSelected);
		}
	}

	void IDeselectHandler.OnDeselect(BaseEventData eventData)
	{
		//IL_0159: Expected O, but got I4
		//IL_0173: Expected O, but got I4
		EventSystem eventSystem = eventData.m_EventSystem;
		GameObject currentSelected = eventSystem.m_CurrentSelected;
		GameObject gameObject = base.gameObject;
		bool flag = (object)gameObject == null;
		bool flag2 = (object)eventSystem.m_CurrentSelected == null;
		object obj = flag2 & flag;
		bool flag3 = obj == null;
		object obj2 = !flag3;
		if (obj2 == null)
		{
			bool flag4;
			if ((object)gameObject != null)
			{
				if ((object)eventSystem.m_CurrentSelected != null)
				{
					object obj3 = (object)eventSystem.m_CurrentSelected - (object)gameObject;
					flag4 = obj3 == null;
				}
				else
				{
					flag4 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
				}
			}
			else
			{
				flag4 = ((UnityEngine.Object)currentSelected).m_CachedPtr == (IntPtr)0;
			}
			if (!flag4)
			{
				return;
			}
		}
		UIToggleBehavior onDeselected = OnDeselected;
		if (onDeselected.Enabled)
		{
			TriggerToggleBehavior(onDeselected);
		}
	}

	public void DeselectToggle()
	{
		if (IsSelected)
		{
			EventSystem unityEventSystem = UIComponentBase<UIToggle>.UnityEventSystem;
			unityEventSystem.SetSelectedGameObject(null);
		}
	}

	public void DeselectToggle(float delay)
	{
		_003CDeselectToggleEnumerator_003Ed__70 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		obj.delay = delay;
		Coroutine coroutine = Coroutiner.Start(obj);
	}

	public void DisableToggle()
	{
		Toggle toggle = Toggle;
		toggle.interactable = false;
	}

	public void DisableToggle(float duration)
	{
		Toggle toggle = Toggle;
		if (((Selectable)toggle).m_Interactable)
		{
			Toggle toggle2 = Toggle;
			toggle2.interactable = false;
			_003CDisableToggleEnumerator_003Ed__72 obj = null;
			obj._003C_003E1__state = 0;
			obj._003C_003E4__this = this;
			obj.duration = duration;
			Coroutine disableButtonCoroutine = StartCoroutine(obj);
			m_disableButtonCoroutine = disableButtonCoroutine;
		}
	}

	public void EnableToggle()
	{
		Toggle toggle = Toggle;
		toggle.interactable = true;
	}

	public void ExecutePointerEnter(bool debug = false)
	{
		//IL_00a8: Invalid comparison between F4 and I4
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980755]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		UIToggleBehavior onPointerEnter = OnPointerEnter;
		if (onPointerEnter.Enabled)
		{
			PrintBehaviorDebugMessage(onPointerEnter, "initiated", debug);
			IEnumerator routine = ExecuteToggleBehaviorEnumerator(OnPointerEnter);
			Coroutine coroutine = StartCoroutine(routine);
			UIToggleBehavior onPointerEnter2 = OnPointerEnter;
			if (onPointerEnter2.DisableInterval > 0f)
			{
				IEnumerator routine2 = DisableToggleBehaviorEnumerator(onPointerEnter2);
				Coroutine coroutine2 = StartCoroutine(routine2);
			}
			PrintBehaviorDebugMessage(OnPointerEnter, "executed", debug);
		}
	}

	public void ExecutePointerExit(bool debug = false)
	{
		//IL_00a8: Invalid comparison between F4 and I4
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980756]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		UIToggleBehavior onPointerExit = OnPointerExit;
		if (onPointerExit.Enabled)
		{
			PrintBehaviorDebugMessage(onPointerExit, "initiated", debug);
			IEnumerator routine = ExecuteToggleBehaviorEnumerator(OnPointerExit);
			Coroutine coroutine = StartCoroutine(routine);
			UIToggleBehavior onPointerExit2 = OnPointerExit;
			if (onPointerExit2.DisableInterval > 0f)
			{
				IEnumerator routine2 = DisableToggleBehaviorEnumerator(onPointerExit2);
				Coroutine coroutine2 = StartCoroutine(routine2);
			}
			PrintBehaviorDebugMessage(OnPointerExit, "executed", debug);
		}
	}

	public void ExecuteClick(bool debug = false)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980757]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		UIToggleBehavior onClick = OnClick;
		if (onClick.Enabled)
		{
			PrintBehaviorDebugMessage(onClick, "initiated", debug);
			Toggle toggle = Toggle;
			if (((Selectable)toggle).m_Interactable)
			{
				IEnumerator routine = ExecuteToggleBehaviorEnumerator(OnClick);
				Coroutine coroutine = StartCoroutine(routine);
				PrintBehaviorDebugMessage(OnClick, "executed", debug);
			}
			if (!AllowMultipleClicks)
			{
				Toggle toggle2 = Toggle;
				if (((Selectable)toggle2).m_Interactable)
				{
					Toggle toggle3 = Toggle;
					toggle3.interactable = false;
					_003CDisableToggleEnumerator_003Ed__72 obj = null;
					obj._003C_003E1__state = 0;
					obj._003C_003E4__this = this;
					obj.duration = DisableButtonBetweenClicksInterval;
					Coroutine disableButtonCoroutine = StartCoroutine(obj);
					m_disableButtonCoroutine = disableButtonCoroutine;
				}
			}
		}
		Toggle toggle4 = Toggle;
		if (!((Selectable)toggle4).m_Interactable)
		{
			UIToggleBehavior onPointerExit = OnPointerExit;
			if (onPointerExit.Enabled && onPointerExit.Ready)
			{
				IEnumerator routine2 = ExecuteToggleBehaviorEnumerator(onPointerExit);
				Coroutine coroutine2 = StartCoroutine(routine2);
				PrintBehaviorDebugMessage(OnPointerExit, "executed", debug);
			}
		}
	}

	public void ExecuteOnButtonDeselected(bool debug = false)
	{
		//IL_00a8: Invalid comparison between F4 and I4
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980758]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		UIToggleBehavior onDeselected = OnDeselected;
		if (onDeselected.Enabled)
		{
			PrintBehaviorDebugMessage(onDeselected, "initiated", debug);
			IEnumerator routine = ExecuteToggleBehaviorEnumerator(OnDeselected);
			Coroutine coroutine = StartCoroutine(routine);
			UIToggleBehavior onDeselected2 = OnDeselected;
			if (onDeselected2.DisableInterval > 0f)
			{
				IEnumerator routine2 = DisableToggleBehaviorEnumerator(onDeselected2);
				Coroutine coroutine2 = StartCoroutine(routine2);
			}
			PrintBehaviorDebugMessage(OnDeselected, "executed", debug);
		}
	}

	public void ExecuteOnButtonSelected(bool debug = false)
	{
		//IL_00a8: Invalid comparison between F4 and I4
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980759]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		UIToggleBehavior onSelected = OnSelected;
		if (onSelected.Enabled)
		{
			PrintBehaviorDebugMessage(onSelected, "initiated", debug);
			IEnumerator routine = ExecuteToggleBehaviorEnumerator(OnSelected);
			Coroutine coroutine = StartCoroutine(routine);
			UIToggleBehavior onSelected2 = OnSelected;
			if (onSelected2.DisableInterval > 0f)
			{
				IEnumerator routine2 = DisableToggleBehaviorEnumerator(onSelected2);
				Coroutine coroutine2 = StartCoroutine(routine2);
			}
			PrintBehaviorDebugMessage(OnSelected, "executed", debug);
		}
	}

	public void LoadPresets()
	{
		UIToggleBehavior onPointerEnter = OnPointerEnter;
		if (onPointerEnter.Enabled && onPointerEnter.LoadSelectedPresetAtRuntime)
		{
			onPointerEnter.LoadPreset();
		}
		UIToggleBehavior onPointerExit = OnPointerExit;
		if (onPointerExit.Enabled && onPointerExit.LoadSelectedPresetAtRuntime)
		{
			onPointerExit.LoadPreset();
		}
		UIToggleBehavior onClick = OnClick;
		if (onClick.Enabled && onClick.LoadSelectedPresetAtRuntime)
		{
			onClick.LoadPreset();
		}
		UIToggleBehavior onSelected = OnSelected;
		if (onSelected.Enabled && onSelected.LoadSelectedPresetAtRuntime)
		{
			onSelected.LoadPreset();
		}
		UIToggleBehavior onDeselected = OnDeselected;
		if (onDeselected.Enabled && onDeselected.LoadSelectedPresetAtRuntime)
		{
			onDeselected.LoadPreset();
		}
	}

	public void NotifySystemOfTriggeredBehavior(UIToggleState toggleState, UIToggleBehaviorType behaviorType)
	{
		if (OnUIToggleAction != null)
		{
			Action<UIToggle, UIToggleState, UIToggleBehaviorType> onUIToggleAction = OnUIToggleAction;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v83 @ r10_v2 (System.Action`3<Doozy.Engine.UI.UIToggle, Doozy.Engine.UI.UIToggleState, Doozy.Engine.UI.UIToggleBehaviorType>)+18] (should have been resolved before IL gen)");
		}
		UIToggleMessage uIToggleMessage = null;
		uIToggleMessage.Toggle = this;
		uIToggleMessage.ToggleState = toggleState;
		uIToggleMessage.Type = behaviorType;
		Message.Send(uIToggleMessage);
	}

	public void SelectToggle()
	{
		EventSystem unityEventSystem = UIComponentBase<UIToggle>.UnityEventSystem;
		GameObject selectedGameObject = base.gameObject;
		unityEventSystem.SetSelectedGameObject(selectedGameObject);
	}

	public void SetLabelText(string text)
	{
		if (TargetLabel != TargetLabel.None && TargetLabel == TargetLabel.Text)
		{
			Text textLabel = TextLabel;
			bool flag2;
			if ((object)TextLabel != null)
			{
				bool flag = ((UnityEngine.Object)textLabel).m_CachedPtr == (IntPtr)0;
				flag2 = !flag;
			}
			else
			{
				flag2 = false;
			}
			if (flag2 && TargetLabel == TargetLabel.Text)
			{
				TextLabel.text = text;
			}
		}
	}

	public void ToggleOff()
	{
		Toggle toggle = Toggle;
		toggle.Set(false, true);
	}

	public void ToggleOn()
	{
		Toggle toggle = Toggle;
		toggle.Set(true, true);
	}

	private unsafe void PrintBehaviorDebugMessage(UIToggleBehavior behavior, string action, bool debug = false)
	{
		//IL_0084: Expected O, but got Ref
		//IL_00af: Expected O, but got Ref
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Doozy.Engine.UI.UIToggle)+20]");
		bool flag = (nint)0 == 0;
		if (flag)
		{
			DoozySettings instance = DoozySettings.Instance;
			flag = (object)instance == null;
		}
		if (!flag)
		{
			string[] array = new string[9];
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			string text = GetName();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Toggle toggle = Toggle;
			IntPtr intPtr = default(IntPtr);
			string text2 = ((Enum)(&intPtr)).ToString();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			string text3 = ((Enum)(&intPtr)).ToString();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			string message = string.Concat(array);
			DDebug.Log(message, this);
		}
	}

	private void ToggleOnValueChanged(bool value)
	{
		//IL_00d5: Invalid comparison between I4 and F4
		//IL_00fd: Expected I4, but got F4
		Toggle toggle = Toggle;
		m_previousValue = toggle.m_IsOn;
		Toggle toggle2 = Toggle;
		OnValueChanged.Invoke(toggle2.m_IsOn);
		Progressor toggleProgressor = ToggleProgressor;
		if ((object)ToggleProgressor == null || ((UnityEngine.Object)toggleProgressor).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		Progressor toggleProgressor2 = ToggleProgressor;
		Toggle toggle3 = Toggle;
		bool flag = !toggle3.m_IsOn;
		bool flag2 = !flag;
		bool flag4;
		if ((false ? 1 : 0) <= (flag2 ? 1 : 0))
		{
			bool flag3 = !((float)(flag2 ? 1 : 0) > 1f);
			flag4 = flag2;
			if (!flag3)
			{
				flag4 = true;
			}
		}
		else
		{
			flag4 = false;
		}
		float num = toggleProgressor2.m_maxValue - toggleProgressor2.m_minValue;
		float num2 = num * (float)(flag4 ? 1 : 0);
		float value2 = num2 + toggleProgressor2.m_minValue;
		toggleProgressor2.SetValue(value2, instantUpdate: false);
	}

	private void TriggerToggleBehavior(UIToggleBehavior behavior, bool debug = false)
	{
		//IL_003a: Expected O, but got I4
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Expected O, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_02bd: Invalid comparison between F4 and I4
		//IL_0182: Invalid comparison between F4 and I4
		//IL_060d: Invalid comparison between F4 and I4
		//IL_0465: Invalid comparison between F4 and I4
		bool flag = behavior.m_behaviorType == UIToggleBehaviorType.OnClick;
		if (!flag)
		{
			object obj = behavior.m_behaviorType - 1;
			UIToggleBehavior behavior2;
			bool debug2;
			string action;
			if (!flag)
			{
				object obj2 = obj - 1;
				if (!flag)
				{
					object obj3 = obj2 - 1;
					if (!flag)
					{
						if ((nint)obj3 != 1)
						{
							return;
						}
						if (behavior.Enabled)
						{
							PrintBehaviorDebugMessage(behavior, "triggered", debug);
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980758]");
						if ((nint)0 == 0)
						{
							_ = 1;
						}
						UIToggleBehavior onDeselected = OnDeselected;
						if (!onDeselected.Enabled)
						{
							return;
						}
						PrintBehaviorDebugMessage(onDeselected, "initiated", debug);
						IEnumerator routine = ExecuteToggleBehaviorEnumerator(OnDeselected);
						Coroutine coroutine = StartCoroutine(routine);
						UIToggleBehavior onDeselected2 = OnDeselected;
						if (onDeselected2.DisableInterval > 0f)
						{
							IEnumerator routine2 = DisableToggleBehaviorEnumerator(onDeselected2);
							Coroutine coroutine2 = StartCoroutine(routine2);
						}
						behavior2 = OnDeselected;
						debug2 = debug;
						action = "executed";
					}
					else
					{
						if (behavior.Enabled)
						{
							PrintBehaviorDebugMessage(behavior, "triggered", debug);
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980759]");
						if ((nint)0 == 0)
						{
							_ = 1;
						}
						UIToggleBehavior onSelected = OnSelected;
						if (!onSelected.Enabled)
						{
							return;
						}
						PrintBehaviorDebugMessage(onSelected, "initiated", debug);
						IEnumerator routine3 = ExecuteToggleBehaviorEnumerator(OnSelected);
						Coroutine coroutine3 = StartCoroutine(routine3);
						UIToggleBehavior onSelected2 = OnSelected;
						if (onSelected2.DisableInterval > 0f)
						{
							IEnumerator routine4 = DisableToggleBehaviorEnumerator(onSelected2);
							Coroutine coroutine4 = StartCoroutine(routine4);
						}
						behavior2 = OnSelected;
						debug2 = debug;
						action = "executed";
					}
				}
				else
				{
					Toggle toggle = Toggle;
					if (!((Selectable)toggle).m_Interactable)
					{
						return;
					}
					bool uIInteractionsDisabled = UIComponentBase<UIToggle>.UIInteractionsDisabled;
					if (uIInteractionsDisabled || behavior.Ready == uIInteractionsDisabled)
					{
						return;
					}
					if (behavior.Enabled)
					{
						PrintBehaviorDebugMessage(behavior, "triggered", debug);
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980756]");
					if ((nint)0 == 0)
					{
						_ = 1;
					}
					UIToggleBehavior onPointerExit = OnPointerExit;
					if (!onPointerExit.Enabled)
					{
						return;
					}
					PrintBehaviorDebugMessage(onPointerExit, "initiated", debug);
					IEnumerator routine5 = ExecuteToggleBehaviorEnumerator(OnPointerExit);
					Coroutine coroutine5 = StartCoroutine(routine5);
					UIToggleBehavior onPointerExit2 = OnPointerExit;
					if (onPointerExit2.DisableInterval > 0f)
					{
						IEnumerator routine6 = DisableToggleBehaviorEnumerator(onPointerExit2);
						Coroutine coroutine6 = StartCoroutine(routine6);
					}
					behavior2 = OnPointerExit;
					debug2 = debug;
					action = "executed";
				}
			}
			else
			{
				Toggle toggle2 = Toggle;
				if (!((Selectable)toggle2).m_Interactable)
				{
					return;
				}
				bool uIInteractionsDisabled2 = UIComponentBase<UIToggle>.UIInteractionsDisabled;
				if (uIInteractionsDisabled2 || behavior.Ready == uIInteractionsDisabled2)
				{
					return;
				}
				if (behavior.Enabled)
				{
					PrintBehaviorDebugMessage(behavior, "triggered", debug);
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980755]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				UIToggleBehavior onPointerEnter = OnPointerEnter;
				if (!onPointerEnter.Enabled)
				{
					return;
				}
				PrintBehaviorDebugMessage(onPointerEnter, "initiated", debug);
				IEnumerator routine7 = ExecuteToggleBehaviorEnumerator(OnPointerEnter);
				Coroutine coroutine7 = StartCoroutine(routine7);
				UIToggleBehavior onPointerEnter2 = OnPointerEnter;
				if (onPointerEnter2.DisableInterval > 0f)
				{
					IEnumerator routine8 = DisableToggleBehaviorEnumerator(onPointerEnter2);
					Coroutine coroutine8 = StartCoroutine(routine8);
				}
				behavior2 = OnPointerEnter;
				debug2 = debug;
				action = "executed";
			}
			PrintBehaviorDebugMessage(behavior2, action, debug2);
			return;
		}
		Toggle toggle3 = Toggle;
		if (!((Selectable)toggle3).m_Interactable)
		{
			return;
		}
		bool uIInteractionsDisabled3 = UIComponentBase<UIToggle>.UIInteractionsDisabled;
		if (!uIInteractionsDisabled3 && behavior.Ready != uIInteractionsDisabled3)
		{
			if (behavior.Enabled != uIInteractionsDisabled3)
			{
				PrintBehaviorDebugMessage(behavior, "triggered - ", debug);
			}
			ExecuteClick(debug);
		}
	}

	private bool BehaviorEnabled(UIToggleBehaviorType behaviorType)
	{
		bool flag = behaviorType == UIToggleBehaviorType.OnClick;
		UIToggleBehavior uIToggleBehavior;
		if (!flag)
		{
			UIToggleBehaviorType uIToggleBehaviorType = behaviorType - 1;
			if (!flag)
			{
				UIToggleBehaviorType uIToggleBehaviorType2 = uIToggleBehaviorType - 1;
				if (!flag)
				{
					UIToggleBehaviorType uIToggleBehaviorType3 = uIToggleBehaviorType2 - 1;
					if (!flag)
					{
						if (uIToggleBehaviorType3 != UIToggleBehaviorType.OnPointerEnter)
						{
							UIToggleBehaviorType uIToggleBehaviorType4 = default(UIToggleBehaviorType);
							object actualValue = uIToggleBehaviorType4;
							ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException("behaviorType", actualValue, null);
							throw ex;
						}
						uIToggleBehavior = OnDeselected;
					}
					else
					{
						uIToggleBehavior = OnSelected;
					}
				}
				else
				{
					uIToggleBehavior = OnPointerExit;
				}
			}
			else
			{
				uIToggleBehavior = OnPointerEnter;
			}
		}
		else
		{
			uIToggleBehavior = OnClick;
		}
		return uIToggleBehavior.Enabled;
	}

	private IEnumerator DeselectToggleEnumerator(float delay)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		//IL_002e: Expected O, but got I8
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected O, but got Unknown
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected O, but got Unknown
		//IL_010a: Expected O, but got I4
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Expected O, but got Unknown
		_003CDeselectToggleEnumerator_003Ed__70 obj = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
		bool flag = (nint)0 == 0;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		if (!flag)
		{
			object obj2 = obj + 40;
			object obj3 = obj2 >> 12;
			object obj4 = 6603864928L;
			object obj5 = obj3 & 0x1FFFFF;
			object obj6 = obj5 >> 6;
			object obj7 = obj5 & 0x3F;
			nint num2;
			do
			{
				object obj8 = 1 << (int)obj7;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ r10_v1+v51 @ r8_v2*8]");
				object obj9 = 0 | obj8;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ r10_v1+v51 @ r8_v2*8]");
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ r10_v1+v51 @ r8_v2*8]");
				if (num == 0)
				{
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ r10_v1+v51 @ r8_v2*8]");
				num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ r10_v1+v51 @ r8_v2*8]");
			}
			while (num2 != 0);
			obj.delay = delay;
			return obj;
		}
		obj.delay = delay;
		return obj;
	}

	private IEnumerator ExecuteToggleBehaviorEnumerator(UIToggleBehavior behavior)
	{
		_003CExecuteToggleBehaviorEnumerator_003Ed__71 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		obj.behavior = behavior;
		return obj;
	}

	private IEnumerator DisableToggleEnumerator(float duration)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		//IL_002e: Expected O, but got I8
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected O, but got Unknown
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected O, but got Unknown
		//IL_010a: Expected O, but got I4
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Expected O, but got Unknown
		_003CDisableToggleEnumerator_003Ed__72 obj = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
		bool flag = (nint)0 == 0;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		if (!flag)
		{
			object obj2 = obj + 32;
			object obj3 = obj2 >> 12;
			object obj4 = 6603864928L;
			object obj5 = obj3 & 0x1FFFFF;
			object obj6 = obj5 >> 6;
			object obj7 = obj5 & 0x3F;
			nint num2;
			do
			{
				object obj8 = 1 << (int)obj7;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ r10_v1+v51 @ r8_v2*8]");
				object obj9 = 0 | obj8;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ r10_v1+v51 @ r8_v2*8]");
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ r10_v1+v51 @ r8_v2*8]");
				if (num == 0)
				{
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ r10_v1+v51 @ r8_v2*8]");
				num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ r10_v1+v51 @ r8_v2*8]");
			}
			while (num2 != 0);
			obj.duration = duration;
			return obj;
		}
		obj.duration = duration;
		return obj;
	}

	private IEnumerator DisableToggleBehaviorEnumerator(UIToggleBehavior behavior)
	{
		_003CDisableToggleBehaviorEnumerator_003Ed__73 obj = null;
		obj._003C_003E1__state = 0;
		obj.behavior = behavior;
		return obj;
	}

	public UIToggle()
	{
		InputData inputData = new InputData();
		InputData = inputData;
		BoolEvent onValueChanged = new BoolEvent();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180494DF0");
		OnValueChanged = onValueChanged;
		base._002Ector();
	}

	static UIToggle()
	{
		Action<UIToggle, UIToggleState, UIToggleBehaviorType> onUIToggleAction = delegate
		{
		};
		OnUIToggleAction = onUIToggleAction;
	}
}
