using UnityEngine;

public struct AddTwoPointCommandData
{
	public CreationModel BaseCreationModel { get; set; }

	public Transform BaseViewTransform { get; set; }

	public Vector3 EndPointPosition { get; set; }

	public Quaternion EndPointRotation { get; set; }

	public int SecondBlockId { get; set; }

	public int SecondBodyIndex { get; set; }

	public bool IsHingeJoint { get; set; }

	public Vector3 TargetPosition { get; set; }

	public Vector3 AxisDirection { get; set; }
}
