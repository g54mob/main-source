using System;
using System.Collections.Generic;
using System.IO;
using FourHandsTwoCats.VideoPlayer;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

public class MyTubeUI : MonoBehaviour
{
	private LocalizedString subsString = new LocalizedString("MyTable", "subscribers");

	[Header("Renew")]
	[SerializeField]
	private GameObject uploadPannel;

	[SerializeField]
	private GameObject videoBlock;

	[SerializeField]
	private GameObject scoreGO;

	[SerializeField]
	private GameObject videoPrefab;

	[SerializeField]
	private GameObject descriptionGO;

	[SerializeField]
	private GameObject channelBtn;

	[SerializeField]
	private TextMeshProUGUI videoTitle;

	[SerializeField]
	private TextMeshProUGUI subsText;

	[SerializeField]
	private TextMeshProUGUI scoreText;

	[SerializeField]
	private VideoPlayerManager videoPlayerManager;

	[SerializeField]
	private Transform videosPos;

	private int subs;

	private int flightVidCount;

	private bool isNewVid;

	private string lastVid;

	private List<GameObject> videoList = new List<GameObject>();

	public static event Action OnVideoUploaded;

	private void Awake()
	{
		LoadData();
	}

	private void Start()
	{
		base.gameObject.SetActive(value: false);
		ES3AutoSaveMgr.OnBeforeSave += ES3AutoSaveMgr_OnBeforeSave;
		GameManager.S.OnVideoUnlocked += S_OnVideoUnlocked;
		GameManager.S.OnNewVidRecorded += S_OnNewVidRecorded;
		_ = GameManager.S.isVideoUnlocked;
		subsString.Arguments = new object[1] { subs };
		subsText.text = subsString.GetLocalizedString();
	}

	private void OnEnable()
	{
		if (isNewVid)
		{
			VidLoaded(lastVid);
			isNewVid = false;
			uploadPannel.SetActive(value: true);
			channelBtn.SetActive(value: false);
		}
		else if (videoList.Count > 0)
		{
			VidSelected(videoList[videoList.Count - 1].GetComponent<MyTubeVideo>());
		}
	}

	private void OnDisable()
	{
		if (videoList.Count > 0)
		{
			VidSelected(videoList[videoList.Count - 1].GetComponent<MyTubeVideo>());
		}
	}

	private void S_OnNewVidRecorded(string vidName)
	{
		lastVid = vidName;
		isNewVid = true;
	}

	public void VidSelected(MyTubeVideo vid)
	{
		string text = Path.Combine(Application.persistentDataPath, vid.vidUrl);
		text = text.Replace("/", "\\");
		if (File.Exists(text))
		{
			videoPlayerManager.LoadVideo(text);
			Debug.Log("비디오 참조 성공: " + text);
			videoPlayerManager.PlayVideo();
			string text2 = $"Flight {vid.vidIndex}";
			videoTitle.text = text2;
			scoreText.text = vid.vidScore.ToString();
			scoreGO.SetActive(value: true);
		}
		else
		{
			Debug.LogError("파일을 찾을 수 없습니다: " + text);
		}
		descriptionGO.SetActive(value: false);
	}

	public void VidLoaded(string vidUrl)
	{
		string text = Path.Combine(Application.persistentDataPath, vidUrl);
		text = text.Replace("/", "\\");
		text += ".mp4";
		if (File.Exists(text))
		{
			videoPlayerManager.LoadVideo(text);
			Debug.Log("비디오 참조 성공: " + text);
			videoPlayerManager.PlayVideo();
			string text2 = $"Flight {flightVidCount}";
			videoTitle.text = text2;
			scoreGO.SetActive(value: false);
			channelBtn.SetActive(value: false);
		}
		else
		{
			Debug.LogError("파일을 찾을 수 없습니다: " + text);
		}
	}

	public void ChannelButton()
	{
		descriptionGO.SetActive(value: true);
	}

	public void VideoUpload()
	{
		AudioManager.S.PlaySFX(AudioManager.S.vidUploaded);
		AudioManager.S.PlaySFX(AudioManager.S.money);
		int num = ES3.Load("Score", 0);
		subs += (int)((float)num * 0.1f);
		subsString.Arguments = new object[1] { subs };
		subsText.text = subsString.GetLocalizedString();
		float foodValue = (float)num * 0.001f + 1f;
		FirstPersonController.S.MoneyUpdated(foodValue);
		if (lastVid == null)
		{
			return;
		}
		string text = Path.Combine(Application.persistentDataPath, lastVid);
		text = text.Replace("/", "\\");
		text += ".mp4";
		if (File.Exists(text))
		{
			uploadPannel.SetActive(value: false);
			string text2 = $"Flight {flightVidCount}";
			string text3 = Path.Combine(Application.persistentDataPath, text2 + ".mp4");
			if (File.Exists(text3))
			{
				File.Delete(text3);
			}
			File.Move(text, text3);
			videoPlayerManager.PlayVideo();
			GameObject gameObject = UnityEngine.Object.Instantiate(videoPrefab, videosPos);
			MyTubeVideo videoCompo = gameObject.GetComponent<MyTubeVideo>();
			gameObject.GetComponent<Button>().onClick.AddListener(delegate
			{
				VidSelected(videoCompo);
			});
			videoCompo.vidUrl = text3;
			videoCompo.vidIndex = flightVidCount;
			videoCompo.vidScore = num;
			scoreGO.SetActive(value: true);
			scoreText.text = num.ToString();
			channelBtn.SetActive(value: true);
			string text4 = Path.Combine(Application.persistentDataPath, lastVid);
			text4 = text4.Replace("/", "\\");
			text4 += ".png";
			string text5 = Path.Combine(Application.persistentDataPath, text2 + ".png");
			if (File.Exists(text4))
			{
				if (File.Exists(text5))
				{
					File.Delete(text5);
				}
				File.Move(text4, text5);
				videoCompo.thumbnailUrl = text5;
			}
			videoCompo.VidCreated();
			videoList.Add(gameObject);
			if (videoList.Count > 10)
			{
				MyTubeVideo component = videoList[0].GetComponent<MyTubeVideo>();
				videoList.RemoveAt(0);
				component.DeleteVideo();
			}
			flightVidCount++;
			MyTubeUI.OnVideoUploaded?.Invoke();
		}
		else
		{
			Debug.LogError("파일을 찾을 수 없습니다: " + text);
		}
	}

	private void S_OnVideoUnlocked()
	{
		videoBlock.SetActive(value: false);
		uploadPannel.SetActive(value: false);
	}

	private void OnDestroy()
	{
		ES3AutoSaveMgr.OnBeforeSave -= ES3AutoSaveMgr_OnBeforeSave;
		GameManager.S.OnVideoUnlocked -= S_OnVideoUnlocked;
		GameManager.S.OnNewVidRecorded -= S_OnNewVidRecorded;
	}

	private void ES3AutoSaveMgr_OnBeforeSave()
	{
		ES3.Save("VidList", videoList);
		ES3.Save("Subs", subs);
		ES3.Save("flightVidCount", flightVidCount);
	}

	private void LoadData()
	{
		videoList = ES3.Load("VidList", videoList);
		subs = ES3.Load("Subs", 0);
		flightVidCount = ES3.Load("flightVidCount", 0);
		foreach (GameObject video in videoList)
		{
			MyTubeVideo videoCompo = video.GetComponent<MyTubeVideo>();
			video.GetComponent<Button>().onClick.AddListener(delegate
			{
				VidSelected(videoCompo);
			});
			videoCompo.VidCreated();
		}
	}
}
