using UnityEngine;

public class PlayerWeaponAudio : MonoBehaviour
{
	public enum WeaponType
	{
		Sword = 0,
		Spear = 1,
		Bow = 2,
		LightningWand = 3,
		ShadowCodex = 4,
		Falchion = 5,
		PotionVials = 6,
		Axe = 7,
		Bloodwand = 8
	}

	public ManualAttack autoWeapon;

	public ManualAttack activeAbility;

	public WeaponType weaponType;

	public float pitchRange;

	public float volume = 0.75f;

	[HideInInspector]
	private AudioSet.ClipArray attackSound;

	private bool initialized;

	public AudioSet.ClipArray AttackSound
	{
		get
		{
			if (!initialized)
			{
				Initialize();
			}
			return attackSound;
		}
	}

	private void Initialize()
	{
		switch (weaponType)
		{
		case WeaponType.Bow:
			attackSound = ThronefallAudioManager.Instance.audioContent.PlayerBow;
			break;
		case WeaponType.Spear:
			attackSound = ThronefallAudioManager.Instance.audioContent.PlayerSpear;
			break;
		case WeaponType.Sword:
			attackSound = ThronefallAudioManager.Instance.audioContent.PlayerSword;
			break;
		case WeaponType.LightningWand:
			attackSound = ThronefallAudioManager.Instance.audioContent.PlayerLightningWand;
			break;
		case WeaponType.ShadowCodex:
			attackSound = ThronefallAudioManager.Instance.audioContent.PlayerShadowCodex;
			break;
		case WeaponType.Falchion:
			attackSound = ThronefallAudioManager.Instance.audioContent.PlayerFalchion;
			break;
		case WeaponType.PotionVials:
			attackSound = ThronefallAudioManager.Instance.audioContent.PlayerPotionThrow;
			break;
		case WeaponType.Axe:
			attackSound = ThronefallAudioManager.Instance.audioContent.PlayerAxeHit;
			break;
		case WeaponType.Bloodwand:
			attackSound = ThronefallAudioManager.Instance.audioContent.PlayerBloodwandHit;
			break;
		}
		initialized = true;
	}
}
