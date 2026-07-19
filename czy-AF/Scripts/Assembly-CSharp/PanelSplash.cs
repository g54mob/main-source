using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PanelSplash : MonoBehaviour
{
	[Header("Components")]
	public Text versionText;

	public Text buildText;

	public Text cacheProgress;

	public Image cacheProgressBar;

	public GameObject panelCache;

	public GameObject panelAnnouncements;

	[Header("Update")]
	public GameObject updateButton;

	public RawImage updateImage;

	public string updateURL;

	private void Awake()
	{
		panelCache.SetActive(value: true);
		panelAnnouncements.SetActive(value: false);
		versionText.text = $"Version {Application.version}";
		DailyBuild();
	}

	private void Start()
	{
		StartCoroutine(LoadUpdate());
	}

	private void DailyBuild()
	{
		string[] array = (Resources.Load("Data/dailyBuilds") as TextAsset).text.Split("\n"[0]);
		int dayOfYear = DateTime.Now.DayOfYear;
		buildText.text = array[dayOfYear - 1];
	}

	public void SetProgressText(string _progress)
	{
		cacheProgress.text = _progress;
	}

	public void SetProgress(float _progress)
	{
		cacheProgressBar.fillAmount = _progress;
	}

	public void ProgressComplete()
	{
		panelCache.SetActive(value: false);
		panelAnnouncements.SetActive(value: true);
	}

	public void ButtonVideos()
	{
		Application.OpenURL("https://www.youtube.com/watch?v=cq9P-KcJMkY&list=PLgZyoeNk0Yr423smsnxyT5eTkWPFB3AmP");
	}

	public void ButtonDocumentation()
	{
		Application.OpenURL("https://kenney.nl/knowledge-base/asset-forge");
	}

	public void ButtonCommunity()
	{
		Application.OpenURL("https://kenney.itch.io/assetforge/community");
	}

	public void SplashClose()
	{
		if (panelAnnouncements.activeSelf)
		{
			Global.control = true;
			GameObject.Find("splash").SetActive(value: false);
			Interface.Unblock();
		}
	}

	public IEnumerator LoadUpdate()
	{
		string uri = "https://kenney.nl/tools/asset-forge?data";
		if (Global.deluxe)
		{
			uri = "https://kenney.nl/tools/asset-forge-deluxe?data";
		}
		using UnityWebRequest _request = UnityWebRequest.Get(uri);
		yield return _request.SendWebRequest();
		if (_request.result == UnityWebRequest.Result.ConnectionError || _request.result == UnityWebRequest.Result.ProtocolError)
		{
			updateButton.SetActive(value: false);
			yield break;
		}
		KenneyOnlineDataList kenneyOnlineDataList = JsonUtility.FromJson<KenneyOnlineDataList>("{\"updates\":" + _request.downloadHandler.text + "}");
		if (kenneyOnlineDataList.updates.Count > 0)
		{
			KenneyOnlineData kenneyOnlineData = kenneyOnlineDataList.updates[0];
			int num = StringToVersion(kenneyOnlineData.version);
			int num2 = StringToVersion(Application.version);
			kenneyOnlineData.update = num > num2;
			updateURL = kenneyOnlineData.text;
			StartCoroutine(LoadUpdateImage(kenneyOnlineData.image));
		}
	}

	public IEnumerator LoadUpdateImage(string _url)
	{
		using UnityWebRequest _request = UnityWebRequestTexture.GetTexture(_url);
		yield return _request.SendWebRequest();
		if (_request.result == UnityWebRequest.Result.ConnectionError || _request.result == UnityWebRequest.Result.ProtocolError)
		{
			updateButton.SetActive(value: false);
			yield break;
		}
		Texture2D content = DownloadHandlerTexture.GetContent(_request);
		updateImage.texture = content;
	}

	public int StringToVersion(string _input)
	{
		_input = _input.Replace(".", "");
		return int.Parse(_input);
	}

	public void ButtonUpdate()
	{
		Application.OpenURL(updateURL);
	}
}
