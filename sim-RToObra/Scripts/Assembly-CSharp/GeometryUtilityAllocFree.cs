using System;
using System.Reflection;
using UnityEngine;

public static class GeometryUtilityAllocFree
{
	private static Action<Plane[], Matrix4x4> Internal_ExtractPlanes = (Action<Plane[], Matrix4x4>)Delegate.CreateDelegate(typeof(Action<Plane[], Matrix4x4>), typeof(GeometryUtility).GetMethod("Internal_ExtractPlanes", BindingFlags.Static | BindingFlags.NonPublic));

	public static void CalculateFrustumPlanes(Camera camera, Plane[] planes)
	{
		Internal_ExtractPlanes(planes, camera.projectionMatrix * camera.worldToCameraMatrix);
	}
}
