using System;
using UnityEngine;

public class Berry : MonoBehaviour
{
	private PickUppable ourPickUpScript;

	public int berryTier;

	private int calculatedCoinPayout;

	public int goldenBerryCoinValue;

	public bool isGoldenBerry;

	public bool isNebulaBerry;

	[Header("TrickShot")]
	[SerializeField]
	private bool isTrackingTrickShot;

	public float distanceThrown;

	private Vector3 posThrownAt;

	[SerializeField]
	private float trickShotDistance;

	[Header("Smoothie")]
	public long smoothieCombinedPayout;

	public int holePrestigeJuice_CombinedPayout;

	public Renderer smoothieLiquidRend;

	public int[] smoothieBerryTiers = new int[12];

	private bool awakeStateLastFrame;

	private Rigidbody rb;

	public const float NEBULABERRY_SLIGHTGRAVITY = 3f;

	public const float NEBULABERRY_PULLDOWNFORCENEARHOLE = 20f;

	private bool isInHoleGravPuller;

	[Header("Nebula Berry")]
	public const float NEBULABERRY_LIFETIME_MAX = 60f;

	[SerializeField]
	private float nebulaBerryLifeTime_Curr;

	private bool hasStartedDestroy;

	public const float SEEDCOST_TOHOLEJUICEVALUE_MULTIPLIER = 1.5f;

	private void Awake()
	{
		rb = GetComponent<Rigidbody>();
		ourPickUpScript = GetComponent<PickUppable>();
		PickUppable pickUppable = ourPickUpScript;
		pickUppable.OnThrown_Action = (Action)Delegate.Combine(pickUppable.OnThrown_Action, new Action(OnThrown));
		PickUppable pickUppable2 = ourPickUpScript;
		pickUppable2.OnPickUp_Action = (Action)Delegate.Combine(pickUppable2.OnPickUp_Action, new Action(OnPickUp));
		if ((bool)GameManager.Singleton)
		{
			GameManager.Singleton.AddToSpawnedBerryList(base.gameObject);
		}
	}

	private void OnDestroy()
	{
		PickUppable pickUppable = ourPickUpScript;
		pickUppable.OnThrown_Action = (Action)Delegate.Remove(pickUppable.OnThrown_Action, new Action(OnThrown));
		PickUppable pickUppable2 = ourPickUpScript;
		pickUppable2.OnPickUp_Action = (Action)Delegate.Remove(pickUppable2.OnPickUp_Action, new Action(OnPickUp));
		GameManager.Singleton.RemoveFromSpawnedBerryList(base.gameObject);
	}

	private void Start()
	{
		if (!isNebulaBerry)
		{
			RollForGoldenBerry();
		}
		CalculateHoleGrowthValue();
		ResetDistanceThrown();
	}

	private void CalculateHoleGrowthValue()
	{
	}

	private void Update()
	{
		_ = isTrackingTrickShot;
		if (isNebulaBerry)
		{
			if (ourPickUpScript.isHeld)
			{
				ResetNebulaBerryTimer();
			}
			HandleNebulaBerryLifetime();
		}
	}

	private void FixedUpdate()
	{
		if (rb.IsSleeping() && !awakeStateLastFrame)
		{
			ResetDistanceThrown();
		}
		awakeStateLastFrame = rb.IsSleeping();
		if (isNebulaBerry)
		{
			if (base.transform.position.y > 5.5f)
			{
				rb.AddForce(Vector3.down * 3f, ForceMode.Acceleration);
			}
			if (base.transform.position.y < 0.5f)
			{
				rb.useGravity = true;
			}
			if (isInHoleGravPuller)
			{
				rb.AddForce(Vector3.down * 20f, ForceMode.Acceleration);
			}
		}
	}

	private void OnCollisionEnter(Collision _other)
	{
		_other.collider.gameObject.CompareTag("Turtle");
		_other.collider.gameObject.CompareTag("Ground");
	}

	private void OnTriggerEnter(Collider other)
	{
		other.gameObject.CompareTag("TurtleEatAOE");
		if (other.gameObject.CompareTag("GravEnabler"))
		{
			isInHoleGravPuller = true;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.CompareTag("GravEnabler"))
		{
			isInHoleGravPuller = false;
		}
	}

	public void CalculateCoinPayout()
	{
		float num = 1f;
		if (distanceThrown > TrickShotHelper.Singleton.trickShotDistanceThresholds[0])
		{
			num = GetTrickShotMuliplier();
		}
		float num2 = (isGoldenBerry ? PlayerStats.Singleton.goldenBerry_ValueMultiplier_Curr : 1f);
		if (berryTier == 100)
		{
			calculatedCoinPayout = Mathf.CeilToInt((float)smoothieCombinedPayout * num * PlayerStats.Singleton.berryCoinValue_Multiplier);
		}
		else
		{
			calculatedCoinPayout = Mathf.CeilToInt((float)ShopAndUpgradesManager.Singleton.BerryCoinValueList[berryTier] * num * PlayerStats.Singleton.berryCoinValue_Multiplier * num2);
		}
		ourPickUpScript.coinValue = calculatedCoinPayout;
	}

	public float GetHoleGrowthPointValue()
	{
		if (berryTier == 100)
		{
			return smoothieCombinedPayout;
		}
		return ShopAndUpgradesManager.Singleton.BerryHoleGrowthValueList[berryTier];
	}

	private float GetTrickShotMuliplier()
	{
		return 1f + distanceThrown * PlayerStats.Singleton.trickShot_bonusMultiplierPerUnitThrown;
	}

	private void OnThrown()
	{
		StartTrickShot();
	}

	private void OnPickUp()
	{
		ResetDistanceThrown();
		if (isNebulaBerry)
		{
			ResetNebulaBerryTimer();
		}
	}

	private void StartTrickShot()
	{
		ResetDistanceThrown();
		isTrackingTrickShot = true;
		posThrownAt = base.transform.position;
	}

	private void ResetDistanceThrown()
	{
		isTrackingTrickShot = false;
		distanceThrown = 0f;
	}

	private void RollForGoldenBerry()
	{
		if (berryTier != 100 && UnityEngine.Random.Range(0f, 100f) <= PlayerStats.Singleton.goldenBerryChance_Curr)
		{
			ChangeToGoldenBerry();
		}
	}

	private void ChangeToGoldenBerry()
	{
		isGoldenBerry = true;
		base.gameObject.GetComponentInChildren<Renderer>().material = GameManager.Singleton.prefabBank.mat_GoldenBerry;
		ourPickUpScript.coinValue = Mathf.RoundToInt((float)ourPickUpScript.coinValue * PlayerStats.Singleton.goldenBerry_ValueMultiplier_Curr);
	}

	public void ChangeToNebulaBerry()
	{
		ResetNebulaBerryTimer();
		isNebulaBerry = true;
		isGoldenBerry = true;
		base.gameObject.GetComponentInChildren<Renderer>().material = GameManager.Singleton.prefabBank.mat_Nebula;
		rb.useGravity = false;
	}

	private void ResetNebulaBerryTimer()
	{
		nebulaBerryLifeTime_Curr = 60f;
	}

	private void HandleNebulaBerryLifetime()
	{
		nebulaBerryLifeTime_Curr -= Time.deltaTime;
		if (nebulaBerryLifeTime_Curr <= 0f && !hasStartedDestroy)
		{
			hasStartedDestroy = true;
			int num = berryTier + 1;
			for (int i = 0; i < num; i++)
			{
				Rigidbody component = UnityEngine.Object.Instantiate(GameManager.Singleton.prefabBank.seedPrefab, base.gameObject.transform.position, Quaternion.identity).GetComponent<Rigidbody>();
				component.AddForce(Vector3.up * 8f, ForceMode.VelocityChange);
				component.AddTorque(component.transform.right * 15f, ForceMode.VelocityChange);
			}
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	public PickUppable GetPickUpScript()
	{
		return ourPickUpScript;
	}
}
