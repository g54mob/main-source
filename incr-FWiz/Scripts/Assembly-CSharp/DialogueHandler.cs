using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class DialogueHandler : MonoBehaviour
{
	public static DialogueHandler Instance { get; private set; }

	public DialogueStory CurrentStory { get; private set; }

	[field: SerializeField]
	public DialogueInterface Interface { get; private set; }

	public bool StoryActive => false;

	private event Action _callOnEndStory
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	private void Start()
	{
	}

	public void Initiate()
	{
	}

	public void StartStory(DialogueStory story, Action onFinishCallback = null, int lineIndex = 0)
	{
	}

	public void StartOrSetStory(DialogueStory story, int lineIndex, Action onFinishCallback = null, bool canQueue = true)
	{
	}

	public void SetLine(int lineIndex = 0)
	{
	}

	public void ForceQuitStory()
	{
	}

	public void OnEndStory()
	{
	}
}
