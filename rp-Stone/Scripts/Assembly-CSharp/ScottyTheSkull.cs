using System.Collections.Generic;
using UnityEngine;

public class ScottyTheSkull
{
	public enum DialogType
	{
		Hello = 0,
		WelcomeBack = 1,
		WelcomeBack2 = 2,
		HappyHolidays = 3,
		NoTreasureReminderAsk = 4,
		NoTreasureReminderSet = 5,
		Score1 = 6,
		Score2 = 7,
		PlayerMisses = 8,
		PlayerMissesScoreZero = 9,
		PlayerWinsFirstTime = 10,
		PlayerWins = 11,
		GoodBye = 12,
		GoodBye2 = 13,
		SpecialCaseSkullIsBack = 14,
		ReferralQuestion = 15,
		ReferralSuccess1 = 16,
		ReferralSuccess2 = 17,
		ReferralError = 18,
		ReferralDeclined = 19,
		ReferralExhausted = 20
	}

	public enum Expression
	{
		Serious = 0,
		Stunned = 1,
		Flabbergasted = 2,
		Frustrated = 3,
		Annoyed = 4,
		Suspicious = 5,
		Sad = 6,
		Crying = 7,
		Condescending = 8,
		Angry = 9,
		Happy = 10,
		Blushing = 11
	}

	public class DialogData
	{
		public DialogType type;

		private string _message;

		public string playerNameAlternativeMessage;

		public Expression expression;

		public bool continuesInNextDialog;

		public string sfxId;

		public string message
		{
			get
			{
				if (!string.IsNullOrEmpty(playerNameAlternativeMessage) && HeroSettings.isNameSet)
				{
					return string.Format(Te.xt(playerNameAlternativeMessage), HeroSettings.name);
				}
				return Te.xt(_message);
			}
			set
			{
				_message = value;
			}
		}
	}

	private List<DialogData> allDialogs = new List<DialogData>();

	private Dictionary<string, List<DialogData>> dialogsPerTypeDict = new Dictionary<string, List<DialogData>>();

	private Dictionary<string, int> indexPerTypeDict = new Dictionary<string, int>();

	public ScottyTheSkull()
	{
		string message = "A' ye have to do is guess which of us has it.\n\nReady?";
		string message2 = "Guess which of us has it.\n\nReady?";
		string message3 = "Well then, make ye guess.";
		string message4 = "Let's harden the game. Guess twice more to win.";
		AddDialog(DialogType.Hello, Expression.Annoyed, continuesInNextDialog: true, "scotty_intro", "Who goes hither?\n\nThey know me as [color=#00ffff]Scotty, the Skull[/color], keeper of the gate.");
		AddDialog(DialogType.Hello, Expression.Suspicious, continuesInNextDialog: true, "scotty_intro", "What are ye staring at? Never met skulls as big as us, or something of sorts?", "{0} eh? Welcome to this here gate.");
		AddDialog(DialogType.Hello, Expression.Serious, continuesInNextDialog: false, "scotty_intro", "Oh, ye want to get through the gate?\n\nWe have the [color=#00ffff]key[/color].");
		AddDialog(DialogType.Hello, Expression.Happy, continuesInNextDialog: true, "scotty_intro", "Let's play a game. If ye win ye can have the [color=#00ffff]key[/color].");
		AddDialog(DialogType.Hello, Expression.Serious, continuesInNextDialog: false, "scotty_guess_which", message);
		AddDialog(DialogType.Hello, Expression.Serious, continuesInNextDialog: false, "scotty_make_ye_guess", message3);
		AddDialog(DialogType.Hello, Expression.Serious, continuesInNextDialog: false, "scotty_lets_harden", message4);
		AddDialog(DialogType.WelcomeBack, Expression.Happy, continuesInNextDialog: true, "scotty_failte_back", "Fàilte back! We've looked forward to a rematch.", "Fàilte back {0}! We've looked forward to a rematch.");
		AddDialog(DialogType.WelcomeBack, Expression.Serious, continuesInNextDialog: false, "scotty_shall_we_up", "Shall we up the stakes? If ye win ye get this [color=#00ffff]treasure[/color].");
		AddDialog(DialogType.WelcomeBack, Expression.Condescending, continuesInNextDialog: true, "scotty_we_have_wee_use", "We have wee use for it, so it could be yers.");
		AddDialog(DialogType.WelcomeBack, Expression.Serious, continuesInNextDialog: false, "scotty_guess_which", message2);
		AddDialog(DialogType.WelcomeBack, Expression.Serious, continuesInNextDialog: false, "scotty_make_ye_guess", message3);
		AddDialog(DialogType.WelcomeBack, Expression.Serious, continuesInNextDialog: false, "scotty_lets_harden", message4);
		AddDialog(DialogType.WelcomeBack2, Expression.Happy, continuesInNextDialog: false, "scotty_failte_back", "Fàilte back! Cannot get enough treasure eh? Here ye go.", "Fàilte back {0}! Cannot get enough treasure eh? Here ye go.");
		AddDialog(DialogType.WelcomeBack2, Expression.Serious, continuesInNextDialog: false, "scotty_guess_which", message2);
		AddDialog(DialogType.WelcomeBack2, Expression.Serious, continuesInNextDialog: false, "scotty_make_ye_guess", message3);
		AddDialog(DialogType.WelcomeBack2, Expression.Serious, continuesInNextDialog: false, "scotty_lets_harden", message4);
		AddDialog(DialogType.HappyHolidays, Expression.Happy, continuesInNextDialog: false, "scotty_failte_back", Te.xt("tid_uulaa_winter"));
		string message5 = "We're out of [color=#00ffff]treasure[/color], but keep the heid! Skully is out gettin' more.";
		string text = "He'll be back wi' more treasure in\n          \n&\n";
		string text2 = "          \nSet a reminder?";
		AddDialog(DialogType.NoTreasureReminderAsk, Expression.Serious, continuesInNextDialog: true, "scotty_out_of_treasure", message5);
		AddDialog(DialogType.NoTreasureReminderAsk, Expression.Serious, continuesInNextDialog: false, "scotty_hell_be_back", text + text2);
		AddDialog(DialogType.NoTreasureReminderSet, Expression.Serious, continuesInNextDialog: true, "scotty_out_of_treasure", message5);
		AddDialog(DialogType.NoTreasureReminderSet, Expression.Serious, continuesInNextDialog: false, "scotty_hell_be_back", text);
		AddDialog(DialogType.Score1, Expression.Stunned, continuesInNextDialog: false, "scotty_wizard", "How did ye guess? Ye must be a wizard!");
		AddDialog(DialogType.Score1, Expression.Serious, continuesInNextDialog: false, "scotty_getting_good", "Getting good at it, aren't ye?");
		AddDialog(DialogType.Score2, Expression.Frustrated, continuesInNextDialog: false, "scotty_grr", "Grr! This cannot be! Let's show what we can do lads!");
		AddDialog(DialogType.Score2, Expression.Frustrated, continuesInNextDialog: false, "scotty_noo_jist", "Blast it be! Ye gettin us each time!\n\nShow 'em our best lads!");
		AddDialog(DialogType.Score2, Expression.Frustrated, continuesInNextDialog: false, "scotty_noo_jist", "Noo jist hold on! We'll get ye now!\n\nGo strong lads!");
		AddDialog(DialogType.PlayerMisses, Expression.Condescending, continuesInNextDialog: false, "scotty_wrong_choice", "Wrong choice. Ye losing a point for that.");
		AddDialog(DialogType.PlayerMisses, Expression.Condescending, continuesInNextDialog: false, "scotty_wrong_choice", "Not so fancy now are ye? Point for us!");
		AddDialog(DialogType.PlayerMisses, Expression.Happy, continuesInNextDialog: false, "scotty_wrong_choice", "Hah, tricked ye this time! There goes a point.");
		AddDialog(DialogType.PlayerMissesScoreZero, Expression.Annoyed, continuesInNextDialog: false, "scotty_perhaps_the_rules", "Perhaps the rules aren't clear. Ye suppose to guess which of us has it.");
		AddDialog(DialogType.PlayerWinsFirstTime, Expression.Annoyed, continuesInNextDialog: false, "scotty_deuced", "Deuced! What's for ye'll no go by ye, I suppose.\n\nGet goin' then.");
		AddDialog(DialogType.PlayerWins, Expression.Happy, continuesInNextDialog: false, "scotty_well_met", "Well met! Here's your reward...", "Well met {0}! Here's your treasure...");
		AddDialog(DialogType.PlayerWins, Expression.Happy, continuesInNextDialog: false, "scotty_a_worthy_opponent", "A worthy opponent! Here's the treasure then...");
		AddDialog(DialogType.GoodBye, Expression.Happy, continuesInNextDialog: false, "scotty_pick_some_treasure", "I'll pick some [color=#00ffff]treasure[/color] for our next match. Come back a' play again!");
		AddDialog(DialogType.GoodBye2, Expression.Happy, continuesInNextDialog: false, "scotty_a_pleasure", "A pleasure as usual. Haste ye back for more [color=#00ffff]treasure[/color]!");
		AddDialog(DialogType.SpecialCaseSkullIsBack, Expression.Happy, continuesInNextDialog: false, "scotty_there_he_is", "There he is. We have [color=#00ffff]treasure[/color] now.");
		AddDialog(DialogType.ReferralQuestion, Expression.Suspicious, continuesInNextDialog: false, "scotty_there_he_is", Te.xt("tid_scotty_35"));
		AddDialog(DialogType.ReferralSuccess1, Expression.Happy, continuesInNextDialog: false, "scotty_there_he_is", Te.xt("tid_scotty_42"));
		AddDialog(DialogType.ReferralSuccess2, Expression.Annoyed, continuesInNextDialog: true, "scotty_there_he_is", Te.xt("tid_scotty_43"));
		AddDialog(DialogType.ReferralSuccess2, Expression.Serious, continuesInNextDialog: false, "scotty_there_he_is", message2);
		AddDialog(DialogType.ReferralError, Expression.Condescending, continuesInNextDialog: true, "scotty_there_he_is", Te.xt("tid_scotty_41"));
		AddDialog(DialogType.ReferralError, Expression.Happy, continuesInNextDialog: false, "scotty_there_he_is", Te.xt("tid_scotty_40"));
		AddDialog(DialogType.ReferralDeclined, Expression.Serious, continuesInNextDialog: true, "scotty_there_he_is", Te.xt("tid_scotty_36"));
		AddDialog(DialogType.ReferralDeclined, Expression.Serious, continuesInNextDialog: true, "scotty_there_he_is", Te.xt("tid_scotty_37"));
		AddDialog(DialogType.ReferralDeclined, Expression.Condescending, continuesInNextDialog: true, "scotty_there_he_is", Te.xt("tid_scotty_38"));
		AddDialog(DialogType.ReferralDeclined, Expression.Serious, continuesInNextDialog: true, "scotty_there_he_is", Te.xt("tid_scotty_39"));
		AddDialog(DialogType.ReferralDeclined, Expression.Happy, continuesInNextDialog: false, "scotty_there_he_is", Te.xt("tid_scotty_40"));
		AddDialog(DialogType.ReferralExhausted, Expression.Serious, continuesInNextDialog: true, "scotty_there_he_is", Te.xt("tid_scotty_44"));
		AddDialog(DialogType.ReferralExhausted, Expression.Annoyed, continuesInNextDialog: true, "scotty_there_he_is", Te.xt("tid_scotty_45"));
		AddDialog(DialogType.ReferralExhausted, Expression.Happy, continuesInNextDialog: false, "scotty_there_he_is", Te.xt("tid_scotty_46"));
	}

	public DialogData GetDialogForType(DialogType type)
	{
		string key = type.ToString();
		if (!dialogsPerTypeDict.ContainsKey(key))
		{
			Utils.LogError("[ScottyTheSkull] (1) There is no dialog for type " + type);
			return null;
		}
		if (!indexPerTypeDict.ContainsKey(key))
		{
			indexPerTypeDict.Add(key, -1);
		}
		int num = indexPerTypeDict[key];
		num = (num + 1) % dialogsPerTypeDict[key].Count;
		indexPerTypeDict[key] = num;
		if (num >= 0)
		{
			return dialogsPerTypeDict[key][num];
		}
		Utils.LogError("[ScottyTheSkull] (2) There is no dialog for type " + type);
		return null;
	}

	public DialogData GetRandomDialogForType(DialogType type)
	{
		List<DialogData> dialogListForType = GetDialogListForType(type);
		if (dialogListForType != null && dialogListForType.Count > 0)
		{
			int index = Random.Range(0, dialogListForType.Count);
			return dialogListForType[index];
		}
		Utils.LogError("[ScottyTheSkull] (3) There is no dialog for type " + type);
		return null;
	}

	public List<DialogData> GetDialogListForType(DialogType type)
	{
		string key = type.ToString();
		if (dialogsPerTypeDict.ContainsKey(key))
		{
			return dialogsPerTypeDict[key];
		}
		return null;
	}

	private void AddDialog(DialogData dialog)
	{
		allDialogs.Add(dialog);
		string key = dialog.type.ToString();
		if (!dialogsPerTypeDict.ContainsKey(key))
		{
			dialogsPerTypeDict.Add(key, new List<DialogData>());
		}
		dialogsPerTypeDict[key].Add(dialog);
	}

	private void AddDialog(DialogType type, Expression expression, bool continuesInNextDialog, string sfxId, string message, string playerNameAlternative = null)
	{
		DialogData dialogData = new DialogData();
		dialogData.type = type;
		dialogData.expression = expression;
		dialogData.continuesInNextDialog = continuesInNextDialog;
		dialogData.sfxId = sfxId;
		dialogData.message = message;
		dialogData.playerNameAlternativeMessage = playerNameAlternative;
		AddDialog(dialogData);
	}
}
