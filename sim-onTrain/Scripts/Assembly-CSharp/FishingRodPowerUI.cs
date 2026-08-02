using UnityEngine;
using UnityEngine.UI;

public class FishingRodPowerUI : MonoBehaviour
{
	[SerializeField]
	private FishingRodInputHandler handler;

	[SerializeField]
	private Image fillImage;

	[SerializeField]
	private CanvasGroup canvasGroup;

	[SerializeField]
	private float fadeSpeed = 10f;

	[Header("Colors")]
	[SerializeField]
	private Gradient fillGradient = new Gradient();

	private float targetAlpha;

	private bool subscribed;

	private void Awake()
	{
		if (canvasGroup == null)
		{
			canvasGroup = GetComponent<CanvasGroup>();
		}
		if (canvasGroup != null)
		{
			canvasGroup.alpha = 0f;
		}
		if (fillImage != null)
		{
			fillImage.fillAmount = 0f;
		}
	}

	private void OnEnable()
	{
		TrySubscribe();
	}

	private void OnDisable()
	{
		Unsubscribe();
	}

	private void Update()
	{
		if (!subscribed)
		{
			TrySubscribe();
		}
		if (canvasGroup != null)
		{
			canvasGroup.alpha = Mathf.MoveTowards(canvasGroup.alpha, targetAlpha, Time.deltaTime * fadeSpeed);
		}
	}

	private void TrySubscribe()
	{
		if (!subscribed)
		{
			if (handler == null)
			{
				handler = Object.FindObjectOfType<FishingRodInputHandler>(includeInactive: true);
			}
			if (!(handler == null))
			{
				handler.OnChargeStart.AddListener(HandleStart);
				handler.OnChargeUpdate.AddListener(HandleUpdate);
				handler.OnChargeRelease.AddListener(HandleRelease);
				subscribed = true;
			}
		}
	}

	private void Unsubscribe()
	{
		if (subscribed && !(handler == null))
		{
			handler.OnChargeStart.RemoveListener(HandleStart);
			handler.OnChargeUpdate.RemoveListener(HandleUpdate);
			handler.OnChargeRelease.RemoveListener(HandleRelease);
			subscribed = false;
		}
	}

	private void HandleStart()
	{
		targetAlpha = 1f;
		if (fillImage != null)
		{
			fillImage.fillAmount = 0f;
		}
	}

	private void HandleUpdate(float t)
	{
		if (fillImage != null)
		{
			fillImage.fillAmount = t;
			if (fillGradient != null && fillGradient.colorKeys.Length != 0)
			{
				fillImage.color = fillGradient.Evaluate(t);
			}
		}
	}

	private void HandleRelease()
	{
		targetAlpha = 0f;
	}
}
