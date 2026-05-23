using System;
using UnityEngine;
using UnityEngine.UI;

public class UIDynamicContent : MonoBehaviour
{
	[SerializeField]
	private RectTransform _panel;

	[SerializeField]
	private GameObject _contentWrapper;

	[SerializeField]
	private GameObject _contentLoader;

	[SerializeField]
	private ScreenshotContest _screenshotContest;

	[SerializeField]
	private GameObject _expandedPanel;

	[SerializeField]
	private Button _expandButton;

	[SerializeField]
	private Button _bgButton;

	[SerializeField]
	private Button _closeButton;

	private void Awake()
	{
		_contentLoader.SetActive(value: true);
		_contentWrapper.SetActive(value: false);
		ScreenshotContest screenshotContest = _screenshotContest;
		screenshotContest.OnContentAvailable = (Action<bool>)Delegate.Combine(screenshotContest.OnContentAvailable, new Action<bool>(OnContentAvailable));
		_bgButton.onClick.AddListener(CloseExpandedPanel);
		_closeButton.onClick.AddListener(CloseExpandedPanel);
		_expandButton.onClick.AddListener(ExpandPanel);
	}

	private void OnDestroy()
	{
		ScreenshotContest screenshotContest = _screenshotContest;
		screenshotContest.OnContentAvailable = (Action<bool>)Delegate.Remove(screenshotContest.OnContentAvailable, new Action<bool>(OnContentAvailable));
		_bgButton.onClick.RemoveListener(CloseExpandedPanel);
		_closeButton.onClick.RemoveListener(CloseExpandedPanel);
		_expandButton.onClick.RemoveListener(ExpandPanel);
	}

	private void OnContentAvailable(bool success)
	{
		if (success)
		{
			_contentLoader.SetActive(value: false);
			_contentWrapper.SetActive(value: true);
		}
		_panel.ForceUpdateRectTransforms();
		LayoutRebuilder.ForceRebuildLayoutImmediate(_panel);
	}

	private void ExpandPanel()
	{
		_expandedPanel.SetActive(value: true);
	}

	private void CloseExpandedPanel()
	{
		_expandedPanel.SetActive(value: false);
	}
}
