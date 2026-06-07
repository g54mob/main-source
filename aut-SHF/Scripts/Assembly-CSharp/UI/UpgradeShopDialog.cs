using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace UI
{
	public class UpgradeShopDialog : BaseDialog
	{
		public TMP_Text upgradePointText;

		public ResearchMenuButton researchItemPrefab;

		private List<ResearchMenuButton> _choiceShopButtons;

		[Header("詳細")]
		public GameObject descriptionGroup;

		public AnimatedImage gifPlayer;

		public ChoiceMenuButtonBase toolTip;

		public RectTransform artifactContent;

		public ResearchGroup researchGroupPrefab;

		public RectTransform sameLevelReserchPrefab;

		public Dictionary<eResearchCategory, ResearchGroup> _researchGroupDict;

		private const int MAXLEVEL = 4;

		public override void Init()
		{
		}

		public override void Open()
		{
		}

		public void UpdateUpgradePoint()
		{
		}

		public void CheckNewTree()
		{
		}

		private ResearchGroup CreateResearchTree(eResearchCategory category)
		{
			return null;
		}

		private ResearchGroup CreateReserchGroup(eResearchCategory category)
		{
			return null;
		}

		private RectTransform CreateSameLevelReserch(RectTransform parent)
		{
			return null;
		}

		private ResearchMenuButton CreateChild(RectTransform buttonParent)
		{
			return null;
		}

		public void ShopButtonUpdate()
		{
		}

		public override void Back()
		{
		}
	}
}
