using UnityEngine;

public class CameraFrustum : MonoBehaviour
{
	[SerializeField]
	private Camera _camera;

	private Plane[] _frustumPlanes = new Plane[6];

	private void Awake()
	{
		Update();
	}

	private void Update()
	{
		GeometryUtility.CalculateFrustumPlanes(_camera, _frustumPlanes);
	}

	public bool IsCulled(Bounds bounds)
	{
		return !GeometryUtility.TestPlanesAABB(_frustumPlanes, bounds);
	}
}
