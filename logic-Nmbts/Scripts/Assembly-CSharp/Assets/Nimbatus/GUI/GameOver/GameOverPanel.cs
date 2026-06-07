using System.Collections;
using Assets.Nimbatus.Scripts.Persistence;
using UnityEngine;

namespace Assets.Nimbatus.GUI.GameOver
{
	public class GameOverPanel : MonoBehaviour
	{
		[Header("Background Slide")]
		public UIPanel BackgroundPanel;

		[Header("GameOver Slide")]
		public UIPanel GameOverSlidePanel;

		public Transform GameOverLabel;

		[Header("Game Story Slide")]
		public UIPanel GameStorySlidePanel;

		public GameObject ContinueButton;

		[Header("Gameplay Slide")]
		public UIPanel GameplaySlidePanel;

		public Transform StartNewGamePanel;

		public GameObject ResetGalaxyButton;

		public GameObject UploadCheckbox;

		[Header("Nimbatus")]
		public Transform NimbatusPivot;

		private bool _allPanelsVisible;

		private float _startTime;

		private Vector3 _nimbatusStartPosition;

		public void Start()
		{
			_nimbatusStartPosition = NimbatusPivot.position;
			_startTime = Time.time;
			GameOverSlidePanel.gameObject.SetActive(false);
			GameStorySlidePanel.gameObject.SetActive(false);
			GameplaySlidePanel.gameObject.SetActive(false);
			if (RuntimeGlobals.GameMode == EGameMode.Campaign)
			{
				ResetGalaxyButton.SetActive(false);
				Vector3 localPosition = StartNewGamePanel.localPosition;
				localPosition.x = 0f;
				StartNewGamePanel.localPosition = localPosition;
			}
			StartCoroutine(ShowGameOverTitleSlide());
		}

		public void Update()
		{
			if (Input.anyKeyDown && !_allPanelsVisible && Time.time - _startTime >= 2f)
			{
				StopAllCoroutines();
				GameOverSlidePanel.alpha = 1f;
				GameStorySlidePanel.alpha = 1f;
				BackgroundPanel.alpha = 0f;
				GameOverSlidePanel.gameObject.SetActive(true);
				GameStorySlidePanel.gameObject.SetActive(true);
				GameplaySlidePanel.gameObject.SetActive(false);
				ContinueButton.SetActive(true);
				GameOverLabel.transform.localPosition = new Vector3(0f, 250f, 0f);
				_allPanelsVisible = true;
			}
			NimbatusPivot.position = (Vector3)(Mathf.Sin(Time.time / 5f) * 1f * Vector2.right) + _nimbatusStartPosition;
		}

		private IEnumerator ShowGameOverTitleSlide()
		{
			yield return new WaitForSeconds(1.5f);
			GameOverSlidePanel.alpha = 0f;
			GameOverSlidePanel.gameObject.SetActive(true);
			for (int i = 1; i <= 120; i++)
			{
				GameOverSlidePanel.alpha = (float)i / 120f;
				yield return new WaitForSeconds(1f / 60f);
			}
			yield return new WaitForSeconds(1f);
			int j = 120;
			for (int i = 1; i <= j; i++)
			{
				GameOverLabel.transform.localPosition = new Vector3(0f, Mathf.Lerp(0f, 250f, (float)i / (float)j), 0f);
				yield return new WaitForSeconds(1f / 60f);
			}
			StartCoroutine(ShowGameStorySlide());
		}

		private IEnumerator ShowGameStorySlide()
		{
			GameStorySlidePanel.alpha = 0f;
			BackgroundPanel.alpha = 1f;
			ContinueButton.SetActive(false);
			GameStorySlidePanel.gameObject.SetActive(true);
			int j = 60;
			for (int i = 1; i <= j; i++)
			{
				BackgroundPanel.alpha = 1f - (float)i / (float)j;
				GameStorySlidePanel.alpha = (float)i / (float)j;
				yield return new WaitForSeconds(1f / 60f);
			}
			yield return new WaitForSeconds(1f);
			_allPanelsVisible = true;
			ContinueButton.SetActive(true);
		}

		private IEnumerator ShowGameplaySlide()
		{
			int j = 30;
			for (int i = 1; i <= j; i++)
			{
				BackgroundPanel.alpha = (float)i / (float)j;
				GameStorySlidePanel.alpha = 1f - (float)i / (float)j;
				GameOverSlidePanel.alpha = 1f - (float)i / (float)j;
				yield return new WaitForSeconds(1f / 60f);
			}
			yield return new WaitForSeconds(0.3f);
			GameOverSlidePanel.gameObject.SetActive(false);
			GameStorySlidePanel.gameObject.SetActive(false);
			GameplaySlidePanel.gameObject.SetActive(true);
		}

		public void ContinueToGameplaySlide()
		{
			ContinueButton.SetActive(false);
			StartCoroutine(ShowGameplaySlide());
		}
	}
}
