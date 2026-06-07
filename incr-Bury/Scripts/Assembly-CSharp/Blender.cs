using System;
using System.Collections.Generic;
using MoreMountains.Feedbacks;
using UnityEngine;
using UnityEngine.UI;

public class Blender : MonoBehaviour
{
	[SerializeField]
	private int berriesToNextSeedDrop;

	[SerializeField]
	private int berriesGrindedSinceLastSmoothieDrop;

	[SerializeField]
	private long nextSmoothieValue;

	[SerializeField]
	private int nextSmoothie_StoredHolePrestigeJuice;

	private Berry enteredBerryScript;

	[Header("Spawning")]
	[SerializeField]
	private float smoothieSpawnUpwardOffset;

	[Header("Feedbacks")]
	[SerializeField]
	private MMF_Player feedback_GrindBerry;

	[SerializeField]
	private MMWiggle wiggleComponent;

	[Header("UI")]
	[SerializeField]
	private Image fillIndicatorImage;

	[SerializeField]
	private Gradient fillGradient;

	[Header("Particles")]
	[SerializeField]
	private float particlePlayTime;

	private float particlePlayTime_Curr;

	[SerializeField]
	private ParticleSystem berryParticles;

	private ParticleSystem.MainModule berryParticles_Main;

	[Header("Stored Berry Colors")]
	public List<int> storedBerryTiers;

	private Color smoothieColor1;

	private Color smoothieColor2;

	[Header("Chainsaw")]
	private PickUppable ourPickUpScript;

	[SerializeField]
	private AudioSource audioSource_ChainSawIdling;

	private void Awake()
	{
		ourPickUpScript = GetComponentInParent<PickUppable>();
	}

	private void Start()
	{
		InitialSetup();
		AudioManager singleton = AudioManager.Singleton;
		singleton.AudioLevelsChanged_Action = (Action)Delegate.Combine(singleton.AudioLevelsChanged_Action, new Action(OnAudioLevelsChanged));
		GameManager singleton2 = GameManager.Singleton;
		singleton2.OnRoundStart_Action = (Action)Delegate.Combine(singleton2.OnRoundStart_Action, new Action(OnRoundStart));
		GameManager singleton3 = GameManager.Singleton;
		singleton3.OnNightTime_Action = (Action)Delegate.Combine(singleton3.OnNightTime_Action, new Action(OnNightTime));
	}

	private void OnDestroy()
	{
		AudioManager singleton = AudioManager.Singleton;
		singleton.AudioLevelsChanged_Action = (Action)Delegate.Remove(singleton.AudioLevelsChanged_Action, new Action(OnAudioLevelsChanged));
		GameManager singleton2 = GameManager.Singleton;
		singleton2.OnRoundStart_Action = (Action)Delegate.Remove(singleton2.OnRoundStart_Action, new Action(OnRoundStart));
		GameManager singleton3 = GameManager.Singleton;
		singleton3.OnNightTime_Action = (Action)Delegate.Remove(singleton3.OnNightTime_Action, new Action(OnNightTime));
	}

	private void OnRoundStart()
	{
		audioSource_ChainSawIdling.Play();
	}

	private void OnNightTime()
	{
		audioSource_ChainSawIdling.Stop();
		wiggleComponent.enabled = false;
	}

	private void OnAudioLevelsChanged()
	{
		SetChainSawIdleVolume();
	}

	private void SetChainSawIdleVolume()
	{
		audioSource_ChainSawIdling.volume = AudioManager.Singleton.sfxVolume;
	}

	private void Update()
	{
		HandleParticlePlayTime();
	}

	private void FixedUpdate()
	{
		berryParticles.transform.LookAt(Vector3.up);
	}

	private void InitialSetup()
	{
		ResetStoredBerryTiers();
		berryParticles_Main = berryParticles.main;
		berriesToNextSeedDrop = 0;
		berriesGrindedSinceLastSmoothieDrop = 0;
		nextSmoothieValue = 0L;
		nextSmoothie_StoredHolePrestigeJuice = 0;
		UpdateFillUI();
	}

	private void SpawnSmoothie()
	{
		Berry component = UnityEngine.Object.Instantiate(GameManager.Singleton.prefabBank.smoothie_Prefab, base.transform.position + Vector3.up * smoothieSpawnUpwardOffset, Quaternion.identity).GetComponent<Berry>();
		PickUppable component2 = component.GetComponent<PickUppable>();
		component.smoothieCombinedPayout = nextSmoothieValue;
		component2.coinValue = 0;
		component2.smoothie_holePrestigeJuice = 0;
		Debug.Log("Total Prestinge Juice Of Smoothie: " + component2.smoothie_holePrestigeJuice);
		component2.JUICED_amt = nextSmoothie_StoredHolePrestigeJuice;
		Rigidbody component3 = component.gameObject.GetComponent<Rigidbody>();
		component3.linearVelocity = Vector3.zero;
		component3.AddForce(base.transform.forward * GameManager.Singleton.SmoothieSpawn_Force_Direction.z + Vector3.up * GameManager.Singleton.SmoothieSpawn_Force_Direction.y * GameManager.Singleton.SmoothieSpawn_Force_Power, ForceMode.VelocityChange);
		component2.PlayImpactFeedback(_playSFX: true);
		component.smoothieLiquidRend.material.SetColor("_Color1", smoothieColor1);
		component.smoothieLiquidRend.material.SetColor("_Color2", smoothieColor2);
		for (int i = 0; i < storedBerryTiers.Count; i++)
		{
			component.smoothieBerryTiers[i] = storedBerryTiers[i];
		}
		nextSmoothieValue = 0L;
		berriesGrindedSinceLastSmoothieDrop = 0;
		nextSmoothie_StoredHolePrestigeJuice = 0;
		ResetStoredBerryTiers();
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 9)
		{
			enteredBerryScript = other.transform.root.gameObject.GetComponent<Berry>();
			if ((bool)enteredBerryScript && enteredBerryScript.berryTier != 100 && enteredBerryScript.berryTier != 12)
			{
				enteredBerryScript.CalculateCoinPayout();
				nextSmoothieValue += enteredBerryScript.GetPickUpScript().coinValue;
				nextSmoothie_StoredHolePrestigeJuice += enteredBerryScript.berryTier + 1;
				storedBerryTiers[enteredBerryScript.berryTier]++;
				IncreaseBerriesGrindedForSmoothieMaking();
				PlayBerryBlendParticles(enteredBerryScript.berryTier);
				UnityEngine.Object.Destroy(enteredBerryScript.gameObject);
				enteredBerryScript = null;
				feedback_GrindBerry?.PlayFeedbacks();
				AudioManager.Singleton.PlaySFX_ChainSawRev(base.transform.position);
				AudioManager.Singleton.PlaySFX_BerrySquish(base.transform.position);
			}
		}
	}

	private void IncreaseBerriesToNextSeed()
	{
		berriesToNextSeedDrop++;
	}

	private void CalculateGradientForSmoothieDrop()
	{
		int num = 0;
		int num2 = -1;
		int num3 = 0;
		int num4 = -1;
		int num5 = 0;
		int num6 = 0;
		foreach (int storedBerryTier in storedBerryTiers)
		{
			if (storedBerryTier > num)
			{
				num5 = num3;
				num3 = num;
				num4 = num2;
				num = storedBerryTier;
				num2 = num6;
			}
			else if (storedBerryTier > num3)
			{
				num5 = num3;
				num3 = storedBerryTier;
				num4 = num6;
			}
			else if (storedBerryTier > num5)
			{
				num5 = storedBerryTier;
			}
			num6++;
		}
		if (num2 != -1)
		{
			smoothieColor1 = GameManager.Singleton.prefabBank.BlenderBerryParticleColors[num2];
			if (num4 != -1)
			{
				smoothieColor2 = GameManager.Singleton.prefabBank.BlenderBerryParticleColors[num4];
			}
			else
			{
				smoothieColor2 = smoothieColor1;
			}
		}
		else
		{
			smoothieColor1 = Color.blue;
			smoothieColor2 = Color.blue;
		}
	}

	private void ResetStoredBerryTiers()
	{
		storedBerryTiers.Clear();
		for (int i = 0; i < 12; i++)
		{
			storedBerryTiers.Add(0);
		}
	}

	private void IncreaseBerriesGrindedForSmoothieMaking()
	{
		berriesGrindedSinceLastSmoothieDrop++;
		if (berriesGrindedSinceLastSmoothieDrop >= PlayerStats.Singleton.blender_BerryToSmoothieAmt)
		{
			CalculateGradientForSmoothieDrop();
			SpawnSmoothie();
		}
		UpdateFillUI();
	}

	private void UpdateFillUI()
	{
		fillIndicatorImage.fillAmount = (float)berriesGrindedSinceLastSmoothieDrop / (float)PlayerStats.Singleton.blender_BerryToSmoothieAmt;
		fillIndicatorImage.color = fillGradient.Evaluate(fillIndicatorImage.fillAmount);
	}

	private void PlayBerryBlendParticles(int _berryTier)
	{
		berryParticles_Main.startColor = GameManager.Singleton.prefabBank.BlenderBerryParticleColors[_berryTier];
		berryParticles.Play();
		particlePlayTime_Curr = particlePlayTime;
	}

	private void HandleParticlePlayTime()
	{
		if (berryParticles.isPlaying)
		{
			if (particlePlayTime_Curr > 0f)
			{
				particlePlayTime_Curr -= Time.deltaTime;
			}
			else
			{
				berryParticles.Stop();
			}
		}
	}
}
