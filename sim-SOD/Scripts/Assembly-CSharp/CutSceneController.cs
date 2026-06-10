using System.Collections.Generic;
using NaughtyAttributes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CutSceneController : MonoBehaviour
{
	[Header("Components")]
	public Image displayImage;

	public CanvasRenderer displayImageRend;

	public TextMeshProUGUI cutSceneSkipText;

	[Header("State")]
	public bool cutSceneActive;

	public float sceneTimer;

	public CutScenePreset preset;

	public int cursor;

	private CutScenePreset.CutSceneElement previousElement;

	private List<CutScenePreset.CameraMovement> currentCamMovement;

	private CutScenePreset.CameraMovement currentFrom;

	private CutScenePreset.CameraMovement currentTo;

	public float currentShotTimer;

	private Vector3 playerSavedPosition;

	private Quaternion camSavedLocalQuat;

	private bool savedFreeCam;

	private bool savedInaudible;

	private bool savedInvisible;

	private bool savedInvincible;

	private bool savedPhotoMode;

	private bool triggeredFadeOut;

	private CutScenePreset.CutSceneElement finalShot;

	private bool triggeredImage;

	private float imageFadeIn;

	private float imageFadeOut;

	[Header("Debug")]
	public CutScenePreset debugLoad;

	private static CutSceneController _instance;

	public static CutSceneController Instance => null;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	public void PlayCutScene(CutScenePreset newPreset)
	{
	}

	private void Update()
	{
	}

	private void UpdateCam(Vector3 position, Quaternion rotation, bool updateMixing)
	{
	}

	private void SetActive(bool val)
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void PlayScene()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void StopScene()
	{
	}
}
