using UnityEngine;
using UnityEngine.UI;

public class HatcheryItem : MonoBehaviour
{
	public CoolButton Btn;

	public int Idx;

	public PetDisplayItem DispItem;

	public Image ImgNotif;

	private PetInst _tgtPet;

	private void Awake()
	{
	}

	public void Init(int idx, PetId id)
	{
	}

	private void OnClicked()
	{
	}

	public bool IsEmpty()
	{
		return false;
	}

	public PetInst GetPet()
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
