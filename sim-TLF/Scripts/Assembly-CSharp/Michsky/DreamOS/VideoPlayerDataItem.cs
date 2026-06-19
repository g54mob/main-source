using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Michsky.DreamOS
{
	[DisallowMultipleComponent]
	[AddComponentMenu("DreamOS/Apps/Video Player/Video Player Data Item")]
	public class VideoPlayerDataItem : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler
	{
		public enum ObjectType
		{
			Title = 0,
			Description = 1,
			Cover = 2,
			CurrentTime = 3,
			Duration = 4,
			VideoSlider = 5,
			PlayButton = 6,
			PauseButton = 7,
			SeekForward = 8,
			SeekBackward = 9,
			Loop = 10,
			VolumeSlider = 11
		}

		[Header("Resources")]
		[SerializeField]
		private VideoPlayerManager playerManager;

		[Header("Settings")]
		public bool alwaysUpdate;

		[SerializeField]
		private ObjectType objectType;

		private TextMeshProUGUI textObj;

		private Image imageObj;

		private Slider sliderObj;

		private ButtonManager btnObj;

		private AnimatedIconHandler animHandler;

		private bool enableSliderUpdate = true;

		private DreamOSDataManager.DataCategory dataCat = DreamOSDataManager.DataCategory.Apps;

		private void Start()
		{
			Initalize();
		}

		private void OnEnable()
		{
			UpdateItem();
		}

		private void Update()
		{
			if (alwaysUpdate)
			{
				UpdateItem();
			}
		}

		public void Initalize()
		{
			if (playerManager == null)
			{
				try
				{
					VideoPlayerManager[] array = Resources.FindObjectsOfTypeAll(typeof(VideoPlayerManager)) as VideoPlayerManager[];
					foreach (VideoPlayerManager videoPlayerManager in array)
					{
						if (videoPlayerManager.gameObject.scene.name != null)
						{
							playerManager = videoPlayerManager;
							break;
						}
					}
				}
				catch
				{
					Debug.Log("<b>[Video Player Data Item]</b> Player Manager is missing.", this);
					return;
				}
			}
			if (!(playerManager == null))
			{
				if (objectType == ObjectType.Title || objectType == ObjectType.Description || objectType == ObjectType.CurrentTime || objectType == ObjectType.Duration)
				{
					textObj = base.gameObject.GetComponent<TextMeshProUGUI>();
				}
				else if (objectType == ObjectType.Cover)
				{
					imageObj = base.gameObject.GetComponent<Image>();
				}
				else if (objectType == ObjectType.VideoSlider)
				{
					sliderObj = base.gameObject.GetComponent<Slider>();
				}
				else if (objectType == ObjectType.PlayButton || objectType == ObjectType.PauseButton)
				{
					InitializePlayAndPauseButton();
				}
				else if (objectType == ObjectType.SeekForward)
				{
					InitializeSeekForwardButton();
				}
				else if (objectType == ObjectType.SeekBackward)
				{
					InitializeSeekBackwardButton();
				}
				else if (objectType == ObjectType.Loop)
				{
					InitializeLoopButton();
				}
				else if (objectType == ObjectType.VolumeSlider)
				{
					InitializeVolumeSlider();
				}
				playerManager.dataToBeUpdated.Add(this);
				UpdateItem();
			}
		}

		public void UpdateItem()
		{
			if (playerManager == null)
			{
				return;
			}
			if (objectType == ObjectType.Title && textObj != null)
			{
				CheckForTitle();
			}
			else if (objectType == ObjectType.Cover && imageObj != null)
			{
				imageObj.sprite = playerManager.videoItems[playerManager.currentClipIndex].cover;
			}
			else if (objectType == ObjectType.CurrentTime && textObj != null)
			{
				textObj.text = $"{playerManager.minutesPassed:00}:{playerManager.secondsPassed:00}";
			}
			else if (objectType == ObjectType.Duration && textObj != null)
			{
				textObj.text = $"{playerManager.totalMinutes:00}:{playerManager.totalSeconds:00}";
			}
			else if (objectType == ObjectType.VideoSlider && sliderObj != null)
			{
				MoveVideoSlider();
			}
			else if ((objectType == ObjectType.PlayButton || objectType == ObjectType.PauseButton) && animHandler != null)
			{
				if (playerManager.videoPlayer.isPlaying)
				{
					animHandler.PlayOut();
				}
				else
				{
					animHandler.PlayIn();
				}
			}
		}

		private void CheckForTitle()
		{
			if (string.IsNullOrEmpty(playerManager.tempVideoTitle))
			{
				textObj.text = playerManager.videoItems[playerManager.currentClipIndex].title;
			}
			else
			{
				textObj.text = playerManager.tempVideoTitle;
			}
		}

		private void MoveVideoSlider()
		{
			if (enableSliderUpdate)
			{
				sliderObj.maxValue = (float)playerManager.videoPlayer.length;
				sliderObj.value = (float)playerManager.videoPlayer.time;
			}
			else if (!enableSliderUpdate && sliderObj.value < (float)playerManager.duration)
			{
				playerManager.videoPlayer.time = sliderObj.value;
			}
		}

		private void InitializeVolumeSlider()
		{
			sliderObj = base.gameObject.GetComponent<Slider>();
			sliderObj.onValueChanged.AddListener(SetVolume);
			if (playerManager.audioSource != null)
			{
				playerManager.audioSource.volume = sliderObj.value;
			}
		}

		private void InitializeLoopButton()
		{
			btnObj = base.gameObject.GetComponent<ButtonManager>();
			animHandler = base.gameObject.GetComponent<AnimatedIconHandler>();
			btnObj.onClick.AddListener(delegate
			{
				if (playerManager.videoPlayer.isLooping)
				{
					DreamOSDataManager.WriteBooleanData(dataCat, "VideoPlayer_Loop", value: false);
					playerManager.videoPlayer.isLooping = false;
					animHandler.PlayOut();
				}
				else
				{
					DreamOSDataManager.WriteBooleanData(dataCat, "VideoPlayer_Loop", value: true);
					playerManager.videoPlayer.isLooping = true;
					animHandler.PlayIn();
				}
			});
			if (!DreamOSDataManager.ContainsJsonKey(dataCat, "VideoPlayer_Loop") && playerManager.loop)
			{
				DreamOSDataManager.WriteBooleanData(dataCat, "VideoPlayer_Loop", value: true);
			}
			else if (!DreamOSDataManager.ContainsJsonKey(dataCat, "VideoPlayer_Loop") && !playerManager.loop)
			{
				DreamOSDataManager.WriteBooleanData(dataCat, "VideoPlayer_Loop", value: false);
			}
			else if (DreamOSDataManager.ReadBooleanData(dataCat, "VideoPlayer_Loop"))
			{
				playerManager.loop = true;
			}
			else if (!DreamOSDataManager.ReadBooleanData(dataCat, "VideoPlayer_Loop"))
			{
				playerManager.loop = false;
			}
			playerManager.videoPlayer.isLooping = playerManager.loop;
			if (playerManager.videoPlayer.isLooping)
			{
				animHandler.PlayIn();
			}
			else
			{
				animHandler.PlayOut();
			}
		}

		private void InitializeSeekBackwardButton()
		{
			btnObj = base.gameObject.GetComponent<ButtonManager>();
			btnObj.onClick.AddListener(delegate
			{
				playerManager.SeekBackward();
			});
		}

		private void InitializeSeekForwardButton()
		{
			btnObj = base.gameObject.GetComponent<ButtonManager>();
			btnObj.onClick.AddListener(delegate
			{
				playerManager.SeekForward();
			});
		}

		private void InitializePlayAndPauseButton()
		{
			btnObj = base.gameObject.GetComponent<ButtonManager>();
			animHandler = base.gameObject.GetComponent<AnimatedIconHandler>();
			btnObj.onClick.AddListener(delegate
			{
				if (playerManager.videoPlayer.isPlaying)
				{
					playerManager.Pause();
				}
				else
				{
					playerManager.Play();
				}
			});
		}

		public void SetVolume(float volume)
		{
			playerManager.audioSource.volume = sliderObj.value;
		}

		public void OnPointerDown(PointerEventData eventData)
		{
			if (objectType == ObjectType.VideoSlider)
			{
				enableSliderUpdate = false;
			}
		}

		public void OnPointerUp(PointerEventData eventData)
		{
			if (objectType == ObjectType.VideoSlider)
			{
				enableSliderUpdate = true;
			}
		}
	}
}
