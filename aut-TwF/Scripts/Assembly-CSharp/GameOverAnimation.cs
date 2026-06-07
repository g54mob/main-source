using System;
using System.Collections;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using SmoothShakeFree;
using UnityEngine;

public class GameOverAnimation : MonoBehaviour
{
	[SerializeField]
	private AudioData defeatMusic;

	[SerializeField]
	private float defeatMusicDelay;

	[SerializeField]
	private float cameraMovementMaxSpeed = 10f;

	[Header("FirstLightnings")]
	[SerializeField]
	private AudioData firstLightningsSound;

	[SerializeField]
	private SmoothShakeFreePreset firstLightningsShakePreset;

	[SerializeField]
	private float firstLightningsDelay;

	[SerializeField]
	private float firstLightningsTime;

	[SerializeField]
	private Vector2 firstLightningsMinMaxBetweenTime;

	[Header("BigLightning")]
	[SerializeField]
	private AudioData bigLightningSound;

	[SerializeField]
	private SmoothShakeFreePreset bigLightningShakePreset;

	[SerializeField]
	private float bigLightningDelay;

	[Header("Ending")]
	[SerializeField]
	private float showEndGameUITime = 1f;

	private Coroutine gameOverAnimationCoroutine;

	public event Action onGameOverAnimationEnded;

	public void PlayGameOverAnimation()
	{
		this.StartCoroutineCheckingVar(GameOverCoroutine(), ref gameOverAnimationCoroutine);
	}

	private IEnumerator GameOverCoroutine()
	{
		LTPlayerController playerController = LTFunctionLibrary.GetLTPlayerController();
		playerController.LTHUD.ShowEndGameAnimationUI();
		LTFunctionLibrary.GetLTGameManager().ShowGrid(show: false, LTGameManager.EShowGridMode.Full);
		AudioSource audioSource = AudioSystem.Instance.PlaySound2D(defeatMusic, AudioSystem.EAudioMixerGroup.Music, 0f, defeatMusicDelay);
		audioSource.volume = 0f;
		AudioSystem.Instance.FadeAudioSource(audioSource, defeatMusic.Volume, 1f, unscaledDeltaTime: false, defeatMusicDelay);
		Character controlledCharacter = playerController.ControlledCharacter;
		PlayerTower playerTower = LTFunctionLibrary.GetLTGameManager().PlayerTower;
		Vector3 vector = playerTower.transform.position + (playerTower.transform.forward - playerTower.transform.right).normalized * 3f;
		float num = Vector3.Distance(controlledCharacter.transform.position, vector) / cameraMovementMaxSpeed;
		controlledCharacter.transform.DOMove(vector, num).SetEase(Ease.OutSine);
		playerController.ResetCameraZoom();
		float cameraRotation = playerController.PlayerCamera.transform.rotation.eulerAngles.y;
		TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(() => cameraRotation, delegate(float x)
		{
			cameraRotation = x;
		}, 315f + playerTower.transform.rotation.eulerAngles.y, Mathf.Min(0.4f, num)).SetEase(Ease.OutSine);
		tweenerCore.onUpdate = (TweenCallback)Delegate.Combine(tweenerCore.onUpdate, (TweenCallback)delegate
		{
			playerController.SetCameraRotation(cameraRotation);
		});
		yield return new WaitForSeconds(num + firstLightningsDelay);
		float timer = 0f;
		float nextTimeLightning = 0f;
		while (timer <= firstLightningsTime)
		{
			timer += Time.deltaTime;
			if (Time.time >= nextTimeLightning)
			{
				playerTower.FirstLightningsPS.Play();
				AudioSystem.Instance.PlaySound3D(firstLightningsSound, playerTower.FirstLightningsPS.transform.position, AudioSystem.EAudioMixerGroup.SFX, AudioRolloffMode.Logarithmic, 5f);
				LTFunctionLibrary.GetLTPlayerController().ShakeCamera(firstLightningsShakePreset);
				nextTimeLightning = Time.time + UnityEngine.Random.Range(firstLightningsMinMaxBetweenTime.x, firstLightningsMinMaxBetweenTime.y);
			}
			yield return null;
		}
		yield return new WaitForSeconds(bigLightningDelay);
		playerTower.BigLightningPS.Play();
		AudioSystem.Instance.PlaySound3D(bigLightningSound, playerTower.BigLightningPS.transform.position, AudioSystem.EAudioMixerGroup.SFX, AudioRolloffMode.Logarithmic, 5f);
		LTFunctionLibrary.GetLTPlayerController().ShakeCamera(bigLightningShakePreset);
		yield return new WaitForSeconds(0.35f);
		playerTower.MainModel.gameObject.SetActive(value: false);
		playerTower.DestroyedModel.gameObject.SetActive(value: true);
		yield return new WaitForSeconds(showEndGameUITime);
		this.onGameOverAnimationEnded?.Invoke();
	}
}
