using System;
using DG.Tweening;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.UserInterface
{
	public class GUI_DialoguePanel : MonoBehaviour, IInitializable, IDisposable
	{
		[SerializeField]
		private GUI_DialoguePhrase dialoguePhrase;

		[SerializeField]
		private GUI_DialogueChoice dialogueChoice;

		[SerializeField]
		private GUI_SystemMessage systemMessage;

		[SerializeField]
		private float fadeDuration = 0.5f;

		private TweenSequencesService tweenSequences;

		private Sequence transitionSequence;

		public event Action OnSystemMessageSubmit;

		[Inject]
		private void Construct(TweenSequencesService tweenSequences)
		{
			this.tweenSequences = tweenSequences;
		}

		public void Initialize()
		{
			DisableDialogueObject(dialoguePhrase);
			DisableDialogueObject(dialogueChoice);
			DisableDialogueObject(systemMessage);
			systemMessage.SubmitButton.onClick.AddListener(ResolveSystemMessageSubmit);
		}

		public void Dispose()
		{
			if (transitionSequence != null)
			{
				tweenSequences.Kill(transitionSequence);
			}
			systemMessage.SubmitButton.onClick.RemoveListener(ResolveSystemMessageSubmit);
		}

		public void ShowDialoguePhrase(string phraseContent)
		{
			dialoguePhrase.UpdateContent(phraseContent);
			ShowDialogueObject(dialoguePhrase);
		}

		public void ShowDialogueChoice(string firstOptionContent, string secondOptionContent)
		{
			dialogueChoice.UpdateContent(firstOptionContent, secondOptionContent);
			ShowDialogueObject(dialogueChoice);
		}

		public void ShowSystemMessage(string messageContent)
		{
			systemMessage.UpdateContent(messageContent);
			ShowDialogueObject(systemMessage);
		}

		public void HideDialoguePhrase()
		{
			HideDialogueObject(dialoguePhrase);
		}

		public void HideDialogueChoice()
		{
			if (transitionSequence != null)
			{
				tweenSequences.Kill(transitionSequence);
			}
			transitionSequence = tweenSequences.Create();
			transitionSequence.Append(dialogueChoice.CanvasGroup.DOFade(0f, fadeDuration)).Join(dialoguePhrase.CanvasGroup.DOFade(0f, fadeDuration)).SetEase(Ease.InQuad)
				.OnComplete(delegate
				{
					DisableDialogueObject(dialogueChoice);
					DisableDialogueObject(dialoguePhrase);
				});
		}

		public void HideSystemMessage()
		{
			HideDialogueObject(systemMessage);
		}

		private void ShowDialogueObject(IDialogueObject dialogueObject)
		{
			if (transitionSequence != null)
			{
				tweenSequences.Kill(transitionSequence);
			}
			dialogueObject.GameObject.SetActive(value: true);
			transitionSequence = tweenSequences.Create();
			transitionSequence.Append(dialogueObject.CanvasGroup.DOFade(1f, fadeDuration)).SetEase(Ease.InQuad);
		}

		private void HideDialogueObject(IDialogueObject dialogueObject)
		{
			if (transitionSequence != null)
			{
				tweenSequences.Kill(transitionSequence);
			}
			transitionSequence = tweenSequences.Create();
			transitionSequence.Append(dialogueObject.CanvasGroup.DOFade(0f, fadeDuration)).SetEase(Ease.InQuad).OnComplete(delegate
			{
				DisableDialogueObject(dialogueObject);
			});
		}

		private void DisableDialogueObject(IDialogueObject dialogueObject)
		{
			dialogueObject.CanvasGroup.alpha = 0f;
			dialogueObject.GameObject.SetActive(value: false);
		}

		private void ResolveSystemMessageSubmit()
		{
			this.OnSystemMessageSubmit?.Invoke();
		}
	}
}
