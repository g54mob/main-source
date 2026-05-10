using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using SmoothShakeFree;
using UnityEngine;

public class BossVictoryAnimation : MonoBehaviour
{
	[SerializeField]
	private AudioData victoryMusic;

	[SerializeField]
	private float victoryMusicDelay;

	[SerializeField]
	private float cameraMovementMaxSpeed = 10f;

	[SerializeField]
	private float cameraZoom = 0.5f;

	[Header("Boss levitate")]
	[SerializeField]
	[Tooltip("Tiempo que pasa desde que la cámara se centra en el boss hasta que empieza a levitar")]
	private float bossLevitateDelay = 1f;

	[SerializeField]
	[Tooltip("Tiempo que tarda en levitar el boss")]
	private float bossLevitateTime = 0.25f;

	[SerializeField]
	private float bossLevitateHeight = 1f;

	[Header("Light Rays")]
	[SerializeField]
	private GameObject lightRaysPrefab;

	[SerializeField]
	private float lightRaysDelay = 1f;

	[Header("Emissive Mat")]
	[SerializeField]
	[ColorUsage(false, true)]
	private Color emissionColor;

	[SerializeField]
	private float emissionDelay;

	[SerializeField]
	private float emissionTime = 1f;

	[SerializeField]
	private AudioData emissionSound;

	[SerializeField]
	private SmoothShakeFreePreset emissionShakePreset;

	[Header("Swelling")]
	[SerializeField]
	private Vector3 swellingScale;

	[SerializeField]
	private float swellingNormalizedTime;

	[Header("Explosion")]
	[SerializeField]
	private GameObject explosionPSPrefab;

	[SerializeField]
	private GameObject lightRingPSPrefab;

	[SerializeField]
	private SmoothShakeFreePreset explosionShakePreset;

	[Header("Ending")]
	[SerializeField]
	private float showEndGameUIDelay = 1f;

	private Coroutine bossVictoryAnimationCoroutine;

	public event Action onVictoryAnimationEnded;

	public void PlayVictoryAnimation(Enemy boss)
	{
		this.StartCoroutineCheckingVar(BossVictoryAnimationCoroutine(boss), ref bossVictoryAnimationCoroutine);
	}

	private IEnumerator BossVictoryAnimationCoroutine(Enemy boss)
	{
		LTPlayerController playerController = LTFunctionLibrary.GetLTPlayerController();
		playerController.LTHUD.ShowEndGameAnimationUI();
		LTFunctionLibrary.GetLTGameManager().ShowGrid(show: false, LTGameManager.EShowGridMode.Full);
		AudioSource audioSource = AudioSystem.Instance.PlaySound2D(victoryMusic, AudioSystem.EAudioMixerGroup.Music, 0f, victoryMusicDelay, loop: false, AudioSystem.EAudioPriority.High);
		audioSource.volume = 0f;
		AudioSystem.Instance.FadeAudioSource(audioSource, victoryMusic.Volume, 1f, unscaledDeltaTime: false, victoryMusicDelay);
		Character controlledCharacter = playerController.ControlledCharacter;
		Vector3 vector = boss.transform.position + (-boss.transform.forward - boss.transform.right).normalized * 3f;
		float num = Vector3.Distance(controlledCharacter.transform.position, vector) / cameraMovementMaxSpeed;
		controlledCharacter.transform.DOMove(vector, num).SetEase(Ease.OutSine);
		playerController.CurrentCameraZoom = cameraZoom;
		float cameraRotation = playerController.PlayerCamera.transform.rotation.eulerAngles.y;
		TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(() => cameraRotation, delegate(float x)
		{
			cameraRotation = x;
		}, 225f + boss.transform.rotation.eulerAngles.y, Mathf.Min(0.4f, num)).SetEase(Ease.OutSine);
		tweenerCore.onUpdate = (TweenCallback)Delegate.Combine(tweenerCore.onUpdate, (TweenCallback)delegate
		{
			playerController.SetCameraRotation(cameraRotation);
		});
		boss.animator.speed = 0f;
		yield return new WaitForSeconds(num);
		yield return new WaitForSeconds(bossLevitateDelay);
		boss.transform.DOLocalMoveY(base.transform.position.y + bossLevitateHeight, bossLevitateTime).SetEase(Ease.OutSine);
		boss.transform.DORotate(base.transform.rotation.eulerAngles + new Vector3(0f, 90f, 0f), bossLevitateTime, RotateMode.WorldAxisAdd).SetEase(Ease.InSine);
		yield return new WaitForSeconds(lightRaysDelay);
		List<ParticleSystem> lightRaysParticles = new List<ParticleSystem>();
		SkinnedMeshRenderer[] skinnedMeshRenderers = boss.GetComponentsInChildren<SkinnedMeshRenderer>();
		MeshRenderer[] meshRenderers = boss.GetComponentsInChildren<MeshRenderer>();
		SkinnedMeshRenderer[] array = skinnedMeshRenderers;
		foreach (SkinnedMeshRenderer skinnedMeshRenderer in array)
		{
			ParticleSystem component = UnityEngine.Object.Instantiate(lightRaysPrefab, boss.transform.position, Quaternion.identity).GetComponent<ParticleSystem>();
			lightRaysParticles.Add(component);
			ParticleSystem.MainModule main = component.main;
			main.duration = emissionTime + emissionDelay;
			ParticleSystem.ShapeModule shape = component.shape;
			shape.shapeType = ParticleSystemShapeType.SkinnedMeshRenderer;
			shape.skinnedMeshRenderer = skinnedMeshRenderer;
			component.Play();
		}
		yield return new WaitForSeconds(emissionDelay);
		array = skinnedMeshRenderers;
		for (int num2 = 0; num2 < array.Length; num2++)
		{
			array[num2].material.DOColor(emissionColor, "_Emission", emissionTime).SetEase(Ease.InSine);
		}
		MeshRenderer[] array2 = meshRenderers;
		for (int num2 = 0; num2 < array2.Length; num2++)
		{
			array2[num2].material.DOColor(emissionColor, "_Emission", emissionTime).SetEase(Ease.InSine);
		}
		AudioSystem.Instance.PlaySound3D(emissionSound, boss.transform.position, AudioSystem.EAudioMixerGroup.SFX, AudioRolloffMode.Logarithmic, 8f, 500f, null, 0f, 0f, loop: false, 0f, AudioSystem.EAudioPriority.High);
		playerController.ShakeCamera(emissionShakePreset);
		if (swellingNormalizedTime > 0f)
		{
			boss.transform.DOScale(swellingScale, emissionTime * swellingNormalizedTime).SetDelay(emissionTime - emissionTime * swellingNormalizedTime).SetEase(Ease.InSine);
		}
		yield return new WaitForSeconds(emissionTime);
		UnityEngine.Object.Instantiate(lightRingPSPrefab, boss.CombatComponent.TargetObject.transform.position, Quaternion.identity).GetComponent<ParticleSystem>().Play();
		array = skinnedMeshRenderers;
		foreach (SkinnedMeshRenderer skinnedMeshRenderer2 in array)
		{
			ParticleSystem component2 = UnityEngine.Object.Instantiate(explosionPSPrefab, boss.transform.position, Quaternion.identity).GetComponent<ParticleSystem>();
			ParticleSystem.ShapeModule shape2 = component2.shape;
			shape2.shapeType = ParticleSystemShapeType.SkinnedMeshRenderer;
			shape2.skinnedMeshRenderer = skinnedMeshRenderer2;
			ParticleSystem.Burst burst = component2.emission.GetBurst(0);
			burst.count = burst.count.constant / (float)skinnedMeshRenderers.Length;
			component2.emission.SetBurst(0, burst);
			component2.Play();
		}
		foreach (ParticleSystem item in lightRaysParticles)
		{
			item.Stop(withChildren: true, ParticleSystemStopBehavior.StopEmittingAndClear);
		}
		playerController.ShakeCamera(explosionShakePreset);
		boss.gameObject.SetActive(value: false);
		yield return new WaitForSeconds(showEndGameUIDelay);
		this.onVictoryAnimationEnded?.Invoke();
	}
}
