using MEC;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUDUpgradeItem : MonoBehaviour
{
	public CanvasGroup CvsGrp;

	public CoolButton Btn;

	public Image ImgBacking;

	public RectTransform Xfm;

	public Image ImgIcon;

	public TextMeshProUGUI TxtLvl;

	public int Idx;

	public bool IsHero;

	public Image ImgReadyMeter;

	public Sprite SprBackingNormal;

	public Sprite SprBackingCurBall;

	private CoroutineHandle _updateAnim;

	private void Awake()
	{
	}

	private float GetDefaultSize()
	{
		return 0f;
	}

	private void SetCanUpgrade(bool canUpgrade)
	{
	}

	private void InitInternal()
	{
	}

	public void Init(int idx, HeroInst h)
	{
	}

	private void MyUpdate()
	{
	}

	public void Init(int idx, PassiveInst p)
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

	public void RefreshBallState()
	{
	}
}
