using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Components;
using UnityEngine.UI;

public class BigProgressBar : MonoBehaviour
{
	[SerializeField]
	private Image _fillImage;

	[SerializeField]
	private LocalizedString _demoCompletionString;

	[SerializeField]
	private LocalizedString _completionString;

	[SerializeField]
	private LocalizeStringEvent _localizedTextEvent;

	private int _totalUnlockableCount;

	private int _demoUnlockableCount;

	private int _currentUnlockCount;

	[SerializeField]
	private SimpleFillBar _fillBar;

	public void Initiate(int currentUpgradeCount, int totalUnlockableCount, int demoUnlockableCount = 1)
	{
	}

	private void OnEnable()
	{
	}

	public void UpdateAppearance()
	{
	}

	public void SetProgress(int currentUpgradeCount)
	{
	}
}
