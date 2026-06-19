using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Michsky.DreamOS
{
	public class MusicPlayerManager : MonoBehaviour
	{
		public MusicPlayerPlaylist libraryPlaylist;

		public MusicPlayerPlaylist modPlaylist;

		public List<MusicPlayerPlaylist> customPlaylists = new List<MusicPlayerPlaylist>();

		public AudioSource audioSource;

		public Transform libraryParent;

		[SerializeField]
		private Transform playlistParent;

		[SerializeField]
		private Transform playlistPanelParent;

		[SerializeField]
		private GameObject playlistTrackPreset;

		[SerializeField]
		private GameObject playlistPanelPreset;

		[SerializeField]
		private GameObject playlistItemPreset;

		public WindowPanelManager musicPanelManager;

		[SerializeField]
		private TextMeshProUGUI nowPlayingListTitle;

		public bool repeat;

		public bool shuffle;

		public bool sortListByName = true;

		public bool enablePopupNotification;

		public string playlistSingularLabel = "Song";

		public string playlistPluralLabel = "Songs";

		[SerializeField]
		private Sprite notificationIcon;

		public int duration;

		public float playTime;

		public int seconds;

		public float secondsRaw;

		public int minutes;

		public MusicPlayerPlaylist currentPlaylist;

		public PlaylistTrack currentTrack;

		public int currentTrackIndex;

		public List<PlaylistTrack> playerQueue = new List<PlaylistTrack>();

		public List<MusicPlayerDataItem> dataToBeUpdated = new List<MusicPlayerDataItem>();

		public string customClipName;

		public string customClipArtist;

		public Sprite customClipCover;

		private void Awake()
		{
			Initialize();
		}

		private void OnDisable()
		{
			Stop();
		}

		public void Initialize()
		{
			foreach (Transform item in libraryParent)
			{
				Object.Destroy(item.gameObject);
			}
			foreach (Transform item2 in playlistParent)
			{
				Object.Destroy(item2.gameObject);
			}
			foreach (Transform item3 in playlistPanelParent)
			{
				Object.Destroy(item3.gameObject);
			}
			if (audioSource == null)
			{
				audioSource = GetComponent<AudioSource>();
			}
			if (sortListByName)
			{
				libraryPlaylist.playlist.Sort(SortByName);
			}
			InstantiatePlaylist(libraryPlaylist, createContent: true, libraryParent);
			for (int i = 0; i < customPlaylists.Count; i++)
			{
				InstantiatePlaylist(customPlaylists[i]);
			}
		}

		public void InstantiatePlaylist(MusicPlayerPlaylist targetPlaylist, bool createContent = true, Transform altTrackParent = null)
		{
			if (targetPlaylist.playlist.Count != 0)
			{
				GameObject gameObject = Object.Instantiate(playlistItemPreset, new Vector3(0f, 0f, 0f), Quaternion.identity);
				gameObject.transform.SetParent(playlistParent, worldPositionStays: false);
				gameObject.gameObject.name = targetPlaylist.playlistName;
				PlaylistItem tempItem = gameObject.GetComponent<PlaylistItem>();
				tempItem.playlistID = targetPlaylist.playlistName;
				tempItem.coverImage.sprite = targetPlaylist.coverImage;
				tempItem.titleText.text = targetPlaylist.playlistName;
				string text = null;
				text = ((targetPlaylist.playlist.Count != 1) ? (targetPlaylist.playlist.Count + " " + playlistPluralLabel) : (targetPlaylist.playlist.Count + " " + playlistSingularLabel));
				tempItem.countText.text = text;
				tempItem.playlistButton.onClick.AddListener(delegate
				{
					musicPanelManager.OpenPanel("Playlist_" + tempItem.playlistID);
				});
				if (createContent)
				{
					InstantiatePlaylistContent(targetPlaylist, altTrackParent);
				}
			}
		}

		public void InstantiatePlaylistContent(MusicPlayerPlaylist targetPlaylist, Transform altTrackParent = null)
		{
			if (sortListByName)
			{
				targetPlaylist.playlist.Sort(SortByName);
			}
			bool flag = false;
			PlaylistTrack trackHelper = null;
			GameObject gameObject = Object.Instantiate(playlistPanelPreset, new Vector3(0f, 0f, 0f), Quaternion.identity);
			gameObject.transform.SetParent(playlistPanelParent, worldPositionStays: false);
			gameObject.gameObject.name = targetPlaylist.playlistName;
			WindowPanelManager.PanelItem panelItem = new WindowPanelManager.PanelItem();
			panelItem.panelName = "Playlist_" + targetPlaylist.playlistName;
			panelItem.panelObject = gameObject.GetComponent<Animator>();
			musicPanelManager.panels.Add(panelItem);
			PlaylistPanel panel = gameObject.GetComponent<PlaylistPanel>();
			panel.panelID = targetPlaylist.playlistName;
			if (panel.bannerImage != null)
			{
				panel.bannerImage.sprite = targetPlaylist.coverImage;
			}
			panel.coverImage.sprite = targetPlaylist.coverImage;
			panel.titleText.text = targetPlaylist.playlistName;
			string text = null;
			text = ((targetPlaylist.playlist.Count != 1) ? (targetPlaylist.playlist.Count + " " + playlistPluralLabel) : (targetPlaylist.playlist.Count + " " + playlistSingularLabel));
			panel.countText.text = text;
			foreach (Transform item in panel.contentParent)
			{
				Object.Destroy(item.gameObject);
			}
			for (int i = 0; i < targetPlaylist.playlist.Count; i++)
			{
				if (targetPlaylist.playlist[i].excludeFromLibrary || targetPlaylist.playlist[i].musicClip == null)
				{
					continue;
				}
				GameObject gameObject2 = Object.Instantiate(playlistTrackPreset, new Vector3(0f, 0f, 0f), Quaternion.identity);
				gameObject2.transform.SetParent(panel.contentParent, worldPositionStays: false);
				gameObject2.gameObject.name = targetPlaylist.playlist[i].musicTitle;
				PlaylistTrack tempTrack = gameObject2.GetComponent<PlaylistTrack>();
				tempTrack.itemIndex = i;
				tempTrack.manager = this;
				tempTrack.playlist = targetPlaylist;
				tempTrack.cover = targetPlaylist.playlist[i].musicCover;
				tempTrack.title = targetPlaylist.playlist[i].musicTitle;
				tempTrack.artist = targetPlaylist.playlist[i].artistTitle;
				tempTrack.album = targetPlaylist.playlist[i].albumTitle;
				tempTrack.accentColor = DreamOSInternalTools.GetSpriteAccentColor(tempTrack.cover);
				tempTrack.accentMatchColor = DreamOSInternalTools.GetAccentMatchColor(tempTrack.accentColor);
				panel.tracks.Add(tempTrack);
				if (trackHelper == null)
				{
					trackHelper = tempTrack;
				}
				if (!flag && tempTrack.backgroundImage != null)
				{
					tempTrack.backgroundImage.color = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, 4);
					flag = true;
				}
				else if (tempTrack.backgroundImage != null)
				{
					tempTrack.backgroundImage.color = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, 0);
					flag = false;
				}
				tempTrack.coverImage.sprite = targetPlaylist.playlist[i].musicCover;
				tempTrack.titleText.text = targetPlaylist.playlist[i].musicTitle;
				tempTrack.artistText.text = targetPlaylist.playlist[i].artistTitle;
				tempTrack.durationText.text = (int)targetPlaylist.playlist[i].musicClip.length / 60 % 60 + ":" + ((int)targetPlaylist.playlist[i].musicClip.length % 60).ToString("D2");
				tempTrack.button.onClick.AddListener(delegate
				{
					if (currentPlaylist != targetPlaylist || playerQueue.Count == 0)
					{
						playerQueue.Clear();
						foreach (PlaylistTrack track in panel.tracks)
						{
							playerQueue.Add(track);
						}
					}
					currentPlaylist = targetPlaylist;
					Play(tempTrack);
				});
				if (!(altTrackParent != null))
				{
					continue;
				}
				GameObject gameObject3 = Object.Instantiate(gameObject2, new Vector3(0f, 0f, 0f), Quaternion.identity);
				gameObject3.transform.SetParent(altTrackParent, worldPositionStays: false);
				gameObject3.gameObject.name = targetPlaylist.playlist[i].musicTitle;
				PlaylistTrack altTrack = gameObject3.GetComponent<PlaylistTrack>();
				tempTrack.twinTrack = altTrack;
				altTrack.button.onClick.AddListener(delegate
				{
					if (currentPlaylist != targetPlaylist || playerQueue.Count == 0)
					{
						playerQueue.Clear();
						foreach (PlaylistTrack track2 in panel.tracks)
						{
							playerQueue.Add(track2);
						}
					}
					currentPlaylist = targetPlaylist;
					Play(altTrack);
				});
			}
			panel.playAllButton.onClick.AddListener(delegate
			{
				playerQueue.Clear();
				foreach (PlaylistTrack track3 in panel.tracks)
				{
					playerQueue.Add(track3);
				}
				Play(trackHelper);
			});
			if (currentTrack == null)
			{
				trackHelper.button.onClick.Invoke();
				Stop();
			}
		}

		public void Play()
		{
			if (currentTrack != null)
			{
				audioSource.clip = currentTrack.playlist.playlist[currentTrack.itemIndex].musicClip;
				currentTrack.SetNowPlayingState(value: true);
				if (nowPlayingListTitle != null)
				{
					nowPlayingListTitle.text = currentTrack.playlist.playlistName;
				}
			}
			audioSource.Play();
			UpdateDataItems();
			if (base.gameObject.activeInHierarchy)
			{
				StopCoroutine("ProcessPlayback");
				StartCoroutine("ProcessPlayback");
			}
		}

		public void Play(PlaylistTrack track)
		{
			if (currentTrack != null)
			{
				currentTrack.SetNowPlayingState(value: false);
			}
			audioSource.Stop();
			currentTrack = track;
			currentTrackIndex = currentTrack.itemIndex;
			audioSource.clip = track.playlist.playlist[currentTrackIndex].musicClip;
			audioSource.time = 0f;
			duration = GetDuration();
			audioSource.Play();
			UpdateDataItems();
			if (currentTrack != null)
			{
				currentTrack.SetNowPlayingState(value: true);
			}
			if (nowPlayingListTitle != null)
			{
				nowPlayingListTitle.text = currentTrack.playlist.playlistName;
			}
			if (base.gameObject.activeInHierarchy)
			{
				StopCoroutine("ProcessPlayback");
				StartCoroutine("ProcessPlayback");
			}
		}

		public void PlayCustomClip(AudioClip clip, Sprite cover, string clipName, string clipAuthor)
		{
			if (currentTrack != null)
			{
				currentTrack.SetNowPlayingState(value: false);
			}
			customClipName = clipName;
			customClipArtist = clipAuthor;
			customClipCover = cover;
			currentTrack = null;
			currentPlaylist = null;
			audioSource.Stop();
			audioSource.clip = clip;
			audioSource.time = 0f;
			duration = GetDuration();
			audioSource.Play();
			UpdateDataItems();
			if (nowPlayingListTitle != null)
			{
				nowPlayingListTitle.text = "Custom";
			}
			if (base.gameObject.activeInHierarchy)
			{
				StopCoroutine("ProcessPlayback");
				StartCoroutine("ProcessPlayback");
			}
		}

		public void Pause()
		{
			audioSource.Pause();
			if (currentTrack != null)
			{
				currentTrack.SetNowPlayingState(value: false);
			}
			UpdateDataItems();
		}

		public void Stop()
		{
			StopCoroutine("ProcessPlayback");
			if (audioSource != null)
			{
				audioSource.Stop();
			}
			if (currentTrack != null)
			{
				currentTrack.SetNowPlayingState(value: false);
			}
			UpdateDataItems();
		}

		public void Mute()
		{
			audioSource.mute = !audioSource.mute;
		}

		public void NextTrack()
		{
			if (currentTrack != null)
			{
				currentTrack.SetNowPlayingState(value: false);
			}
			if (currentPlaylist == null)
			{
				Stop();
				return;
			}
			audioSource.Stop();
			if (currentPlaylist.playlist.Count == 1)
			{
				audioSource.Stop();
				audioSource.time = 0f;
				audioSource.Play();
			}
			else if (shuffle && !repeat)
			{
				currentTrack = playerQueue[DreamOSInternalTools.GetRandomUniqueValue(currentTrackIndex, 0, currentPlaylist.playlist.Count)];
				currentTrackIndex = currentTrack.itemIndex;
				if (currentPlaylist.playlist[currentTrackIndex].excludeFromLibrary)
				{
					NextTrack();
					return;
				}
				audioSource.clip = currentPlaylist.playlist[currentTrackIndex].musicClip;
			}
			else
			{
				currentTrackIndex++;
				if (currentTrackIndex > currentPlaylist.playlist.Count - 1)
				{
					currentTrackIndex = 0;
				}
				if (currentPlaylist.playlist[currentTrackIndex].excludeFromLibrary)
				{
					NextTrack();
				}
				currentTrack = playerQueue[currentTrackIndex];
				audioSource.clip = currentPlaylist.playlist[currentTrackIndex].musicClip;
			}
			duration = GetDuration();
			audioSource.time = 0f;
			audioSource.Play();
			UpdateDataItems();
			if (currentTrack != null)
			{
				currentTrack.SetNowPlayingState(value: true);
			}
			if (enablePopupNotification && NotificationManager.instance != null)
			{
				NotificationManager.instance.CreatePopupNotification(notificationIcon, currentPlaylist.playlist[currentTrackIndex].musicTitle, currentPlaylist.playlist[currentTrackIndex].artistTitle, true, null);
			}
		}

		public void PrevTrack()
		{
			if (currentTrack != null)
			{
				currentTrack.SetNowPlayingState(value: false);
			}
			if (currentPlaylist == null)
			{
				Stop();
				return;
			}
			audioSource.Stop();
			if (shuffle && !repeat)
			{
				currentTrack = playerQueue[DreamOSInternalTools.GetRandomUniqueValue(currentTrackIndex, 0, currentPlaylist.playlist.Count)];
				currentTrackIndex = currentTrack.itemIndex;
				audioSource.clip = currentPlaylist.playlist[currentTrackIndex].musicClip;
			}
			else
			{
				currentTrackIndex--;
				if (currentTrackIndex < 0)
				{
					currentTrackIndex = currentPlaylist.playlist.Count - 1;
				}
				currentTrack = playerQueue[currentTrackIndex];
				audioSource.clip = currentPlaylist.playlist[currentTrackIndex].musicClip;
			}
			duration = GetDuration();
			audioSource.clip = currentPlaylist.playlist[currentTrackIndex].musicClip;
			audioSource.time = 0f;
			audioSource.Play();
			UpdateDataItems();
			if (currentTrack != null)
			{
				currentTrack.SetNowPlayingState(value: true);
			}
			if (enablePopupNotification && NotificationManager.instance != null)
			{
				NotificationManager.instance.CreatePopupNotification(notificationIcon, currentPlaylist.playlist[currentTrackIndex].musicTitle, currentPlaylist.playlist[currentTrackIndex].artistTitle, true, null);
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

		public void SetPopupNotification(bool value)
		{
			if (value)
			{
				enablePopupNotification = true;
			}
			else
			{
				enablePopupNotification = false;
			}
		}

		public int GetDuration()
		{
			return (int)audioSource.clip.length;
		}

		public string GetNormalizedDuration()
		{
			return GetDuration() / 60 % 60 + ":" + (duration % 60).ToString("D2");
		}

		public int GetPlayTime()
		{
			int result = (int)playTime % 60;
			secondsRaw = playTime % 60f;
			minutes = (int)playTime / 60 % 60;
			return result;
		}

		public string GetNormalizedPlayTime()
		{
			return minutes + ":" + seconds.ToString("00");
		}

		public Sprite GetCoverArt()
		{
			if (currentTrack != null)
			{
				return currentTrack.cover;
			}
			return customClipCover;
		}

		public string GetAlbumName()
		{
			if (currentTrack != null)
			{
				return currentTrack.album;
			}
			return "Custom";
		}

		public string GetTrackName()
		{
			if (currentTrack != null)
			{
				return currentTrack.title;
			}
			return customClipName;
		}

		public string GetArtistName()
		{
			if (currentTrack != null)
			{
				return currentTrack.artist;
			}
			return customClipArtist;
		}

		public Color GetAccentColor(Image targetImage)
		{
			Color result = new Color(25f, 35f, 45f, targetImage.color.a);
			if (currentTrack != null)
			{
				result = new Color(currentTrack.accentColor.r, currentTrack.accentColor.g, currentTrack.accentColor.b, targetImage.color.a);
			}
			return result;
		}

		public Color GetAccentMatchColor(Image targetImage)
		{
			Color result = new Color(25f, 35f, 45f, targetImage.color.a);
			if (currentTrack != null)
			{
				result = new Color(currentTrack.accentMatchColor.r, currentTrack.accentMatchColor.g, currentTrack.accentMatchColor.b, targetImage.color.a);
			}
			return result;
		}

		public Color GetAccentColor(TextMeshProUGUI targetText)
		{
			Color result = new Color(25f, 35f, 45f, targetText.color.a);
			if (currentTrack != null)
			{
				result = new Color(currentTrack.accentColor.r, currentTrack.accentColor.g, currentTrack.accentColor.b, targetText.color.a);
			}
			return result;
		}

		public Color GetAccentMatchColor(TextMeshProUGUI targetText)
		{
			Color result = new Color(25f, 35f, 45f, targetText.color.a);
			if (currentTrack != null)
			{
				result = new Color(currentTrack.accentMatchColor.r, currentTrack.accentMatchColor.g, currentTrack.accentMatchColor.b, targetText.color.a);
			}
			return result;
		}

		private static int SortByName(MusicPlayerPlaylist.MusicItem o1, MusicPlayerPlaylist.MusicItem o2)
		{
			return o1.musicTitle.CompareTo(o2.musicTitle);
		}

		private IEnumerator ProcessPlayback()
		{
			while (audioSource.isPlaying)
			{
				playTime = audioSource.time;
				seconds = GetPlayTime();
				if (playTime >= (float)duration && repeat && !shuffle)
				{
					audioSource.Stop();
					audioSource.time = 0f;
					audioSource.Play();
				}
				else if (playTime >= (float)duration)
				{
					NextTrack();
				}
				yield return null;
			}
		}
	}
}
