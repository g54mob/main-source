using System.Collections.Generic;
using UnityEngine;

public class DiscordUpsell : CreditsASlide
{
	public DialogButton discordButton;

	private string chatServerUrl = "http://StoneStoryRPG.com/discord";

	private string[] text = new string[14]
	{
		"Stone Story chat", "on Discord", "", "  _   _  ", " /\u00b4\u00af\u00af\u00af`\\ ", "/  O O  \\", "\\_>---<_/", "", "", "Follow daily development of the game.",
		"", "Exchange strategy and tips with other players.", "", "Submit feedback and bugs."
	};

	private List<AsciiString> asciiStrings;

	private int linesShown;

	private bool isDone;

	public override void Reset()
	{
		if (asciiStrings == null)
		{
			asciiStrings = new List<AsciiString>(text.Length);
			for (int i = 0; i < text.Length; i++)
			{
				AsciiString asciiString = new AsciiString();
				asciiString.alignment = AsciiString.Alignment.Center;
				asciiString.SetValue(text[i]);
				asciiStrings.Add(asciiString);
			}
		}
		linesShown = 0;
		isDone = false;
	}

	public override void UpdateTic()
	{
		discordButton.UpdateTic();
		linesShown++;
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		int offsetX2 = r.width / 2;
		int num = (r.height - asciiStrings.Count) / 2 - 2;
		for (int i = 0; i < asciiStrings.Count && i < linesShown; i++)
		{
			asciiStrings[i].Draw(r, offsetX2, num);
			num++;
		}
		if (linesShown > asciiStrings.Count)
		{
			discordButton.Draw(r, offsetX2, num);
		}
	}

	public override bool IsDone()
	{
		return isDone;
	}

	private void HandleDiscordButtonPressed(DialogButton btn)
	{
		isDone = true;
		AnalyticsMacros.PressedDiscordButton();
		Application.OpenURL(chatServerUrl);
	}

	private void HandleClickedOutsideButton()
	{
		if (linesShown > asciiStrings.Count + 2)
		{
			isDone = true;
		}
	}

	private void Start()
	{
		discordButton.OnPressed += HandleDiscordButtonPressed;
		discordButton.OnClickedOutside += HandleClickedOutsideButton;
	}

	private void OnDestroy()
	{
		discordButton.OnPressed -= HandleDiscordButtonPressed;
		discordButton.OnClickedOutside -= HandleClickedOutsideButton;
	}
}
