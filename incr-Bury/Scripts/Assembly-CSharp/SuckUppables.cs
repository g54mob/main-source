using System.Collections;
using MoreMountains.Feedbacks;
using UnityEngine;

public class SuckUppables : MonoBehaviour
{
	public bool CanBeSuckedUp;

	private bool autoDepositSeed;

	[SerializeField]
	private float autoDepositTime;

	private bool hasDepositied;

	public ItemIdentity identity;

	[SerializeField]
	private MMF_Player feedback_PickUp;

	private Rigidbody rb;

	public bool pickedUpManually;

	private void Awake()
	{
		rb = GetComponent<Rigidbody>();
	}

	private void Start()
	{
		CheckIfSeedAndPiggyBankSeedVacuumUpgraded();
	}

	private void CheckIfSeedAndPiggyBankSeedVacuumUpgraded()
	{
		if (identity == ItemIdentity.Seed)
		{
			CanBeSuckedUp = false;
			if (ShopAndUpgradesManager.Singleton.piggyBank_CanSuckUpSeeds)
			{
				autoDepositSeed = true;
				StartCoroutine(HandleAutoDepositSeed());
			}
		}
	}

	public void OnPlayerPickedUsed()
	{
		if (!hasDepositied)
		{
			PickUpSeed();
		}
	}

	private void PickUpSeed()
	{
		base.gameObject.tag = "Untagged";
		hasDepositied = true;
		OnPickUpCuteUpwardBoop();
		feedback_PickUp?.PlayFeedbacks();
		if (identity == ItemIdentity.Coin)
		{
			AudioManager.Singleton.PlayCoinPickUpSFX(base.transform.position);
		}
		StartCoroutine(WaitThenDestroy(0.35f));
		if (!pickedUpManually || !UpgradeTreeManager.Singleton.allUpgradeTreeButtons[105].isUnlocked || GameManager.Singleton.achievement_coinsPickedUpAchivementUnlockedThisRound)
		{
			return;
		}
		GameManager.Singleton.achievement_coinsPickedUpManuallyDespiteAutoPickUpEnabled++;
		if (GameManager.Singleton.achievement_coinsPickedUpManuallyDespiteAutoPickUpEnabled >= 5)
		{
			GameManager.Singleton.achievement_coinsPickedUpAchivementUnlockedThisRound = true;
			if (!AchievementHelper.IsAchievementUnlocked("ACH_ForgotAboutAutoPickUp"))
			{
				AchievementHelper.UnlockAchievement("ACH_ForgotAboutAutoPickUp");
			}
		}
	}

	private void OnPickUpCuteUpwardBoop()
	{
		rb.linearVelocity = Vector3.zero;
		rb.angularVelocity = Vector3.zero;
		rb.AddForce(Vector3.up * 5f, ForceMode.VelocityChange);
		Vector3 normalized = new Vector3(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f)).normalized;
		rb.AddTorque(normalized * 8f, ForceMode.VelocityChange);
	}

	private IEnumerator WaitThenDestroy(float _timeBeforeDestroy)
	{
		yield return new WaitForSeconds(_timeBeforeDestroy);
		try
		{
			if (identity == ItemIdentity.Coin)
			{
				Coin component = GetComponent<Coin>();
				component.CalculateCoinValue();
				PlayerStats.Singleton.IncreaseMoney_Held(component.GetCoinValue());
			}
			else if (identity == ItemIdentity.Seed)
			{
				PlayerStats.Singleton.IncreaseSeeds(1);
			}
		}
		catch
		{
			Debug.Log("Failed to get the corresponding identity scripts from this object, ignoring! Not intended!");
		}
		Object.Destroy(base.gameObject);
	}

	private IEnumerator HandleAutoDepositSeed()
	{
		base.gameObject.tag = "Untagged";
		hasDepositied = true;
		yield return new WaitForSeconds(autoDepositTime);
		PickUpSeed();
	}

	private void OnTriggerEnter(Collider other)
	{
		if (GameManager.Singleton.gameState == GameManager.GameState.Playing && other.gameObject.CompareTag("AutoCoinPickUp"))
		{
			OnPlayerPickedUsed();
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		if ((collision.gameObject.layer == 6 || collision.gameObject.layer == 8) && collision.impulse.magnitude / Time.fixedDeltaTime > 200f)
		{
			AudioManager.Singleton.PlayCoinImpactSFX(base.transform.position);
		}
	}
}
