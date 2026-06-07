using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NotificationHeader : MonoBehaviour, IScrollHandler, IEventSystemHandler
{
	public RectTransform Self;

	public RectTransform ClearButton;

	public RectTransform HideIcon;

	public RectTransform Counter;

	public Text Label;

	public Text CounterLabel;

	[NonSerialized]
	public List<UINotification> Notifications = new List<UINotification>();

	[NonSerialized]
	public bool Toggled = true;

	public bool ActiveInBuildMode;

	public float PunchDistance = 64f;

	public float PunchDuration = 1f;

	public float PunchElasticity = 1f;

	public int PunchVibrato = 10;

	private Tweener _tweener;

	public void NoticeMe()
	{
		if (_tweener != null)
		{
			_tweener.Kill();
		}
		Self.localScale = Vector3.one;
		_tweener = Self.DOPunchScale(Vector3.right * PunchDistance, PunchDuration, PunchVibrato, PunchElasticity).OnComplete(delegate
		{
			_tweener = null;
		});
	}

	private void Move(RectTransform t, Vector2 newPos, float newWidth, Sequence seq, RectTransform noAnim, bool animate)
	{
		if (t.anchoredPosition != newPos || t.sizeDelta.x != newWidth)
		{
			if (!animate || noAnim == t)
			{
				t.anchoredPosition = newPos;
				t.sizeDelta = new Vector2(newWidth, t.sizeDelta.y);
			}
			else
			{
				seq.Join(t.DOAnchorPos(newPos, 0.5f, true));
				seq.Join(t.DOSizeDelta(new Vector2(newWidth, t.sizeDelta.y), 0.5f, true));
			}
		}
	}

	public void UpdateY(ref float offset, Sequence seq, RectTransform ignore, bool animate)
	{
		CounterLabel.text = Notifications.Count.ToString();
		if (HUD.Instance != null && !ActiveInBuildMode && HUD.Instance.BuildMode)
		{
			Move(Self, new Vector2(0f - Self.sizeDelta.x - 1f, Self.anchoredPosition.y), Self.sizeDelta.x, seq, ignore, animate);
			for (int num = Notifications.Count - 1; num >= 0; num--)
			{
				UINotification uINotification = Notifications[num];
				if (!uINotification.IsRemoving)
				{
					float num2 = (Toggled ? uINotification.GetWidth() : 64f);
					Move(uINotification.Self, new Vector2(0f - num2, uINotification.Self.anchoredPosition.y), num2, seq, ignore, animate);
				}
			}
		}
		else if (Notifications.Count > 0)
		{
			if (Self.anchoredPosition.x < 0f)
			{
				Self.anchoredPosition = new Vector2(Self.anchoredPosition.x, offset);
			}
			Move(Self, new Vector2(0f, offset), Toggled ? NotificationManager.Instance.Holder.sizeDelta.x : 108f, seq, ignore, animate);
			Self.gameObject.SetActive(true);
			if (Toggled)
			{
				offset -= Self.sizeDelta.y + 1f;
			}
			for (int num3 = Notifications.Count - 1; num3 >= 0; num3--)
			{
				UINotification uINotification2 = Notifications[num3];
				if (!uINotification2.IsRemoving)
				{
					Move(uINotification2.Self, new Vector2(uINotification2.GetXOffset(), offset), Toggled ? uINotification2.GetWidth() : 64f, seq, ignore, animate);
					if (Toggled)
					{
						offset -= uINotification2.Self.sizeDelta.y + 1f;
					}
				}
			}
			if (!Toggled)
			{
				offset -= Self.sizeDelta.y + 1f;
			}
		}
		else
		{
			Move(Self, new Vector2(0f - Self.sizeDelta.x - 1f, Self.anchoredPosition.y), Self.sizeDelta.x, seq, ignore, animate);
		}
	}

	public void Clear()
	{
		Notifications.ForEach(delegate(UINotification x)
		{
			x.Message.OnDismissed();
			x.Remove();
		});
		NotificationManager.Instance.CloseDropDowns();
	}

	public void RefreshNotificationActive()
	{
		for (int i = 0; i < Notifications.Count; i++)
		{
			Notifications[i].gameObject.SetActive(Toggled);
		}
	}

	public void Toggle()
	{
		Toggled = !Toggled;
		UISoundFX.PlaySFX(Toggled ? "SlideIn2" : "SlideOut2", -1f, -0.6f);
		if (Toggled)
		{
			RefreshNotificationActive();
			ClearButton.DOSizeDelta(new Vector2(32f, ClearButton.sizeDelta.y), 0.5f, true);
			Label.DOColor(Label.color.Alpha(1f), 0.5f);
			HideIcon.DORotate(new Vector3(0f, 0f, 0f), 0.5f);
			Counter.DOScale(Vector3.zero, 0.5f);
		}
		else
		{
			ClearButton.DOSizeDelta(new Vector2(0f, ClearButton.sizeDelta.y), 0.5f, true);
			Label.DOColor(Label.color.Alpha(0f), 0.5f);
			HideIcon.DORotate(new Vector3(0f, 0f, 180f), 0.5f);
			Counter.DOScale(Vector3.one, 0.5f);
		}
		NotificationManager.Instance.UpdateY();
	}

	public void OnScroll(PointerEventData eventData)
	{
		NotificationManager.Instance.OnScroll(eventData);
	}
}
