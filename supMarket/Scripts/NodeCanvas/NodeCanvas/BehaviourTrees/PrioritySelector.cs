using System;
using System.Collections.Generic;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using ParadoxNotion.Serialization.FullSerializer;
using UnityEngine;

namespace NodeCanvas.BehaviourTrees
{
	[Category("Composites")]
	[Description("Used for Utility AI, the Priority Selector executes the child with the highest utility weight. If it fails, the Priority Selector will continue with the next highest utility weight child until one Succeeds, or until all Fail (similar to how a normal Selector does).\n\nEach child branch represents a desire, where each desire has one or more consideration which are all averaged.\nConsiderations are a pair of input value and curve, which together produce the consideration utility weight.\n\nIf Dynamic option is enabled, will continously evaluate utility weights and execute the child with the highest one regardless of what status the children return.")]
	[Icon("Priority", false, null)]
	[Color("b3ff7f")]
	[fsMigrateVersions(new Type[] { typeof(PrioritySelector_0) })]
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

		[Tooltip("If enabled, will continously evaluate utility weights and execute the child with the highest one accordingly. In this mode child return status does not matter.")]
		public bool dynamic;

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
