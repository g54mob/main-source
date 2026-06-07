using UnityEngine;

public class PlayerCharacterAudio : MonoBehaviour
{
	public Hp playerHp;

	public AutoRevive playerReviveComponent;

	public AudioSource stepAudioSource;

	public AudioSource fxAudioSource;

	public AudioSource dmgAudioSource;

	public PlayerMovement targetController;

	public float fadeTime = 0.3f;

	public float sprintPitch = 1.1f;

	private PlayerWeaponAudio weaponAudio;

	private float initialVolume;

	private float initialPitch;

	private float fadeSpeed;

	private void Start()
	{
		initialPitch = stepAudioSource.pitch;
		initialVolume = stepAudioSource.volume;
		stepAudioSource.volume = 0f;
		stepAudioSource.priority = 110;
		fadeSpeed = initialVolume / fadeTime;
		playerHp.OnKillOrKnockout.AddListener(OnDeath);
		playerHp.OnReceiveDamage.AddListener(OnDmg);
		playerReviveComponent.onReviveTrigger.AddListener(OnRevive);
	}

	public void OnWeaponEquip(ManualAttack weapon)
	{
		weaponAudio = weapon.GetComponent<PlayerWeaponAudio>();
		weaponAudio.autoWeapon.onAttack.AddListener(PlayAttackSound);
	}

	private void PlayAttackSound()
	{
		fxAudioSource.priority = 5;
		fxAudioSource.pitch = Random.Range(1f - weaponAudio.pitchRange, 1f + weaponAudio.pitchRange);
		fxAudioSource.PlayOneShot(weaponAudio.AttackSound.GetRandomClip(), weaponAudio.volume);
	}

	private void OnDeath()
	{
		dmgAudioSource.priority = 5;
		dmgAudioSource.pitch = 1f;
		dmgAudioSource.PlayOneShot(ThronefallAudioManager.Instance.audioContent.PlayerDeath.GetRandomClip(), 1f);
	}

	private void OnDmg(bool b)
	{
		dmgAudioSource.priority = 5;
		dmgAudioSource.pitch = Random.Range(0.9f, 1.1f);
		dmgAudioSource.PlayOneShot(ThronefallAudioManager.Instance.audioContent.PlayerDamage.GetRandomClip(), 0.65f);
	}

	private void OnRevive()
	{
		fxAudioSource.priority = 5;
		fxAudioSource.pitch = 1f;
		fxAudioSource.PlayOneShot(ThronefallAudioManager.Instance.audioContent.PlayerRevive, 0.8f);
	}

	private void Update()
	{
		if (targetController.Sprinting)
		{
			stepAudioSource.pitch = sprintPitch;
		}
		else
		{
			stepAudioSource.pitch = initialPitch;
		}
		if (targetController.Moving && (playerHp == null || !playerHp.KnockedOut))
		{
			stepAudioSource.volume = Mathf.MoveTowards(stepAudioSource.volume, initialVolume, fadeSpeed * Time.unscaledDeltaTime);
		}
		else
		{
			stepAudioSource.volume = Mathf.MoveTowards(stepAudioSource.volume, 0f, fadeSpeed * Time.unscaledDeltaTime);
		}
	}
}
