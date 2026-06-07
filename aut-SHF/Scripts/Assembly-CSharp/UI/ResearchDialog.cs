using System.Collections.Generic;
using InputControl;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public class ResearchDialog : BaseDialog
	{
		public class ResearchTreeCategoryInfo
		{
			public MstResearchCategoryEntities researchCategoryData;

			public List<ResearchTreeNodeInfo> children;

			public void AddResearchTreeData(MstResearchTreeDataEntities data)
			{
			}
		}

		public class ResearchTreeNodeInfo
		{
			public MstResearchTreeDataEntities researchTreeData;

			public List<ResearchTreeNodeInfo> children;

			public ResearchTreeNodeInfo replaceInfo;

			public MstResearchTreeDataEntities FindResearchTreeData(eResearchTreeId researchTreeId)
			{
				return null;
			}

			public bool AddResearchTreeData(MstResearchTreeDataEntities data)
			{
				return false;
			}
		}

		[SerializeField]
		private ResearchCategoryPanelCtrl researchCategoryPanelPrefab;

		[SerializeField]
		private GameObject contentParent;

		[SerializeField]
		private Button previewButton;

		[SerializeField]
		private Image previewButtonDisableImage;

		[SerializeField]
		private Button nextButton;

		[SerializeField]
		private Image nextButtonDisableImage;

		[SerializeField]
		private PadInputConfigure padInputConfigure;

		[SerializeField]
		private CursorUIGroup contentsCursorUIGroup;

		public TMP_Text upgradePointText;

		public TMP_Text redResearchPointText;

		[Header("詳細")]
		public ResearchDescriptionCtrl descCtrl;

		[Header("設備獲得エフェクトを飛ばすか")]
		[SerializeField]
		private bool isOnGetMachineEffect;

		private List<ResearchTreeCategoryInfo> researchCategoryList;

		private List<ResearchCategoryPanelCtrl> categoryCtrlList;

		private const float categoryWidth = 352f;

		private const float categoryHeight = 344f;

		private const int OnePageRowMax = 4;

		private const int OnePageLineMax = 2;

		private int page;

		private int pageMax;

		private bool isPlayAnimation;

		private InputActionController input;

		private List<eMachine> getMachines;

		private int OnePageCategoryCountMax => 0;

		private float OnePageWidth => 0f;

		public override void Init()
		{
		}

		public override void Open()
		{
		}

		private void Awake()
		{
		}

		private void Update()
		{
		}

		private void CreateResearchTreeData()
		{
		}

		private void CreateResearchTree()
		{
		}

		public void UpdateTreeUI()
		{
		}

		public void OnClickPreviewButton()
		{
		}

		public void OnClickNextButton()
		{
		}

		private bool CheckPageCount(int value)
		{
			return false;
		}

		private void UpdateButtonStatus()
		{
		}

		private void SetPagingButtonActive(Button button, Image disableImage, bool active)
		{
		}

		private void UpdateViewCategory(bool isBefore)
		{
		}

		private void PadContentsUpdate()
		{
		}

		public void UpdateUpgradePoint()
		{
		}

		public void UpdateRedResearchPoint()
		{
		}

		public void OnClickItem(MstResearchTreeDataEntities data)
		{
		}

		public void OnPointerOverCategory(MstResearchCategoryEntities data)
		{
		}

		public void OnPointerOverItem(MstResearchTreeDataEntities data)
		{
		}

		public void OnPointerExitItem()
		{
		}

		private void DisplayResearchTips()
		{
		}

		private void SelectAdjacentPanel(int offset)
		{
		}

		public void CurrentGroupSelect()
		{
		}

		public void OnNextGroupSelect()
		{
		}

		public void OnPreviousGroupSelect()
		{
		}

		public override void Back()
		{
		}
	}
}
