using System.Collections.Generic;
using UnityEngine;

public class TitleGroupUI : MonoBehaviour
{
	[Header("Setup")]
	[Tooltip("Drag all your TitleLetterUI objects here in order (Left to Right)")]
	public List<TitleLetterUI> letters;

	[Header("Settings")]
	public float delayBetweenLetters = 0.05f;

	private void Start()
	{
		foreach (TitleLetterUI letter in letters)
		{
			if (letter != null)
			{
				letter.Initialize(this);
			}
		}
		TriggerGroupEffect();
	}

	public void TriggerGroupEffect()
	{
		for (int i = 0; i < letters.Count; i++)
		{
			if (letters[i] != null)
			{
				float delay = (float)i * delayBetweenLetters;
				letters[i].PlayWaveAnimation(delay);
			}
		}
	}

	[ContextMenu("Auto Find Letters")]
	public void AutoFindChildrenLetters()
	{
		letters = new List<TitleLetterUI>(GetComponentsInChildren<TitleLetterUI>());
	}
}
