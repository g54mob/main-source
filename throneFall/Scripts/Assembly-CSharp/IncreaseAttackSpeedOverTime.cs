using UnityEngine;

public class IncreaseAttackSpeedOverTime : MonoBehaviour, DayNightCycle.IDaytimeSensitive
{
	[SerializeField]
	private AutoAttack autoAttack;

	[SerializeField]
	[BalancingParameter(BalancingParameter.EType.Percentage)]
	private float maximumAdditionalCooldownSpeed = 4f;

	[SerializeField]
	[BalancingParameter(BalancingParameter.EType.Default)]
	private float increaseSpeed = 0.1f;

	[SerializeField]
	[BalancingParameter(BalancingParameter.EType.Default)]
	private float decreaseSpeed = 1f;

	private float additionalCooldownSpeed;

	private void Start()
	{
		DayNightCycle.Instance.RegisterDaytimeSensitiveObject(this);
	}

	private void Update()
	{
		if (autoAttack.onCooldown)
		{
			additionalCooldownSpeed = Mathf.Min(additionalCooldownSpeed + increaseSpeed * Time.deltaTime, maximumAdditionalCooldownSpeed);
			autoAttack.ReduceCooldownBy(additionalCooldownSpeed * Time.deltaTime);
		}
		else
		{
			additionalCooldownSpeed = Mathf.Max(additionalCooldownSpeed - decreaseSpeed * Time.deltaTime, 0f);
		}
	}

	public void OnDawn_AfterSunrise()
	{
	}

	public void OnDawn_BeforeSunrise()
	{
	}

	public void OnDusk()
	{
		additionalCooldownSpeed = 0f;
	}

	public void OnDuskEarly()
	{
	}
}
