using Unity.Mathematics;
using UnityEngine;

public static class EntityMonoBehaviourExtensions
{
	public static Vector3 ToWorld(this Vector3 p)
	{
		return EntityMonoBehaviour.ToWorldFromRender(p);
	}

	public static Vector3 ToRender(this Vector3 p)
	{
		return EntityMonoBehaviour.ToRenderFromWorld(p);
	}

	public static float3 ToWorld(this float3 p)
	{
		return EntityMonoBehaviour.ToWorldFromRender(p);
	}

	public static float3 ToRender(this float3 p)
	{
		return EntityMonoBehaviour.ToRenderFromWorld(p);
	}
}
