using UnityEngine;

public class CameraCollision : MonoBehaviour
{
	[Header("Layer(s) to include")]
	public LayerMask CamOcclusion;

	private Vector3 camPosition;

	public float minDistance = 1f;

	public float maxDistance = 2f;

	public float DistanceUp = -2f;

	public float rotateAround = 70f;

	[Header("Map coordinate script")]
	private RaycastHit hit;

	public float smooth = 15f;

	private Vector3 camMask;

	private GameObject TransparentedGameObject;

	[SerializeField]
	private Material TransparentMaterial;

	private Material StandartMaterial;

	private Renderer WallHitRenderer;

	private bool isRaycastHit;

	public Transform targetTransform;

	private Transform lastHit;

	private void LateUpdate()
	{
		if (WallHitRenderer != null)
		{
			OccludeRay(targetTransform.eulerAngles);
		}
	}

	private void OccludeRay(Vector3 targetFollow)
	{
		RaycastHit hitInfo = default(RaycastHit);
		Vector3 start = base.transform.position + base.transform.forward * -15f;
		Debug.DrawLine(start, targetTransform.position + Vector3.up, Color.magenta);
		if (Physics.Linecast(start, targetTransform.position + Vector3.up, out hitInfo, CamOcclusion))
		{
			if (isRaycastHit && lastHit != hitInfo.transform)
			{
				ChangeMaterial();
			}
			if (!isRaycastHit && hitInfo.collider.TryGetComponent<Renderer>(out var component))
			{
				WallHitRenderer = component;
				StandartMaterial = WallHitRenderer.material;
				WallHitRenderer.material = TransparentMaterial;
				isRaycastHit = true;
				lastHit = hitInfo.transform;
			}
		}
		else if (isRaycastHit)
		{
			ChangeMaterial();
		}
	}

	private void ChangeMaterial()
	{
		WallHitRenderer.material = StandartMaterial;
		isRaycastHit = false;
	}
}
