using System;
using MalbersAnimations.Controller.AI;
using UnityEngine;

namespace MalbersAnimations.Conditions
{
	[Serializable]
	[AddComponentMenu("Malbers/Animal Controller/Conditions/Animal AI")]
	public class C_AnimalAI : MCondition
	{
		public enum AnimalAICondition
		{
			enabled = 0,
			HasTarget = 1,
			HasNextTarget = 2,
			Arrived = 3,
			Waiting = 4,
			InOffMesh = 5,
			CurrentTarget = 6,
			NextTarget = 7
		}

		[RequiredField]
		public MAnimalAIControl AI;

		public AnimalAICondition Condition;

		[Hide("Condition", new int[] { 6, 7 })]
		public Transform Target;

		[HideInInspector]
		[SerializeField]
		private bool showTarg;

		public override string DisplayName => "Animal/Animal AI";

		public override bool _Evaluate()
		{
			if ((bool)AI)
			{
				switch (Condition)
				{
				case AnimalAICondition.enabled:
					return AI.enabled;
				case AnimalAICondition.HasTarget:
					return AI.Target != null;
				case AnimalAICondition.HasNextTarget:
					return AI.NextTarget != null;
				case AnimalAICondition.Arrived:
					return AI.HasArrived;
				case AnimalAICondition.InOffMesh:
					return AI.InOffMeshLink;
				case AnimalAICondition.CurrentTarget:
					return AI.Target == Target;
				case AnimalAICondition.Waiting:
					return AI.IsWaiting;
				case AnimalAICondition.NextTarget:
					return AI.NextTarget == Target;
				}
			}
			return false;
		}

		protected override void _SetTarget(UnityEngine.Object target)
		{
			VerifyTarget(target, ref AI);
		}

		private void Reset()
		{
			Name = "New Animal AI Condition";
		}

		protected override void OnValidate()
		{
			base.OnValidate();
			showTarg = Condition == AnimalAICondition.CurrentTarget || Condition == AnimalAICondition.NextTarget;
		}
	}
}
