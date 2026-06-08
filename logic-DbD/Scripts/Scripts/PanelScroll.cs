using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PanelScroll : Panel
{
	[SerializeField]
	private bool rememberScroll;

	private float lastScrollPosition;

	private ScrollRect scrollRect;

	private bool isPlayingMinimize;

	private float scrollPos;

	private bool isLocked;

	protected override void Awake()
	{
		base.Awake();
		scrollRect = GetComponentInChildren<ScrollRect>();
		lastScrollPosition = 1f;
		scrollRect.verticalNormalizedPosition = lastScrollPosition;
		scrollRect.onValueChanged.AddListener(SetScrollPosition);
	}

	public override void OpenPanel()
	{
		base.OpenPanel();
		StartCoroutine(LockScrollRectDelay(0.15f));
	}

	public override void ClosePanel()
	{
		base.ClosePanel();
		StartCoroutine(LockScrollRectDelay(1f));
	}

	public void SetScrollPosition(Vector2 position)
	{
		if (!isPlayingMinimize && !isLocked && (!isMinimizing || IsPanelMaximizing()))
		{
			lastScrollPosition = scrollRect.verticalNormalizedPosition;
			Debug.Log($"Setting lastScrollPosition {lastScrollPosition}");
		}
	}

	public override void OnMinimizePanel()
	{
		if (!isPlayingMinimize)
		{
			scrollPos = scrollRect.verticalNormalizedPosition;
		}
		isPlayingMinimize = true;
		StartCoroutine(LockScrollRect());
		StartCoroutine(FinishedMinimizing(0.3f, isOpen: false));
	}

	public override void OnMaximizePanel()
	{
		isPlayingMinimize = true;
		StartCoroutine(LockScrollRect());
		StartCoroutine(FinishedMinimizing(0.3f, isOpen: true));
	}

	protected virtual IEnumerator LockScrollRect()
	{
		while (isPlayingMinimize)
		{
			scrollRect.verticalNormalizedPosition = scrollPos;
			yield return null;
		}
	}

	protected virtual IEnumerator LockScrollRectDelay(float waitTime)
	{
		float timer = 0f;
		isLocked = true;
		while (timer < waitTime)
		{
			scrollRect.verticalNormalizedPosition = (rememberScroll ? lastScrollPosition : 1f);
			timer += Time.deltaTime;
			yield return null;
		}
		isLocked = false;
	}

	protected virtual IEnumerator FinishedMinimizing(float waitTime, bool isOpen)
	{
		yield return new WaitForSeconds(waitTime);
		if (IsPanelMaximizing() == isOpen)
		{
			isPlayingMinimize = false;
		}
	}
}
