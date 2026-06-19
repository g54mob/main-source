using UnityEngine;
using UnityEngine.UI;

namespace Michsky.DreamOS
{
	[RequireComponent(typeof(Image))]
	public class WallpaperObject : MonoBehaviour
	{
		[SerializeField]
		private WallpaperManager wallpaperManager;

		[SerializeField]
		private Image targetImage;

		private void Awake()
		{
			if (targetImage == null)
			{
				targetImage = GetComponent<Image>();
			}
			if (wallpaperManager == null && Object.FindObjectsByType<WallpaperManager>(FindObjectsSortMode.None).Length != 0)
			{
				wallpaperManager = Object.FindObjectsByType<WallpaperManager>(FindObjectsSortMode.None)[0];
			}
		}

		private void Start()
		{
			if (wallpaperManager == null)
			{
				Debug.LogWarning("<b>[Wallpaper Object]</b> Cannot update the wallpaper because 'Wallpaper Manager' is missing.");
			}
			else
			{
				wallpaperManager.AddCachedObject(this, updateAfterAdding: true);
			}
		}

		public void UpdateWallpaper()
		{
			if (!(wallpaperManager == null))
			{
				targetImage.sprite = wallpaperManager.GetWallpaper(wallpaperManager.wallpaperIndex);
			}
		}

		public void UpdateWallpaper(WallpaperManager manager)
		{
			targetImage.sprite = manager.GetWallpaper(wallpaperManager.wallpaperIndex);
		}
	}
}
