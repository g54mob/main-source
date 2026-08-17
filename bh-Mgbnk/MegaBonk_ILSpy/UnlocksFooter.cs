using System;
using System.Collections.Generic;
using Assets.Scripts.Managers;
using Assets.Scripts.Saves___Serialization.Progression.Achievements;
using Assets.Scripts.UI.Localization;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;

public class UnlocksFooter : MonoBehaviour
{
	public TextMeshProUGUI t_unlockName;

	public TextMeshProUGUI t_unlockDescription;

	public UnlockContainer unlockContainer;

	public MyButton buyButton;

	public RequirementPrefab[] reqContainers;

	public RequirementsContainer requirementsContainer;

	public GameObject buyContainer;

	public TextMeshProUGUI t_buyPrice;

	public TextMeshProUGUI t_suggestedBy;

	public UnlocksExtraInformation extraInformation;

	public ButtonNavigationSelectionOnly tabNavigation;

	public static Action<UnlockableBase> A_Purchased;

	private UnlockContainer lastSelected;

	private Vector2 reqContainerPosDefault;

	private Vector2 reqContainerPosSmall;

	private Vector2 reqContainerScaleDefault;

	private Vector2 reqContainerScaleSmall;

	public Window parentWindow;

	private void Awake()
	{
		//IL_034e: Expected O, but got I4
		//IL_0357: Expected O, but got I4
		//IL_0365: Expected I, but got O
		//IL_009f: Expected O, but got I4
		//IL_00a8: Expected O, but got I4
		//IL_00b6: Expected I, but got O
		//IL_0152: Expected O, but got I4
		//IL_015b: Expected O, but got I4
		//IL_0169: Expected I, but got O
		//IL_0123: Expected I, but got O
		//IL_01a7: Expected I, but got O
		//IL_01b8: Expected O, but got I4
		//IL_01c1: Expected O, but got I4
		//IL_01cf: Expected I, but got O
		//IL_0209: Expected O, but got I4
		//IL_0212: Expected O, but got I4
		//IL_02a8: Expected O, but got I4
		//IL_02b1: Expected O, but got I4
		//IL_02bf: Expected I, but got O
		//IL_030c: Expected O, but got I4
		//IL_0315: Expected O, but got I4
		//IL_0323: Expected I, but got O
		SetEmpty();
		Action<UnlockContainer> b = OnUnlockSelected;
		Delegate obj = Delegate.Combine(UnlockContainer.A_Selected, b);
		nint num2;
		Delegate obj2;
		object obj3;
		object obj4;
		nint num;
		if ((object)obj == null)
		{
			UnlockContainer.A_Selected = (Action<UnlockContainer>)obj;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<UnlockContainer> action = default(Action<UnlockContainer>);
			if (action == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				obj2 = obj;
				obj3 = 0;
				obj4 = 0;
				num = (nint)typeof(Action<UnlockContainer>);
				goto IL_03d5;
			}
			UnlockContainer.A_Selected = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			obj2 = obj;
			obj3 = 0;
			obj4 = 0;
			num2 = (nint)typeof(Action<UnlockContainer>);
			if (flag)
			{
				goto IL_0386;
			}
		}
		Action<UnlockContainer> b2 = OnUnlockClicked;
		Delegate obj6 = Delegate.Combine(MyButtonUnlock.A_Clicked, b2);
		if ((object)obj6 == null)
		{
			MyButtonUnlock.A_Clicked = (Action<UnlockContainer>)obj6;
			num = (nint)MyButtonUnlock.A_Clicked;
			goto IL_01dd;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<UnlockContainer> action2 = default(Action<UnlockContainer>);
		bool flag2 = action2 == null;
		obj2 = obj6;
		obj3 = 0;
		obj4 = 0;
		num2 = (nint)typeof(Action<UnlockContainer>);
		if (!flag2)
		{
			MyButtonUnlock.A_Clicked = action2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj7 = default(object);
			bool flag3 = obj7 == null;
			num = (nint)typeof(Action<UnlockContainer>);
			obj2 = obj6;
			obj3 = 0;
			obj4 = 0;
			num2 = (nint)typeof(Action<UnlockContainer>);
			if (!flag3)
			{
				goto IL_01dd;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0386;
		IL_03c5:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_03b1;
		IL_0386:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_03d5:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		Delegate obj8 = obj2;
		goto IL_03c5;
		IL_03b1:
		throw new NullReferenceException();
		IL_01dd:
		ButtonNavigationSelectionOnly buttonNavigationSelectionOnly = tabNavigation;
		bool flag4 = (object)tabNavigation == null;
		obj2 = obj6;
		obj3 = 0;
		obj4 = 0;
		if (flag4)
		{
			goto IL_03b1;
		}
		Action<int> b3 = OnTabChanged;
		Delegate obj9 = Delegate.Combine(buttonNavigationSelectionOnly.A_ButtonSelected, b3);
		if ((object)obj9 == null)
		{
			buttonNavigationSelectionOnly.A_ButtonSelected = (Action<int>)obj9;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<int> action3 = default(Action<int>);
		bool flag5 = action3 == null;
		obj2 = obj9;
		obj3 = 0;
		obj4 = 0;
		num = (nint)typeof(Action<int>);
		obj8 = obj9;
		if (flag5)
		{
			goto IL_03c5;
		}
		buttonNavigationSelectionOnly.A_ButtonSelected = action3;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		object obj10 = default(object);
		bool flag6 = obj10 == null;
		obj2 = obj9;
		obj3 = 0;
		obj4 = 0;
		num = (nint)typeof(Action<int>);
		if (!flag6)
		{
			return;
		}
		goto IL_03d5;
	}

	private void OnDestroy()
	{
		//IL_0339: Expected I, but got O
		//IL_034a: Expected O, but got I4
		//IL_0353: Expected O, but got I4
		//IL_008a: Expected I, but got O
		//IL_009b: Expected O, but got I4
		//IL_00a4: Expected O, but got I4
		//IL_013d: Expected I, but got O
		//IL_014e: Expected O, but got I4
		//IL_0157: Expected O, but got I4
		//IL_0111: Expected I, but got O
		//IL_0195: Expected I, but got O
		//IL_01a3: Expected I, but got O
		//IL_01b4: Expected O, but got I4
		//IL_01bd: Expected O, but got I4
		//IL_01f7: Expected O, but got I4
		//IL_0200: Expected O, but got I4
		//IL_0293: Expected I, but got O
		//IL_02a4: Expected O, but got I4
		//IL_02ad: Expected O, but got I4
		//IL_02f7: Expected I, but got O
		//IL_0308: Expected O, but got I4
		//IL_0311: Expected O, but got I4
		Action<UnlockContainer> value = OnUnlockSelected;
		Delegate obj = Delegate.Remove(UnlockContainer.A_Selected, value);
		nint num2;
		Delegate obj2;
		nint num;
		object obj3;
		object obj4;
		if ((object)obj == null)
		{
			UnlockContainer.A_Selected = (Action<UnlockContainer>)obj;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<UnlockContainer> action = default(Action<UnlockContainer>);
			if (action == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num = (nint)typeof(Action<UnlockContainer>);
				obj2 = obj;
				obj3 = 0;
				obj4 = 0;
				goto IL_03cf;
			}
			UnlockContainer.A_Selected = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			num2 = (nint)typeof(Action<UnlockContainer>);
			obj2 = obj;
			obj3 = 0;
			obj4 = 0;
			if (flag)
			{
				goto IL_0380;
			}
		}
		Action<UnlockContainer> value2 = OnUnlockClicked;
		Delegate obj6 = Delegate.Remove(MyButtonUnlock.A_Clicked, value2);
		if ((object)obj6 == null)
		{
			MyButtonUnlock.A_Clicked = (Action<UnlockContainer>)obj6;
			num = (nint)MyButtonUnlock.A_Clicked;
			goto IL_01cb;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<UnlockContainer> action2 = default(Action<UnlockContainer>);
		bool flag2 = action2 == null;
		num2 = (nint)typeof(Action<UnlockContainer>);
		obj2 = obj6;
		obj3 = 0;
		obj4 = 0;
		if (!flag2)
		{
			MyButtonUnlock.A_Clicked = action2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj7 = default(object);
			bool flag3 = obj7 == null;
			num = (nint)typeof(Action<UnlockContainer>);
			num2 = (nint)typeof(Action<UnlockContainer>);
			obj2 = obj6;
			obj3 = 0;
			obj4 = 0;
			if (!flag3)
			{
				goto IL_01cb;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0380;
		IL_03bf:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_03ab;
		IL_0380:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_03cf:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		Delegate obj8 = obj2;
		goto IL_03bf;
		IL_03ab:
		throw new NullReferenceException();
		IL_01cb:
		ButtonNavigationSelectionOnly buttonNavigationSelectionOnly = tabNavigation;
		bool flag4 = (object)tabNavigation == null;
		obj2 = obj6;
		obj3 = 0;
		obj4 = 0;
		if (flag4)
		{
			goto IL_03ab;
		}
		Action<int> b = OnTabChanged;
		Delegate obj9 = Delegate.Combine(buttonNavigationSelectionOnly.A_ButtonSelected, b);
		if ((object)obj9 == null)
		{
			buttonNavigationSelectionOnly.A_ButtonSelected = (Action<int>)obj9;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<int> action3 = default(Action<int>);
		bool flag5 = action3 == null;
		num = (nint)typeof(Action<int>);
		obj2 = obj9;
		obj3 = 0;
		obj4 = 0;
		obj8 = obj9;
		if (flag5)
		{
			goto IL_03bf;
		}
		buttonNavigationSelectionOnly.A_ButtonSelected = action3;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		object obj10 = default(object);
		bool flag6 = obj10 == null;
		num = (nint)typeof(Action<int>);
		obj2 = obj9;
		obj3 = 0;
		obj4 = 0;
		if (!flag6)
		{
			return;
		}
		goto IL_03cf;
	}

	private void OnTabChanged(int index)
	{
		SetEmpty();
	}

	private void SetEmpty()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1831720F1]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		t_unlockName.text = "";
		t_unlockDescription.text = "";
		t_suggestedBy.text = "";
		UnlockContainer unlockContainer = this.unlockContainer;
		unlockContainer.icon.enabled = false;
		unlockContainer.notPurchasedOverlay.SetActive(value: false);
		buyContainer.SetActive(value: false);
		GameObject gameObject = requirementsContainer.gameObject;
		gameObject.SetActive(value: false);
		GameObject gameObject2 = extraInformation.gameObject;
		gameObject2.SetActive(value: false);
	}

	private void OnUnlockSelected(UnlockContainer container)
	{
		lastSelected = container;
		UnlockContainer unlockContainer = this.unlockContainer;
		if (container.unlockable != unlockContainer.unlockable)
		{
			Refresh(container);
		}
	}

	private void Refresh(UnlockContainer container)
	{
		//IL_007c: Expected O, but got I
		//IL_008c: Expected O, but got I
		//IL_06aa: Expected O, but got I4
		//IL_06b3: Expected O, but got I4
		//IL_0444: Expected O, but got I
		//IL_0735: Unknown result type (might be due to invalid IL or missing references)
		//IL_073a: Expected O, but got Unknown
		//IL_048b: Expected I, but got O
		//IL_0493: Expected I, but got O
		//IL_04a3: Expected O, but got I
		//IL_0533: Expected I, but got O
		//IL_0543: Expected O, but got I
		//IL_04df: Expected O, but got I
		//IL_057f: Expected O, but got I
		GameObject gameObject = extraInformation.gameObject;
		gameObject.SetActive(value: false);
		GameObject gameObject2 = this.requirementsContainer.gameObject;
		gameObject2.SetActive(value: true);
		unlockContainer.Set(container.unlockable);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B70]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v988 @ rax_v11+B8]");
		object text = 0;
		t_suggestedBy.text = (string)text;
		Component component3;
		if (container.unlockable != null)
		{
			UnlockableBase unlockable = container.unlockable;
			if (unlockable.isEnabled)
			{
				GameObject gameObject3 = buyButton.gameObject;
				gameObject3.SetActive(value: true);
				RequirementPrefab[] array = reqContainers;
				int num = 0;
				int num2 = 0;
				for (int num3 = 0; num3 < array.Length; num3 = num2)
				{
					GameObject gameObject4 = array[num2].gameObject;
					gameObject4.SetActive(value: false);
					num2 = num + 1;
					num = num2;
				}
				bool flag = !container.isUnlocked;
				bool active = false;
				if (!flag)
				{
					bool flag2 = !container.isPurchased;
					active = flag2;
				}
				buyContainer.SetActive(active);
				Vector2 sizeDelta;
				RectTransform rectTransform;
				if (!container.isUnlocked)
				{
					string text2 = container.unlockable.GetName();
					t_unlockName.text = text2;
					GameObject gameObject5 = t_unlockDescription.gameObject;
					gameObject5.SetActive(value: false);
					this.requirementsContainer.Set(container.unlockable);
					RectTransform component = this.requirementsContainer.GetComponent<RectTransform>();
					component.anchoredPosition = reqContainerPosDefault;
					sizeDelta = reqContainerScaleDefault;
					rectTransform = component;
				}
				else
				{
					string text3 = container.unlockable.GetName();
					t_unlockName.text = text3;
					if (container.isPurchased)
					{
						GameObject gameObject6 = t_unlockDescription.gameObject;
						gameObject6.SetActive(value: true);
						string description = container.unlockable.GetDescription();
						t_unlockDescription.text = description;
						UnlockableBase unlockable2 = container.unlockable;
						if (!string.IsNullOrEmpty(unlockable2.author))
						{
							Dictionary<string, string> dictionary = new Dictionary<string, string>();
							UnlockableBase unlockable3 = container.unlockable;
							((Dictionary<object, object>)(object)dictionary).Add((object)"author", (object)unlockable3.author);
							string localizedString = LocalizationUtility.GetLocalizedString("Unlockables", "SUGGESTED_BY", dictionary);
							t_suggestedBy.text = localizedString;
						}
						Component component2 = extraInformation;
						UnityEngine.Object unlockable4 = container.unlockable;
						GameObject gameObject7 = extraInformation.gameObject;
						gameObject7.SetActive(value: true);
						if (container.unlockable != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v274 @ rbx_v7 (UnityEngine.Component)+30]");
							GameObject gameObject8 = ((Component)0).gameObject;
							gameObject8.SetActive(value: false);
							if ((object)container.unlockable != null)
							{
								nint num4 = (nint)typeof(WeaponData);
								nint num5 = (nint)unlockable4;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1332 @ rcx_v67 (Il2CppClass<WeaponData>)+130]");
								object obj2 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1395 @ rdx_v60 (Il2CppClass<UnityEngine.Object>)+130]");
								nint num6 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1332 @ rcx_v67 (Il2CppClass<WeaponData>)+130]");
								if (num6 >= 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1395 @ rdx_v60 (Il2CppClass<UnityEngine.Object>)+C8]");
									object obj3 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1410 @ rax_v85+FFFFFFF8+v1396 @ rax_v80*8]");
									if (0 == (nint)typeof(WeaponData))
									{
										extraInformation.SetInfoWeapon((WeaponData)container.unlockable);
										return;
									}
								}
								nint num7 = (nint)typeof(CharacterData);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1326 @ rdx_v61 (Il2CppClass<CharacterData>)+130]");
								object obj4 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1395 @ rdx_v60 (Il2CppClass<UnityEngine.Object>)+130]");
								nint num8 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1326 @ rdx_v61 (Il2CppClass<CharacterData>)+130]");
								if (num8 >= 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1395 @ rdx_v60 (Il2CppClass<UnityEngine.Object>)+C8]");
									object obj5 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1329 @ rax_v83+FFFFFFF8+v1328 @ rax_v82*8]");
									if (0 == (nint)typeof(CharacterData))
									{
										extraInformation.SetCharacterInformation((CharacterData)container.unlockable);
										return;
									}
								}
							}
						}
						component3 = extraInformation;
						goto IL_0855;
					}
					int price = container.unlockable.GetPrice();
					string text4 = num.ToString();
					string text5 = "<sprite name=silver> " + text4;
					t_buyPrice.text = text5;
					GameObject gameObject9 = t_unlockDescription.gameObject;
					gameObject9.SetActive(value: false);
					GameObject gameObject10 = this.requirementsContainer.gameObject;
					gameObject10.SetActive(value: true);
					this.requirementsContainer.Set(container.unlockable);
					RequirementsContainer requirementsContainer = this.requirementsContainer;
					RequirementPrefab[] array2 = requirementsContainer.reqContainers;
					object obj6 = 0;
					object obj7 = 0;
					while ((nint)obj6 < array2.Length)
					{
						RequirementPrefab requirementPrefab = array2[obj7];
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1831720E0]");
						if ((nint)0 == 0)
						{
							_ = 1;
						}
						requirementPrefab.progress.SetActive(value: false);
						requirementPrefab.t_progress.text = "";
						obj7++;
						obj6 = obj7;
					}
					RectTransform component4 = this.requirementsContainer.GetComponent<RectTransform>();
					component4.anchoredPosition = reqContainerPosSmall;
					sizeDelta = reqContainerScaleSmall;
					rectTransform = component4;
				}
				rectTransform.sizeDelta = sizeDelta;
				return;
			}
		}
		GameObject gameObject11 = t_unlockDescription.gameObject;
		gameObject11.SetActive(value: true);
		GameObject gameObject12 = t_unlockName.gameObject;
		gameObject12.SetActive(value: true);
		t_unlockName.text = "???";
		t_unlockDescription.text = "";
		t_suggestedBy.text = "";
		buyContainer.SetActive(value: false);
		GameObject gameObject13 = this.requirementsContainer.gameObject;
		gameObject13.SetActive(value: false);
		component3 = extraInformation;
		goto IL_0855;
		IL_0855:
		GameObject gameObject14 = component3.gameObject;
		gameObject14.SetActive(value: false);
	}

	private void OnUnlockClicked(UnlockContainer container)
	{
		GameObject gameObject = buyButton.gameObject;
		if (gameObject.activeInHierarchy)
		{
			ButtonManager.ForceHoverButton(buyButton);
		}
	}

	public unsafe void TryBuyUnlockable()
	{
		//IL_006f: Expected I, but got O
		//IL_00a0: Expected O, but got I
		//IL_04cc: Expected O, but got Ref
		//IL_04fa: Expected O, but got Ref
		//IL_04fa: Expected O, but got Ref
		//IL_01e3: Expected I, but got O
		//IL_0214: Expected O, but got I
		//IL_023e: Expected O, but got I
		//IL_0273: Expected O, but got Ref
		//IL_0304: Expected O, but got I
		//IL_0323: Expected O, but got I
		//IL_0382: Expected O, but got I
		//IL_03af: Expected I, but got O
		UnlockContainer unlockContainer = lastSelected;
		bool flag = (object)lastSelected == null;
		UnlocksFooter unlocksFooter = this;
		if (!flag)
		{
			bool flag2 = (object)unlockContainer.unlockable == null;
			unlocksFooter = this;
			if (!flag2)
			{
				if (unlockContainer.unlockable.CanBuy())
				{
					nint num = (nint)typeof(SaveManager);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v520 @ rax_v26 (Il2CppClass<SaveManager>)+B8]");
					nint num2 = 0;
					SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
					bool flag3 = (object)SaveManager._003CInstance_003Ek__BackingField == null;
					unlocksFooter = (UnlocksFooter)num2;
					if (!flag3)
					{
						bool flag4 = saveManager.progression == null;
						unlocksFooter = (UnlocksFooter)(object)saveManager.progression;
						if (!flag4)
						{
							if (!saveManager.progression.PurchaseUnlockable(unlockContainer.unlockable))
							{
								return;
							}
							bool flag5 = (object)parentWindow == null;
							unlocksFooter = (UnlocksFooter)(object)parentWindow;
							if (!flag5)
							{
								parentWindow.FindAllButtonsInWindow();
								bool flag6 = (object)lastSelected == null;
								unlocksFooter = (UnlocksFooter)(object)lastSelected;
								if (!flag6)
								{
									MyButton component = lastSelected.GetComponent<MyButton>();
									ButtonManager.ForceHoverButton(component);
									bool flag7 = (object)buyContainer == null;
									unlocksFooter = (UnlocksFooter)(object)buyContainer;
									if (!flag7)
									{
										buyContainer.SetActive(value: false);
										Refresh(this.unlockContainer);
										nint num3 = (nint)typeof(DataManager);
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ rax_v36 (Il2CppClass<DataManager>)+B8]");
										nint num4 = 0;
										DataManager instance = DataManager.Instance;
										bool flag8 = (object)DataManager.Instance == null;
										unlocksFooter = (UnlocksFooter)num4;
										if (!flag8)
										{
											bool flag9 = instance.unsortedCharacterData == null;
											unlocksFooter = (UnlocksFooter)num4;
											if (!flag9)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
												List<object>.Enumerator enumerator = default(List<object>.Enumerator);
												UnlocksFooter unlocksFooter2 = default(UnlocksFooter);
												object obj = default(object);
												string item = default(string);
												while (true)
												{
													if (enumerator.MoveNext())
													{
														bool flag10 = (object)unlocksFooter2 == null;
														unlocksFooter = (UnlocksFooter)(&enumerator);
														if (!flag10)
														{
															if (((MonoBehaviour)unlocksFooter2).m_CancellationTokenSource == null || !((UnityEngine.Object)unlocksFooter2.reqContainerPosDefault == unlockContainer.unlockable))
															{
																continue;
															}
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v668 @ stack_-58 (UnlocksFooter)+B0]");
															bool flag11 = (nint)0 == 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v668 @ stack_-58 (UnlocksFooter)+B0]");
															unlocksFooter = (UnlocksFooter)0;
															if (!flag11)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v668 @ stack_-58 (UnlocksFooter)+B0]");
																if (((MyAchievement)0).IsCompleted())
																{
																	Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803311C0");
																	bool flag12 = obj == null;
																	unlocksFooter = null;
																	if (flag12)
																	{
																		throw new NullReferenceException();
																	}
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v317 @ rax_v48+30]");
																	unlocksFooter = (UnlocksFooter)0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v317 @ rax_v48+30]");
																	if ((nint)0 == 0)
																	{
																		throw new NullReferenceException();
																	}
																	nint num5 = (nint)unlocksFooter2;
																	Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v756 @ rax_v49 (Il2CppClass<UnlocksFooter>)+1F8] (should have been resolved before IL gen)");
																	bool flag13 = (object)unlocksFooter2.t_buyPrice == null;
																	unlocksFooter = unlocksFooter2;
																	if (flag13)
																	{
																		break;
																	}
																	bool flag14 = ((HashSet<string>)(object)unlocksFooter2.t_buyPrice).Add(item);
																}
																continue;
															}
															throw new NullReferenceException();
														}
														throw new NullReferenceException();
													}
													((List<CharacterData>.Enumerator*)(&enumerator))->Dispose();
													Action<UnlockableBase> a_Purchased = A_Purchased;
													if (A_Purchased != null)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v624 @ rax_v42 (System.Action`1<Assets.Scripts.Saves___Serialization.Progression.Achievements.UnlockableBase>)+18] (should have been resolved before IL gen)");
													}
													return;
												}
												throw new NullReferenceException();
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
					AlwaysUi instance2 = AlwaysUi.Instance;
					if ((object)AlwaysUi.Instance != null)
					{
						string localizedString = LocalizationUtility.GetLocalizedString("PopupText", "CANT_AFFORD_SILVER");
						if ((object)buyButton != null)
						{
							Transform transform = buyButton.transform;
							if ((object)transform != null)
							{
								Vector3 position = transform.position;
								bool flag15 = (object)instance2.UiTextPopup == null;
								object obj2 = default(object);
								unlocksFooter = (UnlocksFooter)(&obj2);
								if (!flag15)
								{
									float num6 = default(float);
									List<object>.Enumerator enumerator2 = default(List<object>.Enumerator);
									float desiredScale = default(float);
									instance2.UiTextPopup.SetText(localizedString, (Vector3)(&num6), (Color)(&enumerator2), desiredScale);
									return;
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public UnlocksFooter()
	{
		//IL_000b: Expected O, but got I4
		//IL_0020: Expected O, but got I4
		//IL_0035: Expected O, but got I4
		//IL_0046: Expected O, but got I4
		reqContainerPosDefault = (Vector2)1143308288;
		_ = 3267887104L;
		reqContainerPosSmall = (Vector2)1141686272;
		_ = 3267887104L;
		reqContainerScaleDefault = (Vector2)1148846080;
		_ = 1117388800;
		reqContainerScaleSmall = (Vector2)1145569280;
		_ = 1117388800;
		base._002Ector();
	}
}
