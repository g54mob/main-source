using UnityEngine;

public class InterestPerk : MonoBehaviour, DayNightCycle.IDaytimeSensitive
{
	public static InterestPerk instance;

	[SerializeField]
	private Equippable requiredEquippable;

	[SerializeField]
	[BalancingParameter(BalancingParameter.EType.Default)]
	private int interestForEach = 3;

	[SerializeField]
	[BalancingParameter(BalancingParameter.EType.Default)]
	private int maximumInterest = 20;

	private void Awake()
	{
		instance = this;
	}

	private void Start()
	{
		if (!PerkManager.IsEquipped(requiredEquippable))
		{
			Object.Destroy(this);
		}
		else
		{
			DayNightCycle.Instance.RegisterDaytimeSensitiveObject(this);
		}
	}

	private void Update()
	{
	}

	public void OnDawn_AfterSunrise()
	{
	}

	public void OnDawn_BeforeSunrise()
	{
	}

	public void OnDusk()
	{
		PlayerInteraction.instance.AddCoin(InterestAmount());
	}

	public void OnDuskEarly()
	{
	}

	public int InterestAmount()
	{
		if (!PerkManager.IsEquipped(requiredEquippable))
		{
			return 0;
		}
		return Mathf.Min(maximumInterest, Mathf.CeilToInt((float)PlayerInteraction.instance.Balance / (float)interestForEach));
	}
}
