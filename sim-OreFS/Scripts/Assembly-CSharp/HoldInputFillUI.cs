using System.Collections;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class HoldInputFillUI : MonoBehaviour
{
	[Header("Input")]
	public InputActionReference inputAction;

	[Header("UI")]
	public CanvasGroup canvasGroup;

	public Image fillImage;

	[Header("Animator")]
	public Animator animator;

	[Header("Timings")]
	public float holdDuration = 1.5f;

	public float closeDelayAfterPerformed = 0.25f;

	[Header("Pack All Notification")]
	[Tooltip("İşlem tamamlandığında gösterilecek bildirim objesi")]
	public GameObject packAllNotification;

	[Tooltip("Bildirim text'i - kaç item paketlendiği yazılır")]
	public TMP_Text packAllNotificationText;

	[Tooltip("Bildirim gösterim süresi (saniye)")]
	public float packAllNotificationDuration = 2f;

	[Header("Events")]
	public UnityEvent OnHoldPerformed;

	private Coroutine fillRoutine;

	private Coroutine closeRoutine;

	private Coroutine notificationRoutine;

	public void showAnimator()
	{
		if (animator != null)
		{
			animator.enabled = true;
		}
	}

	public void hideAnimator()
	{
		if (animator != null)
		{
			animator.enabled = false;
		}
	}

	private void OnEnable()
	{
		if (!(inputAction == null) && inputAction.action != null)
		{
			inputAction.action.started += OnStarted;
			inputAction.action.performed += OnPerformed;
			inputAction.action.canceled += OnCanceled;
			inputAction.action.Enable();
			SetUI(visible: false, 0f);
		}
	}

	private void OnDisable()
	{
		if (inputAction != null && inputAction.action != null)
		{
			inputAction.action.started -= OnStarted;
			inputAction.action.performed -= OnPerformed;
			inputAction.action.canceled -= OnCanceled;
		}
		StopAllRoutines();
		SetUI(visible: false, 0f);
	}

	private void OnStarted(InputAction.CallbackContext ctx)
	{
		StopAllRoutines();
		SetUI(visible: true, 0f);
		fillRoutine = StartCoroutine(FillOverTime());
	}

	private void OnCanceled(InputAction.CallbackContext ctx)
	{
		StopAllRoutines();
		SetUI(visible: false, 0f);
	}

	private void OnPerformed(InputAction.CallbackContext ctx)
	{
		StopFillRoutine();
		SetFill(1f);
		OnHoldPerformed?.Invoke();
		if (GameManager.Instance != null && GameManager.Instance.localBag != null)
		{
			int num = GameManager.Instance.localBag.ConvertToSack();
			if (num > 0)
			{
				ShowPackAllNotification(num);
			}
		}
		closeRoutine = StartCoroutine(CloseAfterDelay());
	}

	public void ShowPackAllNotification(int itemCount, string localizationKey = null)
	{
		if (!(packAllNotification == null))
		{
			if (packAllNotificationText != null)
			{
				string translation = LocalizationManager.GetTranslation(localizationKey ?? "Notification_PackAllCount");
				packAllNotificationText.text = string.Format(translation, itemCount);
			}
			packAllNotification.SetActive(value: true);
			if (notificationRoutine != null)
			{
				StopCoroutine(notificationRoutine);
			}
			notificationRoutine = StartCoroutine(HideNotificationAfterDelay());
		}
	}

	private IEnumerator HideNotificationAfterDelay()
	{
		yield return new WaitForSeconds(packAllNotificationDuration);
		if (packAllNotification != null)
		{
			packAllNotification.SetActive(value: false);
		}
		notificationRoutine = null;
	}

	private IEnumerator FillOverTime()
	{
		float t = 0f;
		while (t < holdDuration)
		{
			t += Time.unscaledDeltaTime;
			SetFill(Mathf.Clamp01(t / holdDuration));
			yield return null;
		}
		SetFill(1f);
		fillRoutine = null;
	}

	private IEnumerator CloseAfterDelay()
	{
		yield return new WaitForSecondsRealtime(closeDelayAfterPerformed);
		SetUI(visible: false, 0f);
		closeRoutine = null;
	}

	private void StopAllRoutines()
	{
		StopFillRoutine();
		if (closeRoutine != null)
		{
			StopCoroutine(closeRoutine);
			closeRoutine = null;
		}
	}

	private void StopFillRoutine()
	{
		if (fillRoutine != null)
		{
			StopCoroutine(fillRoutine);
			fillRoutine = null;
		}
	}

	private void SetUI(bool visible, float fill)
	{
		if ((bool)canvasGroup)
		{
			canvasGroup.alpha = (visible ? 1f : 0f);
			canvasGroup.interactable = false;
			canvasGroup.blocksRaycasts = false;
		}
		SetFill(fill);
	}

	private void SetFill(float v)
	{
		if ((bool)fillImage)
		{
			fillImage.fillAmount = v;
		}
	}
}
