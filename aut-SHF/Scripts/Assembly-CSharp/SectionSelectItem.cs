using System;
using System.Collections.Generic;
using InputControl;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SectionSelectItem : MonoBehaviour
{
	private enum Status
	{
		None = 0,
		NotCleared_Off = 1,
		NotCleared_On = 2,
		Cleared_Off = 3,
		Cleared_On = 4
	}

	[Serializable]
	private class StatusContentsCtrl
	{
		public Status status;

		public Color textColor;

		public List<GameObject> contents;
	}

	[SerializeField]
	private Button button;

	[SerializeField]
	private Color buttonDisabledTextColor;

	[SerializeField]
	private GameObject checkmark_pointerEnter;

	[SerializeField]
	private GameObject checkmark_pointerExit;

	[SerializeField]
	private CursorUIItem cursorUIItem;

	[SerializeField]
	private TMP_Text title;

	[SerializeField]
	private TMP_Text notClearedPointText;

	[SerializeField]
	[Header("Status Contents")]
	private List<StatusContentsCtrl> statusContents;

	private UnityAction onClickAction;

	private Dictionary<Status, StatusContentsCtrl> statusContentsDic;

	private Status status;

	private bool _isEnable;

	public void Init(string title, bool enabled, bool isCleared, UnityAction onClickAction, bool forceInitDic = false)
	{
	}

	public void ResetStatus()
	{
	}

	public void OnPointerEnter()
	{
	}

	public void OnPointerExit()
	{
	}

	public void UpdateStatus(bool isCleared)
	{
	}

	private void SwitchStatus()
	{
	}

	private void SetStatusContents(bool enabled = true)
	{
	}

	public void OnClickButton()
	{
	}
}
