using I2.Loc;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardEquipmentItem : MonoBehaviour
{
	public CoolButton Btn;

	public Image Img;

	private PassiveType _tgtPassive;

	private HeroType _tgtHero;

	private HeroInst _tgtCombo;

	private void Awake()
	{
	}

	private void OnValidate()
	{
	}

	public void InitPassive(PassiveType p)
	{
	}

	public void InitCombo(HeroInst h)
	{
	}

	public void InitHero(HeroType h)
	{
	}

	public void ApplyHoverLoc(Localize loc, LocalizationParamsManager prms)
	{
	}

	private void OnHover()
	{
	}

	private void OnHoverExit()
	{
	}
}
