using System.Collections.Generic;

public class PetObjRat : PetObj
{
	private static readonly PickupType[] kTgtPickupTypes;

	private PickupObj _aiTgtPickup;

	private float _poopCooldown;

	private List<float> _lastPickupTime;

	private List<PickupInst> _lastPickupInst;

	private float _moveSpeed;

	private bool _allowMultiple;

	private int _minGems;

	private int _maxGems;

	private float _healAmt;

	private int _minDamage;

	private int _maxDamage;

	private PetUpgradeInst _painStepInst;

	private List<GridPieceObj> _touchingEnemies;

	private List<GridPieceObj> _touchedEnemiesThisFrame;

	public override void Init(int idx, PetBattleInst p)
	{
	}

	public override void RefreshProperties()
	{
	}

	private void PickTgtPickup()
	{
	}

	protected override void MyUpdate()
	{
	}
}
