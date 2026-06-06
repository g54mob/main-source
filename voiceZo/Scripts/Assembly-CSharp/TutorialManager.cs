using System;
using UnityEngine;

public class TutorialManager : MonoSingleton<TutorialManager>
{
	[SerializeField]
	private DialogueView _dialogueView;

	public DialogueView DialogueView => _dialogueView;

	public bool IsTutorialCompleted { get; private set; }

	public event Action OnStartTutorial;

	public event Action OnEndDialogue;

	public event Action OnEndTutorial;

	public void TryStartTutorial()
	{
		if (IsTutorialCompleted)
		{
			Debug.Log("튜토리얼 이미 완료");
			return;
		}
		this.OnStartTutorial?.Invoke();
		_dialogueView.Open(Notify_OnEndDialogue);
	}

	public void TryEndTutorial()
	{
		if (IsTutorialCompleted)
		{
			Debug.Log("튜토리얼 이미 완료");
			return;
		}
		this.OnEndTutorial?.Invoke();
		SetIsTutorialCompleted(isTutorialCompleted: true);
		MonoSingleton<GameManager>.Instance.SaveGame();
	}

	public void SetIsTutorialCompleted(bool isTutorialCompleted)
	{
		IsTutorialCompleted = isTutorialCompleted;
	}

	public void Notify_OnEndDialogue()
	{
		this.OnEndDialogue?.Invoke();
	}
}
