using System;
using System.Runtime.CompilerServices;
using NodeCanvas.Framework;
using ParadoxNotion;
using UnityEngine;

namespace NodeCanvas.BehaviourTrees
{
	[GraphInfo(packageName = "NodeCanvas", docsURL = "https://nodecanvas.paradoxnotion.com/documentation/", resourcesURL = "https://nodecanvas.paradoxnotion.com/downloads/", forumsURL = "https://nodecanvas.paradoxnotion.com/forums-page/")]
	[CreateAssetMenu(menuName = "ParadoxNotion/NodeCanvas/Behaviour Tree Asset")]
	public class BehaviourTree : Graph
	{
		[Serializable]
		private class DerivedSerializationData
		{
			public bool repeat;

			public float updateInterval;
		}

		[NonSerialized]
		public bool repeat;

		[NonSerialized]
		public float updateInterval;

		private float intervalCounter;

		private Status _rootStatus;

		public Status rootStatus
		{
			get
			{
				return default(Status);
			}
			private set
			{
			}
		}

		public override Type baseNodeType => null;

		public override bool requiresAgent => false;

		public override bool requiresPrimeNode => false;

		public override bool isTree => false;

		public override bool allowBlackboardOverrides => false;

		public sealed override bool canAcceptVariableDrops => false;

		public override PlanarDirection flowDirection => default(PlanarDirection);

		public static event Action<BehaviourTree, Status> onRootStatusChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public override object OnDerivedDataSerialization()
		{
			return null;
		}

		public override void OnDerivedDataDeserialization(object data)
		{
		}

		protected override void OnGraphStarted()
		{
		}

		protected override void OnGraphUpdate()
		{
		}

		private Status Tick(Component agent, IBlackboard blackboard)
		{
			return default(Status);
		}
	}
}
