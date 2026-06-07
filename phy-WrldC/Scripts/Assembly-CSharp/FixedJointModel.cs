using UnityEngine;

public class FixedJointModel
{
	public BlockBodyModel ParentBlockBodyModel { get; set; }

	public int Index { get; set; }

	public BlockBodyModel ConnectedBlockBodyModel { get; set; }

	public bool IsFullJoint { get; set; }

	public Vector3 Position { get; set; }

	public Vector3 AxisDirection { get; set; }

	public FixedJointModel()
	{
		IsFullJoint = false;
		Position = Vector3.zero;
		AxisDirection = Vector3.zero;
	}
}
