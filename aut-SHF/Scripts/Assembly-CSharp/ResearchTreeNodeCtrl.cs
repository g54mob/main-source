using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ResearchTreeNodeCtrl : MonoBehaviour
{
	[SerializeField]
	protected Image itemIcon;

	[SerializeField]
	protected Image completedPanel;

	[SerializeField]
	protected Image canUnlockPanel;

	[SerializeField]
	protected Image lockPanel;

	[SerializeField]
	protected Image lockIcon;

	[SerializeField]
	protected TMP_Text price;

	[SerializeField]
	protected Image completed;

	[SerializeField]
	protected Image bottomLine;

	[SerializeField]
	protected Image branchLine;

	[SerializeField]
	protected Button button;

	[SerializeField]
	protected Image selectedCursor;

	[SerializeField]
	protected GameObject padGuide;

	[SerializeField]
	protected Color lockIconColor;

	[SerializeField]
	protected List<Color> pointColor;

	protected ResearchDialog.ResearchTreeNodeInfo nodeInfo;

	public event UnityAction<MstResearchTreeDataEntities> OnClickAction
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public event UnityAction<MstResearchTreeDataEntities> OnPointerOverAction
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public event UnityAction OnPointerExitAction
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public eResearchTreeId GetResearchTreeId()
	{
		return default(eResearchTreeId);
	}

	public eResearchTreeId GetReplaceResearchTreeId()
	{
		return default(eResearchTreeId);
	}

	public void Init(ResearchDialog.ResearchTreeNodeInfo info, float branchWidth, UnityAction<MstResearchTreeDataEntities> onClickItemAction, UnityAction<MstResearchTreeDataEntities> onPointerOverItemAction, UnityAction onPointerExitItemAction)
	{
	}

	protected virtual string GetPriceText()
	{
		return null;
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void ResetUI()
	{
	}

	public virtual void UpdateUI(ResearchTreeDataUnit data)
	{
	}

	protected virtual bool isOkPurchase(ResearchTreeDataUnit data)
	{
		return false;
	}

	protected virtual void SwitchStandardUI(ResearchTreeDataUnit data)
	{
	}

	public void ResetEvent()
	{
	}

	public void OnClick()
	{
	}

	public void OnPointerOver()
	{
	}

	public void OnPointerExit()
	{
	}

	protected virtual (MstResearchTreeDataEntities, ResearchTreeDataUnit) GetActiveResearchData()
	{
		return default((MstResearchTreeDataEntities, ResearchTreeDataUnit));
	}
}
