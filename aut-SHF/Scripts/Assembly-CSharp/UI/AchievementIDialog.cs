using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public class AchievementIDialog : BaseDialog
	{
		[SerializeField]
		private AchievementItemButton itemButtonPrefab;

		[SerializeField]
		private Toggle normalTabToggle;

		[SerializeField]
		private GameObject normalContentsObj;

		[SerializeField]
		private RectTransform normalParent;

		[SerializeField]
		private Toggle eventTabToggle;

		[SerializeField]
		private GameObject eventContentsObj;

		[SerializeField]
		private RectTransform eventParent;

		[SerializeField]
		private GameObject descriptionGroup;

		[SerializeField]
		private ChoiceMenuButtonBase toolTip;

		[SerializeField]
		private Image tipsIcon;

		[SerializeField]
		private Sprite unknownTipsIcon;

		private List<AchievementItemButton> itemList;

		private const char secretChar = '?';

		private string _secretTitle;

		private string _secretDesc;

		public override void Init()
		{
		}

		private void ResetItems()
		{
		}

		private void CreateItems()
		{
		}

		public override void Open()
		{
		}

		public void OnPointerEnterItem(eSteamAchivementId id)
		{
		}

		public void OnPointerExitItem()
		{
		}

		public void OnChangedTab(bool isOn)
		{
		}

		public void UpdateUI()
		{
		}
	}
}
