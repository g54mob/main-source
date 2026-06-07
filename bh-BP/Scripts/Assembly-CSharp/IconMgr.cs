using UnityEngine;

public class IconMgr : MonoBehaviour
{
	public static IconMgr I;

	[Header("Ball")]
	public Sprite SprBallPortrait;

	[Header("Char")]
	public Sprite SprCharPortrait;

	[Header("Misc")]
	public Sprite SprCheckmark;

	public Sprite SprX;

	public Sprite SprStatConnector;

	public Sprite SprLock;

	public Sprite[] SprDamageNumbers;

	public float[] DamageNumberWidth;

	public Sprite SprExclamation;

	public Sprite SprDot;

	public Sprite SprPlus;

	public Sprite SprAmmoBaby;

	public Sprite SprAmmoNormal;

	[Header("Status")]
	public Sprite SprMiningStone;

	public Sprite SprMiningGold;

	public Sprite SprFarming;

	public Sprite SprLumbering;

	[Header("UI")]
	public Sprite SprInnerPanel;

	public Sprite SprInnerPanelHighlighted;

	public Sprite SprInnerPanelSmall;

	[NamedArray(typeof(ResourceType))]
	public Sprite[] ResourceIcons;

	[NamedArray(typeof(ResourceType))]
	public Sprite[] BigResourceIcons;

	public Sprite IconQuestion;

	public Sprite IconBlueprint;

	public Sprite IconGear;

	public Sprite IconGearShadow;

	public Sprite SprChildConnectorBot;

	public Sprite SprChildConnectorMid;

	public Sprite IconBabyBall;

	[Header("Stat")]
	[NamedArray(typeof(StatType))]
	public Sprite[] StatIcons;

	[Header("Building")]
	public Sprite SprLevelUpAvailable;

	public Sprite SprEmptyWorkstation;

	[Header("Button")]
	public CoolButtonViz BtnVizNormal;

	public CoolButtonViz BtnVizNormalDisabled;

	[Header("Shadows")]
	public Sprite SprShadowSmall;

	public Sprite SprShadow1x1;

	public Sprite SprShadow2x1;

	public Sprite SprShadow1x2;

	public Sprite SprShadowTriple;

	public Sprite SprShadowTetris;

	[Header("Temp")]
	public Sprite SprEggPortraitDefault;

	private void Awake()
	{
	}

	public string GetStatIconTag(StatType st)
	{
		return null;
	}

	private void OnValidate()
	{
	}
}
