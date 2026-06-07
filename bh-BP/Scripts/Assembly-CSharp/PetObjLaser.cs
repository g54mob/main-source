public class PetObjLaser : PetObj
{
	private float _lastShootTime;

	private float _cooldownLength;

	private float _speed;

	private GridPieceInst _tgt;

	private PetUpgradeInst _extraLaser;

	private PetUpgradeInst _crossLaser;

	private PetUpgradeInst _babyUpg;

	public override void Init(int idx, PetBattleInst p)
	{
	}

	public override void RefreshProperties()
	{
	}

	public override void InitPlacement(int idx)
	{
	}

	private void PickTarget()
	{
	}

	private bool IsOnLeft()
	{
		return false;
	}

	protected override void MyUpdate()
	{
	}

	public override void OnGridExpanded()
	{
	}
}
