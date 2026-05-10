using UnityEngine;
using UnityEngine.UI;

public class SelectableUI_tower_gemUI : GemUI
{
	[SerializeField]
	private Button removeGemButton;

	[SerializeField]
	private Button addGemButtonPressed;

	private SelectableUI_tower selectableUI_Tower;

	private int idx;

	public void Setup(SelectableUI_tower selectableUI, int idx)
	{
		selectableUI_Tower = selectableUI;
		this.idx = idx;
	}

	public override void SetGem(GemData gemData)
	{
		removeGemButton.gameObject.SetActive(gemData != null);
		addGemButtonPressed.gameObject.SetActive(gemData == null);
		base.SetGem(gemData);
	}

	public void OnAddButtonPressed()
	{
		selectableUI_Tower.ShowGemsContextWindow(idx);
	}

	public void OnRemoveGemButtonPressed()
	{
		SetGem(null);
		selectableUI_Tower.RemoveGem(idx);
	}
}
