public class CouplingHoseRopeInstanceFree : CouplingHoseRopeInstance
{
	private CouplingHoseConnector connector;

	public override void OnAboutToTakeFromPool()
	{
		rope.solver = CouplingHoseSolverManager.Solver;
	}

	public override void OnTakenFromPool()
	{
		rig = base.transform.parent.GetComponent<CouplingHoseRig>();
		rope.ropeParams.receiveForcesFrom = rig.ropeAnchor;
		base.transform.localPosition = rig.ropeAnchor.localPosition;
		base.transform.localRotation = rig.ropeAnchor.localRotation;
		connector = GetComponentInChildren<CouplingHoseConnector>(includeInactive: true);
		connector.OnTakenFromPool(rig);
	}

	public override void OnAboutToReturnToPool()
	{
		connector.OnAboutToReturnToPool();
	}

	public override void OnReturnedToPool()
	{
		rope.solver = null;
		rig = null;
	}

	public override void SetLOD(CouplingHoseLODManager.LODLevel newLODLevel)
	{
		int solverIterations = ((newLODLevel == CouplingHoseLODManager.LODLevel.Visible_And_Full_Simulation) ? 100 : 5);
		rope.ropeParams.solverIterations = solverIterations;
	}
}
