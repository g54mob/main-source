using UnityEngine;

public class ResourceBox : MonoBehaviour
{
	[SerializeField]
	protected float resourceMin = 25f;

	[SerializeField]
	protected float resourceMax = 75f;

	[SerializeField]
	protected ResourceTypes resourceType;

	protected ModuleClaw claw;

	protected void Start()
	{
		claw = Train.Instance.GetModuleByType<ModuleClaw>();
	}

	protected void Update()
	{
		if (base.transform.position.x < -5f)
		{
			Object.Destroy(base.gameObject);
		}
	}

	public virtual ResourceBoxData OnGrab(float gainMult)
	{
		if (base.gameObject == null)
		{
			return null;
		}
		float num = Random.Range(resourceMin, resourceMax) * gainMult;
		if (resourceType == ResourceTypes.Ammo)
		{
			claw.AddResource(num, ResourceTypes.Ammo);
			DataTrackingManager.Instance.AddAmmoCollected((int)num);
		}
		else if (resourceType == ResourceTypes.Scrap)
		{
			claw.AddResource(num, ResourceTypes.Scrap);
			DataTrackingManager.Instance.AddScrapCollected((int)num);
		}
		if (base.gameObject != null)
		{
			Object.Destroy(base.gameObject, 0.01f);
		}
		return new ResourceBoxData(base.transform.position, num, resourceType);
	}
}
