using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects;

namespace VampireSurvivors.UI;

public class OnlineMPPlayerItem : MonoBehaviour
{
	private GameObject _CharacterSelectedGroup;

	private GameObject _PlayerNotConnected;

	private Image _Frame;

	private Image _OuterFrame;

	private TextMeshProUGUI _CharacterName;

	private TextMeshProUGUI _PlayerName;

	private Image _CharacterIcon;

	private Image _WeaponIcon;

	private Image _WeaponShadow;

	private GameObject _selectionFrame;

	private GameObject _selectionBox;

	private GameObject _selectionTick;

	private GameObject _aiSettingsButton;

	private DataManager _dataManager;

	private PlayerOptions _playerOptions;

	private PlayerInfo _onlinePlayerInfo;

	private CharacterData _data;

	private int _index;

	private bool _isMyPlayerButton;

	private Action m_OnAiSettingsButtonClicked;

	public PlayerInfo OnlinePlayerInfo => _onlinePlayerInfo;

	public event Action OnAiSettingsButtonClicked
	{
		add
		{
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d7: Expected O, but got Unknown
			object obj = this + 176;
			Delegate obj2 = this.m_OnAiSettingsButtonClicked;
			while (true)
			{
				Delegate obj3 = Delegate.Combine(obj2, value);
				bool flag = (object)obj3 == null;
				Delegate obj4 = null;
				if (!flag)
				{
					bool flag2 = (object)obj3.GetType() != typeof(Action);
					obj4 = null;
					if (!flag2)
					{
						obj4 = obj3;
					}
					if ((object)obj4 == null)
					{
						break;
					}
				}
				bool flag3 = obj2 == obj;
				Delegate obj5;
				if (obj2 == obj)
				{
					obj = obj4;
					obj5 = obj2;
				}
				else
				{
					obj5 = (Delegate)obj;
				}
				Delegate obj6 = obj2;
				if (!flag3)
				{
					obj6 = obj5;
				}
				bool flag4 = (object)obj6 != obj2;
				obj2 = obj6;
				if (!flag4)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
		remove
		{
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d7: Expected O, but got Unknown
			object obj = this + 176;
			Delegate obj2 = this.m_OnAiSettingsButtonClicked;
			while (true)
			{
				Delegate obj3 = Delegate.Remove(obj2, value);
				bool flag = (object)obj3 == null;
				Delegate obj4 = null;
				if (!flag)
				{
					bool flag2 = (object)obj3.GetType() != typeof(Action);
					obj4 = null;
					if (!flag2)
					{
						obj4 = obj3;
					}
					if ((object)obj4 == null)
					{
						break;
					}
				}
				bool flag3 = obj2 == obj;
				Delegate obj5;
				if (obj2 == obj)
				{
					obj = obj4;
					obj5 = obj2;
				}
				else
				{
					obj5 = (Delegate)obj;
				}
				Delegate obj6 = obj2;
				if (!flag3)
				{
					obj6 = obj5;
				}
				bool flag4 = (object)obj6 != obj2;
				obj2 = obj6;
				if (!flag4)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
	}

	private void Construct(DataManager dataManager, PlayerOptions playerOptions)
	{
		_dataManager = dataManager;
		_playerOptions = playerOptions;
	}

	private void Awake()
	{
		Button component = _aiSettingsButton.GetComponent<Button>();
		UnityAction call = delegate
		{
			Action onAiSettingsButtonClicked = this.m_OnAiSettingsButtonClicked;
			if (this.m_OnAiSettingsButtonClicked != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v0.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		};
		component.m_OnClick.AddListener(call);
		_aiSettingsButton.SetActive(value: false);
	}

	public unsafe void Init(PlayerInfo playerInfo, int seatNumber)
	{
		//IL_0131: Expected O, but got I4
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_013e: Expected O, but got Unknown
		//IL_01b8: Expected O, but got Ref
		PlayerInfo onlinePlayerInfo = _onlinePlayerInfo;
		if ((object)_onlinePlayerInfo != null && ((UnityEngine.Object)onlinePlayerInfo).m_CachedPtr != (IntPtr)0)
		{
			PlayerInfo onlinePlayerInfo2 = _onlinePlayerInfo;
			Action<CharacterType> value = SetData;
			Delegate obj = Delegate.Remove(onlinePlayerInfo2.OnCharacterSelectionChanged, value);
			if ((object)obj == null)
			{
				onlinePlayerInfo2.OnCharacterSelectionChanged = null;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				Action<CharacterType> action = default(Action<CharacterType>);
				if (action == null)
				{
					throw new InvalidCastException();
				}
				onlinePlayerInfo2.OnCharacterSelectionChanged = action;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj2 = default(object);
				if (obj2 == null)
				{
					throw new InvalidCastException();
				}
			}
		}
		_aiSettingsButton.SetActive(value: false);
		int mySeatNumber = OnlineStageManager._instance.GetMySeatNumber();
		object obj3 = mySeatNumber + 1;
		object obj4 = seatNumber - obj3;
		bool isMyPlayerButton = obj4 == null;
		_isMyPlayerButton = isMyPlayerButton;
		GameObject playerNotConnected;
		bool active;
		if ((object)playerInfo != null && ((UnityEngine.Object)playerInfo).m_CachedPtr != (IntPtr)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object arg = default(object);
			System.ParamsArray paramsArray = new System.ParamsArray(arg);
			object obj5 = default(object);
			string text = string.FormatHelper((IFormatProvider)null, "Player {0}", (System.ParamsArray)(&obj5));
			_PlayerName.text = text;
			_onlinePlayerInfo = playerInfo;
			PlayerInfo onlinePlayerInfo3 = _onlinePlayerInfo;
			Action<CharacterType> b = SetData;
			Delegate obj6 = Delegate.Combine(onlinePlayerInfo3.OnCharacterSelectionChanged, b);
			if ((object)obj6 == null)
			{
				onlinePlayerInfo3.OnCharacterSelectionChanged = null;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				Action<CharacterType> action2 = default(Action<CharacterType>);
				if (action2 == null)
				{
					throw new InvalidCastException();
				}
				onlinePlayerInfo3.OnCharacterSelectionChanged = action2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj7 = default(object);
				if (obj7 == null)
				{
					throw new InvalidCastException();
				}
			}
			PlayerInfo onlinePlayerInfo4 = _onlinePlayerInfo;
			Action<SkinType> b2 = RefreshForSkin;
			Delegate obj8 = Delegate.Combine(onlinePlayerInfo4.OnSkinSelectionChanged, b2);
			if ((object)obj8 == null)
			{
				onlinePlayerInfo4.OnSkinSelectionChanged = null;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				Action<SkinType> action3 = default(Action<SkinType>);
				if (action3 == null)
				{
					throw new InvalidCastException();
				}
				onlinePlayerInfo4.OnSkinSelectionChanged = action3;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj9 = default(object);
				if (obj9 == null)
				{
					throw new InvalidCastException();
				}
			}
			_selectionFrame.SetActive(playerInfo._isReadyToPlay);
			_selectionTick.SetActive(playerInfo._isReadyToPlay);
			_selectionBox.SetActive(value: true);
			if (playerInfo._selectedCharacter == CharacterType.VOID)
			{
				return;
			}
			SetData(playerInfo._selectedCharacter);
			Transform transform = _PlayerName.transform;
			Transform parent = transform.parent;
			GameObject gameObject = parent.gameObject;
			gameObject.SetActive(value: true);
			_CharacterSelectedGroup.SetActive(value: true);
			playerNotConnected = _PlayerNotConnected;
			active = false;
		}
		else
		{
			_onlinePlayerInfo = null;
			_CharacterSelectedGroup.SetActive(value: false);
			Transform transform2 = _PlayerName.transform;
			Transform parent2 = transform2.parent;
			GameObject gameObject2 = parent2.gameObject;
			gameObject2.SetActive(value: false);
			playerNotConnected = _PlayerNotConnected;
			active = true;
		}
		playerNotConnected.SetActive(active);
	}

	private void OnDestroy()
	{
		PlayerInfo onlinePlayerInfo = _onlinePlayerInfo;
		if ((object)_onlinePlayerInfo == null || ((UnityEngine.Object)onlinePlayerInfo).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		PlayerInfo onlinePlayerInfo2 = _onlinePlayerInfo;
		Action<CharacterType> value = SetData;
		Delegate obj = Delegate.Remove(onlinePlayerInfo2.OnCharacterSelectionChanged, value);
		if ((object)obj == null)
		{
			onlinePlayerInfo2.OnCharacterSelectionChanged = (Action<CharacterType>)obj;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			Action<CharacterType> action = default(Action<CharacterType>);
			if (action == null)
			{
				throw new InvalidCastException();
			}
			onlinePlayerInfo2.OnCharacterSelectionChanged = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj2 = default(object);
			if (obj2 == null)
			{
				throw new InvalidCastException();
			}
		}
		PlayerInfo onlinePlayerInfo3 = _onlinePlayerInfo;
		Action<SkinType> value2 = RefreshForSkin;
		Delegate obj3 = Delegate.Remove(onlinePlayerInfo3.OnSkinSelectionChanged, value2);
		if ((object)obj3 == null)
		{
			onlinePlayerInfo3.OnSkinSelectionChanged = (Action<SkinType>)obj3;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		Action<SkinType> action2 = default(Action<SkinType>);
		if (action2 != null)
		{
			onlinePlayerInfo3.OnSkinSelectionChanged = action2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj4 = default(object);
			if (obj4 != null)
			{
				return;
			}
			throw new InvalidCastException();
		}
		throw new InvalidCastException();
	}

	private void Update()
	{
		PlayerInfo onlinePlayerInfo = _onlinePlayerInfo;
		bool flag;
		if ((object)_onlinePlayerInfo != null && ((UnityEngine.Object)onlinePlayerInfo).m_CachedPtr != (IntPtr)0)
		{
			PlayerInfo onlinePlayerInfo2 = _onlinePlayerInfo;
			flag = onlinePlayerInfo2._isReadyToPlay;
		}
		else
		{
			flag = false;
		}
		bool flag2 = !flag;
		bool active = !flag2;
		_selectionFrame.SetActive(active);
		PlayerInfo onlinePlayerInfo3 = _onlinePlayerInfo;
		bool flag3 = (object)_onlinePlayerInfo == null;
		bool flag4 = false;
		if (!flag3)
		{
			bool flag5 = ((UnityEngine.Object)onlinePlayerInfo3).m_CachedPtr == (IntPtr)0;
			flag4 = false;
			if (!flag5)
			{
				PlayerInfo onlinePlayerInfo4 = _onlinePlayerInfo;
				flag4 = onlinePlayerInfo4._isReadyToPlay;
			}
		}
		bool flag6 = !flag4;
		bool active2 = !flag6;
		_selectionTick.SetActive(active2);
	}

	public unsafe void SetAIData(CharacterType type, int index)
	{
		//IL_0083: Expected O, but got Ref
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A338D]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_onlinePlayerInfo = null;
		_CharacterSelectedGroup.SetActive(value: true);
		_PlayerNotConnected.SetActive(value: false);
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object arg = default(object);
		System.ParamsArray paramsArray = new System.ParamsArray(arg);
		object obj = default(object);
		string text = string.FormatHelper((IFormatProvider)null, "Player {0}", (System.ParamsArray)(&obj));
		_PlayerName.text = text;
		Transform transform = _PlayerName.transform;
		Transform parent = transform.parent;
		GameObject gameObject = parent.gameObject;
		gameObject.SetActive(value: true);
		_aiSettingsButton.SetActive(value: true);
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 223 Invalid \"Jump target not found in method: 0x186D3B9B0\"");
		throw new NullReferenceException();
	}

	private void RefreshForSkin(SkinType skinType)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 16 Invalid \"Jump target not found in method: 0x186D3B9B0\"");
		throw new NullReferenceException();
	}

	private unsafe void SetData(CharacterType type)
	{
		//IL_072f: Expected O, but got Ref
		//IL_00ae: Expected O, but got I
		//IL_00c5: Expected O, but got I
		//IL_06f8: Expected O, but got Ref
		//IL_0132: Expected O, but got Ref
		//IL_04c1: Expected O, but got I4
		//IL_0471: Expected O, but got I4
		//IL_02db: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e0: Expected Ref, but got Unknown
		//IL_02f7: Expected I8, but got I4
		//IL_0300: Unknown result type (might be due to invalid IL or missing references)
		//IL_0305: Expected Ref, but got Unknown
		//IL_04e3: Expected O, but got I4
		//IL_053c: Expected O, but got I4
		//IL_0726->IL0782: Incompatible stack heights: 1 vs 0
		//IL_06ef->IL0782: Incompatible stack heights: 3 vs 0
		Rect ret = default(Rect);
		bool flag3;
		bool flag7;
		if ((object)this != null && ((UnityEngine.Object)this).m_CachedPtr != (IntPtr)0)
		{
			if (type == CharacterType.VOID)
			{
				return;
			}
			Dictionary<CharacterType, List<CharacterData>> convertedCharacterData = _dataManager.GetConvertedCharacterData();
			object obj = ((Dictionary<System.Int32Enum, object>)(object)convertedCharacterData).get_Item((System.Int32Enum)type);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v440 @ rax_v18 (System.Object)+18]");
			bool flag = (nint)0 <= (nint)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v440 @ rax_v18 (System.Object)+10]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v441 @ rax_v21+20]");
			_data = (CharacterData)0;
			if (_data != null)
			{
				CharacterData data = _data;
				if (data._003CcharName_003Ek__BackingField != null)
				{
					SetName(data._003CcharName_003Ek__BackingField);
				}
				else
				{
					string text = ((Enum)(&ret)).ToString();
					string message = "charName for character type " + text + " is null!";
					Debug.LogError(message);
				}
				string firstNameLocKey = _data.GetFirstNameLocKey(type);
				bool applyParameters = default(bool);
				GameObject localParametersRoot = default(GameObject);
				string overrideLanguage = default(string);
				bool allowLocalizedParameters = default(bool);
				string translation = LocalizationManager.GetTranslation(firstNameLocKey, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18634B7A0");
				string text2 = _CharacterName.text;
				bool flag2 = text2 == null;
				flag3 = true;
				if (!flag2)
				{
					bool flag4 = text2._stringLength <= 0;
					flag3 = true;
					if (!flag4)
					{
						string text3 = _CharacterName.text;
						bool flag5 = (object)text3 == firstNameLocKey;
						flag3 = true;
						if (!flag5)
						{
							bool flag6 = text3 == null;
							flag7 = true;
							if (!flag6)
							{
								bool flag8 = firstNameLocKey == null;
								flag7 = true;
								if (!flag8)
								{
									bool flag9 = text3._stringLength != firstNameLocKey._stringLength;
									flag7 = true;
									if (!flag9)
									{
										ref byte second = ref *(byte*)(firstNameLocKey + 20);
										ulong length = (ulong)(text3._stringLength + text3._stringLength);
										bool flag10 = System.SpanHelpers.SequenceEqual(ref *(byte*)(text3 + 20), ref second, length);
										bool flag11 = !flag10;
										flag3 = false;
										flag7 = false;
										if (!flag11)
										{
											goto IL_0345;
										}
									}
								}
							}
							goto IL_036b;
						}
					}
				}
				goto IL_0345;
			}
			string text4 = ((Enum)(&ret)).ToString();
			string message2 = "No data found for character type " + text4;
			Debug.LogError(message2);
			return;
		}
		string text5 = ((Enum)(&ret)).ToString();
		string message3 = "OnlineMPPlayerItem SetData called with " + text5 + " when the object is null - ignoring";
		Debug.LogWarning(message3);
		return;
		IL_05f7:
		Skin skinForCharacter;
		string spriteName = skinForCharacter._003CspriteName_003Ek__BackingField;
		string textureName = skinForCharacter._003CtextureName_003Ek__BackingField;
		goto IL_0616;
		IL_0616:
		Sprite sprite = SpriteManager.GetSprite(spriteName, textureName);
		_CharacterIcon.sprite = sprite;
		RectTransform rectTransform = _CharacterIcon.rectTransform;
		bool flag12 = ((UnityEngine.Object)sprite).m_CachedPtr == (IntPtr)0;
		Sprite.get_rect_Injected(((UnityEngine.Object)sprite).m_CachedPtr, out Rect _);
		bool flag13 = ((UnityEngine.Object)sprite).m_CachedPtr == (IntPtr)0;
		Sprite.get_rect_Injected(((UnityEngine.Object)sprite).m_CachedPtr, out ret);
		Vector2 sizeDelta = default(Vector2);
		rectTransform.sizeDelta = sizeDelta;
		_CharacterSelectedGroup.SetActive(value: true);
		Transform transform = _PlayerName.transform;
		Transform parent = transform.parent;
		GameObject gameObject = parent.gameObject;
		gameObject.SetActive(value: true);
		_PlayerNotConnected.SetActive(value: false);
		return;
		IL_036b:
		if (type == CharacterType.ARENGIJUS)
		{
			CharacterData data2 = _data;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18634B7A0");
		}
		PlayerInfo onlinePlayerInfo = _onlinePlayerInfo;
		skinForCharacter = _playerOptions.GetSkinForCharacter(type, onlinePlayerInfo._skinType);
		PlayerInfo onlinePlayerInfo2 = _onlinePlayerInfo;
		CharacterData data3 = _data;
		data3._003CcurrentSkin_003Ek__BackingField = onlinePlayerInfo2._skinType;
		Sprite sprite2 = SpriteManager.GetSprite(skinForCharacter._003CspriteName_003Ek__BackingField, skinForCharacter._003CtextureName_003Ek__BackingField);
		SetWeaponIconSprite(_data, skinForCharacter);
		object obj3;
		if (skinForCharacter._003CcharSelFrame_003Ek__BackingField == null)
		{
			obj3 = 0;
		}
		else
		{
			bool flag14 = (nint)skinForCharacter._003CcharSelTexture_003Ek__BackingField < 0;
			bool flag15 = skinForCharacter._003CcharSelTexture_003Ek__BackingField == null;
			bool flag16 = !flag14;
			bool flag17 = !flag15;
			obj3 = flag17 & flag16;
		}
		CharacterData data4 = _data;
		bool flag18 = data4._003CcharSelFrame_003Ek__BackingField == null;
		object obj4 = 0;
		if (!flag18)
		{
			bool flag19 = (nint)data4._003CcharSelTexture_003Ek__BackingField < 0;
			flag18 = data4._003CcharSelTexture_003Ek__BackingField == null;
			bool flag20 = !flag19;
			bool flag21 = !flag18;
			obj4 = flag21 & flag20;
		}
		if (flag18)
		{
			goto IL_05f7;
		}
		if (obj3 != null)
		{
			spriteName = skinForCharacter._003CcharSelFrame_003Ek__BackingField;
			textureName = skinForCharacter._003CcharSelTexture_003Ek__BackingField;
		}
		else
		{
			if (skinForCharacter.skinType != SkinType.DEFAULT || obj4 == null)
			{
				goto IL_05f7;
			}
			CharacterData data5 = _data;
			CharacterData data6 = _data;
			spriteName = data5._003CcharSelFrame_003Ek__BackingField;
			textureName = data6._003CcharSelTexture_003Ek__BackingField;
		}
		goto IL_0616;
		IL_0345:
		CharacterData data7 = _data;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18634B7A0");
		flag7 = flag3;
		goto IL_036b;
	}

	private unsafe void SetWeaponIconSprite(CharacterData characterData, Skin skinData)
	{
		//IL_0147: Expected I4, but got O
		//IL_00bf: Expected O, but got I
		//IL_00d4: Expected O, but got I
		//IL_01b3: Expected O, but got Ref
		//IL_032b: Expected O, but got I
		//IL_032b: Expected O, but got I
		//IL_025b: Expected O, but got I
		//IL_0270: Expected O, but got I
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
		goto IL_038f;
		IL_038f:
		System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
		return;
		IL_0367:
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		goto IL_038f;
		IL_005d:
		Dictionary<WeaponType, List<WeaponData>> convertedWeapons = _dataManager.GetConvertedWeapons();
		object obj = ((Dictionary<System.Int32Enum, object>)(object)convertedWeapons).get_Item(int32Enum);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v111 @ rax_v11 (System.Object)+18]");
		if ((nint)0 > (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v111 @ rax_v11 (System.Object)+10]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rbx_v7+20]");
			object obj3 = 0;
			Skin skin = characterData.GetCurrentSkinData();
			if (skin != null)
			{
				skin = (Skin)skin._003CstartingWeapon_003Ek__BackingField;
			}
			if (skin != null)
			{
				IntPtr intPtr = default(IntPtr);
				string text = ((Enum)(&intPtr)).ToString();
				if (text != null && text._stringLength > 0)
				{
					Dictionary<WeaponType, List<WeaponData>> convertedWeapons2 = _dataManager.GetConvertedWeapons();
					System.Int32Enum key = default(System.Int32Enum);
					object obj4 = ((Dictionary<System.Int32Enum, object>)(object)convertedWeapons2).get_Item(key);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ rax_v25 (System.Object)+18]");
					if ((nint)0 <= (nint)0)
					{
						goto IL_0367;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ rax_v25 (System.Object)+10]");
					object obj5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v154 @ rbx_v12+20]");
					obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v154 @ rbx_v12+20]");
					if ((nint)0 == 0)
					{
						Dictionary<WeaponType, List<WeaponData>> convertedWeapons3 = _dataManager.GetConvertedWeapons();
						object obj6 = ((Dictionary<System.Int32Enum, object>)(object)convertedWeapons3).get_Item((System.Int32Enum)3);
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
						object obj7 = default(object);
						obj3 = obj7;
					}
				}
			}
			_WeaponIcon.enabled = true;
			_WeaponShadow.enabled = true;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ rbx_v9+40]");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ rbx_v9+38]");
			Sprite sprite = SpriteManager.GetSprite((string)num, (string)0);
			_WeaponIcon.sprite = sprite;
			Image weaponIcon = _WeaponIcon;
			_WeaponShadow.sprite = weaponIcon.m_Sprite;
			return;
		}
		goto IL_0367;
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

	public OnlineMPPlayerItem()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}

	private void _003CAwake_003Eb__25_0()
	{
		Action onAiSettingsButtonClicked = this.m_OnAiSettingsButtonClicked;
		if (this.m_OnAiSettingsButtonClicked != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v0.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}
}
