using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Polarith.AI.Criteria;
using Polarith.Utils;
using UnityEngine;

namespace Polarith.AI.Move
{
	[Serializable]
	public class PlanarInterpolation : MoveBehaviour
	{
		private delegate float MinMax(float a, float b);

		private delegate bool Compare(float a, float b);

		[Tooltip("To find a better solution, this behaviour will solve a linear equation based on the values of the targeted objective. This parameter determines which objective is used for this calculation.")]
		[TargetObjective(false)]
		public int TargetObjective;

		[Tooltip("It is possible that a better solution with respect to the 'TargetObjective' violates a constraint of another objective.\n\nIf 'true', this behaviour rejects solutions which violate the constraints of other objectives. If 'false', the constraints are ignored.")]
		public bool Constraint = true;

		private List<float> eps;

		private IDecision<float, Structure> decision;

		private ISensor<Structure> sensor;

		private IReceptor<Structure> receptor;

		private IProblem<float> problem;

		private int unconstrained;

		private int neighbourID;

		private int l1;

		private int l2;

		private int r1;

		private int r2;

		private int i;

		private float deltaL;

		private float deltaR;

		private float p1;

		private float p2;

		private float result1;

		private float result2;

		private bool hitConstraint;

		private MinMax minmax;

		private Compare compare1;

		private Compare compare2;

		private MinMax min = Mathf.Min;

		private MinMax max = Mathf.Max;

		private Compare less;

		private Compare greater;

		public PlanarInterpolation()
		{
			less = Less;
			greater = Greater;
		}

		public override void Behave()
		{
			sensor = Context.Sensor;
			problem = Context.Problem;
			decision = Context.Decision;
			if (TargetObjective < 0 || TargetObjective >= problem.ObjectiveCount)
			{
				return;
			}
			if (decision.Index < 0 || decision.Index >= sensor.ReceptorCount)
			{
				throw new IndexOutOfRangeException("The decision index does not match the receptor range");
			}
			receptor = sensor[decision.Index];
			l1 = receptor.NeighbourIDs[0];
			r1 = receptor.NeighbourIDs[1];
			if (l1 < 0)
			{
				decision.Index = decision.Index;
				return;
			}
			if (r1 < 0)
			{
				decision.Index = decision.Index;
				return;
			}
			l2 = sensor[l1].NeighbourIDs[0];
			r2 = sensor[r1].NeighbourIDs[1];
			if (l2 < 0)
			{
				l2 = l1;
			}
			if (r2 < 0)
			{
				r2 = r1;
			}
			result1 = InterpolateLinear(problem.GetObjective(TargetObjective), l2, l1, decision.Index, r1, out p1);
			result2 = InterpolateLinear(problem.GetObjective(TargetObjective), l1, decision.Index, r1, r2, out p2);
			if (problem.IsObjectiveMinimized(TargetObjective))
			{
				minmax = min;
				compare1 = greater;
				compare2 = less;
			}
			else
			{
				minmax = max;
				compare1 = less;
				compare2 = greater;
			}
			if ((result1 < 1E-06f && result2 < 1E-06f) || compare1(minmax(result1, result2), problem.GetObjective(TargetObjective)[decision.Index] + 1E-06f))
			{
				return;
			}
			if (compare2(result1, result2))
			{
				neighbourID = sensor[decision.Index].NeighbourIDs[0];
				for (i = 0; i < decision.Values.Count; i++)
				{
					decision.Values[i] = Mathf.Lerp(problem[i][neighbourID], problem[i][decision.Index], p1);
				}
				Structure.Lerp(sensor[neighbourID].Structure, sensor[decision.Index].Structure, p1, decision.Structure);
			}
			else
			{
				neighbourID = sensor[decision.Index].NeighbourIDs[1];
				for (i = 0; i < decision.Values.Count; i++)
				{
					decision.Values[i] = Mathf.Lerp(problem[i][decision.Index], problem[i][neighbourID], p2);
				}
				Structure.Lerp(sensor[decision.Index].Structure, sensor[neighbourID].Structure, p2, decision.Structure);
			}
			if (!Constraint)
			{
				return;
			}
			ConstraintSolver<float> constraintSolver = (ConstraintSolver<float>)Context.Solver;
			if (constraintSolver == null)
			{
				return;
			}
			eps = constraintSolver.Epsilons;
			unconstrained = constraintSolver.Unlimited;
			hitConstraint = false;
			for (i = 0; i < decision.Values.Count; i++)
			{
				if (i != unconstrained && i != TargetObjective && (problem.IsObjectiveMinimized(i) ? (decision.Values[i] > eps[i]) : (decision.Values[i] < eps[i])))
				{
					hitConstraint = true;
				}
			}
			if (hitConstraint)
			{
				for (i = 0; i < decision.Values.Count; i++)
				{
					decision.Values[i] = problem.GetObjective(i)[decision.Index];
				}
				decision.Structure.Copy(sensor[decision.Index].Structure);
			}
		}

		private float InterpolateLinear(ReadOnlyCollection<float> values, int i0, int i1, int i2, int i3, out float p)
		{
			p = -1f;
			deltaL = values[i1] - values[i0];
			deltaR = values[i3] - values[i2];
			if (Mathf2.Approximately(deltaL, deltaR))
			{
				return -1f;
			}
			p = (values[i2] - deltaR - values[i1]) / (deltaL - deltaR);
			if (p >= 1E-06f && p <= 0.999999f)
			{
				return deltaR * p + values[i2] - deltaR;
			}
			return -1f;
		}

		private bool Less(float a, float b)
		{
			return a < b;
		}

		private bool Greater(float a, float b)
		{
			return a > b;
		}
	}
}
