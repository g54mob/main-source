using System.Collections.Generic;
using UnityEngine;

public class UIDialogButtonCollection : MonoBehaviour
{
	public GameObject buttonPrefab;

	private List<UIButton> buttonList;

	public void Clear()
	{
		if (buttonList == null || buttonList.Count <= 0)
		{
			return;
		}
		foreach (UIButton button in buttonList)
		{
			if (button.gameObject != null)
			{
				Object.Destroy(button.gameObject);
			}
		}
		buttonList.Clear();
	}

	public void AddButton(string text, bool hasFocus)
	{
		if (buttonList == null)
		{
			buttonList = new List<UIButton>();
		}
		GameObject gameObject = Object.Instantiate(buttonPrefab);
		gameObject.transform.SetParent(base.gameObject.transform);
		gameObject.transform.localScale = Vector3.one;
		Vector3 localPosition = gameObject.transform.localPosition;
		localPosition.z = 0f;
		gameObject.transform.localPosition = localPosition;
		UIButton component = gameObject.GetComponent<UIButton>();
		component.SetButtonColors(DialogUI.Instance.focusedButtonColor, DialogUI.Instance.focusedTextColor, DialogUI.Instance.notFocusedButtonColor, DialogUI.Instance.notFocusedTextColor);
		if (hasFocus)
		{
			component.GotFocus();
		}
		else
		{
			component.LostFocus();
		}
		component.label.text = text;
		buttonList.Add(component);
	}

	public int FocusedButtonIndex()
	{
		int result = -1;
		if (buttonList != null)
		{
			int count = buttonList.Count;
			for (int i = 0; i < count; i++)
			{
				if (buttonList[i].HasFocus)
				{
					result = i;
					break;
				}
			}
		}
		return result;
	}

	public void HideFocus()
	{
		buttonList[0].HideFocus();
		buttonList[1].HideFocus();
	}

	public void ResumeFocus()
	{
		buttonList[0].UnHideFocus();
		buttonList[1].UnHideFocus();
	}

	public void MoveFocusRight()
	{
		int num = FocusedButtonIndex();
		if (num > -1)
		{
			buttonList[num].LostFocus();
			num++;
			if (num >= buttonList.Count)
			{
				num = 0;
			}
			buttonList[num].GotFocus();
		}
	}

	public void MoveFocusLeft()
	{
		int num = FocusedButtonIndex();
		if (num > -1)
		{
			buttonList[num].LostFocus();
			num--;
			if (num < 0)
			{
				num = buttonList.Count - 1;
			}
			buttonList[num].GotFocus();
		}
	}

	public void SetFocusByIndex(int index)
	{
		if (index > -1 && index < buttonList.Count)
		{
			int num = FocusedButtonIndex();
			if (num > -1)
			{
				buttonList[num].LostFocus();
			}
			buttonList[index].GotFocus();
		}
	}
}
