using System;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

public class PerkBeacon : ResourceActivatedBuilding
{
	[Header("Perk Beacon")]
	[SerializeField]
	private int tier;

	[SerializeField]
	private GameObject ring;

	[SerializeField]
	private GameObject smallCrystals;

	[SerializeField]
	private GameObject crystalStone;

	[SerializeField]
	private LightAnimation[] lightAnimations;

	[SerializeField]
	private AudioData activationSound;

	private Vector3 crystalStoneStartPosition;

	private Vector3 ringStartPosition;

	public int Tier => tier;

	protected override void Start()
	{
		base.Start();
		crystalStoneStartPosition = crystalStone.transform.position;
		ringStartPosition = ring.transform.position;
		LoadRecipesFromPool(2);
	}

	public void LoadRecipesFromPool(int recipesToLoad)
	{
		base.Recipes.Clear();
		WeightedRandomSelector<ResourceActivatedGEData> recipesPool = GetRecipesPool();
		int num = 0;
		while (num < recipesToLoad)
		{
			ResourceActivatedGEData randomElement = recipesPool.GetRandomElement();
			if (!base.Recipes.Contains(randomElement))
			{
				base.Recipes.Add(randomElement);
				num++;
			}
		}
	}

	private WeightedRandomSelector<ResourceActivatedGEData> GetRecipesPool()
	{
		if (tier == 0)
		{
			return LTFunctionLibrary.GetLTLevelController().PerkBeaconsRecipesT1;
		}
		if (tier == 1)
		{
			return LTFunctionLibrary.GetLTLevelController().PerkBeaconsRecipesT2;
		}
		return LTFunctionLibrary.GetLTLevelController().PerkBeaconsRecipesT3;
	}

	protected override void OnActivate(bool playAnimation = true)
	{
		base.OnActivate();
		float num = 6f;
		float duration = 2f;
		float crystalStoneHeight = 0.25f;
		float duration2 = 3f;
		float duration3 = 30f;
		float crystalStoneFloatingDistance = 0.075f;
		float crystalStoneFloatingTime = 3f;
		float ringHeight = 1.484f;
		float duration4 = 3f;
		float ringFloatingDistance = 0.15f;
		if (base.CurrentDuration > 0f || !playAnimation)
		{
			smallCrystals.GetComponent<Renderer>().material.SetFloat("_EmissionIntensity", num);
			for (int i = 0; i < lightAnimations.Length; i++)
			{
				lightAnimations[i].TurnOn(0f);
			}
			ring.transform.DOMoveY(ringStartPosition.y + ringHeight, 0f).SetEase(Ease.OutCubic);
			crystalStone.transform.DORotate(Vector3.up * 360f, duration3, RotateMode.WorldAxisAdd).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = crystalStone.transform.DOMoveY(crystalStoneStartPosition.y + crystalStoneHeight, 0f).SetEase(Ease.OutCubic);
			tweenerCore.onComplete = (TweenCallback)Delegate.Combine(tweenerCore.onComplete, (TweenCallback)delegate
			{
				crystalStone.transform.DOMoveY(crystalStoneStartPosition.y + crystalStoneHeight - crystalStoneFloatingDistance, crystalStoneFloatingTime).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
				ring.transform.DOMoveY(ringStartPosition.y + ringHeight - ringFloatingDistance, crystalStoneFloatingTime).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo)
					.SetDelay(0.75f);
			});
			return;
		}
		DOTween.Kill(crystalStone.transform);
		DOTween.Kill(ring.transform);
		AudioSystem.Instance.PlaySound3D(activationSound, base.transform.position, AudioSystem.EAudioMixerGroup.SFX, AudioRolloffMode.Custom, 1f, 50f, null, 0f, 0f, loop: false, 0f, AudioSystem.EAudioPriority.High);
		smallCrystals.GetComponent<Renderer>().material.DOFloat(num, "_EmissionIntensity", duration).SetEase(Ease.OutSine);
		for (int num2 = 0; num2 < lightAnimations.Length; num2++)
		{
			lightAnimations[num2].TurnOn();
		}
		ring.transform.DOMoveY(ringStartPosition.y + ringHeight, duration4).SetEase(Ease.OutCubic);
		crystalStone.transform.DORotate(Vector3.up * 360f, duration3, RotateMode.WorldAxisAdd).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2 = crystalStone.transform.DOMoveY(crystalStoneStartPosition.y + crystalStoneHeight, duration2).SetEase(Ease.OutCubic);
		tweenerCore2.onComplete = (TweenCallback)Delegate.Combine(tweenerCore2.onComplete, (TweenCallback)delegate
		{
			crystalStone.transform.DOMoveY(crystalStoneStartPosition.y + crystalStoneHeight - crystalStoneFloatingDistance, crystalStoneFloatingTime).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
			ring.transform.DOMoveY(ringStartPosition.y + ringHeight - ringFloatingDistance, crystalStoneFloatingTime).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo)
				.SetDelay(0.75f);
		});
	}

	protected override void OnDeactivate()
	{
		base.OnDeactivate();
		float duration = 2f;
		float duration2 = 3f;
		float duration3 = 4f;
		smallCrystals.GetComponent<Renderer>().material.DOFloat(0f, "_EmissionIntensity", duration).SetEase(Ease.OutSine);
		for (int i = 0; i < lightAnimations.Length; i++)
		{
			lightAnimations[i].TurnOff();
		}
		DOTween.Kill(crystalStone.transform);
		DOTween.Kill(ring.transform);
		ring.transform.DOMoveY(ringStartPosition.y, duration3).SetEase(Ease.OutCubic);
		crystalStone.transform.DOMoveY(crystalStoneStartPosition.y, duration2).SetEase(Ease.OutCubic);
	}
}
