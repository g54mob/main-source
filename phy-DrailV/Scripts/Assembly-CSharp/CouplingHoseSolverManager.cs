using UnityEngine;
using VerletRope;

public class CouplingHoseSolverManager : MonoBehaviour
{
	private const string SOLVER_PREFAB_NAME = "[coupling_hose_solver]";

	private static VerletSolver _commonSolver;

	public static VerletSolver Solver
	{
		get
		{
			if (_commonSolver == null)
			{
				_commonSolver = Object.Instantiate(Resources.Load("[coupling_hose_solver]") as GameObject, WorldMover.OriginShiftParent, worldPositionStays: true).GetComponent<VerletSolver>();
			}
			return _commonSolver;
		}
	}
}
