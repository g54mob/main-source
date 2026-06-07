using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UINotification : MonoBehaviour
{
	public RectTransform Self;

	public RectTransform IconHolder;

	public Text Label;

	public Text Count;

	public Image Icon;

	public Image IconBack;

	public Image CountBubbleBack;

	public GameObject CountBubble;

	public Button Dropdown;

	public Button Goto;

	public float Margin = 2f;

	public float MinHeight = 32f;

	public float PunchDistance = 64f;

	public float PunchDuration = 1f;

	public float PunchElasticity = 1f;

	public int PunchVibrato = 10;

	public NotificationHeader Parent;

	[NonSerialized]
	public NotificationMessage Message;

	private bool _isRemoving;

	public Color[] TypeColor;

	private Tweener _iconTween;

	private Sequence _countTween;

	private int _collapseCountState;

	private int _lastCount = -1;

	public float textWidth = 10f;

	public bool IsRemoving
	{
		get
		{
			return _isRemoving;
		}
	}

	public bool Collapsed
	{
		get
		{
			return Message.Collapsed;
		}
		set
		{
			if (Message.Collapsed != value)
			{
				Message.Collapsed = value;
				UISoundFX.PlaySFX(Message.Collapsed ? "SlideOut2" : "SlideIn2", -1f, -0.6f);
				if (_iconTween != null)
				{
					_iconTween.Kill();
				}
				_iconTween = IconHolder.DOAnchorPos(new Vector2(Message.Collapsed ? (GetWidth() - IconHolder.sizeDelta.x) : 0f, IconHolder.anchoredPosition.y), 0.5f).OnComplete(delegate
				{
					_iconTween = null;
				});
				_collapseCountState = 0;
				if (!Refresh())
				{
					NotificationManager.Instance.UpdateY();
				}
			}
		}
	}

	public void Scroll(BaseEventData e)
	{
		NotificationManager.Instance.OnScroll(e);
	}

	public void RefreshCount()
	{
		int count = Message.GetCount();
		if (_lastCount >= 0 && count > _lastCount)
		{
			if ((Message.Type != NotificationManager.NotificationType.Issue || !GameSettings.Instance.MuteIssues) && (Message.LastBlip == -1f || Time.realtimeSinceStartup - Message.LastBlip > 10f))
			{
				if (Message.Type == NotificationManager.NotificationType.Hint)
				{
					UISoundFX.PlaySFX("NotificationGood");
				}
				else
				{
					UISoundFX.PlaySFX("Notification" + Message.Type);
				}
				Message.LastBlip = Time.realtimeSinceStartup;
			}
			if (Parent.Toggled)
			{
				if (Collapsed)
				{
					if (_iconTween != null)
					{
						_iconTween.Kill();
					}
					IconHolder.anchoredPosition = new Vector2(Collapsed ? (GetWidth() - IconHolder.sizeDelta.x) : 0f, IconHolder.anchoredPosition.y);
					_iconTween = IconHolder.DOPunchAnchorPos(Vector2.right * PunchDistance, PunchDuration, PunchVibrato, PunchElasticity).OnComplete(delegate
					{
						_iconTween = null;
					});
				}
				PushCount();
			}
			else
			{
				Parent.NoticeMe();
			}
		}
		_lastCount = count;
	}

	private void PushCount()
	{
		if (CountBubble.activeSelf)
		{
			if (_countTween != null)
			{
				_countTween.Kill(true);
			}
			CountBubbleBack.color = CountBubbleBack.color.Alpha(1f);
			CountBubbleBack.rectTransform.localScale = Vector3.one;
			CountBubbleBack.gameObject.SetActive(true);
			_countTween = DOTween.Sequence();
			_countTween.Append(CountBubbleBack.rectTransform.DOScale(Vector3.one * 3f, 1f)).SetEase(Ease.OutCirc);
			_countTween.Insert(0.5f, CountBubbleBack.DOColor(CountBubbleBack.color.Alpha(0f), 0.5f));
			_countTween.OnComplete(delegate
			{
				CountBubbleBack.gameObject.SetActive(false);
				_countTween = null;
			});
		}
	}

	public float GetXOffset()
	{
		if (!Collapsed)
		{
			return 0f;
		}
		return IconHolder.sizeDelta.x + (float)(CountBubble.activeSelf ? 28 : 0) - GetWidth() - 1f;
	}

	public void ToggleCollapse(BaseEventData e)
	{
		PointerEventData pointerEventData = e as PointerEventData;
		if (pointerEventData != null && pointerEventData.button == PointerEventData.InputButton.Right)
		{
			SelectorController.CanClick = false;
			DestroyClick();
			return;
		}
		UISoundFX.PlaySFX("ButtonClick");
		if (base.isActiveAndEnabled)
		{
			StopCoroutine("CollapseWait");
		}
		Collapsed = !Collapsed;
	}

	public void OnClick(BaseEventData e)
	{
		PointerEventData pointerEventData = e as PointerEventData;
		if (pointerEventData != null && pointerEventData.button == PointerEventData.InputButton.Right)
		{
			SelectorController.CanClick = false;
			DestroyClick();
		}
	}

	private void DestroyClick()
	{
		if (Message.IsDismissable() && !_isRemoving)
		{
			UISoundFX.PlaySFX("ButtonSwoop");
			HelpTipPanel.DismissHint(HintController.Hints.HintDismissNotification);
			Message.OnDismissed();
			Remove();
			NotificationManager.Instance.CloseDropDowns();
		}
	}

	public void Set(NotificationMessage msg)
	{
		Self.sizeDelta = new Vector2(NotificationManager.Instance.GetNotificationWidth(), 0f);
		Message = msg;
		Icon.sprite = ObjectDatabase.GetIcon(msg.Icon, true);
		if (Icon.sprite == null)
		{
			Icon.sprite = ObjectDatabase.GetIcon("Info");
			Debug.LogWarning("Icon not found: " + msg.Icon + " for message type: " + msg.GetType().Name);
		}
		IconBack.color = TypeColor[(int)msg.Type];
		Refresh(true);
		_lastCount = msg.GetCount();
		if (msg.Collapsed)
		{
			IconHolder.anchoredPosition = new Vector2(GetWidth() - IconHolder.sizeDelta.x, IconHolder.anchoredPosition.y);
		}
		if (!msg.Collapsed && msg.Type != NotificationManager.NotificationType.Issue && msg.Type != NotificationManager.NotificationType.Warning && msg.Type != NotificationManager.NotificationType.Hint && base.isActiveAndEnabled)
		{
			StartCoroutine("CollapseWait");
		}
		if (Message.IsDismissable())
		{
			HelpTipPanel.Show(HintController.Hints.HintDismissNotification, Self);
		}
	}

	private IEnumerator CollapseWait()
	{
		yield return new WaitForSecondsRealtime(10f);
		Collapsed = true;
	}

	public bool HasDrop()
	{
		NotificationManager.DropType dropType = Message.GetDropType();
		if (dropType == NotificationManager.DropType.List)
		{
			if (Message.HasGoto() && Message.GetCount() == 1)
			{
				return Message.ForceList();
			}
			return true;
		}
		return dropType == NotificationManager.DropType.Simple;
	}

	public void GotoClick()
	{
		if (base.isActiveAndEnabled)
		{
			StopCoroutine("CollapseWait");
		}
		if (Message.GetCount() > 0)
		{
			Message.Goto(0);
		}
	}

	public void DropClick()
	{
		if (base.isActiveAndEnabled)
		{
			StopCoroutine("CollapseWait");
		}
		NotificationManager.Instance.DropDownPrefabs[(int)Message.GetDropType()].Drop(this);
	}

	public void Remove()
	{
		if (_isRemoving)
		{
			return;
		}
		NotificationManager.Instance.RemoveAggregate(Message);
		if (Parent.Toggled)
		{
			UISoundFX.PlaySFX("SlideOut2", -1f, -0.6f);
			Self.DOAnchorPos(new Vector2(0f - Self.rect.width, Self.anchoredPosition.y), 0.5f).OnComplete(delegate
			{
				UnityEngine.Object.Destroy(base.gameObject);
			});
			_isRemoving = true;
		}
		else
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	private void OnDestroy()
	{
		if (!GameSettings.IsQuitting)
		{
			NotificationManager.Instance.Remove(this);
		}
	}

	public float GetWidth()
	{
		float num = textWidth + Label.rectTransform.offsetMin.x + 4f;
		if (!Collapsed && Dropdown.gameObject.activeSelf)
		{
			num += 32f;
		}
		if (!Collapsed && Goto.gameObject.activeSelf)
		{
			num += 32f;
		}
		if (CountBubble.activeSelf)
		{
			num += 28f;
		}
		return Mathf.Min(num, NotificationManager.Instance.GetNotificationWidth());
	}

	public bool Refresh(bool first = false)
	{
		int num = Mathf.FloorToInt((float)NotificationManager.Instance.GetNotificationWidth() - Label.rectTransform.offsetMin.x) - 2;
		bool flag = !Collapsed && HasDrop();
		bool flag2 = !Collapsed && Message.HasGoto() && (Message.GetDropType() != NotificationManager.DropType.List || !flag);
		Dropdown.gameObject.SetActive(flag);
		Goto.gameObject.SetActive(flag2);
		float num2 = 0f;
		if (flag)
		{
			Dropdown.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f - num2, 0f);
			num2 += 32f;
			num -= 32;
		}
		if (flag2)
		{
			Goto.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f - num2, 0f);
			num2 += 32f;
			num -= 32;
		}
		if (flag)
		{
			Dropdown.image.sprite = ObjectDatabase.Instance.GetSprite(true, true, false, false);
			if (flag2)
			{
				Goto.image.sprite = ObjectDatabase.Instance.GetSprite(false, false, false, false);
			}
		}
		else if (flag2)
		{
			Goto.image.sprite = ObjectDatabase.Instance.GetSprite(true, true, false, false);
		}
		int count = Message.GetCount();
		CountBubble.SetActive(count > 1);
		if (count > 1)
		{
			Count.text = Mathf.Min(99, count).ToString();
			if (count > 99)
			{
				Count.text += "+";
			}
			CountBubble.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f - num2 - 8f - (Collapsed ? (IconHolder.sizeDelta.x - 4f) : 0f), 0f);
			num2 += 28f;
			num -= 28;
		}
		Label.rectTransform.offsetMax = new Vector2(0f - num2 - 2f, 0f);
		Label.gameObject.SetActive(!Collapsed);
		string message = Message.Message;
		Label.text = message;
		float num3;
		if (Collapsed)
		{
			num3 = 0f;
		}
		else
		{
			TextGenerationSettings generationSettings = Label.GetGenerationSettings(new Vector2(num, 0f));
			num3 = Label.cachedTextGeneratorForLayout.GetPreferredHeight(Message.Message, generationSettings) / Options.UISize;
			textWidth = Label.cachedTextGeneratorForLayout.GetPreferredWidth(Message.Message, generationSettings) / Options.UISize;
		}
		float y = Self.sizeDelta.y;
		Self.sizeDelta = new Vector2(GetWidth(), Mathf.Max(MinHeight, num3 + Margin * 2f));
		bool flag3 = false;
		if (Collapsed)
		{
			int num4 = ((count <= 1) ? 1 : 2);
			if (_collapseCountState > 0 && num4 != _collapseCountState)
			{
				flag3 = true;
			}
			_collapseCountState = num4;
		}
		if (!first && (flag3 || y != Self.sizeDelta.y))
		{
			NotificationManager.Instance.UpdateY();
			return true;
		}
		return false;
	}
}
