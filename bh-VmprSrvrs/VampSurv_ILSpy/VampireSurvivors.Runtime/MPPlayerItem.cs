using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using I2.Loc;
using Rewired;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects;
using VampireSurvivors.Objects.Algorithm;

public class MPPlayerItem : MonoBehaviour
{
	public enum PlayerState
	{
		INACTIVE,
		CONNECTED,
		WAITING,
		SELECTING,
		FINISHED,
		LOCKED
	}

	private GameObject _CharacterSelectedGroup;

	private GameObject _AwaitingPlayerGroup;

	private GameObject _AwaitingSelectionGroup;

	private GameObject _AwaitingTurnGroup;

	private GameObject _AwaitingConnect;

	private TextMeshProUGUI _AwaitingConnectText;

	private Image _Frame;

	private Image _OuterFrame;

	private TextMeshProUGUI _CharacterName;

	private TextMeshProUGUI _PlayerName;

	private Image _CharacterIcon;

	private Image _WeaponIcon;

	private Image _WeaponShadow;

	private Image _aiIcon;

	public PlayerState _PlayerState;

	private DataManager _dataManager;

	private PlayerOptions _playerOptions;

	private CharacterType _type;

	private CharacterData _data;

	private int _index;

	public Player PotentialPlayer
	{
		get
		{
			if (MultiplayerManager.s_instance != null)
			{
				return MultiplayerManager.s_instance.GetPotentialRewiredPlayer(_index);
			}
			return (Player)(object)new NullReferenceException();
		}
	}

	public Player Player
	{
		get
		{
			if (MultiplayerManager.s_instance != null)
			{
				CoopSlotData slotInfo = MultiplayerManager.s_instance.GetSlotInfo(_index);
				if (slotInfo != null)
				{
					return slotInfo.RewiredPlayer;
				}
			}
			return (Player)(object)new NullReferenceException();
		}
	}

	public AIType AITypeValue
	{
		get
		{
			//IL_004e: Expected I4, but got O
			if (MultiplayerManager.s_instance != null)
			{
				CoopSlotData slotInfo = MultiplayerManager.s_instance.GetSlotInfo(_index);
				if (slotInfo != null)
				{
					return slotInfo.AIType;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (AIType)ex;
		}
	}

	public bool HasAI
	{
		get
		{
			//IL_0094: Expected I4, but got O
			if (MultiplayerManager.s_instance != null)
			{
				CoopSlotData slotInfo = MultiplayerManager.s_instance.GetSlotInfo(_index);
				if (slotInfo != null)
				{
					bool flag = slotInfo.AIType < AIType.None;
					bool flag2 = slotInfo.AIType == AIType.None;
					bool flag3 = !flag;
					bool flag4 = !flag2;
					return flag4 & flag3;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	public CharacterType Type => _type;

	public void Initialize(DataManager dataManager, PlayerOptions playerOptions)
	{
		_dataManager = dataManager;
		_playerOptions = playerOptions;
	}

	private void Awake()
	{
		GameObject gameObject = _aiIcon.gameObject;
		gameObject.SetActive(value: false);
	}

	public void SetCharacterType(CharacterType characterType)
	{
		_type = characterType;
	}

	private void Update()
	{
		//IL_002f: Expected O, but got I4
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Expected O, but got Unknown
		//IL_00f8: Expected O, but got I4
		//IL_015f: Expected O, but got I4
		bool flag = _PlayerState == PlayerState.INACTIVE;
		if (!flag)
		{
			object obj = _PlayerState - 1;
			if (!flag)
			{
				object obj2 = obj - 1;
				if (!flag)
				{
					object obj3 = obj2 - 1;
					if (!flag)
					{
						if ((nint)obj3 == 1)
						{
							RefreshData();
						}
						return;
					}
					if (!HasAI)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18695F8A0");
						int index = _index;
						MultiplayerManager multiplayerManager = default(MultiplayerManager);
						CoopSlotData slotInfo = multiplayerManager.GetSlotInfo(_index);
						bool flag2 = slotInfo == null;
						object obj4 = 0;
						MultiplayerManager multiplayerManager2 = multiplayerManager;
						if (!flag2)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18695F8A0");
							index = _index;
							MultiplayerManager multiplayerManager3 = default(MultiplayerManager);
							CoopSlotData slotInfo2 = multiplayerManager3.GetSlotInfo(_index);
							bool flag3 = slotInfo2.SelectedCharacter != CharacterType.VOID;
							obj4 = 0;
							multiplayerManager2 = multiplayerManager3;
							if (flag3)
							{
								goto IL_0312;
							}
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18695F8A0");
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rax_v26+80]");
						if ((nint)0 != _index)
						{
							goto IL_01aa;
						}
						return;
					}
				}
				else if (!HasAI)
				{
					Player player = Player;
					if (player != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18695F8A0");
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v144 @ rax_v20+80]");
						if ((nint)0 == _index)
						{
							GoToSelecting();
						}
						return;
					}
					goto IL_029b;
				}
			}
			else if (!HasAI)
			{
				Player player2 = Player;
				if (player2 != null)
				{
					goto IL_01aa;
				}
				Player potentialPlayer = PotentialPlayer;
				if (potentialPlayer == null)
				{
					goto IL_029b;
				}
				return;
			}
		}
		else if (!HasAI)
		{
			Player player3 = Player;
			if (player3 == null)
			{
				Player potentialPlayer2 = PotentialPlayer;
				if (potentialPlayer2 == null)
				{
					return;
				}
			}
			GoToConnected();
			return;
		}
		goto IL_0312;
		IL_0312:
		GoToFinished();
		return;
		IL_01aa:
		GoToWaiting();
		return;
		IL_029b:
		GoToInactive();
	}

	public unsafe void SetData()
	{
		//IL_0433: Expected O, but got I4
		//IL_0208: Unknown result type (might be due to invalid IL or missing references)
		//IL_020d: Expected Ref, but got Unknown
		//IL_0224: Expected I8, but got I4
		//IL_022d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0232: Expected Ref, but got Unknown
		//IL_04aa: Expected O, but got I4
		//IL_0580: Expected O, but got I
		//IL_073b->IL0671: Incompatible stack heights: 2 vs 0
		//IL_0671->IL0740: Incompatible stack heights: 2 vs 0
		if (_data == null)
		{
			return;
		}
		CharacterData data = _data;
		SetName(data._003CcharName_003Ek__BackingField);
		bool flag2;
		if (_data != null)
		{
			string firstNameLocKey = _data.GetFirstNameLocKey(_type);
			bool applyParameters = default(bool);
			GameObject localParametersRoot = default(GameObject);
			string overrideLanguage = default(string);
			bool allowLocalizedParameters = default(bool);
			string translation = LocalizationManager.GetTranslation(firstNameLocKey, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
			if ((object)_CharacterName != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18634B7A0");
				if ((object)_CharacterName != null)
				{
					string text = _CharacterName.text;
					bool flag = text == null;
					flag2 = true;
					if (!flag)
					{
						bool flag3 = text._stringLength <= 0;
						flag2 = true;
						if (!flag3)
						{
							if ((object)_CharacterName == null)
							{
								goto IL_0671;
							}
							string text2 = _CharacterName.text;
							bool flag4 = (object)text2 == firstNameLocKey;
							flag2 = true;
							if (!flag4)
							{
								bool flag5 = text2 == null;
								bool flag6 = true;
								if (!flag5)
								{
									bool flag7 = firstNameLocKey == null;
									flag6 = true;
									if (!flag7)
									{
										bool flag8 = text2._stringLength != firstNameLocKey._stringLength;
										flag6 = true;
										if (!flag8)
										{
											ref byte second = ref *(byte*)(firstNameLocKey + 20);
											ulong length = (ulong)(text2._stringLength + text2._stringLength);
											bool flag9 = System.SpanHelpers.SequenceEqual(ref *(byte*)(text2 + 20), ref second, length);
											bool flag10 = !flag9;
											flag2 = false;
											flag6 = false;
											if (!flag10)
											{
												goto IL_0272;
											}
										}
									}
								}
								goto IL_02d1;
							}
						}
					}
					goto IL_0272;
				}
			}
		}
		goto IL_0671;
		IL_05b1:
		string spriteName;
		string textureName;
		Sprite sprite = SpriteManager.GetSprite(spriteName, textureName);
		Skin skinForCharacter;
		if ((object)_CharacterIcon != null)
		{
			_CharacterIcon.sprite = sprite;
			if ((object)_CharacterIcon != null)
			{
				RectTransform rectTransform = _CharacterIcon.rectTransform;
				if ((object)sprite != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v297 @ rax_v31 (UnityEngine.Sprite)+10]");
					bool flag11 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v297 @ rax_v31 (UnityEngine.Sprite)+10]");
					Sprite.get_rect_Injected((IntPtr)0, out Rect _);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v297 @ rax_v31 (UnityEngine.Sprite)+10]");
					bool flag12 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v297 @ rax_v31 (UnityEngine.Sprite)+10]");
					Sprite.get_rect_Injected((IntPtr)0, out Rect _);
					if ((object)rectTransform != null)
					{
						Vector2 sizeDelta = default(Vector2);
						rectTransform.sizeDelta = sizeDelta;
						SetWeaponIconSprite(_data, skinForCharacter);
						return;
					}
				}
			}
		}
		goto IL_0671;
		IL_0272:
		CharacterData data2 = _data;
		if (_data != null && (object)_CharacterName != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18634B7A0");
			bool flag6 = flag2;
			goto IL_02d1;
		}
		goto IL_0671;
		IL_0592:
		spriteName = skinForCharacter._003CspriteName_003Ek__BackingField;
		textureName = skinForCharacter._003CtextureName_003Ek__BackingField;
		goto IL_05b1;
		IL_0671:
		throw new NullReferenceException();
		IL_02d1:
		if (_type == CharacterType.ARENGIJUS)
		{
			CharacterData data3 = _data;
			if (_data == null || (object)_CharacterName == null)
			{
				goto IL_0671;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18634B7A0");
		}
		if (_playerOptions != null)
		{
			SkinType skinTypeForCharacter = _playerOptions.GetSkinTypeForCharacter(_type);
			skinForCharacter = _playerOptions.GetSkinForCharacter(_type, skinTypeForCharacter);
			if (skinForCharacter != null)
			{
				object obj;
				if (skinForCharacter._003CcharSelFrame_003Ek__BackingField == null)
				{
					obj = null;
				}
				else
				{
					bool flag13 = (nint)skinForCharacter._003CcharSelTexture_003Ek__BackingField < 0;
					bool flag14 = skinForCharacter._003CcharSelTexture_003Ek__BackingField == null;
					bool flag15 = !flag13;
					bool flag16 = !flag14;
					obj = flag16 & flag15;
				}
				CharacterData data4 = _data;
				if (_data != null)
				{
					bool flag17 = data4._003CcharSelFrame_003Ek__BackingField == null;
					object obj2 = null;
					if (!flag17)
					{
						bool flag18 = (nint)data4._003CcharSelTexture_003Ek__BackingField < 0;
						flag17 = data4._003CcharSelTexture_003Ek__BackingField == null;
						bool flag19 = !flag18;
						bool flag20 = !flag17;
						obj2 = flag20 & flag19;
					}
					if (flag17)
					{
						goto IL_0592;
					}
					SetWeaponIconSprite(_data, skinForCharacter);
					if (obj != null)
					{
						spriteName = skinForCharacter._003CcharSelFrame_003Ek__BackingField;
						textureName = skinForCharacter._003CcharSelTexture_003Ek__BackingField;
					}
					else
					{
						if (skinForCharacter.skinType != SkinType.DEFAULT || obj2 == null)
						{
							goto IL_0592;
						}
						object data5 = _data;
						if (_data == null)
						{
							goto IL_0671;
						}
						CharacterData data6 = _data;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v252 @ rsi_v13 (System.Object)+58]");
						spriteName = (string)0;
						textureName = data6._003CcharSelTexture_003Ek__BackingField;
					}
					goto IL_05b1;
				}
			}
		}
		goto IL_0671;
	}

	private void SetWeaponIconSprite(CharacterData characterData, Skin skinData)
	{
		//IL_00fb: Expected I4, but got O
		//IL_00bf: Expected O, but got I
		//IL_0151: Expected O, but got I
		//IL_01a7: Expected O, but got I
		//IL_01a7: Expected O, but got I
		System.Int32Enum int32Enum;
		WeaponType? weaponType;
		if ((object)skinData._003CstartingWeapon_003Ek__BackingField == null)
		{
			if ((object)characterData._003CstartingWeapon_003Ek__BackingField == null)
			{
				int32Enum = (System.Int32Enum)3;
				goto IL_005d;
			}
			weaponType = characterData._003CstartingWeapon_003Ek__BackingField;
		}
		else
		{
			weaponType = skinData._003CstartingWeapon_003Ek__BackingField;
		}
		if ((object)weaponType != null)
		{
			int32Enum = (System.Int32Enum)((object?)weaponType >> 32);
			if (int32Enum == (System.Int32Enum)0)
			{
				_WeaponIcon.enabled = false;
				_WeaponShadow.enabled = false;
				return;
			}
			goto IL_005d;
		}
		goto IL_020b;
		IL_005d:
		Dictionary<WeaponType, List<WeaponData>> convertedWeapons = _dataManager.GetConvertedWeapons();
		object obj = ((Dictionary<System.Int32Enum, object>)(object)convertedWeapons).get_Item(int32Enum);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ rax_v11 (System.Object)+18]");
		if ((nint)0 > (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ rax_v11 (System.Object)+10]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ rax_v12+20]");
			object obj3 = 0;
			_WeaponIcon.enabled = true;
			_WeaponShadow.enabled = true;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ rbx_v7+40]");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ rbx_v7+38]");
			Sprite sprite = SpriteManager.GetSprite((string)num, (string)0);
			_WeaponIcon.sprite = sprite;
			Image weaponIcon = _WeaponIcon;
			_WeaponShadow.sprite = weaponIcon.m_Sprite;
			return;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		goto IL_020b;
		IL_020b:
		System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
	}

	public unsafe void GoToInactive()
	{
		//IL_01eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f0: Expected I4, but got Unknown
		//IL_008b: Expected O, but got Ref
		int num = this + 184;
		string text = ((int*)num)->ToString();
		string message = text + ": Going to Inactive State";
		Debug.Log(message);
		_AwaitingPlayerGroup.SetActive(value: false);
		_AwaitingTurnGroup.SetActive(value: false);
		_AwaitingSelectionGroup.SetActive(value: false);
		_CharacterSelectedGroup.SetActive(value: false);
		_AwaitingConnect.SetActive(value: true);
		object obj = default(object);
		_Frame.color = (Color)(&obj);
		_OuterFrame.enabled = false;
		RectTransform component = GetComponent<RectTransform>();
		Vector2 sizeDelta = default(Vector2);
		component.sizeDelta = sizeDelta;
		Transform transform = _PlayerName.transform;
		Transform parent = transform.parent;
		GameObject gameObject = parent.gameObject;
		gameObject.SetActive(value: false);
		_PlayerState = PlayerState.INACTIVE;
		PlayerOptionsData config = _playerOptions.Config;
		List<ItemType> list = config._003CCollectedItems_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v182 @ rcx_v21 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		bool flag = (nint)0 == 0;
		string term = "lang/multiplayer_awaiting_connect";
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj2 = default(object);
			bool flag2 = (nint)obj2 == -1;
			term = "lang/multiplayer_awaiting_connect";
			if (!flag2)
			{
				term = "partyLang/ConnectOrSelect";
			}
		}
		bool applyParameters = default(bool);
		GameObject localParametersRoot = default(GameObject);
		string overrideLanguage = default(string);
		bool allowLocalizedParameters = default(bool);
		string translation = LocalizationManager.GetTranslation(term, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18634B7A0");
	}

	public void SetPartymodeText()
	{
		if (_PlayerState == PlayerState.INACTIVE)
		{
			PlayerOptionsData config = _playerOptions.Config;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A965C0");
			object obj = default(object);
			if (obj != null)
			{
				bool applyParameters = default(bool);
				GameObject localParametersRoot = default(GameObject);
				string overrideLanguage = default(string);
				bool allowLocalizedParameters = default(bool);
				string translation = LocalizationManager.GetTranslation("partyLang/ConnectOrSelect", FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18634B7A0");
			}
		}
	}

	public unsafe void GoToConnected()
	{
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Expected I4, but got Unknown
		int num = this + 184;
		string text = ((int*)num)->ToString();
		string message = text + ": Going to Connected State";
		Debug.Log(message);
		_AwaitingPlayerGroup.SetActive(value: true);
		_AwaitingTurnGroup.SetActive(value: false);
		_AwaitingSelectionGroup.SetActive(value: false);
		_CharacterSelectedGroup.SetActive(value: false);
		_AwaitingConnect.SetActive(value: false);
		RectTransform component = GetComponent<RectTransform>();
		Vector2 sizeDelta = default(Vector2);
		component.sizeDelta = sizeDelta;
		Transform transform = _PlayerName.transform;
		Transform parent = transform.parent;
		GameObject gameObject = parent.gameObject;
		gameObject.SetActive(value: false);
		_PlayerState = PlayerState.CONNECTED;
		SetColor();
		_OuterFrame.enabled = false;
	}

	public void LockSelection()
	{
		_PlayerState = PlayerState.LOCKED;
	}

	public void UnlockSelected()
	{
		_PlayerState = PlayerState.INACTIVE;
	}

	public unsafe void SetPlayerName(int index)
	{
		//IL_0058: Expected O, but got Ref
		bool applyParameters = default(bool);
		GameObject localParametersRoot = default(GameObject);
		string overrideLanguage = default(string);
		bool allowLocalizedParameters = default(bool);
		string translation = LocalizationManager.GetTranslation("lang/multiplayer_player_name", FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
		int value = index + 1;
		object obj = default(object);
		string newValue = System.Number.FormatInt32(value, (ReadOnlySpan<char>)(&obj), null);
		string text = translation.Replace("%0", newValue);
		_PlayerName.text = text;
	}

	public unsafe void GoToWaiting()
	{
		//IL_0137: Unknown result type (might be due to invalid IL or missing references)
		//IL_013c: Expected I4, but got Unknown
		int num = this + 184;
		string text = ((int*)num)->ToString();
		string message = text + ": Going to Waiting State";
		Debug.Log(message);
		_PlayerState = PlayerState.WAITING;
		_AwaitingPlayerGroup.SetActive(value: false);
		_AwaitingTurnGroup.SetActive(value: true);
		_AwaitingSelectionGroup.SetActive(value: false);
		_CharacterSelectedGroup.SetActive(value: false);
		_AwaitingConnect.SetActive(value: false);
		SetColor(0.5f);
		_OuterFrame.enabled = false;
		RectTransform component = GetComponent<RectTransform>();
		Vector2 sizeDelta = default(Vector2);
		component.sizeDelta = sizeDelta;
		Transform transform = _PlayerName.transform;
		Transform parent = transform.parent;
		GameObject gameObject = parent.gameObject;
		gameObject.SetActive(value: true);
		GameObject gameObject2 = _aiIcon.gameObject;
		gameObject2.SetActive(value: false);
	}

	public void SetIndex(int index)
	{
		_index = index;
	}

	private unsafe void SetColor(float saturation = 1f)
	{
		//IL_0097: Expected O, but got Ref
		//IL_004f: Invalid comparison between I4 and F4
		Color slotColor = MultiplayerManager.s_instance.GetSlotColor(_index);
		bool flag = !(1f > saturation);
		float num = slotColor.r;
		if (!flag)
		{
			if (0f > saturation || saturation > 1f)
			{
			}
			float num2 = default(float);
			num = num2;
		}
		_Frame.color = (Color)(&num);
	}

	public unsafe void GoToSelecting()
	{
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected I4, but got Unknown
		int num = this + 184;
		string text = ((int*)num)->ToString();
		string message = text + ": Going to Selection State";
		Debug.Log(message);
		_AwaitingTurnGroup.SetActive(value: false);
		_AwaitingSelectionGroup.SetActive(value: true);
		_CharacterSelectedGroup.SetActive(value: false);
		_AwaitingConnect.SetActive(value: false);
		SetColor();
		_PlayerState = PlayerState.SELECTING;
		_OuterFrame.enabled = true;
	}

	public unsafe void GoToFinished()
	{
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0120: Expected I4, but got Unknown
		int num = this + 184;
		string text = ((int*)num)->ToString();
		string message = text + ": Going to Finished State";
		Debug.Log(message);
		RefreshData();
		_AwaitingPlayerGroup.SetActive(value: false);
		_AwaitingTurnGroup.SetActive(value: false);
		_AwaitingSelectionGroup.SetActive(value: false);
		_CharacterSelectedGroup.SetActive(value: true);
		Transform transform = _PlayerName.transform;
		Transform parent = transform.parent;
		GameObject gameObject = parent.gameObject;
		gameObject.SetActive(value: true);
		_AwaitingConnect.SetActive(value: false);
		RectTransform component = GetComponent<RectTransform>();
		Vector2 sizeDelta = default(Vector2);
		component.sizeDelta = sizeDelta;
		SetColor(0.5f);
		_PlayerState = PlayerState.FINISHED;
		_OuterFrame.enabled = false;
	}

	public void UpdateAIIcon()
	{
		//IL_00ef: Expected O, but got I
		//IL_00ef: Expected O, but got I
		if (HasAI)
		{
			DataManager dataManager = _dataManager;
			AIType aITypeValue = AITypeValue;
			object obj = ((Dictionary<System.Int32Enum, object>)(object)dataManager._003CAllCPU_003Ek__BackingField).get_Item((System.Int32Enum)aITypeValue);
			if (obj != null)
			{
				DataManager dataManager2 = _dataManager;
				AIType aITypeValue2 = AITypeValue;
				object obj2 = ((Dictionary<System.Int32Enum, object>)(object)dataManager2._003CAllCPU_003Ek__BackingField).get_Item((System.Int32Enum)aITypeValue2);
				DataManager dataManager3 = _dataManager;
				AIType aITypeValue3 = AITypeValue;
				object obj3 = ((Dictionary<System.Int32Enum, object>)(object)dataManager3._003CAllCPU_003Ek__BackingField).get_Item((System.Int32Enum)aITypeValue3);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rax_v14 (System.Object)+18]");
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ rax_v17 (System.Object)+20]");
				Sprite sprite = SpriteManager.GetSprite((string)num, (string)0);
				_aiIcon.sprite = sprite;
			}
			GameObject gameObject = _aiIcon.gameObject;
			gameObject.SetActive(value: true);
		}
	}

	public void RefreshData()
	{
		//IL_010c: Expected O, but got I
		//IL_0123: Expected O, but got I
		CoopSlotData slotInfo = MultiplayerManager.s_instance.GetSlotInfo(_index);
		if (slotInfo != null)
		{
			CoopSlotData slotInfo2 = MultiplayerManager.s_instance.GetSlotInfo(_index);
			if (slotInfo2.SelectedCharacter != CharacterType.VOID)
			{
				CoopSlotData slotInfo3 = MultiplayerManager.s_instance.GetSlotInfo(_index);
				_type = slotInfo3.SelectedCharacter;
				Dictionary<CharacterType, List<CharacterData>> convertedCharacterData = _dataManager.GetConvertedCharacterData();
				object obj = ((Dictionary<System.Int32Enum, object>)(object)convertedCharacterData).get_Item((System.Int32Enum)_type);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ rax_v21 (System.Object)+18]");
				if ((nint)0 > (nint)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ rax_v21 (System.Object)+10]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rax_v22+20]");
					_data = (CharacterData)0;
					SetData();
				}
				else
				{
					System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				}
				return;
			}
		}
		GoToWaiting();
	}

	public MPPlayerItem()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
