using System;
using System.Collections.Generic;
using Polarith.AI.Criteria;
using Polarith.Utils;
using UnityEngine;

namespace Polarith.AI.Move
{
	[Serializable]
	public sealed class Context : Context<float, Structure>
	{
		[NonSerialized]
		public Vector3 DecidedDirection = Vector3.zero;

		[NonSerialized]
		public Vector3 DecidedReceptorPosition = Vector3.zero;

		[NonSerialized]
		public Matrix4x4 LocalToWorldMatrix = Matrix4x4.identity;

		[NonSerialized]
		public Matrix4x4 WorldToLocalMatrix = Matrix4x4.identity;

		[NonSerialized]
		public float DeltaTime;

		private readonly Problem problem = new Problem();

		private readonly Decision decision = new Decision();

		private int oldMinCount;

		private int oldNormCount;

		[Tooltip("Determines whether objectives are to be minimized or maximized.")]
		[SerializeField]
		private List<bool> minObjectives = new List<bool>();

		[Tooltip("Determines whether objectives are to be normalized.")]
		[SerializeField]
		private List<bool> normObjectives = new List<bool>();

		[Tooltip("The solver used during evaluation for making decisions.")]
		[SerializeField]
		private ConstraintSolver constraintSolver = new ConstraintSolver();

		public override IProblem<float> Problem => problem;

		public override IDecision<float, Structure> Decision => decision;

		public override void Evaluate()
		{
			Collections.ResizeList(minObjectives, problem.ObjectiveCount);
			for (int i = 0; i < minObjectives.Count; i++)
			{
				minObjectives[i] = problem.IsObjectiveMinimized(i);
			}
			oldNormCount = normObjectives.Count;
			Collections.ResizeList(normObjectives, problem.ObjectiveCount);
			if (oldNormCount < normObjectives.Count)
			{
				for (int j = normObjectives.Count - oldNormCount; j < normObjectives.Count; j++)
				{
					normObjectives[j] = true;
				}
			}
			base.Evaluate();
			DecidedReceptorPosition = LocalToWorldMatrix.MultiplyPoint3x4(decision.Structure.Position);
			DecidedDirection = LocalToWorldMatrix.MultiplyVector(decision.Structure.Direction);
		}

		public void BuildContext()
		{
			problem.ClearObjectives();
			for (int i = 0; i < minObjectives.Count; i++)
			{
				problem.AddObjective(minObjectives[i]);
			}
			if (minObjectives.Count != normObjectives.Count)
			{
				oldNormCount = normObjectives.Count;
				Collections.ResizeList(normObjectives, minObjectives.Count);
				if (oldNormCount < normObjectives.Count)
				{
					for (int j = normObjectives.Count - oldNormCount; j < normObjectives.Count; j++)
					{
						normObjectives[j] = true;
					}
				}
			}
			solver = constraintSolver;
			Collections.ResizeList(decision.Values, minObjectives.Count);
		}

		public float GetEpsilonConstraint(int index)
		{
			Collections.ResizeList(constraintSolver.Epsilons, problem.ObjectiveCount);
			return constraintSolver.Epsilons[index];
		}

		public bool IsObjectiveMinimized(int index)
		{
			oldMinCount = minObjectives.Count;
			Collections.ResizeList(minObjectives, problem.ObjectiveCount);
			if (oldMinCount < minObjectives.Count)
			{
				for (int i = minObjectives.Count - oldMinCount; i < minObjectives.Count; i++)
				{
					minObjectives[i] = true;
				}
			}
			return minObjectives[index];
		}

		public bool IsObjectiveNormalized(int index)
		{
			oldNormCount = normObjectives.Count;
			Collections.ResizeList(normObjectives, problem.ObjectiveCount);
			if (oldNormCount < normObjectives.Count)
			{
				for (int i = normObjectives.Count - oldNormCount; i < normObjectives.Count; i++)
				{
					normObjectives[i] = true;
				}
			}
			return normObjectives[index];
		}

		public bool IsObjectiveUnlimited(int index)
		{
			if (index < 0 || index >= problem.ObjectiveCount)
			{
				throw new ArgumentOutOfRangeException("No objective with the given index " + index);
			}
			return index == constraintSolver.Unlimited;
		}

		public void SetEpsilonConstraint(int index, float value)
		{
			Collections.ResizeList(constraintSolver.Epsilons, problem.ObjectiveCount);
			constraintSolver.Epsilons[index] = value;
		}

		public void SetObjectiveMinimized(int index, bool minimized)
		{
			oldMinCount = minObjectives.Count;
			Collections.ResizeList(minObjectives, problem.ObjectiveCount);
			if (oldMinCount < minObjectives.Count)
			{
				for (int i = minObjectives.Count - oldMinCount; i < minObjectives.Count; i++)
				{
					minObjectives[i] = true;
				}
			}
			minObjectives[index] = minimized;
			Problem.SetObjectiveMinimized(index, minimized);
		}

		public void SetObjectiveNormalized(int index, bool normalized)
		{
			oldNormCount = normObjectives.Count;
			Collections.ResizeList(normObjectives, problem.ObjectiveCount);
			if (oldNormCount < normObjectives.Count)
			{
				for (int i = normObjectives.Count - oldNormCount; i < normObjectives.Count; i++)
				{
					normObjectives[i] = true;
				}
			}
			normObjectives[index] = normalized;
		}

		public void SetObjectiveUnlimited(int index)
		{
			if (index < 0 || index >= problem.ObjectiveCount)
			{
				throw new ArgumentOutOfRangeException("No objective with the given index " + index);
			}
			constraintSolver.Unlimited = index;
		}

		public void ClearObjectives()
		{
			minObjectives.Clear();
			normObjectives.Clear();
			problem.ClearObjectives();
			constraintSolver.Epsilons.Clear();
		}

		public void ClearValues()
		{
			problem.ClearValues();
		}

		public void Reset()
		{
			DecidedDirection = Vector3.zero;
			DecidedReceptorPosition = Vector3.zero;
			LocalToWorldMatrix = Matrix4x4.identity;
			WorldToLocalMatrix = Matrix4x4.identity;
			DeltaTime = 0f;
			problem.ClearObjectives();
			decision.Values.Clear();
			decision.Index = 0;
			decision.Structure = new Structure();
			oldMinCount = 0;
			oldNormCount = 0;
			minObjectives.Clear();
			normObjectives.Clear();
			constraintSolver.Unlimited = 0;
			constraintSolver.Epsilons.Clear();
		}

		protected override void MakeDecision()
		{
			for (int i = 0; i < normObjectives.Count; i++)
			{
				if (normObjectives[i])
				{
					problem.NormalizeObjective(i);
				}
			}
			base.MakeDecision();
			Collections.ResizeListDefault(decision.Values, problem.ObjectiveCount);
			for (int j = 0; j < problem.ObjectiveCount; j++)
			{
				decision.Values[j] = problem[j][solutionIndices[0]];
			}
			decision.Index = solutionIndices[0];
			decision.Structure.Copy(sensor[solutionIndices[0]].Structure);
		}
	}
}
