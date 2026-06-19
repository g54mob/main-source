using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

namespace Michsky.DreamOS
{
	public class ModManager : MonoBehaviour
	{
		[Serializable]
		public class ModItem
		{
			public string modTitle;

			public string modDescription;

			public Sprite modIcon;

			public string modAsset;

			public ModuleType moduleType;
		}

		public enum ModuleType
		{
			MusicPlayer = 0,
			Notepad = 1,
			PhotoGallery = 2,
			VideoPlayer = 3
		}

		[SerializeField]
		private GameObject modLibraryElement;

		[SerializeField]
		private Transform modLibraryParent;

		[SerializeField]
		private GameObject noModsIndicator;

		public bool enableMusicPlayerModule = true;

		[SerializeField]
		private MusicPlayerManager musicPlayer;

		[SerializeField]
		private bool enableMusicPlayerImportLogs = true;

		[SerializeField]
		private string musicPlayerID = "Music Player";

		public bool enableNotepadModule = true;

		[SerializeField]
		private NotepadManager notepad;

		[SerializeField]
		private string notepadID = "Notepad";

		public bool enablePhotoGalleryModule = true;

		[SerializeField]
		private PhotoGalleryManager photoGallery;

		[SerializeField]
		private string photoGalleryID = "Photo Gallery";

		public bool enableVideoPlayerModule = true;

		[SerializeField]
		private VideoPlayerManager videoPlayer;

		[SerializeField]
		private string videoPlayerID = "Video Player";

		[SerializeField]
		private string subPath = "DreamOS_Mods";

		[SerializeField]
		private string dataName = "ModData";

		[SerializeField]
		private string fileExtension = ".data";

		[SerializeField]
		private Sprite defaultIcon;

		private string fullPath;

		private List<ModItem> mods = new List<ModItem>();

		private void Awake()
		{
			InitializeMods();
		}

		public void InitializeMods()
		{
			ReadModData();
		}

		private void CheckForDataFile()
		{
			string dataPath = Application.dataPath;
			dataPath = dataPath.Replace(Application.productName + "_Data", "");
			fullPath = dataPath + subPath + "/";
		}

		private void ReadModData()
		{
			CheckForDataFile();
			if (!Directory.Exists(fullPath))
			{
				return;
			}
			List<string> list = new List<string>();
			FileInfo[] files = new DirectoryInfo(fullPath).GetFiles("*" + fileExtension, SearchOption.AllDirectories);
			foreach (FileInfo fileInfo in files)
			{
				list.Add(fileInfo.DirectoryName + "/" + dataName + fileExtension);
			}
			foreach (Transform item in modLibraryParent)
			{
				UnityEngine.Object.Destroy(item.gameObject);
			}
			int num = 0;
			string text = null;
			string text2 = null;
			string text3 = null;
			string text4 = null;
			for (int j = 0; j < list.Count; j++)
			{
				foreach (string item2 in File.ReadLines(list[j]))
				{
					if (item2.Contains("[Title] "))
					{
						text = item2.Replace("[Title] ", "");
					}
					else if (item2.Contains("[Description] "))
					{
						text2 = item2.Replace("[Description] ", "");
					}
					else if (item2.Contains("[Icon] "))
					{
						text3 = item2.Replace("[Icon] ", "");
					}
					else if (item2.Contains("[ModuleType] "))
					{
						text4 = item2.Replace("[ModuleType] ", "");
					}
					else if (item2.Contains("[ModuleAsset] "))
					{
						Sprite sprite = null;
						string moduleAsset = item2.Replace("[ModuleAsset] ", "");
						GameObject gameObject = UnityEngine.Object.Instantiate(modLibraryElement, new Vector3(0f, 0f, 0f), Quaternion.identity);
						gameObject.transform.SetParent(modLibraryParent, worldPositionStays: false);
						gameObject.name = text;
						try
						{
							sprite = LoadNewSprite(fullPath + text4 + "/" + text + "/" + text3);
						}
						catch
						{
							sprite = defaultIcon;
						}
						ModLibraryElement component = gameObject.GetComponent<ModLibraryElement>();
						component.SetIcon(sprite);
						component.SetTitle(text);
						component.SetDescription(text2);
						component.SetModuleIcon(text4);
						CreateModuleItem(sprite, text, text2, text4, moduleAsset);
						num++;
					}
				}
			}
			if (enableMusicPlayerModule)
			{
				musicPlayer.modPlaylist.playlist.Clear();
			}
			if (num == 0)
			{
				noModsIndicator.SetActive(value: true);
				return;
			}
			StartCoroutine(ProcessModules());
			noModsIndicator.SetActive(value: false);
		}

		private void CreateModuleItem(Sprite icon, string title, string desc, string moduleType, string moduleAsset)
		{
			ModItem modItem = new ModItem();
			modItem.modIcon = icon;
			modItem.modTitle = title;
			modItem.modDescription = desc;
			modItem.modAsset = moduleAsset;
			if (moduleType == musicPlayerID)
			{
				modItem.moduleType = ModuleType.MusicPlayer;
			}
			else if (moduleType == notepadID)
			{
				modItem.moduleType = ModuleType.Notepad;
			}
			else if (moduleType == photoGalleryID)
			{
				modItem.moduleType = ModuleType.PhotoGallery;
			}
			else if (moduleType == videoPlayerID)
			{
				modItem.moduleType = ModuleType.VideoPlayer;
			}
			mods.Add(modItem);
		}

		private IEnumerator ProcessModules()
		{
			int musicPlayerCount = 0;
			int i = 0;
			while (i < mods.Count)
			{
				if (mods[i].moduleType == ModuleType.MusicPlayer && enableMusicPlayerModule)
				{
					MusicPlayerPlaylist.MusicItem tempItem = new MusicPlayerPlaylist.MusicItem
					{
						musicTitle = mods[i].modTitle,
						artistTitle = mods[i].modDescription,
						musicCover = mods[i].modIcon,
						isModContent = true
					};
					string uri = fullPath + musicPlayerID + "/" + mods[i].modTitle + "/" + mods[i].modAsset;
					UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip(uri, AudioType.MPEG);
					yield return www.SendWebRequest();
					if (enableMusicPlayerImportLogs)
					{
						Debug.Log(string.Format("Importing ({0}): {1}", musicPlayerCount, mods[i].modTitle + "/" + mods[i].modAsset));
					}
					tempItem.musicClip = DownloadHandlerAudioClip.GetContent(www);
					musicPlayer.modPlaylist.playlist.Add(tempItem);
					musicPlayerCount++;
				}
				else if (mods[i].moduleType == ModuleType.Notepad && enableNotepadModule)
				{
					notepad.CreateNote(mods[i].modTitle, mods[i].modTitle, mods[i].modAsset);
				}
				else if (mods[i].moduleType == ModuleType.PhotoGallery && enablePhotoGalleryModule)
				{
					photoGallery.CreatePhoto(mods[i].modIcon, mods[i].modTitle, mods[i].modDescription);
				}
				else if (mods[i].moduleType == ModuleType.VideoPlayer && enableVideoPlayerModule)
				{
					string url = fullPath + videoPlayerID + "/" + mods[i].modTitle + "/" + mods[i].modAsset;
					videoPlayer.CreateVideo(mods[i].modIcon, mods[i].modTitle, mods[i].modDescription, url);
				}
				int num = i + 1;
				i = num;
			}
			if (musicPlayerCount > 0)
			{
				musicPlayer.InstantiatePlaylist(musicPlayer.modPlaylist);
			}
			yield return null;
		}

		private Sprite LoadNewSprite(string filePath, float pixelsPerUnit = 100f, SpriteMeshType spriteType = SpriteMeshType.Tight)
		{
			Texture2D texture2D = DreamOSInternalTools.LoadTexture(filePath);
			return Sprite.Create(texture2D, new Rect(0f, 0f, texture2D.width, texture2D.height), new Vector2(0f, 0f), pixelsPerUnit, 0u, spriteType);
		}
	}
}
