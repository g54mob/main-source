using UnityEngine;

public class DetectionCrosshair : MonoBehaviour
{
	public Camera playerCamera;

	public float distance;

	public float sphereRadius;

	public Color gizmoColor;

	public LayerMask layerMask;

	public LayerMask noOccluded;

	private GameObject lastDetectedObject;

	private void Update()
	{
	}

	private void DetectCrosshair()
	{
	}

	private bool IsObjectOccluded(Collider detectedCollider)
	{
		return false;
	}

	private void OnDrawGizmos()
	{
	}
}
