using FIMSpace.FGenerating;
using UnityEngine;

namespace FIMSpace.FProceduralAnimation
{
	public class RAF_LevelsOfDetail : RagdollAnimatorFeatureBase
	{
		private int initialSolverIterations = 6;

		private FUniversalVariable[] dists = new FUniversalVariable[3];

		private FUniversalVariable[] disableHM = new FUniversalVariable[3];

		private FUniversalVariable[] solverIterations = new FUniversalVariable[3];

		private FUniversalVariable[] disableInterpolation = new FUniversalVariable[3];

		private FUniversalVariable[] onlyDiscrete = new FUniversalVariable[3];

		private int currentIndex = -1;

		public override bool OnInit()
		{
			base.ParentRagdollHandler.AddToUpdateLoop(Update);
			initialSolverIterations = base.ParentRagdollHandler.UnitySolverIterations;
			for (int i = 0; i < 3; i++)
			{
				int num = i + 1;
				dists[i] = base.InitializedWith.RequestVariable("Dist" + num, (float)num * 10f);
				disableHM[i] = base.InitializedWith.RequestVariable("Hard" + num, false);
				solverIterations[i] = base.InitializedWith.RequestVariable("Iter" + num, 1f + Mathf.Lerp(base.ParentRagdollHandler.UnitySolverIterations, 1f, (float)num / 3f));
				disableInterpolation[i] = base.InitializedWith.RequestVariable("Interp" + num, false);
				onlyDiscrete[i] = base.InitializedWith.RequestVariable("Discr" + num, false);
			}
			return base.OnInit();
		}

		public override void OnDestroyFeature()
		{
			base.ParentRagdollHandler.RemoveFromUpdateLoop(Update);
		}

		public virtual void Update()
		{
			float num = CalculateDistance();
			if (num > dists[2].GetFloat())
			{
				ApplyLOD(2);
			}
			else if (num > dists[1].GetFloat())
			{
				ApplyLOD(1);
			}
			else if (num > dists[0].GetFloat())
			{
				ApplyLOD(0);
			}
			else
			{
				ApplyLOD(-1);
			}
		}

		private void ApplyLOD(int index)
		{
			if (currentIndex != index)
			{
				currentIndex = index;
				if (index == -1)
				{
					base.ParentRagdollHandler.UnitySolverIterations = initialSolverIterations;
					base.ParentRagdollHandler.disableHardMatching = false;
					base.ParentRagdollHandler.disableInterpolation = false;
					base.ParentRagdollHandler.onlyDiscreteDetection = false;
					base.ParentRagdollHandler.RefreshAllChainsRigidbodyOptimizationParameters();
				}
				else
				{
					base.ParentRagdollHandler.UnitySolverIterations = solverIterations[index].GetInt();
					base.ParentRagdollHandler.disableHardMatching = disableHM[index].GetBool();
					base.ParentRagdollHandler.disableInterpolation = disableInterpolation[index].GetBool();
					base.ParentRagdollHandler.onlyDiscreteDetection = onlyDiscrete[index].GetBool();
					base.ParentRagdollHandler.RefreshAllChainsRigidbodyOptimizationParameters();
				}
			}
		}

		protected virtual float CalculateDistance()
		{
			Camera main = Camera.main;
			if (main == null)
			{
				return 0f;
			}
			return Vector3.Distance(base.ParentRagdollHandler.GetAnchorSourceBone().position, main.transform.position);
		}
	}
}
