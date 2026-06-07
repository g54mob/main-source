using System;
using System.Collections;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using SmoothShakeFree;
using UnityEngine;

public class VictoryAnimation : MonoBehaviour
{
	[SerializeField]
	private AudioData victoryMusic;

	[SerializeField]
	private float victoryMusicDelay;

	[SerializeField]
	private float cameraMovementMaxSpeed = 10f;

	[Header("Crystal fall")]
	[SerializeField]
	[Tooltip("Tiempo que pasa desde que la cámara se centra en la torre enemiga hasta que empiezan a caer los cristales")]
	private float crystalFallDelay = 1f;

	[SerializeField]
	[Tooltip("Tiempo que tarda en caer cada cristal")]
	private float crystalFallTime = 0.25f;

	[SerializeField]
	private Vector2 minMaxTimeBetweenCrystalFall = Vector2.one;

	[SerializeField]
	private AudioData crystalFallSound;

	[SerializeField]
	private SmoothShakeFreePreset crystalFallShakePreset;

	[Header("Explosion")]
	[SerializeField]
	private float crystalChangeColorDelay = 1f;

	[SerializeField]
	private float crystalChangeColorTime = 1f;

	[SerializeField]
	[ColorUsage(false, true)]
	private Color startCrystalColor;

	[SerializeField]
	[ColorUsage(false, true)]
	private Color endCrystalColor;

	[SerializeField]
	private AudioData crystalChargeSound;

	[SerializeField]
	private AudioData explosionSound;

	[SerializeField]
	private SmoothShakeFreePreset crystalChangeColorShakePreset;

	[SerializeField]
	private SmoothShakeFreePreset explosionShakePreset;

	[Header("Ending")]
	[SerializeField]
	private float purpleCrystalFallDelay = 1f;

	[SerializeField]
	private float purpleCrystalFallTime = 1f;

	[SerializeField]
	private AudioData purpleCrystalFallSound;

	[SerializeField]
	private float showEndGameUITime = 1f;

	private Material victoryCrystalsMaterial;

	private Coroutine victoryAnimationCoroutine;

	public event Action onVictoryAnimationEnded;

	public void PlayVictoryAnimation()
	{
		this.StartCoroutineCheckingVar(VictoryAnimationCoroutine(), ref victoryAnimationCoroutine);
	}

	private IEnumerator VictoryAnimationCoroutine()
	{
		LTPlayerController playerController = LTFunctionLibrary.GetLTPlayerController();
		playerController.LTHUD.ShowEndGameAnimationUI();
		LTFunctionLibrary.GetLTGameManager().ShowGrid(show: false, LTGameManager.EShowGridMode.Full);
		AudioSource audioSource = AudioSystem.Instance.PlaySound2D(victoryMusic, AudioSystem.EAudioMixerGroup.Music, 0f, victoryMusicDelay, loop: false, AudioSystem.EAudioPriority.High);
		audioSource.volume = 0f;
		AudioSystem.Instance.FadeAudioSource(audioSource, victoryMusic.Volume, 1f, unscaledDeltaTime: false, victoryMusicDelay);
		Character controlledCharacter = playerController.ControlledCharacter;
		EnemyTower enemyTower = LTFunctionLibrary.GetLTGameManager().EnemyTower;
		GameObject[] crystals = enemyTower.VictoryAnimationCrystals;
		victoryCrystalsMaterial = new Material(enemyTower.VictoryAnimationCrystals[0].GetComponent<MeshRenderer>().material);
		victoryCrystalsMaterial.SetColor("_EmissionColor", startCrystalColor);
		GameObject[] array = crystals;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].GetComponent<MeshRenderer>().material = victoryCrystalsMaterial;
		}
		Vector3 vector = enemyTower.transform.position + (-enemyTower.transform.forward - enemyTower.transform.right).normalized * 3f;
		float num = Vector3.Distance(controlledCharacter.transform.position, vector) / cameraMovementMaxSpeed;
		controlledCharacter.transform.DOMove(vector, num).SetEase(Ease.OutSine);
		playerController.ResetCameraZoom();
		float cameraRotation = playerController.PlayerCamera.transform.rotation.eulerAngles.y;
		TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(() => cameraRotation, delegate(float x)
		{
			cameraRotation = x;
		}, 225f + enemyTower.transform.rotation.eulerAngles.y, Mathf.Min(0.4f, num)).SetEase(Ease.OutSine);
		tweenerCore.onUpdate = (TweenCallback)Delegate.Combine(tweenerCore.onUpdate, (TweenCallback)delegate
		{
			playerController.SetCameraRotation(cameraRotation);
		});
		yield return new WaitForSeconds(num);
		yield return new WaitForSeconds(crystalFallDelay);
		int fellCrystalsAmount = 0;
		for (int num2 = 0; num2 < crystals.Length; num2++)
		{
			crystals[num2].transform.localPosition = Vector3.forward * 20f;
			crystals[num2].gameObject.SetActive(value: true);
			float delay = (float)num2 * UnityEngine.Random.Range(minMaxTimeBetweenCrystalFall.x, minMaxTimeBetweenCrystalFall.y);
			AudioSystem.Instance.PlaySound3D(crystalFallSound, crystals[num2].transform.parent.position, AudioSystem.EAudioMixerGroup.SFX, AudioRolloffMode.Logarithmic, 1f, 500f, null, 0f, 0f, loop: false, delay, AudioSystem.EAudioPriority.High);
			crystals[num2].transform.DOLocalMove(Vector3.zero, crystalFallTime).SetDelay(delay).OnComplete(delegate
			{
				playerController.ShakeCamera(crystalFallShakePreset);
				enemyTower.CrystalImpactPS[fellCrystalsAmount].Play();
				fellCrystalsAmount++;
			});
		}
		while (fellCrystalsAmount < crystals.Length)
		{
			yield return null;
		}
		yield return new WaitForSeconds(crystalChangeColorDelay);
		victoryCrystalsMaterial.DOColor(endCrystalColor, crystalChangeColorTime).SetEase(Ease.InSine);
		playerController.ShakeCamera(crystalChangeColorShakePreset);
		crystalChangeColorShakePreset.timeSettings.fadeInDuration = crystalChangeColorTime;
		AudioSystem.Instance.PlaySound3D(crystalChargeSound, enemyTower.VictoryAnimationCrystals[1].transform.position, AudioSystem.EAudioMixerGroup.SFX, AudioRolloffMode.Logarithmic, 8f, 500f, null, 0f, 0f, loop: false, 0f, AudioSystem.EAudioPriority.High);
		yield return new WaitForSeconds(crystalChangeColorTime);
		array = crystals;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].SetActive(value: false);
		}
		enemyTower.ExplosionPS.Play();
		AudioSystem.Instance.PlaySound3D(explosionSound, enemyTower.ExplosionPS.transform.position, AudioSystem.EAudioMixerGroup.SFX, AudioRolloffMode.Logarithmic, 8f, 500f, null, 0f, 0f, loop: false, 0f, AudioSystem.EAudioPriority.High);
		playerController.ShakeCamera(explosionShakePreset);
		yield return new WaitForSeconds(0.35f);
		enemyTower.MainModel.gameObject.SetActive(value: false);
		enemyTower.DestroyedModel.gameObject.SetActive(value: true);
		enemyTower.PurpleCrystal.transform.DOMoveY(0.5f, purpleCrystalFallTime).SetDelay(purpleCrystalFallDelay).SetEase(Ease.InSine);
		yield return new WaitForSeconds(purpleCrystalFallDelay + purpleCrystalFallTime);
		AudioSystem.Instance.PlaySound3D(purpleCrystalFallSound, enemyTower.PurpleCrystal.transform.position, AudioSystem.EAudioMixerGroup.SFX, AudioRolloffMode.Logarithmic, 8f, 500f, null, 0f, 0f, loop: false, 0f, AudioSystem.EAudioPriority.High);
		yield return new WaitForSeconds(showEndGameUITime);
		this.onVictoryAnimationEnded?.Invoke();
	}
}
