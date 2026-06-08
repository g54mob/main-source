using UnityEngine;

public static class CameraExtensions
{
	public static Vector3 WorldToNormalizedViewportPoint(this Camera camera, Vector3 point)
	{
		point = camera.WorldToViewportPoint(point);
		if (camera.orthographic)
		{
			point.z = 2f * (point.z - camera.nearClipPlane) / (camera.farClipPlane - camera.nearClipPlane) - 1f;
		}
		else
		{
			point.z = (camera.farClipPlane + camera.nearClipPlane) / (camera.farClipPlane - camera.nearClipPlane) + 1f / point.z * (-2f * camera.farClipPlane * camera.nearClipPlane / (camera.farClipPlane - camera.nearClipPlane));
		}
		return point;
	}

	public static Vector3 NormalizedViewportToWorldPoint(this Camera camera, Vector3 point)
	{
		if (camera.orthographic)
		{
			point.z = (point.z + 1f) * (camera.farClipPlane - camera.nearClipPlane) * 0.5f + camera.nearClipPlane;
		}
		else
		{
			point.z = -2f * camera.farClipPlane * camera.nearClipPlane / (camera.farClipPlane - camera.nearClipPlane) / (point.z - (camera.farClipPlane + camera.nearClipPlane) / (camera.farClipPlane - camera.nearClipPlane));
		}
		return camera.ViewportToWorldPoint(point);
	}
}
