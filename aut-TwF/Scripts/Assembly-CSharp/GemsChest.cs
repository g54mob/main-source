using System;
using System.Collections.Generic;
using UnityEngine;

public class GemsChest : MapObject, ISavable
{
	[SerializeField]
	private AudioData openChestAudioData;

	[SerializeField]
	private List<GemData> reward;

	private Animator animator;

	[SerializeField]
	private ParticleSystem beaconParticles;

	[Savable("alreadyUsed", true, false)]
	private bool alreadyUsed;

	public List<GemData> Reward
	{
		get
		{
			return reward;
		}
		set
		{
			reward = value;
		}
	}

	public bool AlreadyUsed => alreadyUsed;

	protected override void Awake()
	{
		base.Awake();
		animator = GetComponent<Animator>();
		beaconParticles?.Stop(withChildren: true, ParticleSystemStopBehavior.StopEmittingAndClear);
	}

	protected override void Start()
	{
		base.Start();
		LTGameManager lTGameManager = LTFunctionLibrary.GetLTGameManager();
		lTGameManager.onGameStarted = (Action)Delegate.Combine(lTGameManager.onGameStarted, new Action(OnGameStarted));
	}

	protected override void OnDestroy()
	{
		base.OnDestroy();
		if ((bool)LTFunctionLibrary.GetLTGameManager())
		{
			LTGameManager lTGameManager = LTFunctionLibrary.GetLTGameManager();
			lTGameManager.onGameStarted = (Action)Delegate.Remove(lTGameManager.onGameStarted, new Action(OnGameStarted));
		}
		if ((bool)LTFunctionLibrary.GetFogOfWarController())
		{
			LTFunctionLibrary.GetFogOfWarController().onFogOfWarUpdated -= OnFogOfWarUpdated;
		}
	}

	private void OnGameStarted()
	{
		LTFunctionLibrary.GetFogOfWarController().onFogOfWarUpdated += OnFogOfWarUpdated;
		OnFogOfWarUpdated(importantUpdate: false);
	}

	private void OnFogOfWarUpdated(bool importantUpdate)
	{
		if (placementComponent.IsVisible())
		{
			beaconParticles?.Play();
			LTFunctionLibrary.GetFogOfWarController().onFogOfWarUpdated -= OnFogOfWarUpdated;
		}
	}

	public void GetReward()
	{
		if (alreadyUsed)
		{
			return;
		}
		foreach (GemData item in Reward)
		{
			LTFunctionLibrary.GetPlayerData().AddGem(item);
		}
		AudioSystem.Instance.PlaySound2DOneShot(openChestAudioData, AudioSystem.EAudioMixerGroup.UI);
		alreadyUsed = true;
		beaconParticles.transform.SetParent(null);
		beaconParticles.Stop();
		ParticleSystem.MainModule main = beaconParticles.main;
		main.simulationSpeed = 3f;
		UnityEngine.Object.Destroy(beaconParticles.gameObject, 2f);
		animator.Play("Disappear");
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
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}
}
