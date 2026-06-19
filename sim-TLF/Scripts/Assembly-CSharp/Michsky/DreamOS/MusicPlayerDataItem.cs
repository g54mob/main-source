using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Michsky.DreamOS
{
	[DisallowMultipleComponent]
	[AddComponentMenu("DreamOS/Apps/Music Player/Music Player Data Item")]
	public class MusicPlayerDataItem : MonoBehaviour
	{
		public enum ObjectType
		{
			Title = 0,
			Artist = 1,
			Album = 2,
			Cover = 3,
			PlayTime = 4,
			Duration = 5,
			MusicSlider = 6,
			PlayButton = 7,
			PauseButton = 8,
			NextButton = 9,
			PrevButton = 10,
			Repeat = 11,
			Shuffle = 12,
			VolumeSlider = 13,
			AccentColor = 14,
			AccentMatchColor = 15,
			AccentColorTMP = 16,
			AccentMatchColorTMP = 17
		}

		[Header("Resources")]
		[SerializeField]
		private MusicPlayerManager playerManager;

		[Header("Settings")]
		public bool alwaysUpdate;

		[SerializeField]
		private ObjectType objectType;

		private float colorAnimDuration = 0.25f;

		private TextMeshProUGUI textObj;

		private Image imageObj;

		private Slider sliderObj;

		private ButtonManager btnObj;

		private AnimatedIconHandler animHandler;

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
					MusicPlayerManager[] array = Resources.FindObjectsOfTypeAll(typeof(MusicPlayerManager)) as MusicPlayerManager[];
					foreach (MusicPlayerManager musicPlayerManager in array)
					{
						if (musicPlayerManager.gameObject.scene.name != null)
						{
							playerManager = musicPlayerManager;
							break;
						}
					}
				}
				catch
				{
					Debug.Log("<b>[Music Player Data Item]</b> Player Manager is missing.", this);
					return;
				}
			}
			if (!(playerManager == null))
			{
				if (objectType == ObjectType.Title || objectType == ObjectType.Artist || objectType == ObjectType.Album)
				{
					textObj = GetComponent<TextMeshProUGUI>();
				}
				else if (objectType == ObjectType.PlayTime || objectType == ObjectType.Duration)
				{
					textObj = GetComponent<TextMeshProUGUI>();
				}
				else if (objectType == ObjectType.Cover || objectType == ObjectType.AccentColor || objectType == ObjectType.AccentMatchColor)
				{
					imageObj = GetComponent<Image>();
				}
				else if (objectType == ObjectType.AccentColorTMP || objectType == ObjectType.AccentMatchColorTMP)
				{
					textObj = GetComponent<TextMeshProUGUI>();
				}
				else if (objectType == ObjectType.PlayButton || objectType == ObjectType.PauseButton)
				{
					InitializePlayAndPauseButton();
				}
				else if (objectType == ObjectType.NextButton)
				{
					InitializeNextButton();
				}
				else if (objectType == ObjectType.PrevButton)
				{
					InitializePrevButton();
				}
				else if (objectType == ObjectType.MusicSlider)
				{
					InitializeMusicSlider();
				}
				else if (objectType == ObjectType.VolumeSlider)
				{
					InitializeVolumeSlider();
				}
				else if (objectType == ObjectType.Repeat)
				{
					InitializeRepeatButton();
				}
				else if (objectType == ObjectType.Shuffle)
				{
					InitializeShuffleButton();
				}
				playerManager.dataToBeUpdated.Add(this);
				UpdateItem();
			}
		}

		public void UpdateItem()
		{
			if (playerManager == null || playerManager.audioSource.clip == null)
			{
				return;
			}
			if (objectType == ObjectType.Title && textObj != null)
			{
				textObj.text = playerManager.GetTrackName();
			}
			else if (objectType == ObjectType.Artist && textObj != null)
			{
				textObj.text = playerManager.GetArtistName();
			}
			else if (objectType == ObjectType.Album && textObj != null)
			{
				textObj.text = playerManager.GetAlbumName();
			}
			else if (objectType == ObjectType.Cover && imageObj != null)
			{
				imageObj.sprite = playerManager.GetCoverArt();
			}
			else if (objectType == ObjectType.PlayTime && textObj != null)
			{
				textObj.text = playerManager.GetNormalizedPlayTime();
			}
			else if (objectType == ObjectType.Duration && textObj != null)
			{
				textObj.text = playerManager.GetNormalizedDuration();
			}
			else if (objectType == ObjectType.MusicSlider && sliderObj != null)
			{
				sliderObj.maxValue = playerManager.audioSource.clip.length;
				sliderObj.value = playerManager.audioSource.time;
			}
			else if (objectType == ObjectType.Shuffle && playerManager.shuffle && animHandler != null)
			{
				animHandler.PlayIn();
			}
			else if (objectType == ObjectType.Shuffle && !playerManager.shuffle && animHandler != null)
			{
				animHandler.PlayOut();
			}
			else if (objectType == ObjectType.Repeat && playerManager.repeat && animHandler != null)
			{
				animHandler.PlayIn();
			}
			else if (objectType == ObjectType.Repeat && !playerManager.repeat && animHandler != null)
			{
				animHandler.PlayOut();
			}
			else if (objectType == ObjectType.AccentColor && imageObj != null)
			{
				SetImageColor(playerManager.GetAccentColor(imageObj));
			}
			else if (objectType == ObjectType.AccentMatchColor && imageObj != null)
			{
				SetImageColor(playerManager.GetAccentMatchColor(imageObj));
			}
			else if (objectType == ObjectType.AccentColorTMP && textObj != null)
			{
				SetTextColor(playerManager.GetAccentColor(textObj));
			}
			else if (objectType == ObjectType.AccentMatchColorTMP && textObj != null)
			{
				SetTextColor(playerManager.GetAccentMatchColor(textObj));
			}
			else if ((objectType == ObjectType.PlayButton || objectType == ObjectType.PauseButton) && animHandler != null)
			{
				if (playerManager.audioSource.isPlaying)
				{
					animHandler.PlayOut();
				}
				else
				{
					animHandler.PlayIn();
				}
			}
		}

		private void InitializeMusicSlider()
		{
			sliderObj = base.gameObject.GetComponent<Slider>();
			sliderObj.onValueChanged.AddListener(delegate
			{
				if (!(sliderObj.value > playerManager.audioSource.clip.length - 0.01f))
				{
					playerManager.audioSource.time = sliderObj.value;
				}
			});
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

		private void InitializePlayAndPauseButton()
		{
			btnObj = base.gameObject.GetComponent<ButtonManager>();
			animHandler = base.gameObject.GetComponent<AnimatedIconHandler>();
			btnObj.onClick.AddListener(delegate
			{
				if (!playerManager.gameObject.activeInHierarchy)
				{
					playerManager.gameObject.GetComponent<WindowManager>().OpenWindow();
					playerManager.Play();
				}
				else if (playerManager.gameObject.activeInHierarchy && playerManager.audioSource.isPlaying)
				{
					playerManager.Pause();
				}
				else if (playerManager.gameObject.activeInHierarchy && !playerManager.audioSource.isPlaying)
				{
					playerManager.Play();
				}
			});
		}

		private void InitializeNextButton()
		{
			btnObj = base.gameObject.GetComponent<ButtonManager>();
			animHandler = base.gameObject.GetComponent<AnimatedIconHandler>();
			btnObj.onClick.AddListener(delegate
			{
				if (playerManager.gameObject.activeInHierarchy)
				{
					playerManager.audioSource.time = 0f;
					playerManager.NextTrack();
					if (animHandler != null)
					{
						animHandler.PlayIn();
					}
				}
			});
		}

		private void InitializePrevButton()
		{
			btnObj = base.gameObject.GetComponent<ButtonManager>();
			animHandler = base.gameObject.GetComponent<AnimatedIconHandler>();
			btnObj.onClick.AddListener(delegate
			{
				if (playerManager.gameObject.activeInHierarchy)
				{
					playerManager.audioSource.time = 0f;
					playerManager.PrevTrack();
					if (animHandler != null)
					{
						animHandler.PlayIn();
					}
				}
			});
		}

		private void InitializeRepeatButton()
		{
			btnObj = base.gameObject.GetComponent<ButtonManager>();
			animHandler = base.gameObject.GetComponent<AnimatedIconHandler>();
			btnObj.onClick.AddListener(delegate
			{
				if (playerManager.repeat)
				{
					DreamOSDataManager.WriteBooleanData(dataCat, "MusicPlayer_Repeat", value: false);
					playerManager.repeat = false;
					animHandler.PlayOut();
				}
				else
				{
					DreamOSDataManager.WriteBooleanData(dataCat, "MusicPlayer_Repeat", value: true);
					playerManager.repeat = true;
					animHandler.PlayIn();
				}
			});
			if (!DreamOSDataManager.ContainsJsonKey(dataCat, "MusicPlayer_Repeat") && playerManager.repeat)
			{
				DreamOSDataManager.WriteBooleanData(dataCat, "MusicPlayer_Repeat", value: true);
			}
			else if (!DreamOSDataManager.ContainsJsonKey(dataCat, "MusicPlayer_Repeat") && !playerManager.repeat)
			{
				DreamOSDataManager.WriteBooleanData(dataCat, "MusicPlayer_Repeat", value: false);
			}
			else if (DreamOSDataManager.ReadBooleanData(dataCat, "MusicPlayer_Repeat"))
			{
				playerManager.repeat = true;
			}
			else if (!DreamOSDataManager.ReadBooleanData(dataCat, "MusicPlayer_Repeat"))
			{
				playerManager.repeat = false;
			}
		}

		private void InitializeShuffleButton()
		{
			btnObj = base.gameObject.GetComponent<ButtonManager>();
			animHandler = base.gameObject.GetComponent<AnimatedIconHandler>();
			btnObj.onClick.AddListener(delegate
			{
				if (playerManager.shuffle)
				{
					DreamOSDataManager.WriteBooleanData(dataCat, "MusicPlayer_Shuffle", value: false);
					playerManager.shuffle = false;
					animHandler.PlayOut();
				}
				else
				{
					DreamOSDataManager.WriteBooleanData(dataCat, "MusicPlayer_Shuffle", value: true);
					playerManager.shuffle = true;
					animHandler.PlayIn();
				}
			});
			if (!DreamOSDataManager.ContainsJsonKey(dataCat, "MusicPlayer_Shuffle") && playerManager.shuffle)
			{
				DreamOSDataManager.WriteBooleanData(dataCat, "MusicPlayer_Shuffle", value: true);
			}
			else if (!DreamOSDataManager.ContainsJsonKey(dataCat, "MusicPlayer_Shuffle") && !playerManager.shuffle)
			{
				DreamOSDataManager.WriteBooleanData(dataCat, "MusicPlayer_Shuffle", value: false);
			}
			else if (DreamOSDataManager.ReadBooleanData(dataCat, "MusicPlayer_Shuffle"))
			{
				playerManager.shuffle = true;
			}
			else if (!DreamOSDataManager.ReadBooleanData(dataCat, "MusicPlayer_Shuffle"))
			{
				playerManager.shuffle = false;
			}
		}

		public void SetVolume(float volume)
		{
			playerManager.audioSource.volume = sliderObj.value;
		}

		private void SetImageColor(Color targetColor)
		{
			if (!imageObj.gameObject.activeInHierarchy)
			{
				imageObj.color = targetColor;
				return;
			}
			StopCoroutine("ChangeImageColor");
			StartCoroutine("ChangeImageColor", targetColor);
		}

		private void SetTextColor(Color targetColor)
		{
			if (!textObj.gameObject.activeInHierarchy)
			{
				textObj.color = targetColor;
				return;
			}
			StopCoroutine("ChangeTextColor");
			StartCoroutine("ChangeTextColor", targetColor);
		}

		private IEnumerator ChangeImageColor(Color targetColor)
		{
			float startTime = Time.time;
			Color baseColor = imageObj.color;
			while (Time.time - startTime < colorAnimDuration)
			{
				float t = (Time.time - startTime) / colorAnimDuration;
				imageObj.color = Color.Lerp(baseColor, targetColor, t);
				yield return new WaitForEndOfFrame();
			}
			imageObj.color = targetColor;
		}

		private IEnumerator ChangeTextColor(Color targetColor)
		{
			float startTime = Time.time;
			Color baseColor = textObj.color;
			while (Time.time - startTime < colorAnimDuration)
			{
				float t = (Time.time - startTime) / colorAnimDuration;
				textObj.color = Color.Lerp(baseColor, targetColor, t);
				yield return new WaitForEndOfFrame();
			}
			textObj.color = targetColor;
		}
	}
}
