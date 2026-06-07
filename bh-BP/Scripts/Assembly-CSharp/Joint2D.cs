using System.Collections.Generic;
using UnityEngine;

public class Joint2D
{
	public enum Type
	{
		DistanceJoint2D = 0,
		FixedJoint2D = 1,
		FrictionJoint2D = 2,
		HingeJoint2D = 3,
		RelativeJoint2D = 4,
		SliderJoint2D = 5,
		SpringJoint2D = 6,
		TargetJoint2D = 7,
		WheelJoint2D = 8
	}

	public Type jointType;

	public GameObject gameObject;

	public DistanceJoint2D distanceJoint2D;

	public FixedJoint2D fixedJoint2D;

	public FrictionJoint2D frictionJoint2D;

	public HingeJoint2D hingeJoint2D;

	public RelativeJoint2D relativeJoint2D;

	public SliderJoint2D sliderJoint2D;

	public SpringJoint2D springJoint2D;

	public TargetJoint2D targetJoint2D;

	public WheelJoint2D wheelJoint2D;

	public AnchoredJoint2D anchoredJoint2D;

	public Joint2D(Type type)
	{
	}

	public static List<Joint2D> GetJoints(GameObject gameObject)
	{
		return null;
	}

	public static List<Joint2D> GetJointsConnected(Rigidbody2D connected)
	{
		return null;
	}

	public static List<Joint2D> GetJointsConnected()
	{
		return null;
	}
}
