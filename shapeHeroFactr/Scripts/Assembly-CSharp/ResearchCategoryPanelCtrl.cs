using System.Collections.Generic;
using InputControl;
using UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ResearchCategoryPanelCtrl : MonoBehaviour
{
	[SerializeField]
	private ResearchTreeNodeCtrl researchNodePrefab;

	[SerializeField]
	private Image frame;

	[SerializeField]
	private Image backgroundImage;

	[SerializeField]
	private GameObject categoryPanel;

	[SerializeField]
	private Image categoryIcon;

	[SerializeField]
	private Image branchLine;

	[SerializeField]
	private CursorUIItem _topItem;

	[SerializeField]
	private GameObject _padGuide;

	[SerializeField]
	private GameObject _cursor;

	private const float branchWidth = 74f;

	private const float nodeHeight = 86f;

	private ResearchDialog.ResearchTreeCategoryInfo categoryInfo;

	private List<ResearchTreeNodeCtrl> nodeList;

	private UnityAction<MstResearchCategoryEntities> OnPointerOverAction;

	private UnityAction OnPointerExitAction;

	public CursorUIItem TopItem => null;

	public eResearchCategory GetCategoryId()
	{
		return default(eResearchCategory);
	}

	public void Init(ResearchDialog.ResearchTreeCategoryInfo categoryInfo, UnityAction<MstResearchTreeDataEntities> onClickItemAction = null, UnityAction<MstResearchCategoryEntities> onPointerOverCategoryAction = null, UnityAction<MstResearchTreeDataEntities> onPointerOverItemAction = null, UnityAction onPointerExitItemAction = null)
	{
	}

	private int CreateResearchTreeNode(Transform parent, List<ResearchDialog.ResearchTreeNodeInfo> children, UnityAction<MstResearchTreeDataEntities> onClickItemAction, UnityAction<MstResearchTreeDataEntities> onPointerOverItemAction, UnityAction onPointerExitItemAction, bool isFirst = false)
	{
		return 0;
	}

	public void UpdateItemUI(List<ResearchTreeDataUnit> playResearchTreeDatas)
	{
	}

	public void ShowContent(bool showContent)
	{
	}

	public void OnPointerOver()
	{
	}

	public void OnPointerExit()
	{
	}

	public void SetGuide(bool isOn)
	{
	}
}
