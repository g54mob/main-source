using UnityEngine;
using UnityEngine.Audio;

public class MonsterModelTriggerScript : MonoBehaviour
{
	public MonsterModelScript ModelScript;

	public bool DoActivate;

	public Transform Player;

	public GameObject Blocker;

	public float FinalWaitTime;

	public AudioSource FinalMusic;

	public CanvasGroup FinalUI;

	public AudioMixer Mixer;

	[HideInInspector]
	public bool DoingFinalSequence;

	public float AttackDelayTimer;

	public bool DoingAttackDelay;

	public AudioSource BreachSound;

	public AudioSource MonsterGaspSound;

	public ParticleSystem BloodExplode;

	public ParticleSystem BloodSpray;

	private MyMouseLook Mouse;

	private void Start()
	{
		Mouse = GameObject.Find("PlayerCamera").GetComponent<MyMouseLook>();
	}

	private void Update()
	{
		if (ModelScript.amactive)
		{
			FinalWaitTime -= Time.deltaTime;
			if (FinalWaitTime <= 0f && !DoingFinalSequence)
			{
				ActivateFinalSequence();
			}
		}
		if (Player.eulerAngles.y > 240f && Player.eulerAngles.y < 300f && DoActivate)
		{
			DoingAttackDelay = true;
		}
		if (DoingAttackDelay)
		{
			AttackDelayTimer -= Time.deltaTime;
			if (AttackDelayTimer <= 0f)
			{
				Activate();
			}
		}
	}

	private void FixedUpdate()
	{
		if (DoActivate)
		{
			Blocker.SetActive(value: true);
		}
	}

	public void Activate()
	{
		if (!ModelScript.amactive)
		{
			ModelScript.amactive = true;
			BreachSound.Play();
			MonsterGaspSound.Play();
			BloodExplode.Play();
			BloodSpray.Play();
			Mouse.RumbleAmount = 7f;
		}
	}

	public void ActivateFinalSequence()
	{
		DoingFinalSequence = true;
		ModelScript.amactive = false;
		FinalMusic.Play();
		FinalUI.alpha = 1f;
		Mixer.SetFloat("EnvironmentVolume", -80f);
		Mixer.SetFloat("MusicVolume", -80f);
	}
}
