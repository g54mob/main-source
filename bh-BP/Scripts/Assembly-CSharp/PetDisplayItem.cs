using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PetDisplayItem : MonoBehaviour
{
	public Image ImgIcon;

	public TextMeshProUGUI TxtName;

	public Localize LocType;

	public Localize LocDesc;

	public LocalizationParamsManager ParamsDesc;

	public bool ShowPetNameInLvl;

	public LocalizationParamsManager ParamsLvl;

	public GameObject WrapperLvl;

	public TextMeshProUGUI TxtLvl;

	public Image ImgXP;

	public TextMeshProUGUI TxtXP;

	private PetInst _tgtPet;

	public CoolButton HoverBtn;

	private void Awake()
	{
	}

	public void Init(PetId pid)
	{
	}

	public void Init(PetInst p)
	{
	}

	public void SetXPVal(int xp)
	{
	}

	private void OnHover()
	{
	}

	private void OnHoverExit()
	{
	}
}
