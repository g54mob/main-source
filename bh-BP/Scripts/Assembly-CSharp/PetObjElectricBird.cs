using System.Collections.Generic;

public class PetObjElectricBird : PetObj
{
	private float _lastShootTime;

	private float _cooldownLength;

	private int _lightningLimit;

	private int _minDmg;

	private int _maxDmg;

	private float _circleRange;

	private float _curTheta;

	private List<GridPieceInst> _lightningEnemies;

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
}
