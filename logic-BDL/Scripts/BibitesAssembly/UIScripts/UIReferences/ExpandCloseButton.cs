using UnityEngine;

namespace UIScripts.UIReferences
{
	public class ExpandCloseButton : MonoBehaviour
	{
		public GameObject body;

		public Transform arrow;

		private void Awake()
		{
			arrow.transform.rotation = Quaternion.Euler(0f, 0f, body.activeSelf ? 0f : 180f);
		}

		public void Toggle()
		{
			Toggle(!body.activeSelf);
		}

		public void Toggle(bool active)
		{
			body.SetActive(active);
			arrow.transform.rotation = Quaternion.Euler(0f, 0f, active ? 0f : 180f);
		}
	}
}
