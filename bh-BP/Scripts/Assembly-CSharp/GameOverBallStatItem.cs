using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverBallStatItem : MonoBehaviour
{
	public RectTransform Xfm;

	public CoolButton Btn;

	public Image ImgChildConnector;

	public Image ImgIcon;

	public TextMeshProUGUI TxtLvl;

	public TextMeshProUGUI TxtLaunches;

	public TextMeshProUGUI TxtDamage;

	public TextMeshProUGUI TxtDamagePerSec;

	[NonSerialized]
	public HeroInst TgtHero;

	[NonSerialized]
	public PassiveInst TgtPassive;

	private void Awake()
	{
	}

	public void Init(HeroInst h, int childLvl)
	{
	}

	public void InitBaby()
	{
	}

	public void InitPassive(PassiveInst p)
	{
	}

	private void OnHover()
	{
	}

	private void OnHoverExit()
	{
	}
}
