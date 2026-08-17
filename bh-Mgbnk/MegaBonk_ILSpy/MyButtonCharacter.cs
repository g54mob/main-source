using System;
using Assets.Scripts.Managers;
using Assets.Scripts.Saves___Serialization.Progression;
using Assets.Scripts.Saves___Serialization.Progression.Achievements;
using Assets.Scripts.Saves___Serialization.Progression.Unlocks;
using Assets.Scripts.UI.Localization;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MyButtonCharacter : MyButton
{
	public GameObject hoverOverlay;

	public GameObject unavailableOverlay;

	public TextMeshProUGUI t_name;

	public RawImage i_icon;

	public GameObject requiresPurchaseOverlay;

	public TextMeshProUGUI t_price;

	public GameObject star;

	public CharacterData characterData;

	public Material lockedMaterial;

	public static Action<MyButtonCharacter> A_Confirm;

	public static Action<MyButtonCharacter> A_Select;

	public bool canUseCharacter;

	private CharacterData data;

	public string cantUseCharacterReason;

	private new void Awake()
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<UnlockableBase> b = OnItemPurchased;
		Delegate obj = Delegate.Combine(UnlocksFooter.A_Purchased, b);
		if ((object)obj == null)
		{
			UnlocksFooter.A_Purchased = (Action<UnlockableBase>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<UnlockableBase> action = default(Action<UnlockableBase>);
		if (action != null)
		{
			UnlocksFooter.A_Purchased = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<UnlockableBase>);
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<UnlockableBase>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	private void OnEnable()
	{
		if (data != null)
		{
			string text = data.GetName();
			t_name.text = text;
		}
	}

	private void OnDestroy()
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<UnlockableBase> value = OnItemPurchased;
		Delegate obj = Delegate.Remove(UnlocksFooter.A_Purchased, value);
		if ((object)obj == null)
		{
			UnlocksFooter.A_Purchased = (Action<UnlockableBase>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<UnlockableBase> action = default(Action<UnlockableBase>);
		if (action != null)
		{
			UnlocksFooter.A_Purchased = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<UnlockableBase>);
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<UnlockableBase>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	private void OnItemPurchased(UnlockableBase unlockable)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 2 Invalid \"Jump target not found in method: 0x180552190\"");
	}

	public unsafe void SetCharacter(CharacterData data)
	{
		//IL_01cb: Expected O, but got Ref
		//IL_0148: Expected O, but got Ref
		this.data = data;
		canUseCharacter = false;
		bool flag = data == null;
		if (!flag && data.isEnabled != flag)
		{
			this.characterData = data;
			TextMeshProUGUI textMeshProUGUI = t_name;
			string text = this.characterData.GetName();
			t_name.text = text;
			Texture icon = this.characterData.GetIcon();
			i_icon.texture = icon;
			SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
			CharacterData characterData = this.characterData;
			CharacterProgression characterProgression = saveManager.progression.GetCharacterProgression(characterData.eCharacter);
			bool active = characterProgression.HasStar();
			star.SetActive(active);
			object obj = default(object);
			if (!MyAchievements.IsUnlocked(this.characterData, out var _))
			{
				i_icon.color = (Color)(&obj);
				string localizedString = LocalizationUtility.GetLocalizedString("PopupText", "CHARACTER_NOT_UNLOCKED");
				cantUseCharacterReason = localizedString;
				if (this.characterData.IsBlackedOutInCharacterSelectionScreen())
				{
					unavailableOverlay.SetActive(value: true);
					t_name.text = "??";
				}
				return;
			}
			i_icon.color = (Color)(&obj);
			canUseCharacter = true;
			if (!MyAchievements.IsPurchased(this.characterData))
			{
				requiresPurchaseOverlay.SetActive(value: true);
				int price = this.characterData.GetPrice();
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
				object arg = default(object);
				string text2 = $"<size=110%><sprite name=silver></size> {arg:N0}";
				t_price.text = text2;
			}
			else
			{
				requiresPurchaseOverlay.SetActive(value: false);
			}
		}
		else
		{
			t_name.text = "???";
			IconManager instance = IconManager.Instance;
			i_icon.texture = instance.questionMark;
			this.characterData = null;
			cantUseCharacterReason = "Character not enabled..";
		}
	}

	public void Refresh()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 2 Invalid \"Jump target not found in method: 0x180552190\"");
	}

	public override void StartHover()
	{
		isHovering = true;
		hoverOverlay.SetActive(value: true);
		Action<MyButtonCharacter> a_Select = A_Select;
		if (A_Select != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v43 @ rax_v5 (System.Action`1<MyButtonCharacter>)+18] (should have been resolved before IL gen)");
		}
	}

	public override void StopHover()
	{
		isHovering = false;
		hoverOverlay.SetActive(value: false);
	}

	protected override void OnClick()
	{
	}

	private new void Update()
	{
		base.Update();
		if (isHovering && MyInputManager.GetButtonDown(MyInputManager.UISubmit) && ButtonManager.selectedButton2 == this)
		{
			if (customSfx == null)
			{
				AudioManager.Instance.PlayButtonEnter();
			}
			else
			{
				AudioManager.Instance.PlaySfx(customSfx);
			}
			Action<MyButtonCharacter> a_Confirm = A_Confirm;
			if (A_Confirm != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v238 @ rax_v20 (System.Action`1<MyButtonCharacter>)+18] (should have been resolved before IL gen)");
			}
		}
	}

	public MyButtonCharacter()
	{
		hoverScale = 1.05f;
		((MonoBehaviour)this)._002Ector();
	}
}
