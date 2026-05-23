using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public class MasterImageItem : MonoBehaviour
	{
		[Header("Unlock")]
		public GameObject unlockedItemsParent;

		[Header("Image")]
		public Image unselectedImage;

		public Image selectedImage;

		[Header("Ascension")]
		public GameObject ascensionGroup;

		public TMP_Text unlockedAscensionLevelText;

		public TMP_Text masterLevelText;

		public void Init(bool unlock, Sprite unselectedImage, Sprite selectedImage, int masterLevel, int unlockedAscensionLevel, bool displayAscension = true)
		{
		}

		public void SetClearAscensionText(int ascension)
		{
		}

		public void SetMasterLevel(bool unlock, int level)
		{
		}

		public void SelectItem(bool selected)
		{
		}

		public bool IsSelected()
		{
			return false;
		}

		public bool IsUnlocked()
		{
			return false;
		}
	}
}
