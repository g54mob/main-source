using UnityEngine;

public class CouplingHoseRopeInstanceConnected : CouplingHoseRopeInstance
{
	private const int LAST_PIN_INDEX = 3;

	private Transform connectedToRopeAnchor;

	public override void OnAboutToTakeFromPool()
	{
		rope.solver = CouplingHoseSolverManager.Solver;
		GetComponent<CouplingHoseDisconnectButton>().OnAboutToTakeFromPool();
	}

	public override void OnTakenFromPool()
	{
		rig = base.transform.parent.GetComponent<CouplingHoseRig>();
		connectedToRopeAnchor = rig.ConnectionManager.ConnectedTo.ropeAnchor;
		rope.ropeParams.receiveForcesFrom = connectedToRopeAnchor;
		base.transform.localPosition = rig.ropeAnchor.localPosition;
		base.transform.localRotation = rig.ropeAnchor.localRotation;
		Update();
	}

	public override void OnAboutToReturnToPool()
	{
	}

	public override void OnReturnedToPool()
	{
		GetComponent<CouplingHoseDisconnectButton>().OnReturnedToPool();
		rope.solver = null;
		rig = null;
		connectedToRopeAnchor = null;
	}

	public override void SetLOD(CouplingHoseLODManager.LODLevel newLODLevel)
	{
		int solverIterations = ((newLODLevel == CouplingHoseLODManager.LODLevel.Visible_And_Full_Simulation) ? 100 : 5);
		rope.ropeParams.solverIterations = solverIterations;
	}

	private void Update()
	{
		rope.pins[3].pinnedToTransform.SetPositionAndRotation(connectedToRopeAnchor.position, connectedToRopeAnchor.rotation);
	}
}
