using UnityEngine;

public class Plantable : MonoBehaviour
{
	public Ivy ivyRef;

	public PlantController controllerRef;

	public bool advanceOnCollision = true;

	private bool groundCollision;

	private Rigidbody rb;

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	private void OnCollisionEnter(Collision c)
	{
		if (!groundCollision && !rb.isKinematic && (c.gameObject.layer == RaycastUtil.stageLayer || c.gameObject.layer == RaycastUtil.navmeshObjectLayer))
		{
			OnGroundCollision(c);
		}
	}

	protected virtual void OnGroundCollision(Collision c)
	{
		groundCollision = true;
		base.transform.root.localRotation = Quaternion.FromToRotation(Vector3.up, c.contacts[0].normal * 90f);
		base.transform.root.Rotate(Vector3.up, Random.Range(0f, 360f));
		base.transform.position = c.contacts[0].point + base.transform.localScale.y / 2f * base.transform.root.up;
		rb.isKinematic = true;
		if (advanceOnCollision)
		{
			if (ivyRef != null)
			{
				ivyRef.OnSeedPlanted();
			}
			if (controllerRef != null)
			{
				controllerRef.SetPlantStage(PlantController.PlantStage.MOUND);
			}
		}
	}
}
