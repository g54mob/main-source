using UnityEngine;

namespace Michsky.DreamOS
{
	public class NavbarExpandButton : MonoBehaviour
	{
		[Header("Resources")]
		public AnimatedIconHandler animatedIcon;

		[Header("Settings")]
		public string appName = "App Name";

		public DreamOSDataManager.DataCategory dataCategory = DreamOSDataManager.DataCategory.Apps;

		private void OnEnable()
		{
			if (!(animatedIcon == null))
			{
				string key = appName + "_NavDrawer";
				if (DreamOSDataManager.ContainsJsonKey(dataCategory, key) && DreamOSDataManager.ReadBooleanData(dataCategory, key))
				{
					animatedIcon.PlayIn();
				}
				else if (DreamOSDataManager.ContainsJsonKey(dataCategory, key) && !DreamOSDataManager.ReadBooleanData(dataCategory, key))
				{
					animatedIcon.PlayOut();
				}
				else
				{
					animatedIcon.PlayStart();
				}
			}
		}
	}
}
