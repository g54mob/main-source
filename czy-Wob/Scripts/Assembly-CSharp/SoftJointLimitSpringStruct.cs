using System;
using UnityEngine;

[Serializable]
public struct SoftJointLimitSpringStruct
{
	public float spring;

	public float damper;

	public SoftJointLimitSpringStruct(SoftJointLimitSpring springRef)
	{
		spring = springRef.spring;
		damper = springRef.damper;
	}

	public SoftJointLimitSpring CreateSpring()
	{
		return new SoftJointLimitSpring
		{
			spring = spring,
			damper = damper
		};
	}
}
