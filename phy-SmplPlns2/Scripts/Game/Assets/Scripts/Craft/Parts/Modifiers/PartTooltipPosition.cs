using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public struct PartTooltipPosition
	{
		public float OffsetDistance { get; }

		public MeshRenderer TargetRenderer { get; }

		public Transform TargetTransform { get; }

		public PartTooltipPosition(Transform transform, float offsetDistance = 0.02f)
		{
			TargetRenderer = null;
			TargetTransform = transform;
			OffsetDistance = offsetDistance;
		}

		public PartTooltipPosition(MeshRenderer renderer, float offsetDistance = 0.02f)
		{
			TargetRenderer = renderer;
			TargetTransform = null;
			OffsetDistance = offsetDistance;
		}
	}
}
