using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Powertrain.Tree
{
	public class PowertrainNodeConnection
	{
		public Transform ChildConnectionTransform { get; set; }

		public float MaxTotalGearRatio { get; set; } = 1f;

		public PowertrainNode Parent { get; }

		public Transform ParentConnectionTransform { get; }

		public PartConnection PartConnection { get; }

		public PowertrainNodeConnection(PowertrainNode parent, PartConnection partConnection, Transform parentConnectionTransform)
		{
			Parent = parent;
			ParentConnectionTransform = parentConnectionTransform;
			PartConnection = partConnection;
		}
	}
}
