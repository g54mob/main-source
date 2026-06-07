using System.Collections;
using DG.Tweening;
using SmoothShakeFree;
using UnityEngine;

public class Beacon_04 : CircleBeacon
{
	[Header("Objects")]
	[SerializeField]
	private GameObject[] wings;

	[SerializeField]
	private GameObject gear;

	[SerializeField]
	private GameObject crystal;

	[SerializeField]
	private GameObject smallCrystals;

	[Header("Particles")]
	[SerializeField]
	private ParticleSystem warmUpSparksPS;

	[SerializeField]
	private ParticleSystem shockwavePS;

	[SerializeField]
	private ParticleSystem crystalGlowPS;

	[Header("Lights")]
	[SerializeField]
	private Light crystalPointLight;

	[SerializeField]
	private Light[] smallPointLights;

	[Header("Camera Shake")]
	[SerializeField]
	private SmoothShakeFreePreset shakePrest;

	[Header("Audio")]
	[SerializeField]
	private AudioData activationSound;

	private Coroutine activationAnimationCoroutine;

	protected override void Awake()
	{
		base.Awake();
		smallCrystals.GetComponent<Renderer>().material.SetFloat("_EmissionIntensity", 0f);
		crystalPointLight.intensity = 0f;
		Light[] array = smallPointLights;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].intensity = 0f;
		}
	}

	protected override void OnPlace(PlacementComponent component)
	{
		this.StartCoroutineCheckingVar(ActivationAnimationCoroutine(), ref activationAnimationCoroutine);
	}

	private IEnumerator ActivationAnimationCoroutine()
	{
		yield return null;
		Light[] array;
		if (hasBeenActivated)
		{
			float endValue = 4.03f;
			float endValue2 = 4.1f;
			Object.Instantiate(fowAreaPrefab, placementComponent.GetCenter() + Vector3.up * 5f, Quaternion.identity, base.transform).transform.localScale = Vector3.one * radius;
			wings[0].transform.DOLocalRotate(Vector3.right * 70f, 0f);
			wings[1].transform.DOLocalRotate(Vector3.forward * 70f, 0f);
			wings[2].transform.DOLocalRotate(Vector3.right * -70f, 0f);
			wings[3].transform.DOLocalRotate(Vector3.forward * -70f, 0f);
			GameObject gameObject = new GameObject("CrystalContainer");
			gameObject.transform.parent = crystal.transform.parent;
			gameObject.transform.position = crystal.transform.position;
			crystal.transform.parent = gameObject.transform;
			for (int num = crystal.transform.childCount - 1; num >= 0; num--)
			{
				crystal.transform.GetChild(num).SetParent(crystal.transform.parent);
			}
			crystal.transform.DORotate(Vector3.up * 360f, 8f, RotateMode.WorldAxisAdd).SetEase(Ease.Linear).SetLoops(-1, LoopType.Restart);
			gameObject.transform.DOLocalMoveY(endValue, 0f);
			gameObject.transform.DOLocalMoveY(endValue2, 3f).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
			smallCrystals.GetComponent<Renderer>().material.SetFloat("_EmissionIntensity", 5.65f);
			array = smallPointLights;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].intensity = 0.5f;
			}
			crystalGlowPS.Play(withChildren: true);
			crystalPointLight.intensity = 2f;
			FogOfWarController.instance.UpdateFogOfWar();
			yield break;
		}
		hasBeenActivated = true;
		float seconds = 0.5f;
		float num2 = 2f;
		float revealAreaTime = 2.25f;
		float gearRotation = -720f;
		float crystalExplosionHeight = 4.22f;
		float crystalMinFinalHeight = 4.03f;
		float crystalMaxFinalHeight = 4.1f;
		float timer = 0f;
		GameObject fowArea = Object.Instantiate(fowAreaPrefab, placementComponent.GetCenter() + Vector3.up * 5f, Quaternion.identity, base.transform);
		fowArea.transform.localScale = Vector3.one * num2;
		FogOfWarController.instance.UpdateFogOfWar();
		yield return new WaitForSeconds(seconds);
		wings[0].transform.DOLocalRotate(Vector3.right * 70f, 1.5f).SetEase(Ease.InOutSine);
		wings[1].transform.DOLocalRotate(Vector3.forward * 70f, 1.5f).SetEase(Ease.InOutSine).SetDelay(0.32f);
		wings[2].transform.DOLocalRotate(Vector3.right * -70f, 1.5f).SetEase(Ease.InOutSine).SetDelay(0.16f);
		wings[3].transform.DOLocalRotate(Vector3.forward * -70f, 1.5f).SetEase(Ease.InOutSine).SetDelay(0.39f);
		gear.transform.DORotate(Vector3.up * gearRotation, 3.5f, RotateMode.WorldAxisAdd).SetEase(Ease.InQuint).SetDelay(0.5f);
		GameObject crystalContainer = new GameObject("CrystalContainer");
		crystalContainer.transform.parent = crystal.transform.parent;
		crystalContainer.transform.position = crystal.transform.position;
		crystal.transform.parent = crystalContainer.transform;
		crystal.transform.localScale = Vector3.one * 0.75f;
		crystal.transform.DOScale(Vector3.one * 0.9f, 2f).SetDelay(2f);
		crystalContainer.transform.DOLocalMoveY(crystalExplosionHeight, 3f).SetEase(Ease.InSine).SetDelay(1f);
		Sequence sequence = DOTween.Sequence();
		int num3 = 5;
		float duration = 2f / (float)num3;
		for (int j = 1; j <= num3; j++)
		{
			float num4 = (float)j / (float)num3 * 0.02f;
			sequence.Append(crystal.transform.DOShakePosition(duration, new Vector3(1f, 0f, 1f) * num4, 100, 90f, snapping: false, fadeOut: false));
		}
		sequence.SetDelay(2f).Play();
		smallCrystals.GetComponent<Renderer>().material.DOFloat(5.65f, "_EmissionIntensity", 3f).SetDelay(1f).SetEase(Ease.InExpo);
		ParticleSystem.MainModule main = warmUpSparksPS.main;
		main.startDelay = 2f;
		warmUpSparksPS.Play();
		crystalPointLight.DOIntensity(4f, 4f);
		array = smallPointLights;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].DOIntensity(0.5f, 3f).SetDelay(1f).SetEase(Ease.InExpo);
		}
		yield return new WaitForSeconds(1.6f);
		AudioSystem.Instance.PlaySound3D(activationSound, crystal.transform.position, AudioSystem.EAudioMixerGroup.SFX);
		yield return new WaitForSeconds(2.4f);
		for (int num5 = crystal.transform.childCount - 1; num5 >= 0; num5--)
		{
			crystal.transform.GetChild(num5).SetParent(crystal.transform.parent);
		}
		crystal.transform.DOScale(Vector3.one, 0.25f).SetEase(Ease.OutBack);
		crystal.transform.DORotate(Vector3.up * 360f, 8f, RotateMode.WorldAxisAdd).SetEase(Ease.Linear).SetLoops(-1, LoopType.Restart);
		crystalContainer.transform.DOLocalMoveY(crystalMinFinalHeight, 3f).SetEase(Ease.OutSine);
		crystalContainer.transform.DOLocalMoveY(crystalMaxFinalHeight, 3f).SetDelay(3f).SetEase(Ease.InOutSine)
			.SetLoops(-1, LoopType.Yoyo);
		shockwavePS.transform.localScale = Vector3.one * radius * 0.1f;
		ParticleSystem.MainModule main2 = shockwavePS.main;
		main2.startLifetime = revealAreaTime;
		shockwavePS.Play();
		crystalGlowPS.Play(withChildren: true);
		crystalPointLight.intensity = 20f;
		crystalPointLight.DOIntensity(2f, 3f).SetEase(Ease.OutExpo);
		fowArea.transform.DOScale(Vector3.one * radius, revealAreaTime).SetEase(Ease.OutExpo);
		LTFunctionLibrary.GetLTPlayerController().ShakeCameraFromPosition(base.transform.position, 1f, shakePrest);
		while (timer <= revealAreaTime)
		{
			timer += Time.deltaTime;
			FogOfWarController.instance.UpdateFogOfWar(importantUpdate: false);
			yield return null;
		}
		FogOfWarController.instance.UpdateFogOfWar();
	}
}
