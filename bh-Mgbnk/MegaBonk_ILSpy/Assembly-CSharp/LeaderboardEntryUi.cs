using System;
using Assets.Scripts.Menu.Shop.Leaderboards;
using Assets.Scripts.Steam;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using Steamworks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardEntryUi : MyButton
{
	public RawImage playerIcon;

	public RawImage characterIcon;

	public TextMeshProUGUI playerName;

	public TextMeshProUGUI rank;

	public TextMeshProUGUI score;

	public RawImage localHighlight;

	public MaskableGraphic outlineColor;

	public Color colorDefault;

	public Color colorGold;

	public GameObject hoverOverlay;

	private LeaderboardEntry entry;

	private new void Awake()
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<ulong> b = OnPlayerInformationArrived;
		Delegate obj = Delegate.Combine(SteamManager.A_PlayerInformationArrived, b);
		if ((object)obj == null)
		{
			SteamManager.A_PlayerInformationArrived = (Action<ulong>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<ulong> action = default(Action<ulong>);
		if (action != null)
		{
			SteamManager.A_PlayerInformationArrived = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<ulong>);
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<ulong>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	public override void StartHover()
	{
		hoverOverlay.SetActive(value: true);
		isHovering = true;
	}

	public override void StopHover()
	{
		hoverOverlay.SetActive(value: false);
		isHovering = false;
	}

	protected override void OnClick()
	{
	}

	private void OnDestroy()
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<ulong> value = OnPlayerInformationArrived;
		Delegate obj = Delegate.Remove(SteamManager.A_PlayerInformationArrived, value);
		if ((object)obj == null)
		{
			SteamManager.A_PlayerInformationArrived = (Action<ulong>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<ulong> action = default(Action<ulong>);
		if (action != null)
		{
			SteamManager.A_PlayerInformationArrived = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<ulong>);
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<ulong>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	public unsafe void Set(LeaderboardEntry entry, int rankIndex, ELeaderboardCategory category = ELeaderboardCategory.Kills)
	{
		//IL_0066: Expected I, but got O
		//IL_026e: Expected F4, but got I
		//IL_00df: Expected O, but got I
		//IL_0111: Expected O, but got Ref
		//IL_0143: Unknown result type (might be due to invalid IL or missing references)
		//IL_0148: Expected O, but got Unknown
		//IL_017c: Expected O, but got I
		//IL_01af: Expected O, but got I
		//IL_01d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d8: Expected O, but got Unknown
		//IL_02f6: Expected I8, but got O
		//IL_03eb: Expected O, but got Ref
		//IL_041a: Expected O, but got Ref
		this.entry = entry;
		playerIcon.texture = null;
		GameObject gameObject = base.gameObject;
		gameObject.SetActive(value: true);
		TextMeshProUGUI textMeshProUGUI = rank;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
		object arg = default(object);
		string text = $"#{arg}";
		nint num = (nint)textMeshProUGUI;
		textMeshProUGUI.text = text;
		string text3;
		TextMeshProUGUI textMeshProUGUI2;
		if (category != ELeaderboardCategory.Kills)
		{
			if (category != ELeaderboardCategory.Speedrun)
			{
				goto IL_0440;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul dword ptr [rbp+1Ch]\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul dword ptr [rbp+1Ch]\"");
			object obj2 = default(object);
			object obj = (nint)(&obj2) >> 6;
			object obj3 = obj >> 31;
			object obj4 = obj + obj3;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul r8d\"");
			object obj5 = (ref *(_003F*)(&obj2)) + (ref *(_003F*)obj4);
			object obj6 = obj5 >> 5;
			object obj7 = obj6 >> 31;
			object obj8 = obj6 + obj7;
			object obj9 = obj8 * 60;
			object obj10 = obj4 - obj9;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul dword ptr [rbp+1Ch]\"");
			object obj12 = default(object);
			object obj11 = (nint)(&obj12) >> 5;
			object obj13 = obj11 >> 31;
			object obj14 = obj11 + obj13;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul r8d\"");
			object obj15 = (nint)(&obj12) >> 2;
			object obj16 = obj15 >> 31;
			object obj17 = obj15 + obj16;
			object obj18 = obj17 * 4;
			object obj19 = obj17 + obj18;
			object obj20 = obj19 + obj19;
			object obj21 = obj14 - obj20;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
			object arg2 = default(object);
			object arg3 = default(object);
			object arg4 = default(object);
			string text2 = $"{arg2:00}:{arg3:00}.{arg4}";
			score.text = text2;
			text3 = text2;
			textMeshProUGUI2 = score;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [entry @ rdx (Assets.Scripts.Steam.LeaderboardEntry)+1C]");
			string text4 = DamageNumbers.FormatDamageNumber(0f, "0.00");
			text3 = text4;
			textMeshProUGUI2 = score;
		}
		textMeshProUGUI2.text = text3;
		goto IL_0440;
		IL_0440:
		string friendPersonaName = SteamFriends.GetFriendPersonaName((CSteamID)entry.leaderboardEntry);
		string text5 = ChatUtility.SanitizePlayerName(friendPersonaName);
		playerName.text = text5;
		if (!SteamFriends.RequestUserInformation((CSteamID)entry.leaderboardEntry, bRequireNameOnly: false))
		{
			LeaderboardEntry leaderboardEntry = this.entry;
			Texture2D texture = SteamUtility.LoadAvatar((ulong)(long)leaderboardEntry.leaderboardEntry);
			playerIcon.texture = texture;
		}
		ECharacter character = entry.GetCharacter();
		CharacterData characterData = DataManager.Instance.GetCharacterData(character);
		Texture icon = characterData.GetIcon();
		characterIcon.texture = icon;
		GameObject gameObject2 = localHighlight.gameObject;
		CSteamID steamID = SteamUser.GetSteamID();
		object obj22 = (object)entry.leaderboardEntry - (object)steamID;
		bool active = obj22 == null;
		gameObject2.SetActive(active);
		if (outlineColor != null)
		{
			Color color = default(Color);
			outlineColor.color = (Color)(&color);
			if (rankIndex == 0)
			{
				outlineColor.color = (Color)(&color);
			}
		}
	}

	public void Clear()
	{
		GameObject gameObject = base.gameObject;
		gameObject.SetActive(value: false);
	}

	private void OnPlayerInformationArrived(ulong steamid)
	{
		//IL_0060: Expected I8, but got O
		if (entry != null)
		{
			LeaderboardEntry leaderboardEntry = entry;
			if (steamid == (ulong)(long)leaderboardEntry.leaderboardEntry)
			{
				Texture2D texture = SteamUtility.LoadAvatar((ulong)(long)leaderboardEntry.leaderboardEntry);
				playerIcon.texture = texture;
			}
		}
	}

	private void LoadAvatar()
	{
		//IL_0022: Expected I8, but got O
		LeaderboardEntry leaderboardEntry = entry;
		Texture2D texture = SteamUtility.LoadAvatar((ulong)(long)leaderboardEntry.leaderboardEntry);
		playerIcon.texture = texture;
	}
}
