using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ObjectivesBar : MonoBehaviour
{
	[Serializable]
	public class OnObjectiveSelectedEvent : UnityEvent<int>
	{
	}

	public Toggle[] toggles;

	public GameObject loadingCover;

	public OnObjectiveSelectedEvent OnObjectiveSelected;

	private Color unavailColor;

	private Color incompleteColor;

	private Color completeColor;

	public void OnToggle0(bool val)
	{
	}

	public void OnToggle1(bool val)
	{
	}

	public void OnToggle2(bool val)
	{
	}

	public void OnToggle3(bool val)
	{
	}

	public void OnToggle4(bool val)
	{
	}

	public void OnToggle5(bool val)
	{
	}

	public void SetStates(int[] vals)
	{
	}

	public void SetSelected(int val)
	{
	}

	public int GetSelected()
	{
		return 0;
	}
}
