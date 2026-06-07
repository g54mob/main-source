using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;
using DevConsole;
using Steamworks;
using TinyJson;
using Tyd;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class LocalizorButton : MonoBehaviour
{
	public Text NameLabel;

	public Text ButtonLabel;

	public Text ProgLabel;

	public RectTransform Prog1;

	public RectTransform Prog2;

	public RectTransform ProgBack;

	public Button DownloadButton;

	public Image Flag;

	private string _downloadUrl;

	private string _versionUrl;

	private string _downloadName;

	private int _id;

	private int _version;

	public void Init(string name, string downloadName, string url, int id, string versionUrl, int version, float approved, float suggested)
	{
		Prog1.anchorMax = new Vector2(suggested, 1f);
		Prog1.sizeDelta = new Vector2(0f, 0f);
		Prog2.anchorMax = new Vector2(approved, 1f);
		Prog2.sizeDelta = new Vector2(0f, 0f);
		_downloadName = downloadName;
		_downloadUrl = url;
		_versionUrl = versionUrl;
		_version = version;
		_id = id;
		NameLabel.text = name;
		Flag.sprite = ObjectDatabase.Instance.TryGetFlag(name);
		ProgLabel.text = approved.ToPercent();
	}

	public void Download()
	{
		StartCoroutine(DownloadLanguage(_downloadUrl, _downloadName, _versionUrl, -1, ButtonLabel, DownloadButton, base.gameObject));
	}

	public void ShowLocalizor()
	{
		if (SteamManager.Initialized && SteamUtils.IsOverlayEnabled())
		{
			SteamFriends.ActivateGameOverlayToWebPage("https://translate.Coredumping.com/language.php?l=" + _id);
		}
		else
		{
			Application.OpenURL("https://translate.Coredumping.com/language.php?l=" + _id);
		}
	}

	private static byte[] DecompressToBytes(byte[] input)
	{
		using (MemoryStream stream = new MemoryStream(input))
		{
			using (GZipStream gZipStream = new GZipStream(stream, CompressionMode.Decompress))
			{
				using (MemoryStream memoryStream = new MemoryStream())
				{
					gZipStream.CopyTo(memoryStream);
					return memoryStream.ToArray();
				}
			}
		}
	}

	public static string DecompressToString(byte[] input)
	{
		if (input.Length <= 2 || input[0] != 31 || input[1] != 139)
		{
			return Encoding.UTF8.GetString(input);
		}
		byte[] bytes = DecompressToBytes(input);
		return Encoding.UTF8.GetString(bytes);
	}

	public static IEnumerator DownloadLanguage(string downloadUrl, string downloadName, string versionLink, int version, Text debugLabel, Button initiater, GameObject destroy = null)
	{
		if (debugLabel != null)
		{
			initiater.interactable = false;
			debugLabel.text = "Pleasewait".Loc();
		}
		UnityWebRequest web;
		if (version < 0 && !string.IsNullOrWhiteSpace(versionLink))
		{
			web = UnityWebRequest.Get(versionLink);
			web.SetRequestHeader("User-Agent", "Swinc User Agent");
			yield return web.SendWebRequest();
			if (web.error != null)
			{
				if (debugLabel != null)
				{
					debugLabel.text = "Error".Loc();
				}
				DevConsole.Console.LogError("Failed downloaded translation version:\n" + web.error.ToString());
				yield break;
			}
			version = web.downloadHandler.text.ConvertToIntDef(0);
		}
		web = UnityWebRequest.Get(downloadUrl);
		web.SetRequestHeader("User-Agent", "Swinc User Agent");
		yield return web.SendWebRequest();
		if (web.error == null)
		{
			Dictionary<string, string> dictionary = DecompressToString(web.downloadHandler.data).FromJson<Dictionary<string, string>>();
			if (dictionary.Count > 0)
			{
				Dictionary<string, TydList> lists = new Dictionary<string, TydList>();
				TydDocument root = new TydDocument();
				foreach (KeyValuePair<string, string> item in dictionary)
				{
					ParseNode(item.Key, item.Value, root, lists);
				}
				string subFolder = Path.Combine(Localization.LocalizationFolder, downloadName);
				if (!Directory.Exists(subFolder))
				{
					Directory.CreateDirectory(subFolder);
				}
				try
				{
					string[] files = Directory.GetFiles(subFolder, "*.tyd");
					for (int i = 0; i < files.Length; i++)
					{
						File.Delete(files[i]);
					}
				}
				catch (Exception)
				{
				}
				string credits = "N/A";
				UnityWebRequest webc = UnityWebRequest.Get(downloadUrl + "&credits=1");
				webc.SetRequestHeader("User-Agent", "Swinc User Agent");
				yield return webc.SendWebRequest();
				if (webc.error == null)
				{
					credits = webc.downloadHandler.text.Replace("\"", "\\\"");
				}
				File.WriteAllText(Path.Combine(subFolder, "translation.tyd"), TydToText.Write(root, true, 0, 0, true, false, false, true), Encoding.UTF8);
				string text = "https://translate.Coredumping.com".Substring("https://translate.Coredumping.com".IndexOf("://") + 3);
				File.WriteAllText(Path.Combine(subFolder, "meta.tyd"), "Name \"" + downloadName + "\"\nAuthor \"" + credits + "\"\nDescription \"Downloaded from " + text + "\"\nDownloadLink \"" + downloadUrl + "\"\n" + string.Format("Version \"{0}\"\n", version) + "VersionLink \"" + versionLink + "\"");
				try
				{
					Localization.Translation translation = new Localization.Translation("Localization/" + downloadName);
					Localization.AddLanguage(translation);
					if (LanguageWindow.Instance != null)
					{
						LanguageWindow.Instance.Refresh();
						LanguageWindow.Instance.SelectLanguage(translation);
					}
					if (debugLabel != null)
					{
						if (destroy != null)
						{
							debugLabel.text = "Done".Loc();
							yield break;
						}
						initiater.interactable = true;
						debugLabel.text = "Download".Loc();
					}
				}
				catch (Exception ex2)
				{
					if (debugLabel != null)
					{
						debugLabel.text = "Error".Loc();
					}
					DevConsole.Console.LogError("Localization failed loading language with error:\n" + ex2.ToString());
				}
			}
			else
			{
				if (debugLabel != null)
				{
					debugLabel.text = "Error".Loc();
				}
				DevConsole.Console.LogError("Translation was empty");
			}
		}
		else
		{
			if (debugLabel != null)
			{
				debugLabel.text = "Error".Loc();
				initiater.interactable = true;
			}
			DevConsole.Console.LogError("Failed downloading translation:\n" + web.error);
		}
	}

	private static void ParseNode(string keys, string value, TydDocument doc, Dictionary<string, TydList> lists)
	{
		string[] array = keys.Split('|');
		if (array.Length > 1)
		{
			if (array[0].Equals("Plural"))
			{
				TydTable node = new TydTable("Item", new TydString("Name", array[1]), new TydString("Plural", array[2]), new TydString("Value", value));
				doc.AddChild(node);
				return;
			}
			int num = array[1].ConvertToInt(array[0]);
			TydList orAdd = lists.GetOrAdd(array[0], delegate(string x)
			{
				if (TydToText.ShouldWriteWithQuotes(x))
				{
					TydList tydList = new TydList("Value");
					TydTable tydTable = new TydTable("Item", new TydString("Name", x));
					tydTable.AddChild(tydList);
					doc.AddChild(tydTable);
					return tydList;
				}
				TydList tydList2 = new TydList(x);
				doc.AddChild(tydList2);
				return tydList2;
			});
			for (int num2 = orAdd.Count; num2 <= num; num2++)
			{
				orAdd.AddChild(new TydString(null, ""));
			}
			((TydString)orAdd.Nodes[num]).Value = value;
		}
		else if (TydToText.ShouldWriteWithQuotes(array[0]))
		{
			doc.AddChild(new TydTable("Item", new TydString("Name", array[0]), new TydString("Value", value)));
		}
		else
		{
			doc.AddChild(new TydString(array[0], value));
		}
	}
}
