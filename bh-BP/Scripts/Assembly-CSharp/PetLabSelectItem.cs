using UnityEngine;
using UnityEngine.UI;

public class PetLabSelectItem : MonoBehaviour
{
	public CoolButton Btn;

	public PetDisplayItem DispItem;

	public CoolButtonViz VizUnselected;

	public CoolButtonViz VizSelected;

	public Image ImgLvlWrapper;

	public Sprite SprFusionAvail;

	public Sprite SprFusionUnavail;

	private PetInst _tgtInst;

	public bool IsValid;

	public bool IsSelected;

	private void Awake()
	{
	}

	private void OnClicked()
	{
	}

	public PetInst GetInst()
	{
		return null;
	}

	private void OnHover()
	{
	}

	private void OnHoverExit()
	{
	}

	public void SetValid(bool v)
	{
	}

	public void SetSelected(bool s)
	{
	}
}
