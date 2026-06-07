using System.Collections.Generic;
using UnityEngine;

public class CorruptKingGround : MonoBehaviour
{
	[SerializeField]
	private Hp hp;

	[SerializeField]
	private PathfindMovementEnemy pathfindMovement;

	[SerializeField]
	private List<TargetPriority> attackIfOwnHealthHigherThanCastleCenter;

	[SerializeField]
	private List<TargetPriority> attackIfOwnHealthLowerThanCastleCenter;

	[SerializeField]
	private UnitDashJumpEnemy dashJump;

	[SerializeField]
	private List<TargetPriority> jumpIfOwnHealthHigherThanCastleCenter;

	[SerializeField]
	private List<TargetPriority> jumpIfOwnHealthLowerThanCastleCenter;

	private Hp castleCenterHp;

	private void Start()
	{
		castleCenterHp = CastleCenter.instance.GetComponent<Hp>();
	}

	private void Update()
	{
		if ((double)castleCenterHp.HpPercentage < (double)hp.HpPercentage + 0.15)
		{
			pathfindMovement.targetPriorities = attackIfOwnHealthHigherThanCastleCenter;
			dashJump.targetPriorities = jumpIfOwnHealthHigherThanCastleCenter;
		}
		else if ((double)castleCenterHp.HpPercentage > (double)hp.HpPercentage + 0.15)
		{
			pathfindMovement.targetPriorities = attackIfOwnHealthLowerThanCastleCenter;
			dashJump.targetPriorities = jumpIfOwnHealthLowerThanCastleCenter;
		}
	}
}
