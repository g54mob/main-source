using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using SmoothShakeFree;
using UnityEngine;

public class Beacon_01 : CircleBeacon
{
	[Header("Activation animation")]
	[SerializeField]
	private GameObject lightSphere;

	[SerializeField]
	private GameObject lightsContainer;

	[SerializeField]
	private ParticleSystem startingSpherePS;

	[SerializeField]
	private ParticleSystem startingSphereSparksPS;

	[SerializeField]
	private ParticleSystem flarePS;

	[SerializeField]
	private ParticleSystem shockwavePS;

	[SerializeField]
	private float floatingLightSphereStartHeight;

	[SerializeField]
	private float floatingLightSphereEndHeight;

	[SerializeField]
	private float floatingLightSphereTime;

	[SerializeField]
	private Renderer crystalsRenderer;

	[SerializeField]
	[ColorUsage(true, true)]
	private Color crystalsColor;

	[SerializeField]
	private List<GameObject> crystalsPS;

	[SerializeField]
	private SmoothShakeFreePreset shakePrest;

	[SerializeField]
	private AudioData activationSound;

	private Coroutine activationAnimationCoroutine;

	protected override void Awake()
	{
		base.Awake();
		crystalsRenderer.material.EnableKeyword("_EMISSION");
		crystalsRenderer.material.SetColor("_EmissionColor", Color.black);
	}

	protected override void OnPlace(PlacementComponent component)
	{
		this.StartCoroutineCheckingVar(ActivationAnimationCoroutine(), ref activationAnimationCoroutine);
	}

	private IEnumerator ActivationAnimationCoroutine()
	{
		yield return null;
		if (hasBeenActivated)
		{
			Object.Instantiate(fowAreaPrefab, placementComponent.GetCenter() + Vector3.up * 5f, Quaternion.identity, base.transform).transform.localScale = Vector3.one * radius;
			crystalsRenderer.material.EnableKeyword("_EMISSION");
			crystalsRenderer.material.SetColor("_EmissionColor", Color.black);
			crystalsRenderer.material.SetColor("_EmissionColor", crystalsColor);
			crystalsPS.ForEach(delegate(GameObject x)
			{
				x.SetActive(value: true);
			});
			lightSphere.SetActive(value: true);
			lightSphere.transform.DOLocalMoveY(floatingLightSphereEndHeight, floatingLightSphereTime * 0.3f).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
			lightsContainer.SetActive(value: true);
			FogOfWarController.instance.UpdateFogOfWar();
			yield break;
		}
		hasBeenActivated = true;
		float num = 2f;
		float startingSphereTime = 2f;
		float flareTime = 0.8f;
		float revealAreaTime = 2.25f;
		Material crystalsMaterial = crystalsRenderer.material;
		lightsContainer.gameObject.SetActive(value: false);
		lightSphere.gameObject.SetActive(value: false);
		lightSphere.transform.localPosition = Vector3.up * floatingLightSphereStartHeight;
		crystalsMaterial.EnableKeyword("_EMISSION");
		crystalsMaterial.SetColor("_EmissionColor", Color.black);
		crystalsPS.ForEach(delegate(GameObject x)
		{
			x.SetActive(value: false);
		});
		GameObject fowArea = Object.Instantiate(fowAreaPrefab, placementComponent.GetCenter() + Vector3.up * 5f, Quaternion.identity, base.transform);
		fowArea.transform.localScale = Vector3.one * num;
		FogOfWarController.instance.UpdateFogOfWar();
		AudioSystem.Instance.PlaySound3D(activationSound, lightSphere.transform.position, AudioSystem.EAudioMixerGroup.SFX);
		ParticleSystem.MainModule main = startingSpherePS.main;
		main.duration = startingSphereTime;
		main.startLifetime = startingSphereTime;
		ParticleSystem.MainModule main2 = startingSphereSparksPS.main;
		main2.duration = startingSphereTime * 0.75f;
		startingSpherePS.Play();
		startingSphereSparksPS.Play();
		crystalsMaterial.DOColor(crystalsColor * 0.035f, "_EmissionColor", startingSphereTime * 0.9f).SetEase(Ease.InQuart).OnComplete(delegate
		{
			crystalsMaterial.DOColor(Color.black, "_EmissionColor", startingSphereTime * 0.1f + flareTime * 0.5f);
		});
		yield return new WaitForSeconds(startingSphereTime);
		flarePS.Play();
		yield return new WaitForSeconds(flareTime);
		float timer = 0f;
		fowArea.transform.DOScale(Vector3.one * radius, revealAreaTime).SetEase(Ease.OutExpo);
		shockwavePS.transform.localScale = Vector3.one * radius * 0.1f;
		ParticleSystem.MainModule main3 = shockwavePS.main;
		main3.startLifetime = revealAreaTime;
		shockwavePS.Play();
		crystalsMaterial.DOColor(crystalsColor, "_EmissionColor", revealAreaTime * 0.5f).SetEase(Ease.OutQuad);
		crystalsPS.ForEach(delegate(GameObject x)
		{
			x.SetActive(value: true);
		});
		lightSphere.SetActive(value: true);
		lightSphere.transform.localScale = Vector3.zero;
		lightSphere.transform.DOScale(Vector3.one, 0.25f).SetEase(Ease.OutBack);
		lightSphere.transform.DOLocalMoveY(floatingLightSphereEndHeight, floatingLightSphereTime * 0.3f).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
		lightsContainer.SetActive(value: true);
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
