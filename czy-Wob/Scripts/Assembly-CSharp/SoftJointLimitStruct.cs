using System;
using UnityEngine;

[Serializable]
public struct SoftJointLimitStruct
{
	public float limit;

	public float bounciness;

	public float contactDistance;

	public SoftJointLimitStruct(SoftJointLimit springRef)
	{
		limit = springRef.limit;
		bounciness = springRef.bounciness;
		contactDistance = springRef.contactDistance;
	}

	public SoftJointLimit CreateLimit()
	{
		return new SoftJointLimit
		{
			limit = limit,
			bounciness = bounciness,
			contactDistance = contactDistance
		};
	}
}
