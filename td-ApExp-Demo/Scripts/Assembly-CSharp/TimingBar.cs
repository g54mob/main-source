using System;
using System.Collections;
using AudioSystem;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class TimingBar : MonoBehaviour
{
	[SerializeField]
	private TimingBarTypes type;

	[Header("UI References")]
	public RectTransform movingSlider;

	public RectTransform highlightArea;

	public RectTransform fillArea;

	[SerializeField]
	private Image areaImage;

	[SerializeField]
	private Image sliderImage;

	[Header("Sprites")]
	[SerializeField]
	private Sprite areaActive;

	[SerializeField]
	private Sprite areaFailure;

	[SerializeField]
	private Sprite areaSuccess;

	[SerializeField]
	private Sprite areaInactive;

	[SerializeField]
	private Sprite sliderActive;

	[SerializeField]
	private Sprite sliderInactive;

	[SerializeField]
	private Sprite sliderFlash;

	[Header("Audio")]
	[SerializeField]
	private UnitAudioController audioController;

	private SoundBuilder soundBuilder;

	[Header("Settings")]
	public float sliderSpeed;

	[SerializeField]
	[Tooltip("Percent of the parent Bars width as width")]
	private float maxAreaWidthPercent;

	[SerializeField]
	[Tooltip("Percent of the parent Bars width as width")]
	private float minAreaWidthPercent;

	[SerializeField]
	private float maxAreaWidthAtResourcePercent;

	[SerializeField]
	private float minAreaWidthAtResourcePercent;

	[SerializeField]
	private float checkTime;

	public float resourceGained;

	public float overfillingChargingPercentGain;

	private float coopResourceModifier;

	[SerializeField]
	private bool pauseResourceGain;

	private bool movingRight = true;

	private float minX;

	private float maxX;

	private bool active;

	[NonSerialized]
	public Health currentModule;

	[NonSerialized]
	public PlayerController currentPlayer;

	private RectTransform parentRect;

	private float tempSpeed;

	private Quaternion originalRotation;

	private bool pauseUpdateArea;

	private bool animationStarted;

	private bool readyToReset;

	[Header("SFX")]
	[SerializeField]
	private SoundData onSuccessSound;

	[SerializeField]
	private SoundData onFailSound;

	public event Action OnSuccess;

	public event Action OnFail;

	private void Start()
	{
		InputManager.Instance.OnInteract += ShovelCheck;
		InputManager.Instance.OnXPressed += RepairCheck;
		originalRotation = highlightArea.rotation;
		soundBuilder = PersistentSingleton<SoundEmitterManager>.Instance.CreateSoundBuilder();
	}

	private void Update()
	{
		if (type == TimingBarTypes.Shovel)
		{
			if (Train.Instance.preventCoalGain)
			{
				return;
			}
			UpdateAreaWidth(Train.Instance.CoalSeconds, Train.Instance.CoalSecondsCapacity, maxAreaWidthAtResourcePercent, minAreaWidthAtResourcePercent);
		}
		if (type == TimingBarTypes.Repair)
		{
			UpdateAreaWidth(currentModule.HealthCurrent, currentModule.HealthMax, maxAreaWidthAtResourcePercent, minAreaWidthAtResourcePercent);
		}
		float x = movingSlider.anchoredPosition.x;
		if (movingRight)
		{
			x += sliderSpeed * Time.deltaTime;
			if (x >= maxX)
			{
				if (animationStarted)
				{
					active = true;
					readyToReset = true;
				}
				else
				{
					Restart();
				}
				movingRight = false;
			}
		}
		else
		{
			x -= sliderSpeed * Time.deltaTime;
			if (x <= minX)
			{
				if (animationStarted)
				{
					active = true;
					readyToReset = true;
				}
				else
				{
					Restart();
				}
				movingRight = true;
			}
		}
		movingSlider.anchoredPosition = new Vector2(x, movingSlider.anchoredPosition.y);
	}

	public void SetupBar()
	{
		pauseUpdateArea = false;
		parentRect = fillArea;
		minX = (0f - parentRect.rect.width) / 2f + 1.5f;
		maxX = parentRect.rect.width / 2f - 1.5f;
		if (tempSpeed > 0f)
		{
			sliderSpeed = tempSpeed;
		}
		movingSlider.anchoredPosition = new Vector2(minX, movingSlider.anchoredPosition.y);
		coopResourceModifier = (PlayerManager.Instance.IsCoop ? DifficultyManager.Instance.CoopTimingBarMultiplier : 1f);
		Restart();
	}

	private void UpdateAreaWidth(float currentResourceValue, float maxResourceValue, float maxValueAt, float minValueAt)
	{
		if (!pauseUpdateArea)
		{
			float num = currentResourceValue / maxResourceValue;
			float num2;
			if (num <= maxValueAt)
			{
				num2 = maxAreaWidthPercent;
			}
			else if (num >= minValueAt)
			{
				num2 = minAreaWidthPercent;
			}
			else
			{
				float num3 = minValueAt - maxValueAt;
				float num4 = (num - maxValueAt) / num3;
				num2 = maxAreaWidthPercent + (minAreaWidthPercent - maxAreaWidthPercent) * num4;
			}
			highlightArea.sizeDelta = new Vector2(parentRect.sizeDelta.x * num2, highlightArea.sizeDelta.y);
		}
	}

	private void RepairCheck(int playerIndex, InputAction.CallbackContext ctx)
	{
		if (currentModule != null && !currentModule.gameObject.GetComponent<Module>().IsFullyBroken && type == TimingBarTypes.Repair && playerIndex == currentPlayer.PlayerIndex)
		{
			CheckSuccess();
		}
	}

	private void ShovelCheck(int playerIndex, InputAction.CallbackContext ctx)
	{
		if (type == TimingBarTypes.Shovel && playerIndex == currentPlayer.PlayerIndex)
		{
			CheckSuccess();
		}
	}

	private void CheckSuccess()
	{
		if (active && base.gameObject.activeInHierarchy)
		{
			active = false;
			RectTransform component = highlightArea.GetComponent<RectTransform>();
			Rect screenRect = GetScreenRect(component);
			RectTransform rectTransform = movingSlider;
			Vector2 vector = RectTransformUtility.WorldToScreenPoint(null, rectTransform.position);
			if (vector.x >= screenRect.xMin && vector.x <= screenRect.xMax)
			{
				StartCoroutine(Success());
			}
			else
			{
				StartCoroutine(Fail());
			}
		}
	}

	private Rect GetScreenRect(RectTransform rectTransform)
	{
		Vector3[] array = new Vector3[4];
		rectTransform.GetWorldCorners(array);
		Vector3 vector = RectTransformUtility.WorldToScreenPoint(null, array[0]);
		Vector3 vector2 = RectTransformUtility.WorldToScreenPoint(null, array[2]);
		return new Rect(vector.x, vector.y, vector2.x - vector.x, vector2.y - vector.y);
	}

	private IEnumerator Success()
	{
		animationStarted = true;
		this.OnSuccess?.Invoke();
		areaImage.sprite = areaSuccess;
		sliderImage.sprite = sliderFlash;
		soundBuilder.Play(onSuccessSound);
		Vector3 vector = new Vector3(base.transform.position.x - 0.3f, base.transform.position.y + 1.5f, base.transform.position.z);
		float num = resourceGained * coopResourceModifier * GlobalFields.Instance.TimingMinigameGainModifier;
		float progressAmount = 0f;
		if (type == TimingBarTypes.Shovel)
		{
			ModuleFurnace furnace = Train.Instance.furnace;
			if (furnace.chargingOverfill)
			{
				num = furnace.OverfillTimeNeeded * (overfillingChargingPercentGain / 100f);
				string arg = (Mathf.Approximately(num % 1f, 0f) ? $"{num:0}" : $"{num:0.0}");
				base.gameObject.GetComponent<FloatingText>().SpawnFloatingText(vector, $"+{arg:F2}s <sprite index=0>");
				Train.Instance.CoalSeconds += 5f;
				furnace.OverfillTimeNow += num;
			}
			else
			{
				string arg2 = (Mathf.Approximately(num % 1f, 0f) ? $"{num:0}" : $"{num:0.0}");
				base.gameObject.GetComponent<FloatingText>().SpawnFloatingText(vector, $"+{arg2:F2}s <sprite index=0>");
				Train.Instance.CoalSeconds += num;
				progressAmount = num;
			}
			UpdateAreaWidth(Train.Instance.CoalSeconds, Train.Instance.CoalSecondsCapacity, maxAreaWidthAtResourcePercent, minAreaWidthAtResourcePercent);
			if (pauseResourceGain)
			{
				Train.Instance.pauseCoal = true;
			}
		}
		else if (type == TimingBarTypes.Repair)
		{
			string arg3 = (Mathf.Approximately(num % 1f, 0f) ? $"{num:0}" : $"{num:0.0}");
			base.gameObject.GetComponent<FloatingText>().SpawnFloatingText(vector, $"+{arg3:F2}% <sprite index=0>");
			currentModule.Fix(num, isPercent: true);
			progressAmount = currentModule.HealthMax * num / 100f;
			UpdateAreaWidth(currentModule.HealthCurrent, currentModule.HealthMax, maxAreaWidthAtResourcePercent, minAreaWidthAtResourcePercent);
			if (pauseResourceGain)
			{
				currentPlayer.pauseRepairing = true;
			}
		}
		foreach (MilestoneTimingMinigame timingMinigamesMilestone in MilestoneManager.Instance.TimingMinigamesMilestones)
		{
			if (!timingMinigamesMilestone.Completed)
			{
				timingMinigamesMilestone.AddProgress(progressAmount, type);
			}
		}
		Vector2 originalSize = highlightArea.sizeDelta;
		float elapsedTime = 0f;
		float duration = checkTime / 4f;
		pauseUpdateArea = true;
		float currentSizePercent = 1f - Mathf.InverseLerp(fillArea.sizeDelta.x * minAreaWidthPercent, fillArea.sizeDelta.x * maxAreaWidthPercent, highlightArea.sizeDelta.x);
		currentSizePercent = 0.5f * currentSizePercent;
		currentSizePercent = Mathf.Clamp(currentSizePercent, 0.1f, 0.5f);
		Vector2 targetSize = new Vector2(originalSize.x * (1f + currentSizePercent / 2f), originalSize.y);
		Quaternion targetRotation = Quaternion.Euler(0f, 0f, -6f * (1f + currentSizePercent)) * originalRotation;
		while (elapsedTime < duration)
		{
			float t = elapsedTime / duration;
			highlightArea.sizeDelta = Vector2.Lerp(originalSize, targetSize, t);
			highlightArea.rotation = Quaternion.Slerp(originalRotation, targetRotation, t);
			elapsedTime += Time.deltaTime;
			yield return null;
		}
		Vector2 targetSize2 = new Vector2(highlightArea.sizeDelta.x * (1f + currentSizePercent), originalSize.y);
		elapsedTime = 0f;
		while (elapsedTime < duration)
		{
			float t2 = elapsedTime / duration;
			highlightArea.sizeDelta = Vector2.Lerp(highlightArea.sizeDelta, targetSize2, t2);
			highlightArea.rotation = Quaternion.Slerp(highlightArea.rotation, Quaternion.Euler(0f, 0f, 6f * (1f + currentSizePercent)) * originalRotation, t2);
			elapsedTime += Time.deltaTime;
			yield return null;
		}
		Vector2 targetSize3 = new Vector2(highlightArea.sizeDelta.x * (1f + currentSizePercent / 2f), originalSize.y);
		elapsedTime = 0f;
		while (elapsedTime < duration)
		{
			float t3 = elapsedTime / duration;
			highlightArea.sizeDelta = Vector2.Lerp(highlightArea.sizeDelta, targetSize3, t3);
			highlightArea.rotation = Quaternion.Slerp(highlightArea.rotation, Quaternion.Euler(0f, 0f, -6f * (1f + currentSizePercent)) * originalRotation, t3);
			elapsedTime += Time.deltaTime;
			yield return null;
		}
		elapsedTime = 0f;
		while (elapsedTime < duration)
		{
			float t4 = elapsedTime / duration;
			highlightArea.sizeDelta = Vector2.Lerp(highlightArea.sizeDelta, originalSize, t4);
			highlightArea.rotation = Quaternion.Slerp(highlightArea.rotation, Quaternion.Euler(0f, 0f, 6f * (1f + currentSizePercent)) * originalRotation, t4);
			elapsedTime += Time.deltaTime;
			yield return null;
		}
		elapsedTime = 0f;
		while (elapsedTime < 0.1f)
		{
			float t5 = elapsedTime / 0.1f;
			highlightArea.rotation = Quaternion.Slerp(highlightArea.rotation, originalRotation, t5);
			elapsedTime += Time.deltaTime;
			yield return null;
		}
		highlightArea.rotation = originalRotation;
		pauseUpdateArea = false;
		if (type == TimingBarTypes.Shovel)
		{
			Train.Instance.pauseCoal = false;
		}
		else if (type == TimingBarTypes.Repair)
		{
			currentPlayer.pauseRepairing = false;
		}
		animationStarted = false;
		if (readyToReset)
		{
			Restart();
		}
	}

	private IEnumerator Fail()
	{
		animationStarted = true;
		this.OnFail?.Invoke();
		areaImage.sprite = areaFailure;
		sliderImage.sprite = sliderFlash;
		if (onFailSound.clips.Count > 0)
		{
			soundBuilder.Play(onFailSound);
		}
		if (pauseResourceGain)
		{
			if (type == TimingBarTypes.Shovel)
			{
				Train.Instance.pauseCoal = true;
			}
			else if (type == TimingBarTypes.Repair)
			{
				currentPlayer.pauseRepairing = true;
			}
		}
		float elapsedTime = 0f;
		float duration = checkTime / 4f;
		pauseUpdateArea = true;
		float currentSizePercent = 1f - Mathf.InverseLerp(fillArea.sizeDelta.x * minAreaWidthPercent, fillArea.sizeDelta.x * maxAreaWidthPercent, highlightArea.sizeDelta.x);
		currentSizePercent = 0.5f * currentSizePercent;
		currentSizePercent = Mathf.Clamp(currentSizePercent, 0.1f, 0.5f);
		Quaternion targetRotation = Quaternion.Euler(0f, 0f, -6f * (1f + currentSizePercent)) * originalRotation;
		while (elapsedTime < duration)
		{
			float t = elapsedTime / duration;
			highlightArea.rotation = Quaternion.Slerp(originalRotation, targetRotation, t);
			elapsedTime += Time.deltaTime;
			yield return null;
		}
		elapsedTime = 0f;
		while (elapsedTime < duration)
		{
			float t2 = elapsedTime / duration;
			highlightArea.rotation = Quaternion.Slerp(highlightArea.rotation, Quaternion.Euler(0f, 0f, 6f * (1f + currentSizePercent)) * originalRotation, t2);
			elapsedTime += Time.deltaTime;
			yield return null;
		}
		elapsedTime = 0f;
		while (elapsedTime < duration)
		{
			float t3 = elapsedTime / duration;
			highlightArea.rotation = Quaternion.Slerp(highlightArea.rotation, Quaternion.Euler(0f, 0f, -6f * (1f + currentSizePercent)) * originalRotation, t3);
			elapsedTime += Time.deltaTime;
			yield return null;
		}
		elapsedTime = 0f;
		while (elapsedTime < duration)
		{
			float t4 = elapsedTime / duration;
			highlightArea.rotation = Quaternion.Slerp(highlightArea.rotation, Quaternion.Euler(0f, 0f, 6f * (1f + currentSizePercent)) * originalRotation, t4);
			elapsedTime += Time.deltaTime;
			yield return null;
		}
		elapsedTime = 0f;
		while (elapsedTime < 0.1f)
		{
			float t5 = elapsedTime / 0.1f;
			highlightArea.rotation = Quaternion.Slerp(highlightArea.rotation, originalRotation, t5);
			elapsedTime += Time.deltaTime;
			yield return null;
		}
		highlightArea.rotation = originalRotation;
		pauseUpdateArea = false;
		if (type == TimingBarTypes.Shovel)
		{
			Train.Instance.pauseCoal = false;
		}
		else if (type == TimingBarTypes.Repair)
		{
			currentPlayer.pauseRepairing = false;
		}
		animationStarted = false;
		if (readyToReset)
		{
			Restart();
		}
	}

	private void Restart()
	{
		if (base.gameObject.activeInHierarchy)
		{
			sliderImage.sprite = sliderActive;
			areaImage.sprite = areaActive;
			highlightArea.rotation = originalRotation;
			active = true;
			readyToReset = false;
			currentPlayer.pauseRepairing = false;
			Train.Instance.pauseCoal = false;
		}
	}

	private void OnEnable()
	{
		SetupBar();
	}

	private void OnDisable()
	{
		currentPlayer.pauseRepairing = false;
		Train.Instance.pauseCoal = false;
	}
}
