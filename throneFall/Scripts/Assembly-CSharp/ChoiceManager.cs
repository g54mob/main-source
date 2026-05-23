using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceManager : MonoBehaviour
{
	public static ChoiceManager instance;

	private bool choiceCoroutineRunning;

	private bool choiceCanceled;

	[HideInInspector]
	public List<Choice> availableChoices = new List<Choice>();

	[HideInInspector]
	public Choice choiceToReturn;

	[HideInInspector]
	public BuildSlot currentOriginBuildSlot;

	public bool ChoiceCoroutineWaiting
	{
		get
		{
			if (!choiceCanceled)
			{
				return choiceToReturn == null;
			}
			return false;
		}
	}

	public bool ChoiceCoroutineRunning => choiceCoroutineRunning;

	public void CancelChoice()
	{
		choiceCanceled = true;
	}

	private void Awake()
	{
		instance = this;
	}

	public void PresentChoices(List<Choice> _availableChoices, BuildSlot originBuildSlot, Action<Choice> _onCompleteFunction)
	{
		if (!choiceCoroutineRunning)
		{
			currentOriginBuildSlot = originBuildSlot;
			if (_availableChoices.Count == 0)
			{
				_onCompleteFunction(null);
				return;
			}
			if (_availableChoices.Count == 1)
			{
				_onCompleteFunction(_availableChoices[0]);
				return;
			}
			availableChoices = _availableChoices;
			UIFrameManager.instance.PresentChoiceFrame();
			StartCoroutine(Choice(_availableChoices, _onCompleteFunction));
		}
	}

	private IEnumerator Choice(List<Choice> _availableChoices, Action<Choice> _onCompleteFunction)
	{
		choiceToReturn = null;
		choiceCoroutineRunning = true;
		choiceCanceled = false;
		LocalGamestate.Instance.SetPlayerFreezeState(frozen: true);
		while (choiceToReturn == null && !choiceCanceled)
		{
			yield return null;
		}
		LocalGamestate.Instance.SetPlayerFreezeState(frozen: false);
		yield return null;
		_onCompleteFunction(choiceToReturn);
		choiceCoroutineRunning = false;
	}
}
