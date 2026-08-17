using System;
using Assets.Scripts.Saves___Serialization.Progression.Achievements;
using Assets.Scripts.Saves___Serialization.Progression.Unlocks;
using Assets.Scripts.Saves___Serialization.SaveFiles;
using Assets.Scripts.UI.Localization;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkinContainer : MyButton, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public RawImage skinIcon;

	public GameObject locked;

	public GameObject notSelectedOverlay;

	public GameObject purchaseOverlay;

	public TextMeshProUGUI t_price;

	public SkinData skin;

	public static Action<SkinContainer> A_Hover;

	public static Action<SkinContainer> A_HoverMouse;

	public static Action<SkinContainer> A_HoverMouseExit;

	public static Action<SkinData> A_Purchased;

	public void SetSkin(SkinData skin)
	{
		this.skin = skin;
		if (!MyAchievements.IsUnlocked(skin, out var _))
		{
			GameObject gameObject = skinIcon.gameObject;
			gameObject.SetActive(value: false);
			locked.SetActive(value: true);
			purchaseOverlay.SetActive(value: false);
			return;
		}
		GameObject gameObject2 = skinIcon.gameObject;
		gameObject2.SetActive(value: true);
		locked.SetActive(value: false);
		skinIcon.texture = skin.icon;
		bool flag = MyAchievements.IsPurchased(skin);
		bool active = (byte)((flag ? 1u : 0u) ^ 1u) != 0;
		purchaseOverlay.SetActive(active);
		int price = skin.GetPrice();
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
		object arg = default(object);
		string text = $"<sprite name=silver> {arg}";
		t_price.text = text;
	}

	public void SetSelected(bool isSelected)
	{
		GameObject gameObject = notSelectedOverlay.gameObject;
		bool active = (byte)((isSelected ? 1u : 0u) ^ 1u) != 0;
		gameObject.SetActive(active);
	}

	public override void StartHover()
	{
		TooltipHoverEnter();
		if (!locked.activeInHierarchy)
		{
			Action<SkinContainer> a_Hover = A_Hover;
			if (A_Hover != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v56 @ rax_v7 (System.Action`1<SkinContainer>)+18] (should have been resolved before IL gen)");
			}
		}
	}

	private bool IsLocked()
	{
		//IL_0041: Expected I4, but got O
		if ((object)locked != null)
		{
			return locked.activeInHierarchy;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private bool NeedPurchase()
	{
		bool flag = MyAchievements.IsPurchased(skin);
		return (byte)((flag ? 1u : 0u) ^ 1u) != 0;
	}

	public ECharacter GetCharacter()
	{
		//IL_0041: Expected I4, but got O
		SkinData skinData = skin;
		if ((object)skin != null)
		{
			return skinData.character;
		}
		NullReferenceException ex = new NullReferenceException();
		return (ECharacter)ex;
	}

	public override void StopHover()
	{
		ToolTip.Instance.HideTip();
	}

	private void OnDisable()
	{
		ToolTip.Instance.HideTip();
	}

	protected unsafe override void OnClick()
	{
		//IL_0172: Expected O, but got Ref
		//IL_0172: Expected O, but got Ref
		if (MyAchievements.IsPurchased(skin) || !MyAchievements.IsUnlocked(skin, out var _))
		{
			return;
		}
		int price = skin.GetPrice();
		SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
		ProgressionSaveFile progression = saveManager.progression;
		if (progression.silver >= price)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
			object arg = default(object);
			string content = $"Purchase skin for <sprite name=silver> {arg}?";
			AlwaysUi instance = AlwaysUi.Instance;
			Action a_Accept = delegate
			{
				SaveManager saveManager2 = SaveManager._003CInstance_003Ek__BackingField;
				bool flag = saveManager2.progression.PurchaseUnlockable(skin);
				purchaseOverlay.SetActive(value: false);
				Action<SkinData> a_Purchased = A_Purchased;
				if (A_Purchased != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v166 @ r9_v1 (System.Action`1<SkinData>)+18] (should have been resolved before IL gen)");
				}
				Action<SkinContainer> a_Hover = A_Hover;
				if (A_Hover != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v126 @ r9_v2 (System.Action`1<SkinContainer>)+18] (should have been resolved before IL gen)");
				}
			};
			instance.dynamicWindows.NewWindowPrompt("Skin", content, a_Accept);
		}
		else
		{
			AlwaysUi instance2 = AlwaysUi.Instance;
			string localizedString = LocalizationUtility.GetLocalizedString("PopupText", "CANT_AFFORD");
			Transform transform = base.transform;
			Vector3 position = transform.position;
			object obj = default(object);
			object obj2 = default(object);
			float desiredScale = default(float);
			instance2.UiTextPopup.SetText(localizedString, (Vector3)(&obj), (Color)(&obj2), desiredScale);
		}
	}

	private void TooltipHoverEnter()
	{
		ToolTip instance;
		string unlockRequirement2;
		if (locked.activeInHierarchy)
		{
			instance = ToolTip.Instance;
			MyAchievement unlockRequirement = skin.GetUnlockRequirement();
			unlockRequirement2 = unlockRequirement.GetUnlockRequirement();
		}
		else
		{
			instance = ToolTip.Instance;
			unlockRequirement2 = skin.GetName();
		}
		RectTransform component = GetComponent<RectTransform>();
		instance.SetTip(unlockRequirement2, component);
	}

	private void TooltipHoverExit()
	{
		ToolTip.Instance.HideTip();
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		Action<SkinContainer> a_HoverMouse = A_HoverMouse;
		if (A_HoverMouse != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v29 @ rax_v3 (System.Action`1<SkinContainer>)+18] (should have been resolved before IL gen)");
		}
		TooltipHoverEnter();
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		Action<SkinContainer> a_HoverMouseExit = A_HoverMouseExit;
		if (A_HoverMouseExit != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v29 @ rax_v3 (System.Action`1<SkinContainer>)+18] (should have been resolved before IL gen)");
		}
		ToolTip.Instance.HideTip();
	}

	public SkinContainer()
	{
		hoverScale = 1.05f;
		((MonoBehaviour)this)._002Ector();
	}

	private void _003COnClick_003Eb__18_0()
	{
		SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
		bool flag = saveManager.progression.PurchaseUnlockable(skin);
		purchaseOverlay.SetActive(value: false);
		Action<SkinData> a_Purchased = A_Purchased;
		if (A_Purchased != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v166 @ r9_v1 (System.Action`1<SkinData>)+18] (should have been resolved before IL gen)");
		}
		Action<SkinContainer> a_Hover = A_Hover;
		if (A_Hover != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v126 @ r9_v2 (System.Action`1<SkinContainer>)+18] (should have been resolved before IL gen)");
		}
	}
}
