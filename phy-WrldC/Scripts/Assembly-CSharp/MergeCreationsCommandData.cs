using UnityEngine;

public struct MergeCreationsCommandData
{
	public CreationModel BaseCreationModel { get; set; }

	public CreationModel ToMergeCreationModel { get; set; }

	public Transform BaseViewTransform { get; set; }

	public Transform ToMergeViewTransform { get; set; }

	public int SecondBlockId { get; set; }

	public int SecondBodyIndex { get; set; }

	public Vector3 TargetPosition { get; set; }

	public Vector3 AxisDirection { get; set; }
}
