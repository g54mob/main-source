using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResolutionSettingsUI : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI _resolutionText;

	[SerializeField]
	private CanvasGroup _applyButtonCanvasGroup;

	[SerializeField]
	private float _applyButtonEnabledAlpha;

	[SerializeField]
	private float _applyButtonDisabledAlpha;

	public List<Resolution> Resolutions { get; private set; }

	public int AppliedIndex { get; private set; }

	public int ResolutionIndex { get; private set; }

	private void OnEnable()
	{
	}

	public void IterateResolution()
	{
	}

	public void ApplyResolution()
	{
	}

	private void SeSetApplyButtonEnabled()
	{
	}
}
