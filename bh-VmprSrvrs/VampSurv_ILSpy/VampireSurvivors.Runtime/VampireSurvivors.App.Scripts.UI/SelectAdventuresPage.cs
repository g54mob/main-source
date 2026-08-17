using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Coherence.Cloud;
using Com.LuisPedroFonseca.ProCamera2D;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Rewired.Integration.UnityUI;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using VampireSurvivors.Achievements;
using VampireSurvivors.App.Data.Adventures;
using VampireSurvivors.App.Scripts.Data;
using VampireSurvivors.App.Scripts.Framework.Adventures;
using VampireSurvivors.App.UI;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.DLC;
using VampireSurvivors.Framework.Loading;
using VampireSurvivors.Objects;
using VampireSurvivors.Tools;
using VampireSurvivors.UI;

namespace VampireSurvivors.App.Scripts.UI;

public class SelectAdventuresPage : BaseUIPage
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Func<KeyValuePair<AdventureType, AdventureData>, int> _003C_003E9__48_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal int _003CPopulate_003Eb__48_0(KeyValuePair<AdventureType, AdventureData> kvp)
		{
			//IL_0030: Expected O, but got I
			//IL_0020: Expected I4, but got O
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [kvp @ rdx (System.Collections.Generic.KeyValuePair`2<VampireSurvivors.Data.AdventureType, VampireSurvivors.App.Data.Adventures.AdventureData>)+8]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [kvp @ rdx (System.Collections.Generic.KeyValuePair`2<VampireSurvivors.Data.AdventureType, VampireSurvivors.App.Data.Adventures.AdventureData>)+8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ rax_v2+10]");
				return 0;
			}
			NullReferenceException ex = new NullReferenceException();
			return (int)ex;
		}
	}

	private sealed class _003C_003Ec__DisplayClass41_0
	{
		public SelectAdventuresPage _003C_003E4__this;

		public GameObject bg;

		internal void _003CAnimate_003Eb__0()
		{
			Transform transform = bg.transform;
			_003CMoveBackgroundIntoPlaceInANiceFancyWay_003Ed__42 obj = null;
			obj._003C_003E1__state = 0;
			obj._003C_003E4__this = _003C_003E4__this;
			obj.bg = transform;
			Coroutine coroutine = CoroutineRunner.Instance.StartCoroutine(obj);
		}
	}

	private sealed class _003CAnimate_003Ed__41(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public SelectAdventuresPage _003C_003E4__this;

		private _003C_003Ec__DisplayClass41_0 _003C_003E8__1;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private unsafe bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_011a: Expected I4, but got I8
			//IL_0149: Expected O, but got I
			//IL_01ac: Expected O, but got I
			//IL_0095: Expected O, but got I
			//IL_050b: Expected O, but got I
			//IL_0583: Expected O, but got I
			//IL_037c->IL0621: Incompatible stack heights: 1 vs 0
			//IL_039e->IL0621: Incompatible stack heights: 1 vs 0
			//IL_03cd->IL0621: Incompatible stack heights: 1 vs 0
			//IL_0400->IL0621: Incompatible stack heights: 2 vs 0
			//IL_0422->IL0621: Incompatible stack heights: 2 vs 0
			//IL_053a->IL0621: Incompatible stack heights: 2 vs 0
			//IL_04e2->IL0621: Incompatible stack heights: 2 vs 0
			//IL_055c->IL0621: Incompatible stack heights: 2 vs 0
			//IL_05a3->IL0621: Incompatible stack heights: 2 vs 0
			//IL_05df->IL0613: Incompatible stack heights: 3 vs 0
			//IL_0604->IL0613: Incompatible stack heights: 3 vs 0
			//IL_0613->IL0613: Incompatible stack heights: 3 vs 0
			Component component = _003C_003E4__this;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				_003C_003Ec__DisplayClass41_0 obj = new _003C_003Ec__DisplayClass41_0();
				_003C_003E8__1 = obj;
				_003C_003Ec__DisplayClass41_0 obj2 = _003C_003E8__1;
				if (_003C_003E8__1 != null)
				{
					obj2._003C_003E4__this = _003C_003E4__this;
					if ((object)_003C_003E4__this != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rbp_v1 (UnityEngine.Component)+140]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rbp_v1 (UnityEngine.Component)+140]");
							GameObject gameObject = ((Component)0).gameObject;
							if ((object)gameObject != null)
							{
								gameObject.SetActive(value: true);
								_003C_003E2__current = null;
								_003C_003E1__state = 1;
								return true;
							}
						}
					}
				}
			}
			else
			{
				if (_003C_003E1__state != 1)
				{
					goto IL_0613;
				}
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rbp_v1 (UnityEngine.Component)+198]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rbp_v1 (UnityEngine.Component)+198]");
					if ((nint)0 != 0)
					{
						_003C_003Ec__DisplayClass41_0 obj4 = _003C_003E8__1;
						if (_003C_003E8__1 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v259 @ rax_v23+A8]");
							obj4.bg = (GameObject)0;
							_003C_003Ec__DisplayClass41_0 obj5 = _003C_003E8__1;
							if (_003C_003E8__1 != null && (object)obj5.bg != null)
							{
								RectTransform component2 = obj5.bg.GetComponent<RectTransform>();
								_003C_003Ec__DisplayClass41_0 obj6 = _003C_003E8__1;
								if (_003C_003E8__1 != null && (object)obj6.bg != null)
								{
									Transform transform = obj6.bg.transform;
									Transform transform2 = _003C_003E4__this.transform;
									if ((object)transform2 != null)
									{
										Transform parent = transform2.parent;
										if ((object)transform != null)
										{
											transform.parent = parent;
											_003C_003Ec__DisplayClass41_0 obj7 = _003C_003E8__1;
											if (_003C_003E8__1 != null && (object)obj7.bg != null)
											{
												((UnityEngine.Object)obj7.bg).SetName("ANIMATED BACKGROUND");
												if ((object)component2 != null)
												{
													bool flag = ((UnityEngine.Object)component2).m_CachedPtr == (IntPtr)0;
													RectTransform.get_rect_Injected(((UnityEngine.Object)component2).m_CachedPtr, out Rect ret);
													_003C_003Ec__DisplayClass41_0 obj8 = _003C_003E8__1;
													if (_003C_003E8__1 != null && (object)obj8.bg != null)
													{
														RectTransform component3 = obj8.bg.GetComponent<RectTransform>();
														if ((object)component3 != null)
														{
															bool flag2 = ((UnityEngine.Object)component3).m_CachedPtr == (IntPtr)0;
															RectTransform.get_rect_Injected(((UnityEngine.Object)component3).m_CachedPtr, out ret);
															Vector2 vector = default(Vector2);
															component3.anchorMax = vector;
															component3.anchorMin = vector;
															component3.sizeDelta = vector;
															_003C_003Ec__DisplayClass41_0 obj9 = _003C_003E8__1;
															if (_003C_003E8__1 != null && (object)obj9.bg != null)
															{
																RectTransform component4 = obj9.bg.GetComponent<RectTransform>();
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182B07BB0");
																Vector2 endValue = default(Vector2);
																TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore = DOTweenModuleUI.DOAnchorPos(component4, endValue, 0.5f);
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049AF40");
																Transform transform3 = component3.transform;
																TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2 = ShortcutExtensions.DOScale(transform3, 1f, 0.5f);
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rbp_v1 (UnityEngine.Component)+120]");
																if ((nint)0 != 0)
																{
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rbp_v1 (UnityEngine.Component)+110]");
																	if ((nint)0 == 0)
																	{
																		goto IL_0621;
																	}
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rbp_v1 (UnityEngine.Component)+110]");
																	bool disableWhenFinished = default(bool);
																	Tween tween = ((PixelateEffect)0).Pixelate(1f, 5f, 0.5f, disableWhenFinished);
																}
																_003C_003Ec__DisplayClass41_0 obj10 = _003C_003E8__1;
																if (_003C_003E8__1 != null && (object)obj10.bg != null)
																{
																	RectTransform component5 = obj10.bg.GetComponent<RectTransform>();
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rbp_v1 (UnityEngine.Component)+140]");
																	RectTransform rectTransform = (RectTransform)0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rbp_v1 (UnityEngine.Component)+140]");
																	if ((nint)0 != 0)
																	{
																		bool flag3 = ((UnityEngine.Object)rectTransform).m_CachedPtr == (IntPtr)0;
																		RectTransform.get_rect_Injected(((UnityEngine.Object)rectTransform).m_CachedPtr, out ret);
																		TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore3 = DOTweenModuleUI.DOSizeDelta(component5, vector, 0.5f);
																		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049AF40");
																		TweenCallback tweenCallback = delegate
																		{
																			Transform transform4 = _003C_003E8__1.bg.transform;
																			_003CMoveBackgroundIntoPlaceInANiceFancyWay_003Ed__42 obj12 = null;
																			obj12._003C_003E1__state = 0;
																			obj12._003C_003E4__this = _003C_003E8__1._003C_003E4__this;
																			obj12.bg = transform4;
																			Coroutine coroutine = CoroutineRunner.Instance.StartCoroutine(obj12);
																		};
																		tweenCallback._002Ector(_003C_003E8__1, (nint)__ldftn(_003C_003Ec__DisplayClass41_0._003CAnimate_003Eb__0));
																		object obj11 = default(object);
																		if (obj11 != null)
																		{
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1417 @ rax_v61+E8]");
																			if ((nint)0 == 0)
																			{
																			}
																		}
																		goto IL_0613;
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
					}
				}
			}
			goto IL_0621;
			IL_0621:
			throw new NullReferenceException();
			IL_0613:
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

	private sealed class _003CMoveBackgroundIntoPlaceInANiceFancyWay_003Ed__42(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public Transform bg;

		public SelectAdventuresPage _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0303: Expected I4, but got I8
			//IL_0015: Expected O, but got I4
			//IL_03aa: Expected I4, but got O
			//IL_02bc: Expected I4, but got I8
			//IL_0052: Expected I4, but got I8
			//IL_00a7: Expected O, but got I
			//IL_00e6: Expected O, but got I
			//IL_0220: Expected O, but got I
			//IL_0181: Expected O, but got I
			//IL_01cc: Expected O, but got I
			object obj = _003C_003E4__this;
			bool flag = _003C_003E1__state == 0;
			if (!flag)
			{
				object obj2 = _003C_003E1__state - 1;
				if (flag)
				{
					_003C_003E1__state = -1;
					BackButtonController.FireBack();
					WaitForEndOfFrame waitForEndOfFrame = new WaitForEndOfFrame();
					_003C_003E2__current = waitForEndOfFrame;
					_003C_003E1__state = 2;
					return true;
				}
				if ((nint)obj2 != 1)
				{
					goto IL_02a7;
				}
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rdi_v1 (System.Object)+148]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rdi_v1 (System.Object)+148]");
						CanvasGroup component = ((Component)0).GetComponent<CanvasGroup>();
						if ((object)component != null)
						{
							component.alpha = 0f;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rdi_v1 (System.Object)+118]");
							object obj3 = 0;
							Transform transform = bg;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rdi_v1 (System.Object)+118]");
							if ((nint)0 != 0)
							{
								if ((object)bg == null || ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0)
								{
									Debug.LogWarning("Could not set a custom background due to it being NULL");
									goto IL_01ea;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v221 @ rsi_v6+20]");
								if ((nint)0 != 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v221 @ rsi_v6+20]");
									GameObject gameObject = ((Component)0).gameObject;
									if ((object)gameObject != null)
									{
										gameObject.SetActive(value: true);
										Transform transform2 = bg;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v221 @ rsi_v6+20]");
										transform2.SetParent((Transform)0, worldPositionStays: true);
										goto IL_01ea;
									}
								}
							}
						}
					}
				}
			}
			else
			{
				_003C_003E1__state = -1;
				Canvas canvas = UIHelper.Canvas;
				if ((object)canvas != null)
				{
					Transform transform3 = canvas.transform;
					if ((object)bg != null)
					{
						bg.SetParent(transform3, worldPositionStays: true);
						WaitForEndOfFrame waitForEndOfFrame2 = new WaitForEndOfFrame();
						_003C_003E2__current = waitForEndOfFrame2;
						_003C_003E1__state = 1;
						return true;
					}
				}
			}
			goto IL_039c;
			IL_01ea:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rdi_v1 (System.Object)+148]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rdi_v1 (System.Object)+148]");
				CanvasGroup component2 = ((Component)0).GetComponent<CanvasGroup>();
				TweenerCore<float, float, FloatOptions> tweenerCore = DOTweenModuleUI.DOFade(component2, 1f, 0.5f);
				TweenCallback tweenCallback = delegate
				{
					RewiredStandaloneInputModule inputModule = _003C_003E4__this.InputModule;
					inputModule.enabled = true;
				};
				if (tweenerCore != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v660 @ rax_v37 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
					if ((nint)0 == 0)
					{
					}
				}
				goto IL_02a7;
			}
			goto IL_039c;
			IL_039c:
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
			IL_02a7:
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

	private GameObject _AdventureItemPrefab;

	private RectTransform _AdventureItemContainer;

	private AdventureInfoPanel _InfoPanel;

	private Button _ConfirmButton;

	private GameObject _CoinsUI;

	private GameObject _AdventureStarsCurrencyUI;

	private PixelateEffect _pixelEffect;

	private MainMenuBackgroundManager _MainMenuBackgroundManager;

	private bool DoPixelEffect;

	private AscensionPanel _AscensionPanel;

	private Image _PortraitBreaker;

	private GameObject _PortraitAscensionGroup;

	private RectTransform _CustomBackgroundHolderOnMainMenu;

	private MainMenuPage _MainMenuPage;

	private AchievementPopup _AchievementPopup;

	private AdventureManager _adventureManager;

	private PlayerOptions _playerOptions;

	private DataManager _dataManager;

	private MainMenuBackgroundFactory _backgroundFactory;

	private AdventureProgressManager _adventureProgressManager;

	private AchievementManager _achievementManager;

	private LobbiesManager _lobbiesManager;

	private List<AdventureItemUI> _spawned;

	private AdventureItemUI _selected;

	private AdventureItemUI _ascending;

	private TutorialPopup _spawnedTutorialPopup;

	private RewiredStandaloneInputModule InputModule
	{
		get
		{
			//IL_007c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0081: Expected O, but got Unknown
			//IL_0098: Unknown result type (might be due to invalid IL or missing references)
			//IL_009d: Expected O, but got Unknown
			//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b9: Expected O, but got Unknown
			//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c7: Expected O, but got Unknown
			//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d9: Expected O, but got Unknown
			//IL_015f: Expected O, but got I4
			RewiredStandaloneInputModule inputModule = _inputModule;
			RewiredStandaloneInputModule rewiredStandaloneInputModule;
			if ((object)_inputModule == null || ((UnityEngine.Object)inputModule).m_CachedPtr == (IntPtr)0)
			{
				rewiredStandaloneInputModule = UnityEngine.Object.FindObjectOfType<RewiredStandaloneInputModule>();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
				bool flag = (nint)0 == 0;
				_inputModule = rewiredStandaloneInputModule;
				if (flag)
				{
					goto IL_012d;
				}
				object obj = this + 104;
				object obj2 = obj >> 12;
				object obj3 = obj2 & 0x1FFFFF;
				object obj4 = obj3 >> 6;
				object obj5 = obj3 & 0x3F;
				object obj6 = obj4 * 8;
				object obj7 = 6603864928L + obj6;
				do
				{
					object obj8 = 1 << (int)obj5;
					object obj9 = obj7 | obj8;
					if (obj7 == obj7)
					{
						obj7 = obj9;
					}
				}
				while (obj7 != obj7);
			}
			rewiredStandaloneInputModule = _inputModule;
			goto IL_012d;
			IL_012d:
			return rewiredStandaloneInputModule;
		}
	}

	public AdventureManager AdventureManager => _adventureManager;

	public DataManager DataManager => _dataManager;

	public PlayerOptions PlayerOptions => _playerOptions;

	private void Construct(AdventureManager adventureManager, PlayerOptions playerOptions, DataManager data, MainMenuBackgroundFactory backgroundFactory, AdventureProgressManager adventureProgressManager, AchievementManager achievementManager, LobbiesManager lobbiesManager)
	{
		_adventureManager = adventureManager;
		_playerOptions = playerOptions;
		_dataManager = data;
		MainMenuBackgroundFactory backgroundFactory2 = default(MainMenuBackgroundFactory);
		_backgroundFactory = backgroundFactory2;
		AdventureProgressManager adventureProgressManager2 = default(AdventureProgressManager);
		_adventureProgressManager = adventureProgressManager2;
		AchievementManager achievementManager2 = default(AchievementManager);
		_achievementManager = achievementManager2;
		LobbiesManager lobbiesManager2 = default(LobbiesManager);
		_lobbiesManager = lobbiesManager2;
	}

	protected override void Awake()
	{
		base.Awake();
	}

	public unsafe void SelectAdventure(AdventureItemUI item)
	{
		//IL_00bb: Expected I4, but got O
		//IL_0206: Expected O, but got Ref
		//IL_0306: Expected O, but got I4
		AdventureData data = item._data;
		CoreAdventureData coreAdventureData = data._003CCoreAdventureData_003Ek__BackingField;
		bool flag = (object)coreAdventureData._003CRequiresDLC_003Ek__BackingField == null;
		int num = 1;
		if (!flag)
		{
			Dictionary<DlcType, BundleManifestData> loadedDlc = DlcSystem.LoadedDlc;
			AdventureData data2 = item._data;
			CoreAdventureData coreAdventureData2 = data2._003CCoreAdventureData_003Ek__BackingField;
			if ((object)coreAdventureData2._003CRequiresDLC_003Ek__BackingField == null)
			{
				System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
				return;
			}
			System.Int32Enum key = (System.Int32Enum)((object?)coreAdventureData2._003CRequiresDLC_003Ek__BackingField >> 32);
			int num2 = ((Dictionary<System.Int32Enum, object>)(object)loadedDlc).FindEntry(key);
			int num3 = num2 >> 31;
			num = num3 ^ 1;
		}
		AdventureItemUI selected = _selected;
		if ((object)_selected != null && ((UnityEngine.Object)selected).m_CachedPtr != (IntPtr)0)
		{
			bool flag2;
			if ((object)_selected != null)
			{
				object obj = (object)item - (object)_selected;
				flag2 = obj == null;
			}
			else
			{
				flag2 = ((UnityEngine.Object)item).m_CachedPtr == (IntPtr)0;
			}
			if (!flag2)
			{
				AdventureItemUI selected2 = _selected;
				GameObject gameObject = selected2._Selection.gameObject;
				gameObject.SetActive(value: false);
			}
		}
		bool flag3;
		if ((object)_selected != null)
		{
			object obj2 = (object)_selected - (object)item;
			flag3 = obj2 == null;
		}
		else
		{
			flag3 = ((UnityEngine.Object)item).m_CachedPtr == (IntPtr)0;
		}
		if (!flag3)
		{
			object obj3 = default(object);
			_ConfirmButton.navigation = (Navigation)(&obj3);
			AdventureItemUI selected3 = _selected;
			if ((object)_selected != null && ((UnityEngine.Object)selected3).m_CachedPtr != (IntPtr)0)
			{
				Selectable component = _selected.GetComponent<Selectable>();
				SetNavigationUp(_ConfirmButton, component);
			}
			if (num == 0)
			{
				_InfoPanel.Hide();
			}
			else
			{
				_InfoPanel.SetData(item._type);
			}
			_selected = item;
			bool flag4 = _adventureManager.IsOwned(item._type);
			int num4 = num & (flag4 ? 1 : 0);
			bool flag5 = num4 == 0;
			object obj4 = !flag5;
			if (obj4 == null)
			{
				GameObject gameObject2 = _ConfirmButton.gameObject;
				gameObject2.SetActive(value: false);
			}
			else
			{
				GameObject gameObject3 = _ConfirmButton.gameObject;
				gameObject3.SetActive(value: true);
				_ConfirmButton.Select();
			}
			UpdateCompletionPanelInfo(item._type);
		}
		else
		{
			Debug.Log("We are selecting the same AdventureItemUI again, no need to process again...");
		}
	}

	public void SetAscendingAdventureItem(AdventureItemUI item)
	{
		_ascending = item;
	}

	private void OnAscended(bool result)
	{
		if (result)
		{
			Canvas.ForceUpdateCanvases();
			RectTransform component = GetComponent<RectTransform>();
			LayoutRebuilder.ForceRebuildLayoutImmediate(component);
			Canvas canvas = UIHelper.Canvas;
			canvas.renderMode = RenderMode.WorldSpace;
			ProCamera2DShake instance = ProCamera2DShake.Instance;
			instance.Shake(1);
			AdventureItemUI adventureItemUI = _ascending;
			_ascending.SetData(this, adventureItemUI._type, adventureItemUI._data);
			AdventureItemUI adventureItemUI2 = _ascending;
			UpdateCompletionPanelInfo(adventureItemUI2._type);
			AdventureItemUI adventureItemUI3 = _ascending;
			_InfoPanel.SetData(adventureItemUI3._type);
			GenerateNavigation();
			Selectable component2 = _ascending.GetComponent<Selectable>();
			component2.Select();
		}
	}

	public GameObject GetBackground(AdventureType adventureType)
	{
		if ((object)_backgroundFactory != null)
		{
			return _backgroundFactory.GetBackgroundForAdventureType(adventureType);
		}
		return (GameObject)(object)new NullReferenceException();
	}

	public void ConfirmAdventure()
	{
		RewiredStandaloneInputModule inputModule = InputModule;
		inputModule.enabled = false;
		Button component = _ConfirmButton.GetComponent<Button>();
		component.interactable = false;
		AdventureItemUI selected = _selected;
		_adventureManager.InitAdventure(selected._type);
		RoomSelectionPage roomSelectionPage = RoomSelectionPage._003CInstance_003Ek__BackingField;
		LobbiesManager lobbiesManager = roomSelectionPage._lobbiesManager;
		if (lobbiesManager._activeLobby != null)
		{
			LobbySession activeLobby = lobbiesManager._activeLobby;
			if (!activeLobby._003CIsDisposed_003Ek__BackingField)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18695F8E0");
				RoomSelectionPage roomSelectionPage2 = default(RoomSelectionPage);
				roomSelectionPage2.StartGame();
				goto IL_0102;
			}
		}
		_003CAnimate_003Ed__41 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		Coroutine coroutine = StartCoroutine(obj);
		goto IL_0102;
		IL_0102:
		Button component2 = _ConfirmButton.GetComponent<Button>();
		component2.interactable = false;
		CanvasGroup component3 = GetComponent<CanvasGroup>();
		component3.interactable = false;
	}

	private IEnumerator Animate()
	{
		_003CAnimate_003Ed__41 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	private IEnumerator MoveBackgroundIntoPlaceInANiceFancyWay(Transform bg)
	{
		_003CMoveBackgroundIntoPlaceInANiceFancyWay_003Ed__42 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		obj.bg = bg;
		return obj;
	}

	protected override void OnShowStart(GameObject g)
	{
		//IL_00fd: Expected I4, but got O
		//IL_02bd: Expected O, but got I4
		base.OnShowStart(g);
		List<AchievementData> list;
		if ((object)_CoinsUI != null)
		{
			_CoinsUI.SetActive(value: false);
			if ((object)_AdventureStarsCurrencyUI != null)
			{
				_AdventureStarsCurrencyUI.SetActive(value: false);
				if ((object)_ConfirmButton != null)
				{
					Button component = _ConfirmButton.GetComponent<Button>();
					if ((object)component != null)
					{
						component.interactable = true;
						Action cb = ShowTutorialPopup;
						HelpButton.AddCallback(cb);
						AdventureManager adventureManager = _adventureManager;
						if (_adventureManager != null)
						{
							Action<bool> action = null;
							((SelectAdventuresPage)(object)action).OnAscended((byte)(int)this != 0);
							Delegate obj = Delegate.Combine(adventureManager._003COnAdventureAscended_003Ek__BackingField, action);
							Action<bool> action2 = default(Action<bool>);
							if ((object)obj == null)
							{
								action2 = null;
							}
							else
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
								if (action2 == null)
								{
									throw new InvalidCastException();
								}
							}
							adventureManager._003COnAdventureAscended_003Ek__BackingField = action2;
							Populate();
							PlayerOptions playerOptions = _playerOptions;
							if (_playerOptions != null)
							{
								PlayerOptionsData mainGameConfig = playerOptions._mainGameConfig;
								if (playerOptions._mainGameConfig != null)
								{
									if (!mainGameConfig._003CHasSeenAdventuresIntroTutorial_003Ek__BackingField)
									{
										TutorialPopup spawnedTutorialPopup = PopupManager.CreateTutorialPopup("Adventures-Intro-Tutorial", "adventureLang/adv_adventurePopup_title", "adventureLang/adv_adventurePopup", "lang/postGame_done");
										_spawnedTutorialPopup = spawnedTutorialPopup;
										TutorialPopup.OnOkButtonClicked value = OnTutorialFinished;
										if ((object)_spawnedTutorialPopup == null)
										{
											goto IL_08ca;
										}
										_spawnedTutorialPopup.OKButtonClicked += value;
									}
									list = new List<AchievementData>();
									DataManager dataManager = _dataManager;
									if (_dataManager != null && dataManager._003CAllAdventures_003Ek__BackingField != null)
									{
										List<SkinToUnlock>.Enumerator enumerator = (List<SkinToUnlock>.Enumerator)0;
										Dictionary<AdventureType, AdventureData>.Enumerator enumerator2 = default(Dictionary<AdventureType, AdventureData>.Enumerator);
										while (enumerator2.MoveNext())
										{
											bool flag = _adventureManager == null;
											List<SkinToUnlock>.Enumerator adventureManager2 = (List<SkinToUnlock>.Enumerator)_adventureManager;
											if (!flag)
											{
												bool flag2 = _adventureManager.IsAdventureCompleted(AdventureType.ADV_LMS_001);
												adventureManager2 = (List<SkinToUnlock>.Enumerator)_adventureManager;
												if (!flag2)
												{
													if (_adventureManager == null)
													{
														throw new NullReferenceException();
													}
													bool flag3 = _adventureManager.WasAdventureAlreadyCompleted(AdventureType.ADV_LMS_001);
													bool flag4 = !flag3;
													adventureManager2 = (List<SkinToUnlock>.Enumerator)_adventureManager;
													if (flag4)
													{
														continue;
													}
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm6,8\"");
												AdventureType adventureType = AdventureType.ADV_LMS_001;
												throw new NullReferenceException();
											}
											throw new NullReferenceException();
										}
										if (list != null)
										{
											if (list._size <= 0)
											{
												goto IL_0a61;
											}
											if (_achievementManager != null)
											{
												_achievementManager.UnlockAchievementsAndGiveRewards();
												if (_playerOptions != null)
												{
													_playerOptions.Save();
													goto IL_0a61;
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
		goto IL_08ca;
		IL_08ca:
		throw new NullReferenceException();
		IL_0a61:
		if (list._size <= 0)
		{
			if ((object)_AchievementPopup != null)
			{
				GameObject gameObject = _AchievementPopup.gameObject;
				if ((object)gameObject != null)
				{
					gameObject.SetActive(value: false);
					return;
				}
			}
		}
		else if ((object)_AchievementPopup != null)
		{
			GameObject gameObject2 = _AchievementPopup.gameObject;
			if ((object)gameObject2 != null)
			{
				gameObject2.SetActive(value: true);
				if ((object)_AchievementPopup != null)
				{
					_AchievementPopup.SetAchievements(list, cancelAfterOneCycle: true);
					return;
				}
			}
		}
		goto IL_08ca;
	}

	private void QueueAchievements(List<AchievementData> achievementsUnlocked)
	{
		if (achievementsUnlocked != null)
		{
			if (achievementsUnlocked._size <= 0)
			{
				GameObject gameObject = _AchievementPopup.gameObject;
				gameObject.SetActive(value: false);
			}
			else
			{
				GameObject gameObject2 = _AchievementPopup.gameObject;
				gameObject2.SetActive(value: true);
				_AchievementPopup.SetAchievements(achievementsUnlocked, cancelAfterOneCycle: true);
			}
		}
	}

	private void ShowTutorialPopup()
	{
		TutorialPopup spawnedTutorialPopup = PopupManager.CreateTutorialPopup("Adventures-Intro-Tutorial", "adventureLang/adv_adventurePopup_title", "adventureLang/adv_adventurePopup", "lang/postGame_done");
		_spawnedTutorialPopup = spawnedTutorialPopup;
		TutorialPopup.OnOkButtonClicked value = OnTutorialFinished;
		_spawnedTutorialPopup.OKButtonClicked += value;
	}

	private void OnTutorialFinished()
	{
		PlayerOptionsData config = _playerOptions.Config;
		config._003CHasSeenAdventuresIntroTutorial_003Ek__BackingField = true;
		_playerOptions.Save();
		TutorialPopup.OnOkButtonClicked value = OnTutorialFinished;
		_spawnedTutorialPopup.OKButtonClicked -= value;
	}

	protected override void OnHideStart(GameObject g)
	{
		//IL_0087: Expected I4, but got O
		base.OnHideStart(g);
		_CoinsUI.SetActive(value: true);
		_AdventureStarsCurrencyUI.SetActive(value: false);
		_AscensionPanel.Apply();
		_AchievementPopup.CancelLoop();
		HelpButton.Clear();
		_playerOptions.Save();
		AdventureManager adventureManager = _adventureManager;
		Action<bool> action = null;
		((SelectAdventuresPage)(object)action).OnAscended((byte)(int)this != 0);
		Delegate obj = Delegate.Remove(adventureManager._003COnAdventureAscended_003Ek__BackingField, action);
		if ((object)obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			if ((object)obj == null)
			{
				throw new InvalidCastException();
			}
		}
		adventureManager._003COnAdventureAscended_003Ek__BackingField = (Action<bool>)obj;
	}

	private unsafe void Populate()
	{
		//IL_00cb: Expected O, but got Ref
		//IL_00d4: Expected O, but got I4
		//IL_07cf: Expected I, but got O
		//IL_07e5: Expected O, but got I
		//IL_0801: Expected I, but got O
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Expected O, but got Unknown
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Expected O, but got Unknown
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Expected O, but got Unknown
		//IL_09a7: Expected O, but got I4
		//IL_09b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_09bc: Expected O, but got Unknown
		//IL_00ac: Expected I, but got O
		//IL_0921: Expected O, but got I
		//IL_093b: Expected O, but got I
		//IL_095a: Expected O, but got Ref
		//IL_0179: Expected O, but got I
		//IL_01f8: Expected O, but got Ref
		//IL_0590: Expected O, but got I
		//IL_0599: Unknown result type (might be due to invalid IL or missing references)
		//IL_059e: Expected O, but got Unknown
		//IL_05a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ab: Expected O, but got Unknown
		//IL_018f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0194: Expected O, but got Unknown
		//IL_022d: Expected O, but got Ref
		//IL_028c: Expected I, but got O
		//IL_0295: Expected O, but got I4
		//IL_00e7: Expected O, but got I4
		//IL_046e: Expected I4, but got O
		//IL_048b: Expected I, but got O
		//IL_051f: Expected O, but got I
		//IL_051f: Expected I4, but got O
		//IL_0431: Expected I, but got O
		PlayerOptionsData config = _playerOptions.Config;
		config._003CHideUnavailableAdventures_003Ek__BackingField = true;
		DataManager dataManager = _dataManager;
		Func<KeyValuePair<AdventureType, AdventureData>, int> keySelector = _003C_003Ec._003C_003E9__48_0;
		if (_003C_003Ec._003C_003E9__48_0 == null)
		{
			Func<KeyValuePair<AdventureType, AdventureData>, int> func = (_003C_003Ec._003C_003E9__48_0 = delegate
			{
				//IL_0030: Expected O, but got I
				//IL_0020: Expected I4, but got O
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [kvp @ rdx (System.Collections.Generic.KeyValuePair`2<VampireSurvivors.Data.AdventureType, VampireSurvivors.App.Data.Adventures.AdventureData>)+8]");
				object obj29 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [kvp @ rdx (System.Collections.Generic.KeyValuePair`2<VampireSurvivors.Data.AdventureType, VampireSurvivors.App.Data.Adventures.AdventureData>)+8]");
				if ((nint)0 == 0)
				{
					NullReferenceException ex = new NullReferenceException();
					return (int)ex;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ rax_v2+10]");
				return 0;
			});
			nint num = (nint)typeof(_003C_003Ec);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v494 @ rax_v116 (Il2CppClass<VampireSurvivors.App.Scripts.UI.SelectAdventuresPage+<>c>)+B8]");
			object obj = (nint)0 + (nint)8;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
			bool flag = (nint)0 == 0;
			nint num2 = unchecked((nint)null);
			keySelector = func;
			if (!flag)
			{
				object obj2 = obj >> 12;
				object obj3 = obj2 & 0x1FFFFF;
				object obj4 = obj3 >> 6;
				object obj5 = obj4 * 8;
				object obj6 = obj5 + 6603577472L;
				object obj7 = obj3 & 0x3F;
				nint num4;
				do
				{
					object obj8 = 1 << (int)obj7;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v576 @ rdx_v55+462E0]");
					object obj9 = 0 | obj8;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v576 @ rdx_v55+462E0]");
					nint num3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v576 @ rdx_v55+462E0]");
					if (num3 == 0)
					{
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v576 @ rdx_v55+462E0]");
					num4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v576 @ rdx_v55+462E0]");
				}
				while (num4 != 0);
				num2 = unchecked((nint)null);
				keySelector = func;
			}
		}
		IOrderedEnumerable<KeyValuePair<AdventureType, AdventureData>> orderedEnumerable = Enumerable.OrderBy(dataManager._003CAllAdventures_003Ek__BackingField, keySelector);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		ItemType itemType = default(ItemType);
		object obj10 = (object)(&itemType);
		object obj11 = 0;
		PlayerOptionsData playerOptionsData = null;
		object obj12 = default(object);
		object obj22 = default(object);
		object obj24 = default(object);
		object obj25 = default(object);
		object obj27 = default(object);
		object obj28 = default(object);
		while (true)
		{
			object obj21;
			if (itemType != ItemType.VOID)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				if (obj12 != null)
				{
					bool flag2 = itemType == ItemType.VOID;
					playerOptionsData = null;
					if (!flag2)
					{
						int value__ = ((ItemType*)(int)itemType)->value__;
						object obj13 = obj11;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v256 @ r10_v20 (System.Int32)+12E]");
						if ((nint)obj13 >= 0)
						{
							goto IL_01b8;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v256 @ r10_v20 (System.Int32)+B0]");
						object obj14 = 0;
						object obj15 = obj11;
						while (true)
						{
							object obj16 = obj15 + obj15;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1237 @ r8_v45+v1240 @ rax_v109*8]");
							if (0 == (nint)typeof(IEnumerator<KeyValuePair<AdventureType, AdventureData>>))
							{
								break;
							}
							obj15++;
							object obj17 = obj15;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v256 @ r10_v20 (System.Int32)+12E]");
							if ((nint)obj17 < 0)
							{
								continue;
							}
							goto IL_01b8;
						}
						object obj18 = obj15 + obj15;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1237 @ r8_v45+8+v1384 @ rcx_v71*8]");
						object obj19 = (nint)0 << 4;
						object obj20 = obj19 + 312;
						obj21 = obj20 + value__;
						goto IL_0911;
					}
					throw new NullReferenceException();
				}
				if (obj10 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
				}
				break;
			}
			throw new NullReferenceException();
			IL_01b8:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
			obj21 = obj22;
			goto IL_0911;
			IL_0911:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1389 @ r8_v33+8]");
			object obj23 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1389 @ r8_v33] (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1137 @ rax_v69+8]");
			AdventureData adventureData = (AdventureData)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1137 @ rax_v69+8]");
			bool flag3 = (nint)0 == 0;
			playerOptionsData = (PlayerOptionsData)(&obj24);
			if (!flag3)
			{
				CoreAdventureData coreAdventureData = adventureData._003CCoreAdventureData_003Ek__BackingField;
				bool flag4 = adventureData._003CCoreAdventureData_003Ek__BackingField == null;
				playerOptionsData = (PlayerOptionsData)(&obj24);
				if (!flag4)
				{
					bool flag5 = (object)coreAdventureData._003CRequiresDLC_003Ek__BackingField != null;
					ItemType itemType2 = itemType;
					PlayerOptionsData playerOptionsData2 = (PlayerOptionsData)(&obj24);
					if (!flag5)
					{
						PlayerOptions playerOptions = _playerOptions;
						playerOptionsData = playerOptions._mainGameConfig;
						bool flag6 = playerOptions._mainGameConfig.HasCollectedItem(ItemType.RELIC_ATLAS);
						bool flag7 = !flag6;
						nint num2 = (nint)typeof(IEnumerator<KeyValuePair<AdventureType, AdventureData>>);
						obj23 = 0;
						itemType2 = ItemType.RELIC_ATLAS;
						playerOptionsData2 = playerOptions._mainGameConfig;
						if (flag7)
						{
							goto IL_00de;
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18699C080");
					if (obj25 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1493 @ rax_v72+10]");
						if ((nint)0 != 0)
						{
							goto IL_037f;
						}
					}
					LobbiesManager lobbiesManager = _lobbiesManager;
					if (_lobbiesManager != null)
					{
						if (lobbiesManager._activeLobby != null)
						{
							LobbySession activeLobby = lobbiesManager._activeLobby;
							if (!activeLobby._003CIsDisposed_003Ek__BackingField)
							{
								goto IL_037f;
							}
						}
						goto IL_043f;
					}
					throw new NullReferenceException();
				}
				throw new NullReferenceException();
			}
			throw new NullReferenceException();
			IL_037f:
			CoreAdventureData coreAdventureData2 = adventureData._003CCoreAdventureData_003Ek__BackingField;
			if (adventureData._003CCoreAdventureData_003Ek__BackingField != null)
			{
				if ((object)coreAdventureData2._003CRequiresDLC_003Ek__BackingField != null)
				{
					playerOptionsData = (PlayerOptionsData)(object)DlcSystem.OnlineAvaliableDlcTypes;
					CoreAdventureData coreAdventureData3 = adventureData._003CCoreAdventureData_003Ek__BackingField;
					if (adventureData._003CCoreAdventureData_003Ek__BackingField != null)
					{
						if ((object)coreAdventureData3._003CRequiresDLC_003Ek__BackingField != null)
						{
							object obj26 = (object?)coreAdventureData3._003CRequiresDLC_003Ek__BackingField >> 32;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A99BA0");
							bool flag8 = obj27 == null;
							nint num2 = (nint)typeof(IEnumerator<KeyValuePair<AdventureType, AdventureData>>);
							if (flag8)
							{
								goto IL_00de;
							}
							goto IL_043f;
						}
						System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
					}
					throw new NullReferenceException();
				}
				goto IL_043f;
			}
			throw new NullReferenceException();
			IL_00de:
			obj11 = 0;
			continue;
			IL_043f:
			if (_adventureManager != null)
			{
				bool flag9 = _adventureManager.IsOwned((AdventureType)obj28);
				bool flag10 = !flag9;
				nint num2 = (nint)typeof(IEnumerator<KeyValuePair<AdventureType, AdventureData>>);
				playerOptionsData = (PlayerOptionsData)(object)_adventureManager;
				if (!flag10)
				{
					GameObject gameObject = UnityEngine.Object.Instantiate(_AdventureItemPrefab, _AdventureItemContainer);
					if ((object)gameObject == null)
					{
						throw new NullReferenceException();
					}
					AdventureItemUI component = gameObject.GetComponent<AdventureItemUI>();
					if ((object)component == null)
					{
						throw new NullReferenceException();
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1137 @ rax_v69+8]");
					component.SetData(this, (AdventureType)obj28, (AdventureData)0);
					if (_spawned == null)
					{
						throw new NullReferenceException();
					}
					((List<object>)(object)_spawned).Add((object)component);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1137 @ rax_v69+8]");
					num2 = 0;
					playerOptionsData = (PlayerOptionsData)(object)_spawned;
				}
				goto IL_00de;
			}
			throw new NullReferenceException();
		}
		if (_spawned != null)
		{
			List<AdventureItemUI> spawned = _spawned;
			if (spawned._size > 0)
			{
				if (spawned._size > 0)
				{
					AdventureItemUI[] items = spawned._items;
					Selectable component2 = items[0].GetComponent<Selectable>();
					component2.Select();
					List<AdventureItemUI> spawned2 = _spawned;
					if (spawned2._size > 0)
					{
						AdventureItemUI[] items2 = spawned2._items;
						AdventureItemUI component3 = items2[0].GetComponent<AdventureItemUI>();
						_selected = component3;
						goto IL_06d8;
					}
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				return;
			}
		}
		goto IL_06d8;
		IL_06d8:
		UpdateAdventureStatesBasedOnHideToggle();
		GenerateNavigation();
	}

	protected override void Update()
	{
		base.Update();
		RoomSelectionPage roomSelectionPage = RoomSelectionPage._003CInstance_003Ek__BackingField;
		LobbiesManager lobbiesManager = roomSelectionPage._lobbiesManager;
		if (lobbiesManager._activeLobby == null)
		{
			return;
		}
		LobbySession activeLobby = lobbiesManager._activeLobby;
		if (!activeLobby._003CIsDisposed_003Ek__BackingField)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18695F8E0");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v106 @ rax_v14+188]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
			}
		}
	}

	private unsafe void GenerateNavigation()
	{
		//IL_0008: Expected O, but got Ref
		//IL_011c: Expected O, but got Ref
		//IL_01ac: Expected O, but got I4
		//IL_01f3: Expected O, but got I4
		//IL_027e: Expected O, but got I
		//IL_030d: Expected O, but got I4
		//IL_0240: Expected O, but got I4
		//IL_0375: Expected O, but got Ref
		//IL_06ea: Expected O, but got Ref
		//IL_0750: Expected O, but got I4
		//IL_0799: Expected O, but got I4
		//IL_0460: Expected O, but got I4
		//IL_04bb: Expected O, but got I4
		//IL_0500: Expected O, but got I4
		object obj2 = default(object);
		object obj = (object)(&obj2);
		AdventureItemUI selected = _selected;
		_ = 0;
		if ((object)_selected != null && ((UnityEngine.Object)selected).m_CachedPtr != (IntPtr)0)
		{
			PlayerOptions playerOptions = _playerOptions;
			PlayerOptionsData mainGameConfig = playerOptions._mainGameConfig;
			AdventureItemUI selected2 = _selected;
			bool flag = ((Dictionary<System.Int32Enum, object>)(object)mainGameConfig._003CAdventuresSaveData_003Ek__BackingField).TryGetValue((System.Int32Enum)selected2._type, out System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 103));
			List<AdventureItemUI> spawned = _spawned;
			AdventureType adventureType = AdventureType.ADV_LMS_001;
			AdventureType adventureType2 = AdventureType.ADV_LMS_001;
			Component instance = default(Component);
			Selectable right = default(Selectable);
			while (true)
			{
				List<AdventureItemUI> spawned2 = _spawned;
				if ((int)adventureType2 < spawned._size)
				{
					if ((int)adventureType >= spawned2._size)
					{
						break;
					}
					AdventureItemUI[] items = spawned2._items;
					Selectable component = items[(int)adventureType].GetComponent<Selectable>();
					Navigation navigation = (Navigation)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
					_ = component.m_Navigation;
					_ = 4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v340 @ rax_v68 (UnityEngine.UI.Selectable)+38]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+17]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v340 @ rax_v68 (UnityEngine.UI.Selectable)+48]");
					_ = 0;
					component.navigation = navigation;
					Component component2;
					if (adventureType > AdventureType.ADV_LMS_001)
					{
						AdventureType key = adventureType - 1;
						bool flag2 = ((Dictionary<AdventureType, PlayerOptionsData>)(object)_spawned).TryGetValue(key, out *(PlayerOptionsData*)null);
						component2 = (Component)flag2;
					}
					else
					{
						component2 = BackButtonController.Instance;
					}
					Selectable component3 = component2.GetComponent<Selectable>();
					SetNavigationUp(component, component3);
					List<AdventureItemUI> spawned3 = _spawned;
					object obj3 = spawned3._size - 1;
					bool flag3 = (nint)adventureType >= (nint)obj3;
					Selectable selectable = component3;
					if (!flag3)
					{
						AdventureType key2 = adventureType + 1;
						Component component4 = (Component)((Dictionary<AdventureType, PlayerOptionsData>)(object)_spawned).TryGetValue(key2, out *(PlayerOptionsData*)component3);
						Selectable component5 = component4.GetComponent<Selectable>();
						SetNavigationDown(component, component5);
						selectable = component5;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+67]");
					object obj4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+67]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v345 @ rax_v77+2D4]");
						if ((nint)0 > (nint)0)
						{
							Selectable firstSelectable = _AscensionPanel.GetFirstSelectable();
							SetNavigationLeft(component, firstSelectable);
							selectable = firstSelectable;
						}
					}
					Component component6 = (Component)((Dictionary<AdventureType, PlayerOptionsData>)(object)_spawned).TryGetValue(adventureType, out *(PlayerOptionsData*)selectable);
					AdventureItemUI component7 = component6.GetComponent<AdventureItemUI>();
					if ((object)component7 != null && ((UnityEngine.Object)component7).m_CachedPtr != (IntPtr)0)
					{
						Selectable ascendAdventureButton = component7._AscendAdventureButton;
						Navigation navigation2 = (Navigation)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
						_ = ascendAdventureButton.m_Navigation;
						_ = 4;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v380 @ rcx_v70 (UnityEngine.UI.Selectable)+38]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+17]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v380 @ rcx_v70 (UnityEngine.UI.Selectable)+48]");
						_ = 0;
						ascendAdventureButton.navigation = navigation2;
						if (!_adventureManager.CanAscend(component7._type))
						{
							ClearNavigationRight(component);
							ClearNavigationLeft(component7._AscendAdventureButton);
						}
						else
						{
							SetNavigationRight(component, component7._AscendAdventureButton);
							SetNavigationLeft(component7._AscendAdventureButton, component);
							if (adventureType > AdventureType.ADV_LMS_001)
							{
								object obj5 = adventureType - 1;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
							}
							else
							{
								instance = BackButtonController.Instance;
							}
							Selectable component8 = instance.GetComponent<Selectable>();
							SetNavigationUp(component7._AscendAdventureButton, component8);
							List<AdventureItemUI> spawned4 = _spawned;
							object obj6 = spawned4._size - 1;
							if ((nint)adventureType < (nint)obj6)
							{
								AdventureType key3 = adventureType + 1;
								Component component9 = (Component)((Dictionary<AdventureType, PlayerOptionsData>)(object)_spawned).TryGetValue(key3, out *(PlayerOptionsData*)component8);
								Selectable component10 = component9.GetComponent<Selectable>();
								SetNavigationDown(component7._AscendAdventureButton, component10);
							}
						}
					}
					spawned = _spawned;
					adventureType++;
					adventureType2 = adventureType;
					continue;
				}
				if (spawned2._size <= 0)
				{
					break;
				}
				AdventureItemUI[] items2 = spawned2._items;
				Selectable component11 = items2[0].GetComponent<Selectable>();
				Selectable component12 = HelpButton.Instance.GetComponent<Selectable>();
				ForceBackButtonNavigation(null, component11, component12, right);
				Selectable component13 = BackButtonController.Instance.GetComponent<Selectable>();
				object obj7 = Enumerable.Last((IEnumerable<object>)_spawned);
				Selectable component14 = ((Component)obj7).GetComponent<Selectable>();
				AdventureItemUI adventureItemUI = Enumerable.First(_spawned);
				Selectable component15 = adventureItemUI.GetComponent<Selectable>();
				HelpButton.SetNavigation(null, component13, component14, component15);
				Button confirmButton = _ConfirmButton;
				if ((object)_ConfirmButton != null && ((UnityEngine.Object)confirmButton).m_CachedPtr != (IntPtr)0)
				{
					if (_spawned == null)
					{
						goto IL_0893;
					}
					List<AdventureItemUI> spawned5 = _spawned;
					if (spawned5._size > 0)
					{
						Selectable component16 = _ConfirmButton.GetComponent<Selectable>();
						Navigation navigation3 = (Navigation)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
						_ = component16.m_Navigation;
						_ = 4;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v358 @ rax_v53 (UnityEngine.UI.Selectable)+38]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+17]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v358 @ rax_v53 (UnityEngine.UI.Selectable)+48]");
						_ = 0;
						component16.navigation = navigation3;
						List<AdventureItemUI> spawned6 = _spawned;
						object obj8 = spawned6._size - 1;
						if ((nint)obj8 >= spawned6._size)
						{
							break;
						}
						AdventureItemUI[] items3 = spawned6._items;
						object obj9 = spawned6._size - 1;
						Selectable component17 = items3[obj9].GetComponent<Selectable>();
						SetNavigationUp(component16, component17);
						SetNavigationLeft(component16, component17);
					}
				}
				if (_spawned != null)
				{
					List<AdventureItemUI> spawned7 = _spawned;
					if (spawned7._size > 0)
					{
						if (spawned7._size <= 0)
						{
							break;
						}
						AdventureItemUI[] items4 = spawned7._items;
						SelectableUI component18 = items4[0].GetComponent<SelectableUI>();
						component18.IsDefaultSelectedOnPage = true;
						return;
					}
				}
				goto IL_0893;
				IL_0893:
				Selectable component19 = BackButtonController.Instance.GetComponent<Selectable>();
				component19.Select();
				return;
			}
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
		else
		{
			Debug.LogWarning("Cannot generate navigation with no Adventures listed");
		}
	}

	protected unsafe override void OnHideFinish(GameObject g)
	{
		//IL_0044: Expected O, but got Ref
		base.OnHideFinish(g);
		List<string> customOperationHandleKeys = AddressableCache.GetCustomOperationHandleKeys("AdventureBackgrounds");
		if (AdventureManager._003CIsInAdventureMode_003Ek__BackingField)
		{
			IntPtr intPtr = default(IntPtr);
			string item = ((Enum)(&intPtr)).ToString();
			bool flag = ((List<object>)(object)customOperationHandleKeys).Remove((object)item);
		}
		AddressableCache.ReleaseCustomOperationHandles("AdventureBackgrounds", customOperationHandleKeys);
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 172 Invalid \"Jump target not found in method: 0x186C3BF60\"");
		throw new NullReferenceException();
	}

	private void ClearItems()
	{
		//IL_0039->IL0125: Incompatible stack heights: 1 vs 0
		if (_spawned != null)
		{
			List<AdventureItemUI>.Enumerator enumerator = default(List<AdventureItemUI>.Enumerator);
			while (enumerator.MoveNext())
			{
				object obj = null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ rbx_v7 (System.Object)+10]");
				bool flag = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ rbx_v7 (System.Object)+10]");
				IntPtr gcHandlePtr = Component.get_gameObject_Injected((IntPtr)0);
				GameObject obj2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr);
				UnityEngine.Object.Destroy(obj2, 0f);
			}
			List<AdventureItemUI> spawned = _spawned;
			if (_spawned != null)
			{
				int version = spawned._version + 1;
				spawned._version = version;
				spawned._size = 0;
				if (spawned._size > 0)
				{
					Array.Clear(spawned._items, 0, spawned._size);
				}
				return;
			}
		}
		throw new NullReferenceException();
	}

	protected override void OnEnterPressed()
	{
		//IL_0196: Expected I4, but got O
		EventSystem current = EventSystem.current;
		GameObject currentSelected = current.m_CurrentSelected;
		if ((object)current.m_CurrentSelected == null || ((UnityEngine.Object)currentSelected).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		EventSystem current2 = EventSystem.current;
		AdventureItemUI component = current2.m_CurrentSelected.GetComponent<AdventureItemUI>();
		if ((object)component == null || ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		EventSystem current3 = EventSystem.current;
		AdventureItemUI component2 = current3.m_CurrentSelected.GetComponent<AdventureItemUI>();
		AdventureData data = component2._data;
		CoreAdventureData coreAdventureData = data._003CCoreAdventureData_003Ek__BackingField;
		if ((object)coreAdventureData._003CRequiresDLC_003Ek__BackingField != null)
		{
			Dictionary<DlcType, BundleManifestData> loadedDlc = DlcSystem.LoadedDlc;
			AdventureData data2 = component2._data;
			CoreAdventureData coreAdventureData2 = data2._003CCoreAdventureData_003Ek__BackingField;
			if ((object)coreAdventureData2._003CRequiresDLC_003Ek__BackingField == null)
			{
				System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
				return;
			}
			System.Int32Enum key = (System.Int32Enum)((object?)coreAdventureData2._003CRequiresDLC_003Ek__BackingField >> 32);
			int num = ((Dictionary<System.Int32Enum, object>)(object)loadedDlc).FindEntry(key);
			if (num < 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 499 Invalid \"Jump target not found in method: 0x186C3C580\"");
				throw new NullReferenceException();
			}
		}
		_ConfirmButton.Select();
	}

	public void HandleDLCPerPlatform()
	{
		Application.OpenURL("https://store.steampowered.com/dlc/1794680/Vampire_Survivors/");
	}

	private unsafe void UpdateCompletionPanelInfo(AdventureType adventureType)
	{
		//IL_02cd: Expected I4, but got O
		//IL_02f2: Expected O, but got Ref
		//IL_007b: Expected O, but got I
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Expected O, but got Unknown
		//IL_0181: Expected O, but got I
		//IL_0191: Unknown result type (might be due to invalid IL or missing references)
		//IL_0196: Expected O, but got Unknown
		//IL_023e: Expected O, but got I
		//IL_024e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0253: Expected O, but got Unknown
		PlayerOptions playerOptions = _playerOptions;
		PlayerOptionsData mainGameConfig = playerOptions._mainGameConfig;
		if (((Dictionary<System.Int32Enum, object>)(object)mainGameConfig._003CAdventuresSaveData_003Ek__BackingField).TryGetValue((System.Int32Enum)adventureType, out object value))
		{
			GameObject gameObject = _AscensionPanel.gameObject;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ stack_20_v3 (System.Object)+2D4]");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ stack_20_v3 (System.Object)+2D4]");
			object obj = num ^ 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ stack_20_v3 (System.Object)+2D4]");
			object obj2 = 0 & obj;
			bool flag = (nint)obj2 < 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ stack_20_v3 (System.Object)+2D4]");
			bool flag2 = (nint)0 < (nint)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ stack_20_v3 (System.Object)+2D4]");
			bool flag3 = (nint)0 == 0;
			bool flag4 = flag2 == flag;
			bool flag5 = !flag3;
			bool active = flag5 & flag4;
			gameObject.SetActive(active);
			AscensionPanel ascensionPanel = _AscensionPanel;
			ascensionPanel._adventurePod = (PlayerOptionsData)value;
			ascensionPanel._adventureType = adventureType;
			ascensionPanel.RefreshData();
			Selectable component = _selected.GetComponent<Selectable>();
			_AscensionPanel.SetSelected(component);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ stack_20_v3 (System.Object)+2D4]");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ stack_20_v3 (System.Object)+2D4]");
			object obj3 = num2 ^ 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ stack_20_v3 (System.Object)+2D4]");
			object obj4 = 0 & obj3;
			bool flag6 = (nint)obj4 < 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ stack_20_v3 (System.Object)+2D4]");
			bool flag7 = (nint)0 < (nint)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ stack_20_v3 (System.Object)+2D4]");
			bool flag8 = (nint)0 == 0;
			bool flag9 = flag7 == flag6;
			bool flag10 = !flag8;
			bool active2 = flag10 & flag9;
			_PortraitAscensionGroup.SetActive(active2);
			GameObject gameObject2 = _PortraitBreaker.gameObject;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ stack_20_v3 (System.Object)+2D4]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ stack_20_v3 (System.Object)+2D4]");
			object obj5 = num3 ^ 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ stack_20_v3 (System.Object)+2D4]");
			object obj6 = 0 & obj5;
			bool flag11 = (nint)obj6 < 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ stack_20_v3 (System.Object)+2D4]");
			bool flag12 = (nint)0 < (nint)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ stack_20_v3 (System.Object)+2D4]");
			bool flag13 = (nint)0 == 0;
			bool flag14 = flag12 == flag11;
			bool flag15 = !flag13;
			bool active3 = flag15 & flag14;
			gameObject2.SetActive(active3);
		}
		else
		{
			object obj7 = default(object);
			object arg = (AdventureType)obj7;
			System.ParamsArray paramsArray = new System.ParamsArray(arg);
			object obj8 = default(object);
			string message = string.FormatHelper((IFormatProvider)null, "Progress data for {0} could not be found in the main game config", (System.ParamsArray)(&obj8));
			Debug.LogWarning(message);
			GameObject gameObject3 = _PortraitBreaker.gameObject;
			gameObject3.SetActive(value: false);
			_PortraitAscensionGroup.SetActive(value: false);
			GameObject gameObject4 = _AscensionPanel.gameObject;
			gameObject4.SetActive(value: false);
		}
	}

	private unsafe void UpdateAdventureStatesBasedOnHideToggle()
	{
		//IL_0012: Expected O, but got Ref
		List<AdventureItemUI>.Enumerator enumerator = default(List<AdventureItemUI>.Enumerator);
		if (enumerator.MoveNext())
		{
			List<AdventureItemUI>.Enumerator enumerator2 = (List<AdventureItemUI>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
	}

	public SelectAdventuresPage()
	{
		List<AdventureItemUI> spawned = new List<AdventureItemUI>();
		_spawned = spawned;
		base._002Ector();
	}

	private void _003CMoveBackgroundIntoPlaceInANiceFancyWay_003Eb__42_0()
	{
		RewiredStandaloneInputModule inputModule = InputModule;
		inputModule.enabled = true;
	}
}
