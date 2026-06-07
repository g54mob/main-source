using MEC;
using UnityEngine;
using UnityEngine.UI;

public class PetObjTortoise : PetObj
{
	public GameObject WrapperHealthBar;

	public Image HealthBarFill;

	public TortoiseState CurState;

	private CoroutineHandle _blockAnim;

	private int _faceDir;

	private float _speed;

	private float _recoveryTime;

	private bool _reflectsArrows;

	private int _minArrowDmg;

	private int _maxArrowDmg;

	private bool _shootBabies;

	private int _minShootBabies;

	private int _maxShootBabies;

	private PetUpgradeInst _laserInst;

	private PetUpgradeInst _thornsInst;

	public override void Init(int idx, PetBattleInst p)
	{
	}

	public override void RefreshProperties()
	{
	}

	public override void Reset()
	{
	}

	public override void InitPlacement(int idx)
	{
	}

	public void SetFaceDir(int dir)
	{
	}

	public void SetState(TortoiseState st)
	{
	}

	public float GetMinX()
	{
		return 0f;
	}

	public float GetMaxX()
	{
		return 0f;
	}

	public float GetTgtY()
	{
		return 0f;
	}

	protected override void MyUpdate()
	{
	}

	public void Damage(int amt, PieceDmgType dmgType)
	{
	}

	public void RefreshHealthBar()
	{
	}
}
