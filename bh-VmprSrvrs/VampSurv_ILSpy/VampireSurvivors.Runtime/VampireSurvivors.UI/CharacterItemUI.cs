using System;
using System.Collections;
using System.Collections.Generic;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.App.Scripts.Framework.Adventures;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects;

namespace VampireSurvivors.UI;

public class CharacterItemUI : SelectableUI
{
	private sealed class _003CWaitAndSelect_003Ed__24(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public CharacterItemUI _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0369: Expected I4, but got I8
			//IL_0015: Expected O, but got I4
			//IL_0186: Expected I4, but got I8
			//IL_0394: Expected I4, but got O
			//IL_0052: Expected I4, but got I8
			//IL_00ae: Expected I, but got O
			//IL_00b6: Expected I, but got O
			//IL_00c6: Expected O, but got I
			//IL_0146: Expected O, but got I4
			//IL_0102: Expected O, but got I
			//IL_0138: Expected O, but got I4
			CharacterItemUI characterItemUI = _003C_003E4__this;
			bool flag = _003C_003E1__state == 0;
			object obj4;
			if (!flag)
			{
				object obj = _003C_003E1__state - 1;
				if (!flag)
				{
					if ((nint)obj == 1)
					{
						_003C_003E1__state = -1;
						if ((object)_003C_003E4__this == null)
						{
							goto IL_0386;
						}
						ICharacterSelector page = characterItemUI._page;
						if (characterItemUI._page != null)
						{
							nint num = (nint)typeof(CharacterSelectionPage);
							nint num2 = (nint)page;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ r8_v16 (Il2CppClass<VampireSurvivors.UI.CharacterSelectionPage>)+130]");
							object obj2 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ r9_v2 (Il2CppClass<VampireSurvivors.ICharacterSelector>)+130]");
							nint num3 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ r8_v16 (Il2CppClass<VampireSurvivors.UI.CharacterSelectionPage>)+130]");
							if (num3 >= 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ r9_v2 (Il2CppClass<VampireSurvivors.ICharacterSelector>)+C8]");
								object obj3 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v353 @ rax_v43+FFFFFFF8+v339 @ rax_v36*8]");
								if (0 == (nint)typeof(CharacterSelectionPage))
								{
									obj4 = 1;
									goto IL_03bd;
								}
							}
							obj4 = 0;
							goto IL_03bd;
						}
					}
					goto IL_0171;
				}
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this != null && (object)characterItemUI._CharacterName != null)
				{
					GameObject gameObject = characterItemUI._CharacterName.gameObject;
					if ((object)gameObject != null)
					{
						gameObject.SetActive(value: false);
						if ((object)characterItemUI._CharacterName != null)
						{
							GameObject gameObject2 = characterItemUI._CharacterName.gameObject;
							if ((object)gameObject2 != null)
							{
								gameObject2.SetActive(value: true);
								TextMeshProUGUI characterName = characterItemUI._CharacterName;
								if ((object)characterItemUI._CharacterName != null)
								{
									if (((MaskableGraphic)characterName).m_Maskable)
									{
										((MaskableGraphic)characterName).m_Maskable = false;
										((MaskableGraphic)characterName).m_ShouldRecalculateStencil = true;
										characterItemUI._CharacterName.SetMaterialDirty();
									}
									TextMeshProUGUI characterName2 = characterItemUI._CharacterName;
									if ((object)characterItemUI._CharacterName != null)
									{
										if (!((MaskableGraphic)characterName2).m_Maskable)
										{
											((MaskableGraphic)characterName2).m_Maskable = true;
											((MaskableGraphic)characterName2).m_ShouldRecalculateStencil = true;
											characterItemUI._CharacterName.SetMaterialDirty();
										}
										Selectable component = _003C_003E4__this.GetComponent<Selectable>();
										if ((object)component != null)
										{
											component.Select();
											_003C_003E2__current = null;
											_003C_003E1__state = 2;
											return true;
										}
									}
								}
							}
						}
					}
				}
				goto IL_0386;
			}
			_003C_003E1__state = -1;
			_003C_003E2__current = null;
			_003C_003E1__state = 1;
			return true;
			IL_0386:
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
			IL_0171:
			return false;
			IL_03bd:
			bool flag2 = obj4 == null;
			CharacterSelectionPage characterSelectionPage = null;
			if (!flag2)
			{
				characterSelectionPage = (CharacterSelectionPage)characterItemUI._page;
			}
			characterSelectionPage?.SpawnDoilie(_003C_003E4__this);
			goto IL_0171;
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

	private TextMeshProUGUI _CharacterName;

	private Image _CharacterIcon;

	private Image _WeaponIcon;

	private Image _ShadowIcon;

	private Image _LockIcon;

	private Image _Background;

	private Image _Flash;

	private ICharacterSelector _page;

	private UIUnlockStates? _forcedUnlockState;

	private bool _isTaken;

	private bool _voidWeapon;

	private DataManager _dataManager;

	private PlayerOptions _playerOptions;

	private Color _highlightColor;

	private readonly float _iconUIScale;

	private CharacterItem _charItem;

	private Color _backgroundColor;

	public CharacterItem CharacterItem => _charItem;

	public CharacterType Type
	{
		get
		{
			//IL_0041: Expected I4, but got O
			CharacterItem charItem = _charItem;
			if (_charItem != null)
			{
				return charItem._characterType;
			}
			NullReferenceException ex = new NullReferenceException();
			return (CharacterType)ex;
		}
	}

	public unsafe void SetData(ICharacterSelector page, DataManager dataManager, PlayerOptions playerOptions, CharacterItem charItem, bool useDefaultSkin = false)
	{
		//IL_014d: Expected O, but got Ref
		//IL_00f7: Expected O, but got I
		//IL_0109: Expected O, but got I4
		_dataManager = dataManager;
		_playerOptions = playerOptions;
		_page = page;
		CharacterItem charItem2 = default(CharacterItem);
		_charItem = charItem2;
		object obj = default(object);
		bool flag = obj == null;
		_isTaken = false;
		if (!flag)
		{
			PlayerOptionsData config = _playerOptions.Config;
			CharacterItem charItem3 = _charItem;
			bool flag2 = ((Dictionary<System.Int32Enum, System.Int32Enum>)(object)config._003CSelectedSkinsV2_003Ek__BackingField).TryInsert((System.Int32Enum)charItem3._characterType, (System.Int32Enum)0, System.Collections.Generic.InsertionBehavior.OverwriteExisting);
		}
		PlayerOptionsData config2 = _playerOptions.Config;
		CharacterItem charItem4 = _charItem;
		Dictionary<CharacterType, SkinType> dictionary = config2._003CSelectedSkinsV2_003Ek__BackingField;
		int num = config2._003CSelectedSkinsV2_003Ek__BackingField.FindEntry(charItem4._characterType);
		if (num >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v422 @ rdi_v4 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.CharacterType, VampireSurvivors.Data.SkinType>)+18]");
			object obj2 = 0;
			object obj3 = num + num;
			CharacterItem charItem5 = _charItem;
			CharacterData characterData = charItem5._characterData;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v413 @ rcx_v18+2C+v631 @ rax_v20*8]");
			characterData._003CcurrentSkin_003Ek__BackingField = SkinType.DEFAULT;
		}
		GameObject gameObject = base.gameObject;
		IntPtr intPtr = default(IntPtr);
		string text = ((Enum)(&intPtr)).ToString();
		((UnityEngine.Object)gameObject).SetName(text);
	}

	public void Refresh(bool setInfoPanel = true)
	{
		//IL_0020: Expected I4, but got O
		//IL_0054: Expected O, but got I4
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Expected O, but got Unknown
		_charItem.RefreshUnlockState();
		UIUnlockStates uIUnlockStates;
		if ((object)_forcedUnlockState != null)
		{
			uIUnlockStates = (UIUnlockStates)((object?)_forcedUnlockState >> 32);
		}
		else
		{
			CharacterItem charItem = _charItem;
			uIUnlockStates = charItem._unlockState;
		}
		bool flag = uIUnlockStates == UIUnlockStates.UNAVAILABLE;
		if (!flag)
		{
			object obj = uIUnlockStates - 1;
			if (!flag)
			{
				object obj2 = obj - 1;
				if (!flag)
				{
					if ((nint)obj2 == 1)
					{
						SetVisualStateAvailable();
					}
				}
				else
				{
					SetVisualStatePurchasable();
				}
			}
			else
			{
				SetVisualStateUnlockable();
			}
		}
		if (setInfoPanel)
		{
			SetInfoPanel();
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A30AB]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		CharacterItem charItem2 = _charItem;
		if (charItem2._unlockState != UIUnlockStates.UNLOCKABLE)
		{
			TextMeshProUGUI characterName = _CharacterName;
		}
		else
		{
			CharacterData characterData = charItem2._characterData;
			bool flag2 = !characterData._003Csecret_003Ek__BackingField;
			TextMeshProUGUI characterName = _CharacterName;
			if (!flag2)
			{
				string text = "???";
				goto IL_01d7;
			}
		}
		CharacterItem charItem3 = _charItem;
		if (charItem2._characterType == CharacterType.ARENGIJUS)
		{
			CharacterData characterData2 = charItem3._characterData;
			string text = characterData2._003CcharName_003Ek__BackingField;
		}
		else
		{
			string text = charItem3._characterData.GetCharFirstName(charItem3._characterType);
		}
		goto IL_01d7;
		IL_01d7:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18634B7A0");
		Sprite sprite;
		if (IsUnlockableAndSecret())
		{
			sprite = SpriteManager.GetSprite("QuestionMark", "UI");
		}
		else
		{
			CharacterItem charItem4 = _charItem;
			sprite = GetCharSprite(charItem4._characterType, charItem4._characterData);
		}
		_CharacterIcon.sprite = sprite;
		SetWeaponIconSprite();
		SetIconSizes();
	}

	public unsafe void AnimateIn()
	{
		//IL_03b6: Expected O, but got I8
		//IL_0141: Expected O, but got Ref
		//IL_0155: Expected O, but got Ref
		//IL_01d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01da: Expected O, but got Unknown
		//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f6: Expected O, but got Unknown
		//IL_020d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0212: Expected O, but got Unknown
		//IL_0432: Expected O, but got I4
		//IL_0442: Unknown result type (might be due to invalid IL or missing references)
		//IL_0447: Expected O, but got Unknown
		//IL_012d->IL02c2: Incompatible stack heights: 2 vs 0
		GameObject gameObject = base.gameObject;
		object obj;
		if ((object)gameObject != null)
		{
			Canvas canvas = gameObject.AddComponent<Canvas>();
			if ((object)canvas != null)
			{
				bool flag = ((UnityEngine.Object)canvas).m_CachedPtr != (IntPtr)0;
				obj = canvas;
				if (flag)
				{
					goto IL_006a;
				}
			}
			Canvas component = GetComponent<Canvas>();
			obj = component;
			goto IL_006a;
		}
		goto IL_02c2;
		IL_027f:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v798 @ rax_v43 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
		if ((nint)0 == 0)
		{
		}
		goto IL_0402;
		IL_02c2:
		throw new NullReferenceException();
		IL_0402:
		_003CWaitAndSelect_003Ed__24 obj2 = null;
		obj2._003C_003E1__state = 0;
		obj2._003C_003E4__this = this;
		Coroutine coroutine = StartCoroutine(obj2);
		return;
		IL_006a:
		((Canvas)obj).overrideSorting = true;
		((Canvas)obj).sortingLayerName = "UI";
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rbx_v8 (System.Object)+10]");
		bool flag2 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rbx_v8 (System.Object)+10]");
		Canvas.set_sortingOrder_Injected((IntPtr)0, 9999);
		GameObject gameObject2 = base.gameObject;
		GraphicRaycaster graphicRaycaster = gameObject2.AddComponent<GraphicRaycaster>();
		Transform transform = base.transform;
		bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
		Transform target = base.transform;
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(target, 1f, 0.3f);
		object obj3 = 6603577472L;
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v707 @ rax_v37 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 9;
				_ = 0;
			}
		}
		GameObject gameObject3 = _Flash.gameObject;
		gameObject3.SetActive(value: true);
		if ((object)_Flash == null)
		{
			goto IL_02c2;
		}
		object obj4 = default(object);
		_Flash.color = (Color)(&obj4);
		TweenerCore<Color, Color, ColorOptions> tweenerCore2 = DOTweenModuleUI.DOColor(_Flash, (Color)(&obj4), 0.3f);
		TweenCallback tweenCallback2;
		if (tweenerCore2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v798 @ rax_v43 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 9;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
				bool flag4 = (nint)0 == 0;
				_ = 0;
				if (!flag4)
				{
					object obj5 = tweenerCore2 + 184;
					object obj6 = obj5 >> 12;
					object obj7 = obj6 & 0x1FFFFF;
					object obj8 = obj7 >> 6;
					object obj9 = obj7 & 0x3F;
					nint num2;
					do
					{
						object obj10 = 1 << (int)obj9;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rbp_v7+462E0+v851 @ rdx_v37*8]");
						object obj11 = 0 | obj10;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rbp_v7+462E0+v851 @ rdx_v37*8]");
						nint num = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rbp_v7+462E0+v851 @ rdx_v37*8]");
						if (num == 0)
						{
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rbp_v7+462E0+v851 @ rdx_v37*8]");
						num2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rbp_v7+462E0+v851 @ rdx_v37*8]");
					}
					while (num2 != 0);
					TweenCallback tweenCallback = delegate
					{
						GameObject gameObject4 = _Flash.gameObject;
						gameObject4.SetActive(value: false);
						Canvas component2 = GetComponent<Canvas>();
						component2.overrideSorting = false;
					};
					tweenCallback2 = tweenCallback;
					goto IL_027f;
				}
			}
		}
		TweenCallback tweenCallback3 = delegate
		{
			GameObject gameObject4 = _Flash.gameObject;
			gameObject4.SetActive(value: false);
			Canvas component2 = GetComponent<Canvas>();
			component2.overrideSorting = false;
		};
		bool flag5 = tweenerCore2 == null;
		tweenCallback2 = tweenCallback3;
		if (!flag5)
		{
			goto IL_027f;
		}
		goto IL_0402;
	}

	private IEnumerator WaitAndSelect()
	{
		_003CWaitAndSelect_003Ed__24 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	public unsafe void SetTakenByAnotherPlayer(bool taken, Color highlightColor)
	{
		//IL_0019: Expected O, but got F4
		//IL_005d: Expected O, but got Ref
		_isTaken = taken;
		_highlightColor = (Color)highlightColor.r;
		object obj = default(object);
		if (taken)
		{
			Color color = _Background.color;
			object obj2 = default(object);
			obj = obj2;
		}
		_Background.color = (Color)(&obj);
		Sprite backgroundSprite = GetBackgroundSprite();
		_Background.sprite = backgroundSprite;
	}

	public bool IsTakenByAnotherPlayer()
	{
		return _isTaken;
	}

	public unsafe void SetSelected()
	{
		//IL_001e: Expected O, but got Ref
		Color color = _Background.color;
		object obj = default(object);
		_Background.color = (Color)(&obj);
	}

	public unsafe void UnSelect()
	{
		//IL_004a: Expected O, but got Ref
		object obj = default(object);
		if (_isTaken)
		{
			Color color = _Background.color;
			object obj2 = default(object);
			obj = obj2;
		}
		_Background.color = (Color)(&obj);
		Sprite backgroundSprite = GetBackgroundSprite();
		_Background.sprite = backgroundSprite;
	}

	private Sprite GetBackgroundSprite()
	{
		if (AdventureManager._003CIsInAdventureMode_003Ek__BackingField)
		{
			return SpriteManager.GetSprite("AdventurePanel");
		}
		return SpriteManager.GetSprite("frame1_c2");
	}

	public bool IsAvailable()
	{
		//IL_00ae: Expected I4, but got O
		//IL_0084: Expected O, but got I4
		bool flag = IsCharAvailable();
		if (!flag)
		{
			return flag;
		}
		if (_charItem != null)
		{
			SkinItem currentSkinItem = _charItem.GetCurrentSkinItem();
			bool flag2 = currentSkinItem == null;
			bool result = true;
			if (!flag2)
			{
				object obj = currentSkinItem._unlockState - 3;
				bool flag3 = obj == null;
				result = flag3;
			}
			return result;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public bool IsCharAvailable()
	{
		//IL_007f: Expected I4, but got O
		//IL_0015: Expected I4, but got O
		UIUnlockStates uIUnlockStates;
		if ((object)_forcedUnlockState != null)
		{
			uIUnlockStates = (UIUnlockStates)((object?)_forcedUnlockState >> 32);
		}
		else
		{
			CharacterItem charItem = _charItem;
			if (_charItem == null)
			{
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			uIUnlockStates = charItem._unlockState;
		}
		if (uIUnlockStates != UIUnlockStates.AVAILABLE)
		{
			return false;
		}
		return !_isTaken;
	}

	public bool IsSkinAvailable()
	{
		//IL_0091: Expected I4, but got O
		//IL_0067: Expected O, but got I4
		if (_charItem != null)
		{
			SkinItem currentSkinItem = _charItem.GetCurrentSkinItem();
			bool flag = currentSkinItem == null;
			bool result = true;
			if (!flag)
			{
				object obj = currentSkinItem._unlockState - 3;
				bool flag2 = obj == null;
				result = flag2;
			}
			return result;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public bool IsPurchasable()
	{
		//IL_00d7: Expected I4, but got O
		//IL_00ad: Expected O, but got I4
		if (IsCharPurchasable())
		{
			return true;
		}
		bool flag = IsCharAvailable();
		if (!flag)
		{
			return flag;
		}
		if (_charItem != null)
		{
			SkinItem currentSkinItem = _charItem.GetCurrentSkinItem();
			bool flag2 = currentSkinItem == null;
			bool result = false;
			if (!flag2)
			{
				object obj = currentSkinItem._unlockState - 2;
				bool flag3 = obj == null;
				result = flag3;
			}
			return result;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public bool IsCharPurchasable()
	{
		//IL_007f: Expected I4, but got O
		//IL_0015: Expected I4, but got O
		UIUnlockStates uIUnlockStates;
		if ((object)_forcedUnlockState != null)
		{
			uIUnlockStates = (UIUnlockStates)((object?)_forcedUnlockState >> 32);
		}
		else
		{
			CharacterItem charItem = _charItem;
			if (_charItem == null)
			{
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			uIUnlockStates = charItem._unlockState;
		}
		if (uIUnlockStates != UIUnlockStates.PURCHASABLE)
		{
			return false;
		}
		return !_isTaken;
	}

	public bool IsSkinPurchasable()
	{
		//IL_0091: Expected I4, but got O
		//IL_0067: Expected O, but got I4
		if (_charItem != null)
		{
			SkinItem currentSkinItem = _charItem.GetCurrentSkinItem();
			bool flag = currentSkinItem == null;
			bool result = false;
			if (!flag)
			{
				object obj = currentSkinItem._unlockState - 2;
				bool flag2 = obj == null;
				result = flag2;
			}
			return result;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public bool IsUnlockable()
	{
		//IL_00d7: Expected I4, but got O
		//IL_00ad: Expected O, but got I4
		if (IsCharUnlockable())
		{
			return true;
		}
		bool flag = IsCharAvailable();
		if (!flag)
		{
			return flag;
		}
		if (_charItem != null)
		{
			SkinItem currentSkinItem = _charItem.GetCurrentSkinItem();
			bool flag2 = currentSkinItem == null;
			bool result = false;
			if (!flag2)
			{
				object obj = currentSkinItem._unlockState - 1;
				bool flag3 = obj == null;
				result = flag3;
			}
			return result;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public bool IsCharUnlockable()
	{
		//IL_007f: Expected I4, but got O
		//IL_0015: Expected I4, but got O
		UIUnlockStates uIUnlockStates;
		if ((object)_forcedUnlockState != null)
		{
			uIUnlockStates = (UIUnlockStates)((object?)_forcedUnlockState >> 32);
		}
		else
		{
			CharacterItem charItem = _charItem;
			if (_charItem == null)
			{
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			uIUnlockStates = charItem._unlockState;
		}
		if (uIUnlockStates != UIUnlockStates.UNLOCKABLE)
		{
			return false;
		}
		return !_isTaken;
	}

	public bool IsSkinUnlockable()
	{
		//IL_0091: Expected I4, but got O
		//IL_0067: Expected O, but got I4
		if (_charItem != null)
		{
			SkinItem currentSkinItem = _charItem.GetCurrentSkinItem();
			bool flag = currentSkinItem == null;
			bool result = false;
			if (!flag)
			{
				object obj = currentSkinItem._unlockState - 1;
				bool flag2 = obj == null;
				result = flag2;
			}
			return result;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public float GetPrice()
	{
		//IL_01c6: Invalid comparison between F4 and I
		//IL_00ad: Invalid comparison between F4 and I4
		//IL_0182: Expected F4, but got I
		CharacterItem charItem = _charItem;
		if (_charItem != null)
		{
			if (charItem._unlockState == UIUnlockStates.AVAILABLE)
			{
				if (charItem._characterData == null)
				{
					goto IL_0187;
				}
				Skin currentSkinData = charItem._characterData.GetCurrentSkinData();
				if (currentSkinData != null)
				{
					bool flag = currentSkinData._003Cprice_003Ek__BackingField == 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186C86E0Bh\"");
					if (!flag)
					{
						return currentSkinData._003Cprice_003Ek__BackingField;
					}
				}
			}
			CharacterItem charItem2 = _charItem;
			if (_charItem != null)
			{
				float num;
				if (charItem2._characterType == CharacterType.ANTONIO)
				{
					num = 10f;
				}
				else
				{
					CharacterData characterData = charItem2._characterData;
					if (charItem2._characterData == null)
					{
						goto IL_0187;
					}
					num = characterData._003Cprice_003Ek__BackingField;
				}
				float num2 = CharMarkup();
				float num3 = num2 * num;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E0DC");
				float num4 = num3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A112E0]");
				if (num4 > 0f)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A112E0]");
					num3 = 0f;
				}
				return num3;
			}
		}
		goto IL_0187;
		IL_0187:
		throw new NullReferenceException();
	}

	private float CharMarkup()
	{
		//IL_0027: Expected O, but got I4
		//IL_01c4: Expected F4, but got O
		//IL_01ee: Expected F4, but got O
		//IL_0144: Expected F4, but got O
		//IL_0092: Expected O, but got I
		//IL_0165: Expected O, but got I4
		//IL_0192: Expected F4, but got O
		//IL_0205: Unknown result type (might be due to invalid IL or missing references)
		//IL_020a: Expected O, but got Unknown
		//IL_0218: Unknown result type (might be due to invalid IL or missing references)
		//IL_021d: Expected O, but got Unknown
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Expected O, but got Unknown
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Expected O, but got Unknown
		PlayerOptionsData config = _playerOptions.Config;
		object obj = 0;
		object obj3 = default(object);
		object obj2 = obj3;
		object obj4 = default(object);
		object obj5 = default(object);
		float num;
		while (true)
		{
			bool flag = obj4 == null;
			num = (float)config._003CBoughtCharacters_003Ek__BackingField;
			if (!flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ stack_-28_v7+1C]");
				if (obj5 == null)
				{
					object obj6 = obj2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ stack_-28_v7+18]");
					if ((nint)obj6 < 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ stack_-28_v7+10]");
						object obj7 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ stack_-28_v7+10]");
						bool flag2 = (nint)0 == 0;
						List<CharacterType> list = config._003CBoughtCharacters_003Ek__BackingField;
						if (!flag2)
						{
							object obj8 = obj2;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v129 @ rax_v32+18]");
							bool flag3 = (nint)obj8 >= 0;
							list = config._003CBoughtCharacters_003Ek__BackingField;
							if (!flag3)
							{
								obj2++;
								obj++;
								continue;
							}
							throw new IndexOutOfRangeException();
						}
						num = (float)list;
						throw new NullReferenceException();
					}
					break;
				}
				break;
			}
			throw new NullReferenceException();
		}
		bool flag4 = obj4 == null;
		num = (float)config._003CBoughtCharacters_003Ek__BackingField;
		if (!flag4)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ stack_-28_v7+1C]");
			bool flag5 = obj5 != null;
			num = (float)config._003CBoughtCharacters_003Ek__BackingField;
			if (!flag5)
			{
				object obj9 = obj - 1;
				object obj10 = obj9 * GameManager.BaseMarkup;
				return (float)obj10 + 1f;
			}
			System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
			object obj11 = 0;
		}
		throw new NullReferenceException();
	}

	public void SetInfoPanel()
	{
		CharacterItem charItem = _charItem;
		_page.ShowCharacterInfo(charItem._characterData, charItem._characterType, this);
	}

	public bool HasForcedUnlockState()
	{
		//IL_003c: Expected I4, but got O
		//IL_0035: Expected I4, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A30A3]");
		if ((nint)0 == 0)
		{
			_ = 1;
			return (byte)(int)_forcedUnlockState != 0;
		}
		return (byte)(int)_forcedUnlockState != 0;
	}

	public void SetForcedUnlockState(UIUnlockStates? state)
	{
		_forcedUnlockState = state;
		Refresh(setInfoPanel: false);
	}

	public bool IsUnlockableAndSecret()
	{
		//IL_013e: Expected I4, but got O
		CharacterItem charItem = _charItem;
		if (_charItem != null)
		{
			bool result;
			if (charItem._unlockState != UIUnlockStates.UNLOCKABLE)
			{
				result = false;
			}
			else
			{
				CharacterData characterData = charItem._characterData;
				if (charItem._characterData == null)
				{
					goto IL_0130;
				}
				bool flag = !characterData._003Csecret_003Ek__BackingField;
				result = !flag;
			}
			SkinItem currentSkinItem = _charItem.GetCurrentSkinItem();
			if (currentSkinItem != null && currentSkinItem._unlockState == UIUnlockStates.UNLOCKABLE)
			{
				Skin skinData = currentSkinItem._skinData;
				if (currentSkinItem._skinData == null)
				{
					goto IL_0130;
				}
				if (skinData._003Csecret_003Ek__BackingField)
				{
					result = true;
				}
			}
			return result;
		}
		goto IL_0130;
		IL_0130:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public Sprite GetCharSprite(CharacterType charType, CharacterData charData)
	{
		//IL_006e: Expected O, but got I4
		//IL_00c7: Expected O, but got I4
		//IL_00e9: Expected O, but got I4
		//IL_0142: Expected O, but got I4
		if (_playerOptions != null)
		{
			SkinType skinTypeForCharacter = _playerOptions.GetSkinTypeForCharacter(charType);
			Skin skinForCharacter = _playerOptions.GetSkinForCharacter(charType, skinTypeForCharacter);
			if (skinForCharacter != null)
			{
				bool flag = skinForCharacter._003CcharSelFrame_003Ek__BackingField == null;
				object obj = 0;
				if (!flag)
				{
					bool flag2 = (nint)skinForCharacter._003CcharSelTexture_003Ek__BackingField < 0;
					bool flag3 = skinForCharacter._003CcharSelTexture_003Ek__BackingField == null;
					bool flag4 = !flag2;
					bool flag5 = !flag3;
					obj = flag5 & flag4;
				}
				if (charData != null)
				{
					bool flag6 = charData._003CcharSelFrame_003Ek__BackingField == null;
					object obj2 = 0;
					if (!flag6)
					{
						bool flag7 = (nint)charData._003CcharSelTexture_003Ek__BackingField < 0;
						bool flag8 = charData._003CcharSelTexture_003Ek__BackingField == null;
						bool flag9 = !flag7;
						bool flag10 = !flag8;
						obj2 = flag10 & flag9;
					}
					string spriteName;
					string textureName;
					if (obj != null)
					{
						spriteName = skinForCharacter._003CcharSelFrame_003Ek__BackingField;
						textureName = skinForCharacter._003CcharSelTexture_003Ek__BackingField;
					}
					else if (skinForCharacter.skinType == SkinType.DEFAULT && obj2 != null)
					{
						spriteName = charData._003CcharSelFrame_003Ek__BackingField;
						textureName = charData._003CcharSelTexture_003Ek__BackingField;
					}
					else
					{
						textureName = skinForCharacter._003CtextureName_003Ek__BackingField;
						spriteName = skinForCharacter._003CspriteName_003Ek__BackingField;
					}
					return SpriteManager.GetSprite(spriteName, textureName);
				}
			}
		}
		return (Sprite)(object)new NullReferenceException();
	}

	private void UpdateVisualState()
	{
		//IL_0015: Expected I4, but got O
		//IL_0049: Expected O, but got I4
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected O, but got Unknown
		UIUnlockStates uIUnlockStates;
		if ((object)_forcedUnlockState != null)
		{
			uIUnlockStates = (UIUnlockStates)((object?)_forcedUnlockState >> 32);
		}
		else
		{
			CharacterItem charItem = _charItem;
			uIUnlockStates = charItem._unlockState;
		}
		bool flag = uIUnlockStates == UIUnlockStates.UNAVAILABLE;
		if (flag)
		{
			return;
		}
		object obj = uIUnlockStates - 1;
		if (!flag)
		{
			object obj2 = obj - 1;
			if (!flag)
			{
				if ((nint)obj2 == 1)
				{
					SetVisualStateAvailable();
				}
			}
			else
			{
				SetVisualStatePurchasable();
			}
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 100 Invalid \"Jump target not found in method: 0x186C87450\"");
		throw new NullReferenceException();
	}

	private void SetVisualStateUnlockable()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected O, but got Unknown
		//IL_00b3: Expected O, but got F4
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Expected O, but got Unknown
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_0126: Expected O, but got Unknown
		//IL_0162: Unknown result type (might be due to invalid IL or missing references)
		//IL_0167: Expected O, but got Unknown
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a8: Expected O, but got Unknown
		//IL_01e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e9: Expected O, but got Unknown
		object obj = default(object);
		Color color = (Color)(obj - 64);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11F20]");
		_ = 0;
		_CharacterIcon.color = color;
		Color color2 = (Color)(obj - 64);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12170]");
		_ = 0;
		_CharacterName.color = color2;
		_ShadowIcon.enabled = false;
		Color color3 = ColourHelper.HexToColor("B6BCF2");
		bool flag = !_isTaken;
		float r = color3.r;
		_backgroundColor = (Color)color3.r;
		if (!flag)
		{
			Color color4 = _Background.color;
			float num = default(float);
			r = num;
		}
		Color color5 = (Color)(obj - 64);
		_Background.color = color5;
		Color color6 = _Background.color;
		Color color7 = (Color)(obj - 64);
		_ = 1065353216;
		_Background.color = color7;
		Color color8 = _WeaponIcon.color;
		Color color9 = (Color)(obj - 64);
		_ = 1051931443;
		_WeaponIcon.color = color9;
		Color color10 = _ShadowIcon.color;
		Color color11 = (Color)(obj - 64);
		_ = 1051931443;
		_ShadowIcon.color = color11;
		Color color12 = _CharacterIcon.color;
		Color color13 = (Color)(obj - 64);
		_ = 1051931443;
		_CharacterIcon.color = color13;
	}

	private unsafe void SetVisualStatePurchasable()
	{
		//IL_0015: Expected O, but got Ref
		//IL_0029: Expected O, but got Ref
		//IL_0061: Expected O, but got I
		//IL_009b: Expected F4, but got I
		//IL_00af: Expected O, but got Ref
		//IL_00d2: Expected O, but got Ref
		//IL_00f5: Expected O, but got Ref
		//IL_0118: Expected O, but got Ref
		//IL_013b: Expected O, but got Ref
		float num = default(float);
		_CharacterIcon.color = (Color)(&num);
		_CharacterName.color = (Color)(&num);
		_ShadowIcon.enabled = false;
		bool flag = !_isTaken;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
		_backgroundColor = (Color)0;
		if (!flag)
		{
			Color color = _Background.color;
			float num2 = default(float);
			num = num2;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12170]");
			num = 0f;
		}
		_Background.color = (Color)(&num);
		Color color2 = _Background.color;
		_Background.color = (Color)(&num);
		Color color3 = _WeaponIcon.color;
		_WeaponIcon.color = (Color)(&num);
		Color color4 = _ShadowIcon.color;
		_ShadowIcon.color = (Color)(&num);
		Color color5 = _CharacterIcon.color;
		_CharacterIcon.color = (Color)(&num);
	}

	private void SetVisualStateAvailable()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		//IL_0023: Expected O, but got I
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Expected O, but got Unknown
		//IL_00e5: Expected O, but got I
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Expected O, but got Unknown
		//IL_0153: Unknown result type (might be due to invalid IL or missing references)
		//IL_0158: Expected O, but got Unknown
		//IL_0194: Unknown result type (might be due to invalid IL or missing references)
		//IL_0199: Expected O, but got Unknown
		//IL_01d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01da: Expected O, but got Unknown
		//IL_0216: Unknown result type (might be due to invalid IL or missing references)
		//IL_021b: Expected O, but got Unknown
		//IL_0299: Unknown result type (might be due to invalid IL or missing references)
		//IL_029e: Expected O, but got Unknown
		//IL_03c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ca: Expected O, but got Unknown
		//IL_02ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f1: Expected O, but got Unknown
		//IL_032d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0332: Expected O, but got Unknown
		//IL_036e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0373: Expected O, but got Unknown
		object obj = default(object);
		Color color = (Color)(obj - 64);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
		Color color2 = (Color)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
		_ = 0;
		_CharacterIcon.color = color;
		Color color3 = (Color)(obj - 64);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
		_ = 0;
		_WeaponIcon.color = color3;
		bool flag = !_voidWeapon;
		_ShadowIcon.enabled = flag;
		Color color4 = (Color)(obj - 64);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
		_ = 0;
		_CharacterName.color = color4;
		bool flag2 = !_isTaken;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
		_backgroundColor = (Color)0;
		if (!flag2)
		{
			Color color5 = _Background.color;
			Color color6 = default(Color);
			color2 = color6;
		}
		Color color7 = (Color)(obj - 64);
		_Background.color = color7;
		Color color8 = _Background.color;
		Color color9 = (Color)(obj - 64);
		_ = 1065353216;
		_Background.color = color9;
		Color color10 = _WeaponIcon.color;
		Color color11 = (Color)(obj - 64);
		_ = 1065353216;
		_WeaponIcon.color = color11;
		Color color12 = _ShadowIcon.color;
		Color color13 = (Color)(obj - 64);
		_ = 1065353216;
		_ShadowIcon.color = color13;
		Color color14 = _CharacterIcon.color;
		Color color15 = (Color)(obj - 64);
		_ = 1065353216;
		_CharacterIcon.color = color15;
		SkinItem currentSkinItem = _charItem.GetCurrentSkinItem();
		if (currentSkinItem != null)
		{
			if (currentSkinItem._unlockState == UIUnlockStates.UNLOCKABLE)
			{
				Color color16 = (Color)(obj - 64);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11F20]");
				_ = 0;
				_CharacterIcon.color = color16;
				_ShadowIcon.enabled = false;
				Color color17 = _WeaponIcon.color;
				Color color18 = (Color)(obj - 64);
				_ = 1051931443;
				_WeaponIcon.color = color18;
				Color color19 = _ShadowIcon.color;
				Color color20 = (Color)(obj - 64);
				_ = 1051931443;
				_ShadowIcon.color = color20;
				Color color21 = _CharacterIcon.color;
				Color color22 = (Color)(obj - 64);
				_ = 1051931443;
				_CharacterIcon.color = color22;
			}
			else if (currentSkinItem._unlockState == UIUnlockStates.PURCHASABLE)
			{
				Color color23 = (Color)(obj - 64);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11F20]");
				_ = 0;
				_CharacterIcon.color = color23;
				_ShadowIcon.enabled = false;
				RenderingExtensions.SetAlpha(_WeaponIcon, 1f);
				RenderingExtensions.SetAlpha(_ShadowIcon, 1f);
				RenderingExtensions.SetAlpha(_CharacterIcon, 1f);
			}
		}
	}

	private unsafe void SetIconSizes()
	{
		//IL_00b2: Expected O, but got I
		//IL_0625: Unknown result type (might be due to invalid IL or missing references)
		//IL_062a: Expected O, but got Unknown
		//IL_039d: Expected O, but got I
		//IL_00f1: Expected O, but got I
		//IL_0800: Unknown result type (might be due to invalid IL or missing references)
		//IL_0805: Expected O, but got Unknown
		//IL_0698: Unknown result type (might be due to invalid IL or missing references)
		//IL_069d: Expected O, but got Unknown
		//IL_04f4: Expected O, but got I
		//IL_03dc: Expected O, but got I
		//IL_0166: Expected O, but got I
		//IL_0902: Unknown result type (might be due to invalid IL or missing references)
		//IL_0907: Expected O, but got Unknown
		//IL_0873: Unknown result type (might be due to invalid IL or missing references)
		//IL_0878: Expected O, but got Unknown
		//IL_0533: Expected O, but got I
		//IL_0975: Unknown result type (might be due to invalid IL or missing references)
		//IL_097a: Expected O, but got Unknown
		//IL_072e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0733: Expected O, but got Unknown
		//IL_078b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0790: Expected O, but got Unknown
		//IL_0663->IL0575: Incompatible stack heights: 1 vs 0
		//IL_0111->IL0575: Incompatible stack heights: 1 vs 0
		//IL_083e->IL0575: Incompatible stack heights: 1 vs 0
		//IL_06cb->IL0575: Incompatible stack heights: 2 vs 0
		//IL_03fc->IL0575: Incompatible stack heights: 1 vs 0
		//IL_0151->IL0575: Incompatible stack heights: 2 vs 0
		//IL_0940->IL0575: Incompatible stack heights: 1 vs 0
		//IL_08a6->IL0575: Incompatible stack heights: 2 vs 0
		//IL_06f6->IL05cc: Incompatible stack heights: 2 vs 0
		//IL_0553->IL0575: Incompatible stack heights: 1 vs 0
		//IL_041e->IL041e: Incompatible stack heights: 2 vs 0
		//IL_019b->IL05cc: Incompatible stack heights: 2 vs 0
		//IL_01ba->IL0575: Incompatible stack heights: 2 vs 0
		//IL_09a7->IL0575: Incompatible stack heights: 2 vs 0
		//IL_01e6->IL0575: Incompatible stack heights: 2 vs 0
		//IL_0574->IL0574: Incompatible stack heights: 2 vs 0
		//IL_075f->IL0575: Incompatible stack heights: 3 vs 0
		//IL_021c->IL0575: Incompatible stack heights: 3 vs 0
		//IL_024d->IL0575: Incompatible stack heights: 3 vs 0
		//IL_0279->IL0575: Incompatible stack heights: 3 vs 0
		//IL_02aa->IL0575: Incompatible stack heights: 3 vs 0
		//IL_07a9->IL05cc: Incompatible stack heights: 5 vs 0
		Image characterIcon = _CharacterIcon;
		if ((object)_CharacterIcon == null)
		{
			goto IL_0575;
		}
		object sprite = characterIcon.m_Sprite;
		object obj3 = default(object);
		Vector2 sizeDelta = default(Vector2);
		if ((object)characterIcon.m_Sprite != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ rdi_v19 (System.Object)+10]");
			if ((nint)0 != 0)
			{
				if ((object)_CharacterIcon != null)
				{
					RectTransform rectTransform = _CharacterIcon.rectTransform;
					object characterIcon2 = _CharacterIcon;
					if ((object)_CharacterIcon != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ rdi_v34 (System.Object)+E0]");
						object obj = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ rdi_v34 (System.Object)+E0]");
						if ((nint)0 != 0)
						{
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ rdi_v35 (System.Object)+10]");
							bool flag = (nint)0 == 0;
							object obj2 = obj3 - 56;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ rdi_v35 (System.Object)+10]");
							Sprite.get_rect_Injected((IntPtr)0, out *(Rect*)obj2);
							object characterIcon3 = _CharacterIcon;
							if ((object)_CharacterIcon != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ rdi_v36 (System.Object)+E0]");
								object obj4 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ rdi_v36 (System.Object)+E0]");
								if ((nint)0 != 0)
								{
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v154 @ rdi_v37 (System.Object)+10]");
									bool flag2 = (nint)0 == 0;
									object obj5 = obj3 - 40;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v154 @ rdi_v37 (System.Object)+10]");
									Sprite.get_rect_Injected((IntPtr)0, out *(Rect*)obj5);
									if ((object)rectTransform != null)
									{
										rectTransform.sizeDelta = sizeDelta;
										object lockIcon = _LockIcon;
										if ((object)_LockIcon != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ rdi_v38 (System.Object)+E0]");
											object obj6 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ rdi_v38 (System.Object)+E0]");
											if ((nint)0 != 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ rdi_v39 (System.Object)+10]");
												if ((nint)0 != 0)
												{
													if ((object)_CharacterIcon != null)
													{
														RectTransform rectTransform2 = _CharacterIcon.rectTransform;
														if ((object)rectTransform2 != null)
														{
															_ = 0;
															_ = 0;
															bool flag3 = ((UnityEngine.Object)rectTransform2).m_CachedPtr == (IntPtr)0;
															object obj7 = obj3 - 56;
															Transform.get_localPosition_Injected(((UnityEngine.Object)rectTransform2).m_CachedPtr, out *(Vector3*)obj7);
															if ((object)_CharacterIcon != null)
															{
																RectTransform rectTransform3 = _CharacterIcon.rectTransform;
																if ((object)rectTransform3 != null)
																{
																	Vector2 sizeDelta2 = rectTransform3.sizeDelta;
																	if ((object)_LockIcon != null)
																	{
																		RectTransform rectTransform4 = _LockIcon.rectTransform;
																		if ((object)rectTransform4 != null)
																		{
																			Vector2 sizeDelta3 = rectTransform4.sizeDelta;
																			if ((object)_LockIcon != null)
																			{
																				RectTransform rectTransform5 = _LockIcon.rectTransform;
																				bool flag4 = (object)rectTransform5 == null;
																				_ = 0;
																				bool flag5 = ((UnityEngine.Object)rectTransform5).m_CachedPtr == (IntPtr)0;
																				object obj8 = obj3 - 56;
																				Transform.set_localPosition_Injected(((UnityEngine.Object)rectTransform5).m_CachedPtr, ref *(Vector3*)obj8);
																				goto IL_05cc;
																			}
																		}
																	}
																}
															}
														}
													}
													goto IL_0575;
												}
											}
											goto IL_05cc;
										}
									}
								}
							}
						}
					}
				}
				goto IL_0575;
			}
		}
		goto IL_05cc;
		IL_041e:
		Image shadowIcon = _ShadowIcon;
		if ((object)_ShadowIcon != null)
		{
			object sprite2 = shadowIcon.m_Sprite;
			if ((object)shadowIcon.m_Sprite == null)
			{
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ rdi_v23 (System.Object)+10]");
			if ((nint)0 == 0)
			{
				return;
			}
			if ((object)_ShadowIcon != null)
			{
				RectTransform rectTransform6 = _ShadowIcon.rectTransform;
				object shadowIcon2 = _ShadowIcon;
				if ((object)_ShadowIcon != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ rdi_v26 (System.Object)+E0]");
					object obj9 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ rdi_v26 (System.Object)+E0]");
					if ((nint)0 != 0)
					{
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v165 @ rdi_v27 (System.Object)+10]");
						bool flag6 = (nint)0 == 0;
						object obj10 = obj3 - 40;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v165 @ rdi_v27 (System.Object)+10]");
						Sprite.get_rect_Injected((IntPtr)0, out *(Rect*)obj10);
						object shadowIcon3 = _ShadowIcon;
						if ((object)_ShadowIcon != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v170 @ rdi_v28 (System.Object)+E0]");
							object obj11 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v170 @ rdi_v28 (System.Object)+E0]");
							if ((nint)0 != 0)
							{
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v166 @ rdi_v29 (System.Object)+10]");
								bool flag7 = (nint)0 == 0;
								object obj12 = obj3 - 56;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v166 @ rdi_v29 (System.Object)+10]");
								Sprite.get_rect_Injected((IntPtr)0, out *(Rect*)obj12);
								if ((object)rectTransform6 != null)
								{
									rectTransform6.sizeDelta = sizeDelta;
									return;
								}
							}
						}
					}
				}
			}
		}
		goto IL_0575;
		IL_05cc:
		Image weaponIcon = _WeaponIcon;
		if ((object)_WeaponIcon != null)
		{
			object sprite3 = weaponIcon.m_Sprite;
			if ((object)weaponIcon.m_Sprite != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v158 @ rdi_v21 (System.Object)+10]");
				if ((nint)0 != 0)
				{
					if ((object)_WeaponIcon != null)
					{
						RectTransform rectTransform7 = _WeaponIcon.rectTransform;
						object weaponIcon2 = _WeaponIcon;
						if ((object)_WeaponIcon != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ rdi_v30 (System.Object)+E0]");
							object obj13 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ rdi_v30 (System.Object)+E0]");
							if ((nint)0 != 0)
							{
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ rdi_v31 (System.Object)+10]");
								bool flag8 = (nint)0 == 0;
								object obj14 = obj3 - 40;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ rdi_v31 (System.Object)+10]");
								Sprite.get_rect_Injected((IntPtr)0, out *(Rect*)obj14);
								object weaponIcon3 = _WeaponIcon;
								if ((object)_WeaponIcon != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v169 @ rdi_v32 (System.Object)+E0]");
									object obj15 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v169 @ rdi_v32 (System.Object)+E0]");
									if ((nint)0 != 0)
									{
										_ = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ rdi_v33 (System.Object)+10]");
										bool flag9 = (nint)0 == 0;
										object obj16 = obj3 - 56;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ rdi_v33 (System.Object)+10]");
										Sprite.get_rect_Injected((IntPtr)0, out *(Rect*)obj16);
										if ((object)rectTransform7 != null)
										{
											rectTransform7.sizeDelta = sizeDelta;
											goto IL_041e;
										}
									}
								}
							}
						}
					}
					goto IL_0575;
				}
			}
			goto IL_041e;
		}
		goto IL_0575;
		IL_0575:
		throw new NullReferenceException();
	}

	private void SetCharacterSprite()
	{
		Sprite sprite;
		if (IsUnlockableAndSecret())
		{
			sprite = SpriteManager.GetSprite("QuestionMark", "UI");
		}
		else
		{
			CharacterItem charItem = _charItem;
			sprite = GetCharSprite(charItem._characterType, charItem._characterData);
		}
		_CharacterIcon.sprite = sprite;
	}

	protected override void OnSelected()
	{
		SetInfoPanel();
	}

	private void SetCharacterName()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A30AB]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		CharacterItem charItem = _charItem;
		if (charItem._unlockState != UIUnlockStates.UNLOCKABLE)
		{
			TextMeshProUGUI characterName = _CharacterName;
		}
		else
		{
			CharacterData characterData = charItem._characterData;
			bool flag = !characterData._003Csecret_003Ek__BackingField;
			TextMeshProUGUI characterName = _CharacterName;
			if (!flag)
			{
				string text = "???";
				goto IL_00f4;
			}
		}
		CharacterItem charItem2 = _charItem;
		if (charItem._characterType == CharacterType.ARENGIJUS)
		{
			CharacterData characterData2 = charItem2._characterData;
			string text = characterData2._003CcharName_003Ek__BackingField;
		}
		else
		{
			string text = charItem2._characterData.GetCharFirstName(charItem2._characterType);
		}
		goto IL_00f4;
		IL_00f4:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18634B7A0");
	}

	private void SetWeaponIconSprite()
	{
		//IL_004c: Expected I4, but got O
		//IL_01c4: Expected O, but got I
		//IL_01d9: Expected O, but got I
		//IL_0116: Expected I4, but got O
		//IL_022f: Expected O, but got I
		//IL_022f: Expected O, but got I
		CharacterItem charItem = _charItem;
		CharacterData characterData = charItem._characterData;
		System.Int32Enum int32Enum = (((object)characterData._003CstartingWeapon_003Ek__BackingField == null) ? ((System.Int32Enum)3) : ((System.Int32Enum)((object?)characterData._003CstartingWeapon_003Ek__BackingField >> 32)));
		Skin currentSkinData = charItem._characterData.GetCurrentSkinData();
		if (currentSkinData != null && (object)currentSkinData._003CstartingWeapon_003Ek__BackingField != null)
		{
			CharacterItem charItem2 = _charItem;
			Skin currentSkinData2 = charItem2._characterData.GetCurrentSkinData();
			bool flag = currentSkinData2 == null;
			WeaponType? weaponType = (WeaponType?)currentSkinData2;
			if (!flag)
			{
				weaponType = currentSkinData2._003CstartingWeapon_003Ek__BackingField;
			}
			System.Int32Enum int32Enum2 = (((object)weaponType == null) ? int32Enum : ((System.Int32Enum)((object?)weaponType >> 32)));
			int32Enum = int32Enum2;
		}
		if (int32Enum == (System.Int32Enum)0)
		{
			_voidWeapon = true;
			_WeaponIcon.enabled = false;
			_ShadowIcon.enabled = false;
		}
		else
		{
			Dictionary<WeaponType, List<WeaponData>> convertedWeapons = _dataManager.GetConvertedWeapons();
			object obj = ((Dictionary<System.Int32Enum, object>)(object)convertedWeapons).get_Item(int32Enum);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ rax_v17 (System.Object)+18]");
			if ((nint)0 <= (nint)0)
			{
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ rax_v17 (System.Object)+10]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ rax_v18+20]");
			object obj3 = 0;
			_WeaponIcon.enabled = true;
			_ShadowIcon.enabled = true;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ rbx_v10+40]");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ rbx_v10+38]");
			Sprite sprite = SpriteManager.GetSprite((string)num, (string)0);
			_WeaponIcon.sprite = sprite;
			Image weaponIcon = _WeaponIcon;
			_ShadowIcon.sprite = weaponIcon.m_Sprite;
		}
		GameObject gameObject = _WeaponIcon.gameObject;
		CharacterItem charItem3 = _charItem;
		CharacterData characterData2 = charItem3._characterData;
		bool active = !characterData2._003ChideWeaponIcon_003Ek__BackingField;
		gameObject.SetActive(active);
		GameObject gameObject2 = _ShadowIcon.gameObject;
		CharacterItem charItem4 = _charItem;
		CharacterData characterData3 = charItem4._characterData;
		bool active2 = !characterData3._003ChideWeaponIcon_003Ek__BackingField;
		gameObject2.SetActive(active2);
	}

	public CharacterItemUI()
	{
		//IL_0070: Expected O, but got I
		//IL_001a: Expected I, but got O
		float iconUIScale = UIHelper.JS_MAGIC_SCALE_NUMBER + UIHelper.JS_MAGIC_SCALE_NUMBER;
		base._ShowSelector = true;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
		_backgroundColor = (Color)0;
		base._ShouldUpdatePositionWhenForcingDumbFix = true;
		ReselectIfDefaultSelectedOnPage = true;
		_iconUIScale = iconUIScale;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rcx_v4 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}

	private void _003CAnimateIn_003Eb__23_0()
	{
		GameObject gameObject = _Flash.gameObject;
		gameObject.SetActive(value: false);
		Canvas component = GetComponent<Canvas>();
		component.overrideSorting = false;
	}
}
