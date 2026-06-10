using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SurveillanceApp : CruncherAppContent
{
	[Header("Components")]
	public TextMeshProUGUI titleText;

	public TextMeshProUGUI cameraSelectionText;

	public RectTransform timelineRect;

	public RectTransform timelineScrub;

	public ComputerOSUIComponent scrubUI;

	public GameObject timelineEntryPrefab;

	public TextMeshProUGUI timestampText;

	public TextMeshProUGUI timestampTextShadow;

	public TextMeshProUGUI locationstampText;

	public TextMeshProUGUI locationstampTextShadow;

	public RenderTexture renderTexturePrefab;

	public RawImage captureDisplay;

	public RectTransform captureRect;

	public Button yesterdayButton;

	public Button todayButton;

	public Button actorNextButton;

	public Button actorPrevButton;

	public TextMeshProUGUI printButtonText;

	public RectTransform actorPageRect;

	public RectTransform camDisplayPageRect;

	public RawImage actorImage;

	public TextMeshProUGUI actorNameText;

	public Button acquireNameButton;

	public Button actorBackButton;

	public TextMeshProUGUI actorPageText;

	public TextMeshProUGUI yesterdayText;

	public TextMeshProUGUI todayText;

	[Space(5f)]
	public RectTransform actorListRect;

	public GameObject actorListPrefab;

	public RectTransform locator;

	[Space(7f)]
	public Color timelineColor;

	public Color timelineMOColor;

	public Color timelineFlagColor;

	[Header("State")]
	public List<Interactable> cameras;

	[NonSerialized]
	public Interactable selectedCamera;

	public List<Interactable> selectedSentries;

	public List<SceneRecorder.SceneCapture> loadedCaptures;

	private List<CruncherTimelineEntry> spawnedTimelineEntries;

	public List<CruncherSurveillanceActorEntry> spawnedActorEntries;

	public CruncherSurveillanceActorEntry hoveredActor;

	public CruncherSurveillanceActorEntry selectedActor;

	public Human flaggedActor;

	public bool dispayYesterday;

	public Vector2 timelineScale;

	public float timelineCovers;

	public SceneRecorder.SceneCapture currentScene;

	public float currentSceneGametime;

	public float scrubTime;

	public int actorPage;

	public float loadInHeadshots;

	public bool scrubMove;

	private Vector3 scrubOffset;

	public bool actorPageActive;

	public override void OnSetup()
	{
	}

	public void SetCamera(Interactable newSelection)
	{
	}

	private void OnSelectedCameraNewCapture()
	{
	}

	private void OnDestroy()
	{
	}

	private void Update()
	{
	}

	public void UpdateScrub(bool forceTime = false, float newScrub = 0f)
	{
	}

	public void SetScene(SceneRecorder.SceneCapture newScene)
	{
	}

	public void CameraSelection(int addSelection)
	{
	}

	public void ExitButton()
	{
	}

	public void NextCaptureButtion(int val)
	{
	}

	public override void PrintButton()
	{
	}

	public void SetCamActiveButton(bool val)
	{
	}

	private void UpdateCamStatus()
	{
	}

	private void UpdateActorList()
	{
	}

	public void SetActorPage(int val)
	{
	}

	public void SelectActor(CruncherSurveillanceActorEntry actorButton)
	{
	}

	public void SetActorPage(bool val, bool forceUpdate = false)
	{
	}

	public void ActorBackButton()
	{
	}

	public void AcquireNameButton()
	{
	}

	public void ToggleFlagOnFootage()
	{
	}

	public void SetFlaggedActor(Human h)
	{
	}

	public void UpdateTimelineFlagging()
	{
	}

	public void SaveToTapeButton()
	{
	}

	public void YesterdayButton()
	{
	}

	public void TodayButton()
	{
	}
}
