using UnityEngine;

public class LiquidSpreader : MonoBehaviour
{
	public LiquidType liquidType;

	public bool spawnSplashParticles;

	private float minParticleVel = 5f;

	private string puddleImpactSound = "impact_puddle";

	private float particleGap = 0.1f;

	private float currentGap;

	private LiquidController controllerRef;

	private LiquidInfo liquidInfo;

	private LiquidPuddle puddleRef;

	private void Awake()
	{
		controllerRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<LiquidController>(GlobalObject.LIQUID_CONTROLLER);
		liquidInfo = controllerRef.GetLiquidForType(liquidType);
		puddleRef = base.transform.root.gameObject.GetComponent<LiquidPuddle>();
	}

	private void Update()
	{
		if (currentGap > 0f)
		{
			currentGap -= Time.deltaTime;
		}
	}

	public void SetLiquidInfo(LiquidInfo newInfo)
	{
		bool flag = true;
		if (newInfo.liquidMaterial == liquidInfo.liquidMaterial)
		{
			flag = false;
		}
		liquidInfo = newInfo;
		liquidType = newInfo.liquidType;
		if (flag)
		{
			Collider[] componentsInChildren = GetComponentsInChildren<Collider>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].material = liquidInfo.liquidMaterial;
			}
		}
	}

	private void OnTriggerEnter(Collider collider)
	{
		if (Tags.GetLiquidSpreadableObjects().Contains(collider.transform.root.gameObject.tag))
		{
			SpreadLiquidToObj(collider.transform.root.gameObject, collider.transform);
		}
	}

	private void OnTriggerStay(Collider collider)
	{
		if (puddleRef != null && collider.transform.root.gameObject.tag == Tags.VACUUM)
		{
			collider.transform.root.gameObject.GetComponent<InteractableRoboVacuum>().OnCollisionWithPuddle(puddleRef);
		}
	}

	private void SpreadLiquidToObj(GameObject obj, Transform hitTransform)
	{
		Liquid liquid = obj.GetComponent<Liquid>();
		if (liquid == null)
		{
			liquid = obj.AddComponent<Liquid>();
		}
		liquid.ApplyLiquid(liquidInfo);
		if (spawnSplashParticles && currentGap <= 0f)
		{
			Rigidbody rigidbody = hitTransform.GetComponent<Rigidbody>();
			if (rigidbody == null)
			{
				rigidbody = obj.GetComponentInChildren<Rigidbody>();
			}
			if (!(rigidbody == null) && !(rigidbody.velocity.magnitude < minParticleVel))
			{
				Vector3 position = hitTransform.position;
				position = new Vector3(position.x, base.transform.position.y, position.z);
				RequestSplashParticles(position);
			}
		}
	}

	public Color GetLiquidColor()
	{
		return liquidInfo.liquidColor;
	}

	public void RequestSplashParticles(Vector3 particlesPos)
	{
		if (!(currentGap > 0f))
		{
			currentGap = particleGap;
			GameObject obj = Object.Instantiate(controllerRef.splashParticles, particlesPos, Quaternion.identity);
			Material material = obj.GetComponent<Renderer>().material;
			material.color = liquidInfo.liquidColor;
			RequestSplashSound(particlesPos);
			obj.GetComponent<Renderer>().material = material;
		}
	}

	public void RequestSplashSound(Vector3 soundPos)
	{
		AudioController.Play(puddleImpactSound, soundPos);
	}
}
