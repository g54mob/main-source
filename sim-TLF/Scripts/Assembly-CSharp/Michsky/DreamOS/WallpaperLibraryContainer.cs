using UnityEngine;

namespace Michsky.DreamOS
{
	[DisallowMultipleComponent]
	[AddComponentMenu("DreamOS/Wallpaper/Wallpaper Library Container")]
	public class WallpaperLibraryContainer : MonoBehaviour
	{
		[SerializeField]
		private WallpaperManager wallpaperManager;

		private void Start()
		{
			FetchItems();
		}

		public void FetchItems()
		{
			if (wallpaperManager == null)
			{
				if (Object.FindObjectsByType<WallpaperManager>(FindObjectsSortMode.None).Length == 0)
				{
					Debug.Log("<b>[Wallpaper Library Container]</b> Wallpaper Manager is missing.", this);
					return;
				}
				wallpaperManager = Object.FindObjectsByType<WallpaperManager>(FindObjectsSortMode.None)[0];
			}
			foreach (Transform item in base.transform)
			{
				Object.Destroy(item.gameObject);
			}
			wallpaperManager.InitializeWallpapers(base.transform);
		}
	}
}
