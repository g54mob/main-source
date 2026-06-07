using UnityEngine;

namespace DV.UIFramework
{
	[DisallowMultipleComponent]
	public class UIMenu : MonoBehaviour
	{
		public void ToggleMenu(bool open)
		{
			if (base.gameObject.activeSelf != open)
			{
				base.gameObject.SetActive(open);
			}
		}
	}
}
