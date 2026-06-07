using UnityEngine;

namespace Assets.Scripts.Tools.ObjectTransform
{
	public static class MovementGizmoCamera
	{
		public static CameraClearFlags CameraClearFlags => CameraClearFlags.Depth;

		public static int CullingMask => 3072;

		public static Camera Create(Transform parent)
		{
			Camera camera = Game.Instance.ResourceLoader.InstantiatePrefab<Camera>("Design/GizmoCamera");
			Transform transform = camera.transform;
			transform.SetParent(parent, worldPositionStays: true);
			transform.localRotation = Quaternion.identity;
			transform.localPosition = Vector3.zero;
			camera.name = "GizmoCamera";
			camera.clearFlags = CameraClearFlags;
			camera.cullingMask = CullingMask;
			return camera;
		}
	}
}
