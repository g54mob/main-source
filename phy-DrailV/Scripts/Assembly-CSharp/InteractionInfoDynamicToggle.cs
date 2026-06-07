using DV;
using DV.Interaction;
using DV.Interaction.Inputs;
using DV.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InteractionInfoDynamicToggle : MonoBehaviour
{
	private enum DynamicFadeDirection
	{
		None = 0,
		ToMax = 1,
		ToMin = 2
	}

	[SerializeField]
	private TextMeshProUGUI outlineText;

	[SerializeField]
	private TextMeshProUGUI normalText;

	[SerializeField]
	private Image crosshair;

	[SerializeField]
	private float fadeTime = 0.1f;

	[SerializeField]
	private float mouseMovementSqrThreshold = 0.01f;

	private const float IDLE_TIME = 1.7f;

	private float elapsedFadeTime;

	private float visibleIdleElapsedTime;

	private float fadeMax = 1f;

	private float fadeMin;

	private bool fadedOut;

	private DynamicFadeDirection fadeDirection;

	private Grabber grabber;

	private Transform cam;

	private Transform camHolder;

	private InfoVisibilityValues state;

	public float FadeValue { get; private set; }

	private void Start()
	{
		cam = PlayerManager.PlayerCamera.transform;
		camHolder = cam.parent;
		ChangeInfoVisibilityState((InfoVisibilityValues)GamePreferences.Get<int>(Preferences.Crosshair));
		SetupListeners(on: true);
		base.enabled = state == InfoVisibilityValues.Auto;
		FadeValue = 1f;
	}

	private void ChangeInfoVisibilityState(InfoVisibilityValues prefValue)
	{
		state = prefValue;
	}

	private void OnDestroy()
	{
		SetupListeners(on: false);
	}

	private void SetupListeners(bool on)
	{
		if (on)
		{
			GamePreferences.RegisterToPreferenceUpdated(Preferences.Crosshair, TryUpdateVisibility);
			SingletonBehaviour<AppUtil>.Instance.GameUnpaused += OnVisiblityUpdated;
			return;
		}
		if (!UnloadWatcher.isUnloading)
		{
			SingletonBehaviour<AppUtil>.Instance.GameUnpaused -= OnVisiblityUpdated;
		}
		GamePreferences.UnregisterFromPreferenceUpdated(Preferences.Crosshair, TryUpdateVisibility);
	}

	private void TryUpdateVisibility()
	{
		if (TimeUtil.IsFlowing)
		{
			OnVisiblityUpdated();
		}
	}

	private void OnVisiblityUpdated()
	{
		InfoVisibilityValues infoVisibilityValues = (InfoVisibilityValues)GamePreferences.Get<int>(Preferences.Crosshair);
		if (state != infoVisibilityValues)
		{
			ChangeInfoVisibilityState(infoVisibilityValues);
			bool flag = state == InfoVisibilityValues.Auto;
			if (!flag)
			{
				ResetVisibility();
			}
			base.enabled = flag;
		}
	}

	private void ResetVisibility()
	{
		fadedOut = false;
		elapsedFadeTime = 0f;
		visibleIdleElapsedTime = 0f;
		Color color = outlineText.color;
		color.a = 1f;
		outlineText.color = color;
		color = normalText.color;
		color.a = 1f;
		normalText.color = color;
		color = crosshair.color;
		color.a = 1f;
		crosshair.color = color;
		FadeValue = 1f;
	}

	private void Update()
	{
		if (!TimeUtil.IsFlowing)
		{
			return;
		}
		if (fadeDirection == DynamicFadeDirection.None)
		{
			if (fadedOut)
			{
				if (TriggerFadeByRotation(DynamicFadeDirection.ToMax))
				{
					fadeDirection = DynamicFadeDirection.ToMax;
					InvertFadeTime();
					visibleIdleElapsedTime = 0f;
				}
			}
			else if (TriggerFadeByRotation(DynamicFadeDirection.ToMin))
			{
				if (visibleIdleElapsedTime >= 1.7f)
				{
					fadeDirection = DynamicFadeDirection.ToMin;
					InvertFadeTime();
					visibleIdleElapsedTime = 0f;
				}
				else
				{
					visibleIdleElapsedTime += Time.deltaTime;
				}
			}
			else
			{
				visibleIdleElapsedTime = 0f;
			}
		}
		else if (fadeDirection != DynamicFadeDirection.ToMax && TriggerFadeByRotation(DynamicFadeDirection.ToMax))
		{
			fadeDirection = DynamicFadeDirection.ToMax;
		}
		else
		{
			elapsedFadeTime += Time.deltaTime;
			float num = ((fadeDirection == DynamicFadeDirection.ToMax) ? (elapsedFadeTime / fadeTime) : (1f - elapsedFadeTime / fadeTime));
			FadeUiElements(num, fadeDirection);
			FadeValue = num;
			if (elapsedFadeTime >= fadeTime)
			{
				elapsedFadeTime = fadeTime;
				fadedOut = DynamicFadeDirection.ToMin == fadeDirection;
				fadeDirection = DynamicFadeDirection.None;
			}
		}
	}

	private void InvertFadeTime()
	{
		elapsedFadeTime = Mathf.Clamp(fadeTime - elapsedFadeTime, 0f, fadeTime);
	}

	private void FadeUiElements(float fadeFactor, DynamicFadeDirection fadeDirection)
	{
		FadeText(outlineText, fadeFactor, fadeDirection);
		FadeText(normalText, fadeFactor, fadeDirection);
		FadeImage(crosshair, fadeFactor, fadeDirection);
	}

	private bool TriggerFadeByRotation(DynamicFadeDirection desiredDirection)
	{
		bool result = false;
		Vector2 mouseAxisInput = InputManager.GetMouseAxisInput();
		switch (desiredDirection)
		{
		case DynamicFadeDirection.ToMax:
			result = mouseAxisInput.sqrMagnitude > mouseMovementSqrThreshold;
			break;
		case DynamicFadeDirection.ToMin:
			result = mouseAxisInput.sqrMagnitude < mouseMovementSqrThreshold;
			break;
		default:
			Debug.LogError($"Fade cannot be triggered by '{desiredDirection}'. Returning false.", this);
			break;
		}
		return result;
	}

	private void FadeText(TextMeshProUGUI text, float fadeFactor, DynamicFadeDirection fadeDirection)
	{
		if (ValidateFadeValue(text.color.a, fadeFactor, fadeDirection))
		{
			Color color = text.color;
			color.a = fadeFactor;
			text.color = color;
		}
	}

	private void FadeImage(Image image, float fadeFactor, DynamicFadeDirection fadeDirection)
	{
		if (ValidateFadeValue(image.color.a, fadeFactor, fadeDirection))
		{
			Color color = image.color;
			color.a = fadeFactor;
			image.color = color;
		}
	}

	private bool ValidateFadeValue(float currentValue, float desiredValue, DynamicFadeDirection direction)
	{
		switch (direction)
		{
		case DynamicFadeDirection.ToMax:
			if (desiredValue < currentValue)
			{
				return false;
			}
			_ = fadeMax;
			break;
		case DynamicFadeDirection.ToMin:
			if (desiredValue > currentValue)
			{
				return false;
			}
			_ = fadeMin;
			break;
		default:
			Debug.LogError(string.Format("{0} with value {1} is invalid. No fading can be done.", "DynamicFadeDirection", direction), this);
			return false;
		}
		return true;
	}
}
