using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Michsky.DreamOS
{
	public class WallpaperManager : MonoBehaviour
	{
		public WallpaperLibrary wallpaperLibrary;

		public GameObject wallpaperItem;

		public int wallpaperIndex;

		public bool saveSelected = true;

		private List<WallpaperObject> cachedObjects = new List<WallpaperObject>();

		private DreamOSDataManager.DataCategory dataCat;

		private void Awake()
		{
			GetWallpaperData();
		}

		public void GetWallpaperData()
		{
			if (saveSelected && DreamOSDataManager.ContainsJsonKey(dataCat, "CurrentWallpaper"))
			{
				wallpaperIndex = DreamOSDataManager.ReadIntData(dataCat, "CurrentWallpaper");
			}
			else if (saveSelected && !DreamOSDataManager.ContainsJsonKey(dataCat, "CurrentWallpaper"))
			{
				DreamOSDataManager.WriteIntData(dataCat, "CurrentWallpaper", wallpaperIndex);
			}
		}

		public void InitializeWallpapers(Transform wallpaperParent)
		{
			if (wallpaperItem == null)
			{
				return;
			}
			foreach (Transform item in wallpaperParent)
			{
				Object.Destroy(item.gameObject);
			}
			for (int i = 0; i < wallpaperLibrary.wallpapers.Count; i++)
			{
				int tempIndex = i;
				GameObject obj = Object.Instantiate(wallpaperItem, new Vector3(0f, 0f, 0f), Quaternion.identity);
				obj.transform.SetParent(wallpaperParent, worldPositionStays: false);
				obj.name = wallpaperLibrary.wallpapers[i].wallpaperID;
				obj.transform.Find("Image Parent/Image").GetComponent<Image>().sprite = wallpaperLibrary.wallpapers[i].wallpaperSprite;
				obj.GetComponent<ButtonManager>().onClick.AddListener(delegate
				{
					SetWallpaper(tempIndex, updateCachedObjects: true);
				});
			}
		}

		public void SetWallpaper(int index, bool updateCachedObjects = false)
		{
			wallpaperIndex = index;
			if (saveSelected)
			{
				DreamOSDataManager.WriteIntData(dataCat, "CurrentWallpaper", wallpaperIndex);
			}
			if (!updateCachedObjects)
			{
				return;
			}
			foreach (WallpaperObject cachedObject in cachedObjects)
			{
				cachedObject.UpdateWallpaper();
			}
		}

		public Sprite GetWallpaper(int index)
		{
			return wallpaperLibrary.wallpapers[index].wallpaperSprite;
		}

		public void AddWallpaperToLibrary(Sprite wallpaperSprite, string wallpaperName)
		{
			if (wallpaperLibrary == null)
			{
				Debug.LogError("<b>[Wallpaper Manager]</b> Cannot add the wallpaper due to missing library.");
				return;
			}
			WallpaperLibrary.WallpaperItem wallpaperItem = new WallpaperLibrary.WallpaperItem();
			wallpaperItem.wallpaperSprite = wallpaperSprite;
			wallpaperItem.wallpaperID = wallpaperName;
			wallpaperLibrary.wallpapers.Add(wallpaperItem);
		}

		public void AddCachedObject(WallpaperObject woInstance, bool updateAfterAdding = false)
		{
			cachedObjects.Add(woInstance);
			if (updateAfterAdding)
			{
				woInstance.UpdateWallpaper();
			}
		}
	}
}
