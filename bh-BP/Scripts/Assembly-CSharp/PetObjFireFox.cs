using System.Collections.Generic;

public class PetObjFireFox : PetObj
{
	private PetUpgradeInst _areaInst;

	private PetUpgradeInst _laserInst;

	private PetUpgradeInst _speedInst;

	private int _minDamage;

	private int _maxDamage;

	private float _speed;

	private int _faceDir;

	public List<BallObj> TouchingBalls;

	public List<BallObj> TouchedBallsThisFrame;

	public override void Init(int idx, PetBattleInst p)
	{
	}

	public override void RefreshProperties()
	{
	}

	public override void InitPlacement(int idx)
	{
	}

	protected override void MyUpdate()
	{
	}

	private void SetFaceDir(int dir)
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
}
