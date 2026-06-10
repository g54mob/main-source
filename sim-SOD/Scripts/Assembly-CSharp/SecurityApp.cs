using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SecurityApp : CruncherAppContent
{
	[Header("Components")]
	public TextMeshProUGUI titleText;

	public TextMeshProUGUI cameraSelectionText;

	public TextMeshProUGUI targetSelectionText;

	public TextMeshProUGUI locationstampText;

	public TextMeshProUGUI locationstampTextShadow;

	public RenderTexture renderTexturePrefab;

	public RawImage captureDisplay;

	public RectTransform captureRect;

	public Button camOnButton;

	public Button camOffButton;

	public Button alarmOnButton;

	public Button alarmOffButton;

	public RectTransform camDisplayPageRect;

	[Space(5f)]
	public TextMeshProUGUI camOnText;

	public TextMeshProUGUI camOffText;

	public TextMeshProUGUI alarmOnText;

	public TextMeshProUGUI alarmOffText;

	[Header("State")]
	public List<Interactable> cameras;

	[NonSerialized]
	public Interactable selectedCamera;

	public List<Interactable> selectedSentries;

	private float camUpdateTimer;

	public override void OnSetup()
	{
	}

	public void SetCamera(Interactable newSelection)
	{
	}

	private void Update()
	{
	}

	public void CameraSelection(int addSelection)
	{
	}

	public void AlarmTargetSelection(int addSelection)
	{
	}

	public void ExitButton()
	{
	}

	public void SetCamActiveButton(bool val)
	{
	}

	public void SetAlarmActiveButton(bool val)
	{
	}

	private void UpdateCamStatus()
	{
	}
}
