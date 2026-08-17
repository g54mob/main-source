using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Cysharp.Threading.Tasks;
using DarkTonic.MasterAudio;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using VampireSurvivors.Achievements;
using VampireSurvivors.App.Framework;
using VampireSurvivors.App.Scripts.Framework;
using VampireSurvivors.App.Scripts.Framework.Adventures;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.DLC;
using VampireSurvivors.Framework.Saves;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects;
using VampireSurvivors.Objects.Stages;
using VampireSurvivors.Tools;
using Zenject;

namespace VampireSurvivors.UI;

public class OptionsController : MonoBehaviour
{
	public enum OptionsTabType
	{
		QUICKACCESS,
		DISPLAY,
		SOUND,
		GAMEPLAY,
		USER,
		ABOUT,
		INGAME,
		CHEATS,
		MULTIPLAYER
	}

	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Func<Resolution, Resolution> _003C_003E9__51_0;

		public static Comparison<Resolution> _003C_003E9__51_1;

		public static Func<ISelectableUI, bool> _003C_003E9__64_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal unsafe Resolution _003CInitialize_003Eb__51_0(Resolution resolution)
		{
			//IL_000e: Expected O, but got I4
			//IL_0009: Expected native int or pointer, but got O
			//IL_001b: Expected native int or pointer, but got O
			//IL_002d: Expected native int or pointer, but got O
			Resolution resolution2 = default(Resolution);
			((Resolution*)(nint)resolution2)->m_RefreshRate = (RefreshRate)0;
			((Resolution*)(nint)resolution2)->m_Width = resolution.m_Width;
			((Resolution*)(nint)resolution2)->m_Height = resolution.m_Height;
			return resolution2;
		}

		internal int _003CInitialize_003Eb__51_1(Resolution x, Resolution y)
		{
			//IL_0017: Expected O, but got I4
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			//IL_0025: Expected O, but got Unknown
			//IL_0032: Unknown result type (might be due to invalid IL or missing references)
			//IL_0037: Expected O, but got Unknown
			//IL_0044: Unknown result type (might be due to invalid IL or missing references)
			//IL_0049: Expected I4, but got Unknown
			object obj = x.m_Width - y.m_Width;
			object obj2 = obj * 40000;
			object obj3 = obj2 - y.m_Height;
			return obj3 + x.m_Height;
		}

		internal bool _003CGenerateNavigation_003Eb__64_0(ISelectableUI ui)
		{
			if (ui != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9BB80");
				Component component = default(Component);
				if ((object)component != null)
				{
					GameObject gameObject = component.gameObject;
					if ((object)gameObject != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v10 (UnityEngine.GameObject)+10]");
						bool flag = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: Type: Il2CppMethodInfo (should have been resolved before IL gen)");
						Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 87 ConditionalJump @-1, v147 @ ZF_v9 (System.Boolean) --- -1 Nop");
						/*Error: End of method reached without returning.*/;
					}
				}
			}
			throw new NullReferenceException();
		}
	}

	private sealed class _003C_003Ec__DisplayClass150_0
	{
		public OptionsController _003C_003E4__this;

		public Action onComplete;

		internal void _003CShowDeleteAdventureDataPopup_003Eb__0()
		{
			OptionsController optionsController = _003C_003E4__this;
			optionsController._shouldDeleteAdventureData = true;
			Action action = onComplete;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v12.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}

		internal void _003CShowDeleteAdventureDataPopup_003Eb__1()
		{
			OptionsController optionsController = _003C_003E4__this;
			optionsController._shouldDeleteAdventureData = false;
			Action action = onComplete;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v12.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	private sealed class _003C_003Ec__DisplayClass52_0
	{
		public OptionsTabType v;

		public OptionsController _003C_003E4__this;

		internal void _003CAddTabs_003Eb__0()
		{
			_003C_003E4__this.SelectTab(v);
		}
	}

	private sealed class _003CWaitAndFormatWidth_003Ed__65(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public OptionsController _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_0062: Expected I4, but got I8
			//IL_0204: Expected O, but got I
			//IL_022d: Expected O, but got I4
			//IL_016d: Expected O, but got I
			//IL_0186: Expected O, but got I4
			//IL_028e->IL0279: Incompatible stack heights: 1 vs 0
			//IL_024d->IL024d: Incompatible stack heights: 2 vs 0
			object obj = default(object);
			object obj2 = default(object);
			Vector2 vector = default(Vector2);
			while (true)
			{
				OptionsController optionsController = _003C_003E4__this;
				if (_003C_003E1__state == 0)
				{
					_003C_003E1__state = -1;
					_003C_003E2__current = null;
					_003C_003E1__state = 1;
					return true;
				}
				if (_003C_003E1__state != 1)
				{
					break;
				}
				_003C_003E1__state = -1;
				Transform transform = optionsController._Content.transform;
				Transform parent = transform.parent;
				Transform parent2 = parent.parent;
				RectTransform component = parent2.GetComponent<RectTransform>();
				Vector2 sizeDelta = optionsController._Content.sizeDelta;
				Vector2 sizeDelta2 = component.sizeDelta;
				bool num;
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2))
				{
					Vector2 offsetMax = component.offsetMax;
					component.offsetMax = vector;
					VerticalLayoutGroup component2 = optionsController._Content.GetComponent<VerticalLayoutGroup>();
					RectOffset padding = ((LayoutGroup)component2).m_Padding;
					IntPtr ptr = padding.m_Ptr;
					bool flag = padding.m_Ptr == (IntPtr)0;
					num = flag;
					object obj3 = 0;
					object obj4 = obj;
					Vector2 vector2 = vector;
					object obj5 = 0;
				}
				else
				{
					Vector2 offsetMax2 = component.offsetMax;
					component.offsetMax = vector;
					VerticalLayoutGroup component3 = optionsController._Content.GetComponent<VerticalLayoutGroup>();
					RectOffset padding2 = ((LayoutGroup)component3).m_Padding;
					IntPtr ptr = padding2.m_Ptr;
					bool flag2 = padding2.m_Ptr == (IntPtr)0;
					num = flag2;
					object obj3 = 0;
					bool flag3 = (nint)0 != 0;
					object obj4 = obj;
					Vector2 vector2 = vector;
					object obj5 = 0;
					if (!flag3)
					{
						bool flag4 = (nint)0 == 0;
						continue;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v633 @ rax_v23 (should have been resolved before IL gen)");
				break;
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

	private sealed class _003CWaitAndReselect_003Ed__153(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public OptionsController _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_0062: Expected I4, but got I8
			OptionsController optionsController = _003C_003E4__this;
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
				List<ISelectableUI> spawnedElements = optionsController._spawnedElements;
				if (spawnedElements._size <= 0)
				{
					System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
					bool result = default(bool);
					return result;
				}
				ISelectableUI[] items = spawnedElements._items;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9BB80");
				object obj2 = default(object);
				object obj = obj2;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v119 @ r8_v6+398] (should have been resolved before IL gen)");
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

	private List<OptionsTabType> _OptionsConfig;

	private Selectable OnUp;

	private Selectable OnDown;

	private Selectable Quit;

	private TextMeshProUGUI _Title;

	private RectTransform _TabContainer;

	private RectTransform _DisplayPanel;

	private GameObject _TabPrefab;

	private RectTransform _Content;

	private GameObject _TickboxPrefab;

	private GameObject _SliderPrefab;

	private GameObject _ButtonPrefab;

	private GameObject _MultipleChoicePrefab;

	private GameObject _DropdownPrefab;

	private GameObject _DropdownImagesPrefab;

	private GameObject _InputPrefab;

	private GameObject _LabelPrefab;

	private CoopConfig _CoopConfig;

	private List<IUIObject> _spawnedUnselectables;

	private List<ISelectableUI> _spawnedElements;

	private List<GameObject> _spawnedTabs;

	private ScrollEnhancer _scroller;

	private SignalBus _signalBus;

	private PlayerOptions _playerOptions;

	private AdventureManager _adventureManager;

	private CheatsController _cheatsController;

	private Resolution? _selectedResolution;

	private List<string> _resolutionStrings;

	private int _selectedRefreshRate;

	private FullScreenMode _selectedWindowMode;

	private bool _vSyncEnabled;

	private int _selectedFrameRate;

	private AchievementManager _achievementManager;

	private MultiplayerManager _multiplayer;

	private LabeledInputUI _twitchChannelNameInput;

	private LabeledButtonUI _twitchConnectButton;

	private LabeledButtonUI _twitchDisconnectButton;

	private OptionsTabType? _currentTabType;

	private CustomDropDown _screenResolutionDropdown;

	private CustomDropDown _refreshRateDropdown;

	private SliderUI _frameRateSlider;

	private TickBoxUI _vSyncTickBox;

	private LabeledButtonUI _applyGraphicsButton;

	private List<Resolution> _resolutions;

	private List<Resolution> _currentRefreshRateResolutions;

	private ScreenOrientation _currentScreenOrientation;

	private int _deleteSaveClicks;

	private int _loadSavegameClicks;

	private bool _shouldDeleteAdventureData;

	private static uint[] optionColours = new uint[12]
	{
		16068142u, 5530623u, 16762647u, 2072128u, 2413764u, 13901029u, 8664063u, 6734079u, 14688650u, 15594741u,
		6750094u, 16750080u
	};

	private void Construct(SignalBus signalBus, PlayerOptions player, CheatsController cheats, AchievementManager achievementManager, MultiplayerManager multi, AdventureManager adventureManager)
	{
		_signalBus = signalBus;
		_playerOptions = player;
		_cheatsController = cheats;
		AchievementManager achievementManager2 = default(AchievementManager);
		_achievementManager = achievementManager2;
		MultiplayerManager multiplayer = default(MultiplayerManager);
		_multiplayer = multiplayer;
		AdventureManager adventureManager2 = default(AdventureManager);
		_adventureManager = adventureManager2;
	}

	public void Initialize()
	{
		//IL_0169: Expected I4, but got I8
		//IL_05fe: Expected O, but got I4
		//IL_01a3: Expected O, but got I
		//IL_01b3: Expected O, but got I
		//IL_01c9: Expected O, but got I
		//IL_024b: Expected O, but got I
		_shouldDeleteAdventureData = false;
		Resolution[] resolutions = Screen.resolutions;
		Func<Resolution, Resolution> selector = _003C_003Ec._003C_003E9__51_0;
		if (_003C_003Ec._003C_003E9__51_0 == null)
		{
			Func<Resolution, Resolution> func = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804F4960");
			_003C_003Ec._003C_003E9__51_0 = func;
			selector = func;
		}
		IEnumerable<Resolution> source = Enumerable.Select(resolutions, selector);
		IEnumerable<Resolution> enumerable = Enumerable.Select(source, selector);
		if (enumerable != null)
		{
			List<Resolution> resolutions2 = new List<Resolution>(enumerable);
			_resolutions = resolutions2;
			_resolutions._002Ector(enumerable);
			List<Resolution> list = default(List<Resolution>);
			bool flag = list == null;
			List<Resolution> resolutions3 = new List<Resolution>(list);
			_resolutions = resolutions3;
			List<Resolution> resolutions4 = _resolutions;
			Comparison<Resolution> comparison = _003C_003Ec._003C_003E9__51_1;
			if (_003C_003Ec._003C_003E9__51_1 == null)
			{
				Comparison<Resolution> comparison2 = null;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18061D790");
				_003C_003Ec._003C_003E9__51_1 = comparison2;
				comparison = comparison2;
			}
			bool flag2 = comparison == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v331 @ rsi_v12 (System.Collections.Generic.List`1<UnityEngine.Resolution>)+18]");
			if ((nint)0 > (nint)1)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1838D2A50");
				Scrollbar scrollbar = (Scrollbar)(object)comparison;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v331 @ rsi_v12 (System.Collections.Generic.List`1<UnityEngine.Resolution>)+1C]");
			_ = (nint)0 + (nint)1;
			int selectedRefreshRate = (int)((!PlayerPrefs.HasKey("VS_SavedRefreshRate")) ? 4294967295L : PlayerPrefs.GetInt("VS_SavedRefreshRate", 0));
			_selectedRefreshRate = selectedRefreshRate;
			int selectedFrameRate = PlayerPrefs.GetInt("VS_SavedFrameRate", 60);
			_selectedFrameRate = selectedFrameRate;
			int num = PlayerPrefs.GetInt("VS_VSyncEnabled", 1);
			List<System.Int32Enum> optionsConfig = (List<System.Int32Enum>)(object)_OptionsConfig;
			object obj = num - 1;
			bool vSyncEnabled = obj == null;
			_vSyncEnabled = vSyncEnabled;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1476 @ rcx_v51 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1476 @ rcx_v51 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
				Scrollbar scrollbar = (Scrollbar)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1476 @ rcx_v51 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
				optionsConfig = (List<System.Int32Enum>)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1476 @ rcx_v51 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
				bool flag3 = ((List<OptionsTabType>)0).Remove(OptionsTabType.ABOUT);
				if ((flag3 ? 1 : 0) != -1)
				{
					optionsConfig = (List<System.Int32Enum>)(object)_OptionsConfig;
					bool flag4 = ((List<System.Int32Enum>)(object)_OptionsConfig).Remove((System.Int32Enum)5);
				}
			}
			ScreenOrientation screenOrientation = Screen.GetScreenOrientation();
			_currentScreenOrientation = screenOrientation;
			FullScreenMode fullScreenMode = Screen.fullScreenMode;
			_selectedWindowMode = fullScreenMode;
			_deleteSaveClicks = 0;
			AddTabs();
			List<OptionsTabType> optionsConfig2 = _OptionsConfig;
			int lastSelectedTabIndex = OptionsState.LastSelectedTabIndex;
			int lastSelectedTabIndex2 = OptionsState.LastSelectedTabIndex;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v598 @ rdx_v29 (System.Collections.Generic.List`1<VampireSurvivors.UI.OptionsController+OptionsTabType>)+18]");
			bool flag5 = (nint)lastSelectedTabIndex2 >= (nint)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v598 @ rdx_v29 (System.Collections.Generic.List`1<VampireSurvivors.UI.OptionsController+OptionsTabType>)+10]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v609 @ rax_v60+20+v602 @ r8_v22 (System.Int32)*4]");
			SelectTab(OptionsTabType.QUICKACCESS);
			ScrollEnhancer componentInChildren = GetComponentInChildren<ScrollEnhancer>();
			_scroller = componentInChildren;
			ScrollEnhancer scroller = _scroller;
			if ((object)_scroller == null || ((UnityEngine.Object)scroller).m_CachedPtr == (IntPtr)0)
			{
				Transform transform = _Content.transform;
				Transform parent = transform.parent;
				Transform parent2 = parent.parent;
				GameObject gameObject = parent2.gameObject;
				ScrollEnhancer scroller2 = gameObject.AddComponent<ScrollEnhancer>();
				_scroller = scroller2;
				ScrollRect componentInChildren2 = GetComponentInChildren<ScrollRect>();
				Slider[] componentsInChildren = GetComponentsInChildren<Slider>();
				object obj3 = Enumerable.Last((IEnumerable<object>)componentsInChildren);
				Slider slider = default(Slider);
				float offset = default(float);
				_scroller.Initialize(3f, _Content, componentInChildren2.m_VerticalScrollbar, slider, offset);
				Scrollbar scrollbar = componentInChildren2.m_VerticalScrollbar;
			}
			ScrollEnhancer scroller3 = _scroller;
			scroller3.RequiresMouseOverForScroll = true;
			_scroller.ForceScrollAlignment();
			List<GameObject> spawnedTabs = _spawnedTabs;
			bool num2;
			Selectable component = default(Selectable);
			if (spawnedTabs._size <= 1)
			{
				List<ISelectableUI> spawnedElements = _spawnedElements;
				bool flag6 = spawnedElements._size <= 0;
				num2 = flag6;
				ISelectableUI[] items = spawnedElements._items;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9BB80");
			}
			else
			{
				int lastSelectedTabIndex3 = OptionsState.LastSelectedTabIndex;
				bool flag7 = OptionsState.LastSelectedTabIndex >= spawnedTabs._size;
				num2 = flag7;
				GameObject[] items2 = spawnedTabs._items;
				component = items2[lastSelectedTabIndex3].GetComponent<Selectable>();
			}
			component.Select();
			return;
		}
		Exception ex = System.Linq.Error.ArgumentNull("source");
		throw ex;
	}

	private unsafe void AddTabs()
	{
		//IL_006e: Expected O, but got I
		//IL_03e7: Expected I, but got O
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Expected O, but got Unknown
		//IL_024b: Expected O, but got Ref
		//IL_0506->IL0385: Incompatible stack heights: 1 vs 0
		//IL_0560->IL04b0: Incompatible stack heights: 3 vs 0
		List<OptionsTabType> optionsConfig = _OptionsConfig;
		if (_OptionsConfig != null)
		{
			object obj = default(object);
			object obj2 = default(object);
			object obj4 = default(object);
			IntPtr intPtr = default(IntPtr);
			while (true)
			{
				if (obj != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ stack_-58_v21+1C]");
					if (obj2 != null)
					{
						break;
					}
					object obj3 = obj4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ stack_-58_v21+18]");
					if ((nint)obj3 >= 0)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ stack_-58_v21+10]");
					object obj5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ stack_-58_v21+10]");
					if ((nint)0 != 0)
					{
						object obj6 = obj4;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v261 @ rax_v78+18]");
						if ((nint)obj6 < 0)
						{
							object obj7 = obj4 + 1;
							_003C_003Ec__DisplayClass52_0 CS_0024_003C_003E8__locals6 = new _003C_003Ec__DisplayClass52_0();
							if (CS_0024_003C_003E8__locals6 != null)
							{
								CS_0024_003C_003E8__locals6._003C_003E4__this = this;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v261 @ rax_v78+20+v245 @ stack_-50_v20*4]");
								CS_0024_003C_003E8__locals6.v = OptionsTabType.QUICKACCESS;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v261 @ rax_v78+20+v245 @ stack_-50_v20*4]");
								bool flag = (nint)0 == 7;
								obj4 = obj7;
								if (!flag)
								{
									GameObject gameObject = UnityEngine.Object.Instantiate(_TabPrefab, _TabContainer);
									if ((object)gameObject == null)
									{
										throw new NullReferenceException();
									}
									Image component = gameObject.GetComponent<Image>();
									Sprite tabSprite = GetTabSprite(CS_0024_003C_003E8__locals6.v);
									if ((object)component == null)
									{
										throw new NullReferenceException();
									}
									component.sprite = tabSprite;
									Button component2 = gameObject.GetComponent<Button>();
									if ((object)component2 == null)
									{
										throw new NullReferenceException();
									}
									UnityAction call = delegate
									{
										CS_0024_003C_003E8__locals6._003C_003E4__this.SelectTab(CS_0024_003C_003E8__locals6.v);
									};
									if (component2.m_OnClick == null)
									{
										throw new NullReferenceException();
									}
									component2.m_OnClick.AddListener(call);
									string text = ((Enum)(&intPtr)).ToString();
									if (text == null)
									{
										throw new NullReferenceException();
									}
									string text2 = text.ToUpperInvariant();
									((UnityEngine.Object)gameObject).SetName(text2);
									if (_spawnedTabs == null)
									{
										throw new NullReferenceException();
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180497F80");
									optionsConfig = null;
									obj4 = obj7;
								}
								continue;
							}
							throw new NullReferenceException();
						}
						throw new IndexOutOfRangeException();
					}
					throw new NullReferenceException();
				}
				throw new NullReferenceException();
			}
			bool flag2 = obj == null;
			nint num = 0;
			if (!flag2)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ stack_-58_v21+1C]");
				if (obj2 == null)
				{
					List<GameObject> spawnedTabs = _spawnedTabs;
					if (_spawnedTabs != null)
					{
						if (spawnedTabs._size >= 2)
						{
							return;
						}
						if ((object)_TabContainer != null)
						{
							GameObject gameObject2 = _TabContainer.gameObject;
							if ((object)gameObject2 != null)
							{
								bool flag3 = ((UnityEngine.Object)gameObject2).m_CachedPtr == (IntPtr)0;
								GameObject.SetActive_Injected(((UnityEngine.Object)gameObject2).m_CachedPtr, false);
								object displayPanel = _DisplayPanel;
								if ((object)_DisplayPanel != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ r14_v23 (System.Object)+10]");
									bool flag4 = (nint)0 == 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ r14_v23 (System.Object)+10]");
									RectTransform.get_sizeDelta_Injected((IntPtr)0, out Vector2 _);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ r14_v23 (System.Object)+10]");
									bool flag5 = (nint)0 == 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ r14_v23 (System.Object)+10]");
									Vector2 value = default(Vector2);
									RectTransform.set_sizeDelta_Injected((IntPtr)0, ref value);
									return;
								}
							}
						}
					}
					goto IL_0385;
				}
				System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
				num = unchecked((nint)null);
			}
			throw new NullReferenceException();
		}
		goto IL_0385;
		IL_0385:
		throw new NullReferenceException();
	}

	private unsafe Sprite GetTabSprite(OptionsTabType t)
	{
		//IL_00b8: Expected O, but got Ref
		//IL_0052: Expected O, but got Ref
		IntPtr intPtr = default(IntPtr);
		string text = ((Enum)(&intPtr)).ToString();
		if (text != null)
		{
			string spriteName = text.ToLowerInvariant();
			Sprite unpackedSprite = SpriteManager.GetUnpackedSprite(spriteName);
			if ((object)unpackedSprite == null)
			{
				string text2 = ((Enum)(&intPtr)).ToString();
				if (text2 == null)
				{
					goto IL_00a1;
				}
				string spriteName2 = text2.ToLowerInvariant();
				unpackedSprite = SpriteManager.GetUnpackedSprite(spriteName2);
			}
			return unpackedSprite;
		}
		goto IL_00a1;
		IL_00a1:
		return (Sprite)(object)new NullReferenceException();
	}

	private string GetTabName(OptionsTabType t)
	{
		//IL_0049: Expected O, but got I8
		//IL_0063: Expected O, but got I8
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A33CE]");
		if ((nint)0 == 0)
		{
			_ = 1;
			object obj = "lang/options_tab_sound";
		}
		if (t <= OptionsTabType.MULTIPLAYER)
		{
			object obj2 = 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rdx_v1+6D496B8+t @ rdx (VampireSurvivors.UI.OptionsController+OptionsTabType)*4]");
			object obj3 = 0 + 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v50 @ rcx_v3 (should have been resolved before IL gen)");
		}
		return "Settings";
	}

	private unsafe void SelectTab(OptionsTabType type)
	{
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_00b5: Expected O, but got I4
		//IL_0121: Expected I, but got O
		//IL_025b: Expected I, but got O
		//IL_027f: Expected I8, but got I4
		//IL_01d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01dd: Expected Ref, but got Unknown
		//IL_01f4: Expected I8, but got I4
		//IL_01fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0203: Expected Ref, but got Unknown
		//IL_0228: Expected I, but got O
		//IL_02f1: Expected O, but got Ref
		//IL_04fb: Expected I, but got O
		//IL_050b: Expected I8, but got I
		//IL_0518: Expected O, but got Ref
		//IL_03bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c4: Expected Ref, but got Unknown
		//IL_03db: Expected I8, but got I4
		//IL_03e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e9: Expected Ref, but got Unknown
		//IL_0403: Expected I, but got O
		//IL_0410: Expected I, but got O
		int deleteSaveClicks = ((type == OptionsTabType.USER) ? (_deleteSaveClicks + 1) : 0);
		_deleteSaveClicks = deleteSaveClicks;
		object obj = (object?)_currentTabType >> 32;
		object obj2 = obj - type;
		bool flag = obj2 == null;
		object obj3 = (_003F?)_currentTabType & flag;
		if (obj3 != null && type != OptionsTabType.USER)
		{
			return;
		}
		_currentTabType = (OptionsTabType?)(object)1;
		if (_playerOptions != null)
		{
			_playerOptions.Save();
		}
		TextMeshProUGUI title = _Title;
		string tabName = GetTabName(type);
		string text = Translate(tabName);
		nint num = (nint)title;
		title.text = text;
		string text2 = _Title.text;
		object obj4 = "";
		if ((object)text2 == "")
		{
			goto IL_0236;
		}
		if (text2 != null && "" != null)
		{
			int stringLength = text2._stringLength;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v569 @ rdx_v12+10]");
			if ((nint)stringLength == 0)
			{
				ref byte first = ref *(byte*)(text2 + 20);
				ulong length = (ulong)(text2._stringLength + text2._stringLength);
				bool flag2 = System.SpanHelpers.SequenceEqual(ref first, ref *(byte*)("" + 20), length);
				bool flag3 = !flag2;
				num = unchecked((nint)null);
				if (!flag3)
				{
					goto IL_0236;
				}
			}
		}
		goto IL_04ce;
		IL_04ce:
		ClearPage();
		BuildPage(type);
		List<GameObject> spawnedTabs = _spawnedTabs;
		int num2 = 0;
		ulong num3 = 0uL;
		int num4 = 0;
		nint num5 = default(nint);
		GameObject gameObject = default(GameObject);
		GameObject gameObject2 = default(GameObject);
		while (true)
		{
			if (num4 >= spawnedTabs._size)
			{
				return;
			}
			List<GameObject> spawnedTabs2 = _spawnedTabs;
			if (num2 >= spawnedTabs2._size)
			{
				break;
			}
			GameObject[] items = spawnedTabs2._items;
			string text3 = ((UnityEngine.Object)items[num2]).GetName();
			string text4 = ((Enum)(&num5)).ToString();
			string text5 = text4.ToUpperInvariant();
			Image component;
			if ((object)text3 != text5)
			{
				bool flag4 = text3 == null;
				ulong num6 = num3;
				nint num7 = num;
				if (!flag4)
				{
					bool flag5 = text5 == null;
					num6 = num3;
					num7 = num;
					if (!flag5)
					{
						bool flag6 = text3._stringLength != text5._stringLength;
						num6 = num3;
						num7 = num;
						if (!flag6)
						{
							ref byte second = ref *(byte*)(text5 + 20);
							num6 = (ulong)(text3._stringLength + text3._stringLength);
							bool flag7 = System.SpanHelpers.SequenceEqual(ref *(byte*)(text3 + 20), ref second, num6);
							num7 = unchecked((nint)null);
							num3 = num6;
							num = unchecked((nint)null);
							if (flag7)
							{
								goto IL_0454;
							}
						}
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
				component = gameObject.GetComponent<Image>();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
				num5 = 0;
				goto IL_04f3;
			}
			goto IL_0454;
			IL_0454:
			OptionsState.LastSelectedTabIndex = num2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
			component = gameObject2.GetComponent<Image>();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12030]");
			num5 = 0;
			goto IL_04f3;
			IL_04f3:
			nint num8 = (nint)component;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ r9_v10 (Il2CppClass<UnityEngine.UI.Image>)+2B0]");
			num3 = 0uL;
			component.color = (Color)(&num5);
			spawnedTabs = _spawnedTabs;
			num2++;
			num = num8;
			num4 = num2;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		return;
		IL_0236:
		TextMeshProUGUI title2 = _Title;
		string tabName2 = GetTabName(type);
		num = (nint)title2;
		title2.text = tabName2;
		goto IL_04ce;
	}

	private unsafe void ClearPage()
	{
		//IL_0013: Expected F4, but got I4
		//IL_0435: Expected O, but got Ref
		//IL_0021: Expected F4, but got I4
		//IL_0029: Expected O, but got Ref
		//IL_0148: Expected F4, but got I4
		//IL_0156: Expected F4, but got I4
		//IL_015e: Expected O, but got Ref
		//IL_02cd: Expected I4, but got O
		//IL_02cd: Expected O, but got I
		//IL_0359: Expected I4, but got O
		//IL_0359: Expected O, but got I
		bool flag = _spawnedElements == null;
		OptionsController optionsController = this;
		if (!flag)
		{
			float num = 0f;
			List<ISelectableUI>.Enumerator enumerator = default(List<ISelectableUI>.Enumerator);
			if (enumerator.MoveNext())
			{
				float num2 = 0f;
				List<ISelectableUI>.Enumerator enumerator2 = (List<ISelectableUI>.Enumerator)(&enumerator);
				throw new NullReferenceException();
			}
			bool flag2 = _spawnedUnselectables == null;
			optionsController = (OptionsController)(&enumerator);
			if (!flag2)
			{
				float num3 = 0f;
				List<IUIObject>.Enumerator enumerator3 = default(List<IUIObject>.Enumerator);
				if (enumerator3.MoveNext())
				{
					float num4 = 0f;
					List<IUIObject>.Enumerator enumerator4 = (List<IUIObject>.Enumerator)(&enumerator3);
					throw new NullReferenceException();
				}
				optionsController = (OptionsController)(object)_spawnedElements;
				if (_spawnedElements != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v135 @ rcx_v4 (VampireSurvivors.UI.OptionsController)+1C]");
					_ = (nint)0 + (nint)1;
					((MonoBehaviour)optionsController).m_CancellationTokenSource = null;
					if ((nint)((MonoBehaviour)optionsController).m_CancellationTokenSource > 0)
					{
						Array.Clear((Array)(nint)((UnityEngine.Object)optionsController).m_CachedPtr, 0, (int)((MonoBehaviour)optionsController).m_CancellationTokenSource);
					}
					optionsController = (OptionsController)(object)_spawnedUnselectables;
					if (_spawnedUnselectables != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v135 @ rcx_v4 (VampireSurvivors.UI.OptionsController)+1C]");
						_ = (nint)0 + (nint)1;
						((MonoBehaviour)optionsController).m_CancellationTokenSource = null;
						if ((nint)((MonoBehaviour)optionsController).m_CancellationTokenSource > 0)
						{
							Array.Clear((Array)(nint)((UnityEngine.Object)optionsController).m_CachedPtr, 0, (int)((MonoBehaviour)optionsController).m_CancellationTokenSource);
						}
						_twitchChannelNameInput = null;
						_twitchConnectButton = null;
						_twitchDisconnectButton = null;
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public GameObject GetFirstTab()
	{
		List<GameObject> spawnedTabs = _spawnedTabs;
		if (spawnedTabs._size <= 0)
		{
			return null;
		}
		if (spawnedTabs._size > 0)
		{
			GameObject[] items = spawnedTabs._items;
			return items[0];
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		GameObject result = default(GameObject);
		return result;
	}

	public GameObject GetFirstElement()
	{
		List<ISelectableUI> spawnedElements = _spawnedElements;
		if (spawnedElements._size <= 0)
		{
			return null;
		}
		if (spawnedElements._size > 0)
		{
			ISelectableUI[] items = spawnedElements._items;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			GameObject result = default(GameObject);
			return result;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		GameObject result2 = default(GameObject);
		return result2;
	}

	public Selectable GetFirstSelectable()
	{
		List<ISelectableUI> spawnedElements = _spawnedElements;
		if (spawnedElements._size <= 0)
		{
			return null;
		}
		if (spawnedElements._size > 0)
		{
			ISelectableUI[] items = spawnedElements._items;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9BB80");
			Selectable result = default(Selectable);
			return result;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		Selectable result2 = default(Selectable);
		return result2;
	}

	public Selectable GetLastSelectable()
	{
		//IL_003c: Expected O, but got I4
		//IL_0085: Expected O, but got I4
		List<ISelectableUI> spawnedElements = _spawnedElements;
		if (spawnedElements._size <= 0)
		{
			return null;
		}
		object obj = spawnedElements._size - 1;
		if ((nint)obj < spawnedElements._size)
		{
			ISelectableUI[] items = spawnedElements._items;
			object obj2 = spawnedElements._size - 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9BB80");
			Selectable result = default(Selectable);
			return result;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		Selectable result2 = default(Selectable);
		return result2;
	}

	public unsafe void ClearAll()
	{
		//IL_048f: Expected O, but got Ref
		//IL_0037: Expected F4, but got I4
		//IL_0541: Expected O, but got Ref
		//IL_0045: Expected F4, but got I4
		//IL_004d: Expected O, but got Ref
		//IL_016c: Expected F4, but got I4
		//IL_017a: Expected F4, but got I4
		//IL_0182: Expected O, but got Ref
		//IL_02f1: Expected I4, but got O
		//IL_02f1: Expected O, but got I
		//IL_037d: Expected I4, but got O
		//IL_037d: Expected O, but got I
		//IL_0419: Expected O, but got I4
		//IL_0409: Expected I4, but got O
		//IL_0409: Expected O, but got I
		bool flag = _spawnedTabs == null;
		OptionsController optionsController = this;
		if (!flag)
		{
			List<GameObject>.Enumerator enumerator = default(List<GameObject>.Enumerator);
			while (enumerator.MoveNext())
			{
				UnityEngine.Object.Destroy(null, 0f);
			}
			bool flag2 = _spawnedElements == null;
			optionsController = (OptionsController)(&enumerator);
			if (!flag2)
			{
				float num = 0f;
				List<ISelectableUI>.Enumerator enumerator2 = default(List<ISelectableUI>.Enumerator);
				if (enumerator2.MoveNext())
				{
					float num2 = 0f;
					List<ISelectableUI>.Enumerator enumerator3 = (List<ISelectableUI>.Enumerator)(&enumerator2);
					throw new NullReferenceException();
				}
				bool flag3 = _spawnedUnselectables == null;
				optionsController = (OptionsController)(&enumerator2);
				if (!flag3)
				{
					float num3 = 0f;
					List<IUIObject>.Enumerator enumerator4 = default(List<IUIObject>.Enumerator);
					if (enumerator4.MoveNext())
					{
						float num4 = 0f;
						List<IUIObject>.Enumerator enumerator5 = (List<IUIObject>.Enumerator)(&enumerator4);
						throw new NullReferenceException();
					}
					optionsController = (OptionsController)(object)_spawnedUnselectables;
					if (_spawnedUnselectables != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v158 @ rcx_v4 (VampireSurvivors.UI.OptionsController)+1C]");
						_ = (nint)0 + (nint)1;
						((MonoBehaviour)optionsController).m_CancellationTokenSource = null;
						if ((nint)((MonoBehaviour)optionsController).m_CancellationTokenSource > 0)
						{
							Array.Clear((Array)(nint)((UnityEngine.Object)optionsController).m_CachedPtr, 0, (int)((MonoBehaviour)optionsController).m_CancellationTokenSource);
						}
						optionsController = (OptionsController)(object)_spawnedElements;
						if (_spawnedElements != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v158 @ rcx_v4 (VampireSurvivors.UI.OptionsController)+1C]");
							_ = (nint)0 + (nint)1;
							((MonoBehaviour)optionsController).m_CancellationTokenSource = null;
							if ((nint)((MonoBehaviour)optionsController).m_CancellationTokenSource > 0)
							{
								Array.Clear((Array)(nint)((UnityEngine.Object)optionsController).m_CachedPtr, 0, (int)((MonoBehaviour)optionsController).m_CancellationTokenSource);
							}
							optionsController = (OptionsController)(object)_spawnedTabs;
							if (_spawnedTabs != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v158 @ rcx_v4 (VampireSurvivors.UI.OptionsController)+1C]");
								_ = (nint)0 + (nint)1;
								((MonoBehaviour)optionsController).m_CancellationTokenSource = null;
								if ((nint)((MonoBehaviour)optionsController).m_CancellationTokenSource > 0)
								{
									Array.Clear((Array)(nint)((UnityEngine.Object)optionsController).m_CachedPtr, 0, (int)((MonoBehaviour)optionsController).m_CancellationTokenSource);
								}
								_currentTabType = (OptionsTabType?)(object)0;
								return;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public void RefreshTab(OptionsTabType type)
	{
		ClearPage();
		BuildPage(type);
		IEnumerator routine = WaitAndReselect();
		Coroutine coroutine = StartCoroutine(routine);
	}

	private void BuildPage(OptionsTabType type)
	{
		//IL_0044: Expected O, but got I8
		//IL_005e: Expected O, but got I8
		LayoutRebuilder.ForceRebuildLayoutImmediate(_Content);
		Canvas.ForceUpdateCanvases();
		if (type <= OptionsTabType.MULTIPLAYER)
		{
			object obj = 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rdx_v3+6D4ADB8+type @ rdx (VampireSurvivors.UI.OptionsController+OptionsTabType)*4]");
			object obj2 = 0 + 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v74 @ rcx_v7 (should have been resolved before IL gen)");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 219 Invalid \"Jump target not found in method: 0x186D4ADE0\"");
		throw new NullReferenceException();
	}

	private unsafe void GenerateNavigation()
	{
		//IL_0008: Expected O, but got Ref
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Expected O, but got Unknown
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Expected O, but got Unknown
		//IL_0157: Expected I, but got O
		//IL_018e: Expected O, but got I
		//IL_099f: Expected O, but got I4
		//IL_0237: Expected O, but got I4
		//IL_024d: Expected O, but got I
		//IL_0256: Unknown result type (might be due to invalid IL or missing references)
		//IL_025b: Expected O, but got Unknown
		//IL_0263: Unknown result type (might be due to invalid IL or missing references)
		//IL_0268: Expected O, but got Unknown
		//IL_04b6: Expected O, but got I
		//IL_04f2: Expected O, but got I4
		//IL_053b: Expected O, but got I4
		//IL_02b6: Expected I4, but got O
		//IL_0661: Expected O, but got I
		//IL_069d: Expected O, but got I4
		//IL_06e6: Expected O, but got I4
		//IL_05ad: Expected O, but got Ref
		//IL_05bd: Expected O, but got I
		//IL_0313: Expected I4, but got O
		//IL_088d: Expected O, but got Ref
		//IL_0758: Expected O, but got Ref
		//IL_0768: Expected O, but got I
		//IL_03cb: Expected O, but got Ref
		//IL_040a: Unknown result type (might be due to invalid IL or missing references)
		//IL_040f: Expected O, but got Unknown
		//IL_0440: Expected I4, but got O
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		if (_spawnedElements != null)
		{
			List<ISelectableUI> spawnedElements = _spawnedElements;
			if (spawnedElements._size > 0)
			{
				Func<ISelectableUI, bool> predicate = _003C_003Ec._003C_003E9__64_0;
				if (_003C_003Ec._003C_003E9__64_0 == null)
				{
					predicate = (_003C_003Ec._003C_003E9__64_0 = delegate(ISelectableUI ui)
					{
						if (ui != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9BB80");
							Component component3 = default(Component);
							if ((object)component3 != null)
							{
								GameObject gameObject = component3.gameObject;
								if ((object)gameObject != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v10 (UnityEngine.GameObject)+10]");
									bool flag3 = (nint)0 == 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: Type: Il2CppMethodInfo (should have been resolved before IL gen)");
									Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 87 ConditionalJump @-1, v147 @ ZF_v9 (System.Boolean) --- -1 Nop");
									/*Error: End of method reached without returning.*/;
								}
							}
						}
						throw new NullReferenceException();
					});
					Selectable selectable = null;
				}
				IEnumerable<ISelectableUI> enumerable = Enumerable.Where(spawnedElements, predicate);
				if (enumerable != null)
				{
					List<object> list = new List<object>(enumerable);
					Selectable selectable2 = null;
					int num = 0;
					IEnumerable<object> enumerable2 = null;
					IEnumerable<object> enumerable3 = enumerable;
					int num2 = 0;
					int num3 = 0;
					object obj10 = default(object);
					object obj15 = default(object);
					Selectable selectable5 = default(Selectable);
					Selectable selectable7 = default(Selectable);
					object obj16 = default(object);
					Selectable selectable8 = default(Selectable);
					while (true)
					{
						object obj3;
						object obj4;
						ISelectableUI selectableUI;
						if (num3 < list._size)
						{
							obj3 = enumerable2 - 1;
							obj4 = enumerable2 + 1;
							if ((nint)enumerable2 < list._size)
							{
								object[] items = list._items;
								selectableUI = (ISelectableUI)items[(object)enumerable2];
								nint num4 = (nint)selectableUI;
								int num5 = num2;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v485 @ r10_v6 (Il2CppClass<VampireSurvivors.UI.ISelectableUI>)+12E]");
								if ((nint)num5 >= (nint)0)
								{
									goto IL_01cd;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v485 @ r10_v6 (Il2CppClass<VampireSurvivors.UI.ISelectableUI>)+B0]");
								object obj5 = 0;
								int num6 = num2;
								while (true)
								{
									object obj6 = num6 + num6;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1300 @ r8_v70+v1303 @ rax_v182*8]");
									if (0 == (nint)typeof(ISelectableUI))
									{
										break;
									}
									num6++;
									int num7 = num6;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v485 @ r10_v6 (Il2CppClass<VampireSurvivors.UI.ISelectableUI>)+12E]");
									if ((nint)num7 < (nint)0)
									{
										continue;
									}
									goto IL_01cd;
								}
								object obj7 = num6 + num6;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1300 @ r8_v70+8+v1412 @ rcx_v117*8]");
								object obj8 = (nint)0 << 4;
								object obj9 = obj8 + 312;
								obj10 = obj9 + num4;
								goto IL_01dc;
							}
							goto IL_0987;
						}
						Selectable onDown = OnDown;
						bool flag = (object)OnDown == null;
						Navigation navigation = (Navigation)enumerable3;
						if (!flag)
						{
							bool flag2 = ((UnityEngine.Object)onDown).m_CachedPtr == (IntPtr)0;
							navigation = (Navigation)enumerable3;
							if (!flag2)
							{
								Selectable onDown2 = OnDown;
								List<ISelectableUI> spawnedElements2 = _spawnedElements;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v635 @ rax_v114 (UnityEngine.UI.Selectable)+38]");
								object obj11 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v635 @ rax_v114 (UnityEngine.UI.Selectable)+48]");
								_ = 0;
								_ = onDown2.m_Navigation;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v635 @ rax_v114 (UnityEngine.UI.Selectable)+38]");
								_ = 0;
								object obj12 = spawnedElements2._size - 1;
								if ((nint)obj12 < list._size)
								{
									object[] items2 = list._items;
									object obj13 = spawnedElements2._size - 1;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9BB80");
									if (list._size > 0)
									{
										object[] items3 = list._items;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9BB80");
										navigation = (Navigation)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 112));
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-30]");
										selectable2 = (Selectable)0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-40]");
										_ = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-20]");
										_ = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-30]");
										_ = 0;
										OnDown.navigation = navigation;
										goto IL_05f8;
									}
								}
								goto IL_0987;
							}
						}
						goto IL_05f8;
						IL_01dc:
						object obj14 = obj10;
						Selectable selectable3 = selectableUI.GetSelectable();
						List<GameObject> spawnedTabs = _spawnedTabs;
						int num8;
						if (spawnedTabs._size <= 0)
						{
							num8 = num2;
						}
						else
						{
							if (spawnedTabs._size <= 0)
							{
								goto IL_0987;
							}
							GameObject[] items4 = spawnedTabs._items;
							num8 = (int)items4[0];
						}
						int num9;
						if (num8 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v570 @ rbx_v13 (System.Int32)+10]");
							if ((nint)0 != 0)
							{
								GameObject firstTab = GetFirstTab();
								Selectable component = firstTab.GetComponent<Selectable>();
								num9 = (int)component;
								goto IL_09ff;
							}
						}
						num9 = num2;
						goto IL_09ff;
						IL_09ff:
						Selectable selectable4;
						if ((nint)obj3 >= 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9BB80");
							obj14 = obj15;
							selectable4 = selectable5;
						}
						else
						{
							selectable4 = OnUp;
						}
						Selectable selectable6;
						if ((nint)obj4 >= list._size)
						{
							selectable6 = OnDown;
						}
						else
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9BB80");
							selectable6 = selectable7;
							obj14 = obj16;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9BB80");
						Navigation navigation2 = (Navigation)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 112));
						_ = 4;
						selectable8.navigation = navigation2;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9BAD0");
						enumerable2 = (IEnumerable<object>)(enumerable2 + 1);
						selectable2 = selectable6;
						num = num9;
						enumerable3 = enumerable2;
						Selectable selectable = selectable4;
						num2 = 0;
						num3 = (int)enumerable2;
						continue;
						IL_0987:
						System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
						break;
						IL_05f8:
						Selectable quit = Quit;
						if ((object)Quit != null && ((UnityEngine.Object)quit).m_CachedPtr != (IntPtr)0)
						{
							Selectable quit2 = Quit;
							List<ISelectableUI> spawnedElements3 = _spawnedElements;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v640 @ rax_v87 (UnityEngine.UI.Selectable)+38]");
							object obj11 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v640 @ rax_v87 (UnityEngine.UI.Selectable)+48]");
							_ = 0;
							_ = quit2.m_Navigation;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v640 @ rax_v87 (UnityEngine.UI.Selectable)+38]");
							_ = 0;
							object obj17 = spawnedElements3._size - 1;
							if ((nint)obj17 < list._size)
							{
								object[] items5 = list._items;
								object obj18 = spawnedElements3._size - 1;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9BB80");
								if (list._size > 0)
								{
									object[] items6 = list._items;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9BB80");
									navigation = (Navigation)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 112));
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-8]");
									selectable2 = (Selectable)0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-18]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+8]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-8]");
									_ = 0;
									Quit.navigation = navigation;
									goto IL_07ad;
								}
							}
							goto IL_0987;
						}
						goto IL_07ad;
						IL_07ad:
						List<ISelectableUI> spawnedElements4 = _spawnedElements;
						if (spawnedElements4._size > 0)
						{
							ISelectableUI[] items7 = spawnedElements4._items;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9BB80");
							List<GameObject> spawnedTabs2 = _spawnedTabs;
							if (spawnedTabs2._size <= 0)
							{
								break;
							}
							if (spawnedTabs2._size > 0)
							{
								GameObject[] items8 = spawnedTabs2._items;
								Selectable component2 = items8[0].GetComponent<Selectable>();
								object obj19 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 112));
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9A320");
								_003CWaitAndFormatWidth_003Ed__65 obj20 = null;
								obj20._003C_003E1__state = num2;
								obj20._003C_003E4__this = this;
								Coroutine coroutine = StartCoroutine(obj20);
								return;
							}
						}
						goto IL_0987;
						IL_01cd:
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
						goto IL_01dc;
					}
					throw new NullReferenceException();
				}
				Exception ex = System.Linq.Error.ArgumentNull("source");
				throw ex;
			}
		}
		Debug.LogWarning("Cannot generate navigation in OptionsController as the _spawnedElements list is empty");
	}

	private IEnumerator WaitAndFormatWidth()
	{
		_003CWaitAndFormatWidth_003Ed__65 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	public void SetUpNavigation(Selectable sel)
	{
		OnUp = sel;
	}

	public void SetDownNavigation(Selectable sel)
	{
		OnDown = sel;
	}

	public void SetQuit(Selectable sel)
	{
		Quit = sel;
	}

	private void AddFlashingVfxTickBox()
	{
		//IL_0028: Expected I4, but got O
		PlayerOptionsData config = _playerOptions.Config;
		Action<bool> action = null;
		((OptionsController)(object)action).FlashingVFX((byte)(int)this != 0);
		bool textIsLocalizationTerm = default(bool);
		TickBoxUI tickBoxUI = AddTickBox("lang/options_flashing_VFX", config._003CFlashingVFXEnabled_003Ek__BackingField, action, textIsLocalizationTerm);
	}

	private void BuildQuickAccessPage()
	{
		//IL_00de: Expected I4, but got O
		AddLanguageButton();
		PlayerOptions playerOptions = _playerOptions;
		PlayerOptionsData mainGameConfig = playerOptions._mainGameConfig;
		Action<float> action = null;
		float num = default(float);
		((OptionsController)(object)action).SetSounds(num);
		bool textIsLocalizationTerm = default(bool);
		float minValue = default(float);
		float maxValue = default(float);
		SliderUI sliderUI = AddSlider("lang/options_sounds", mainGameConfig._003CSoundsVolume_003Ek__BackingField, action, textIsLocalizationTerm, minValue, maxValue);
		PlayerOptions playerOptions2 = _playerOptions;
		PlayerOptionsData mainGameConfig2 = playerOptions2._mainGameConfig;
		Action<float> action2 = null;
		((OptionsController)(object)action2).SetMusic(num);
		SliderUI sliderUI2 = AddSlider("lang/options_music", mainGameConfig2._003CMusicVolume_003Ek__BackingField, action2, textIsLocalizationTerm, minValue, maxValue);
		PlayerOptionsData config = _playerOptions.Config;
		Action<bool> action3 = null;
		((OptionsController)(object)action3).DamageNumbers((byte)(int)this != 0);
		TickBoxUI tickBoxUI = AddTickBox("lang/options_damageNumbers", config._003CDamageNumbersEnabled_003Ek__BackingField, action3, textIsLocalizationTerm);
		AddFlashingVfxTickBox();
		AddSoundEffectTypes();
	}

	private void BuildIngamePage()
	{
		//IL_00ef: Expected I4, but got O
		//IL_013c: Expected I4, but got O
		//IL_01d1: Expected I4, but got O
		PlayerOptions playerOptions = _playerOptions;
		PlayerOptionsData mainGameConfig = playerOptions._mainGameConfig;
		Action<float> action = null;
		float num = default(float);
		((OptionsController)(object)action).SetSounds(num);
		bool textIsLocalizationTerm = default(bool);
		float minValue = default(float);
		float maxValue = default(float);
		SliderUI sliderUI = AddSlider("lang/options_sounds", mainGameConfig._003CSoundsVolume_003Ek__BackingField, action, textIsLocalizationTerm, minValue, maxValue);
		PlayerOptions playerOptions2 = _playerOptions;
		PlayerOptionsData mainGameConfig2 = playerOptions2._mainGameConfig;
		Action<float> action2 = null;
		((OptionsController)(object)action2).SetMusic(num);
		SliderUI sliderUI2 = AddSlider("lang/options_music", mainGameConfig2._003CMusicVolume_003Ek__BackingField, action2, textIsLocalizationTerm, minValue, maxValue);
		AddVisibleJoysticks();
		AddFlashingVfxTickBox();
		PlayerOptionsData config = _playerOptions.Config;
		Action<bool> action3 = null;
		((OptionsController)(object)action3).ScreenShake((byte)(int)this != 0);
		TickBoxUI tickBoxUI = AddTickBox("lang/options_screenShake", config._003CScreenShakeEnabled_003Ek__BackingField, action3, textIsLocalizationTerm);
		PlayerOptionsData config2 = _playerOptions.Config;
		Action<bool> action4 = null;
		((OptionsController)(object)action4).DamageNumbers((byte)(int)this != 0);
		TickBoxUI tickBoxUI2 = AddTickBox("lang/options_damageNumbers", config2._003CDamageNumbersEnabled_003Ek__BackingField, action4, textIsLocalizationTerm);
		AddDisableMovingBackground();
		Dictionary<DlcType, BundleManifestData> loadedDlc = DlcSystem.LoadedDlc;
		int num2 = ((Dictionary<System.Int32Enum, object>)(object)loadedDlc).FindEntry((System.Int32Enum)4);
		if (num2 >= 0)
		{
			PlayerOptionsData config3 = _playerOptions.Config;
			Action<bool> action5 = null;
			((OptionsController)(object)action5).GlimmerCarousel((byte)(int)this != 0);
			TickBoxUI tickBoxUI3 = AddTickBox("lang/options_ShowGlimmerCarousel", config3._003CGlimmerCarouselEnabled_003Ek__BackingField, action5, textIsLocalizationTerm);
		}
	}

	private void BuildDisplayPage()
	{
		//IL_0028: Expected I4, but got O
		//IL_0075: Expected I4, but got O
		//IL_00c2: Expected I4, but got O
		//IL_0174: Expected I4, but got O
		AddResolutions();
		AddBorderTypes();
		AddFlashingVfxTickBox();
		PlayerOptionsData config = _playerOptions.Config;
		Action<bool> action = null;
		((OptionsController)(object)action).DisableBlood((byte)(int)this != 0);
		bool textIsLocalizationTerm = default(bool);
		TickBoxUI tickBoxUI = AddTickBox("lang/options_disable_blood", config._003CDisableBlood_003Ek__BackingField, action, textIsLocalizationTerm);
		PlayerOptionsData config2 = _playerOptions.Config;
		Action<bool> action2 = null;
		((OptionsController)(object)action2).ScreenShake((byte)(int)this != 0);
		TickBoxUI tickBoxUI2 = AddTickBox("lang/options_screenShake", config2._003CScreenShakeEnabled_003Ek__BackingField, action2, textIsLocalizationTerm);
		PlayerOptionsData config3 = _playerOptions.Config;
		Action<bool> action3 = null;
		((OptionsController)(object)action3).PixelFont((byte)(int)this != 0);
		TickBoxUI tickBoxUI3 = AddTickBox("lang/options_pixel_font", config3._003CPixelFont_003Ek__BackingField, action3, textIsLocalizationTerm);
		PlayerOptionsData config4 = _playerOptions.Config;
		List<ItemType> list = config4._003CCollectedItems_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ rcx_v20 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				PlayerOptionsData config5 = _playerOptions.Config;
				Action<bool> action4 = null;
				((OptionsController)(object)action4).DisplayDefangedEnemies((byte)(int)this != 0);
				TickBoxUI tickBoxUI4 = AddTickBox("lang/options_see_defang", config5._003CDisplayDefangedEnemies_003Ek__BackingField, action4, textIsLocalizationTerm);
			}
		}
	}

	private void BuildSoundPage()
	{
		PlayerOptions playerOptions = _playerOptions;
		PlayerOptionsData mainGameConfig = playerOptions._mainGameConfig;
		Action<float> action = null;
		float num = default(float);
		((OptionsController)(object)action).SetSounds(num);
		bool textIsLocalizationTerm = default(bool);
		float minValue = default(float);
		float maxValue = default(float);
		SliderUI sliderUI = AddSlider("lang/options_sounds", mainGameConfig._003CSoundsVolume_003Ek__BackingField, action, textIsLocalizationTerm, minValue, maxValue);
		PlayerOptions playerOptions2 = _playerOptions;
		PlayerOptionsData mainGameConfig2 = playerOptions2._mainGameConfig;
		Action<float> action2 = null;
		((OptionsController)(object)action2).SetMusic(num);
		SliderUI sliderUI2 = AddSlider("lang/options_music", mainGameConfig2._003CMusicVolume_003Ek__BackingField, action2, textIsLocalizationTerm, minValue, maxValue);
		AddSoundEffectTypes();
	}

	private void BuildGameplayPage()
	{
		//IL_0028: Expected I4, but got O
		//IL_0075: Expected I4, but got O
		//IL_0136: Expected I4, but got O
		PlayerOptionsData config = _playerOptions.Config;
		Action<bool> action = null;
		((OptionsController)(object)action).DamageNumbers((byte)(int)this != 0);
		bool textIsLocalizationTerm = default(bool);
		TickBoxUI tickBoxUI = AddTickBox("lang/options_damageNumbers", config._003CDamageNumbersEnabled_003Ek__BackingField, action, textIsLocalizationTerm);
		PlayerOptionsData config2 = _playerOptions.Config;
		Action<bool> action2 = null;
		((OptionsController)(object)action2).ToggleStageProgression((byte)(int)this != 0);
		bool defaultValue = !config2._003CHideProgress_003Ek__BackingField;
		TickBoxUI tickBoxUI2 = AddTickBox("lang/show_stage_progression", defaultValue, action2, textIsLocalizationTerm);
		PlayerOptionsData config3 = _playerOptions.Config;
		List<ItemType> list = config3._003CCollectedItems_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ rcx_v14 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				PlayerOptionsData config4 = _playerOptions.Config;
				Action<bool> action3 = null;
				((OptionsController)(object)action3).ToggleVisualInvert((byte)(int)this != 0);
				TickBoxUI tickBoxUI3 = AddTickBox("lang/options_invertStages", config4._003CVisuallyInvertStages_003Ek__BackingField, action3, textIsLocalizationTerm);
			}
		}
		AddVisibleJoysticks();
		AddJoystickTypes();
	}

	private void BuildUserPage()
	{
		//IL_00ea: Expected I4, but got O
		AddLanguageButton();
		TwitchIntegration sInstance = TwitchIntegration._sInstance;
		bool textIsLocalizationTerm = default(bool);
		LabeledInputUI twitchChannelNameInput = AddLabeledInput("lang/options_twitchChannel", sInstance._username, "", textIsLocalizationTerm);
		_twitchChannelNameInput = twitchChannelNameInput;
		Action callback = OnTwitchConnectButtonPressed;
		LabeledButtonUI twitchConnectButton = AddLabeledButton("lang/options_twitchDesc", "lang/options_twitchLogin", callback, textIsLocalizationTerm);
		_twitchConnectButton = twitchConnectButton;
		Action callback2 = OnTwitchDisconnectButtonPressed;
		LabeledButtonUI twitchDisconnectButton = AddLabeledButton("lang/options_twitchEnabled", "lang/options_twitchLogout", callback2, textIsLocalizationTerm);
		_twitchDisconnectButton = twitchDisconnectButton;
		UpdateTwitchButtonStates();
		PlayerOptionsData config = _playerOptions.Config;
		Action<bool> action = null;
		((OptionsController)(object)action).TogglePopupsShouldFollowPriority((byte)(int)this != 0);
		TickBoxUI tickBoxUI = AddTickBox("lang/options_popupsFollowPriority", config._003CPopupsShouldFollowPriority_003Ek__BackingField, action, textIsLocalizationTerm);
		Action callback3 = RecoverOldData;
		LabeledButtonUI labeledButtonUI = AddLabeledButton("lang/options_dataRecovery", "lang/options_restore", callback3, textIsLocalizationTerm);
		if (!AdventureManager._003CIsInAdventureMode_003Ek__BackingField && _deleteSaveClicks >= 7)
		{
			Action callback4 = delegate
			{
				//IL_0015: Expected I4, but got O
				Action<bool> action2 = null;
				((OptionsController)(object)action2)._003CDeleteSave_003Eb__151_0((byte)(int)this != 0);
				bool textIsLocalizationTerm2 = default(bool);
				PopupManager.CreateOKCancelPopup("Delete-Save", "lang/options_deleteSave", "lang/options_deleteSaveMessage1", action2, textIsLocalizationTerm2);
			};
			LabeledButtonUI labeledButtonUI2 = AddLabeledButton("lang/options_deleteSave", "lang/options_delete", callback4, textIsLocalizationTerm);
		}
	}

	private void BuildAboutPage()
	{
	}

	private unsafe void BuildCheatsPage()
	{
		//IL_002b: Expected O, but got Ref
		List<CheatData> cheats = _cheatsController.GetCheats();
		List<CheatData>.Enumerator enumerator = default(List<CheatData>.Enumerator);
		if (enumerator.MoveNext())
		{
			object obj = null;
			List<CheatData>.Enumerator enumerator2 = (List<CheatData>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
	}

	private unsafe List<Color> ColourDropdownValues()
	{
		//IL_0189: Expected O, but got I4
		//IL_009b: Expected O, but got I
		//IL_0102: Expected O, but got I
		//IL_00d9: Expected O, but got Ref
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Expected O, but got Unknown
		//IL_014c: Expected O, but got I
		//IL_0162: Unknown result type (might be due to invalid IL or missing references)
		//IL_0167: Expected O, but got Unknown
		List<Color> list = new List<Color>();
		object obj = 0;
		float num4 = default(float);
		while (true)
		{
			uint[] array = optionColours;
			if ((nint)obj >= array.Length)
			{
				return list;
			}
			uint[] array2 = optionColours;
			if ((nint)obj >= array2.Length)
			{
				break;
			}
			int num = (int)array2[obj] >> 16;
			float num2 = (float)num / 255f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Color>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Color>)+10]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Color>)+18]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rdx_v6+18]");
			if (num3 >= 0)
			{
				list.AddWithResize((Color)(&num4));
				obj++;
				continue;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Color>)+18]");
			object obj3 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Color>)+18]");
			nint num5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rdx_v6+18]");
			if (num5 >= 0)
			{
				break;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Color>)+18]");
			object obj4 = (nint)0 + (nint)2;
			object obj5 = obj4 + obj4;
			obj++;
		}
		return (List<Color>)(object)new IndexOutOfRangeException();
	}

	private void BuildMultiplayerPage()
	{
		//IL_0088: Expected I4, but got O
		//IL_016f: Expected I4, but got O
		//IL_0256: Expected I4, but got O
		//IL_033d: Expected I4, but got O
		//IL_0383: Expected I4, but got O
		//IL_03a4: Expected I4, but got O
		//IL_03d0: Expected I4, but got O
		//IL_03f1: Expected I4, but got O
		//IL_041d: Expected I4, but got O
		//IL_043e: Expected I4, but got O
		//IL_0494: Expected I4, but got O
		//IL_047e: Expected I4, but got O
		//IL_0529: Expected I4, but got O
		//IL_04dc: Expected I4, but got O
		//IL_04fd: Expected I4, but got O
		//IL_05b3: Expected I4, but got O
		List<Color> options = ColourDropdownValues();
		string text = Translate("lang/options_coop_colour_X");
		string text2 = text.Replace("%0", "1");
		uint[] array = optionColours;
		PlayerOptionsData config = _playerOptions.Config;
		uint[] array2 = config._003CPlayerColours_003Ek__BackingField;
		bool textIsLocalizationTerm2;
		if (optionColours != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180507C20");
			Action<int> action = null;
			((OptionsController)(object)action)._003CBuildMultiplayerPage_003Eb__80_0((int)this);
			int selectedIndex = default(int);
			Action<int> action2 = default(Action<int>);
			int howManyOptionsToShowAtOnce = default(int);
			bool textIsLocalizationTerm = default(bool);
			AddColourDropDown(text2, options, selectedIndex, action2, howManyOptionsToShowAtOnce, textIsLocalizationTerm);
			string text3 = text.Replace("%0", "2");
			uint[] array3 = optionColours;
			PlayerOptionsData config2 = _playerOptions.Config;
			uint[] array4 = config2._003CPlayerColours_003Ek__BackingField;
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v925 @ rdi_v9 (Il2CppMethodInfo)+38]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
			}
			if (optionColours != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180507C20");
				Action<int> action3 = null;
				((OptionsController)(object)action3)._003CBuildMultiplayerPage_003Eb__80_1((int)this);
				int selectedIndex2 = default(int);
				AddColourDropDown(text3, options, selectedIndex2, action2, howManyOptionsToShowAtOnce, textIsLocalizationTerm);
				string text4 = text.Replace("%0", "3");
				uint[] array5 = optionColours;
				PlayerOptionsData config3 = _playerOptions.Config;
				uint[] array6 = config3._003CPlayerColours_003Ek__BackingField;
				nint num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v741 @ rdi_v11 (Il2CppMethodInfo)+38]");
				if ((nint)0 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
				}
				if (optionColours != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180507C20");
					Action<int> action4 = null;
					((OptionsController)(object)action4)._003CBuildMultiplayerPage_003Eb__80_2((int)this);
					int selectedIndex3 = default(int);
					AddColourDropDown(text4, options, selectedIndex3, action2, howManyOptionsToShowAtOnce, textIsLocalizationTerm);
					string text5 = text.Replace("%0", "4");
					uint[] array7 = optionColours;
					PlayerOptionsData config4 = _playerOptions.Config;
					uint[] array8 = config4._003CPlayerColours_003Ek__BackingField;
					nint num3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v543 @ rdi_v13 (Il2CppMethodInfo)+38]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
					}
					if (optionColours != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180507C20");
						Action<int> action5 = null;
						((OptionsController)(object)action5)._003CBuildMultiplayerPage_003Eb__80_3((int)this);
						int selectedIndex4 = default(int);
						AddColourDropDown(text5, options, selectedIndex4, action2, howManyOptionsToShowAtOnce, textIsLocalizationTerm);
						PlayerOptionsData config5 = _playerOptions.Config;
						Action<bool> action6 = null;
						((OptionsController)(object)action6).ToggleShowPlayerIndicators((byte)(int)this != 0);
						TickBoxUI tickBoxUI = AddTickBox("lang/options_coop_indicators", config5._003CShowPlayerIndicators_003Ek__BackingField, action6, (byte)(int)action2 != 0);
						PlayerOptionsData config6 = _playerOptions.Config;
						Action<bool> action7 = null;
						((OptionsController)(object)action7).TogglePermanentCoopOutlines((byte)(int)this != 0);
						TickBoxUI tickBoxUI2 = AddTickBox("lang/options_permanent_outlines", config6._003CPermanentCoopOutlines_003Ek__BackingField, action7, (byte)(int)action2 != 0);
						PlayerOptionsData config7 = _playerOptions.Config;
						Action<bool> action8 = null;
						((OptionsController)(object)action8).ToggleControllerVibration((byte)(int)this != 0);
						TickBoxUI tickBoxUI3 = AddTickBox("lang/options_coop_vibration", config7._003CControllerVibrationEnabled_003Ek__BackingField, action8, (byte)(int)action2 != 0);
						GameManager core = GM.Core;
						if ((object)GM.Core != null)
						{
							bool flag = ((UnityEngine.Object)core).m_CachedPtr != (IntPtr)0;
							textIsLocalizationTerm2 = (byte)(int)action2 != 0;
							if (flag)
							{
								goto IL_0506;
							}
						}
						textIsLocalizationTerm2 = (byte)(int)action2 != 0;
						SystemPlatform sInstance = SystemPlatform.sInstance;
						if (!sInstance.m_CurrentSystem.DoesPlayer1NeedController())
						{
							PlayerOptionsData config8 = _playerOptions.Config;
							Action<bool> action9 = null;
							((OptionsController)(object)action9).ToggleAssignControllerToPlayer1((byte)(int)this != 0);
							TickBoxUI tickBoxUI4 = AddTickBox("lang/options_coop_assign_controller_player_1", config8._003CAssignControllerToPlayer1_003Ek__BackingField, action9, (byte)(int)action2 != 0);
						}
						goto IL_0506;
					}
					ArgumentNullException ex = new ArgumentNullException("array");
					ex._002Ector("array");
					throw ex;
				}
				ArgumentNullException ex2 = new ArgumentNullException("array");
				ex2._002Ector("array");
				throw ex2;
			}
			ArgumentNullException ex3 = new ArgumentNullException("array");
			ex3._002Ector("array");
			throw ex3;
		}
		ArgumentNullException ex4 = new ArgumentNullException("array");
		ex4._002Ector("array");
		throw ex4;
		IL_0506:
		PlayerOptionsData config9 = _playerOptions.Config;
		Action<bool> action10 = null;
		((OptionsController)(object)action10).ToggleTintUISelection((byte)(int)this != 0);
		TickBoxUI tickBoxUI5 = AddTickBox("lang/options_coop_tint_ui_selection", config9._003CTintUISelection_003Ek__BackingField, action10, textIsLocalizationTerm2);
		GameManager core2 = GM.Core;
		if ((object)GM.Core == null || ((UnityEngine.Object)core2).m_CachedPtr == (IntPtr)0)
		{
			PlayerOptionsData config10 = _playerOptions.Config;
			Action<bool> action11 = null;
			((OptionsController)(object)action11).SetCoopChestMode((byte)(int)this != 0);
			TickBoxUI tickBoxUI6 = AddTickBox("lang/options_sequential_chest_mode", config10._003CSequentialChestMode_003Ek__BackingField, action11, textIsLocalizationTerm2);
		}
	}

	private void AddLanguageButton()
	{
		LocalizationManager.InitializeIfNeeded();
		CultureInfo cultureInfo = new CultureInfo(LocalizationManager.mLanguageCode, true, false);
		string nativeName = cultureInfo.NativeName;
		string buttonText = Extensions.FirstCharToUpper(nativeName);
		string labelText = Translate("lang/options_language");
		Action callback = OpenLanguagesPage;
		bool textIsLocalizationTerm = default(bool);
		LabeledButtonUI labeledButtonUI = AddLabeledButton(labelText, buttonText, callback, textIsLocalizationTerm);
	}

	private void AddVisuallyInvertStages()
	{
		//IL_008d: Expected I4, but got O
		PlayerOptionsData config = _playerOptions.Config;
		List<ItemType> list = config._003CCollectedItems_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ rcx_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				PlayerOptionsData config2 = _playerOptions.Config;
				Action<bool> action = null;
				((OptionsController)(object)action).ToggleVisualInvert((byte)(int)this != 0);
				bool textIsLocalizationTerm = default(bool);
				TickBoxUI tickBoxUI = AddTickBox("lang/options_invertStages", config2._003CVisuallyInvertStages_003Ek__BackingField, action, textIsLocalizationTerm);
			}
		}
	}

	private void AddDisableMovingBackground()
	{
		//IL_0161: Expected I4, but got O
		GameManager core = GM.Core;
		if ((object)GM.Core == null || ((UnityEngine.Object)core).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		GameManager core2 = GM.Core;
		Stage stage = core2._stage;
		if ((object)core2._stage == null || ((UnityEngine.Object)stage).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		GameManager core3 = GM.Core;
		Stage stage2 = core3._stage;
		BackgroundManager fancyBg = stage2._fancyBg;
		if ((object)stage2._fancyBg != null && ((UnityEngine.Object)fancyBg).m_CachedPtr != (IntPtr)0)
		{
			GameManager core4 = GM.Core;
			Stage stage3 = core4._stage;
			BackgroundManager fancyBg2 = stage3._fancyBg;
			if (fancyBg2._003CHasMovingBg_003Ek__BackingField)
			{
				PlayerOptionsData config = _playerOptions.Config;
				Action<bool> action = null;
				((OptionsController)(object)action).ToggleMovingBackground((byte)(int)this != 0);
				bool textIsLocalizationTerm = default(bool);
				TickBoxUI tickBoxUI = AddTickBox("lang/disableMovingBackground", config._003CDisableMovingBackground_003Ek__BackingField, action, textIsLocalizationTerm);
			}
		}
	}

	private void AddFullScreen()
	{
		//IL_0028: Expected I4, but got O
		PlayerOptionsData config = _playerOptions.Config;
		Action<bool> action = null;
		((OptionsController)(object)action).SetFullscreen((byte)(int)this != 0);
		bool textIsLocalizationTerm = default(bool);
		TickBoxUI tickBoxUI = AddTickBox("lang/options_fullscreen", config._003CFullscreen_003Ek__BackingField, action, textIsLocalizationTerm);
	}

	private void AddJoystickTypes()
	{
		List<string> list = new List<string>();
		int version = list._version + 1;
		list._version = version;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"lang/options_legacy");
		}
		else
		{
			int size = list._size + 1;
			list._size = size;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version2 = list._version + 1;
		list._version = version2;
		string[] items2 = list._items;
		if (list._size >= items2.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"lang/options_default");
		}
		else
		{
			int size2 = list._size + 1;
			list._size = size2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		List<Action> callbacks = new List<Action>();
		Action action = SetJoystickLegacy;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809F2220");
		Action action2 = SetJoystickDefault;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809F2220");
		PlayerOptionsData config = _playerOptions.Config;
		int selectedIndex = default(int);
		bool textIsLocalizedTerm = default(bool);
		AddMultipleChoice("lang/options_joystickType", list, callbacks, selectedIndex, textIsLocalizedTerm);
	}

	private void AddOrientations()
	{
		//IL_0286: Expected O, but got I4
		//IL_0379: Expected I4, but got O
		//IL_02a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ab: Expected O, but got Unknown
		//IL_0356: Expected I4, but got O
		//IL_02c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c7: Expected O, but got Unknown
		List<string> list = new List<string>();
		int version = list._version + 1;
		list._version = version;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"lang/options_portrait");
		}
		else
		{
			int size = list._size + 1;
			list._size = size;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version2 = list._version + 1;
		list._version = version2;
		string[] items2 = list._items;
		if (list._size >= items2.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"lang/options_portraitInverse");
		}
		else
		{
			int size2 = list._size + 1;
			list._size = size2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version3 = list._version + 1;
		list._version = version3;
		string[] items3 = list._items;
		if (list._size >= items3.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"lang/options_landscapeLeft");
		}
		else
		{
			int size3 = list._size + 1;
			list._size = size3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version4 = list._version + 1;
		list._version = version4;
		string[] items4 = list._items;
		bool flag = list._size == items4.Length;
		if (list._size >= items4.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"lang/options_landscapeRight");
		}
		else
		{
			int size4 = list._size + 1;
			list._size = size4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		object obj = _currentScreenOrientation - 1;
		int selectedIndex = 0;
		if (!flag)
		{
			object obj2 = obj - 1;
			if (!flag)
			{
				object obj3 = obj2 - 1;
				if (!flag)
				{
					bool flag2 = (nint)obj3 != 1;
					selectedIndex = 0;
					if (!flag2)
					{
						selectedIndex = 3;
					}
				}
				else
				{
					selectedIndex = 2;
				}
			}
			else
			{
				selectedIndex = 1;
			}
		}
		Action<int> action = null;
		((OptionsController)(object)action).SetOrientation((int)this);
		Action<int> action2 = default(Action<int>);
		int howManyOptionsToShowAtOnce = default(int);
		bool textIsLocalizationTerm = default(bool);
		CustomDropDown customDropDown = AddDropDown("lang/options_orientation", list, selectedIndex, action2, howManyOptionsToShowAtOnce, textIsLocalizationTerm);
		Action callback = ApplySelectedOrientation;
		LabeledButtonUI labeledButtonUI = AddLabeledButton("lang/options_applyOrientation", "lang/options_apply", callback, (byte)(int)action2 != 0);
	}

	private unsafe int GetResolutionIndex(int screenWidth, int screenHeight)
	{
		//IL_0090: Expected I4, but got I8
		//IL_00ed: Expected O, but got I
		//IL_0100: Expected O, but got I4
		//IL_012d: Expected O, but got Ref
		//IL_015b: Expected O, but got Ref
		//IL_0241: Expected O, but got I4
		//IL_0271: Expected O, but got I4
		//IL_0294: Expected O, but got I4
		//IL_02b4: Expected O, but got I4
		List<string> resolutionStrings = _resolutionStrings;
		int version = resolutionStrings._version + 1;
		resolutionStrings._version = version;
		resolutionStrings._size = 0;
		if (resolutionStrings._size > 0)
		{
			Array.Clear(resolutionStrings._items, 0, resolutionStrings._size);
		}
		List<Resolution> resolutions = _resolutions;
		int result = -1;
		int num = 0;
		int num2 = 0;
		Resolution? resolution = default(Resolution?);
		while (true)
		{
			int num3 = num2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v246 @ rax_v10 (System.Collections.Generic.List`1<UnityEngine.Resolution>)+18]");
			if ((nint)num3 < (nint)0)
			{
				List<Resolution> resolutions2 = _resolutions;
				int num4 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ rax_v12 (System.Collections.Generic.List`1<UnityEngine.Resolution>)+18]");
				if ((nint)num4 >= (nint)0)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ rax_v12 (System.Collections.Generic.List`1<UnityEngine.Resolution>)+10]");
				object obj = 0;
				object obj2 = num + 2;
				object obj3 = obj2 + obj2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ rcx_v10+v402 @ rax_v15*8]");
				string text = System.Number.FormatInt32(0, (ReadOnlySpan<char>)(&resolution), null);
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,4\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ rcx_v10+v402 @ rax_v15*8]");
				string text2 = System.Number.FormatInt32(0, (ReadOnlySpan<char>)(&resolution), null);
				string item = text + "x" + text2;
				List<object> resolutionStrings2 = (List<object>)(object)_resolutionStrings;
				int version2 = resolutionStrings2._version + 1;
				resolutionStrings2._version = version2;
				object[] items = resolutionStrings2._items;
				if (resolutionStrings2._size >= items.Length)
				{
					resolutionStrings2.AddWithResize((object)item);
				}
				else
				{
					int size = resolutionStrings2._size + 1;
					resolutionStrings2._size = size;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ rcx_v10+v402 @ rax_v15*8]");
				bool flag = (nint)screenWidth != 0;
				resolution = (Resolution?)(object)0;
				if (!flag)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ rcx_v10+v402 @ rax_v15*8]");
					bool flag2 = (nint)screenHeight != 0;
					resolution = (Resolution?)(object)0;
					if (!flag2)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm6,0Ch\"");
						_selectedResolution = (Resolution?)(object)1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ rcx_v10+v402 @ rax_v15*8]");
						_ = 0;
						result = num;
						resolution = (Resolution?)(object)1;
					}
				}
				resolutions = _resolutions;
				num++;
				num2 = num;
				continue;
			}
			return result;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		int result2 = default(int);
		return result2;
	}

	private void AddResolutions()
	{
		//IL_02c2: Expected I4, but got O
		//IL_029a: Expected O, but got I4
		//IL_0325: Expected I4, but got O
		//IL_0346: Expected I4, but got O
		//IL_0139: Expected I4, but got O
		//IL_0147: Expected O, but got I4
		//IL_016d: Expected I4, but got O
		//IL_01f9: Expected I4, but got O
		int width = Screen.width;
		int height = Screen.height;
		int resolutionIndex = GetResolutionIndex(width, height);
		if (_selectedResolution == null)
		{
			Screen.get_currentResolution_Injected(out Resolution _);
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,0Ch\"");
			_selectedResolution = (Resolution?)(object)1;
		}
		bool flag = resolutionIndex != -1;
		int num = resolutionIndex;
		if (!flag)
		{
			bool flag2 = _selectedResolution == null;
			num = resolutionIndex;
			if (!flag2)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ rcx_v1 (VampireSurvivors.UI.OptionsController)+F4]");
				int screenHeight = (int)((nint)0 >> 32);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ rcx_v1 (VampireSurvivors.UI.OptionsController)+F4]");
				int resolutionIndex2 = GetResolutionIndex(0, screenHeight);
				num = resolutionIndex2;
			}
		}
		string text = Translate("lang/options_resolution");
		Action<int> action = null;
		((OptionsController)(object)action).SetResolution((int)this);
		bool flag3 = num == -1;
		int selectedIndex = 0;
		if (!flag3)
		{
			selectedIndex = num;
		}
		Action<int> action2 = default(Action<int>);
		int num2 = default(int);
		bool flag4 = default(bool);
		CustomDropDown screenResolutionDropdown = AddDropDown(text, _resolutionStrings, selectedIndex, action2, num2, flag4);
		_screenResolutionDropdown = screenResolutionDropdown;
		HandleRefreshRateDropdown();
		SystemPlatform sInstance = SystemPlatform.sInstance;
		if (sInstance.m_CurrentSystem.DoesSupportWindowModes())
		{
			AddWindowTypes();
		}
		SystemPlatform sInstance2 = SystemPlatform.sInstance;
		if (sInstance2.m_CurrentSystem.DoesSupportVSync())
		{
			int num3 = PlayerPrefs.GetInt("VS_VSyncEnabled", 1);
			Action<bool> action3 = null;
			((OptionsController)(object)action3).SetVsyncEnabled((byte)(int)this != 0);
			object obj = num3 - 1;
			bool defaultValue = obj == null;
			TickBoxUI vSyncTickBox = AddTickBox("lang/options_enable_vsync", defaultValue, action3, (byte)(int)action2 != 0);
			_vSyncTickBox = vSyncTickBox;
		}
		Action<int> action4 = null;
		((OptionsController)(object)action4).SetTargetFrameRate((int)this);
		SliderUI frameRateSlider = AddSliderInteger("lang/options_target_framerate", _selectedFrameRate, action4, (byte)(int)action2 != 0, num2, flag4 ? 1 : 0);
		_frameRateSlider = frameRateSlider;
		GameObject gameObject = _frameRateSlider.gameObject;
		bool active = !_vSyncEnabled;
		gameObject.SetActive(active);
		Action callback = ApplyGraphicsSettings;
		LabeledButtonUI applyGraphicsButton = AddLabeledButton("", "lang/options_apply", callback, (byte)(int)action2 != 0);
		_applyGraphicsButton = applyGraphicsButton;
	}

	private unsafe void HandleRefreshRateDropdown()
	{
		//IL_00c6: Expected I4, but got I8
		//IL_0393: Expected I4, but got O
		//IL_0139: Expected O, but got Ref
		//IL_0139: Expected I4, but got F8
		//IL_037f: Expected I4, but got O
		//IL_01ab: Expected O, but got I
		//IL_0250: Invalid comparison between F8 and I4
		if (_selectedResolution == null)
		{
			return;
		}
		List<string> list = new List<string>();
		Resolution[] resolutions = Screen.resolutions;
		Func<Resolution, bool> func = null;
		bool flag = ((OptionsController)(object)func)._003CHandleRefreshRateDropdown_003Eb__89_0((Resolution)this);
		IEnumerable<Resolution> source = Enumerable.Where(resolutions, func);
		IEnumerable<Resolution> enumerable = Enumerable.Where(source, func);
		if (enumerable != null)
		{
			List<Resolution> currentRefreshRateResolutions = new List<Resolution>(enumerable);
			_currentRefreshRateResolutions = currentRefreshRateResolutions;
			List<Resolution> currentRefreshRateResolutions2 = _currentRefreshRateResolutions;
			int num = 0;
			int num2 = -1;
			int num3 = 0;
			object obj = default(object);
			object message = default(object);
			object message2 = default(object);
			Action<int> action = default(Action<int>);
			int howManyOptionsToShowAtOnce = default(int);
			bool textIsLocalizationTerm = default(bool);
			while (true)
			{
				int num4 = num3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v469 @ rax_v26 (System.Collections.Generic.List`1<UnityEngine.Resolution>)+18]");
				if ((nint)num4 < (nint)0)
				{
					List<Resolution> currentRefreshRateResolutions3 = _currentRefreshRateResolutions;
					int num5 = num;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v465 @ rax_v49 (System.Collections.Generic.List`1<UnityEngine.Resolution>)+18]");
					if ((nint)num5 >= (nint)0)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm6,0Ch\"");
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2sd xmm7,rax\"");
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2sd xmm1,rax\"");
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"divsd xmm7,xmm1\"");
					double num6 = Math.Round(0.0);
					string text = System.Number.FormatInt32((int)num6, (ReadOnlySpan<char>)(&obj), null);
					int version = list._version + 1;
					list._version = version;
					string[] items = list._items;
					if (list._size >= items.Length)
					{
						((List<object>)(object)list).AddWithResize((object)text);
						string text2 = (string)0;
					}
					else
					{
						int size = list._size + 1;
						list._size = size;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						string text2 = text;
					}
					if (_selectedRefreshRate != -1)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182AD6810");
						Debug.Log(message);
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2sd xmm6,rax\"");
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2sd xmm1,rax\"");
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"divsd xmm6,xmm1\"");
						double num7 = Math.Round(0.0);
						bool flag2 = num7 != (double)_selectedRefreshRate;
						int selectedRefreshRate = _selectedRefreshRate;
						if (!flag2)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182AD6810");
							Debug.Log(message2);
							selectedRefreshRate = num;
							num2 = num;
						}
					}
					currentRefreshRateResolutions2 = _currentRefreshRateResolutions;
					num++;
					num3 = num;
					continue;
				}
				if (list._size > 0)
				{
					if (num2 == -1)
					{
						num2 = list._size - 1;
					}
					CustomDropDown refreshRateDropdown = _refreshRateDropdown;
					if ((object)_refreshRateDropdown != null && ((UnityEngine.Object)refreshRateDropdown).m_CachedPtr != (IntPtr)0)
					{
						RegenerateDropdownOptions(_refreshRateDropdown, list, num2, (byte)(int)action != 0);
					}
					else
					{
						Action<int> action2 = null;
						((OptionsController)(object)action2).SetRefreshRate((int)this);
						CustomDropDown refreshRateDropdown2 = AddDropDown("lang/options_screen_refresh_rate", list, num2, action, howManyOptionsToShowAtOnce, textIsLocalizationTerm);
						_refreshRateDropdown = refreshRateDropdown2;
					}
					UpdateRefreshRateDropdownVisibility();
				}
				return;
			}
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			return;
		}
		Exception ex = System.Linq.Error.ArgumentNull("source");
		throw ex;
	}

	private void AddFrameRateSlider()
	{
		//IL_0024: Expected I4, but got O
		Action<int> action = null;
		((OptionsController)(object)action).SetTargetFrameRate((int)this);
		bool textIsLocalizationTerm = default(bool);
		int minValue = default(int);
		int maxValue = default(int);
		SliderUI frameRateSlider = AddSliderInteger("lang/options_target_framerate", _selectedFrameRate, action, textIsLocalizationTerm, minValue, maxValue);
		_frameRateSlider = frameRateSlider;
	}

	private unsafe void AddBorderTypes()
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected O, but got Unknown
		//IL_0360: Expected O, but got Ref
		//IL_037c: Expected O, but got Ref
		//IL_00f5: Expected I, but got O
		//IL_0180: Expected O, but got I4
		//IL_05df: Expected I, but got O
		//IL_012d: Expected O, but got I
		//IL_0136: Expected O, but got I4
		//IL_02f3: Expected O, but got I
		//IL_030a: Unknown result type (might be due to invalid IL or missing references)
		//IL_030f: Expected O, but got Unknown
		//IL_0317: Unknown result type (might be due to invalid IL or missing references)
		//IL_031c: Expected O, but got Unknown
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Expected O, but got Unknown
		//IL_04af: Expected I4, but got O
		//IL_04d2: Expected I4, but got O
		//IL_04d2: Expected I4, but got O
		//IL_04d2: Expected O, but got I4
		//IL_01d2: Expected O, but got Ref
		List<string> list = new List<string>();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		object obj4 = default(object);
		object obj3 = obj4;
		PlayerOptionsData playerOptionsData;
		if (obj3 != null)
		{
			object obj5 = obj3;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v175 @ rdx_v13+8F8] (should have been resolved before IL gen)");
			Array array = default(Array);
			IEnumerator enumerator = array.GetEnumerator();
			Array array2 = array;
			Array array3 = default(Array);
			object obj6 = default(object);
			object obj18 = default(object);
			object obj19 = default(object);
			int num3 = default(int);
			IntPtr intPtr = default(IntPtr);
			while (true)
			{
				object obj7;
				object obj15;
				if (array3 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
					if (obj6 != null)
					{
						bool flag = array3 == null;
						array2 = null;
						if (!flag)
						{
							nint num = (nint)array3;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v320 @ r10_v10 (Il2CppClass<System.Array>)+12E]");
							if ((nint)0 >= (nint)0)
							{
								goto IL_016d;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v320 @ r10_v10 (Il2CppClass<System.Array>)+B0]");
							obj7 = 0;
							object obj8 = 0;
							while (true)
							{
								object obj9 = obj8 + obj8;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v789 @ r8_v16+v639 @ rax_v75*8]");
								if (0 == (nint)typeof(IEnumerator))
								{
									break;
								}
								obj8++;
								object obj10 = obj8;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v320 @ r10_v10 (Il2CppClass<System.Array>)+12E]");
								if ((nint)obj10 < 0)
								{
									continue;
								}
								goto IL_016d;
							}
							object obj11 = obj8 + obj8;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v789 @ r8_v16+8+v782 @ rcx_v52*8]");
							object obj12 = (nint)0 + (nint)1;
							object obj13 = obj12 << 4;
							object obj14 = obj13 + 312;
							obj15 = obj14 + num;
							goto IL_05c7;
						}
						throw new NullReferenceException();
					}
					object obj16 = (object)(&array3);
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
					object obj17 = (object)(&array3);
					obj17 = obj18;
					if (obj18 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
					}
					break;
				}
				throw new NullReferenceException();
				IL_016d:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
				obj7 = 1;
				obj15 = obj19;
				goto IL_05c7;
				IL_05c7:
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v790 @ rdx_v25] (should have been resolved before IL gen)");
				nint num2 = (nint)typeof(BorderType);
				bool flag2 = num3 == 0;
				array2 = array3;
				if (!flag2)
				{
					int value = ((int*)num3)->m_value;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v756 @ rcx_v42 (System.Int32)+40]");
					nint num4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v752 @ rdx_v27 (Il2CppClass<VampireSurvivors.Data.BorderType>)+40]");
					if (num4 == 0)
					{
						string text = ((Enum)(&intPtr)).ToString();
						if (text != null)
						{
							string text2 = text.ToLowerInvariant();
							string text3 = "lang/options_borders_" + text2;
							if (list != null)
							{
								int version = list._version + 1;
								list._version = version;
								array2 = list._items;
								if (list._items != null)
								{
									int size = list._size;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v256 @ rcx_v11 (System.Array)+18]");
									if ((nint)size >= (nint)0)
									{
										((List<object>)(object)list).AddWithResize((object)text3);
										string text4 = text3;
										array2 = (Array)(object)list;
									}
									else
									{
										int size2 = list._size + 1;
										list._size = size2;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
										string text4 = text3;
									}
									continue;
								}
								throw new NullReferenceException();
							}
							throw new NullReferenceException();
						}
						throw new NullReferenceException();
					}
					throw new InvalidCastException();
				}
				throw new NullReferenceException();
			}
			PlayerOptions playerOptions = _playerOptions;
			if (playerOptions._onlineClientWithRunDataConfig == null)
			{
				if (playerOptions._hostGameConfig == null)
				{
					if (playerOptions._currentAdventureSaveData != null)
					{
						playerOptionsData = playerOptions._currentAdventureSaveData;
						if ((object)playerOptionsData._003CSelectedAdventureType_003Ek__BackingField != null)
						{
							goto IL_046e;
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
			goto IL_046e;
		}
		ArgumentNullException ex = new ArgumentNullException("enumType");
		throw ex;
		IL_046e:
		bool flag3 = default(bool);
		GameObject gameObject = default(GameObject);
		string text5 = default(string);
		bool allowLocalizedParameters = default(bool);
		string translation = LocalizationManager.GetTranslation("lang/options_borders", FixForRTL: true, 0, ignoreRTLnumbers: true, flag3, gameObject, text5, allowLocalizedParameters);
		Action<int> action = null;
		((OptionsController)(object)action).SetBorderType((int)this);
		CustomDropDown customDropDown = AddDropDown(translation, list, (int)playerOptionsData._003CBorderType_003Ek__BackingField, (Action<int>)flag3, (int)gameObject, (byte)(int)text5 != 0);
	}

	private void AddWindowTypes()
	{
		//IL_0270: Expected I4, but got O
		int fullScreenMode = (int)Screen.fullScreenMode;
		List<string> list = new List<string>();
		int version = list._version + 1;
		list._version = version;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"lang/exclusive_fullscreen");
		}
		else
		{
			int size = list._size + 1;
			list._size = size;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version2 = list._version + 1;
		list._version = version2;
		string[] items2 = list._items;
		if (list._size >= items2.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"lang/fullscreen_window");
		}
		else
		{
			int size2 = list._size + 1;
			list._size = size2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version3 = list._version + 1;
		list._version = version3;
		string[] items3 = list._items;
		if (list._size >= items3.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"lang/maximised_window");
		}
		else
		{
			int size3 = list._size + 1;
			list._size = size3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version4 = list._version + 1;
		list._version = version4;
		string[] items4 = list._items;
		if (list._size >= items4.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"lang/windowed");
		}
		else
		{
			int size4 = list._size + 1;
			list._size = size4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		Action<int> action = null;
		((OptionsController)(object)action).SetWindowMode((int)this);
		Action<int> callbackWithNewSelectedIndex = default(Action<int>);
		int howManyOptionsToShowAtOnce = default(int);
		bool textIsLocalizationTerm = default(bool);
		CustomDropDown customDropDown = AddDropDown("lang/options_window_mode", list, fullScreenMode, callbackWithNewSelectedIndex, howManyOptionsToShowAtOnce, textIsLocalizationTerm);
	}

	private void AddVisibleJoysticks()
	{
		//IL_0028: Expected I4, but got O
		PlayerOptionsData config = _playerOptions.Config;
		Action<bool> action = null;
		((OptionsController)(object)action).VisibleJoystick((byte)(int)this != 0);
		bool textIsLocalizationTerm = default(bool);
		TickBoxUI tickBoxUI = AddTickBox("lang/options_visible_control_stick", config._003CJoystickVisible_003Ek__BackingField, action, textIsLocalizationTerm);
	}

	private void AddSoundEffectTypes()
	{
		List<string> list = new List<string>();
		int version = list._version + 1;
		list._version = version;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"lang/options_SFX_classic");
		}
		else
		{
			int size = list._size + 1;
			list._size = size;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version2 = list._version + 1;
		list._version = version2;
		string[] items2 = list._items;
		if (list._size >= items2.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"lang/options_SFX_blast");
		}
		else
		{
			int size2 = list._size + 1;
			list._size = size2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		List<Action> callbacks = new List<Action>();
		Action action = SetClassicMusic;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809F2220");
		Action action2 = SetBlastProcessedMusic;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809F2220");
		PlayerOptionsData config = _playerOptions.Config;
		int selectedIndex = default(int);
		bool textIsLocalizedTerm = default(bool);
		AddMultipleChoice("lang/options_classicmusic", list, callbacks, selectedIndex, textIsLocalizedTerm);
	}

	public LabeledInputUI AddLabeledInput(string labelText, string defaultValue = "", string placeholder = "", bool textIsLocalizationTerm = true)
	{
		//IL_0374: Expected O, but got I4
		//IL_03b8: Expected O, but got I4
		//IL_035a->IL02e9: Incompatible stack heights: 1 vs 0
		//IL_023e->IL02e9: Incompatible stack heights: 1 vs 0
		//IL_039e->IL02e9: Incompatible stack heights: 2 vs 0
		//IL_03d0->IL02e9: Incompatible stack heights: 3 vs 0
		//IL_02d5->IL02e9: Incompatible stack heights: 3 vs 0
		GameObject gameObject = UnityEngine.Object.Instantiate(_InputPrefab, _Content);
		if ((object)gameObject != null)
		{
			LabeledInputUI component = gameObject.GetComponent<LabeledInputUI>();
			object obj = default(object);
			bool flag = obj == null;
			string text = labelText;
			if (!flag)
			{
				string text2 = Translate(labelText);
				text = text2;
			}
			if ((object)component != null && (object)component._Label != null)
			{
				component._Label.text = text;
				bool flag2 = defaultValue == null;
				string text3 = placeholder;
				if (!flag2)
				{
					bool flag3 = defaultValue._stringLength <= 0;
					text3 = placeholder;
					if (!flag3)
					{
						if ((object)component._Input == null)
						{
							goto IL_02e9;
						}
						component._Input.SetText(defaultValue, true);
						text3 = null;
					}
				}
				if (placeholder != null && placeholder._stringLength > 0)
				{
					component.SetInputPlaceholderText(placeholder);
				}
				RectTransform component2 = component.GetComponent<RectTransform>();
				if ((object)_Content != null)
				{
					VerticalLayoutGroup component3 = _Content.GetComponent<VerticalLayoutGroup>();
					string content = (string)(object)_Content;
					if ((object)_Content != null)
					{
						bool flag4 = content._stringLength == 0;
						RectTransform.get_rect_Injected((IntPtr)content._stringLength, out Rect _);
						if ((object)component3 != null)
						{
							object padding = ((LayoutGroup)component3).m_Padding;
							if (((LayoutGroup)component3).m_Padding != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v145 @ rcx_v28 (System.Object)+10]");
								bool flag5 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v145 @ rcx_v28 (System.Object)+10]");
								object obj2 = RectOffset.get_left_Injected((IntPtr)0);
								object padding2 = ((LayoutGroup)component3).m_Padding;
								if (((LayoutGroup)component3).m_Padding != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ rcx_v31 (System.Object)+10]");
									bool flag6 = (nint)0 == 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ rcx_v31 (System.Object)+10]");
									string text4 = (string)RectOffset.get_right_Injected((IntPtr)0);
									if ((object)component2 != null)
									{
										Vector2 sizeDelta = component2.sizeDelta;
										object obj3 = text4 + obj2;
										Vector2 sizeDelta2 = default(Vector2);
										component2.sizeDelta = sizeDelta2;
										if (_spawnedElements != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9B920");
											return component;
										}
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_02e9;
		IL_02e9:
		throw new NullReferenceException();
	}

	private SliderUI AddSlider(string text, float defaultValue, Action<float> valueChangeCallback, bool textIsLocalizationTerm = true, float minValue = 0f, float maxValue = 1f)
	{
		//IL_0387: Expected O, but got I4
		//IL_03cb: Expected O, but got I4
		//IL_036d->IL0319: Incompatible stack heights: 1 vs 0
		//IL_00e1->IL0319: Incompatible stack heights: 1 vs 0
		//IL_03b1->IL0319: Incompatible stack heights: 2 vs 0
		//IL_03e3->IL0319: Incompatible stack heights: 3 vs 0
		//IL_0400->IL0319: Incompatible stack heights: 3 vs 0
		//IL_01ae->IL0319: Incompatible stack heights: 3 vs 0
		//IL_01e2->IL0319: Incompatible stack heights: 3 vs 0
		//IL_0217->IL0319: Incompatible stack heights: 3 vs 0
		//IL_024b->IL0319: Incompatible stack heights: 3 vs 0
		//IL_027f->IL0319: Incompatible stack heights: 3 vs 0
		//IL_042f->IL0319: Incompatible stack heights: 3 vs 0
		//IL_02cf->IL0319: Incompatible stack heights: 3 vs 0
		//IL_0300->IL0319: Incompatible stack heights: 3 vs 0
		GameObject gameObject = UnityEngine.Object.Instantiate(_SliderPrefab, _Content);
		if ((object)gameObject != null)
		{
			SliderUI component = gameObject.GetComponent<SliderUI>();
			RectTransform component2 = gameObject.GetComponent<RectTransform>();
			if ((object)_Content != null)
			{
				VerticalLayoutGroup component3 = _Content.GetComponent<VerticalLayoutGroup>();
				GameObject content = (GameObject)(object)_Content;
				if ((object)_Content != null)
				{
					bool flag = ((UnityEngine.Object)content).m_CachedPtr == (IntPtr)0;
					RectTransform.get_rect_Injected(((UnityEngine.Object)content).m_CachedPtr, out Rect _);
					if ((object)component3 != null)
					{
						object padding = ((LayoutGroup)component3).m_Padding;
						if (((LayoutGroup)component3).m_Padding != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ rcx_v24 (System.Object)+10]");
							bool flag2 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ rcx_v24 (System.Object)+10]");
							object obj = RectOffset.get_left_Injected((IntPtr)0);
							object padding2 = ((LayoutGroup)component3).m_Padding;
							if (((LayoutGroup)component3).m_Padding != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v183 @ rcx_v27 (System.Object)+10]");
								bool flag3 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v183 @ rcx_v27 (System.Object)+10]");
								GameObject gameObject2 = (GameObject)RectOffset.get_right_Injected((IntPtr)0);
								if ((object)component2 != null)
								{
									Vector2 sizeDelta = component2.sizeDelta;
									Vector2 sizeDelta2 = default(Vector2);
									component2.sizeDelta = sizeDelta2;
									object obj2 = default(object);
									bool flag4 = obj2 == null;
									string text2 = text;
									if (!flag4)
									{
										string text3 = Translate(text);
										text2 = text3;
									}
									if ((object)component != null && (object)component._label != null)
									{
										component._label.text = text2;
										if ((object)component._slider != null)
										{
											component._slider.wholeNumbers = false;
											if ((object)component._slider != null)
											{
												float minValue2 = default(float);
												component._slider.minValue = minValue2;
												if ((object)component._slider != null)
												{
													float maxValue2 = default(float);
													component._slider.maxValue = maxValue2;
													if ((object)component._slider != null)
													{
														component._slider.value = defaultValue;
														Slider slider = component._slider;
														if ((object)component._slider != null)
														{
															UnityAction<float> unityAction = null;
															unityAction(defaultValue);
															if (slider.m_OnValueChanged != null)
															{
																slider.m_OnValueChanged.AddListener(unityAction);
																if (_spawnedElements != null)
																{
																	((UnityEvent<float>)(object)_spawnedElements).AddListener((UnityAction<float>)(object)component);
																	return component;
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
		throw new NullReferenceException();
	}

	private SliderUI AddSliderInteger(string text, int defaultValue, Action<int> valueChangeCallback, bool textIsLocalizationTerm = true, int minValue = 0, int maxValue = 100)
	{
		//IL_030c: Expected O, but got I4
		//IL_0350: Expected O, but got I4
		//IL_02f2->IL029e: Incompatible stack heights: 1 vs 0
		//IL_00e1->IL029e: Incompatible stack heights: 1 vs 0
		//IL_0336->IL029e: Incompatible stack heights: 2 vs 0
		//IL_0368->IL029e: Incompatible stack heights: 3 vs 0
		//IL_0385->IL029e: Incompatible stack heights: 3 vs 0
		//IL_01ae->IL029e: Incompatible stack heights: 3 vs 0
		//IL_03ab->IL029e: Incompatible stack heights: 3 vs 0
		//IL_021b->IL029e: Incompatible stack heights: 3 vs 0
		//IL_0254->IL029e: Incompatible stack heights: 3 vs 0
		//IL_0285->IL029e: Incompatible stack heights: 3 vs 0
		GameObject gameObject = UnityEngine.Object.Instantiate(_SliderPrefab, _Content);
		if ((object)gameObject != null)
		{
			SliderUI component = gameObject.GetComponent<SliderUI>();
			RectTransform component2 = gameObject.GetComponent<RectTransform>();
			if ((object)_Content != null)
			{
				VerticalLayoutGroup component3 = _Content.GetComponent<VerticalLayoutGroup>();
				GameObject content = (GameObject)(object)_Content;
				if ((object)_Content != null)
				{
					bool flag = ((UnityEngine.Object)content).m_CachedPtr == (IntPtr)0;
					RectTransform.get_rect_Injected(((UnityEngine.Object)content).m_CachedPtr, out Rect _);
					if ((object)component3 != null)
					{
						object padding = ((LayoutGroup)component3).m_Padding;
						if (((LayoutGroup)component3).m_Padding != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v170 @ rcx_v24 (System.Object)+10]");
							bool flag2 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v170 @ rcx_v24 (System.Object)+10]");
							object obj = RectOffset.get_left_Injected((IntPtr)0);
							object padding2 = ((LayoutGroup)component3).m_Padding;
							if (((LayoutGroup)component3).m_Padding != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v177 @ rcx_v27 (System.Object)+10]");
								bool flag3 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v177 @ rcx_v27 (System.Object)+10]");
								GameObject gameObject2 = (GameObject)RectOffset.get_right_Injected((IntPtr)0);
								if ((object)component2 != null)
								{
									Vector2 sizeDelta = component2.sizeDelta;
									Vector2 sizeDelta2 = default(Vector2);
									component2.sizeDelta = sizeDelta2;
									object obj2 = default(object);
									bool flag4 = obj2 == null;
									string text2 = text;
									if (!flag4)
									{
										string text3 = Translate(text);
										text2 = text3;
									}
									if ((object)component != null && (object)component._label != null)
									{
										component._label.text = text2;
										int minValue2 = default(int);
										int maxValue2 = default(int);
										component.InitialSet(defaultValue, minValue2, maxValue2);
										SliderUI._003C_003Ec__DisplayClass5_0 obj3 = new SliderUI._003C_003Ec__DisplayClass5_0();
										if (obj3 != null)
										{
											obj3._003C_003E4__this = component;
											Slider slider = component._slider;
											if ((object)component._slider != null)
											{
												UnityAction<float> unityAction = null;
												float v = default(float);
												((SliderUI._003C_003Ec__DisplayClass5_0)(object)unityAction)._003CAddOnValueChange_003Eb__0(v);
												if (slider.m_OnValueChanged != null)
												{
													slider.m_OnValueChanged.AddListener(unityAction);
													if (_spawnedElements != null)
													{
														((UnityEvent<float>)(object)_spawnedElements).AddListener((UnityAction<float>)(object)component);
														return component;
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
	}

	private CustomDropDown AddDropDown(string text, List<string> options, int selectedIndex, Action<int> callbackWithNewSelectedIndex, int howManyOptionsToShowAtOnce = 4, bool textIsLocalizationTerm = true)
	{
		//IL_04d0: Expected O, but got I4
		//IL_0514: Expected O, but got I4
		//IL_02b0: Expected O, but got I4
		//IL_02b0: Expected I4, but got O
		//IL_0329: Unknown result type (might be due to invalid IL or missing references)
		//IL_032e: Expected O, but got Unknown
		//IL_04b6->IL0462: Incompatible stack heights: 1 vs 0
		//IL_00e1->IL0462: Incompatible stack heights: 1 vs 0
		//IL_04fa->IL0462: Incompatible stack heights: 2 vs 0
		//IL_052c->IL0462: Incompatible stack heights: 3 vs 0
		//IL_01dd->IL0462: Incompatible stack heights: 3 vs 0
		//IL_03e2->IL0462: Incompatible stack heights: 4 vs 0
		//IL_0258->IL0462: Incompatible stack heights: 4 vs 0
		//IL_044e->IL0462: Incompatible stack heights: 4 vs 0
		//IL_02f1->IL0462: Incompatible stack heights: 6 vs 0
		//IL_035c->IL01e2: Incompatible stack heights: 6 vs 3
		GameObject gameObject = UnityEngine.Object.Instantiate(_DropdownPrefab, _Content);
		if ((object)gameObject != null)
		{
			CustomDropDown component = gameObject.GetComponent<CustomDropDown>();
			RectTransform component2 = gameObject.GetComponent<RectTransform>();
			if ((object)_Content != null)
			{
				VerticalLayoutGroup component3 = _Content.GetComponent<VerticalLayoutGroup>();
				GameObject content = (GameObject)(object)_Content;
				if ((object)_Content != null)
				{
					bool flag = ((UnityEngine.Object)content).m_CachedPtr == (IntPtr)0;
					RectTransform.get_rect_Injected(((UnityEngine.Object)content).m_CachedPtr, out Rect _);
					if ((object)component3 != null)
					{
						object padding = ((LayoutGroup)component3).m_Padding;
						if (((LayoutGroup)component3).m_Padding != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v207 @ rcx_v31 (System.Object)+10]");
							bool flag2 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v207 @ rcx_v31 (System.Object)+10]");
							object obj = RectOffset.get_left_Injected((IntPtr)0);
							object padding2 = ((LayoutGroup)component3).m_Padding;
							if (((LayoutGroup)component3).m_Padding != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v214 @ rcx_v34 (System.Object)+10]");
								bool flag3 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v214 @ rcx_v34 (System.Object)+10]");
								GameObject gameObject2 = (GameObject)RectOffset.get_right_Injected((IntPtr)0);
								if ((object)component2 != null)
								{
									Vector2 sizeDelta = component2.sizeDelta;
									object obj2 = (object)gameObject2 + obj;
									Vector2 vector = default(Vector2);
									component2.sizeDelta = vector;
									object obj3 = default(object);
									bool flag4 = obj3 == null;
									int num = selectedIndex;
									Vector2 vector2 = vector;
									string text2 = null;
									string text3 = text;
									Action<int> action = default(Action<int>);
									bool flag9 = default(bool);
									if (!flag4)
									{
										string text4 = Translate(text);
										bool flag5 = options == null;
										num = selectedIndex;
										GameObject gameObject3 = null;
										vector2 = (Vector2)text;
										text2 = null;
										GameObject gameObject4 = null;
										if (flag5)
										{
											goto IL_0462;
										}
										string overrideLanguage = default(string);
										bool allowLocalizedParameters = default(bool);
										while (true)
										{
											bool flag6 = (nint)gameObject4 >= options._size;
											text3 = text4;
											if (flag6)
											{
												break;
											}
											bool flag7 = (nint)gameObject3 >= options._size;
											string[] items = options._items;
											if (options._items != null)
											{
												bool flag8 = (nint)gameObject3 >= items.Length;
												string translation = LocalizationManager.GetTranslation(items[(object)gameObject3], FixForRTL: true, 0, ignoreRTLnumbers: true, (byte)(int)action != 0, (GameObject)flag9, overrideLanguage, allowLocalizedParameters);
												bool flag10 = (nint)gameObject3 >= options._size;
												if (options._items != null)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
													int version = options._version + 1;
													options._version = version;
													gameObject3 = (GameObject)(gameObject3 + 1);
													num = 1;
													vector2 = (Vector2)gameObject3;
													text2 = translation;
													action = action;
													gameObject4 = gameObject3;
													continue;
												}
											}
											goto IL_0462;
										}
									}
									nint num2 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v170 @ rdi_v18 (Il2CppMethodInfo)+38]");
									if ((nint)0 == 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
									}
									bool flag11 = options == null;
									List<object> options2 = new List<object>(options);
									if ((object)component != null)
									{
										component.InitialSet(text3, options2, selectedIndex, action, flag9);
										int num3 = default(int);
										component._ItemsToShow = num3;
										CustomDropDown._003CWaitAndFormat_003Ed__20 obj4 = null;
										obj4._003C_003E1__state = 0;
										obj4._003C_003E4__this = component;
										obj4.count = num3;
										Coroutine coroutine = component.StartCoroutine(obj4);
										if (_spawnedElements != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9B920");
											return component;
										}
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_0462;
		IL_0462:
		throw new NullReferenceException();
	}

	private void RegenerateDropdownOptions(CustomDropDown customDropDown, List<string> options, int selectedIndex, bool textIsLocalizationTerm = true)
	{
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		if ((object)customDropDown == null || ((UnityEngine.Object)customDropDown).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		object obj = default(object);
		if (obj != null)
		{
			CustomDropDown customDropDown2 = null;
			CustomDropDown customDropDown3 = null;
			bool applyParameters = default(bool);
			GameObject localParametersRoot = default(GameObject);
			string overrideLanguage = default(string);
			bool allowLocalizedParameters = default(bool);
			while ((nint)customDropDown3 < options._size)
			{
				if ((nint)customDropDown2 < options._size)
				{
					string[] items = options._items;
					string translation = LocalizationManager.GetTranslation(items[(object)customDropDown2], FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
					if ((nint)customDropDown2 < options._size)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						int version = options._version + 1;
						options._version = version;
						customDropDown2 = (CustomDropDown)(customDropDown2 + 1);
						customDropDown3 = customDropDown2;
						continue;
					}
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				throw new NullReferenceException();
			}
		}
		if (options != null)
		{
			List<object> options2 = new List<object>(options);
			customDropDown.RegenerateOptions(options2, selectedIndex);
			return;
		}
		Exception ex = System.Linq.Error.ArgumentNull("source");
		throw ex;
	}

	private void AddColourDropDown(string text, List<Color> options, int selectedIndex, Action<int> callbackWithNewSelectedIndex, int howManyOptionsToShowAtOnce = 4, bool textIsLocalizationTerm = true)
	{
		//IL_0482: Expected O, but got I4
		//IL_04c6: Expected O, but got I4
		//IL_0505: Expected O, but got I4
		//IL_03c7: Expected I4, but got O
		//IL_01d3: Expected O, but got I
		//IL_03d9: Expected I4, but got O
		//IL_0224: Unknown result type (might be due to invalid IL or missing references)
		//IL_0229: Expected O, but got Unknown
		//IL_0246: Expected O, but got I
		//IL_0355: Expected O, but got I4
		//IL_035e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0363: Expected O, but got Unknown
		//IL_0373: Expected O, but got I
		//IL_02fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0300: Expected O, but got Unknown
		//IL_0310: Expected O, but got I
		//IL_0468->IL0414: Incompatible stack heights: 1 vs 0
		//IL_00e1->IL0414: Incompatible stack heights: 1 vs 0
		//IL_04ac->IL0414: Incompatible stack heights: 2 vs 0
		//IL_04de->IL0414: Incompatible stack heights: 3 vs 0
		//IL_0520->IL0414: Incompatible stack heights: 3 vs 0
		//IL_0398->IL0414: Incompatible stack heights: 3 vs 0
		//IL_01f3->IL0414: Incompatible stack heights: 4 vs 0
		//IL_0404->IL0414: Incompatible stack heights: 3 vs 0
		//IL_026b->IL0414: Incompatible stack heights: 5 vs 0
		//IL_02ba->IL0414: Incompatible stack heights: 5 vs 0
		//IL_0380->IL0525: Incompatible stack heights: 5 vs 3
		//IL_031e->IL0525: Incompatible stack heights: 5 vs 3
		GameObject gameObject = UnityEngine.Object.Instantiate(_DropdownImagesPrefab, _Content);
		if ((object)gameObject != null)
		{
			CustomDropDown component = gameObject.GetComponent<CustomDropDown>();
			RectTransform component2 = gameObject.GetComponent<RectTransform>();
			if ((object)_Content != null)
			{
				VerticalLayoutGroup component3 = _Content.GetComponent<VerticalLayoutGroup>();
				GameObject content = (GameObject)(object)_Content;
				if ((object)_Content != null)
				{
					bool flag = ((UnityEngine.Object)content).m_CachedPtr == (IntPtr)0;
					RectTransform.get_rect_Injected(((UnityEngine.Object)content).m_CachedPtr, out Rect ret);
					if ((object)component3 != null)
					{
						object padding = ((LayoutGroup)component3).m_Padding;
						if (((LayoutGroup)component3).m_Padding != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v183 @ rcx_v27 (System.Object)+10]");
							bool flag2 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v183 @ rcx_v27 (System.Object)+10]");
							object obj = RectOffset.get_left_Injected((IntPtr)0);
							object padding2 = ((LayoutGroup)component3).m_Padding;
							if (((LayoutGroup)component3).m_Padding != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v191 @ rcx_v30 (System.Object)+10]");
								bool flag3 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v191 @ rcx_v30 (System.Object)+10]");
								GameObject gameObject2 = (GameObject)RectOffset.get_right_Injected((IntPtr)0);
								if ((object)component2 != null)
								{
									Vector2 sizeDelta = component2.sizeDelta;
									object obj2 = (object)gameObject2 + obj;
									Vector2 sizeDelta2 = default(Vector2);
									component2.sizeDelta = sizeDelta2;
									object obj3 = default(object);
									bool flag4 = obj3 == null;
									string text2 = text;
									if (!flag4)
									{
										string text3 = Translate(text);
										text2 = text3;
									}
									List<object> list = new List<object>();
									bool flag5 = options == null;
									ret = (Rect)0;
									object obj4 = obj2;
									GameObject gameObject3 = null;
									GameObject gameObject4 = null;
									if (!flag5)
									{
										Action<int> callbackWithNewSelectedIndex2 = default(Action<int>);
										bool clearCurrentOptions = default(bool);
										GameObject gameObject5 = default(GameObject);
										while (true)
										{
											GameObject obj5 = gameObject4;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [options @ r8 (System.Collections.Generic.List`1<UnityEngine.Color>)+18]");
											if ((nint)obj5 < 0)
											{
												GameObject obj6 = gameObject3;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [options @ r8 (System.Collections.Generic.List`1<UnityEngine.Color>)+18]");
												bool flag6 = (nint)obj6 >= 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [options @ r8 (System.Collections.Generic.List`1<UnityEngine.Color>)+10]");
												object obj7 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [options @ r8 (System.Collections.Generic.List`1<UnityEngine.Color>)+10]");
												if ((nint)0 == 0)
												{
													break;
												}
												GameObject obj8 = gameObject3;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v185 @ rcx_v49+18]");
												bool flag7 = (nint)obj8 >= 0;
												object obj9 = gameObject3 + 2;
												object obj10 = obj9 + obj9;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v185 @ rcx_v49+v993 @ rax_v60*8]");
												obj4 = 0;
												object item = (Color)ret;
												if (list == null)
												{
													break;
												}
												int version = list._version + 1;
												list._version = version;
												List<object> items = (List<object>)(object)list._items;
												if (list._items == null)
												{
													break;
												}
												if (list._size >= items._size)
												{
													list.AddWithResize(item);
													gameObject3 = (GameObject)(gameObject3 + 1);
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v185 @ rcx_v49+v993 @ rax_v60*8]");
													ret = (Rect)0;
													gameObject4 = gameObject3;
												}
												else
												{
													int size = list._size + 1;
													list._size = size;
													((List<object>)(object)list._items).AddWithResize((object)list._size);
													gameObject3 = (GameObject)(gameObject3 + 1);
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v185 @ rcx_v49+v993 @ rax_v60*8]");
													ret = (Rect)0;
													gameObject4 = gameObject3;
												}
												continue;
											}
											if ((object)component == null)
											{
												break;
											}
											component.InitialSet(text2, list, selectedIndex, callbackWithNewSelectedIndex2, clearCurrentOptions);
											component._ItemsToShow = (int)gameObject5;
											CustomDropDown._003CWaitAndFormat_003Ed__20 obj11 = null;
											obj11._003C_003E1__state = 0;
											obj11._003C_003E4__this = component;
											obj11.count = (int)gameObject5;
											Coroutine coroutine = component.StartCoroutine(obj11);
											if (_spawnedElements == null)
											{
												break;
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9B920");
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

	private TickBoxUI AddTickBox(string text, bool defaultValue, Action<bool> valueChangeCallback, bool textIsLocalizationTerm = true)
	{
		//IL_029f: Expected O, but got I4
		//IL_02e3: Expected O, but got I4
		//IL_0285->IL0231: Incompatible stack heights: 1 vs 0
		//IL_00eb->IL0231: Incompatible stack heights: 1 vs 0
		//IL_02c9->IL0231: Incompatible stack heights: 2 vs 0
		//IL_02fb->IL0231: Incompatible stack heights: 3 vs 0
		//IL_0318->IL0231: Incompatible stack heights: 3 vs 0
		//IL_01e4->IL0231: Incompatible stack heights: 3 vs 0
		//IL_021d->IL0231: Incompatible stack heights: 3 vs 0
		GameObject gameObject = UnityEngine.Object.Instantiate(_TickboxPrefab, _Content);
		if ((object)gameObject != null)
		{
			TickBoxUI componentInChildren = gameObject.GetComponentInChildren<TickBoxUI>(includeInactive: false);
			RectTransform component = gameObject.GetComponent<RectTransform>();
			if ((object)_Content != null)
			{
				VerticalLayoutGroup component2 = _Content.GetComponent<VerticalLayoutGroup>();
				Transform content = _Content;
				if ((object)_Content != null)
				{
					bool flag = ((UnityEngine.Object)content).m_CachedPtr == (IntPtr)0;
					RectTransform.get_rect_Injected(((UnityEngine.Object)content).m_CachedPtr, out Rect _);
					if ((object)component2 != null)
					{
						object padding = ((LayoutGroup)component2).m_Padding;
						if (((LayoutGroup)component2).m_Padding != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ rcx_v26 (System.Object)+10]");
							bool flag2 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ rcx_v26 (System.Object)+10]");
							object obj = RectOffset.get_left_Injected((IntPtr)0);
							object padding2 = ((LayoutGroup)component2).m_Padding;
							if (((LayoutGroup)component2).m_Padding != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v171 @ rcx_v29 (System.Object)+10]");
								bool flag3 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v171 @ rcx_v29 (System.Object)+10]");
								Transform transform = (Transform)RectOffset.get_right_Injected((IntPtr)0);
								if ((object)component != null)
								{
									Vector2 sizeDelta = component.sizeDelta;
									object obj2 = (object)transform + obj;
									Vector2 sizeDelta2 = default(Vector2);
									component.sizeDelta = sizeDelta2;
									object obj3 = default(object);
									bool flag4 = obj3 == null;
									string text2 = text;
									if (!flag4)
									{
										string text3 = Translate(text);
										text2 = text3;
									}
									if ((object)componentInChildren != null)
									{
										componentInChildren.InitialSet(defaultValue);
										TextMeshProUGUI componentInChildren2 = gameObject.GetComponentInChildren<TextMeshProUGUI>(includeInactive: false);
										if ((object)componentInChildren2 != null)
										{
											componentInChildren2.text = text2;
											componentInChildren.AddOnToggle(valueChangeCallback);
											if (_spawnedElements != null)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9B920");
												return componentInChildren;
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
	}

	public LabeledButtonUI AddLabeledButton(string labelText, string buttonText, Action callback, bool textIsLocalizationTerm = true)
	{
		//IL_0323: Expected O, but got I4
		//IL_0367: Expected O, but got I4
		//IL_0309->IL0298: Incompatible stack heights: 1 vs 0
		//IL_01ed->IL0298: Incompatible stack heights: 1 vs 0
		//IL_034d->IL0298: Incompatible stack heights: 2 vs 0
		//IL_037f->IL0298: Incompatible stack heights: 3 vs 0
		//IL_0284->IL0298: Incompatible stack heights: 3 vs 0
		GameObject gameObject = UnityEngine.Object.Instantiate(_ButtonPrefab, _Content);
		if ((object)gameObject != null)
		{
			LabeledButtonUI component = gameObject.GetComponent<LabeledButtonUI>();
			object obj = default(object);
			bool flag = obj == null;
			string text = labelText;
			string text2 = buttonText;
			if (!flag)
			{
				string text3 = Translate(labelText);
				string text4 = Translate(buttonText);
				text = text3;
				text2 = text4;
			}
			if ((object)component != null && (object)component._Label != null)
			{
				component._Label.text = text;
				if ((object)component._ButtonLabel != null)
				{
					component._ButtonLabel.text = text2;
					if ((object)component._Button != null)
					{
						((UnityEngine.Object)component._Button).SetName(text2);
						component.SetButtonCallback(callback);
						RectTransform component2 = gameObject.GetComponent<RectTransform>();
						if ((object)_Content != null)
						{
							VerticalLayoutGroup component3 = _Content.GetComponent<VerticalLayoutGroup>();
							GameObject content = (GameObject)(object)_Content;
							if ((object)_Content != null)
							{
								bool flag2 = ((UnityEngine.Object)content).m_CachedPtr == (IntPtr)0;
								RectTransform.get_rect_Injected(((UnityEngine.Object)content).m_CachedPtr, out Rect _);
								if ((object)component3 != null)
								{
									object padding = ((LayoutGroup)component3).m_Padding;
									if (((LayoutGroup)component3).m_Padding != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ rcx_v29 (System.Object)+10]");
										bool flag3 = (nint)0 == 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ rcx_v29 (System.Object)+10]");
										object obj2 = RectOffset.get_left_Injected((IntPtr)0);
										object padding2 = ((LayoutGroup)component3).m_Padding;
										if (((LayoutGroup)component3).m_Padding != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v154 @ rcx_v32 (System.Object)+10]");
											bool flag4 = (nint)0 == 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v154 @ rcx_v32 (System.Object)+10]");
											GameObject gameObject2 = (GameObject)RectOffset.get_right_Injected((IntPtr)0);
											if ((object)component2 != null)
											{
												Vector2 sizeDelta = component2.sizeDelta;
												object obj3 = (object)gameObject2 + obj2;
												Vector2 sizeDelta2 = default(Vector2);
												component2.sizeDelta = sizeDelta2;
												if (_spawnedElements != null)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9B920");
													return component;
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
	}

	public void AddLabel(string labelText)
	{
		//IL_0250: Expected O, but got I4
		//IL_0294: Expected O, but got I4
		//IL_0236->IL01e2: Incompatible stack heights: 1 vs 0
		//IL_013b->IL01e2: Incompatible stack heights: 1 vs 0
		//IL_027a->IL01e2: Incompatible stack heights: 2 vs 0
		//IL_02ac->IL01e2: Incompatible stack heights: 3 vs 0
		//IL_01d2->IL01e2: Incompatible stack heights: 3 vs 0
		GameObject gameObject = UnityEngine.Object.Instantiate(_LabelPrefab, _Content);
		if ((object)gameObject != null)
		{
			LabelUI component = gameObject.GetComponent<LabelUI>();
			if ((object)component != null)
			{
				TextMeshProUGUI label = component._Label;
				if ((object)component._Label != null)
				{
					component._Label.text = labelText;
					RectTransform component2 = component.GetComponent<RectTransform>();
					if ((object)_Content != null)
					{
						VerticalLayoutGroup component3 = _Content.GetComponent<VerticalLayoutGroup>();
						GameObject content = (GameObject)(object)_Content;
						if ((object)_Content != null)
						{
							bool flag = ((UnityEngine.Object)content).m_CachedPtr == (IntPtr)0;
							RectTransform.get_rect_Injected(((UnityEngine.Object)content).m_CachedPtr, out Rect _);
							if ((object)component3 != null)
							{
								object padding = ((LayoutGroup)component3).m_Padding;
								if (((LayoutGroup)component3).m_Padding != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rcx_v25 (System.Object)+10]");
									bool flag2 = (nint)0 == 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rcx_v25 (System.Object)+10]");
									object obj = RectOffset.get_left_Injected((IntPtr)0);
									object padding2 = ((LayoutGroup)component3).m_Padding;
									if (((LayoutGroup)component3).m_Padding != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ rcx_v28 (System.Object)+10]");
										bool flag3 = (nint)0 == 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ rcx_v28 (System.Object)+10]");
										GameObject gameObject2 = (GameObject)RectOffset.get_right_Injected((IntPtr)0);
										if ((object)component2 != null)
										{
											Vector2 sizeDelta = component2.sizeDelta;
											object obj2 = (object)gameObject2 + obj;
											Vector2 sizeDelta2 = default(Vector2);
											component2.sizeDelta = sizeDelta2;
											if (_spawnedUnselectables != null)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9B980");
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
		}
		throw new NullReferenceException();
	}

	private unsafe void AddMultipleChoice(string labelText, List<string> buttonLabels, List<Action> callbacks, int selectedIndex, bool textIsLocalizedTerm = true)
	{
		//IL_03da: Expected O, but got I4
		//IL_041e: Expected O, but got I4
		//IL_0201: Unknown result type (might be due to invalid IL or missing references)
		//IL_0206: Expected O, but got Unknown
		//IL_03c0->IL0350: Incompatible stack heights: 1 vs 0
		//IL_02ad->IL0350: Incompatible stack heights: 1 vs 0
		//IL_0404->IL0350: Incompatible stack heights: 2 vs 0
		//IL_0436->IL0350: Incompatible stack heights: 3 vs 0
		//IL_04a7->IL0350: Incompatible stack heights: 5 vs 0
		//IL_0340->IL0350: Incompatible stack heights: 5 vs 0
		GameObject gameObject = UnityEngine.Object.Instantiate(_MultipleChoicePrefab, _Content);
		if ((object)gameObject != null)
		{
			OptionsMultipleChoice component = gameObject.GetComponent<OptionsMultipleChoice>();
			object obj = default(object);
			bool flag = obj == null;
			string text = labelText;
			bool flag4 = default(bool);
			if (!flag)
			{
				string text2 = Translate(labelText);
				bool flag2 = buttonLabels == null;
				GameObject gameObject2 = null;
				GameObject gameObject3 = null;
				if (flag2)
				{
					goto IL_0350;
				}
				GameObject localParametersRoot = default(GameObject);
				string overrideLanguage = default(string);
				bool allowLocalizedParameters = default(bool);
				while (true)
				{
					bool flag3 = (nint)gameObject3 >= buttonLabels._size;
					text = text2;
					if (flag3)
					{
						break;
					}
					if ((nint)gameObject2 < buttonLabels._size)
					{
						string[] items = buttonLabels._items;
						if (buttonLabels._items != null)
						{
							if ((nint)gameObject2 >= items.Length)
							{
								goto IL_0367;
							}
							string translation = LocalizationManager.GetTranslation(items[(object)gameObject2], FixForRTL: true, 0, ignoreRTLnumbers: true, flag4, localParametersRoot, overrideLanguage, allowLocalizedParameters);
							if ((nint)gameObject2 >= buttonLabels._size)
							{
								goto IL_0361;
							}
							if (buttonLabels._items != null)
							{
								GameObject gameObject4 = UnityEngine.Object.Instantiate((GameObject)(object)buttonLabels._items, (Transform)(object)gameObject2);
								int version = buttonLabels._version + 1;
								buttonLabels._version = version;
								gameObject2 = (GameObject)(gameObject2 + 1);
								gameObject3 = gameObject2;
								continue;
							}
						}
						goto IL_0350;
					}
					goto IL_0361;
					IL_0361:
					System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
					goto IL_0367;
					IL_0367:
					throw new IndexOutOfRangeException();
				}
			}
			RectTransform component2 = gameObject.GetComponent<RectTransform>();
			if ((object)_Content != null)
			{
				VerticalLayoutGroup component3 = _Content.GetComponent<VerticalLayoutGroup>();
				Transform content = _Content;
				if ((object)_Content != null)
				{
					bool flag5 = ((UnityEngine.Object)content).m_CachedPtr == (IntPtr)0;
					RectTransform.get_rect_Injected(((UnityEngine.Object)content).m_CachedPtr, out Rect ret);
					if ((object)component3 != null)
					{
						object padding = ((LayoutGroup)component3).m_Padding;
						if (((LayoutGroup)component3).m_Padding != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v208 @ rcx_v38 (System.Object)+10]");
							bool flag6 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v208 @ rcx_v38 (System.Object)+10]");
							object obj2 = RectOffset.get_left_Injected((IntPtr)0);
							object padding2 = ((LayoutGroup)component3).m_Padding;
							if (((LayoutGroup)component3).m_Padding != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v211 @ rcx_v41 (System.Object)+10]");
								bool flag7 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v211 @ rcx_v41 (System.Object)+10]");
								object obj3 = RectOffset.get_right_Injected((IntPtr)0);
								if ((object)component2 != null)
								{
									bool flag8 = ((UnityEngine.Object)component2).m_CachedPtr == (IntPtr)0;
									RectTransform.get_sizeDelta_Injected(((UnityEngine.Object)component2).m_CachedPtr, out Vector2 _);
									object obj4 = obj3 + obj2;
									bool flag9 = ((UnityEngine.Object)component2).m_CachedPtr == (IntPtr)0;
									RectTransform.set_sizeDelta_Injected(((UnityEngine.Object)component2).m_CachedPtr, ref *(Vector2*)(&ret));
									if ((object)component != null)
									{
										component.Initialize(text, buttonLabels, callbacks, flag4 ? 1 : 0);
										if (_spawnedElements != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9B920");
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
		goto IL_0350;
		IL_0350:
		throw new NullReferenceException();
	}

	private string Translate(string term)
	{
		bool applyParameters = default(bool);
		GameObject localParametersRoot = default(GameObject);
		string overrideLanguage = default(string);
		bool allowLocalizedParameters = default(bool);
		return LocalizationManager.GetTranslation(term, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
	}

	public void ToggleVisualInvert(bool b)
	{
		PlayerOptionsData config = _playerOptions.Config;
		config._003CVisuallyInvertStages_003Ek__BackingField = b;
	}

	public void SetJoystickDefault()
	{
		PlayerOptionsData config = _playerOptions.Config;
		config._003CSelectedJoystickType_003Ek__BackingField = VisibleJoystickType.Default;
	}

	public void SetJoystickLegacy()
	{
		PlayerOptionsData config = _playerOptions.Config;
		config._003CSelectedJoystickType_003Ek__BackingField = VisibleJoystickType.Legacy;
	}

	private void SetOrientation(int index)
	{
		//IL_002b: Expected O, but got I4
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected O, but got Unknown
		bool flag = index == 0;
		if (!flag)
		{
			object obj = index - 1;
			if (!flag)
			{
				object obj2 = obj - 1;
				if (!flag)
				{
					if ((nint)obj2 == 1)
					{
						_currentScreenOrientation = ScreenOrientation.LandscapeRight;
					}
				}
				else
				{
					_currentScreenOrientation = ScreenOrientation.LandscapeLeft;
				}
			}
			else
			{
				_currentScreenOrientation = ScreenOrientation.PortraitUpsideDown;
			}
		}
		else
		{
			_currentScreenOrientation = ScreenOrientation.Portrait;
		}
	}

	public void ApplySelectedOrientation()
	{
		//IL_010a: Expected O, but got I4
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A33FC]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		object obj = Screen.GetScreenOrientation();
		if ((nint)obj == (nint)_currentScreenOrientation)
		{
			return;
		}
		PlayerPrefs.SetInt("VS_SavedOrientation", (int)_currentScreenOrientation);
		PlayerPrefs.Save();
		Screen.orientation = _currentScreenOrientation;
		if (_multiplayer != null)
		{
			int playerCount = _multiplayer.GetPlayerCount();
			if (playerCount > 1 || _multiplayer.IsOnlineMultiplayer)
			{
				_multiplayer.ClearAllExtraPlayers();
				_multiplayer.ResetMultiplayerSelections();
			}
		}
		UniTaskVoid uniTaskVoid = VSUtils.RestartAppWithFrameDelay();
	}

	private void SetMusic(float f)
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		//IL_0061: Expected I, but got O
		//IL_007d: Expected O, but got I
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		IntPtr intPtr = default(IntPtr);
		num = intPtr;
		object obj3 = default(object);
		object signal = (IntPtr)obj3;
		bool requireDeclaration = default(bool);
		_signalBus.InternalFire((Type)num, signal, (object)null, requireDeclaration);
	}

	private void SetSounds(float f)
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		//IL_0061: Expected I, but got O
		//IL_007d: Expected O, but got I
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		IntPtr intPtr = default(IntPtr);
		num = intPtr;
		object obj3 = default(object);
		object signal = (IntPtr)obj3;
		bool requireDeclaration = default(bool);
		_signalBus.InternalFire((Type)num, signal, (object)null, requireDeclaration);
	}

	private void SetClassicMusic()
	{
		PlayerOptionsData config = _playerOptions.Config;
		config._003CClassicMusic_003Ek__BackingField = true;
	}

	private void SetBlastProcessedMusic()
	{
		PlayerOptionsData config = _playerOptions.Config;
		config._003CClassicMusic_003Ek__BackingField = false;
	}

	public void FlashingVFX(bool b)
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		//IL_0061: Expected I, but got O
		//IL_007d: Expected O, but got I
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		IntPtr intPtr = default(IntPtr);
		num = intPtr;
		object obj3 = default(object);
		object signal = (IntPtr)obj3;
		bool requireDeclaration = default(bool);
		_signalBus.InternalFire((Type)num, signal, (object)null, requireDeclaration);
	}

	public void DisableBlood(bool b)
	{
		PlayerOptionsData config = _playerOptions.Config;
		config._003CDisableBlood_003Ek__BackingField = b;
	}

	private void ScreenShake(bool value)
	{
		PlayerOptionsData config = _playerOptions.Config;
		config._003CScreenShakeEnabled_003Ek__BackingField = value;
	}

	private void PixelFont(bool value)
	{
		PlayerOptionsData config = _playerOptions.Config;
		config._003CPixelFont_003Ek__BackingField = value;
		if (!value)
		{
			PixelFontManager.TurnOff();
		}
		else
		{
			PixelFontManager.TurnOn();
		}
		PixelFontManager._dirty = true;
	}

	private void DisplayDefangedEnemies(bool value)
	{
		PlayerOptionsData config = _playerOptions.Config;
		config._003CDisplayDefangedEnemies_003Ek__BackingField = value;
	}

	private void StageLighting(bool value)
	{
		PlayerOptionsData config = _playerOptions.Config;
		config._003CStageLighting_003Ek__BackingField = value;
		GM.Core.SetSpecialStageLightingEnabled(value);
	}

	public void VisibleJoystick(bool b)
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		//IL_0061: Expected I, but got O
		//IL_007d: Expected O, but got I
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		IntPtr intPtr = default(IntPtr);
		num = intPtr;
		object obj3 = default(object);
		object signal = (IntPtr)obj3;
		bool requireDeclaration = default(bool);
		_signalBus.InternalFire((Type)num, signal, (object)null, requireDeclaration);
	}

	public void DamageNumbers(bool b)
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		//IL_0061: Expected I, but got O
		//IL_007d: Expected O, but got I
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		IntPtr intPtr = default(IntPtr);
		num = intPtr;
		object obj3 = default(object);
		object signal = (IntPtr)obj3;
		bool requireDeclaration = default(bool);
		_signalBus.InternalFire((Type)num, signal, (object)null, requireDeclaration);
	}

	public void GlimmerCarousel(bool b)
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		//IL_0061: Expected I, but got O
		//IL_007d: Expected O, but got I
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		IntPtr intPtr = default(IntPtr);
		num = intPtr;
		object obj3 = default(object);
		object signal = (IntPtr)obj3;
		bool requireDeclaration = default(bool);
		_signalBus.InternalFire((Type)num, signal, (object)null, requireDeclaration);
	}

	public void SetFullscreen(bool b)
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		//IL_0061: Expected I, but got O
		//IL_007d: Expected O, but got I
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		IntPtr intPtr = default(IntPtr);
		num = intPtr;
		object obj3 = default(object);
		object signal = (IntPtr)obj3;
		bool requireDeclaration = default(bool);
		_signalBus.InternalFire((Type)num, signal, (object)null, requireDeclaration);
	}

	public void ToggleMovingBackground(bool b)
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		//IL_0061: Expected I, but got O
		//IL_007d: Expected O, but got I
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		IntPtr intPtr = default(IntPtr);
		num = intPtr;
		object obj3 = default(object);
		object signal = (IntPtr)obj3;
		bool requireDeclaration = default(bool);
		_signalBus.InternalFire((Type)num, signal, (object)null, requireDeclaration);
	}

	public void ToggleStageProgression(bool b)
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		//IL_0061: Expected I, but got O
		//IL_007d: Expected O, but got I
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		IntPtr intPtr = default(IntPtr);
		num = intPtr;
		object obj3 = default(object);
		object signal = (IntPtr)obj3;
		bool requireDeclaration = default(bool);
		_signalBus.InternalFire((Type)num, signal, (object)null, requireDeclaration);
	}

	public void ToggleControllerVibration(bool value)
	{
		PlayerOptionsData config = _playerOptions.Config;
		config._003CControllerVibrationEnabled_003Ek__BackingField = value;
	}

	public void ToggleAssignControllerToPlayer1(bool value)
	{
		PlayerOptionsData config = _playerOptions.Config;
		config._003CAssignControllerToPlayer1_003Ek__BackingField = value;
		_multiplayer.SetControllerAssignedToPlayer1(value);
		MultiplayerManager multiplayer = _multiplayer;
		multiplayer.AllowP1Reassign = value;
	}

	public void TogglePopupsShouldFollowPriority(bool value)
	{
		PlayerOptionsData config = _playerOptions.Config;
		config._003CPopupsShouldFollowPriority_003Ek__BackingField = value;
	}

	public void ToggleShowPlayerIndicators(bool value)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18998A2F7]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		bool flag = !value;
		string text = "False";
		if (!flag)
		{
			text = "True";
		}
		string message = "Setting show player indicators : " + text;
		Debug.Log(message);
		PlayerOptionsData config = _playerOptions.Config;
		config._003CShowPlayerIndicators_003Ek__BackingField = value;
	}

	public void TogglePermanentCoopOutlines(bool value)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18998A2F7]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		bool flag = !value;
		string text = "False";
		if (!flag)
		{
			text = "True";
		}
		string message = "Setting permanent coop outlines : " + text;
		Debug.Log(message);
		PlayerOptionsData config = _playerOptions.Config;
		config._003CPermanentCoopOutlines_003Ek__BackingField = value;
	}

	public void ToggleTintUISelection(bool value)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18998A2F7]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		bool flag = !value;
		string text = "False";
		if (!flag)
		{
			text = "True";
		}
		string message = "Setting TintUISelection : " + text;
		Debug.Log(message);
		PlayerOptionsData config = _playerOptions.Config;
		config._003CTintUISelection_003Ek__BackingField = value;
	}

	public void SetPlayerColourIndex(int playerIndex, int index)
	{
		if (playerIndex >= 0)
		{
			PlayerOptionsData config = _playerOptions.Config;
			uint[] array = config._003CPlayerColours_003Ek__BackingField;
			if (playerIndex < array.Length)
			{
				goto IL_0137;
			}
		}
		int num = default(int);
		string text = num.ToString();
		string message = "Colour dropdown player index out of range: " + text;
		Debug.LogError(message);
		goto IL_0137;
		IL_0137:
		if (index >= 0)
		{
			uint[] array2 = optionColours;
			if (index < array2.Length)
			{
				PlayerOptionsData config2 = _playerOptions.Config;
				uint[] array3 = config2._003CPlayerColours_003Ek__BackingField;
				uint[] array4 = optionColours;
				array3[playerIndex] = array4[index];
				return;
			}
		}
		int num2 = default(int);
		string text2 = num2.ToString();
		string message2 = "Colour dropdown index out of range: " + text2;
		Debug.LogError(message2);
	}

	public void SetCoopChestMode(bool value)
	{
		PlayerOptionsData config = _playerOptions.Config;
		config._003CSequentialChestMode_003Ek__BackingField = value;
	}

	public void ToggleHideDebugUI(bool value)
	{
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0087: Expected I, but got O
		//IL_00a3: Expected O, but got I
		PlayerOptionsData config = _playerOptions.Config;
		config._003CHideDebugUI_003Ek__BackingField = value;
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		IntPtr intPtr = default(IntPtr);
		num = intPtr;
		object obj3 = default(object);
		object signal = (IntPtr)obj3;
		bool requireDeclaration = default(bool);
		_signalBus.InternalFire((Type)num, signal, (object)null, requireDeclaration);
	}

	public void ToggleHideGameUI(bool value)
	{
		PlayerOptionsData config = _playerOptions.Config;
		config._003CHideGameUI_003Ek__BackingField = value;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA0860");
	}

	public void ViewPonclePrivacyPolicy()
	{
		Application.OpenURL("https://poncle.games/privacypolicy.html");
	}

	public void OpenLanguagesPage()
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType = default(Type);
		bool requireDeclaration = default(bool);
		_signalBus.InternalFire(signalType, (object)null, (object)null, requireDeclaration);
	}

	public void SetResolution(int i)
	{
		//IL_003c: Expected O, but got I
		//IL_004f: Expected O, but got I4
		//IL_0071: Expected O, but got I4
		List<Resolution> resolutions = _resolutions;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Resolution>)+18]");
		if ((nint)i < (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Resolution>)+10]");
			object obj = 0;
			object obj2 = i + 2;
			object obj3 = obj2 + obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,0Ch\"");
			_selectedResolution = (Resolution?)(object)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rcx_v6+v133 @ rax_v9*8]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189984D69]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			Resolution resolution = default(Resolution);
			string text = resolution.ToString();
			string message = "Selected resolution : " + text;
			Debug.Log(message);
			HandleRefreshRateDropdown();
		}
		else
		{
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}

	public unsafe void SetRefreshRate(int i)
	{
		//IL_004d: Expected I4, but got F8
		//IL_0078: Expected O, but got Ref
		List<Resolution> currentRefreshRateResolutions = _currentRefreshRateResolutions;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Resolution>)+18]");
		if ((nint)i < (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm6,0Ch\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2sd xmm7,rcx\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2sd xmm1,rcx\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"divsd xmm7,xmm1\"");
			double num = Math.Round(0.0);
			_selectedRefreshRate = (int)num;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object arg = default(object);
			System.ParamsArray paramsArray = new System.ParamsArray(arg);
			object obj = default(object);
			string message = string.FormatHelper((IFormatProvider)null, "Selected Refresh Rate: {0}", (System.ParamsArray)(&obj));
			Debug.Log(message);
		}
		else
		{
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}

	private void SetTargetFrameRate(int targetFrameRate)
	{
		_selectedFrameRate = targetFrameRate;
	}

	public void SetBorderType(int i)
	{
		PlayerOptionsData config = _playerOptions.Config;
		config._003CBorderType_003Ek__BackingField = (BorderType)i;
	}

	public unsafe void SetWindowMode(int i)
	{
		//IL_0038: Expected O, but got Ref
		_selectedWindowMode = (FullScreenMode)i;
		object obj = default(object);
		string text = ((Enum)(&obj)).ToString();
		string message = "Selected window mode : " + text;
		Debug.Log(message);
		UpdateRefreshRateDropdownVisibility();
		HandleRefreshRateDropdown();
	}

	private void UpdateRefreshRateDropdownVisibility(bool forceShow = false)
	{
		//IL_0328: Expected O, but got I4
		//IL_0342: Expected O, but got I4
		CustomDropDown refreshRateDropdown = _refreshRateDropdown;
		if ((object)_refreshRateDropdown == null || ((UnityEngine.Object)refreshRateDropdown).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		bool flag = _selectedWindowMode != FullScreenMode.ExclusiveFullScreen;
		bool flag2 = forceShow;
		if (!flag)
		{
			flag2 = true;
		}
		if (!flag2)
		{
			GameObject gameObject = _refreshRateDropdown.gameObject;
			gameObject.SetActive(value: false);
			SelectableUI currentSelectableUI = SelectableUI.CurrentSelectableUI;
			if ((object)SelectableUI.CurrentSelectableUI != null && ((UnityEngine.Object)currentSelectableUI).m_CachedPtr != (IntPtr)0)
			{
				GameObject gameObject2 = SelectableUI.CurrentSelectableUI.gameObject;
				CustomDropDown refreshRateDropdown2 = _refreshRateDropdown;
				GameObject gameObject3 = refreshRateDropdown2._DropDown.gameObject;
				bool flag3 = (object)gameObject3 == null;
				bool flag4 = (object)gameObject2 == null;
				object obj = flag4 & flag3;
				bool flag5 = obj == null;
				object obj2 = !flag5;
				if (obj2 == null)
				{
					bool flag6;
					if ((object)gameObject3 != null)
					{
						if ((object)gameObject2 != null)
						{
							object obj3 = (object)gameObject2 - (object)gameObject3;
							flag6 = obj3 == null;
						}
						else
						{
							flag6 = ((UnityEngine.Object)gameObject3).m_CachedPtr == (IntPtr)0;
						}
					}
					else
					{
						flag6 = ((UnityEngine.Object)gameObject2).m_CachedPtr == (IntPtr)0;
					}
					if (!flag6)
					{
						goto IL_0288;
					}
				}
				CustomDropDown refreshRateDropdown3 = _refreshRateDropdown;
				SelectableUI component = refreshRateDropdown3._DropDown.GetComponent<SelectableUI>();
				if ((object)component != null && ((UnityEngine.Object)component).m_CachedPtr != (IntPtr)0)
				{
					component.IsDefaultSelectedOnPage = false;
				}
				CustomDropDown screenResolutionDropdown = _screenResolutionDropdown;
				if ((object)_screenResolutionDropdown != null && ((UnityEngine.Object)screenResolutionDropdown).m_CachedPtr != (IntPtr)0)
				{
					CustomDropDown screenResolutionDropdown2 = _screenResolutionDropdown;
					screenResolutionDropdown2._DropDown.Select();
				}
			}
		}
		else
		{
			GameObject gameObject4 = _refreshRateDropdown.gameObject;
			gameObject4.SetActive(value: true);
		}
		goto IL_0288;
		IL_0288:
		GenerateNavigation();
	}

	public unsafe void SetVsyncEnabled(bool value)
	{
		//IL_02b7: Expected O, but got Ref
		//IL_0337: Expected O, but got I4
		//IL_0351: Expected O, but got I4
		_vSyncEnabled = value;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object arg = default(object);
		System.ParamsArray paramsArray = new System.ParamsArray(arg);
		object obj = default(object);
		string message = string.FormatHelper((IFormatProvider)null, "Selected V-Sync Mode: {0}", (System.ParamsArray)(&obj));
		Debug.Log(message);
		SliderUI frameRateSlider = _frameRateSlider;
		if ((object)_frameRateSlider != null && ((UnityEngine.Object)frameRateSlider).m_CachedPtr != (IntPtr)0)
		{
			if (!_vSyncEnabled)
			{
				GameObject gameObject = _frameRateSlider.gameObject;
				gameObject.SetActive(value: true);
			}
			else
			{
				GameObject gameObject2 = _frameRateSlider.gameObject;
				gameObject2.SetActive(value: false);
				SelectableUI currentSelectableUI = SelectableUI.CurrentSelectableUI;
				if ((object)SelectableUI.CurrentSelectableUI != null && ((UnityEngine.Object)currentSelectableUI).m_CachedPtr != (IntPtr)0)
				{
					GameObject gameObject3 = SelectableUI.CurrentSelectableUI.gameObject;
					SliderUI frameRateSlider2 = _frameRateSlider;
					GameObject gameObject4 = frameRateSlider2._slider.gameObject;
					bool flag = (object)gameObject4 == null;
					bool flag2 = (object)gameObject3 == null;
					object obj2 = flag2 & flag;
					bool flag3 = obj2 == null;
					object obj3 = !flag3;
					if (obj3 == null)
					{
						bool flag4;
						if ((object)gameObject4 != null)
						{
							if ((object)gameObject3 != null)
							{
								object obj4 = (object)gameObject3 - (object)gameObject4;
								flag4 = obj4 == null;
							}
							else
							{
								flag4 = ((UnityEngine.Object)gameObject4).m_CachedPtr == (IntPtr)0;
							}
						}
						else
						{
							flag4 = ((UnityEngine.Object)gameObject3).m_CachedPtr == (IntPtr)0;
						}
						if (!flag4)
						{
							goto IL_009c;
						}
					}
					SliderUI frameRateSlider3 = _frameRateSlider;
					SelectableUI component = frameRateSlider3._slider.GetComponent<SelectableUI>();
					if ((object)component != null && ((UnityEngine.Object)component).m_CachedPtr != (IntPtr)0)
					{
						component.IsDefaultSelectedOnPage = false;
					}
					TickBoxUI vSyncTickBox = _vSyncTickBox;
					if ((object)_vSyncTickBox != null && ((UnityEngine.Object)vSyncTickBox).m_CachedPtr != (IntPtr)0)
					{
						Button componentInChildren = _vSyncTickBox.GetComponentInChildren<Button>();
						componentInChildren.Select();
					}
				}
			}
		}
		goto IL_009c;
		IL_009c:
		GenerateNavigation();
	}

	public unsafe void ApplyGraphicsSettings()
	{
		//IL_0217: Expected O, but got I
		//IL_028b: Expected I4, but got O
		if (_selectedResolution != null)
		{
			Debug.Log("Saving / Applying new graphics settings");
			bool flag = !_vSyncEnabled;
			bool vSyncCount = !flag;
			QualitySettings.vSyncCount = (vSyncCount ? 1 : 0);
			if (_selectedRefreshRate == -1)
			{
				_selectedRefreshRate = 0;
			}
			bool flag2 = _selectedResolution == null;
			if (_selectedRefreshRate < 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.UI.OptionsController)+F4]");
				object obj = (nint)0 >> 32;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.UI.OptionsController)+F4]");
				int preferredRefreshRate = default(int);
				Screen.SetResolution_Injected(0, (int)obj, _selectedWindowMode, ref *(RefreshRate*)(&preferredRefreshRate));
			}
			Application.targetFrameRate = _selectedFrameRate;
			bool flag3 = _selectedResolution == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.UI.OptionsController)+F4]");
			PlayerPrefs.SetInt("VS_SavedResolutionX", 0);
			bool flag4 = _selectedResolution == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.UI.OptionsController)+F4]");
			int value = (int)((nint)0 >> 32);
			PlayerPrefs.SetInt("VS_SavedResolutionY", value);
			PlayerPrefs.SetInt("VS_SavedWindowedMode", (int)_selectedWindowMode);
			PlayerPrefs.SetInt("VS_SavedRefreshRate", _selectedRefreshRate);
			PlayerPrefs.SetInt("VS_SavedFrameRate", _selectedFrameRate);
			bool flag5 = !_vSyncEnabled;
			bool value2 = !flag5;
			PlayerPrefs.SetInt("VS_VSyncEnabled", value2 ? 1 : 0);
			bool flag6 = _selectedResolution == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.UI.OptionsController)+F4]");
			PlayerPrefs.SetInt("Screenmanager Resolution Width", 0);
			bool flag7 = _selectedResolution == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.UI.OptionsController)+F4]");
			int value3 = (int)((nint)0 >> 32);
			PlayerPrefs.SetInt("Screenmanager Resolution Height", value3);
			PlayerPrefs.SetInt("Screenmanager Fullscreen mode", (int)_selectedWindowMode);
			PlayerPrefs.Save();
			UniTaskVoid uniTaskVoid = VSUtils.RestartAppWithFrameDelay();
		}
		else
		{
			Debug.LogWarning("Invalid resolution, dropdown might not be selected yet");
		}
	}

	public void RestoreBackup()
	{
		//IL_0015: Expected I4, but got O
		Action<bool> action = null;
		((OptionsController)(object)action)._003CRestoreBackup_003Eb__147_0((byte)(int)this != 0);
		bool textIsLocalizationTerm = default(bool);
		PopupManager.CreateOKCancelPopup("Restore-Backup", "lang/options_areYouSure", "lang/options_restoreDescription", action, textIsLocalizationTerm);
	}

	public void RecoverOldData()
	{
		//IL_0015: Expected I4, but got O
		Action<bool> action = null;
		((OptionsController)(object)action)._003CRecoverOldData_003Eb__148_0((byte)(int)this != 0);
		bool textIsLocalizationTerm = default(bool);
		PopupManager.CreateOKCancelPopup("Recover-Old-Data", "lang/options_areYouSure", "lang/options_restoreDescription", action, textIsLocalizationTerm);
	}

	public void ShowDLCSelector()
	{
		Action callback = Application.Quit;
		bool showBackButton = default(bool);
		PopupManager.CreateLoadableDLCSelection("LoadableDLCSelection", callback, textisLocalizationTerm: true, runCallbackIfNoDLC: false, showBackButton);
	}

	private void ShowDeleteAdventureDataPopup(Action onComplete)
	{
		//IL_007c: Expected I4, but got O
		//IL_007c: Expected I4, but got O
		//IL_007c: Expected I4, but got O
		_003C_003Ec__DisplayClass150_0 CS_0024_003C_003E8__locals6 = new _003C_003Ec__DisplayClass150_0();
		CS_0024_003C_003E8__locals6._003C_003E4__this = this;
		CS_0024_003C_003E8__locals6.onComplete = onComplete;
		Action action = delegate
		{
			OptionsController optionsController = CS_0024_003C_003E8__locals6._003C_003E4__this;
			optionsController._shouldDeleteAdventureData = true;
			Action onComplete2 = CS_0024_003C_003E8__locals6.onComplete;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v12.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		};
		Action action2 = delegate
		{
			OptionsController optionsController = CS_0024_003C_003E8__locals6._003C_003E4__this;
			optionsController._shouldDeleteAdventureData = false;
			Action onComplete2 = CS_0024_003C_003E8__locals6.onComplete;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v12.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		};
		string button2Text = default(string);
		Action button1Callback = default(Action);
		Action button2Callback = default(Action);
		bool titleIsLocalizationTerm = default(bool);
		PopupManager.CreateTwoButtonPopup("Delete-Adventure-Data-Popup", "adventureLang/adv_adventureDelete1", "adventureLang/adv_adventureDelete2", "lang/options_yes", button2Text, button1Callback, button2Callback, titleIsLocalizationTerm, (byte)(int)"lang/options_no" != 0, (byte)(int)action != 0, (byte)(int)action2 != 0);
	}

	public void DeleteSave()
	{
		//IL_0015: Expected I4, but got O
		Action<bool> action = null;
		((OptionsController)(object)action)._003CDeleteSave_003Eb__151_0((byte)(int)this != 0);
		bool textIsLocalizationTerm = default(bool);
		PopupManager.CreateOKCancelPopup("Delete-Save", "lang/options_deleteSave", "lang/options_deleteSaveMessage1", action, textIsLocalizationTerm);
	}

	private void ActuallyDeleteSave()
	{
		//IL_0084: Expected O, but got I4
		//IL_00e9: Expected I4, but got O
		//IL_0105: Expected O, but got I4
		if (AdventureManager._003CIsInAdventureMode_003Ek__BackingField)
		{
			_adventureManager.ExitAdventureMode(fireExitEvent: false);
		}
		_playerOptions.ClearSaveData(_shouldDeleteAdventureData);
		_achievementManager.CheckForStartupAchievements();
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 2f;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.PentagramSFX, soundConfig, 0f, 10, time);
		SelectTab(OptionsTabType.USER);
		_shouldDeleteAdventureData = false;
		Scene activeScene = SceneManager.GetActiveScene();
		string nameInternal = Scene.GetNameInternal((int)activeScene);
		Scene scene = SceneManager.LoadScene(nameInternal, (LoadSceneParameters)0);
	}

	private IEnumerator WaitAndReselect()
	{
		_003CWaitAndReselect_003Ed__153 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	private unsafe void HideAdsButtons(bool b)
	{
		//IL_006a: Expected O, but got Ref
		PlayerOptionsData config = _playerOptions.Config;
		config._003CEnableBonusAdsMechanics_003Ek__BackingField = b;
		PlayerOptionsData config2 = _playerOptions.Config;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object arg = default(object);
		System.ParamsArray paramsArray = new System.ParamsArray(arg);
		object obj = default(object);
		string message = string.FormatHelper((IFormatProvider)null, "HideAdsButtons Value: {0}", (System.ParamsArray)(&obj));
		Debug.Log(message);
	}

	private void OnTwitchConnectButtonPressed()
	{
		LabeledInputUI twitchChannelNameInput = _twitchChannelNameInput;
		TMP_InputField input = twitchChannelNameInput._Input;
		string text = input.m_Text;
		if (input.m_Text != null && text._stringLength > 0)
		{
			TwitchIntegration sInstance = TwitchIntegration._sInstance;
			sInstance._username = input.m_Text;
			UpdateTwitchButtonStates(updateSelection: true);
		}
	}

	private void OnTwitchDisconnectButtonPressed()
	{
		//IL_0015: Expected O, but got I
		//IL_0025: Expected O, but got I
		//IL_0056: Expected O, but got I
		//IL_0066: Expected O, but got I
		TwitchIntegration sInstance = TwitchIntegration._sInstance;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF00]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ rax_v5+B8]");
		object username = 0;
		sInstance._username = (string)username;
		LabeledInputUI twitchChannelNameInput = _twitchChannelNameInput;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF00]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ rax_v9+B8]");
		object value = 0;
		twitchChannelNameInput._Input.SetText((string)value, true);
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 120 Invalid \"Jump target not found in method: 0x186D56EE0\"");
		throw new NullReferenceException();
	}

	private void UpdateTwitchButtonStates(bool updateSelection = false)
	{
		TwitchIntegration sInstance = TwitchIntegration._sInstance;
		string username = sInstance._username;
		bool flag = ((sInstance._username != null && username._stringLength > 0) ? true : false);
		GameObject gameObject = _twitchConnectButton.gameObject;
		bool active = (byte)((flag ? 1u : 0u) ^ 1u) != 0;
		gameObject.SetActive(active);
		GameObject gameObject2 = _twitchDisconnectButton.gameObject;
		gameObject2.SetActive(flag);
		UpdateTwitchButtonNavigation(flag);
		if (updateSelection)
		{
			LabeledButtonUI labeledButtonUI = (flag ? _twitchDisconnectButton : _twitchConnectButton);
			labeledButtonUI._Button.Select();
		}
	}

	private void UpdateTwitchButtonNavigation(bool isTwitchConfigured)
	{
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Expected O, but got Unknown
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Expected O, but got Unknown
		//IL_01cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d1: Expected O, but got Unknown
		LabeledButtonUI twitchDisconnectButton = _twitchDisconnectButton;
		Button button = twitchDisconnectButton._Button;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rax_v4 (UnityEngine.UI.Button)+48]");
		_ = 0;
		_ = ((Selectable)button).m_Navigation;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rax_v4 (UnityEngine.UI.Button)+38]");
		_ = 0;
		Selectable component = _twitchChannelNameInput.GetComponent<Selectable>();
		LabeledButtonUI twitchDisconnectButton2 = _twitchDisconnectButton;
		object obj = default(object);
		Navigation navigation = (Navigation)(obj - 48);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ rsp-60]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ rsp-40]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ rsp-50]");
		_ = 0;
		twitchDisconnectButton2._Button.navigation = navigation;
		LabeledButtonUI twitchConnectButton = _twitchConnectButton;
		Button button2 = twitchConnectButton._Button;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v246 @ rax_v11 (UnityEngine.UI.Button)+48]");
		_ = 0;
		_ = ((Selectable)button2).m_Navigation;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v246 @ rax_v11 (UnityEngine.UI.Button)+38]");
		_ = 0;
		Selectable component2 = _twitchChannelNameInput.GetComponent<Selectable>();
		LabeledButtonUI twitchConnectButton2 = _twitchConnectButton;
		Navigation navigation2 = (Navigation)(obj - 48);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ rsp-60]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ rsp-40]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ rsp-50]");
		_ = 0;
		twitchConnectButton2._Button.navigation = navigation2;
		Selectable component3 = _twitchChannelNameInput.GetComponent<Selectable>();
		_ = component3.m_Navigation;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v249 @ rax_v18 (UnityEngine.UI.Selectable)+38]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v249 @ rax_v18 (UnityEngine.UI.Selectable)+48]");
		_ = 0;
		LabeledButtonUI labeledButtonUI = ((!isTwitchConfigured) ? _twitchConnectButton : _twitchDisconnectButton);
		_ = labeledButtonUI._Button;
		Selectable component4 = _twitchChannelNameInput.GetComponent<Selectable>();
		Navigation navigation3 = (Navigation)(obj - 48);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ rsp-60]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ rsp-40]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ rsp-50]");
		_ = 0;
		component4.navigation = navigation3;
	}

	public OptionsController()
	{
		//IL_008c: Expected I4, but got I8
		List<OptionsTabType> optionsConfig = new List<OptionsTabType>();
		_OptionsConfig = optionsConfig;
		List<IUIObject> spawnedUnselectables = new List<IUIObject>();
		_spawnedUnselectables = spawnedUnselectables;
		List<ISelectableUI> spawnedElements = new List<ISelectableUI>();
		_spawnedElements = spawnedElements;
		List<GameObject> spawnedTabs = new List<GameObject>();
		_spawnedTabs = spawnedTabs;
		List<string> resolutionStrings = new List<string>();
		_resolutionStrings = resolutionStrings;
		_selectedRefreshRate = -1;
		_vSyncEnabled = true;
		_selectedFrameRate = 60;
		List<Resolution> resolutions = new List<Resolution>();
		_resolutions = resolutions;
		List<Resolution> currentRefreshRateResolutions = new List<Resolution>();
		_currentRefreshRateResolutions = currentRefreshRateResolutions;
	}

	private void _003CBuildUserPage_003Eb__75_0()
	{
		//IL_0015: Expected I4, but got O
		Action<bool> action = null;
		((OptionsController)(object)action)._003CDeleteSave_003Eb__151_0((byte)(int)this != 0);
		bool textIsLocalizationTerm = default(bool);
		PopupManager.CreateOKCancelPopup("Delete-Save", "lang/options_deleteSave", "lang/options_deleteSaveMessage1", action, textIsLocalizationTerm);
	}

	private void _003CBuildMultiplayerPage_003Eb__80_0(int index)
	{
		SetPlayerColourIndex(0, index);
	}

	private void _003CBuildMultiplayerPage_003Eb__80_1(int index)
	{
		SetPlayerColourIndex(1, index);
	}

	private void _003CBuildMultiplayerPage_003Eb__80_2(int index)
	{
		SetPlayerColourIndex(2, index);
	}

	private void _003CBuildMultiplayerPage_003Eb__80_3(int index)
	{
		SetPlayerColourIndex(3, index);
	}

	private bool _003CHandleRefreshRateDropdown_003Eb__89_0(Resolution resolution)
	{
		//IL_0069: Expected O, but got I
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Expected O, but got Unknown
		if (_selectedResolution != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.UI.OptionsController)+F4]");
			if ((nint)0 != resolution.m_Width)
			{
				return false;
			}
			if (_selectedResolution != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.UI.OptionsController)+F4]");
				object obj = (nint)0 >> 32;
				object obj2 = obj - resolution.m_Height;
				return obj2 == null;
			}
		}
		System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
		bool result = default(bool);
		return result;
	}

	private void _003CRestoreBackup_003Eb__147_0(bool success)
	{
		//IL_0014: Expected I4, but got O
		if (success)
		{
			Action<bool> action = null;
			((OptionsController)(object)action)._003CRestoreBackup_003Eb__147_1((byte)(int)this != 0);
			SaveSystem.TryRestoreBackup(_playerOptions, action);
		}
	}

	private void _003CRestoreBackup_003Eb__147_1(bool restoreSuccess)
	{
		if (restoreSuccess)
		{
			_playerOptions.Save();
		}
		UniTaskVoid uniTaskVoid = VSUtils.RestartAppWithFrameDelay();
	}

	private void _003CRecoverOldData_003Eb__148_0(bool success)
	{
		if (success)
		{
			Migrator._003CAttemptMigration_003Ed__1 obj = null;
			obj.playerOptions = _playerOptions;
			obj._003C_003E1__state = 0;
			Coroutine coroutine = StartCoroutine(obj);
		}
	}

	private void _003CDeleteSave_003Eb__151_0(bool success1)
	{
		//IL_0032: Expected I4, but got O
		if (!success1)
		{
			IEnumerator routine = WaitAndReselect();
			Coroutine coroutine = StartCoroutine(routine);
		}
		else
		{
			Action<bool> action = null;
			((OptionsController)(object)action)._003CDeleteSave_003Eb__151_1((byte)(int)this != 0);
			bool textIsLocalizationTerm = default(bool);
			PopupManager.CreateOKCancelPopup("Delete-Save-2", "lang/options_deleteSave", "lang/options_deleteSaveMessage2", action, textIsLocalizationTerm);
		}
	}

	private void _003CDeleteSave_003Eb__151_1(bool success2)
	{
		//IL_0032: Expected I4, but got O
		if (!success2)
		{
			IEnumerator routine = WaitAndReselect();
			Coroutine coroutine = StartCoroutine(routine);
		}
		else
		{
			Action<bool> action = null;
			((OptionsController)(object)action)._003CDeleteSave_003Eb__151_2((byte)(int)this != 0);
			bool textIsLocalizationTerm = default(bool);
			PopupManager.CreateOKCancelPopup("Delete-Save-3", "lang/options_deleteSave", "lang/options_deleteSaveMessage3", action, textIsLocalizationTerm);
		}
	}

	private void _003CDeleteSave_003Eb__151_2(bool success3)
	{
		if (!success3)
		{
			IEnumerator routine = WaitAndReselect();
			Coroutine coroutine = StartCoroutine(routine);
		}
		else
		{
			_shouldDeleteAdventureData = true;
			ActuallyDeleteSave();
		}
	}
}
