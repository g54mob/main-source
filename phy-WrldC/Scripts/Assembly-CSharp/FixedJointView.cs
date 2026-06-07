using UnityEngine;

public class FixedJointView
{
	public BlockBodyView ParentBlockBodyView { get; set; }

	public int Index { get; set; }

	public FixedJoint FixedJoint { get; set; }

	public BlockBodyView ConnectedBlockBodyView { get; set; }
}
