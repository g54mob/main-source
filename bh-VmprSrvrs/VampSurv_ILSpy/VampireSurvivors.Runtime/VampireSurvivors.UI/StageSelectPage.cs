using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using VampireSurvivors.App.Objects;
using VampireSurvivors.App.Scripts.Framework.Adventures;
using VampireSurvivors.App.Scripts.UI;
using VampireSurvivors.App.UI;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Stage;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Cheats;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects;
using Zenject;

namespace VampireSurvivors.UI;

public class StageSelectPage : BaseUIPage
{
	public enum SelectionPhase
	{
		PHASE1,
		PHASE2
	}

	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Func<GameObject, StageItemUI> _003C_003E9__63_0;

		public static Func<StageItemUI, bool> _003C_003E9__63_1;

		public static Func<StageItemUI, TextMeshProUGUI> _003C_003E9__63_2;

		public static Func<TextMeshProUGUI, bool> _003C_003E9__63_3;

		public static Func<StageItemUI, int> _003C_003E9__84_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal StageItemUI _003CAutoSizeStageDescriptions_003Eb__63_0(GameObject go)
		{
			if ((object)go != null)
			{
				return go.GetComponent<StageItemUI>();
			}
			return (StageItemUI)(object)new NullReferenceException();
		}

		internal bool _003CAutoSizeStageDescriptions_003Eb__63_1(StageItemUI comp)
		{
			if ((object)comp != null)
			{
				bool flag = ((UnityEngine.Object)comp).m_CachedPtr == (IntPtr)0;
				return !flag;
			}
			return false;
		}

		internal TextMeshProUGUI _003CAutoSizeStageDescriptions_003Eb__63_2(StageItemUI stageItemUI)
		{
			if ((object)stageItemUI == null)
			{
				goto IL_00d2;
			}
			Localize descriptionText = stageItemUI._DescriptionText;
			TextMeshProUGUI result;
			if ((object)stageItemUI._DescriptionText != null && ((UnityEngine.Object)descriptionText).m_CachedPtr != (IntPtr)0)
			{
				if ((object)stageItemUI._DescriptionText == null)
				{
					goto IL_00d2;
				}
				TextMeshProUGUI component = stageItemUI._DescriptionText.GetComponent<TextMeshProUGUI>();
				if ((object)component != null)
				{
					bool flag = ((UnityEngine.Object)component).m_CachedPtr != (IntPtr)0;
					result = component;
					if (flag)
					{
						goto IL_013b;
					}
				}
			}
			result = null;
			goto IL_013b;
			IL_013b:
			return result;
			IL_00d2:
			return (TextMeshProUGUI)(object)new NullReferenceException();
		}

		internal bool _003CAutoSizeStageDescriptions_003Eb__63_3(TextMeshProUGUI descText)
		{
			if ((object)descText != null)
			{
				bool flag = ((UnityEngine.Object)descText).m_CachedPtr == (IntPtr)0;
				return !flag;
			}
			return false;
		}

		internal int _003CPopulate_003Eb__84_0(StageItemUI x)
		{
			//IL_0064: Expected I4, but got O
			if ((object)x != null)
			{
				StageData stage = x._stage;
				if (x._stage != null)
				{
					return stage._003Corder_003Ek__BackingField;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (int)ex;
		}
	}

	private sealed class _003CWaitAndSelect_003Ed__62(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public StageSelectPage _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_0062: Expected I4, but got I8
			StageSelectPage stageSelectPage = _003C_003E4__this;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			}
			if (_003C_003E1__state == 1)
			{
				_003C_003E1__state = -1;
				StageItemUI selectedStage = stageSelectPage._selectedStage;
				Selectable component;
				if ((object)stageSelectPage._selectedStage != null && ((UnityEngine.Object)selectedStage).m_CachedPtr != (IntPtr)0)
				{
					component = stageSelectPage._selectedStage.GetComponent<Selectable>();
				}
				else
				{
					List<GameObject> spawned = stageSelectPage._spawned;
					if (spawned._size <= 0)
					{
						System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
						bool result = default(bool);
						return result;
					}
					GameObject[] items = spawned._items;
					component = items[0].GetComponent<Selectable>();
				}
				component.Select();
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

	private sealed class _003CWaitRoutine_003Ed__89(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public Action cb;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0031: Expected I4, but got I8
			//IL_0089: Expected I4, but got I8
			//IL_00c5: Expected I4, but got O
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			}
			if (_003C_003E1__state == 1)
			{
				Action action = cb;
				_003C_003E1__state = -1;
				if (cb == null)
				{
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v75.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
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

	private GameObject stagePrefab;

	private RectTransform container;

	private Image _BackgroundPanel;

	private Localize nameText;

	private Localize tips;

	private Localize hyperTips;

	private TextMeshProUGUI _PageTitle;

	private TickBoxUI _HyperModeTickBox;

	private TickBoxUI _HurryModeTickBox;

	private TickBoxUI _MazzoModeTickBox;

	private TickBoxUI _LimitBreakTickBox;

	private TickBoxUI _InverseModeTickBox;

	private TickBoxUI _EndlessModeTickBox;

	private TickBoxUI _LockSelectedTickBox;

	private Button _ConfirmButton;

	private Button _SelectButton;

	private StageStatsPanel _Stats;

	private SongSelectionPanel _SongPanel;

	private Button _SelectableSongButton;

	private Button _SelectableSpeedButton;

	private Button _AdvancedSettingsButton;

	private RelicPanel _RelicPanel;

	private RectTransform _InfoPanel;

	private RectTransform _SliderRect;

	private StageRandomPanel _StageRandomPanel;

	private GameObject _SharePassivesPanel;

	private TickBoxUI _SharePassivesBox;

	private GameObject _DescriptionPanelTextPage;

	public SelectionPhase _selectionPhase;

	private SignalBus _signalBus;

	private List<GameObject> _spawned;

	private StageItemUI _selectedStage;

	private StageItemUI _highlightedStage;

	private StageData _selectedData;

	private DataManager _data;

	private PlayerOptions _playerOptions;

	private DiContainer _diContainer;

	private StageSelectionCheatCodeManager _cheats;

	private AdventureManager _adventureManager;

	private AdvancedMusicSelection _advancedMusicPanel;

	private bool _hurryModeAvailable;

	private bool _hyperModeAvailable;

	private bool _mazzoModeAvailable;

	private bool _limitBreakAvailable;

	private bool _inverseModeAvailable;

	private bool _endlessModeAvailable;

	private bool _hasConfirmed;

	private bool _phase1Disabled;

	private bool _phase2Disabled;

	private List<Selectable> _availableOptions;

	private bool _hasBanger;

	private bool _hasRandomOptions;

	private bool _hasRandomEvents;

	private bool _hasRandomLevelUps;

	private bool _hasToggles;

	private void Construct(SignalBus signal, DataManager data, PlayerOptions player, DiContainer diContainer, AdventureManager adventureManager)
	{
		_signalBus = signal;
		_data = data;
		_playerOptions = player;
		DiContainer diContainer2 = default(DiContainer);
		_diContainer = diContainer2;
		AdventureManager adventureManager2 = default(AdventureManager);
		_adventureManager = adventureManager2;
	}

	private void Start()
	{
		StageSelectionCheatCodeManager cheats = _diContainer.Instantiate<StageSelectionCheatCodeManager>();
		_cheats = cheats;
		_cheats.Initialize();
	}

	protected override void Update()
	{
		base.Update();
		_cheats.InternalUpdate();
		if (Player.GetButtonDown(6) || Player.GetButtonDown(10))
		{
			int localPlayerCount = Multiplayer.GetLocalPlayerCount();
			if (localPlayerCount <= 1 || !Multiplayer.IsUIBeingBlocked)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 133 Invalid \"Jump target not found in method: 0x186DA46F0\"");
			}
		}
	}

	private void OnDestroy()
	{
		if (_cheats != null)
		{
			_cheats.Dispose();
		}
		ResetBackButtonNavigation();
	}

	private unsafe void BackPressed()
	{
		//IL_008b: Expected O, but got Ref
		if (!_hasConfirmed)
		{
			BackButtonController.FireBack();
			return;
		}
		Selectable component = _selectedStage.GetComponent<Selectable>();
		component.Select();
		_hasConfirmed = false;
		if (_selectionPhase == SelectionPhase.PHASE2)
		{
			EnableFirstPhaseGroup();
			DisableSecondPhaseGroup();
			_selectionPhase = SelectionPhase.PHASE1;
			object obj = default(object);
			_BackgroundPanel.color = (Color)(&obj);
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.ClickOut, null, 0f, 10, time);
		}
	}

	protected override void OnShowStart(GameObject g)
	{
		//IL_00d4: Expected I4, but got O
		//IL_013f: Expected I4, but got O
		base.OnShowStart(g);
		UIHelper.OnInputMethodChanged value = SwitchInput;
		UIHelper.InputMethodChanged += value;
		_SongPanel.Initialize();
		Populate();
		AutoSizeStageDescriptions();
		List<GameObject> spawned = _spawned;
		if (spawned._size > 0)
		{
			GameObject[] items = spawned._items;
			Selectable component = items[0].GetComponent<Selectable>();
			Selectable selectable = default(Selectable);
			ForceBackButtonNavigation(null, component, null, selectable);
			GameObject localParametersRoot = default(GameObject);
			string overrideLanguage = default(string);
			bool allowLocalizedParameters = default(bool);
			string translation = LocalizationManager.GetTranslation("lang/stageSelection_header", FixForRTL: true, 0, ignoreRTLnumbers: true, (byte)(int)selectable != 0, localParametersRoot, overrideLanguage, allowLocalizedParameters);
			bool flag = !AdventureManager._003CIsInAdventureMode_003Ek__BackingField;
			bool flag2 = true;
			string text = translation;
			if (!flag)
			{
				string translation2 = LocalizationManager.GetTranslation("adventureLang/adv_adventureChapterSelection_header", FixForRTL: true, 0, ignoreRTLnumbers: true, (byte)(int)selectable != 0, localParametersRoot, overrideLanguage, allowLocalizedParameters);
				flag2 = true;
				text = translation2;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18634B7A0");
			UIHelper.ActiveInputType activeInput = UIHelper.ActiveInput;
			if (activeInput != UIHelper.ActiveInputType.MOUSE)
			{
				EnableFirstPhaseGroup();
				DisableSecondPhaseGroup();
				_selectionPhase = SelectionPhase.PHASE1;
			}
			_003CWaitAndSelect_003Ed__62 obj = null;
			obj._003C_003E1__state = 0;
			obj._003C_003E4__this = this;
			Coroutine coroutine = StartCoroutine(obj);
		}
		else
		{
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}

	private IEnumerator WaitAndSelect()
	{
		_003CWaitAndSelect_003Ed__62 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	private void AutoSizeStageDescriptions()
	{
		//IL_00f9: Expected I4, but got I8
		//IL_0110: Expected I4, but got I8
		Func<GameObject, StageItemUI> selector = _003C_003Ec._003C_003E9__63_0;
		if (_003C_003Ec._003C_003E9__63_0 == null)
		{
			selector = (_003C_003Ec._003C_003E9__63_0 = (GameObject go) => (StageItemUI)(((object)go != null) ? ((object)go.GetComponent<StageItemUI>()) : ((object)new NullReferenceException())));
		}
		IEnumerable<StageItemUI> source = Enumerable.Select(_spawned, selector);
		Func<StageItemUI, bool> predicate = _003C_003Ec._003C_003E9__63_1;
		if (_003C_003Ec._003C_003E9__63_1 == null)
		{
			predicate = (_003C_003Ec._003C_003E9__63_1 = delegate(StageItemUI comp)
			{
				if ((object)comp != null)
				{
					bool flag = ((UnityEngine.Object)comp).m_CachedPtr == (IntPtr)0;
					return !flag;
				}
				return false;
			});
		}
		IEnumerable<StageItemUI> enumerable = Enumerable.Where(source, predicate);
		if (enumerable != null)
		{
			List<object> source2 = new List<object>(enumerable);
			Func<StageItemUI, TextMeshProUGUI> selector2 = _003C_003Ec._003C_003E9__63_2;
			if (_003C_003Ec._003C_003E9__63_2 == null)
			{
				selector2 = (_003C_003Ec._003C_003E9__63_2 = delegate(StageItemUI stageItemUI)
				{
					if ((object)stageItemUI == null)
					{
						goto IL_00d2;
					}
					Localize descriptionText = stageItemUI._DescriptionText;
					TextMeshProUGUI result;
					if ((object)stageItemUI._DescriptionText != null && ((UnityEngine.Object)descriptionText).m_CachedPtr != (IntPtr)0)
					{
						if ((object)stageItemUI._DescriptionText == null)
						{
							goto IL_00d2;
						}
						TextMeshProUGUI component = stageItemUI._DescriptionText.GetComponent<TextMeshProUGUI>();
						if ((object)component != null)
						{
							bool flag = ((UnityEngine.Object)component).m_CachedPtr != (IntPtr)0;
							result = component;
							if (flag)
							{
								goto IL_013b;
							}
						}
					}
					result = null;
					goto IL_013b;
					IL_013b:
					return result;
					IL_00d2:
					return (TextMeshProUGUI)(object)new NullReferenceException();
				});
			}
			IEnumerable<TextMeshProUGUI> source3 = Enumerable.Select((IEnumerable<StageItemUI>)source2, selector2);
			Func<TextMeshProUGUI, bool> predicate2 = _003C_003Ec._003C_003E9__63_3;
			if (_003C_003Ec._003C_003E9__63_3 == null)
			{
				predicate2 = (_003C_003Ec._003C_003E9__63_3 = delegate(TextMeshProUGUI descText)
				{
					if ((object)descText != null)
					{
						bool flag = ((UnityEngine.Object)descText).m_CachedPtr == (IntPtr)0;
						return !flag;
					}
					return false;
				});
			}
			IEnumerable<TextMeshProUGUI> enumerable2 = Enumerable.Where(source3, predicate2);
			if (enumerable2 != null)
			{
				List<object> textObjects = new List<object>(enumerable2);
				TextAutoSizeHelper.UpdateTextSizes((List<TextMeshProUGUI>)(object)textObjects, -1, useLineCount: true);
				TextAutoSizeHelper.UpdateTextSizes((List<TextMeshProUGUI>)(object)textObjects, -1, useLineCount: true);
				return;
			}
			Exception ex = System.Linq.Error.ArgumentNull("source");
			throw ex;
		}
		Exception ex2 = System.Linq.Error.ArgumentNull("source");
		throw ex2;
	}

	protected override void OnEnterPressed()
	{
		EventSystem current = EventSystem.current;
		StageItemUI component = current.m_CurrentSelected.GetComponent<StageItemUI>();
		if ((object)component != null && ((UnityEngine.Object)component).m_CachedPtr != (IntPtr)0)
		{
			StageItemUI selectedStage = _selectedStage;
			StageData stage = selectedStage._stage;
			if (stage._003Cunlocked_003Ek__BackingField && !_hasConfirmed)
			{
				SelectStage();
			}
		}
	}

	private void OnDisable()
	{
		UIHelper.OnInputMethodChanged value = SwitchInput;
		UIHelper.InputMethodChanged -= value;
	}

	protected override void OnHideStart(GameObject g)
	{
		ResetBackButtonNavigation();
		EnableFirstPhaseGroup();
		EnableSecondPhaseGroup();
		UIHelper.OnInputMethodChanged value = SwitchInput;
		UIHelper.InputMethodChanged -= value;
	}

	protected override void OnHideFinish(GameObject g)
	{
		//IL_0087: Expected I4, but got O
		//IL_0087: Expected O, but got I
		base.OnHideFinish(g);
		bool flag = _spawned == null;
		BaseUIPage baseUIPage = this;
		if (!flag)
		{
			List<GameObject>.Enumerator enumerator = default(List<GameObject>.Enumerator);
			while (enumerator.MoveNext())
			{
				UnityEngine.Object.Destroy(null, 0f);
			}
			baseUIPage = (BaseUIPage)(object)_spawned;
			if (_spawned != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ rcx_v8 (VampireSurvivors.UI.BaseUIPage)+1C]");
				_ = (nint)0 + (nint)1;
				((MonoBehaviour)baseUIPage).m_CancellationTokenSource = null;
				if ((nint)((MonoBehaviour)baseUIPage).m_CancellationTokenSource > 0)
				{
					Array.Clear((Array)(nint)((UnityEngine.Object)baseUIPage).m_CachedPtr, 0, (int)((MonoBehaviour)baseUIPage).m_CancellationTokenSource);
				}
				SongSelectionPanel songPanel = _SongPanel;
				if ((object)_SongPanel != null)
				{
					SoundManager.StopMusic(songPanel._selectedSong);
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	public void OpenAdvancedMusicSelectionPanel()
	{
		//IL_0330: Expected O, but got I
		//IL_033b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0340: Expected O, but got Unknown
		//IL_023b: Expected O, but got I4
		//IL_0244: Expected O, but got I4
		//IL_03e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e6: Expected O, but got Unknown
		//IL_035e->IL00c9: Incompatible stack heights: 1 vs 0
		//IL_02c2->IL02ee: Incompatible stack heights: 1 vs 0
		//IL_03f3->IL0252: Incompatible stack heights: 2 vs 0
		BasePopup basePopup = PopupManager.CreateAdvancedMusicSelectionPopup("POPUP_MUSIC");
		if ((object)basePopup != null)
		{
			AdvancedMusicSelection component = basePopup.GetComponent<AdvancedMusicSelection>();
			_advancedMusicPanel = component;
			Action onClose = ReEnable;
			basePopup._onClose = onClose;
			BasePopup advancedMusicPanel = _advancedMusicPanel;
			AdvancedMusicSelection.OnSelectionChanged b = RefreshSongPanel;
			if ((object)_advancedMusicPanel != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ rdi_v7 (VampireSurvivors.UI.BasePopup)+100]");
				Delegate obj = (Delegate)0;
				object obj2 = _advancedMusicPanel + 256;
				bool flag5;
				do
				{
					Delegate obj3 = Delegate.Combine(obj, b);
					bool flag = (object)obj3 == null;
					Delegate obj4 = null;
					if (!flag)
					{
						bool flag2 = (object)obj3.GetType() != typeof(AdvancedMusicSelection.OnSelectionChanged);
						obj4 = null;
						if (!flag2)
						{
							obj4 = obj3;
						}
						bool flag3 = (object)obj4 == null;
					}
					bool flag4 = obj == obj2;
					Delegate obj5;
					if (obj == obj2)
					{
						obj2 = obj4;
						obj5 = obj;
					}
					else
					{
						obj5 = (Delegate)obj2;
					}
					Delegate obj6 = obj;
					if (!flag4)
					{
						obj6 = obj5;
					}
					flag5 = (object)obj6 != obj;
					obj = obj6;
				}
				while (flag5);
				SongSelectionPanel songPanel = _SongPanel;
				if ((object)_SongPanel != null)
				{
					AdvancedMusicSelection advancedMusicPanel2 = _advancedMusicPanel;
					if ((object)_advancedMusicPanel != null)
					{
						advancedMusicPanel2._defaultSong = songPanel._selectedSong;
						base.enabled = false;
						if ((object)_scroll != null)
						{
							ScrollEnhancer component2 = _scroll.GetComponent<ScrollEnhancer>();
							if ((object)component2 != null)
							{
								component2.enabled = false;
								Scrollbar[] componentsInChildren = GetComponentsInChildren<Scrollbar>();
								bool flag6 = componentsInChildren == null;
								object obj7 = 0;
								object obj8 = 0;
								if (!flag6)
								{
									while (true)
									{
										if ((nint)obj8 < componentsInChildren.Length)
										{
											bool flag7 = (nint)obj7 >= componentsInChildren.Length;
											BasePopup basePopup2 = (BasePopup)(object)componentsInChildren[obj7];
											if ((object)componentsInChildren[obj7] == null)
											{
												break;
											}
											bool flag8 = ((UnityEngine.Object)basePopup2).m_CachedPtr == (IntPtr)0;
											Behaviour.set_enabled_Injected(((UnityEngine.Object)basePopup2).m_CachedPtr, false);
											obj7++;
											obj8 = obj7;
											continue;
										}
										EnableFirstPhaseGroup();
										DisableSecondPhaseGroup();
										_selectionPhase = SelectionPhase.PHASE1;
										return;
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

	private unsafe void ReEnable()
	{
		//IL_00d7: Expected I, but got O
		//IL_00ed: Expected O, but got I
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Expected O, but got Unknown
		//IL_0171: Expected I, but got O
		//IL_0429: Expected O, but got I4
		//IL_0440: Expected I, but got I8
		//IL_040e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0413: Expected O, but got Unknown
		//IL_045b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0460: Expected O, but got Unknown
		//IL_014d: Expected I, but got I8
		//IL_0330: Expected O, but got I
		//IL_039c: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a1: Expected O, but got Unknown
		//IL_036e: Expected I4, but got O
		//IL_0420->IL04f7: Incompatible stack heights: 1 vs 0
		//IL_03b3->IL04d0: Incompatible stack heights: 1 vs 0
		base.enabled = true;
		ScrollEnhancer component = _scroll.GetComponent<ScrollEnhancer>();
		component.enabled = true;
		Scrollbar[] componentsInChildren = GetComponentsInChildren<Scrollbar>();
		Delegate obj = null;
		Delegate obj2 = null;
		while ((nint)obj2 < componentsInChildren.Length)
		{
			Scrollbar scrollbar = componentsInChildren[(object)obj];
			bool flag = ((UnityEngine.Object)scrollbar).m_CachedPtr == (IntPtr)0;
			Behaviour.set_enabled_Injected(((UnityEngine.Object)scrollbar).m_CachedPtr, true);
			obj = (Delegate)(obj + 1);
			obj2 = obj;
		}
		UIHelper.ActiveInputType activeInput = UIHelper.ActiveInput;
		SwitchInput(activeInput);
		AdvancedMusicSelection advancedMusicPanel = _advancedMusicPanel;
		AdvancedMusicSelection.OnSelectionChanged onSelectionChanged = null;
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ r9_v6 (Il2CppMethodInfo)+8]");
		((Delegate)onSelectionChanged).method_ptr = (IntPtr)0;
		((Delegate)onSelectionChanged).method = (nint)__ldftn(StageSelectPage.RefreshSongPanel);
		((Delegate)onSelectionChanged).m_target = this;
		((Delegate)onSelectionChanged).method_code = (IntPtr)onSelectionChanged;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ r9_v6 (Il2CppMethodInfo)+4C]");
		object obj3 = (nint)0 >> 4;
		object obj4 = obj3 & 1;
		nint num2;
		if (obj4 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ r9_v6 (Il2CppMethodInfo)+52]");
			if ((nint)0 == 0)
			{
				num2 = unchecked((nint)6447293664L);
				goto IL_0420;
			}
		}
		num2 = ((Delegate)onSelectionChanged).method_ptr;
		((Delegate)onSelectionChanged).method_code = (IntPtr)((Delegate)onSelectionChanged).m_target;
		goto IL_0420;
		IL_0420:
		object obj5 = 24;
		((Delegate)onSelectionChanged).extra_arg = unchecked((nint)6447293568L);
		Delegate obj6 = advancedMusicPanel.SelectedTrackChanged;
		object obj7 = advancedMusicPanel + 256;
		while (true)
		{
			Delegate obj8 = Delegate.Remove(obj6, onSelectionChanged);
			bool flag2 = (object)obj8 == null;
			Delegate obj9 = null;
			if (!flag2)
			{
				bool flag3 = (object)obj8.GetType() != typeof(AdvancedMusicSelection.OnSelectionChanged);
				obj9 = null;
				if (!flag3)
				{
					obj9 = obj8;
				}
				if ((object)obj9 == null)
				{
					break;
				}
			}
			bool flag4 = obj6 == obj7;
			Delegate obj10;
			if (obj6 == obj7)
			{
				obj7 = obj9;
				obj10 = obj6;
			}
			else
			{
				obj10 = (Delegate)obj7;
			}
			Delegate obj11 = obj6;
			if (!flag4)
			{
				obj11 = obj10;
			}
			bool flag5 = (object)obj11 != obj6;
			obj6 = obj11;
			if (flag5)
			{
				continue;
			}
			_advancedMusicPanel = null;
			SongSelectionPanel songPanel = _SongPanel;
			Debug.Log("Refreshing");
			songPanel._previousSong = BgmType.NONE;
			PlayerOptionsData config = songPanel._playerOptions.Config;
			songPanel._selectedSpeed = config._003CSelectedBGMMod_003Ek__BackingField;
			PlayerOptionsData config2 = songPanel._playerOptions.Config;
			songPanel._selectedSong = config2._003CSelectedBGM_003Ek__BackingField;
			List<BgmType> songList = songPanel._songList;
			Delegate obj12 = null;
			Delegate obj13 = null;
			while (true)
			{
				Delegate obj14 = obj13;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v971 @ rax_v44 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmType>)+18]");
				if ((nint)obj14 >= 0)
				{
					break;
				}
				List<BgmType> songList2 = songPanel._songList;
				Delegate obj15 = obj12;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ rax_v46 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmType>)+18]");
				bool flag6 = (nint)obj15 >= 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ rax_v46 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmType>)+10]");
				object obj16 = 0;
				BgmType selectedSong = songPanel._selectedSong;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v138 @ rcx_v39+20+v92 @ rdi_v5 (System.Delegate)*4]");
				if ((nint)selectedSong == (nint)0)
				{
					songPanel._songIndex = (int)obj12;
					songPanel.SetIcon();
					songPanel.SetName();
				}
				songList = songPanel._songList;
				obj12 = (Delegate)(obj12 + 1);
				obj13 = obj12;
			}
			songPanel.SetSpeedName();
			return;
		}
		throw new InvalidCastException();
	}

	private void RefreshSongPanel()
	{
		//IL_00f6: Expected O, but got I
		SongSelectionPanel songPanel = _SongPanel;
		Debug.Log("Refreshing");
		songPanel._previousSong = BgmType.NONE;
		PlayerOptionsData config = songPanel._playerOptions.Config;
		songPanel._selectedSpeed = config._003CSelectedBGMMod_003Ek__BackingField;
		PlayerOptionsData config2 = songPanel._playerOptions.Config;
		songPanel._selectedSong = config2._003CSelectedBGM_003Ek__BackingField;
		List<BgmType> songList = songPanel._songList;
		int num = 0;
		int num2 = 0;
		while (true)
		{
			int num3 = num2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v277 @ rax_v15 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmType>)+18]");
			if ((nint)num3 < (nint)0)
			{
				List<BgmType> songList2 = songPanel._songList;
				int num4 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rax_v17 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmType>)+18]");
				if ((nint)num4 >= (nint)0)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rax_v17 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmType>)+10]");
				object obj = 0;
				BgmType selectedSong = songPanel._selectedSong;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ rcx_v13+20+v29 @ rdi_v5 (System.Int32)*4]");
				if ((nint)selectedSong == (nint)0)
				{
					songPanel._songIndex = num;
					songPanel.SetIcon();
					songPanel.SetName();
				}
				songList = songPanel._songList;
				num++;
				num2 = num;
				continue;
			}
			songPanel.SetSpeedName();
			return;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public void ConfirmStage()
	{
		StageItemUI selectedStage = _selectedStage;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA03B0");
		PlayerOptionsData config = _playerOptions.Config;
		TickBoxUI hyperModeTickBox = _HyperModeTickBox;
		bool flag;
		if (!hyperModeTickBox.isOn)
		{
			flag = false;
		}
		else
		{
			StageData selectedData = _selectedData;
			StageModifiers stageModifiers = selectedData._003Chyper_003Ek__BackingField;
			flag = stageModifiers._003Cunlocked_003Ek__BackingField;
		}
		bool flag2 = !flag;
		bool flag3 = !flag2;
		config._003CSelectedHyper_003Ek__BackingField = flag3;
		PlayerOptionsData config2 = _playerOptions.Config;
		TickBoxUI hurryModeTickBox = _HurryModeTickBox;
		config2._003CSelectedHurry_003Ek__BackingField = hurryModeTickBox.isOn;
		PlayerOptionsData config3 = _playerOptions.Config;
		TickBoxUI mazzoModeTickBox = _MazzoModeTickBox;
		config3._003CSelectedMazzo_003Ek__BackingField = mazzoModeTickBox.isOn;
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Detune = 250f;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.ClickIn, soundConfig, 0f, 10, time);
		SongSelectionPanel songPanel = _SongPanel;
		PlayerOptionsData config4 = songPanel._playerOptions.Config;
		config4._003CSelectedBGM_003Ek__BackingField = songPanel._selectedSong;
		PlayerOptionsData config5 = songPanel._playerOptions.Config;
		config5._003CSelectedBGMMod_003Ek__BackingField = songPanel._selectedSpeed;
		HostPlayerOptions hostPlayerOptions = HostPlayerOptions._003CInstance_003Ek__BackingField;
		if ((object)HostPlayerOptions._003CInstance_003Ek__BackingField != null && ((UnityEngine.Object)hostPlayerOptions).m_CachedPtr != (IntPtr)0)
		{
			HostPlayerOptions hostPlayerOptions2 = HostPlayerOptions._003CInstance_003Ek__BackingField;
			hostPlayerOptions2._003CSelectedBGM_003Ek__BackingField = (int)songPanel._selectedSong;
		}
		UIHelper.OnInputMethodChanged value = SwitchInput;
		UIHelper.InputMethodChanged -= value;
	}

	public unsafe void SelectStage()
	{
		//IL_00dc: Expected O, but got Ref
		PlayerOptionsData config = _playerOptions.Config;
		StageItemUI selectedStage = _selectedStage;
		config._003CSelectedStage_003Ek__BackingField = selectedStage._003CType_003Ek__BackingField;
		_ConfirmButton.interactable = true;
		GameObject gameObject = _ConfirmButton.gameObject;
		gameObject.SetActive(value: true);
		_ConfirmButton.Select();
		UIHelper.ActiveInputType activeInput = UIHelper.ActiveInput;
		if (activeInput != UIHelper.ActiveInputType.MOUSE)
		{
			DisableFirstPhaseGroup();
			EnableSecondPhaseGroup();
		}
		_selectionPhase = SelectionPhase.PHASE2;
		object obj = default(object);
		_BackgroundPanel.color = (Color)(&obj);
		GameObject gameObject2 = _SelectButton.gameObject;
		gameObject2.SetActive(value: false);
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Detune = 225f;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.ClickIn, soundConfig, 0f, 10, time);
		GenerateNavigation();
		_hasConfirmed = true;
	}

	public void HighlightStage(StageItemUI item)
	{
		StageItemUI highlightedStage = _highlightedStage;
		if ((object)_highlightedStage != null && ((UnityEngine.Object)highlightedStage).m_CachedPtr != (IntPtr)0)
		{
			StageItemUI highlightedStage2 = _highlightedStage;
			highlightedStage2._Background.enabled = false;
		}
		_highlightedStage = item;
		StageItemUI highlightedStage3 = _highlightedStage;
		highlightedStage3._Background.enabled = true;
	}

	public unsafe void SetInfoPanel(StageItemUI stageItemUI, StageData stage, StageType stageType)
	{
		//IL_0526: Expected O, but got Ref
		_selectedData = stage;
		_selectedStage = stageItemUI;
		GameObject gameObject = _SelectButton.gameObject;
		StageData selectedData = _selectedData;
		gameObject.SetActive(selectedData._003Cunlocked_003Ek__BackingField);
		GameObject gameObject2 = _ConfirmButton.gameObject;
		gameObject2.SetActive(value: false);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2C74]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		string prefix = stage.GetPrefix(stageType);
		string term = prefix + "stageName";
		nameText.Term = term;
		StageData selectedData2 = _selectedData;
		if (!selectedData2._003Cunlocked_003Ek__BackingField)
		{
			TextMeshProUGUI component = nameText.GetComponent<TextMeshProUGUI>();
			component.text = "???";
		}
		StageModifiers stageModifiers = stage._003Chyper_003Ek__BackingField;
		bool flag = !stageModifiers._003Cunlocked_003Ek__BackingField;
		bool flag2 = false;
		if (!flag)
		{
			flag2 = stage._003Cunlocked_003Ek__BackingField;
		}
		bool flag3 = !flag2;
		bool hyperModeAvailable = !flag3;
		_hyperModeAvailable = hyperModeAvailable;
		GameObject gameObject3 = _HyperModeTickBox.gameObject;
		bool flag4 = !_hyperModeAvailable;
		bool flag5 = false;
		if (!flag4)
		{
			flag5 = stage._003Cunlocked_003Ek__BackingField;
		}
		bool flag6 = !flag5;
		bool active = !flag6;
		gameObject3.SetActive(active);
		GameObject gameObject4 = _HurryModeTickBox.gameObject;
		bool flag7 = !_hurryModeAvailable;
		bool flag8 = false;
		if (!flag7)
		{
			flag8 = stage._003Cunlocked_003Ek__BackingField;
		}
		bool flag9 = !flag8;
		bool active2 = !flag9;
		gameObject4.SetActive(active2);
		GameObject gameObject5 = _MazzoModeTickBox.gameObject;
		bool flag10 = !_mazzoModeAvailable;
		bool flag11 = false;
		if (!flag10)
		{
			flag11 = stage._003Cunlocked_003Ek__BackingField;
		}
		bool flag12 = !flag11;
		bool active3 = !flag12;
		gameObject5.SetActive(active3);
		GameObject gameObject6 = _LimitBreakTickBox.gameObject;
		bool flag13 = !_limitBreakAvailable;
		bool flag14 = false;
		if (!flag13)
		{
			flag14 = stage._003Cunlocked_003Ek__BackingField;
		}
		bool flag15 = !flag14;
		bool active4 = !flag15;
		gameObject6.SetActive(active4);
		GameObject gameObject7 = _EndlessModeTickBox.gameObject;
		bool flag16 = !_endlessModeAvailable;
		bool flag17 = false;
		if (!flag16)
		{
			flag17 = stage._003Cunlocked_003Ek__BackingField;
		}
		bool flag18 = !flag17;
		bool active5 = !flag18;
		gameObject7.SetActive(active5);
		GameObject gameObject8 = _InverseModeTickBox.gameObject;
		bool flag19 = !_inverseModeAvailable;
		bool flag20 = false;
		if (!flag19)
		{
			flag20 = stage._003Cunlocked_003Ek__BackingField;
		}
		bool flag21 = !flag20;
		bool active6 = !flag21;
		gameObject8.SetActive(active6);
		_Stats.SetStage(stage, stageType, _playerOptions);
		_Stats.Refresh();
		_StageRandomPanel.SetStage(stage, stageType);
		_SongPanel.SetStage(stage);
		if (!stage._003Cunlocked_003Ek__BackingField)
		{
			GameObject gameObject9 = _RelicPanel.gameObject;
			gameObject9.SetActive(value: false);
		}
		else
		{
			GameObject gameObject10 = _RelicPanel.gameObject;
			gameObject10.SetActive(value: true);
			_RelicPanel.SetRelics(stage, stageType);
		}
		UIHelper.ActiveInputType activeInput = UIHelper.ActiveInput;
		if (activeInput == UIHelper.ActiveInputType.MOUSE)
		{
			_selectionPhase = SelectionPhase.PHASE1;
			object obj = default(object);
			_BackgroundPanel.color = (Color)(&obj);
		}
		_hasConfirmed = false;
		Selectable component2 = _SelectableSongButton.GetComponent<Selectable>();
		Selectable component3 = _SelectableSpeedButton.GetComponent<Selectable>();
		Selectable component4 = stageItemUI.GetComponent<Selectable>();
		SetNavigationLeft(component2, component4);
		Selectable component5 = stageItemUI.GetComponent<Selectable>();
		SetNavigationLeft(component3, component5);
		Selectable component6 = stageItemUI.GetComponent<Selectable>();
		SetNavigationLeft(_AdvancedSettingsButton, component6);
	}

	public void SetHyper(bool b)
	{
		StageStatsPanel stats = _Stats;
		stats._hyperSelected = b;
		PlayerOptionsData config = _playerOptions.Config;
		config._003CSelectedHyper_003Ek__BackingField = b;
		_Stats.Refresh();
	}

	public void SetHurry(bool b)
	{
		StageStatsPanel stats = _Stats;
		stats._hurrySelected = b;
		PlayerOptionsData config = _playerOptions.Config;
		config._003CSelectedHurry_003Ek__BackingField = b;
		_Stats.Refresh();
	}

	public void SetArcanas(bool b)
	{
		PlayerOptionsData config = _playerOptions.Config;
		config._003CSelectedMazzo_003Ek__BackingField = b;
	}

	public void SetLimitBreak(bool b)
	{
		PlayerOptionsData config = _playerOptions.Config;
		config._003CSelectedLimitBreak_003Ek__BackingField = b;
	}

	public void SetInverse(bool b)
	{
		PlayerOptionsData config = _playerOptions.Config;
		config._003CSelectedInverse_003Ek__BackingField = b;
		StageStatsPanel stats = _Stats;
		stats._inverseSelected = b;
		_Stats.Refresh();
		StageItemUI selectedStage = _selectedStage;
		_SongPanel.SetStage(selectedStage._stage);
	}

	public void SetEndless(bool b)
	{
		PlayerOptionsData config = _playerOptions.Config;
		config._003CSelectedReapers_003Ek__BackingField = b;
	}

	public void ToggleHyper()
	{
		PlayerOptionsData config = _playerOptions.Config;
		TickBoxUI hyperModeTickBox = _HyperModeTickBox;
		bool flag;
		if (!hyperModeTickBox.isOn)
		{
			flag = false;
		}
		else
		{
			StageData selectedData = _selectedData;
			StageModifiers stageModifiers = selectedData._003Chyper_003Ek__BackingField;
			flag = stageModifiers._003Cunlocked_003Ek__BackingField;
		}
		bool flag2 = !flag;
		bool flag3 = !flag2;
		config._003CSelectedHyper_003Ek__BackingField = flag3;
	}

	public void SetSharePassives(bool b)
	{
		PlayerOptionsData config = _playerOptions.Config;
		config._003CSelectedSharePassives_003Ek__BackingField = b;
		_Stats.Refresh();
	}

	private static Dictionary<StageType, List<StageData>> Stage6Checks(Dictionary<StageType, List<StageData>> STAGE_DATA, PlayerOptions playerOptions)
	{
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Expected O, but got Unknown
		//IL_0156: Unknown result type (might be due to invalid IL or missing references)
		//IL_015b: Expected O, but got Unknown
		//IL_01e9: Expected O, but got I
		//IL_0381: Expected O, but got I
		//IL_01fe: Expected O, but got I
		//IL_0396: Expected O, but got I
		//IL_02ff: Expected O, but got I
		//IL_0314: Expected O, but got I
		//IL_0258: Expected O, but got I
		//IL_026d: Expected O, but got I
		//IL_049a: Expected O, but got I
		//IL_04af: Expected O, but got I
		PlayerOptionsData config = playerOptions.Config;
		List<AchievementType> list = config._003CAchievements_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ rcx_v7 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
		bool flag;
		if ((nint)0 == 0)
		{
			flag = false;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj2 = default(object);
			object obj = obj2 - -1;
			bool flag2 = obj == null;
			flag = !flag2;
		}
		PlayerOptionsData config2 = playerOptions.Config;
		List<ItemType> list2 = config2._003CCollectedItems_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ rcx_v11 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		bool flag3;
		if ((nint)0 == 0)
		{
			flag3 = false;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj4 = default(object);
			object obj3 = obj4 - -1;
			bool flag4 = obj3 == null;
			flag3 = !flag4;
		}
		PlayerOptionsData config3 = playerOptions.Config;
		List<ItemType> list3 = config3._003CCollectedItems_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ rcx_v15 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		bool flag5;
		if ((nint)0 == 0)
		{
			flag5 = false;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj6 = default(object);
			object obj5 = obj6 - -1;
			bool flag6 = obj5 == null;
			flag5 = !flag6;
		}
		PlayerOptionsData config4 = playerOptions.Config;
		PlayerOptionsData config5 = playerOptions.Config;
		if (!flag)
		{
			object obj7 = ((Dictionary<System.Int32Enum, object>)(object)STAGE_DATA).get_Item((System.Int32Enum)15);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ rax_v37 (System.Object)+18]");
			if ((nint)0 > (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ rax_v37 (System.Object)+10]");
				object obj8 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ rax_v38+20]");
				object obj9 = 0;
				_ = 1;
				object obj10 = ((Dictionary<System.Int32Enum, object>)(object)STAGE_DATA).get_Item((System.Int32Enum)15);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ rax_v39 (System.Object)+18]");
				if ((nint)0 > (nint)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ rax_v39 (System.Object)+10]");
					object obj11 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ rax_v40+20]");
					object obj12 = 0;
					goto IL_0573;
				}
			}
			goto IL_0552;
		}
		PlayerOptionsData config6 = playerOptions.Config;
		object message;
		if (config6._003CHasSeenFinalFireworks_003Ek__BackingField)
		{
			object obj13 = ((Dictionary<System.Int32Enum, object>)(object)STAGE_DATA).get_Item((System.Int32Enum)15);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v117 @ rax_v33 (System.Object)+18]");
			if ((nint)0 <= (nint)0)
			{
				goto IL_0552;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v117 @ rax_v33 (System.Object)+10]");
			object obj14 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rax_v34+20]");
			object obj15 = 0;
			_ = 1000;
			message = "MACHINE 1000";
		}
		else
		{
			object obj16 = ((Dictionary<System.Int32Enum, object>)(object)STAGE_DATA).get_Item((System.Int32Enum)15);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rax_v29 (System.Object)+18]");
			if ((nint)0 <= (nint)0)
			{
				goto IL_0552;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rax_v29 (System.Object)+10]");
			object obj17 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ rax_v30+20]");
			object obj18 = 0;
			_ = 0;
			message = "MACHINE 0";
		}
		Debug.Log(message);
		if (!flag3)
		{
			if (!flag5)
			{
				object obj19 = ((Dictionary<System.Int32Enum, object>)(object)STAGE_DATA).get_Item((System.Int32Enum)15);
				List<StageData> list4 = ((Dictionary<StageType, List<StageData>>)obj19).get_Item(StageType.MACHINE);
				goto IL_0573;
			}
		}
		else
		{
			if (~(config5._003CHasUsedTrumpet_003Ek__BackingField ? 1u : 0u) != 0)
			{
				goto IL_04bf;
			}
			if (!flag5)
			{
				goto IL_044b;
			}
		}
		if (~(config4._003CHasUsedMirror_003Ek__BackingField ? 1u : 0u) == 0)
		{
			goto IL_044b;
		}
		goto IL_04bf;
		IL_0552:
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		Dictionary<StageType, List<StageData>> result = default(Dictionary<StageType, List<StageData>>);
		return result;
		IL_0573:
		return STAGE_DATA;
		IL_04bf:
		object obj20 = ((Dictionary<System.Int32Enum, object>)(object)STAGE_DATA).get_Item((System.Int32Enum)15);
		List<StageData> list5 = ((Dictionary<StageType, List<StageData>>)obj20).get_Item(StageType.MACHINE);
		_ = 1;
		goto IL_0573;
		IL_044b:
		object obj21 = ((Dictionary<System.Int32Enum, object>)(object)STAGE_DATA).get_Item((System.Int32Enum)15);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ rax_v25 (System.Object)+18]");
		if ((nint)0 <= (nint)0)
		{
			goto IL_0552;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ rax_v25 (System.Object)+10]");
		object obj22 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ rax_v26+20]");
		object obj23 = 0;
		_ = 0;
		goto IL_0573;
	}

	private unsafe void Populate()
	{
		//IL_00be: Expected O, but got I4
		//IL_02b2: Expected O, but got I
		//IL_069c: Expected O, but got I4
		//IL_068a: Expected O, but got I4
		//IL_0678: Expected O, but got I4
		//IL_063c: Expected O, but got I4
		//IL_06f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_06fe: Expected O, but got Unknown
		//IL_07d6: Expected O, but got I4
		//IL_07c4: Expected O, but got I4
		//IL_07b2: Expected O, but got I4
		//IL_0776: Expected O, but got I4
		//IL_0833: Unknown result type (might be due to invalid IL or missing references)
		//IL_0838: Expected O, but got Unknown
		//IL_0910: Expected O, but got I4
		//IL_08fe: Expected O, but got I4
		//IL_08ec: Expected O, but got I4
		//IL_08b0: Expected O, but got I4
		//IL_096d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0972: Expected O, but got Unknown
		//IL_0c93: Expected I, but got O
		//IL_0ca9: Expected O, but got I
		//IL_0cb2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cb7: Expected O, but got Unknown
		//IL_0d20: Expected I, but got O
		//IL_29a1: Expected I, but got I8
		//IL_0d09: Expected I, but got I8
		//IL_0d94: Expected I, but got O
		//IL_0daa: Expected O, but got I
		//IL_0db3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0db8: Expected O, but got Unknown
		//IL_0e21: Expected I, but got O
		//IL_29e2: Expected I, but got I8
		//IL_0e0a: Expected I, but got I8
		//IL_150d: Expected O, but got I
		//IL_1827: Expected O, but got F4
		//IL_1838: Expected O, but got F4
		//IL_16f0: Expected O, but got F4
		//IL_174c: Expected O, but got F4
		//IL_1762: Expected O, but got I4
		//IL_2bcb: Expected I, but got O
		//IL_2bf3: Expected O, but got I
		//IL_19c0: Expected O, but got I
		//IL_1a27: Expected O, but got I
		//IL_1aa2: Expected I4, but got O
		//IL_2c81: Expected O, but got I4
		//IL_2ca0: Expected O, but got I
		//IL_1b01: Expected O, but got I4
		//IL_1b1c: Expected O, but got I4
		//IL_1b3b: Expected O, but got I4
		//IL_1e92: Expected O, but got I
		//IL_1f0f: Expected O, but got I
		//IL_1f7d: Expected O, but got Ref
		//IL_2d05: Expected I, but got O
		//IL_2d1b: Expected O, but got I
		//IL_1f8a: Expected I, but got O
		//IL_2015: Expected O, but got I4
		//IL_1fc2: Expected O, but got I
		//IL_2d35: Expected O, but got I4
		//IL_20f2: Expected O, but got I4
		//IL_2108: Expected O, but got I
		//IL_2111: Unknown result type (might be due to invalid IL or missing references)
		//IL_2116: Expected O, but got Unknown
		//IL_211e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2123: Expected O, but got Unknown
		//IL_2043: Expected I, but got O
		//IL_20ce: Expected O, but got I4
		//IL_21e8: Expected I, but got O
		//IL_207b: Expected O, but got I
		//IL_222e: Expected O, but got Ref
		//IL_2d6c: Expected O, but got I4
		//IL_2212: Expected I4, but got O
		//IL_2217: Expected I, but got O
		//IL_2135: Expected O, but got I4
		//IL_214b: Expected O, but got I
		//IL_2154: Unknown result type (might be due to invalid IL or missing references)
		//IL_2159: Expected O, but got Unknown
		//IL_2161: Unknown result type (might be due to invalid IL or missing references)
		//IL_2166: Expected O, but got Unknown
		//IL_223b: Expected I, but got O
		//IL_22c6: Expected O, but got I4
		//IL_2273: Expected O, but got I
		//IL_2ea9: Expected O, but got I4
		//IL_23a3: Expected O, but got I4
		//IL_23b9: Expected O, but got I
		//IL_23c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_23c7: Expected O, but got Unknown
		//IL_23cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_23d4: Expected O, but got Unknown
		//IL_22f4: Expected I, but got O
		//IL_237f: Expected O, but got I4
		//IL_232c: Expected O, but got I
		//IL_2ee0: Expected O, but got I4
		//IL_23e6: Expected O, but got I4
		//IL_23fc: Expected O, but got I
		//IL_2405: Unknown result type (might be due to invalid IL or missing references)
		//IL_240a: Expected O, but got Unknown
		//IL_2412: Unknown result type (might be due to invalid IL or missing references)
		//IL_2417: Expected O, but got Unknown
		//IL_2bfc->IL2504: Incompatible stack heights: 1 vs 0
		//IL_18ba->IL2504: Incompatible stack heights: 1 vs 0
		//IL_1936->IL2504: Incompatible stack heights: 1 vs 0
		//IL_1b64->IL2504: Incompatible stack heights: 1 vs 0
		//IL_2c16->IL301b: Incompatible stack heights: 5 vs 1
		//IL_1bb4->IL2504: Incompatible stack heights: 2 vs 0
		//IL_1aa7->IL2c01: Incompatible stack heights: 7 vs 5
		//IL_1c04->IL2504: Incompatible stack heights: 3 vs 0
		//IL_2ca9->IL1b40: Incompatible stack heights: 2 vs 1
		//IL_1c40->IL2504: Incompatible stack heights: 3 vs 0
		//IL_1b25->IL2504: Incompatible stack heights: 2 vs 0
		//IL_1c7a->IL2504: Incompatible stack heights: 3 vs 0
		//IL_1d6f->IL2504: Incompatible stack heights: 2 vs 0
		//IL_1cd2->IL2504: Incompatible stack heights: 4 vs 0
		//IL_1d98->IL2504: Incompatible stack heights: 2 vs 0
		//IL_1d3b->IL2504: Incompatible stack heights: 5 vs 0
		//IL_1de4->IL2504: Incompatible stack heights: 2 vs 0
		//IL_1d40->IL1d40: Incompatible stack heights: 5 vs 2
		//IL_1e41->IL2504: Incompatible stack heights: 2 vs 0
		//IL_1f66->IL2504: Incompatible stack heights: 2 vs 0
		//IL_1f2b->IL2cae: Incompatible stack heights: 4 vs 2
		//IL_1ef9->IL2cae: Incompatible stack heights: 4 vs 2
		//IL_2e97->IL2504: Incompatible stack heights: 3 vs 0
		//IL_2e73->IL306b: Incompatible stack heights: 8 vs 2
		//IL_24d3->IL2fbc: Incompatible stack heights: 9 vs 3
		//IL_24a4->IL2fbc: Incompatible stack heights: 9 vs 3
		PlayerOptions stats = (PlayerOptions)(object)_Stats;
		Dictionary<StageType, List<StageData>> availableStages;
		StageType stageType;
		if ((object)_Stats != null)
		{
			_ = _playerOptions;
			stats = _playerOptions;
			if (_playerOptions != null)
			{
				PlayerOptionsData config = _playerOptions.Config;
				if (config != null)
				{
					availableStages = GetAvailableStages(_data, _playerOptions);
					bool flag = availableStages == null;
					stats = (PlayerOptions)(object)_data;
					if (!flag)
					{
						int num = ((Dictionary<System.Int32Enum, object>)(object)availableStages).FindEntry((System.Int32Enum)config._003CSelectedStage_003Ek__BackingField);
						object obj = !flag;
						stageType = config._003CSelectedStage_003Ek__BackingField;
						if (obj == null)
						{
							if (((Dictionary<StageType, List<StageData>>)(object)typeof(AdventureManager)).FindEntry(config._003CSelectedStage_003Ek__BackingField) != 0)
							{
								AdventureManager adventureManager = _adventureManager;
								bool flag2 = _adventureManager == null;
								stats = (PlayerOptions)(object)typeof(AdventureManager);
								if (!flag2)
								{
									stats = (PlayerOptions)(object)adventureManager._003CAdventureData_003Ek__BackingField;
									if (adventureManager._003CAdventureData_003Ek__BackingField != null)
									{
										PlayerOptions.OnValueChanged powerUpsRefunded = stats.PowerUpsRefunded;
										if (stats.PowerUpsRefunded != null)
										{
											stageType = (StageType)(nint)((Delegate)powerUpsRefunded).method;
											goto IL_2549;
										}
									}
								}
								goto IL_2504;
							}
							stageType = StageType.FOREST;
						}
						goto IL_2549;
					}
				}
			}
		}
		goto IL_2504;
		IL_2b14:
		BgmType bgmType;
		BgmType bgmType2;
		if (bgmType != BgmType.BGM_Forest && (object)_SharePassivesBox != null)
		{
			TickBoxUI sharePassivesBox = _SharePassivesBox;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v373 @ rax_v164 (VampireSurvivors.Data.BgmType)+54]");
			sharePassivesBox.InitialSet(b: false);
			PlayerOptionsData playerOptions = (PlayerOptionsData)(object)_playerOptions;
			bool flag3 = _playerOptions == null;
			stats = (PlayerOptions)(object)_SharePassivesBox;
			if (!flag3)
			{
				stats = (PlayerOptions)(object)_SharePassivesBox;
				if (playerOptions._003CSelectedBGM_003Ek__BackingField == BgmType.BGM_Forest)
				{
					if (playerOptions._003CSelectedArcana_003Ek__BackingField == 0)
					{
						if (playerOptions._003CSelectedMaxWeapons_003Ek__BackingField != 0)
						{
							bgmType2 = (BgmType)playerOptions._003CSelectedMaxWeapons_003Ek__BackingField;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v375 @ rax_v167 (VampireSurvivors.Data.BgmType)+2CC]");
							if ((nint)0 != 0)
							{
								goto IL_2b56;
							}
						}
						bgmType2 = (playerOptions._003CSelectedLimitBreak_003Ek__BackingField ? BgmType.BGM_Library : BgmType.BGM_Forest);
					}
					else
					{
						bgmType2 = (BgmType)playerOptions._003CSelectedArcana_003Ek__BackingField;
					}
				}
				else
				{
					bgmType2 = playerOptions._003CSelectedBGM_003Ek__BackingField;
				}
				goto IL_2b56;
			}
		}
		goto IL_2504;
		IL_296d:
		BgmType bgmType3;
		Button component;
		UnityAction unityAction;
		if (bgmType3 != BgmType.BGM_Forest && (object)_HyperModeTickBox != null)
		{
			TickBoxUI hyperModeTickBox = _HyperModeTickBox;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v361 @ rax_v130 (VampireSurvivors.Data.BgmType)+4C]");
			hyperModeTickBox.InitialSet(b: false);
			bool flag4 = (object)_HyperModeTickBox == null;
			stats = (PlayerOptions)(object)_HyperModeTickBox;
			if (!flag4)
			{
				component = _HyperModeTickBox.GetComponent<Button>();
				bool flag5 = (object)component == null;
				stats = (PlayerOptions)(object)_HyperModeTickBox;
				if (!flag5)
				{
					unityAction = null;
					nint num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ r10_v35 (Il2CppMethodInfo)+8]");
					((Delegate)unityAction).method_ptr = (IntPtr)0;
					((Delegate)unityAction).method = (nint)__ldftn(StageSelectPage.ToggleHyper);
					((Delegate)unityAction).m_target = this;
					((Delegate)unityAction).method_code = (IntPtr)unityAction;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ r10_v35 (Il2CppMethodInfo)+4C]");
					object obj2 = (nint)0 >> 4;
					object obj3 = 1 & obj2;
					nint num3;
					if (obj3 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ r10_v35 (Il2CppMethodInfo)+52]");
						if ((nint)0 == 0)
						{
							num3 = unchecked((nint)6447293664L);
							goto IL_298a;
						}
					}
					((Delegate)unityAction).method_code = (IntPtr)((Delegate)unityAction).m_target;
					num3 = ((Delegate)unityAction).method_ptr;
					goto IL_298a;
				}
			}
		}
		goto IL_2504;
		IL_298a:
		((Delegate)unityAction).extra_arg = unchecked((nint)6447293568L);
		bool flag6 = component.m_OnClick == null;
		stats = (PlayerOptions)(object)unityAction;
		if (flag6)
		{
			goto IL_2504;
		}
		component.m_OnClick.AddListener(unityAction);
		Action action = null;
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4663 @ r9_v40 (Il2CppMethodInfo)+8]");
		((Delegate)action).method_ptr = (IntPtr)0;
		((Delegate)action).method = (nint)__ldftn(StageSelectPage.ToggleHyper);
		((Delegate)action).m_target = this;
		((Delegate)action).method_code = (IntPtr)action;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4663 @ r9_v40 (Il2CppMethodInfo)+4C]");
		object obj4 = (nint)0 >> 4;
		object obj5 = 1 & obj4;
		nint num5;
		if (obj5 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4663 @ r9_v40 (Il2CppMethodInfo)+52]");
			if ((nint)0 == 0)
			{
				num5 = unchecked((nint)6447293664L);
				goto IL_29cb;
			}
		}
		((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
		num5 = ((Delegate)action).method_ptr;
		goto IL_29cb;
		IL_2a0c:
		BgmType bgmType4;
		BgmType bgmType5;
		if (bgmType4 != BgmType.BGM_Forest && (object)_HurryModeTickBox != null)
		{
			TickBoxUI hurryModeTickBox = _HurryModeTickBox;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v365 @ rax_v152 (VampireSurvivors.Data.BgmType)+4E]");
			hurryModeTickBox.InitialSet(b: false);
			PlayerOptionsData playerOptions2 = (PlayerOptionsData)(object)_playerOptions;
			bool flag7 = _playerOptions == null;
			stats = (PlayerOptions)(object)_HurryModeTickBox;
			if (!flag7)
			{
				stats = (PlayerOptions)(object)_HurryModeTickBox;
				if (playerOptions2._003CSelectedBGM_003Ek__BackingField == BgmType.BGM_Forest)
				{
					if (playerOptions2._003CSelectedArcana_003Ek__BackingField == 0)
					{
						if (playerOptions2._003CSelectedMaxWeapons_003Ek__BackingField != 0)
						{
							bgmType5 = (BgmType)playerOptions2._003CSelectedMaxWeapons_003Ek__BackingField;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v367 @ rax_v155 (VampireSurvivors.Data.BgmType)+2CC]");
							if ((nint)0 != 0)
							{
								goto IL_2a4e;
							}
						}
						bgmType5 = (playerOptions2._003CSelectedLimitBreak_003Ek__BackingField ? BgmType.BGM_Library : BgmType.BGM_Forest);
					}
					else
					{
						bgmType5 = (BgmType)playerOptions2._003CSelectedArcana_003Ek__BackingField;
					}
				}
				else
				{
					bgmType5 = playerOptions2._003CSelectedBGM_003Ek__BackingField;
				}
				goto IL_2a4e;
			}
		}
		goto IL_2504;
		IL_27ed:
		PlayerOptionsData playerOptionsData;
		PlayerOptionsData playerOptionsData3;
		if (playerOptionsData != null)
		{
			stats = (PlayerOptions)(object)playerOptionsData._003CCollectedItems_003Ek__BackingField;
			if (playerOptionsData._003CCollectedItems_003Ek__BackingField != null)
			{
				bool hasRandomEvents;
				if (stats.PowerUpPurchased == null)
				{
					hasRandomEvents = false;
				}
				else
				{
					stats = (PlayerOptions)(object)stats.RunGoldUpdated;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
					object obj7 = default(object);
					object obj6 = obj7 - -1;
					bool flag8 = obj6 == null;
					hasRandomEvents = !flag8;
				}
				_hasRandomEvents = hasRandomEvents;
				PlayerOptionsData playerOptions3 = (PlayerOptionsData)(object)_playerOptions;
				if (_playerOptions != null)
				{
					if (playerOptions3._003CSelectedBGM_003Ek__BackingField == BgmType.BGM_Forest)
					{
						if (playerOptions3._003CSelectedArcana_003Ek__BackingField == 0)
						{
							if (playerOptions3._003CSelectedMaxWeapons_003Ek__BackingField != 0)
							{
								PlayerOptionsData playerOptionsData2 = (PlayerOptionsData)playerOptions3._003CSelectedMaxWeapons_003Ek__BackingField;
								if ((object)playerOptionsData2._003CSelectedAdventureType_003Ek__BackingField != null)
								{
									playerOptionsData3 = playerOptionsData2;
									goto IL_2891;
								}
							}
							playerOptionsData3 = (PlayerOptionsData)playerOptions3._003CSelectedLimitBreak_003Ek__BackingField;
						}
						else
						{
							playerOptionsData3 = (PlayerOptionsData)playerOptions3._003CSelectedArcana_003Ek__BackingField;
						}
					}
					else
					{
						playerOptionsData3 = (PlayerOptionsData)playerOptions3._003CSelectedBGM_003Ek__BackingField;
					}
					goto IL_2891;
				}
			}
		}
		goto IL_2504;
		IL_0463:
		int num6 = 1;
		goto IL_2664;
		IL_2664:
		_mazzoModeAvailable = (byte)num6 != 0;
		stats = _playerOptions;
		PlayerOptionsData playerOptionsData5;
		if (_playerOptions != null)
		{
			PlayerOptionsData config2 = _playerOptions.Config;
			if (config2 != null)
			{
				stats = (PlayerOptions)(object)config2._003CCollectedItems_003Ek__BackingField;
				if (config2._003CCollectedItems_003Ek__BackingField != null)
				{
					int limitBreakAvailable = ((Dictionary<StageType, List<StageData>>)(object)config2._003CCollectedItems_003Ek__BackingField).FindEntry(StageType.EX_WESTWOODS);
					_limitBreakAvailable = (byte)limitBreakAvailable != 0;
					stats = _playerOptions;
					if (_playerOptions != null)
					{
						PlayerOptionsData config3 = _playerOptions.Config;
						if (config3 != null)
						{
							stats = (PlayerOptions)(object)config3._003CCollectedItems_003Ek__BackingField;
							if (config3._003CCollectedItems_003Ek__BackingField != null)
							{
								int inverseModeAvailable = ((Dictionary<StageType, List<StageData>>)(object)config3._003CCollectedItems_003Ek__BackingField).FindEntry((StageType)50);
								_inverseModeAvailable = (byte)inverseModeAvailable != 0;
								stats = _playerOptions;
								if (_playerOptions != null)
								{
									PlayerOptionsData config4 = _playerOptions.Config;
									if (config4 != null)
									{
										stats = (PlayerOptions)(object)config4._003CCollectedItems_003Ek__BackingField;
										if (config4._003CCollectedItems_003Ek__BackingField != null)
										{
											int endlessModeAvailable = ((Dictionary<StageType, List<StageData>>)(object)config4._003CCollectedItems_003Ek__BackingField).FindEntry((StageType)51);
											_endlessModeAvailable = (byte)endlessModeAvailable != 0;
											PlayerOptionsData playerOptions4 = (PlayerOptionsData)(object)_playerOptions;
											if (_playerOptions != null)
											{
												if (playerOptions4._003CSelectedBGM_003Ek__BackingField == BgmType.BGM_Forest)
												{
													if (playerOptions4._003CSelectedArcana_003Ek__BackingField == 0)
													{
														if (playerOptions4._003CSelectedMaxWeapons_003Ek__BackingField != 0)
														{
															PlayerOptionsData playerOptionsData4 = (PlayerOptionsData)playerOptions4._003CSelectedMaxWeapons_003Ek__BackingField;
															if ((object)playerOptionsData4._003CSelectedAdventureType_003Ek__BackingField != null)
															{
																playerOptionsData5 = playerOptionsData4;
																goto IL_2749;
															}
														}
														playerOptionsData5 = (PlayerOptionsData)playerOptions4._003CSelectedLimitBreak_003Ek__BackingField;
													}
													else
													{
														playerOptionsData5 = (PlayerOptionsData)playerOptions4._003CSelectedArcana_003Ek__BackingField;
													}
												}
												else
												{
													playerOptionsData5 = (PlayerOptionsData)playerOptions4._003CSelectedBGM_003Ek__BackingField;
												}
												goto IL_2749;
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
		goto IL_2504;
		IL_29cb:
		((Delegate)action).extra_arg = unchecked((nint)6447293568L);
		_003CWaitRoutine_003Ed__89 obj8 = null;
		obj8._003C_003E1__state = 0;
		obj8.cb = action;
		Coroutine coroutine = StartCoroutine(obj8);
		PlayerOptionsData playerOptions5 = (PlayerOptionsData)(object)_playerOptions;
		bool flag9 = _playerOptions == null;
		stats = (PlayerOptions)(object)this;
		if (flag9)
		{
			goto IL_2504;
		}
		stats = (PlayerOptions)(object)this;
		if (playerOptions5._003CSelectedBGM_003Ek__BackingField == BgmType.BGM_Forest)
		{
			if (playerOptions5._003CSelectedArcana_003Ek__BackingField == 0)
			{
				if (playerOptions5._003CSelectedMaxWeapons_003Ek__BackingField != 0)
				{
					bgmType4 = (BgmType)playerOptions5._003CSelectedMaxWeapons_003Ek__BackingField;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v365 @ rax_v152 (VampireSurvivors.Data.BgmType)+2CC]");
					if ((nint)0 != 0)
					{
						goto IL_2a0c;
					}
				}
				bgmType4 = (playerOptions5._003CSelectedLimitBreak_003Ek__BackingField ? BgmType.BGM_Library : BgmType.BGM_Forest);
			}
			else
			{
				bgmType4 = (BgmType)playerOptions5._003CSelectedArcana_003Ek__BackingField;
			}
		}
		else
		{
			bgmType4 = playerOptions5._003CSelectedBGM_003Ek__BackingField;
		}
		goto IL_2a0c;
		IL_2749:
		if (playerOptionsData5 != null)
		{
			stats = (PlayerOptions)(object)playerOptionsData5._003CCollectedItems_003Ek__BackingField;
			if (playerOptionsData5._003CCollectedItems_003Ek__BackingField != null)
			{
				bool hasBanger;
				if (stats.PowerUpPurchased == null)
				{
					hasBanger = false;
				}
				else
				{
					stats = (PlayerOptions)(object)stats.RunGoldUpdated;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
					object obj10 = default(object);
					object obj9 = obj10 - -1;
					bool flag10 = obj9 == null;
					hasBanger = !flag10;
				}
				_hasBanger = hasBanger;
				PlayerOptionsData playerOptions6 = (PlayerOptionsData)(object)_playerOptions;
				if (_playerOptions != null)
				{
					if (playerOptions6._003CSelectedBGM_003Ek__BackingField == BgmType.BGM_Forest)
					{
						if (playerOptions6._003CSelectedArcana_003Ek__BackingField == 0)
						{
							if (playerOptions6._003CSelectedMaxWeapons_003Ek__BackingField != 0)
							{
								PlayerOptionsData playerOptionsData6 = (PlayerOptionsData)playerOptions6._003CSelectedMaxWeapons_003Ek__BackingField;
								if ((object)playerOptionsData6._003CSelectedAdventureType_003Ek__BackingField != null)
								{
									playerOptionsData = playerOptionsData6;
									goto IL_27ed;
								}
							}
							playerOptionsData = (PlayerOptionsData)playerOptions6._003CSelectedLimitBreak_003Ek__BackingField;
						}
						else
						{
							playerOptionsData = (PlayerOptionsData)playerOptions6._003CSelectedArcana_003Ek__BackingField;
						}
					}
					else
					{
						playerOptionsData = (PlayerOptionsData)playerOptions6._003CSelectedBGM_003Ek__BackingField;
					}
					goto IL_27ed;
				}
			}
		}
		goto IL_2504;
		IL_2891:
		BgmType bgmType6;
		if (playerOptionsData3 != null)
		{
			stats = (PlayerOptions)(object)playerOptionsData3._003CCollectedItems_003Ek__BackingField;
			if (playerOptionsData3._003CCollectedItems_003Ek__BackingField != null)
			{
				bool flag11;
				if (stats.PowerUpPurchased == null)
				{
					flag11 = false;
				}
				else
				{
					stats = (PlayerOptions)(object)stats.RunGoldUpdated;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
					object obj12 = default(object);
					object obj11 = obj12 - -1;
					bool flag12 = obj11 == null;
					flag11 = !flag12;
				}
				_hasRandomLevelUps = flag11;
				if (_hasRandomEvents)
				{
					flag11 = true;
				}
				if ((object)this != null)
				{
					_hasRandomOptions = flag11;
					PlayerOptionsData playerOptions7 = (PlayerOptionsData)(object)_playerOptions;
					if (_playerOptions != null)
					{
						if (playerOptions7._003CSelectedBGM_003Ek__BackingField == BgmType.BGM_Forest)
						{
							if (playerOptions7._003CSelectedArcana_003Ek__BackingField == 0)
							{
								if (playerOptions7._003CSelectedMaxWeapons_003Ek__BackingField != 0)
								{
									bgmType6 = (BgmType)playerOptions7._003CSelectedMaxWeapons_003Ek__BackingField;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v359 @ rax_v127 (VampireSurvivors.Data.BgmType)+2CC]");
									if ((nint)0 != 0)
									{
										goto IL_292b;
									}
								}
								bgmType6 = (playerOptions7._003CSelectedLimitBreak_003Ek__BackingField ? BgmType.BGM_Library : BgmType.BGM_Forest);
							}
							else
							{
								bgmType6 = (BgmType)playerOptions7._003CSelectedArcana_003Ek__BackingField;
							}
						}
						else
						{
							bgmType6 = playerOptions7._003CSelectedBGM_003Ek__BackingField;
						}
						goto IL_292b;
					}
				}
			}
		}
		goto IL_2504;
		IL_2549:
		stats = _playerOptions;
		if (_playerOptions != null)
		{
			PlayerOptionsData config5 = _playerOptions.Config;
			if (config5 != null && config5._003CUnlockedHypers_003Ek__BackingField != null)
			{
				List<StageType>.Enumerator enumerator = default(List<StageType>.Enumerator);
				while (true)
				{
					bool flag13 = enumerator.MoveNext();
					bool flag14 = !flag13;
					if (flag14)
					{
						break;
					}
					int num7 = ((Dictionary<System.Int32Enum, object>)(object)availableStages).FindEntry((System.Int32Enum)0);
					if (!flag14)
					{
						object obj13 = ((Dictionary<System.Int32Enum, object>)(object)availableStages).get_Item((System.Int32Enum)0);
						if (obj13 == null)
						{
							throw new NullReferenceException();
						}
						List<StageData> list = ((Dictionary<StageType, List<StageData>>)obj13).get_Item(StageType.FOREST);
						if (list == null)
						{
							throw new NullReferenceException();
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1527 @ rax_v454 (System.Collections.Generic.List`1<VampireSurvivors.Data.Stage.StageData>)+A0]");
						object obj14 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1527 @ rax_v454 (System.Collections.Generic.List`1<VampireSurvivors.Data.Stage.StageData>)+A0]");
						if ((nint)0 == 0)
						{
							throw new NullReferenceException();
						}
						_ = 1;
					}
				}
				stats = _playerOptions;
				if (_playerOptions != null)
				{
					PlayerOptionsData config6 = _playerOptions.Config;
					if (config6 != null)
					{
						stats = (PlayerOptions)(object)config6._003CCollectedItems_003Ek__BackingField;
						if (config6._003CCollectedItems_003Ek__BackingField != null)
						{
							int hurryModeAvailable = ((Dictionary<StageType, List<StageData>>)(object)config6._003CCollectedItems_003Ek__BackingField).FindEntry(StageType.FOSCARI);
							_hurryModeAvailable = (byte)hurryModeAvailable != 0;
							stats = _playerOptions;
							if (_playerOptions != null)
							{
								PlayerOptionsData config7 = _playerOptions.Config;
								if (config7 != null)
								{
									stats = (PlayerOptions)(object)config7._003CCollectedItems_003Ek__BackingField;
									if (config7._003CCollectedItems_003Ek__BackingField != null)
									{
										StageType stageType2 = StageType.FOSCARI2;
										if (((Dictionary<StageType, List<StageData>>)(object)config7._003CCollectedItems_003Ek__BackingField).FindEntry(StageType.FOSCARI2) != 0)
										{
											goto IL_0463;
										}
										stats = _playerOptions;
										if (_playerOptions != null)
										{
											PlayerOptionsData config8 = _playerOptions.Config;
											if (config8 != null)
											{
												stats = (PlayerOptions)(object)config8._003CCollectedItems_003Ek__BackingField;
												if (config8._003CCollectedItems_003Ek__BackingField != null)
												{
													num6 = ((Dictionary<StageType, List<StageData>>)(object)config8._003CCollectedItems_003Ek__BackingField).FindEntry((StageType)75);
													if (num6 != 0)
													{
														goto IL_0463;
													}
													goto IL_2664;
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
		goto IL_2504;
		IL_1d40:
		GameObject gameObject;
		StageItemUI component2 = gameObject.GetComponent<StageItemUI>();
		bool flag15 = (object)component2 == null;
		stats = (PlayerOptions)(object)_Stats;
		if (!flag15)
		{
			bool flag16 = (object)_Stats == null;
			stats = (PlayerOptions)(object)_Stats;
			if (!flag16)
			{
				_Stats.SetStage(component2._stage, component2._003CType_003Ek__BackingField, _playerOptions);
				bool flag17 = (object)_StageRandomPanel == null;
				stats = (PlayerOptions)(object)_StageRandomPanel;
				if (!flag17)
				{
					_StageRandomPanel.SetStage(component2._stage, component2._003CType_003Ek__BackingField);
					List<StageItemUI> list2 = new List<StageItemUI>();
					List<GameObject> spawned = _spawned;
					bool flag18 = _spawned == null;
					stats = (PlayerOptions)(object)list2;
					if (!flag18)
					{
						List<GameObject>.Enumerator enumerator2 = default(List<GameObject>.Enumerator);
						while (enumerator2.MoveNext())
						{
							StageItemUI component3 = ((GameObject)null).GetComponent<StageItemUI>();
							bool flag19 = list2 == null;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5855 @ rax_v192 (System.Collections.Generic.List`1<VampireSurvivors.UI.StageItemUI>)+1C]");
							_ = (nint)0 + (nint)1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5855 @ rax_v192 (System.Collections.Generic.List`1<VampireSurvivors.UI.StageItemUI>)+10]");
							object obj15 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5855 @ rax_v192 (System.Collections.Generic.List`1<VampireSurvivors.UI.StageItemUI>)+10]");
							bool flag20 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5855 @ rax_v192 (System.Collections.Generic.List`1<VampireSurvivors.UI.StageItemUI>)+18]");
							nint num8 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2365 @ rcx_v232 (System.Object)+18]");
							if (num8 >= 0)
							{
								((List<object>)(object)list2).AddWithResize((object)component3);
								spawned = (List<GameObject>)(object)component3;
								continue;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5855 @ rax_v192 (System.Collections.Generic.List`1<VampireSurvivors.UI.StageItemUI>)+18]");
							object obj16 = (nint)0 + (nint)1;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							spawned = (List<GameObject>)(object)component3;
						}
						Func<StageItemUI, int> keySelector = _003C_003Ec._003C_003E9__84_0;
						if (_003C_003Ec._003C_003E9__84_0 == null)
						{
							Func<StageItemUI, int> func = (_003C_003Ec._003C_003E9__84_0 = delegate(StageItemUI x)
							{
								//IL_0064: Expected I4, but got O
								if ((object)x != null)
								{
									StageData stage = x._stage;
									if (x._stage != null)
									{
										return stage._003Corder_003Ek__BackingField;
									}
								}
								NullReferenceException ex = new NullReferenceException();
								return (int)ex;
							});
							nint num9 = (nint)typeof(_003C_003Ec);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6021 @ rax_v278 (Il2CppClass<VampireSurvivors.UI.StageSelectPage+<>c>)+B8]");
							spawned = (List<GameObject>)((nint)0 + (nint)40);
							keySelector = func;
						}
						IOrderedEnumerable<StageItemUI> orderedEnumerable = Enumerable.OrderBy(list2, keySelector);
						bool flag21 = orderedEnumerable == null;
						stats = (PlayerOptions)(object)list2;
						if (!flag21)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
							object obj17 = default(object);
							PlayerOptionsData playerOptionsData7 = (PlayerOptionsData)(&obj17);
							object obj24 = default(object);
							object obj31 = default(object);
							Dictionary<StageType, List<StageData>> dictionary = default(Dictionary<StageType, List<StageData>>);
							object obj32 = default(object);
							while (true)
							{
								bool flag22 = obj17 == null;
								nint num10 = (nint)obj17;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ r10_v37 (Il2CppClass<System.Object>)+12E]");
								if ((nint)0 >= (nint)0)
								{
									goto IL_2002;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ r10_v37 (Il2CppClass<System.Object>)+B0]");
								object obj18 = 0;
								StageType stageType3 = StageType.FOREST;
								while (true)
								{
									object obj19 = (int)stageType3 + (int)stageType3;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3036 @ r8_v68+v6140 @ rax_v272*8]");
									if (0 == (nint)typeof(IEnumerator))
									{
										break;
									}
									stageType3++;
									StageType num11 = stageType3;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ r10_v37 (Il2CppClass<System.Object>)+12E]");
									if ((nint)num11 < (nint)0)
									{
										continue;
									}
									goto IL_2002;
								}
								object obj20 = (int)stageType3 + (int)stageType3;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3036 @ r8_v68+8+v6196 @ rcx_v221*8]");
								object obj21 = (nint)0 << 4;
								object obj22 = obj21 + 312;
								object obj23 = obj22 + num10;
								goto IL_2df2;
								IL_2df2:
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v6201 @ rdx_v100] (should have been resolved before IL gen)");
								if (obj24 == null)
								{
									break;
								}
								bool flag23 = obj17 == null;
								nint num12 = (nint)obj17;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2544 @ r10_v41 (Il2CppClass<System.Object>)+12E]");
								object obj25;
								object obj30;
								if ((nint)0 < (nint)0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2544 @ r10_v41 (Il2CppClass<System.Object>)+B0]");
									obj25 = 0;
									StageType stageType4 = StageType.FOREST;
									while (true)
									{
										object obj26 = (int)stageType4 + (int)stageType4;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2561 @ r8_v88+v6256 @ rax_v267*8]");
										if (0 == (nint)typeof(IEnumerator<StageItemUI>))
										{
											break;
										}
										stageType4++;
										StageType num13 = stageType4;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2544 @ r10_v41 (Il2CppClass<System.Object>)+12E]");
										if ((nint)num13 < (nint)0)
										{
											continue;
										}
										goto IL_20bb;
									}
									object obj27 = (int)stageType4 + (int)stageType4;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2561 @ r8_v88+8+v6326 @ rcx_v215*8]");
									object obj28 = (nint)0 << 4;
									object obj29 = obj28 + 312;
									obj30 = obj29 + num12;
									goto IL_2e19;
								}
								goto IL_20bb;
								IL_20bb:
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
								obj25 = 0;
								obj30 = obj31;
								goto IL_2e19;
								IL_2e19:
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v6331 @ rdx_v134] (should have been resolved before IL gen)");
								bool flag24 = dictionary == null;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2976 @ rax_v248 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.StageType, System.Collections.Generic.List`1<VampireSurvivors.Data.Stage.StageData>>)+10]");
								bool flag25 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2976 @ rax_v248 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.StageType, System.Collections.Generic.List`1<VampireSurvivors.Data.Stage.StageData>>)+10]");
								IntPtr gcHandlePtr = Component.get_transform_Injected((IntPtr)0);
								Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
								bool flag26 = (object)transform == null;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2806 @ rax_v253 (UnityEngine.Transform)+10]");
								bool flag27 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2806 @ rax_v253 (UnityEngine.Transform)+10]");
								Transform.SetAsLastSibling_Injected((IntPtr)0);
								continue;
								IL_2002:
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
								obj18 = 0;
								obj23 = obj32;
								goto IL_2df2;
							}
							if (playerOptionsData7 != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
							}
							stats = (PlayerOptions)(object)_spawned;
							if (_spawned != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v428 @ rcx_v93 (VampireSurvivors.Objects.PlayerOptions)+1C]");
								_ = (nint)0 + (nint)1;
								stats.PowerUpPurchased = null;
								bool flag28 = (nint)stats.PowerUpPurchased <= 0;
								nint num14 = (nint)typeof(IEnumerator);
								if (!flag28)
								{
									Array.Clear((Array)(object)stats.RunGoldUpdated, 0, (int)stats.PowerUpPurchased);
									num14 = unchecked((nint)null);
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
								PlayerOptionsData playerOptionsData8 = (PlayerOptionsData)(&obj17);
								object obj39 = default(object);
								object obj46 = default(object);
								object obj47 = default(object);
								object obj48 = default(object);
								while (true)
								{
									bool flag29 = obj17 == null;
									nint num15 = (nint)obj17;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3534 @ r10_v39 (Il2CppClass<System.Object>)+12E]");
									if ((nint)0 >= (nint)0)
									{
										goto IL_22b3;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3534 @ r10_v39 (Il2CppClass<System.Object>)+B0]");
									object obj33 = 0;
									StageType stageType5 = StageType.FOREST;
									while (true)
									{
										object obj34 = (int)stageType5 + (int)stageType5;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3551 @ r8_v73+v6444 @ rax_v243*8]");
										if (0 == (nint)typeof(IEnumerator))
										{
											break;
										}
										stageType5++;
										StageType num16 = stageType5;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3534 @ r10_v39 (Il2CppClass<System.Object>)+12E]");
										if ((nint)num16 < (nint)0)
										{
											continue;
										}
										goto IL_22b3;
									}
									object obj35 = (int)stageType5 + (int)stageType5;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3551 @ r8_v73+8+v6510 @ rcx_v192*8]");
									object obj36 = (nint)0 << 4;
									object obj37 = obj36 + 312;
									object obj38 = obj37 + num15;
									goto IL_2f68;
									IL_2f68:
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v6515 @ rdx_v107] (should have been resolved before IL gen)");
									if (obj39 == null)
									{
										break;
									}
									bool flag30 = obj17 == null;
									nint num17 = (nint)obj17;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3189 @ r10_v40 (Il2CppClass<System.Object>)+12E]");
									if ((nint)0 >= (nint)0)
									{
										goto IL_236c;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3189 @ r10_v40 (Il2CppClass<System.Object>)+B0]");
									object obj40 = 0;
									StageType stageType6 = StageType.FOREST;
									while (true)
									{
										object obj41 = (int)stageType6 + (int)stageType6;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3208 @ r8_v76+v6578 @ rax_v238*8]");
										if (0 == (nint)typeof(IEnumerator<StageItemUI>))
										{
											break;
										}
										stageType6++;
										StageType num18 = stageType6;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3189 @ r10_v40 (Il2CppClass<System.Object>)+12E]");
										if ((nint)num18 < (nint)0)
										{
											continue;
										}
										goto IL_236c;
									}
									object obj42 = (int)stageType6 + (int)stageType6;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3208 @ r8_v76+8+v6634 @ rcx_v186*8]");
									object obj43 = (nint)0 << 4;
									object obj44 = obj43 + 312;
									object obj45 = obj44 + num17;
									goto IL_2f8f;
									IL_236c:
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
									obj40 = 0;
									obj45 = obj46;
									goto IL_2f8f;
									IL_2f8f:
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v6639 @ rdx_v113] (should have been resolved before IL gen)");
									List<object> spawned2 = (List<object>)(object)_spawned;
									bool flag31 = obj47 == null;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3487 @ rax_v221 (System.Object)+10]");
									bool flag32 = (nint)0 == 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3487 @ rax_v221 (System.Object)+10]");
									IntPtr gcHandlePtr2 = Component.get_gameObject_Injected((IntPtr)0);
									GameObject item = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr2);
									bool flag33 = _spawned == null;
									int version = spawned2._version + 1;
									spawned2._version = version;
									object items = spawned2._items;
									bool flag34 = spawned2._items == null;
									int size = spawned2._size;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3294 @ rcx_v177 (System.Object)+18]");
									if ((nint)size >= (nint)0)
									{
										((List<object>)(object)_spawned).AddWithResize((object)item);
										continue;
									}
									int size2 = spawned2._size + 1;
									spawned2._size = size2;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
									continue;
									IL_22b3:
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
									obj33 = 0;
									obj38 = obj48;
									goto IL_2f68;
								}
								if (playerOptionsData8 != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
								}
								GenerateNavigation();
								return;
							}
						}
					}
				}
			}
		}
		goto IL_2504;
		IL_292b:
		if (bgmType6 != BgmType.BGM_Forest && (object)_MazzoModeTickBox != null)
		{
			TickBoxUI mazzoModeTickBox = _MazzoModeTickBox;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v359 @ rax_v127 (VampireSurvivors.Data.BgmType)+4F]");
			mazzoModeTickBox.InitialSet(b: false);
			PlayerOptionsData playerOptions8 = (PlayerOptionsData)(object)_playerOptions;
			bool flag35 = _playerOptions == null;
			stats = (PlayerOptions)(object)_MazzoModeTickBox;
			if (!flag35)
			{
				stats = (PlayerOptions)(object)_MazzoModeTickBox;
				if (playerOptions8._003CSelectedBGM_003Ek__BackingField == BgmType.BGM_Forest)
				{
					if (playerOptions8._003CSelectedArcana_003Ek__BackingField == 0)
					{
						if (playerOptions8._003CSelectedMaxWeapons_003Ek__BackingField != 0)
						{
							bgmType3 = (BgmType)playerOptions8._003CSelectedMaxWeapons_003Ek__BackingField;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v361 @ rax_v130 (VampireSurvivors.Data.BgmType)+2CC]");
							if ((nint)0 != 0)
							{
								goto IL_296d;
							}
						}
						bgmType3 = (playerOptions8._003CSelectedLimitBreak_003Ek__BackingField ? BgmType.BGM_Library : BgmType.BGM_Forest);
					}
					else
					{
						bgmType3 = (BgmType)playerOptions8._003CSelectedArcana_003Ek__BackingField;
					}
				}
				else
				{
					bgmType3 = playerOptions8._003CSelectedBGM_003Ek__BackingField;
				}
				goto IL_296d;
			}
		}
		goto IL_2504;
		IL_2ad2:
		BgmType bgmType7;
		if (bgmType7 != BgmType.BGM_Forest && (object)_EndlessModeTickBox != null)
		{
			TickBoxUI endlessModeTickBox = _EndlessModeTickBox;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v371 @ rax_v161 (VampireSurvivors.Data.BgmType)+52]");
			endlessModeTickBox.InitialSet(b: false);
			PlayerOptionsData playerOptions9 = (PlayerOptionsData)(object)_playerOptions;
			bool flag36 = _playerOptions == null;
			stats = (PlayerOptions)(object)_EndlessModeTickBox;
			if (!flag36)
			{
				stats = (PlayerOptions)(object)_EndlessModeTickBox;
				if (playerOptions9._003CSelectedBGM_003Ek__BackingField == BgmType.BGM_Forest)
				{
					if (playerOptions9._003CSelectedArcana_003Ek__BackingField == 0)
					{
						if (playerOptions9._003CSelectedMaxWeapons_003Ek__BackingField != 0)
						{
							bgmType = (BgmType)playerOptions9._003CSelectedMaxWeapons_003Ek__BackingField;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v373 @ rax_v164 (VampireSurvivors.Data.BgmType)+2CC]");
							if ((nint)0 != 0)
							{
								goto IL_2b14;
							}
						}
						bgmType = (playerOptions9._003CSelectedLimitBreak_003Ek__BackingField ? BgmType.BGM_Library : BgmType.BGM_Forest);
					}
					else
					{
						bgmType = (BgmType)playerOptions9._003CSelectedArcana_003Ek__BackingField;
					}
				}
				else
				{
					bgmType = playerOptions9._003CSelectedBGM_003Ek__BackingField;
				}
				goto IL_2b14;
			}
		}
		goto IL_2504;
		IL_2a90:
		BgmType bgmType8;
		if (bgmType8 != BgmType.BGM_Forest && (object)_InverseModeTickBox != null)
		{
			TickBoxUI inverseModeTickBox = _InverseModeTickBox;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v369 @ rax_v158 (VampireSurvivors.Data.BgmType)+51]");
			inverseModeTickBox.InitialSet(b: false);
			PlayerOptionsData playerOptions10 = (PlayerOptionsData)(object)_playerOptions;
			bool flag37 = _playerOptions == null;
			stats = (PlayerOptions)(object)_InverseModeTickBox;
			if (!flag37)
			{
				stats = (PlayerOptions)(object)_InverseModeTickBox;
				if (playerOptions10._003CSelectedBGM_003Ek__BackingField == BgmType.BGM_Forest)
				{
					if (playerOptions10._003CSelectedArcana_003Ek__BackingField == 0)
					{
						if (playerOptions10._003CSelectedMaxWeapons_003Ek__BackingField != 0)
						{
							bgmType7 = (BgmType)playerOptions10._003CSelectedMaxWeapons_003Ek__BackingField;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v371 @ rax_v161 (VampireSurvivors.Data.BgmType)+2CC]");
							if ((nint)0 != 0)
							{
								goto IL_2ad2;
							}
						}
						bgmType7 = (playerOptions10._003CSelectedLimitBreak_003Ek__BackingField ? BgmType.BGM_Library : BgmType.BGM_Forest);
					}
					else
					{
						bgmType7 = (BgmType)playerOptions10._003CSelectedArcana_003Ek__BackingField;
					}
				}
				else
				{
					bgmType7 = playerOptions10._003CSelectedBGM_003Ek__BackingField;
				}
				goto IL_2ad2;
			}
		}
		goto IL_2504;
		IL_2a4e:
		if (bgmType5 != BgmType.BGM_Forest && (object)_LimitBreakTickBox != null)
		{
			TickBoxUI limitBreakTickBox = _LimitBreakTickBox;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v367 @ rax_v155 (VampireSurvivors.Data.BgmType)+50]");
			limitBreakTickBox.InitialSet(b: false);
			PlayerOptionsData playerOptions11 = (PlayerOptionsData)(object)_playerOptions;
			bool flag38 = _playerOptions == null;
			stats = (PlayerOptions)(object)_LimitBreakTickBox;
			if (!flag38)
			{
				stats = (PlayerOptions)(object)_LimitBreakTickBox;
				if (playerOptions11._003CSelectedBGM_003Ek__BackingField == BgmType.BGM_Forest)
				{
					if (playerOptions11._003CSelectedArcana_003Ek__BackingField == 0)
					{
						if (playerOptions11._003CSelectedMaxWeapons_003Ek__BackingField != 0)
						{
							bgmType8 = (BgmType)playerOptions11._003CSelectedMaxWeapons_003Ek__BackingField;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v369 @ rax_v158 (VampireSurvivors.Data.BgmType)+2CC]");
							if ((nint)0 != 0)
							{
								goto IL_2a90;
							}
						}
						bgmType8 = (playerOptions11._003CSelectedLimitBreak_003Ek__BackingField ? BgmType.BGM_Library : BgmType.BGM_Forest);
					}
					else
					{
						bgmType8 = (BgmType)playerOptions11._003CSelectedArcana_003Ek__BackingField;
					}
				}
				else
				{
					bgmType8 = playerOptions11._003CSelectedBGM_003Ek__BackingField;
				}
				goto IL_2a90;
			}
		}
		goto IL_2504;
		IL_2504:
		throw new NullReferenceException();
		IL_2b56:
		if (bgmType2 != BgmType.BGM_Forest)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v375 @ rax_v167 (VampireSurvivors.Data.BgmType)+1A8]");
			stats = (PlayerOptions)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v375 @ rax_v167 (VampireSurvivors.Data.BgmType)+1A8]");
			if ((nint)0 != 0)
			{
				bool hasToggles = (((nint)stats.PowerUpPurchased > 0 || _hyperModeAvailable || _hurryModeAvailable || _mazzoModeAvailable || _limitBreakAvailable || _inverseModeAvailable || _endlessModeAvailable) ? true : false);
				_hasToggles = hasToggles;
				float num19 = default(float);
				if (!_hasToggles)
				{
					bool flag39 = (object)_InfoPanel == null;
					stats = (PlayerOptions)(object)_InfoPanel;
					if (!flag39)
					{
						GameObject gameObject2 = _InfoPanel.gameObject;
						bool flag40 = (object)gameObject2 == null;
						stats = (PlayerOptions)(object)_InfoPanel;
						if (!flag40)
						{
							gameObject2.SetActive(value: false);
							bool flag41 = (object)_scroll == null;
							stats = (PlayerOptions)(object)_scroll;
							if (!flag41)
							{
								Vector2 offsetMin = _scroll.offsetMin;
								_scroll.offsetMin = (Vector2)num19;
								bool flag42 = (object)_SliderRect == null;
								stats = (PlayerOptions)(object)_scroll;
								if (!flag42)
								{
									Vector2 sizeDelta = _SliderRect.sizeDelta;
									object obj49 = default(object);
									float num20 = (float)obj49 + 180f;
									_SliderRect.sizeDelta = (Vector2)num19;
									float num21 = num19;
									Vector2 vector = (Vector2)0;
									stats = (PlayerOptions)(object)_SliderRect;
									goto IL_1849;
								}
							}
						}
					}
				}
				else
				{
					bool flag43 = (object)_InfoPanel == null;
					stats = (PlayerOptions)(object)_InfoPanel;
					if (!flag43)
					{
						GameObject gameObject3 = _InfoPanel.gameObject;
						bool flag44 = (object)gameObject3 == null;
						stats = (PlayerOptions)(object)_InfoPanel;
						if (!flag44)
						{
							gameObject3.SetActive(value: true);
							bool flag45 = (object)_scroll == null;
							stats = (PlayerOptions)(object)_scroll;
							if (!flag45)
							{
								Vector2 offsetMin2 = _scroll.offsetMin;
								_scroll.offsetMin = (Vector2)num19;
								float num21 = 200f;
								Vector2 vector = (Vector2)num19;
								stats = (PlayerOptions)(object)_scroll;
								goto IL_1849;
							}
						}
					}
				}
			}
		}
		goto IL_2504;
		IL_1849:
		PlayerOptionsData stageRandomPanel = (PlayerOptionsData)(object)_StageRandomPanel;
		if ((object)_StageRandomPanel != null)
		{
			bool flag46 = stageRandomPanel._003CsaveDate_003Ek__BackingField == null;
			IntPtr intPtr = Component.get_gameObject_Injected((IntPtr)stageRandomPanel._003CsaveDate_003Ek__BackingField);
			GameObject gameObject4 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(intPtr);
			bool flag47 = (object)gameObject4 == null;
			stats = (PlayerOptions)(nint)intPtr;
			if (!flag47)
			{
				gameObject4.SetActive(_hasRandomOptions);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18695F8A0");
				MultiplayerManager multiplayerManager = default(MultiplayerManager);
				bool flag48 = multiplayerManager == null;
				stats = (PlayerOptions)(object)gameObject4;
				if (!flag48)
				{
					int playerCount = multiplayerManager.GetPlayerCount();
					bool active;
					if (playerCount > 1)
					{
						active = true;
						stats = (PlayerOptions)(object)multiplayerManager;
					}
					else
					{
						active = multiplayerManager.IsOnlineMultiplayer;
						stats = (PlayerOptions)(object)multiplayerManager;
					}
					if ((object)_SharePassivesPanel != null)
					{
						_SharePassivesPanel.SetActive(active);
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AD50");
						bool flag49 = true;
						StageType stageType7 = StageType.FOREST;
						Dictionary<StageType, List<StageData>>.Enumerator enumerator3 = default(Dictionary<StageType, List<StageData>>.Enumerator);
						object obj50 = default(object);
						while (enumerator3.MoveNext())
						{
							bool flag50 = obj50 == null;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5644 @ stack_-90+18]");
							bool flag51 = (nint)0 <= (nint)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5644 @ stack_-90+10]");
							object obj51 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5644 @ stack_-90+10]");
							bool flag52 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1772 @ rdx_v162+18]");
							bool flag53 = (nint)0 <= (nint)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1772 @ rdx_v162+20]");
							nint num22 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5601 @ rax_v180+10]");
							GameObject gameObject5 = CreateStageItem((StageData)num22, StageType.FOREST, flag49 ? 1 : 0);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5601 @ rax_v180+10]");
							if ((nint)0 == (nint)stageType)
							{
								bool flag54 = (object)gameObject5 == null;
								Selectable component4 = gameObject5.GetComponent<Selectable>();
								bool flag55 = (object)component4 == null;
								component4.Select();
								stageType7 = (StageType)gameObject5;
							}
							flag49 = (byte)((flag49 ? 1u : 0u) + 1u) != 0;
						}
						bool flag56 = stageType7 == StageType.FOREST;
						stats = (PlayerOptions)(object)typeof(UnityEngine.Object);
						if (!flag56)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5606 @ r14_v54 (VampireSurvivors.Data.StageType)+10]");
							bool flag57 = (nint)0 == 0;
							stats = (PlayerOptions)(object)typeof(UnityEngine.Object);
							if (!flag57)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5606 @ r14_v54 (VampireSurvivors.Data.StageType)+10]");
								bool flag58 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5606 @ r14_v54 (VampireSurvivors.Data.StageType)+10]");
								object obj52 = GameObject.get_activeInHierarchy_Injected((IntPtr)0);
								bool flag59 = obj52 == null;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5606 @ r14_v54 (VampireSurvivors.Data.StageType)+10]");
								stats = (PlayerOptions)0;
								if (!flag59)
								{
									Selectable component5 = ((GameObject)stageType7).GetComponent<Selectable>();
									bool flag60 = (object)component5 == null;
									stats = (PlayerOptions)stageType7;
									if (!flag60)
									{
										component5.Select();
										gameObject = (GameObject)stageType7;
										goto IL_1d40;
									}
									goto IL_2504;
								}
							}
						}
						List<GameObject> spawned3 = _spawned;
						if (_spawned != null)
						{
							bool flag61 = spawned3._size <= 0;
							stats = (PlayerOptions)(object)spawned3._items;
							if (spawned3._items != null)
							{
								bool flag62 = (nint)stats.PowerUpPurchased <= 0;
								bool flag63 = stats.PowerUpsRefunded == null;
								stats = (PlayerOptions)(object)stats.PowerUpsRefunded;
								if (!flag63)
								{
									Selectable component6 = ((GameObject)(object)stats.PowerUpsRefunded).GetComponent<Selectable>();
									bool flag64 = (object)component6 == null;
									stats = (PlayerOptions)(object)stats.PowerUpsRefunded;
									if (!flag64)
									{
										component6.Select();
										List<GameObject> spawned4 = _spawned;
										bool flag65 = _spawned == null;
										stats = (PlayerOptions)(object)component6;
										if (!flag65)
										{
											bool flag66 = spawned4._size <= 0;
											GameObject[] items2 = spawned4._items;
											bool flag67 = spawned4._items == null;
											stats = (PlayerOptions)(object)component6;
											if (!flag67)
											{
												bool flag68 = items2.Length <= 0;
												stats = (PlayerOptions)(object)items2[0];
												bool flag69 = (object)items2[0] == null;
												gameObject = items2[0];
												if (!flag69)
												{
													goto IL_1d40;
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
		goto IL_2504;
	}

	public static Dictionary<StageType, List<StageData>> GetAvailableStages(DataManager data, PlayerOptions playerOptions)
	{
		//IL_03bf: Expected O, but got I
		//IL_0d52: Expected I, but got O
		//IL_03cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d2: Expected O, but got Unknown
		//IL_055d: Expected O, but got I
		//IL_059a: Expected O, but got I
		//IL_0703: Expected O, but got I
		//IL_0740: Expected O, but got I
		//IL_0755: Expected O, but got I
		//IL_0a74: Expected O, but got I
		//IL_0ab1: Expected O, but got I
		//IL_07f8: Expected O, but got I
		//IL_0ac6: Expected O, but got I
		//IL_0835: Expected O, but got I
		//IL_084a: Expected O, but got I
		//IL_0872: Expected O, but got I
		//IL_0882: Expected O, but got I
		//IL_0b69: Expected O, but got I
		//IL_08dc: Expected O, but got I
		//IL_0ba6: Expected O, but got I
		//IL_0bbb: Expected O, but got I
		//IL_0be3: Expected O, but got I
		//IL_0bf3: Expected O, but got I
		//IL_0c4d: Expected O, but got I
		Dictionary<StageType, List<StageData>> dictionary = new Dictionary<StageType, List<StageData>>();
		if (AdventureManager._003CIsInAdventureMode_003Ek__BackingField)
		{
			Dictionary<StageType, List<StageData>> adventureStageData = data._adventureStageData;
		}
		else
		{
			Dictionary<StageType, List<StageData>> convertedStages = data.GetConvertedStages();
			Dictionary<StageType, List<StageData>> adventureStageData = convertedStages;
		}
		Dictionary<StageType, List<StageData>>.Enumerator enumerator = default(Dictionary<StageType, List<StageData>>.Enumerator);
		if (enumerator.MoveNext())
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
			System.Int32Enum int32Enum = (System.Int32Enum)0;
			System.Int32Enum int32Enum2 = (System.Int32Enum)0;
			throw new NullReferenceException();
		}
		if (playerOptions._onlineClientWithRunDataConfig == null)
		{
			if (playerOptions._hostGameConfig == null)
			{
				PlayerOptionsData currentAdventureSaveData;
				if (playerOptions._currentAdventureSaveData != null)
				{
					currentAdventureSaveData = playerOptions._currentAdventureSaveData;
					if ((object)currentAdventureSaveData._003CSelectedAdventureType_003Ek__BackingField != null)
					{
						goto IL_0e04;
					}
				}
				currentAdventureSaveData = playerOptions._mainGameConfig;
			}
			else
			{
				PlayerOptionsData currentAdventureSaveData = playerOptions._hostGameConfig;
			}
		}
		else
		{
			PlayerOptionsData currentAdventureSaveData = playerOptions._onlineClientWithRunDataConfig;
		}
		goto IL_0e04;
		IL_0e04:
		object obj = default(object);
		object obj2 = default(object);
		object obj4 = default(object);
		while (true)
		{
			if (obj != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ stack_-B0_v26+1C]");
				if (obj2 == null)
				{
					object obj3 = obj4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ stack_-B0_v26+18]");
					if ((nint)obj3 < 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ stack_-B0_v26+10]");
						object obj5 = 0;
						object obj6 = obj4 + 1;
						bool flag = dictionary == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1311 @ rsi_v40+20+v1268 @ stack_-A8_v24*4]");
						int num = ((Dictionary<System.Int32Enum, object>)(object)dictionary).FindEntry((System.Int32Enum)0);
						obj4 = obj6;
						if (!flag)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1311 @ rsi_v40+20+v1926 @ rcx_v81*4]");
							object obj7 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).get_Item((System.Int32Enum)0);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1311 @ rsi_v40+20+v1926 @ rcx_v81*4]");
							List<StageData> list = ((Dictionary<StageType, List<StageData>>)obj7).get_Item(StageType.FOREST);
							_ = 1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1311 @ rsi_v40+20+v1926 @ rcx_v81*4]");
							object obj8 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).get_Item((System.Int32Enum)0);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1311 @ rsi_v40+20+v1926 @ rcx_v81*4]");
							List<StageData> list2 = ((Dictionary<StageType, List<StageData>>)obj8).get_Item(StageType.FOREST);
							_ = 0;
							obj4 = obj6;
						}
						continue;
					}
					break;
				}
				break;
			}
			throw new NullReferenceException();
		}
		bool flag2 = obj == null;
		nint num2 = 0;
		Dictionary<StageType, List<StageData>> result;
		PlayerOptionsData playerOptionsData;
		if (!flag2)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ stack_-B0_v26+1C]");
			if (obj2 == null)
			{
				int num3 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).FindEntry((System.Int32Enum)15);
				bool flag3 = num3 < 0;
				result = dictionary;
				if (flag3)
				{
					goto IL_0e44;
				}
				object obj9 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).get_Item((System.Int32Enum)15);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v641 @ rax_v81 (System.Object)+18]");
				if ((nint)0 <= (nint)0)
				{
					goto IL_0c8c;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v641 @ rax_v81 (System.Object)+10]");
				object obj10 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v642 @ rax_v84+18]");
				if ((nint)0 <= (nint)0)
				{
					goto IL_0e49;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v642 @ rax_v84+20]");
				object obj11 = 0;
				_ = 1;
				if (playerOptions._onlineClientWithRunDataConfig == null)
				{
					if (playerOptions._hostGameConfig == null)
					{
						if (playerOptions._currentAdventureSaveData != null)
						{
							PlayerOptionsData currentAdventureSaveData2 = playerOptions._currentAdventureSaveData;
							if ((object)currentAdventureSaveData2._003CSelectedAdventureType_003Ek__BackingField != null)
							{
								playerOptionsData = currentAdventureSaveData2;
								goto IL_0ea9;
							}
						}
						playerOptionsData = playerOptions._mainGameConfig;
					}
					else
					{
						playerOptionsData = playerOptions._hostGameConfig;
					}
				}
				else
				{
					playerOptionsData = playerOptions._onlineClientWithRunDataConfig;
				}
				goto IL_0ea9;
			}
			System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
			num2 = unchecked((nint)null);
		}
		throw new NullReferenceException();
		IL_0ea9:
		List<ItemType> list3 = playerOptionsData._003CCollectedItems_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v271 @ rcx_v51 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj12 = default(object);
			if ((nint)obj12 != -1)
			{
				object obj13 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).get_Item((System.Int32Enum)15);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v645 @ rax_v121 (System.Object)+18]");
				if ((nint)0 <= (nint)0)
				{
					goto IL_0c8c;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v645 @ rax_v121 (System.Object)+10]");
				object obj14 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v646 @ rax_v122+18]");
				if ((nint)0 > (nint)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v646 @ rax_v122+20]");
					object obj15 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v273 @ rcx_v71+198]");
					object obj16 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v274 @ rcx_v72+18]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
						object obj17 = default(object);
						if ((nint)obj17 != -1)
						{
							goto IL_0ebb;
						}
					}
					object obj18 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).get_Item((System.Int32Enum)15);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v647 @ rax_v124 (System.Object)+18]");
					if ((nint)0 <= (nint)0)
					{
						goto IL_0c8c;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v647 @ rax_v124 (System.Object)+10]");
					object obj19 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v648 @ rax_v125+18]");
					if ((nint)0 > (nint)0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v648 @ rax_v125+20]");
						object obj20 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v276 @ rcx_v75+198]");
						List<System.Int32Enum> list4 = (List<System.Int32Enum>)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v277 @ rcx_v76 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
						_ = (nint)0 + (nint)1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v277 @ rcx_v76 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
						object obj21 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v277 @ rcx_v76 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
						object obj22 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v277 @ rcx_v76 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
						nint num4 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v240 @ r9_v37+18]");
						if (num4 >= 0)
						{
							list4.AddWithResize((System.Int32Enum)51);
						}
						else
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v277 @ rcx_v76 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
							object obj23 = (nint)0 + (nint)1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v277 @ rcx_v76 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
							nint num5 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v240 @ r9_v37+18]");
							if (num5 >= 0)
							{
								goto IL_0e49;
							}
							_ = 51;
						}
						goto IL_0ebb;
					}
				}
				goto IL_0e49;
			}
		}
		goto IL_0ebb;
		IL_0ebb:
		PlayerOptionsData playerOptionsData2;
		if (playerOptions._onlineClientWithRunDataConfig == null)
		{
			if (playerOptions._hostGameConfig == null)
			{
				if (playerOptions._currentAdventureSaveData != null)
				{
					PlayerOptionsData currentAdventureSaveData3 = playerOptions._currentAdventureSaveData;
					if ((object)currentAdventureSaveData3._003CSelectedAdventureType_003Ek__BackingField != null)
					{
						playerOptionsData2 = currentAdventureSaveData3;
						goto IL_0ee0;
					}
				}
				playerOptionsData2 = playerOptions._mainGameConfig;
			}
			else
			{
				playerOptionsData2 = playerOptions._hostGameConfig;
			}
		}
		else
		{
			playerOptionsData2 = playerOptions._onlineClientWithRunDataConfig;
		}
		goto IL_0ee0;
		IL_0e8b:
		Dictionary<StageType, List<StageData>> dictionary2 = Stage6Checks(dictionary, playerOptions);
		result = dictionary2;
		goto IL_0e44;
		IL_0c8c:
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		throw new IndexOutOfRangeException();
		IL_0e44:
		return result;
		IL_0ee0:
		List<ItemType> list5 = playerOptionsData2._003CCollectedItems_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v279 @ rcx_v55 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj24 = default(object);
			if ((nint)obj24 != -1)
			{
				object obj25 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).get_Item((System.Int32Enum)15);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v651 @ rax_v99 (System.Object)+18]");
				if ((nint)0 <= (nint)0)
				{
					goto IL_0c8c;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v651 @ rax_v99 (System.Object)+10]");
				object obj26 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v652 @ rax_v100+18]");
				if ((nint)0 > (nint)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v652 @ rax_v100+20]");
					object obj27 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v281 @ rcx_v60+198]");
					object obj28 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v282 @ rcx_v61+18]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
						object obj29 = default(object);
						if ((nint)obj29 != -1)
						{
							goto IL_0e8b;
						}
					}
					object obj30 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).get_Item((System.Int32Enum)15);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v653 @ rax_v102 (System.Object)+18]");
					if ((nint)0 <= (nint)0)
					{
						goto IL_0c8c;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v653 @ rax_v102 (System.Object)+10]");
					object obj31 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v654 @ rax_v103+18]");
					if ((nint)0 > (nint)0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v654 @ rax_v103+20]");
						object obj32 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v284 @ rcx_v64+198]");
						List<System.Int32Enum> list6 = (List<System.Int32Enum>)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v285 @ rcx_v65 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
						_ = (nint)0 + (nint)1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v285 @ rcx_v65 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
						object obj33 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v285 @ rcx_v65 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
						object obj34 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v285 @ rcx_v65 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
						nint num6 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v244 @ r9_v33+18]");
						if (num6 >= 0)
						{
							list6.AddWithResize((System.Int32Enum)50);
						}
						else
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v285 @ rcx_v65 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
							object obj35 = (nint)0 + (nint)1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v285 @ rcx_v65 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
							nint num7 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v244 @ r9_v33+18]");
							if (num7 >= 0)
							{
								goto IL_0e49;
							}
							_ = 50;
						}
						goto IL_0e8b;
					}
				}
				goto IL_0e49;
			}
		}
		goto IL_0e8b;
		IL_0e49:
		return (Dictionary<StageType, List<StageData>>)(object)new IndexOutOfRangeException();
	}

	private unsafe void GenerateNavigation()
	{
		//IL_0a45: Expected O, but got I4
		//IL_0aab: Expected O, but got I4
		//IL_084b: Expected O, but got I
		//IL_0861: Expected O, but got Ref
		//IL_0de6: Expected O, but got I4
		//IL_0942: Expected O, but got I4
		//IL_09c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_09c8: Expected O, but got Unknown
		//IL_08d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_08dc: Expected O, but got Unknown
		//IL_0993: Unknown result type (might be due to invalid IL or missing references)
		//IL_0998: Expected O, but got Unknown
		//IL_0b70: Expected O, but got Ref
		//IL_0b16->IL0daf: Incompatible stack heights: 1 vs 0
		//IL_0b44->IL0daf: Incompatible stack heights: 1 vs 0
		//IL_0e41->IL0daf: Incompatible stack heights: 1 vs 0
		//IL_0b94->IL0daf: Incompatible stack heights: 1 vs 0
		//IL_0bb9->IL0cb8: Incompatible stack heights: 1 vs 0
		//IL_0be8->IL0daf: Incompatible stack heights: 1 vs 0
		//IL_0c29->IL0daf: Incompatible stack heights: 1 vs 0
		//IL_0c4e->IL0cb8: Incompatible stack heights: 1 vs 0
		//IL_0c7d->IL0daf: Incompatible stack heights: 1 vs 0
		List<GameObject> spawned = _spawned;
		List<GameObject> spawned2;
		if (_spawned != null)
		{
			spawned2 = _spawned;
			Selectable selectable = null;
			List<GameObject>.Enumerator enumerator = default(List<GameObject>.Enumerator);
			if (enumerator.MoveNext())
			{
				GameObject gameObject = null;
				throw new NullReferenceException();
			}
			List<Selectable> availableOptions = _availableOptions;
			if (_availableOptions != null)
			{
				int version = availableOptions._version + 1;
				availableOptions._version = version;
				availableOptions._size = 0;
				if (availableOptions._size > 0)
				{
					Array.Clear(availableOptions._items, 0, availableOptions._size);
					spawned = null;
				}
				if (!_hasRandomOptions)
				{
					goto IL_0420;
				}
				if (!_hasRandomEvents)
				{
					goto IL_0376;
				}
				StageRandomPanel stageRandomPanel = _StageRandomPanel;
				if ((object)_StageRandomPanel != null && (object)stageRandomPanel._RandomEventsTickBox != null)
				{
					Selectable component = stageRandomPanel._RandomEventsTickBox.GetComponent<Selectable>();
					if (_availableOptions != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA11F0");
						goto IL_0376;
					}
				}
			}
		}
		goto IL_0daf;
		IL_049b:
		if (!_hurryModeAvailable)
		{
			goto IL_0516;
		}
		if ((object)_HurryModeTickBox != null)
		{
			Selectable component2 = _HurryModeTickBox.GetComponent<Selectable>();
			if (_availableOptions != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA11F0");
				goto IL_0516;
			}
		}
		goto IL_0daf;
		IL_0591:
		if (!_limitBreakAvailable)
		{
			goto IL_060c;
		}
		if ((object)_LimitBreakTickBox != null)
		{
			Selectable component3 = _LimitBreakTickBox.GetComponent<Selectable>();
			if (_availableOptions != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA11F0");
				goto IL_060c;
			}
		}
		goto IL_0daf;
		IL_0daf:
		throw new NullReferenceException();
		IL_0516:
		if (!_mazzoModeAvailable)
		{
			goto IL_0591;
		}
		if ((object)_MazzoModeTickBox != null)
		{
			Selectable component4 = _MazzoModeTickBox.GetComponent<Selectable>();
			if (_availableOptions != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA11F0");
				goto IL_0591;
			}
		}
		goto IL_0daf;
		IL_0376:
		if (!_hasRandomLevelUps)
		{
			goto IL_0420;
		}
		StageRandomPanel stageRandomPanel2 = _StageRandomPanel;
		if ((object)_StageRandomPanel != null && (object)stageRandomPanel2._RandomLevelsTickBox != null)
		{
			Selectable component5 = stageRandomPanel2._RandomLevelsTickBox.GetComponent<Selectable>();
			if (_availableOptions != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA11F0");
				goto IL_0420;
			}
		}
		goto IL_0daf;
		IL_0420:
		if (!_hyperModeAvailable)
		{
			goto IL_049b;
		}
		if ((object)_HyperModeTickBox != null)
		{
			Selectable component6 = _HyperModeTickBox.GetComponent<Selectable>();
			if (_availableOptions != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA11F0");
				goto IL_049b;
			}
		}
		goto IL_0daf;
		IL_0687:
		if (!_endlessModeAvailable)
		{
			goto IL_0702;
		}
		if ((object)_EndlessModeTickBox != null)
		{
			Selectable component7 = _EndlessModeTickBox.GetComponent<Selectable>();
			if (_availableOptions != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA11F0");
				goto IL_0702;
			}
		}
		goto IL_0daf;
		IL_060c:
		if (!_inverseModeAvailable)
		{
			goto IL_0687;
		}
		if ((object)_InverseModeTickBox != null)
		{
			Selectable component8 = _InverseModeTickBox.GetComponent<Selectable>();
			if (_availableOptions != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA11F0");
				goto IL_0687;
			}
		}
		goto IL_0daf;
		IL_0702:
		if (_availableOptions != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA11F0");
			List<Selectable> availableOptions2 = _availableOptions;
			bool flag = _availableOptions == null;
			Selectable selectable2 = null;
			GameObject gameObject2 = null;
			Selectable selectable3 = null;
			if (!flag)
			{
				List<GameObject>.Enumerator enumerator2 = default(List<GameObject>.Enumerator);
				Selectable origin = default(Selectable);
				Selectable selectable6 = default(Selectable);
				Selectable origin2 = default(Selectable);
				Selectable target = default(Selectable);
				List<Selectable>.Enumerator enumerator3 = default(List<Selectable>.Enumerator);
				while (true)
				{
					if ((nint)selectable3 < availableOptions2._size)
					{
						List<Selectable> availableOptions3 = _availableOptions;
						if (_availableOptions == null)
						{
							break;
						}
						if ((nint)selectable2 < availableOptions3._size)
						{
							Selectable[] items = availableOptions3._items;
							if (availableOptions3._items == null)
							{
								break;
							}
							Selectable selectable4 = items[(object)selectable2];
							if ((object)items[(object)selectable2] == null)
							{
								break;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v287 @ rcx_v55 (UnityEngine.UI.Selectable)+48]");
							gameObject2 = (GameObject)0;
							items[(object)selectable2].navigation = (Navigation)(&enumerator2);
							bool flag2 = (nint)selectable2 <= 0;
							Selectable selectable5 = null;
							if (!flag2)
							{
								if (_availableOptions == null)
								{
									break;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
								if (_availableOptions == null)
								{
									break;
								}
								object obj = selectable2 - 1;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
								SetNavigationLeft(origin, selectable6);
								spawned = null;
								selectable5 = selectable6;
							}
							List<Selectable> availableOptions4 = _availableOptions;
							if (_availableOptions == null)
							{
								break;
							}
							object obj2 = availableOptions4._size - 1;
							if (System.Runtime.CompilerServices.Unsafe.As<Selectable, UIntPtr>(ref selectable2) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2))
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
								if (_availableOptions == null)
								{
									break;
								}
								object obj3 = selectable2 + 1;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
								SetNavigationRight(origin2, target);
								spawned = null;
							}
							selectable2 = (Selectable)(selectable2 + 1);
							availableOptions2 = _availableOptions;
							if (_availableOptions == null)
							{
								break;
							}
							selectable3 = selectable2;
							continue;
						}
					}
					else
					{
						List<Selectable> availableOptions5 = _availableOptions;
						List<Selectable> availableOptions6 = _availableOptions;
						if (_availableOptions == null)
						{
							break;
						}
						object obj4 = availableOptions6._size - 1;
						if ((nint)obj4 < availableOptions5._size)
						{
							Selectable[] items2 = availableOptions5._items;
							if (availableOptions5._items == null)
							{
								break;
							}
							object obj5 = availableOptions6._size - 1;
							SetNavigationLeft(_SelectButton, items2[obj5]);
							Selectable sharePassivesPanel = (Selectable)(object)_SharePassivesPanel;
							if ((object)_SharePassivesPanel == null)
							{
								break;
							}
							bool flag3 = ((UnityEngine.Object)sharePassivesPanel).m_CachedPtr == (IntPtr)0;
							object obj6 = GameObject.get_activeInHierarchy_Injected(((UnityEngine.Object)sharePassivesPanel).m_CachedPtr);
							if (obj6 == null)
							{
								goto IL_0c9f;
							}
							if ((object)_SharePassivesBox == null)
							{
								break;
							}
							Selectable component9 = _SharePassivesBox.GetComponent<Selectable>();
							if (_availableOptions == null)
							{
								break;
							}
							while (enumerator3.MoveNext())
							{
								SetNavigationUp(null, component9);
							}
							if ((object)component9 == null)
							{
								break;
							}
							component9.navigation = (Navigation)(&spawned2);
							List<Selectable> availableOptions7 = _availableOptions;
							if (_availableOptions == null)
							{
								break;
							}
							if (availableOptions7._size > 0)
							{
								Selectable[] items3 = availableOptions7._items;
								if (availableOptions7._items == null)
								{
									break;
								}
								SetNavigationDown(component9, items3[0]);
								List<Selectable> availableOptions8 = _availableOptions;
								if (_availableOptions == null)
								{
									break;
								}
								if (availableOptions8._size > 0)
								{
									Selectable[] items4 = availableOptions8._items;
									if (availableOptions8._items == null)
									{
										break;
									}
									SetNavigationRight(component9, items4[0]);
									goto IL_0c9f;
								}
							}
						}
					}
					System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
					throw new NullReferenceException();
					IL_0c9f:
					RectTransform component10 = GetComponent<RectTransform>();
					LayoutRebuilder.ForceRebuildLayoutImmediate(component10);
					return;
				}
			}
		}
		goto IL_0daf;
	}

	private unsafe GameObject CreateStageItem(StageData stage, StageType type, int index)
	{
		//IL_0123: Expected O, but got Ref
		GameObject gameObject = UnityEngine.Object.Instantiate(stagePrefab, container);
		if ((object)gameObject != null)
		{
			StageItemUI component = gameObject.GetComponent<StageItemUI>();
			if (stage != null && stage._003CframeName_003Ek__BackingField != null)
			{
				string text = stage._003CframeName_003Ek__BackingField.Replace("_icon", "");
				if (text != null)
				{
					string text2 = text.Replace("_unlock", "");
					if (stage._003CuiFrame_003Ek__BackingField == null || stage._003CuiTexture_003Ek__BackingField == null)
					{
						object obj = default(object);
						string text3 = ((Enum)(&obj)).ToString();
						string message = "Missing uiFrame and/or uiTexture from stage data: " + text3;
						Debug.LogError(message);
					}
					Sprite sprite = SpriteManager.GetSprite(stage._003CuiFrame_003Ek__BackingField, stage._003CuiTexture_003Ek__BackingField);
					if ((object)component != null)
					{
						Sprite mapSprite = default(Sprite);
						StageType stageType = default(StageType);
						int index2 = default(int);
						bool hideDescriptionText = default(bool);
						component.SetData(_playerOptions, this, stage, mapSprite, stageType, index2, hideDescriptionText);
						if (_spawned != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180497F80");
							return gameObject;
						}
					}
				}
			}
		}
		return (GameObject)(object)new NullReferenceException();
	}

	private void WaitAndDo(Action cb)
	{
		_003CWaitRoutine_003Ed__89 obj = null;
		obj._003C_003E1__state = 0;
		obj.cb = cb;
		Coroutine coroutine = StartCoroutine(obj);
	}

	private static IEnumerator WaitRoutine(Action cb)
	{
		_003CWaitRoutine_003Ed__89 obj = null;
		obj._003C_003E1__state = 0;
		obj.cb = cb;
		return obj;
	}

	private void EnableInfoPanelNavigation()
	{
		GenerateNavigation();
	}

	private void SetNavigationPhase1()
	{
		EnableFirstPhaseGroup();
		DisableSecondPhaseGroup();
		_selectionPhase = SelectionPhase.PHASE1;
	}

	private void SetNavigationPhase2()
	{
		DisableFirstPhaseGroup();
		EnableSecondPhaseGroup();
		_selectionPhase = SelectionPhase.PHASE2;
	}

	private unsafe void DisableFirstPhaseGroup()
	{
		//IL_00c4: Expected O, but got I4
		//IL_00cd: Expected O, but got I4
		//IL_0111: Expected I, but got O
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Expected O, but got Unknown
		//IL_01ef: Expected O, but got Ref
		if (_phase1Disabled)
		{
			return;
		}
		bool flag = _spawned == null;
		StageSelectPage stageSelectPage = this;
		if (!flag)
		{
			List<GameObject> spawned = _spawned;
			List<GameObject>.Enumerator enumerator = default(List<GameObject>.Enumerator);
			if (enumerator.MoveNext())
			{
				GameObject gameObject = null;
				throw new NullReferenceException();
			}
			bool flag2 = (object)_selectedStage == null;
			stageSelectPage = (StageSelectPage)(object)_selectedStage;
			if (!flag2)
			{
				_selectedStage.MakeEnabled();
				bool flag3 = (object)_SongPanel == null;
				stageSelectPage = (StageSelectPage)(object)_selectedStage;
				if (!flag3)
				{
					Graphic[] componentsInChildren = _SongPanel.GetComponentsInChildren<Graphic>();
					bool flag4 = componentsInChildren == null;
					stageSelectPage = (StageSelectPage)(object)_SongPanel;
					if (!flag4)
					{
						object obj = 0;
						object obj2 = 0;
						while (true)
						{
							if ((nint)obj2 < componentsInChildren.Length)
							{
								stageSelectPage = (StageSelectPage)(object)componentsInChildren[obj];
								if ((object)componentsInChildren[obj] == null)
								{
									break;
								}
								nint num = (nint)stageSelectPage;
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v600 @ rax_v30 (Il2CppClass<VampireSurvivors.UI.StageSelectPage>)+2A8] (should have been resolved before IL gen)");
								obj++;
								obj2 = obj;
								continue;
							}
							if ((object)_scroll == null)
							{
								break;
							}
							Transform transform = _scroll.transform;
							if ((object)transform == null)
							{
								break;
							}
							Transform parent = transform.parent;
							if ((object)parent == null)
							{
								break;
							}
							Image component = parent.GetComponent<Image>();
							if ((object)component == null)
							{
								break;
							}
							Color color = component.color;
							component.color = (Color)(&spawned);
							_phase1Disabled = true;
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void EnableFirstPhaseGroup()
	{
		//IL_0211: Expected O, but got Ref
		//IL_00dc: Expected I, but got O
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Expected O, but got Unknown
		//IL_0176: Expected O, but got Ref
		//IL_02d8->IL0182: Incompatible stack heights: 1 vs 0
		//IL_0332->IL0182: Incompatible stack heights: 2 vs 0
		//IL_0164->IL0182: Incompatible stack heights: 2 vs 0
		bool flag = _spawned == null;
		Component component = this;
		if (!flag)
		{
			List<GameObject> spawned = _spawned;
			List<GameObject>.Enumerator enumerator = default(List<GameObject>.Enumerator);
			if (enumerator.MoveNext())
			{
				GameObject gameObject = null;
				throw new NullReferenceException();
			}
			bool flag2 = (object)_SongPanel == null;
			component = (Component)(&enumerator);
			if (!flag2)
			{
				Graphic[] componentsInChildren = _SongPanel.GetComponentsInChildren<Graphic>();
				bool flag3 = componentsInChildren == null;
				component = _SongPanel;
				if (!flag3)
				{
					object obj = null;
					object obj2 = null;
					component = _SongPanel;
					while (true)
					{
						if ((nint)obj2 < componentsInChildren.Length)
						{
							if ((nint)obj < componentsInChildren.Length)
							{
								component = componentsInChildren[obj];
								if ((object)componentsInChildren[obj] == null)
								{
									break;
								}
								nint num = (nint)component;
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v581 @ rax_v50 (Il2CppClass<UnityEngine.Component>)+2A8] (should have been resolved before IL gen)");
								obj++;
								obj2 = obj;
								continue;
							}
							throw new IndexOutOfRangeException();
						}
						object scroll = _scroll;
						if ((object)_scroll == null)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rbx_v11 (System.Object)+10]");
						bool flag4 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rbx_v11 (System.Object)+10]");
						IntPtr gcHandlePtr = Component.get_transform_Injected((IntPtr)0);
						Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
						if ((object)transform == null)
						{
							break;
						}
						bool flag5 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
						IntPtr parent_Injected = Transform.GetParent_Injected(((UnityEngine.Object)transform).m_CachedPtr);
						Transform transform2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(parent_Injected);
						if ((object)transform2 == null)
						{
							break;
						}
						Image component2 = transform2.GetComponent<Image>();
						if ((object)component2 == null)
						{
							break;
						}
						component2.color = (Color)(&spawned);
						_phase1Disabled = false;
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void DisableSecondPhaseGroup()
	{
		//IL_00ba: Expected O, but got Ref
		//IL_00d7: Expected O, but got I4
		//IL_00e7: Expected O, but got I
		//IL_00f0: Expected O, but got I4
		//IL_0157: Expected O, but got Ref
		//IL_010b: Expected O, but got Ref
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Expected O, but got Unknown
		//IL_0129: Expected O, but got I
		//IL_01fd: Expected O, but got I4
		//IL_020d: Expected O, but got I
		//IL_0216: Expected O, but got I4
		//IL_0177: Expected O, but got Ref
		//IL_0180: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Expected O, but got Unknown
		if (!_phase2Disabled)
		{
			_MazzoModeTickBox.MakeVisuallyDisabled();
			_HyperModeTickBox.MakeVisuallyDisabled();
			_HurryModeTickBox.MakeVisuallyDisabled();
			_LimitBreakTickBox.MakeVisuallyDisabled();
			_InverseModeTickBox.MakeVisuallyDisabled();
			_EndlessModeTickBox.MakeVisuallyDisabled();
			_SharePassivesBox.MakeVisuallyDisabled();
			Transform transform = _HyperModeTickBox.transform;
			Transform parent = transform.parent;
			Image component = parent.GetComponent<Image>();
			object obj = default(object);
			component.color = (Color)(&obj);
			Graphic[] componentsInChildren = _SelectButton.GetComponentsInChildren<Graphic>();
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12250]");
			obj = 0;
			object obj3 = 0;
			while ((nint)obj3 < componentsInChildren.Length)
			{
				componentsInChildren[obj2].color = (Color)(&obj);
				obj2++;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12250]");
				obj = 0;
				obj3 = obj2;
			}
			Image component2 = _SharePassivesPanel.GetComponent<Image>();
			component2.color = (Color)(&obj);
			Graphic[] componentsInChildren2 = _StageRandomPanel.GetComponentsInChildren<Graphic>();
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12250]");
			obj = 0;
			object obj5 = 0;
			while ((nint)obj5 < componentsInChildren2.Length)
			{
				componentsInChildren2[obj4].color = (Color)(&obj);
				obj4++;
				obj5 = obj4;
			}
			_phase2Disabled = true;
		}
	}

	private unsafe void EnableSecondPhaseGroup()
	{
		//IL_00bb: Expected O, but got Ref
		//IL_00e1: Expected O, but got Ref
		//IL_00fe: Expected O, but got I4
		//IL_010e: Expected O, but got I
		//IL_0117: Expected O, but got I4
		//IL_01f9: Expected O, but got I4
		//IL_0202: Expected O, but got I4
		//IL_0132: Expected O, but got Ref
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0140: Expected O, but got Unknown
		//IL_0150: Expected O, but got I
		//IL_0199: Expected O, but got Ref
		//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a7: Expected O, but got Unknown
		_MazzoModeTickBox.MakeVisuallyEnabled();
		_HyperModeTickBox.MakeVisuallyEnabled();
		_HurryModeTickBox.MakeVisuallyEnabled();
		_LimitBreakTickBox.MakeVisuallyEnabled();
		_InverseModeTickBox.MakeVisuallyEnabled();
		_EndlessModeTickBox.MakeVisuallyEnabled();
		_SharePassivesBox.MakeVisuallyEnabled();
		Transform transform = _HyperModeTickBox.transform;
		Transform parent = transform.parent;
		Image component = parent.GetComponent<Image>();
		object obj = default(object);
		component.color = (Color)(&obj);
		Image component2 = _SharePassivesPanel.GetComponent<Image>();
		component2.color = (Color)(&obj);
		Graphic[] componentsInChildren = _SelectButton.GetComponentsInChildren<Graphic>();
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
		obj = 0;
		object obj3 = 0;
		while ((nint)obj3 < componentsInChildren.Length)
		{
			componentsInChildren[obj2].color = (Color)(&obj);
			obj2++;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
			obj = 0;
			obj3 = obj2;
		}
		Graphic[] componentsInChildren2 = _StageRandomPanel.GetComponentsInChildren<Graphic>();
		object obj4 = 0;
		object obj5 = 0;
		while ((nint)obj5 < componentsInChildren2.Length)
		{
			componentsInChildren2[obj4].color = (Color)(&obj);
			obj4++;
			obj5 = obj4;
		}
		_phase2Disabled = false;
	}

	public unsafe void SwitchInput(UIHelper.ActiveInputType input)
	{
		//IL_013a: Expected O, but got I4
		//IL_0125: Expected O, but got Ref
		bool flag = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
		object obj = Behaviour.get_enabled_Injected(((UnityEngine.Object)this).m_CachedPtr);
		if (obj == null)
		{
			return;
		}
		UIHelper.ActiveInputType activeInput = UIHelper.ActiveInput;
		if (activeInput != UIHelper.ActiveInputType.MOUSE)
		{
			if (_selectionPhase != SelectionPhase.PHASE1)
			{
				DisableFirstPhaseGroup();
				EnableSecondPhaseGroup();
				_selectionPhase = SelectionPhase.PHASE2;
			}
			else
			{
				EnableFirstPhaseGroup();
				DisableSecondPhaseGroup();
				_selectionPhase = SelectionPhase.PHASE1;
			}
			return;
		}
		EnableFirstPhaseGroup();
		EnableSecondPhaseGroup();
		if (_selectionPhase == SelectionPhase.PHASE1)
		{
			Transform transform = _HyperModeTickBox.transform;
			Transform parent = transform.parent;
			Image component = parent.GetComponent<Image>();
			object obj2 = default(object);
			component.color = (Color)(&obj2);
		}
	}

	public StageSelectPage()
	{
		List<GameObject> spawned = new List<GameObject>();
		_spawned = spawned;
		_availableOptions = new List<Selectable>();
		base._002Ector();
	}
}
