using System;
using UnityEngine;

[Serializable]
public class soundEffects : MonoBehaviour
{
	public AudioSource audio;

	public AudioClip PCaught;

	public AudioClip PCaughtNightmare;

	public AudioClip exitDoorOpen;

	public AudioClip playerHit;

	public AudioClip hukaSig;

	public AudioClip stand;

	public AudioClip bedNer;

	public AudioClip bedUpp;

	public AudioClip manakin;

	public AudioClip crossbowShoot;

	public AudioClip crossbowLoad;

	public AudioClip inCoffin;

	public AudioClip OutCoffin;

	public AudioClip landSound;

	public AudioClip landBRSound;

	public AudioClip fallFloor;

	public AudioClip placeTavelbit;

	public AudioClip gunShot;

	public AudioClip inCar;

	public AudioClip outCar;

	public AudioClip shotgunLoad;

	public AudioClip shotgunEmpty;

	public AudioClip pickUpLoaded;

	public AudioClip remoteSound;

	public AudioClip pickupObject;

	public AudioClip landJumpSound;

	public virtual void Start()
	{
	}

	public virtual void playerCaught()
	{
	}

	public virtual void playerCaughtNightmare()
	{
	}

	public virtual void openExitDoor()
	{
	}

	public virtual void playerGetHit()
	{
	}

	public virtual void hukarSig()
	{
	}

	public virtual void standUp()
	{
	}

	public virtual void underBed()
	{
	}

	public virtual void fromBed()
	{
	}

	public virtual void manakinLook()
	{
	}

	public virtual void CrossbowShoot()
	{
	}

	public virtual void CrossbowLoad()
	{
	}

	public virtual void CoffinIn()
	{
	}

	public virtual void CoffinUt()
	{
	}

	public virtual void playerLandSound()
	{
	}

	public virtual void playerLandBRSound()
	{
	}

	public virtual void playerFallFloor()
	{
	}

	public virtual void tavelbitPlace()
	{
	}

	public virtual void GunShoot()
	{
	}

	public virtual void CarIn()
	{
	}

	public virtual void CarOut()
	{
	}

	public virtual void loadShotgun()
	{
	}

	public virtual void emptyShotgun()
	{
	}

	public virtual void loadedPickup()
	{
	}

	public virtual void clickRemote()
	{
	}

	public virtual void pickingUpStuff()
	{
	}

	public virtual void playerLandJumpSound()
	{
	}
}
