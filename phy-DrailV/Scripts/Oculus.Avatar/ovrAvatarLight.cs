using UnityEngine;

public struct ovrAvatarLight
{
	public uint id;

	public ovrAvatarLightType type;

	public float intensity;

	public Vector3 worldDirection;

	public Vector3 worldPosition;

	public float range;

	public float spotAngleDeg;
}
