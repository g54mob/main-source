using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EggListItem : MonoBehaviour
{
	public CoolButton Btn;

	public PetDisplayItem DispItem;

	public Image ImgNew;

	public TextMeshProUGUI TxtCost;

	private PetInst _tgtInst;

	private void Awake()
	{
	}

	public void Init(PetInst p)
	{
	}

	public void InitEmpty()
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
}
