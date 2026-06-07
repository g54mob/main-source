using UnityEngine;
using UnityEngine.UI;

public class CollectionView : MonoBehaviour
{
	[SerializeField]
	private CollectionCellsPanel _cellsPanel;

	[SerializeField]
	private CollectionDetailPanel _detailPanel;

	private bool _isAdoptEditProcessing;

	public CollectionCellsPanel CellsPanel => _cellsPanel;

	public CollectionDetailPanel DetailPanel => _detailPanel;

	private void Update()
	{
		if (!_isAdoptEditProcessing && Input.GetKeyDown(KeyCode.Escape))
		{
			OnClickExitButton();
		}
	}

	public void Show()
	{
		_cellsPanel.OnSelectCollectionCell += ShowDetailPanel;
		_cellsPanel.GetComponent<ScrollRect>().verticalNormalizedPosition = 1f;
		_cellsPanel.Show();
		MonoSingleton<SoundManager>.Instance.PlaySFX(SFXType.SFX_PaperShow);
		base.gameObject.SetActive(value: true);
	}

	public void Hide()
	{
		_cellsPanel.OnSelectCollectionCell -= ShowDetailPanel;
		_cellsPanel.Hide();
		_detailPanel.Hide();
		base.gameObject.SetActive(value: false);
	}

	private void ShowDetailPanel(CollectionCell collectionCell)
	{
		_detailPanel.Show(collectionCell.Animal);
	}

	public void OnClickExitButton()
	{
		Hide();
		MonoSingleton<SoundManager>.Instance.PlaySFX(SFXType.SFX_BTNCommon_Down);
	}

	public void SetIsAdoptEditProcessing_Start(Animal animal)
	{
		_isAdoptEditProcessing = true;
	}

	public void SetIsAdoptEditProcessing_End(Animal animal)
	{
		_isAdoptEditProcessing = false;
	}
}
