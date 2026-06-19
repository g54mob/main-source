using System.Collections;
using Intro.Tutorial;
using Loxodon.Framework.Contexts;
using UI.HUD.Assistant;
using UnityEngine;

namespace Intro
{
	public class IntroAssistantPlayer : MonoBehaviour
	{
		[SerializeField]
		private IntroSequencePlayer _introSequencePlayer;

		[SerializeField]
		private TutorialPlayer _tutorialPlayer;

		[SerializeField]
		private float _appearDelay;

		[SerializeField]
		private float _speechDelay;

		[SerializeField]
		private float _visionDelay;

		private AssistantPopupViewModel _assistantPopupViewModel;

		private void Start()
		{
			_assistantPopupViewModel = Context.GetApplicationContext().GetService<AssistantPopupViewModel>();
		}

		private void OnEnable()
		{
			_introSequencePlayer.OnIntroFinished += IntroFinished;
		}

		private void OnDisable()
		{
			_introSequencePlayer.OnIntroFinished -= IntroFinished;
		}

		private void IntroFinished()
		{
			StartCoroutine(AssistantSequence());
		}

		private IEnumerator AssistantSequence()
		{
			yield return new WaitForSeconds(_appearDelay);
			_assistantPopupViewModel.Closed.Value = false;
			_assistantPopupViewModel.SetSpeechBubbleText("One moment...");
			yield return new WaitForSeconds(_speechDelay);
			_assistantPopupViewModel.SetSpeechBubbleText("Trying to enable vision module...");
			yield return new WaitForSeconds(_visionDelay);
			_introSequencePlayer.gameObject.SetActive(value: false);
			_tutorialPlayer.StartTutorial();
		}
	}
}
