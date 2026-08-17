using System;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class CinematicBars : MonoBehaviour
{
	public RectTransform topBar;

	public RectTransform bottomBar;

	public CanvasGroup canvasGroup;

	private float barHeight;

	private float moveTime = 1f;

	private float moveTimer;

	private bool isShowing;

	private void Awake()
	{
		float num = topBar.rect.m_Height + 1f;
		barHeight = num;
	}

	public void InstaShow()
	{
		isShowing = true;
		moveTimer = 1f;
		GameObject gameObject = topBar.gameObject;
		gameObject.SetActive(value: true);
		GameObject gameObject2 = bottomBar.gameObject;
		gameObject2.SetActive(value: true);
		Vector2 anchoredPosition = default(Vector2);
		topBar.anchoredPosition = anchoredPosition;
		bottomBar.anchoredPosition = anchoredPosition;
	}

	public void Show()
	{
		if (!isShowing)
		{
			isShowing = true;
			moveTimer = 0f;
			Vector2 anchoredPosition = default(Vector2);
			topBar.anchoredPosition = anchoredPosition;
			bottomBar.anchoredPosition = anchoredPosition;
			GameObject gameObject = topBar.gameObject;
			gameObject.SetActive(value: true);
			GameObject gameObject2 = bottomBar.gameObject;
			gameObject2.SetActive(value: true);
		}
	}

	public void Hide()
	{
		if (isShowing)
		{
			isShowing = false;
			moveTimer = 0f;
			Vector2 anchoredPosition = default(Vector2);
			topBar.anchoredPosition = anchoredPosition;
			bottomBar.anchoredPosition = anchoredPosition;
		}
	}

	public bool IsShowing()
	{
		//IL_006b: Expected I4, but got O
		if ((object)topBar != null)
		{
			GameObject gameObject = topBar.gameObject;
			if ((object)gameObject != null)
			{
				return gameObject.activeSelf;
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private void Update()
	{
		//IL_0042: Invalid comparison between I4 and F4
		//IL_008d: Expected F4, but got I4
		//IL_0227: Invalid comparison between I4 and F4
		//IL_00c9: Expected F4, but got I4
		if (moveTimer > 1f)
		{
			return;
		}
		float deltaTime = Time.deltaTime;
		float num = deltaTime / moveTime;
		if (!(0f > num))
		{
			if (num > 1f)
			{
				num = 1f;
			}
		}
		else
		{
			num = 0f;
		}
		float num2 = (moveTimer += num);
		if (!(0f > num2))
		{
			if (num2 > 1f)
			{
				num2 = 1f;
			}
		}
		else
		{
			num2 = 0f;
		}
		float num3 = (isShowing ? Easing.OutCirc(num2) : Easing.InOutCubic(num2));
		Vector2 anchoredPosition = default(Vector2);
		if (!isShowing)
		{
			topBar.anchoredPosition = anchoredPosition;
			bottomBar.anchoredPosition = anchoredPosition;
			float alpha = 1f - num3;
			canvasGroup.alpha = alpha;
			if (!(num3 < 1f))
			{
				GameObject gameObject = topBar.gameObject;
				gameObject.SetActive(value: false);
				GameObject gameObject2 = bottomBar.gameObject;
				gameObject2.SetActive(value: false);
			}
		}
		else
		{
			topBar.anchoredPosition = anchoredPosition;
			bottomBar.anchoredPosition = anchoredPosition;
			canvasGroup.alpha = num3;
		}
	}
}
