using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class AutoTypeBox : MonoBehaviour
{
	[Serializable]
	public class OnDoneEvent : UnityEvent
	{
	}

	public string autoTypeText;

	public TextMeshProUGUI text;

	public Image caret;

	private string[] textArray;

	private int textArrayPos;

	private float blinkCounter;

	public OnDoneEvent onDoneEvent;

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void LateUpdate()
	{
	}

	private void FillText()
	{
	}
}
