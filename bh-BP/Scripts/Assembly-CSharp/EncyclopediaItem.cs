using UnityEngine;
using UnityEngine.UI;

public class EncyclopediaItem : MonoBehaviour
{
	public CoolButton Btn;

	public Image ImgIcon;

	public UpgradeInfo TgtInf;

	public LevelInfo LvlInf;

	public GridPieceInfo PieceInf;

	public bool IsLocked;

	private bool _isSelected;

	private void Awake()
	{
	}

	public void Init(UpgradeInfo inf)
	{
	}

	public void Init(LevelInfo lInf, GridPieceInfo eInf)
	{
	}

	private void OnHover()
	{
	}

	private void OnHoverExit()
	{
	}

	private void OnClicked()
	{
	}

	public void SetSelected(bool isSelected)
	{
	}
}
