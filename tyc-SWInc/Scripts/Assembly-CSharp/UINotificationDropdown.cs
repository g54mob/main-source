using System;
using DG.Tweening;
using UnityEngine;

public abstract class UINotificationDropdown : MonoBehaviour
{
	public RectTransform Self;

	[NonSerialized]
	private bool _workItemHack;

	private bool _open;

	[NonSerialized]
	private Tweener _activeTween;

	[NonSerialized]
	private UINotification _last;

	[NonSerialized]
	private SubWorkItem _lastW;

	public bool Open
	{
		get
		{
			return _open;
		}
	}

	public void Drop(SubWorkItem workItem)
	{
		_workItemHack = true;
		if (_open && workItem == _lastW)
		{
			Close();
			return;
		}
		_lastW = workItem;
		Self.anchoredPosition = new Vector2(-8f, (float)(-Screen.height) / Options.UISize / 2f + workItem.GetY() - 12f);
		_open = true;
		SetContent(new SubWorkItem.FakeTaskNotification(workItem.Work));
		if (_activeTween != null && _activeTween.IsPlaying())
		{
			_activeTween.Kill(true);
		}
		_activeTween = Self.DOSizeDelta(new Vector2(Self.sizeDelta.x, GetHeight()), 0.5f, true).SetEase(Ease.OutBounce);
		float b = (float)(-Screen.height) / Options.UISize + GetHeight();
		Self.anchoredPosition = new Vector2(-8f, Mathf.Max(Self.anchoredPosition.y, b));
		base.gameObject.SetActive(true);
	}

	public void Drop(UINotification msg)
	{
		_workItemHack = false;
		if (_open && msg == _last)
		{
			Close();
			return;
		}
		_last = msg;
		Self.anchoredPosition = new Vector2(msg.Self.anchoredPosition.x + 16f, msg.Self.anchoredPosition.y - msg.Self.sizeDelta.y);
		Self.sizeDelta = new Vector2(msg.Self.sizeDelta.x - 32f, 0f);
		_open = true;
		SetContent(msg.Message);
		if (_activeTween != null && _activeTween.IsPlaying())
		{
			_activeTween.Kill(true);
		}
		_activeTween = Self.DOSizeDelta(new Vector2(Self.sizeDelta.x, GetHeight()), 0.5f, true).SetEase(Ease.OutBounce);
		base.gameObject.SetActive(true);
	}

	public void Close()
	{
		_open = false;
		if (_activeTween != null && _activeTween.IsPlaying())
		{
			_activeTween.Kill(true);
		}
		_activeTween = Self.DOSizeDelta(new Vector2(Self.sizeDelta.x, 0f), 0.5f, true).SetEase(Ease.OutCirc).OnComplete(delegate
		{
			base.gameObject.SetActive(false);
		});
	}

	public abstract void SetContent(NotificationMessage msg);

	public abstract float GetHeight();

	private void Update()
	{
		if (_workItemHack)
		{
			if (_open && Input.mousePosition.x < (float)Screen.width - 256f * Options.UISize)
			{
				Close();
			}
		}
		else if (_open && ((_last != null && (_last.IsRemoving || !_last.gameObject.activeSelf)) || Input.mousePosition.x > (HUD.Instance.MainContentPanel.offsetMin.x + NotificationManager.Instance.Holder.rect.width) * Options.UISize || Input.mousePosition.x < HUD.Instance.MainContentPanel.offsetMin.x * Options.UISize))
		{
			Close();
		}
	}
}
