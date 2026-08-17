using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Menu.Shop;
using Assets.Scripts.Saves___Serialization.Progression.Stats;
using Assets.Scripts.Saves___Serialization.Progression.Unlocks;
using Assets.Scripts.Saves___Serialization.SaveFiles;
using Assets.Scripts.UI.Localization;
using Assets.Scripts.UI.Mouse;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

public class ChallengesUi : Window
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Func<ChallengeData, bool> _003C_003E9__18_0;

		public static Comparison<ChallengeData> _003C_003E9__18_1;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal bool _003CRefresh_003Eb__18_0(ChallengeData a)
		{
			//IL_0035: Expected I4, but got O
			if ((object)a != null)
			{
				return a.isEnabled;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		internal unsafe int _003CRefresh_003Eb__18_1(ChallengeData a, ChallengeData b)
		{
			//IL_0071: Expected I4, but got O
			//IL_0043: Unknown result type (might be due to invalid IL or missing references)
			//IL_0048: Expected I4, but got Unknown
			if ((object)a != null && (object)b != null)
			{
				int num = a + 88;
				return ((int*)num)->CompareTo(b.sortingOrder);
			}
			NullReferenceException ex = new NullReferenceException();
			return (int)ex;
		}
	}

	public GameObject challengeButtonPrefab;

	public SelectionGroupToggleSingle challengesSelectionGroup;

	private List<SelectionGroupToggleSingleButtonChallenge> challengeButtons;

	public MapSelectionUi mapSelectionUi;

	public MyButton btn_confirm;

	private SelectionGroupToggleSingleButton hoverBtn;

	private Color completedColor;

	private Color notCompletedColor;

	public TextMeshProUGUI t_name;

	public TextMeshProUGUI t_stats;

	public TextMeshProUGUI t_description;

	public TextMeshProUGUI t_silver;

	public TextMeshProUGUI t_completed;

	public TextMeshProUGUI t_author;

	public TextMeshProUGUI t_header;

	public TextMeshProUGUI t_winCondition;

	public TextMeshProUGUI t_reward;

	public TextMeshProUGUI t_leaderboards;

	private new void Awake()
	{
		//IL_0085: Expected O, but got I4
		//IL_008e: Expected O, but got I4
		//IL_009c: Expected I, but got O
		//IL_00e9: Expected O, but got I4
		//IL_00f2: Expected O, but got I4
		//IL_0100: Expected I, but got O
		//IL_0193: Expected O, but got I4
		//IL_019c: Expected O, but got I4
		//IL_01aa: Expected I, but got O
		base.Awake();
		SelectionGroupToggleSingle selectionGroupToggleSingle = challengesSelectionGroup;
		Action<SelectionGroupToggleSingleButton> b = OnChallengeSelected;
		Delegate obj = Delegate.Combine(selectionGroupToggleSingle.A_ButtonSelected, b);
		Delegate obj6;
		object obj2;
		object obj3;
		nint num;
		Delegate obj4;
		if ((object)obj == null)
		{
			selectionGroupToggleSingle.A_ButtonSelected = (Action<SelectionGroupToggleSingleButton>)obj;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<SelectionGroupToggleSingleButton> action = default(Action<SelectionGroupToggleSingleButton>);
			bool flag = action == null;
			obj2 = 0;
			obj3 = 0;
			num = (nint)typeof(Action<SelectionGroupToggleSingleButton>);
			obj4 = obj;
			if (flag)
			{
				goto IL_01fe;
			}
			selectionGroupToggleSingle.A_ButtonSelected = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag2 = obj5 == null;
			obj6 = obj;
			obj2 = 0;
			obj3 = 0;
			num = (nint)typeof(Action<SelectionGroupToggleSingleButton>);
			if (flag2)
			{
				goto IL_0209;
			}
		}
		Action<SelectionGroupToggleSingleButtonChallenge> b2 = OnChallengeHovered;
		Delegate obj7 = Delegate.Combine(SelectionGroupToggleSingleButtonChallenge.A_ChallengeHovered, b2);
		if ((object)obj7 == null)
		{
			SelectionGroupToggleSingleButtonChallenge.A_ChallengeHovered = (Action<SelectionGroupToggleSingleButtonChallenge>)obj7;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<SelectionGroupToggleSingleButtonChallenge> action2 = default(Action<SelectionGroupToggleSingleButtonChallenge>);
		bool flag3 = action2 == null;
		obj6 = obj7;
		obj2 = 0;
		obj3 = 0;
		num = (nint)typeof(Action<SelectionGroupToggleSingleButtonChallenge>);
		if (!flag3)
		{
			SelectionGroupToggleSingleButtonChallenge.A_ChallengeHovered = action2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj8 = default(object);
			if (obj8 != null)
			{
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			Delegate obj9 = default(Delegate);
			obj6 = obj9;
			object obj10 = default(object);
			obj2 = obj10;
			object obj11 = default(object);
			obj3 = obj11;
			IntPtr intPtr = default(IntPtr);
			num = intPtr;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0209;
		IL_0209:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		obj4 = obj6;
		goto IL_01fe;
		IL_01fe:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	private new void Start()
	{
		//IL_00e3: Expected I, but got O
		//IL_00f9: Expected O, but got I
		//IL_021f: Expected O, but got I
		//IL_013d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0142: Expected O, but got Unknown
		//IL_0171: Expected I, but got O
		//IL_01c7: Expected I, but got O
		base.Start();
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		bool flag = dictionary == null;
		nint num = 0;
		Dictionary<string, string> dictionary2 = dictionary;
		if (!flag)
		{
			((Dictionary<object, object>)(object)dictionary).Add((object)"reward_icon", (object)"<size=115%><sprite name=silver></size>");
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
			object arg = default(object);
			string value = $"+{arg}%";
			((Dictionary<object, object>)(object)dictionary).Add((object)"value", (object)value);
			LocalizedString localizedStringReference = LocalizationUtility.GetLocalizedStringReference("ChallengesUi", "REWARD");
			object[] array = new object[1];
			bool flag2 = array == null;
			string text = null;
			num = 1;
			dictionary2 = (Dictionary<string, string>)(object)typeof(object[]);
			if (!flag2)
			{
				nint num2 = (nint)array;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v225 @ rdx_v13 (Il2CppClass<System.Object[]>)+40]");
				dictionary.Add((string)0, null);
				object obj = default(object);
				bool flag3 = obj == null;
				text = null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v225 @ rdx_v13 (Il2CppClass<System.Object[]>)+40]");
				num = 0;
				dictionary2 = dictionary;
				if (flag3)
				{
					dictionary2.Add((string)num, text);
					object obj2 = default(object);
					throw obj2;
				}
				dictionary2 = (Dictionary<string, string>)(array + 32);
				array[0] = dictionary;
				bool flag4 = localizedStringReference == null;
				text = null;
				num = (nint)dictionary;
				if (!flag4)
				{
					string localizedString = localizedStringReference.GetLocalizedString(array);
					string text2 = localizedString + ":";
					bool flag5 = (object)t_reward == null;
					text = null;
					num = unchecked((nint)":");
					dictionary2 = (Dictionary<string, string>)(object)localizedString;
					if (!flag5)
					{
						t_reward.text = text2;
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private new void OnDestroy()
	{
		//IL_0085: Expected O, but got I4
		//IL_008e: Expected O, but got I4
		//IL_009c: Expected I, but got O
		//IL_00e9: Expected O, but got I4
		//IL_00f2: Expected O, but got I4
		//IL_0100: Expected I, but got O
		//IL_0193: Expected O, but got I4
		//IL_019c: Expected O, but got I4
		//IL_01aa: Expected I, but got O
		base.OnDestroy();
		SelectionGroupToggleSingle selectionGroupToggleSingle = challengesSelectionGroup;
		Action<SelectionGroupToggleSingleButton> value = OnChallengeSelected;
		Delegate obj = Delegate.Remove(selectionGroupToggleSingle.A_ButtonSelected, value);
		Delegate obj6;
		object obj2;
		object obj3;
		nint num;
		Delegate obj4;
		if ((object)obj == null)
		{
			selectionGroupToggleSingle.A_ButtonSelected = (Action<SelectionGroupToggleSingleButton>)obj;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<SelectionGroupToggleSingleButton> action = default(Action<SelectionGroupToggleSingleButton>);
			bool flag = action == null;
			obj2 = 0;
			obj3 = 0;
			num = (nint)typeof(Action<SelectionGroupToggleSingleButton>);
			obj4 = obj;
			if (flag)
			{
				goto IL_01fe;
			}
			selectionGroupToggleSingle.A_ButtonSelected = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag2 = obj5 == null;
			obj6 = obj;
			obj2 = 0;
			obj3 = 0;
			num = (nint)typeof(Action<SelectionGroupToggleSingleButton>);
			if (flag2)
			{
				goto IL_0209;
			}
		}
		Action<SelectionGroupToggleSingleButtonChallenge> value2 = OnChallengeHovered;
		Delegate obj7 = Delegate.Remove(SelectionGroupToggleSingleButtonChallenge.A_ChallengeHovered, value2);
		if ((object)obj7 == null)
		{
			SelectionGroupToggleSingleButtonChallenge.A_ChallengeHovered = (Action<SelectionGroupToggleSingleButtonChallenge>)obj7;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<SelectionGroupToggleSingleButtonChallenge> action2 = default(Action<SelectionGroupToggleSingleButtonChallenge>);
		bool flag3 = action2 == null;
		obj6 = obj7;
		obj2 = 0;
		obj3 = 0;
		num = (nint)typeof(Action<SelectionGroupToggleSingleButtonChallenge>);
		if (!flag3)
		{
			SelectionGroupToggleSingleButtonChallenge.A_ChallengeHovered = action2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj8 = default(object);
			if (obj8 != null)
			{
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			Delegate obj9 = default(Delegate);
			obj6 = obj9;
			object obj10 = default(object);
			obj2 = obj10;
			object obj11 = default(object);
			obj3 = obj11;
			IntPtr intPtr = default(IntPtr);
			num = intPtr;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0209;
		IL_0209:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		obj4 = obj6;
		goto IL_01fe;
		IL_01fe:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	private unsafe void OnChallengeHovered(SelectionGroupToggleSingleButtonChallenge btn)
	{
		//IL_0c06: Expected O, but got I
		//IL_0146: Expected O, but got I4
		//IL_01cb: Expected O, but got I4
		//IL_0239: Expected I, but got O
		//IL_02cd: Expected O, but got I
		//IL_02ec: Expected O, but got I
		//IL_033e: Expected O, but got I
		//IL_03a7: Expected I, but got O
		//IL_03b7: Expected O, but got I
		//IL_03d6: Expected O, but got I
		//IL_04f2: Expected O, but got I
		//IL_050d: Expected O, but got I
		//IL_0743: Expected O, but got I
		//IL_0578: Expected O, but got I
		//IL_0789: Expected O, but got I
		//IL_05a8: Expected O, but got I
		//IL_05bd: Expected O, but got I
		//IL_05cd: Expected O, but got I
		//IL_07df: Expected O, but got I
		//IL_05f4: Expected I, but got O
		//IL_0615: Expected O, but got I
		//IL_0615: Expected O, but got I
		//IL_062a: Expected O, but got I
		//IL_063a: Expected O, but got I
		//IL_064a: Expected O, but got I
		//IL_080f: Expected I, but got O
		//IL_081f: Expected O, but got I
		//IL_0839: Expected O, but got I
		//IL_084e: Expected O, but got I
		//IL_0669: Unknown result type (might be due to invalid IL or missing references)
		//IL_066e: Expected O, but got Unknown
		//IL_0695: Expected O, but got I
		//IL_06a5: Expected O, but got I
		//IL_0876: Unknown result type (might be due to invalid IL or missing references)
		//IL_087b: Expected O, but got Unknown
		//IL_08a2: Expected O, but got I
		//IL_06e3: Expected O, but got I
		//IL_08e9: Expected O, but got I
		//IL_0b0d: Expected O, but got I
		//IL_09d0: Expected O, but got I
		//IL_0b50: Expected I, but got O
		//IL_0b6a: Expected O, but got I
		//IL_0b97: Expected O, but got Ref
		//IL_0a13: Expected I, but got O
		//IL_0a2d: Expected O, but got I
		//IL_0a5a: Expected O, but got Ref
		//IL_0bb5: Expected O, but got I
		//IL_0d1f: Expected I, but got O
		//IL_0a78: Expected O, but got I
		bool flag = (object)btn == null;
		IntPtr intPtr = default(IntPtr);
		string text = (string)(nint)intPtr;
		UnityEngine.Object obj = btn;
		UnityEngine.Object obj2 = this;
		TextMeshProUGUI textMeshProUGUI;
		UnityEngine.Object obj5;
		if (!flag)
		{
			UnityEngine.Object obj3 = btn._003CchallengeData_003Ek__BackingField;
			hoverBtn = btn;
			if (!(btn._003CchallengeData_003Ek__BackingField != null))
			{
				SetEmpty();
				return;
			}
			bool flag2 = (object)btn._003CchallengeData_003Ek__BackingField == null;
			text = null;
			obj = null;
			obj2 = btn._003CchallengeData_003Ek__BackingField;
			if (!flag2)
			{
				if (!btn._003CchallengeData_003Ek__BackingField.CanShow())
				{
					SetHidden(btn._003CchallengeData_003Ek__BackingField);
					return;
				}
				bool flag3 = (object)t_completed == null;
				text = null;
				obj = null;
				obj2 = t_completed;
				if (!flag3)
				{
					GameObject gameObject = t_completed.gameObject;
					bool flag4 = (object)gameObject == null;
					text = null;
					obj = null;
					obj2 = t_completed;
					if (!flag4)
					{
						gameObject.SetActive(value: true);
						bool flag5 = (object)t_reward == null;
						text = null;
						obj = (UnityEngine.Object)1;
						obj2 = t_reward;
						if (!flag5)
						{
							GameObject gameObject2 = t_reward.gameObject;
							bool flag6 = (object)gameObject2 == null;
							text = null;
							obj = null;
							obj2 = t_reward;
							if (!flag6)
							{
								gameObject2.SetActive(value: true);
								bool flag7 = (object)t_leaderboards == null;
								text = null;
								obj = (UnityEngine.Object)1;
								obj2 = t_leaderboards;
								if (!flag7)
								{
									GameObject gameObject3 = t_leaderboards.gameObject;
									bool flag8 = (object)gameObject3 == null;
									text = null;
									obj = null;
									obj2 = t_leaderboards;
									if (!flag8)
									{
										gameObject3.SetActive(value: true);
										nint num = (nint)obj3;
										Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v791 @ rax_v25 (Il2CppClass<UnityEngine.Object>)+188] (should have been resolved before IL gen)");
										UnityEngine.Object obj4 = default(UnityEngine.Object);
										bool flag9 = (object)obj4 == null;
										obj = (UnityEngine.Object)(object)"";
										if (!flag9)
										{
											obj = obj4;
										}
										bool flag10 = (object)t_name == null;
										text = null;
										obj2 = btn._003CchallengeData_003Ek__BackingField;
										if (!flag10)
										{
											t_name.text = (string)(object)obj;
											UpdateStatsText(btn._003CchallengeData_003Ek__BackingField);
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rsi_v5 (UnityEngine.Object)+20]");
											bool flag11 = (nint)0 == 0;
											text = null;
											obj = btn._003CchallengeData_003Ek__BackingField;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rsi_v5 (UnityEngine.Object)+20]");
											obj2 = (UnityEngine.Object)0;
											if (!flag11)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rsi_v5 (UnityEngine.Object)+20]");
												bool isEmpty = ((LocalizedReference)0).IsEmpty;
												textMeshProUGUI = t_description;
												if (isEmpty)
												{
													bool flag12 = (object)t_description == null;
													text = null;
													obj = null;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rsi_v5 (UnityEngine.Object)+20]");
													obj2 = (UnityEngine.Object)0;
													if (!flag12)
													{
														obj5 = (UnityEngine.Object)(object)"";
														goto IL_039f;
													}
												}
												else
												{
													string unlockDescription = btn._003CchallengeData_003Ek__BackingField.GetUnlockDescription();
													bool flag13 = unlockDescription == null;
													obj5 = (UnityEngine.Object)(object)"";
													if (!flag13)
													{
														obj5 = (UnityEngine.Object)(object)unlockDescription;
													}
													bool flag14 = (object)t_description == null;
													text = null;
													obj = obj5;
													obj2 = btn._003CchallengeData_003Ek__BackingField;
													if (!flag14)
													{
														goto IL_039f;
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
		goto IL_0be3;
		IL_039f:
		nint num2 = (nint)textMeshProUGUI;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v849 @ rax_v32 (Il2CppClass<TMPro.TextMeshProUGUI>)+560]");
		text = (string)0;
		t_description.text = (string)(object)obj5;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rsi_v5 (UnityEngine.Object)+B0]");
		obj2 = (UnityEngine.Object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rsi_v5 (UnityEngine.Object)+B0]");
		bool flag15 = (nint)0 == 0;
		obj = obj5;
		if (!flag15)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180381570");
			UnityEngine.Object obj6 = default(UnityEngine.Object);
			bool flag16 = (object)obj6 == null;
			obj = (UnityEngine.Object)(object)"";
			if (!flag16)
			{
				obj = obj6;
			}
			if ((object)t_winCondition != null)
			{
				t_winCondition.text = (string)(object)obj;
				TextMeshProUGUI textMeshProUGUI2 = t_silver;
				string silverMultiplier = btn._003CchallengeData_003Ek__BackingField.GetSilverMultiplier();
				string statName = LocalizationUtility.GetStatName(EStat.SilverIncreaseMultiplier);
				string text2 = "<sprite name=silver> <size=90%>" + silverMultiplier + "x " + statName;
				bool flag17 = (object)t_silver == null;
				string text3 = statName;
				text = "x ";
				obj = (UnityEngine.Object)(object)silverMultiplier;
				obj2 = (UnityEngine.Object)(object)"<sprite name=silver> <size=90%>";
				if (!flag17)
				{
					text3 = (string)(object)textMeshProUGUI2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v645 @ r9_v13 (System.String)+560]");
					text = (string)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v645 @ r9_v13 (System.String)+558] (should have been resolved before IL gen)");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rsi_v5 (UnityEngine.Object)+90]");
					bool flag18 = string.IsNullOrEmpty((string)0);
					TextMeshProUGUI textMeshProUGUI3 = t_author;
					if (!flag18)
					{
						LocalizedString localizedStringReference = LocalizationUtility.GetLocalizedStringReference("ChallengesUi", "SUGGESTION");
						object[] array = new object[1];
						Dictionary<string, string> dictionary = new Dictionary<string, string>();
						bool flag19 = dictionary == null;
						text = null;
						obj = (UnityEngine.Object)0;
						obj2 = (UnityEngine.Object)(object)dictionary;
						if (!flag19)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rsi_v5 (UnityEngine.Object)+90]");
							((Dictionary<object, object>)(object)dictionary).Add((object)"name", (object)0);
							bool flag20 = array == null;
							text3 = (string)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rsi_v5 (UnityEngine.Object)+90]");
							text = (string)0;
							obj = (UnityEngine.Object)(object)"name";
							obj2 = (UnityEngine.Object)(object)dictionary;
							if (!flag20)
							{
								nint num3 = (nint)array;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v932 @ rdx_v60 (Il2CppClass<System.Object[]>)+40]");
								nint num4 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rsi_v5 (UnityEngine.Object)+90]");
								dictionary.Add((string)num4, (string)0);
								object obj7 = default(object);
								bool flag21 = obj7 == null;
								text3 = (string)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rsi_v5 (UnityEngine.Object)+90]");
								text = (string)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v932 @ rdx_v60 (Il2CppClass<System.Object[]>)+40]");
								obj = (UnityEngine.Object)0;
								obj2 = (UnityEngine.Object)(object)dictionary;
								if (flag21)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180269410");
									Dictionary<string, string> dictionary2 = default(Dictionary<string, string>);
									throw dictionary2;
								}
								obj2 = (UnityEngine.Object)(array + 32);
								array[0] = dictionary;
								bool flag22 = localizedStringReference == null;
								text3 = (string)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rsi_v5 (UnityEngine.Object)+90]");
								text = (string)0;
								obj = (UnityEngine.Object)(object)dictionary;
								if (!flag22)
								{
									string localizedString = localizedStringReference.GetLocalizedString(array);
									bool flag23 = (object)t_author == null;
									text3 = (string)0;
									text = null;
									obj = (UnityEngine.Object)(object)array;
									obj2 = (UnityEngine.Object)(object)localizedStringReference;
									if (!flag23)
									{
										text3 = (string)(object)textMeshProUGUI3;
										Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v645 @ r9_v13 (System.String)+558] (should have been resolved before IL gen)");
										goto IL_0cd3;
									}
								}
							}
						}
					}
					else
					{
						bool flag24 = (object)t_author == null;
						obj = null;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rsi_v5 (UnityEngine.Object)+90]");
						obj2 = (UnityEngine.Object)0;
						if (!flag24)
						{
							t_author.text = "";
							goto IL_0cd3;
						}
					}
				}
			}
		}
		goto IL_0be3;
		IL_0cd3:
		LocalizedString localizedStringReference2 = LocalizationUtility.GetLocalizedStringReference("ChallengesUi", "REWARD");
		object[] array2 = new object[1];
		Dictionary<string, string> dictionary3 = new Dictionary<string, string>();
		dictionary3._002Ector();
		bool flag25 = dictionary3 == null;
		text = null;
		obj = (UnityEngine.Object)0;
		obj2 = (UnityEngine.Object)(object)dictionary3;
		if (!flag25)
		{
			((Dictionary<object, object>)(object)dictionary3).Add((object)"reward_icon", (object)"<size=115%><sprite name=silver></size>");
			((Dictionary<object, object>)(object)dictionary3).Add((object)"value", (object)"+1%");
			bool flag26 = array2 == null;
			string text3 = (string)0;
			text = "+1%";
			obj = (UnityEngine.Object)(object)"value";
			obj2 = (UnityEngine.Object)(object)dictionary3;
			if (!flag26)
			{
				nint num5 = (nint)array2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v939 @ rdx_v39 (Il2CppClass<System.Object[]>)+40]");
				string text4 = (string)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v939 @ rdx_v39 (Il2CppClass<System.Object[]>)+40]");
				dictionary3.Add((string)0, "+1%");
				object obj8 = default(object);
				bool flag27 = obj8 == null;
				text3 = (string)0;
				text = "+1%";
				Dictionary<string, string> dictionary4 = dictionary3;
				if (flag27)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180269410");
					object obj9 = default(object);
					throw obj9;
				}
				obj2 = (UnityEngine.Object)(array2 + 32);
				array2[0] = dictionary3;
				bool flag28 = localizedStringReference2 == null;
				text3 = (string)0;
				text = "+1%";
				obj = (UnityEngine.Object)(object)dictionary3;
				if (!flag28)
				{
					string localizedString2 = localizedStringReference2.GetLocalizedString(array2);
					bool flag29 = (object)t_reward == null;
					text3 = (string)0;
					text = null;
					obj = (UnityEngine.Object)(object)array2;
					obj2 = (UnityEngine.Object)(object)localizedStringReference2;
					if (!flag29)
					{
						t_reward.text = localizedString2;
						bool flag30 = MyAchievements.IsUnlocked(btn._003CchallengeData_003Ek__BackingField);
						TextMeshProUGUI textMeshProUGUI4 = t_completed;
						Color color2 = default(Color);
						if (!flag30)
						{
							string localizedString3 = LocalizationUtility.GetLocalizedString("Other", "NOT_COMPLETED", "Not completed", useEnglishDefaultIfAvailable: false);
							string text5 = "<sprite name=x> <size=85%>" + localizedString3;
							bool flag31 = (object)t_completed == null;
							text3 = null;
							text = null;
							obj = (UnityEngine.Object)(object)localizedString3;
							obj2 = (UnityEngine.Object)(object)"<sprite name=x> <size=85%>";
							if (!flag31)
							{
								text3 = (string)(object)textMeshProUGUI4;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v645 @ r9_v13 (System.String)+560]");
								text = (string)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v645 @ r9_v13 (System.String)+558] (should have been resolved before IL gen)");
								obj2 = t_completed;
								bool flag32 = (object)t_completed == null;
								obj = (UnityEngine.Object)(object)text5;
								if (!flag32)
								{
									nint num6 = (nint)obj2;
									Color color = notCompletedColor;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v983 @ rax_v66 (Il2CppClass<UnityEngine.Object>)+2B0]");
									text = (string)0;
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v983 @ rax_v66 (Il2CppClass<UnityEngine.Object>)+2A8] (should have been resolved before IL gen)");
									obj2 = t_reward;
									bool flag33 = (object)t_reward == null;
									obj = (UnityEngine.Object)(&color2);
									if (!flag33)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262F120]");
										object obj10 = 0;
										color2 = notCompletedColor;
										goto IL_0d17;
									}
								}
							}
						}
						else
						{
							string localizedString4 = LocalizationUtility.GetLocalizedString("Other", "COMPLETED", "Completed", useEnglishDefaultIfAvailable: false);
							string text6 = "<sprite name=\"check\" tint> <size=85%>" + localizedString4;
							bool flag34 = (object)t_completed == null;
							text3 = null;
							text = null;
							obj = (UnityEngine.Object)(object)localizedString4;
							obj2 = (UnityEngine.Object)(object)"<sprite name=\"check\" tint> <size=85%>";
							if (!flag34)
							{
								text3 = (string)(object)textMeshProUGUI4;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v645 @ r9_v13 (System.String)+560]");
								text = (string)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v645 @ r9_v13 (System.String)+558] (should have been resolved before IL gen)");
								obj2 = t_completed;
								bool flag35 = (object)t_completed == null;
								obj = (UnityEngine.Object)(object)text6;
								if (!flag35)
								{
									nint num7 = (nint)obj2;
									Color color = completedColor;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v984 @ rax_v61 (Il2CppClass<UnityEngine.Object>)+2B0]");
									text = (string)0;
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v984 @ rax_v61 (Il2CppClass<UnityEngine.Object>)+2A8] (should have been resolved before IL gen)");
									obj2 = t_reward;
									bool flag36 = (object)t_reward == null;
									obj = (UnityEngine.Object)(&color2);
									if (!flag36)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED70]");
										object obj10 = 0;
										color2 = completedColor;
										goto IL_0d17;
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_0be3;
		IL_0d17:
		nint num8 = (nint)obj2;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v991 @ rax_v56 (Il2CppClass<UnityEngine.Object>)+2A8] (should have been resolved before IL gen)");
		return;
		IL_0be3:
		throw new NullReferenceException();
	}

	private unsafe void UpdateStatsText(ChallengeData challengeData)
	{
		//IL_000d: Expected I, but got O
		//IL_001d: Expected O, but got I
		//IL_002d: Expected O, but got I
		//IL_00ba: Expected O, but got I4
		//IL_00c4: Expected O, but got I4
		//IL_0b3a: Expected O, but got Ref
		//IL_02d4: Expected I, but got O
		//IL_015b: Expected O, but got I4
		//IL_02ea: Expected I, but got O
		//IL_030d: Expected I, but got O
		//IL_0256: Unknown result type (might be due to invalid IL or missing references)
		//IL_025b: Expected O, but got Unknown
		//IL_05d2: Expected I, but got O
		//IL_05ff: Expected I, but got O
		//IL_0362: Unknown result type (might be due to invalid IL or missing references)
		//IL_0367: Expected O, but got Unknown
		//IL_0615: Expected O, but got I
		//IL_03a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03aa: Expected O, but got Unknown
		//IL_0906: Expected I, but got O
		//IL_065a: Expected I, but got O
		//IL_0a91: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a96: Expected O, but got Unknown
		//IL_0683: Unknown result type (might be due to invalid IL or missing references)
		//IL_0688: Expected I, but got Unknown
		//IL_03cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d0: Expected O, but got Unknown
		//IL_06c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_06cb: Expected I, but got Unknown
		//IL_06ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f1: Expected I, but got Unknown
		//IL_0473: Unknown result type (might be due to invalid IL or missing references)
		//IL_0478: Expected O, but got Unknown
		//IL_04b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_04bb: Expected O, but got Unknown
		//IL_0510: Expected O, but got I4
		//IL_078c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0791: Expected I, but got Unknown
		//IL_0539: Unknown result type (might be due to invalid IL or missing references)
		//IL_053e: Expected O, but got Unknown
		//IL_07cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_07d4: Expected I, but got Unknown
		//IL_058d: Expected I, but got O
		//IL_0845: Unknown result type (might be due to invalid IL or missing references)
		//IL_084a: Expected I, but got Unknown
		List<StatModifier> list = (List<StatModifier>)(object)t_stats;
		if ((object)t_stats != null)
		{
			nint num = (nint)list;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B70]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rax_v53+B8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v122 @ r9_v27 (Il2CppClass<System.Collections.Generic.List`1<Assets.Scripts.Inventory__Items__Pickups.Stats.StatModifier>>)+558] (should have been resolved before IL gen)");
			List<StatModifier> list2 = new List<StatModifier>();
			List<StatModifier> list3 = new List<StatModifier>();
			bool flag = (object)challengeData == null;
			list = list3;
			if (!flag)
			{
				ChallengeModifier[] challengeModifiers = challengeData.challengeModifiers;
				bool flag2 = challengeData.challengeModifiers == null;
				list = list3;
				if (!flag2)
				{
					object obj3 = 0;
					object obj4 = 0;
					list = list3;
					List<object>.Enumerator enumerator = default(List<object>.Enumerator);
					object obj6 = default(object);
					StatModifier statModifier = default(StatModifier);
					object obj8 = default(object);
					string value = default(string);
					while (true)
					{
						if ((nint)obj4 < challengeModifiers.Length)
						{
							if ((nint)obj3 < challengeModifiers.Length)
							{
								ChallengeModifier challengeModifier = challengeModifiers[obj3];
								if ((object)challengeModifiers[obj3] == null)
								{
									break;
								}
								StatModifier[] statModifiers = challengeModifier.statModifiers;
								bool flag3 = challengeModifier.statModifiers == null;
								List<StatModifier> list4 = list;
								object obj5 = 0;
								if (flag3)
								{
									break;
								}
								while ((nint)obj5 < statModifiers.Length)
								{
									bool flag4 = (nint)obj5 >= statModifiers.Length;
									list = list4;
									if (!flag4)
									{
										List<StatModifier> list5;
										if (!IsNegativeModifier(statModifiers[obj5]))
										{
											bool flag5 = list3 == null;
											list = (List<StatModifier>)(object)statModifiers[obj5];
											if (flag5)
											{
												goto end_IL_0aa4;
											}
											list5 = list3;
										}
										else
										{
											bool flag6 = list2 == null;
											list = (List<StatModifier>)(object)statModifiers[obj5];
											if (flag6)
											{
												goto end_IL_0aa4;
											}
											list5 = list2;
										}
										list5.Add(statModifiers[obj5]);
										obj5++;
										list4 = list5;
										continue;
									}
									goto IL_0a67;
								}
								obj3++;
								obj4 = obj3;
								list = list4;
								continue;
							}
							goto IL_0a67;
						}
						if (list3 == null)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
						while (enumerator.MoveNext())
						{
							List<StatModifier> list6 = (List<StatModifier>)(object)t_stats;
							string[] array = new string[8];
							bool flag7 = (object)t_stats == null;
							nint num2 = (nint)typeof(string[]);
							if (!flag7)
							{
								nint num3 = (nint)list6;
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v362 @ r8_v37 (Il2CppClass<System.Collections.Generic.List`1<Assets.Scripts.Inventory__Items__Pickups.Stats.StatModifier>>)+548] (should have been resolved before IL gen)");
								bool flag8 = array == null;
								num2 = (nint)t_stats;
								if (!flag8)
								{
									bool flag9 = array.Length <= 0;
									list = (List<StatModifier>)(object)t_stats;
									if (!flag9)
									{
										array[0] = (string)obj6;
										list = (List<StatModifier>)(array + 32);
										if (array.Length > 1)
										{
											array[1] = "<color=";
											list = (List<StatModifier>)(array + 40);
											if (array.Length > 2)
											{
												array[2] = MyColorUtility.positiveColorString;
												list = (List<StatModifier>)(array + 48);
												if (array.Length > 3)
												{
													array[3] = ">";
													string modificationString = StatUtility.GetModificationString(statModifier, addOneToMultiplication: false);
													string text = StatUtility.EncapsulateNumber(modificationString, MyColorUtility.positiveColorString);
													bool flag10 = array.Length <= 4;
													list = (List<StatModifier>)(object)modificationString;
													if (!flag10)
													{
														array[4] = text;
														list = (List<StatModifier>)(array + 64);
														if (array.Length > 5)
														{
															array[5] = " ";
															list = (List<StatModifier>)(array + 72);
															if (statModifier != null)
															{
																string tooltipString = Tooltip.GetTooltipString(statModifier.stat, MyColorUtility.positiveColorString);
																bool flag11 = array.Length <= 6;
																list = (List<StatModifier>)statModifier.stat;
																if (!flag11)
																{
																	array[6] = tooltipString;
																	list = (List<StatModifier>)(array + 80);
																	if (array.Length > 7)
																	{
																		array[7] = "\n";
																		string text2 = string.Concat(array);
																		nint num4 = (nint)list6;
																		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v788 @ r9_v29 (Il2CppClass<System.Collections.Generic.List`1<Assets.Scripts.Inventory__Items__Pickups.Stats.StatModifier>>)+558] (should have been resolved before IL gen)");
																		num = num4;
																		continue;
																	}
																	throw new IndexOutOfRangeException();
																}
																throw new IndexOutOfRangeException();
															}
															throw new NullReferenceException();
														}
														throw new IndexOutOfRangeException();
													}
													throw new IndexOutOfRangeException();
												}
												throw new IndexOutOfRangeException();
											}
											throw new IndexOutOfRangeException();
										}
										throw new IndexOutOfRangeException();
									}
									throw new IndexOutOfRangeException();
								}
								throw new NullReferenceException();
							}
							throw new NullReferenceException();
						}
						((List<StatModifier>.Enumerator*)(&enumerator))->Dispose();
						bool flag12 = list2 == null;
						list = (List<StatModifier>)(&enumerator);
						if (flag12)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
						nint num5 = 0;
						while (enumerator.MoveNext())
						{
							nint num6 = (nint)t_stats;
							string[] array2 = new string[8];
							bool flag13 = (object)t_stats == null;
							nint num7 = (nint)typeof(string[]);
							if (!flag13)
							{
								object obj7 = num6;
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1364 @ rax_v75+548] (should have been resolved before IL gen)");
								if (array2 != null)
								{
									bool flag14 = array2.Length <= 0;
									nint num2 = (nint)t_stats;
									if (!flag14)
									{
										array2[0] = (string)obj8;
										num2 = (nint)(array2 + 32);
										if (array2.Length > 1)
										{
											array2[1] = "<color=";
											num2 = (nint)(array2 + 40);
											if (array2.Length > 2)
											{
												array2[2] = MyColorUtility.negativeColorString;
												num2 = (nint)(array2 + 48);
												if (array2.Length > 3)
												{
													array2[3] = ">";
													string modificationString2 = StatUtility.GetModificationString(statModifier, addOneToMultiplication: false);
													string text3 = StatUtility.EncapsulateNumber(modificationString2, MyColorUtility.negativeColorString);
													if (array2.Length > 4)
													{
														array2[4] = text3;
														num2 = (nint)(array2 + 64);
														if (array2.Length > 5)
														{
															array2[5] = " ";
															num7 = (nint)(array2 + 72);
															if (statModifier != null)
															{
																string tooltipString2 = Tooltip.GetTooltipString(statModifier.stat, MyColorUtility.negativeColorString);
																if (array2.Length > 6)
																{
																	array2[6] = tooltipString2;
																	num2 = (nint)(array2 + 80);
																	if (array2.Length > 7)
																	{
																		array2[7] = "\n";
																		string text4 = string.Concat(array2);
																		num = num6;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ r9_v27 (Il2CppClass<System.Collections.Generic.List`1<Assets.Scripts.Inventory__Items__Pickups.Stats.StatModifier>>)+560]");
																		num5 = 0;
																		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v122 @ r9_v27 (Il2CppClass<System.Collections.Generic.List`1<Assets.Scripts.Inventory__Items__Pickups.Stats.StatModifier>>)+558] (should have been resolved before IL gen)");
																		continue;
																	}
																	throw new IndexOutOfRangeException();
																}
																throw new IndexOutOfRangeException();
															}
															throw new NullReferenceException();
														}
														throw new IndexOutOfRangeException();
													}
													throw new IndexOutOfRangeException();
												}
												throw new IndexOutOfRangeException();
											}
											throw new IndexOutOfRangeException();
										}
										throw new IndexOutOfRangeException();
									}
									throw new IndexOutOfRangeException();
								}
								throw new NullReferenceException();
							}
							throw new NullReferenceException();
						}
						((List<StatModifier>.Enumerator*)(&enumerator))->Dispose();
						bool flag15 = (object)t_stats == null;
						list = (List<StatModifier>)(object)t_stats;
						if (flag15)
						{
							break;
						}
						GameObject gameObject = t_stats.gameObject;
						list = (List<StatModifier>)(object)t_stats;
						if ((object)t_stats == null)
						{
							break;
						}
						nint num8 = (nint)list;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v111 @ r8_v31 (Il2CppClass<System.Collections.Generic.List`1<Assets.Scripts.Inventory__Items__Pickups.Stats.StatModifier>>)+548] (should have been resolved before IL gen)");
						bool flag16 = string.IsNullOrEmpty(value);
						if ((object)gameObject == null)
						{
							break;
						}
						bool active = (byte)((flag16 ? 1u : 0u) ^ 1u) != 0;
						gameObject.SetActive(active);
						return;
						IL_0a67:
						throw new IndexOutOfRangeException();
						continue;
						end_IL_0aa4:
						break;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public static bool IsNegativeModifier(StatModifier statModifier)
	{
		//IL_0162: Expected I4, but got O
		//IL_00b9: Invalid comparison between I4 and F4
		//IL_0175: Expected O, but got I4
		//IL_011c: Expected O, but got I4
		if (statModifier == null)
		{
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
		bool flag = (((statModifier.modifyType == EStatModifyType.Multiplication && 1f > statModifier.modification) || ((statModifier.modifyType == EStatModifyType.Addition || statModifier.modifyType == EStatModifyType.Flat) && 0f > statModifier.modification)) ? true : false);
		object obj = statModifier.stat - 50;
		if ((nint)obj <= 5)
		{
			return (byte)((flag ? 1u : 0u) ^ 1u) != 0;
		}
		object obj2 = statModifier.stat - 34;
		bool flag2 = obj2 == null;
		bool result = (byte)((flag ? 1u : 0u) ^ 1u) != 0;
		if (!flag2)
		{
			result = flag;
		}
		return result;
	}

	private static bool IsOppositeStat(EStat stat)
	{
		//IL_000e: Expected O, but got I4
		//IL_003f: Expected O, but got I4
		object obj = stat - 50;
		if ((nint)obj <= 5)
		{
			return true;
		}
		object obj2 = stat - 34;
		return obj2 == null;
	}

	private void SetEmpty()
	{
		//IL_0058: Expected O, but got I
		//IL_0068: Expected O, but got I
		//IL_008c: Expected O, but got I
		//IL_009c: Expected O, but got I
		//IL_00c0: Expected O, but got I
		//IL_00d0: Expected O, but got I
		//IL_00f4: Expected O, but got I
		//IL_0104: Expected O, but got I
		//IL_0128: Expected O, but got I
		//IL_0138: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1831730ED]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		t_name.text = "No challenges";
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B70]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v208 @ rax_v6+B8]");
		object text = 0;
		t_stats.text = (string)text;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B70]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v210 @ rax_v8+B8]");
		object text2 = 0;
		t_description.text = (string)text2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B70]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v233 @ rax_v10+B8]");
		object text3 = 0;
		t_silver.text = (string)text3;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B70]");
		object obj4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v235 @ rax_v12+B8]");
		object text4 = 0;
		t_author.text = (string)text4;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B70]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v237 @ rax_v14+B8]");
		object text5 = 0;
		t_winCondition.text = (string)text5;
		GameObject gameObject = t_completed.gameObject;
		gameObject.SetActive(value: false);
		GameObject gameObject2 = t_reward.gameObject;
		gameObject2.SetActive(value: false);
		GameObject gameObject3 = t_leaderboards.gameObject;
		gameObject3.SetActive(value: false);
		hoverBtn = null;
	}

	private unsafe void SetHidden(ChallengeData challengeData)
	{
		//IL_04ac: Expected I, but got O
		//IL_000d: Expected I, but got O
		//IL_003f: Expected I, but got O
		//IL_034c: Expected O, but got Ref
		//IL_00ff: Expected I, but got O
		//IL_03da: Expected I, but got O
		//IL_03ea: Expected O, but got I
		//IL_0403: Expected O, but got I
		//IL_0420: Expected I, but got O
		//IL_052d: Expected O, but got I
		//IL_011b: Expected I, but got O
		//IL_04d2: Expected I, but got O
		//IL_0182: Expected I, but got O
		//IL_018b: Expected I, but got O
		//IL_01a9: Expected I, but got O
		//IL_01b9: Expected O, but got I
		//IL_01d2: Expected O, but got I
		//IL_01ef: Expected I, but got O
		//IL_04f1: Expected O, but got I
		//IL_04f1: Expected O, but got I
		//IL_0237: Expected I, but got O
		//IL_0256: Unknown result type (might be due to invalid IL or missing references)
		//IL_025b: Expected O, but got Unknown
		//IL_028a: Expected I, but got O
		//IL_0292: Expected I, but got O
		//IL_02cd: Expected I, but got O
		//IL_02d5: Expected I, but got O
		SetEmpty();
		Dictionary<object, object> dictionary = (Dictionary<object, object>)(object)t_name;
		bool flag = (object)t_name == null;
		nint num = unchecked((nint)null);
		string text2;
		TextMeshProUGUI textMeshProUGUI2;
		if (!flag)
		{
			nint num2 = (nint)dictionary;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ rax_v17 (Il2CppClass<System.Collections.Generic.Dictionary`2<System.Object, System.Object>>)+560]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v57 @ rax_v17 (Il2CppClass<System.Collections.Generic.Dictionary`2<System.Object, System.Object>>)+558] (should have been resolved before IL gen)");
			bool flag2 = (object)challengeData == null;
			num = unchecked((nint)"??");
			if (!flag2)
			{
				if (!(challengeData.prerequisiteChallenge != null) || MyAchievements.IsUnlocked(challengeData.prerequisiteChallenge))
				{
					TextMeshProUGUI textMeshProUGUI = t_description;
					LocalizedString localizedStringReference = LocalizationUtility.GetLocalizedStringReference("ChallengesUi", "REQUIREMENT");
					object[] array = new object[1];
					Dictionary<string, string> dictionary2 = new Dictionary<string, string>();
					IntPtr intPtr = default(IntPtr);
					string statName = ((Enum)(&intPtr)).ToString();
					float stat = MyStats.GetStat(statName);
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
					object arg = default(object);
					string value = $"{arg}";
					((Dictionary<object, object>)(object)dictionary2).Add((object)"value", (object)value);
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
					object arg2 = default(object);
					string text = $"{arg2}";
					((Dictionary<object, object>)(object)dictionary2).Add((object)"target_value", (object)text);
					nint num4 = (nint)array;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v648 @ rdx_v25 (Il2CppClass<System.Object[]>)+40]");
					string key = (string)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v648 @ rdx_v25 (Il2CppClass<System.Object[]>)+40]");
					dictionary2.Add((string)0, text);
					object obj = default(object);
					bool flag3 = obj == null;
					nint num5 = 0;
					num3 = (nint)text;
					Dictionary<string, string> dictionary3 = dictionary2;
					if (!flag3)
					{
						array[0] = dictionary2;
						string localizedString = localizedStringReference.GetLocalizedString(array);
						text2 = localizedString;
						textMeshProUGUI2 = textMeshProUGUI;
						goto IL_0544;
					}
					dictionary3.Add(key, (string)num3);
					object obj2 = default(object);
					throw obj2;
				}
				LocalizedString localizedStringReference2 = LocalizationUtility.GetLocalizedStringReference("ChallengesUi", "REQUIREMENT_PRE");
				object[] array2 = new object[1];
				Dictionary<string, string> dictionary4 = new Dictionary<string, string>();
				dictionary = (Dictionary<object, object>)(object)challengeData.prerequisiteChallenge;
				bool flag4 = (object)challengeData.prerequisiteChallenge == null;
				num3 = unchecked((nint)null);
				num = 0;
				if (!flag4)
				{
					num3 = (nint)dictionary;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v368 @ r8_v2 (Il2CppMethodInfo)+188] (should have been resolved before IL gen)");
					object obj3 = default(object);
					if (obj3 == null)
					{
						obj3 = "";
					}
					bool flag5 = dictionary4 == null;
					num = unchecked((nint)"prerequisite");
					if (!flag5)
					{
						((Dictionary<object, object>)(object)dictionary4).Add((object)"prerequisite", obj3);
						bool flag6 = array2 == null;
						nint num5 = 0;
						num3 = (nint)obj3;
						num = unchecked((nint)"prerequisite");
						dictionary = (Dictionary<object, object>)(object)dictionary4;
						if (!flag6)
						{
							nint num6 = (nint)array2;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v641 @ rdx_v36 (Il2CppClass<System.Object[]>)+40]");
							string key = (string)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v641 @ rdx_v36 (Il2CppClass<System.Object[]>)+40]");
							dictionary4.Add((string)0, (string)obj3);
							object obj4 = default(object);
							bool flag7 = obj4 == null;
							num5 = 0;
							num3 = (nint)obj3;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v641 @ rdx_v36 (Il2CppClass<System.Object[]>)+40]");
							num = 0;
							dictionary = (Dictionary<object, object>)(object)dictionary4;
							if (flag7)
							{
								((Dictionary<string, string>)(object)dictionary).Add((string)num, (string)num3);
								Dictionary<string, string> dictionary5 = default(Dictionary<string, string>);
								throw dictionary5;
							}
							bool flag8 = array2.Length <= 0;
							num5 = 0;
							num3 = (nint)obj3;
							Dictionary<string, string> dictionary3 = dictionary4;
							if (flag8)
							{
								throw new IndexOutOfRangeException();
							}
							dictionary = (Dictionary<object, object>)(array2 + 32);
							array2[0] = dictionary4;
							bool flag9 = localizedStringReference2 == null;
							num5 = 0;
							num3 = (nint)obj3;
							num = (nint)dictionary4;
							if (!flag9)
							{
								string localizedString2 = localizedStringReference2.GetLocalizedString(array2);
								bool flag10 = (object)t_description == null;
								num5 = 0;
								num3 = unchecked((nint)null);
								num = (nint)array2;
								dictionary = (Dictionary<object, object>)(object)localizedStringReference2;
								if (!flag10)
								{
									text2 = localizedString2;
									textMeshProUGUI2 = t_description;
									goto IL_0544;
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
		IL_0544:
		textMeshProUGUI2.text = text2;
	}

	private new void OnEnable()
	{
		base.OnEnable();
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 11 Invalid \"Jump target not found in method: 0x180562D30\"");
	}

	private unsafe void Refresh()
	{
		//IL_0075: Expected O, but got I
		//IL_1296: Expected O, but got I
		//IL_129e: Expected O, but got Ref
		//IL_019c: Expected O, but got I
		//IL_1244: Expected I, but got O
		//IL_01ba: Expected O, but got I
		//IL_01d7: Expected O, but got I
		//IL_0162: Expected I, but got O
		//IL_0204: Expected O, but got I
		//IL_132a: Expected O, but got I
		//IL_0268: Expected O, but got I4
		//IL_1372: Expected I, but got O
		//IL_1388: Expected O, but got I
		//IL_0a0d: Expected I, but got O
		//IL_0a3e: Expected O, but got I
		//IL_0a75: Expected O, but got I
		//IL_08ca: Expected O, but got I4
		//IL_0a90: Expected I, but got O
		//IL_0aac: Expected O, but got I
		//IL_0add: Expected O, but got I
		//IL_0943: Expected I, but got O
		//IL_094c: Expected O, but got I4
		//IL_03d9: Expected O, but got I
		//IL_0b27: Expected O, but got I
		//IL_09aa: Expected O, but got I4
		//IL_0b70: Expected O, but got I
		//IL_09e0: Expected I, but got O
		//IL_0465: Expected O, but got I4
		//IL_0b9b: Expected O, but got I
		//IL_0f59: Expected I, but got O
		//IL_0bd0: Expected I, but got O
		//IL_0c0f: Expected O, but got I
		//IL_0c17: Expected O, but got I
		//IL_052f: Expected O, but got I4
		//IL_100f: Expected I, but got O
		//IL_1015: Expected O, but got I
		//IL_0c5c: Expected O, but got I
		//IL_0c64: Expected O, but got I
		//IL_1033: Expected O, but got I
		//IL_104f: Expected I, but got O
		//IL_1055: Expected O, but got I
		//IL_0ca9: Expected O, but got I
		//IL_05c0: Expected O, but got I4
		//IL_1085: Expected I, but got O
		//IL_1092: Expected O, but got Ref
		//IL_0ce8: Expected O, but got I
		//IL_10ca: Expected I, but got O
		//IL_0622: Expected O, but got Ref
		//IL_0638: Expected I, but got O
		//IL_0640: Expected O, but got Ref
		//IL_10f1: Expected I, but got O
		//IL_110a: Expected O, but got I
		//IL_1122: Expected I, but got O
		//IL_13bf: Expected O, but got I
		//IL_13bf: Expected O, but got I
		//IL_0696: Expected O, but got I4
		//IL_1163: Unknown result type (might be due to invalid IL or missing references)
		//IL_1168: Expected O, but got Unknown
		//IL_1180: Expected I, but got O
		//IL_0d8d: Expected O, but got I
		//IL_11be: Expected I, but got O
		//IL_0db8: Expected O, but got I
		//IL_0de1: Expected O, but got I
		//IL_0df1: Expected O, but got I
		//IL_0e30: Expected O, but got I
		//IL_074f: Expected O, but got I4
		//IL_0e4e: Expected O, but got I
		//IL_0ea6: Expected O, but got I
		//IL_0ece: Expected I4, but got O
		//IL_0ece: Expected O, but got I
		//IL_07ee: Expected O, but got I4
		//IL_0850: Expected O, but got Ref
		//IL_0864: Expected I, but got O
		//IL_086c: Expected O, but got Ref
		bool flag = challengeButtons != null;
		List<SelectionGroupToggleSingleButtonChallenge> list = (List<SelectionGroupToggleSingleButtonChallenge>)(object)this;
		if (flag)
		{
			goto IL_00a7;
		}
		List<SelectionGroupToggleSingleButtonChallenge> list2 = (challengeButtons = new List<SelectionGroupToggleSingleButtonChallenge>());
		GameObject gameObject = challengeButtonPrefab;
		bool flag2 = (object)challengeButtonPrefab == null;
		List<SelectionGroupToggleSingleButtonChallenge> list3 = list2;
		if (!flag2)
		{
			SelectionGroupToggleSingleButtonChallenge component = challengeButtonPrefab.GetComponent<SelectionGroupToggleSingleButtonChallenge>();
			bool flag3 = challengeButtons == null;
			list3 = (List<SelectionGroupToggleSingleButtonChallenge>)0;
			if (!flag3)
			{
				challengeButtons.Add(component);
				nint num = 0;
				list = challengeButtons;
				goto IL_00a7;
			}
		}
		goto IL_11ec;
		IL_11ec:
		Component component2 = (Component)(object)gameObject;
		throw new NullReferenceException();
		IL_00a7:
		list3 = challengeButtons;
		bool flag4 = challengeButtons == null;
		gameObject = (GameObject)(object)list;
		if (!flag4)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
			nint num = 0;
			List<object>.Enumerator enumerator = default(List<object>.Enumerator);
			Component component3 = default(Component);
			while (enumerator.MoveNext())
			{
				bool flag5 = (object)component3 == null;
				nint num2 = 0;
				component2 = component3;
				if (!flag5)
				{
					GameObject gameObject2 = component3.gameObject;
					bool flag6 = (object)gameObject2 == null;
					list3 = null;
					component2 = component3;
					if (!flag6)
					{
						gameObject2.SetActive(value: false);
						num = unchecked((nint)null);
						continue;
					}
					num2 = (nint)list3;
					throw new NullReferenceException();
				}
				throw new NullReferenceException();
			}
			((List<SelectionGroupToggleSingleButtonChallenge>.Enumerator*)(&enumerator))->Dispose();
			MapSelectionUi mapSelectionUi = this.mapSelectionUi;
			bool flag7 = (object)this.mapSelectionUi == null;
			list3 = (List<SelectionGroupToggleSingleButtonChallenge>)0;
			gameObject = (GameObject)(&enumerator);
			if (!flag7)
			{
				gameObject = (GameObject)(object)mapSelectionUi.runConfig;
				bool flag8 = mapSelectionUi.runConfig == null;
				list3 = (List<SelectionGroupToggleSingleButtonChallenge>)0;
				if (!flag8)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v327 @ rcx_v7 (UnityEngine.GameObject)+18]");
					object obj = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v327 @ rcx_v7 (UnityEngine.GameObject)+18]");
					bool flag9 = (nint)0 == 0;
					list3 = (List<SelectionGroupToggleSingleButtonChallenge>)0;
					if (!flag9)
					{
						Func<ChallengeData, bool> predicate = _003C_003Ec._003C_003E9__18_0;
						if (_003C_003Ec._003C_003E9__18_0 == null)
						{
							predicate = (_003C_003Ec._003C_003E9__18_0 = delegate(ChallengeData a)
							{
								//IL_0035: Expected I4, but got O
								if ((object)a == null)
								{
									NullReferenceException ex = new NullReferenceException();
									return (byte)(int)ex != 0;
								}
								return a.isEnabled;
							});
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v289 @ rax_v21+110]");
						IEnumerable<ChallengeData> source = Enumerable.Where((IEnumerable<ChallengeData>)0, predicate);
						List<object> list4 = Enumerable.ToList((IEnumerable<object>)source);
						Comparison<object> comparison = (Comparison<object>)_003C_003Ec._003C_003E9__18_1;
						bool flag10 = _003C_003Ec._003C_003E9__18_1 != null;
						num = 0;
						list3 = (List<SelectionGroupToggleSingleButtonChallenge>)0;
						gameObject = (GameObject)(object)typeof(_003C_003Ec);
						if (!flag10)
						{
							Comparison<ChallengeData> comparison2 = (_003C_003Ec._003C_003E9__18_1 = delegate(ChallengeData a, ChallengeData b)
							{
								//IL_0071: Expected I4, but got O
								//IL_0043: Unknown result type (might be due to invalid IL or missing references)
								//IL_0048: Expected I4, but got Unknown
								if ((object)a == null || (object)b == null)
								{
									NullReferenceException ex = new NullReferenceException();
									return (int)ex;
								}
								int num16 = a + 88;
								return ((int*)num16)->CompareTo(b.sortingOrder);
							});
							nint num3 = (nint)typeof(_003C_003Ec);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1456 @ rax_v114 (Il2CppClass<ChallengesUi+<>c>)+B8]");
							gameObject = (GameObject)((nint)0 + (nint)16);
							comparison = (Comparison<object>)comparison2;
							num = 0;
							list3 = (List<SelectionGroupToggleSingleButtonChallenge>)(object)comparison2;
						}
						if (list4 != null)
						{
							list4.Sort(comparison);
							int num4 = 0;
							List<object>.Enumerator enumerator2 = (List<object>.Enumerator)0;
							num = 0;
							list3 = (List<SelectionGroupToggleSingleButtonChallenge>)(object)comparison;
							gameObject = (GameObject)(object)list4;
							int num14 = default(int);
							object obj3 = default(object);
							object obj4 = default(object);
							while (true)
							{
								if (num4 < list4._size)
								{
									List<SelectionGroupToggleSingleButtonChallenge> list5 = challengeButtons;
									if (challengeButtons == null)
									{
										break;
									}
									if (num4 >= list5._size)
									{
										bool flag11 = (object)challengeButtonPrefab == null;
										gameObject = challengeButtonPrefab;
										if (flag11)
										{
											break;
										}
										Transform transform = challengeButtonPrefab.transform;
										bool flag12 = (object)transform == null;
										list3 = null;
										gameObject = challengeButtonPrefab;
										if (flag12)
										{
											break;
										}
										Transform parent = transform.parent;
										GameObject gameObject3 = UnityEngine.Object.Instantiate(challengeButtonPrefab, parent);
										bool flag13 = (object)gameObject3 == null;
										num = 0;
										list3 = (List<SelectionGroupToggleSingleButtonChallenge>)(object)parent;
										gameObject = challengeButtonPrefab;
										if (flag13)
										{
											break;
										}
										SelectionGroupToggleSingleButtonChallenge component4 = gameObject3.GetComponent<SelectionGroupToggleSingleButtonChallenge>();
										bool flag14 = challengeButtons == null;
										num = 0;
										list3 = (List<SelectionGroupToggleSingleButtonChallenge>)0;
										gameObject = gameObject3;
										if (flag14)
										{
											break;
										}
										challengeButtons.Add(component4);
										bool flag15 = challengeButtons == null;
										num = 0;
										list3 = (List<SelectionGroupToggleSingleButtonChallenge>)(object)component4;
										gameObject = (GameObject)(object)challengeButtons;
										if (flag15)
										{
											break;
										}
										SelectionGroupToggleSingleButtonChallenge selectionGroupToggleSingleButtonChallenge = challengeButtons.get_Item(num4);
										bool flag16 = (object)selectionGroupToggleSingleButtonChallenge == null;
										num = 0;
										list3 = (List<SelectionGroupToggleSingleButtonChallenge>)num4;
										gameObject = (GameObject)(object)challengeButtons;
										if (flag16)
										{
											break;
										}
										Button button = selectionGroupToggleSingleButtonChallenge.GetButton();
										bool flag17 = (object)button == null;
										num = 0;
										list3 = null;
										gameObject = (GameObject)(object)selectionGroupToggleSingleButtonChallenge;
										if (flag17)
										{
											break;
										}
										bool flag18 = challengeButtons == null;
										num = 0;
										list3 = null;
										gameObject = (GameObject)(object)challengeButtons;
										if (flag18)
										{
											break;
										}
										int num5 = num4 - 1;
										SelectionGroupToggleSingleButtonChallenge selectionGroupToggleSingleButtonChallenge2 = challengeButtons.get_Item(num5);
										bool flag19 = (object)selectionGroupToggleSingleButtonChallenge2 == null;
										num = 0;
										list3 = (List<SelectionGroupToggleSingleButtonChallenge>)num5;
										gameObject = (GameObject)(object)challengeButtons;
										if (flag19)
										{
											break;
										}
										Button button2 = selectionGroupToggleSingleButtonChallenge2.GetButton();
										bool flag20 = challengeButtons == null;
										num = 0;
										list3 = (List<SelectionGroupToggleSingleButtonChallenge>)(object)button2;
										gameObject = (GameObject)(object)challengeButtons;
										if (flag20)
										{
											break;
										}
										SelectionGroupToggleSingleButtonChallenge selectionGroupToggleSingleButtonChallenge3 = challengeButtons.get_Item(num4);
										bool flag21 = (object)selectionGroupToggleSingleButtonChallenge3 == null;
										num = 0;
										list3 = (List<SelectionGroupToggleSingleButtonChallenge>)num4;
										gameObject = (GameObject)(object)challengeButtons;
										if (flag21)
										{
											break;
										}
										Button button3 = selectionGroupToggleSingleButtonChallenge3.GetButton();
										bool flag22 = (object)button3 == null;
										num = 0;
										list3 = null;
										gameObject = (GameObject)(object)selectionGroupToggleSingleButtonChallenge3;
										if (flag22)
										{
											break;
										}
										button3.navigation = (Navigation)(&enumerator2);
										bool flag23 = challengeButtons == null;
										num = unchecked((nint)null);
										list3 = (List<SelectionGroupToggleSingleButtonChallenge>)(&enumerator2);
										gameObject = (GameObject)(object)challengeButtons;
										if (flag23)
										{
											break;
										}
										int num6 = num4 - 1;
										SelectionGroupToggleSingleButtonChallenge selectionGroupToggleSingleButtonChallenge4 = challengeButtons.get_Item(num6);
										bool flag24 = (object)selectionGroupToggleSingleButtonChallenge4 == null;
										num = 0;
										list3 = (List<SelectionGroupToggleSingleButtonChallenge>)num6;
										gameObject = (GameObject)(object)challengeButtons;
										if (flag24)
										{
											break;
										}
										Button button4 = selectionGroupToggleSingleButtonChallenge4.GetButton();
										bool flag25 = (object)button4 == null;
										num = 0;
										list3 = null;
										gameObject = (GameObject)(object)selectionGroupToggleSingleButtonChallenge4;
										if (flag25)
										{
											break;
										}
										bool flag26 = challengeButtons == null;
										num = 0;
										list3 = null;
										gameObject = (GameObject)(object)challengeButtons;
										if (flag26)
										{
											break;
										}
										SelectionGroupToggleSingleButtonChallenge selectionGroupToggleSingleButtonChallenge5 = challengeButtons.get_Item(num4);
										bool flag27 = (object)selectionGroupToggleSingleButtonChallenge5 == null;
										num = 0;
										list3 = (List<SelectionGroupToggleSingleButtonChallenge>)num4;
										gameObject = (GameObject)(object)challengeButtons;
										if (flag27)
										{
											break;
										}
										Button button5 = selectionGroupToggleSingleButtonChallenge5.GetButton();
										bool flag28 = challengeButtons == null;
										num = 0;
										list3 = (List<SelectionGroupToggleSingleButtonChallenge>)(object)button5;
										gameObject = (GameObject)(object)challengeButtons;
										if (flag28)
										{
											break;
										}
										int num7 = num4 - 1;
										SelectionGroupToggleSingleButtonChallenge selectionGroupToggleSingleButtonChallenge6 = challengeButtons.get_Item(num7);
										bool flag29 = (object)selectionGroupToggleSingleButtonChallenge6 == null;
										num = 0;
										list3 = (List<SelectionGroupToggleSingleButtonChallenge>)num7;
										gameObject = (GameObject)(object)challengeButtons;
										if (flag29)
										{
											break;
										}
										Button button6 = selectionGroupToggleSingleButtonChallenge6.GetButton();
										bool flag30 = (object)button6 == null;
										num = 0;
										list3 = null;
										gameObject = (GameObject)(object)selectionGroupToggleSingleButtonChallenge6;
										if (flag30)
										{
											break;
										}
										button6.navigation = (Navigation)(&enumerator2);
										enumerator2 = (List<object>.Enumerator)((Selectable)button4).m_Navigation;
										num = unchecked((nint)null);
										list3 = (List<SelectionGroupToggleSingleButtonChallenge>)(&enumerator2);
									}
									bool flag31 = challengeButtons == null;
									gameObject = (GameObject)(object)challengeButtons;
									if (flag31)
									{
										break;
									}
									SelectionGroupToggleSingleButtonChallenge selectionGroupToggleSingleButtonChallenge7 = challengeButtons.get_Item(num4);
									bool flag32 = (object)selectionGroupToggleSingleButtonChallenge7 == null;
									num = 0;
									list3 = (List<SelectionGroupToggleSingleButtonChallenge>)num4;
									gameObject = (GameObject)(object)challengeButtons;
									if (flag32)
									{
										break;
									}
									GameObject gameObject4 = selectionGroupToggleSingleButtonChallenge7.gameObject;
									bool flag33 = (object)gameObject4 == null;
									num = 0;
									list3 = null;
									gameObject = (GameObject)(object)selectionGroupToggleSingleButtonChallenge7;
									if (flag33)
									{
										break;
									}
									gameObject4.SetActive(value: true);
									bool flag34 = challengeButtons == null;
									num = unchecked((nint)null);
									list3 = (List<SelectionGroupToggleSingleButtonChallenge>)1;
									gameObject = (GameObject)(object)challengeButtons;
									if (flag34)
									{
										break;
									}
									SelectionGroupToggleSingleButtonChallenge selectionGroupToggleSingleButtonChallenge8 = challengeButtons.get_Item(num4);
									ChallengeData challengeData = ((List<ChallengeData>)(object)list4).get_Item(num4);
									bool flag35 = (object)selectionGroupToggleSingleButtonChallenge8 == null;
									num = 0;
									list3 = (List<SelectionGroupToggleSingleButtonChallenge>)num4;
									gameObject = (GameObject)(object)list4;
									if (flag35)
									{
										break;
									}
									selectionGroupToggleSingleButtonChallenge8.Set(challengeData);
									num4++;
									num = unchecked((nint)null);
									list3 = (List<SelectionGroupToggleSingleButtonChallenge>)(object)challengeData;
									gameObject = (GameObject)(object)selectionGroupToggleSingleButtonChallenge8;
									continue;
								}
								nint num8 = (nint)typeof(SaveManager);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1537 @ rax_v36 (Il2CppClass<SaveManager>)+B8]");
								nint num9 = 0;
								SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
								bool flag36 = (object)SaveManager._003CInstance_003Ek__BackingField == null;
								gameObject = (GameObject)num9;
								if (flag36)
								{
									break;
								}
								ProgressionSaveFile progression = saveManager.progression;
								bool flag37 = saveManager.progression == null;
								gameObject = (GameObject)num9;
								if (flag37)
								{
									break;
								}
								num = (nint)progression.menuMeta;
								bool flag38 = progression.menuMeta == null;
								gameObject = (GameObject)num9;
								if (flag38)
								{
									break;
								}
								MapSelectionUi mapSelectionUi2 = this.mapSelectionUi;
								bool flag39 = (object)this.mapSelectionUi == null;
								gameObject = (GameObject)num9;
								if (flag39)
								{
									break;
								}
								gameObject = (GameObject)(object)mapSelectionUi2.runConfig;
								if (mapSelectionUi2.runConfig == null)
								{
									break;
								}
								list3 = (List<SelectionGroupToggleSingleButtonChallenge>)(nint)((UnityEngine.Object)gameObject).m_CachedPtr;
								if (((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0)
								{
									break;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v225 @ r8_v29 (Il2CppMethodInfo)+18]");
								bool flag40 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v225 @ r8_v29 (Il2CppMethodInfo)+18]");
								gameObject = (GameObject)0;
								if (flag40)
								{
									break;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v225 @ r8_v29 (Il2CppMethodInfo)+18]");
								nint num10 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v259 @ rdx_v45 (System.Collections.Generic.List`1<SelectionGroupToggleSingleButtonChallenge>)+58]");
								if (((Dictionary<System.Int32Enum, object>)num10).ContainsKey((System.Int32Enum)0))
								{
									nint num11 = (nint)typeof(SaveManager);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1677 @ rax_v66 (Il2CppClass<SaveManager>)+B8]");
									nint num12 = 0;
									SaveManager saveManager2 = SaveManager._003CInstance_003Ek__BackingField;
									bool flag41 = (object)SaveManager._003CInstance_003Ek__BackingField == null;
									num = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v259 @ rdx_v45 (System.Collections.Generic.List`1<SelectionGroupToggleSingleButtonChallenge>)+58]");
									list3 = (List<SelectionGroupToggleSingleButtonChallenge>)0;
									gameObject = (GameObject)num12;
									if (flag41)
									{
										break;
									}
									ProgressionSaveFile progression2 = saveManager2.progression;
									bool flag42 = saveManager2.progression == null;
									num = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v259 @ rdx_v45 (System.Collections.Generic.List`1<SelectionGroupToggleSingleButtonChallenge>)+58]");
									list3 = (List<SelectionGroupToggleSingleButtonChallenge>)0;
									gameObject = (GameObject)num12;
									if (flag42)
									{
										break;
									}
									gameObject = (GameObject)(object)progression2.menuMeta;
									bool flag43 = progression2.menuMeta == null;
									num = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v259 @ rdx_v45 (System.Collections.Generic.List`1<SelectionGroupToggleSingleButtonChallenge>)+58]");
									list3 = (List<SelectionGroupToggleSingleButtonChallenge>)0;
									if (flag43)
									{
										break;
									}
									MapSelectionUi mapSelectionUi3 = this.mapSelectionUi;
									bool flag44 = (object)this.mapSelectionUi == null;
									num = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v259 @ rdx_v45 (System.Collections.Generic.List`1<SelectionGroupToggleSingleButtonChallenge>)+58]");
									list3 = (List<SelectionGroupToggleSingleButtonChallenge>)0;
									if (flag44)
									{
										break;
									}
									list3 = (List<SelectionGroupToggleSingleButtonChallenge>)(object)mapSelectionUi3.runConfig;
									bool flag45 = mapSelectionUi3.runConfig == null;
									num = 0;
									if (flag45)
									{
										break;
									}
									list3 = (List<SelectionGroupToggleSingleButtonChallenge>)(object)list3._items;
									bool flag46 = list3._items == null;
									num = 0;
									if (flag46)
									{
										break;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v327 @ rcx_v7 (UnityEngine.GameObject)+18]");
									bool flag47 = (nint)0 == 0;
									num = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v327 @ rcx_v7 (UnityEngine.GameObject)+18]");
									gameObject = (GameObject)0;
									if (flag47)
									{
										break;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v327 @ rcx_v7 (UnityEngine.GameObject)+18]");
									nint num13 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v259 @ rdx_v45 (System.Collections.Generic.List`1<SelectionGroupToggleSingleButtonChallenge>)+58]");
									object obj2 = ((Dictionary<System.Int32Enum, object>)num13).get_Item((System.Int32Enum)0);
									bool flag48 = obj2 == null;
									num = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v259 @ rdx_v45 (System.Collections.Generic.List`1<SelectionGroupToggleSingleButtonChallenge>)+58]");
									list3 = (List<SelectionGroupToggleSingleButtonChallenge>)0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v327 @ rcx_v7 (UnityEngine.GameObject)+18]");
									gameObject = (GameObject)0;
									if (flag48)
									{
										break;
									}
									gameObject = (GameObject)(object)this.mapSelectionUi;
									bool flag49 = (object)this.mapSelectionUi == null;
									num = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v259 @ rdx_v45 (System.Collections.Generic.List`1<SelectionGroupToggleSingleButtonChallenge>)+58]");
									list3 = (List<SelectionGroupToggleSingleButtonChallenge>)0;
									if (flag49)
									{
										break;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v327 @ rcx_v7 (UnityEngine.GameObject)+90]");
									list3 = (List<SelectionGroupToggleSingleButtonChallenge>)0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v327 @ rcx_v7 (UnityEngine.GameObject)+90]");
									bool flag50 = (nint)0 == 0;
									num = 0;
									if (flag50)
									{
										break;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v320 @ rax_v70 (System.Object)+18]");
									bool flag51 = (nint)0 == 0;
									num = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v320 @ rax_v70 (System.Object)+18]");
									gameObject = (GameObject)0;
									if (flag51)
									{
										break;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v320 @ rax_v70 (System.Object)+18]");
									bool flag52 = ((HashSet<int>)0).Remove((int)list3._syncRoot);
								}
								if (list4._size <= 0)
								{
									SetEmpty();
									startBtn = btn_confirm;
								}
								else
								{
									if (hoverBtn == null)
									{
										bool flag53 = challengeButtons == null;
										num = unchecked((nint)null);
										list3 = null;
										gameObject = (GameObject)(object)challengeButtons;
										if (flag53)
										{
											break;
										}
										SelectionGroupToggleSingleButtonChallenge selectionGroupToggleSingleButtonChallenge9 = challengeButtons.get_Item(0);
										startBtn = selectionGroupToggleSingleButtonChallenge9;
									}
									ChallengeData challengeData2 = ((List<ChallengeData>)(object)list4).get_Item(0);
									UpdateStatsText(challengeData2);
								}
								LocalizedString localizedStringReference = LocalizationUtility.GetLocalizedStringReference("ChallengesUi", "CHALLENGES_HEADER");
								object[] array = new object[1];
								Dictionary<string, string> dictionary = new Dictionary<string, string>();
								gameObject = (GameObject)(object)this.mapSelectionUi;
								bool flag54 = (object)this.mapSelectionUi == null;
								num = unchecked((nint)null);
								list3 = (List<SelectionGroupToggleSingleButtonChallenge>)0;
								if (flag54)
								{
									break;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v327 @ rcx_v7 (UnityEngine.GameObject)+90]");
								gameObject = (GameObject)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v327 @ rcx_v7 (UnityEngine.GameObject)+90]");
								bool flag55 = (nint)0 == 0;
								num = unchecked((nint)null);
								list3 = (List<SelectionGroupToggleSingleButtonChallenge>)0;
								if (flag55)
								{
									break;
								}
								string text = num14.ToString();
								bool flag56 = dictionary == null;
								num = unchecked((nint)null);
								list3 = null;
								gameObject = (GameObject)(&num14);
								if (flag56)
								{
									break;
								}
								((Dictionary<object, object>)(object)dictionary).Add((object)"tier", (object)text);
								bool flag57 = array == null;
								num = (nint)text;
								list3 = (List<SelectionGroupToggleSingleButtonChallenge>)(object)"tier";
								gameObject = (GameObject)(object)dictionary;
								if (flag57)
								{
									break;
								}
								nint num15 = (nint)array;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1747 @ rdx_v27 (Il2CppClass<System.Object[]>)+40]");
								dictionary.Add((string)0, text);
								bool flag58 = obj3 == null;
								num = (nint)text;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1747 @ rdx_v27 (Il2CppClass<System.Object[]>)+40]");
								nint num2 = 0;
								component2 = (Component)(object)dictionary;
								if (!flag58)
								{
									array[0] = dictionary;
									gameObject = (GameObject)(array + 32);
									bool flag59 = localizedStringReference == null;
									num = (nint)text;
									list3 = (List<SelectionGroupToggleSingleButtonChallenge>)(object)dictionary;
									if (flag59)
									{
										break;
									}
									string localizedString = localizedStringReference.GetLocalizedString(array);
									bool flag60 = (object)t_header == null;
									num = unchecked((nint)null);
									list3 = (List<SelectionGroupToggleSingleButtonChallenge>)(object)array;
									gameObject = (GameObject)(object)localizedStringReference;
									if (flag60)
									{
										break;
									}
									t_header.text = localizedString;
									return;
								}
								((Dictionary<string, string>)(object)component2).Add((string)num2, (string)num);
								throw obj4;
							}
						}
					}
				}
			}
		}
		goto IL_11ec;
	}

	public void SetNone()
	{
		challengesSelectionGroup.SetNone();
		mapSelectionUi.SetChallenge(null);
	}

	private unsafe void OnChallengeSelected(SelectionGroupToggleSingleButton btn)
	{
		//IL_0013: Expected I, but got O
		//IL_001b: Expected I, but got O
		//IL_002b: Expected O, but got I
		//IL_0067: Expected O, but got I
		//IL_009c: Expected I, but got O
		//IL_00ac: Expected O, but got I
		//IL_00bc: Expected O, but got I
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Expected O, but got Unknown
		//IL_0150: Expected O, but got I
		//IL_019c: Expected O, but got Ref
		nint num = (nint)typeof(SelectionGroupToggleSingleButtonChallenge);
		nint num2 = (nint)btn;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ r8_v2 (Il2CppClass<SelectionGroupToggleSingleButtonChallenge>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rdx_v2 (Il2CppClass<SelectionGroupToggleSingleButton>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ r8_v2 (Il2CppClass<SelectionGroupToggleSingleButtonChallenge>)+130]");
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rdx_v2 (Il2CppClass<SelectionGroupToggleSingleButton>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ rax_v5+FFFFFFF8+v42 @ rax_v4*8]");
			if (0 == (nint)typeof(SelectionGroupToggleSingleButtonChallenge))
			{
				nint num4 = (nint)btn;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ r8_v2 (Il2CppClass<SelectionGroupToggleSingleButtonChallenge>)+130]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ rax_v6 (Il2CppClass<SelectionGroupToggleSingleButton>)+C8]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v169 @ rcx_v4+FFFFFFF8+v168 @ rdx_v3*8]");
				object obj5 = 0 - typeof(SelectionGroupToggleSingleButtonChallenge);
				bool flag = obj5 == null;
				bool flag2 = !flag;
				SelectionGroupToggleSingleButton selectionGroupToggleSingleButton = null;
				if (!flag2)
				{
					selectionGroupToggleSingleButton = btn;
				}
				ChallengeData challenge;
				if (!btn._003CisSelected_003Ek__BackingField)
				{
					challenge = null;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ rdx_v5 (SelectionGroupToggleSingleButton)+98]");
					challenge = (ChallengeData)0;
				}
				mapSelectionUi.SetChallenge(challenge);
				Button button = btn_confirm.GetButton();
				Button button2 = btn.GetButton();
				Button button3 = btn_confirm.GetButton();
				object obj6 = default(object);
				button3.navigation = (Navigation)(&obj6);
				startBtn = btn;
				return;
			}
		}
		throw new NullReferenceException();
	}

	public ChallengesUi()
	{
		//IL_0022: Expected O, but got F4
		//IL_0044: Expected O, but got F4
		completedColor = (Color)MyColorUtility.StringToColor("#00C4FF").r;
		notCompletedColor = (Color)MyColorUtility.StringToColor("#EC3434").r;
		base._002Ector();
	}
}
