using System.Collections.Generic;
using UnityEngine;

namespace com.ootii.Actors.BoneControllers
{
	public class FABRIKSolver : IKSolver
	{
		private static List<Vector3> lBonePositions;

		private static List<Quaternion> lBoneRotations;

		public static void SolveIK(ref IKSolverState rState)
		{
		}
	}
}
