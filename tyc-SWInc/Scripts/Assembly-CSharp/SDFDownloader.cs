using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class SDFDownloader : MonoBehaviour
{
	public SDFDownloadItem[] Items;

	public InputField QueryBox;

	public InputField AuthCode;

	public Button PageForward;

	public Button PageBackward;

	public Button SearchButton;

	public Button PopularButton;

	public Button NewButton;

	public RectTransform LoadingCircle;

	public Text PageLabel;

	public GUIProgressBar Prog;

	public Text ProgText;

	[NonSerialized]
	public Action<string> OnLogoDownload;

	[NonSerialized]
	private int _availablePages;

	[NonSerialized]
	private int _currentPage;

	[NonSerialized]
	private bool querying;

	public bool AuthMode;

	public bool Local;

	[NonSerialized]
	private string list;

	public void ShowDefault()
	{
		QueryBox.text = "";
		StartCoroutine(Query(null, 0, false));
	}

	public void UpdatePageState()
	{
		PageLabel.text = _currentPage + 1 + " / " + Mathf.Max(1, _availablePages);
		PageBackward.interactable = _currentPage > 0;
		PageForward.interactable = _currentPage < _availablePages - 1;
	}

	public void SkipPage(int offset)
	{
		StartCoroutine(Query(QueryBox.text, _currentPage + offset, false));
	}

	public void SearchChange()
	{
		_availablePages = 0;
		UpdatePageState();
	}

	public void Search()
	{
		list = null;
		StartCoroutine(Query(QueryBox.text, 0, false));
	}

	public void ShowDuplicates()
	{
		StartCoroutine(Query("", 0, true));
	}

	private void Update()
	{
		if (LoadingCircle.gameObject.activeSelf)
		{
			LoadingCircle.rotation = Quaternion.Euler(0f, 0f, Time.realtimeSinceStartup * 360f);
		}
	}

	public void RefreshIcons()
	{
		StartCoroutine(StartReplacement());
	}

	private IEnumerator StartReplacement()
	{
		string code = ((!AuthMode) ? "" : AuthCode.text);
		UnityWebRequest www = UnityWebRequest.Post("https://SoftwareInc.Coredumping.com/logo/load.php", new Dictionary<string, string>
		{
			{ "All", "true" },
			{ "auth", code }
		});
		www.SetRequestHeader("User-Agent", "Swinc User Agent");
		yield return www.SendWebRequest();
		if (string.IsNullOrEmpty(www.error))
		{
			int checke = 0;
			int changed = 0;
			string result = www.downloadHandler.text;
			if (result.StartsWith("ERROR"))
			{
				Debug.Log(result);
				yield break;
			}
			string[] sp = result.TrimEnd().Split('\n');
			float realtimeSinceStartup = Time.realtimeSinceStartup;
			for (int i = 0; i < sp.Length; i++)
			{
				Prog.Value = ((float)i + 1f) / (float)sp.Length;
				ProgText.text = i + 1 + " / " + sp.Length;
				string[] array = sp[i].Split('|');
				if (array.Length == 2)
				{
					int num = array[0].ConvertToIntDef(-1);
					if (num >= 0)
					{
						string text = ReloadTree(ReloadTree(ReloadTree(array[1])));
						checke++;
						if (!array[1].Equals(text))
						{
							changed++;
							Debug.Log(string.Format("Found difference for ID = {0}", num));
							IEnumerator up = UploadReplacement(num, text, code);
							while (up.MoveNext())
							{
								yield return up.Current;
							}
							yield return new WaitForSeconds(0.25f);
							realtimeSinceStartup = Time.realtimeSinceStartup;
						}
						if (Time.realtimeSinceStartup - realtimeSinceStartup > 1f / 30f)
						{
							yield return new WaitForEndOfFrame();
							realtimeSinceStartup = Time.realtimeSinceStartup;
						}
						continue;
					}
					ProgText.text = string.Format("{0} checked, {1} changed", checke, changed);
					Debug.Log("ID was not 0, stopping\n" + result);
					yield break;
				}
				ProgText.text = string.Format("{0} checked, {1} changed", checke, changed);
				Debug.Log("Split was not 2, stopping\n" + result);
				yield break;
			}
			ProgText.text = string.Format("{0} checked, {1} changed", checke, changed);
		}
		else
		{
			Debug.Log(www.error);
		}
	}

	public static string ReloadTree(string input)
	{
		return SDFCreator.GetTreeString(SDFCreator.SerializeTree(SDFCreator.LoadSDFTree(SDFCreator.GetTreeFromString(input))));
	}

	private IEnumerator UploadReplacement(int id, string logo, string code)
	{
		UnityWebRequest unityWebRequest = UnityWebRequest.Post("https://SoftwareInc.Coredumping.com/logo/load.php", new Dictionary<string, string>
		{
			{
				"id",
				id.ToString()
			},
			{ "logo", logo },
			{ "Replace", "true" },
			{ "auth", code }
		});
		unityWebRequest.SetRequestHeader("User-Agent", "Swinc User Agent");
		yield return unityWebRequest.SendWebRequest();
	}

	public void List(bool popular)
	{
		Local = false;
		_availablePages = 0;
		UpdatePageState();
		list = (popular ? "popular" : "new");
		StartCoroutine(Query(QueryBox.text, 0, false));
	}

	public void ShowLocal()
	{
		Local = true;
		_availablePages = 0;
		UpdatePageState();
		StartCoroutine(Query(null, 0, false));
	}

	private IEnumerator Query(string query, int page, bool duplicates)
	{
		if (Local)
		{
			_currentPage = page;
			_availablePages = Mathf.CeilToInt((float)GameData.LocalLogos.Count / 9f);
			UpdatePageState();
			for (int i = 0; i < 9; i++)
			{
				int num = i + _currentPage * 9;
				if (num < GameData.LocalLogos.Count)
				{
					Items[i].Init(0, "", GameData.LocalLogos[num], null, 0, DateTime.Now, delegate(string x)
					{
						OnLogoDownload(x);
					}, null, true);
				}
				else
				{
					Items[i].gameObject.SetActive(false);
				}
			}
		}
		else
		{
			if (querying)
			{
				yield break;
			}
			yield return new WaitForEndOfFrame();
			LoadingCircle.gameObject.SetActive(true);
			SearchButton.interactable = false;
			PopularButton.interactable = false;
			NewButton.interactable = false;
			QueryBox.interactable = false;
			PageForward.interactable = false;
			PageBackward.interactable = false;
			Items.ForEachEnum(delegate(SDFDownloadItem x)
			{
				x.gameObject.SetActive(false);
			});
			querying = true;
			string uri = "https://SoftwareInc.Coredumping.com/logo/load.php";
			string code = ((!AuthMode) ? "" : AuthCode.text);
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			if (page > 0)
			{
				dictionary["page"] = page.ToString();
			}
			bool flag = !string.IsNullOrWhiteSpace(query);
			bool flag2 = !string.IsNullOrWhiteSpace(list);
			bool hasR = false;
			if (flag || flag2)
			{
				if (flag)
				{
					dictionary["query"] = query;
				}
				if (flag2)
				{
					dictionary["list"] = list;
				}
			}
			else if (AuthMode)
			{
				dictionary["Pending"] = "true";
				dictionary["auth"] = code;
				if (duplicates)
				{
					dictionary["Duplicates"] = "1";
				}
				else
				{
					hasR = true;
				}
			}
			UnityWebRequest www = UnityWebRequest.Post(uri, dictionary);
			www.SetRequestHeader("User-Agent", "Swinc User Agent");
			yield return www.SendWebRequest();
			_currentPage = page;
			int num2 = (hasR ? 6 : 5);
			if (string.IsNullOrEmpty(www.error))
			{
				string text = www.downloadHandler.text;
				if (text.StartsWith("ERROR"))
				{
					Debug.Log(text);
				}
				else
				{
					string[] array = text.Split('\n');
					int num3 = array.Length - 1;
					HashSet<int> hashSet = new HashSet<int>();
					int num4 = 0;
					for (int num5 = 0; num5 < num3; num5++)
					{
						string[] array2 = array[num5].Split('|');
						if (array2.Length != num2)
						{
							continue;
						}
						int num6 = array2[0].ConvertToIntDef(-1);
						if (num6 < 0 || !hashSet.Add(num6))
						{
							continue;
						}
						DateTime date;
						try
						{
							date = DateTime.ParseExact(array2[4] + " +2", "yyyy-MM-dd HH:mm:ss z", CultureInfo.CurrentCulture);
						}
						catch (Exception)
						{
							date = DateTime.Now;
						}
						try
						{
							string reports = ((array2.Length >= 6 && !string.IsNullOrWhiteSpace(array2[5])) ? array2[5].Replace(">>", "\n") : null);
							Items[num4].Init(num6, array2[1], array2[2], reports, array2[3].ConvertToIntDef(0), date, delegate(string x)
							{
								OnLogoDownload(x);
							}, AuthMode ? code : null, false);
							num4++;
						}
						catch (Exception)
						{
						}
					}
					for (int num7 = num4; num7 < Items.Length; num7++)
					{
						Items[num7].gameObject.SetActive(false);
					}
					_availablePages = Mathf.CeilToInt((float)array[array.Length - 1].ConvertToIntDef(0) / 9f);
				}
			}
			else
			{
				Debug.Log(www.error);
			}
			UpdatePageState();
			querying = false;
			LoadingCircle.gameObject.SetActive(false);
			SearchButton.interactable = true;
			PopularButton.interactable = true;
			NewButton.interactable = true;
			QueryBox.interactable = true;
		}
	}
}
