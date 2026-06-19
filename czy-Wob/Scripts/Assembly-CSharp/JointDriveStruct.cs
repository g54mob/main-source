using System;
using UnityEngine;

[Serializable]
public struct JointDriveStruct
{
	public float spring;

	public float damper;

	public float maxForce;

	public JointDriveStruct(JointDrive driveRef)
	{
		spring = driveRef.positionSpring;
		damper = driveRef.positionDamper;
		maxForce = driveRef.maximumForce;
	}

	public JointDrive CreateDrive()
	{
		return new JointDrive
		{
			positionSpring = spring,
			positionDamper = damper,
			maximumForce = maxForce
		};
	}
}
