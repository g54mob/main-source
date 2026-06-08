using System;
using UnityEngine;

public class MessageHintState : IHintState
{
	private string message = string.Empty;

	public HintStateTypeEnum StateType
	{
		get
		{
			throw new NotImplementedException();
		}
	}

	private MessageHintState()
	{
	}

	public MessageHintState(string message)
	{
		this.message = message;
		HintManager.HintText.text = message;
		if (HintManager.HintBackgroundObject != null)
		{
			RectTransform component = HintManager.HintText.gameObject.GetComponent<RectTransform>();
			RectTransform component2 = HintManager.HintBackgroundObject.GetComponent<RectTransform>();
			component2.sizeDelta = new Vector2(component.sizeDelta.x, component.sizeDelta.y);
		}
	}

	public void Start()
	{
	}

	public bool Update()
	{
		return false;
	}

	public void Stop()
	{
	}
}
