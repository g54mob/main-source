using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MarkVPane : MonoBehaviour
{
	[Serializable]
	public class ChangeEvent : UnityEvent<int>
	{
	}

	public Toggle choice0;

	public Toggle choice1;

	public Toggle choice2;

	public Toggle choice3;

	public ChangeEvent toggleChangedEvent;

	public byte GetChoice()
	{
		return 0;
	}

	public void SetChoice(int choice)
	{
	}

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
}
