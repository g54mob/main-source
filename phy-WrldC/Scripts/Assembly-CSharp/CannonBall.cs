using UnityEngine;

public class CannonBall : MonoBehaviour
{
	private MeshRenderer[] allMeshRenderers;

	private Collider[] allColliders;

	private Rigidbody thisRigidbody;

	public bool IsExisting { get; private set; }

	private void Awake()
	{
		allMeshRenderers = GetComponentsInChildren<MeshRenderer>(includeInactive: true);
		allColliders = GetComponentsInChildren<Collider>(includeInactive: true);
		thisRigidbody = base.transform.GetComponent<Rigidbody>();
		IsExisting = true;
	}

	public void SetExistence(bool isExisting)
	{
		if (isExisting != IsExisting)
		{
			for (int i = 0; i < allMeshRenderers.Length; i++)
			{
				allMeshRenderers[i].enabled = isExisting;
			}
			for (int j = 0; j < allColliders.Length; j++)
			{
				allColliders[j].enabled = isExisting;
			}
			if (!isExisting)
			{
				thisRigidbody.isKinematic = true;
			}
			IsExisting = isExisting;
		}
	}

	public Rigidbody GetRigidbody()
	{
		return thisRigidbody;
	}
}
