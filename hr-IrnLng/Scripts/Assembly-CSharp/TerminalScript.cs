using System;
using TMPro;
using UnityEngine;

public class TerminalScript : MonoBehaviour
{
	[Serializable]
	public class entry
	{
		[TextArea(15, 20)]
		public string EntryText;

		public string[] Queries;
	}

	public entry[] Entries;

	public string ConsoleText;

	public TextMeshProUGUI Console;

	public TextMeshProUGUI Text;

	public bool CanType;

	private CanvasGroup MyGroup;

	private SteamScript SScript;

	private MaterialManagerScript MManager;

	public GameObject RealtimeScreen;

	public GameObject SubCamera;

	public GameObject MainPost;

	public GameObject NoirPost;

	private MainLightScript MainLight;

	private Light Flashlight;

	private void Start()
	{
		SScript = GameObject.Find("SteamObject").GetComponent<SteamScript>();
		MManager = GameObject.Find("MaterialManager").GetComponent<MaterialManagerScript>();
		MainLight = GameObject.Find("MainLight").GetComponent<MainLightScript>();
		Flashlight = GameObject.Find("Flashlight").GetComponent<Light>();
		MyGroup = GetComponent<CanvasGroup>();
		ClearConsole();
		ClearText();
	}

	private void Update()
	{
		if (!CanType)
		{
			MyGroup.alpha = 0f;
			return;
		}
		MyGroup.alpha = 1f;
		GetInput();
	}

	public void GetInput()
	{
		if (Input.GetKeyDown(KeyCode.Return))
		{
			CheckQuery();
			ClearConsole();
			return;
		}
		string inputString = Input.inputString;
		if (inputString.Length == 1)
		{
			char c = char.Parse(inputString);
			if (char.IsLetter(c) || char.IsNumber(c) || char.IsWhiteSpace(c))
			{
				Console.text = Console.text.Substring(0, Console.text.Length - 1);
				TextMeshProUGUI console = Console;
				console.text = console.text + c + "_";
			}
		}
		if (Input.GetKeyDown(KeyCode.Backspace) && Console.text.Length > 1)
		{
			Console.text = Console.text.Substring(0, Console.text.Length - 2);
			Console.text += "_";
		}
	}

	public void CheckQuery()
	{
		string text = Console.text.Substring(0, Console.text.Length - 1).ToLower();
		for (int i = 0; i < Entries.Length; i++)
		{
			for (int j = 0; j < Entries[i].Queries.Length; j++)
			{
				if (text == "query>" + Entries[i].Queries[j])
				{
					OpenEntry(i);
					return;
				}
			}
		}
		if (!CheatCheck(text))
		{
			Text.text += "\nunknown query\n\n";
		}
	}

	public void OpenEntry(int entry)
	{
		TextMeshProUGUI text = Text;
		text.text = text.text + "\n" + Entries[entry].EntryText + "\n\n";
		if (entry == 7)
		{
			SScript.UnlockCheevo("all_lore");
		}
	}

	public void ClearConsole()
	{
		Console.text = "query>_";
	}

	public void ClearText()
	{
		Text.text = "<c.o.i informational terminal>\nThis is a local database.  Be sure to update before each descent.\nLast updated today [5/378]";
	}

	public bool CheatCheck(string s)
	{
		switch (s)
		{
		case "query>chclear":
			MManager.TextureType = MaterialManagerScript.TexTypes.Default;
			MManager.ChangeTextures();
			RealtimeScreen.SetActive(value: false);
			SubCamera.SetActive(value: false);
			NoirPost.SetActive(value: false);
			MainPost.SetActive(value: true);
			MainLight.DoRave = false;
			GameObject.Find("Speaker").GetComponent<Renderer>().enabled = false;
			Flashlight.enabled = false;
			Text.text += "\nall cheats cleared\n\n";
			return true;
		case "query>chmark":
			MManager.TextureType = MaterialManagerScript.TexTypes.MarkiplierMode;
			MManager.ChangeTextures();
			Text.text += "\nactivated 'markiplier mode'\n\n";
			return true;
		case "query>chview":
			RealtimeScreen.SetActive(value: true);
			SubCamera.SetActive(value: true);
			Text.text += "\nnow you can see!\n\n";
			return true;
		case "query>chnoir":
			NoirPost.SetActive(value: true);
			MainPost.SetActive(value: false);
			Text.text += "\nnoir mode activated\n\n";
			return true;
		case "query>chrave":
			MainLight.DoRave = true;
			Text.text += "\nrave mode activated\n\n";
			return true;
		case "query>chava":
			GameObject.Find("Speaker").GetComponent<Renderer>().enabled = true;
			Text.text += "\nspeaker activated\n\n";
			return true;
		case "query>chvest":
			Flashlight.enabled = true;
			Text.text += "\nLife vest activated\n\n";
			return true;
		default:
			return false;
		}
	}
}
