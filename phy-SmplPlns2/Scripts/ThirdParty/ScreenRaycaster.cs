using UnityEngine;

[AddComponentMenu("FingerGestures/Components/Screen Raycaster")]
public class ScreenRaycaster : MonoBehaviour
{
	public Camera[] Cameras;

	public LayerMask IgnoreLayerMask;

	public float RayThickness;

	public bool VisualizeRaycasts = true;

	public bool UsePhysics2D = true;

	private void Start()
	{
		if (Cameras == null || Cameras.Length == 0)
		{
			Cameras = new Camera[1] { Camera.main };
		}
	}

	public bool Raycast(Vector2 screenPos, out ScreenRaycastData hitData)
	{
		for (int i = 0; i < Cameras.Length; i++)
		{
			Camera camera = Cameras[i];
			if ((bool)camera && camera.enabled && camera.gameObject.activeInHierarchy && Raycast(camera, screenPos, out hitData))
			{
				return true;
			}
		}
		hitData = default(ScreenRaycastData);
		return false;
	}

	private bool Raycast(Camera cam, Vector2 screenPos, out ScreenRaycastData hitData)
	{
		Ray ray = cam.ScreenPointToRay(screenPos);
		bool flag = false;
		hitData = default(ScreenRaycastData);
		if (UsePhysics2D && cam.orthographic)
		{
			hitData.Hit2D = Physics2D.Raycast(ray.origin, Vector2.zero, float.PositiveInfinity, ~(int)IgnoreLayerMask);
			if ((bool)hitData.Hit2D.collider)
			{
				hitData.Is2D = true;
				flag = true;
			}
		}
		if (!flag)
		{
			hitData.Is2D = false;
			flag = ((!(RayThickness > 0f)) ? Physics.Raycast(ray, out hitData.Hit3D, float.PositiveInfinity, ~(int)IgnoreLayerMask) : Physics.SphereCast(ray, 0.5f * RayThickness, out hitData.Hit3D, float.PositiveInfinity, ~(int)IgnoreLayerMask));
		}
		return flag;
	}
}
