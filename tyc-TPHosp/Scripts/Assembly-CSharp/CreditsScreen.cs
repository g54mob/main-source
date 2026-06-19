using System;
using TH20;
using TH20.UI;
using UnityEngine;
using UnityEngine.UI;

public class CreditsScreen : MonoBehaviour
{
	[SerializeField]
	private RectTransform _contentTransform;

	[SerializeField]
	private float _secondsBeforeScrolling = 2f;

	[SerializeField]
	private float _scrollSpeedPixelsPerSecond = 200f;

	[SerializeField]
	private Button _backingCloseButton;

	[SerializeField]
	private float _extraPixelsBeforeDestroy = 1000f;

	public Action<bool> OnCreditsStatusChange;

	private double _timeSinceStart;

	private void Awake()
	{
		_backingCloseButton.onClick.AddListener(Close);
		_contentTransform.anchoredPosition = new Vector2(_contentTransform.anchoredPosition.x, 0f);
	}

	private void Start()
	{
		_backingCloseButton.Select();
		if (OnCreditsStatusChange != null)
		{
			OnCreditsStatusChange(obj: true);
		}
	}

	private void Update()
	{
		Rect rect = new Rect(0f, 0f, Screen.width, Screen.height);
		for (int i = 0; i < _contentTransform.childCount; i++)
		{
			Transform child = _contentTransform.GetChild(i);
			GameObjectUtils.SetActive(isActive: rect.Overlaps(child.GetComponent<RectTransform>().GetScreenSpaceRect()), gameObject: child.gameObject);
		}
		_timeSinceStart += Time.unscaledDeltaTime;
		float num = Mathf.Max((float)(_timeSinceStart - (double)_secondsBeforeScrolling), 0f) * _scrollSpeedPixelsPerSecond;
		_contentTransform.anchoredPosition = new Vector2(_contentTransform.anchoredPosition.x, num);
		if (num - _extraPixelsBeforeDestroy >= _contentTransform.rect.height)
		{
			Close();
		}
		if (Input.anyKeyDown)
		{
			Close();
		}
	}

	private void Close()
	{
		if (OnCreditsStatusChange != null)
		{
			OnCreditsStatusChange(obj: false);
		}
		UnityEngine.Object.Destroy(base.gameObject);
	}
}
