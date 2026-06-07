using UnityEngine;

public class TwoPointBlockModel
{
	public BlockBodyModel ParentBlockBodyModel { get; set; }

	public Vector3 EndPointPosition { get; set; }

	public Quaternion EndPointRotation { get; set; }
}
