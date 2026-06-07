using System.Text.RegularExpressions;
using Steamworks;
using UnityEngine;
using UnityEngine.UI;

public class CreditWindow : MonoBehaviour
{
	public GameObject TextPrefab;

	public GameObject ButtonPrefab;

	public int Version;

	public GUIWindow Window;

	public Text text;

	public string textAsset;

	public bool EULA;

	public Transform MainPanel;

	public Color HeaderColor;

	private string CleanURL(string url)
	{
		Match match = new Regex("(https?://)?(www\\.)?([^/]+)").Match(url);
		if (match.Groups.Count < 4)
		{
			return url;
		}
		return match.Groups[3].Value;
	}

	private void Start()
	{
		if (EULA)
		{
			text.text = GameData.LoadFullTextAsset(textAsset);
		}
		else
		{
			string[] array = GameData.LoadTextAsset(textAsset);
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].StartsWith("http://") || array[i].StartsWith("https://"))
				{
					GameObject obj = Object.Instantiate(ButtonPrefab);
					obj.GetComponentInChildren<Text>().text = CleanURL(array[i]);
					string i2 = array[i];
					obj.GetComponent<Button>().onClick.AddListener(delegate
					{
						if (SteamManager.Initialized && SteamUtils.IsOverlayEnabled())
						{
							SteamFriends.ActivateGameOverlayToWebPage(i2);
						}
						else
						{
							Application.OpenURL(i2);
						}
					});
					obj.transform.SetParent(MainPanel, false);
				}
				else
				{
					AddLabel(array[i]);
				}
			}
			AddLabel("Engine");
			AddLabel("*Unity3D " + Application.unityVersion);
		}
		if (EULA)
		{
			Window.Close();
		}
	}

	private void AddLabel(string value)
	{
		GameObject obj = Object.Instantiate(TextPrefab);
		Text component = obj.GetComponent<Text>();
		component.text = value.Replace("*", "");
		if (value.StartsWith("*"))
		{
			component.fontSize = 16;
		}
		else
		{
			component.color = HeaderColor;
		}
		obj.transform.SetParent(MainPanel, false);
	}

	public void Close()
	{
		if (EULA)
		{
			PlayerPrefs.SetInt("EULA", Version);
			PlayerPrefs.Save();
		}
		Window.Close();
	}
}
