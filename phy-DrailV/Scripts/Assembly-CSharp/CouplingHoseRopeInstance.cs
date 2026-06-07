using System;
using UnityEngine;
using VerletRope;

public abstract class CouplingHoseRopeInstance : MonoBehaviour, CouplingHosePool.IPoolItemComponent
{
	protected const int SIMULATION_FULL = 100;

	protected const int SIMULATION_REDUCED = 5;

	[SerializeField]
	protected RopeBehaviour rope;

	[NonSerialized]
	public CouplingHoseRig rig;

	public abstract void OnAboutToTakeFromPool();

	public abstract void OnTakenFromPool();

	public abstract void OnAboutToReturnToPool();

	public abstract void OnReturnedToPool();

	public abstract void SetLOD(CouplingHoseLODManager.LODLevel newLODLevel);

	public RopeBehaviour GetRopeBehaviour()
	{
		return rope;
	}
}
