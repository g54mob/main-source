using System.Collections.Generic;
using Motorways.UI;
using UnityEngine;
using UnityEngine.UI;

public class TouchOptionButton : OptionButton
{
	public enum RangeClampTransition
	{
		None = 0,
		UnInteractable = 1,
		Animation = 2
	}

	public GameObject[] options;

	public TouchButton leftButton;

	public TouchButton rightButton;

	[SerializeField]
	private List<int> _blockedOptions = new List<int>();

	[SerializeField]
	private RangeClampTransition _rangeClampTransition = RangeClampTransition.UnInteractable;

	[SerializeField]
	private string _clampedAnimParam;

	public override int NumberOfOptions => options.Length;

	private void Start()
	{
		if (NumberOfOptions > 0 && _currentIndex < 0)
		{
			SetOption(0, invokeMethod: false);
		}
	}

	private void OnEnable()
	{
		if (NumberOfOptions > 0)
		{
			SetOption(_currentIndex, invokeMethod: false);
		}
	}

	public void OnLeftPressed()
	{
		int num = 0;
		int num2 = _currentIndex;
		do
		{
			num2--;
			num++;
			if (num2 < 0)
			{
				num2 = (wrap ? (NumberOfOptions - 1) : 0);
			}
		}
		while (_blockedOptions.Contains(num2) && num <= NumberOfOptions);
		if (Diagnostics.Verify(num <= NumberOfOptions, "We've skipped more options than are available on {0}", base.name))
		{
			SetOption(num2);
		}
	}

	public void OnRightPressed()
	{
		int num = 0;
		int num2 = _currentIndex;
		do
		{
			num2++;
			num++;
			if (num2 >= NumberOfOptions)
			{
				num2 = ((!wrap) ? (NumberOfOptions - 1) : 0);
			}
		}
		while (_blockedOptions.Contains(num2) && num <= NumberOfOptions);
		if (num <= NumberOfOptions)
		{
			SetOption(num2);
		}
	}

	public void SkipOption(int optionIndex)
	{
		if (!_blockedOptions.Contains(optionIndex))
		{
			_blockedOptions.Add(optionIndex);
		}
	}

	public void UnskipOption(int optionIndex)
	{
		if (_blockedOptions.Contains(optionIndex))
		{
			_blockedOptions.Remove(optionIndex);
		}
	}

	public override void SetOption(int index, bool invokeMethod)
	{
		base.SetOption(index, invokeMethod);
		for (int i = 0; i < options.Length; i++)
		{
			options[i].SetActive(i == _currentIndex);
		}
		if (wrap)
		{
			return;
		}
		int j;
		for (j = 0; _blockedOptions.Contains(j); j++)
		{
		}
		bool flag = _currentIndex == j;
		int num = options.Length - 1;
		while (_blockedOptions.Contains(num))
		{
			num--;
		}
		bool flag2 = _currentIndex == num;
		switch (_rangeClampTransition)
		{
		case RangeClampTransition.UnInteractable:
			if (leftButton != null)
			{
				leftButton.interactable = !flag;
			}
			if (rightButton != null)
			{
				rightButton.interactable = !flag2;
			}
			break;
		case RangeClampTransition.Animation:
			if (leftButton != null)
			{
				leftButton.animator.SetBool(_clampedAnimParam, flag);
			}
			if (rightButton != null)
			{
				rightButton.animator.SetBool(_clampedAnimParam, flag2);
			}
			break;
		case RangeClampTransition.None:
			break;
		}
	}
}
