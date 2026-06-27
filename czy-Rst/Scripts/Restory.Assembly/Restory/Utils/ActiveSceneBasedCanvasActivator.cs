using System.Linq;
using DG.Tweening;
using Helpers.Attributes;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Restory.Utils
{
	public class ActiveSceneBasedCanvasActivator : MonoBehaviour
	{
		[SerializeField]
		private CanvasGroup canvasGroup;

		[SerializeField]
		private float showDuration = 2.5f;

		[SerializeField]
		private float hideDuration = 2.5f;

		[SerializeField]
		[Scene]
		private string[] hideForScenes = new string[0];

		private Sequence mainSequence;

		private TweenSequencesService tweenSequencesService;

		[Inject]
		private void Construct(TweenSequencesService tweenSequencesService)
		{
			this.tweenSequencesService = tweenSequencesService;
		}

		private void OnEnable()
		{
			SceneManager.activeSceneChanged += SceneManagerOnActiveSceneChanged;
			UpdateView();
		}

		private void OnDisable()
		{
			SceneManager.activeSceneChanged -= SceneManagerOnActiveSceneChanged;
		}

		private void UpdateView()
		{
			Scene activeScene = SceneManager.GetActiveScene();
			if (hideForScenes.Contains(activeScene.name) && canvasGroup.alpha > 0f)
			{
				Hide();
			}
			else if (!hideForScenes.Contains(activeScene.name))
			{
				Show();
			}
		}

		private void Show()
		{
			KillSequence();
			mainSequence = tweenSequencesService.Create();
			mainSequence.OnStart(delegate
			{
				canvasGroup.interactable = false;
			});
			mainSequence.Append(canvasGroup.DOFade(1f, showDuration));
			mainSequence.OnComplete(delegate
			{
				canvasGroup.interactable = true;
			});
		}

		private void Hide()
		{
			KillSequence();
			mainSequence = tweenSequencesService.Create();
			mainSequence.OnStart(delegate
			{
				canvasGroup.interactable = false;
			});
			mainSequence.Append(canvasGroup.DOFade(0f, hideDuration));
		}

		private void KillSequence()
		{
			if (mainSequence != null)
			{
				tweenSequencesService.Kill(mainSequence);
				mainSequence = null;
			}
		}

		private void SceneManagerOnActiveSceneChanged(Scene arg0, Scene arg1)
		{
			UpdateView();
		}
	}
}
