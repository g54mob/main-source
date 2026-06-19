using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Video;

namespace Michsky.DreamOS
{
	public class VideoPlayerManager : MonoBehaviour
	{
		[Serializable]
		public class VideoItem
		{
			public string title = "Video Title";

			public string description = "Video Description";

			public Sprite cover;

			public VideoType type;

			public VideoClip clip;

			public string URL;

			[HideInInspector]
			public VideoPreset preset;
		}

		public enum VideoType
		{
			Clip = 0,
			URL = 1
		}

		public List<VideoItem> videoItems = new List<VideoItem>();

		public VideoPlayer videoPlayer;

		public AudioSource audioSource;

		[SerializeField]
		private Transform videoParent;

		[SerializeField]
		private GameObject videoPreset;

		[SerializeField]
		private WindowPanelManager panelManager;

		[SerializeField]
		private Animator videoControls;

		[SerializeField]
		private Animator miniPlayer;

		[Range(1f, 15f)]
		public float hideControlsIn = 2.5f;

		[Range(1f, 60f)]
		public float seekTime = 10f;

		[SerializeField]
		private string videoPanelName = "Now Playing";

		public List<VideoPlayerDataItem> dataToBeUpdated = new List<VideoPlayerDataItem>();

		[HideInInspector]
		public int currentClipIndex;

		[HideInInspector]
		public int secondsPassed;

		[HideInInspector]
		public int minutesPassed;

		[HideInInspector]
		public int totalSeconds;

		[HideInInspector]
		public int totalMinutes;

		[HideInInspector]
		public bool loop;

		[HideInInspector]
		public string tempVideoTitle;

		[HideInInspector]
		public bool isDone;

		[HideInInspector]
		public bool isMiniPlayerEnabled;

		private bool updateControlInput;

		private bool isControlsVisible;

		private float cachedMiniPlayerLength = 0.5f;

		private float cachedVideoControlsLength = 0.5f;

		private Vector3 lastMousePos;

		public double time => videoPlayer.time;

		public ulong duration => (ulong)((float)videoPlayer.frameCount / videoPlayer.frameRate);

		public double nTime => time / (double)duration;

		private void Awake()
		{
			Initialize();
		}

		private void OnDisable()
		{
			Pause();
		}

		public void Initialize()
		{
			videoPlayer.SetTargetAudioSource(0, audioSource);
			if (miniPlayer != null)
			{
				cachedMiniPlayerLength = DreamOSInternalTools.GetAnimatorClipLength(miniPlayer, "MiniPlayer_In") + 0.1f;
			}
			if (videoControls != null)
			{
				cachedVideoControlsLength = DreamOSInternalTools.GetAnimatorClipLength(videoControls, "VideoControls_In") + 0.1f;
			}
			foreach (Transform item in videoParent)
			{
				UnityEngine.Object.Destroy(item.gameObject);
			}
			for (int i = 0; i < videoItems.Count; i++)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate(videoPreset, new Vector3(0f, 0f, 0f), Quaternion.identity);
				gameObject.transform.SetParent(videoParent, worldPositionStays: false);
				gameObject.gameObject.name = videoItems[i].title;
				VideoPreset preset = gameObject.GetComponent<VideoPreset>();
				preset.videoIndex = i;
				preset.manager = this;
				preset.type = videoItems[i].type;
				preset.coverImage.sprite = videoItems[i].cover;
				preset.titleText.text = videoItems[i].title;
				preset.descriptionText.text = videoItems[i].description;
				if (preset.type == VideoType.Clip)
				{
					preset.durationText.text = (int)videoItems[i].clip.length / 60 % 60 + ":" + ((int)videoItems[i].clip.length % 60).ToString("D2");
				}
				else
				{
					preset.videoURL = videoItems[i].URL;
					preset.durationText.text = "URL";
				}
				videoItems[i].preset = preset;
				gameObject.GetComponent<ButtonManager>().onClick.AddListener(delegate
				{
					if (preset.type == VideoType.Clip)
					{
						OpenVideo(preset.videoIndex);
					}
					else if (preset.type == VideoType.URL)
					{
						OpenVideo(preset.videoURL, preset.videoIndex);
					}
				});
			}
			if (miniPlayer != null)
			{
				miniPlayer.gameObject.SetActive(value: false);
			}
		}

		private void Update()
		{
			if (videoPlayer.isPrepared)
			{
				totalMinutes = (int)duration / 60;
				totalSeconds = (int)duration - totalMinutes * 60;
				minutesPassed = (int)time / 60;
				secondsPassed = (int)time - minutesPassed * 60;
			}
			if (updateControlInput)
			{
				if (lastMousePos == new Vector3(Mouse.current.position.ReadValue().x, Mouse.current.position.ReadValue().y, 0f) && isControlsVisible)
				{
					HideVideoControls(hideControlsIn);
				}
				else if (lastMousePos != new Vector3(Mouse.current.position.ReadValue().x, Mouse.current.position.ReadValue().y, 0f) && !isControlsVisible)
				{
					ShowVideoControls();
				}
				lastMousePos = new Vector3(Mouse.current.position.ReadValue().x, Mouse.current.position.ReadValue().y, 0f);
			}
		}

		public void OpenVideo(int index)
		{
			currentClipIndex = index;
			tempVideoTitle = null;
			videoPlayer.Stop();
			videoPlayer.source = VideoSource.VideoClip;
			videoPlayer.clip = videoItems[index].clip;
			videoPlayer.time = 0.0;
			videoPlayer.Play();
			panelManager.OpenPanel(videoPanelName);
			HideMiniPlayer();
			UpdateDataItems();
		}

		public void OpenVideo(string url, int index = -1)
		{
			currentClipIndex = index;
			tempVideoTitle = null;
			videoPlayer.Stop();
			videoPlayer.source = VideoSource.Url;
			videoPlayer.url = url;
			videoPlayer.time = 0.0;
			videoPlayer.Play();
			panelManager.OpenPanel(videoPanelName);
			HideMiniPlayer();
			UpdateDataItems();
		}

		public void OpenVideo(VideoClip clip, string title)
		{
			currentClipIndex = -1;
			tempVideoTitle = title;
			videoPlayer.Stop();
			videoPlayer.source = VideoSource.VideoClip;
			videoPlayer.clip = clip;
			videoPlayer.time = 0.0;
			videoPlayer.Play();
			panelManager.OpenPanel(videoPanelName);
			HideMiniPlayer();
			UpdateDataItems();
		}

		public void CreateVideo(Sprite cover, string title, string desc, string url)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(videoPreset, new Vector3(0f, 0f, 0f), Quaternion.identity);
			gameObject.transform.SetParent(videoParent, worldPositionStays: false);
			gameObject.gameObject.name = title;
			VideoPreset preset = gameObject.GetComponent<VideoPreset>();
			preset.manager = this;
			preset.type = VideoType.URL;
			preset.coverImage.sprite = cover;
			preset.titleText.text = title;
			preset.descriptionText.text = desc;
			preset.videoURL = url;
			preset.durationText.text = "MOD";
			gameObject.GetComponent<ButtonManager>().onClick.AddListener(delegate
			{
				OpenVideo(preset.videoURL);
			});
		}

		public void Play()
		{
			videoPlayer.Play();
			UpdateDataItems();
		}

		public void Pause()
		{
			if (base.gameObject.activeInHierarchy)
			{
				videoPlayer.Pause();
				UpdateDataItems();
				StopCoroutine("FadeOutVideoControls");
			}
		}

		public void SeekForward()
		{
			videoPlayer.time += seekTime;
		}

		public void SeekBackward()
		{
			videoPlayer.time -= seekTime;
		}

		public void IncreasePlaybackSpeed()
		{
			if (videoPlayer.canSetPlaybackSpeed)
			{
				videoPlayer.playbackSpeed += 1f;
				videoPlayer.playbackSpeed = Mathf.Clamp(videoPlayer.playbackSpeed, 0f, 10f);
			}
		}

		public void DecreasePlaybackSpeed()
		{
			if (videoPlayer.canSetPlaybackSpeed)
			{
				videoPlayer.playbackSpeed -= 1f;
				videoPlayer.playbackSpeed = Mathf.Clamp(videoPlayer.playbackSpeed, 0f, 10f);
			}
		}

		public void ShowVideoControls()
		{
			StopCoroutine("FadeOutVideoControls");
			StopCoroutine("DisableVideoControlsAnimator");
			StartCoroutine("DisableVideoControlsAnimator");
			Cursor.visible = true;
			isControlsVisible = true;
			videoControls.enabled = true;
			videoControls.CrossFade("In", 0.15f);
		}

		public void HideVideoControls(float time = 0.1f)
		{
			StopCoroutine("FadeOutVideoControls");
			StartCoroutine("FadeOutVideoControls", time);
			isControlsVisible = false;
		}

		public void ShowMiniPlayer()
		{
			if (miniPlayer != null && videoPlayer.isPlaying)
			{
				StopCoroutine("DisableMiniPlayerAnimator");
				StopCoroutine("DisableMiniPlayer");
				StartCoroutine("DisableMiniPlayerAnimator");
				miniPlayer.gameObject.SetActive(value: true);
				isMiniPlayerEnabled = true;
				miniPlayer.enabled = true;
				miniPlayer.Play("In");
			}
			else if (miniPlayer != null && !videoPlayer.isPlaying)
			{
				HideMiniPlayer();
			}
		}

		public void HideMiniPlayer()
		{
			if (miniPlayer != null && isMiniPlayerEnabled)
			{
				StopCoroutine("DisableMiniPlayerAnimator");
				StopCoroutine("DisableMiniPlayer");
				StartCoroutine("DisableMiniPlayer");
				isMiniPlayerEnabled = false;
				miniPlayer.enabled = true;
				miniPlayer.Play("Out");
			}
		}

		public void UpdateControlInput(bool value)
		{
			updateControlInput = value;
			if (!value)
			{
				HideVideoControls();
			}
		}

		public void UpdateDataItems()
		{
			for (int i = 0; i < dataToBeUpdated.Count; i++)
			{
				if (dataToBeUpdated[i] == null)
				{
					dataToBeUpdated.RemoveAt(i);
				}
				else if (!dataToBeUpdated[i].alwaysUpdate && dataToBeUpdated[i].gameObject.activeInHierarchy)
				{
					dataToBeUpdated[i].UpdateItem();
				}
			}
		}

		private IEnumerator FadeOutVideoControls(float time)
		{
			yield return new WaitForSeconds(time);
			if (updateControlInput)
			{
				Cursor.visible = false;
			}
			videoControls.enabled = true;
			videoControls.CrossFade("Out", 0.15f);
			StopCoroutine("DisableVideoControlsAnimator");
			StartCoroutine("DisableVideoControlsAnimator");
		}

		private IEnumerator DisableMiniPlayer()
		{
			yield return new WaitForSeconds(cachedMiniPlayerLength);
			miniPlayer.gameObject.SetActive(value: false);
		}

		private IEnumerator DisableMiniPlayerAnimator()
		{
			yield return new WaitForSeconds(cachedMiniPlayerLength);
			miniPlayer.enabled = false;
		}

		private IEnumerator DisableVideoControlsAnimator()
		{
			yield return new WaitForSeconds(cachedVideoControlsLength);
			videoControls.enabled = false;
		}
	}
}
