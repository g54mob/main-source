using UnityEngine;

public class ShieldOnFirstDamaged : MonoBehaviour, DayNightCycle.IDaytimeSensitive
{
	[SerializeField]
	private Hp hpToShield;

	[SerializeField]
	[BalancingParameter(BalancingParameter.EType.Default)]
	private float shieldDuration;

	[SerializeField]
	private GameObject shieldVisuals;

	private float shiledHasBeenActiveFor;

	private bool shieldActive;

	private bool shieldAvailable;

	private void Reset()
	{
		shieldActive = false;
		shieldAvailable = true;
		shiledHasBeenActiveFor = 0f;
		SetShieldVisuals(_enabled: false);
	}

	private void Update()
	{
		if (shieldActive)
		{
			shiledHasBeenActiveFor += Time.deltaTime;
			if (shiledHasBeenActiveFor >= shieldDuration)
			{
				shieldActive = false;
				shieldAvailable = false;
				hpToShield.invulnerable = false;
				SetShieldVisuals(_enabled: false);
			}
		}
	}

	private void Start()
	{
		Reset();
		hpToShield.OnReceiveDamage.AddListener(OnDamaged);
		DayNightCycle.Instance.RegisterDaytimeSensitiveObject(this);
	}

	private void OnDamaged(bool dealtByPlayer)
	{
		if (shieldActive || shieldAvailable)
		{
			if (!shieldActive)
			{
				SetShieldVisuals(_enabled: true);
			}
			hpToShield.SetHpToMaxHp();
			hpToShield.invulnerable = true;
			shieldActive = true;
		}
	}

	private void SetShieldVisuals(bool _enabled)
	{
		shieldVisuals.SetActive(_enabled);
	}

	public void OnDawn_AfterSunrise()
	{
		Reset();
	}

	public void OnDawn_BeforeSunrise()
	{
	}

	public void OnDusk()
	{
	}

	public void OnDuskEarly()
	{
	}
}
