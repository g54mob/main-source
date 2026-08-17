using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Coherence;
using Cpp2ILInjected;
using Doozy.Engine.UI;
using Doozy.Engine.UI.Base;
using Rewired;
using Rewired.Integration.UnityUI;
using TMPro;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using VampireSurvivors.App.Scripts.Framework.Adventures;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Signals;
using Zenject;

namespace VampireSurvivors.UI;

public class BaseUIPage : MonoBehaviour
{
	private sealed class _003CParse_003Ed__47(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public BaseUIPage _003C_003E4__this;

		private string _003CignoreTag_003E5__2;

		private TextMeshProUGUI[] _003Cts_003E5__3;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_03b1: Expected I4, but got I8
			//IL_0015: Expected O, but got I4
			//IL_01c3: Expected I4, but got I8
			//IL_005c: Expected I4, but got I8
			//IL_0076: Expected O, but got I4
			//IL_007f: Expected O, but got I4
			//IL_0194: Unknown result type (might be due to invalid IL or missing references)
			//IL_0199: Expected O, but got Unknown
			//IL_02eb: Unknown result type (might be due to invalid IL or missing references)
			//IL_02f0: Expected O, but got Unknown
			//IL_0369: Unknown result type (might be due to invalid IL or missing references)
			//IL_036e: Expected O, but got Unknown
			//IL_00a5->IL01a6: Incompatible stack heights: 1 vs 0
			//IL_03a2->IL04ca: Incompatible stack heights: 3 vs 0
			//IL_01a6->IL0089: Incompatible stack heights: 4 vs 1
			//IL_02ff->IL04a9: Incompatible stack heights: 6 vs 3
			//IL_018b->IL018b: Incompatible stack heights: 5 vs 4
			//IL_037d->IL04a9: Incompatible stack heights: 7 vs 3
			Component component = _003C_003E4__this;
			bool flag = _003C_003E1__state == 0;
			if (!flag)
			{
				object obj = _003C_003E1__state - 1;
				if (!flag)
				{
					if ((nint)obj == 1)
					{
						TextMeshProUGUI[] array = _003Cts_003E5__3;
						_003C_003E1__state = -1;
						bool flag2 = _003Cts_003E5__3 == null;
						object obj2 = 0;
						object obj3 = 0;
						while ((nint)obj3 < array.Length)
						{
							object obj4 = array[obj2];
							bool flag3 = (object)array[obj2] == null;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v332 @ rbx_v13 (System.Object)+10]");
							bool flag4 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v332 @ rbx_v13 (System.Object)+10]");
							IntPtr gcHandlePtr = Component.get_gameObject_Injected((IntPtr)0);
							GameObject gameObject = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr);
							bool flag5 = (object)gameObject == null;
							if (!gameObject.CompareTag_Internal(_003CignoreTag_003E5__2))
							{
								array[obj2].parseCtrlCharacters = true;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v332 @ rbx_v13 (System.Object)+268]");
								if ((nint)0 == 0)
								{
									bool flag6 = (object)_003C_003E4__this == null;
									TextMeshProUGUI textMeshProUGUI = array[obj2];
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ r15_v1 (UnityEngine.Component)+4C]");
									textMeshProUGUI.enableAutoSizing = false;
								}
							}
							obj2++;
							obj3 = obj2;
						}
					}
					return false;
				}
				_003C_003E1__state = -1;
				_003CignoreTag_003E5__2 = "Ignore Auto Format";
				bool flag7 = (object)_003C_003E4__this == null;
				GameObject gameObject2 = _003C_003E4__this.gameObject;
				bool flag8 = (object)gameObject2 == null;
				TextMeshProUGUI[] componentsInChildren = gameObject2.GetComponentsInChildren<TextMeshProUGUI>(includeInactive: true);
				_003Cts_003E5__3 = componentsInChildren;
				TextMeshProUGUI[] array2 = _003Cts_003E5__3;
				bool flag9 = _003Cts_003E5__3 == null;
				object obj5 = null;
				object obj6 = null;
				while ((nint)obj6 < array2.Length)
				{
					TMP_Text tMP_Text = array2[obj5];
					bool flag10 = (object)array2[obj5] == null;
					bool flag11 = ((UnityEngine.Object)tMP_Text).m_CachedPtr == (IntPtr)0;
					IntPtr gcHandlePtr2 = Component.get_gameObject_Injected(((UnityEngine.Object)tMP_Text).m_CachedPtr);
					GameObject gameObject3 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr2);
					bool flag12 = (object)gameObject3 == null;
					if (!gameObject3.CompareTag_Internal(_003CignoreTag_003E5__2))
					{
						array2[obj5].parseCtrlCharacters = false;
						obj5++;
						obj6 = obj5;
						continue;
					}
					GameObject gameObject4 = array2[obj5].gameObject;
					bool flag13 = (object)gameObject4 == null;
					string name = ((UnityEngine.Object)gameObject4).GetName();
					string message = "Ignoring : " + name;
					Debug.Log(message);
					obj5++;
					obj6 = obj5;
				}
				_003C_003E2__current = null;
				_003C_003E1__state = 2;
				return true;
			}
			_003C_003E1__state = -1;
			_003C_003E2__current = null;
			_003C_003E1__state = 1;
			return true;
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

	private sealed class _003CWaitForPlayersToBeInsideGameplayUi_003Ed__44(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public BaseUIPage _003C_003E4__this;

		public int uiPageId;

		private List<Button> _003CdeactivatedButtons_003E5__2;

		private Selectable _003CselectedBtn_003E5__3;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private unsafe bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_009f: Expected I4, but got I8
			//IL_0178: Expected I4, but got O
			//IL_0039: Unknown result type (might be due to invalid IL or missing references)
			//IL_003e: Expected Ref, but got Unknown
			BaseUIPage baseUIPage = _003C_003E4__this;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this == null)
				{
					goto IL_016a;
				}
				ref Selectable selectedBtn = ref *(Selectable*)(this + 56);
				baseUIPage._isWaitingForPlayersToEnterUi = true;
				List<Button> list = _003C_003E4__this.DeactivateButtons(out selectedBtn);
				_003CdeactivatedButtons_003E5__2 = list;
			}
			else
			{
				if (_003C_003E1__state != 1)
				{
					goto IL_01a9;
				}
				_003C_003E1__state = -1;
			}
			OnlineStageManager instance = OnlineStageManager._instance;
			if ((object)OnlineStageManager._instance != null && ((UnityEngine.Object)instance).m_CachedPtr != (IntPtr)0)
			{
				if ((object)OnlineStageManager._instance == null)
				{
					goto IL_016a;
				}
				if (!OnlineStageManager._instance.AreAllPlayersInsideGameplayUi(uiPageId))
				{
					_003C_003E2__current = null;
					_003C_003E1__state = 1;
					return true;
				}
			}
			if ((object)_003C_003E4__this == null)
			{
				goto IL_016a;
			}
			_003C_003E4__this.ReactivateButtons(_003CdeactivatedButtons_003E5__2, _003CselectedBtn_003E5__3);
			baseUIPage._isWaitingForPlayersToEnterUi = false;
			goto IL_01a9;
			IL_01a9:
			return false;
			IL_016a:
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

	private bool _UseScreenSpaceCamera;

	protected bool _hasScrollView;

	protected float _scrollSpeed;

	protected RectTransform _scroll;

	protected RectTransform _content;

	protected Scrollbar _scrollbar;

	protected Slider _Slider;

	protected float _ForceScrollBarSize;

	protected bool _AutoSizeAfterParse;

	private float _OffsetWhenSliderShown;

	protected int ItemsPerPage;

	protected int previouslySelectedItemIndex;

	protected ScrollEnhancer _scrollEnhancer;

	protected RewiredStandaloneInputModule _inputModule;

	protected UIView View;

	private bool ShouldLog;

	protected SignalBus SignalBus;

	protected MultiplayerManager Multiplayer;

	protected Rewired.Player Player;

	protected DataManager Data;

	protected AdventureManager Adventure;

	protected bool _isWaitingForPlayersToEnterUi;

	private float _defaultRepeatDelay;

	private float _defaultInputActionsPerSecond;

	private float _maxInputActionsPerSecond;

	private float _scrollAccelerationSpeed;

	private static float SCROLL_ACTIONS_PER_SEC = 25f;

	private static float SCROLL_ACCELERATION = 3f;

	private Sprite _defaultPanelSprite;

	private RenderMode? _originalMode;

	private Vector3 _originalCanvasScale;

	private float _originalOrthographicSize;

	protected virtual bool IsOnlineUi => true;

	private void Construct(SignalBus signalBus, MultiplayerManager _mult, DataManager _data, AdventureManager _adventure)
	{
		SignalBus = signalBus;
		Multiplayer = _mult;
		Data = _data;
		AdventureManager adventure = default(AdventureManager);
		Adventure = adventure;
	}

	protected virtual void Awake()
	{
		//IL_004e: Expected I, but got O
		//IL_00af: Expected I, but got O
		//IL_0110: Expected I, but got O
		//IL_0171: Expected I, but got O
		UIView component = GetComponent<UIView>();
		View = component;
		UIView view = View;
		UIViewBehavior showBehavior = view.ShowBehavior;
		UIAction onStart = showBehavior.OnStart;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v462 @ r8_v3 (Il2CppClass<VampireSurvivors.UI.BaseUIPage>)+1A0]");
		Action<GameObject> action = new Action<GameObject>(this, (IntPtr)0);
		nint num = (nint)this;
		onStart.Action = action;
		UIView view2 = View;
		UIViewBehavior showBehavior2 = view2.ShowBehavior;
		UIAction onFinished = showBehavior2.OnFinished;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v581 @ r8_v6 (Il2CppClass<VampireSurvivors.UI.BaseUIPage>)+1D0]");
		Action<GameObject> action2 = new Action<GameObject>(this, (IntPtr)0);
		nint num2 = (nint)this;
		onFinished.Action = action2;
		UIView view3 = View;
		UIViewBehavior hideBehavior = view3.HideBehavior;
		UIAction onStart2 = hideBehavior.OnStart;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v644 @ r8_v9 (Il2CppClass<VampireSurvivors.UI.BaseUIPage>)+1E0]");
		Action<GameObject> action3 = new Action<GameObject>(this, (IntPtr)0);
		nint num3 = (nint)this;
		onStart2.Action = action3;
		UIView view4 = View;
		UIViewBehavior hideBehavior2 = view4.HideBehavior;
		UIAction onFinished2 = hideBehavior2.OnFinished;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v707 @ r8_v12 (Il2CppClass<VampireSurvivors.UI.BaseUIPage>)+1F0]");
		Action<GameObject> action4 = new Action<GameObject>(this, (IntPtr)0);
		nint num4 = (nint)this;
		onFinished2.Action = action4;
		EventSystem current = EventSystem.current;
		RewiredStandaloneInputModule component2 = current.GetComponent<RewiredStandaloneInputModule>();
		_inputModule = component2;
		RewiredStandaloneInputModule inputModule = _inputModule;
		if ((object)_inputModule != null && ((UnityEngine.Object)inputModule).m_CachedPtr != (IntPtr)0)
		{
			RewiredStandaloneInputModule inputModule2 = _inputModule;
			inputModule2.m_RepeatDelay = _defaultRepeatDelay;
			RewiredStandaloneInputModule inputModule3 = _inputModule;
			inputModule3.m_InputActionsPerSecond = _defaultInputActionsPerSecond;
		}
		ReInput.PlayerHelper players = ReInput.players;
		Rewired.Player player = players.GetPlayer(0);
		Player = player;
		if (!_hasScrollView)
		{
			return;
		}
		GameObject gameObject = _scroll.gameObject;
		ScrollEnhancer scrollEnhancer = gameObject.AddComponent<ScrollEnhancer>();
		_scrollEnhancer = scrollEnhancer;
		Slider slider = default(Slider);
		float offset = default(float);
		_scrollEnhancer.Initialize(_scrollSpeed, _content, _scrollbar, slider, offset);
		if (_hasScrollView)
		{
			Transform transform = _scroll.transform;
			Transform parent = transform.parent;
			Image component3 = parent.GetComponent<Image>();
			if ((object)component3 != null && ((UnityEngine.Object)component3).m_CachedPtr != (IntPtr)0)
			{
				_defaultPanelSprite = component3.m_Sprite;
			}
		}
	}

	protected virtual void OnShowStart(GameObject g)
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		//IL_0937: Expected I, but got O
		//IL_0106: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Expected O, but got Unknown
		//IL_096d: Expected I, but got O
		//IL_01ae: Expected O, but got I4
		//IL_01de: Expected O, but got I4
		//IL_01fe: Expected O, but got I4
		//IL_0264: Expected O, but got I4
		//IL_0264: Expected O, but got I
		//IL_026d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0272: Expected O, but got Unknown
		//IL_09a1: Expected O, but got I
		//IL_0446: Expected O, but got I4
		//IL_0492: Expected O, but got F4
		Canvas rootCanvas;
		if (SignalBus != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj2 = default(object);
			object obj = obj2 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			Type signalType = default(Type);
			bool flag = default(bool);
			SignalBus.InternalFire(signalType, (object)null, (object)null, flag);
			Action<OnlineSignals.CharacterDisconnected> token = null;
			nint num = (nint)this;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804A2950");
			if (SignalBus != null)
			{
				nint num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v669 @ rbx_v7 (Il2CppMethodInfo)+38]");
				if ((nint)0 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
				}
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v689 @ rbx_v8 (Il2CppMethodInfo)+38]");
				if ((nint)0 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
				object obj4 = default(object);
				object obj3 = obj4 + 32;
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
				Type signalType2 = default(Type);
				SignalBus.UnsubscribeInternal(signalType2, (object)null, (object)token, flag);
				Action<OnlineSignals.CharacterDisconnected> action = null;
				nint num4 = (nint)this;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804A2950");
				if (SignalBus != null)
				{
					nint num5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v786 @ rbx_v11 (Il2CppMethodInfo)+38]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
					}
					nint num6 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ rbx_v12 (Il2CppMethodInfo)+38]");
					bool flag2 = (nint)0 != 0;
					Action<object> callback = (Action<object>)flag;
					if (!flag2)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ rbx_v12 (Il2CppMethodInfo)+38]");
						bool flag3 = (nint)0 != 0;
						callback = (Action<object>)flag;
						if (!flag3)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
							callback = (Action<object>)flag;
						}
					}
					object obj5 = null;
					if (obj5 != null)
					{
						Action<object> action2 = ((SignalBus._003C_003Ec__DisplayClass37_0<OnlineSignals.CharacterDisconnected>)obj5)._003CSubscribeId_003Eb__0;
						((SignalBus._003C_003Ec__DisplayClass37_0<OnlineSignals.CharacterDisconnected>)0)._003CSubscribeId_003Eb__0((object)1);
						object obj7 = default(object);
						object obj6 = obj7 + 32;
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
						SignalBus signalBus = SignalBus;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v176 @ rax_v28 (System.Object)+10]");
						Type signalType3 = default(Type);
						signalBus.SubscribeInternal(signalType3, (object)null, (object)0, callback);
						SCROLL_ACTIONS_PER_SEC = _maxInputActionsPerSecond;
						SCROLL_ACCELERATION = _scrollAccelerationSpeed;
						RewiredStandaloneInputModule inputModule = _inputModule;
						if ((object)_inputModule != null && ((UnityEngine.Object)inputModule).m_CachedPtr != (IntPtr)0)
						{
							RewiredStandaloneInputModule inputModule2 = _inputModule;
							if ((object)_inputModule == null)
							{
								goto IL_08e7;
							}
							inputModule2.moveOneElementPerAxisPress = true;
						}
						if (!_UseScreenSpaceCamera)
						{
							goto IL_0627;
						}
						if ((object)View != null)
						{
							Canvas canvas = View.Canvas;
							if ((object)canvas != null)
							{
								rootCanvas = canvas.rootCanvas;
								if ((object)rootCanvas != null)
								{
									RenderMode renderMode = rootCanvas.renderMode;
									if (renderMode == RenderMode.WorldSpace)
									{
										GameManager core = GM.Core;
										if ((object)GM.Core != null && ((UnityEngine.Object)core).m_CachedPtr != (IntPtr)0)
										{
											GameManager core2 = GM.Core;
											if ((object)GM.Core != null)
											{
												if ((object)core2._preZoomOrthoSize == null)
												{
													goto IL_05c9;
												}
												RenderMode renderMode2 = rootCanvas.renderMode;
												_originalMode = (RenderMode?)(object)1;
												Transform transform = rootCanvas.transform;
												if ((object)transform != null)
												{
													Vector3 localScale = transform.localScale;
													_originalCanvasScale = (Vector3)localScale.x;
													_ = localScale.z;
													Camera main = Camera.main;
													if ((object)main != null)
													{
														float orthographicSize = main.orthographicSize;
														_originalOrthographicSize = orthographicSize;
														Camera main2 = Camera.main;
														if ((object)main2 != null)
														{
															float orthographicSize2 = main2.orthographicSize;
															GameManager core3 = GM.Core;
															if ((object)GM.Core != null)
															{
																if ((object)core3._preZoomOrthoSize == null)
																{
																	System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
																	return;
																}
																Camera main3 = Camera.main;
																if ((object)main3 != null)
																{
																	float orthographicSize3 = main3.orthographicSize;
																	float num7 = orthographicSize2 / (float)renderMode2;
																	float orthographicSize4 = num7 * orthographicSize3;
																	main3.orthographicSize = orthographicSize4;
																	goto IL_05c9;
																}
															}
														}
													}
												}
											}
											goto IL_08e7;
										}
									}
									goto IL_05c9;
								}
							}
						}
					}
				}
			}
		}
		goto IL_08e7;
		IL_0aa4:
		Image image;
		Sprite sprite;
		image.sprite = sprite;
		return;
		IL_0627:
		if (ShouldLog)
		{
			GameObject gameObject = base.gameObject;
			if ((object)gameObject == null)
			{
				goto IL_08e7;
			}
			string text = ((UnityEngine.Object)gameObject).GetName();
			string message = text + " Show : Start";
			Debug.Log(message);
		}
		_003CParse_003Ed__47 obj8 = null;
		obj8._003C_003E1__state = 0;
		obj8._003C_003E4__this = this;
		Coroutine coroutine = StartCoroutine(obj8);
		if (!AdventureManager._003CIsInAdventureMode_003Ek__BackingField)
		{
			Sprite defaultPanelSprite = _defaultPanelSprite;
			if ((object)_defaultPanelSprite == null || ((UnityEngine.Object)defaultPanelSprite).m_CachedPtr == (IntPtr)0)
			{
				return;
			}
			if ((object)_scroll != null)
			{
				Transform transform2 = _scroll.transform;
				if ((object)transform2 != null)
				{
					Transform parent = transform2.parent;
					if ((object)parent != null)
					{
						Image component = parent.GetComponent<Image>();
						if ((object)component != null)
						{
							sprite = _defaultPanelSprite;
							image = component;
							goto IL_0aa4;
						}
					}
				}
			}
		}
		else
		{
			if (!_hasScrollView)
			{
				return;
			}
			if ((object)_scroll != null)
			{
				Transform transform3 = _scroll.transform;
				if ((object)transform3 != null)
				{
					Transform parent2 = transform3.parent;
					if ((object)parent2 != null)
					{
						Image component2 = parent2.GetComponent<Image>();
						if ((object)component2 == null || ((UnityEngine.Object)component2).m_CachedPtr == (IntPtr)0)
						{
							return;
						}
						Sprite sprite2 = SpriteManager.GetSprite("AdventureFrame");
						sprite = sprite2;
						image = component2;
						goto IL_0aa4;
					}
				}
			}
		}
		goto IL_08e7;
		IL_05c9:
		rootCanvas.renderMode = RenderMode.ScreenSpaceCamera;
		GameObject gameObject2 = GameObject.Find("UI Camera");
		if ((object)gameObject2 != null)
		{
			Camera component3 = gameObject2.GetComponent<Camera>();
			rootCanvas.worldCamera = component3;
			goto IL_0627;
		}
		goto IL_08e7;
		IL_08e7:
		throw new NullReferenceException();
	}

	protected virtual void OnCharacterDisconnected(OnlineSignals.CharacterDisconnected signal)
	{
		//IL_00d0: Expected I, but got O
		//IL_0241: Expected O, but got I4
		//IL_025b: Expected O, but got I4
		//IL_02a9: Expected I8, but got O
		//IL_01a2: Expected I4, but got O
		//IL_0173: Expected I4, but got O
		GameObject gameObject = base.gameObject;
		if ((object)gameObject == null || ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		GameObject gameObject2 = base.gameObject;
		if (!gameObject2.activeInHierarchy)
		{
			return;
		}
		GameManager core = GM.Core;
		if (!core._multiplayer.IsOnlineMultiplayer || !GM.Core.IsStageHost)
		{
			return;
		}
		nint num = (nint)this;
		VampireSurvivors.Objects.Characters.CharacterController characterControllingUi = GetCharacterControllingUi();
		bool flag = (object)characterControllingUi == null;
		bool flag2 = (object)signal == null;
		object obj = flag2 & flag;
		bool flag3 = obj == null;
		object obj2 = !flag3;
		bool flag4 = flag;
		if (obj2 == null)
		{
			bool flag5;
			if ((object)characterControllingUi != null)
			{
				if ((object)signal != null)
				{
					object obj3 = (object)signal - (object)characterControllingUi;
					flag5 = obj3 == null;
					flag4 = flag;
				}
				else
				{
					flag5 = ((UnityEngine.Object)characterControllingUi).m_CachedPtr == (IntPtr)0;
					flag4 = (byte)(int)typeof(UnityEngine.Object) != 0;
				}
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [signal @ rdx (VampireSurvivors.Signals.OnlineSignals+CharacterDisconnected)+10]");
				flag5 = (nint)0 == 0;
				flag4 = (byte)(int)typeof(UnityEngine.Object) != 0;
			}
			if (!flag5)
			{
				return;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18699C080");
		OnlineStageManager onlineStageManager = default(OnlineStageManager);
		long startingOnlineClientFrame = onlineStageManager.GetStartingOnlineClientFrame();
		Action<long> action = null;
		((OnlineStageManager)(object)action).ForceCloseUi((long)onlineStageManager);
		bool flag6 = onlineStageManager._sync.SendCommand(action, MessageTarget.All, startingOnlineClientFrame);
	}

	protected void EnterMultiplayerControl(VampireSurvivors.Objects.Characters.CharacterController player, float vibrationMilliseconds = -1f)
	{
		//IL_007b: Invalid comparison between I4 and F4
		GameManager core = GM.Core;
		int localPlayerCount = core._multiplayer.GetLocalPlayerCount();
		if (localPlayerCount > 1 && player._player != null)
		{
			Player = player._player;
			if (0f > vibrationMilliseconds)
			{
			}
			float vibrationMS = default(float);
			Multiplayer.SelectPlayerToControlUI(player._player, exclusiveUIControl: true, vibrate: true, vibrationMS);
		}
	}

	private void SelectPlayerInput(VampireSurvivors.Objects.Characters.CharacterController player, float vibrationMilliseconds)
	{
		//IL_0044: Invalid comparison between I4 and F4
		if (player._player != null)
		{
			Player = player._player;
			if (0f > vibrationMilliseconds)
			{
			}
			float vibrationMS = default(float);
			Multiplayer.SelectPlayerToControlUI(player._player, exclusiveUIControl: true, vibrate: true, vibrationMS);
		}
	}

	protected virtual VampireSurvivors.Objects.Characters.CharacterController GetCharacterControllingUi()
	{
		if ((object)GM.Core != null)
		{
			return GM.Core.InteractingPlayer;
		}
		return (VampireSurvivors.Objects.Characters.CharacterController)(object)new NullReferenceException();
	}

	protected bool IsLocalPlayerControllingUi()
	{
		//IL_0083: Expected I4, but got O
		VampireSurvivors.Objects.Characters.CharacterController characterControllingUi = GetCharacterControllingUi();
		if ((object)characterControllingUi != null && ((UnityEngine.Object)characterControllingUi).m_CachedPtr != (IntPtr)0)
		{
			if ((object)characterControllingUi._coherenceSync != null)
			{
				return characterControllingUi._coherenceSync.HasStateAuthority;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
		return false;
	}

	protected void ExitMultiplayerControl()
	{
		GameManager core = GM.Core;
		int localPlayerCount = core._multiplayer.GetLocalPlayerCount();
		if (localPlayerCount > 1)
		{
			ReInput.PlayerHelper players = ReInput.players;
			Rewired.Player player = players.GetPlayer(0);
			Player = player;
			Multiplayer.SelectPlayerOneToControlUI();
		}
	}

	private void EnterOnlineMultiplayerControl()
	{
		//IL_0074: Expected I, but got O
		//IL_010e: Expected O, but got I
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Expected O, but got Unknown
		//IL_013d: Expected I4, but got I8
		GameManager core = GM.Core;
		if ((object)GM.Core == null || ((UnityEngine.Object)core).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		GameManager core2 = GM.Core;
		if (!core2._multiplayer.IsOnlineMultiplayer)
		{
			return;
		}
		nint num = (nint)this;
		if (IsOnlineUi)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18699C080");
			OnlineStageManager onlineStageManager = default(OnlineStageManager);
			PlayerInfo myPlayerInfo = onlineStageManager.GetMyPlayerInfo();
			if ((object)myPlayerInfo != null && ((UnityEngine.Object)myPlayerInfo).m_CachedPtr != (IntPtr)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18699C080");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v312 @ rax_v23+A8]");
				object obj = (nint)0 << 13;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v312 @ rax_v23+A8]");
				object obj2 = obj ^ 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v312 @ rax_v23+A8]");
				int num2 = -2147483648;
				object obj3 = obj2 >> 17;
				object obj4 = obj2 ^ obj3;
				object obj5 = obj4 << 5;
				object obj6 = obj5 ^ obj4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182AD6810");
				object message = default(object);
				Debug.Log(message);
				myPlayerInfo._003CUiPageId_003Ek__BackingField = num2;
				myPlayerInfo._hasGameplayUiActive = true;
				_003CWaitForPlayersToBeInsideGameplayUi_003Ed__44 obj7 = null;
				obj7._003C_003E1__state = 0;
				obj7._003C_003E4__this = this;
				obj7.uiPageId = num2;
				Coroutine coroutine = StartCoroutine(obj7);
			}
		}
	}

	private IEnumerator WaitForPlayersToBeInsideGameplayUi(int uiPageId)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected O, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Expected O, but got Unknown
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Expected O, but got Unknown
		//IL_0110: Expected O, but got I4
		_003CWaitForPlayersToBeInsideGameplayUi_003Ed__44 obj = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
		bool flag = (nint)0 == 0;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		if (!flag)
		{
			object obj2 = obj + 32;
			object obj3 = obj2 >> 12;
			object obj4 = obj3 & 0x1FFFFF;
			object obj5 = obj4 >> 6;
			object obj6 = obj4 & 0x3F;
			object obj7 = obj5 * 8;
			object obj8 = 6603864928L + obj7;
			do
			{
				object obj9 = 1 << (int)obj6;
				object obj10 = obj8 | obj9;
				if (obj8 == obj8)
				{
					obj8 = obj10;
				}
			}
			while (obj8 != obj8);
			obj.uiPageId = uiPageId;
			return obj;
		}
		obj.uiPageId = uiPageId;
		return obj;
	}

	private unsafe List<Button> DeactivateButtons(out Selectable selectedBtn)
	{
		//IL_02a4: Expected O, but got I4
		//IL_0378: Expected O, but got I4
		//IL_03a1: Expected O, but got I4
		ref Selectable reference = ref *(Selectable*)null;
		Button[] componentsInChildren = GetComponentsInChildren<Button>();
		List<Button> list = (List<Button>)(object)new List<object>(componentsInChildren);
		bool flag = (nint)list < 0;
		int num = list._size - 1;
		Button[] array = componentsInChildren;
		if (!flag)
		{
			List<Button> result = default(List<Button>);
			object obj4;
			do
			{
				Button[] items;
				bool flag2;
				if (num < list._size)
				{
					items = list._items;
					Component component = items[num];
					flag2 = (nint)items[num] < 0;
					if ((object)items[num] != null)
					{
						flag2 = (nint)((UnityEngine.Object)component).m_CachedPtr < 0;
						if (((UnityEngine.Object)component).m_CachedPtr != (IntPtr)0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ rbp_v5 (UnityEngine.Component)+D8]");
							flag2 = (nint)0 < (nint)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ rbp_v5 (UnityEngine.Component)+D8]");
							if ((nint)0 != 0)
							{
								Selectable component2 = items[num].GetComponent<Selectable>();
								flag2 = (nint)component2 < 0;
								if ((object)component2 != null)
								{
									flag2 = (nint)((UnityEngine.Object)component2).m_CachedPtr < 0;
									if (((UnityEngine.Object)component2).m_CachedPtr != (IntPtr)0)
									{
										EventSystem current = EventSystem.current;
										array = (Button[])(object)current.m_CurrentSelected;
										GameObject gameObject = component2.gameObject;
										bool flag3 = (object)gameObject == null;
										bool flag4 = (object)current.m_CurrentSelected == null;
										object obj = flag4 & flag3;
										bool flag5 = obj == null;
										bool flag6 = (nint)obj < 0;
										object obj2 = !flag5;
										if (obj2 == null)
										{
											bool flag7;
											if ((object)gameObject != null)
											{
												if ((object)current.m_CurrentSelected != null)
												{
													object obj3 = (object)current.m_CurrentSelected - (object)gameObject;
													flag7 = obj3 == null;
												}
												else
												{
													flag7 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
												}
											}
											else
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v516 @ rbx_v8 (UnityEngine.UI.Button[])+10]");
												flag7 = (nint)0 == 0;
											}
											flag6 = (flag7 ? 1 : 0) < (false ? 1 : 0);
											bool flag8 = !flag7;
											flag2 = flag6;
											if (flag8)
											{
												goto IL_025d;
											}
										}
										reference = ref *(Selectable*)component2;
										flag2 = flag6;
									}
								}
								goto IL_025d;
							}
						}
					}
					list.RemoveAt(num);
					goto IL_028b;
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				return result;
				IL_028b:
				num--;
				obj4 = !flag2;
				continue;
				IL_025d:
				items[num].interactable = false;
				goto IL_028b;
			}
			while (obj4 != null);
		}
		return list;
	}

	private void ReactivateButtons(List<Button> buttons, Selectable selectedBtn)
	{
		List<Button>.Enumerator enumerator = default(List<Button>.Enumerator);
		while (enumerator.MoveNext())
		{
			Selectable selectable = null;
		}
		if ((object)selectedBtn != null && ((UnityEngine.Object)selectedBtn).m_CachedPtr != (IntPtr)0)
		{
			selectedBtn.Select();
		}
	}

	private IEnumerator Parse()
	{
		_003CParse_003Ed__47 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	public void ForceScrollAlignment()
	{
		_scrollEnhancer.ForceScrollAlignment();
	}

	protected virtual void OnShowFinish(GameObject g)
	{
		if (ShouldLog)
		{
			GameObject gameObject = base.gameObject;
			string text = ((UnityEngine.Object)gameObject).GetName();
			string message = text + " Show : Finish";
			Debug.Log(message);
		}
		EnterOnlineMultiplayerControl();
	}

	protected virtual void OnHideStart(GameObject g)
	{
		if (ShouldLog)
		{
			GameObject gameObject = base.gameObject;
			string text = ((UnityEngine.Object)gameObject).GetName();
			string message = text + " Hide : Start";
			Debug.Log(message);
		}
		GameManager core = GM.Core;
		if ((object)GM.Core != null && ((UnityEngine.Object)core).m_CachedPtr != (IntPtr)0)
		{
			GameManager core2 = GM.Core;
			if (core2._multiplayer.IsOnlineMultiplayer)
			{
				Debug.Log("Setting HasGameplayUiActive to false");
				PlayerInfo myPlayerInfo = OnlineStageManager._instance.GetMyPlayerInfo();
				myPlayerInfo._hasGameplayUiActive = false;
			}
		}
	}

	protected virtual void OnHideFinish(GameObject g)
	{
		//IL_026f: Expected I, but got O
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Expected O, but got Unknown
		//IL_0122: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Expected O, but got Unknown
		//IL_014d: Expected I, but got O
		//IL_0339: Expected O, but got I4
		//IL_033e->IL02d4: Incompatible stack heights: 2 vs 0
		Action<OnlineSignals.CharacterDisconnected> token = null;
		nint num = (nint)this;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804A2950");
		if (SignalBus != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj2 = default(object);
			object obj = obj2 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			Type signalType = default(Type);
			bool throwIfMissing = default(bool);
			SignalBus.UnsubscribeInternal(signalType, (object)null, (object)token, throwIfMissing);
			if (ShouldLog)
			{
				GameObject gameObject = base.gameObject;
				if ((object)gameObject == null)
				{
					goto IL_025e;
				}
				string text = ((UnityEngine.Object)gameObject).GetName();
				string message = text + " Hide : Finish";
				Debug.Log(message);
			}
			if (!_UseScreenSpaceCamera || (object)_originalMode == null)
			{
				return;
			}
			object obj3 = (object?)_originalMode >> 32;
			object obj4 = obj3 - 2;
			bool flag = obj4 == null;
			object obj5 = (_003F?)_originalMode & flag;
			if (obj5 == null)
			{
				return;
			}
			nint num2 = (nint)GM.Core;
			if ((object)GM.Core == null)
			{
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ rbx_v13 (Il2CppClass<VampireSurvivors.Signals.OnlineSignals+CharacterDisconnected>)+10]");
			if ((nint)0 == 0)
			{
				return;
			}
			GameManager core = GM.Core;
			if ((object)GM.Core != null)
			{
				if ((object)core._preZoomOrthoSize != null)
				{
					Camera main = Camera.main;
					main.orthographicSize = _originalOrthographicSize;
					Canvas canvas = View.Canvas;
					Canvas rootCanvas = canvas.rootCanvas;
					bool flag2 = (object)_originalMode == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.UI.BaseUIPage)+CC]");
					rootCanvas.renderMode = RenderMode.ScreenSpaceOverlay;
					Transform transform = rootCanvas.transform;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v596 @ rax_v37 (UnityEngine.Transform)+10]");
					bool flag3 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v596 @ rax_v37 (UnityEngine.Transform)+10]");
					Vector3 value = default(Vector3);
					Transform.set_localScale_Injected((IntPtr)0, ref value);
					_originalMode = (RenderMode?)(object)0;
				}
				return;
			}
		}
		goto IL_025e;
		IL_025e:
		throw new NullReferenceException();
	}

	protected virtual void Update()
	{
		//IL_0625: Expected O, but got F4
		//IL_0722: Expected O, but got I4
		//IL_073c: Expected O, but got I4
		if (Player == null)
		{
			int localPlayerCount = Multiplayer.GetLocalPlayerCount();
			if (localPlayerCount <= 1)
			{
				int playerCount = Multiplayer.GetPlayerCount();
				Rewired.Player player;
				if (playerCount != 1)
				{
					ReInput.PlayerHelper players = ReInput.players;
					player = players.GetPlayer(0);
				}
				else
				{
					player = Multiplayer.GetRewiredPlayerOne();
				}
				Player = player;
			}
			else
			{
				Rewired.Player selectedPlayer = Multiplayer.GetSelectedPlayer();
				Player = selectedPlayer;
			}
		}
		if (Multiplayer.IsUIBeingBlocked)
		{
			return;
		}
		RewiredStandaloneInputModule inputModule = _inputModule;
		if ((object)_inputModule != null && ((UnityEngine.Object)inputModule).m_CachedPtr != (IntPtr)0)
		{
			float axis = Player.GetAxis("UIVertical");
			float axis2 = Player.GetAxis("UIHorizontal");
			if (!(axis < -0.1f) && !(0.1f < axis) && !(axis2 < -0.1f) && !(0.1f < axis2))
			{
				RewiredStandaloneInputModule inputModule2 = _inputModule;
				inputModule2.moveOneElementPerAxisPress = false;
				RewiredStandaloneInputModule inputModule3 = _inputModule;
				inputModule3.m_InputActionsPerSecond = _defaultInputActionsPerSecond;
			}
			else
			{
				RewiredStandaloneInputModule inputModule4 = _inputModule;
				float inputActionsPerSecond = SCROLL_ACTIONS_PER_SEC;
				RewiredStandaloneInputModule inputModule5 = _inputModule;
				object obj = Time.deltaTime;
				float num = axis2 * SCROLL_ACCELERATION;
				float num2 = num + inputModule5.m_InputActionsPerSecond;
				if (!(num2 > SCROLL_ACTIONS_PER_SEC))
				{
					inputActionsPerSecond = num2;
				}
				inputModule4.m_InputActionsPerSecond = inputActionsPerSecond;
			}
		}
		if (Player.GetButtonDown(5))
		{
			OnEnterPressed();
		}
		if (Player.GetButtonDown(10))
		{
			OnCancelPressed();
		}
		if (_hasScrollView)
		{
			GameObject gameObject = _Slider.gameObject;
			if (gameObject.activeInHierarchy)
			{
				ReInput.PlayerHelper players2 = ReInput.players;
				Rewired.Player player2 = players2.GetPlayer(0);
				if (player2.GetButtonDown("UIPageDown"))
				{
					ScrollSelection(up: false);
				}
				ReInput.PlayerHelper players3 = ReInput.players;
				Rewired.Player player3 = players3.GetPlayer(0);
				if (player3.GetButtonDown("UIPageUp"))
				{
					ScrollSelection(up: true);
				}
			}
		}
		EventSystem current = EventSystem.current;
		GameObject currentSelected = current.m_CurrentSelected;
		if ((object)current.m_CurrentSelected == null || ((UnityEngine.Object)currentSelected).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		RectTransform content = _content;
		if ((object)_content == null || ((UnityEngine.Object)content).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		EventSystem current2 = EventSystem.current;
		Transform transform = current2.m_CurrentSelected.transform;
		Transform transform2 = transform;
		while (true)
		{
			Transform parent = transform2.parent;
			if ((object)parent == null || ((UnityEngine.Object)parent).m_CachedPtr == (IntPtr)0)
			{
				break;
			}
			Transform parent2 = transform2.parent;
			GameObject gameObject2 = parent2.gameObject;
			GameObject gameObject3 = _content.gameObject;
			bool flag = (object)gameObject3 == null;
			bool flag2 = (object)gameObject2 == null;
			object obj2 = flag2 & flag;
			bool flag3 = obj2 == null;
			object obj3 = !flag3;
			if (obj3 == null)
			{
				bool flag4;
				if ((object)gameObject3 != null)
				{
					if ((object)gameObject2 != null)
					{
						object obj4 = (object)gameObject2 - (object)gameObject3;
						flag4 = obj4 == null;
					}
					else
					{
						flag4 = ((UnityEngine.Object)gameObject3).m_CachedPtr == (IntPtr)0;
					}
				}
				else
				{
					flag4 = ((UnityEngine.Object)gameObject2).m_CachedPtr == (IntPtr)0;
				}
				if (!flag4)
				{
					Transform parent3 = transform2.parent;
					transform2 = parent3;
					continue;
				}
			}
			int siblingIndex = transform2.GetSiblingIndex();
			previouslySelectedItemIndex = siblingIndex;
			break;
		}
	}

	private void ScrollSelection(bool up)
	{
		//IL_0bfb: Expected O, but got I4
		//IL_0c70: Expected O, but got I4
		//IL_0c8a: Expected O, but got I4
		//IL_021c: Invalid comparison between F4 and O
		//IL_028e: Expected O, but got I4
		//IL_0d18: Expected F4, but got I4
		//IL_0d21: Expected O, but got I4
		//IL_032c: Expected F4, but got I4
		//IL_0335: Expected O, but got I4
		//IL_0360: Expected F4, but got I
		//IL_0d66: Expected F4, but got O
		//IL_03a4: Expected F4, but got O
		//IL_05fc: Expected I4, but got O
		//IL_08ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_08b1: Expected I4, but got Unknown
		//IL_08bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_08c0: Expected I4, but got Unknown
		//IL_0e3d: Expected O, but got I4
		//IL_0a98: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a9d: Expected O, but got Unknown
		//IL_0ab4: Invalid comparison between F4 and O
		//IL_06d0: Expected I4, but got O
		//IL_0b9c->IL0b9c: Incompatible stack heights: 1 vs 0
		//IL_0b90->IL0ec6: Incompatible stack heights: 3 vs 1
		//IL_0293->IL0293: Incompatible stack heights: 11 vs 8
		//IL_0275->IL0c98: Incompatible stack heights: 12 vs 7
		//IL_0e89->IL0dd1: Incompatible stack heights: 21 vs 18
		//IL_0762->IL0dd1: Incompatible stack heights: 21 vs 18
		//IL_0725->IL0dd1: Incompatible stack heights: 21 vs 18
		//IL_05d2->IL0dec: Incompatible stack heights: 21 vs 18
		//IL_06c1->IL070b: Incompatible stack heights: 23 vs 21
		//IL_0ea4->IL0ac6: Incompatible stack heights: 26 vs 25
		//IL_05e5->IL0dd1: Incompatible stack heights: 21 vs 18
		//IL_0705->IL0e5c: Incompatible stack heights: 23 vs 19
		//IL_070b->IL070b: Incompatible stack heights: 23 vs 21
		//IL_0ec1->IL0ec6: Incompatible stack heights: 27 vs 1
		//IL_0b6e->IL0ec6: Incompatible stack heights: 27 vs 1
		//IL_0b81->IL0ec6: Incompatible stack heights: 27 vs 1
		while (true)
		{
			object content = _content;
			bool flag = (object)_content == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rbx_v1 (System.Object)+10]");
			if ((nint)0 != 0)
			{
				break;
			}
			UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(_content);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rbx_v1 (System.Object)+10]");
		object obj = Transform.get_childCount_Injected((IntPtr)0);
		if ((nint)obj < 2)
		{
			return;
		}
		bool flag2 = (object)_content == null;
		Transform child = _content.GetChild(0);
		bool flag3 = (object)child == null;
		Selectable componentInChildren = child.GetComponentInChildren<Selectable>();
		object obj6 = default(object);
		int index;
		RectTransform rectTransform;
		if ((object)componentInChildren != null && ((UnityEngine.Object)componentInChildren).m_CachedPtr != (IntPtr)0)
		{
			bool flag4 = (object)_content == null;
			Transform child2 = _content.GetChild(0);
			bool flag5 = (object)child2 == null;
			RectTransform component = child2.GetComponent<RectTransform>();
			bool flag6 = (object)component == null;
			Vector2 sizeDelta = component.sizeDelta;
			object content2 = _content;
			bool flag7 = (object)_content == null;
			int num = 0;
			int num2 = 0;
			object obj3;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v186 @ rbx_v13 (System.Object)+10]");
				bool flag8 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v186 @ rbx_v13 (System.Object)+10]");
				object obj2 = Transform.get_childCount_Injected((IntPtr)0);
				bool flag9 = num >= (nint)obj2;
				obj3 = 1;
				if (flag9)
				{
					break;
				}
				bool flag10 = (object)_content == null;
				Transform child3 = _content.GetChild(num2);
				bool flag11 = (object)child3 == null;
				RectTransform component2 = child3.GetComponent<RectTransform>();
				bool flag12 = (object)component2 == null;
				Vector2 sizeDelta2 = component2.sizeDelta;
				object obj4 = sizeDelta2 - sizeDelta;
				object obj5 = obj6 - obj6;
				object obj7 = obj5 * obj5;
				object obj8 = obj4 * obj4;
				object obj9 = obj7 + obj8;
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)9.9999994E-11f) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj9))
				{
					content2 = _content;
					num2++;
					bool flag13 = (object)_content == null;
					num = num2;
					continue;
				}
				Debug.Log("Scroll content : IS NOT UNIFORM SIZE");
				obj3 = 0;
				break;
			}
			bool flag14 = (object)_content == null;
			Vector2 sizeDelta3 = _content.sizeDelta;
			object scroll = _scroll;
			bool flag15 = (object)_scroll == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v188 @ rbx_v14 (System.Object)+10]");
			bool flag16 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v188 @ rbx_v14 (System.Object)+10]");
			RectTransform.get_rect_Injected((IntPtr)0, out Rect _);
			object obj11 = default(object);
			object obj10 = obj6 / obj11;
			bool flag17 = (object)_content == null;
			GridLayoutGroup component3 = _content.GetComponent<GridLayoutGroup>();
			bool flag18 = (object)component3 == null;
			float num3 = 0f;
			Vector2 vector = (Vector2)0;
			if (!flag18)
			{
				bool flag19 = ((UnityEngine.Object)component3).m_CachedPtr == (IntPtr)0;
				num3 = 0f;
				vector = (Vector2)0;
				if (!flag19)
				{
					vector = component3.m_Spacing;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1613 @ rax_v51 (UnityEngine.UI.GridLayoutGroup)+74]");
					num3 = 0f;
				}
			}
			bool flag20 = (object)_content == null;
			HorizontalLayoutGroup component4 = _content.GetComponent<HorizontalLayoutGroup>();
			bool flag21 = (object)component4 == null;
			float num4 = (float)vector;
			if (!flag21)
			{
				bool flag22 = ((UnityEngine.Object)component4).m_CachedPtr == (IntPtr)0;
				num4 = (float)vector;
				if (!flag22)
				{
					num4 = ((HorizontalOrVerticalLayoutGroup)component4).m_Spacing;
				}
			}
			bool flag23 = (object)_content == null;
			VerticalLayoutGroup component5 = _content.GetComponent<VerticalLayoutGroup>();
			if ((object)component5 != null && ((UnityEngine.Object)component5).m_CachedPtr != (IntPtr)0)
			{
				num3 = ((HorizontalOrVerticalLayoutGroup)component5).m_Spacing;
			}
			if (obj3 == null)
			{
				bool flag24 = (object)_content == null;
				Vector2 sizeDelta4 = _content.sizeDelta;
				int num5 = previouslySelectedItemIndex;
				object obj12 = obj6 / obj10;
				bool flag25 = (object)_content == null;
				Transform child4 = _content.GetChild(previouslySelectedItemIndex);
				bool flag26 = (object)child4 == null;
				RectTransform component6 = child4.GetComponent<RectTransform>();
				bool flag27 = (object)component6 == null;
				Vector2 anchoredPosition = component6.anchoredPosition;
				if (up)
				{
					object obj13 = obj6 + obj12;
					bool flag28 = previouslySelectedItemIndex <= -1;
					index = 0;
					if (!flag28)
					{
						while (true)
						{
							bool flag29 = (object)_content == null;
							Transform child5 = _content.GetChild(num5);
							bool flag30 = (object)child5 == null;
							RectTransform component7 = child5.GetComponent<RectTransform>();
							bool flag31 = (object)component7 == null;
							Vector2 anchoredPosition2 = component7.anchoredPosition;
							bool flag32 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj6) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj13);
							rectTransform = component7;
							if (flag32)
							{
								break;
							}
							num5--;
							if (num5 > -1)
							{
								continue;
							}
							goto IL_05d7;
						}
						goto IL_070b;
					}
				}
				else
				{
					object obj14 = obj6 - obj12;
					int num6 = (int)_content;
					bool flag33 = (object)_content == null;
					int num7 = previouslySelectedItemIndex;
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ rsi_v17 (System.Int32)+10]");
						bool flag34 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ rsi_v17 (System.Int32)+10]");
						object obj15 = Transform.get_childCount_Injected((IntPtr)0);
						if (num7 >= (nint)obj15)
						{
							break;
						}
						bool flag35 = (object)_content == null;
						Transform child6 = _content.GetChild(num5);
						bool flag36 = (object)child6 == null;
						RectTransform component8 = child6.GetComponent<RectTransform>();
						bool flag37 = (object)component8 == null;
						Vector2 anchoredPosition3 = component8.anchoredPosition;
						bool flag38 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj14) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj6);
						rectTransform = component8;
						if (!flag38)
						{
							num6 = (int)_content;
							num5++;
							bool flag39 = (object)_content != null;
							num7 = num5;
							if (flag39)
							{
								continue;
							}
						}
						goto IL_070b;
					}
					bool flag40 = (object)_content == null;
					int childCount = _content.childCount;
					index = childCount - 1;
				}
			}
			else
			{
				bool flag41 = (object)_content == null;
				Transform child7 = _content.GetChild(0);
				bool flag42 = (object)child7 == null;
				RectTransform component9 = child7.GetComponent<RectTransform>();
				bool flag43 = (object)component9 == null;
				Vector2 sizeDelta5 = component9.sizeDelta;
				bool flag44 = (object)_scroll == null;
				Rect rect = _scroll.rect;
				float num8 = (float)sizeDelta5 + num4;
				float num9 = rect.m_Width / num8;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B93760");
				bool flag45 = (object)_scroll == null;
				Rect rect2 = _scroll.rect;
				float num10 = (float)obj6 + num3;
				float num11 = rect2.m_Height / num10;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B93760");
				object obj17 = default(object);
				object obj18 = default(object);
				object obj16 = obj17 * obj18;
				int num12 = obj16 + previouslySelectedItemIndex;
				int num13 = previouslySelectedItemIndex - obj16;
				if (!up)
				{
					num13 = num12;
				}
				bool flag46 = (object)_content == null;
				Transform transform = _content.transform;
				bool flag47 = (object)transform == null;
				int childCount2 = transform.childCount;
				int num14 = childCount2 - 1;
				if (num13 >= 0)
				{
					if (num13 > num14)
					{
						num13 = num14;
					}
				}
				else
				{
					num13 = 0;
				}
				index = num13;
			}
			goto IL_0dd1;
		}
		ScrollPageWithoutSelectables(up);
		return;
		IL_070b:
		int siblingIndex = rectTransform.GetSiblingIndex();
		index = siblingIndex;
		goto IL_0dd1;
		IL_05d7:
		index = 0;
		goto IL_0dd1;
		IL_0dd1:
		bool flag48 = (object)_content == null;
		Vector2 sizeDelta6 = _content.sizeDelta;
		bool flag49 = (object)_content == null;
		Transform child8 = _content.GetChild(index);
		bool flag50 = (object)child8 == null;
		RectTransform component10 = child8.GetComponent<RectTransform>();
		bool flag51 = (object)component10 == null;
		Vector2 anchoredPosition4 = component10.anchoredPosition;
		bool flag52 = (object)_content == null;
		Transform child9 = _content.GetChild(index);
		bool flag53 = (object)child9 == null;
		RectTransform component11 = child9.GetComponent<RectTransform>();
		bool flag54 = (object)component11 == null;
		Vector2 sizeDelta7 = component11.sizeDelta;
		float num15 = (float)obj6 * 0.5f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj20 = default(object);
		object obj19 = obj20 & 0;
		float num16 = num15 + num15;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num16) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj19))
		{
			bool flag55 = (object)_content == null;
		}
		Vector2 anchoredPosition5 = _content.anchoredPosition;
		Vector2 anchoredPosition6 = default(Vector2);
		_content.anchoredPosition = anchoredPosition6;
		bool flag56 = (object)_content == null;
		Transform child10 = _content.GetChild(index);
		bool flag57 = (object)child10 == null;
		Selectable componentInChildren2 = child10.GetComponentInChildren<Selectable>();
		if ((object)componentInChildren2 != null && ((UnityEngine.Object)componentInChildren2).m_CachedPtr != (IntPtr)0)
		{
			componentInChildren2.Select();
		}
	}

	private void ScrollPageWithoutSelectables(bool up)
	{
		bool num;
		Rect ret;
		if (!up)
		{
			if ((object)_content != null)
			{
				Vector2 anchoredPosition = _content.anchoredPosition;
				if ((object)_content != null)
				{
					Vector2 anchoredPosition2 = _content.anchoredPosition;
					BaseUIPage scroll = (BaseUIPage)(object)_scroll;
					if ((object)_scroll != null)
					{
						bool flag = ((UnityEngine.Object)scroll).m_CachedPtr == (IntPtr)0;
						num = flag;
						RectTransform.get_rect_Injected(((UnityEngine.Object)scroll).m_CachedPtr, out ret);
						goto IL_019d;
					}
				}
			}
		}
		else if ((object)_content != null)
		{
			Vector2 anchoredPosition3 = _content.anchoredPosition;
			if ((object)_content != null)
			{
				Vector2 anchoredPosition4 = _content.anchoredPosition;
				BaseUIPage scroll2 = (BaseUIPage)(object)_scroll;
				if ((object)_scroll != null)
				{
					bool flag2 = ((UnityEngine.Object)scroll2).m_CachedPtr == (IntPtr)0;
					num = flag2;
					RectTransform.get_rect_Injected(((UnityEngine.Object)scroll2).m_CachedPtr, out ret);
					goto IL_019d;
				}
			}
		}
		throw new NullReferenceException();
		IL_019d:
		Vector2 anchoredPosition5 = default(Vector2);
		_content.anchoredPosition = anchoredPosition5;
	}

	protected void ForceBackButtonNavigation(Selectable up, Selectable down, Selectable left, Selectable right)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9A320");
	}

	protected void ResetBackButtonNavigation()
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType = default(Type);
		bool requireDeclaration = default(bool);
		SignalBus.InternalFire(signalType, (object)null, (object)null, requireDeclaration);
	}

	protected virtual void OnEnterPressed()
	{
	}

	protected virtual void OnCancelPressed()
	{
	}

	protected unsafe void SetNavigationUp(Selectable origin, Selectable target = null)
	{
		//IL_0082: Expected O, but got Ref
		//IL_0052: Expected O, but got Ref
		if ((object)target == null || ((UnityEngine.Object)target).m_CachedPtr == (IntPtr)0)
		{
			object obj = default(object);
			Selectable selectable = origin.FindSelectable((Vector3)(&obj));
		}
		object obj2 = default(object);
		origin.navigation = (Navigation)(&obj2);
	}

	protected unsafe void SetNavigationDown(Selectable origin, Selectable target = null)
	{
		//IL_0083: Expected O, but got Ref
		//IL_0052: Expected O, but got Ref
		if ((object)target == null || ((UnityEngine.Object)target).m_CachedPtr == (IntPtr)0)
		{
			Vector3 vector = default(Vector3);
			Selectable selectable = origin.FindSelectable((Vector3)(&vector));
		}
		object obj = default(object);
		origin.navigation = (Navigation)(&obj);
	}

	protected unsafe void SetNavigationLeft(Selectable origin, Selectable target = null)
	{
		//IL_0083: Expected O, but got Ref
		//IL_0052: Expected O, but got Ref
		if ((object)target == null || ((UnityEngine.Object)target).m_CachedPtr == (IntPtr)0)
		{
			Vector3 vector = default(Vector3);
			Selectable selectable = origin.FindSelectable((Vector3)(&vector));
		}
		object obj = default(object);
		origin.navigation = (Navigation)(&obj);
	}

	protected unsafe void SetNavigationRight(Selectable origin, Selectable target = null)
	{
		//IL_0082: Expected O, but got Ref
		//IL_0052: Expected O, but got Ref
		if ((object)target == null || ((UnityEngine.Object)target).m_CachedPtr == (IntPtr)0)
		{
			object obj = default(object);
			Selectable selectable = origin.FindSelectable((Vector3)(&obj));
		}
		object obj2 = default(object);
		origin.navigation = (Navigation)(&obj2);
	}

	protected unsafe void SetNavigationMode(Selectable origin, Navigation.Mode mode)
	{
		//IL_000d: Expected O, but got Ref
		object obj = default(object);
		origin.navigation = (Navigation)(&obj);
	}

	protected unsafe void ClearNavigationUp(Selectable origin)
	{
		//IL_0012: Expected O, but got Ref
		object obj = default(object);
		origin.navigation = (Navigation)(&obj);
	}

	protected unsafe void ClearNavigationDown(Selectable origin)
	{
		//IL_0012: Expected O, but got Ref
		object obj = default(object);
		origin.navigation = (Navigation)(&obj);
	}

	protected unsafe void ClearNavigationLeft(Selectable origin)
	{
		//IL_0012: Expected O, but got Ref
		object obj = default(object);
		origin.navigation = (Navigation)(&obj);
	}

	protected unsafe void ClearNavigationRight(Selectable origin)
	{
		//IL_0012: Expected O, but got Ref
		object obj = default(object);
		origin.navigation = (Navigation)(&obj);
	}

	public void SetScrollAcceleration(float maxSpeed, float acceleration)
	{
		_maxInputActionsPerSecond = maxSpeed;
		_scrollAccelerationSpeed = acceleration;
	}

	public BaseUIPage()
	{
		//IL_0062: Expected I, but got O
		_UseScreenSpaceCamera = true;
		_scrollSpeed = 3f;
		_ForceScrollBarSize = 0.01f;
		_defaultRepeatDelay = 0.44f;
		_defaultInputActionsPerSecond = 4.5f;
		_maxInputActionsPerSecond = 25f;
		_scrollAccelerationSpeed = 3f;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
