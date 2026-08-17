using System;
using System.Collections.Generic;
using Assets.Scripts.Managers;
using Assets.Scripts.Saves___Serialization.Progression.Achievements;
using Assets.Scripts.Saves___Serialization.Progression.Unlocks;
using Assets.Scripts.Saves___Serialization.SaveFiles;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UnlockContainer : MonoBehaviour, ISelectHandler, IEventSystemHandler
{
	public UnlockableBase unlockable;

	public RawImage icon;

	public RawImage fullReleaseOnly;

	public RawImage backgroundLocked;

	public RawImage backgroundUnlocked;

	public Texture t_unknown;

	public string requirementsString;

	public bool isUnlocked;

	public bool fullGameOnly;

	public bool isPurchased;

	public GameObject notPurchasedOverlay;

	public TextMeshProUGUI t_price;

	public GameObject alert;

	public GameObject activationToggle;

	public GameObject activationToggleCheckmark;

	public GameObject unactivatedOverlay;

	private Button button;

	public static Action<UnlockContainer> A_Selected;

	public static Action<UnlockContainer> A_Clicked;

	public Color defaultBackgroundColor;

	public bool visualsOnlyNoButton;

	public static Action A_RemovedAlert;

	private unsafe void Awake()
	{
		//IL_00d9: Expected I, but got O
		//IL_00b1: Expected I, but got O
		Button component = GetComponent<Button>();
		button = component;
		Action<UnlockableBase> action = OnPurchased;
		action._002Ector((object)this, (IntPtr)(nint)__ldftn(UnlockContainer.OnPurchased));
		Delegate obj = Delegate.Combine(UnlocksFooter.A_Purchased, action);
		if ((object)obj == null)
		{
			UnlocksFooter.A_Purchased = (Action<UnlockableBase>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<UnlockableBase> action2 = default(Action<UnlockableBase>);
		if (action2 != null)
		{
			UnlocksFooter.A_Purchased = action2;
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

	private void OnDestroy()
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<UnlockableBase> value = OnPurchased;
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

	private void OnEnable()
	{
		if (unlockable != null)
		{
			Set(unlockable);
		}
	}

	public unsafe void Set(UnlockableBase unlockable)
	{
		//IL_0038: Expected O, but got Ref
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Expected Ref, but got Unknown
		//IL_018a: Expected O, but got Ref
		//IL_0295: Expected I, but got O
		this.unlockable = unlockable;
		icon.enabled = true;
		Color backgroundColor = GetBackgroundColor(unlockable);
		float num = default(float);
		backgroundUnlocked.color = (Color)(&num);
		bool flag;
		if (unlockable == null)
		{
			flag = true;
		}
		else
		{
			bool flag2 = !unlockable.isEnabled;
			flag = flag2;
		}
		fullGameOnly = flag;
		bool flag3 = !flag && MyAchievements.IsUnlocked(unlockable, out *(string*)(this + 80));
		isUnlocked = flag3;
		GameObject gameObject = fullReleaseOnly.gameObject;
		gameObject.SetActive(fullGameOnly);
		RawImage rawImage;
		Texture texture;
		if (!fullGameOnly && unlockable != null)
		{
			rawImage = icon;
			texture = unlockable.GetIcon();
		}
		else
		{
			rawImage = icon;
			texture = t_unknown;
		}
		rawImage.texture = texture;
		RawImage rawImage2 = backgroundUnlocked;
		Color backgroundColor2 = GetBackgroundColor(unlockable);
		backgroundUnlocked.color = (Color)(&num);
		bool flag4 = MyAchievements.IsPurchased(unlockable);
		isPurchased = flag4;
		if (notPurchasedOverlay != null)
		{
			bool flag5 = !isUnlocked;
			bool active = false;
			if (!flag5)
			{
				bool flag6 = !isPurchased;
				active = flag6;
			}
			notPurchasedOverlay.SetActive(active);
			if (unlockable != null)
			{
				TextMeshProUGUI textMeshProUGUI = t_price;
				int price = unlockable.GetPrice();
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
				object arg = default(object);
				string text = $"<size=110%><sprite name=silver></size> {arg:N0}";
				nint num2 = (nint)textMeshProUGUI;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v718 @ r9_v8 (Il2CppClass<UnityEngine.UI.RawImage>)+558] (should have been resolved before IL gen)");
			}
		}
		if (alert != null)
		{
			bool active2;
			if (!(unlockable != null))
			{
				active2 = false;
			}
			else
			{
				SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
				ProgressionSaveFile progression = saveManager.progression;
				object internalName = unlockable.GetInternalName();
				bool flag7 = ((HashSet<object>)(object)progression.newUnlockables).Contains(internalName);
				active2 = flag7;
			}
			alert.SetActive(active2);
		}
		SetUnlocked(isUnlocked);
		if (activationToggle != null)
		{
			bool flag8;
			if (!isPurchased)
			{
				flag8 = false;
			}
			else
			{
				bool flag9 = MyAchievements.CanToggleActivation(unlockable);
				flag8 = flag9;
			}
			activationToggle.SetActive(flag8);
			if (!flag8)
			{
				unactivatedOverlay.SetActive(value: false);
			}
			GameObject gameObject2 = activationToggle.gameObject;
			if (gameObject2.activeSelf)
			{
				bool active3 = MyAchievements.IsActivated(unlockable);
				activationToggleCheckmark.SetActive(active3);
				bool activeSelf = activationToggleCheckmark.activeSelf;
				bool active4 = (byte)((activeSelf ? 1u : 0u) ^ 1u) != 0;
				unactivatedOverlay.SetActive(active4);
			}
		}
	}

	public void SetEmpty()
	{
		icon.enabled = false;
		notPurchasedOverlay.SetActive(value: false);
	}

	public unsafe void SetUnlocked(bool isUnlocked)
	{
		//IL_0022: Expected O, but got Ref
		if (!isUnlocked)
		{
		}
		object obj = default(object);
		icon.color = (Color)(&obj);
		GameObject gameObject = backgroundLocked.gameObject;
		bool active = (byte)((isUnlocked ? 1u : 0u) ^ 1u) != 0;
		gameObject.SetActive(active);
		GameObject gameObject2 = backgroundUnlocked.gameObject;
		gameObject2.SetActive(isUnlocked);
	}

	public void SetAchievement(MyAchievement ach)
	{
		bool flag = ach != null;
		if (flag)
		{
			flag = MyAchievements.IsUnlocked(ach);
		}
		isUnlocked = flag;
		SetUnlocked(flag);
		icon.enabled = true;
		if (!(ach != null))
		{
			IconManager instance = IconManager.Instance;
			icon.texture = instance.questionMark;
		}
		else
		{
			Texture texture = ach.GetIcon();
			icon.texture = texture;
		}
	}

	private unsafe Color GetBackgroundColor(UnlockableBase unlockable)
	{
		//IL_0206: Expected F4, but got O
		//IL_0201: Expected native int or pointer, but got O
		//IL_004c: Expected I, but got O
		//IL_0054: Expected I, but got O
		//IL_0064: Expected O, but got I
		//IL_00a0: Expected O, but got I
		//IL_0154: Expected native int or pointer, but got O
		//IL_018b: Expected native int or pointer, but got O
		//IL_01e0: Expected native int or pointer, but got O
		//IL_01ed: Expected native int or pointer, but got O
		Color color2 = default(Color);
		if (unlockable != null && (object)unlockable != null)
		{
			nint num = (nint)typeof(ItemData);
			nint num2 = (nint)unlockable;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rdx_v3 (Il2CppClass<ItemData>)+130]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ r8_v3 (Il2CppClass<Assets.Scripts.Saves___Serialization.Progression.Achievements.UnlockableBase>)+130]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rdx_v3 (Il2CppClass<ItemData>)+130]");
			if (num3 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ r8_v3 (Il2CppClass<Assets.Scripts.Saves___Serialization.Progression.Achievements.UnlockableBase>)+C8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rax_v7+FFFFFFF8+v79 @ rax_v6*8]");
				if (0 == (nint)typeof(ItemData))
				{
					Color color = ((ItemData)unlockable).GetColor();
					float num4 = 1f - color.r;
					float num5 = 1f - color.b;
					float num6 = num4 * 0.25f;
					float num7 = num5 * 0.25f;
					float r = num6 + color.r;
					float b = num7 + color.b;
					((Color*)(nint)color2)->r = r;
					float num8 = 1f - color.g;
					float num9 = 1f - color.a;
					((Color*)(nint)color2)->b = b;
					float num10 = num8 * 0.25f;
					float num11 = num9 * 0.25f;
					float g = num10 + color.g;
					float a = num11 + color.a;
					((Color*)(nint)color2)->g = g;
					((Color*)(nint)color2)->a = a;
					return color2;
				}
			}
		}
		((Color*)(nint)color2)->r = (float)defaultBackgroundColor;
		return color2;
	}

	public void OnSelect(BaseEventData eventData)
	{
		//IL_00d9: Expected O, but got I
		//IL_0107: Expected O, but got I
		//IL_014c: Expected O, but got I
		//IL_017a: Expected O, but got I
		if (visualsOnlyNoButton)
		{
			return;
		}
		SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
		if ((object)SaveManager._003CInstance_003Ek__BackingField != null)
		{
			ProgressionSaveFile progression = saveManager.progression;
			if (saveManager.progression != null && progression.newUnlockables != null && unlockable != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803311C0");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v294 @ rax_v17+30]");
				object obj = 0;
				object internalName = unlockable.GetInternalName();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v305 @ rdx_v7+58]");
				if (((HashSet<object>)0).Contains(internalName))
				{
					bool flag = ((HashSet<string>)null).Contains((string)internalName);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v323 @ rax_v24 (System.Boolean)+30]");
					object obj2 = 0;
					object internalName2 = unlockable.GetInternalName();
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v317 @ rdx_v10+58]");
					bool flag2 = ((HashSet<object>)0).Remove(internalName2);
					alert.SetActive(value: false);
					Action a_RemovedAlert = A_RemovedAlert;
					if (A_RemovedAlert != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v201.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
					}
				}
			}
		}
		Action<UnlockContainer> a_Selected = A_Selected;
		if (A_Selected != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v262 @ rax_v10 (System.Action`1<UnlockContainer>)+18] (should have been resolved before IL gen)");
		}
	}

	public void ToggleActivation()
	{
		//IL_0176: Expected O, but got I
		//IL_011b: Expected O, but got I
		//IL_01a4: Expected O, but got I
		//IL_0149: Expected O, but got I
		if (activationToggle != null && MyAchievements.IsPurchased(unlockable) && MyAchievements.CanToggleActivation(unlockable))
		{
			bool flag = MyAchievements.IsActivated(unlockable);
			bool flag2 = (byte)((flag ? 1u : 0u) ^ 1u) != 0;
			activationToggleCheckmark.SetActive(flag2);
			bool activeSelf = activationToggleCheckmark.activeSelf;
			bool active = (byte)((activeSelf ? 1u : 0u) ^ 1u) != 0;
			unactivatedOverlay.SetActive(active);
			if (!flag2)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803311C0");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v263 @ rax_v24+30]");
				object obj = 0;
				string internalName = unlockable.GetInternalName();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v255 @ rdx_v13+40]");
				bool flag3 = ((HashSet<string>)0).Add(internalName);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803311C0");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v265 @ rax_v18+30]");
				object obj2 = 0;
				object internalName2 = unlockable.GetInternalName();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v257 @ rdx_v10+40]");
				bool flag4 = ((HashSet<object>)0).Remove(internalName2);
			}
		}
	}

	private void OnPurchased(UnlockableBase unlockable)
	{
		if (unlockable == this.unlockable)
		{
			Set(unlockable);
		}
	}
}
