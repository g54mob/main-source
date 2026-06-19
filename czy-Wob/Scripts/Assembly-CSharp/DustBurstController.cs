using UnityEngine;

public class DustBurstController : MonoBehaviour
{
	public bool specialBurst;

	private GameObject dustBurst;

	private GameObject starBurst;

	private GameObject starBurstSingle;

	private GameObject flairBurst_1;

	private float defaultSize = 1.5f;

	private float burstSeparationMin = 0.25f;

	private float burstTimer;

	private int minBurst = 2;

	private int maxBurst = 8;

	private float burstVelMin = 100f;

	private float burstVelMax = 800f;

	private BoundingBoxComponent boundingBoxRef;

	private void Awake()
	{
		dustBurst = (GameObject)Resources.Load("Particles/objectDust");
		starBurst = (GameObject)Resources.Load("Particles/starHitBurst");
		starBurstSingle = (GameObject)Resources.Load("Particles/starHitBurstSingle");
		flairBurst_1 = (GameObject)Resources.Load("Particles/objectFlairBurst_1");
		boundingBoxRef = GetComponent<BoundingBoxComponent>();
		if (boundingBoxRef == null)
		{
			boundingBoxRef = base.gameObject.AddComponent<BoundingBoxComponent>();
		}
		float massMultiplierForObject = ObjectUtil.GetMassMultiplierForObject(base.gameObject);
		burstVelMin *= massMultiplierForObject;
		burstVelMax *= massMultiplierForObject;
	}

	private void Update()
	{
		if (burstTimer > 0f)
		{
			burstTimer -= Time.deltaTime;
		}
	}

	public void ClearBurstTimer()
	{
		burstTimer = burstSeparationMin;
	}

	public void RequestBurst(Collision c)
	{
		if (burstTimer > 0f)
		{
			return;
		}
		float magnitude = c.impulse.magnitude;
		if (magnitude < burstVelMin)
		{
			return;
		}
		DustBurstController component = c.transform.root.gameObject.GetComponent<DustBurstController>();
		if (component != null)
		{
			component.ClearBurstTimer();
		}
		burstTimer = burstSeparationMin;
		Vector3 zero = Vector3.zero;
		for (int i = 0; i < c.contacts.Length; i++)
		{
			zero += c.contacts[i].point;
		}
		zero /= (float)c.contacts.Length;
		Vector3 zero2 = Vector3.zero;
		for (int j = 0; j < c.contacts.Length; j++)
		{
			zero2 += c.contacts[j].normal;
		}
		zero2 /= (float)c.contacts.Length;
		zero2 *= -90f;
		Vector3 boxSize = boundingBoxRef.GetBoxSize();
		if (base.gameObject.CompareTag(Tags.DOG))
		{
			boxSize /= 2f;
		}
		float num = Mathf.Min(boxSize.x, boxSize.z) / defaultSize;
		bool flag = false;
		if (specialBurst || (component != null && component.specialBurst))
		{
			Object.Instantiate(starBurst, zero, Quaternion.Euler(zero2));
		}
		else if (c.contacts.Length < 4 && !base.gameObject.CompareTag(Tags.DOG))
		{
			flag = true;
			Object.Instantiate(flairBurst_1, zero, Quaternion.Euler(zero2));
			Object.Instantiate(starBurstSingle, zero, Quaternion.Euler(-zero2));
			GameObject obj = Object.Instantiate(dustBurst, zero, Quaternion.identity);
			obj.transform.LookAt(zero2);
			ParticleSystem componentInChildren = obj.GetComponentInChildren<ParticleSystem>();
			ParticleSystem.MainModule main = componentInChildren.main;
			ParticleSystem.MinMaxCurve startSize = componentInChildren.main.startSize;
			startSize.constant *= num;
			ParticleSystem.MinMaxCurve startSpeed = componentInChildren.main.startSpeed;
			startSpeed.constant *= num;
			ParticleSystem.MinMaxCurve gravityModifier = componentInChildren.main.gravityModifier;
			gravityModifier.constant *= num;
			main.startSize = startSize;
			main.startSpeed = startSpeed;
			main.gravityModifier = gravityModifier;
			magnitude = Mathf.Min(magnitude, burstVelMax);
			float num2 = burstVelMax - burstVelMin;
			int num3 = Mathf.RoundToInt((magnitude - burstVelMin) / num2 * (float)(maxBurst - minBurst) + (float)minBurst);
			if (flag)
			{
				num3 = minBurst;
			}
			ParticleSystem.Burst[] array = new ParticleSystem.Burst[1] { default(ParticleSystem.Burst) };
			array[0].minCount = (short)num3;
			array[0].maxCount = (short)num3;
			componentInChildren.emission.SetBursts(array);
		}
		GameObject gameObject = c.transform.root.gameObject;
		if (base.gameObject.CompareTag(Tags.DOG))
		{
			GetComponent<DogAI>().OnStrongCollision(gameObject);
		}
		else if (gameObject.CompareTag(Tags.DOG))
		{
			gameObject.GetComponent<DogAI>().OnStrongCollision(base.gameObject);
		}
	}
}
