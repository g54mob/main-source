using System.Collections.Generic;
using UnityEngine;

public class DiagnosticsUI : MonoBehaviour
{
	private readonly int MAX_STONESCRIPT_ERRORS = 4;

	private List<AsciiString> stonescriptErrors = new List<AsciiString>();

	private List<AsciiString> asciiStrings = new List<AsciiString>();

	private Stack<AsciiString> stringPool = new Stack<AsciiString>();

	private bool isDrawing;

	private int lastWidth;

	public static DiagnosticsUI singleton { get; private set; }

	public static string GetOperatingSystemGlyph()
	{
		return "w";
	}

	private void UpdateContents()
	{
		ClearList();
		GameStates gameStates = GameStates.Singleton;
		HeroAI component = gameStates.hero.GetComponent<HeroAI>();
		Version vERSION = Features.VERSION;
		AddLine(" v" + vERSION.ToString() + " " + GetOperatingSystemGlyph());
		AddLine(" loc: " + ((gameStates.level.QuestData != null) ? (gameStates.level.QuestData.id + " ☆" + gameStates.level.QuestData.level) : "") + ", pos.x:" + gameStates.hero.PositionX + " .y:" + gameStates.hero.PositionY + " .z:" + gameStates.hero.PositionZ + ", time: " + gameStates.level.gameTime + ", totaltime: " + gameStates.GetTotalTime());
		AddLine(" " + component.DiagnosticString());
		AddLine(" State: " + gameStates.CurrentState.ToString() + ", Previous: " + gameStates.previousState);
		AddLine(" Pause Scheduled: " + gameStates.pauseScheduled + ", Can Leave: " + gameStates.userCanLeaveQuest);
		AddLine(" " + gameStates.level.DiagnosticsString());
		AddLine(" XP: " + gameStates.xpDialogScheduled + ", " + gameStates.level.XpEarned + ", " + XPController.singleton.HasXpStone() + "; " + EventController.singleton.DiagnosticsString());
		AddLine(" AI: " + (component.enabled ? "ON" : "OFF") + ((component.remainingPause > 0f) ? (" " + component.remainingPause) : "") + " Player State: " + gameStates.hero.CurrentState.ToString() + " " + GetLoadoutString());
		AddLine(" Res: " + SettingsResolutions.singleton.GetCurrentResolutionString() + ", VSync: " + QualitySettings.vSyncCount + ", vol:" + MusicController.singleton.GetActiveVolume() + ", tS: " + Time.timeScale + ", dT: " + Utils.deltaTime);
	}

	public override string ToString()
	{
		UpdateContents();
		string text = "";
		for (int i = 0; i < asciiStrings.Count; i++)
		{
			text += asciiStrings[i].Value;
			if (i < asciiStrings.Count - 1)
			{
				text += "\n";
			}
		}
		return text;
	}

	private void AddLine(string str)
	{
		if (str.Length > lastWidth)
		{
			string[] array = Utils.BreakIntoLines(str, lastWidth);
			for (int i = 0; i < array.Length; i++)
			{
				AddLine(array[i]);
			}
		}
		else
		{
			AsciiString asciiString = GetAsciiString();
			asciiStrings.Add(asciiString);
			asciiString.SetValue(str + " ");
			asciiString.color = Color.white;
		}
	}

	public void AddStonescriptError(string message)
	{
		AsciiString asciiString;
		if (stonescriptErrors.Count >= MAX_STONESCRIPT_ERRORS)
		{
			int index = stonescriptErrors.Count - 1;
			asciiString = stonescriptErrors[index];
			stonescriptErrors.RemoveAt(index);
		}
		else
		{
			asciiString = GetAsciiString();
		}
		stonescriptErrors.Insert(0, asciiString);
		asciiString.SetValue(message);
		asciiString.color = Color.red;
	}

	public void AddStonescriptWarning(string message)
	{
		AsciiString asciiString;
		if (stonescriptErrors.Count >= MAX_STONESCRIPT_ERRORS)
		{
			int index = stonescriptErrors.Count - 1;
			asciiString = stonescriptErrors[index];
			stonescriptErrors.RemoveAt(index);
		}
		else
		{
			asciiString = GetAsciiString();
		}
		stonescriptErrors.Insert(0, asciiString);
		asciiString.color = Color.yellow;
		asciiString.SetValue(message);
	}

	public void ClearStonescriptErrors()
	{
		for (int i = 0; i < stonescriptErrors.Count; i++)
		{
			stringPool.Push(stonescriptErrors[i]);
		}
		stonescriptErrors.Clear();
	}

	private void ClearList()
	{
		for (int i = 0; i < asciiStrings.Count; i++)
		{
			stringPool.Push(asciiStrings[i]);
		}
		asciiStrings.Clear();
	}

	private AsciiString GetAsciiString()
	{
		if (stringPool.Count > 0)
		{
			return stringPool.Pop();
		}
		return new AsciiString();
	}

	private void Update()
	{
		if (Input.GetKey(KeyCode.Tab))
		{
			isDrawing = true;
			UpdateContents();
		}
		else
		{
			isDrawing = false;
		}
	}

	public void Draw(AsciiRenderProcedural r)
	{
		lastWidth = r.width;
		if (!isDrawing)
		{
			return;
		}
		int num = 0;
		for (int i = 0; i < stonescriptErrors.Count; i++)
		{
			AsciiString asciiString = stonescriptErrors[i];
			float num2 = Mathf.Lerp(1f, 0.2f, (float)i / (float)MAX_STONESCRIPT_ERRORS);
			Color colorOverride = asciiString.color * num2;
			asciiString.Draw(r, 0, num, colorOverride);
			num++;
			if (asciiString.Length > lastWidth)
			{
				asciiString.Draw(r, -lastWidth, num, colorOverride);
				num++;
			}
		}
		num = r.height - 1;
		for (int num3 = asciiStrings.Count - 1; num3 >= 0; num3--)
		{
			asciiStrings[num3].Draw(r, 0, num);
			num--;
		}
	}

	private static string GetLoadoutString()
	{
		Hero hero = GameStates.Singleton.hero;
		string text = "";
		if ((bool)hero.LeftHand)
		{
			text += hero.LeftHand.GetGroupId();
		}
		text += ", ";
		if ((bool)hero.RightHand)
		{
			text += hero.RightHand.GetGroupId();
		}
		return text;
	}

	private void Awake()
	{
		singleton = this;
	}
}
