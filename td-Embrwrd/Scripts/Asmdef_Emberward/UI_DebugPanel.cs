using TMPro;
using UnityEngine;

public class UI_DebugPanel : MonoBehaviour
{
	[SerializeField]
	private TMP_Text fpsText;

	[SerializeField]
	private TMP_Text resolutionText;

	[SerializeField]
	private TMP_Text timeElapsedText;

	[SerializeField]
	private TMP_Text vSyncText;

	[SerializeField]
	private TMP_Text timeScaleText;

	[SerializeField]
	private TMP_Text stageInfoText;

	[SerializeField]
	private TMP_Text controllerInfoText;

	private float deltaTime;

	private int framesCount;

	private float fps;

	private void Awake()
	{
	}

	private void Update()
	{
	}

	private void UpdateFPS()
	{
	}

	private void UpdateResolution()
	{
	}

	private void UpdateTimeElapsed()
	{
	}

	private void UpdateVSync()
	{
	}

	private string FormatTime(float time)
	{
		return null;
	}

	private void UpdateTimeScale()
	{
	}

	private void UpdateStageInfo()
	{
	}

	private void UpdateControllerInfo()
	{
	}
}
