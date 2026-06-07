using System.Collections;
using DG.Tweening;
using UnityEngine;

public class Beacon_02 : CircleBeacon
{
	[Header("Activation animation")]
	[SerializeField]
	private float startDelay = 1f;

	[SerializeField]
	private float fowAreaDelay = 1f;

	[SerializeField]
	private float revealAreaTime = 2f;

	[SerializeField]
	private ParticleSystem sparksPS;

	[SerializeField]
	private ParticleSystem firePS;

	[SerializeField]
	private ParticleSystem explosionPS;

	[SerializeField]
	private Light pointLight;

	[SerializeField]
	private AudioData activationSound;

	[SerializeField]
	private AudioSource fireCrackingAS;

	private Coroutine activationAnimationCoroutine;

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
			ParticleSystem.MainModule main = firePS.main;
			main.startDelay = 0f;
			firePS.Play();
			pointLight.gameObject.SetActive(value: true);
			float volume = fireCrackingAS.volume;
			fireCrackingAS.volume = 0f;
			fireCrackingAS.outputAudioMixerGroup = AudioSystem.Instance.GetAudioMixerConfig(AudioSystem.EAudioMixerGroup.SFX).mixer;
			fireCrackingAS.loop = true;
			fireCrackingAS.Play();
			fireCrackingAS.DOFade(volume, 1f);
			FogOfWarController.instance.UpdateFogOfWar();
			yield break;
		}
		hasBeenActivated = true;
		float num = 1.5f;
		float pointLightIntensity = pointLight.intensity;
		GameObject fowArea = Object.Instantiate(fowAreaPrefab, placementComponent.GetCenter() + Vector3.up * 5f, Quaternion.identity, base.transform);
		fowArea.transform.localScale = Vector3.one * num;
		FogOfWarController.instance.UpdateFogOfWar();
		yield return new WaitForSeconds(startDelay);
		AudioSystem.Instance.PlaySound3D(activationSound, base.transform.position + Vector3.up * 1f, AudioSystem.EAudioMixerGroup.SFX);
		sparksPS.Play();
		firePS.Play();
		explosionPS.Play();
		yield return new WaitForSeconds(fowAreaDelay);
		pointLight.intensity = 0f;
		pointLight.gameObject.SetActive(value: true);
		pointLight.DOIntensity(pointLightIntensity, 1f);
		float volume2 = fireCrackingAS.volume;
		fireCrackingAS.volume = 0f;
		fireCrackingAS.outputAudioMixerGroup = AudioSystem.Instance.GetAudioMixerConfig(AudioSystem.EAudioMixerGroup.SFX).mixer;
		fireCrackingAS.loop = true;
		fireCrackingAS.Play();
		fireCrackingAS.DOFade(volume2, 1f);
		float timer = 0f;
		fowArea.transform.DOScale(Vector3.one * radius, revealAreaTime).SetEase(Ease.OutExpo);
		while (timer <= revealAreaTime)
		{
			timer += Time.deltaTime;
			FogOfWarController.instance.UpdateFogOfWar(importantUpdate: false);
			yield return null;
		}
		FogOfWarController.instance.UpdateFogOfWar();
	}
}
