using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class CrystalAltar : MapObject, ISavable
{
	[SerializeField]
	private List<Cost> reward;

	[SerializeField]
	private AudioData takeCrystalSound;

	[Header("Loot Aniamtion")]
	[SerializeField]
	private GameObject crystal;

	[SerializeField]
	private ParticleSystem glowPS;

	[SerializeField]
	private ParticleSystem disappearPS;

	[SerializeField]
	private Light pointLight;

	private AudioSource ambienceAudioSource;

	private Animator animator;

	[Savable("alreadyUsed", true, false)]
	private bool alreadyUsed;

	private bool isBeingTracked;

	public List<Cost> Reward => reward;

	public bool AlreadyUsed => alreadyUsed;

	public bool IsBeingTracked
	{
		get
		{
			return isBeingTracked;
		}
		set
		{
			isBeingTracked = value;
		}
	}

	public event Action onLootAltar;

	protected override void Awake()
	{
		base.Awake();
		animator = GetComponent<Animator>();
		ambienceAudioSource = GetComponent<AudioSource>();
		reward.Sort((Cost x, Cost y) => x.Amount.CompareTo(y.Amount));
	}

	protected override void Start()
	{
		base.Start();
		placementComponent.onBecomeVisible += OnBecomeVisible;
		if (placementComponent.IsVisible())
		{
			OnBecomeVisible();
		}
	}

	public void GetReward()
	{
		if (alreadyUsed)
		{
			return;
		}
		foreach (Cost item in Reward)
		{
			LTFunctionLibrary.GetPlayerInventory().StoreObject(item.Resource, item.Amount, Storage_ResourceData.EStoreSource.Chest);
		}
		alreadyUsed = true;
		PlayLootAnimation();
		ambienceAudioSource.DOFade(0f, 1.5f);
		this.onLootAltar?.Invoke();
	}

	private void PlayLootAnimation()
	{
		AudioSystem.Instance.PlaySound2D(takeCrystalSound, AudioSystem.EAudioMixerGroup.UI);
		disappearPS.Play();
		glowPS.gameObject.SetActive(value: false);
		crystal.SetActive(value: false);
		pointLight.DOIntensity(3.5f, 0.15f).SetEase(Ease.InOutSine).SetUpdate(isIndependentUpdate: true)
			.onComplete = delegate
		{
			pointLight.DOIntensity(0f, 0.5f).SetEase(Ease.InOutSine).SetDelay(0.15f)
				.SetUpdate(isIndependentUpdate: true)
				.onComplete = delegate
			{
				pointLight.gameObject.SetActive(value: false);
			};
		};
	}

	private void OnBecomeVisible()
	{
		if (!alreadyUsed)
		{
			float volume = ambienceAudioSource.volume;
			ambienceAudioSource.outputAudioMixerGroup = AudioSystem.Instance.GetAudioMixerConfig(AudioSystem.EAudioMixerGroup.SFX).mixer;
			ambienceAudioSource.loop = true;
			ambienceAudioSource.volume = 0f;
			ambienceAudioSource.Play();
			ambienceAudioSource.DOFade(volume, 1.5f);
		}
	}

	public void OnSave()
	{
	}

	public void OnPreLoad()
	{
	}

	public void OnLoad(Dictionary<string, object> data, bool hasLoadedSomething)
	{
		if (!hasLoadedSomething || alreadyUsed)
		{
			alreadyUsed = true;
			glowPS.gameObject.SetActive(value: false);
			crystal.SetActive(value: false);
			pointLight.gameObject.SetActive(value: false);
			ambienceAudioSource.Stop();
		}
	}
}
