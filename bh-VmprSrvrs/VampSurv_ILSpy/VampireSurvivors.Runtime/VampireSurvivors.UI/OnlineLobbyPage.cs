using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using Coherence;
using Coherence.Cloud;
using Coherence.Connection;
using Coherence.Toolkit;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using I2.Loc;
using Newtonsoft.Json.Linq;
using Rewired.Integration.UnityUI;
using TMPro;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using VampireSurvivors.App.Data;
using VampireSurvivors.App.Data.Adventures;
using VampireSurvivors.App.Scripts.Data;
using VampireSurvivors.App.Scripts.Framework.Adventures;
using VampireSurvivors.App.Tools;
using VampireSurvivors.App.UI;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Data.Stage;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.DLC;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects;
using VampireSurvivors.Objects.Algorithm;
using VampireSurvivors.Signals;
using Zenject;

namespace VampireSurvivors.UI;

public class OnlineLobbyPage : BaseUIPage, ICharacterSelector
{
	private sealed class _003CSelectAfterFrameDelay_003Ed__54(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public OnlineLobbyPage _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_0062: Expected I4, but got I8
			//IL_0191: Expected I4, but got O
			OnlineLobbyPage onlineLobbyPage = _003C_003E4__this;
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
				if ((object)_003C_003E4__this != null)
				{
					CharacterItemUI selectedCharacter = onlineLobbyPage._selectedCharacter;
					if ((object)onlineLobbyPage._selectedCharacter == null || ((UnityEngine.Object)selectedCharacter).m_CachedPtr == (IntPtr)0)
					{
						goto IL_01bd;
					}
					if ((object)onlineLobbyPage._selectedCharacter != null)
					{
						onlineLobbyPage._selectedCharacter.SetSelected();
						if ((object)onlineLobbyPage._selectedCharacter != null)
						{
							onlineLobbyPage._selectedCharacter.SetInfoPanel();
							if ((object)onlineLobbyPage._selectedCharacter != null)
							{
								Button component = onlineLobbyPage._selectedCharacter.GetComponent<Button>();
								if ((object)component != null)
								{
									component.Select();
									goto IL_01bd;
								}
							}
						}
					}
				}
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			goto IL_01bd;
			IL_01bd:
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

	private sealed class _003CWaitAndDo_003Ed__104(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
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

	private static OnlineLobbyPage _003CInstance_003Ek__BackingField;

	private GameObject CharacterPrefab;

	private RectTransform Container;

	private Button ConfirmButton;

	private Button BuyButton;

	private Button StartButton;

	private Button _collectionsButton;

	private Button _powerUpsButton;

	private Button _achievementButton;

	private Image PanelBackground;

	private Sprite _SkinOffIcon;

	private Sprite _SkinOnIcon;

	private RectTransform _SkinIndexContainer;

	private GameObject _SkinIndexPrefab;

	private CharacterStageCompletionPanel _StageCompletionPanel;

	private TextMeshProUGUI _Name;

	private TextMeshProUGUI Description;

	private Image Icon;

	private Image WeaponIcon;

	private StatsPanelUI StatsPanel;

	private PriceUI Price;

	private Image _LockIcon;

	private GameObject _WeaponFrame;

	private List<OnlineMPPlayerItem> _players;

	private StageItemUI _stageItem;

	private GameObject _selectStageButton;

	private TextMeshProUGUI _latencyText;

	private TextMeshProUGUI _buyButtonLabel;

	private bool _characterBoughtThisFrame;

	private Dictionary<CharacterType, CharacterItemUI> _characterItems;

	private CharacterItemUI _selectedCharacter;

	private SignalBus _signalBus;

	private DataManager _dataManager;

	private readonly List<GameObject> _spawned;

	private PlayerOptions _playerOptions;

	private AdventureManager _adventureManager;

	private LobbiesManager _lobbiesManager;

	private CharacterData _currentData;

	private CharacterType _currentType;

	private bool _characterConfirmed;

	private List<Image> _skinSlots;

	private List<int> _weirdCharacters;

	private List<CharacterType> _tempUnlockedCoopCharacters;

	private int _selectedPlayerSlotIndex;

	private bool _rnjSetup;

	private bool _missingNSetup;

	private bool _isUILocked;

	private bool _waitingForAllPlayersToBeReadyToStartCharacterSelect;

	private static float ICON_UI_SCALE;

	private bool _onlineInit;

	public static OnlineLobbyPage Instance
	{
		get
		{
			return _003CInstance_003Ek__BackingField;
		}
		private set
		{
			_003CInstance_003Ek__BackingField = value;
		}
	}

	private void Construct(SignalBus signalBus, PlayerOptions playerOptions, DataManager dataManager, AdventureManager adventureManager, LobbiesManager lobbiesManager)
	{
		_signalBus = signalBus;
		_playerOptions = playerOptions;
		_dataManager = dataManager;
		AdventureManager adventureManager2 = default(AdventureManager);
		_adventureManager = adventureManager2;
		LobbiesManager lobbiesManager2 = default(LobbiesManager);
		_lobbiesManager = lobbiesManager2;
	}

	public void RefreshCharacters()
	{
		//IL_0035: Expected O, but got I4
		//IL_01f1: Expected O, but got I
		//IL_0201: Expected O, but got I
		//IL_027b: Expected O, but got I
		//IL_095a: Expected O, but got I
		//IL_096a: Expected O, but got I
		//IL_02e5: Expected O, but got I
		//IL_09b9: Expected O, but got I
		//IL_09c9: Expected O, but got I
		//IL_034f: Expected O, but got I
		//IL_0a11: Expected O, but got I
		//IL_0a21: Expected O, but got I
		//IL_03c2: Expected O, but got I
		//IL_03f3: Expected I, but got O
		//IL_0a71: Expected O, but got I
		//IL_044c: Expected O, but got I
		//IL_0483: Expected O, but got I
		//IL_05ed: Expected O, but got I
		//IL_05fb: Expected O, but got I4
		//IL_065e: Expected O, but got I
		//IL_0847: Expected O, but got I4
		//IL_066c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0671: Expected O, but got Unknown
		//IL_0708: Expected O, but got I
		//IL_0750: Expected O, but got I4
		//IL_0784: Unknown result type (might be due to invalid IL or missing references)
		//IL_0789: Expected O, but got Unknown
		bool flag = _characterItems == null;
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
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ rcx_v22 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
				_ = (nint)0 + (nint)1;
				_ = 0;
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
									goto IL_0915;
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
					goto IL_0915;
				}
			}
		}
		goto IL_07d6;
		IL_07d6:
		throw new NullReferenceException();
		IL_0aa4:
		PlayerOptionsData playerOptionsData2;
		System.Int32Enum int32Enum;
		if (playerOptionsData2 != null)
		{
			list = playerOptionsData2._003CBoughtCharacters_003Ek__BackingField;
			if (playerOptionsData2._003CBoughtCharacters_003Ek__BackingField != null)
			{
				System.Int32Enum num = int32Enum;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ rcx_v22 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
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
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v494 @ stack_-A8_v17+1C]");
							if (obj5 == null)
							{
								object obj6 = obj2;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v494 @ stack_-A8_v17+18]");
								if ((nint)obj6 < 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v494 @ stack_-A8_v17+10]");
									object obj7 = 0;
									obj2++;
									if (System.Runtime.CompilerServices.Unsafe.As<UIUnlockStates?, UIntPtr>(ref uIUnlockStates) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj))
									{
										continue;
									}
									goto IL_0690;
								}
								break;
							}
							break;
						}
						throw new NullReferenceException();
					}
					break;
					IL_0690:
					bool flag2 = _characterItems == null;
					Dictionary<CharacterType, CharacterItemUI> characterItems = _characterItems;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v528 @ rax_v83+20+v515 @ rdx_v37*4]");
					int num2 = ((Dictionary<System.Int32Enum, object>)(object)characterItems).FindEntry((System.Int32Enum)0);
					obj3 = obj2;
					if (!flag2)
					{
						Dictionary<CharacterType, CharacterItemUI> characterItems2 = _characterItems;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v528 @ rax_v83+20+v515 @ rdx_v37*4]");
						object obj8 = ((Dictionary<System.Int32Enum, object>)(object)characterItems2).get_Item((System.Int32Enum)0);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v774 @ rax_v88 (System.Object)+118]");
						bool flag3 = ((CharacterItem)0).IsCharacterBought();
						obj3 = obj2;
						if (!flag3)
						{
							Dictionary<CharacterType, CharacterItemUI> characterItems3 = _characterItems;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v528 @ rax_v83+20+v515 @ rdx_v37*4]");
							object obj9 = ((Dictionary<System.Int32Enum, object>)(object)characterItems3).get_Item((System.Int32Enum)0);
							((CharacterItemUI)obj9)._forcedUnlockState = (UIUnlockStates?)(object)1;
							((CharacterItemUI)obj9).Refresh(false);
							List<CharacterType> tempUnlockedCoopCharacters = _tempUnlockedCoopCharacters;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v528 @ rax_v83+20+v515 @ rdx_v37*4]");
							tempUnlockedCoopCharacters.InsertRange(0, null);
							uIUnlockStates = (UIUnlockStates?)(object)((_003F?)uIUnlockStates + 1);
							obj3 = obj2;
						}
					}
				}
				if (obj4 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v494 @ stack_-A8_v17+1C]");
					if (obj5 == null)
					{
						goto IL_0b13;
					}
					System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
					object obj10 = 0;
				}
				throw new NullReferenceException();
			}
		}
		goto IL_07d6;
		IL_0b13:
		_003CSelectAfterFrameDelay_003Ed__54 obj11 = null;
		obj11._003C_003E1__state = 0;
		obj11._003C_003E4__this = this;
		Coroutine coroutine = StartCoroutine(obj11);
		return;
		IL_0a5a:
		List<CharacterType> list2;
		bool flag4 = list2 == null;
		nint num3;
		list = (List<CharacterType>)num3;
		List<CharacterType> collection;
		if (!flag4)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1676 @ rax_v58 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			((List<System.Int32Enum>)(object)list2).InsertRange(0, (IEnumerable<System.Int32Enum>)collection);
			PlayerOptions playerOptions2 = _playerOptions;
			bool flag5 = _playerOptions == null;
			list = list2;
			if (!flag5)
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
								goto IL_0aa4;
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
				goto IL_0aa4;
			}
		}
		goto IL_07d6;
		IL_0915:
		if (playerOptionsData != null)
		{
			list = playerOptionsData._003CBoughtCharacters_003Ek__BackingField;
			if (playerOptionsData._003CBoughtCharacters_003Ek__BackingField != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ rcx_v22 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
				if ((nint)0 >= (nint)4)
				{
					goto IL_0b13;
				}
				List<CharacterType> list3 = new List<CharacterType>();
				bool flag6 = list3 == null;
				list = list3;
				if (!flag6)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1163 @ rax_v52 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
					_ = (nint)0 + (nint)1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1163 @ rax_v52 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
					list = (List<CharacterType>)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1163 @ rax_v52 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
					object obj12 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1163 @ rax_v52 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1163 @ rax_v52 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
						nint num4 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ rcx_v22 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
						if (num4 >= 0)
						{
							((List<System.Int32Enum>)(object)list3).AddWithResize((System.Int32Enum)1);
						}
						else
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1163 @ rax_v52 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
							object obj13 = (nint)0 + (nint)1;
							_ = 1;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1163 @ rax_v52 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
						_ = (nint)0 + (nint)1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1163 @ rax_v52 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
						list = (List<CharacterType>)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1163 @ rax_v52 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
						object obj14 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1163 @ rax_v52 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1163 @ rax_v52 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
							nint num5 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ rcx_v22 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
							if (num5 >= 0)
							{
								((List<System.Int32Enum>)(object)list3).AddWithResize((System.Int32Enum)2);
							}
							else
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1163 @ rax_v52 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
								object obj15 = (nint)0 + (nint)1;
								_ = 2;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1163 @ rax_v52 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
							_ = (nint)0 + (nint)1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1163 @ rax_v52 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
							list = (List<CharacterType>)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1163 @ rax_v52 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
							object obj16 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1163 @ rax_v52 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1163 @ rax_v52 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
								nint num6 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ rcx_v22 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
								if (num6 >= 0)
								{
									((List<System.Int32Enum>)(object)list3).AddWithResize((System.Int32Enum)3);
								}
								else
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1163 @ rax_v52 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
									object obj17 = (nint)0 + (nint)1;
									_ = 3;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1163 @ rax_v52 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
								_ = (nint)0 + (nint)1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1163 @ rax_v52 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
								list = (List<CharacterType>)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1163 @ rax_v52 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
								object obj18 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1163 @ rax_v52 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
								if ((nint)0 != 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1163 @ rax_v52 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
									nint num7 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ rcx_v22 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
									if (num7 >= 0)
									{
										((List<System.Int32Enum>)(object)list3).AddWithResize((System.Int32Enum)4);
										int32Enum = (System.Int32Enum)4;
									}
									else
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1163 @ rax_v52 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
										object obj19 = (nint)0 + (nint)1;
										_ = 4;
										int32Enum = (System.Int32Enum)4;
									}
									list2 = new List<CharacterType>();
									nint num8 = (nint)typeof(AdventureManager);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1722 @ rax_v63 (Il2CppClass<VampireSurvivors.App.Scripts.Framework.Adventures.AdventureManager>)+B8]");
									num3 = 0;
									bool flag7 = !AdventureManager._003CIsInAdventureMode_003Ek__BackingField;
									collection = list3;
									if (flag7)
									{
										goto IL_0a5a;
									}
									AdventureManager adventureManager = _adventureManager;
									bool flag8 = _adventureManager == null;
									list = (List<CharacterType>)num3;
									if (!flag8)
									{
										AdventureData adventureData = adventureManager._003CAdventureData_003Ek__BackingField;
										bool flag9 = adventureManager._003CAdventureData_003Ek__BackingField == null;
										list = (List<CharacterType>)num3;
										if (!flag9)
										{
											collection = adventureData._003CCharacterTypes_003Ek__BackingField;
											goto IL_0a5a;
										}
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_07d6;
	}

	private IEnumerator SelectAfterFrameDelay()
	{
		_003CSelectAfterFrameDelay_003Ed__54 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	public unsafe void StartGame()
	{
		//IL_00fb: Expected O, but got Ref
		//IL_072f: Expected I, but got O
		//IL_0760: Expected O, but got I
		//IL_01e1: Expected O, but got I4
		//IL_03e5: Expected O, but got I
		//IL_018e: Expected O, but got I
		//IL_05a0: Expected O, but got I4
		//IL_02d0: Expected O, but got I4
		//IL_02e6: Expected O, but got I
		//IL_02ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f4: Expected O, but got Unknown
		//IL_0434: Expected I4, but got O
		//IL_0464: Unknown result type (might be due to invalid IL or missing references)
		//IL_0469: Expected O, but got Unknown
		//IL_04a9: Expected O, but got I
		//IL_0386: Expected I, but got O
		//IL_02be: Expected I, but got O
		Debug.Log("Starting Game");
		PlayerOptions playerOptions = _playerOptions;
		if (_playerOptions != null)
		{
			PlayerOptionsData config = _playerOptions.Config;
			if (config != null)
			{
				playerOptions = (PlayerOptions)(object)config.OnlineMultiplayerSelections;
				if (config.OnlineMultiplayerSelections != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v570 @ rcx_v7 (VampireSurvivors.Objects.PlayerOptions)+1C]");
					_ = (nint)0 + (nint)1;
					playerOptions.PowerUpPurchased = null;
					bool flag = (object)OnlineStageManager._instance == null;
					playerOptions = (PlayerOptions)(object)OnlineStageManager._instance;
					if (!flag)
					{
						IEnumerable<PlayerInfo> enumerable = OnlineStageManager._instance.IterateSeats();
						bool flag2 = enumerable == null;
						playerOptions = (PlayerOptions)(object)OnlineStageManager._instance;
						if (!flag2)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
							object obj2 = default(object);
							object obj = (object)(&obj2);
							playerOptions = null;
							object obj3 = default(object);
							object obj11 = default(object);
							object obj12 = default(object);
							while (true)
							{
								object obj5;
								object obj10;
								if (obj2 != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
									if (obj3 == null)
									{
										break;
									}
									bool flag3 = obj2 == null;
									playerOptions = null;
									if (!flag3)
									{
										object obj4 = obj2;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v242 @ r10_v14+12E]");
										if ((nint)0 >= (nint)0)
										{
											goto IL_01ce;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v242 @ r10_v14+B0]");
										obj5 = 0;
										int num = 0;
										while (true)
										{
											object obj6 = num + num;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v253 @ r8_v22+v709 @ rax_v87*8]");
											if (0 == (nint)typeof(IEnumerator<PlayerInfo>))
											{
												break;
											}
											num++;
											int num2 = num;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v242 @ r10_v14+12E]");
											if ((nint)num2 < (nint)0)
											{
												continue;
											}
											goto IL_01ce;
										}
										object obj7 = num + num;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v253 @ r8_v22+8+v782 @ rcx_v67*8]");
										object obj8 = (nint)0 << 4;
										object obj9 = obj8 + 312;
										obj10 = obj9 + obj4;
										goto IL_063c;
									}
									throw new NullReferenceException();
								}
								throw new NullReferenceException();
								IL_063c:
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v787 @ rdx_v33] (should have been resolved before IL gen)");
								if (obj11 != null)
								{
									playerOptions = _playerOptions;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v803 @ rax_v67+10]");
									if ((nint)0 != 0)
									{
										if (_playerOptions != null)
										{
											PlayerOptionsData config2 = _playerOptions.Config;
											if (config2 != null)
											{
												playerOptions = (PlayerOptions)(object)config2.OnlineMultiplayerSelections;
												if (config2.OnlineMultiplayerSelections != null)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A99240");
													nint num3 = (nint)typeof(IEnumerator<PlayerInfo>);
													continue;
												}
												throw new NullReferenceException();
											}
											throw new NullReferenceException();
										}
										throw new NullReferenceException();
									}
								}
								else
								{
									playerOptions = _playerOptions;
								}
								if (playerOptions != null)
								{
									PlayerOptionsData config3 = playerOptions.Config;
									if (config3 != null)
									{
										playerOptions = (PlayerOptions)(object)config3.OnlineMultiplayerSelections;
										if (config3.OnlineMultiplayerSelections != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A99240");
											nint num3 = (nint)typeof(IEnumerator<PlayerInfo>);
											continue;
										}
										throw new NullReferenceException();
									}
									throw new NullReferenceException();
								}
								throw new NullReferenceException();
								IL_01ce:
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
								obj5 = 0;
								obj10 = obj12;
								goto IL_063c;
							}
							if (obj != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
							}
							nint num4 = (nint)typeof(OnlineStageManager);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v117 @ rax_v32 (Il2CppClass<VampireSurvivors.OnlineStageManager>)+B8]");
							nint num5 = 0;
							OnlineStageManager instance = OnlineStageManager._instance;
							bool flag4 = (object)OnlineStageManager._instance == null;
							playerOptions = (PlayerOptions)num5;
							if (!flag4)
							{
								CoherenceSync sync = instance._sync;
								bool flag5 = (object)instance._sync == null;
								playerOptions = (PlayerOptions)num5;
								if (!flag5)
								{
									NetworkEntityState networkEntityState = sync._003CEntityState_003Ek__BackingField;
									if (sync._003CEntityState_003Ek__BackingField != null)
									{
										playerOptions = (PlayerOptions)(object)networkEntityState._003CAuthorityType_003Ek__BackingField;
										if (networkEntityState._003CAuthorityType_003Ek__BackingField == null)
										{
											goto IL_0514;
										}
										bool flag6 = (byte)(int)playerOptions.RunGoldUpdated != 0;
										if ((nint)playerOptions.RunGoldUpdated != 1)
										{
											object obj13 = playerOptions.RunGoldUpdated - 3;
											bool flag7 = obj13 == null;
											flag6 = flag7;
										}
										if (!flag6)
										{
											goto IL_04c9;
										}
									}
									object instance2 = OnlineStageManager._instance;
									if ((object)OnlineStageManager._instance != null)
									{
										Action action = OnlineStageManager._instance.LockOnlineUI;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ rbx_v16 (System.Object)+78]");
										if ((nint)0 != 0)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ rbx_v16 (System.Object)+78]");
											bool flag8 = ((CoherenceSync)0).SendCommand(action, MessageTarget.All);
											OnlineStageManager._003C_WaitToStartOnline_003Ed__94 obj14 = null;
											obj14._003C_003E1__state = 0;
											obj14._003C_003E4__this = OnlineStageManager._instance;
											Coroutine coroutine = OnlineStageManager._instance.StartCoroutine(obj14);
											goto IL_04c9;
										}
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_0514;
		IL_0514:
		throw new NullReferenceException();
		IL_04c9:
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Detune = 200f;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.ClickIn, soundConfig, 0f, 10, time);
	}

	public unsafe void SelectCharacter(bool fromUnlock)
	{
		//IL_016b: Expected O, but got Ref
		CharacterItemUI selectedCharacter = _selectedCharacter;
		if (_selectedCharacter.IsCharAvailable())
		{
			SkinItem currentSkinItem = selectedCharacter._charItem.GetCurrentSkinItem();
			if (currentSkinItem == null || currentSkinItem._unlockState == UIUnlockStates.AVAILABLE)
			{
				PlayerOptionsData config = _playerOptions.Config;
				PlayerInfo myPlayerInfo = OnlineStageManager._instance.GetMyPlayerInfo();
				config.SelectedCharacter = myPlayerInfo._selectedCharacter;
				if (OnlineStageManager._instance.IsHost)
				{
					GameObject gameObject = ConfirmButton.gameObject;
					gameObject.SetActive(value: false);
					GameObject gameObject2 = StartButton.gameObject;
					gameObject2.SetActive(value: true);
					StartButton.Select();
				}
				Debug.Log("Stack");
				if (!fromUnlock)
				{
					object obj = default(object);
					PanelBackground.color = (Color)(&obj);
				}
				PlayerOptionsData config2 = _playerOptions.Config;
				object obj2 = ((Dictionary<System.Int32Enum, object>)(object)_characterItems).get_Item((System.Int32Enum)config2._selectedChar);
				((CharacterItemUI)obj2).SetSelected();
				SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
				soundConfig.Rate = 1f;
				soundConfig.Detune = 100f;
				float time = default(float);
				PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.ClickIn, soundConfig, 0f, 10, time);
				Debug.Log("Detune 100");
				_characterConfirmed = true;
				PlayerInfo myPlayerInfo2 = OnlineStageManager._instance.GetMyPlayerInfo();
				myPlayerInfo2._isReadyToPlay = true;
				GameObject gameObject3 = ConfirmButton.gameObject;
				gameObject3.SetActive(value: false);
				PlayerOptionsData config3 = _playerOptions.Config;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9DAE0");
				return;
			}
		}
		BuyButton.Select();
	}

	public void SelectStage()
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

	private void UpdatePlayerInfoSelectedCharacter()
	{
		int mySeatNumber = OnlineStageManager._instance.GetMySeatNumber();
		if (_selectedPlayerSlotIndex != mySeatNumber)
		{
			List<FollowerData> aICharacters = MultiplayerManager.s_instance.AICharacters;
			FollowerData followerData = new FollowerData();
			followerData._003CEveryXLevels_003Ek__BackingField = 3;
			followerData._003CShouldSharePassives_003Ek__BackingField = true;
			followerData._003CAllowDuplicates_003Ek__BackingField = true;
			followerData._003CCountsAsMainCharacterForRevivals_003Ek__BackingField = true;
			followerData._003CFollowerAI_003Ek__BackingField = AIType.Aggressive;
			CharacterItemUI selectedCharacter = _selectedCharacter;
			CharacterItem charItem = selectedCharacter._charItem;
			followerData._003CFollowerCharacter_003Ek__BackingField = charItem._characterType;
			followerData._003CManualLevelUps_003Ek__BackingField = true;
			followerData._003CShouldFollowMainPlayer_003Ek__BackingField = true;
			if (_selectedPlayerSlotIndex < aICharacters._size)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				int version = aICharacters._version + 1;
				aICharacters._version = version;
				List<OnlineMPPlayerItem> players = _players;
				int selectedPlayerSlotIndex = _selectedPlayerSlotIndex;
				if (_selectedPlayerSlotIndex < players._size)
				{
					OnlineMPPlayerItem[] items = players._items;
					CharacterItemUI selectedCharacter2 = _selectedCharacter;
					CharacterItem charItem2 = selectedCharacter2._charItem;
					items[selectedPlayerSlotIndex].SetAIData(charItem2._characterType, _selectedPlayerSlotIndex);
					return;
				}
			}
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
		else
		{
			PlayerInfo myPlayerInfo = OnlineStageManager._instance.GetMyPlayerInfo();
			CharacterItemUI selectedCharacter3 = _selectedCharacter;
			CharacterItem charItem3 = selectedCharacter3._charItem;
			myPlayerInfo._selectedCharacter = charItem3._characterType;
			Action<CharacterType> onCharacterSelectionChanged = myPlayerInfo.OnCharacterSelectionChanged;
			if (myPlayerInfo.OnCharacterSelectionChanged != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v433 @ rax_v14 (System.Action`1<VampireSurvivors.Data.CharacterType>)+18] (should have been resolved before IL gen)");
			}
		}
	}

	public unsafe void BuyCharacter()
	{
		//IL_0032: Expected I4, but got O
		//IL_00a8: Expected O, but got I
		//IL_0063: Expected O, but got I
		//IL_03c6: Expected O, but got Ref
		//IL_025e: Expected O, but got I4
		float price = _selectedCharacter.GetPrice();
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si esi,xmm0\"");
		CharacterType characterType = (CharacterType)_playerOptions;
		int num = default(int);
		if (!AdventureManager._003CIsInAdventureMode_003Ek__BackingField)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rdx_v4 (VampireSurvivors.Data.CharacterType)+50]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ rax_v52+84]");
			bool flag = (nint)num <= (nint)0;
			int num2 = num;
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rdx_v4 (VampireSurvivors.Data.CharacterType)+78]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ rax_v50+84]");
			bool flag2 = (nint)num > (nint)0;
			int num2 = num;
			if (flag2)
			{
				return;
			}
		}
		CharacterItemUI selectedCharacter = _selectedCharacter;
		CharacterItem charItem = selectedCharacter._charItem;
		if (charItem._unlockState != UIUnlockStates.PURCHASABLE)
		{
			if (charItem._unlockState == UIUnlockStates.AVAILABLE)
			{
				SkinItem currentSkinItem = charItem.GetCurrentSkinItem();
				bool flag3 = currentSkinItem == null;
				characterType = CharacterType.VOID;
				if (!flag3)
				{
					bool flag4 = currentSkinItem._unlockState != UIUnlockStates.PURCHASABLE;
					characterType = CharacterType.VOID;
					if (!flag4)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18699C0C0");
						PlayerOptions playerOptions = _playerOptions;
						object obj3 = default(object);
						playerOptions.BuySkin(config: (obj3 != null) ? playerOptions._currentAdventureSaveData : playerOptions._mainGameConfig, skinType: currentSkinItem._skinType);
						PlayerOptionsData config = _playerOptions.Config;
						CharacterData currentData = _currentData;
						bool flag5 = ((Dictionary<System.Int32Enum, System.Int32Enum>)(object)config._003CSelectedSkinsV2_003Ek__BackingField).TryInsert((System.Int32Enum)_currentType, (System.Int32Enum)currentData._003CcurrentSkin_003Ek__BackingField, System.Collections.Generic.InsertionBehavior.OverwriteExisting);
						System.Collections.Generic.InsertionBehavior insertionBehavior = System.Collections.Generic.InsertionBehavior.OverwriteExisting;
						PlayerOptionsData playerOptionsData = (PlayerOptionsData)currentData._003CcurrentSkin_003Ek__BackingField;
						characterType = _currentType;
					}
				}
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18699C0C0");
			CharacterItemUI selectedCharacter2 = _selectedCharacter;
			object obj4 = default(object);
			CharacterItem charItem2;
			PlayerOptionsData playerOptionsData;
			if (obj4 == null)
			{
				charItem2 = selectedCharacter2._charItem;
				PlayerOptions playerOptions2 = _playerOptions;
				playerOptionsData = playerOptions2._mainGameConfig;
			}
			else
			{
				charItem2 = selectedCharacter2._charItem;
				PlayerOptions playerOptions3 = _playerOptions;
				playerOptionsData = playerOptions3._currentAdventureSaveData;
			}
			characterType = charItem2._characterType;
			_playerOptions.BuyCharacter(charItem2._characterType, playerOptionsData);
			System.Collections.Generic.InsertionBehavior insertionBehavior = System.Collections.Generic.InsertionBehavior.None;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18699C0C0");
		PlayerOptions playerOptions4 = _playerOptions;
		object obj5 = default(object);
		PlayerOptionsData config2 = ((obj5 != null) ? playerOptions4._currentAdventureSaveData : playerOptions4._mainGameConfig);
		playerOptions4.RemoveCoins(num, removeFromLifetime: true, config2);
		GameObject gameObject = BuyButton.gameObject;
		gameObject.SetActive(value: false);
		GameObject gameObject2 = Price.gameObject;
		gameObject2.SetActive(value: false);
		object obj6 = default(object);
		Icon.color = (Color)(&obj6);
		SetSkinSlots();
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Detune = -400f;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.ClickOut, soundConfig, 0f, 10, time);
		Debug.Log("Detune 400");
		_selectedCharacter.SetSelected();
		UpdateStatsPanelVisibility();
		_selectedCharacter.Refresh();
		EventSystem current = EventSystem.current;
		GameObject selectedGameObject = _selectedCharacter.gameObject;
		current.SetSelectedGameObject(selectedGameObject);
		_characterBoughtThisFrame = true;
	}

	private unsafe void WrapNavigation()
	{
		//IL_0018: Expected O, but got I4
		//IL_0061: Expected O, but got I4
		//IL_013a: Expected O, but got I4
		//IL_014d: Expected O, but got I4
		//IL_0196: Expected O, but got I4
		//IL_01e5: Expected O, but got I4
		//IL_028f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0294: Expected O, but got Unknown
		//IL_029d: Invalid comparison between F4 and O
		//IL_02e2: Expected O, but got Ref
		//IL_0324: Unknown result type (might be due to invalid IL or missing references)
		//IL_0329: Expected O, but got Unknown
		//IL_0341: Expected O, but got I4
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
				Selectable right = default(Selectable);
				ForceBackButtonNavigation(component, component2, null, right);
				Selectable component3 = BackButtonController.Instance.GetComponent<Selectable>();
				LayoutRebuilder.ForceRebuildLayoutImmediate(_content);
				Canvas.ForceUpdateCanvases();
				List<GameObject> spawned3 = _spawned;
				Selectable selectable = (Selectable)spawned3._size;
				object obj3 = spawned3._size - 1;
				if ((nint)obj3 < spawned3._size)
				{
					GameObject[] items3 = spawned3._items;
					object obj4 = spawned3._size - 1;
					RectTransform component4 = items3[obj4].GetComponent<RectTransform>();
					Vector2 anchoredPosition = component4.anchoredPosition;
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
						RectTransform component5 = items4[obj5].GetComponent<RectTransform>();
						Vector2 anchoredPosition2 = component5.anchoredPosition;
						object obj6 = obj7 - obj7;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
						object obj8 = obj6 & 0;
						if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj8))
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
							Selectable component6 = gameObject.GetComponent<Selectable>();
							component6.navigation = (Navigation)(&obj9);
							SetNavigationDown(component6, component3);
							SetNavigationRight(component6);
							SetNavigationLeft(component6);
							SetNavigationUp(component6);
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

	private unsafe bool IsCharacterHighlightedByOtherPlayer(CharacterType cType)
	{
		//IL_008a: Expected O, but got I4
		//IL_00a5: Expected O, but got I
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Expected O, but got Unknown
		//IL_00ee: Expected O, but got I
		//IL_0127: Expected O, but got I
		//IL_0122: Expected native int or pointer, but got O
		IEnumerable<PlayerInfo> enumerable = OnlineStageManager._instance.IterateSeats();
		if (enumerable != null)
		{
			System.Linq.Buffer<object> buffer = new System.Linq.Buffer<object>((IEnumerable<object>)enumerable);
			System.Linq.Buffer<PlayerInfo> buffer2 = default(System.Linq.Buffer<PlayerInfo>);
			IEnumerable<PlayerInfo> source = buffer2.ToArray();
			int num = Enumerable.Count(source);
			if (num > 0)
			{
				object obj = 0;
				nint num2 = 0;
				OnlineStageManager onlineStageManager = default(OnlineStageManager);
				bool flag;
				do
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v256 @ rax_v16 (System.Collections.Generic.IEnumerable`1<VampireSurvivors.PlayerInfo>)+20+v90 @ rbx_v9*8]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v256 @ rax_v16 (System.Collections.Generic.IEnumerable`1<VampireSurvivors.PlayerInfo>)+20+v90 @ rbx_v9*8]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rsi_v8+10]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v256 @ rax_v16 (System.Collections.Generic.IEnumerable`1<VampireSurvivors.PlayerInfo>)+20+v90 @ rbx_v9*8]");
							System.Linq.Buffer<PlayerInfo> buffer3 = (System.Linq.Buffer<PlayerInfo>)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rcx_v25 (System.Linq.Buffer`1<VampireSurvivors.PlayerInfo>)+50]");
							if ((nint)cType == (nint)0)
							{
								System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)buffer3, new System.Linq.Buffer<PlayerInfo>((IEnumerable<PlayerInfo>)num2));
								int mySeatNumber = onlineStageManager.GetMySeatNumber();
								if ((nint)obj != mySeatNumber)
								{
									return true;
								}
							}
						}
					}
					obj++;
					int num3 = Enumerable.Count(source);
					flag = (nint)obj < num3;
					num2 = 0;
				}
				while (flag);
			}
			return false;
		}
		Exception ex = System.Linq.Error.ArgumentNull("source");
		throw ex;
	}

	private unsafe void DisableButtons()
	{
		//IL_0078: Expected O, but got I4
		//IL_0081: Expected O, but got Ref
		//IL_016c: Expected O, but got I4
		IEnumerable<PlayerInfo> enumerable = OnlineStageManager._instance.IterateSeats();
		if (enumerable != null)
		{
			System.Linq.Buffer<object> buffer = new System.Linq.Buffer<object>((IEnumerable<object>)enumerable);
			System.Linq.Buffer<object> buffer2 = default(System.Linq.Buffer<object>);
			PlayerInfo[] array = ((System.Linq.Buffer<PlayerInfo>*)(&buffer2))->ToArray();
			List<GameObject>.Enumerator enumerator = default(List<GameObject>.Enumerator);
			while (true)
			{
				if (!enumerator.MoveNext())
				{
					return;
				}
				bool flag = array == null;
				object obj = 0;
				List<GameObject>.Enumerator enumerator2 = (List<GameObject>.Enumerator)(&enumerator);
				if (!flag)
				{
					if ((nint)obj >= array.Length)
					{
						continue;
					}
					PlayerInfo playerInfo = array[obj];
					if ((object)array[obj] != null && ((UnityEngine.Object)playerInfo).m_CachedPtr != (IntPtr)0)
					{
						if ((nint)obj >= array.Length)
						{
							break;
						}
						PlayerInfo playerInfo2 = array[obj];
						bool flag2 = (object)array[obj] == null;
						enumerator2 = (List<GameObject>.Enumerator)typeof(UnityEngine.Object);
						if (!flag2)
						{
							playerInfo = (PlayerInfo)playerInfo2._selectedCharacter;
							enumerator2 = (List<GameObject>.Enumerator)typeof(UnityEngine.Object);
							throw new NullReferenceException();
						}
						throw new NullReferenceException();
					}
				}
				throw new NullReferenceException();
			}
			throw new IndexOutOfRangeException();
		}
		Exception ex = System.Linq.Error.ArgumentNull("source");
		throw ex;
	}

	private unsafe bool ShouldSelectionChangesBeBlocked()
	{
		//IL_02c8: Expected I4, but got O
		//IL_0068: Expected O, but got Ref
		//IL_0076: Expected I, but got O
		//IL_0135: Expected O, but got I4
		//IL_00e2: Expected O, but got I
		//IL_00eb: Expected O, but got I4
		//IL_01f9: Expected O, but got I
		//IL_0202: Unknown result type (might be due to invalid IL or missing references)
		//IL_0207: Expected O, but got Unknown
		//IL_0155: Expected I, but got O
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Expected O, but got Unknown
		//IL_0331: Expected I, but got O
		//IL_0184: Expected I, but got O
		//IL_0192: Expected I, but got O
		//IL_01c3: Expected I, but got O
		//IL_01d1: Expected I, but got O
		if (_isUILocked)
		{
			return true;
		}
		if ((object)OnlineStageManager._instance != null)
		{
			if (OnlineStageManager._instance.IsHost)
			{
				return false;
			}
			if ((object)OnlineStageManager._instance != null)
			{
				IEnumerable<PlayerInfo> enumerable = OnlineStageManager._instance.IterateSeats();
				if (enumerable != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
					object obj2 = default(object);
					object obj = (object)(&obj2);
					bool flag = true;
					nint num = unchecked((nint)null);
					object obj3 = default(object);
					object obj13 = default(object);
					object obj14 = default(object);
					while (true)
					{
						object obj5;
						object obj12;
						if (obj2 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
							if (obj3 != null)
							{
								object obj4 = obj2;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v263 @ r10_v3+12E]");
								if ((nint)0 >= (nint)0)
								{
									goto IL_0122;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v263 @ r10_v3+B0]");
								obj5 = 0;
								object obj6 = 0;
								while (true)
								{
									object obj7 = obj6 + obj6;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v268 @ r8_v7+v370 @ rax_v39*8]");
									if (0 == (nint)typeof(IEnumerator<PlayerInfo>))
									{
										break;
									}
									obj6++;
									object obj8 = obj6;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v263 @ r10_v3+12E]");
									if ((nint)obj8 < 0)
									{
										continue;
									}
									goto IL_0122;
								}
								object obj9 = obj6 + obj6;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v268 @ r8_v7+8+v426 @ rcx_v29*8]");
								object obj10 = (nint)0 << 4;
								object obj11 = obj10 + 312;
								obj12 = obj11 + obj4;
								goto IL_035c;
							}
							if (obj != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
							}
							break;
						}
						throw new NullReferenceException();
						IL_035c:
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v431 @ rdx_v11] (should have been resolved before IL gen)");
						num = (nint)typeof(UnityEngine.Object);
						bool flag2 = obj13 == null;
						nint num2 = (nint)typeof(IEnumerator<PlayerInfo>);
						if (!flag2)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v447 @ rax_v24+10]");
							bool flag3 = (nint)0 == 0;
							num2 = (nint)typeof(IEnumerator<PlayerInfo>);
							num = (nint)typeof(UnityEngine.Object);
							if (!flag3)
							{
								bool num3 = flag;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v447 @ rax_v24+58]");
								flag = (byte)((nuint)(num3 ? 1 : 0) & (nuint)0u) != 0;
								num2 = (nint)typeof(IEnumerator<PlayerInfo>);
								num = (nint)typeof(UnityEngine.Object);
							}
						}
						continue;
						IL_0122:
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
						obj5 = 0;
						obj12 = obj14;
						goto IL_035c;
					}
					return flag;
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public unsafe void ShowCharacterInfo(CharacterData charData, CharacterType cType, CharacterItemUI character)
	{
		//IL_0140: Expected I, but got O
		//IL_01ed: Expected I, but got O
		//IL_0399: Expected O, but got I
		//IL_03ef: Expected O, but got I4
		//IL_07aa: Expected O, but got I
		//IL_07bf: Expected O, but got I
		//IL_0685: Expected O, but got I
		//IL_0944: Expected O, but got I4
		//IL_20db: Expected O, but got I4
		//IL_0931: Unknown result type (might be due to invalid IL or missing references)
		//IL_0936: Expected O, but got Unknown
		//IL_09eb: Expected O, but got Ref
		//IL_0a43: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a48: Expected O, but got Unknown
		//IL_0a51: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a56: Expected I4, but got Unknown
		//IL_09a5: Expected F4, but got I4
		//IL_09ae: Expected F4, but got I4
		//IL_09b7: Expected F4, but got I4
		//IL_0bc6: Expected I, but got O
		//IL_0c86: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c8b: Expected I4, but got Unknown
		//IL_1cf0: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cf5: Expected I4, but got Unknown
		//IL_1db8: Expected I, but got O
		//IL_1dca: Expected I, but got O
		//IL_1e0f: Expected I, but got O
		//IL_1e21: Expected I, but got O
		//IL_1e72: Expected O, but got Ref
		//IL_14ff: Expected I, but got O
		//IL_152f: Expected O, but got I4
		//IL_2253: Expected O, but got I4
		//IL_1547: Expected O, but got I4
		//IL_1550: Expected O, but got I4
		//IL_14ed: Expected O, but got Ref
		//IL_1398: Expected O, but got I4
		//IL_1957: Expected O, but got I4
		//IL_1796: Expected I4, but got O
		//IL_17a4: Expected I4, but got O
		//IL_17c8: Expected O, but got I4
		//IL_17d1: Expected O, but got I4
		//IL_17ee: Expected O, but got I4
		//IL_17f7: Expected O, but got I4
		//IL_1b6d: Expected O, but got Ref
		CharacterItemUI typeFromHandle;
		if (!ShouldSelectionChangesBeBlocked())
		{
			_currentData = charData;
			_currentType = cType;
			CharacterItemUI selectedCharacter = _selectedCharacter;
			bool flag = (object)_selectedCharacter == null;
			typeFromHandle = (CharacterItemUI)(object)typeof(UnityEngine.Object);
			if (!flag)
			{
				bool flag2 = ((UnityEngine.Object)selectedCharacter).m_CachedPtr == (IntPtr)0;
				typeFromHandle = (CharacterItemUI)(object)typeof(UnityEngine.Object);
				if (!flag2)
				{
					typeFromHandle = _selectedCharacter;
					if ((object)_selectedCharacter == null)
					{
						goto IL_1fe2;
					}
					_selectedCharacter.UnSelect();
				}
			}
			_selectedCharacter = character;
			TextMeshProUGUI textMeshProUGUI = _Name;
			if (charData != null)
			{
				string fullName = charData.GetFullName(cType);
				bool flag3 = (object)_Name == null;
				typeFromHandle = (CharacterItemUI)(object)charData;
				if (!flag3)
				{
					nint num = (nint)textMeshProUGUI;
					_Name.text = fullName;
					bool flag4 = (object)_LockIcon == null;
					typeFromHandle = (CharacterItemUI)(object)_LockIcon;
					if (!flag4)
					{
						GameObject gameObject = _LockIcon.gameObject;
						bool flag5 = (object)gameObject == null;
						typeFromHandle = (CharacterItemUI)(object)_LockIcon;
						if (!flag5)
						{
							gameObject.SetActive(value: false);
							typeFromHandle = (CharacterItemUI)(object)_Name;
							if ((object)_Name != null)
							{
								nint num2 = (nint)typeFromHandle;
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2362 @ rdx_v16 (Il2CppClass<VampireSurvivors.UI.CharacterItemUI>)+548] (should have been resolved before IL gen)");
								object obj = default(object);
								if (obj != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2365 @ rax_v39+10]");
									if ((nint)0 > (nint)0 && cType != CharacterType.ARENGIJUS && cType != CharacterType.EXDASH)
									{
										goto IL_02bc;
									}
								}
								string fullNameUntranslated = charData.GetFullNameUntranslated();
								bool flag6 = (object)_Name == null;
								typeFromHandle = (CharacterItemUI)(object)charData;
								if (!flag6)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18634B7A0");
									goto IL_02bc;
								}
							}
						}
					}
				}
			}
		}
		else if ((object)character != null)
		{
			character.UnSelect();
			CharacterItemUI selectedCharacter2 = _selectedCharacter;
			if ((object)_selectedCharacter == null || ((UnityEngine.Object)selectedCharacter2).m_CachedPtr == (IntPtr)0)
			{
				return;
			}
			if ((object)_selectedCharacter != null)
			{
				_selectedCharacter.SetSelected();
				if ((object)_selectedCharacter != null)
				{
					Button component = _selectedCharacter.GetComponent<Button>();
					if ((object)component != null)
					{
						component.Select();
						return;
					}
				}
			}
		}
		goto IL_1fe2;
		IL_208e:
		PlayerOptionsData playerOptionsData;
		bool flag7;
		object obj2;
		bool flag8;
		object obj3;
		if (playerOptionsData != null)
		{
			typeFromHandle = (CharacterItemUI)(object)playerOptionsData._003COpenedCoffins_003Ek__BackingField;
			if (playerOptionsData._003COpenedCoffins_003Ek__BackingField != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9ACE0");
				flag7 = obj2 == null;
				if (!flag7)
				{
					flag7 = !flag8;
					if (!flag8)
					{
						object obj4 = default(object);
						obj3 = obj4 ^ 1;
						goto IL_20d0;
					}
				}
				obj3 = 0;
				goto IL_20d0;
			}
		}
		goto IL_1fe2;
		IL_21c1:
		DataManager dataManager = _dataManager;
		bool flag9;
		if (_dataManager != null)
		{
			nint num3 = (nint)dataManager._003CAllAchievements_003Ek__BackingField;
			if (dataManager._003CAllAchievements_003Ek__BackingField != null)
			{
				List<VampireSurvivors.Achievements.AchievementData>.Enumerator enumerator = (List<VampireSurvivors.Achievements.AchievementData>.Enumerator)2;
				Dictionary<AchievementType, VampireSurvivors.Achievements.AchievementData>.Enumerator enumerator2 = default(Dictionary<AchievementType, VampireSurvivors.Achievements.AchievementData>.Enumerator);
				while (enumerator2.MoveNext())
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
					List<VampireSurvivors.Achievements.AchievementData>.Enumerator enumerator3 = (List<VampireSurvivors.Achievements.AchievementData>.Enumerator)0;
					enumerator = (List<VampireSurvivors.Achievements.AchievementData>.Enumerator)0;
				}
				flag9 = false;
				List<VampireSurvivors.Achievements.AchievementData>.Enumerator enumerator4 = (List<VampireSurvivors.Achievements.AchievementData>.Enumerator)0;
				bool flag10 = (byte)num3 != 0;
				bool flag11 = _playerOptions == null;
				typeFromHandle = (CharacterItemUI)(object)_playerOptions;
				if (!flag11)
				{
					PlayerOptionsData config = _playerOptions.Config;
					bool flag12 = config == null;
					typeFromHandle = (CharacterItemUI)(object)_playerOptions;
					if (!flag12)
					{
						if (!config.HasCollectedItem(ItemType.RELIC_SECRETS))
						{
							SetCharPanelDescription("", isHidden: true, isSecret: true);
							flag9 = false;
							enumerator4 = (List<VampireSurvivors.Achievements.AchievementData>.Enumerator)0;
							flag10 = true;
							goto IL_2297;
						}
						DataManager dataManager2 = _dataManager;
						bool flag13 = _dataManager == null;
						typeFromHandle = (CharacterItemUI)(object)config;
						if (!flag13)
						{
							flag10 = (byte)(int)dataManager2._003CAllSecrets_003Ek__BackingField != 0;
							bool flag14 = (byte)(int)(~dataManager2._003CAllSecrets_003Ek__BackingField) != 0;
							typeFromHandle = (CharacterItemUI)(object)config;
							if (!flag14)
							{
								enumerator = (List<VampireSurvivors.Achievements.AchievementData>.Enumerator)2;
								enumerator4 = (List<VampireSurvivors.Achievements.AchievementData>.Enumerator)0;
								Dictionary<SecretType, SecretData>.Enumerator enumerator5 = default(Dictionary<SecretType, SecretData>.Enumerator);
								while (enumerator5.MoveNext())
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
									SecretData secretData = null;
									enumerator = (List<VampireSurvivors.Achievements.AchievementData>.Enumerator)0;
									enumerator4 = (List<VampireSurvivors.Achievements.AchievementData>.Enumerator)0;
								}
								flag9 = false;
								goto IL_2297;
							}
						}
					}
				}
			}
		}
		goto IL_1fe2;
		IL_2108:
		typeFromHandle = (CharacterItemUI)(object)PanelBackground;
		CharacterData characterData;
		object obj6;
		Vector2 vector = default(Vector2);
		if ((object)PanelBackground != null)
		{
			nint num4 = (nint)typeFromHandle;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2820 @ r8_v28 (Il2CppClass<VampireSurvivors.UI.CharacterItemUI>)+2A8] (should have been resolved before IL gen)");
			SetWeaponIconSprite(characterData);
			bool flag15 = (object)Price == null;
			typeFromHandle = (CharacterItemUI)(object)Price;
			if (!flag15)
			{
				GameObject gameObject2 = Price.gameObject;
				bool active;
				if (obj3 == null)
				{
					typeFromHandle = (CharacterItemUI)(object)Price;
					active = false;
				}
				else
				{
					typeFromHandle = (CharacterItemUI)(object)_tempUnlockedCoopCharacters;
					if (_tempUnlockedCoopCharacters == null)
					{
						goto IL_1fe2;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9ACE0");
					object obj5 = default(object);
					active = (byte)(obj5 ^ 1) != 0;
				}
				if ((object)gameObject2 != null)
				{
					gameObject2.SetActive(active);
					CharacterItemUI characterItemUI = default(CharacterItemUI);
					bool flag16 = (object)characterItemUI == null;
					typeFromHandle = characterItemUI;
					if (!flag16)
					{
						float price = characterItemUI.GetPrice();
						bool flag17 = (object)Price == null;
						typeFromHandle = characterItemUI;
						if (!flag17)
						{
							Price.SetPrice(price);
							bool flag18 = (object)BuyButton == null;
							typeFromHandle = (CharacterItemUI)(object)BuyButton;
							if (!flag18)
							{
								GameObject gameObject3 = BuyButton.gameObject;
								bool flag19 = (object)gameObject3 == null;
								typeFromHandle = (CharacterItemUI)(object)BuyButton;
								if (!flag19)
								{
									gameObject3.SetActive(value: false);
									UpdateStatsPanelVisibility();
									bool flag20 = (object)StatsPanel == null;
									typeFromHandle = (CharacterItemUI)(object)StatsPanel;
									if (!flag20)
									{
										StatsPanel.SetCharacter(characterData, cType);
										bool flag21 = (object)StartButton == null;
										typeFromHandle = (CharacterItemUI)(object)StartButton;
										if (!flag21)
										{
											GameObject gameObject4 = StartButton.gameObject;
											bool flag22 = (object)gameObject4 == null;
											typeFromHandle = (CharacterItemUI)(object)StartButton;
											if (!flag22)
											{
												gameObject4.SetActive(value: false);
												SetSkinSlots();
												bool flag23 = (object)_StageCompletionPanel == null;
												typeFromHandle = (CharacterItemUI)(object)_StageCompletionPanel;
												if (!flag23)
												{
													_StageCompletionPanel.SetPanel(cType);
													_characterConfirmed = false;
													bool flag24 = (object)OnlineStageManager._instance == null;
													typeFromHandle = (CharacterItemUI)(object)OnlineStageManager._instance;
													if (!flag24)
													{
														PlayerInfo myPlayerInfo = OnlineStageManager._instance.GetMyPlayerInfo();
														bool flag25 = (object)myPlayerInfo == null;
														typeFromHandle = (CharacterItemUI)(object)OnlineStageManager._instance;
														if (!flag25)
														{
															myPlayerInfo._isReadyToPlay = false;
															bool flag26 = (object)_selectedCharacter == null;
															typeFromHandle = _selectedCharacter;
															if (!flag26)
															{
																Button component2 = _selectedCharacter.GetComponent<Button>();
																SetNavigationUp(StartButton, component2);
																bool flag27 = (object)_selectedCharacter == null;
																typeFromHandle = _selectedCharacter;
																if (!flag27)
																{
																	Button component3 = _selectedCharacter.GetComponent<Button>();
																	SetNavigationUp(BuyButton, component3);
																	bool flag28 = (object)_selectedCharacter == null;
																	typeFromHandle = _selectedCharacter;
																	if (!flag28)
																	{
																		Button component4 = _selectedCharacter.GetComponent<Button>();
																		SetNavigationUp(ConfirmButton, component4);
																		bool flag29 = (object)Icon == null;
																		typeFromHandle = (CharacterItemUI)(object)Icon;
																		if (!flag29)
																		{
																			Button component5 = Icon.GetComponent<Button>();
																			bool flag30 = (object)_selectedCharacter == null;
																			typeFromHandle = _selectedCharacter;
																			if (!flag30)
																			{
																				Button component6 = _selectedCharacter.GetComponent<Button>();
																				SetNavigationUp(component5, component6);
																				bool flag31 = (object)Icon == null;
																				typeFromHandle = (CharacterItemUI)(object)Icon;
																				if (!flag31)
																				{
																					Button component7 = Icon.GetComponent<Button>();
																					ClearNavigationLeft(component7);
																					SetIconSizes();
																					if (characterData._003Chidden_003Ek__BackingField && obj6 == null)
																					{
																						bool flag32 = (object)_LockIcon == null;
																						typeFromHandle = (CharacterItemUI)(object)_LockIcon;
																						if (!flag32)
																						{
																							GameObject gameObject5 = _LockIcon.gameObject;
																							bool flag33 = (object)gameObject5 == null;
																							typeFromHandle = (CharacterItemUI)(object)_LockIcon;
																							if (!flag33)
																							{
																								gameObject5.SetActive(value: true);
																								bool flag34 = (object)Price == null;
																								typeFromHandle = (CharacterItemUI)(object)Price;
																								if (!flag34)
																								{
																									GameObject gameObject6 = Price.gameObject;
																									bool flag35 = (object)gameObject6 == null;
																									typeFromHandle = (CharacterItemUI)(object)Price;
																									if (!flag35)
																									{
																										gameObject6.SetActive(value: false);
																										bool flag36 = (object)_WeaponFrame == null;
																										typeFromHandle = (CharacterItemUI)(object)_WeaponFrame;
																										if (!flag36)
																										{
																											Image component8 = _WeaponFrame.GetComponent<Image>();
																											bool flag37 = (object)component8 == null;
																											typeFromHandle = (CharacterItemUI)(object)_WeaponFrame;
																											if (!flag37)
																											{
																												component8.enabled = false;
																												RenderingExtensions.SetAlpha(WeaponIcon, 0.35f);
																												RenderingExtensions.SetAlpha(Icon, 0.35f);
																												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186C0B080");
																												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186C0B200");
																												bool flag38 = (object)BuyButton == null;
																												typeFromHandle = (CharacterItemUI)(object)BuyButton;
																												if (!flag38)
																												{
																													GameObject gameObject7 = BuyButton.gameObject;
																													bool flag39 = (object)gameObject7 == null;
																													typeFromHandle = (CharacterItemUI)(object)BuyButton;
																													if (!flag39)
																													{
																														gameObject7.SetActive(value: false);
																														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18699C0C0");
																														object obj7 = default(object);
																														bool flag40 = obj7 == null;
																														typeFromHandle = (CharacterItemUI)(object)typeof(AdventureManager);
																														if (flag40)
																														{
																															goto IL_21c1;
																														}
																														AdventureManager adventureManager = _adventureManager;
																														bool flag41 = _adventureManager == null;
																														typeFromHandle = (CharacterItemUI)(object)typeof(AdventureManager);
																														if (!flag41)
																														{
																															AdventureData adventureData = adventureManager._003CAdventureData_003Ek__BackingField;
																															bool flag42 = adventureManager._003CAdventureData_003Ek__BackingField == null;
																															typeFromHandle = (CharacterItemUI)(object)typeof(AdventureManager);
																															if (!flag42)
																															{
																																bool flag43 = adventureData._003CProgressData_003Ek__BackingField == null;
																																typeFromHandle = (CharacterItemUI)(object)typeof(AdventureManager);
																																if (!flag43)
																																{
																																	List<VampireSurvivors.Achievements.AchievementData>.Enumerator enumerator6 = default(List<VampireSurvivors.Achievements.AchievementData>.Enumerator);
																																	while (enumerator6.MoveNext())
																																	{
																																		List<VampireSurvivors.Achievements.AchievementData>.Enumerator enumerator7 = (List<VampireSurvivors.Achievements.AchievementData>.Enumerator)0;
																																	}
																																	typeFromHandle = (CharacterItemUI)(&enumerator6);
																																	goto IL_21c1;
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
																					else
																					{
																						bool flag44 = (object)_LockIcon == null;
																						typeFromHandle = (CharacterItemUI)(object)_LockIcon;
																						if (!flag44)
																						{
																							GameObject gameObject8 = _LockIcon.gameObject;
																							bool flag45 = (object)gameObject8 == null;
																							typeFromHandle = (CharacterItemUI)(object)_LockIcon;
																							if (!flag45)
																							{
																								gameObject8.SetActive(value: false);
																								bool flag46 = (object)Price == null;
																								typeFromHandle = (CharacterItemUI)(object)Price;
																								if (!flag46)
																								{
																									GameObject gameObject9 = Price.gameObject;
																									bool active2;
																									if (obj3 == null)
																									{
																										typeFromHandle = (CharacterItemUI)(object)Price;
																										active2 = false;
																									}
																									else
																									{
																										typeFromHandle = (CharacterItemUI)(object)_tempUnlockedCoopCharacters;
																										if (_tempUnlockedCoopCharacters == null)
																										{
																											goto IL_1fe2;
																										}
																										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9ACE0");
																										object obj8 = default(object);
																										active2 = (byte)(obj8 ^ 1) != 0;
																									}
																									if ((object)gameObject9 != null)
																									{
																										gameObject9.SetActive(active2);
																										bool flag47 = (object)_WeaponFrame == null;
																										typeFromHandle = (CharacterItemUI)(object)_WeaponFrame;
																										if (!flag47)
																										{
																											Image component9 = _WeaponFrame.GetComponent<Image>();
																											bool flag48 = (object)component9 == null;
																											typeFromHandle = (CharacterItemUI)(object)_WeaponFrame;
																											if (!flag48)
																											{
																												component9.enabled = true;
																												CharacterItemUI weaponIcon = (CharacterItemUI)(object)WeaponIcon;
																												bool flag49 = (object)WeaponIcon == null;
																												typeFromHandle = (CharacterItemUI)(object)typeof(RenderingExtensions);
																												if (!flag49)
																												{
																													nint num5 = (nint)weaponIcon;
																													Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v3005 @ r8_v46 (Il2CppClass<VampireSurvivors.UI.CharacterItemUI>)+298] (should have been resolved before IL gen)");
																													nint num6 = (nint)weaponIcon;
																													Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v3026 @ rax_v114 (Il2CppClass<VampireSurvivors.UI.CharacterItemUI>)+2A8] (should have been resolved before IL gen)");
																													CharacterItemUI icon = (CharacterItemUI)(object)Icon;
																													bool flag50 = (object)Icon == null;
																													typeFromHandle = (CharacterItemUI)(object)WeaponIcon;
																													if (!flag50)
																													{
																														nint num7 = (nint)icon;
																														Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v3044 @ r8_v49 (Il2CppClass<VampireSurvivors.UI.CharacterItemUI>)+298] (should have been resolved before IL gen)");
																														nint num8 = (nint)icon;
																														Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v3061 @ rax_v118 (Il2CppClass<VampireSurvivors.UI.CharacterItemUI>)+2A8] (should have been resolved before IL gen)");
																														bool flag51 = (object)_Name == null;
																														typeFromHandle = (CharacterItemUI)(object)Icon;
																														if (!flag51)
																														{
																															Color color = _Name.color;
																															_Name.color = (Color)(&vector);
																															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186C0B200");
																															if (obj3 != null)
																															{
																																if (_tempUnlockedCoopCharacters == null)
																																{
																																	goto IL_1fe2;
																																}
																																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9ACE0");
																																object obj9 = default(object);
																																if (obj9 == null)
																																{
																																	SetVisualStatePurchasable();
																																}
																															}
																															goto IL_1eed;
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
		goto IL_1fe2;
		IL_20e9:
		CharacterData characterData2 = default(CharacterData);
		if ((object)Icon != null)
		{
			Icon.color = (Color)(&vector);
			object obj10 = (object?)characterData2._003CstartingWeapon_003Ek__BackingField >> 32;
			bool flag52 = (object)_WeaponFrame == null;
			typeFromHandle = (CharacterItemUI)(object)_WeaponFrame;
			if (!flag52)
			{
				bool flag53 = obj10 == null;
				object obj11 = flag53 & (_003F?)characterData2._003CstartingWeapon_003Ek__BackingField;
				bool active3 = (byte)(obj11 ^ 1) != 0;
				_WeaponFrame.SetActive(active3);
				bool flag54 = _playerOptions == null;
				typeFromHandle = (CharacterItemUI)(object)_playerOptions;
				if (!flag54)
				{
					PlayerOptionsData config2 = _playerOptions.Config;
					bool flag55 = config2 == null;
					typeFromHandle = (CharacterItemUI)(object)_playerOptions;
					if (!flag55)
					{
						typeFromHandle = (CharacterItemUI)(object)config2._003CSelectedSkins_003Ek__BackingField;
						bool flag56 = config2._003CSelectedSkins_003Ek__BackingField == null;
						if (!flag56)
						{
							int num9 = config2._003CSelectedSkins_003Ek__BackingField.FindEntry(cType);
							characterData = characterData2;
							if (flag56)
							{
								goto IL_2108;
							}
							if (_playerOptions != null)
							{
								SkinType skinTypeForCharacter = _playerOptions.GetSkinTypeForCharacter(_currentType);
								Skin skinForCharacter = _playerOptions.GetSkinForCharacter(_currentType, skinTypeForCharacter);
								bool flag57 = skinForCharacter == null;
								typeFromHandle = (CharacterItemUI)(object)_playerOptions;
								if (!flag57)
								{
									Sprite sprite = SpriteManager.GetSprite(skinForCharacter._003CspriteName_003Ek__BackingField, skinForCharacter._003CtextureName_003Ek__BackingField);
									bool flag58 = (object)Icon == null;
									typeFromHandle = (CharacterItemUI)(object)skinForCharacter._003CspriteName_003Ek__BackingField;
									if (!flag58)
									{
										Icon.sprite = sprite;
										PlayerOptionsData playerOptionsData2 = null;
										characterData = characterData2;
										goto IL_2108;
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_1fe2;
		IL_1fe2:
		throw new NullReferenceException();
		IL_2297:
		if (!characterData2._003Csecret_003Ek__BackingField || !IsSecretChar(cType))
		{
			goto IL_1eed;
		}
		bool flag59 = _playerOptions == null;
		typeFromHandle = (CharacterItemUI)(object)_playerOptions;
		if (!flag59)
		{
			PlayerOptionsData config3 = _playerOptions.Config;
			bool flag60 = config3 == null;
			typeFromHandle = (CharacterItemUI)(object)_playerOptions;
			if (!flag60)
			{
				typeFromHandle = (CharacterItemUI)(object)config3._003CUnlockedCharacters_003Ek__BackingField;
				if (config3._003CUnlockedCharacters_003Ek__BackingField != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9ACE0");
					object obj12 = default(object);
					if (obj12 != null)
					{
						goto IL_1eed;
					}
					typeFromHandle = (CharacterItemUI)(object)_Name;
					if ((object)_Name != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18634B7A0");
						Sprite sprite2 = SpriteManager.GetSprite("QuestionMark", "UI");
						bool flag61 = (object)Icon == null;
						typeFromHandle = (CharacterItemUI)(object)"QuestionMark";
						if (!flag61)
						{
							Icon.sprite = sprite2;
							bool flag62 = (object)Icon == null;
							typeFromHandle = (CharacterItemUI)(object)Icon;
							if (!flag62)
							{
								RectTransform rectTransform = Icon.rectTransform;
								typeFromHandle = (CharacterItemUI)(object)Icon;
								if ((object)Icon != null && (object)typeFromHandle._forcedUnlockState != null)
								{
									Rect rect = ((Sprite)typeFromHandle._forcedUnlockState).rect;
									typeFromHandle = (CharacterItemUI)(&flag9);
									Image icon2 = Icon;
									if ((object)Icon != null && (object)icon2.m_Sprite != null)
									{
										Rect rect2 = icon2.m_Sprite.rect;
										if ((object)rectTransform != null)
										{
											Vector2 sizeDelta = default(Vector2);
											rectTransform.sizeDelta = sizeDelta;
											goto IL_1eed;
										}
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_1fe2;
		IL_1eed:
		UpdatePlayerInfoSelectedCharacter();
		return;
		IL_20d0:
		object obj13 = !flag7;
		float num10;
		float num11;
		float num12;
		if (obj13 == null)
		{
			typeFromHandle = (CharacterItemUI)(object)_tempUnlockedCoopCharacters;
			if (_tempUnlockedCoopCharacters == null)
			{
				goto IL_1fe2;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9ACE0");
			object obj14 = default(object);
			if (obj14 == null)
			{
				num10 = 0f;
				num11 = 0f;
				num12 = 0f;
				goto IL_20e9;
			}
		}
		num10 = 1f;
		num11 = 1f;
		num12 = 1f;
		goto IL_20e9;
		IL_02bc:
		bool flag63 = _playerOptions == null;
		typeFromHandle = (CharacterItemUI)(object)_playerOptions;
		if (!flag63)
		{
			PlayerOptionsData config4 = _playerOptions.Config;
			bool flag64 = config4 == null;
			typeFromHandle = (CharacterItemUI)(object)_playerOptions;
			if (!flag64)
			{
				Dictionary<CharacterType, SkinType> dictionary = config4._003CSelectedSkinsV2_003Ek__BackingField;
				bool flag65 = config4._003CSelectedSkinsV2_003Ek__BackingField == null;
				typeFromHandle = (CharacterItemUI)(object)_playerOptions;
				if (!flag65)
				{
					int num13 = config4._003CSelectedSkinsV2_003Ek__BackingField.FindEntry(_currentType);
					if (num13 < 0)
					{
						goto IL_2323;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v362 @ r14_v8 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.CharacterType, VampireSurvivors.Data.SkinType>)+18]");
					typeFromHandle = (CharacterItemUI)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v362 @ r14_v8 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.CharacterType, VampireSurvivors.Data.SkinType>)+18]");
					if ((nint)0 != 0)
					{
						if (num13 >= (nint)((MonoBehaviour)typeFromHandle).m_CancellationTokenSource)
						{
							throw new IndexOutOfRangeException();
						}
						object obj15 = num13 + num13;
						CharacterData currentData = _currentData;
						if (_currentData != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v609 @ rcx_v50 (VampireSurvivors.UI.CharacterItemUI)+2C+v392 @ rdx_v156*8]");
							currentData._003CcurrentSkin_003Ek__BackingField = SkinType.DEFAULT;
							goto IL_2323;
						}
					}
				}
			}
		}
		goto IL_1fe2;
		IL_2323:
		bool flag66 = (object)OnlineStageManager._instance == null;
		typeFromHandle = (CharacterItemUI)(object)OnlineStageManager._instance;
		if (!flag66)
		{
			PlayerInfo myPlayerInfo2 = OnlineStageManager._instance.GetMyPlayerInfo();
			typeFromHandle = (CharacterItemUI)(object)_currentData;
			if (_currentData != null && (object)myPlayerInfo2 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v609 @ rcx_v50 (VampireSurvivors.UI.CharacterItemUI)+184]");
				myPlayerInfo2._skinType = SkinType.DEFAULT;
				string description = charData.GetDescription(cType);
				SetCharPanelDescription(description);
				typeFromHandle = _selectedCharacter;
				if ((object)_selectedCharacter != null)
				{
					Sprite sprite3;
					if (_selectedCharacter.IsUnlockableAndSecret())
					{
						sprite3 = SpriteManager.GetSprite("QuestionMark", "UI");
						typeFromHandle = (CharacterItemUI)(object)"QuestionMark";
					}
					else
					{
						typeFromHandle = _selectedCharacter;
						if ((object)_selectedCharacter == null)
						{
							goto IL_1fe2;
						}
						sprite3 = _selectedCharacter.GetCharSprite(cType, charData);
					}
					if ((object)Icon != null)
					{
						Icon.sprite = sprite3;
						bool flag67 = _playerOptions == null;
						typeFromHandle = (CharacterItemUI)(object)_playerOptions;
						if (!flag67)
						{
							bool flag68 = _playerOptions.IsUnlocked(cType);
							bool flag69 = _playerOptions == null;
							typeFromHandle = (CharacterItemUI)(object)_playerOptions;
							if (!flag69)
							{
								bool flag70 = _playerOptions.IsBought(cType);
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18699C0C0");
								typeFromHandle = (CharacterItemUI)(object)_playerOptions;
								object obj16 = default(object);
								if (obj16 == null)
								{
									if ((object)typeFromHandle != null)
									{
										bool reselectIfDefaultSelectedOnPage = typeFromHandle.ReselectIfDefaultSelectedOnPage;
										if (~(typeFromHandle.ReselectIfDefaultSelectedOnPage ? 1u : 0u) == 0)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v364 @ r14_v30 (System.Boolean)+170]");
											typeFromHandle = (CharacterItemUI)0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v364 @ r14_v30 (System.Boolean)+170]");
											if ((nint)0 != 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9ACE0");
												PlayerOptions playerOptions = _playerOptions;
												if (_playerOptions != null)
												{
													PlayerOptionsData playerOptionsData2 = playerOptions._mainGameConfig;
													bool flag71 = _playerOptions.IsBought(cType, ignoreSkins: false, playerOptions._mainGameConfig);
													PlayerOptions playerOptions2 = _playerOptions;
													bool flag72 = _playerOptions == null;
													typeFromHandle = (CharacterItemUI)(object)_playerOptions;
													if (!flag72)
													{
														playerOptionsData = playerOptions2._mainGameConfig;
														object obj17 = default(object);
														obj6 = obj17;
														flag8 = flag71;
														bool flag73 = false;
														typeFromHandle = (CharacterItemUI)(object)_playerOptions;
														obj2 = obj17;
														goto IL_208e;
													}
												}
											}
										}
									}
								}
								else if (_playerOptions != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v609 @ rcx_v50 (VampireSurvivors.UI.CharacterItemUI)+78]");
									object obj18 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v609 @ rcx_v50 (VampireSurvivors.UI.CharacterItemUI)+78]");
									if ((nint)0 != 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v366 @ r14_v28+170]");
										typeFromHandle = (CharacterItemUI)0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v366 @ r14_v28+170]");
										if ((nint)0 != 0)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9ACE0");
											PlayerOptions playerOptions3 = _playerOptions;
											if (_playerOptions != null)
											{
												PlayerOptionsData playerOptionsData2 = playerOptions3._currentAdventureSaveData;
												bool flag74 = _playerOptions.IsBought(cType, ignoreSkins: false, playerOptions3._currentAdventureSaveData);
												PlayerOptions playerOptions4 = _playerOptions;
												bool flag75 = _playerOptions == null;
												typeFromHandle = (CharacterItemUI)(object)_playerOptions;
												if (!flag75)
												{
													playerOptionsData = playerOptions4._currentAdventureSaveData;
													object obj19 = default(object);
													obj6 = obj19;
													flag8 = flag74;
													bool flag73 = false;
													typeFromHandle = (CharacterItemUI)(object)_playerOptions;
													obj2 = obj19;
													goto IL_208e;
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
		goto IL_1fe2;
	}

	private unsafe void SetVisualStatePurchasable()
	{
		//IL_01eb: Expected O, but got Ref
		//IL_01ff: Expected O, but got Ref
		//IL_0222: Expected O, but got Ref
		//IL_0245: Expected O, but got Ref
		GameObject gameObject = Price.gameObject;
		gameObject.SetActive(value: true);
		float price = _selectedCharacter.GetPrice();
		Price.SetPrice(price);
		GameObject gameObject2 = BuyButton.gameObject;
		gameObject2.SetActive(value: true);
		bool applyParameters = default(bool);
		GameObject localParametersRoot = default(GameObject);
		string overrideLanguage = default(string);
		bool allowLocalizedParameters = default(bool);
		string translation = LocalizationManager.GetTranslation("lang/charConfirm_unlock", FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
		_buyButtonLabel.text = translation;
		CharacterItemUI selectedCharacter = _selectedCharacter;
		SkinItem currentSkinItem = selectedCharacter._charItem.GetCurrentSkinItem();
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

	private void SetCharacterSprite(CharacterType cType, CharacterData cData)
	{
		Sprite sprite = ((!_selectedCharacter.IsUnlockableAndSecret()) ? _selectedCharacter.GetCharSprite(cType, cData) : SpriteManager.GetSprite("QuestionMark", "UI"));
		Icon.sprite = sprite;
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

	private void SetIconSizes()
	{
		//IL_04c1->IL028f: Incompatible stack heights: 1 vs 0
		//IL_00a0->IL028f: Incompatible stack heights: 1 vs 0
		//IL_0333->IL028f: Incompatible stack heights: 2 vs 0
		//IL_00d6->IL028f: Incompatible stack heights: 2 vs 0
		//IL_010e->IL028f: Incompatible stack heights: 2 vs 0
		//IL_013d->IL028f: Incompatible stack heights: 2 vs 0
		//IL_0392->IL028f: Incompatible stack heights: 3 vs 0
		//IL_0176->IL028f: Incompatible stack heights: 3 vs 0
		//IL_03e6->IL028f: Incompatible stack heights: 4 vs 0
		//IL_01ac->IL028f: Incompatible stack heights: 4 vs 0
		//IL_01d8->IL028f: Incompatible stack heights: 4 vs 0
		//IL_0202->IL028f: Incompatible stack heights: 4 vs 0
		//IL_022c->IL028f: Incompatible stack heights: 4 vs 0
		//IL_0268->IL028f: Incompatible stack heights: 4 vs 0
		//IL_044b->IL028f: Incompatible stack heights: 5 vs 0
		//IL_0498->IL028f: Incompatible stack heights: 6 vs 0
		if ((object)Icon != null)
		{
			RectTransform rectTransform = Icon.rectTransform;
			Image icon = Icon;
			if ((object)Icon != null)
			{
				Image sprite = (Image)(object)icon.m_Sprite;
				if ((object)icon.m_Sprite != null)
				{
					bool flag = ((UnityEngine.Object)sprite).m_CachedPtr == (IntPtr)0;
					Sprite.get_rect_Injected(((UnityEngine.Object)sprite).m_CachedPtr, out Rect ret);
					Image icon2 = Icon;
					if ((object)Icon != null)
					{
						Image sprite2 = (Image)(object)icon2.m_Sprite;
						if ((object)icon2.m_Sprite != null)
						{
							bool flag2 = ((UnityEngine.Object)sprite2).m_CachedPtr == (IntPtr)0;
							Sprite.get_rect_Injected(((UnityEngine.Object)sprite2).m_CachedPtr, out Rect ret2);
							if ((object)rectTransform != null)
							{
								Vector2 sizeDelta = default(Vector2);
								rectTransform.sizeDelta = sizeDelta;
								if ((object)WeaponIcon != null)
								{
									RectTransform rectTransform2 = WeaponIcon.rectTransform;
									Image weaponIcon = WeaponIcon;
									if ((object)WeaponIcon != null)
									{
										object sprite3 = weaponIcon.m_Sprite;
										if ((object)weaponIcon.m_Sprite != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ rbx_v19 (System.Object)+10]");
											bool flag3 = (nint)0 == 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ rbx_v19 (System.Object)+10]");
											Sprite.get_rect_Injected((IntPtr)0, out ret2);
											Image weaponIcon2 = WeaponIcon;
											if ((object)WeaponIcon != null)
											{
												object sprite4 = weaponIcon2.m_Sprite;
												if ((object)weaponIcon2.m_Sprite != null)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v117 @ rbx_v21 (System.Object)+10]");
													bool flag4 = (nint)0 == 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v117 @ rbx_v21 (System.Object)+10]");
													Sprite.get_rect_Injected((IntPtr)0, out ret);
													if ((object)rectTransform2 != null)
													{
														rectTransform2.sizeDelta = sizeDelta;
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
																		RectTransform rectTransform3 = component.rectTransform;
																		object sprite5 = component.m_Sprite;
																		if ((object)component.m_Sprite != null)
																		{
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rbx_v22 (System.Object)+10]");
																			bool flag5 = (nint)0 == 0;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rbx_v22 (System.Object)+10]");
																			Sprite.get_rect_Injected((IntPtr)0, out ret2);
																			Image sprite6 = (Image)(object)component.m_Sprite;
																			if ((object)component.m_Sprite != null)
																			{
																				bool flag6 = ((UnityEngine.Object)sprite6).m_CachedPtr == (IntPtr)0;
																				Sprite.get_rect_Injected(((UnityEngine.Object)sprite6).m_CachedPtr, out ret);
																				if ((object)rectTransform3 != null)
																				{
																					rectTransform3.sizeDelta = sizeDelta;
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

	public void NextSkin()
	{
		if (ShouldSelectionChangesBeBlocked() || !CanSeeSkins())
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
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v871 @ stack_-48+38]");
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
								goto IL_0307;
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
				goto IL_0307;
			}
			goto IL_035c;
			IL_0307:
			bool flag2 = ((Dictionary<System.Int32Enum, System.Int32Enum>)(object)playerOptionsData._003CSelectedSkinsV2_003Ek__BackingField).TryInsert((System.Int32Enum)_currentType, (System.Int32Enum)skinItem2._skinType, System.Collections.Generic.InsertionBehavior.OverwriteExisting);
			PlayerInfo myPlayerInfo = OnlineStageManager._instance.GetMyPlayerInfo();
			myPlayerInfo._skinType = skinItem2._skinType;
			goto IL_035c;
			IL_035c:
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.ClickIn, null, 0f, 10, time);
			_selectedCharacter.Refresh();
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

	public unsafe void SetSkinOnline(int character, int skinTypeAsInt)
	{
		//IL_002d: Expected O, but got I
		//IL_0042: Expected O, but got I
		//IL_00c8: Expected O, but got Ref
		//IL_0106: Expected O, but got I4
		//IL_01d9: Expected O, but got I4
		//IL_01e2: Expected O, but got I4
		//IL_01eb: Expected O, but got I4
		//IL_029e: Expected O, but got I4
		//IL_02a7: Expected O, but got I4
		//IL_03da: Unknown result type (might be due to invalid IL or missing references)
		//IL_03df: Expected O, but got Unknown
		//IL_0348: Unknown result type (might be due to invalid IL or missing references)
		//IL_034d: Expected O, but got Unknown
		object obj = ((Dictionary<System.Int32Enum, object>)(object)_characterItems).get_Item((System.Int32Enum)character);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ rax_v9 (System.Object)+118]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ rax_v10+20]");
		object obj3 = 0;
		PlayerOptionsData config = _playerOptions.Config;
		bool flag = ((Dictionary<System.Int32Enum, System.Int32Enum>)(object)config._003CSelectedSkinsV2_003Ek__BackingField).TryInsert((System.Int32Enum)character, (System.Int32Enum)skinTypeAsInt, System.Collections.Generic.InsertionBehavior.OverwriteExisting);
		int num = default(int);
		object arg = (CharacterType)num;
		object arg2 = (SkinType)num;
		System.ParamsArray paramsArray = new System.ParamsArray(arg, arg2);
		System.ParamsArray paramsArray2 = default(System.ParamsArray);
		string message = string.FormatHelper((IFormatProvider)null, "Setting Skin For {0}: Index: {1}.", (System.ParamsArray)(&paramsArray2));
		Debug.Log(message);
		object obj4 = ((Dictionary<System.Int32Enum, object>)(object)_characterItems).get_Item((System.Int32Enum)character);
		object obj5 = character - _currentType;
		bool setInfoPanel = obj5 == null;
		((CharacterItemUI)obj4).Refresh(setInfoPanel);
		if (character == (int)_currentType)
		{
			SetIconSizes();
			StatsPanel.SetValues();
			List<SkinItem> list = new List<SkinItem>();
			Dictionary<SkinType, SkinItem>.Enumerator enumerator = default(Dictionary<SkinType, SkinItem>.Enumerator);
			object obj6 = default(object);
			while (enumerator.MoveNext())
			{
				if (obj6 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v874 @ stack_-30+38]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9DBC0");
					}
					continue;
				}
				throw new NullReferenceException();
			}
			object obj7 = 0;
			object obj8 = 0;
			object obj9 = 0;
			while (true)
			{
				if ((nint)obj8 < list._size)
				{
					if ((nint)obj7 < list._size)
					{
						SkinItem[] items = list._items;
						SkinItem skinItem = items[obj7];
						CharacterData currentData = _currentData;
						bool flag2 = skinItem._skinType == currentData._003CcurrentSkin_003Ek__BackingField;
						object obj10 = obj7;
						if (!flag2)
						{
							obj10 = obj9;
						}
						obj7++;
						obj8 = obj7;
						obj9 = obj10;
						continue;
					}
					goto IL_03bf;
				}
				List<Image> skinSlots = _skinSlots;
				object obj11 = 0;
				object obj12 = 0;
				List<Image> skinSlots2 = _skinSlots;
				while ((nint)obj12 < skinSlots._size)
				{
					if ((nint)obj11 < skinSlots2._size)
					{
						Image[] items2 = skinSlots2._items;
						Sprite sprite = ((obj11 != obj9) ? _SkinOffIcon : _SkinOnIcon);
						items2[obj11].sprite = sprite;
						obj11++;
						skinSlots2 = _skinSlots;
						obj12 = obj11;
						skinSlots = _skinSlots;
						continue;
					}
					goto IL_03bf;
				}
				break;
				IL_03bf:
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				return;
			}
		}
		PopulatePlayerUis();
	}

	private unsafe void SetWeaponIconSprite(CharacterData characterData)
	{
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Expected O, but got Unknown
		//IL_00b9: Expected O, but got Ref
		//IL_00da: Expected I, but got O
		//IL_01cc: Expected O, but got I
		//IL_010d: Expected I, but got O
		//IL_01e1: Expected O, but got I
		//IL_0206: Expected O, but got I4
		//IL_04a0: Expected O, but got I
		//IL_03c0: Expected O, but got I
		//IL_022f: Expected O, but got Ref
		//IL_0250: Expected I, but got O
		//IL_015f: Expected I4, but got O
		//IL_016d: Expected I, but got O
		//IL_03d4: Expected O, but got Ref
		//IL_0284: Expected I, but got O
		//IL_0422: Expected O, but got I
		//IL_0422: Expected O, but got I
		//IL_02f5: Expected O, but got I
		//IL_030a: Expected O, but got I
		//IL_038c: Expected I, but got O
		object obj = (object?)characterData._003CstartingWeapon_003Ek__BackingField >> 32;
		bool flag = obj == null;
		object obj2 = (_003F?)characterData._003CstartingWeapon_003Ek__BackingField & flag;
		if (obj2 != null)
		{
			WeaponIcon.enabled = false;
			return;
		}
		nint num = default(nint);
		Dictionary<WeaponType, List<WeaponData>> convertedWeapons;
		System.Int32Enum key;
		if ((object)characterData._003CstartingWeapon_003Ek__BackingField != null)
		{
			if ((object)characterData._003CstartingWeapon_003Ek__BackingField == null)
			{
				goto IL_043f;
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
						goto IL_043f;
					}
					key = (System.Int32Enum)((object?)characterData._003CstartingWeapon_003Ek__BackingField >> 32);
					num = (nint)typeof(WeaponType);
					goto IL_044a;
				}
			}
		}
		convertedWeapons = _dataManager.GetConvertedWeapons();
		key = (System.Int32Enum)3;
		goto IL_044a;
		IL_0460:
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		return;
		IL_043f:
		System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
		throw new IndexOutOfRangeException();
		IL_044a:
		object obj3 = ((Dictionary<System.Int32Enum, object>)(object)convertedWeapons).get_Item(key);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ rax_v12 (System.Object)+18]");
		System.ParamsArray paramsArray;
		if ((nint)0 > (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ rax_v12 (System.Object)+10]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rsi_v5+20]");
			List<WeaponData> list = (List<WeaponData>)0;
			Skin currentSkinData = characterData.GetCurrentSkinData();
			bool flag4 = currentSkinData == null;
			WeaponType? weaponType = (WeaponType?)(object)0;
			if (!flag4)
			{
				weaponType = currentSkinData._003CstartingWeapon_003Ek__BackingField;
			}
			bool flag5 = (object)weaponType == null;
			nint num2 = num;
			if (!flag5)
			{
				string text2 = ((Enum)(&num)).ToString();
				bool flag6 = text2 == null;
				num2 = (nint)typeof(WeaponType);
				if (!flag6)
				{
					bool flag7 = text2._stringLength <= 0;
					num2 = (nint)typeof(WeaponType);
					if (!flag7)
					{
						Dictionary<WeaponType, List<WeaponData>> convertedWeapons2 = _dataManager.GetConvertedWeapons();
						System.Int32Enum key2 = default(System.Int32Enum);
						object obj5 = ((Dictionary<System.Int32Enum, object>)(object)convertedWeapons2).get_Item(key2);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ rax_v30 (System.Object)+18]");
						if ((nint)0 <= (nint)0)
						{
							goto IL_0460;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ rax_v30 (System.Object)+10]");
						object obj6 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ rsi_v10+20]");
						list = (List<WeaponData>)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ rsi_v10+20]");
						bool flag8 = (nint)0 != 0;
						paramsArray = (System.ParamsArray)typeof(WeaponType);
						if (flag8)
						{
							goto IL_039a;
						}
						Dictionary<WeaponType, List<WeaponData>> convertedWeapons3 = _dataManager.GetConvertedWeapons();
						object obj7 = ((Dictionary<System.Int32Enum, object>)(object)convertedWeapons3).get_Item((System.Int32Enum)3);
						List<WeaponData> list2 = ((Dictionary<WeaponType, List<WeaponData>>)obj7).get_Item(WeaponType.VOID);
						num2 = (nint)typeof(WeaponType);
						list = list2;
					}
				}
			}
			paramsArray = (System.ParamsArray)num2;
			goto IL_039a;
		}
		goto IL_0460;
		IL_039a:
		WeaponType? weaponType2 = default(WeaponType?);
		object arg = weaponType2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ rsi_v8 (System.Collections.Generic.List`1<VampireSurvivors.Data.Weapons.WeaponData>)+40]");
		paramsArray = new System.ParamsArray(0, arg);
		object obj8 = default(object);
		string message = string.FormatHelper((IFormatProvider)null, "Setting Weapon Sprite Of Info Panel: {0}. weapon: {1}", (System.ParamsArray)(&obj8));
		Debug.Log(message);
		WeaponIcon.enabled = true;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ rsi_v8 (System.Collections.Generic.List`1<VampireSurvivors.Data.Weapons.WeaponData>)+40]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ rsi_v8 (System.Collections.Generic.List`1<VampireSurvivors.Data.Weapons.WeaponData>)+38]");
		Sprite sprite = SpriteManager.GetSprite((string)num3, (string)0);
		WeaponIcon.sprite = sprite;
	}

	private bool CanSeeSkins()
	{
		//IL_00e3: Expected I4, but got O
		if (_playerOptions != null)
		{
			PlayerOptionsData config = _playerOptions.Config;
			if (config != null)
			{
				List<ItemType> list = config._003CCollectedItems_003Ek__BackingField;
				if (config._003CCollectedItems_003Ek__BackingField != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ rcx_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
						object obj = default(object);
						if ((nint)obj != -1)
						{
							if ((object)_selectedCharacter != null)
							{
								return _selectedCharacter.IsCharAvailable();
							}
							goto IL_00d5;
						}
					}
					return false;
				}
			}
		}
		goto IL_00d5;
		IL_00d5:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
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
					CharacterItemUI selectedCharacter = _selectedCharacter;
					if ((object)_selectedCharacter != null)
					{
						object charItem = selectedCharacter._charItem;
						if (selectedCharacter._charItem != null)
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

	public bool IsSecretAndNotUnlocked(CharacterData characterData, CharacterType characterType)
	{
		//IL_00ed: Expected I4, but got O
		if (characterData != null)
		{
			if (!characterData._003Csecret_003Ek__BackingField || !IsSecretChar(characterType))
			{
				return false;
			}
			if (_playerOptions != null)
			{
				PlayerOptionsData config = _playerOptions.Config;
				if (config != null && config._003CUnlockedCharacters_003Ek__BackingField != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9ACE0");
					object obj = default(object);
					return obj == null;
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public bool IsSecretChar(CharacterType characterType)
	{
		//IL_0068: Expected O, but got I
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Expected O, but got Unknown
		//IL_0099: Expected O, but got I
		Dictionary<SecretType, SecretData>.Enumerator enumerator = default(Dictionary<SecretType, SecretData>.Enumerator);
		object obj = default(object);
		while (enumerator.MoveNext())
		{
			if (obj == null)
			{
				continue;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v282 @ stack_-20+18]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v282 @ stack_-20+18]");
				object obj2 = (nint)0 >> 32;
				object obj3 = obj2 - characterType;
				bool flag = obj3 == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v282 @ stack_-20+18]");
				object obj4 = (nint)0 & (nint)(flag ? 1 : 0);
				if (obj4 != null)
				{
					return true;
				}
			}
		}
		return false;
	}

	protected unsafe override void Update()
	{
		//IL_0072: Expected I, but got O
		//IL_008e: Expected I, but got O
		//IL_00db: Expected I, but got O
		//IL_00f1: Expected I, but got O
		//IL_0863: Expected I, but got O
		//IL_0141: Expected I, but got O
		//IL_0161: Expected O, but got Ref
		//IL_016a: Expected O, but got I4
		//IL_016f: Expected I, but got O
		//IL_01af: Expected I, but got O
		//IL_0440: Expected I, but got O
		//IL_01c5: Expected I, but got O
		//IL_036b: Expected I, but got O
		//IL_0250: Expected O, but got I4
		//IL_01fd: Expected O, but got I
		//IL_0899: Expected O, but got I4
		//IL_02f8: Expected O, but got I4
		//IL_030e: Expected O, but got I
		//IL_0317: Unknown result type (might be due to invalid IL or missing references)
		//IL_031c: Expected O, but got Unknown
		//IL_0324: Unknown result type (might be due to invalid IL or missing references)
		//IL_0329: Expected O, but got Unknown
		//IL_03bf: Expected O, but got I
		//IL_0270: Expected I, but got O
		//IL_0962: Expected I, but got O
		//IL_08e5: Expected I, but got O
		//IL_049d: Expected I, but got O
		//IL_029c: Expected I, but got O
		//IL_02aa: Expected I, but got O
		//IL_04d4: Expected I, but got O
		//IL_02d8: Expected I, but got O
		//IL_02e6: Expected I, but got O
		//IL_0506: Expected I, but got O
		//IL_0a1d: Expected I, but got O
		//IL_0535: Expected I, but got O
		//IL_09e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_09e9: Expected O, but got Unknown
		//IL_05cc: Expected I, but got O
		//IL_0596: Expected I, but got O
		//IL_0608: Expected I, but got O
		//IL_0783: Expected O, but got I4
		//IL_0799: Unknown result type (might be due to invalid IL or missing references)
		//IL_079e: Expected I4, but got Unknown
		//IL_06db: Expected I, but got O
		//IL_062f: Expected I, but got O
		//IL_065a: Expected I, but got O
		//IL_0738: Expected O, but got I
		//IL_0a57->IL07f1: Incompatible stack heights: 1 vs 0
		//IL_06c4->IL07f1: Incompatible stack heights: 1 vs 0
		//IL_0ad9->IL07f1: Incompatible stack heights: 1 vs 0
		//IL_07f0->IL07f0: Incompatible stack heights: 1 vs 0
		//IL_0aac->IL07f1: Incompatible stack heights: 1 vs 0
		//IL_06f8->IL07f1: Incompatible stack heights: 1 vs 0
		OnlineStageManager instance = OnlineStageManager._instance;
		if ((object)OnlineStageManager._instance == null || ((UnityEngine.Object)instance).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		base.Update();
		TextMeshProUGUI latencyText = _latencyText;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182B07B50");
		object obj = default(object);
		bool flag = obj == null;
		nint num = (nint)typeof(CoherenceBridgeStore);
		object obj3;
		if (!flag)
		{
			num = (nint)typeof(CoherenceBridgeStore);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v327 @ rax_v12+C0]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800045A0");
				int num2 = default(int);
				string text = num2.ToString();
				string text2 = "Latency: " + text;
				bool flag2 = (object)_latencyText == null;
				num = unchecked((nint)"Latency: ");
				if (!flag2)
				{
					nint num3 = (nint)latencyText;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v750 @ r8_v9 (Il2CppClass<TMPro.TextMeshProUGUI>)+558]");
					nint num4 = 0;
					_latencyText.text = text2;
					SetCharactersTaken();
					bool flag3 = (object)OnlineStageManager._instance == null;
					num = (nint)OnlineStageManager._instance;
					if (!flag3)
					{
						IEnumerable<PlayerInfo> enumerable = OnlineStageManager._instance.IterateSeats();
						bool flag4 = enumerable == null;
						num = (nint)OnlineStageManager._instance;
						if (!flag4)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
							TextMeshProUGUI textMeshProUGUI = default(TextMeshProUGUI);
							object obj2 = (object)(&textMeshProUGUI);
							obj3 = 1;
							num = unchecked((nint)null);
							object obj4 = default(object);
							TextMeshProUGUI textMeshProUGUI2 = default(TextMeshProUGUI);
							object obj11 = default(object);
							while (true)
							{
								object obj5;
								object obj10;
								if ((object)textMeshProUGUI != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
									if (obj4 == null)
									{
										break;
									}
									bool flag5 = (object)textMeshProUGUI == null;
									num = unchecked((nint)null);
									if (!flag5)
									{
										nint num5 = (nint)textMeshProUGUI;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v796 @ r10_v8 (Il2CppClass<TMPro.TextMeshProUGUI>)+12E]");
										if ((nint)0 >= (nint)0)
										{
											goto IL_023d;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v796 @ r10_v8 (Il2CppClass<TMPro.TextMeshProUGUI>)+B0]");
										obj5 = 0;
										bool flag6 = false;
										while (true)
										{
											object obj6 = (flag6 ? 1 : 0) + (flag6 ? 1 : 0);
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v801 @ r8_v20+v882 @ rax_v101*8]");
											if (0 == (nint)typeof(IEnumerator<PlayerInfo>))
											{
												break;
											}
											flag6 = (byte)((flag6 ? 1u : 0u) + 1u) != 0;
											bool num6 = flag6;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v796 @ r10_v8 (Il2CppClass<TMPro.TextMeshProUGUI>)+12E]");
											if ((nint)(num6 ? 1 : 0) < (nint)0)
											{
												continue;
											}
											goto IL_023d;
										}
										object obj7 = (flag6 ? 1 : 0) + (flag6 ? 1 : 0);
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v801 @ r8_v20+8+v987 @ rcx_v84*8]");
										object obj8 = (nint)0 << 4;
										object obj9 = obj8 + 312;
										obj10 = obj9 + num5;
										goto IL_0910;
									}
									throw new NullReferenceException();
								}
								throw new NullReferenceException();
								IL_0910:
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v992 @ rdx_v39] (should have been resolved before IL gen)");
								num = (nint)typeof(UnityEngine.Object);
								bool flag7 = (object)textMeshProUGUI2 == null;
								num4 = (nint)typeof(IEnumerator<PlayerInfo>);
								if (!flag7)
								{
									bool flag8 = ((UnityEngine.Object)textMeshProUGUI2).m_CachedPtr == (IntPtr)0;
									num4 = (nint)typeof(IEnumerator<PlayerInfo>);
									num = (nint)typeof(UnityEngine.Object);
									if (!flag8)
									{
										obj3 &= (object)((Graphic)textMeshProUGUI2).m_CanvasRenderer;
										num4 = (nint)typeof(IEnumerator<PlayerInfo>);
										num = (nint)typeof(UnityEngine.Object);
									}
								}
								continue;
								IL_023d:
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
								obj5 = 0;
								obj10 = obj11;
								goto IL_0910;
							}
							if (obj2 != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
							}
							if (_waitingForAllPlayersToBeReadyToStartCharacterSelect)
							{
								num = (nint)_lobbiesManager;
								if (_lobbiesManager == null)
								{
									goto IL_07f1;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v675 @ rcx_v18 (Il2CppClass<Coherence.Toolkit.CoherenceBridgeStore>)+10]");
								if ((nint)0 != 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v675 @ rcx_v18 (Il2CppClass<Coherence.Toolkit.CoherenceBridgeStore>)+10]");
									object obj12 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1045 @ rax_v81+178]");
									if ((nint)0 == 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1045 @ rax_v81+F0]");
										if ((nint)0 > (nint)0)
										{
											CheckUIInteractionWhenHosting();
											goto IL_0425;
										}
									}
								}
								CheckUIInteractionWhenClient();
							}
							goto IL_0425;
						}
					}
				}
			}
		}
		goto IL_07f1;
		IL_0970:
		GameObject gameObject;
		bool value;
		bool flag10;
		if ((object)gameObject != null)
		{
			bool flag9 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
			GameObject.SetActive_Injected(((UnityEngine.Object)gameObject).m_CachedPtr, value);
			if (_isUILocked)
			{
				flag10 = false;
				goto IL_09dc;
			}
			nint num7 = (nint)typeof(OnlineStageManager);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v411 @ rax_v58 (Il2CppClass<VampireSurvivors.OnlineStageManager>)+B8]");
			nint num8 = 0;
			OnlineStageManager instance2 = OnlineStageManager._instance;
			bool flag11 = (object)OnlineStageManager._instance == null;
			num = num8;
			if (!flag11)
			{
				CoherenceSync sync = instance2._sync;
				bool flag12 = (object)instance2._sync == null;
				num = num8;
				if (!flag12)
				{
					NetworkEntityState networkEntityState = sync._003CEntityState_003Ek__BackingField;
					bool flag13 = sync._003CEntityState_003Ek__BackingField == null;
					num = num8;
					if (!flag13)
					{
						num = (nint)networkEntityState._003CAuthorityType_003Ek__BackingField;
						if (networkEntityState._003CAuthorityType_003Ek__BackingField == null)
						{
							goto IL_07f1;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v675 @ rcx_v18 (Il2CppClass<Coherence.Toolkit.CoherenceBridgeStore>)+10]");
						if ((nint)0 != 1)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v675 @ rcx_v18 (Il2CppClass<Coherence.Toolkit.CoherenceBridgeStore>)+10]");
							object obj13 = -3;
							bool flag14 = obj13 == null;
							flag10 = flag14;
							goto IL_09dc;
						}
					}
					flag10 = true;
					goto IL_09dc;
				}
			}
		}
		goto IL_07f1;
		IL_0425:
		bool flag15 = (object)ConfirmButton == null;
		num = (nint)ConfirmButton;
		nint num9;
		if (!flag15)
		{
			gameObject = ConfirmButton.gameObject;
			CharacterItemUI selectedCharacter = _selectedCharacter;
			bool flag16 = (object)_selectedCharacter == null;
			num9 = (nint)typeof(UnityEngine.Object);
			if (!flag16)
			{
				bool flag17 = ((UnityEngine.Object)selectedCharacter).m_CachedPtr == (IntPtr)0;
				num9 = (nint)typeof(UnityEngine.Object);
				if (!flag17)
				{
					CharacterItemUI selectedCharacter2 = _selectedCharacter;
					bool flag18 = (object)_selectedCharacter == null;
					num = (nint)typeof(UnityEngine.Object);
					if (!flag18)
					{
						bool flag19 = _selectedCharacter.IsCharAvailable();
						bool flag20 = !flag19;
						num9 = (nint)_selectedCharacter;
						if (flag20)
						{
							goto IL_065f;
						}
						bool flag21 = selectedCharacter2._charItem == null;
						num = (nint)selectedCharacter2._charItem;
						if (!flag21)
						{
							SkinItem currentSkinItem = selectedCharacter2._charItem.GetCurrentSkinItem();
							if (currentSkinItem != null)
							{
								bool flag22 = currentSkinItem._unlockState != UIUnlockStates.AVAILABLE;
								num9 = (nint)selectedCharacter2._charItem;
								if (flag22)
								{
									goto IL_065f;
								}
							}
							CharacterItemUI selectedCharacter3 = _selectedCharacter;
							bool flag23 = (object)_selectedCharacter == null;
							num = (nint)selectedCharacter2._charItem;
							if (!flag23)
							{
								CharacterItem charItem = selectedCharacter3._charItem;
								bool flag24 = selectedCharacter3._charItem == null;
								num = (nint)selectedCharacter2._charItem;
								if (!flag24)
								{
									bool flag25 = IsCharacterHighlightedByOtherPlayer(charItem._characterType);
									num9 = (nint)this;
									if (flag25)
									{
										goto IL_065f;
									}
									bool flag26 = obj3 == null;
									value = flag26;
									num = (nint)this;
									goto IL_0970;
								}
							}
						}
					}
					goto IL_07f1;
				}
			}
			goto IL_065f;
		}
		goto IL_07f1;
		IL_065f:
		value = false;
		num = num9;
		goto IL_0970;
		IL_07f1:
		throw new NullReferenceException();
		IL_09dc:
		object obj14 = flag10 & obj3;
		bool flag27 = obj14 == null;
		bool interactable = false;
		if (!flag27)
		{
			if ((object)OnlineStageManager._instance == null)
			{
				goto IL_07f1;
			}
			int numberOfConnectedPlayers = OnlineStageManager._instance.NumberOfConnectedPlayers;
			object obj15 = numberOfConnectedPlayers - 1;
			int num10 = numberOfConnectedPlayers ^ 1;
			int num11 = numberOfConnectedPlayers ^ obj15;
			int num12 = num10 & num11;
			bool flag28 = num12 < 0;
			bool flag29 = (nint)obj15 < 0;
			interactable = flag29 == flag28;
		}
		if ((object)StartButton != null)
		{
			StartButton.interactable = interactable;
			return;
		}
		goto IL_07f1;
	}

	private void CheckUIInteraction()
	{
		LobbiesManager lobbiesManager = _lobbiesManager;
		if (lobbiesManager._activeLobby != null)
		{
			LobbySession activeLobby = lobbiesManager._activeLobby;
			if (!activeLobby._003CIsDisposed_003Ek__BackingField && (nint)activeLobby.lobbyOwnerSession > 0)
			{
				CheckUIInteractionWhenHosting();
				return;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 57 Invalid \"Jump target not found in method: 0x186D32BA0\"");
		throw new NullReferenceException();
	}

	private unsafe void CheckUIInteractionWhenClient()
	{
		//IL_002a: Expected O, but got Ref
		//IL_002f: Expected I, but got O
		//IL_006f: Expected I, but got O
		//IL_009f: Expected I, but got O
		//IL_00ce: Expected I, but got O
		//IL_0104: Expected I, but got O
		IEnumerable<PlayerInfo> enumerable = OnlineStageManager._instance.IterateSeats();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj2 = default(object);
		object obj = (object)(&obj2);
		nint num = unchecked((nint)null);
		object obj3 = default(object);
		object obj4 = default(object);
		while (true)
		{
			if (obj2 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				if (obj3 != null)
				{
					bool flag = obj2 == null;
					num = unchecked((nint)null);
					if (!flag)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A99E70");
						num = (nint)typeof(UnityEngine.Object);
						if (obj4 == null)
						{
							continue;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v304 @ rax_v19+10]");
						bool flag2 = (nint)0 == 0;
						num = (nint)typeof(UnityEngine.Object);
						if (flag2)
						{
							continue;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v304 @ rax_v19+20]");
						bool flag3 = (nint)0 != 0;
						num = (nint)typeof(UnityEngine.Object);
						if (!flag3)
						{
							if (obj != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
							}
							return;
						}
						continue;
					}
					throw new NullReferenceException();
				}
				if (obj != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
				}
				break;
			}
			throw new NullReferenceException();
		}
		EnableUIInteraction();
	}

	private unsafe void CheckUIInteractionWhenHosting()
	{
		//IL_0018: Expected I, but got O
		//IL_00bd: Expected O, but got Ref
		//IL_00c6: Expected O, but got I4
		//IL_00cb: Expected I, but got O
		//IL_010b: Expected I, but got O
		//IL_0328: Expected O, but got Ref
		//IL_01b4: Expected O, but got I4
		//IL_0159: Expected O, but got I
		//IL_0162: Expected O, but got I4
		//IL_02b8: Expected O, but got I
		//IL_02c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c6: Expected O, but got Unknown
		//IL_01cc: Expected I, but got O
		//IL_0170: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Expected O, but got Unknown
		//IL_044f: Expected I, but got O
		//IL_01fb: Expected I, but got O
		//IL_0209: Expected I, but got O
		//IL_023c: Expected O, but got I
		//IL_026f: Expected I, but got O
		//IL_0286: Unknown result type (might be due to invalid IL or missing references)
		//IL_028b: Expected O, but got Unknown
		//IL_0290: Expected I, but got O
		nint num = (nint)typeof(RoomSelectionPage);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rax_v5 (Il2CppClass<VampireSurvivors.UI.RoomSelectionPage>)+B8]");
		nint num2 = 0;
		RoomSelectionPage roomSelectionPage = RoomSelectionPage._003CInstance_003Ek__BackingField;
		if ((object)RoomSelectionPage._003CInstance_003Ek__BackingField != null && roomSelectionPage._activeProvider != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			if ((object)OnlineStageManager._instance != null)
			{
				IEnumerable<PlayerInfo> enumerable = OnlineStageManager._instance.IterateSeats();
				if (enumerable != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
					object obj2 = default(object);
					object obj = (object)(&obj2);
					object obj3 = 0;
					num2 = unchecked((nint)null);
					object obj4 = default(object);
					object obj14 = default(object);
					object obj15 = default(object);
					object arg = default(object);
					while (true)
					{
						object obj13;
						object obj6;
						if (obj2 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
							if (obj4 == null)
							{
								break;
							}
							bool flag = obj2 == null;
							num2 = unchecked((nint)null);
							if (!flag)
							{
								object obj5 = obj2;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v440 @ r10_v5+12E]");
								if ((nint)0 >= (nint)0)
								{
									goto IL_0199;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v440 @ r10_v5+B0]");
								obj6 = 0;
								object obj7 = 0;
								while (true)
								{
									object obj8 = obj7 + obj7;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v449 @ r8_v12+v547 @ rcx_v46*8]");
									if (0 == (nint)typeof(IEnumerator<PlayerInfo>))
									{
										break;
									}
									obj7++;
									object obj9 = obj7;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v440 @ r10_v5+12E]");
									if ((nint)obj9 < 0)
									{
										continue;
									}
									goto IL_0199;
								}
								object obj10 = obj7 + obj7;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v449 @ r8_v12+8+v609 @ rcx_v48*8]");
								object obj11 = (nint)0 << 4;
								object obj12 = obj11 + 312;
								obj13 = obj12 + obj5;
								goto IL_047a;
							}
							throw new NullReferenceException();
						}
						throw new NullReferenceException();
						IL_0199:
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
						obj13 = obj14;
						obj6 = 0;
						goto IL_047a;
						IL_047a:
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v614 @ rdx_v20] (should have been resolved before IL gen)");
						num2 = (nint)typeof(UnityEngine.Object);
						bool flag2 = obj15 == null;
						nint num3 = (nint)typeof(IEnumerator<PlayerInfo>);
						if (flag2)
						{
							continue;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v630 @ rax_v38+10]");
						bool flag3 = (nint)0 == 0;
						num3 = (nint)typeof(IEnumerator<PlayerInfo>);
						num2 = (nint)typeof(UnityEngine.Object);
						if (!flag3)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v630 @ rax_v38+28]");
							string message = $"<color=cyan>Player {0} ready to start character select: {arg}</color>";
							Debug.Log(message);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v630 @ rax_v38+20]");
							bool flag4 = (nint)0 == 0;
							num3 = unchecked((nint)null);
							if (!flag4)
							{
								obj3++;
								num3 = unchecked((nint)null);
							}
						}
					}
					bool flag5 = obj == null;
					object obj16 = obj2;
					if (!flag5)
					{
						obj16 = obj;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
					object arg2 = default(object);
					object arg3 = default(object);
					System.ParamsArray paramsArray = new System.ParamsArray(arg2, arg3);
					System.ParamsArray paramsArray2 = default(System.ParamsArray);
					string message2 = string.FormatHelper((IFormatProvider)null, "<color=cyan>Clients acked: {0} / {1}</color>", (System.ParamsArray)(&paramsArray2));
					Debug.Log(message2);
					object obj17 = default(object);
					if (obj3 != obj17)
					{
						return;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A336D]");
					if ((nint)0 == 0)
					{
						_ = 1;
					}
					PopupManager.ClosePopup("HostStartingGame");
					if (Multiplayer != null)
					{
						Multiplayer.EnableAllUIInteraction();
						_waitingForAllPlayersToBeReadyToStartCharacterSelect = false;
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void EnableUIInteraction()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A336D]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		PopupManager.ClosePopup("HostStartingGame");
		Multiplayer.EnableAllUIInteraction();
		_waitingForAllPlayersToBeReadyToStartCharacterSelect = false;
	}

	private void LateUpdate()
	{
		_characterBoughtThisFrame = false;
	}

	private void SetCharactersTaken()
	{
		IEnumerable<PlayerInfo> enumerable = OnlineStageManager._instance.IterateSeats();
		if (enumerable != null)
		{
			List<object> list = new List<object>(enumerable);
			List<GameObject> spawned = _spawned;
			List<GameObject>.Enumerator enumerator = default(List<GameObject>.Enumerator);
			if (enumerator.MoveNext())
			{
				GameObject gameObject = null;
				throw new NullReferenceException();
			}
			return;
		}
		Exception ex = System.Linq.Error.ArgumentNull("source");
		throw ex;
	}

	protected override void OnShowStart(GameObject g)
	{
		//IL_036d: Expected O, but got I4
		//IL_036d: Expected O, but got I
		//IL_0376: Unknown result type (might be due to invalid IL or missing references)
		//IL_037b: Expected O, but got Unknown
		//IL_0934: Expected O, but got I
		//IL_0934: Expected O, but got I4
		//IL_0555: Expected O, but got I
		//IL_05ea: Expected O, but got I4
		//IL_0631: Expected I, but got O
		//IL_0653: Expected O, but got I4
		base.OnShowStart(g);
		_003CInstance_003Ek__BackingField = this;
		RewiredStandaloneInputModule rewiredStandaloneInputModule = UnityEngine.Object.FindFirstObjectByType<RewiredStandaloneInputModule>();
		rewiredStandaloneInputModule.enabled = true;
		_waitingForAllPlayersToBeReadyToStartCharacterSelect = true;
		if (!OnlineStageManager.IsHostInTheGame())
		{
			return;
		}
		int mySeatNumber = OnlineStageManager._instance.GetMySeatNumber();
		_selectedPlayerSlotIndex = mySeatNumber;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186B7F160");
		PlayerOptionsData config = _playerOptions.Config;
		DlcUtils dlcUtils = default(DlcUtils);
		DlcType? stageDlcType = dlcUtils.GetStageDlcType(config._003CSelectedStage_003Ek__BackingField, _dataManager);
		if ((object)stageDlcType != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A99BA0");
			object obj = default(object);
			if (obj == null)
			{
				PlayerOptionsData config2 = _playerOptions.Config;
				config2._003CSelectedStage_003Ek__BackingField = StageType.FOREST;
			}
		}
		Populate();
		_scrollEnhancer.ForceScrollAlignment();
		RefreshCharacters();
		if (_onlineInit)
		{
			return;
		}
		PopulatePlayerUis();
		WrapNavigation();
		OnlineStageManager instance = OnlineStageManager._instance;
		Action<int, PlayerInfo> b = OnSeatAssigned;
		Delegate obj2 = Delegate.Combine(instance.OnSeatAssigned, b);
		if ((object)obj2 == null)
		{
			instance.OnSeatAssigned = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			Action<int, PlayerInfo> action = default(Action<int, PlayerInfo>);
			if (action == null)
			{
				throw new InvalidCastException();
			}
			instance.OnSeatAssigned = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj3 = default(object);
			if (obj3 == null)
			{
				throw new InvalidCastException();
			}
		}
		Action<UISignals.ConfirmStageSelectionSignal> action2 = null;
		((OnlineLobbyPage)(object)action2).OnStageSelected((UISignals.ConfirmStageSelectionSignal)this);
		((OnlineLobbyPage)(object)_signalBus).OnStageSelected((UISignals.ConfirmStageSelectionSignal)action2);
		Action action3 = LockOnlineUI;
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1546 @ rbx_v15 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v420 @ rbx_v16 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v420 @ rbx_v16 (Il2CppMethodInfo)+38]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
			}
		}
		object obj4 = null;
		Action<object> action4 = ((SignalBus._003C_003Ec__DisplayClass35_0<UISignals.LockOnlineUI>)obj4)._003CSubscribeId_003Eb__0;
		((SignalBus._003C_003Ec__DisplayClass35_0<UISignals.LockOnlineUI>)0)._003CSubscribeId_003Eb__0((object)1);
		object obj6 = default(object);
		object obj5 = obj6 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		SignalBus signalBus = _signalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v326 @ rax_v58 (System.Object)+10]");
		StageType stageType = default(StageType);
		Action<object> callback = default(Action<object>);
		signalBus.SubscribeInternal((Type)stageType, (object)null, (object)0, callback);
		OnlineStageManager instance2 = OnlineStageManager._instance;
		Action b2 = OnBecomeAuthority;
		Delegate obj7 = Delegate.Combine(instance2.OnBecomeAuthority, b2);
		if ((object)obj7 == null)
		{
			instance2.OnBecomeAuthority = null;
		}
		else
		{
			bool flag = (object)obj7.GetType() != typeof(Action);
			Delegate obj8 = null;
			if (!flag)
			{
				obj8 = obj7;
			}
			if ((object)obj8 == null)
			{
				throw new InvalidCastException();
			}
			instance2.OnBecomeAuthority = (Action)obj8;
			bool flag2 = (object)obj7.GetType() != typeof(Action);
			Delegate obj9 = null;
			if (!flag2)
			{
				obj9 = obj7;
			}
			if ((object)obj9 == null)
			{
				goto IL_09a2;
			}
		}
		PlayerOptionsData config3 = _playerOptions.Config;
		PlayerOptionsData config4 = _playerOptions.Config;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002E30");
		object obj10 = default(object);
		if (obj10 != null)
		{
			PlayerOptionsData config5 = _playerOptions.Config;
			StageType stageType2 = config5._003CSelectedStage_003Ek__BackingField;
		}
		else
		{
			PlayerOptionsData config6 = _playerOptions.Config;
			List<StageType> list = config6._003CUnlockedStages_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v333 @ rax_v130 (System.Collections.Generic.List`1<VampireSurvivors.Data.StageType>)+18]");
			if ((nint)0 <= (nint)0)
			{
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				goto IL_09a2;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v333 @ rax_v130 (System.Collections.Generic.List`1<VampireSurvivors.Data.StageType>)+10]");
			object obj11 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v375 @ rcx_v113+20]");
			StageType stageType2 = StageType.FOREST;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA03B0");
		bool isHost = OnlineStageManager._instance.IsHost;
		_selectStageButton.SetActive(isHost);
		Button component = _selectStageButton.GetComponent<Button>();
		component.interactable = true;
		bool flag3 = !_characterConfirmed;
		bool flag4 = true;
		object obj12 = 0;
		if (!flag3)
		{
			GameObject gameObject = StartButton.gameObject;
			gameObject.SetActive(value: true);
			Button startButton = StartButton;
			nint num3 = (nint)startButton;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1990 @ rax_v125 (Il2CppClass<UnityEngine.UI.Button>)+3A0]");
			flag4 = false;
			startButton.Select();
			obj12 = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182B07B50");
		UnityAction<CoherenceBridge, ConnectionCloseReason> unityAction = OnDisconnected;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180495090");
		TextMeshProUGUI componentInChildren = BuyButton.GetComponentInChildren<TextMeshProUGUI>();
		_buyButtonLabel = componentInChildren;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18699C0C0");
		object obj13 = default(object);
		if (obj13 == null)
		{
			GameObject gameObject2 = _collectionsButton.gameObject;
			gameObject2.SetActive(value: false);
			GameObject gameObject3 = _powerUpsButton.gameObject;
			gameObject3.SetActive(value: false);
			GameObject gameObject4 = _achievementButton.gameObject;
			gameObject4.SetActive(value: false);
		}
		else
		{
			GameObject gameObject5 = _collectionsButton.gameObject;
			gameObject5.SetActive(value: true);
			GameObject gameObject6 = _powerUpsButton.gameObject;
			gameObject6.SetActive(value: true);
			GameObject gameObject7 = _achievementButton.gameObject;
			gameObject7.SetActive(value: true);
			LobbiesManager lobbiesManager = _lobbiesManager;
			bool flag5 = lobbiesManager._activeLobby == null;
			StageType interactable = StageType.FOREST;
			if (!flag5)
			{
				LobbySession activeLobby = lobbiesManager._activeLobby;
				bool flag6 = (nint)activeLobby.lobbyOwnerSession < 0;
				bool flag7 = activeLobby.lobbyOwnerSession == null;
				bool flag8 = !flag6;
				bool flag9 = !flag7;
				interactable = ((flag9 & flag8) ? StageType.SINKING : StageType.FOREST);
			}
			_collectionsButton.interactable = (byte)interactable != 0;
			_powerUpsButton.interactable = (byte)interactable != 0;
		}
		_waitingForAllPlayersToBeReadyToStartCharacterSelect = true;
		Multiplayer.DisableAllUIInteraction();
		PlayerInfo myPlayerInfo = OnlineStageManager._instance.GetMyPlayerInfo();
		myPlayerInfo._003CIsReadyToStartCharacterSelect_003Ek__BackingField = true;
		_onlineInit = true;
		return;
		IL_09a2:
		throw new InvalidCastException();
	}

	private void LockOnlineUI()
	{
		Debug.Log("Locking online UI");
		_isUILocked = true;
		Button component = _selectStageButton.GetComponent<Button>();
		component.interactable = false;
	}

	private void OnDisconnected(CoherenceBridge _, ConnectionCloseReason __)
	{
		_playerOptions.DestroyOnlineConfigs();
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 23 Invalid \"Jump target not found in method: 0x186D34640\"");
		throw new NullReferenceException();
	}

	private unsafe void ResetUi()
	{
		//IL_0013: Expected F4, but got I4
		//IL_063c: Expected I, but got O
		//IL_0057: Expected F4, but got I4
		//IL_0150: Expected I, but got O
		//IL_0166: Expected O, but got I
		//IL_016f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0174: Expected O, but got Unknown
		//IL_0235: Expected I, but got O
		//IL_0694: Expected O, but got I4
		//IL_069d: Expected O, but got I4
		//IL_06b4: Expected I, but got I8
		//IL_01c6: Expected I, but got I8
		//IL_026e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0273: Expected O, but got Unknown
		//IL_02d0: Expected O, but got I4
		//IL_02d0: Expected O, but got I
		//IL_02d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02de: Expected O, but got Unknown
		//IL_0734: Expected I, but got O
		//IL_0347: Expected I, but got O
		//IL_035d: Expected O, but got I
		//IL_0366: Unknown result type (might be due to invalid IL or missing references)
		//IL_036b: Expected O, but got Unknown
		//IL_03d9: Expected I, but got O
		//IL_0769: Expected I, but got I8
		//IL_077e: Expected O, but got I
		//IL_03ac: Expected I, but got I8
		//IL_04d3: Expected O, but got I
		//IL_04d3: Expected O, but got I
		//IL_005c->IL05ee: Incompatible stack heights: 2 vs 0
		//IL_0223->IL06d3: Incompatible stack heights: 2 vs 0
		//IL_055b->IL07d9: Incompatible stack heights: 2 vs 0
		_onlineInit = false;
		_rnjSetup = false;
		_isUILocked = false;
		Action action2;
		if (_characterItems != null)
		{
			float num = 0f;
			Dictionary<CharacterType, CharacterItemUI>.Enumerator enumerator = default(Dictionary<CharacterType, CharacterItemUI>.Enumerator);
			IntPtr intPtr = default(IntPtr);
			while (enumerator.MoveNext())
			{
				bool flag = intPtr == (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v528 @ stack_-40 (Il2CppClass<VampireSurvivors.Signals.UISignals+LockOnlineUI>)+10]");
				bool flag2 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v528 @ stack_-40 (Il2CppClass<VampireSurvivors.Signals.UISignals+LockOnlineUI>)+10]");
				IntPtr gcHandlePtr = Component.get_gameObject_Injected((IntPtr)0);
				GameObject obj = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr);
				UnityEngine.Object.Destroy(obj, 0f);
				num = 0f;
			}
			if (_characterItems != null)
			{
				_characterItems.Clear();
				nint num2 = (nint)OnlineStageManager._instance;
				if ((object)OnlineStageManager._instance == null)
				{
					return;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ rbx_v10 (Il2CppClass<VampireSurvivors.Signals.UISignals+LockOnlineUI>)+10]");
				if ((nint)0 == 0)
				{
					return;
				}
				OnlineStageManager instance = OnlineStageManager._instance;
				if ((object)OnlineStageManager._instance != null)
				{
					Action<int, PlayerInfo> value = OnSeatAssigned;
					Delegate obj2 = Delegate.Remove(instance.OnSeatAssigned, value);
					if ((object)obj2 == null)
					{
						instance.OnSeatAssigned = null;
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
						Action<int, PlayerInfo> action = default(Action<int, PlayerInfo>);
						bool flag3 = action == null;
						instance.OnSeatAssigned = action;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
						object obj3 = default(object);
						bool flag4 = obj3 == null;
					}
					action2 = null;
					nint num3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ r9_v12 (Il2CppMethodInfo)+8]");
					((Delegate)action2).method_ptr = (IntPtr)0;
					((Delegate)action2).method = (nint)__ldftn(OnlineLobbyPage.LockOnlineUI);
					((Delegate)action2).m_target = this;
					((Delegate)action2).method_code = (IntPtr)action2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ r9_v12 (Il2CppMethodInfo)+4C]");
					object obj4 = (nint)0 >> 4;
					object obj5 = obj4 & 1;
					nint num4;
					if (obj5 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ r9_v12 (Il2CppMethodInfo)+52]");
						if ((nint)0 == 0)
						{
							num4 = unchecked((nint)6447293664L);
							goto IL_068b;
						}
					}
					((Delegate)action2).method_code = (IntPtr)((Delegate)action2).m_target;
					num4 = ((Delegate)action2).method_ptr;
					goto IL_068b;
				}
			}
		}
		goto IL_055b;
		IL_0752:
		Action action3;
		((Delegate)action3).extra_arg = unchecked((nint)6447293568L);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rbx_v23 (Il2CppClass<VampireSurvivors.Signals.UISignals+LockOnlineUI>)+50]");
		Delegate obj6 = Delegate.Remove((Delegate)0, action3);
		if ((object)obj6 != null)
		{
			bool flag5 = (object)obj6.GetType() != typeof(Action);
			Delegate obj7 = null;
			if (!flag5)
			{
				obj7 = obj6;
			}
			bool flag6 = (object)obj7 == null;
			bool flag7 = (object)obj6.GetType() != typeof(Action);
			Delegate obj8 = null;
			if (!flag7)
			{
				obj8 = obj6;
			}
			bool flag8 = (object)obj8 == null;
		}
		CoherenceBridge masterBridge = CoherenceBridgeStore.masterBridge;
		if ((object)CoherenceBridgeStore.masterBridge != null)
		{
			UnityEvent<CoherenceBridge, ConnectionCloseReason> onDisconnected = masterBridge.onDisconnected;
			UnityAction<CoherenceBridge, ConnectionCloseReason> unityAction = OnDisconnected;
			if (masterBridge.onDisconnected != null && unityAction != null)
			{
				object obj9 = unityAction;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1828 @ rdx_v34+1B8] (should have been resolved before IL gen)");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rdi_v18 (UnityEngine.Events.UnityEvent`2<Coherence.Toolkit.CoherenceBridge, Coherence.Connection.ConnectionCloseReason>)+10]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rdi_v18 (UnityEngine.Events.UnityEvent`2<Coherence.Toolkit.CoherenceBridge, Coherence.Connection.ConnectionCloseReason>)+10]");
					nint num5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1827 @ rax_v79 (UnityEngine.Events.UnityAction`2<Coherence.Toolkit.CoherenceBridge, Coherence.Connection.ConnectionCloseReason>)+20]");
					MethodInfo method = default(MethodInfo);
					((UnityEngine.Events.InvokableCallList)num5).RemoveListener(0, method);
					return;
				}
			}
		}
		goto IL_055b;
		IL_055b:
		throw new NullReferenceException();
		IL_068b:
		object obj10 = 24;
		object obj11 = 24;
		((Delegate)action2).extra_arg = unchecked((nint)6447293568L);
		if (_signalBus != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj13 = default(object);
			object obj12 = obj13 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			Type signalType = default(Type);
			bool throwIfMissing = default(bool);
			_signalBus.UnsubscribeInternal(signalType, (object)null, (object)action2, throwIfMissing);
			Action<UISignals.ConfirmStageSelectionSignal> action4 = null;
			((OnlineLobbyPage)(object)action4).OnStageSelected((UISignals.ConfirmStageSelectionSignal)this);
			if (_signalBus != null)
			{
				((OnlineLobbyPage)0).OnStageSelected((UISignals.ConfirmStageSelectionSignal)1);
				object obj15 = default(object);
				object obj14 = obj15 + 32;
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
				Type signalType2 = default(Type);
				_signalBus.UnsubscribeInternal(signalType2, (object)null, (object)action4, throwIfMissing);
				nint num6 = (nint)OnlineStageManager._instance;
				if ((object)OnlineStageManager._instance != null)
				{
					action3 = null;
					nint num7 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ r10_v10 (Il2CppMethodInfo)+8]");
					((Delegate)action3).method_ptr = (IntPtr)0;
					((Delegate)action3).method = (nint)__ldftn(OnlineLobbyPage.OnBecomeAuthority);
					((Delegate)action3).m_target = this;
					((Delegate)action3).method_code = (IntPtr)action3;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ r10_v10 (Il2CppMethodInfo)+4C]");
					object obj16 = (nint)0 >> 4;
					object obj17 = obj16 & 1;
					nint num8;
					if (obj17 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ r10_v10 (Il2CppMethodInfo)+52]");
						bool flag9 = (nint)0 == 0;
						num8 = unchecked((nint)6447293664L);
						if (flag9)
						{
							goto IL_0752;
						}
					}
					num8 = ((Delegate)action3).method_ptr;
					((Delegate)action3).method_code = (IntPtr)((Delegate)action3).m_target;
					goto IL_0752;
				}
			}
		}
		goto IL_055b;
	}

	private void OnBecomeAuthority()
	{
		bool isHost = OnlineStageManager._instance.IsHost;
		_selectStageButton.SetActive(isHost);
		Button component = _selectStageButton.GetComponent<Button>();
		component.interactable = true;
		if (_characterConfirmed)
		{
			GameObject gameObject = StartButton.gameObject;
			gameObject.SetActive(value: true);
			StartButton.Select();
		}
	}

	private unsafe void OnStageSelected(UISignals.ConfirmStageSelectionSignal startingStage)
	{
		//IL_01f3: Expected I4, but got O
		//IL_0213: Expected O, but got Ref
		//IL_0080: Expected I4, but got O
		//IL_022e: Expected I4, but got O
		//IL_00fb: Expected O, but got I
		//IL_0110: Expected O, but got I
		//IL_01ce: Expected I4, but got O
		object obj = default(object);
		object arg = (StageType)obj;
		System.ParamsArray paramsArray = new System.ParamsArray(arg);
		object obj2 = default(object);
		string message = string.FormatHelper((IFormatProvider)null, "SETTING NEW STAGE: {0}", (System.ParamsArray)(&obj2));
		Debug.Log(message);
		DataManager dataManager = _dataManager;
		Dictionary<StageType, List<StageData>> dictionary;
		if (AdventureManager._003CIsInAdventureMode_003Ek__BackingField)
		{
			dictionary = dataManager._adventureStageData;
		}
		else
		{
			Dictionary<StageType, List<StageData>> convertedStages = _dataManager.GetConvertedStages();
			dictionary = convertedStages;
		}
		int num = ((Dictionary<System.Int32Enum, object>)(object)dictionary).FindEntry((System.Int32Enum)startingStage);
		bool flag = num >= 0;
		UISignals.ConfirmStageSelectionSignal confirmStageSelectionSignal = startingStage;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182FF2590");
			UISignals.ConfirmStageSelectionSignal confirmStageSelectionSignal2 = default(UISignals.ConfirmStageSelectionSignal);
			confirmStageSelectionSignal = confirmStageSelectionSignal2;
		}
		object obj3 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).get_Item((System.Int32Enum)confirmStageSelectionSignal);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v233 @ rax_v18 (System.Object)+18]");
		if ((nint)0 > (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v233 @ rax_v18 (System.Object)+10]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v226 @ rdi_v6+20]");
			StageData stageData = (StageData)0;
			Sprite sprite = SpriteManager.GetSprite(stageData._003CuiFrame_003Ek__BackingField, stageData._003CuiTexture_003Ek__BackingField);
			PlayerOptionsData config = _playerOptions.Config;
			config._003CSelectedBGM_003Ek__BackingField = stageData._003CBGM_003Ek__BackingField;
			Sprite mapSprite = default(Sprite);
			StageType stageType = default(StageType);
			int index = default(int);
			bool hideDescriptionText = default(bool);
			_stageItem.SetData(_playerOptions, null, stageData, mapSprite, stageType, index, hideDescriptionText);
			if (OnlineStageManager._instance.IsHost)
			{
				HostPlayerOptions hostPlayerOptions = HostPlayerOptions._003CInstance_003Ek__BackingField;
				hostPlayerOptions._003CSelectedStage_003Ek__BackingField = (int)confirmStageSelectionSignal;
				HostPlayerOptions hostPlayerOptions2 = HostPlayerOptions._003CInstance_003Ek__BackingField;
				hostPlayerOptions2._003CSelectedBGM_003Ek__BackingField = (int)stageData._003CBGM_003Ek__BackingField;
			}
		}
		else
		{
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}

	private unsafe void PopulatePlayerUis()
	{
		//IL_002a: Expected O, but got Ref
		//IL_0119: Expected O, but got I4
		//IL_00c6: Expected O, but got I
		//IL_026b: Expected O, but got I4
		//IL_016e: Expected O, but got I4
		//IL_0184: Expected O, but got I
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0192: Expected O, but got Unknown
		//IL_01b4: Expected O, but got I
		//IL_01e0: Expected O, but got I
		IEnumerable<PlayerInfo> enumerable = OnlineStageManager._instance.IterateSeats();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj2 = default(object);
		object obj = (object)(&obj2);
		int num = 0;
		OnlineMPPlayerItem onlineMPPlayerItem = null;
		object obj3 = default(object);
		object obj11 = default(object);
		PlayerInfo playerInfo = default(PlayerInfo);
		while (obj2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			object obj5;
			object obj10;
			if (obj3 != null)
			{
				bool flag = obj2 == null;
				onlineMPPlayerItem = null;
				if (!flag)
				{
					object obj4 = obj2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v199 @ r10_v5+12E]");
					if ((nint)0 >= (nint)0)
					{
						goto IL_0106;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v199 @ r10_v5+B0]");
					obj5 = 0;
					int num2 = 0;
					while (true)
					{
						object obj6 = num2 + num2;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v301 @ r8_v9+v324 @ rax_v34*8]");
						if (0 == (nint)typeof(IEnumerator<PlayerInfo>))
						{
							break;
						}
						num2++;
						int num3 = num2;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v199 @ r10_v5+12E]");
						if ((nint)num3 < (nint)0)
						{
							continue;
						}
						goto IL_0106;
					}
					object obj7 = num2 + num2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v301 @ r8_v9+8+v380 @ rcx_v28*8]");
					object obj8 = (nint)0 << 4;
					object obj9 = obj8 + 312;
					obj10 = obj9 + obj4;
					goto IL_0295;
				}
				throw new NullReferenceException();
			}
			if (obj != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
			}
			return;
			IL_0106:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
			obj5 = 0;
			obj10 = obj11;
			goto IL_0295;
			IL_0295:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v385 @ rdx_v11] (should have been resolved before IL gen)");
			onlineMPPlayerItem = (OnlineMPPlayerItem)(object)_players;
			if (_players != null)
			{
				if (num < (nint)((MonoBehaviour)onlineMPPlayerItem).m_CancellationTokenSource)
				{
					IntPtr cachedPtr = ((UnityEngine.Object)onlineMPPlayerItem).m_CachedPtr;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v441 @ rdx_v15 (System.IntPtr)+20+v197 @ rdi_v3 (System.Int32)*8]");
					onlineMPPlayerItem = (OnlineMPPlayerItem)0;
					num++;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v441 @ rdx_v15 (System.IntPtr)+20+v197 @ rdi_v3 (System.Int32)*8]");
					((OnlineMPPlayerItem)0).Init(playerInfo, num);
					continue;
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				onlineMPPlayerItem = null;
			}
			throw new NullReferenceException();
		}
		throw new NullReferenceException();
	}

	private void OnSeatAssigned(int seatNumber, PlayerInfo playerInfo)
	{
		int mySeatNumber = OnlineStageManager._instance.GetMySeatNumber();
		_selectedPlayerSlotIndex = mySeatNumber;
		PopulatePlayerUis();
	}

	protected override void OnEnterPressed()
	{
		if (_characterBoughtThisFrame)
		{
			return;
		}
		EventSystem current = EventSystem.current;
		GameObject currentSelected = current.m_CurrentSelected;
		if ((object)current.m_CurrentSelected == null || ((UnityEngine.Object)currentSelected).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		EventSystem current2 = EventSystem.current;
		CharacterItemUI component = current2.m_CurrentSelected.GetComponent<CharacterItemUI>();
		if ((object)component == null || ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0 || _characterConfirmed)
		{
			return;
		}
		CharacterItemUI selectedCharacter = _selectedCharacter;
		CharacterItem charItem = selectedCharacter._charItem;
		if (IsCharacterHighlightedByOtherPlayer(charItem._characterType))
		{
			return;
		}
		if (!_selectedCharacter.IsAvailable())
		{
			if (!_selectedCharacter.IsPurchasable())
			{
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18699C080");
			OnlineStageManager onlineStageManager = default(OnlineStageManager);
			if (!onlineStageManager.IsHost)
			{
				return;
			}
		}
		SelectCharacter(fromUnlock: false);
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
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ rcx_v3 (VampireSurvivors.UI.BaseUIPage)+1C]");
				_ = (nint)0 + (nint)1;
				((MonoBehaviour)baseUIPage).m_CancellationTokenSource = null;
				if ((nint)((MonoBehaviour)baseUIPage).m_CancellationTokenSource > 0)
				{
					Array.Clear((Array)(nint)((UnityEngine.Object)baseUIPage).m_CachedPtr, 0, (int)((MonoBehaviour)baseUIPage).m_CancellationTokenSource);
				}
				OnlineStageManager instance = OnlineStageManager._instance;
				if ((object)OnlineStageManager._instance == null || ((UnityEngine.Object)instance).m_CachedPtr == (IntPtr)0)
				{
					return;
				}
				if ((object)OnlineStageManager._instance != null)
				{
					PlayerInfo myPlayerInfo = OnlineStageManager._instance.GetMyPlayerInfo();
					if ((object)OnlineStageManager._instance != null)
					{
						PlayerInfo myPlayerInfo2 = OnlineStageManager._instance.GetMyPlayerInfo();
						if ((object)myPlayerInfo2 == null || ((UnityEngine.Object)myPlayerInfo2).m_CachedPtr == (IntPtr)0)
						{
							return;
						}
						bool flag2 = (object)myPlayerInfo == null;
						baseUIPage = (BaseUIPage)(object)typeof(UnityEngine.Object);
						if (!flag2)
						{
							myPlayerInfo._003CIsReadyToStartCharacterSelect_003Ek__BackingField = false;
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void Detune()
	{
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Detune = 200f;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.ClickIn, soundConfig, 0f, 10, time);
		Debug.Log("Detune 200");
	}

	private void OnDestroy()
	{
		ResetUi();
	}

	private unsafe void setupRNJ(CharacterData dat, CharacterType cType)
	{
		//IL_006c: Expected O, but got I4
		//IL_064b: Expected O, but got I
		//IL_0669: Expected O, but got I
		//IL_00b0: Expected O, but got I4
		//IL_00c8: Expected O, but got I4
		//IL_00d0: Expected O, but got Ref
		//IL_0833: Expected O, but got I4
		//IL_09e3: Expected O, but got I4
		//IL_02a4: Expected O, but got I
		//IL_085d: Expected O, but got I4
		//IL_0881: Expected O, but got I
		//IL_074d: Expected O, but got I
		//IL_0720: Expected O, but got I
		//IL_0730: Expected O, but got I
		//IL_08b4: Expected I, but got O
		//IL_079b: Expected I, but got O
		//IL_037a: Expected O, but got I
		//IL_038a: Expected O, but got I
		//IL_0304: Expected I4, but got I8
		//IL_091f: Expected I, but got O
		//IL_0a48: Expected O, but got I4
		//IL_07db: Expected I, but got O
		//IL_07eb: Expected O, but got I
		//IL_047f: Expected I, but got O
		//IL_03f4: Expected I, but got O
		//IL_04d8: Expected I, but got O
		//IL_04eb: Expected O, but got Ref
		//IL_0514: Expected O, but got I4
		//IL_0575: Expected O, but got Ref
		//IL_05b5: Expected O, but got Ref
		//IL_05e2->IL05e2: Incompatible stack heights: 1 vs 0
		CharacterType characterType = default(CharacterType);
		if (characterType != CharacterType.ARENGIJUS || _rnjSetup)
		{
			return;
		}
		_rnjSetup = true;
		bool flag2 = default(bool);
		GameObject localParametersRoot = default(GameObject);
		string overrideLanguage = default(string);
		bool allowLocalizedParameters = default(bool);
		int num5 = default(int);
		if (OnlineStageManager._instance.IsHost)
		{
			dat._003CstartingWeapon_003Ek__BackingField = (WeaponType?)(object)1;
			dat.spriteName = "random_00";
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
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1564 @ rax_v92 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj3 = UnityEngine.Random.RandomRangeInt(0, 0);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1564 @ rax_v92 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			bool flag = (nint)obj3 >= 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1564 @ rax_v92 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
			object obj4 = 0;
			PlayerOptionsData config = _playerOptions.Config;
			if (config._003CPlayedRNJ_003Ek__BackingField <= 0)
			{
				SetDefaultCharacterName(dat);
				LobbyCharacterData lobbyCharacterData = LobbyCharacterData._003CInstance_003Ek__BackingField;
				lobbyCharacterData._003CRnjNameIndex_003Ek__BackingField = -1;
			}
			else
			{
				string translation = LocalizationManager.GetTranslation("lang/arengijus_aliases", FixForRTL: true, 0, ignoreRTLnumbers: true, flag2, localParametersRoot, overrideLanguage, allowLocalizedParameters);
				bool flag3 = "," != null;
				string separator = ",";
				if (!flag3)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF00]");
					object obj5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2476 @ rax_v181+B8]");
					object obj6 = 0;
					separator = (string)obj6;
				}
				string[] array = translation.SplitInternal(separator, (string[])null, 2147483647, flag2 ? StringSplitOptions.RemoveEmptyEntries : StringSplitOptions.None);
				object obj7 = UnityEngine.Random.RandomRangeInt(0, array.Length);
				dat.charName = array[obj7];
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9DF80");
				DataManager dataManager = _dataManager;
				object obj8 = ((Dictionary<System.Int32Enum, object>)(object)dataManager._003CAllCharacters_003Ek__BackingField).get_Item((System.Int32Enum)64);
				nint num = (nint)obj8;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2608 @ r8_v61 (Il2CppClass<System.Object>)+678] (should have been resolved before IL gen)");
				int num2 = default(int);
				JToken jToken = num2;
				object obj10 = default(object);
				object obj9 = obj10;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v387 @ r10_v25+258] (should have been resolved before IL gen)");
				LobbyCharacterData lobbyCharacterData2 = LobbyCharacterData._003CInstance_003Ek__BackingField;
				lobbyCharacterData2._003CRnjNameIndex_003Ek__BackingField = num2;
				dat.spriteName = "random_99";
			}
			DataManager dataManager2 = _dataManager;
			object obj11 = ((Dictionary<System.Int32Enum, object>)(object)dataManager2._003CAllCharacters_003Ek__BackingField).get_Item((System.Int32Enum)64);
			nint num3 = (nint)obj11;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2553 @ r8_v37 (Il2CppClass<System.Object>)+678] (should have been resolved before IL gen)");
			JValue jValue = new JValue((object)dat._003CcharName_003Ek__BackingField, JTokenType.String);
			object obj13 = default(object);
			object obj12 = obj13;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v383 @ r10_v22+258] (should have been resolved before IL gen)");
			DataManager dataManager3 = _dataManager;
			object obj14 = ((Dictionary<System.Int32Enum, object>)(object)dataManager3._003CAllCharacters_003Ek__BackingField).get_Item((System.Int32Enum)64);
			nint num4 = (nint)obj14;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2645 @ r8_v42 (Il2CppClass<System.Object>)+678] (should have been resolved before IL gen)");
			IntPtr intPtr = default(IntPtr);
			string value = ((Enum)(&intPtr)).ToString();
			JValue jValue2 = new JValue((object)value, JTokenType.String);
			object obj16 = default(object);
			object obj15 = obj16;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v93 @ r10_v23+258] (should have been resolved before IL gen)");
			dat._003CstartingWeapon_003Ek__BackingField = (WeaponType?)(object)1;
			LobbyCharacterData lobbyCharacterData3 = LobbyCharacterData._003CInstance_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v600 @ rcx_v74+20+v555 @ rax_v101*4]");
			lobbyCharacterData3._003CRnjStartingWeapon_003Ek__BackingField = 0;
			LobbyCharacterData lobbyCharacterData4 = LobbyCharacterData._003CInstance_003Ek__BackingField;
			lobbyCharacterData4._003CRnjSpriteName_003Ek__BackingField = dat._003CspriteName_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object arg = default(object);
			System.ParamsArray paramsArray = new System.ParamsArray(arg);
			System.ParamsArray paramsArray2 = default(System.ParamsArray);
			string text = string.FormatHelper((IFormatProvider)null, "Initialized Arengijus. Name Index: {0}. StartingWeapon: ", (System.ParamsArray)(&paramsArray2));
			object arg2 = (WeaponType)num5;
			LobbyCharacterData lobbyCharacterData5 = LobbyCharacterData._003CInstance_003Ek__BackingField;
			paramsArray2 = new System.ParamsArray(arg2, lobbyCharacterData5._003CRnjSpriteName_003Ek__BackingField);
			System.ParamsArray paramsArray3 = default(System.ParamsArray);
			string text2 = string.FormatHelper((IFormatProvider)null, "{0}. Sprite Name: {1}", (System.ParamsArray)(&paramsArray3));
			string message = text + text2;
			Debug.Log(message);
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182AD6810");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186D466E0");
		object obj17 = (WeaponType)num5;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182AD6810");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186D466E0");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v571 @ rax_v46+28]");
		string text3 = (string)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v571 @ rax_v46+28]");
		string text4 = default(string);
		string text5 = default(string);
		string message2 = text4 + text5 + " Sprite Name: " + (string)0;
		Debug.Log(message2);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186D466E0");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v572 @ rax_v50+20]");
		if ((nint)0 != -1)
		{
			string translation2 = LocalizationManager.GetTranslation("lang/arengijus_aliases", FixForRTL: true, 0, ignoreRTLnumbers: true, flag2, localParametersRoot, overrideLanguage, allowLocalizedParameters);
			bool flag4 = "," != null;
			string separator2 = ",";
			if (!flag4)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF00]");
				object obj18 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2387 @ rax_v85+B8]");
				object obj19 = 0;
				separator2 = (string)obj19;
			}
			string[] array2 = translation2.SplitInternal(separator2, (string[])null, 2147483647, flag2 ? StringSplitOptions.RemoveEmptyEntries : StringSplitOptions.None);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186D466E0");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v574 @ rax_v75+20]");
			object obj20 = 0;
			dat.charName = array2[obj20];
			DataManager dataManager4 = _dataManager;
			object obj21 = ((Dictionary<System.Int32Enum, object>)(object)dataManager4._003CAllCharacters_003Ek__BackingField).get_Item((System.Int32Enum)64);
			nint num6 = (nint)obj21;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2584 @ r8_v31 (Il2CppClass<System.Object>)+678] (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186D466E0");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v578 @ rax_v80+20]");
			JToken jToken2 = 0;
			CharacterData characterData = default(CharacterData);
			nint num7 = (nint)characterData;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2339 @ r10_v20 (Il2CppClass<VampireSurvivors.Data.Characters.CharacterData>)+260]");
			text3 = (string)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2339 @ r10_v20 (Il2CppClass<VampireSurvivors.Data.Characters.CharacterData>)+258] (should have been resolved before IL gen)");
			string text6 = (string)jToken2;
			object obj22 = "nameIndex";
			CharacterData characterData2 = characterData;
		}
		else
		{
			SetDefaultCharacterName(dat);
			string text6 = " Sprite Name: ";
			object obj22 = 0;
			CharacterData characterData2 = dat;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186D466E0");
		dat._003CstartingWeapon_003Ek__BackingField = (WeaponType?)(object)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186D466E0");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v582 @ rax_v55+28]");
		dat.spriteName = (string)0;
		DataManager dataManager5 = _dataManager;
		object obj23 = ((Dictionary<System.Int32Enum, object>)(object)dataManager5._003CAllCharacters_003Ek__BackingField).get_Item((System.Int32Enum)64);
		nint num8 = (nint)obj23;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2533 @ r8_v21 (Il2CppClass<System.Object>)+678] (should have been resolved before IL gen)");
		JToken jToken3 = dat._003CcharName_003Ek__BackingField;
		object obj25 = default(object);
		object obj24 = obj25;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v386 @ r10_v17+258] (should have been resolved before IL gen)");
		DataManager dataManager6 = _dataManager;
		object obj26 = ((Dictionary<System.Int32Enum, object>)(object)dataManager6._003CAllCharacters_003Ek__BackingField).get_Item((System.Int32Enum)64);
		nint num9 = (nint)obj26;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2623 @ r8_v25 (Il2CppClass<System.Object>)+678] (should have been resolved before IL gen)");
		System.Int32Enum? int32Enum = default(System.Int32Enum?);
		string text7 = int32Enum.ToString();
		JToken jToken4 = text7;
		object obj28 = default(object);
		object obj27 = obj28;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v95 @ r10_v18+258] (should have been resolved before IL gen)");
	}

	private static void SetDefaultCharacterName(CharacterData dat)
	{
		bool applyParameters = default(bool);
		GameObject localParametersRoot = default(GameObject);
		string overrideLanguage = default(string);
		bool allowLocalizedParameters = default(bool);
		string translation = LocalizationManager.GetTranslation("characterLang/{ARENGIJUS}charName", FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
		dat._003CcharName_003Ek__BackingField = translation;
	}

	private void setupMIS(CharacterData ddata, CharacterType cType)
	{
		//IL_00a4: Invalid comparison between I4 and F4
		if (cType != CharacterType.FINO || _missingNSetup)
		{
			return;
		}
		_missingNSetup = true;
		if (OnlineStageManager._instance.IsHost)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186D466E0");
			float num = UnityEngine.Random.Range(1f, 4.2949673E+09f);
			if (0f > num)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si rax,xmm0\"");
			}
		}
		InitMisValues(ddata, CharacterType.FINO);
	}

	private unsafe void InitMisValues(CharacterData ddata, CharacterType cType)
	{
		//IL_00a1: Expected O, but got Ref
		//IL_00ea: Expected I, but got O
		//IL_01fe: Expected I, but got O
		//IL_0307: Expected I, but got O
		//IL_0401: Expected I, but got O
		//IL_050a: Expected I, but got O
		//IL_0606: Expected I, but got O
		//IL_070f: Expected I, but got O
		//IL_0819: Expected I, but got O
		//IL_0922: Expected I, but got O
		//IL_0a2c: Expected I, but got O
		//IL_0b35: Expected I, but got O
		//IL_0c3e: Expected I, but got O
		//IL_0d47: Expected I, but got O
		//IL_0e50: Expected I, but got O
		//IL_0f59: Expected I, but got O
		//IL_1062: Expected I, but got O
		//IL_11c4: Expected O, but got I4
		//IL_11f6: Expected I, but got O
		//IL_125b: Expected I, but got O
		//IL_1503: Expected O, but got I4
		//IL_12aa: Expected O, but got I
		//IL_1332: Expected I, but got O
		//IL_13fa: Expected I4, but got O
		//IL_147c: Expected I4, but got O
		LobbyCharacterData lobbyCharacterData = LobbyCharacterData._003CInstance_003Ek__BackingField;
		int num = (int)(lobbyCharacterData._003CMissingNoSeed_003Ek__BackingField << 13);
		int num2 = (int)lobbyCharacterData._003CMissingNoSeed_003Ek__BackingField ^ num;
		int num3 = num2 >> 17;
		int num4 = num2 ^ num3;
		int num5 = num4 << 5;
		int num6 = num4 ^ num5;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		uint num7 = default(uint);
		object arg = (CharacterType)num7;
		object arg2 = default(object);
		System.ParamsArray paramsArray = new System.ParamsArray(arg2, arg);
		object obj = default(object);
		string message = string.FormatHelper((IFormatProvider)null, "Initializing MissingNo with seed: {0} for character type: {1}", (System.ParamsArray)(&obj));
		Debug.Log(message);
		DataManager dataManager = _dataManager;
		object obj2 = ((Dictionary<System.Int32Enum, object>)(object)dataManager._003CAllCharacters_003Ek__BackingField).get_Item((System.Int32Enum)cType);
		nint num8 = (nint)obj2;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1684 @ r8_v8 (Il2CppClass<System.Object>)+678] (should have been resolved before IL gen)");
		int num9 = num6 >> 9;
		int num10 = num6 << 13;
		int num11 = num9 | 0x3F800000;
		int num12 = num6 ^ num10;
		int num13 = num12 >> 17;
		int num14 = num12 ^ num13;
		float num15 = (float)num11 - 1f;
		int num16 = num14 << 5;
		int num17 = num14 ^ num16;
		float num18 = num15 - 0.025f;
		JToken jToken = (ddata._003CmaxHp_003Ek__BackingField = num18 * 100f);
		object obj4 = default(object);
		object obj3 = obj4;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v126 @ r10_v5+258] (should have been resolved before IL gen)");
		DataManager dataManager2 = _dataManager;
		object obj5 = ((Dictionary<System.Int32Enum, object>)(object)dataManager2._003CAllCharacters_003Ek__BackingField).get_Item((System.Int32Enum)cType);
		nint num19 = (nint)obj5;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1736 @ r8_v12 (Il2CppClass<System.Object>)+678] (should have been resolved before IL gen)");
		int num20 = num17 >> 9;
		int num21 = num17 << 13;
		int num22 = num20 | 0x3F800000;
		int num23 = num17 ^ num21;
		int num24 = num23 >> 17;
		int num25 = num23 ^ num24;
		float num26 = (float)num22 - 1f;
		int num27 = num25 << 5;
		int num28 = num25 ^ num27;
		float num29 = num26 - 0.1f;
		JToken jToken2 = (ddata._003Carmor_003Ek__BackingField = num29 + num29);
		object obj7 = default(object);
		object obj6 = obj7;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v127 @ r10_v6+258] (should have been resolved before IL gen)");
		DataManager dataManager3 = _dataManager;
		object obj8 = ((Dictionary<System.Int32Enum, object>)(object)dataManager3._003CAllCharacters_003Ek__BackingField).get_Item((System.Int32Enum)cType);
		nint num30 = (nint)obj8;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1772 @ r8_v16 (Il2CppClass<System.Object>)+678] (should have been resolved before IL gen)");
		int num31 = num28 >> 9;
		int num32 = num28 << 13;
		int num33 = num31 | 0x3F800000;
		int num34 = num28 ^ num32;
		int num35 = num34 >> 17;
		int num36 = num34 ^ num35;
		float num37 = (float)num33 - 1f;
		int num38 = num36 << 5;
		int num39 = num36 ^ num38;
		JToken jToken3 = (ddata._003Cregen_003Ek__BackingField = num37 - 0.5f);
		object obj10 = default(object);
		object obj9 = obj10;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v128 @ r10_v7+258] (should have been resolved before IL gen)");
		DataManager dataManager4 = _dataManager;
		object obj11 = ((Dictionary<System.Int32Enum, object>)(object)dataManager4._003CAllCharacters_003Ek__BackingField).get_Item((System.Int32Enum)cType);
		nint num40 = (nint)obj11;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1793 @ r8_v20 (Il2CppClass<System.Object>)+678] (should have been resolved before IL gen)");
		int num41 = num39 << 13;
		int num42 = num39 ^ num41;
		int num43 = num39 >> 9;
		int num44 = num43 | 0x3F800000;
		int num45 = num42 >> 17;
		int num46 = num42 ^ num45;
		float num47 = (float)num44 - 1f;
		int num48 = num46 << 5;
		int num49 = num46 ^ num48;
		float num50 = num47 - 0.5f;
		JToken jToken4 = (ddata._003CmoveSpeed_003Ek__BackingField = num50 + num50);
		object obj13 = default(object);
		object obj12 = obj13;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v129 @ r10_v8+258] (should have been resolved before IL gen)");
		DataManager dataManager5 = _dataManager;
		object obj14 = ((Dictionary<System.Int32Enum, object>)(object)dataManager5._003CAllCharacters_003Ek__BackingField).get_Item((System.Int32Enum)cType);
		nint num51 = (nint)obj14;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1811 @ r8_v24 (Il2CppClass<System.Object>)+678] (should have been resolved before IL gen)");
		int num52 = num49 << 13;
		int num53 = num49 ^ num52;
		int num54 = num49 >> 9;
		int num55 = num54 | 0x3F800000;
		int num56 = num53 >> 17;
		int num57 = num53 ^ num56;
		float num58 = (float)num55 - 1f;
		int num59 = num57 << 5;
		int num60 = num57 ^ num59;
		float num61 = num58 - 0.1f;
		float num62 = num61 + num61;
		ddata._003Cpower_003Ek__BackingField = num62;
		JValue jValue = new JValue((double)num62);
		object obj16 = default(object);
		object obj15 = obj16;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v130 @ r10_v9+258] (should have been resolved before IL gen)");
		DataManager dataManager6 = _dataManager;
		object obj17 = ((Dictionary<System.Int32Enum, object>)(object)dataManager6._003CAllCharacters_003Ek__BackingField).get_Item((System.Int32Enum)cType);
		nint num63 = (nint)obj17;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1847 @ r8_v29 (Il2CppClass<System.Object>)+678] (should have been resolved before IL gen)");
		int num64 = num60 << 13;
		int num65 = num60 ^ num64;
		int num66 = num60 >> 9;
		int num67 = num66 | 0x3F800000;
		int num68 = num65 >> 17;
		int num69 = num65 ^ num68;
		float num70 = (float)num67 - 1f;
		int num71 = num69 << 5;
		int num72 = num69 ^ num71;
		float num73 = num70 - 0.1f;
		JToken jToken5 = (ddata._003Ccooldown_003Ek__BackingField = num73 + num73);
		object obj19 = default(object);
		object obj18 = obj19;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v131 @ r10_v10+258] (should have been resolved before IL gen)");
		DataManager dataManager7 = _dataManager;
		object obj20 = ((Dictionary<System.Int32Enum, object>)(object)dataManager7._003CAllCharacters_003Ek__BackingField).get_Item((System.Int32Enum)cType);
		nint num74 = (nint)obj20;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1865 @ r8_v33 (Il2CppClass<System.Object>)+678] (should have been resolved before IL gen)");
		int num75 = num72 << 13;
		int num76 = num72 ^ num75;
		int num77 = num72 >> 9;
		int num78 = num77 | 0x3F800000;
		int num79 = num76 >> 17;
		int num80 = num76 ^ num79;
		float num81 = (float)num78 - 1f;
		int num82 = num80 << 5;
		int num83 = num80 ^ num82;
		float num84 = num81 - 0.1f;
		JToken jToken6 = (ddata._003Carea_003Ek__BackingField = num84 * 4f);
		object obj22 = default(object);
		object obj21 = obj22;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v132 @ r10_v11+258] (should have been resolved before IL gen)");
		DataManager dataManager8 = _dataManager;
		object obj23 = ((Dictionary<System.Int32Enum, object>)(object)dataManager8._003CAllCharacters_003Ek__BackingField).get_Item((System.Int32Enum)cType);
		nint num85 = (nint)obj23;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1883 @ r8_v37 (Il2CppClass<System.Object>)+678] (should have been resolved before IL gen)");
		int num86 = num83 << 13;
		int num87 = num83 ^ num86;
		int num88 = num83 >> 9;
		int num89 = num88 | 0x3F800000;
		int num90 = num87 >> 17;
		int num91 = num87 ^ num90;
		float num92 = (float)num89 - 1f;
		int num93 = num91 << 5;
		int num94 = num91 ^ num93;
		float num95 = num92 - 0.1f;
		JToken jToken7 = (ddata._003Cspeed_003Ek__BackingField = num95 + num95);
		object obj25 = default(object);
		object obj24 = obj25;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v133 @ r10_v12+258] (should have been resolved before IL gen)");
		DataManager dataManager9 = _dataManager;
		object obj26 = ((Dictionary<System.Int32Enum, object>)(object)dataManager9._003CAllCharacters_003Ek__BackingField).get_Item((System.Int32Enum)cType);
		nint num96 = (nint)obj26;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1901 @ r8_v41 (Il2CppClass<System.Object>)+678] (should have been resolved before IL gen)");
		int num97 = num94 << 13;
		int num98 = num94 ^ num97;
		int num99 = num94 >> 9;
		int num100 = num99 | 0x3F800000;
		int num101 = num98 >> 17;
		int num102 = num98 ^ num101;
		float num103 = (float)num100 - 1f;
		int num104 = num102 << 5;
		int num105 = num102 ^ num104;
		float num106 = num103 - 0.1f;
		JToken jToken8 = (ddata._003Cduration_003Ek__BackingField = num106 * 3f);
		object obj28 = default(object);
		object obj27 = obj28;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v134 @ r10_v13+258] (should have been resolved before IL gen)");
		DataManager dataManager10 = _dataManager;
		object obj29 = ((Dictionary<System.Int32Enum, object>)(object)dataManager10._003CAllCharacters_003Ek__BackingField).get_Item((System.Int32Enum)cType);
		nint num107 = (nint)obj29;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1919 @ r8_v45 (Il2CppClass<System.Object>)+678] (should have been resolved before IL gen)");
		int num108 = num105 << 13;
		int num109 = num105 ^ num108;
		int num110 = num105 >> 9;
		int num111 = num110 | 0x3F800000;
		int num112 = num109 >> 17;
		int num113 = num109 ^ num112;
		float num114 = (float)num111 - 1f;
		int num115 = num113 << 5;
		int num116 = num113 ^ num115;
		float num117 = num114 - 0.1f;
		JToken jToken9 = (ddata._003Camount_003Ek__BackingField = num117 + num117);
		object obj31 = default(object);
		object obj30 = obj31;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v135 @ r10_v14+258] (should have been resolved before IL gen)");
		DataManager dataManager11 = _dataManager;
		object obj32 = ((Dictionary<System.Int32Enum, object>)(object)dataManager11._003CAllCharacters_003Ek__BackingField).get_Item((System.Int32Enum)cType);
		nint num118 = (nint)obj32;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1937 @ r8_v49 (Il2CppClass<System.Object>)+678] (should have been resolved before IL gen)");
		int num119 = num116 << 13;
		int num120 = num116 ^ num119;
		int num121 = num116 >> 9;
		int num122 = num121 | 0x3F800000;
		int num123 = num120 >> 17;
		int num124 = num120 ^ num123;
		float num125 = (float)num122 - 1f;
		int num126 = num124 << 5;
		int num127 = num124 ^ num126;
		float num128 = num125 - 0.1f;
		JToken jToken10 = (ddata._003Cluck_003Ek__BackingField = num128 + num128);
		object obj34 = default(object);
		object obj33 = obj34;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v136 @ r10_v15+258] (should have been resolved before IL gen)");
		DataManager dataManager12 = _dataManager;
		object obj35 = ((Dictionary<System.Int32Enum, object>)(object)dataManager12._003CAllCharacters_003Ek__BackingField).get_Item((System.Int32Enum)cType);
		nint num129 = (nint)obj35;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1955 @ r8_v53 (Il2CppClass<System.Object>)+678] (should have been resolved before IL gen)");
		int num130 = num127 << 13;
		int num131 = num127 ^ num130;
		int num132 = num127 >> 9;
		int num133 = num132 | 0x3F800000;
		int num134 = num131 >> 17;
		int num135 = num131 ^ num134;
		float num136 = (float)num133 - 1f;
		int num137 = num135 << 5;
		int num138 = num135 ^ num137;
		float num139 = num136 - 0.1f;
		JToken jToken11 = (ddata._003Cgrowth_003Ek__BackingField = num139 + num139);
		object obj37 = default(object);
		object obj36 = obj37;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v137 @ r10_v16+258] (should have been resolved before IL gen)");
		DataManager dataManager13 = _dataManager;
		object obj38 = ((Dictionary<System.Int32Enum, object>)(object)dataManager13._003CAllCharacters_003Ek__BackingField).get_Item((System.Int32Enum)cType);
		nint num140 = (nint)obj38;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1973 @ r8_v57 (Il2CppClass<System.Object>)+678] (should have been resolved before IL gen)");
		int num141 = num138 << 13;
		int num142 = num138 ^ num141;
		int num143 = num138 >> 9;
		int num144 = num143 | 0x3F800000;
		int num145 = num142 >> 17;
		int num146 = num142 ^ num145;
		float num147 = (float)num144 - 1f;
		int num148 = num146 << 5;
		int num149 = num146 ^ num148;
		float num150 = num147 - 0.1f;
		JToken jToken12 = (ddata._003Cgreed_003Ek__BackingField = num150 + num150);
		object obj40 = default(object);
		object obj39 = obj40;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v138 @ r10_v17+258] (should have been resolved before IL gen)");
		DataManager dataManager14 = _dataManager;
		object obj41 = ((Dictionary<System.Int32Enum, object>)(object)dataManager14._003CAllCharacters_003Ek__BackingField).get_Item((System.Int32Enum)cType);
		nint num151 = (nint)obj41;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1991 @ r8_v61 (Il2CppClass<System.Object>)+678] (should have been resolved before IL gen)");
		int num152 = num149 << 13;
		int num153 = num149 ^ num152;
		int num154 = num149 >> 9;
		int num155 = num154 | 0x3F800000;
		int num156 = num153 >> 17;
		int num157 = num153 ^ num156;
		float num158 = (float)num155 - 1f;
		int num159 = num157 << 5;
		int num160 = num157 ^ num159;
		float num161 = num158 - 0.1f;
		JToken jToken13 = (ddata._003Cmagnet_003Ek__BackingField = num161 + num161);
		object obj43 = default(object);
		object obj42 = obj43;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v139 @ r10_v18+258] (should have been resolved before IL gen)");
		DataManager dataManager15 = _dataManager;
		object obj44 = ((Dictionary<System.Int32Enum, object>)(object)dataManager15._003CAllCharacters_003Ek__BackingField).get_Item((System.Int32Enum)cType);
		nint num162 = (nint)obj44;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2009 @ r8_v65 (Il2CppClass<System.Object>)+678] (should have been resolved before IL gen)");
		int num163 = num160 << 13;
		int num164 = num160 ^ num163;
		int num165 = num160 >> 9;
		int num166 = num165 | 0x3F800000;
		int num167 = num164 >> 17;
		int num168 = num164 ^ num167;
		float num169 = (float)num166 - 1f;
		int num170 = num168 << 5;
		int num171 = num168 ^ num170;
		float num172 = num169 - 0.1f;
		JToken jToken14 = (ddata._003Crevivals_003Ek__BackingField = num172 + num172);
		object obj46 = default(object);
		object obj45 = obj46;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v140 @ r10_v19+258] (should have been resolved before IL gen)");
		DataManager dataManager16 = _dataManager;
		object obj47 = ((Dictionary<System.Int32Enum, object>)(object)dataManager16._003CAllCharacters_003Ek__BackingField).get_Item((System.Int32Enum)cType);
		nint num173 = (nint)obj47;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2027 @ r8_v69 (Il2CppClass<System.Object>)+678] (should have been resolved before IL gen)");
		int num174 = num171 << 13;
		int num175 = num171 ^ num174;
		int num176 = num171 >> 9;
		int num177 = num176 | 0x3F800000;
		int num178 = num175 >> 17;
		int num179 = num175 ^ num178;
		float num180 = (float)num177 - 1f;
		int num181 = num179 << 5;
		int num182 = num179 ^ num181;
		float num183 = num180 - 0.025f;
		JToken jToken15 = (ddata._003Ccurse_003Ek__BackingField = num183 + num183);
		object obj49 = default(object);
		object obj48 = obj49;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v141 @ r10_v20+258] (should have been resolved before IL gen)");
		int num184 = num182 << 13;
		int num185 = num182 ^ num184;
		int num186 = num182 >> 9;
		int num187 = num185 >> 17;
		int num188 = num185 ^ num187;
		int num189 = num188 << 5;
		int num190 = num188 ^ num189;
		int num191 = num186 | 0x3F800000;
		float num192 = (float)num191 - 1f;
		ddata._003CstartingWeapon_003Ek__BackingField = (WeaponType?)(object)1;
		DataManager dataManager17 = _dataManager;
		object obj50 = ((Dictionary<System.Int32Enum, object>)(object)dataManager17._003CAllCharacters_003Ek__BackingField).get_Item((System.Int32Enum)cType);
		nint num193 = (nint)obj50;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2072 @ r8_v73 (Il2CppClass<System.Object>)+678] (should have been resolved before IL gen)");
		System.Int32Enum? int32Enum = default(System.Int32Enum?);
		string value = int32Enum.ToString();
		JValue jValue2 = new JValue((object)value, JTokenType.String);
		object obj52 = default(object);
		object obj51 = obj52;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v142 @ r10_v21+258] (should have been resolved before IL gen)");
		DataManager dataManager18 = _dataManager;
		object obj53 = ((Dictionary<System.Int32Enum, object>)(object)dataManager18._003CAllCharacters_003Ek__BackingField).get_Item((System.Int32Enum)cType);
		nint num194 = (nint)obj53;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2114 @ r8_v78 (Il2CppClass<System.Object>)+678] (should have been resolved before IL gen)");
		int[] array = new int[9] { 109, 105, 115, 115, 105, 110, 103, 78, 0 };
		List<int> weirdCharacters = _weirdCharacters;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ r13_v5 (System.Collections.Generic.List`1<System.Int32>)+18]");
		object obj54 = UnityEngine.Random.RandomRangeInt(0, 0);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ r13_v5 (System.Collections.Generic.List`1<System.Int32>)+18]");
		bool flag = (nint)obj54 >= 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ r13_v5 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj55 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v532 @ rcx_v201+20+v468 @ rax_v121*4]");
		array[8] = 0;
		JValue jValue3 = new JValue((object)(ddata._003CcharName_003Ek__BackingField = CharCodeToString(array)), JTokenType.String);
		object obj57 = default(object);
		object obj56 = obj57;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v143 @ r10_v22+258] (should have been resolved before IL gen)");
		DataManager dataManager19 = _dataManager;
		object obj58 = ((Dictionary<System.Int32Enum, object>)(object)dataManager19._003CAllCharacters_003Ek__BackingField).get_Item((System.Int32Enum)cType);
		nint num195 = (nint)obj58;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2234 @ r8_v86 (Il2CppClass<System.Object>)+678] (should have been resolved before IL gen)");
		int[] array2 = new int[6] { 39, 77, 40, 0, 0, 41 };
		int num196 = num190 << 13;
		int num197 = num190 ^ num196;
		int num198 = num190 >> 9;
		int num199 = num198 | 0x3F800000;
		int num200 = num197 >> 17;
		int num201 = num197 ^ num200;
		float num202 = (float)num199 - 1f;
		float num203 = num202 * 222f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6F7E8");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
		object obj59 = default(object);
		array2[3] = (int)obj59;
		int num204 = num201 << 5;
		int num205 = num204 ^ num201;
		int num206 = num205 >> 9;
		int num207 = num206 | 0x3F800000;
		float num208 = (float)num207 - 1f;
		float num209 = num208 * 222f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6F7E8");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
		object obj60 = default(object);
		array2[4] = (int)obj60;
		JValue jValue4 = new JValue((object)(ddata._003Cdescription_003Ek__BackingField = CharCodeToString(array2)), JTokenType.String);
		object obj62 = default(object);
		object obj61 = obj62;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1628 @ r10_v23+258] (should have been resolved before IL gen)");
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

	private void Populate()
	{
		//IL_0301: Expected O, but got I
		//IL_02ec: Expected O, but got I
		//IL_0316: Expected O, but got I
		//IL_02d7: Expected O, but got I
		//IL_029f: Expected O, but got I
		//IL_0385: Expected O, but got I
		//IL_0617: Expected I4, but got I8
		Dictionary<CharacterType, List<CharacterData>> convertedCharacterData = _dataManager.GetConvertedCharacterData();
		bool flag = !AdventureManager._003CIsInAdventureMode_003Ek__BackingField;
		Dictionary<CharacterType, List<CharacterData>> dictionary = convertedCharacterData;
		if (!flag)
		{
			DataManager dataManager = _dataManager;
			dictionary = dataManager._adventureCharacterData;
			AdventureManager adventureManager = _adventureManager;
			AdventureData adventureData = adventureManager._003CAdventureData_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9ACE0");
			object obj = default(object);
			if (obj == null)
			{
				bool flag2 = ((Dictionary<System.Int32Enum, object>)(object)dataManager._adventureCharacterData).Remove((System.Int32Enum)1);
			}
		}
		Dictionary<CharacterType, CharacterItemUI> characterItems = new Dictionary<CharacterType, CharacterItemUI>();
		_characterItems = characterItems;
		Dictionary<CharacterType, CharacterItem> dictionary2 = new Dictionary<CharacterType, CharacterItem>();
		Dictionary<CharacterType, List<CharacterData>>.Enumerator enumerator = default(Dictionary<CharacterType, List<CharacterData>>.Enumerator);
		object obj2 = default(object);
		CharacterType characterType2 = default(CharacterType);
		while (enumerator.MoveNext())
		{
			DlcUtils utils = DlcSystem._utils;
			if (DlcSystem._utils != null)
			{
				DlcType? characterDlcType = DlcSystem._utils.GetCharacterDlcType(CharacterType.VOID, _dataManager);
				bool flag3 = (object)characterDlcType == null;
				CharacterType characterType = CharacterType.VOID;
				if (!flag3)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A99BA0");
					bool flag4 = obj2 == null;
					characterType = characterType2;
					if (flag4)
					{
						continue;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm6,8\"");
				throw new NullReferenceException();
			}
			throw new NullReferenceException();
		}
		Dictionary<CharacterType, CharacterItemUI> playerOptions = (Dictionary<CharacterType, CharacterItemUI>)(object)_playerOptions;
		if (_playerOptions == null)
		{
			throw new NullReferenceException();
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v973 @ rbx_v22 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.CharacterType, VampireSurvivors.UI.CharacterItemUI>)+68]");
		object obj3;
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v973 @ rbx_v22 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.CharacterType, VampireSurvivors.UI.CharacterItemUI>)+58]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v973 @ rbx_v22 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.CharacterType, VampireSurvivors.UI.CharacterItemUI>)+78]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v973 @ rbx_v22 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.CharacterType, VampireSurvivors.UI.CharacterItemUI>)+78]");
					obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1225 @ rax_v61+2CC]");
					if ((nint)0 != 0)
					{
						goto IL_09f9;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v973 @ rbx_v22 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.CharacterType, VampireSurvivors.UI.CharacterItemUI>)+50]");
				obj3 = 0;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v973 @ rbx_v22 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.CharacterType, VampireSurvivors.UI.CharacterItemUI>)+58]");
				obj3 = 0;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v973 @ rbx_v22 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.CharacterType, VampireSurvivors.UI.CharacterItemUI>)+68]");
			obj3 = 0;
		}
		goto IL_09f9;
		IL_0557:
		System.Int32Enum int32Enum;
		if (AdventureManager._003CIsInAdventureMode_003Ek__BackingField)
		{
			AdventureManager adventureManager2 = _adventureManager;
			AdventureData adventureData2 = adventureManager2._003CAdventureData_003Ek__BackingField;
			CoreAdventureData coreAdventureData = adventureData2._003CCoreAdventureData_003Ek__BackingField;
			int32Enum = (System.Int32Enum)coreAdventureData._003CStartingCharacter_003Ek__BackingField;
		}
		else
		{
			int32Enum = (System.Int32Enum)1;
		}
		goto IL_0a89;
		IL_09f9:
		PlayerOptionsData playerOptionsData;
		if (obj3 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1225 @ rax_v61+328]");
			object obj4 = 0;
			if ((object)OnlineStageManager._instance != null)
			{
				int mySeatNumber = OnlineStageManager._instance.GetMySeatNumber();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1225 @ rax_v61+328]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1347 @ r14_v21+18]");
					if ((nint)mySeatNumber < (nint)0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1347 @ r14_v21+10]");
						object obj5 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1347 @ r14_v21+10]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1309 @ r14_v22+18]");
							if ((nint)mySeatNumber < (nint)0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1309 @ r14_v22+20+v1321 @ rax_v64 (System.Int32)*4]");
								int32Enum = (System.Int32Enum)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1309 @ r14_v22+20+v1321 @ rax_v64 (System.Int32)*4]");
								bool flag5 = (nint)0 == 0;
								if (!flag5)
								{
									Dictionary<CharacterType, List<CharacterData>> dictionary3 = dictionary;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1309 @ r14_v22+20+v1321 @ rax_v64 (System.Int32)*4]");
									int num = ((Dictionary<System.Int32Enum, object>)(object)dictionary3).FindEntry((System.Int32Enum)0);
									if (!flag5)
									{
										PlayerOptions playerOptions2 = _playerOptions;
										if (playerOptions2._onlineClientWithRunDataConfig == null)
										{
											if (playerOptions2._hostGameConfig == null)
											{
												if (playerOptions2._currentAdventureSaveData != null)
												{
													playerOptionsData = playerOptions2._currentAdventureSaveData;
													if ((object)playerOptionsData._003CSelectedAdventureType_003Ek__BackingField != null)
													{
														goto IL_04d0;
													}
												}
												playerOptionsData = playerOptions2._mainGameConfig;
											}
											else
											{
												playerOptionsData = playerOptions2._hostGameConfig;
											}
										}
										else
										{
											playerOptionsData = playerOptions2._onlineClientWithRunDataConfig;
										}
										goto IL_04d0;
									}
								}
								goto IL_0557;
							}
							throw new IndexOutOfRangeException();
						}
						throw new NullReferenceException();
					}
					System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				}
				throw new NullReferenceException();
			}
			throw new NullReferenceException();
		}
		throw new NullReferenceException();
		IL_04d0:
		if (((Dictionary<CharacterType, List<CharacterData>>)(object)playerOptionsData._003CUnlockedCharacters_003Ek__BackingField).FindEntry((CharacterType)int32Enum) != 0)
		{
			PlayerOptionsData config = _playerOptions.Config;
			if (((Dictionary<CharacterType, List<CharacterData>>)(object)config._003CBoughtCharacters_003Ek__BackingField).FindEntry((CharacterType)int32Enum) != 0)
			{
				goto IL_0a89;
			}
		}
		goto IL_0557;
		IL_06fe:
		PlayerOptionsData playerOptionsData2;
		bool flag6 = ((List<System.Int32Enum>)(object)playerOptionsData2._003CBoughtCharacters_003Ek__BackingField).Remove((System.Int32Enum)0);
		Dictionary<CharacterType, CharacterItem>.Enumerator enumerator2 = default(Dictionary<CharacterType, CharacterItem>.Enumerator);
		while (enumerator2.MoveNext())
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
			CharacterItem characterItem = null;
		}
		return;
		IL_0a89:
		StatsPanelUI statsPanel = StatsPanel;
		if (!statsPanel._hasLoaded)
		{
			statsPanel.Populate();
		}
		TextAutoSizeHelper.UpdateTextSizes(statsPanel._statTextLines, -1);
		_StageCompletionPanel.Initialize();
		object stageCompletionPanel = _StageCompletionPanel;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ rbx_v25 (System.Object)+10]");
		bool flag7 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ rbx_v25 (System.Object)+10]");
		IntPtr gcHandlePtr = Component.get_gameObject_Injected((IntPtr)0);
		GameObject gameObject = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr);
		bool flag8 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
		GameObject.SetActive_Injected(((UnityEngine.Object)gameObject).m_CachedPtr, false);
		UpdateStatsPanelVisibility();
		PlayerOptions playerOptions3 = _playerOptions;
		if (playerOptions3._onlineClientWithRunDataConfig == null)
		{
			if (playerOptions3._hostGameConfig == null)
			{
				if (playerOptions3._currentAdventureSaveData != null)
				{
					playerOptionsData2 = playerOptions3._currentAdventureSaveData;
					if ((object)playerOptionsData2._003CSelectedAdventureType_003Ek__BackingField != null)
					{
						goto IL_06fe;
					}
				}
				playerOptionsData2 = playerOptions3._mainGameConfig;
			}
			else
			{
				playerOptionsData2 = playerOptions3._hostGameConfig;
			}
		}
		else
		{
			playerOptionsData2 = playerOptions3._onlineClientWithRunDataConfig;
		}
		goto IL_06fe;
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
		if (cItem != null && (object)gameObject != null)
		{
			CharacterItemUI component = gameObject.GetComponent<CharacterItemUI>();
			if (_characterItems != null)
			{
				bool flag = ((Dictionary<System.Int32Enum, object>)(object)_characterItems).TryInsert((System.Int32Enum)cItem._characterType, (object)component, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
				if (_spawned != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180497F80");
					CharacterItemUI component2 = gameObject.GetComponent<CharacterItemUI>();
					if ((object)component2 != null)
					{
						CharacterItem charItem = default(CharacterItem);
						bool useDefaultSkin = default(bool);
						component2.SetData(this, _dataManager, _playerOptions, charItem, useDefaultSkin);
						return gameObject;
					}
				}
			}
		}
		return (GameObject)(object)new NullReferenceException();
	}

	private IEnumerator WaitAndDo(Action cb)
	{
		_003CWaitAndDo_003Ed__104 obj = null;
		obj._003C_003E1__state = 0;
		obj.cb = cb;
		return obj;
	}

	public void GoBackOnline()
	{
		Debug.Log("GoBackOnline");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA0490");
		Action b = GoBackOnline;
		BackButtonController.TryRemoveListener(b);
		BackButtonController.IgnoreNextAdditionalListner = false;
	}

	public void ShowPowerUps()
	{
		Action b = GoBackOnline;
		BackButtonController.AddListener(b);
		BackButtonController.IgnoreNextAdditionalListner = true;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9FB80");
	}

	public void ShowAchievements()
	{
		Action b = GoBackOnline;
		BackButtonController.AddListener(b);
		BackButtonController.IgnoreNextAdditionalListner = true;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9F970");
	}

	public void ShowCollections()
	{
		Action b = GoBackOnline;
		BackButtonController.AddListener(b);
		BackButtonController.IgnoreNextAdditionalListner = true;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9FA20");
	}

	public OnlineLobbyPage()
	{
		//IL_0073: Expected O, but got I
		//IL_00cd: Expected O, but got I
		//IL_0498: Expected O, but got I
		//IL_0137: Expected O, but got I
		//IL_04c0: Expected O, but got I
		//IL_01a1: Expected O, but got I
		//IL_04e8: Expected O, but got I
		//IL_020b: Expected O, but got I
		//IL_0510: Expected O, but got I
		//IL_0275: Expected O, but got I
		//IL_0538: Expected O, but got I
		//IL_02df: Expected O, but got I
		//IL_0560: Expected O, but got I
		//IL_0349: Expected O, but got I
		//IL_0588: Expected O, but got I
		//IL_03b3: Expected O, but got I
		//IL_05b0: Expected O, but got I
		//IL_041d: Expected O, but got I
		Dictionary<CharacterType, CharacterItemUI> characterItems = new Dictionary<CharacterType, CharacterItemUI>();
		_characterItems = characterItems;
		_spawned = new List<GameObject>();
		_skinSlots = new List<Image>();
		List<int> list = new List<int>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v261 @ rax_v11 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v261 @ rax_v11 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v261 @ rax_v11 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v301 @ rdx_v10+18]");
		if (num >= 0)
		{
			list.AddWithResize(1);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v261 @ rax_v11 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v261 @ rax_v11 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v261 @ rax_v11 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v261 @ rax_v11 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v323 @ rdx_v12+18]");
		if (num2 >= 0)
		{
			list.AddWithResize(174);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v261 @ rax_v11 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 174;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v261 @ rax_v11 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v261 @ rax_v11 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v261 @ rax_v11 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v324 @ rdx_v14+18]");
		if (num3 >= 0)
		{
			list.AddWithResize(169);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v261 @ rax_v11 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 169;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v261 @ rax_v11 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v261 @ rax_v11 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v261 @ rax_v11 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v325 @ rdx_v16+18]");
		if (num4 >= 0)
		{
			list.AddWithResize(990);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v261 @ rax_v11 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj8 = (nint)0 + (nint)1;
			_ = 990;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v261 @ rax_v11 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v261 @ rax_v11 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v261 @ rax_v11 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v326 @ rdx_v18+18]");
		if (num5 >= 0)
		{
			list.AddWithResize(1421);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v261 @ rax_v11 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj10 = (nint)0 + (nint)1;
			_ = 1421;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v261 @ rax_v11 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v261 @ rax_v11 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v261 @ rax_v11 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v327 @ rdx_v20+18]");
		if (num6 >= 0)
		{
			list.AddWithResize(65376);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v261 @ rax_v11 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj12 = (nint)0 + (nint)1;
			_ = 65376;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v261 @ rax_v11 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v261 @ rax_v11 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v261 @ rax_v11 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v328 @ rdx_v22+18]");
		if (num7 >= 0)
		{
			list.AddWithResize(65483);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v261 @ rax_v11 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj14 = (nint)0 + (nint)1;
			_ = 65483;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v261 @ rax_v11 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v261 @ rax_v11 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v261 @ rax_v11 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v329 @ rdx_v24+18]");
		if (num8 >= 0)
		{
			list.AddWithResize(65509);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v261 @ rax_v11 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj16 = (nint)0 + (nint)1;
			_ = 65509;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v261 @ rax_v11 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v261 @ rax_v11 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj17 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v261 @ rax_v11 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v330 @ rdx_v26+18]");
		if (num9 >= 0)
		{
			list.AddWithResize(65533);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v261 @ rax_v11 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj18 = (nint)0 + (nint)1;
			_ = 65533;
		}
		_weirdCharacters = list;
		_tempUnlockedCoopCharacters = new List<CharacterType>();
		base._002Ector();
	}

	static OnlineLobbyPage()
	{
		float iCON_UI_SCALE = UIHelper.JS_MAGIC_SCALE_NUMBER + UIHelper.JS_MAGIC_SCALE_NUMBER;
		ICON_UI_SCALE = iCON_UI_SCALE;
	}
}
