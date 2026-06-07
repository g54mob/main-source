using System.Collections.Generic;
using Assets.Source.Player;
using Assets.Source.World;
using UnityEngine;
using UnityEngine.UI;

public class FrameUI : FullScreenUI
{
	public static bool InfoActive;

	[SerializeField]
	private List<Transform> _persistentElements;

	[SerializeField]
	private UITimerBar _timerPrefab;

	[SerializeField]
	private UIProgressBar _progressPrefab;

	[SerializeField]
	private Image _infoBackground;

	private bool _informationToggled;

	private bool _informationAlt;

	public static FrameUI Instance { get; private set; }

	private void Awake()
	{
		Instance = this;
	}

	private void Start()
	{
	}

	private void Update()
	{
		if (base.FullScreenActive)
		{
			if (PlayerControls.ModifierAlt)
			{
				InfoActive = true;
				_informationAlt = true;
			}
			else if (_informationAlt)
			{
				InfoActive = false;
				_informationAlt = false;
			}
			_infoBackground.color = (InfoActive ? new Color(0f, 1f, 0f, 0.1f) : new Color(0f, 0f, 0f, 0.8f));
		}
	}

	public override void OnFullScreenActivate()
	{
		GamePlayer.Current.RecentInOverview = false;
	}

	public void ShowFrame(WorldFrame frame)
	{
		Clear();
		_infoBackground.gameObject.SetActive(frame.IsPartlyUpgraded() || frame.AutoWorkerMax == 0);
	}

	public void ToggleInformation()
	{
		InfoActive = !InfoActive;
	}

	public bool ReturnToMap()
	{
		if (base.FullScreenActive)
		{
			GameUI.Instance.ShowFullScreenUI(OverviewUI.Instance);
			return true;
		}
		return false;
	}

	public void Clear()
	{
		foreach (Transform item in base.transform)
		{
			if (!_persistentElements.Contains(item))
			{
				Object.Destroy(item.gameObject);
			}
		}
	}

	public UITimerBar ShowTimer(Transform parent, float duration)
	{
		UITimerBar uITimerBar = Object.Instantiate(_timerPrefab, base.transform);
		uITimerBar.StartTimer(duration);
		((RectTransform)uITimerBar.transform).anchoredPosition = base.ActiveCamera.WorldToScreenPoint(parent.transform.position);
		uITimerBar.SetScale(parent.localScale);
		return uITimerBar;
	}

	public UIProgressBar ShowProgress(Transform parent, float progress)
	{
		UIProgressBar uIProgressBar = Object.Instantiate(_progressPrefab, base.transform);
		uIProgressBar.UpdateProgress(progress);
		((RectTransform)uIProgressBar.transform).anchoredPosition = base.ActiveCamera.WorldToScreenPoint(parent.transform.position);
		uIProgressBar.SetScale(parent.localScale);
		return uIProgressBar;
	}
}
