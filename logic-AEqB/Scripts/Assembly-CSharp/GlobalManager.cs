using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Steamworks.Data;
using Steamworks.Ugc;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalManager : MonoBehaviour
{
	public class ProgressClass : IProgress<float>
	{
		private float lastValue;

		public void Report(float val)
		{
			if (!(lastValue >= val))
			{
				lastValue = val;
				Manager manager = UnityEngine.Object.FindObjectOfType<Manager>();
				if ((bool)manager)
				{
					manager.gamelog.inputField.text = "Upload Progress: " + val;
				}
			}
		}
	}

	public bool isDev;

	public string SaveFileName = "globalSaveFile";

	public List<string> level_name;

	public string newlevel;

	public string SaveDir = "";

	public bool sandbox;

	public new_level_info level;

	public new_level_info editor_level;

	public new_level_info sandbox_level;

	public List<short_level_info> levels;

	public chapter_info[] chapters;

	public bool isLevelEditor = true;

	public bool allowChineseInput;

	private string s1;

	private string s2;

	public Dictionary<char, char> dict;

	public SteamManager steamManager;

	public float LastScrollPos = 1f;

	public List<new_level_info> custom_levels;

	public List<new_level_info> custom_levels_workshop;

	public List<string> solved;

	public new_level_info editor_chosen;

	public bool newcustomlevel;

	public save_list sv;

	public setting_list setting;

	public string[] filenames;

	public string[] workshop_filenames;

	public string[] custom_filenames;

	public string[] last_custom_filenames;

	private void Awake()
	{
	}

	private void Start()
	{
		UnityEngine.Object.DontDestroyOnLoad(this);
		Application.targetFrameRate = 30;
		Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
	}

	public async void TryUpload(new_level_info lv)
	{
		if (lv.workshop_id == 0L)
		{
			await UploadToSteam(lv);
		}
		else
		{
			await EditSteam(lv);
		}
	}

	private async Task UploadToSteam(new_level_info lv)
	{
		string folderName = Application.dataPath + "/custom/" + lv.id + ".a2b";
		PublishResult publishResult = await Steamworks.Ugc.Editor.NewCommunityFile.WithTitle(lv.title_en).WithDescription(lv.quest_en).WithTag("level")
			.WithContent(folderName)
			.WithPublicVisibility()
			.SubmitAsync(new ProgressClass());
		if (publishResult.Success)
		{
			Manager manager = UnityEngine.Object.FindObjectOfType<Manager>();
			if ((bool)manager)
			{
				manager.gamelog.inputField.text = "Upload Succeeded";
				manager.editor_info.workshop_id = publishResult.FileId;
				manager.ChangePanel(100);
			}
		}
		else
		{
			Manager manager2 = UnityEngine.Object.FindObjectOfType<Manager>();
			if ((bool)manager2)
			{
				manager2.gamelog.inputField.text = "Upload Failed";
			}
		}
	}

	private async Task EditSteam(new_level_info lv)
	{
		PublishedFileId fileId = lv.workshop_id;
		UnityEngine.Debug.Log("is Update");
		UnityEngine.Debug.Log(steamManager.PlayerSteamIdString);
		string folderName = Application.dataPath + "/custom/" + lv.id + ".a2b";
		PublishResult publishResult = await new Editor(fileId).WithTitle(lv.title_en).WithDescription(lv.quest_en).WithTag("level")
			.WithContent(folderName)
			.WithPublicVisibility()
			.SubmitAsync(new ProgressClass());
		UnityEngine.Debug.Log("Upload: " + publishResult.Success);
		if (publishResult.Success)
		{
			Manager manager = UnityEngine.Object.FindObjectOfType<Manager>();
			if ((bool)manager)
			{
				manager.gamelog.inputField.text = "Update Succeeded";
			}
			return;
		}
		Manager manager2 = UnityEngine.Object.FindObjectOfType<Manager>();
		if ((bool)manager2)
		{
			manager2.gamelog.inputField.text = "Update Failed\nUpload as new workshop item";
			await UploadToSteam(lv);
		}
	}

	private void Update()
	{
	}

	public void solveLevel()
	{
		if (!solved.Contains(level.id))
		{
			solved.Add(level.id);
			Save();
		}
	}

	public void ChooseLevel(short_level_info lv)
	{
		string text = Application.dataPath + "/task/";
		text = text + lv.id + ".a2b";
		UnityEngine.Debug.Log(text);
		if (File.Exists(text))
		{
			StreamReader streamReader = File.OpenText(text);
			string json = streamReader.ReadToEnd();
			level = JsonUtility.FromJson<new_level_info>(json);
			streamReader.Close();
			if (level.quest_ch == "")
			{
				level.quest_ch = level.quest_cht;
				level.title_ch = level.title_cht;
			}
			if (level.quest_cht == "")
			{
				level.quest_cht = level.quest_ch;
				level.title_cht = level.title_ch;
			}
			if (level.quest_ch == "")
			{
				level.quest_ch = level.quest_en;
				level.title_ch = level.title_en;
			}
			if (level.quest_cht == "")
			{
				level.quest_cht = level.quest_en;
				level.title_cht = level.title_en;
			}
			if (level.quest_jp == "")
			{
				level.quest_jp = level.quest_en;
				level.title_jp = level.title_en;
			}
		}
		LastScrollPos = UnityEngine.Object.FindObjectOfType<NewMenuManager>().display_scroll.value;
		SceneManager.LoadScene(1);
	}

	public void FillEmpty()
	{
		if (level.quest_ch == "")
		{
			level.quest_ch = level.quest_cht;
			level.title_ch = level.title_cht;
		}
		if (level.quest_cht == "")
		{
			level.quest_cht = level.quest_ch;
			level.title_cht = level.title_ch;
		}
		if (level.quest_ch == "")
		{
			level.quest_ch = level.quest_en;
			level.title_ch = level.title_en;
		}
		if (level.quest_cht == "")
		{
			level.quest_cht = level.quest_en;
			level.title_cht = level.title_en;
		}
		if (level.quest_jp == "")
		{
			level.quest_jp = level.quest_en;
			level.title_jp = level.title_en;
		}
	}

	public void ChooseCustomLevel(new_level_info lv)
	{
		if (lv.input != null && lv.input.Count != 0 && lv.input.Count == lv.output.Count)
		{
			level = lv;
			if (level.quest_ch == "")
			{
				level.quest_ch = level.quest_cht;
				level.title_ch = level.title_cht;
			}
			if (level.quest_cht == "")
			{
				level.quest_cht = level.quest_ch;
				level.title_cht = level.title_ch;
			}
			if (level.quest_ch == "")
			{
				level.quest_ch = level.quest_en;
				level.title_ch = level.title_en;
			}
			if (level.quest_cht == "")
			{
				level.quest_cht = level.quest_en;
				level.title_cht = level.title_en;
			}
			if (level.quest_jp == "")
			{
				level.quest_jp = level.quest_en;
				level.title_jp = level.title_en;
			}
			LastScrollPos = UnityEngine.Object.FindObjectOfType<NewMenuManager>().display_scroll.value;
			SceneManager.LoadScene(1);
		}
	}

	public void Editor()
	{
		level = editor_level;
		newcustomlevel = true;
		SceneManager.LoadScene(1);
	}

	public void Editor(int id)
	{
		level = editor_level;
		newcustomlevel = false;
		editor_chosen = custom_levels[id];
		SceneManager.LoadScene(1);
	}

	public void SandBox()
	{
		level = sandbox_level;
		SceneManager.LoadScene(1);
	}

	public void SetSaveSlot(int slot)
	{
		Save();
		setting.saveslot = slot;
		setting.last_chapter = 1;
		SaveSetting();
		Load();
		UnityEngine.Object.FindObjectOfType<NewMenuManager>().Setting();
	}

	public void SetTheme(bool isDark)
	{
		setting.theme = isDark;
		UnityEngine.Object.FindObjectOfType<NewMenuManager>().DarkTheme(isDark);
		UnityEngine.Object.FindObjectOfType<NewMenuManager>().Setting();
	}

	public void SetLanguage(int lan)
	{
		UnityEngine.Debug.Log(lan);
		setting.language = lan;
		UnityEngine.Object.FindObjectOfType<NewMenuManager>().Setting();
	}

	public void SaveSetting()
	{
		if (!Directory.Exists(Application.dataPath + "/save/" + steamManager.PlayerSteamIdString + "/"))
		{
			Directory.CreateDirectory(Application.dataPath + "/save/" + steamManager.PlayerSteamIdString + "/");
		}
		FileInfo fileInfo = new FileInfo(Application.dataPath + "/save/" + steamManager.PlayerSteamIdString + "/setting.sav");
		StreamWriter streamWriter;
		if (!fileInfo.Exists)
		{
			streamWriter = fileInfo.CreateText();
		}
		else
		{
			fileInfo.Delete();
			streamWriter = fileInfo.CreateText();
		}
		streamWriter.Write(JsonUtility.ToJson(setting, prettyPrint: true));
		streamWriter.Close();
	}

	public void SetFullScreen(int isFull)
	{
		setting.fullscreen = isFull;
		switch (isFull)
		{
		case 0:
			Screen.fullScreen = true;
			Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, fullscreen: true);
			break;
		case 1:
			Screen.fullScreen = false;
			Screen.SetResolution(1280, 720, fullscreen: false);
			break;
		case 2:
			Screen.fullScreen = false;
			Screen.SetResolution(1600, 900, fullscreen: false);
			break;
		}
		UnityEngine.Object.FindObjectOfType<NewMenuManager>().Setting();
		setting.fontsize = 3;
	}

	public void Save()
	{
		if (!Directory.Exists(Application.dataPath + "/save/" + steamManager.PlayerSteamIdString + "/"))
		{
			Directory.CreateDirectory(Application.dataPath + "/save/" + steamManager.PlayerSteamIdString + "/");
		}
		if (!Directory.Exists(Application.dataPath + "/save/" + steamManager.PlayerSteamIdString + "/0/"))
		{
			Directory.CreateDirectory(Application.dataPath + "/save/" + steamManager.PlayerSteamIdString + "/0/");
		}
		if (!Directory.Exists(Application.dataPath + "/save/" + steamManager.PlayerSteamIdString + "/1/"))
		{
			Directory.CreateDirectory(Application.dataPath + "/save/" + steamManager.PlayerSteamIdString + "/1/");
		}
		if (!Directory.Exists(Application.dataPath + "/save/" + steamManager.PlayerSteamIdString + "/2/"))
		{
			Directory.CreateDirectory(Application.dataPath + "/save/" + steamManager.PlayerSteamIdString + "/2/");
		}
		FileInfo fileInfo = new FileInfo(Application.dataPath + "/save/" + steamManager.PlayerSteamIdString + "/" + setting.saveslot + "/" + SaveFileName + ".sav");
		StreamWriter streamWriter;
		if (!fileInfo.Exists)
		{
			streamWriter = fileInfo.CreateText();
		}
		else
		{
			fileInfo.Delete();
			streamWriter = fileInfo.CreateText();
		}
		bool[] array = new bool[10];
		bool[] array2 = new bool[10];
		int num = 0;
		save_info item = default(save_info);
		foreach (short_level_info level in levels)
		{
			bool flag = true;
			if (level.story_en != "")
			{
				flag = false;
			}
			else
			{
				foreach (save_info datum in sv.data)
				{
					if (datum.id == level.id)
					{
						flag = false;
					}
				}
			}
			if (flag)
			{
				item.id = level.id;
				item.solved = false;
				item.lastpanel = 0;
				item.challenge = false;
				item.challenge_line = -1;
				sv.data.Add(item);
			}
		}
		for (int i = 0; i <= 9; i++)
		{
			array[i] = true;
			array2[i] = true;
		}
		for (int j = 0; j < sv.data.Count; j++)
		{
			if (solved.Contains(sv.data[j].id))
			{
				sv.data[j] = new save_info(sv.data[j].id, s: true, sv.data[j].lastpanel, sv.data[j].challenge, sv.data[j].challenge_line);
			}
			if (!sv.data[j].solved)
			{
				array[sv.data[j].id[1] - 48] = false;
				array2[sv.data[j].id[1] - 48] = false;
				continue;
			}
			foreach (short_level_info level2 in levels)
			{
				if (level2.id == sv.data[j].id)
				{
					if (level2.line < sv.data[j].challenge_line && sv.data[j].challenge_line != -1)
					{
						array2[sv.data[j].id[1] - 48] = false;
					}
					if (level2.line > sv.data[j].challenge_line && sv.data[j].challenge_line != -1)
					{
						num++;
					}
				}
			}
		}
		bool flag2 = true;
		bool flag3 = true;
		for (int k = 1; k <= 6; k++)
		{
			if (array[k])
			{
				steamManager.UnlockAchievements("c" + k);
			}
			else
			{
				flag2 = false;
			}
			if (array2[k])
			{
				steamManager.UnlockAchievements("cc" + k);
			}
			else
			{
				flag3 = false;
			}
		}
		if (num > 0)
		{
			steamManager.UnlockAchievements("b1");
		}
		if (num >= 10)
		{
			steamManager.UnlockAchievements("b5");
		}
		if (flag2)
		{
			steamManager.UnlockAchievements("all");
		}
		if (flag3)
		{
			steamManager.UnlockAchievements("all2");
		}
		streamWriter.Write(JsonUtility.ToJson(sv, prettyPrint: true));
		streamWriter.Close();
	}

	public void StoryRead(string id)
	{
		if (!sv.story.Contains(id))
		{
			sv.story.Add(id);
			Save();
		}
	}

	public void OnApplicationQuit()
	{
		Save();
		SaveSetting();
	}

	public void Load()
	{
		if (steamManager == null)
		{
			steamManager = base.gameObject.AddComponent<SteamManager>();
			steamManager.SetUp();
		}
		string path = Application.dataPath + "/save/" + steamManager.PlayerSteamIdString + "/setting.sav";
		if (File.Exists(path))
		{
			StreamReader streamReader = File.OpenText(path);
			string text = streamReader.ReadToEnd();
			streamReader.Close();
			try
			{
				setting = JsonUtility.FromJson<setting_list>(text);
				if (setting == null)
				{
					throw new Exception("no string");
				}
				FileInfo fileInfo = new FileInfo(Application.dataPath + "/save/" + steamManager.PlayerSteamIdString + "/setting_backup.sav");
				StreamWriter streamWriter;
				if (!fileInfo.Exists)
				{
					streamWriter = fileInfo.CreateText();
				}
				else
				{
					fileInfo.Delete();
					streamWriter = fileInfo.CreateText();
				}
				streamWriter.Write(text);
				streamWriter.Close();
			}
			catch (Exception ex)
			{
				UnityEngine.Debug.Log(ex.Message);
				try
				{
					string text2 = Application.dataPath + "/save/" + steamManager.PlayerSteamIdString + "/setting_backup.sav";
					UnityEngine.Debug.Log(text2);
					StreamReader streamReader2 = File.OpenText(text2);
					string text3 = streamReader2.ReadToEnd();
					streamReader2.Close();
					setting = JsonUtility.FromJson<setting_list>(text3);
					UnityEngine.Debug.Log(text3);
				}
				catch (Exception ex2)
				{
					UnityEngine.Debug.Log(ex2.Message);
					setting = new setting_list();
				}
			}
		}
		else
		{
			setting = new setting_list();
		}
		if (setting == null)
		{
			setting = new setting_list();
		}
		string path2 = Application.dataPath + "/save/" + steamManager.PlayerSteamIdString + "/" + setting.saveslot + "/" + SaveFileName + ".sav";
		sv = new save_list();
		if (File.Exists(path2))
		{
			StreamReader streamReader3 = File.OpenText(path2);
			try
			{
				string text4 = streamReader3.ReadToEnd();
				sv = JsonUtility.FromJson<save_list>(text4);
				if (sv == null)
				{
					throw new Exception("no string");
				}
				FileInfo fileInfo2 = new FileInfo(Application.dataPath + "/save/" + steamManager.PlayerSteamIdString + "/" + setting.saveslot + "/" + SaveFileName + "_old.sav");
				StreamWriter streamWriter2;
				if (!fileInfo2.Exists)
				{
					streamWriter2 = fileInfo2.CreateText();
				}
				else
				{
					fileInfo2.Delete();
					streamWriter2 = fileInfo2.CreateText();
				}
				streamWriter2.Write(text4);
				streamWriter2.Close();
			}
			catch (Exception message)
			{
				UnityEngine.Debug.Log(message);
				try
				{
					StreamReader streamReader4 = File.OpenText(Application.dataPath + "/save/" + steamManager.PlayerSteamIdString + "/" + setting.saveslot + "/" + SaveFileName + "_old.sav");
					string json = streamReader4.ReadToEnd();
					sv = JsonUtility.FromJson<save_list>(json);
					streamReader4.Close();
				}
				catch (Exception message2)
				{
					sv = new save_list();
					UnityEngine.Debug.Log(message2);
				}
			}
			streamReader3.Close();
		}
		if (sv == null)
		{
			sv = new save_list();
		}
		string path3 = Application.dataPath + "/task/";
		string[] files = Directory.GetFiles(path3, "c*.txt");
		Directory.GetFiles(path3, "c*.a2b");
		levels = new List<short_level_info>();
		for (int i = 0; i < files.Length - 1; i++)
		{
			for (int j = i + 1; j < files.Length; j++)
			{
				string[] array = files[i].Substring(files[i].LastIndexOf('/')).Split('_');
				int num = 0;
				float num2 = 0f;
				num = array[0][1] - 48;
				num2 = ((array[1][array[1].Length - 1] != 'a') ? ((float)Convert.ToInt32(array[1])) : ((float)Convert.ToInt32(array[1].Remove(array[1].Length - 1)) + 0.5f));
				string[] array2 = files[j].Substring(files[j].LastIndexOf('/')).Split('_');
				int num3 = 0;
				float num4 = 0f;
				num3 = array2[0][1] - 48;
				num4 = ((array2[1][array2[1].Length - 1] != 'a') ? ((float)Convert.ToInt32(array2[1])) : ((float)Convert.ToInt32(array2[1].Remove(array2[1].Length - 1)) + 0.5f));
				if (num > num3 || (num == num3 && num2 > num4))
				{
					string text5 = files[i];
					files[i] = files[j];
					files[j] = text5;
				}
			}
		}
		string[] array3 = files;
		for (int k = 0; k < array3.Length; k++)
		{
			StreamReader streamReader5 = File.OpenText(array3[k]);
			short_level_info item = JsonUtility.FromJson<short_level_info>(streamReader5.ReadToEnd());
			streamReader5.Close();
			levels.Add(item);
		}
		custom_levels = new List<new_level_info>();
		custom_levels_workshop = new List<new_level_info>();
		RefreshCustom();
		RefreshWorkshop();
		save_info item2 = default(save_info);
		foreach (short_level_info level in levels)
		{
			bool flag = true;
			if (level.story_en != "")
			{
				flag = false;
			}
			else
			{
				foreach (save_info datum in sv.data)
				{
					if (datum.id == level.id)
					{
						flag = false;
					}
				}
			}
			if (flag)
			{
				item2.id = level.id;
				item2.solved = false;
				item2.lastpanel = 0;
				item2.challenge = false;
				item2.challenge_line = -1;
				sv.data.Add(item2);
			}
		}
		solved = new List<string>();
		foreach (save_info datum2 in sv.data)
		{
			if (datum2.solved)
			{
				solved.Add(datum2.id);
			}
		}
	}

	public void RefreshWorkshop()
	{
		string text = Application.dataPath + "\\..\\..\\..\\workshop\\content\\1720850";
		if (!Directory.Exists(text) && Application.dataPath.Contains("Unity"))
		{
			text = "C:\\Program Files (x86)\\Steam\\steamapps\\workshop\\content\\1720850";
		}
		if (!Directory.Exists(text))
		{
			return;
		}
		UnityEngine.Debug.Log(text);
		string[] files = Directory.GetFiles(text, "*.a2b", SearchOption.AllDirectories);
		if (workshop_filenames != null && files.Length == workshop_filenames.Length)
		{
			return;
		}
		custom_levels_workshop = new List<new_level_info>();
		for (int i = 0; i < files.Length; i++)
		{
			UnityEngine.Debug.Log(files[i]);
			StreamReader streamReader = File.OpenText(files[i]);
			try
			{
				new_level_info item = JsonUtility.FromJson<new_level_info>(streamReader.ReadToEnd());
				custom_levels_workshop.Add(item);
			}
			catch
			{
			}
			streamReader.Close();
		}
		workshop_filenames = files;
	}

	public void RefreshCustom()
	{
		custom_levels = new List<new_level_info>();
		string path = Application.dataPath + "/custom/";
		if (!Directory.Exists(path))
		{
			Directory.CreateDirectory(path);
			return;
		}
		string[] files = Directory.GetFiles(path, "*.a2b");
		for (int i = 0; i < files.Length; i++)
		{
			StreamReader streamReader = File.OpenText(files[i]);
			try
			{
				new_level_info item = JsonUtility.FromJson<new_level_info>(streamReader.ReadToEnd());
				custom_levels.Add(item);
			}
			catch
			{
			}
			streamReader.Close();
		}
	}

	public void Init()
	{
		if (!Directory.Exists(Application.dataPath + "/task/"))
		{
			Directory.CreateDirectory(Application.dataPath + "/task/");
		}
		string path = Application.dataPath + "/task/editor.a2b";
		if (File.Exists(path))
		{
			StreamReader streamReader = File.OpenText(path);
			string json = streamReader.ReadToEnd();
			editor_level = JsonUtility.FromJson<new_level_info>(json);
			streamReader.Close();
		}
		path = Application.dataPath + "/task/sandbox.a2b";
		if (File.Exists(path))
		{
			StreamReader streamReader2 = File.OpenText(path);
			string json2 = streamReader2.ReadToEnd();
			sandbox_level = JsonUtility.FromJson<new_level_info>(json2);
			streamReader2.Close();
		}
		chapters = new chapter_info[10];
		string path2 = Application.dataPath + "/chs.txt";
		string path3 = Application.dataPath + "/cht.txt";
		StreamReader streamReader3 = File.OpenText(path2);
		StreamReader streamReader4 = File.OpenText(path3);
		s1 = streamReader3.ReadToEnd();
		s2 = streamReader4.ReadToEnd();
		dict = new Dictionary<char, char>();
		for (int i = 0; i < s1.Length; i++)
		{
			if (!dict.ContainsKey(s1[i]))
			{
				dict.Add(s1[i], s2[i]);
			}
		}
	}

	public string ToChineseTraditional(string s)
	{
		string text = "";
		for (int i = 0; i < s.Length; i++)
		{
			text = ((s[i] != '划') ? ((!dict.ContainsKey(s[i])) ? (text + s[i]) : (text + dict[s[i]])) : (text + "畫"));
		}
		return text;
	}

	public void OpenPDF(string filename)
	{
		Process.Start("explorer.exe", (Application.dataPath + "/manual/" + filename).Replace('/', '\\'));
	}
}
