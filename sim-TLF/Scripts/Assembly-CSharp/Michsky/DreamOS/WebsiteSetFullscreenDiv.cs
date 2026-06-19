using UnityEngine;

namespace Michsky.DreamOS
{
	[DisallowMultipleComponent]
	public class WebsiteSetFullscreenDiv : MonoBehaviour
	{
		private void Start()
		{
			base.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(base.transform.parent.GetComponent<RectTransform>().rect.width, base.transform.parent.GetComponent<RectTransform>().rect.height);
		}
	}
}
