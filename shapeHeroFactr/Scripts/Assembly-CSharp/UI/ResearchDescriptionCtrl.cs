using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public class ResearchDescriptionCtrl : MonoBehaviour
	{
		private enum DetailType
		{
			Category = 0,
			Machine = 1,
			Attacment = 2
		}

		[Header("DetailPanel")]
		public GameObject categoryDetailPanel;

		public GameObject machineDetailPanel;

		public GameObject attachmentDetailPanel;

		[Header("Text")]
		public TMP_Text categoryTitleText;

		public TMP_Text categoryDescriptionText;

		public TMP_Text machineTitleText;

		public TMP_Text machineDescriptionText;

		public TMP_Text attachmentDescriptionText;

		[Header("Image")]
		public Image categoryIcon;

		public Image image;

		public SimpleSpriteAnimator spriteAnimator;

		[Header("Point")]
		public GameObject researchPointPanel;

		public TMP_Text researchPointText;

		public GameObject redResearchPointPanel;

		public TMP_Text redResearchPointText;

		public GameObject manaPanel;

		public TMP_Text manaText;

		[Header("Icon")]
		public Image machineIcon;

		public void SetCategoryDetail(MstResearchCategoryEntities entities)
		{
		}

		public void SetMachineDetail(MstResearchTreeDataEntities entities)
		{
		}

		public void SetAttachmentDetail(MstResearchTreeDataEntities entities)
		{
		}

		protected virtual void SetNeedResearchPoint(MstResearchTreeDataEntities entities)
		{
		}

		private void SetImage(MstResearchTreeDataEntities entities)
		{
		}

		private void ShowPanel(DetailType type)
		{
		}

		public void HideAllPanels()
		{
		}
	}
}
