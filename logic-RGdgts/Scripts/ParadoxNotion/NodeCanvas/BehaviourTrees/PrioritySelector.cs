using System;
using System.Collections.Generic;
using NodeCanvas.Framework;
using ParadoxNotion.Serialization.FullSerializer;
using UnityEngine;

namespace NodeCanvas.BehaviourTrees
{
	public class PrioritySelector : BTComposite, IMigratable<PrioritySelector_0>, IMigratable
	{
		[Serializable]
		public class Desire
		{
			[fsIgnoreInBuild]
			public string name;

			[fsIgnoreInBuild]
			public bool foldout;

			public List<Consideration> considerations;

			public Consideration AddConsideration(IBlackboard bb)
			{
				return null;
			}

			public void RemoveConsideration(Consideration consideration)
			{
			}

			public float GetCompoundUtility()
			{
				return 0f;
			}
		}

		[Serializable]
		public class Consideration
		{
			public BBParameter<float> input;

			public BBParameter<AnimationCurve> function;

			public float utility => 0f;

			public Consideration(IBlackboard blackboard)
			{
			}
		}

		[AutoSortWithChildrenConnections]
		public List<Desire> desires;

		private Connection[] orderedConnections;

		private int current;

		void IMigratable<PrioritySelector_0>.Migrate(PrioritySelector_0 model)
		{
		}

		public override void OnChildConnected(int index)
		{
		}

		public override void OnChildDisconnected(int index)
		{
		}

		protected override Status OnExecute(Component agent, IBlackboard blackboard)
		{
			return default(Status);
		}

		protected override void OnReset()
		{
		}
	}
}
