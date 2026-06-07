using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpCurEquipItem : MonoBehaviour
{
	public Image ImgBacking;

	public CoolButton BtnHoverArea;

	public RectTransform Xfm;

	public Image ImgIcon;

	public TextMeshProUGUI TxtLvl;

	public PixelRectSizer IconSizer;

	public int TgtEquipmentIdx;

	public int DisplayedLvl;

	public HeroType TgtHero;

	public HeroType TgtHeroCombo;

	public PassiveType TgtPassive;

	public PetUpgradeType TgtPetUpgrade;

	public UpgradeInfo TgtInfo;

	private void Awake()
	{
	}

	private void InitInternal(float size)
	{
	}

	public void Init(int idx, HeroInst h)
	{
	}

	public void Init(HeroInfo h)
	{
	}

	public void Init(int idx, PassiveInst p)
	{
	}

	public void Init(PassiveInfo p)
	{
	}

	public void Init(PetUpgradeInst petUpg)
	{
	}

	public void Init(PetUpgradeInfo petUpg)
	{
	}

	public void SetLvlUpgraded(int lvl)
	{
	}

	public void InitEmpty()
	{
	}

	private void OnHover()
	{
	}

	private void OnHoverExit()
	{
	}
}
