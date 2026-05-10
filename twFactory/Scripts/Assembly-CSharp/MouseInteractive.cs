using System;
using UnityEngine;

public class MouseInteractive : MonoBehaviour
{
	public Action onStartLeftClick;

	public Action onEndLeftClick;

	public Action onStartRightClick;

	public Action onEndRightClick;

	public void StartLeftClick()
	{
		onStartLeftClick?.Invoke();
	}

	public void EndLeftClick()
	{
		onEndLeftClick?.Invoke();
	}

	public void StartRightClick()
	{
		onStartRightClick?.Invoke();
	}

	public void EndRightClick()
	{
		onEndRightClick?.Invoke();
	}
}
