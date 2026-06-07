using UnityEngine;

namespace UIScripts
{
	public class ObjectToggle : MonoBehaviour
	{
		public void Toggle()
		{
			base.gameObject.SetActive(!base.gameObject.activeSelf);
		}
	}
}
