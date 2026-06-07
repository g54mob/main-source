using System.Collections;
using DV.ThingTypes;
using DV.UserManagement;
using DV.Utils;
using UnityEngine;

public class GaragePadlockUnlocker : MonoBehaviour
{
	public GameObject blockers;

	public GameObject lootCover;

	public Animation unlockAnim;

	public Padlock padlock;

	private GarageCarSpawner garageSpawner;

	private bool garageAlreadyUnlocked;

	private bool isCareer;

	private void Awake()
	{
		garageSpawner = GetComponent<GarageCarSpawner>();
		if (garageSpawner == null)
		{
			Debug.LogError("Unexpected state: " + base.gameObject.GetPath() + ": garageSpawner is not set!");
		}
		if (padlock == null)
		{
			Debug.LogError("Unexpected state: " + base.gameObject.GetPath() + ": padlock is not set!");
		}
		if (blockers == null)
		{
			Debug.LogError("Unexpected state: " + base.gameObject.GetPath() + ": blockers is not set!");
		}
		if (lootCover == null)
		{
			Debug.LogError("Unexpected state: " + base.gameObject.GetPath() + ": lootCover is not set!");
		}
		isCareer = SingletonBehaviour<UserManager>.Instance?.CurrentUser?.CurrentSession?.GameMode == "Career";
	}

	private void Start()
	{
		garageAlreadyUnlocked = SingletonBehaviour<LicenseManager>.Instance.IsGarageUnlocked(garageSpawner.garageType);
		SetupListeners(on: true);
		if (garageAlreadyUnlocked && isCareer)
		{
			padlock.ContinueUnlockingPadlock();
		}
	}

	private void OnDestroy()
	{
		SetupListeners(on: false);
	}

	private void SetupListeners(bool on)
	{
		if (on)
		{
			padlock.Unlocked += OnPadlockUnlocked;
			SingletonBehaviour<LicenseManager>.Instance.GarageUnlocked += OnGarageUnlocked;
			return;
		}
		if ((bool)padlock)
		{
			padlock.Unlocked -= OnPadlockUnlocked;
		}
		if (!UnloadWatcher.isUnloading)
		{
			SingletonBehaviour<LicenseManager>.Instance.GarageUnlocked -= OnGarageUnlocked;
		}
	}

	private void OnGarageUnlocked(GarageType_v2 unlockedGarageType)
	{
		if (garageSpawner.garageType == unlockedGarageType && isCareer)
		{
			UnlockSequence();
			SetupListeners(on: false);
			if ((bool)padlock && padlock.IsLocked)
			{
				Object.Destroy(padlock.gameObject);
			}
		}
	}

	private void OnPadlockUnlocked()
	{
		garageAlreadyUnlocked = true;
		SingletonBehaviour<LicenseManager>.Instance.UnlockGarage(garageSpawner.garageType);
	}

	private void UnlockSequence()
	{
		StartCoroutine(SafelyDestroyBlockers());
		Object.Destroy(lootCover);
		unlockAnim.Play();
		garageSpawner.AllowSpawning();
	}

	private IEnumerator SafelyDestroyBlockers()
	{
		blockers.transform.position = new Vector3(0f, 5000f, 0f);
		yield return WaitFor.FixedUpdate;
		yield return WaitFor.EndOfFrame;
		Object.Destroy(blockers);
	}
}
