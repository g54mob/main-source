using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Michsky.DreamOS
{
	public class ModLibraryElement : MonoBehaviour
	{
		[SerializeField]
		private Image iconObject;

		[SerializeField]
		private TextMeshProUGUI titleObject;

		[SerializeField]
		private TextMeshProUGUI descObject;

		[SerializeField]
		private Transform moduleTypeParent;

		public void SetIcon(Sprite ico)
		{
			iconObject.sprite = ico;
		}

		public void SetTitle(string title)
		{
			titleObject.text = title;
		}

		public void SetDescription(string desc)
		{
			descObject.text = desc;
		}

		public void SetModuleIcon(string type)
		{
			foreach (Transform item in moduleTypeParent)
			{
				if (item.gameObject.name == type)
				{
					item.gameObject.SetActive(value: true);
				}
				else
				{
					item.gameObject.SetActive(value: false);
				}
			}
		}
	}
}
