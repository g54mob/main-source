using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityStandardAssets.ImageEffects;

public class PhotoModeGUI : MonoBehaviour
{
	public GUIManagerPens guiRef;

	public OptionsMenuToggle UIToggle;

	public OptionsMenuToggle HiResToggle;

	public OptionsMenuToggle particlesToggle;

	public CoreSliderUnityGUI FOVSlider;

	public TextMeshProUGUI FOVSliderText;

	public CoreSliderUnityGUI rotationSlider;

	public TextMeshProUGUI rotationSliderText;

	public CoreSliderUnityGUI DOFFocalSizeSlider;

	public TextMeshProUGUI DOFFocalSizeSliderText;

	public TextMeshProUGUI DOFFocalSizeNameText;

	public CoreSliderUnityGUI DOFApertureSlider;

	public TextMeshProUGUI DOFApertureSliderText;

	public GameObject screenshotSuccessText;

	public GameObject screenshotFailureText;

	public GameObject resetButtonFOV;

	public GameObject resetButtonRotation;

	public GameObject resetButtonAperture;

	public GameObject resetButtonFocalLength;

	public GameObject collapseUIButton;

	public GameObject restoreUIButton;

	public Transform mainUIObject;

	public GameObject closeButton;

	private Vector3 localUIPosRestored = Vector3.zero;

	private Vector3 localUIPosCollapsed = new Vector3(578f, 0f, 0f);

	private bool UIEnabled = true;

	private bool hiResEnabled;

	private bool particlesEnabled = true;

	private string openSound = "photoMode_open";

	private string takePhotoSound = "photoMode_takePhoto";

	private float currentFOV = 60f;

	private float startingFOV = 60f;

	private float minFOV = 20f;

	private float maxFOV = 120f;

	private float currentRotation;

	private float minRotation = -180f;

	private float maxRotation = 180f;

	private float currentDOFFocalSize = 0.05f;

	private float startingDOFFocalSize;

	private float minDOFFocalSize;

	private float maxDOFFocalSize = 100f;

	private float currentDOFAperture = 0.5f;

	private float startingDOFAperture;

	private float minDOFAperture;

	private float maxDOFAperture = 1f;

	private bool inPhotoMode;

	private Coroutine currentSaveTextRoutine;

	private Coroutine currentScreenshotRoutine;

	private PenFocus penFocusRef;

	private DogRegistration dogRegRef;

	private DepthOfField DOFRef;

	private void OnDestroy()
	{
		if (currentScreenshotRoutine != null)
		{
			StopCoroutine(currentScreenshotRoutine);
			currentScreenshotRoutine = null;
		}
		if (currentSaveTextRoutine != null)
		{
			StopCoroutine(currentSaveTextRoutine);
			currentSaveTextRoutine = null;
		}
	}

	private void Update()
	{
		SyncFocalSlider();
		SyncResetButtons();
	}

	public void OnEnterPhotoMode()
	{
		inPhotoMode = true;
		Initialize();
		SyncUIStates();
		screenshotSuccessText.SetActive(value: false);
		screenshotFailureText.SetActive(value: false);
		AudioController.Play(openSound);
	}

	private void Initialize()
	{
		penFocusRef = Camera.main.GetComponent<PenFocus>();
		dogRegRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION);
		startingFOV = penFocusRef.GetCurrentFOV();
		currentFOV = startingFOV;
		DOFRef = penFocusRef.GetDOFRef();
		currentRotation = 0f;
		currentDOFAperture = DOFRef.aperture;
		startingDOFAperture = currentDOFAperture;
		currentDOFFocalSize = DOFRef.focalLength;
		startingDOFFocalSize = currentDOFFocalSize;
		SyncUIStates();
		SyncResetButtons();
		screenshotSuccessText.SetActive(value: false);
		screenshotFailureText.SetActive(value: false);
		OnRestoreUIButtonPressed();
	}

	public void OnExitPhotoMode()
	{
		if (inPhotoMode)
		{
			inPhotoMode = false;
			if (DOFRef != null)
			{
				DOFRef.aperture = startingDOFAperture;
				DOFRef.focalLength = startingDOFFocalSize;
			}
			if (penFocusRef != null)
			{
				penFocusRef.ResetFOV();
				penFocusRef.ResetDutch();
			}
			if (!particlesEnabled)
			{
				SetParticlesVisibility(val: true);
			}
		}
	}

	public void SetStartingAperture(float val)
	{
		startingDOFAperture = val;
	}

	public void OnCollapseUIButtonPressed()
	{
		closeButton.SetActive(value: false);
		collapseUIButton.SetActive(value: false);
		restoreUIButton.SetActive(value: true);
		mainUIObject.localPosition = localUIPosCollapsed;
	}

	public void OnRestoreUIButtonPressed()
	{
		closeButton.SetActive(value: true);
		collapseUIButton.SetActive(value: true);
		restoreUIButton.SetActive(value: false);
		mainUIObject.localPosition = localUIPosRestored;
	}

	public void OnResetFOVButtonPressed()
	{
		currentFOV = startingFOV;
		SyncFOV();
	}

	public void OnResetRotationButtonPressed()
	{
		currentRotation = 0f;
		SyncRotation();
	}

	public void OnResetApertureButtonPressed()
	{
		currentDOFAperture = startingDOFAperture;
		SyncDOFAperture();
	}

	public void OnResetFocalSizeButtonPressed()
	{
		currentDOFFocalSize = startingDOFFocalSize;
		SyncDOFFocalSize();
	}

	private void SyncResetButtons()
	{
		if (resetButtonFOV.activeSelf && currentFOV == startingFOV)
		{
			resetButtonFOV.SetActive(value: false);
		}
		else if (!resetButtonFOV.activeSelf && currentFOV != startingFOV)
		{
			resetButtonFOV.SetActive(value: true);
		}
		if (resetButtonRotation.activeSelf && currentRotation == 0f)
		{
			resetButtonRotation.SetActive(value: false);
		}
		else if (!resetButtonRotation.activeSelf && currentRotation != 0f)
		{
			resetButtonRotation.SetActive(value: true);
		}
		if (resetButtonAperture.activeSelf && currentDOFAperture == startingDOFAperture)
		{
			resetButtonAperture.SetActive(value: false);
		}
		else if (!resetButtonAperture.activeSelf && currentDOFAperture != startingDOFAperture)
		{
			resetButtonAperture.SetActive(value: true);
		}
		if (DOFRef != null && DOFRef.focalTransform != null)
		{
			if (resetButtonFocalLength.activeSelf)
			{
				resetButtonFocalLength.SetActive(value: false);
			}
		}
		else if (resetButtonFocalLength.activeSelf && currentDOFFocalSize == startingDOFFocalSize)
		{
			resetButtonFocalLength.SetActive(value: false);
		}
		else if (!resetButtonFocalLength.activeSelf && currentDOFFocalSize != startingDOFFocalSize)
		{
			resetButtonFocalLength.SetActive(value: true);
		}
	}

	private void SyncUIStates()
	{
		SyncFOV();
		SyncRotation();
		SyncDOFAperture();
		SyncDOFFocalSize();
		SyncUIVisibility();
		SyncHiResScreenshots();
		SyncParticlesVisibility();
	}

	private void SyncFOV()
	{
		FOVSlider.SetValueWithoutNotify(MathUtil.GetPercentageOfRange(currentFOV, minFOV, maxFOV));
		UpdateFOVSliderText();
		penFocusRef.SetFOV(currentFOV);
	}

	public void OnFOVValueUpdated()
	{
		OnFOVValueFinalized();
	}

	public void OnFOVValueFinalized()
	{
		float valueOfRangePercentage = MathUtil.GetValueOfRangePercentage(FOVSlider.value, minFOV, maxFOV);
		currentFOV = MathUtil.Round(valueOfRangePercentage, 1);
		SyncFOV();
	}

	private void UpdateFOVSliderText()
	{
		float valueOfRangePercentage = MathUtil.GetValueOfRangePercentage(FOVSlider.value, minFOV, maxFOV);
		FOVSliderText.text = MathUtil.Round(valueOfRangePercentage, 1).ToString();
	}

	private void SyncDOFAperture()
	{
		DOFApertureSlider.SetValueWithoutNotify(MathUtil.GetPercentageOfRange(currentDOFAperture, minDOFAperture, maxDOFAperture));
		UpdateDOFApertureSliderText();
		DOFRef.aperture = currentDOFAperture;
	}

	private void SyncFocalSlider()
	{
		if (!(DOFRef == null))
		{
			if (DOFFocalSizeSlider.interactable && DOFRef.focalTransform != null)
			{
				DOFFocalSizeSlider.interactable = false;
				DOFFocalSizeNameText.color = DOFFocalSizeSlider.colors.disabledColor;
				DOFFocalSizeSliderText.color = DOFFocalSizeSlider.colors.disabledColor;
			}
			else if (!DOFFocalSizeSlider.interactable && DOFRef.focalTransform == null)
			{
				DOFFocalSizeSlider.interactable = true;
				DOFFocalSizeNameText.color = Color.white;
				DOFFocalSizeSliderText.color = Color.white;
			}
			if (DOFRef.focalTransform != null)
			{
				currentDOFFocalSize = Vector3.Distance(DOFRef.focalTransform.position, penFocusRef.GetCorrectedCamPos());
				SyncDOFFocalSize();
			}
		}
	}

	private void SyncDOFFocalSize()
	{
		DOFFocalSizeSlider.SetValueWithoutNotify(MathUtil.GetPercentageOfRange(currentDOFFocalSize, minDOFFocalSize, maxDOFFocalSize));
		UpdateDOFFocalSizeSliderText();
		DOFRef.focalLength = currentDOFFocalSize;
	}

	public void OnDOFApertureValueUpdated()
	{
		OnApertureValueFinalized();
	}

	public void OnApertureValueFinalized()
	{
		float valueOfRangePercentage = MathUtil.GetValueOfRangePercentage(DOFApertureSlider.value, minDOFAperture, maxDOFAperture);
		currentDOFAperture = valueOfRangePercentage;
		SyncDOFAperture();
	}

	public void OnDOFFocalSizeValueUpdated()
	{
		OnFocalSizeValueFinalized();
	}

	public void OnFocalSizeValueFinalized()
	{
		float valueOfRangePercentage = MathUtil.GetValueOfRangePercentage(DOFFocalSizeSlider.value, minDOFFocalSize, maxDOFFocalSize);
		currentDOFFocalSize = Mathf.RoundToInt(valueOfRangePercentage);
		SyncDOFFocalSize();
	}

	private void UpdateDOFApertureSliderText()
	{
		float valueOfRangePercentage = MathUtil.GetValueOfRangePercentage(DOFApertureSlider.value, minDOFAperture, maxDOFAperture);
		DOFApertureSliderText.text = MathUtil.Round(valueOfRangePercentage, 2).ToString();
	}

	private void UpdateDOFFocalSizeSliderText()
	{
		float valueOfRangePercentage = MathUtil.GetValueOfRangePercentage(DOFFocalSizeSlider.value, minDOFFocalSize, maxDOFFocalSize);
		DOFFocalSizeSliderText.text = Mathf.RoundToInt(valueOfRangePercentage).ToString();
	}

	private void SyncRotation()
	{
		rotationSlider.SetValueWithoutNotify(MathUtil.GetPercentageOfRange(currentRotation, minRotation, maxRotation));
		UpdateRotationSliderText();
		penFocusRef.SetDutch(currentRotation);
	}

	public void OnRotationValueUpdated()
	{
		OnRotationValueFinalized();
	}

	public void OnRotationValueFinalized()
	{
		float valueOfRangePercentage = MathUtil.GetValueOfRangePercentage(rotationSlider.value, minRotation, maxRotation);
		currentRotation = valueOfRangePercentage;
		SyncRotation();
	}

	private void UpdateRotationSliderText()
	{
		float valueOfRangePercentage = MathUtil.GetValueOfRangePercentage(rotationSlider.value, minRotation, maxRotation);
		rotationSliderText.text = Mathf.RoundToInt(valueOfRangePercentage).ToString();
	}

	private void SyncUIVisibility()
	{
		UIToggle.SetToggleState(UIEnabled);
		guiRef.SetUIVisibilityForPhotoMode(UIEnabled);
	}

	public void ToggleUIVisibility()
	{
		UIEnabled = !UIEnabled;
		SyncUIVisibility();
	}

	private void SyncParticlesVisibility()
	{
		particlesToggle.SetToggleState(particlesEnabled);
		SetParticlesVisibility(particlesEnabled);
	}

	private void SetParticlesVisibility(bool val)
	{
		List<GameObject> allDogs = dogRegRef.GetAllDogs();
		for (int i = 0; i < allDogs.Count; i++)
		{
			allDogs[i].GetComponent<DogParticleController>().SetVisibility(val);
		}
	}

	public void ToggleParticlesVisibility()
	{
		particlesEnabled = !particlesEnabled;
		SyncParticlesVisibility();
	}

	public void ToggleHiResScreenshots()
	{
		hiResEnabled = !hiResEnabled;
		SyncHiResScreenshots();
	}

	public void SyncHiResScreenshots()
	{
		HiResToggle.SetToggleState(hiResEnabled);
	}

	public void OnTakeScreenshotButtonPressed()
	{
		if (currentScreenshotRoutine == null)
		{
			AudioController.Play(takePhotoSound);
			currentScreenshotRoutine = StartCoroutine(TakeScreenshotRoutine(hiResEnabled));
		}
	}

	public void OnExitPhotoModeButtonPressed()
	{
		guiRef.ExitPhotoMode();
	}

	public void OnBrowseScreenshotsButtonPressed()
	{
		string screenshotsPath = GetScreenshotsPath();
		if (SystemInfo.operatingSystemFamily == OperatingSystemFamily.Windows)
		{
			OpenWindowsDirectory(screenshotsPath);
		}
		else if (SystemInfo.operatingSystemFamily == OperatingSystemFamily.MacOSX)
		{
			OpenMacDirectory(screenshotsPath);
		}
	}

	private void OpenWindowsDirectory(string dirPath)
	{
		dirPath = dirPath.Replace("/", "\\");
		try
		{
			Process.Start("explorer.exe", "/root," + dirPath);
		}
		catch (Win32Exception message)
		{
			MonoBehaviour.print(message);
			Process.Start("explorer.exe", dirPath + "/");
		}
	}

	private void OpenMacDirectory(string dirPath)
	{
		dirPath = dirPath.Replace("\\", "/");
		if (!dirPath.StartsWith("\""))
		{
			dirPath = "\"" + dirPath;
		}
		if (!dirPath.EndsWith("\""))
		{
			dirPath += "\"";
		}
		string arguments = "-R " + dirPath;
		try
		{
			Process.Start("open", arguments);
		}
		catch (Win32Exception message)
		{
			MonoBehaviour.print(message);
		}
	}

	private string GetScreenshotsPath()
	{
		string text = Application.dataPath + "/Screenshots";
		if (!Directory.Exists(text))
		{
			Directory.CreateDirectory(text);
		}
		return text;
	}

	private IEnumerator TakeScreenshotRoutine(bool hiRes)
	{
		guiRef.photoModeCanvas.enabled = false;
		yield return new WaitForEndOfFrame();
		string filename = GetScreenshotsPath() + "/" + GetTimestamp() + ".png";
		bool success = true;
		try
		{
			if (hiRes)
			{
				ScreenCapture.CaptureScreenshot(filename, 2);
			}
			else
			{
				ScreenCapture.CaptureScreenshot(filename);
			}
		}
		catch
		{
			success = false;
			UnityEngine.Debug.LogError("Failure to save screenshot.");
		}
		yield return new WaitForEndOfFrame();
		guiRef.photoModeCanvas.enabled = true;
		if (currentSaveTextRoutine != null)
		{
			StopCoroutine(currentSaveTextRoutine);
			currentSaveTextRoutine = null;
		}
		currentSaveTextRoutine = StartCoroutine(SaveTextRoutine(success));
		currentScreenshotRoutine = null;
	}

	private IEnumerator SaveTextRoutine(bool success)
	{
		screenshotSuccessText.SetActive(value: false);
		screenshotFailureText.SetActive(value: false);
		if (success)
		{
			screenshotSuccessText.SetActive(value: true);
		}
		else
		{
			screenshotFailureText.SetActive(value: true);
		}
		yield return new WaitForSecondsRealtime(1f);
		screenshotSuccessText.SetActive(value: false);
		screenshotFailureText.SetActive(value: false);
		currentSaveTextRoutine = null;
	}

	private string GetTimestamp()
	{
		return Regex.Replace(DateTime.Now.ToString(), "[^a-zA-Z0-9]", "");
	}
}
