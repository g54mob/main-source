using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using I2.Loc;
using Newtonsoft.Json.Linq;
using Rewired;
using TMPro;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using VampireSurvivors.Achievements;
using VampireSurvivors.App.Data.Adventures;
using VampireSurvivors.App.Scripts.Data;
using VampireSurvivors.App.Scripts.Framework.Adventures;
using VampireSurvivors.App.Tools;
using VampireSurvivors.App.UI;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Cheats;
using VampireSurvivors.Framework.Platforms;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects;
using VampireSurvivors.Objects.Algorithm;
using VampireSurvivors.Signals;
using Zenject;

namespace VampireSurvivors.UI;

public class CharacterSelectionPage : BaseUIPage, ICharacterSelector
{
	private enum State
	{
		SINGLEPLAYER,
		MULTIPLAYER
	}

	private class AIPopupChoice
	{
		public Rewired.Player _player;

		public AIType _aiType;
	}

	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Func<Rewired.Player, bool> _003C_003E9__105_0;

		public static Func<Rewired.Player, int> _003C_003E9__105_1;

		public static Action<MPPlayerItem> _003C_003E9__115_0;

		public static Func<KeyValuePair<CharacterType, CharacterItem>, bool> _003C_003E9__121_0;

		public static Func<KeyValuePair<CharacterType, CharacterItem>, bool> _003C_003E9__121_1;

		public static Func<KeyValuePair<CharacterType, CharacterItem>, bool> _003C_003E9__121_2;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal bool _003CShowAISettingsPopup_003Eb__105_0(Rewired.Player x)
		{
			//IL_00be: Expected I4, but got O
			if (x != null && x.controllers != null)
			{
				int joystickCount = x.controllers.joystickCount;
				if (joystickCount > 0)
				{
					return true;
				}
				if (x.controllers != null)
				{
					return x.controllers.hasKeyboard;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		internal int _003CShowAISettingsPopup_003Eb__105_1(Rewired.Player x)
		{
			//IL_0064: Expected I4, but got O
			if (x != null && x.controllers != null)
			{
				return x.controllers.joystickCount;
			}
			NullReferenceException ex = new NullReferenceException();
			return (int)ex;
		}

		internal void _003CShowPartySizePopup_003Eb__115_0(MPPlayerItem player)
		{
			player._PlayerState = MPPlayerItem.PlayerState.INACTIVE;
		}

		internal bool _003CPopulate_003Eb__121_0(KeyValuePair<CharacterType, CharacterItem> kvp)
		{
			//IL_0065: Expected O, but got I
			//IL_0055: Expected I4, but got O
			//IL_0015: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [kvp @ rdx (System.Collections.Generic.KeyValuePair`2<VampireSurvivors.Data.CharacterType, VampireSurvivors.UI.CharacterItem>)+8]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [kvp @ rdx (System.Collections.Generic.KeyValuePair`2<VampireSurvivors.Data.CharacterType, VampireSurvivors.UI.CharacterItem>)+8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ rax_v2+20]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ rax_v2+20]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v5+12]");
					return false;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		internal bool _003CPopulate_003Eb__121_1(KeyValuePair<CharacterType, CharacterItem> kvp)
		{
			//IL_011b: Expected O, but got I
			//IL_010b: Expected I4, but got O
			//IL_00bd: Expected O, but got I
			//IL_00e0: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [kvp @ rdx (System.Collections.Generic.KeyValuePair`2<VampireSurvivors.Data.CharacterType, VampireSurvivors.UI.CharacterItem>)+8]");
			CharacterItem characterItem = (CharacterItem)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [kvp @ rdx (System.Collections.Generic.KeyValuePair`2<VampireSurvivors.Data.CharacterType, VampireSurvivors.UI.CharacterItem>)+8]");
			if ((nint)0 != 0)
			{
				CharacterData characterData = characterItem._characterData;
				if (characterItem._characterData != null)
				{
					if ((object)characterData._003CrequiresRelic_003Ek__BackingField == null)
					{
						goto IL_00f7;
					}
					if (characterItem._playerOptions != null)
					{
						PlayerOptionsData config = characterItem._playerOptions.Config;
						if (config != null && config._003CCollectedItems_003Ek__BackingField != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A965C0");
							object obj = default(object);
							if (obj == null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [kvp @ rdx (System.Collections.Generic.KeyValuePair`2<VampireSurvivors.Data.CharacterType, VampireSurvivors.UI.CharacterItem>)+8]");
								if (!((CharacterItem)0).IsCharacterUnlocked())
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [kvp @ rdx (System.Collections.Generic.KeyValuePair`2<VampireSurvivors.Data.CharacterType, VampireSurvivors.UI.CharacterItem>)+8]");
									bool flag = ((CharacterItem)0).IsCharacterBought();
									return (byte)((flag ? 1u : 0u) ^ 1u) != 0;
								}
							}
							goto IL_00f7;
						}
					}
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
			IL_00f7:
			return false;
		}

		internal bool _003CPopulate_003Eb__121_2(KeyValuePair<CharacterType, CharacterItem> kvp)
		{
			//IL_004d: Expected O, but got I
			//IL_003d: Expected I4, but got O
			//IL_001b: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [kvp @ rdx (System.Collections.Generic.KeyValuePair`2<VampireSurvivors.Data.CharacterType, VampireSurvivors.UI.CharacterItem>)+8]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [kvp @ rdx (System.Collections.Generic.KeyValuePair`2<VampireSurvivors.Data.CharacterType, VampireSurvivors.UI.CharacterItem>)+8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ rax_v2+18]");
				object obj2 = --1;
				return obj2 == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private sealed class _003C_003Ec__DisplayClass105_0
	{
		public CharacterSelectionPage _003C_003E4__this;

		public int playerSlotIndex;

		public List<AIPopupChoice> popupChoices;

		internal void _003CShowAISettingsPopup_003Eb__2(int i)
		{
			_003C_003E4__this.PlayerSlotSelection(playerSlotIndex, i, popupChoices);
			_003C_003E4__this.GoToNextCharacterOrContinue();
		}
	}

	private sealed class _003C_003Ec__DisplayClass111_0
	{
		public Image i;

		public float outDuration;

		public GameObject g;

		public TweenCallback _003C_003E9__2;

		internal void _003CSpawnDoilie_003Eb__0()
		{
			TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTweenModuleUI.DOFade(i, 0f, outDuration);
		}

		internal void _003CSpawnDoilie_003Eb__1()
		{
			Transform transform = g.transform;
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(transform, 3f, outDuration);
			if (tweenerCore != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rax_v4 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
				if ((nint)0 != 0)
				{
					_ = 5;
					_ = 0;
				}
			}
			TweenCallback tweenCallback = _003C_003E9__2;
			if (_003C_003E9__2 == null)
			{
				tweenCallback = (_003C_003E9__2 = delegate
				{
					g.SetActive(value: false);
				});
			}
			if (tweenerCore != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rax_v4 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
				if ((nint)0 == 0)
				{
				}
			}
		}

		internal void _003CSpawnDoilie_003Eb__2()
		{
			g.SetActive(value: false);
		}
	}

	private sealed class _003C_003Ec__DisplayClass112_0
	{
		public Image i;

		public float outDuration;

		public GameObject g;

		public TweenCallback _003C_003E9__2;

		internal void _003CSpawnMinorDoilie_003Eb__0()
		{
			TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTweenModuleUI.DOFade(i, 0f, outDuration);
		}

		internal void _003CSpawnMinorDoilie_003Eb__1()
		{
			Transform transform = g.transform;
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(transform, 8f, outDuration);
			if (tweenerCore != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rax_v4 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
				if ((nint)0 != 0)
				{
					_ = 5;
					_ = 0;
				}
			}
			TweenCallback tweenCallback = _003C_003E9__2;
			if (_003C_003E9__2 == null)
			{
				tweenCallback = (_003C_003E9__2 = delegate
				{
					g.SetActive(value: false);
				});
			}
			if (tweenerCore != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rax_v4 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
				if ((nint)0 == 0)
				{
				}
			}
		}

		internal void _003CSpawnMinorDoilie_003Eb__2()
		{
			g.SetActive(value: false);
		}
	}

	private sealed class _003C_003Ec__DisplayClass131_0
	{
		public CharacterSelectionPage _003C_003E4__this;

		public int index;

		internal void _003CSpawnPlayerItem_003Eb__0()
		{
			CharacterSelectionPage characterSelectionPage = _003C_003E4__this;
			int num = index;
			characterSelectionPage._multiplayer.SelectSlot(index);
			List<MPPlayerItem> playerSlots = characterSelectionPage._playerSlots;
			if (index < playerSlots._size)
			{
				MPPlayerItem[] items = playerSlots._items;
				MPPlayerItem mPPlayerItem = items[num];
				mPPlayerItem._PlayerState = MPPlayerItem.PlayerState.INACTIVE;
			}
			else
			{
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			}
		}
	}

	private sealed class _003CSelectAfterFrameDelay_003Ed__76(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public CharacterSelectionPage _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_0177: Expected I4, but got I8
			//IL_018a: Expected I4, but got O
			CharacterSelectionPage characterSelectionPage = _003C_003E4__this;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this != null)
				{
					CharacterItemUI selectedCharacterItemUI = characterSelectionPage._selectedCharacterItemUI;
					if ((object)characterSelectionPage._selectedCharacterItemUI == null || ((UnityEngine.Object)selectedCharacterItemUI).m_CachedPtr == (IntPtr)0)
					{
						goto IL_01dd;
					}
					if ((object)characterSelectionPage._selectedCharacterItemUI != null)
					{
						characterSelectionPage._selectedCharacterItemUI.SetSelected();
						if ((object)characterSelectionPage._selectedCharacterItemUI != null)
						{
							characterSelectionPage._selectedCharacterItemUI.SetInfoPanel();
							if ((object)characterSelectionPage._selectedCharacterItemUI != null)
							{
								Button component = characterSelectionPage._selectedCharacterItemUI.GetComponent<Button>();
								if ((object)component != null)
								{
									component.Select();
									goto IL_01dd;
								}
							}
						}
					}
				}
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			if (_003C_003E1__state == 1)
			{
				_003C_003E1__state = -1;
			}
			return false;
			IL_01dd:
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

	private sealed class _003CWaitAndDo_003Ed__124(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
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
			//IL_0090: Expected I4, but got I8
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			}
			if (_003C_003E1__state == 1)
			{
				bool flag = cb == null;
				_003C_003E1__state = -1;
				if (!flag)
				{
					Action action = cb;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v137.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
				}
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

	private GameObject CharacterPrefab;

	private RectTransform Container;

	private Button ConfirmButton;

	private Button BuyButton;

	private Button StartButton;

	private Image PanelBackground;

	private TextMeshProUGUI _EggCount;

	private TextMeshProUGUI _EggCountTitle;

	private TickBoxUI _EggBox;

	private TextMeshProUGUI _MaxWeaponsText;

	private GameObject _EggWeaponBox;

	private GameObject _EggContainer;

	private GameObject _WeaponCountContainer;

	private Sprite _SkinOffIcon;

	private Sprite _SkinOnIcon;

	private RectTransform _SkinIndexContainer;

	private GameObject _SkinIndexPrefab;

	private RectTransform _Panel;

	private GameObject _MultiplayerTextPanel;

	private GameObject MPPlayerItemPrefab;

	private RectTransform MPPlayerContainer;

	private FakeSliderHandleController _StageCompletionScroller;

	private RectTransform _DoilieMask;

	private List<Sprite> _Doilies;

	private CharacterStageCompletionPanel _StageCompletionPanel;

	private TextMeshProUGUI _Name;

	private TextMeshProUGUI Description;

	private Image Icon;

	private Image WeaponIcon;

	private Image _LockIcon;

	private StatsPanelUI StatsPanel;

	private PriceUI Price;

	private GameObject _WeaponFrame;

	private EnterCoopButton _EnterCoopButton;

	private GameObject _SwitchReassignControllersButton;

	private GameObject _lastBonusButton;

	private bool _wasAllowingMultiplayerJoining;

	private bool _characterBoughtThisFrame;

	private TextMeshProUGUI _buyButtonLabel;

	private State state;

	private Dictionary<CharacterType, CharacterItemUI> _characterItemUIs;

	private List<MPPlayerItem> _playerSlots;

	private CharacterItemUI _selectedCharacterItemUI;

	private SignalBus _signalBus;

	private DataManager _dataManager;

	private DiContainer _diContainer;

	private readonly List<GameObject> _spawned;

	private PlayerOptions _playerOptions;

	private MultiplayerManager _multiplayer;

	private AdventureManager _adventureManager;

	private CharacterData _currentData;

	private CharacterType _currentType;

	private LargeMultiOptionPopup _AISelectionPopup;

	private LargeMultiOptionPopup _PartySizeSelectionPopup;

	private CharSelectionCheatCodeManager _cheats;

	private bool _characterConfirmed;

	private List<Image> _skinSlots;

	private List<int> _weirdCharacters;

	private List<CharacterType> _tempUnlockedCoopCharacters;

	private readonly float _iconUIScale;

	private int _partySize;

	private bool _partyModeEnabled
	{
		get
		{
			//IL_014a: Expected I4, but got O
			//IL_012c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0131: Expected I4, but got Unknown
			if (_playerOptions != null)
			{
				PlayerOptionsData config = _playerOptions.Config;
				if (config != null)
				{
					List<ItemType> list = config._003CCollectedItems_003Ek__BackingField;
					if (config._003CCollectedItems_003Ek__BackingField != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ rcx_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
							object obj = default(object);
							if ((nint)obj != -1)
							{
								if (_playerOptions != null)
								{
									PlayerOptionsData config2 = _playerOptions.Config;
									if (config2 != null && config2._003CSealedItems_003Ek__BackingField != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A965C0");
										object obj2 = default(object);
										return (byte)(obj2 ^ 1) != 0;
									}
								}
								goto IL_013c;
							}
						}
						return false;
					}
				}
			}
			goto IL_013c;
			IL_013c:
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private int _selectedPlayerSlotIndex
	{
		get
		{
			//IL_0041: Expected I4, but got O
			MultiplayerManager multiplayer = _multiplayer;
			if (_multiplayer != null)
			{
				return multiplayer._selectedPlayerIndex;
			}
			NullReferenceException ex = new NullReferenceException();
			return (int)ex;
		}
	}

	private void Construct(SignalBus signalBus, PlayerOptions playerOptions, DataManager dataManager, DiContainer diContainer, MultiplayerManager multi, AdventureManager adventureManager)
	{
		_signalBus = signalBus;
		_playerOptions = playerOptions;
		_dataManager = dataManager;
		DiContainer diContainer2 = default(DiContainer);
		_diContainer = diContainer2;
		MultiplayerManager multiplayer = default(MultiplayerManager);
		_multiplayer = multiplayer;
		AdventureManager adventureManager2 = default(AdventureManager);
		_adventureManager = adventureManager2;
	}

	private void Start()
	{
		CharSelectionCheatCodeManager cheats = _diContainer.Instantiate<CharSelectionCheatCodeManager>();
		_cheats = cheats;
		_cheats.Initialize();
		TextMeshProUGUI componentInChildren = _MultiplayerTextPanel.GetComponentInChildren<TextMeshProUGUI>(includeInactive: true);
		if ((object)componentInChildren != null && ((UnityEngine.Object)componentInChildren).m_CachedPtr != (IntPtr)0)
		{
			bool applyParameters = default(bool);
			GameObject localParametersRoot = default(GameObject);
			string overrideLanguage = default(string);
			bool allowLocalizedParameters = default(bool);
			string translation = LocalizationManager.GetTranslation("lang/multiplayer_connect_more_controllers", FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18634B7A0");
		}
		ScrollEnhancer scrollEnhancer = _scrollEnhancer;
		scrollEnhancer.RequiresMouseOverForScroll = true;
		Button component = BackButtonController.Instance.GetComponent<Button>();
		UnityAction call = HandleBackButton;
		component.m_OnClick.AddListener(call);
	}

	private void HandlePlayersPressingB()
	{
		int num = 0;
		while (true)
		{
			MultiplayerManager s_instance = MultiplayerManager.s_instance;
			List<CoopSlotData> slotsSelections = s_instance._slotsSelections;
			if (num >= slotsSelections._size)
			{
				break;
			}
			CoopSlotData slotInfo = MultiplayerManager.s_instance.GetSlotInfo(num);
			if (slotInfo.RewiredPlayer != null)
			{
				Rewired.Player selectedPlayer = _multiplayer.GetSelectedPlayer();
				if (slotInfo.RewiredPlayer != selectedPlayer && slotInfo.RewiredPlayer.GetButtonDown(10) && slotInfo.SelectedCharacter == CharacterType.VOID)
				{
					MultiplayerManager multiplayer = _multiplayer;
					if (num != multiplayer._selectedPlayerIndex)
					{
						multiplayer.AddPlayerForRemoval(slotInfo.RewiredPlayer);
					}
				}
			}
			num++;
		}
	}

	private void HandleBackButton()
	{
		LargeMultiOptionPopup aISelectionPopup = _AISelectionPopup;
		if ((object)_AISelectionPopup != null && ((UnityEngine.Object)aISelectionPopup).m_CachedPtr != (IntPtr)0)
		{
			return;
		}
		LargeMultiOptionPopup partySizeSelectionPopup = _PartySizeSelectionPopup;
		if ((object)_PartySizeSelectionPopup != null && ((UnityEngine.Object)partySizeSelectionPopup).m_CachedPtr != (IntPtr)0)
		{
			return;
		}
		int playerCount = _multiplayer.GetPlayerCount();
		MultiplayerManager multiplayer;
		if (playerCount > 1)
		{
			multiplayer = _multiplayer;
		}
		else
		{
			bool isOnlineMultiplayer = _multiplayer.IsOnlineMultiplayer;
			multiplayer = _multiplayer;
			if (!isOnlineMultiplayer)
			{
				if (!_multiplayer.IsUIBeingBlocked)
				{
					Button component = BackButtonController.Instance.GetComponent<Button>();
					Button.ButtonClickedEvent onClick = component.m_OnClick;
					UnityAction unityAction = HandleBackButton;
					MethodInfo methodImpl = ((MulticastDelegate)unityAction).GetMethodImpl();
					((UnityEventBase)onClick).m_Calls.RemoveListener(((Delegate)unityAction).m_target, methodImpl);
					BackButtonController.GoBack();
				}
				return;
			}
		}
		Rewired.Player currentUIPlayer = multiplayer.GetCurrentUIPlayer();
		Player = currentUIPlayer;
		if (_multiplayer.IsUIBeingBlocked)
		{
			return;
		}
		MultiplayerManager multiplayer2 = _multiplayer;
		if (multiplayer2._selectedPlayerIndex != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18695F8A0");
			MultiplayerManager multiplayer3 = _multiplayer;
			MultiplayerManager multiplayerManager = default(MultiplayerManager);
			CoopSlotData slotInfo = multiplayerManager.GetSlotInfo(multiplayer3._selectedPlayerIndex);
			slotInfo.SelectedCharacter = CharacterType.VOID;
			MultiplayerManager multiplayer4 = _multiplayer;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
			_ = 0;
			MultiplayerManager multiplayer5 = _multiplayer;
			int selectedPlayerIndex = multiplayer5._selectedPlayerIndex - 1;
			multiplayer5._selectedPlayerIndex = selectedPlayerIndex;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A6676]");
			if ((nint)0 < (nint)0)
			{
				multiplayer5._selectedPlayerIndex = 0;
			}
			List<CoopSlotData> slotsSelections = multiplayer5._slotsSelections;
			int selectedPlayerIndex2 = multiplayer5._selectedPlayerIndex;
			if (multiplayer5._selectedPlayerIndex >= slotsSelections._size)
			{
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				return;
			}
			CoopSlotData[] items = slotsSelections._items;
			CoopSlotData coopSlotData = items[selectedPlayerIndex2];
			if (coopSlotData.RewiredPlayer != null)
			{
				float vibrationMS = default(float);
				multiplayer5.SelectPlayerToControlUI(coopSlotData.RewiredPlayer, exclusiveUIControl: true, vibrate: true, vibrationMS);
			}
			Rewired.Player selectedPlayer = _multiplayer.GetSelectedPlayer();
			_multiplayer.PlayerControlOverride(selectedPlayer);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18695F8A0");
			MultiplayerManager multiplayer6 = _multiplayer;
			MultiplayerManager multiplayerManager2 = default(MultiplayerManager);
			CoopSlotData slotInfo2 = multiplayerManager2.GetSlotInfo(multiplayer6._selectedPlayerIndex);
			object selectedCharacterItemUI = ((Dictionary<System.Int32Enum, object>)(object)_characterItemUIs).get_Item((System.Int32Enum)slotInfo2.SelectedCharacter);
			_selectedCharacterItemUI = (CharacterItemUI)selectedCharacterItemUI;
			_selectedCharacterItemUI.SetSelected();
			MultiplayerManager multiplayer7 = _multiplayer;
			CharacterItemUI characterItemUI = ((Dictionary<CharacterType, CharacterItemUI>)(object)_playerSlots).get_Item((CharacterType)multiplayer7._selectedPlayerIndex);
			((MPPlayerItem)(object)characterItemUI).GoToSelecting();
			ResetDisplay(playerLeftGame: true);
		}
		else
		{
			ClearPlayers();
			Action cb = BackButtonController.GoBack;
			IEnumerator routine = WaitAndDo(cb);
			Coroutine coroutine = StartCoroutine(routine);
		}
		_multiplayer.Refresh();
	}

	protected override void Update()
	{
		//IL_0c18: Expected O, but got I4
		//IL_0c79: Expected O, but got I4
		//IL_0c93: Expected O, but got I4
		//IL_0472: Expected O, but got I4
		//IL_04d4: Expected O, but got I4
		//IL_0344->IL0b8b: Incompatible stack heights: 1 vs 0
		//IL_02e9->IL0b8b: Incompatible stack heights: 1 vs 0
		//IL_0cd1->IL0b8b: Incompatible stack heights: 1 vs 0
		//IL_0409->IL0b8b: Incompatible stack heights: 1 vs 0
		//IL_0b67->IL0b8b: Incompatible stack heights: 1 vs 0
		//IL_0751->IL0b8b: Incompatible stack heights: 1 vs 0
		//IL_06fc->IL0b8b: Incompatible stack heights: 1 vs 0
		//IL_045a->IL0b8b: Incompatible stack heights: 1 vs 0
		//IL_04bc->IL0b8b: Incompatible stack heights: 2 vs 0
		//IL_082b->IL0b8b: Incompatible stack heights: 1 vs 0
		//IL_078d->IL0b8b: Incompatible stack heights: 1 vs 0
		//IL_0512->IL0b8b: Incompatible stack heights: 3 vs 0
		//IL_07ac->IL0b8b: Incompatible stack heights: 1 vs 0
		//IL_0551->IL0b8b: Incompatible stack heights: 3 vs 0
		//IL_05a1->IL0b8b: Incompatible stack heights: 4 vs 0
		//IL_05e6->IL0b8b: Incompatible stack heights: 5 vs 0
		//IL_088f->IL0b8b: Incompatible stack heights: 1 vs 0
		//IL_0626->IL0b8b: Incompatible stack heights: 5 vs 0
		//IL_08bb->IL0b8b: Incompatible stack heights: 1 vs 0
		//IL_0648->IL0b8b: Incompatible stack heights: 5 vs 0
		//IL_0677->IL0677: Incompatible stack heights: 5 vs 1
		//IL_0982->IL0b8b: Incompatible stack heights: 1 vs 0
		//IL_09ae->IL0b8b: Incompatible stack heights: 1 vs 0
		//IL_0940->IL0b8b: Incompatible stack heights: 1 vs 0
		//IL_0b39->IL0b8b: Incompatible stack heights: 1 vs 0
		//IL_09e8->IL0b8b: Incompatible stack heights: 1 vs 0
		//IL_0a14->IL0b8b: Incompatible stack heights: 1 vs 0
		//IL_0b01->IL0b8b: Incompatible stack heights: 1 vs 0
		//IL_0a4e->IL0b8b: Incompatible stack heights: 1 vs 0
		//IL_0a7a->IL0b8b: Incompatible stack heights: 1 vs 0
		//IL_0ac9->IL0b8b: Incompatible stack heights: 1 vs 0
		base.Update();
		if (_cheats != null)
		{
			_cheats.InternalUpdate();
			SetDisplayType();
			int num = 0;
			Selectable right = default(Selectable);
			while (true)
			{
				MultiplayerManager s_instance = MultiplayerManager.s_instance;
				if (MultiplayerManager.s_instance == null)
				{
					break;
				}
				List<CoopSlotData> slotsSelections = s_instance._slotsSelections;
				if (s_instance._slotsSelections == null)
				{
					break;
				}
				if (num < slotsSelections._size)
				{
					if (MultiplayerManager.s_instance == null)
					{
						break;
					}
					CoopSlotData slotInfo = MultiplayerManager.s_instance.GetSlotInfo(num);
					if (slotInfo == null)
					{
						break;
					}
					if (slotInfo.RewiredPlayer != null)
					{
						if (_multiplayer == null)
						{
							break;
						}
						Rewired.Player selectedPlayer = _multiplayer.GetSelectedPlayer();
						if (slotInfo.RewiredPlayer != selectedPlayer && slotInfo.RewiredPlayer.GetButtonDown(10) && slotInfo.SelectedCharacter == CharacterType.VOID)
						{
							MultiplayerManager multiplayer = _multiplayer;
							if (_multiplayer == null)
							{
								break;
							}
							if (num != multiplayer._selectedPlayerIndex)
							{
								_multiplayer.AddPlayerForRemoval(slotInfo.RewiredPlayer);
							}
						}
					}
					num++;
					continue;
				}
				if (Player == null)
				{
					break;
				}
				if (!Player.GetButtonDown(10))
				{
					if (Player == null)
					{
						break;
					}
					if (!Player.GetButtonDown(6))
					{
						goto IL_027a;
					}
				}
				HandleBackButton();
				goto IL_027a;
				IL_027a:
				if ((object)_EnterCoopButton == null)
				{
					break;
				}
				GameObject gameObject = _EnterCoopButton.gameObject;
				if ((object)gameObject == null)
				{
					break;
				}
				bool flag = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
				object obj = GameObject.get_activeInHierarchy_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
				GameObject gameObject2;
				if (obj == null)
				{
					if ((object)_SwitchReassignControllersButton == null)
					{
						break;
					}
					bool activeInHierarchy = _SwitchReassignControllersButton.activeInHierarchy;
					bool flag2 = !activeInHierarchy;
					gameObject2 = null;
					if (!flag2)
					{
						gameObject2 = _SwitchReassignControllersButton;
					}
				}
				else
				{
					if ((object)_EnterCoopButton == null)
					{
						break;
					}
					GameObject gameObject3 = _EnterCoopButton.gameObject;
					gameObject2 = gameObject3;
				}
				Rewired.Player lastBonusButton = (Rewired.Player)(object)_lastBonusButton;
				bool flag3 = (object)gameObject2 == null;
				bool flag4 = (object)_lastBonusButton == null;
				object obj2 = flag4 & flag3;
				bool flag5 = obj2 == null;
				object obj3 = !flag5;
				if (obj3 == null)
				{
					bool flag6;
					if ((object)_lastBonusButton != null)
					{
						if ((object)gameObject2 != null)
						{
							object obj4 = (object)gameObject2 - (object)_lastBonusButton;
							flag6 = obj4 == null;
						}
						else
						{
							flag6 = lastBonusButton.YJkKJUbiHwaGAFRHfMnrcXCAcuICA == null;
						}
					}
					else
					{
						if ((object)gameObject2 == null)
						{
							break;
						}
						flag6 = ((UnityEngine.Object)gameObject2).m_CachedPtr == (IntPtr)0;
					}
					if (!flag6)
					{
						_lastBonusButton = gameObject2;
						List<GameObject> spawned = _spawned;
						if (_spawned == null)
						{
							break;
						}
						object obj5 = spawned._size - 1;
						bool flag7 = (nint)obj5 >= spawned._size;
						GameObject[] items = spawned._items;
						if (spawned._items == null)
						{
							break;
						}
						object obj6 = spawned._size - 1;
						bool flag8 = (nint)obj6 >= items.Length;
						if ((object)items[obj6] == null)
						{
							break;
						}
						Selectable component = items[obj6].GetComponent<Selectable>();
						List<GameObject> spawned2 = _spawned;
						if (_spawned == null)
						{
							break;
						}
						bool flag9 = spawned2._size <= 0;
						GameObject[] items2 = spawned2._items;
						if (spawned2._items == null)
						{
							break;
						}
						bool flag10 = items2.Length <= 0;
						if ((object)items2[0] == null)
						{
							break;
						}
						Selectable component2 = items2[0].GetComponent<Selectable>();
						EnterCoopButton enterCoopButton = _EnterCoopButton;
						if ((object)_EnterCoopButton == null || (object)enterCoopButton._button == null)
						{
							break;
						}
						Selectable component3 = enterCoopButton._button.GetComponent<Selectable>();
						ForceBackButtonNavigation(component, component2, null, right);
					}
				}
				MultiplayerManager s_instance2 = MultiplayerManager.s_instance;
				if (MultiplayerManager.s_instance == null)
				{
					break;
				}
				if (s_instance2.AllowPlayerJoining && !_wasAllowingMultiplayerJoining)
				{
					if (!_partyModeEnabled)
					{
						MultiplayerManager multiplayer2 = _multiplayer;
						if (_multiplayer == null)
						{
							break;
						}
						multiplayer2.PartyModeEnabled = false;
					}
					else
					{
						LargeMultiOptionPopup partySizeSelectionPopup = ShowPartySizePopup();
						_PartySizeSelectionPopup = partySizeSelectionPopup;
						MultiplayerManager multiplayer3 = _multiplayer;
						if (_multiplayer == null)
						{
							break;
						}
						multiplayer3.PartyModeEnabled = true;
					}
					if (state == State.SINGLEPLAYER)
					{
						MultiplayerManager multiplayer4 = _multiplayer;
						if (_multiplayer == null || (object)_MultiplayerTextPanel == null)
						{
							break;
						}
						_MultiplayerTextPanel.SetActive(multiplayer4.AllowPlayerJoining);
					}
					RefreshCharacters();
					_wasAllowingMultiplayerJoining = true;
				}
				FakeSliderHandleController stageCompletionScroller = _StageCompletionScroller;
				if ((object)_StageCompletionScroller != null && ((UnityEngine.Object)stageCompletionScroller).m_CachedPtr != (IntPtr)0)
				{
					if ((object)_StageCompletionScroller == null)
					{
						break;
					}
					GameObject gameObject4 = _StageCompletionScroller.gameObject;
					if ((object)gameObject4 != null && ((UnityEngine.Object)gameObject4).m_CachedPtr != (IntPtr)0)
					{
						if ((object)_StageCompletionScroller == null)
						{
							break;
						}
						GameObject gameObject5 = _StageCompletionScroller.gameObject;
						if ((object)gameObject5 == null)
						{
							break;
						}
						if (gameObject5.activeInHierarchy)
						{
							CharacterItemUI selectedCharacterItemUI = _selectedCharacterItemUI;
							if ((object)_selectedCharacterItemUI != null && ((UnityEngine.Object)selectedCharacterItemUI).m_CachedPtr != (IntPtr)0)
							{
								if ((object)_selectedCharacterItemUI == null)
								{
									break;
								}
								VampireSurvivors.App.Tools.Extensions.SetNavigationLeft(target: _selectedCharacterItemUI.GetComponent<Selectable>(), origin: _StageCompletionScroller);
							}
							if ((object)BuyButton == null)
							{
								break;
							}
							GameObject gameObject6 = BuyButton.gameObject;
							if ((object)gameObject6 == null)
							{
								break;
							}
							FakeSliderHandleController stageCompletionScroller2;
							Button onDown;
							if (!gameObject6.activeInHierarchy)
							{
								if ((object)StartButton == null)
								{
									break;
								}
								GameObject gameObject7 = StartButton.gameObject;
								if ((object)gameObject7 == null)
								{
									break;
								}
								if (!gameObject7.activeInHierarchy)
								{
									if ((object)ConfirmButton == null)
									{
										break;
									}
									GameObject gameObject8 = ConfirmButton.gameObject;
									if ((object)gameObject8 == null)
									{
										break;
									}
									if (!gameObject8.activeInHierarchy)
									{
										goto IL_0b4d;
									}
									stageCompletionScroller2 = _StageCompletionScroller;
									if ((object)_StageCompletionScroller == null)
									{
										break;
									}
									onDown = ConfirmButton;
								}
								else
								{
									stageCompletionScroller2 = _StageCompletionScroller;
									if ((object)_StageCompletionScroller == null)
									{
										break;
									}
									onDown = StartButton;
								}
							}
							else
							{
								stageCompletionScroller2 = _StageCompletionScroller;
								if ((object)_StageCompletionScroller == null)
								{
									break;
								}
								onDown = BuyButton;
							}
							stageCompletionScroller2._OnDown = onDown;
						}
					}
				}
				goto IL_0b4d;
				IL_0b4d:
				if (Multiplayer == null)
				{
					break;
				}
				Rewired.Player selectedPlayer2 = Multiplayer.GetSelectedPlayer();
				Player = selectedPlayer2;
				return;
			}
		}
		throw new NullReferenceException();
	}

	private void LateUpdate()
	{
		_characterBoughtThisFrame = false;
	}

	private void EnterCoopMode()
	{
		if (!_partyModeEnabled)
		{
			MultiplayerManager multiplayer = _multiplayer;
			multiplayer.PartyModeEnabled = false;
		}
		else
		{
			LargeMultiOptionPopup partySizeSelectionPopup = ShowPartySizePopup();
			_PartySizeSelectionPopup = partySizeSelectionPopup;
			MultiplayerManager multiplayer2 = _multiplayer;
			multiplayer2.PartyModeEnabled = true;
		}
		if (state == State.SINGLEPLAYER)
		{
			MultiplayerManager multiplayer3 = _multiplayer;
			_MultiplayerTextPanel.SetActive(multiplayer3.AllowPlayerJoining);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 139 Invalid \"Jump target not found in method: 0x186C8AEE0\"");
		throw new NullReferenceException();
	}

	private void ClearPlayers()
	{
		_multiplayer.ClearAllExtraPlayers();
		MultiplayerManager multiplayer = _multiplayer;
		multiplayer.AllowPlayerJoining = false;
	}

	private void OnDestroy()
	{
		if (_cheats != null)
		{
			_cheats.Dispose();
		}
	}

	public void RefreshCharacters()
	{
		//IL_0035: Expected O, but got I4
		//IL_0278: Expected O, but got I
		//IL_0288: Expected O, but got I
		//IL_0302: Expected O, but got I
		//IL_09f1: Expected O, but got I
		//IL_0a01: Expected O, but got I
		//IL_036c: Expected O, but got I
		//IL_0a50: Expected O, but got I
		//IL_0a60: Expected O, but got I
		//IL_03d6: Expected O, but got I
		//IL_0aa8: Expected O, but got I
		//IL_0ab8: Expected O, but got I
		//IL_0449: Expected O, but got I
		//IL_047a: Expected I, but got O
		//IL_0b08: Expected O, but got I
		//IL_04d3: Expected O, but got I
		//IL_050a: Expected O, but got I
		//IL_0674: Expected O, but got I
		//IL_0682: Expected O, but got I4
		//IL_06e5: Expected O, but got I
		//IL_08c0: Expected O, but got I4
		//IL_06f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f8: Expected O, but got Unknown
		//IL_078f: Expected O, but got I
		//IL_07d7: Expected O, but got I4
		//IL_080b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0810: Expected O, but got Unknown
		bool flag = _characterItemUIs == null;
		List<CharacterType> list = (List<CharacterType>)(object)this;
		PlayerOptionsData playerOptionsData;
		if (!flag)
		{
			Dictionary<CharacterType, CharacterItemUI>.Enumerator enumerator = default(Dictionary<CharacterType, CharacterItemUI>.Enumerator);
			CharacterItemUI characterItemUI = default(CharacterItemUI);
			while (enumerator.MoveNext())
			{
				if ((object)characterItemUI != null)
				{
					characterItemUI._forcedUnlockState = (UIUnlockStates?)(object)0;
					characterItemUI.Refresh(setInfoPanel: false);
					continue;
				}
				throw new NullReferenceException();
			}
			list = _tempUnlockedCoopCharacters;
			if (_tempUnlockedCoopCharacters != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ rcx_v28 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
				_ = (nint)0 + (nint)1;
				_ = 0;
				if (_multiplayer != null)
				{
					int playerCount = _multiplayer.GetPlayerCount();
					bool flag2 = playerCount > 1;
					list = (List<CharacterType>)(object)_multiplayer;
					if (!flag2)
					{
						bool isOnlineMultiplayer = _multiplayer.IsOnlineMultiplayer;
						bool flag3 = !isOnlineMultiplayer;
						list = (List<CharacterType>)(object)_multiplayer;
						if (flag3)
						{
							goto IL_0969;
						}
					}
					PlayerOptions playerOptions = _playerOptions;
					if (_playerOptions != null)
					{
						if (playerOptions._onlineClientWithRunDataConfig == null)
						{
							if (playerOptions._hostGameConfig == null)
							{
								if (playerOptions._currentAdventureSaveData != null)
								{
									playerOptionsData = playerOptions._currentAdventureSaveData;
									if ((object)playerOptionsData._003CSelectedAdventureType_003Ek__BackingField != null)
									{
										goto IL_09b1;
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
						goto IL_09b1;
					}
				}
			}
		}
		goto IL_084f;
		IL_0b3b:
		PlayerOptionsData playerOptionsData2;
		System.Int32Enum int32Enum;
		if (playerOptionsData2 != null)
		{
			list = playerOptionsData2._003CBoughtCharacters_003Ek__BackingField;
			if (playerOptionsData2._003CBoughtCharacters_003Ek__BackingField != null)
			{
				System.Int32Enum num = int32Enum;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ rcx_v28 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
				object obj = (nint)num - (nint)0;
				UIUnlockStates? uIUnlockStates = (UIUnlockStates?)(object)0;
				object obj3 = default(object);
				object obj4 = default(object);
				object obj5 = default(object);
				while (true)
				{
					object obj2 = obj3;
					while (true)
					{
						if (obj4 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v509 @ stack_-A8_v17+1C]");
							if (obj5 == null)
							{
								object obj6 = obj2;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v509 @ stack_-A8_v17+18]");
								if ((nint)obj6 < 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v509 @ stack_-A8_v17+10]");
									object obj7 = 0;
									obj2++;
									if (System.Runtime.CompilerServices.Unsafe.As<UIUnlockStates?, UIntPtr>(ref uIUnlockStates) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj))
									{
										continue;
									}
									goto IL_0717;
								}
								break;
							}
							break;
						}
						throw new NullReferenceException();
					}
					break;
					IL_0717:
					bool flag4 = _characterItemUIs == null;
					Dictionary<CharacterType, CharacterItemUI> characterItemUIs = _characterItemUIs;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v517 @ rbx_v25+20+v530 @ rdx_v38*4]");
					int num2 = ((Dictionary<System.Int32Enum, object>)(object)characterItemUIs).FindEntry((System.Int32Enum)0);
					obj3 = obj2;
					if (!flag4)
					{
						Dictionary<CharacterType, CharacterItemUI> characterItemUIs2 = _characterItemUIs;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v517 @ rbx_v25+20+v530 @ rdx_v38*4]");
						object obj8 = ((Dictionary<System.Int32Enum, object>)(object)characterItemUIs2).get_Item((System.Int32Enum)0);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v781 @ rax_v84 (System.Object)+118]");
						bool flag5 = ((CharacterItem)0).IsCharacterBought();
						obj3 = obj2;
						if (!flag5)
						{
							Dictionary<CharacterType, CharacterItemUI> characterItemUIs3 = _characterItemUIs;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v517 @ rbx_v25+20+v530 @ rdx_v38*4]");
							object obj9 = ((Dictionary<System.Int32Enum, object>)(object)characterItemUIs3).get_Item((System.Int32Enum)0);
							((CharacterItemUI)obj9)._forcedUnlockState = (UIUnlockStates?)(object)1;
							((CharacterItemUI)obj9).Refresh(false);
							List<CharacterType> tempUnlockedCoopCharacters = _tempUnlockedCoopCharacters;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v517 @ rbx_v25+20+v530 @ rdx_v38*4]");
							tempUnlockedCoopCharacters.InsertRange(0, null);
							uIUnlockStates = (UIUnlockStates?)(object)((_003F?)uIUnlockStates + 1);
							obj3 = obj2;
						}
					}
				}
				if (obj4 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v509 @ stack_-A8_v17+1C]");
					if (obj5 == null)
					{
						goto IL_0969;
					}
					System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
					object obj10 = 0;
				}
				throw new NullReferenceException();
			}
		}
		goto IL_084f;
		IL_0af1:
		List<CharacterType> list2;
		bool flag6 = list2 == null;
		nint num3;
		list = (List<CharacterType>)num3;
		List<CharacterType> collection;
		if (!flag6)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1649 @ rax_v54 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			((List<System.Int32Enum>)(object)list2).InsertRange(0, (IEnumerable<System.Int32Enum>)collection);
			PlayerOptions playerOptions2 = _playerOptions;
			bool flag7 = _playerOptions == null;
			list = list2;
			if (!flag7)
			{
				list = list2;
				if (playerOptions2._onlineClientWithRunDataConfig == null)
				{
					if (playerOptions2._hostGameConfig == null)
					{
						if (playerOptions2._currentAdventureSaveData != null)
						{
							playerOptionsData2 = playerOptions2._currentAdventureSaveData;
							if ((object)playerOptionsData2._003CSelectedAdventureType_003Ek__BackingField != null)
							{
								goto IL_0b3b;
							}
						}
						playerOptionsData2 = playerOptions2._mainGameConfig;
					}
					else
					{
						playerOptionsData2 = playerOptions2._hostGameConfig;
					}
				}
				else
				{
					playerOptionsData2 = playerOptions2._onlineClientWithRunDataConfig;
				}
				goto IL_0b3b;
			}
		}
		goto IL_084f;
		IL_09b1:
		if (playerOptionsData != null)
		{
			list = playerOptionsData._003CBoughtCharacters_003Ek__BackingField;
			if (playerOptionsData._003CBoughtCharacters_003Ek__BackingField != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ rcx_v28 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
				if ((nint)0 >= (nint)4)
				{
					goto IL_0969;
				}
				List<CharacterType> list3 = new List<CharacterType>();
				bool flag8 = list3 == null;
				list = list3;
				if (!flag8)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1471 @ rax_v48 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
					_ = (nint)0 + (nint)1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1471 @ rax_v48 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
					list = (List<CharacterType>)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1471 @ rax_v48 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
					object obj11 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1471 @ rax_v48 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1471 @ rax_v48 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
						nint num4 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ rcx_v28 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
						if (num4 >= 0)
						{
							((List<System.Int32Enum>)(object)list3).AddWithResize((System.Int32Enum)1);
						}
						else
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1471 @ rax_v48 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
							object obj12 = (nint)0 + (nint)1;
							_ = 1;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1471 @ rax_v48 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
						_ = (nint)0 + (nint)1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1471 @ rax_v48 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
						list = (List<CharacterType>)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1471 @ rax_v48 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
						object obj13 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1471 @ rax_v48 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1471 @ rax_v48 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
							nint num5 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ rcx_v28 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
							if (num5 >= 0)
							{
								((List<System.Int32Enum>)(object)list3).AddWithResize((System.Int32Enum)2);
							}
							else
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1471 @ rax_v48 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
								object obj14 = (nint)0 + (nint)1;
								_ = 2;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1471 @ rax_v48 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
							_ = (nint)0 + (nint)1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1471 @ rax_v48 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
							list = (List<CharacterType>)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1471 @ rax_v48 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
							object obj15 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1471 @ rax_v48 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1471 @ rax_v48 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
								nint num6 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ rcx_v28 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
								if (num6 >= 0)
								{
									((List<System.Int32Enum>)(object)list3).AddWithResize((System.Int32Enum)3);
								}
								else
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1471 @ rax_v48 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
									object obj16 = (nint)0 + (nint)1;
									_ = 3;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1471 @ rax_v48 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
								_ = (nint)0 + (nint)1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1471 @ rax_v48 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
								list = (List<CharacterType>)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1471 @ rax_v48 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
								object obj17 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1471 @ rax_v48 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
								if ((nint)0 != 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1471 @ rax_v48 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
									nint num7 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ rcx_v28 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
									if (num7 >= 0)
									{
										((List<System.Int32Enum>)(object)list3).AddWithResize((System.Int32Enum)4);
										int32Enum = (System.Int32Enum)4;
									}
									else
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1471 @ rax_v48 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
										object obj18 = (nint)0 + (nint)1;
										_ = 4;
										int32Enum = (System.Int32Enum)4;
									}
									list2 = new List<CharacterType>();
									nint num8 = (nint)typeof(AdventureManager);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1695 @ rax_v59 (Il2CppClass<VampireSurvivors.App.Scripts.Framework.Adventures.AdventureManager>)+B8]");
									num3 = 0;
									bool flag9 = !AdventureManager._003CIsInAdventureMode_003Ek__BackingField;
									collection = list3;
									if (flag9)
									{
										goto IL_0af1;
									}
									AdventureManager adventureManager = _adventureManager;
									bool flag10 = _adventureManager == null;
									list = (List<CharacterType>)num3;
									if (!flag10)
									{
										AdventureData adventureData = adventureManager._003CAdventureData_003Ek__BackingField;
										bool flag11 = adventureManager._003CAdventureData_003Ek__BackingField == null;
										list = (List<CharacterType>)num3;
										if (!flag11)
										{
											collection = adventureData._003CCharacterTypes_003Ek__BackingField;
											goto IL_0af1;
										}
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_084f;
		IL_084f:
		throw new NullReferenceException();
		IL_0969:
		RefreshMaxWeaponsAndEggsDisplay();
		IEnumerator routine = SelectAfterFrameDelay();
		Coroutine coroutine = StartCoroutine(routine);
	}

	private IEnumerator SelectAfterFrameDelay()
	{
		_003CSelectAfterFrameDelay_003Ed__76 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	public unsafe void ConfirmCharacter()
	{
		//IL_0186: Expected O, but got Ref
		//IL_008a: Expected O, but got I4
		int playerCount = _multiplayer.GetPlayerCount();
		if (playerCount <= 1 && !_multiplayer.IsOnlineMultiplayer && state != State.MULTIPLAYER)
		{
			MultiplayerManager multiplayer = _multiplayer;
			multiplayer.PartySize = (int?)(object)0;
			List<MPPlayerItem> playerSlots = _playerSlots;
			if (playerSlots._size > 0)
			{
				MPPlayerItem[] items = playerSlots._items;
				MPPlayerItem mPPlayerItem = items[0];
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9DAE0");
				SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
				soundConfig.Rate = 1f;
				soundConfig.Detune = 200f;
				float time = default(float);
				PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.ClickIn, soundConfig, 0f, 10, time);
				return;
			}
		}
		else
		{
			MultiplayerManager multiplayer2 = _multiplayer;
			Color slotColor = _multiplayer.GetSlotColor(multiplayer2._selectedPlayerIndex);
			object obj = default(object);
			_selectedCharacterItemUI.SetTakenByAnotherPlayer(taken: true, (Color)(&obj));
			MultiplayerManager multiplayer3 = _multiplayer;
			List<MPPlayerItem> playerSlots2 = _playerSlots;
			int selectedPlayerIndex = multiplayer3._selectedPlayerIndex;
			if (multiplayer3._selectedPlayerIndex < playerSlots2._size)
			{
				MPPlayerItem[] items2 = playerSlots2._items;
				MPPlayerItem mPPlayerItem2 = items2[selectedPlayerIndex];
				mPPlayerItem2._PlayerState = MPPlayerItem.PlayerState.LOCKED;
				if (_partyModeEnabled)
				{
					MultiplayerManager multiplayer4 = _multiplayer;
					if (multiplayer4._selectedPlayerIndex != 0)
					{
						LargeMultiOptionPopup aISelectionPopup = ShowAISettingsPopup(multiplayer4._selectedPlayerIndex);
						_AISelectionPopup = aISelectionPopup;
						return;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 425 Invalid \"Jump target not found in method: 0x186C8BC90\"");
				throw new NullReferenceException();
			}
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	private bool DoesSlotNeedCharacterChoice(int slotIndex)
	{
		//IL_0199: Expected I4, but got O
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Expected I4, but got Unknown
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Expected I4, but got Unknown
		//IL_017b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0180: Expected I4, but got Unknown
		if (_multiplayer != null)
		{
			CoopSlotData slotInfo = _multiplayer.GetSlotInfo(slotIndex);
			if (slotInfo != null)
			{
				if (slotInfo.SelectedCharacter != CharacterType.VOID)
				{
					return false;
				}
				MultiplayerManager multiplayer = _multiplayer;
				if (_multiplayer != null)
				{
					if (!multiplayer.PartyModeEnabled)
					{
						bool flag = (nint)slotInfo.RewiredPlayer < 0;
						bool flag2 = slotInfo.RewiredPlayer == null;
						bool flag3 = !flag;
						bool flag4 = !flag2;
						return flag4 & flag3;
					}
					object obj = (object?)multiplayer.PartySize >> 32;
					object obj2 = slotIndex - obj;
					int num = slotIndex ^ obj;
					int num2 = slotIndex ^ obj2;
					int num3 = num & num2;
					bool flag5 = num3 < 0;
					bool flag6 = (nint)obj2 < 0;
					bool flag7 = flag6 != flag5;
					return (byte)((flag7 & (_003F?)multiplayer.PartySize) ? 1 : 0) != 0;
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private unsafe void GoToNextCharacterOrContinue()
	{
		//IL_0008: Expected O, but got Ref
		//IL_05bf: Expected O, but got I
		//IL_0107: Expected O, but got Ref
		//IL_0156: Expected O, but got Ref
		//IL_0267: Expected O, but got Ref
		//IL_0289: Expected O, but got Ref
		//IL_029d: Expected native int or pointer, but got O
		//IL_02b5: Expected O, but got Ref
		//IL_034b: Expected O, but got Ref
		//IL_035f: Expected native int or pointer, but got O
		//IL_0377: Expected O, but got Ref
		object obj2 = default(object);
		object obj = (object)(&obj2);
		List<MPPlayerItem> playerSlots = _playerSlots;
		_ = 0;
		int num = 0;
		int num2 = 0;
		object arg = default(object);
		float time = default(float);
		while (true)
		{
			if (num2 >= playerSlots._size)
			{
				goto IL_047a;
			}
			List<MPPlayerItem> playerSlots2 = _playerSlots;
			if (num < playerSlots2._size)
			{
				MPPlayerItem[] items = playerSlots2._items;
				MPPlayerItem mPPlayerItem = items[num];
				if (num >= _partySize && _partySize != 0)
				{
					goto IL_047a;
				}
				string[] array = new string[8];
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				int num3 = (int)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 103));
				string text = ((int*)num3)->ToString();
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				Enum obj3 = (Enum)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
				_ = typeof(CharacterType);
				_ = mPPlayerItem._type;
				_ = -1;
				string text2 = obj3.ToString();
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				Enum obj4 = (Enum)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
				_ = typeof(MPPlayerItem.PlayerState);
				_ = mPPlayerItem._PlayerState;
				_ = -1;
				string text3 = obj4.ToString();
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				Rewired.Player player = mPPlayerItem.Player;
				if (player != null)
				{
					string text4 = player.ToString();
				}
				else
				{
					string text4 = null;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				string message = string.Concat(array);
				Debug.Log(message);
				if (!DoesSlotNeedCharacterChoice(num))
				{
					playerSlots = _playerSlots;
					num++;
					num2 = num;
					continue;
				}
				_multiplayer.SelectSlot(num);
				MultiplayerManager multiplayer = _multiplayer;
				object obj5 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 103));
				_ = multiplayer._selectedPlayerIndex;
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
				System.ParamsArray paramsArray = (System.ParamsArray)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
				_ = 0;
				_ = 0;
				System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)paramsArray, new System.ParamsArray(arg));
				System.ParamsArray args = (System.ParamsArray)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+7]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+17]");
				_ = 0;
				string text5 = string.FormatHelper((IFormatProvider)null, "<CharacterSelectionPage.GoToNextCharacterOrContinue> _selectedPlayerSlotIndex = {0} ", args);
				List<MPPlayerItem> playerSlots3 = _playerSlots;
				if (num < playerSlots3._size)
				{
					MPPlayerItem[] items2 = playerSlots3._items;
					Rewired.Player player2 = items2[num].Player;
					System.ParamsArray paramsArray2 = (System.ParamsArray)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
					_ = 0;
					_ = 0;
					System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)paramsArray2, new System.ParamsArray(player2));
					System.ParamsArray args2 = (System.ParamsArray)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 39));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-19]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-9]");
					_ = 0;
					string text6 = string.FormatHelper((IFormatProvider)null, "_playerSlots[playerToSelectIndex].Player : {0}", args2);
					string message2 = text5 + text6;
					Debug.Log(message2);
					List<MPPlayerItem> playerSlots4 = _playerSlots;
					if (num < playerSlots4._size)
					{
						MPPlayerItem[] items3 = playerSlots4._items;
						items3[num].GoToSelecting();
						ResetDisplay(playerLeftGame: false);
						goto IL_042f;
					}
				}
			}
			goto IL_0690;
			IL_042f:
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Rate = 1f;
			soundConfig.Detune = 200f;
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.ClickIn, soundConfig, 0f, 10, time);
			return;
			IL_047a:
			if (!_partyModeEnabled)
			{
				List<MPPlayerItem> playerSlots5 = _playerSlots;
				int num4 = 0;
				int num5 = 0;
				int num6 = 0;
				while (num6 < playerSlots5._size)
				{
					List<MPPlayerItem> playerSlots6 = _playerSlots;
					if (num5 >= playerSlots6._size)
					{
						goto IL_0690;
					}
					MPPlayerItem[] items4 = playerSlots6._items;
					MPPlayerItem mPPlayerItem2 = items4[num5];
					if (mPPlayerItem2._PlayerState != MPPlayerItem.PlayerState.LOCKED)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rax_v23+90]");
						if ((nint)0 != 4)
						{
							goto IL_0715;
						}
					}
					num4++;
					goto IL_0715;
					IL_0715:
					playerSlots5 = _playerSlots;
					num5++;
					bool flag = _playerSlots != null;
					num6 = num5;
					if (!flag)
					{
						goto end_IL_06f1;
					}
				}
				_ = 0;
			}
			else
			{
				_ = 0;
				_ = _partySize;
			}
			MultiplayerManager multiplayer2 = _multiplayer;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+67]");
			multiplayer2.PartySize = (int?)(object)0;
			_multiplayer.SelectPlayerOneToControlUI(exclusiveUIControl: true);
			MultiplayerManager multiplayer3 = _multiplayer;
			List<MPPlayerItem> playerSlots7 = _playerSlots;
			int selectedPlayerIndex = multiplayer3._selectedPlayerIndex;
			if (multiplayer3._selectedPlayerIndex < playerSlots7._size)
			{
				MPPlayerItem[] items5 = playerSlots7._items;
				MPPlayerItem mPPlayerItem3 = items5[selectedPlayerIndex];
				mPPlayerItem3._PlayerState = MPPlayerItem.PlayerState.LOCKED;
				CoopSlotData slotInfo = _multiplayer.GetSlotInfo(0);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9DAE0");
				goto IL_042f;
			}
			goto IL_0690;
			IL_0690:
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			break;
			continue;
			end_IL_06f1:
			break;
		}
		throw new NullReferenceException();
	}

	public void SetEggs(bool b)
	{
		PlayerOptionsData config = _playerOptions.Config;
		config._003CSelectedGoldenEggs_003Ek__BackingField = b;
		StatsPanel.SetValues();
	}

	public unsafe void SelectCharacter(bool fromUnlock)
	{
		//IL_012a: Expected O, but got Ref
		CharacterItemUI selectedCharacterItemUI = _selectedCharacterItemUI;
		Button button;
		if (_selectedCharacterItemUI.IsCharAvailable())
		{
			SkinItem currentSkinItem = selectedCharacterItemUI._charItem.GetCurrentSkinItem();
			if (currentSkinItem == null || currentSkinItem._unlockState == UIUnlockStates.AVAILABLE)
			{
				PlayerOptionsData config = _playerOptions.Config;
				CoopSlotData slotInfo = MultiplayerManager.s_instance.GetSlotInfo(0);
				config.SelectedCharacter = slotInfo.SelectedCharacter;
				GameObject gameObject = ConfirmButton.gameObject;
				gameObject.SetActive(value: false);
				GameObject gameObject2 = StartButton.gameObject;
				gameObject2.SetActive(value: true);
				if (!fromUnlock)
				{
					object obj = default(object);
					PanelBackground.color = (Color)(&obj);
				}
				_selectedCharacterItemUI.SetSelected();
				SelectableUI component = ConfirmButton.GetComponent<SelectableUI>();
				component.IsDefaultSelectedOnPage = false;
				UpdateNavigationOnCharSelected();
				SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
				soundConfig.Rate = 1f;
				soundConfig.Detune = 100f;
				float time = default(float);
				PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.ClickIn, soundConfig, 0f, 10, time);
				button = StartButton;
				_characterConfirmed = true;
				goto IL_01df;
			}
		}
		button = BuyButton;
		goto IL_01df;
		IL_01df:
		button.Select();
	}

	public unsafe void BuyCharacter()
	{
		//IL_00d9: Invalid comparison between I4 and F4
		//IL_02e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e5: Expected O, but got Unknown
		//IL_04fb: Expected I4, but got F4
		//IL_04fb: Expected O, but got I
		//IL_03c1: Expected O, but got Ref
		//IL_022b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0230: Expected O, but got Unknown
		//IL_04d1: Expected I4, but got F4
		//IL_04d1: Expected O, but got I
		int playerCount = _multiplayer.GetPlayerCount();
		if (playerCount > 1 || _multiplayer.IsOnlineMultiplayer)
		{
			Rewired.Player selectedPlayer = _multiplayer.GetSelectedPlayer();
			if (selectedPlayer.id != 0)
			{
				return;
			}
		}
		float price = _selectedCharacterItemUI.GetPrice();
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si r15d,xmm0\"");
		PlayerOptionsData config = _playerOptions.Config;
		int num = default(int);
		if ((float)num > config._003CCoins_003Ek__BackingField)
		{
			return;
		}
		GameObject gameObject = BuyButton.gameObject;
		gameObject.SetActive(value: false);
		GameObject gameObject2 = Price.gameObject;
		gameObject2.SetActive(value: false);
		CharacterItemUI selectedCharacterItemUI = _selectedCharacterItemUI;
		CharacterItem charItem = selectedCharacterItemUI._charItem;
		bool flag = charItem._unlockState == UIUnlockStates.PURCHASABLE;
		CharacterItemUI selectedCharacterItemUI2 = _selectedCharacterItemUI;
		float num3 = default(float);
		SkinType skinType = default(SkinType);
		if (!flag)
		{
			CharacterItem charItem2 = selectedCharacterItemUI2._charItem;
			if (charItem2._unlockState == UIUnlockStates.AVAILABLE)
			{
				SkinItem currentSkinItem = charItem2.GetCurrentSkinItem();
				if (currentSkinItem != null && currentSkinItem._unlockState == UIUnlockStates.PURCHASABLE)
				{
					nint num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
					object obj2 = default(object);
					object obj = obj2 + 32;
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
					IntPtr intPtr = default(IntPtr);
					num2 = intPtr;
					object signal = (nint)skinType;
					_signalBus.InternalFire((Type)num2, signal, (object)null, (byte)(int)num3 != 0);
					PlayerOptionsData config2 = _playerOptions.Config;
					CharacterData currentData = _currentData;
					bool flag2 = ((Dictionary<System.Int32Enum, System.Int32Enum>)(object)config2._003CSelectedSkinsV2_003Ek__BackingField).TryInsert((System.Int32Enum)_currentType, (System.Int32Enum)currentData._003CcurrentSkin_003Ek__BackingField, System.Collections.Generic.InsertionBehavior.OverwriteExisting);
					skinType = currentSkinItem._skinType;
				}
			}
		}
		else
		{
			CharacterItem charItem3 = selectedCharacterItemUI2._charItem;
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj4 = default(object);
			object obj3 = obj4 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			IntPtr intPtr2 = default(IntPtr);
			num4 = intPtr2;
			object signal2 = (nint)skinType;
			_signalBus.InternalFire((Type)num4, signal2, (object)null, (byte)(int)num3 != 0);
			skinType = (SkinType)charItem3._characterType;
		}
		_playerOptions.RemoveCoins(num, removeFromLifetime: true);
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Detune = -400f;
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.ClickOut, soundConfig, 0f, 10, num3);
		_selectedCharacterItemUI.Refresh();
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		int num5 = default(int);
		object arg = (CharacterType)num5;
		object arg2 = default(object);
		System.ParamsArray paramsArray = new System.ParamsArray(arg2, arg);
		object obj5 = default(object);
		string message = string.FormatHelper((IFormatProvider)null, "<CharacterSelectionPage.BuyCharacter> set the multiplayer selection for _selectedPlayerSlotIndex: {0} to {1}", (System.ParamsArray)(&obj5));
		Debug.Log(message);
		MultiplayerManager multiplayer = _multiplayer;
		List<MPPlayerItem> playerSlots = _playerSlots;
		int selectedPlayerIndex = multiplayer._selectedPlayerIndex;
		if (multiplayer._selectedPlayerIndex < playerSlots._size)
		{
			MPPlayerItem[] items = playerSlots._items;
			items[selectedPlayerIndex].RefreshData();
			EventSystem current = EventSystem.current;
			GameObject selectedGameObject = _selectedCharacterItemUI.gameObject;
			current.SetSelectedGameObject(selectedGameObject);
			_characterBoughtThisFrame = true;
		}
		else
		{
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}

	public unsafe void IncreaseMaxWeapons()
	{
		//IL_006d: Expected O, but got Ref
		PlayerOptionsData config = _playerOptions.Config;
		int num = config._003CSelectedMaxWeapons_003Ek__BackingField + 1;
		bool flag = num > 6;
		int num2 = 1;
		if (!flag)
		{
			num2 = num;
		}
		object obj = default(object);
		string text = System.Number.FormatInt32(num2, (ReadOnlySpan<char>)(&obj), null);
		_MaxWeaponsText.text = text;
		PlayerOptionsData config2 = _playerOptions.Config;
		config2._003CSelectedMaxWeapons_003Ek__BackingField = num2;
	}

	private GameObject GetBonusButton()
	{
		//IL_0122: Expected O, but got I4
		//IL_00ca->IL00eb: Incompatible stack heights: 1 vs 0
		//IL_006f->IL00eb: Incompatible stack heights: 1 vs 0
		if ((object)_EnterCoopButton != null)
		{
			GameObject gameObject = _EnterCoopButton.gameObject;
			if ((object)gameObject != null)
			{
				bool flag = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
				object obj = GameObject.get_activeInHierarchy_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
				GameObject result;
				if (obj == null)
				{
					if ((object)_SwitchReassignControllersButton == null)
					{
						goto IL_00eb;
					}
					bool activeInHierarchy = _SwitchReassignControllersButton.activeInHierarchy;
					bool flag2 = !activeInHierarchy;
					result = null;
					if (!flag2)
					{
						result = _SwitchReassignControllersButton;
					}
				}
				else
				{
					if ((object)_EnterCoopButton == null)
					{
						goto IL_00eb;
					}
					GameObject gameObject2 = _EnterCoopButton.gameObject;
					result = gameObject2;
				}
				return result;
			}
		}
		goto IL_00eb;
		IL_00eb:
		throw new NullReferenceException();
	}

	private unsafe void WrapNavigation()
	{
		//IL_0018: Expected O, but got I4
		//IL_0061: Expected O, but got I4
		//IL_015b: Expected O, but got I4
		//IL_016e: Expected O, but got I4
		//IL_01b7: Expected O, but got I4
		//IL_0206: Expected O, but got I4
		//IL_02b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b5: Expected O, but got Unknown
		//IL_02be: Invalid comparison between F4 and O
		//IL_0303: Expected O, but got Ref
		//IL_0345: Unknown result type (might be due to invalid IL or missing references)
		//IL_034a: Expected O, but got Unknown
		//IL_0362: Expected O, but got I4
		List<GameObject> spawned = _spawned;
		object obj = spawned._size - 1;
		if ((nint)obj < spawned._size)
		{
			GameObject[] items = spawned._items;
			object obj2 = spawned._size - 1;
			Selectable component = items[obj2].GetComponent<Selectable>();
			List<GameObject> spawned2 = _spawned;
			if (spawned2._size > 0)
			{
				GameObject[] items2 = spawned2._items;
				Selectable component2 = items2[0].GetComponent<Selectable>();
				EnterCoopButton enterCoopButton = _EnterCoopButton;
				Selectable component3 = enterCoopButton._button.GetComponent<Selectable>();
				Selectable right = default(Selectable);
				ForceBackButtonNavigation(component, component2, null, right);
				Selectable component4 = BackButtonController.Instance.GetComponent<Selectable>();
				LayoutRebuilder.ForceRebuildLayoutImmediate(_content);
				Canvas.ForceUpdateCanvases();
				List<GameObject> spawned3 = _spawned;
				Selectable selectable = (Selectable)spawned3._size;
				object obj3 = spawned3._size - 1;
				if ((nint)obj3 < spawned3._size)
				{
					GameObject[] items3 = spawned3._items;
					object obj4 = spawned3._size - 1;
					RectTransform component5 = items3[obj4].GetComponent<RectTransform>();
					Vector2 anchoredPosition = component5.anchoredPosition;
					List<GameObject> spawned4 = _spawned;
					object obj5 = spawned4._size - 1;
					if ((nint)obj5 <= 0)
					{
						return;
					}
					Selectable selectable2 = null;
					object obj7 = default(object);
					GameObject gameObject = default(GameObject);
					object obj9 = default(object);
					while (true)
					{
						List<GameObject> spawned5 = _spawned;
						if ((nint)obj5 >= spawned5._size)
						{
							break;
						}
						GameObject[] items4 = spawned5._items;
						RectTransform component6 = items4[obj5].GetComponent<RectTransform>();
						Vector2 anchoredPosition2 = component6.anchoredPosition;
						object obj6 = obj7 - obj7;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
						object obj8 = obj6 & 0;
						if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj8))
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
							Selectable component7 = gameObject.GetComponent<Selectable>();
							component7.navigation = (Navigation)(&obj9);
							SetNavigationDown(component7, component4);
							SetNavigationRight(component7);
							SetNavigationLeft(component7);
							SetNavigationUp(component7);
							obj5--;
							bool flag = (nint)obj5 > 0;
							obj9 = 4;
							selectable2 = null;
							selectable = null;
							if (!flag)
							{
								return;
							}
							continue;
						}
						return;
					}
				}
			}
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	private bool HasCharUnlock(string characterToUnlock, List<CharacterType> charactersToUnlock = null)
	{
		//IL_012a: Expected I4, but got O
		if ((object)_selectedCharacterItemUI != null)
		{
			if (_selectedCharacterItemUI.IsCharUnlockable())
			{
				if (characterToUnlock != null && characterToUnlock._stringLength > 0 && Enum.TryParse<CharacterType>(characterToUnlock, ignoreCase: false, out var result) && result == _currentType)
				{
					goto IL_0110;
				}
				if (charactersToUnlock != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [charactersToUnlock @ r8 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
					if ((nint)0 > (nint)0)
					{
						goto IL_0110;
					}
				}
			}
			return false;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_0110:
		return true;
	}

	private bool HasSkinUnlock(List<SkinToUnlock> skinsToUnlock = null)
	{
		CharacterItemUI selectedCharacterItemUI = _selectedCharacterItemUI;
		if ((object)_selectedCharacterItemUI != null)
		{
			CharacterItem charItem = selectedCharacterItemUI._charItem;
			if (selectedCharacterItemUI._charItem != null)
			{
				SkinItem currentSkinItem = selectedCharacterItemUI._charItem.GetCurrentSkinItem();
				List<SkinToUnlock>.Enumerator enumerator = default(List<SkinToUnlock>.Enumerator);
				if (currentSkinItem != null && currentSkinItem._unlockState == UIUnlockStates.UNLOCKABLE && skinsToUnlock != null && skinsToUnlock._size > 0 && enumerator.MoveNext())
				{
					CharacterItem characterItem = null;
					charItem = null;
					throw new NullReferenceException();
				}
				return false;
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void SetVisualStateUnlockable()
	{
		//IL_00c5: Expected O, but got Ref
		//IL_00f7: Expected O, but got Ref
		//IL_011a: Expected O, but got Ref
		//IL_013d: Expected O, but got Ref
		//IL_0160: Expected O, but got Ref
		GameObject gameObject = ConfirmButton.gameObject;
		gameObject.SetActive(value: false);
		GameObject gameObject2 = _LockIcon.gameObject;
		gameObject2.SetActive(value: true);
		GameObject gameObject3 = Price.gameObject;
		gameObject3.SetActive(value: false);
		GameObject gameObject4 = BuyButton.gameObject;
		gameObject4.SetActive(value: false);
		_WeaponFrame.SetActive(value: false);
		object obj = default(object);
		Icon.color = (Color)(&obj);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186C0B200");
		Color color = WeaponIcon.color;
		WeaponIcon.color = (Color)(&obj);
		Color color2 = Icon.color;
		Icon.color = (Color)(&obj);
		Color color3 = _Name.color;
		_Name.color = (Color)(&obj);
		Color color4 = _LockIcon.color;
		_LockIcon.color = (Color)(&obj);
	}

	private unsafe void SetVisualStatePurchasable()
	{
		//IL_02d3: Expected O, but got Ref
		//IL_02e7: Expected O, but got Ref
		//IL_030a: Expected O, but got Ref
		//IL_032d: Expected O, but got Ref
		GameObject gameObject = Price.gameObject;
		gameObject.SetActive(value: true);
		float price = _selectedCharacterItemUI.GetPrice();
		Price.SetPrice(price);
		GameObject gameObject2 = BuyButton.gameObject;
		int playerCount = _multiplayer.GetPlayerCount();
		bool active;
		if (playerCount <= 1 && !_multiplayer.IsOnlineMultiplayer)
		{
			active = true;
		}
		else
		{
			MultiplayerManager multiplayer = _multiplayer;
			int num = multiplayer._selectedPlayerIndex ^ multiplayer._selectedPlayerIndex;
			int num2 = multiplayer._selectedPlayerIndex & num;
			bool flag = num2 < 0;
			bool flag2 = multiplayer._selectedPlayerIndex < 0;
			bool flag3 = multiplayer._selectedPlayerIndex == 0;
			bool flag4 = flag2 != flag;
			active = flag4 | flag3;
		}
		gameObject2.SetActive(active);
		bool applyParameters = default(bool);
		GameObject localParametersRoot = default(GameObject);
		string overrideLanguage = default(string);
		bool allowLocalizedParameters = default(bool);
		string translation = LocalizationManager.GetTranslation("lang/charConfirm_unlock", FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
		_buyButtonLabel.text = translation;
		CharacterItemUI selectedCharacterItemUI = _selectedCharacterItemUI;
		SkinItem currentSkinItem = selectedCharacterItemUI._charItem.GetCurrentSkinItem();
		if (currentSkinItem != null && currentSkinItem._unlockState == UIUnlockStates.PURCHASABLE)
		{
			string translation2 = LocalizationManager.GetTranslation("lang/charConfirm_buy_skin", FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
			_buyButtonLabel.text = translation2;
		}
		GameObject gameObject3 = ConfirmButton.gameObject;
		gameObject3.SetActive(value: false);
		GameObject gameObject4 = _LockIcon.gameObject;
		gameObject4.SetActive(value: false);
		_WeaponFrame.SetActive(value: true);
		Color color = WeaponIcon.color;
		object obj = default(object);
		WeaponIcon.color = (Color)(&obj);
		Icon.color = (Color)(&obj);
		Color color2 = Icon.color;
		Icon.color = (Color)(&obj);
		Color color3 = _Name.color;
		_Name.color = (Color)(&obj);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186C0B200");
	}

	private unsafe void SetVisualStateAvailable()
	{
		//IL_00d4: Expected O, but got Ref
		//IL_00e8: Expected O, but got Ref
		//IL_010b: Expected O, but got Ref
		//IL_012e: Expected O, but got Ref
		GameObject gameObject = ConfirmButton.gameObject;
		gameObject.SetActive(value: true);
		GameObject gameObject2 = Price.gameObject;
		gameObject2.SetActive(value: false);
		GameObject gameObject3 = BuyButton.gameObject;
		gameObject3.SetActive(value: false);
		GameObject gameObject4 = _LockIcon.gameObject;
		gameObject4.SetActive(value: false);
		_WeaponFrame.SetActive(value: true);
		Color color = WeaponIcon.color;
		object obj = default(object);
		WeaponIcon.color = (Color)(&obj);
		Icon.color = (Color)(&obj);
		Color color2 = Icon.color;
		Icon.color = (Color)(&obj);
		Color color3 = _Name.color;
		_Name.color = (Color)(&obj);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186C0B200");
	}

	public void ShowCharacterInfo(CharacterData charData, CharacterType cType, CharacterItemUI character)
	{
		//IL_00e3: Expected O, but got I
		//IL_00f5: Expected O, but got I4
		//IL_0399: Expected O, but got I
		//IL_03ab: Expected O, but got I4
		CharacterItemUI selectedCharacterItemUI = _selectedCharacterItemUI;
		if ((object)_selectedCharacterItemUI != null && ((UnityEngine.Object)selectedCharacterItemUI).m_CachedPtr != (IntPtr)0)
		{
			CharacterItemUI selectedCharacterItemUI2 = _selectedCharacterItemUI;
			CharacterItem charItem = selectedCharacterItemUI2._charItem;
			if (charItem._characterType != cType)
			{
				PlayerOptionsData config = _playerOptions.Config;
				Dictionary<CharacterType, SkinType> dictionary = config._003CSelectedSkinsV2_003Ek__BackingField;
				int num = config._003CSelectedSkinsV2_003Ek__BackingField.FindEntry(_currentType);
				if (num >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v364 @ rdi_v14 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.CharacterType, VampireSurvivors.Data.SkinType>)+18]");
					object obj = 0;
					object obj2 = num + num;
					CharacterData currentData = _currentData;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v458 @ rcx_v90+2C+v1273 @ rax_v101*8]");
					currentData._003CcurrentSkin_003Ek__BackingField = SkinType.DEFAULT;
				}
				_selectedCharacterItemUI.Refresh(setInfoPanel: false);
			}
			_selectedCharacterItemUI.UnSelect();
		}
		_currentData = charData;
		_currentType = cType;
		_selectedCharacterItemUI = character;
		MultiplayerManager multiplayer = _multiplayer;
		List<MPPlayerItem> playerSlots = _playerSlots;
		int selectedPlayerIndex = multiplayer._selectedPlayerIndex;
		if (multiplayer._selectedPlayerIndex < playerSlots._size)
		{
			MPPlayerItem[] items = playerSlots._items;
			MPPlayerItem mPPlayerItem = items[selectedPlayerIndex];
			if (mPPlayerItem._PlayerState == MPPlayerItem.PlayerState.LOCKED)
			{
				goto IL_03d4;
			}
			MultiplayerManager multiplayer2 = _multiplayer;
			CoopSlotData slotInfo = MultiplayerManager.s_instance.GetSlotInfo(multiplayer2._selectedPlayerIndex);
			slotInfo.SelectedCharacter = _currentType;
			MultiplayerManager multiplayer3 = _multiplayer;
			List<MPPlayerItem> playerSlots2 = _playerSlots;
			int selectedPlayerIndex2 = multiplayer3._selectedPlayerIndex;
			if (multiplayer3._selectedPlayerIndex < playerSlots2._size)
			{
				MPPlayerItem[] items2 = playerSlots2._items;
				items2[selectedPlayerIndex2].RefreshData();
				MultiplayerManager multiplayer4 = _multiplayer;
				List<MPPlayerItem> playerSlots3 = _playerSlots;
				int selectedPlayerIndex3 = multiplayer4._selectedPlayerIndex;
				if (multiplayer4._selectedPlayerIndex < playerSlots3._size)
				{
					MPPlayerItem[] items3 = playerSlots3._items;
					items3[selectedPlayerIndex3].SetData();
					if (cType != _currentType)
					{
						PlayerOptionsData config2 = _playerOptions.Config;
						Dictionary<CharacterType, SkinType> dictionary2 = config2._003CSelectedSkinsV2_003Ek__BackingField;
						int num2 = config2._003CSelectedSkinsV2_003Ek__BackingField.FindEntry(_currentType);
						if (num2 >= 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v365 @ rdi_v12 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.CharacterType, VampireSurvivors.Data.SkinType>)+18]");
							object obj3 = 0;
							object obj4 = num2 + num2;
							CharacterData currentData2 = _currentData;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v469 @ rcx_v73+2C+v1306 @ rax_v75*8]");
							currentData2._003CcurrentSkin_003Ek__BackingField = SkinType.DEFAULT;
						}
					}
					goto IL_03d4;
				}
			}
		}
		goto IL_078e;
		IL_078e:
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		throw new NullReferenceException();
		IL_03d4:
		Icon.enabled = true;
		_Name.enabled = true;
		Description.enabled = true;
		_WeaponFrame.SetActive(value: true);
		GameObject gameObject = _LockIcon.gameObject;
		gameObject.SetActive(value: false);
		GameObject gameObject2 = StartButton.gameObject;
		gameObject2.SetActive(value: false);
		GameObject gameObject3 = ConfirmButton.gameObject;
		gameObject3.SetActive(value: false);
		GameObject gameObject4 = BuyButton.gameObject;
		gameObject4.SetActive(value: false);
		_characterConfirmed = false;
		SetWeaponIconSprite(charData);
		Sprite sprite = ((!_selectedCharacterItemUI.IsUnlockableAndSecret()) ? _selectedCharacterItemUI.GetCharSprite(cType, charData) : SpriteManager.GetSprite("QuestionMark", "UI"));
		Icon.sprite = sprite;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A30E2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		TextMeshProUGUI textMeshProUGUI = _Name;
		string text = ((!_selectedCharacterItemUI.IsUnlockableAndSecret()) ? charData.GetFullName(cType, ignoreSkinPrefixSuffix: false, splitDualCharacterNames: false) : "???");
		_Name.text = text;
		string text2 = _Name.text;
		if (text2 == null || text2._stringLength <= 0 || cType == CharacterType.ARENGIJUS || cType == CharacterType.EXDASH)
		{
			string fullNameUntranslated = charData.GetFullNameUntranslated();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18634B7A0");
		}
		string description = charData.GetDescription(cType);
		SetCharPanelDescription(description);
		UpdateStatsPanelVisibility();
		StatsPanel.SetCharacter(charData, cType);
		SetSkinSlots();
		_StageCompletionPanel.SetPanel(cType);
		UpdateEggCount();
		SetIconSizes();
		SetPanelVisualState();
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 1320 Invalid \"Jump target not found in method: 0x186C8ECA0\"");
		goto IL_078e;
	}

	private void SetPanelVisualState()
	{
		int playerCount = _multiplayer.GetPlayerCount();
		if (playerCount > 1 || _multiplayer.IsOnlineMultiplayer)
		{
			CharacterItemUI selectedCharacterItemUI = _selectedCharacterItemUI;
			if (selectedCharacterItemUI._isTaken)
			{
				SetVisualStateAvailable();
				GameObject gameObject = ConfirmButton.gameObject;
				gameObject.SetActive(value: false);
				return;
			}
		}
		if (!_selectedCharacterItemUI.IsCharUnlockable())
		{
			if (!_selectedCharacterItemUI.IsCharPurchasable())
			{
				CharacterItemUI selectedCharacterItemUI2 = _selectedCharacterItemUI;
				SkinItem currentSkinItem = selectedCharacterItemUI2._charItem.GetCurrentSkinItem();
				if (currentSkinItem != null && currentSkinItem._unlockState == UIUnlockStates.UNLOCKABLE)
				{
					goto IL_01bd;
				}
				CharacterItemUI selectedCharacterItemUI3 = _selectedCharacterItemUI;
				SkinItem currentSkinItem2 = selectedCharacterItemUI3._charItem.GetCurrentSkinItem();
				if (currentSkinItem2 == null || currentSkinItem2._unlockState != UIUnlockStates.PURCHASABLE)
				{
					if (_selectedCharacterItemUI.IsAvailable())
					{
						SetVisualStateAvailable();
					}
					return;
				}
			}
			SetVisualStatePurchasable();
			return;
		}
		goto IL_01bd;
		IL_01bd:
		SetVisualStateUnlockable();
		SetUnlockableDescription();
	}

	private void UpdateNavigationOnCharSelected()
	{
		//IL_048e: Expected O, but got I4
		//IL_04de: Expected O, but got I4
		//IL_052b: Expected O, but got I4
		//IL_0578: Expected O, but got I4
		//IL_01bb->IL0438: Incompatible stack heights: 1 vs 0
		//IL_016b->IL0438: Incompatible stack heights: 1 vs 0
		//IL_0234->IL0438: Incompatible stack heights: 2 vs 0
		//IL_01e4->IL0438: Incompatible stack heights: 2 vs 0
		//IL_02a2->IL0438: Incompatible stack heights: 3 vs 0
		//IL_025d->IL0438: Incompatible stack heights: 3 vs 0
		//IL_02ce->IL0438: Incompatible stack heights: 3 vs 0
		//IL_03da->IL0438: Incompatible stack heights: 4 vs 0
		//IL_02f7->IL0438: Incompatible stack heights: 4 vs 0
		//IL_0408->IL0438: Incompatible stack heights: 4 vs 0
		//IL_0371->IL0438: Incompatible stack heights: 4 vs 0
		//IL_0333->IL0438: Incompatible stack heights: 4 vs 0
		//IL_039f->IL0438: Incompatible stack heights: 4 vs 0
		Selectable component11;
		Selectable origin;
		if ((object)_selectedCharacterItemUI != null)
		{
			Button component = _selectedCharacterItemUI.GetComponent<Button>();
			SetNavigationUp(StartButton, component);
			if ((object)_selectedCharacterItemUI != null)
			{
				Button component2 = _selectedCharacterItemUI.GetComponent<Button>();
				SetNavigationUp(BuyButton, component2);
				if ((object)_selectedCharacterItemUI != null)
				{
					Button component3 = _selectedCharacterItemUI.GetComponent<Button>();
					SetNavigationUp(ConfirmButton, component3);
					if ((object)Icon != null)
					{
						Button component4 = Icon.GetComponent<Button>();
						if ((object)_selectedCharacterItemUI != null)
						{
							Button component5 = _selectedCharacterItemUI.GetComponent<Button>();
							SetNavigationUp(component4, component5);
							Selectable startButton = StartButton;
							if ((object)StartButton != null)
							{
								bool flag = ((UnityEngine.Object)startButton).m_CachedPtr == (IntPtr)0;
								object obj = Behaviour.get_isActiveAndEnabled_Injected(((UnityEngine.Object)startButton).m_CachedPtr);
								if (obj != null)
								{
									if ((object)Icon == null)
									{
										goto IL_0438;
									}
									Button component6 = Icon.GetComponent<Button>();
									SetNavigationRight(component6, StartButton);
								}
								Selectable buyButton = BuyButton;
								if ((object)BuyButton != null)
								{
									bool flag2 = ((UnityEngine.Object)buyButton).m_CachedPtr == (IntPtr)0;
									object obj2 = Behaviour.get_isActiveAndEnabled_Injected(((UnityEngine.Object)buyButton).m_CachedPtr);
									if (obj2 != null)
									{
										if ((object)Icon == null)
										{
											goto IL_0438;
										}
										Button component7 = Icon.GetComponent<Button>();
										SetNavigationRight(component7, BuyButton);
									}
									Selectable confirmButton = ConfirmButton;
									if ((object)ConfirmButton != null)
									{
										bool flag3 = ((UnityEngine.Object)confirmButton).m_CachedPtr == (IntPtr)0;
										object obj3 = Behaviour.get_isActiveAndEnabled_Injected(((UnityEngine.Object)confirmButton).m_CachedPtr);
										if (obj3 != null)
										{
											if ((object)Icon == null)
											{
												goto IL_0438;
											}
											Button component8 = Icon.GetComponent<Button>();
											SetNavigationRight(component8, ConfirmButton);
										}
										if ((object)_EggBox != null)
										{
											GameObject gameObject = _EggBox.gameObject;
											if ((object)gameObject != null)
											{
												bool flag4 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
												object obj4 = GameObject.get_activeInHierarchy_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
												if (obj4 == null)
												{
													if ((object)_EggWeaponBox != null)
													{
														if (!_EggWeaponBox.activeInHierarchy)
														{
															if ((object)Icon != null)
															{
																Button component9 = Icon.GetComponent<Button>();
																ClearNavigationLeft(component9);
																return;
															}
														}
														else if ((object)Icon != null)
														{
															Button component10 = Icon.GetComponent<Button>();
															if ((object)_EggWeaponBox != null)
															{
																component11 = _EggWeaponBox.GetComponent<Selectable>();
																origin = component10;
																goto IL_0429;
															}
														}
													}
												}
												else if ((object)Icon != null)
												{
													Button component12 = Icon.GetComponent<Button>();
													if ((object)_EggBox != null)
													{
														component11 = _EggBox.GetComponent<Selectable>();
														origin = component12;
														goto IL_0429;
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
		goto IL_0438;
		IL_0429:
		SetNavigationLeft(origin, component11);
		return;
		IL_0438:
		throw new NullReferenceException();
	}

	private unsafe void UpdateEggCount()
	{
		//IL_00b1: Expected O, but got Ref
		//IL_00f0: Expected O, but got I4
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Expected I4, but got Unknown
		PlayerOptionsData config = _playerOptions.Config;
		int num = ((Dictionary<System.Int32Enum, object>)(object)config._003CCharacterEggInfo_003Ek__BackingField).FindEntry((System.Int32Enum)_currentType);
		if (num >= 0)
		{
			PlayerOptionsData config2 = _playerOptions.Config;
			int num2 = ((Dictionary<CharacterType, Dictionary<string, float>>)(object)config2._003CCharacterEggCount_003Ek__BackingField).FindEntry(_currentType);
			float eggCount = default(float);
			string formattedEggCount = EggManager.GetFormattedEggCount(eggCount);
		}
		else
		{
			if ("F0" != null)
			{
			}
			object obj = default(object);
			string formattedEggCount = System.Number.FormatInt32(0, (ReadOnlySpan<char>)(&obj), null);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18634B7A0");
		string text = _EggCount.text;
		object obj2 = text._stringLength - 7;
		int num3 = text._stringLength ^ 7;
		int num4 = text._stringLength ^ obj2;
		int num5 = num3 & num4;
		bool flag = num5 < 0;
		bool flag2 = (nint)obj2 < 0;
		bool flag3 = obj2 == null;
		bool flag4 = flag2 != flag;
		bool flag5 = flag4 | flag3;
		_EggCountTitle.enabled = flag5;
	}

	private void SetCharPanelDescription(string descText, bool isHidden = false, bool isSecret = false)
	{
		//IL_003f: Expected O, but got I4
		//IL_0059: Expected O, but got I4
		bool applyParameters = default(bool);
		GameObject localParametersRoot = default(GameObject);
		string overrideLanguage = default(string);
		bool allowLocalizedParameters = default(bool);
		string translation = LocalizationManager.GetTranslation("lang/charConfirm_unlockCondition", FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
		object obj = isSecret & isHidden;
		bool flag = obj == null;
		object obj2 = !flag;
		if (obj2 == null)
		{
			if (!isHidden)
			{
				Description.text = descText;
				return;
			}
			string text = translation + " " + descText;
			Description.text = text;
		}
		else
		{
			string text2 = translation + " ???";
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18634B7A0");
		}
	}

	private unsafe void SetUnlockableDescription()
	{
		//IL_0018: Expected I, but got O
		//IL_0214: Expected O, but got I4
		//IL_022c: Expected O, but got I4
		//IL_0235: Expected O, but got I4
		//IL_0323: Expected I, but got O
		//IL_00ce: Expected O, but got I4
		//IL_0359: Expected I, but got O
		//IL_0600: Expected I, but got O
		//IL_0393: Expected I, but got O
		nint num = (nint)typeof(AdventureManager);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ rax_v6 (Il2CppClass<VampireSurvivors.App.Scripts.Framework.Adventures.AdventureManager>)+B8]");
		nint num2 = 0;
		if (AdventureManager._003CIsInAdventureMode_003Ek__BackingField)
		{
			AdventureManager adventureManager = _adventureManager;
			if (_adventureManager != null)
			{
				AdventureData adventureData = adventureManager._003CAdventureData_003Ek__BackingField;
				if (adventureManager._003CAdventureData_003Ek__BackingField != null && adventureData._003CProgressData_003Ek__BackingField != null)
				{
					List<AchievementData>.Enumerator enumerator = default(List<AchievementData>.Enumerator);
					while (enumerator.MoveNext())
					{
						object obj = 0;
					}
					num2 = (nint)(&enumerator);
					goto IL_0594;
				}
			}
			goto IL_0538;
		}
		goto IL_0594;
		IL_0538:
		throw new NullReferenceException();
		IL_051d:
		SetCharPanelDescription("???", isHidden: true);
		return;
		IL_0594:
		DataManager dataManager = _dataManager;
		if (_dataManager != null && dataManager._003CAllAchievements_003Ek__BackingField != null)
		{
			object obj2 = 2;
			Dictionary<AchievementType, AchievementData>.Enumerator enumerator2 = default(Dictionary<AchievementType, AchievementData>.Enumerator);
			while (enumerator2.MoveNext())
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
				object obj3 = 0;
				obj2 = 0;
			}
			bool flag = _playerOptions == null;
			num2 = (nint)_playerOptions;
			if (!flag)
			{
				PlayerOptionsData config = _playerOptions.Config;
				bool flag2 = config == null;
				num2 = (nint)_playerOptions;
				if (!flag2)
				{
					num2 = (nint)config._003CCollectedItems_003Ek__BackingField;
					if (config._003CCollectedItems_003Ek__BackingField != null)
					{
						if ((object)AdventureManager.MarkerInitDataManager != null)
						{
							num2 = (nint)AdventureManager.MarkerInitAdventure;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
							object obj4 = default(object);
							if ((nint)obj4 != -1)
							{
								DataManager dataManager2 = _dataManager;
								if (_dataManager != null && dataManager2._003CAllSecrets_003Ek__BackingField != null)
								{
									Dictionary<SecretType, SecretData>.Enumerator enumerator3 = default(Dictionary<SecretType, SecretData>.Enumerator);
									while (enumerator3.MoveNext())
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
										SecretData secretData = null;
									}
									goto IL_051d;
								}
								goto IL_0538;
							}
						}
						SetCharPanelDescription("", isHidden: true, isSecret: true);
						goto IL_051d;
					}
				}
			}
		}
		goto IL_0538;
	}

	private void SetIconSizes()
	{
		//IL_00e6: Expected O, but got I
		//IL_023d: Expected O, but got I
		//IL_0125: Expected O, but got I
		//IL_027c: Expected O, but got I
		//IL_048b->IL03bb: Incompatible stack heights: 1 vs 0
		//IL_0145->IL03bb: Incompatible stack heights: 1 vs 0
		//IL_061f->IL03bb: Incompatible stack heights: 1 vs 0
		//IL_0566->IL03bb: Incompatible stack heights: 1 vs 0
		//IL_029c->IL03bb: Incompatible stack heights: 1 vs 0
		//IL_04e0->IL03bb: Incompatible stack heights: 2 vs 0
		//IL_0672->IL03bb: Incompatible stack heights: 2 vs 0
		//IL_0167->IL0167: Incompatible stack heights: 2 vs 0
		//IL_05ba->IL03bb: Incompatible stack heights: 2 vs 0
		//IL_02be->IL02be: Incompatible stack heights: 2 vs 0
		Image icon = Icon;
		Rect ret;
		Rect ret2;
		Vector2 sizeDelta = default(Vector2);
		if ((object)Icon != null)
		{
			object sprite = icon.m_Sprite;
			if ((object)icon.m_Sprite != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ rdi_v14 (System.Object)+10]");
				if ((nint)0 != 0)
				{
					if ((object)_selectedCharacterItemUI != null)
					{
						if (_selectedCharacterItemUI.IsUnlockableAndSecret())
						{
						}
						if ((object)Icon != null)
						{
							RectTransform rectTransform = Icon.rectTransform;
							object icon2 = Icon;
							if ((object)Icon != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ rdi_v25 (System.Object)+E0]");
								object obj = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ rdi_v25 (System.Object)+E0]");
								if ((nint)0 != 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ rdi_v26 (System.Object)+10]");
									bool flag = (nint)0 == 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ rdi_v26 (System.Object)+10]");
									Sprite.get_rect_Injected((IntPtr)0, out ret);
									object icon3 = Icon;
									if ((object)Icon != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v170 @ rdi_v27 (System.Object)+E0]");
										object obj2 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v170 @ rdi_v27 (System.Object)+E0]");
										if ((nint)0 != 0)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ rdi_v28 (System.Object)+10]");
											bool flag2 = (nint)0 == 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ rdi_v28 (System.Object)+10]");
											Sprite.get_rect_Injected((IntPtr)0, out ret2);
											if ((object)rectTransform != null)
											{
												rectTransform.sizeDelta = sizeDelta;
												goto IL_0167;
											}
										}
									}
								}
							}
						}
					}
					goto IL_03bb;
				}
			}
			goto IL_0167;
		}
		goto IL_03bb;
		IL_03bb:
		throw new NullReferenceException();
		IL_02be:
		if ((object)WeaponIcon != null)
		{
			Transform transform = WeaponIcon.transform;
			if ((object)transform != null)
			{
				Transform parent = transform.parent;
				if ((object)parent != null)
				{
					Image component = parent.GetComponent<Image>();
					if ((object)component != null)
					{
						RectTransform rectTransform2 = component.rectTransform;
						object sprite2 = component.m_Sprite;
						if ((object)component.m_Sprite != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v169 @ rdi_v18 (System.Object)+10]");
							bool flag3 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v169 @ rdi_v18 (System.Object)+10]");
							Sprite.get_rect_Injected((IntPtr)0, out ret2);
							object sprite3 = component.m_Sprite;
							if ((object)component.m_Sprite != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ rdi_v19 (System.Object)+10]");
								bool flag4 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ rdi_v19 (System.Object)+10]");
								Sprite.get_rect_Injected((IntPtr)0, out ret);
								if ((object)rectTransform2 != null)
								{
									rectTransform2.sizeDelta = sizeDelta;
									return;
								}
							}
						}
					}
				}
			}
		}
		goto IL_03bb;
		IL_0167:
		Image weaponIcon = WeaponIcon;
		if ((object)WeaponIcon != null)
		{
			object sprite4 = weaponIcon.m_Sprite;
			if ((object)weaponIcon.m_Sprite != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ rdi_v16 (System.Object)+10]");
				if ((nint)0 != 0)
				{
					if ((object)WeaponIcon != null)
					{
						RectTransform rectTransform3 = WeaponIcon.rectTransform;
						object weaponIcon2 = WeaponIcon;
						if ((object)WeaponIcon != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v165 @ rdi_v21 (System.Object)+E0]");
							object obj3 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v165 @ rdi_v21 (System.Object)+E0]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v166 @ rdi_v22 (System.Object)+10]");
								bool flag5 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v166 @ rdi_v22 (System.Object)+10]");
								Sprite.get_rect_Injected((IntPtr)0, out ret2);
								object weaponIcon3 = WeaponIcon;
								if ((object)WeaponIcon != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v171 @ rdi_v23 (System.Object)+E0]");
									object obj4 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v171 @ rdi_v23 (System.Object)+E0]");
									if ((nint)0 != 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ rdi_v24 (System.Object)+10]");
										bool flag6 = (nint)0 == 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ rdi_v24 (System.Object)+10]");
										Sprite.get_rect_Injected((IntPtr)0, out ret);
										if ((object)rectTransform3 != null)
										{
											rectTransform3.sizeDelta = sizeDelta;
											goto IL_02be;
										}
									}
								}
							}
						}
					}
					goto IL_03bb;
				}
			}
			goto IL_02be;
		}
		goto IL_03bb;
	}

	private unsafe void ResetDisplay(bool playerLeftGame)
	{
		//IL_000e: Expected O, but got I4
		//IL_0017: Expected O, but got I4
		//IL_02aa: Expected O, but got I
		//IL_02c1: Expected O, but got Ref
		//IL_009f: Expected O, but got I
		//IL_00b6: Expected O, but got Ref
		//IL_0354: Expected F4, but got O
		//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b0: Expected O, but got Unknown
		//IL_0186: Expected O, but got Ref
		List<GameObject> spawned = _spawned;
		object obj = 0;
		object obj2 = 0;
		float num = default(float);
		Color color = default(Color);
		while (true)
		{
			if ((nint)obj2 < spawned._size)
			{
				List<GameObject> spawned2 = _spawned;
				if ((nint)obj >= spawned2._size)
				{
					break;
				}
				GameObject[] items = spawned2._items;
				CharacterItemUI component = items[obj].GetComponent<CharacterItemUI>();
				component._isTaken = false;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
				component._highlightColor = (Color)0;
				component._Background.color = (Color)(&num);
				Sprite backgroundSprite = component.GetBackgroundSprite();
				component._Background.sprite = backgroundSprite;
				MultiplayerManager multiplayer = _multiplayer;
				List<CoopSlotData> slotsSelections = multiplayer._slotsSelections;
				int num2 = 0;
				while (true)
				{
					bool flag = num2 >= slotsSelections._size;
					num = (float)component._backgroundColor;
					if (flag)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
					CharacterItem charItem = component._charItem;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ rax_v35+10]");
					if ((nint)0 != (nint)charItem._characterType)
					{
						num2++;
						continue;
					}
					Color slotColor = _multiplayer.GetSlotColor(num2);
					component.SetTakenByAnotherPlayer(taken: true, (Color)(&color));
					num = slotColor.r;
					break;
				}
				spawned = _spawned;
				obj++;
				obj2 = obj;
				continue;
			}
			if (!playerLeftGame)
			{
				List<GameObject> spawned3 = _spawned;
				if (spawned3._size <= 0)
				{
					break;
				}
				GameObject[] items2 = spawned3._items;
				CharacterItemUI component2 = items2[0].GetComponent<CharacterItemUI>();
				component2.SetInfoPanel();
				Action cb = delegate
				{
					//IL_0012: Expected O, but got Ref
					List<GameObject>.Enumerator enumerator = default(List<GameObject>.Enumerator);
					if (!enumerator.MoveNext())
					{
						return;
					}
					List<GameObject>.Enumerator enumerator2 = (List<GameObject>.Enumerator)(&enumerator);
					throw new NullReferenceException();
				};
				IEnumerator routine = WaitAndDo(cb);
				Coroutine coroutine = StartCoroutine(routine);
			}
			else
			{
				CharacterItemUI selectedCharacterItemUI = _selectedCharacterItemUI;
				selectedCharacterItemUI._isTaken = false;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
				selectedCharacterItemUI._highlightColor = (Color)0;
				selectedCharacterItemUI._Background.color = (Color)(&num);
				Sprite backgroundSprite2 = selectedCharacterItemUI.GetBackgroundSprite();
				selectedCharacterItemUI._Background.sprite = backgroundSprite2;
				_selectedCharacterItemUI.SetInfoPanel();
				Selectable component3 = _selectedCharacterItemUI.GetComponent<Selectable>();
				component3.Select();
			}
			return;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	private bool CanSeeSkins()
	{
		//IL_01a7: Expected I4, but got O
		if (_playerOptions != null)
		{
			PlayerOptionsData config = _playerOptions.Config;
			if (config != null)
			{
				List<ItemType> list = config._003CCollectedItems_003Ek__BackingField;
				if (config._003CCollectedItems_003Ek__BackingField != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ rcx_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
						object obj = default(object);
						if ((nint)obj != -1)
						{
							if ((object)_selectedCharacterItemUI != null)
							{
								if (!_selectedCharacterItemUI.IsCharAvailable())
								{
									goto IL_0193;
								}
								if (_multiplayer != null)
								{
									int playerCount = _multiplayer.GetPlayerCount();
									if (playerCount <= 1 && !_multiplayer.IsOnlineMultiplayer)
									{
										return true;
									}
									CharacterItemUI selectedCharacterItemUI = _selectedCharacterItemUI;
									if ((object)_selectedCharacterItemUI != null)
									{
										return !selectedCharacterItemUI._isTaken;
									}
								}
							}
							goto IL_0199;
						}
					}
					goto IL_0193;
				}
			}
		}
		goto IL_0199;
		IL_0193:
		return false;
		IL_0199:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public void NextSkin()
	{
		if (!CanSeeSkins())
		{
			return;
		}
		CharacterData currentData = _currentData;
		if (currentData._003Cskins_003Ek__BackingField == null)
		{
			return;
		}
		List<SkinItem> list = new List<SkinItem>();
		Dictionary<SkinType, SkinItem>.Enumerator enumerator = default(Dictionary<SkinType, SkinItem>.Enumerator);
		object obj = default(object);
		while (enumerator.MoveNext())
		{
			if (obj != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v827 @ stack_-48+38]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9DBC0");
				}
				continue;
			}
			throw new NullReferenceException();
		}
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		int num5 = default(int);
		float time = default(float);
		while (true)
		{
			if (num4 < list._size)
			{
				if (num3 >= list._size)
				{
					break;
				}
				SkinItem[] items = list._items;
				SkinItem skinItem = items[num3];
				CharacterData currentData2 = _currentData;
				if (skinItem._skinType == currentData2._003CcurrentSkin_003Ek__BackingField)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
					num = num5;
					num2 = num3;
				}
				num3++;
				num4 = num3;
				continue;
			}
			if (num == 0)
			{
				num2 = list._size;
			}
			int num6 = num2 + 1;
			bool flag = num6 >= list._size;
			int num7 = 0;
			if (!flag)
			{
				num7 = num6;
			}
			if (num7 >= list._size)
			{
				break;
			}
			SkinItem[] items2 = list._items;
			SkinItem skinItem2 = items2[num7];
			CharacterData currentData3 = _currentData;
			currentData3._003CcurrentSkin_003Ek__BackingField = skinItem2._skinType;
			PlayerOptionsData playerOptionsData;
			if (skinItem2._unlockState == UIUnlockStates.AVAILABLE)
			{
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
								goto IL_02e4;
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
				goto IL_02e4;
			}
			goto IL_0314;
			IL_02e4:
			bool flag2 = ((Dictionary<System.Int32Enum, System.Int32Enum>)(object)playerOptionsData._003CSelectedSkinsV2_003Ek__BackingField).TryInsert((System.Int32Enum)_currentType, (System.Int32Enum)skinItem2._skinType, System.Collections.Generic.InsertionBehavior.OverwriteExisting);
			goto IL_0314;
			IL_0314:
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.ClickIn, null, 0f, 10, time);
			_selectedCharacterItemUI.Refresh();
			StatsPanel.SetValues();
			List<Image> skinSlots = _skinSlots;
			int num8 = 0;
			int num9 = 0;
			List<Image> skinSlots2 = _skinSlots;
			while (true)
			{
				if (num9 < skinSlots._size)
				{
					if (num8 >= skinSlots2._size)
					{
						break;
					}
					Image[] items3 = skinSlots2._items;
					Sprite sprite = ((num8 != num7) ? _SkinOffIcon : _SkinOnIcon);
					items3[num8].sprite = sprite;
					num8++;
					skinSlots2 = _skinSlots;
					bool flag3 = _skinSlots != null;
					num9 = num8;
					skinSlots = _skinSlots;
					if (!flag3)
					{
						throw new NullReferenceException();
					}
					continue;
				}
				return;
			}
			break;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	private void SetSkinSlots()
	{
		//IL_017e: Expected O, but got I
		//IL_01ec: Expected O, but got I
		//IL_08c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_08c7: Expected O, but got Unknown
		//IL_003a->IL0757: Incompatible stack heights: 1 vs 0
		//IL_0074->IL07f3: Incompatible stack heights: 1 vs 0
		//IL_0256->IL0842: Incompatible stack heights: 1 vs 0
		//IL_04f9->IL06e5: Incompatible stack heights: 1 vs 0
		//IL_03ed->IL06e5: Incompatible stack heights: 1 vs 0
		//IL_088b->IL0842: Incompatible stack heights: 1 vs 0
		//IL_053c->IL06e5: Incompatible stack heights: 2 vs 0
		//IL_0441->IL06e5: Incompatible stack heights: 2 vs 0
		//IL_02e6->IL0842: Incompatible stack heights: 1 vs 0
		//IL_05b4->IL05d5: Incompatible stack heights: 2 vs 0
		//IL_062a->IL0921: Incompatible stack heights: 1 vs 0
		//IL_046a->IL06e5: Incompatible stack heights: 2 vs 0
		//IL_0a18->IL05d5: Incompatible stack heights: 2 vs 0
		//IL_0348->IL0842: Incompatible stack heights: 3 vs 0
		//IL_08d4->IL0a18: Incompatible stack heights: 2 vs 0
		//IL_06e5->IL0a02: Incompatible stack heights: 0 vs 2
		//IL_0664->IL09b3: Incompatible stack heights: 1 vs 0
		int size;
		Array items3;
		int index;
		if (_skinSlots != null)
		{
			List<Image>.Enumerator enumerator = default(List<Image>.Enumerator);
			while (enumerator.MoveNext())
			{
				object obj = null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v456 @ rbx_v39 (System.Object)+10]");
				bool flag = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v456 @ rbx_v39 (System.Object)+10]");
				IntPtr gcHandlePtr = Component.get_gameObject_Injected((IntPtr)0);
				GameObject obj2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr);
				UnityEngine.Object.Destroy(obj2, 0f);
			}
			List<Image> skinSlots = _skinSlots;
			if (_skinSlots != null)
			{
				List<Image>.Enumerator enumerator2 = default(List<Image>.Enumerator);
				while (enumerator2.MoveNext())
				{
					object obj3 = null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v726 @ rbx_v37 (System.Object)+10]");
					bool flag2 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v726 @ rbx_v37 (System.Object)+10]");
					IntPtr gcHandlePtr2 = Component.get_gameObject_Injected((IntPtr)0);
					GameObject obj4 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr2);
					UnityEngine.Object.Destroy(obj4, 0f);
				}
				List<Image> skinSlots2 = _skinSlots;
				if (_skinSlots != null)
				{
					int version = skinSlots2._version + 1;
					skinSlots2._version = version;
					skinSlots2._size = 0;
					if (skinSlots2._size > 0)
					{
						Array.Clear(skinSlots2._items, 0, skinSlots2._size);
						skinSlots = null;
					}
					if (!CanSeeSkins())
					{
						return;
					}
					CharacterItemUI selectedCharacterItemUI = _selectedCharacterItemUI;
					if ((object)_selectedCharacterItemUI != null)
					{
						object charItem = selectedCharacterItemUI._charItem;
						if (selectedCharacterItemUI._charItem != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ rbx_v23 (System.Object)+30]");
							object obj5 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ rbx_v23 (System.Object)+30]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ rbx_v24 (System.Object)+20]");
								nint num = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ rbx_v24 (System.Object)+28]");
								if (num == 0)
								{
									return;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ rbx_v24 (System.Object)+20]");
								nint num2 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ rbx_v24 (System.Object)+28]");
								object obj6 = num2 - 0;
								if ((nint)obj6 == 1)
								{
									return;
								}
								List<SkinItem> list = new List<SkinItem>();
								Dictionary<SkinType, SkinItem>.Enumerator enumerator3 = default(Dictionary<SkinType, SkinItem>.Enumerator);
								object obj7 = default(object);
								while (enumerator3.MoveNext())
								{
									bool flag3 = obj7 == null;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2046 @ stack_-80+38]");
									if ((nint)0 == 0)
									{
										continue;
									}
									GameObject gameObject = UnityEngine.Object.Instantiate(_SkinIndexPrefab, _SkinIndexContainer);
									object obj8;
									if ((object)gameObject != null)
									{
										Image component = gameObject.GetComponent<Image>();
										obj8 = component;
									}
									else
									{
										obj8 = null;
									}
									if (obj8 != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1080 @ rbx_v34 (System.Object)+10]");
										if ((nint)0 != 0)
										{
											((Image)obj8).sprite = _SkinOffIcon;
											bool flag4 = _skinSlots == null;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A77500");
											bool flag5 = list == null;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9DBC0");
										}
									}
								}
								List<Image> skinSlots3 = _skinSlots;
								if (_skinSlots != null)
								{
									if (skinSlots3._size > 1)
									{
										if (list != null)
										{
											object obj9 = null;
											object obj10 = null;
											object obj11 = null;
											while ((nint)obj10 < list._size)
											{
												bool flag6 = (nint)obj11 >= list._size;
												SkinItem[] items = list._items;
												if (list._items != null)
												{
													bool flag7 = (nint)obj11 >= items.Length;
													SkinItem skinItem = items[obj11];
													if (items[obj11] != null)
													{
														CharacterData currentData = _currentData;
														if (_currentData != null)
														{
															if (skinItem._skinType == currentData._003CcurrentSkin_003Ek__BackingField)
															{
																obj9 = obj11;
															}
															obj11++;
															obj10 = obj11;
															continue;
														}
													}
												}
												goto IL_06e5;
											}
											List<Image> skinSlots4 = _skinSlots;
											bool flag8 = (nint)obj9 >= skinSlots4._size;
											Image[] items2 = skinSlots4._items;
											if (skinSlots4._items != null)
											{
												bool flag9 = (nint)obj9 >= items2.Length;
												if ((object)items2[obj9] != null)
												{
													items2[obj9].sprite = _SkinOnIcon;
													int version2 = list._version + 1;
													list._version = version2;
													size = list._size;
													list._size = 0;
													if (list._size > 0)
													{
														items3 = list._items;
														index = 0;
														goto IL_0a02;
													}
													return;
												}
											}
										}
									}
									else if (_skinSlots != null)
									{
										List<Image>.Enumerator enumerator4 = default(List<Image>.Enumerator);
										while (enumerator4.MoveNext())
										{
											object obj12 = null;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1686 @ rbx_v31 (System.Object)+10]");
											bool flag10 = (nint)0 == 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1686 @ rbx_v31 (System.Object)+10]");
											IntPtr gcHandlePtr3 = Component.get_gameObject_Injected((IntPtr)0);
											GameObject obj13 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr3);
											UnityEngine.Object.Destroy(obj13, 0f);
										}
										if (_skinSlots != null)
										{
											List<Image>.Enumerator enumerator5 = default(List<Image>.Enumerator);
											while (enumerator5.MoveNext())
											{
												object obj14 = null;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1987 @ rbx_v29 (System.Object)+10]");
												bool flag11 = (nint)0 == 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1987 @ rbx_v29 (System.Object)+10]");
												IntPtr gcHandlePtr4 = Component.get_gameObject_Injected((IntPtr)0);
												GameObject obj15 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr4);
												UnityEngine.Object.Destroy(obj15, 0f);
											}
											List<Image> skinSlots5 = _skinSlots;
											if (_skinSlots != null)
											{
												int version3 = skinSlots5._version + 1;
												skinSlots5._version = version3;
												size = skinSlots5._size;
												skinSlots5._size = 0;
												if (skinSlots5._size <= 0)
												{
													return;
												}
												items3 = skinSlots5._items;
												index = 0;
												goto IL_0a02;
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
		goto IL_06e5;
		IL_0a02:
		Array.Clear(items3, index, size);
		return;
		IL_06e5:
		throw new NullReferenceException();
	}

	protected unsafe override void OnShowStart(GameObject g)
	{
		//IL_0252: Expected O, but got I4
		//IL_0252: Expected O, but got I
		//IL_025b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0260: Expected O, but got Unknown
		//IL_0bc8: Expected O, but got I
		//IL_039f: Expected O, but got I4
		//IL_039f: Expected O, but got I
		//IL_03a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ad: Expected O, but got Unknown
		//IL_0c01: Expected O, but got I
		//IL_04ec: Expected O, but got I4
		//IL_04ec: Expected O, but got I
		//IL_04f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_04fa: Expected O, but got Unknown
		//IL_0c3c: Expected O, but got I
		//IL_0639: Expected O, but got I4
		//IL_0639: Expected O, but got I
		//IL_0642: Unknown result type (might be due to invalid IL or missing references)
		//IL_0647: Expected O, but got Unknown
		//IL_0c75: Expected O, but got I
		//IL_0c9e: Expected I4, but got O
		//IL_0ca7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cac: Expected O, but got Unknown
		//IL_0778: Expected I, but got O
		//IL_078e: Expected O, but got I
		//IL_0797: Unknown result type (might be due to invalid IL or missing references)
		//IL_079c: Expected O, but got Unknown
		//IL_0812: Expected I, but got O
		//IL_0cd2: Expected O, but got I4
		//IL_0ce9: Expected I, but got I8
		//IL_07ee: Expected I, but got I8
		//IL_0f33: Expected O, but got I4
		//IL_0a4b: Expected O, but got I4
		//IL_0a38: Expected O, but got I4
		//IL_0eba: Expected I4, but got O
		//IL_0acc: Expected O, but got I
		//IL_0aec: Expected O, but got I4
		//IL_0b10: Expected O, but got I
		//IL_0b19: Expected O, but got I4
		//IL_0d33->IL0858: Incompatible stack heights: 1 vs 0
		//IL_0dd6->IL0b51: Incompatible stack heights: 1 vs 0
		//IL_0e11->IL0d7c: Incompatible stack heights: 2 vs 0
		//IL_0e85->IL0b51: Incompatible stack heights: 1 vs 0
		//IL_0b42->IL0b51: Incompatible stack heights: 2 vs 0
		//IL_0a7e->IL0b51: Incompatible stack heights: 2 vs 0
		//IL_0efd->IL0b51: Incompatible stack heights: 2 vs 0
		//IL_0f2a->IL0f2a: Incompatible stack heights: 3 vs 0
		base.OnShowStart(g);
		MultiplayerManager multiplayer2;
		MultiplayerManager.OnRefresh onRefresh;
		if ((object)Icon != null)
		{
			Icon.enabled = false;
			if ((object)_Name != null)
			{
				_Name.enabled = false;
				if ((object)Description != null)
				{
					Description.enabled = false;
					if ((object)_WeaponFrame != null)
					{
						_WeaponFrame.SetActive(value: false);
						EnterCoopButton enterCoopButton = _EnterCoopButton;
						if ((object)_EnterCoopButton != null)
						{
							if (enterCoopButton._multiplayerManager != null)
							{
								MultiplayerManager multiplayerManager = enterCoopButton._multiplayerManager;
								multiplayerManager.AllowPlayerJoining = false;
								MultiplayerManager multiplayerManager2 = enterCoopButton._multiplayerManager;
								if (enterCoopButton._multiplayerManager == null)
								{
									goto IL_0b51;
								}
								multiplayerManager2.AllowPlayerRemoval = false;
							}
							if ((object)enterCoopButton._button != null)
							{
								GameObject gameObject = enterCoopButton._button.gameObject;
								if ((object)gameObject != null)
								{
									gameObject.SetActive(value: true);
									Action<UISignals.AddNewCharactersToSelectionPageSignal> action = null;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9DC20");
									if (_signalBus != null)
									{
										nint num = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v233 @ rbx_v15 (Il2CppMethodInfo)+38]");
										if ((nint)0 == 0)
										{
										}
										object obj = null;
										if (obj != null)
										{
											Action<object> action2 = ((SignalBus._003C_003Ec__DisplayClass37_0<UISignals.AddNewCharactersToSelectionPageSignal>)obj)._003CSubscribeId_003Eb__0;
											((SignalBus._003C_003Ec__DisplayClass37_0<UISignals.AddNewCharactersToSelectionPageSignal>)0)._003CSubscribeId_003Eb__0((object)1);
											object obj3 = default(object);
											object obj2 = obj3 + 32;
											Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
											SignalBus signalBus = _signalBus;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ rax_v47 (System.Object)+10]");
											Type signalType = default(Type);
											Action<object> callback = default(Action<object>);
											signalBus.SubscribeInternal(signalType, (object)null, (object)0, callback);
											Action<UISignals.ForceSelectionOnCharacterSelectionPageSignal> action3 = null;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9DD00");
											if (_signalBus != null)
											{
												nint num2 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1341 @ rbx_v18 (Il2CppMethodInfo)+38]");
												if ((nint)0 == 0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
												}
												nint num3 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v235 @ rbx_v19 (Il2CppMethodInfo)+38]");
												if ((nint)0 == 0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v235 @ rbx_v19 (Il2CppMethodInfo)+38]");
													if ((nint)0 == 0)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
													}
												}
												object obj4 = null;
												if (obj4 != null)
												{
													Action<object> action4 = ((SignalBus._003C_003Ec__DisplayClass37_0<UISignals.ForceSelectionOnCharacterSelectionPageSignal>)obj4)._003CSubscribeId_003Eb__0;
													((SignalBus._003C_003Ec__DisplayClass37_0<UISignals.ForceSelectionOnCharacterSelectionPageSignal>)0)._003CSubscribeId_003Eb__0((object)1);
													object obj6 = default(object);
													object obj5 = obj6 + 32;
													Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
													SignalBus signalBus2 = _signalBus;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v169 @ rax_v62 (System.Object)+10]");
													Type signalType2 = default(Type);
													signalBus2.SubscribeInternal(signalType2, (object)null, (object)0, callback);
													Action action5 = SpawnMinorDoilie;
													if (_signalBus != null)
													{
														nint num4 = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1552 @ rbx_v22 (Il2CppMethodInfo)+38]");
														if ((nint)0 == 0)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
														}
														nint num5 = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v237 @ rbx_v23 (Il2CppMethodInfo)+38]");
														if ((nint)0 == 0)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v237 @ rbx_v23 (Il2CppMethodInfo)+38]");
															if ((nint)0 == 0)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
															}
														}
														object obj7 = null;
														if (obj7 != null)
														{
															Action<object> action6 = ((SignalBus._003C_003Ec__DisplayClass35_0<UISignals.SpawnMinorDoilieSignal>)obj7)._003CSubscribeId_003Eb__0;
															((SignalBus._003C_003Ec__DisplayClass35_0<UISignals.SpawnMinorDoilieSignal>)0)._003CSubscribeId_003Eb__0((object)1);
															object obj9 = default(object);
															object obj8 = obj9 + 32;
															Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
															SignalBus signalBus3 = _signalBus;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v171 @ rax_v77 (System.Object)+10]");
															Type signalType3 = default(Type);
															signalBus3.SubscribeInternal(signalType3, (object)null, (object)0, callback);
															Action<UISignals.SetCharacterSelectionPageVisibility> action7 = null;
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9DDE0");
															if (_signalBus != null)
															{
																nint num6 = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1761 @ rbx_v26 (Il2CppMethodInfo)+38]");
																if ((nint)0 == 0)
																{
																	Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
																}
																nint num7 = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v239 @ rbx_v27 (Il2CppMethodInfo)+38]");
																if ((nint)0 == 0)
																{
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v239 @ rbx_v27 (Il2CppMethodInfo)+38]");
																	if ((nint)0 == 0)
																	{
																		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
																	}
																}
																object obj10 = null;
																if (obj10 != null)
																{
																	Action<object> action8 = ((SignalBus._003C_003Ec__DisplayClass37_0<UISignals.SetCharacterSelectionPageVisibility>)obj10)._003CSubscribeId_003Eb__0;
																	((SignalBus._003C_003Ec__DisplayClass37_0<UISignals.SetCharacterSelectionPageVisibility>)0)._003CSubscribeId_003Eb__0((object)1);
																	object obj12 = default(object);
																	object obj11 = obj12 + 32;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
																	SignalBus signalBus4 = _signalBus;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rax_v92 (System.Object)+10]");
																	Type signalType4 = default(Type);
																	signalBus4.SubscribeInternal(signalType4, (object)null, (object)0, callback);
																	if (_multiplayer != null)
																	{
																		_multiplayer.ClearAllExtraPlayers();
																		MultiplayerManager multiplayer = _multiplayer;
																		if (_multiplayer != null)
																		{
																			multiplayer.AllowPlayerJoining = false;
																			if ((object)BuyButton != null)
																			{
																				TextMeshProUGUI componentInChildren = BuyButton.GetComponentInChildren<TextMeshProUGUI>();
																				_buyButtonLabel = componentInChildren;
																				GameObject gameObject2 = null;
																				do
																				{
																					SpawnPlayerItem((int)gameObject2);
																					gameObject2 = (GameObject)(gameObject2 + 1);
																				}
																				while ((nint)gameObject2 < 4);
																				Populate();
																				if ((object)_scrollEnhancer != null)
																				{
																					_scrollEnhancer.ForceScrollAlignment();
																					multiplayer2 = _multiplayer;
																					onRefresh = null;
																					nint num8 = 0;
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ r9_v22 (Il2CppMethodInfo)+8]");
																					((Delegate)onRefresh).method_ptr = (IntPtr)0;
																					((Delegate)onRefresh).method = (nint)__ldftn(CharacterSelectionPage.RefreshCharacters);
																					((Delegate)onRefresh).m_target = this;
																					((Delegate)onRefresh).method_code = (IntPtr)onRefresh;
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ r9_v22 (Il2CppMethodInfo)+4C]");
																					object obj13 = (nint)0 >> 4;
																					object obj14 = obj13 & 1;
																					nint num9;
																					if (obj14 != null)
																					{
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ r9_v22 (Il2CppMethodInfo)+52]");
																						if ((nint)0 == 0)
																						{
																							num9 = unchecked((nint)6447293664L);
																							goto IL_0cc9;
																						}
																					}
																					num9 = ((Delegate)onRefresh).method_ptr;
																					((Delegate)onRefresh).method_code = (IntPtr)((Delegate)onRefresh).m_target;
																					goto IL_0cc9;
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
					}
				}
			}
		}
		goto IL_0b51;
		IL_0b51:
		throw new NullReferenceException();
		IL_0cc9:
		object obj15 = 24;
		((Delegate)onRefresh).extra_arg = unchecked((nint)6447293568L);
		if (_multiplayer != null)
		{
			GameObject gameObject3 = (GameObject)(object)multiplayer2.RefreshUI;
			while (true)
			{
				Delegate obj16 = Delegate.Combine((Delegate)(object)gameObject3, onRefresh);
				bool flag = (object)obj16 == null;
				Delegate obj17 = null;
				if (!flag)
				{
					bool flag2 = (object)obj16.GetType() != typeof(MultiplayerManager.OnRefresh);
					obj17 = null;
					if (!flag2)
					{
						obj17 = obj16;
					}
					bool flag3 = (object)obj17 == null;
				}
				bool flag4 = (object)gameObject3 == multiplayer2.RefreshUI;
				GameObject gameObject4;
				if ((object)gameObject3 == multiplayer2.RefreshUI)
				{
					multiplayer2.RefreshUI = (MultiplayerManager.OnRefresh)obj17;
					gameObject4 = gameObject3;
				}
				else
				{
					gameObject4 = (GameObject)(object)multiplayer2.RefreshUI;
				}
				GameObject gameObject5 = gameObject3;
				if (!flag4)
				{
					gameObject5 = gameObject4;
				}
				while (true)
				{
					object obj18 = 0;
					bool flag5 = (object)gameObject5 != gameObject3;
					gameObject3 = gameObject5;
					if (flag5)
					{
						break;
					}
					RefreshCharacters();
					WrapNavigation();
					MultiplayerManager multiplayer3 = _multiplayer;
					if (_multiplayer == null)
					{
						goto end_IL_0d49;
					}
					if (multiplayer3.AllowPlayerJoining)
					{
						int playerCount = _multiplayer.GetPlayerCount();
						if (playerCount <= 1 && !_multiplayer.IsOnlineMultiplayer)
						{
							MakeDisplaySingleplayer();
						}
						else
						{
							MakeDisplayMultiplayer();
						}
					}
					else
					{
						MakeDisplaySingleplayer();
						GameObject mPPlayerContainer = (GameObject)(object)MPPlayerContainer;
						if ((object)MPPlayerContainer == null)
						{
							goto end_IL_0d49;
						}
						bool flag6 = ((UnityEngine.Object)mPPlayerContainer).m_CachedPtr == (IntPtr)0;
						IntPtr gcHandlePtr = Component.get_gameObject_Injected(((UnityEngine.Object)mPPlayerContainer).m_CachedPtr);
						GameObject gameObject6 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr);
						if ((object)gameObject6 == null)
						{
							goto end_IL_0d49;
						}
						bool flag7 = ((UnityEngine.Object)gameObject6).m_CachedPtr == (IntPtr)0;
						GameObject.SetActive_Injected(((UnityEngine.Object)gameObject6).m_CachedPtr, false);
					}
					MultiplayerManager s_instance = MultiplayerManager.s_instance;
					if (MultiplayerManager.s_instance == null)
					{
						goto end_IL_0d49;
					}
					GameObject enterCoopButton2 = (GameObject)(object)_EnterCoopButton;
					_wasAllowingMultiplayerJoining = s_instance.AllowPlayerJoining;
					if ((object)_EnterCoopButton == null)
					{
						goto end_IL_0d49;
					}
					bool flag8 = ((UnityEngine.Object)enterCoopButton2).m_CachedPtr == (IntPtr)0;
					IntPtr gcHandlePtr2 = Component.get_gameObject_Injected(((UnityEngine.Object)enterCoopButton2).m_CachedPtr);
					GameObject gameObject7 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr2);
					object obj19 = ((!_wasAllowingMultiplayerJoining) ? ((object)1) : ((object)0));
					if ((object)gameObject7 == null)
					{
						goto end_IL_0d49;
					}
					bool flag9 = ((UnityEngine.Object)gameObject7).m_CachedPtr == (IntPtr)0;
					GameObject.SetActive_Injected(((UnityEngine.Object)gameObject7).m_CachedPtr, (byte)(int)obj19 != 0);
					if (_partyModeEnabled)
					{
						GameObject enterCoopButton3 = (GameObject)(object)_EnterCoopButton;
						if ((object)_EnterCoopButton == null)
						{
							goto end_IL_0d49;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A3157]");
						if ((nint)0 == 0)
						{
							_ = 1;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v247 @ rbx_v42 (UnityEngine.GameObject)+30]");
						if ((nint)0 == 0)
						{
							goto end_IL_0d49;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v247 @ rbx_v42 (UnityEngine.GameObject)+30]");
						((Localize)0).Term = "partyLang/{co-op&partymode}";
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v247 @ rbx_v42 (UnityEngine.GameObject)+38]");
						bool flag10 = (nint)0 == 0;
						obj18 = 0;
						if (!flag10)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v247 @ rbx_v42 (UnityEngine.GameObject)+38]");
							((GameObject)0).SetActive(value: true);
							obj18 = 0;
						}
					}
					GameObject switchReassignControllersButton = _SwitchReassignControllersButton;
					if ((object)_SwitchReassignControllersButton == null)
					{
						goto end_IL_0d49;
					}
					bool flag11 = ((UnityEngine.Object)switchReassignControllersButton).m_CachedPtr == (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: Type: Il2CppMethodInfo (should have been resolved before IL gen)");
				}
				continue;
				end_IL_0d49:
				break;
			}
		}
		goto IL_0b51;
	}

	private void OnPlayerButtonClicked(int index)
	{
		_multiplayer.SelectSlot(index);
		List<MPPlayerItem> playerSlots = _playerSlots;
		if (index < playerSlots._size)
		{
			MPPlayerItem[] items = playerSlots._items;
			MPPlayerItem mPPlayerItem = items[index];
			mPPlayerItem._PlayerState = MPPlayerItem.PlayerState.INACTIVE;
		}
		else
		{
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}

	private unsafe LargeMultiOptionPopup ShowAISettingsPopup(int playerSlotIndex)
	{
		//IL_00fb: Expected O, but got I4
		//IL_0104: Expected O, but got I4
		//IL_010e: Expected O, but got I4
		//IL_023f: Expected O, but got Ref
		//IL_072a: Unknown result type (might be due to invalid IL or missing references)
		//IL_072f: Expected O, but got Unknown
		//IL_04d5: Expected O, but got Ref
		//IL_0502: Expected I4, but got O
		//IL_0532: Expected I4, but got O
		//IL_0207: Unknown result type (might be due to invalid IL or missing references)
		//IL_020c: Expected O, but got Unknown
		//IL_0593: Expected O, but got I4
		//IL_05e4: Expected I4, but got O
		//IL_05c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c8: Expected O, but got Unknown
		_003C_003Ec__DisplayClass105_0 obj = new _003C_003Ec__DisplayClass105_0();
		obj._003C_003E4__this = this;
		obj.playerSlotIndex = playerSlotIndex;
		List<AIPopupChoice> popupChoices = new List<AIPopupChoice>();
		obj.popupChoices = popupChoices;
		List<OptionDataSet> options = new List<OptionDataSet>();
		ReInput.PlayerHelper players = ReInput.players;
		IList<Rewired.Player> players2 = players.Players;
		Func<Rewired.Player, bool> predicate = _003C_003Ec._003C_003E9__105_0;
		if (_003C_003Ec._003C_003E9__105_0 == null)
		{
			predicate = (_003C_003Ec._003C_003E9__105_0 = delegate(Rewired.Player x)
			{
				//IL_00be: Expected I4, but got O
				if (x != null && x.controllers != null)
				{
					int joystickCount = x.controllers.joystickCount;
					if (joystickCount > 0)
					{
						return true;
					}
					if (x.controllers != null)
					{
						return x.controllers.hasKeyboard;
					}
				}
				NullReferenceException ex2 = new NullReferenceException();
				return (byte)(int)ex2 != 0;
			});
		}
		IEnumerable<Rewired.Player> source = Enumerable.Where(players2, predicate);
		Func<object, int> keySelector = (Func<object, int>)_003C_003Ec._003C_003E9__105_1;
		if (_003C_003Ec._003C_003E9__105_1 == null)
		{
			keySelector = (Func<object, int>)(_003C_003Ec._003C_003E9__105_1 = delegate(Rewired.Player x)
			{
				//IL_0064: Expected I4, but got O
				if (x == null || x.controllers == null)
				{
					NullReferenceException ex2 = new NullReferenceException();
					return (int)ex2;
				}
				return x.controllers.joystickCount;
			});
		}
		IOrderedEnumerable<object> orderedEnumerable = Enumerable.OrderByDescending(source, keySelector);
		if (orderedEnumerable != null)
		{
			List<object> list = new List<object>(orderedEnumerable);
			object obj2 = 0;
			object obj3 = 0;
			object obj4 = 0;
			int num = default(int);
			while ((nint)obj4 < list._size)
			{
				if ((nint)obj3 < list._size)
				{
					object[] items = list._items;
					int id = ((Rewired.Player)items[obj3]).id;
					if (id == obj.playerSlotIndex)
					{
						string text = num.ToString();
						string title = "Controller " + text;
						OptionDataSet optionDataSet = new OptionDataSet(title, "");
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9DEC0");
						AIPopupChoice aIPopupChoice = new AIPopupChoice();
						aIPopupChoice._player = (Rewired.Player)items[obj3];
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9DF20");
						obj2++;
					}
					obj3++;
					obj4 = obj3;
					continue;
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				throw new NullReferenceException();
			}
			Dictionary<AIType, AIData>.Enumerator enumerator = default(Dictionary<AIType, AIData>.Enumerator);
			if (enumerator.MoveNext())
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
				AIType aIType = AIType.None;
				Dictionary<AIType, AIData>.Enumerator enumerator2 = (Dictionary<AIType, AIData>.Enumerator)(&enumerator);
				throw new NullReferenceException();
			}
			int value = obj.playerSlotIndex + 1;
			object obj5 = default(object);
			string text2 = System.Number.FormatInt32(value, (ReadOnlySpan<char>)(&obj5), null);
			string title2 = "CPU " + text2;
			Action<int> action = null;
			((_003C_003Ec__DisplayClass105_0)(object)action)._003CShowAISettingsPopup_003Eb__2((int)obj);
			Action<int> callback = default(Action<int>);
			Action closedCallback = default(Action);
			bool textIsLocalizationTerm = default(bool);
			TextAlignmentOptions? textAlignment = default(TextAlignmentOptions?);
			LargeMultiOptionPopup largeMultiOptionPopup = PopupManager.CreateLargeMultiOption("partyselection", title2, "", options, callback, closedCallback, textIsLocalizationTerm, textAlignment, (byte)(int)action != 0);
			CoopSlotData slotInfo = MultiplayerManager.s_instance.GetSlotInfo(obj.playerSlotIndex);
			if (slotInfo.AIType != AIType.None)
			{
				object obj6 = 0;
				Dictionary<AIType, AIData>.Enumerator enumerator3 = default(Dictionary<AIType, AIData>.Enumerator);
				while (enumerator3.MoveNext() && AIType.None != slotInfo.AIType)
				{
					obj6++;
				}
				int index = (int)(obj2 + obj6);
				largeMultiOptionPopup.SelectOption(index);
			}
			return largeMultiOptionPopup;
		}
		Exception ex = System.Linq.Error.ArgumentNull("source");
		throw ex;
	}

	private void PlayerSlotSelection(int index, int choiceIndex, List<AIPopupChoice> choices)
	{
		Debug.Log("<CharacterSelectionPage.PlayerSlotSelection> start");
		_AISelectionPopup = null;
		if (choiceIndex < choices._size)
		{
			AIPopupChoice[] items = choices._items;
			AIPopupChoice aIPopupChoice = items[choiceIndex];
			CoopSlotData slotInfo = _multiplayer.GetSlotInfo(index);
			slotInfo.AIType = aIPopupChoice._aiType;
			slotInfo.RewiredPlayer = aIPopupChoice._player;
			if (aIPopupChoice._aiType != AIType.None)
			{
				List<MPPlayerItem> playerSlots = _playerSlots;
				if (index >= playerSlots._size)
				{
					goto IL_024b;
				}
				MPPlayerItem[] items2 = playerSlots._items;
				items2[index].UpdateAIIcon();
			}
			Debug.Log("<CharacterSelectionPage.PlayerSlotSelection> pre if (characterToSelect != CharacterType.VOID)");
			if (slotInfo.SelectedCharacter == CharacterType.VOID)
			{
				Debug.Log("<CharacterSelectionPage.PlayerSlotSelection> if (characterToSelect != CharacterType.VOID) was false");
				List<GameObject> spawned = _spawned;
				if (spawned._size <= 0)
				{
					goto IL_024b;
				}
				GameObject[] items3 = spawned._items;
				CharacterItemUI component = items3[0].GetComponent<CharacterItemUI>();
				_selectedCharacterItemUI = component;
			}
			else
			{
				Debug.Log("<CharacterSelectionPage.PlayerSlotSelection> if (characterToSelect != CharacterType.VOID) was true");
				object obj = ((Dictionary<System.Int32Enum, object>)(object)_characterItemUIs).get_Item((System.Int32Enum)slotInfo.SelectedCharacter);
				((CharacterItemUI)obj).SetSelected();
				((CharacterItemUI)obj).SetInfoPanel();
				_selectedCharacterItemUI = (CharacterItemUI)obj;
			}
			IEnumerator enumerator = SelectAfterFrameDelay();
			Debug.Log("<CharacterSelectionPage.PlayerSlotSelection> end");
			return;
		}
		goto IL_024b;
		IL_024b:
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	private void SetVisibility(UISignals.SetCharacterSelectionPageVisibility sig)
	{
		CanvasGroup component = GetComponent<CanvasGroup>();
		if ((object)sig == null)
		{
			component.alpha = 0f;
			component.interactable = false;
			component.blocksRaycasts = false;
		}
		else
		{
			component.alpha = 1f;
			component.interactable = true;
			component.blocksRaycasts = true;
		}
	}

	private void ForceSelectCharacter(UISignals.ForceSelectionOnCharacterSelectionPageSignal sig)
	{
		//IL_0014: Expected I4, but got O
		//IL_0051: Expected I4, but got O
		//IL_0089: Expected I4, but got O
		object obj = ((Dictionary<System.Int32Enum, object>)(object)_characterItemUIs).get_Item((System.Int32Enum)sig);
		GameObject gameObject = ((Component)obj).gameObject;
		gameObject.SetActive(value: true);
		object obj2 = ((Dictionary<System.Int32Enum, object>)(object)_characterItemUIs).get_Item((System.Int32Enum)sig);
		Selectable component = ((Component)obj2).GetComponent<Selectable>();
		component.Select();
		object obj3 = ((Dictionary<System.Int32Enum, object>)(object)_characterItemUIs).get_Item((System.Int32Enum)sig);
		((CharacterItemUI)obj3).AnimateIn();
		RebuildNavigationAfterCreditsReveal();
	}

	private unsafe void AddCharactersFromSignal(UISignals.AddNewCharactersToSelectionPageSignal sig)
	{
		//IL_0351: Expected O, but got I
		//IL_0073: Expected O, but got I
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Expected O, but got Unknown
		//IL_00c2: Expected O, but got I4
		//IL_01e1: Expected O, but got Ref
		GameObject gameObject = null;
		object obj = default(object);
		object obj2 = default(object);
		object obj4 = default(object);
		UISignals.AddNewCharactersToSelectionPageSignal addNewCharactersToSelectionPageSignal = default(UISignals.AddNewCharactersToSelectionPageSignal);
		while (true)
		{
			if (obj != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ stack_-C0_v18+1C]");
				if (obj2 != null)
				{
					break;
				}
				object obj3 = obj4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ stack_-C0_v18+18]");
				if ((nint)obj3 >= 0)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ stack_-C0_v18+10]");
				object obj5 = 0;
				object obj6 = obj4 + 1;
				bool flag = _characterItemUIs == null;
				Dictionary<CharacterType, CharacterItemUI> characterItemUIs = _characterItemUIs;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ rdx_v26+20+v240 @ stack_-B8_v17*4]");
				int num = ((Dictionary<System.Int32Enum, object>)(object)characterItemUIs).FindEntry((System.Int32Enum)0);
				object obj7 = !flag;
				if (obj7 == null)
				{
					Dictionary<CharacterType, List<CharacterData>> convertedCharacterData = _dataManager.GetConvertedCharacterData();
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ rdx_v26+20+v240 @ stack_-B8_v17*4]");
					object obj8 = ((Dictionary<System.Int32Enum, object>)(object)convertedCharacterData).get_Item((System.Int32Enum)0);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ rdx_v26+20+v240 @ stack_-B8_v17*4]");
					List<CharacterData> characterData = ((Dictionary<CharacterType, List<CharacterData>>)obj8).get_Item(CharacterType.VOID);
					PlayerOptions playerOptions = _playerOptions;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ rdx_v26+20+v240 @ stack_-B8_v17*4]");
					CharacterItem cItem = new CharacterItem(playerOptions, CharacterType.VOID, (CharacterData)(object)characterData);
					GameObject gameObject2 = AddCharacter(cItem);
					CharacterItemUI component = gameObject2.GetComponent<CharacterItemUI>();
					component.Refresh();
					CharacterItemUI component2 = gameObject2.GetComponent<CharacterItemUI>();
					component2.AnimateIn();
					if ((object)gameObject == null || ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0)
					{
						gameObject = gameObject2;
					}
					Selectable component3 = gameObject2.GetComponent<Selectable>();
					component3.navigation = (Navigation)(&addNewCharactersToSelectionPageSignal);
					obj4 = obj6;
				}
				else
				{
					Dictionary<CharacterType, CharacterItemUI> characterItemUIs2 = _characterItemUIs;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ rdx_v26+20+v240 @ stack_-B8_v17*4]");
					object obj9 = ((Dictionary<System.Int32Enum, object>)(object)characterItemUIs2).get_Item((System.Int32Enum)0);
					((CharacterItemUI)obj9).AnimateIn();
					obj4 = obj6;
				}
				continue;
			}
			throw new NullReferenceException();
		}
		bool flag2 = obj == null;
		CharacterSelectionPage characterSelectionPage = (CharacterSelectionPage)0;
		if (!flag2)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ stack_-C0_v18+1C]");
			if (obj2 == null)
			{
				LayoutRebuilder.ForceRebuildLayoutImmediate(_content);
				Canvas.ForceUpdateCanvases();
				if ((object)gameObject != null && ((UnityEngine.Object)gameObject).m_CachedPtr != (IntPtr)0)
				{
					Selectable component4 = gameObject.GetComponent<Selectable>();
					component4.Select();
				}
				return;
			}
			System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
			characterSelectionPage = null;
		}
		throw new NullReferenceException();
	}

	private void RebuildNavigationAfterCreditsReveal()
	{
		List<GameObject>.Enumerator enumerator = default(List<GameObject>.Enumerator);
		if (enumerator.MoveNext())
		{
			GameObject gameObject = null;
			throw new NullReferenceException();
		}
		WrapNavigation();
	}

	public void SpawnDoilie(CharacterItemUI c)
	{
		//IL_0191->IL0191: Incompatible stack heights: 1 vs 0
		_003C_003Ec__DisplayClass111_0 obj = new _003C_003Ec__DisplayClass111_0();
		if (obj != null)
		{
			obj.outDuration = 0.25f;
			GameObject gameObject = new GameObject();
			GameObject.Internal_CreateGameObject(gameObject, (string)null);
			obj.g = gameObject;
			if ((object)obj.g != null)
			{
				Transform transform = obj.g.transform;
				if ((object)c != null)
				{
					Transform parent = c.transform;
					if ((object)transform != null)
					{
						transform.SetParent(parent, worldPositionStays: true);
						if ((object)obj.g != null)
						{
							Transform transform2 = obj.g.transform;
							bool flag = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
							Vector3 value = default(Vector3);
							Transform.set_localPosition_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value);
							Transform transform3 = obj.g.transform;
							transform3.SetParent(_DoilieMask, worldPositionStays: true);
							Image i = obj.g.AddComponent<Image>();
							obj.i = i;
							RectTransform component = obj.g.GetComponent<RectTransform>();
							GameObject doilies = (GameObject)(object)_Doilies;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [189999098] (should have been resolved before IL gen)");
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public unsafe void SpawnMinorDoilie()
	{
		//IL_011c: Expected O, but got I
		//IL_03fb: Invalid comparison between I4 and F4
		//IL_0179: Expected O, but got I8
		//IL_049e: Expected O, but got I4
		//IL_04a6: Expected O, but got Ref
		//IL_0541: Expected O, but got I
		//IL_044b: Expected O, but got I4
		//IL_0453: Expected O, but got Ref
		//IL_0587: Invalid comparison between I4 and F4
		//IL_01fd: Expected I, but got I8
		//IL_0265: Expected O, but got I
		//IL_027e: Expected O, but got I4
		//IL_0287: Expected O, but got I4
		//IL_0228: Expected O, but got I
		//IL_0231: Expected O, but got I4
		//IL_023a: Expected O, but got I4
		//IL_017e->IL03dd: Incompatible stack heights: 8 vs 7
		//IL_0202->IL0569: Incompatible stack heights: 10 vs 9
		//IL_035a->IL035a: Incompatible stack heights: 15 vs 0
		Vector2 anchoredPosition = default(Vector2);
		while (true)
		{
			_003C_003Ec__DisplayClass112_0 obj = new _003C_003Ec__DisplayClass112_0();
			bool flag = obj == null;
			obj.outDuration = 0.2f;
			GameObject gameObject = new GameObject();
			GameObject.Internal_CreateGameObject(gameObject, (string)null);
			obj.g = gameObject;
			bool flag2 = (object)obj.g == null;
			Transform transform = obj.g.transform;
			Transform parent = base.transform;
			bool flag3 = (object)transform == null;
			transform.SetParent(parent, worldPositionStays: true);
			bool flag4 = (object)obj.g == null;
			Transform transform2 = obj.g.transform;
			bool flag5 = (object)transform2 == null;
			bool flag6 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
			Transform.SetSiblingIndex_Injected(((UnityEngine.Object)transform2).m_CachedPtr, 0);
			GameObject g = obj.g;
			bool flag7 = (object)obj.g == null;
			RectTransform rectTransform = obj.g.AddComponent<RectTransform>();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				bool flag8 = obj2 == null;
				g = (GameObject)6573110936L;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v991 @ rax_v65 (should have been resolved before IL gen)");
			GameObject doilieMask = (GameObject)(object)_DoilieMask;
			bool num;
			bool num2;
			Rect ret;
			if (0f > 0.5f)
			{
				bool flag9 = (object)_DoilieMask == null;
				num = flag9;
				bool flag10 = ((UnityEngine.Object)doilieMask).m_CachedPtr == (IntPtr)0;
				num2 = flag10;
				RectTransform.get_rect_Injected(((UnityEngine.Object)doilieMask).m_CachedPtr, out ret);
				object obj3 = 0;
				object obj4 = (object)(&ret);
				nint cachedPtr = ((UnityEngine.Object)doilieMask).m_CachedPtr;
			}
			else
			{
				bool flag11 = (object)_DoilieMask == null;
				num = flag11;
				bool flag12 = ((UnityEngine.Object)doilieMask).m_CachedPtr == (IntPtr)0;
				num2 = flag12;
				RectTransform.get_rect_Injected(((UnityEngine.Object)doilieMask).m_CachedPtr, out ret);
				object obj3 = 0;
				object obj4 = (object)(&ret);
				nint cachedPtr = ((UnityEngine.Object)doilieMask).m_CachedPtr;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				bool flag13 = obj5 == null;
				nint cachedPtr = unchecked((nint)6573110936L);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1324 @ rax_v69 (should have been resolved before IL gen)");
			GameObject doilieMask2 = (GameObject)(object)_DoilieMask;
			bool num3;
			bool num4;
			bool num5;
			if (0f > 0.5f)
			{
				bool flag14 = (object)_DoilieMask == null;
				num3 = flag14;
				IntPtr cachedPtr2 = ((UnityEngine.Object)doilieMask2).m_CachedPtr;
				bool flag15 = ((UnityEngine.Object)doilieMask2).m_CachedPtr == (IntPtr)0;
				num4 = flag15;
				object obj6 = 0;
				ret = (Rect)0;
				object obj7 = 0;
			}
			else
			{
				bool flag16 = (object)_DoilieMask == null;
				num3 = flag16;
				IntPtr cachedPtr2 = ((UnityEngine.Object)doilieMask2).m_CachedPtr;
				bool flag17 = ((UnityEngine.Object)doilieMask2).m_CachedPtr == (IntPtr)0;
				num4 = flag17;
				object obj6 = 0;
				bool flag18 = (nint)0 != 0;
				ret = (Rect)0;
				object obj7 = 0;
				if (!flag18)
				{
					bool flag19 = (nint)0 == 0;
					num5 = flag19;
					goto IL_02a7;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1540 @ rax_v71 (should have been resolved before IL gen)");
			bool flag20 = (object)rectTransform == null;
			num5 = flag20;
			goto IL_02a7;
			IL_02a7:
			rectTransform.anchoredPosition = anchoredPosition;
			bool flag21 = (object)obj.g == null;
			Image i = obj.g.AddComponent<Image>();
			obj.i = i;
			bool flag22 = (object)obj.g == null;
			RectTransform component = obj.g.GetComponent<RectTransform>();
			GameObject doilies = (GameObject)(object)_Doilies;
			bool flag23 = _Doilies == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [189999098] (should have been resolved before IL gen)");
		}
	}

	private unsafe void SetDisplayType()
	{
		//IL_0069: Expected O, but got Ref
		//IL_0072: Expected O, but got I4
		//IL_00cd: Expected I, but got O
		//IL_0158: Expected O, but got I4
		//IL_0105: Expected O, but got I
		//IL_010e: Expected O, but got I4
		//IL_0286: Expected O, but got I
		//IL_028f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0294: Expected O, but got Unknown
		//IL_029c: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a1: Expected O, but got Unknown
		//IL_011c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0121: Expected O, but got Unknown
		//IL_024b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0250: Expected O, but got Unknown
		//IL_025e: Expected I, but got O
		//IL_01e4: Expected I, but got O
		//IL_0234: Expected I, but got O
		ReInput.PlayerHelper players = ReInput.players;
		if (players != null)
		{
			IList<Rewired.Player> players2 = players.Players;
			if (players2 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				Rewired.Player.ControllerHelper controllerHelper = default(Rewired.Player.ControllerHelper);
				object obj = (object)(&controllerHelper);
				object obj2 = 0;
				Rewired.Player player = null;
				object obj3 = default(object);
				object obj12 = default(object);
				Rewired.Player player2 = default(Rewired.Player);
				while (true)
				{
					object obj4;
					object obj11;
					if (controllerHelper != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
						if (obj3 == null)
						{
							break;
						}
						bool flag = controllerHelper == null;
						player = null;
						if (!flag)
						{
							nint num = (nint)controllerHelper;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ r10_v8 (Il2CppClass<Rewired.Player+ControllerHelper>)+12E]");
							if ((nint)0 >= (nint)0)
							{
								goto IL_0145;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ r10_v8 (Il2CppClass<Rewired.Player+ControllerHelper>)+B0]");
							obj4 = 0;
							object obj5 = 0;
							while (true)
							{
								object obj6 = obj5 + obj5;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v170 @ r8_v14+v518 @ rax_v42*8]");
								if (0 == (nint)typeof(IEnumerator<Rewired.Player>))
								{
									break;
								}
								obj5++;
								object obj7 = obj5;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ r10_v8 (Il2CppClass<Rewired.Player+ControllerHelper>)+12E]");
								if ((nint)obj7 < 0)
								{
									continue;
								}
								goto IL_0145;
							}
							object obj8 = obj5 + obj5;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v170 @ r8_v14+8+v596 @ rcx_v32*8]");
							object obj9 = (nint)0 << 4;
							object obj10 = obj9 + 312;
							obj11 = obj10 + num;
							goto IL_046c;
						}
						throw new NullReferenceException();
					}
					throw new NullReferenceException();
					IL_0145:
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
					obj4 = 0;
					obj11 = obj12;
					goto IL_046c;
					IL_046c:
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v601 @ rdx_v18] (should have been resolved before IL gen)");
					if (player2 != null)
					{
						if (player2.controllers != null)
						{
							int joystickCount = player2.controllers.joystickCount;
							nint num2;
							if (joystickCount <= 0)
							{
								int id = player2.id;
								bool flag2 = id != 0;
								num2 = (nint)typeof(IEnumerator<Rewired.Player>);
								if (flag2)
								{
									continue;
								}
								IBaseAccount account = SystemPlatform.Account;
								if (account == null)
								{
									throw new NullReferenceException();
								}
								bool flag3 = account.DoesPlayer1NeedController();
								num2 = (nint)typeof(IEnumerator<Rewired.Player>);
								if (flag3)
								{
									continue;
								}
							}
							obj2++;
							num2 = (nint)typeof(IEnumerator<Rewired.Player>);
							continue;
						}
						throw new NullReferenceException();
					}
					throw new NullReferenceException();
				}
				if (obj != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
				}
				if (state != State.SINGLEPLAYER)
				{
					if (state == State.MULTIPLAYER && (nint)obj2 < (nint)state)
					{
						MakeDisplaySingleplayer();
					}
					return;
				}
				MultiplayerManager multiplayer = _multiplayer;
				if (_multiplayer != null)
				{
					if (!multiplayer.AllowPlayerJoining)
					{
						return;
					}
					if ((object)_MultiplayerTextPanel != null)
					{
						_MultiplayerTextPanel.SetActive(multiplayer.AllowPlayerJoining);
						if ((nint)obj2 >= 1)
						{
							MakeDisplayMultiplayer();
						}
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	protected override void OnEnterPressed()
	{
		//IL_0220: Expected O, but got I4
		LargeMultiOptionPopup aISelectionPopup = _AISelectionPopup;
		if ((object)_AISelectionPopup != null && ((UnityEngine.Object)aISelectionPopup).m_CachedPtr != (IntPtr)0)
		{
			return;
		}
		LargeMultiOptionPopup partySizeSelectionPopup = _PartySizeSelectionPopup;
		if (((object)_PartySizeSelectionPopup != null && ((UnityEngine.Object)partySizeSelectionPopup).m_CachedPtr != (IntPtr)0) || _characterBoughtThisFrame)
		{
			return;
		}
		EventSystem current = EventSystem.current;
		CharacterItemUI component = current.m_CurrentSelected.GetComponent<CharacterItemUI>();
		Button button;
		if ((object)component != null && ((UnityEngine.Object)component).m_CachedPtr != (IntPtr)0)
		{
			int playerCount = _multiplayer.GetPlayerCount();
			if (playerCount > 1 || _multiplayer.IsOnlineMultiplayer)
			{
				CharacterItemUI selectedCharacterItemUI = _selectedCharacterItemUI;
				if (selectedCharacterItemUI._isTaken)
				{
					return;
				}
			}
			CharacterItemUI selectedCharacterItemUI2 = _selectedCharacterItemUI;
			if (_selectedCharacterItemUI.IsCharUnlockable())
			{
				goto IL_033c;
			}
			if (_selectedCharacterItemUI.IsCharAvailable())
			{
				SkinItem currentSkinItem = selectedCharacterItemUI2._charItem.GetCurrentSkinItem();
				bool flag = currentSkinItem == null;
				bool flag2 = false;
				if (!flag)
				{
					object obj = currentSkinItem._unlockState - 1;
					bool flag3 = obj == null;
					flag2 = flag3;
				}
				if (flag2)
				{
					goto IL_033c;
				}
			}
			bool flag4 = _selectedCharacterItemUI.IsPurchasable();
			if (!flag4)
			{
				if (_characterConfirmed == flag4)
				{
					SelectCharacter(fromUnlock: false);
					button = StartButton;
					goto IL_049a;
				}
				return;
			}
			int playerCount2 = _multiplayer.GetPlayerCount();
			if (playerCount2 > 1 || _multiplayer.IsOnlineMultiplayer)
			{
				Rewired.Player selectedPlayer = _multiplayer.GetSelectedPlayer();
				if (selectedPlayer.id != 0)
				{
					return;
				}
			}
			SelectCharacter(fromUnlock: false);
			return;
		}
		Debug.Log("Current selection is not a CharacterItemUI, returning");
		return;
		IL_049a:
		button.Select();
		return;
		IL_033c:
		if (_selectedCharacterItemUI.IsCharAvailable() && _selectedCharacterItemUI.IsSkinUnlockable())
		{
			Button component2 = Icon.GetComponent<Button>();
			if ((object)component2 != null && ((UnityEngine.Object)component2).m_CachedPtr != (IntPtr)0)
			{
				button = component2;
				goto IL_049a;
			}
		}
	}

	private unsafe LargeMultiOptionPopup ShowPartySizePopup()
	{
		//IL_0116: Expected O, but got Ref
		//IL_020b: Expected I4, but got O
		//IL_025b: Expected I, but got O
		//IL_0271: Expected O, but got I
		//IL_027a: Unknown result type (might be due to invalid IL or missing references)
		//IL_027f: Expected O, but got Unknown
		//IL_02f5: Expected I, but got O
		//IL_038a: Expected O, but got I4
		//IL_03a1: Expected I, but got I8
		//IL_03cd: Expected I4, but got O
		//IL_02d1: Expected I, but got I8
		List<MPPlayerItem> playerSlots = _playerSlots;
		Action<MPPlayerItem> action = _003C_003Ec._003C_003E9__115_0;
		if (_003C_003Ec._003C_003E9__115_0 == null)
		{
			action = (_003C_003Ec._003C_003E9__115_0 = delegate(MPPlayerItem player)
			{
				player._PlayerState = MPPlayerItem.PlayerState.INACTIVE;
			});
		}
		if (action == null)
		{
			goto IL_0334;
		}
		bool flag = playerSlots._size <= 0;
		bool flag2 = false;
		if (flag)
		{
			goto IL_00a0;
		}
		while (playerSlots._version == playerSlots._version)
		{
			MPPlayerItem[] items = playerSlots._items;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v90 @ rsi_v2 (System.Action`1<MPPlayerItem>)+18] (should have been resolved before IL gen)");
			flag2 = (byte)((flag2 ? 1u : 0u) + 1u) != 0;
			if ((flag2 ? 1 : 0) < playerSlots._size)
			{
				continue;
			}
			goto IL_00a0;
		}
		goto IL_0343;
		IL_00a0:
		if (playerSlots._version != playerSlots._version)
		{
			goto IL_0343;
		}
		MultiplayerManager multiplayer = _multiplayer;
		multiplayer.AllowPlayerJoining = false;
		List<OptionDataSet> list = new List<OptionDataSet>();
		int num = 2;
		object obj = default(object);
		do
		{
			string title = System.Number.FormatInt32(num, (ReadOnlySpan<char>)(&obj), null);
			OptionDataSet item = new OptionDataSet(title, "");
			int version = list._version + 1;
			list._version = version;
			OptionDataSet[] items2 = list._items;
			if (list._size >= items2.Length)
			{
				((List<object>)(object)list).AddWithResize((object)item);
			}
			else
			{
				int size = list._size + 1;
				list._size = size;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			num++;
		}
		while (num <= 4);
		Action<int> action2 = null;
		((CharacterSelectionPage)(object)action2)._003CShowPartySizePopup_003Eb__115_1((int)this);
		Action action3 = null;
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v481 @ r10_v1 (Il2CppMethodInfo)+8]");
		((Delegate)action3).method_ptr = (IntPtr)0;
		((Delegate)action3).method = (nint)__ldftn(CharacterSelectionPage._003CShowPartySizePopup_003Eb__115_2);
		((Delegate)action3).m_target = this;
		((Delegate)action3).method_code = (IntPtr)action3;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v481 @ r10_v1 (Il2CppMethodInfo)+4C]");
		object obj2 = (nint)0 >> 4;
		object obj3 = obj2 & 1;
		nint num3;
		if (obj3 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v481 @ r10_v1 (Il2CppMethodInfo)+52]");
			if ((nint)0 == 0)
			{
				num3 = unchecked((nint)6447293664L);
				goto IL_0381;
			}
		}
		num3 = ((Delegate)action3).method_ptr;
		((Delegate)action3).method_code = (IntPtr)((Delegate)action3).m_target;
		goto IL_0381;
		IL_0381:
		object obj4 = 24;
		((Delegate)action3).extra_arg = unchecked((nint)6447293568L);
		Action<int> callback = default(Action<int>);
		Action closedCallback = default(Action);
		bool textIsLocalizationTerm = default(bool);
		TextAlignmentOptions? textAlignment = default(TextAlignmentOptions?);
		return PopupManager.CreateLargeMultiOption("partySize", "partyLang/PartySize", "", list, callback, closedCallback, textIsLocalizationTerm, textAlignment, (byte)(int)action2 != 0);
		IL_0343:
		System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
		goto IL_0334;
		IL_0334:
		System.ThrowHelper.ThrowArgumentNullException(System.ExceptionArgument.action);
		LargeMultiOptionPopup result = default(LargeMultiOptionPopup);
		return result;
	}

	protected unsafe override void OnHideFinish(GameObject g)
	{
		//IL_00ab: Expected I, but got O
		//IL_00f5: Expected O, but got I
		//IL_01f0: Expected F4, but got I4
		//IL_0213: Expected F4, but got I4
		//IL_02e6: Expected I, but got O
		//IL_02fc: Expected O, but got I
		//IL_0305: Unknown result type (might be due to invalid IL or missing references)
		//IL_030a: Expected O, but got Unknown
		//IL_0373: Expected I, but got O
		//IL_07d3: Expected O, but got I4
		//IL_07ea: Expected I, but got I8
		//IL_035c: Expected I, but got I8
		//IL_04b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_04bc: Expected O, but got Unknown
		//IL_0520: Unknown result type (might be due to invalid IL or missing references)
		//IL_0525: Expected O, but got Unknown
		//IL_0550: Expected I, but got O
		//IL_0566: Expected O, but got I
		//IL_056f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0574: Expected O, but got Unknown
		//IL_05dd: Expected I, but got O
		//IL_0912: Expected O, but got I4
		//IL_0929: Expected I, but got I8
		//IL_05c6: Expected I, but got I8
		//IL_0616: Unknown result type (might be due to invalid IL or missing references)
		//IL_061b: Expected O, but got Unknown
		//IL_067f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0684: Expected O, but got Unknown
		//IL_014a->IL0727: Incompatible stack heights: 1 vs 0
		//IL_0834->IL03c6: Incompatible stack heights: 1 vs 0
		base.OnHideFinish(g);
		_partySize = 0;
		MultiplayerManager multiplayer;
		MultiplayerManager.OnRefresh onRefresh;
		if ((object)BackButtonController.Instance != null)
		{
			Button component = BackButtonController.Instance.GetComponent<Button>();
			if ((object)component != null)
			{
				Button.ButtonClickedEvent onClick = component.m_OnClick;
				UnityAction unityAction = HandleBackButton;
				if (component.m_OnClick != null && unityAction != null)
				{
					nint num = (nint)unityAction;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v546 @ rdx_v11 (Il2CppClass<UnityEngine.GameObject>)+1B8] (should have been resolved before IL gen)");
					if (((UnityEventBase)onClick).m_Calls != null)
					{
						UnityEngine.Events.InvokableCallList calls = ((UnityEventBase)onClick).m_Calls;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v431 @ rax_v22 (UnityEngine.Events.UnityAction)+20]");
						MethodInfo method = default(MethodInfo);
						calls.RemoveListener(0, method);
						if (_playerSlots != null)
						{
							List<MPPlayerItem>.Enumerator enumerator = default(List<MPPlayerItem>.Enumerator);
							while (enumerator.MoveNext())
							{
								GameObject gameObject = null;
								bool flag = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
								IntPtr gcHandlePtr = Component.get_gameObject_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
								GameObject obj = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr);
								UnityEngine.Object.Destroy(obj, 0f);
							}
							List<MPPlayerItem> playerSlots = _playerSlots;
							if (_playerSlots != null)
							{
								int version = playerSlots._version + 1;
								playerSlots._version = version;
								playerSlots._size = 0;
								if (playerSlots._size > 0)
								{
									Array.Clear(playerSlots._items, 0, playerSlots._size);
								}
								if (_spawned != null)
								{
									float num2 = 0f;
									List<GameObject>.Enumerator enumerator2 = default(List<GameObject>.Enumerator);
									while (enumerator2.MoveNext())
									{
										UnityEngine.Object.Destroy(null, 0f);
										num2 = 0f;
									}
									List<GameObject> spawned = _spawned;
									if (_spawned != null)
									{
										int version2 = spawned._version + 1;
										spawned._version = version2;
										spawned._size = 0;
										if (spawned._size > 0)
										{
											Array.Clear(spawned._items, 0, spawned._size);
										}
										multiplayer = _multiplayer;
										onRefresh = null;
										nint num3 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v166 @ r9_v12 (Il2CppMethodInfo)+8]");
										((Delegate)onRefresh).method_ptr = (IntPtr)0;
										((Delegate)onRefresh).method = (nint)__ldftn(CharacterSelectionPage.RefreshCharacters);
										((Delegate)onRefresh).m_target = this;
										((Delegate)onRefresh).method_code = (IntPtr)onRefresh;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v166 @ r9_v12 (Il2CppMethodInfo)+4C]");
										object obj2 = (nint)0 >> 4;
										object obj3 = obj2 & 1;
										nint num4;
										if (obj3 != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v166 @ r9_v12 (Il2CppMethodInfo)+52]");
											if ((nint)0 == 0)
											{
												num4 = unchecked((nint)6447293664L);
												goto IL_07ca;
											}
										}
										((Delegate)onRefresh).method_code = (IntPtr)((Delegate)onRefresh).m_target;
										num4 = ((Delegate)onRefresh).method_ptr;
										goto IL_07ca;
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_06a2;
		IL_0909:
		object obj4 = 24;
		Action action;
		((Delegate)action).extra_arg = unchecked((nint)6447293568L);
		bool throwIfMissing = default(bool);
		if (_signalBus != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj6 = default(object);
			object obj5 = obj6 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			Type signalType = default(Type);
			_signalBus.UnsubscribeInternal(signalType, (object)null, (object)action, throwIfMissing);
			Action<UISignals.SetCharacterSelectionPageVisibility> token = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9DDE0");
			if (_signalBus != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
				object obj8 = default(object);
				object obj7 = obj8 + 32;
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
				Type signalType2 = default(Type);
				_signalBus.UnsubscribeInternal(signalType2, (object)null, (object)token, throwIfMissing);
				return;
			}
		}
		goto IL_06a2;
		IL_06a2:
		throw new NullReferenceException();
		IL_07ca:
		object obj9 = 24;
		((Delegate)onRefresh).extra_arg = unchecked((nint)6447293568L);
		if (_multiplayer != null)
		{
			GameObject gameObject2 = (GameObject)(object)multiplayer.RefreshUI;
			bool flag6;
			do
			{
				Delegate obj10 = Delegate.Remove((Delegate)(object)gameObject2, onRefresh);
				bool flag2 = (object)obj10 == null;
				Delegate obj11 = null;
				if (!flag2)
				{
					bool flag3 = (object)obj10.GetType() != typeof(MultiplayerManager.OnRefresh);
					obj11 = null;
					if (!flag3)
					{
						obj11 = obj10;
					}
					bool flag4 = (object)obj11 == null;
				}
				bool flag5 = (object)gameObject2 == multiplayer.RefreshUI;
				GameObject gameObject3;
				if ((object)gameObject2 == multiplayer.RefreshUI)
				{
					multiplayer.RefreshUI = (MultiplayerManager.OnRefresh)obj11;
					gameObject3 = gameObject2;
				}
				else
				{
					gameObject3 = (GameObject)(object)multiplayer.RefreshUI;
				}
				GameObject gameObject4 = gameObject2;
				if (!flag5)
				{
					gameObject4 = gameObject3;
				}
				flag6 = (object)gameObject4 != gameObject2;
				gameObject2 = gameObject4;
			}
			while (flag6);
			Action<UISignals.AddNewCharactersToSelectionPageSignal> token2 = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9DC20");
			if (_signalBus != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
				object obj13 = default(object);
				object obj12 = obj13 + 32;
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
				Type signalType3 = default(Type);
				_signalBus.UnsubscribeInternal(signalType3, (object)null, (object)token2, throwIfMissing);
				Action<UISignals.ForceSelectionOnCharacterSelectionPageSignal> token3 = null;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9DD00");
				if (_signalBus != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
					object obj15 = default(object);
					object obj14 = obj15 + 32;
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
					Type signalType4 = default(Type);
					_signalBus.UnsubscribeInternal(signalType4, (object)null, (object)token3, throwIfMissing);
					action = null;
					nint num5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v169 @ r9_v15 (Il2CppMethodInfo)+8]");
					((Delegate)action).method_ptr = (IntPtr)0;
					((Delegate)action).method = (nint)__ldftn(CharacterSelectionPage.SpawnMinorDoilie);
					((Delegate)action).m_target = this;
					((Delegate)action).method_code = (IntPtr)action;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v169 @ r9_v15 (Il2CppMethodInfo)+4C]");
					object obj16 = (nint)0 >> 4;
					object obj17 = obj16 & 1;
					nint num6;
					if (obj17 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v169 @ r9_v15 (Il2CppMethodInfo)+52]");
						if ((nint)0 == 0)
						{
							num6 = unchecked((nint)6447293664L);
							goto IL_0909;
						}
					}
					((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
					num6 = ((Delegate)action).method_ptr;
					goto IL_0909;
				}
			}
		}
		goto IL_06a2;
	}

	private void Detune()
	{
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Detune = 200f;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.ClickIn, soundConfig, 0f, 10, time);
	}

	private unsafe void setupRNJ(CharacterData dat, CharacterType cType)
	{
		//IL_0029: Expected O, but got I4
		//IL_006d: Expected O, but got I4
		//IL_0085: Expected O, but got I4
		//IL_008d: Expected O, but got Ref
		//IL_0637: Expected O, but got I4
		//IL_03dc: Expected O, but got I
		//IL_03ec: Expected O, but got I
		//IL_06d9: Expected O, but got I4
		//IL_04c2: Expected I, but got O
		//IL_044c: Expected I, but got O
		//IL_051b: Expected I, but got O
		//IL_052e: Expected O, but got Ref
		//IL_0557: Expected O, but got I4
		CharacterType characterType = default(CharacterType);
		if (characterType != CharacterType.ARENGIJUS)
		{
			return;
		}
		dat._003CstartingWeapon_003Ek__BackingField = (WeaponType?)(object)1;
		dat._003CspriteName_003Ek__BackingField = "random_00";
		Dictionary<WeaponType, List<WeaponData>> convertedWeapons = _dataManager.GetConvertedWeapons();
		List<WeaponType> list = new List<WeaponType>();
		object obj = 2;
		Dictionary<WeaponType, List<WeaponData>>.Enumerator enumerator = default(Dictionary<WeaponType, List<WeaponData>>.Enumerator);
		if (enumerator.MoveNext())
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
			object obj2 = 0;
			Dictionary<WeaponType, List<WeaponData>>.Enumerator enumerator2 = (Dictionary<WeaponType, List<WeaponData>>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v791 @ rax_v15 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		object obj3 = UnityEngine.Random.RandomRangeInt(0, 0);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v791 @ rax_v15 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		PlayerOptionsData playerOptionsData;
		if ((nint)obj3 < 0)
		{
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
							goto IL_0683;
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
			goto IL_0683;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		throw new IndexOutOfRangeException();
		IL_0683:
		bool flag = default(bool);
		GameObject localParametersRoot = default(GameObject);
		string overrideLanguage = default(string);
		bool allowLocalizedParameters = default(bool);
		if (playerOptionsData._003CPlayedRNJ_003Ek__BackingField <= 0)
		{
			string translation = LocalizationManager.GetTranslation("characterLang/{ARENGIJUS}charName", FixForRTL: true, 0, ignoreRTLnumbers: true, flag, localParametersRoot, overrideLanguage, allowLocalizedParameters);
			dat._003CcharName_003Ek__BackingField = translation;
		}
		else
		{
			string translation2 = LocalizationManager.GetTranslation("lang/arengijus_aliases", FixForRTL: true, 0, ignoreRTLnumbers: true, flag, localParametersRoot, overrideLanguage, allowLocalizedParameters);
			bool flag2 = "," != null;
			string separator = ",";
			if (!flag2)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF00]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1658 @ rax_v105+B8]");
				object obj5 = 0;
				separator = (string)obj5;
			}
			string[] array = translation2.SplitInternal(separator, (string[])null, 2147483647, flag ? StringSplitOptions.RemoveEmptyEntries : StringSplitOptions.None);
			object obj6 = UnityEngine.Random.RandomRangeInt(0, array.Length);
			dat._003CcharName_003Ek__BackingField = array[obj6];
			DataManager dataManager = _dataManager;
			object obj7 = ((Dictionary<System.Int32Enum, object>)(object)dataManager._003CAllCharacters_003Ek__BackingField).get_Item((System.Int32Enum)64);
			nint num = (nint)obj7;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1790 @ r8_v22 (Il2CppClass<System.Object>)+678] (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9DF80");
			long value = default(long);
			JValue jValue = new JValue(value);
			object obj9 = default(object);
			object obj8 = obj9;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1563 @ r10_v9+258] (should have been resolved before IL gen)");
			dat._003CspriteName_003Ek__BackingField = "random_99";
		}
		DataManager dataManager2 = _dataManager;
		object obj10 = ((Dictionary<System.Int32Enum, object>)(object)dataManager2._003CAllCharacters_003Ek__BackingField).get_Item((System.Int32Enum)64);
		nint num2 = (nint)obj10;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1675 @ r8_v9 (Il2CppClass<System.Object>)+678] (should have been resolved before IL gen)");
		JValue jValue2 = new JValue((object)dat._003CcharName_003Ek__BackingField, JTokenType.String);
		object obj12 = default(object);
		object obj11 = obj12;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v215 @ r10_v6+258] (should have been resolved before IL gen)");
		DataManager dataManager3 = _dataManager;
		object obj13 = ((Dictionary<System.Int32Enum, object>)(object)dataManager3._003CAllCharacters_003Ek__BackingField).get_Item((System.Int32Enum)64);
		nint num3 = (nint)obj13;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1822 @ r8_v14 (Il2CppClass<System.Object>)+678] (should have been resolved before IL gen)");
		IntPtr intPtr = default(IntPtr);
		string value2 = ((Enum)(&intPtr)).ToString();
		JValue jValue3 = new JValue((object)value2, JTokenType.String);
		object obj15 = default(object);
		object obj14 = obj15;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v80 @ r10_v7+258] (should have been resolved before IL gen)");
		dat._003CstartingWeapon_003Ek__BackingField = (WeaponType?)(object)1;
	}

	private void setupMIS(CharacterData ddata, CharacterType cType)
	{
		//IL_0072: Expected I, but got O
		//IL_0817: Expected O, but got F4
		//IL_00ea: Expected I, but got O
		//IL_0845: Expected O, but got F4
		//IL_013e: Expected I, but got O
		//IL_088c: Expected O, but got F4
		//IL_0192: Expected I, but got O
		//IL_08c4: Expected O, but got F4
		//IL_01e6: Expected I, but got O
		//IL_090b: Expected O, but got F4
		//IL_023a: Expected I, but got O
		//IL_095c: Expected O, but got F4
		//IL_028e: Expected I, but got O
		//IL_09a3: Expected O, but got F4
		//IL_02e2: Expected I, but got O
		//IL_09eb: Expected O, but got F4
		//IL_0336: Expected I, but got O
		//IL_0a32: Expected O, but got F4
		//IL_038a: Expected I, but got O
		//IL_0a7a: Expected O, but got F4
		//IL_03de: Expected I, but got O
		//IL_0ac1: Expected O, but got F4
		//IL_0432: Expected I, but got O
		//IL_0b08: Expected O, but got F4
		//IL_0486: Expected I, but got O
		//IL_0b4f: Expected O, but got F4
		//IL_04da: Expected I, but got O
		//IL_0b96: Expected O, but got F4
		//IL_052e: Expected I, but got O
		//IL_0bdd: Expected O, but got F4
		//IL_0582: Expected I, but got O
		//IL_0c24: Expected O, but got F4
		//IL_0c6b: Expected O, but got F4
		//IL_0c79: Expected O, but got I4
		//IL_05cc: Expected I, but got O
		//IL_063f: Expected I, but got O
		//IL_0ca2: Expected O, but got I4
		//IL_068e: Expected O, but got I
		//IL_0724: Expected I, but got O
		//IL_0cce: Expected O, but got F4
		//IL_077a: Expected I4, but got O
		//IL_0cec: Expected O, but got F4
		//IL_07a5: Expected I4, but got O
		//IL_07ee->IL0d01: Incompatible stack heights: 1 vs 0
		if (cType == CharacterType.FINO)
		{
			PlayerOptionsData config = _playerOptions.Config;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9ACE0");
			object obj = default(object);
			if (obj != null)
			{
				DataManager dataManager = _dataManager;
				object obj2 = ((Dictionary<System.Int32Enum, object>)(object)dataManager._003CAllCharacters_003Ek__BackingField).get_Item((System.Int32Enum)cType);
				nint num = (nint)obj2;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1598 @ r8_v27 (Il2CppClass<System.Object>)+678] (should have been resolved before IL gen)");
				object obj3 = UnityEngine.Random.value;
				object obj4 = default(object);
				float num2 = (float)obj4 - 0.025f;
				float num3 = (ddata._003CmaxHp_003Ek__BackingField = num2 * 100f);
				JToken jToken = num3;
				object obj6 = default(object);
				object obj5 = obj6;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v158 @ r10_v26+258] (should have been resolved before IL gen)");
				DataManager dataManager2 = _dataManager;
				object obj7 = ((Dictionary<System.Int32Enum, object>)(object)dataManager2._003CAllCharacters_003Ek__BackingField).get_Item((System.Int32Enum)46);
				nint num4 = (nint)obj7;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1794 @ r8_v31 (Il2CppClass<System.Object>)+678] (should have been resolved before IL gen)");
				object obj8 = UnityEngine.Random.value;
				float num5 = num3 - 0.1f;
				float num6 = (ddata._003Carmor_003Ek__BackingField = num5 + num5);
				JToken jToken2 = num6;
				object obj10 = default(object);
				object obj9 = obj10;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v159 @ r10_v27+258] (should have been resolved before IL gen)");
				DataManager dataManager3 = _dataManager;
				object obj11 = ((Dictionary<System.Int32Enum, object>)(object)dataManager3._003CAllCharacters_003Ek__BackingField).get_Item((System.Int32Enum)46);
				nint num7 = (nint)obj11;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1932 @ r8_v35 (Il2CppClass<System.Object>)+678] (should have been resolved before IL gen)");
				object obj12 = UnityEngine.Random.value;
				float num8 = (ddata._003Cregen_003Ek__BackingField = num6 - 0.5f);
				JToken jToken3 = num8;
				object obj14 = default(object);
				object obj13 = obj14;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v160 @ r10_v28+258] (should have been resolved before IL gen)");
				DataManager dataManager4 = _dataManager;
				object obj15 = ((Dictionary<System.Int32Enum, object>)(object)dataManager4._003CAllCharacters_003Ek__BackingField).get_Item((System.Int32Enum)46);
				nint num9 = (nint)obj15;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2046 @ r8_v39 (Il2CppClass<System.Object>)+678] (should have been resolved before IL gen)");
				object obj16 = UnityEngine.Random.value;
				float num10 = num8 - 0.5f;
				float num11 = (ddata._003CmoveSpeed_003Ek__BackingField = num10 + num10);
				JToken jToken4 = num11;
				object obj18 = default(object);
				object obj17 = obj18;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v161 @ r10_v29+258] (should have been resolved before IL gen)");
				DataManager dataManager5 = _dataManager;
				object obj19 = ((Dictionary<System.Int32Enum, object>)(object)dataManager5._003CAllCharacters_003Ek__BackingField).get_Item((System.Int32Enum)46);
				nint num12 = (nint)obj19;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2200 @ r8_v43 (Il2CppClass<System.Object>)+678] (should have been resolved before IL gen)");
				object obj20 = UnityEngine.Random.value;
				float num13 = num11 - 0.1f;
				double num14 = (double)num13 + (double)num13;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm0,xmm0\"");
				ddata._003Cpower_003Ek__BackingField = num14;
				JToken jToken5 = num14;
				object obj22 = default(object);
				object obj21 = obj22;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v162 @ r10_v30+258] (should have been resolved before IL gen)");
				DataManager dataManager6 = _dataManager;
				object obj23 = ((Dictionary<System.Int32Enum, object>)(object)dataManager6._003CAllCharacters_003Ek__BackingField).get_Item((System.Int32Enum)46);
				nint num15 = (nint)obj23;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2317 @ r8_v47 (Il2CppClass<System.Object>)+678] (should have been resolved before IL gen)");
				object obj24 = UnityEngine.Random.value;
				double num16 = num14 - 0.10000000149011612;
				float num17 = (ddata._003Ccooldown_003Ek__BackingField = (float)num16 + (float)num16);
				JToken jToken6 = num17;
				object obj26 = default(object);
				object obj25 = obj26;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v163 @ r10_v31+258] (should have been resolved before IL gen)");
				DataManager dataManager7 = _dataManager;
				object obj27 = ((Dictionary<System.Int32Enum, object>)(object)dataManager7._003CAllCharacters_003Ek__BackingField).get_Item((System.Int32Enum)46);
				nint num18 = (nint)obj27;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2430 @ r8_v51 (Il2CppClass<System.Object>)+678] (should have been resolved before IL gen)");
				object obj28 = UnityEngine.Random.value;
				float num19 = num17 - 0.1f;
				float num20 = (ddata._003Carea_003Ek__BackingField = num19 * 4f);
				JToken jToken7 = num20;
				object obj30 = default(object);
				object obj29 = obj30;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v164 @ r10_v32+258] (should have been resolved before IL gen)");
				DataManager dataManager8 = _dataManager;
				object obj31 = ((Dictionary<System.Int32Enum, object>)(object)dataManager8._003CAllCharacters_003Ek__BackingField).get_Item((System.Int32Enum)46);
				nint num21 = (nint)obj31;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2583 @ r8_v55 (Il2CppClass<System.Object>)+678] (should have been resolved before IL gen)");
				object obj32 = UnityEngine.Random.value;
				float num22 = num20 - 0.1f;
				float num23 = (ddata._003Cspeed_003Ek__BackingField = num22 + num22);
				JToken jToken8 = num23;
				object obj34 = default(object);
				object obj33 = obj34;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v165 @ r10_v33+258] (should have been resolved before IL gen)");
				DataManager dataManager9 = _dataManager;
				object obj35 = ((Dictionary<System.Int32Enum, object>)(object)dataManager9._003CAllCharacters_003Ek__BackingField).get_Item((System.Int32Enum)46);
				nint num24 = (nint)obj35;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2696 @ r8_v59 (Il2CppClass<System.Object>)+678] (should have been resolved before IL gen)");
				object obj36 = UnityEngine.Random.value;
				float num25 = num23 - 0.1f;
				float num26 = (ddata._003Cduration_003Ek__BackingField = num25 * 3f);
				JToken jToken9 = num26;
				object obj38 = default(object);
				object obj37 = obj38;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v166 @ r10_v34+258] (should have been resolved before IL gen)");
				DataManager dataManager10 = _dataManager;
				object obj39 = ((Dictionary<System.Int32Enum, object>)(object)dataManager10._003CAllCharacters_003Ek__BackingField).get_Item((System.Int32Enum)46);
				nint num27 = (nint)obj39;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2724 @ r8_v63 (Il2CppClass<System.Object>)+678] (should have been resolved before IL gen)");
				object obj40 = UnityEngine.Random.value;
				float num28 = num26 - 0.1f;
				float num29 = (ddata._003Camount_003Ek__BackingField = num28 + num28);
				JToken jToken10 = num29;
				object obj42 = default(object);
				object obj41 = obj42;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v167 @ r10_v35+258] (should have been resolved before IL gen)");
				DataManager dataManager11 = _dataManager;
				object obj43 = ((Dictionary<System.Int32Enum, object>)(object)dataManager11._003CAllCharacters_003Ek__BackingField).get_Item((System.Int32Enum)46);
				nint num30 = (nint)obj43;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2752 @ r8_v67 (Il2CppClass<System.Object>)+678] (should have been resolved before IL gen)");
				object obj44 = UnityEngine.Random.value;
				float num31 = num29 - 0.1f;
				float num32 = (ddata._003Cluck_003Ek__BackingField = num31 + num31);
				JToken jToken11 = num32;
				object obj46 = default(object);
				object obj45 = obj46;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v168 @ r10_v36+258] (should have been resolved before IL gen)");
				DataManager dataManager12 = _dataManager;
				object obj47 = ((Dictionary<System.Int32Enum, object>)(object)dataManager12._003CAllCharacters_003Ek__BackingField).get_Item((System.Int32Enum)46);
				nint num33 = (nint)obj47;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2780 @ r8_v71 (Il2CppClass<System.Object>)+678] (should have been resolved before IL gen)");
				object obj48 = UnityEngine.Random.value;
				float num34 = num32 - 0.1f;
				float num35 = (ddata._003Cgrowth_003Ek__BackingField = num34 + num34);
				JToken jToken12 = num35;
				object obj50 = default(object);
				object obj49 = obj50;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v169 @ r10_v37+258] (should have been resolved before IL gen)");
				DataManager dataManager13 = _dataManager;
				object obj51 = ((Dictionary<System.Int32Enum, object>)(object)dataManager13._003CAllCharacters_003Ek__BackingField).get_Item((System.Int32Enum)46);
				nint num36 = (nint)obj51;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2808 @ r8_v75 (Il2CppClass<System.Object>)+678] (should have been resolved before IL gen)");
				object obj52 = UnityEngine.Random.value;
				float num37 = num35 - 0.1f;
				float num38 = (ddata._003Cgreed_003Ek__BackingField = num37 + num37);
				JToken jToken13 = num38;
				object obj54 = default(object);
				object obj53 = obj54;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v170 @ r10_v38+258] (should have been resolved before IL gen)");
				DataManager dataManager14 = _dataManager;
				object obj55 = ((Dictionary<System.Int32Enum, object>)(object)dataManager14._003CAllCharacters_003Ek__BackingField).get_Item((System.Int32Enum)46);
				nint num39 = (nint)obj55;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2836 @ r8_v79 (Il2CppClass<System.Object>)+678] (should have been resolved before IL gen)");
				object obj56 = UnityEngine.Random.value;
				float num40 = num38 - 0.1f;
				float num41 = (ddata._003Cmagnet_003Ek__BackingField = num40 + num40);
				JToken jToken14 = num41;
				object obj58 = default(object);
				object obj57 = obj58;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v171 @ r10_v39+258] (should have been resolved before IL gen)");
				DataManager dataManager15 = _dataManager;
				object obj59 = ((Dictionary<System.Int32Enum, object>)(object)dataManager15._003CAllCharacters_003Ek__BackingField).get_Item((System.Int32Enum)46);
				nint num42 = (nint)obj59;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2864 @ r8_v83 (Il2CppClass<System.Object>)+678] (should have been resolved before IL gen)");
				object obj60 = UnityEngine.Random.value;
				float num43 = num41 - 0.1f;
				float num44 = (ddata._003Crevivals_003Ek__BackingField = num43 + num43);
				JToken jToken15 = num44;
				object obj62 = default(object);
				object obj61 = obj62;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v172 @ r10_v40+258] (should have been resolved before IL gen)");
				DataManager dataManager16 = _dataManager;
				object obj63 = ((Dictionary<System.Int32Enum, object>)(object)dataManager16._003CAllCharacters_003Ek__BackingField).get_Item((System.Int32Enum)46);
				nint num45 = (nint)obj63;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2892 @ r8_v87 (Il2CppClass<System.Object>)+678] (should have been resolved before IL gen)");
				object obj64 = UnityEngine.Random.value;
				float num46 = num44 - 0.025f;
				float num47 = (ddata._003Ccurse_003Ek__BackingField = num46 + num46);
				JToken jToken16 = num47;
				object obj66 = default(object);
				object obj65 = obj66;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v173 @ r10_v41+258] (should have been resolved before IL gen)");
				object obj67 = UnityEngine.Random.value;
				ddata._003CstartingWeapon_003Ek__BackingField = (WeaponType?)(object)1;
				DataManager dataManager17 = _dataManager;
				object obj68 = ((Dictionary<System.Int32Enum, object>)(object)dataManager17._003CAllCharacters_003Ek__BackingField).get_Item((System.Int32Enum)46);
				nint num48 = (nint)obj68;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2958 @ r8_v91 (Il2CppClass<System.Object>)+678] (should have been resolved before IL gen)");
				System.Int32Enum? int32Enum = default(System.Int32Enum?);
				string text = int32Enum.ToString();
				JToken jToken17 = text;
				object obj70 = default(object);
				object obj69 = obj70;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v174 @ r10_v42+258] (should have been resolved before IL gen)");
				DataManager dataManager18 = _dataManager;
				object obj71 = ((Dictionary<System.Int32Enum, object>)(object)dataManager18._003CAllCharacters_003Ek__BackingField).get_Item((System.Int32Enum)46);
				nint num49 = (nint)obj71;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2980 @ r8_v95 (Il2CppClass<System.Object>)+678] (should have been resolved before IL gen)");
				int[] array = new int[9] { 109, 105, 115, 115, 105, 110, 103, 78, 0 };
				List<int> weirdCharacters = _weirdCharacters;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ r15_v27 (System.Collections.Generic.List`1<System.Int32>)+18]");
				object obj72 = UnityEngine.Random.RandomRangeInt(0, 0);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ r15_v27 (System.Collections.Generic.List`1<System.Int32>)+18]");
				bool flag = (nint)obj72 >= 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ r15_v27 (System.Collections.Generic.List`1<System.Int32>)+10]");
				object obj73 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v474 @ rcx_v166+20+v412 @ rax_v202*4]");
				array[8] = 0;
				string text2 = (ddata.charName = CharCodeToString(array));
				JToken jToken18 = text2;
				object obj75 = default(object);
				object obj74 = obj75;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v175 @ r10_v43+258] (should have been resolved before IL gen)");
				DataManager dataManager19 = _dataManager;
				object obj76 = ((Dictionary<System.Int32Enum, object>)(object)dataManager19._003CAllCharacters_003Ek__BackingField).get_Item((System.Int32Enum)46);
				nint num50 = (nint)obj76;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v3020 @ r8_v101 (Il2CppClass<System.Object>)+678] (should have been resolved before IL gen)");
				int[] array2 = new int[6] { 39, 77, 40, 0, 0, 41 };
				object obj77 = UnityEngine.Random.value;
				float num51 = num47 * 222f;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6F7E8");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
				object obj78 = default(object);
				array2[3] = (int)obj78;
				object obj79 = UnityEngine.Random.value;
				float num52 = num51 * 222f;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6F7E8");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
				object obj80 = default(object);
				array2[4] = (int)obj80;
				string text4 = (ddata.description = CharCodeToString(array2));
				JToken jToken19 = text4;
				object obj82 = default(object);
				object obj81 = obj82;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1497 @ r10_v44+258] (should have been resolved before IL gen)");
			}
		}
	}

	private string CharCodeToString(int[] codes)
	{
		//IL_0139: Expected O, but got I4
		//IL_0152: Expected O, but got I4
		//IL_0040: Expected O, but got I
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Expected O, but got Unknown
		//IL_00f2: Expected I, but got O
		bool flag = codes == null;
		int[] array = codes;
		string text = "";
		object obj = 0;
		int[] array2 = codes;
		IntPtr intPtr = default(IntPtr);
		nint num = intPtr;
		object obj2 = 0;
		if (!flag)
		{
			while (true)
			{
				if ((nint)obj2 < codes.Length)
				{
					if ((nint)obj < codes.Length)
					{
						bool flag2 = codes[obj] > 65535;
						array = array2;
						intPtr = num;
						if (!flag2)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AEF8]");
							object obj3 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v246 @ rcx_v8+E4]");
							if ((nint)0 == 0)
							{
							}
							string text2 = string.FastAllocateString(1);
							bool flag3 = text2 == null;
							array = array2;
							intPtr = num;
							if (flag3)
							{
								break;
							}
							text2._firstChar = (char)codes[obj];
							string text3 = text + text2;
							obj++;
							text = text3;
							array2 = (int[])(object)text2;
							num = unchecked((nint)null);
							obj2 = obj;
							continue;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002BB0");
						Convert.ThrowCharOverflowException();
					}
					return (string)(object)new IndexOutOfRangeException();
				}
				return text;
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void Populate()
	{
		//IL_007d: Expected O, but got I
		//IL_01b8: Expected O, but got I4
		//IL_01d0: Expected O, but got I4
		//IL_01d9: Expected O, but got I4
		//IL_03ad: Expected O, but got I
		//IL_0157: Expected O, but got I
		//IL_0398: Expected O, but got I
		//IL_0383: Expected O, but got I
		//IL_034b: Expected O, but got I
		//IL_071c: Expected O, but got I
		//IL_0707: Expected O, but got I
		//IL_0731: Expected O, but got I
		//IL_06f2: Expected O, but got I
		//IL_050f: Expected O, but got I
		//IL_06ba: Expected O, but got I
		//IL_1522: Expected O, but got I
		//IL_04fa: Expected O, but got I
		//IL_04c0: Expected O, but got I
		//IL_0488: Expected O, but got I
		//IL_05e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e9: Expected O, but got Unknown
		//IL_08ae: Expected O, but got I
		//IL_0899: Expected O, but got I
		//IL_0884: Expected O, but got I
		//IL_08ee: Expected O, but got I
		//IL_084c: Expected O, but got I
		//IL_09df: Expected O, but got I
		//IL_09ca: Expected O, but got I
		//IL_09b5: Expected O, but got I
		//IL_097d: Expected O, but got I
		//IL_0bc2: Expected I4, but got I8
		//IL_0dc4: Expected O, but got I
		//IL_0daf: Expected O, but got I
		//IL_0d9a: Expected O, but got I
		//IL_0d62: Expected O, but got I
		//IL_0f22: Expected O, but got I
		//IL_0f0d: Expected O, but got I
		//IL_0f37: Expected O, but got I
		//IL_0ef8: Expected O, but got I
		//IL_0f79: Expected O, but got I
		//IL_0ec0: Expected O, but got I
		//IL_1008: Expected O, but got I4
		//IL_1915: Expected I4, but got O
		//IL_10d1: Expected O, but got I
		//IL_10bc: Expected O, but got I
		//IL_10a7: Expected O, but got I
		//IL_106f: Expected O, but got I
		//IL_10f6: Expected O, but got Ref
		//IL_1121: Expected I, but got O
		//IL_1835->IL13fc: Incompatible stack heights: 1 vs 0
		//IL_189b->IL13fc: Incompatible stack heights: 2 vs 0
		//IL_18e0->IL13fc: Incompatible stack heights: 2 vs 0
		//IL_0f57->IL13fc: Incompatible stack heights: 2 vs 0
		//IL_0f91->IL13fc: Incompatible stack heights: 2 vs 0
		//IL_1943->IL13fc: Incompatible stack heights: 3 vs 0
		//IL_1988->IL13fc: Incompatible stack heights: 3 vs 0
		//IL_1114->IL13fc: Incompatible stack heights: 3 vs 0
		Dictionary<CharacterType, List<CharacterData>> dictionary;
		if (_dataManager != null)
		{
			Dictionary<CharacterType, List<CharacterData>> convertedCharacterData = _dataManager.GetConvertedCharacterData();
			bool flag = !AdventureManager._003CIsInAdventureMode_003Ek__BackingField;
			dictionary = convertedCharacterData;
			if (flag)
			{
				goto IL_0160;
			}
			Dictionary<CharacterType, List<CharacterData>> dataManager = (Dictionary<CharacterType, List<CharacterData>>)(object)_dataManager;
			if (_dataManager != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v180 @ rsi_v50 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.CharacterType, System.Collections.Generic.List`1<VampireSurvivors.Data.Characters.CharacterData>>)+130]");
				dictionary = (Dictionary<CharacterType, List<CharacterData>>)0;
				AdventureManager adventureManager = _adventureManager;
				if (_adventureManager != null)
				{
					AdventureData adventureData = adventureManager._003CAdventureData_003Ek__BackingField;
					if (adventureManager._003CAdventureData_003Ek__BackingField != null && adventureData._003CCharacterTypes_003Ek__BackingField != null)
					{
						if (!((Dictionary<CharacterType, List<CharacterData>>)(object)adventureData._003CCharacterTypes_003Ek__BackingField).Remove(CharacterType.ANTONIO))
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v180 @ rsi_v50 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.CharacterType, System.Collections.Generic.List`1<VampireSurvivors.Data.Characters.CharacterData>>)+130]");
							if ((nint)0 == 0)
							{
								goto IL_13fc;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v180 @ rsi_v50 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.CharacterType, System.Collections.Generic.List`1<VampireSurvivors.Data.Characters.CharacterData>>)+130]");
							bool flag2 = ((Dictionary<System.Int32Enum, object>)0).Remove((System.Int32Enum)1);
						}
						goto IL_0160;
					}
				}
			}
		}
		goto IL_13fc;
		IL_07c1:
		Dictionary<CharacterType, CharacterItemUI> playerOptions = (Dictionary<CharacterType, CharacterItemUI>)(object)_playerOptions;
		if (_playerOptions == null)
		{
			goto IL_13fc;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ rbx_v28 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.CharacterType, VampireSurvivors.UI.CharacterItemUI>)+68]");
		object obj;
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ rbx_v28 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.CharacterType, VampireSurvivors.UI.CharacterItemUI>)+58]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ rbx_v28 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.CharacterType, VampireSurvivors.UI.CharacterItemUI>)+78]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ rbx_v28 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.CharacterType, VampireSurvivors.UI.CharacterItemUI>)+78]");
					obj = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v245 @ rax_v76+2CC]");
					if ((nint)0 != 0)
					{
						goto IL_16aa;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ rbx_v28 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.CharacterType, VampireSurvivors.UI.CharacterItemUI>)+50]");
				obj = 0;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ rbx_v28 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.CharacterType, VampireSurvivors.UI.CharacterItemUI>)+58]");
				obj = 0;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ rbx_v28 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.CharacterType, VampireSurvivors.UI.CharacterItemUI>)+68]");
			obj = 0;
		}
		goto IL_16aa;
		IL_13fc:
		throw new NullReferenceException();
		IL_1610:
		object obj2;
		Dictionary<CharacterType, CharacterItem> dictionary2;
		if (obj2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v243 @ rax_v73+170]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v243 @ rax_v73+170]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v281 @ rcx_v55+18]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
					object obj4 = default(object);
					if ((nint)obj4 != -1)
					{
						goto IL_07c1;
					}
				}
				Func<KeyValuePair<CharacterType, CharacterItem>, bool> condition = _003C_003Ec._003C_003E9__121_2;
				if (_003C_003Ec._003C_003E9__121_2 == null)
				{
					condition = (_003C_003Ec._003C_003E9__121_2 = delegate
					{
						//IL_004d: Expected O, but got I
						//IL_003d: Expected I4, but got O
						//IL_001b: Expected O, but got I
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [kvp @ rdx (System.Collections.Generic.KeyValuePair`2<VampireSurvivors.Data.CharacterType, VampireSurvivors.UI.CharacterItem>)+8]");
						object obj18 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [kvp @ rdx (System.Collections.Generic.KeyValuePair`2<VampireSurvivors.Data.CharacterType, VampireSurvivors.UI.CharacterItem>)+8]");
						if ((nint)0 == 0)
						{
							NullReferenceException ex = new NullReferenceException();
							return (byte)(int)ex != 0;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ rax_v2+18]");
						object obj19 = --1;
						return obj19 == null;
					});
				}
				VampireSurvivors.App.Tools.Extensions.RemoveWhere(dictionary2, condition);
				goto IL_07c1;
			}
		}
		goto IL_13fc;
		IL_18c8:
		object obj5;
		GameObject gameObject;
		Dictionary<CharacterType, List<CharacterData>> maxWeaponsText;
		object obj9;
		if (obj5 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v260 @ rax_v110+238]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v260 @ rax_v110+238]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v295 @ rcx_v84+20]");
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v295 @ rcx_v84+28]");
				Dictionary<CharacterType, CharacterItemUI> dictionary3 = (Dictionary<CharacterType, CharacterItemUI>)(num - 0);
				if ((object)gameObject != null)
				{
					bool flag3 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
					object obj7 = (object)dictionary3 ^ (object)dictionary3;
					object obj8 = (object)dictionary3 & obj7;
					bool flag4 = (nint)obj8 < 0;
					bool flag5 = (nint)dictionary3 < 0;
					bool flag6 = dictionary3 == null;
					bool flag7 = flag5 == flag4;
					bool flag8 = !flag6;
					Dictionary<CharacterType, CharacterItemUI> dictionary4 = (Dictionary<CharacterType, CharacterItemUI>)(flag8 & flag7);
					GameObject.SetActive_Injected(((UnityEngine.Object)gameObject).m_CachedPtr, (byte)(int)dictionary4 != 0);
					maxWeaponsText = (Dictionary<CharacterType, List<CharacterData>>)(object)_MaxWeaponsText;
					Dictionary<CharacterType, CharacterItemUI> playerOptions2 = (Dictionary<CharacterType, CharacterItemUI>)(object)_playerOptions;
					if (_playerOptions != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ rbx_v40 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.CharacterType, VampireSurvivors.UI.CharacterItemUI>)+68]");
						if ((nint)0 == 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ rbx_v40 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.CharacterType, VampireSurvivors.UI.CharacterItemUI>)+58]");
							if ((nint)0 == 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ rbx_v40 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.CharacterType, VampireSurvivors.UI.CharacterItemUI>)+78]");
								if ((nint)0 != 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ rbx_v40 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.CharacterType, VampireSurvivors.UI.CharacterItemUI>)+78]");
									obj9 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v270 @ rax_v116+2CC]");
									if ((nint)0 != 0)
									{
										goto IL_1970;
									}
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ rbx_v40 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.CharacterType, VampireSurvivors.UI.CharacterItemUI>)+50]");
								obj9 = 0;
							}
							else
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ rbx_v40 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.CharacterType, VampireSurvivors.UI.CharacterItemUI>)+58]");
								obj9 = 0;
							}
						}
						else
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ rbx_v40 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.CharacterType, VampireSurvivors.UI.CharacterItemUI>)+68]");
							obj9 = 0;
						}
						goto IL_1970;
					}
				}
			}
		}
		goto IL_13fc;
		IL_1729:
		StatsPanelUI statsPanel = StatsPanel;
		object obj10;
		if ((object)StatsPanel != null)
		{
			if (!statsPanel._hasLoaded)
			{
				StatsPanel.Populate();
			}
			TextAutoSizeHelper.UpdateTextSizes(statsPanel._statTextLines, -1);
			if ((object)_StageCompletionPanel != null)
			{
				_StageCompletionPanel.Initialize();
				if (_playerOptions != null)
				{
					PlayerOptionsData config = _playerOptions.Config;
					if (config != null)
					{
						List<CharacterType> list = config._003CBoughtCharacters_003Ek__BackingField;
						if (config._003CBoughtCharacters_003Ek__BackingField != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v252 @ rax_v91 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
							bool active;
							if ((nint)0 > (nint)1)
							{
								active = true;
							}
							else
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18699C0C0");
								bool flag9 = default(bool);
								active = flag9;
							}
							if ((object)StatsPanel != null)
							{
								GameObject gameObject2 = StatsPanel.gameObject;
								if ((object)gameObject2 != null)
								{
									gameObject2.SetActive(active);
									Dictionary<CharacterType, CharacterItemUI> playerOptions3 = (Dictionary<CharacterType, CharacterItemUI>)(object)_playerOptions;
									if (_playerOptions != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ rbx_v32 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.CharacterType, VampireSurvivors.UI.CharacterItemUI>)+68]");
										if ((nint)0 == 0)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ rbx_v32 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.CharacterType, VampireSurvivors.UI.CharacterItemUI>)+58]");
											if ((nint)0 == 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ rbx_v32 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.CharacterType, VampireSurvivors.UI.CharacterItemUI>)+78]");
												if ((nint)0 != 0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ rbx_v32 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.CharacterType, VampireSurvivors.UI.CharacterItemUI>)+78]");
													obj10 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v255 @ rax_v96+2CC]");
													if ((nint)0 != 0)
													{
														goto IL_17bd;
													}
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ rbx_v32 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.CharacterType, VampireSurvivors.UI.CharacterItemUI>)+50]");
												obj10 = 0;
											}
											else
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ rbx_v32 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.CharacterType, VampireSurvivors.UI.CharacterItemUI>)+58]");
												obj10 = 0;
											}
										}
										else
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ rbx_v32 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.CharacterType, VampireSurvivors.UI.CharacterItemUI>)+68]");
											obj10 = 0;
										}
										goto IL_17bd;
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_13fc;
		IL_16aa:
		object obj11;
		if (obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v245 @ rax_v76+148]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v245 @ rax_v76+148]");
				bool flag10 = ((List<System.Int32Enum>)0).Remove((System.Int32Enum)0);
				Dictionary<CharacterType, CharacterItemUI> playerOptions4 = (Dictionary<CharacterType, CharacterItemUI>)(object)_playerOptions;
				if (_playerOptions != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ rbx_v29 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.CharacterType, VampireSurvivors.UI.CharacterItemUI>)+68]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ rbx_v29 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.CharacterType, VampireSurvivors.UI.CharacterItemUI>)+58]");
						if ((nint)0 == 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ rbx_v29 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.CharacterType, VampireSurvivors.UI.CharacterItemUI>)+78]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ rbx_v29 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.CharacterType, VampireSurvivors.UI.CharacterItemUI>)+78]");
								obj11 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v247 @ rax_v79+2CC]");
								if ((nint)0 != 0)
								{
									goto IL_16ef;
								}
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ rbx_v29 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.CharacterType, VampireSurvivors.UI.CharacterItemUI>)+50]");
							obj11 = 0;
						}
						else
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ rbx_v29 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.CharacterType, VampireSurvivors.UI.CharacterItemUI>)+58]");
							obj11 = 0;
						}
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ rbx_v29 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.CharacterType, VampireSurvivors.UI.CharacterItemUI>)+68]");
						obj11 = 0;
					}
					goto IL_16ef;
				}
			}
		}
		goto IL_13fc;
		IL_1970:
		if (obj9 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v270 @ rax_v116+78]");
			object obj12 = default(object);
			string text = System.Number.FormatInt32(0, (ReadOnlySpan<char>)(&obj12), null);
			if ((object)_MaxWeaponsText != null)
			{
				nint num2 = (nint)maxWeaponsText;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v4033 @ r8_v38 (Il2CppClass<System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.CharacterType, System.Collections.Generic.List`1<VampireSurvivors.Data.Characters.CharacterData>>>)+558] (should have been resolved before IL ge…");
				Dictionary<CharacterType, CharacterItem>.Enumerator enumerator = default(Dictionary<CharacterType, CharacterItem>.Enumerator);
				while (enumerator.MoveNext())
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
					CharacterItem characterItem = null;
				}
				return;
			}
		}
		goto IL_13fc;
		IL_148a:
		object obj13;
		if (obj13 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v263 @ rax_v62+2A8]");
			if ((nint)0 != 0)
			{
				CharacterType[] charactersToUnlocks = TPCreditsPage.CharactersToUnlocks;
				bool flag11 = TPCreditsPage.CharactersToUnlocks == null;
				nint num3 = 0;
				Dictionary<CharacterType, List<CharacterData>> dictionary5 = null;
				Dictionary<CharacterType, List<CharacterData>> dictionary6 = null;
				if (flag11)
				{
					goto IL_13fc;
				}
				System.Collections.Generic.InsertionBehavior insertionBehavior = default(System.Collections.Generic.InsertionBehavior);
				System.Collections.Generic.InsertionBehavior insertionBehavior2;
				nint num4;
				object obj16 = default(object);
				for (; (nint)dictionary6 < charactersToUnlocks.Length; dictionary5 = (Dictionary<CharacterType, List<CharacterData>>)(dictionary5 + 1), insertionBehavior = insertionBehavior2, num3 = num4, dictionary6 = dictionary5)
				{
					if ((nint)dictionary5 < charactersToUnlocks.Length)
					{
						Dictionary<CharacterType, CharacterItemUI> playerOptions5 = (Dictionary<CharacterType, CharacterItemUI>)(object)_playerOptions;
						if (_playerOptions == null)
						{
							goto IL_13fc;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ rbx_v53 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.CharacterType, VampireSurvivors.UI.CharacterItemUI>)+68]");
						if ((nint)0 == 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ rbx_v53 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.CharacterType, VampireSurvivors.UI.CharacterItemUI>)+58]");
							if ((nint)0 == 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ rbx_v53 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.CharacterType, VampireSurvivors.UI.CharacterItemUI>)+78]");
								object obj14;
								if ((nint)0 != 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ rbx_v53 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.CharacterType, VampireSurvivors.UI.CharacterItemUI>)+78]");
									obj14 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v265 @ rax_v273+2CC]");
									if ((nint)0 != 0)
									{
										goto IL_1512;
									}
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ rbx_v53 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.CharacterType, VampireSurvivors.UI.CharacterItemUI>)+50]");
								obj14 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ rbx_v53 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.CharacterType, VampireSurvivors.UI.CharacterItemUI>)+50]");
								if ((nint)0 == 0)
								{
									goto IL_13fc;
								}
							}
							else
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ rbx_v53 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.CharacterType, VampireSurvivors.UI.CharacterItemUI>)+58]");
								object obj14 = 0;
							}
						}
						else
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ rbx_v53 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.CharacterType, VampireSurvivors.UI.CharacterItemUI>)+68]");
							object obj14 = 0;
						}
						goto IL_1512;
					}
					throw new IndexOutOfRangeException();
					IL_1512:
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v265 @ rax_v273+170]");
					object obj15 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v265 @ rax_v273+170]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v300 @ rcx_v175+18]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v300 @ rcx_v175+18]");
							insertionBehavior = System.Collections.Generic.InsertionBehavior.None;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
							bool flag12 = (nint)obj16 != -1;
							num3 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v300 @ rcx_v175+18]");
							insertionBehavior2 = System.Collections.Generic.InsertionBehavior.None;
							num4 = 0;
							if (flag12)
							{
								continue;
							}
						}
						if (dictionary2 != null)
						{
							bool flag13 = ((Dictionary<System.Int32Enum, object>)(object)dictionary2).Remove((System.Int32Enum)(int)System.Runtime.CompilerServices.Unsafe.AsPointer(ref charactersToUnlocks[(object)dictionary5]));
							insertionBehavior2 = insertionBehavior;
							num4 = num3;
							continue;
						}
					}
					goto IL_13fc;
				}
			}
			Func<KeyValuePair<CharacterType, CharacterItem>, bool> condition2 = _003C_003Ec._003C_003E9__121_0;
			if (_003C_003Ec._003C_003E9__121_0 == null)
			{
				condition2 = (_003C_003Ec._003C_003E9__121_0 = delegate
				{
					//IL_0065: Expected O, but got I
					//IL_0055: Expected I4, but got O
					//IL_0015: Expected O, but got I
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [kvp @ rdx (System.Collections.Generic.KeyValuePair`2<VampireSurvivors.Data.CharacterType, VampireSurvivors.UI.CharacterItem>)+8]");
					object obj18 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [kvp @ rdx (System.Collections.Generic.KeyValuePair`2<VampireSurvivors.Data.CharacterType, VampireSurvivors.UI.CharacterItem>)+8]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ rax_v2+20]");
						object obj19 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ rax_v2+20]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v5+12]");
							return false;
						}
					}
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				});
			}
			VampireSurvivors.App.Tools.Extensions.RemoveWhere(dictionary2, condition2);
			Func<KeyValuePair<CharacterType, CharacterItem>, bool> condition3 = _003C_003Ec._003C_003E9__121_1;
			if (_003C_003Ec._003C_003E9__121_1 == null)
			{
				condition3 = (_003C_003Ec._003C_003E9__121_1 = delegate
				{
					//IL_011b: Expected O, but got I
					//IL_010b: Expected I4, but got O
					//IL_00bd: Expected O, but got I
					//IL_00e0: Expected O, but got I
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [kvp @ rdx (System.Collections.Generic.KeyValuePair`2<VampireSurvivors.Data.CharacterType, VampireSurvivors.UI.CharacterItem>)+8]");
					CharacterItem characterItem2 = (CharacterItem)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [kvp @ rdx (System.Collections.Generic.KeyValuePair`2<VampireSurvivors.Data.CharacterType, VampireSurvivors.UI.CharacterItem>)+8]");
					if ((nint)0 != 0)
					{
						CharacterData characterData = characterItem2._characterData;
						if (characterItem2._characterData != null)
						{
							if ((object)characterData._003CrequiresRelic_003Ek__BackingField == null)
							{
								goto IL_00f7;
							}
							if (characterItem2._playerOptions != null)
							{
								PlayerOptionsData config2 = characterItem2._playerOptions.Config;
								if (config2 != null && config2._003CCollectedItems_003Ek__BackingField != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A965C0");
									object obj18 = default(object);
									if (obj18 == null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [kvp @ rdx (System.Collections.Generic.KeyValuePair`2<VampireSurvivors.Data.CharacterType, VampireSurvivors.UI.CharacterItem>)+8]");
										if (!((CharacterItem)0).IsCharacterUnlocked())
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [kvp @ rdx (System.Collections.Generic.KeyValuePair`2<VampireSurvivors.Data.CharacterType, VampireSurvivors.UI.CharacterItem>)+8]");
											bool flag17 = ((CharacterItem)0).IsCharacterBought();
											return (byte)((flag17 ? 1u : 0u) ^ 1u) != 0;
										}
									}
									goto IL_00f7;
								}
							}
						}
					}
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
					IL_00f7:
					return false;
				});
			}
			VampireSurvivors.App.Tools.Extensions.RemoveWhere(dictionary2, condition3);
			Dictionary<CharacterType, CharacterItemUI> playerOptions6 = (Dictionary<CharacterType, CharacterItemUI>)(object)_playerOptions;
			if (_playerOptions != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rbx_v26 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.CharacterType, VampireSurvivors.UI.CharacterItemUI>)+68]");
				if ((nint)0 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rbx_v26 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.CharacterType, VampireSurvivors.UI.CharacterItemUI>)+58]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rbx_v26 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.CharacterType, VampireSurvivors.UI.CharacterItemUI>)+78]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rbx_v26 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.CharacterType, VampireSurvivors.UI.CharacterItemUI>)+78]");
							obj2 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v243 @ rax_v73+2CC]");
							if ((nint)0 != 0)
							{
								goto IL_1610;
							}
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rbx_v26 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.CharacterType, VampireSurvivors.UI.CharacterItemUI>)+50]");
						obj2 = 0;
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rbx_v26 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.CharacterType, VampireSurvivors.UI.CharacterItemUI>)+58]");
						obj2 = 0;
					}
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rbx_v26 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.CharacterType, VampireSurvivors.UI.CharacterItemUI>)+68]");
					obj2 = 0;
				}
				goto IL_1610;
			}
		}
		goto IL_13fc;
		IL_0160:
		Dictionary<CharacterType, CharacterItemUI> characterItemUIs = new Dictionary<CharacterType, CharacterItemUI>();
		_characterItemUIs = characterItemUIs;
		dictionary2 = new Dictionary<CharacterType, CharacterItem>();
		if (dictionary != null)
		{
			Dictionary<CharacterType, List<CharacterData>>.Enumerator enumerator2 = (Dictionary<CharacterType, List<CharacterData>>.Enumerator)2;
			Dictionary<CharacterType, List<CharacterData>>.Enumerator enumerator3 = default(Dictionary<CharacterType, List<CharacterData>>.Enumerator);
			if (enumerator3.MoveNext())
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
				Dictionary<CharacterType, List<CharacterData>>.Enumerator enumerator4 = (Dictionary<CharacterType, List<CharacterData>>.Enumerator)0;
				Dictionary<CharacterType, List<CharacterData>>.Enumerator enumerator5 = (Dictionary<CharacterType, List<CharacterData>>.Enumerator)0;
				throw new NullReferenceException();
			}
			Dictionary<CharacterType, CharacterItemUI> playerOptions7 = (Dictionary<CharacterType, CharacterItemUI>)(object)_playerOptions;
			if (_playerOptions != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ rbx_v22 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.CharacterType, VampireSurvivors.UI.CharacterItemUI>)+68]");
				if ((nint)0 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ rbx_v22 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.CharacterType, VampireSurvivors.UI.CharacterItemUI>)+58]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ rbx_v22 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.CharacterType, VampireSurvivors.UI.CharacterItemUI>)+78]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ rbx_v22 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.CharacterType, VampireSurvivors.UI.CharacterItemUI>)+78]");
							obj13 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v263 @ rax_v62+2CC]");
							if ((nint)0 != 0)
							{
								goto IL_148a;
							}
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ rbx_v22 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.CharacterType, VampireSurvivors.UI.CharacterItemUI>)+50]");
						obj13 = 0;
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ rbx_v22 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.CharacterType, VampireSurvivors.UI.CharacterItemUI>)+58]");
						obj13 = 0;
					}
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ rbx_v22 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.CharacterType, VampireSurvivors.UI.CharacterItemUI>)+68]");
					obj13 = 0;
				}
				goto IL_148a;
			}
		}
		goto IL_13fc;
		IL_17bd:
		if (obj10 != null && (object)_EggBox != null)
		{
			TickBoxUI eggBox = _EggBox;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v255 @ rax_v96+53]");
			eggBox.InitialSet(b: false);
			if ((object)_EggCount != null)
			{
				Transform transform = _EggCount.transform;
				if ((object)transform != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v257 @ rax_v98 (UnityEngine.Transform)+10]");
					bool flag14 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v257 @ rax_v98 (UnityEngine.Transform)+10]");
					IntPtr parent_Injected = Transform.GetParent_Injected((IntPtr)0);
					Transform transform2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(parent_Injected);
					if ((object)transform2 != null)
					{
						bool flag15 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
						IntPtr gcHandlePtr = Component.get_gameObject_Injected(((UnityEngine.Object)transform2).m_CachedPtr);
						gameObject = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr);
						Dictionary<CharacterType, CharacterItemUI> playerOptions8 = (Dictionary<CharacterType, CharacterItemUI>)(object)_playerOptions;
						if (_playerOptions != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ rbx_v35 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.CharacterType, VampireSurvivors.UI.CharacterItemUI>)+68]");
							if ((nint)0 == 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ rbx_v35 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.CharacterType, VampireSurvivors.UI.CharacterItemUI>)+58]");
								if ((nint)0 == 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ rbx_v35 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.CharacterType, VampireSurvivors.UI.CharacterItemUI>)+78]");
									if ((nint)0 != 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ rbx_v35 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.CharacterType, VampireSurvivors.UI.CharacterItemUI>)+78]");
										obj5 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v260 @ rax_v110+2CC]");
										if ((nint)0 != 0)
										{
											goto IL_18c8;
										}
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ rbx_v35 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.CharacterType, VampireSurvivors.UI.CharacterItemUI>)+50]");
									obj5 = 0;
								}
								else
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ rbx_v35 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.CharacterType, VampireSurvivors.UI.CharacterItemUI>)+58]");
									obj5 = 0;
								}
							}
							else
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ rbx_v35 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.CharacterType, VampireSurvivors.UI.CharacterItemUI>)+68]");
								obj5 = 0;
							}
							goto IL_18c8;
						}
					}
				}
			}
		}
		goto IL_13fc;
		IL_16ef:
		if (obj11 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v247 @ rax_v79+44]");
			System.Int32Enum int32Enum = (System.Int32Enum)0;
			bool flag16 = dictionary2 == null;
			if (!flag16)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v247 @ rax_v79+44]");
				int num5 = ((Dictionary<System.Int32Enum, object>)(object)dictionary2).FindEntry((System.Int32Enum)0);
				object obj17;
				if (!flag16)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v247 @ rax_v79+44]");
					obj17 = ((Dictionary<System.Int32Enum, object>)(object)dictionary2).get_Item((System.Int32Enum)0);
				}
				else
				{
					obj17 = null;
				}
				if (int32Enum != 0 && obj17 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3420 @ rax_v84 (System.Object)+28]");
					if ((nint)0 == 3)
					{
						goto IL_1729;
					}
				}
				if (!AdventureManager._003CIsInAdventureMode_003Ek__BackingField)
				{
					int32Enum = (System.Int32Enum)1;
					goto IL_1729;
				}
				AdventureManager adventureManager2 = _adventureManager;
				if (_adventureManager != null)
				{
					AdventureData adventureData2 = adventureManager2._003CAdventureData_003Ek__BackingField;
					if (adventureManager2._003CAdventureData_003Ek__BackingField != null)
					{
						CoreAdventureData coreAdventureData = adventureData2._003CCoreAdventureData_003Ek__BackingField;
						if (adventureData2._003CCoreAdventureData_003Ek__BackingField != null)
						{
							int32Enum = (System.Int32Enum)coreAdventureData._003CStartingCharacter_003Ek__BackingField;
							goto IL_1729;
						}
					}
				}
			}
		}
		goto IL_13fc;
	}

	private void UpdateStatsPanelVisibility()
	{
		PlayerOptionsData config = _playerOptions.Config;
		List<CharacterType> list = config._003CBoughtCharacters_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ rax_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		bool active;
		if ((nint)0 > (nint)1)
		{
			active = true;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18699C0C0");
			bool flag = default(bool);
			active = flag;
		}
		GameObject gameObject = StatsPanel.gameObject;
		gameObject.SetActive(active);
	}

	private GameObject AddCharacter(CharacterItem cItem)
	{
		GameObject gameObject = UnityEngine.Object.Instantiate(CharacterPrefab, Container);
		if ((object)gameObject != null)
		{
			CharacterItemUI component = gameObject.GetComponent<CharacterItemUI>();
			if (cItem != null && _characterItemUIs != null)
			{
				bool flag = ((Dictionary<System.Int32Enum, object>)(object)_characterItemUIs).TryInsert((System.Int32Enum)cItem._characterType, (object)component, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
				if (_spawned != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180497F80");
					if ((object)component != null)
					{
						CharacterItem charItem = default(CharacterItem);
						bool useDefaultSkin = default(bool);
						component.SetData(this, _dataManager, _playerOptions, charItem, useDefaultSkin);
						return gameObject;
					}
				}
			}
		}
		return (GameObject)(object)new NullReferenceException();
	}

	private IEnumerator WaitAndDo(Action cb)
	{
		_003CWaitAndDo_003Ed__124 obj = null;
		obj._003C_003E1__state = 0;
		obj.cb = cb;
		return obj;
	}

	private void SetCharacterSprite(CharacterType cType, CharacterData cData)
	{
		Sprite sprite = ((!_selectedCharacterItemUI.IsUnlockableAndSecret()) ? _selectedCharacterItemUI.GetCharSprite(cType, cData) : SpriteManager.GetSprite("QuestionMark", "UI"));
		Icon.sprite = sprite;
	}

	private void SetCharacterName(CharacterType cType, CharacterData cData)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A30E2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		TextMeshProUGUI textMeshProUGUI = _Name;
		string text = ((!_selectedCharacterItemUI.IsUnlockableAndSecret()) ? cData.GetFullName(cType, ignoreSkinPrefixSuffix: false, splitDualCharacterNames: false) : "???");
		_Name.text = text;
		string text2 = _Name.text;
		if (text2 == null || text2._stringLength <= 0 || cType == CharacterType.ARENGIJUS || cType == CharacterType.EXDASH)
		{
			string fullNameUntranslated = cData.GetFullNameUntranslated();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18634B7A0");
		}
	}

	private unsafe void SetWeaponIconSprite(CharacterData characterData)
	{
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Expected O, but got Unknown
		//IL_00e0: Expected O, but got Ref
		//IL_0101: Expected I, but got O
		//IL_01f3: Expected O, but got I
		//IL_0134: Expected I, but got O
		//IL_0208: Expected O, but got I
		//IL_022d: Expected O, but got I4
		//IL_0256: Expected O, but got Ref
		//IL_0186: Expected I4, but got O
		//IL_0194: Expected I, but got O
		//IL_03e8: Expected O, but got I
		//IL_03e8: Expected O, but got I
		//IL_02fe: Expected O, but got I
		//IL_0313: Expected O, but got I
		object obj = (object?)characterData._003CstartingWeapon_003Ek__BackingField >> 32;
		bool flag = obj == null;
		object obj2 = (_003F?)characterData._003CstartingWeapon_003Ek__BackingField & flag;
		if (obj2 != null)
		{
			WeaponIcon.enabled = false;
			Image component = _WeaponFrame.GetComponent<Image>();
			component.enabled = false;
			return;
		}
		nint num = default(nint);
		Dictionary<WeaponType, List<WeaponData>> convertedWeapons;
		System.Int32Enum key;
		if ((object)characterData._003CstartingWeapon_003Ek__BackingField != null)
		{
			if ((object)characterData._003CstartingWeapon_003Ek__BackingField == null)
			{
				goto IL_0405;
			}
			string text = ((Enum)(&num)).ToString();
			bool flag2 = text == null;
			num = (nint)typeof(WeaponType);
			if (!flag2)
			{
				bool flag3 = text._stringLength <= 0;
				num = (nint)typeof(WeaponType);
				if (!flag3)
				{
					convertedWeapons = _dataManager.GetConvertedWeapons();
					if ((object)characterData._003CstartingWeapon_003Ek__BackingField == null)
					{
						goto IL_0405;
					}
					key = (System.Int32Enum)((object?)characterData._003CstartingWeapon_003Ek__BackingField >> 32);
					num = (nint)typeof(WeaponType);
					goto IL_0410;
				}
			}
		}
		convertedWeapons = _dataManager.GetConvertedWeapons();
		key = (System.Int32Enum)3;
		goto IL_0410;
		IL_0426:
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		return;
		IL_0405:
		System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
		throw new IndexOutOfRangeException();
		IL_0410:
		object obj3 = ((Dictionary<System.Int32Enum, object>)(object)convertedWeapons).get_Item(key);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ rax_v12 (System.Object)+18]");
		if ((nint)0 > (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ rax_v12 (System.Object)+10]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rsi_v5+20]");
			List<WeaponData> list = (List<WeaponData>)0;
			Skin currentSkinData = characterData.GetCurrentSkinData();
			bool flag4 = currentSkinData == null;
			WeaponType? weaponType = (WeaponType?)(object)0;
			if (!flag4)
			{
				weaponType = currentSkinData._003CstartingWeapon_003Ek__BackingField;
			}
			if ((object)weaponType != null)
			{
				string text2 = ((Enum)(&num)).ToString();
				if (text2 != null && text2._stringLength > 0)
				{
					Dictionary<WeaponType, List<WeaponData>> convertedWeapons2 = _dataManager.GetConvertedWeapons();
					System.Int32Enum key2 = default(System.Int32Enum);
					object obj5 = ((Dictionary<System.Int32Enum, object>)(object)convertedWeapons2).get_Item(key2);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ rax_v25 (System.Object)+18]");
					if ((nint)0 <= (nint)0)
					{
						goto IL_0426;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ rax_v25 (System.Object)+10]");
					object obj6 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ rsi_v9+20]");
					list = (List<WeaponData>)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ rsi_v9+20]");
					if ((nint)0 == 0)
					{
						Dictionary<WeaponType, List<WeaponData>> convertedWeapons3 = _dataManager.GetConvertedWeapons();
						object obj7 = ((Dictionary<System.Int32Enum, object>)(object)convertedWeapons3).get_Item((System.Int32Enum)3);
						List<WeaponData> list2 = ((Dictionary<WeaponType, List<WeaponData>>)obj7).get_Item(WeaponType.VOID);
						list = list2;
					}
				}
			}
			WeaponIcon.enabled = true;
			Image component2 = _WeaponFrame.GetComponent<Image>();
			component2.enabled = true;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v106 @ rsi_v7 (System.Collections.Generic.List`1<VampireSurvivors.Data.Weapons.WeaponData>)+40]");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v106 @ rsi_v7 (System.Collections.Generic.List`1<VampireSurvivors.Data.Weapons.WeaponData>)+38]");
			Sprite sprite = SpriteManager.GetSprite((string)num2, (string)0);
			WeaponIcon.sprite = sprite;
			return;
		}
		goto IL_0426;
	}

	private unsafe void MakeDisplayMultiplayer()
	{
		//IL_00c8: Expected I4, but got O
		//IL_00d3: Expected I4, but got O
		//IL_00ea: Expected O, but got I4
		//IL_00f8: Expected O, but got I4
		//IL_0100: Expected O, but got Ref
		state = State.MULTIPLAYER;
		Vector2 vector = default(Vector2);
		VampireSurvivors.App.Tools.Extensions.SetPivot(_Panel, vector);
		if ((object)_Panel != null)
		{
			Vector2 sizeDelta = _Panel.sizeDelta;
			TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore = DOTweenModuleUI.DOSizeDelta(_Panel, vector, 0.15f);
			if ((object)_MultiplayerTextPanel != null)
			{
				_MultiplayerTextPanel.SetActive(value: false);
				if ((object)MPPlayerContainer != null)
				{
					GameObject gameObject = MPPlayerContainer.gameObject;
					if ((object)gameObject != null)
					{
						gameObject.SetActive(value: true);
						bool flag = (byte)(int)_playerSlots != 0;
						if ((int)(~_playerSlots) == 0)
						{
							object obj = 0;
							List<MPPlayerItem>.Enumerator enumerator = default(List<MPPlayerItem>.Enumerator);
							if (enumerator.MoveNext())
							{
								object obj2 = 0;
								string text = (string)(&enumerator);
								throw new NullReferenceException();
							}
							RefreshMaxWeaponsAndEggsDisplay();
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void MakeDisplaySingleplayer()
	{
		MultiplayerManager multiplayer = _multiplayer;
		state = State.SINGLEPLAYER;
		_MultiplayerTextPanel.SetActive(multiplayer.AllowPlayerJoining);
		GameObject gameObject = MPPlayerContainer.gameObject;
		gameObject.SetActive(value: false);
		if (!UIHelper.IsPortrait)
		{
			Vector2 sizeDelta = _Panel.sizeDelta;
			Vector2 endValue = default(Vector2);
			TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore = DOTweenModuleUI.DOSizeDelta(_Panel, endValue, 0.15f);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 141 Invalid \"Jump target not found in method: 0x186C9BAB0\"");
		throw new NullReferenceException();
	}

	private void RefreshMaxWeaponsAndEggsDisplay()
	{
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Expected O, but got Unknown
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Expected O, but got Unknown
		PlayerOptionsData config = _playerOptions.Config;
		List<ItemType> list = config._003CCollectedItems_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v284 @ rcx_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
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
		PlayerOptionsData config2 = _playerOptions.Config;
		List<ItemType> list2 = config2._003CCollectedItems_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v285 @ rcx_v8 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
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
		int playerCount = _multiplayer.GetPlayerCount();
		GameObject eggWeaponBox;
		GameObject weaponCountContainer;
		if (playerCount > 1)
		{
			eggWeaponBox = _EggWeaponBox;
		}
		else
		{
			bool isOnlineMultiplayer = _multiplayer.IsOnlineMultiplayer;
			eggWeaponBox = _EggWeaponBox;
			if (!isOnlineMultiplayer)
			{
				bool active = flag3 | flag;
				_EggWeaponBox.SetActive(active);
				_EggContainer.SetActive(flag3);
				weaponCountContainer = _WeaponCountContainer;
				goto IL_0290;
			}
		}
		eggWeaponBox.SetActive(value: false);
		_EggContainer.SetActive(value: false);
		weaponCountContainer = _WeaponCountContainer;
		flag = false;
		goto IL_0290;
		IL_0290:
		weaponCountContainer.SetActive(flag);
		GameObject gameObject;
		bool active2;
		if (flag3)
		{
			PlayerOptions playerOptions = _playerOptions;
			if (playerOptions._currentAdventureSaveData != null)
			{
				gameObject = _EggBox.gameObject;
				active2 = false;
				goto IL_02b6;
			}
		}
		gameObject = _EggBox.gameObject;
		active2 = true;
		goto IL_02b6;
		IL_02b6:
		gameObject.SetActive(active2);
	}

	private unsafe void SpawnPlayerItem(int index)
	{
		//IL_00c3: Expected O, but got Ref
		_003C_003Ec__DisplayClass131_0 CS_0024_003C_003E8__locals8 = new _003C_003Ec__DisplayClass131_0();
		CS_0024_003C_003E8__locals8._003C_003E4__this = this;
		CS_0024_003C_003E8__locals8.index = index;
		GameObject gameObject = UnityEngine.Object.Instantiate(MPPlayerItemPrefab, MPPlayerContainer);
		MPPlayerItem component = gameObject.GetComponent<MPPlayerItem>();
		component._dataManager = _dataManager;
		component._playerOptions = _playerOptions;
		bool applyParameters = default(bool);
		GameObject localParametersRoot = default(GameObject);
		string overrideLanguage = default(string);
		bool allowLocalizedParameters = default(bool);
		string translation = LocalizationManager.GetTranslation("lang/multiplayer_player_name", FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
		int value = CS_0024_003C_003E8__locals8.index + 1;
		object obj = default(object);
		string newValue = System.Number.FormatInt32(value, (ReadOnlySpan<char>)(&obj), null);
		string text = translation.Replace("%0", newValue);
		component._PlayerName.text = text;
		component._index = CS_0024_003C_003E8__locals8.index;
		component.GoToInactive();
		if (_partyModeEnabled)
		{
			Button component2 = component.GetComponent<Button>();
			UnityAction call = delegate
			{
				CharacterSelectionPage characterSelectionPage = CS_0024_003C_003E8__locals8._003C_003E4__this;
				int index2 = CS_0024_003C_003E8__locals8.index;
				characterSelectionPage._multiplayer.SelectSlot(CS_0024_003C_003E8__locals8.index);
				List<MPPlayerItem> playerSlots2 = characterSelectionPage._playerSlots;
				if (CS_0024_003C_003E8__locals8.index < playerSlots2._size)
				{
					MPPlayerItem[] items2 = playerSlots2._items;
					MPPlayerItem mPPlayerItem = items2[index2];
					mPPlayerItem._PlayerState = MPPlayerItem.PlayerState.INACTIVE;
				}
				else
				{
					System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				}
			};
			component2.m_OnClick.AddListener(call);
		}
		List<object> playerSlots = (List<object>)(object)_playerSlots;
		int version = playerSlots._version + 1;
		playerSlots._version = version;
		object[] items = playerSlots._items;
		if (playerSlots._size >= items.Length)
		{
			playerSlots.AddWithResize((object)component);
			return;
		}
		int size = playerSlots._size + 1;
		playerSlots._size = size;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
	}

	public CharacterSelectionPage()
	{
		//IL_00af: Expected O, but got I
		//IL_0109: Expected O, but got I
		//IL_04d4: Expected O, but got I
		//IL_0173: Expected O, but got I
		//IL_04fc: Expected O, but got I
		//IL_01dd: Expected O, but got I
		//IL_0524: Expected O, but got I
		//IL_0247: Expected O, but got I
		//IL_054c: Expected O, but got I
		//IL_02b1: Expected O, but got I
		//IL_0574: Expected O, but got I
		//IL_031b: Expected O, but got I
		//IL_059c: Expected O, but got I
		//IL_0385: Expected O, but got I
		//IL_05c4: Expected O, but got I
		//IL_03ef: Expected O, but got I
		//IL_05ec: Expected O, but got I
		//IL_0459: Expected O, but got I
		List<Sprite> doilies = new List<Sprite>();
		_Doilies = doilies;
		_characterItemUIs = new Dictionary<CharacterType, CharacterItemUI>();
		_playerSlots = new List<MPPlayerItem>();
		_spawned = new List<GameObject>();
		_skinSlots = new List<Image>();
		List<int> list = new List<int>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v413 @ rax_v17 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v413 @ rax_v17 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v413 @ rax_v17 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v450 @ rdx_v14+18]");
		if (num >= 0)
		{
			list.AddWithResize(1);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v413 @ rax_v17 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v413 @ rax_v17 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v413 @ rax_v17 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v413 @ rax_v17 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v472 @ rdx_v16+18]");
		if (num2 >= 0)
		{
			list.AddWithResize(174);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v413 @ rax_v17 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 174;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v413 @ rax_v17 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v413 @ rax_v17 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v413 @ rax_v17 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v473 @ rdx_v18+18]");
		if (num3 >= 0)
		{
			list.AddWithResize(169);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v413 @ rax_v17 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 169;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v413 @ rax_v17 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v413 @ rax_v17 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v413 @ rax_v17 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v474 @ rdx_v20+18]");
		if (num4 >= 0)
		{
			list.AddWithResize(990);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v413 @ rax_v17 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj8 = (nint)0 + (nint)1;
			_ = 990;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v413 @ rax_v17 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v413 @ rax_v17 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v413 @ rax_v17 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v475 @ rdx_v22+18]");
		if (num5 >= 0)
		{
			list.AddWithResize(1421);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v413 @ rax_v17 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj10 = (nint)0 + (nint)1;
			_ = 1421;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v413 @ rax_v17 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v413 @ rax_v17 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v413 @ rax_v17 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v476 @ rdx_v24+18]");
		if (num6 >= 0)
		{
			list.AddWithResize(65376);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v413 @ rax_v17 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj12 = (nint)0 + (nint)1;
			_ = 65376;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v413 @ rax_v17 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v413 @ rax_v17 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v413 @ rax_v17 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v477 @ rdx_v26+18]");
		if (num7 >= 0)
		{
			list.AddWithResize(65483);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v413 @ rax_v17 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj14 = (nint)0 + (nint)1;
			_ = 65483;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v413 @ rax_v17 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v413 @ rax_v17 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v413 @ rax_v17 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v478 @ rdx_v28+18]");
		if (num8 >= 0)
		{
			list.AddWithResize(65509);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v413 @ rax_v17 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj16 = (nint)0 + (nint)1;
			_ = 65509;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v413 @ rax_v17 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v413 @ rax_v17 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj17 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v413 @ rax_v17 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v479 @ rdx_v30+18]");
		if (num9 >= 0)
		{
			list.AddWithResize(65533);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v413 @ rax_v17 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj18 = (nint)0 + (nint)1;
			_ = 65533;
		}
		_weirdCharacters = list;
		_tempUnlockedCoopCharacters = new List<CharacterType>();
		float iconUIScale = UIHelper.JS_MAGIC_SCALE_NUMBER + UIHelper.JS_MAGIC_SCALE_NUMBER;
		_iconUIScale = iconUIScale;
		base._002Ector();
	}

	private unsafe void _003CResetDisplay_003Eb__98_0()
	{
		//IL_0012: Expected O, but got Ref
		List<GameObject>.Enumerator enumerator = default(List<GameObject>.Enumerator);
		if (enumerator.MoveNext())
		{
			List<GameObject>.Enumerator enumerator2 = (List<GameObject>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
	}

	private void _003CShowPartySizePopup_003Eb__115_1(int index)
	{
		//IL_003e: Expected O, but got I4
		//IL_0047: Expected O, but got I4
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Expected O, but got Unknown
		//IL_0214: Expected O, but got I4
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Expected O, but got Unknown
		MultiplayerManager multiplayer = _multiplayer;
		multiplayer.AllowPlayerJoining = true;
		int num = default(int);
		int partySize = num + 2;
		_partySize = partySize;
		List<MPPlayerItem> playerSlots = _playerSlots;
		object obj = 0;
		object obj2 = 0;
		Component component = default(Component);
		while ((nint)obj < playerSlots._size)
		{
			object obj3 = obj2 + 1;
			if ((nint)obj3 > _partySize)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
				GameObject gameObject = component.gameObject;
				gameObject.SetActive(value: false);
				num = 0;
			}
			playerSlots = _playerSlots;
			obj2++;
			obj = obj2;
		}
		MultiplayerManager multiplayer2 = _multiplayer;
		multiplayer2.PartySize = (int?)(object)1;
		List<CoopSlotData> slotsSelections = multiplayer2._slotsSelections;
		if (slotsSelections._size > 0)
		{
			CoopSlotData[] items = slotsSelections._items;
			CoopSlotData coopSlotData = items[0];
			float vibrationMS = default(float);
			multiplayer2.SelectPlayerToControlUI(coopSlotData.RewiredPlayer, exclusiveUIControl: true, vibrate: false, vibrationMS);
			int num2 = multiplayer2.FindSlotIndexContainingRewiredPlayer(coopSlotData.RewiredPlayer);
			if (num2 >= 0)
			{
				Color slotColor = multiplayer2.GetSlotColor(num2);
			}
			multiplayer2.Refresh();
			return;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		throw new NullReferenceException();
	}

	private void _003CShowPartySizePopup_003Eb__115_2()
	{
		if (_multiplayer != null)
		{
			EnterCoopButton enterCoopButton = _EnterCoopButton;
			_wasAllowingMultiplayerJoining = false;
			if (enterCoopButton._multiplayerManager != null)
			{
				MultiplayerManager multiplayerManager = enterCoopButton._multiplayerManager;
				multiplayerManager.AllowPlayerJoining = false;
				MultiplayerManager multiplayerManager2 = enterCoopButton._multiplayerManager;
				multiplayerManager2.AllowPlayerRemoval = false;
			}
			GameObject gameObject = enterCoopButton._button.gameObject;
			gameObject.SetActive(value: true);
			MakeDisplaySingleplayer();
		}
	}
}
