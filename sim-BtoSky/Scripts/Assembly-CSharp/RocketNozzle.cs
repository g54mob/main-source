public class RocketNozzle : RocketAttachment
{
	public float rocketPowMultiplier = 1f;

	private void Awake()
	{
		OnAwake();
	}

	private void Start()
	{
		OnStart();
		if (rocket != null)
		{
			rocket.rocketNozzle = base.gameObject;
			rocket.trustPowMult = rocketPowMultiplier;
		}
	}

	private void Update()
	{
	}
}
