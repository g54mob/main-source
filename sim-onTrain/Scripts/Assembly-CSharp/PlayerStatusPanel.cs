using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatusPanel : UIPanelBase
{
	public Image healthBarFillImage;

	public Image foodBarFillImage;

	public Image waterBarFillImage;

	public Image healthBarLowWarningImage;

	public Image foodBarLowWarningImage;

	public Image waterBarLowWarningImage;

	public CanvasGroup damageEffectImage;

	private float healthBarValue;

	private float foodBarValue;

	private float waterBarValue;

	private float previousHealthValue;

	private float previousFoodValue;

	private float previousWaterValue;

	private Tweener healthFillTween;

	private Tweener foodFillTween;

	private Tweener waterFillTween;

	[Header("Warning Settings")]
	public float healthWarningThreshold = 30f;

	public float foodWarningThreshold = 30f;

	public float waterWarningThreshold = 30f;

	public float warningFadeDuration = 0.5f;

	private Tweener healthWarningTween;

	private Tweener foodWarningTween;

	private Tweener waterWarningTween;

	private float masterWarningAlpha;

	private Tweener masterWarningTween;

	public float damageEffectOpeningTime;

	public float damageEffectShowingTime;

	public float damageEffectFadingTime;

	private void Start()
	{
		if (healthBarLowWarningImage != null)
		{
			healthBarLowWarningImage.gameObject.SetActive(value: false);
		}
		if (foodBarLowWarningImage != null)
		{
			foodBarLowWarningImage.gameObject.SetActive(value: false);
		}
		if (waterBarLowWarningImage != null)
		{
			waterBarLowWarningImage.gameObject.SetActive(value: false);
		}
		previousHealthValue = 100f;
		previousFoodValue = 100f;
		previousWaterValue = 100f;
	}

	private void OnDisable()
	{
		healthFillTween?.Kill();
		foodFillTween?.Kill();
		waterFillTween?.Kill();
		healthWarningTween?.Kill();
		foodWarningTween?.Kill();
		waterWarningTween?.Kill();
		masterWarningTween?.Kill();
	}

	private void Update()
	{
		if (healthBarLowWarningImage != null && healthBarLowWarningImage.gameObject.activeSelf)
		{
			Color color = healthBarLowWarningImage.color;
			healthBarLowWarningImage.color = new Color(color.r, color.g, color.b, masterWarningAlpha);
		}
		if (foodBarLowWarningImage != null && foodBarLowWarningImage.gameObject.activeSelf)
		{
			Color color2 = foodBarLowWarningImage.color;
			foodBarLowWarningImage.color = new Color(color2.r, color2.g, color2.b, masterWarningAlpha);
		}
		if (waterBarLowWarningImage != null && waterBarLowWarningImage.gameObject.activeSelf)
		{
			Color color3 = waterBarLowWarningImage.color;
			waterBarLowWarningImage.color = new Color(color3.r, color3.g, color3.b, masterWarningAlpha);
		}
	}

	public void UpdateUI(float healthStatus, float foodStatus, float waterStatus, bool isDead = false)
	{
		healthBarValue = RoundUpToNextDecimal(healthStatus / 100f);
		foodBarValue = RoundUpToNextDecimal(foodStatus / 100f);
		waterBarValue = RoundUpToNextDecimal(waterStatus / 100f);
		if (healthBarValue != healthBarFillImage.fillAmount)
		{
			healthFillTween?.Kill();
			healthFillTween = DOTween.To(() => healthBarFillImage.fillAmount, delegate(float x)
			{
				healthBarFillImage.fillAmount = x;
			}, healthBarValue, 0.3f);
		}
		UpdateWarningVisibility(healthStatus, previousHealthValue, healthWarningThreshold, healthBarLowWarningImage, ref healthWarningTween);
		previousHealthValue = healthStatus;
		if (foodBarValue != foodBarFillImage.fillAmount)
		{
			foodFillTween?.Kill();
			foodFillTween = DOTween.To(() => foodBarFillImage.fillAmount, delegate(float x)
			{
				foodBarFillImage.fillAmount = x;
			}, foodBarValue, 0.3f);
		}
		UpdateWarningVisibility(foodStatus, previousFoodValue, foodWarningThreshold, foodBarLowWarningImage, ref foodWarningTween);
		previousFoodValue = foodStatus;
		if (waterBarValue != waterBarFillImage.fillAmount)
		{
			waterFillTween?.Kill();
			waterFillTween = DOTween.To(() => waterBarFillImage.fillAmount, delegate(float x)
			{
				waterBarFillImage.fillAmount = x;
			}, waterBarValue, 0.3f);
		}
		UpdateWarningVisibility(waterStatus, previousWaterValue, waterWarningThreshold, waterBarLowWarningImage, ref waterWarningTween);
		previousWaterValue = waterStatus;
	}

	private void UpdateWarningVisibility(float currentValue, float previousValue, float threshold, Image warningImage, ref Tweener warningTween)
	{
		if (!(warningImage == null))
		{
			if (currentValue <= threshold && previousValue > threshold)
			{
				StartWarningAnimation(warningImage, ref warningTween);
			}
			else if (currentValue > threshold && previousValue <= threshold)
			{
				StopWarningAnimation(warningImage, ref warningTween);
			}
			else if (currentValue <= threshold && (warningTween == null || !warningTween.IsActive()))
			{
				StartWarningAnimation(warningImage, ref warningTween);
			}
		}
	}

	private void StartWarningAnimation(Image warningImage, ref Tweener warningTween)
	{
		if (warningImage == null)
		{
			return;
		}
		warningTween?.Kill();
		warningImage.gameObject.SetActive(value: true);
		if (masterWarningTween == null || !masterWarningTween.IsActive())
		{
			masterWarningAlpha = 0f;
			masterWarningTween = DOTween.To(() => masterWarningAlpha, delegate(float x)
			{
				masterWarningAlpha = x;
			}, 1f, warningFadeDuration).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
		}
		warningTween = DOVirtual.Float(0f, 1f, 0.1f, delegate
		{
		});
	}

	private void StopWarningAnimation(Image warningImage, ref Tweener warningTween)
	{
		if (!(warningImage == null))
		{
			warningTween?.Kill();
			warningTween = null;
			warningImage.gameObject.SetActive(value: false);
			if (!IsAnyWarningActive())
			{
				masterWarningTween?.Kill();
				masterWarningTween = null;
				masterWarningAlpha = 0f;
			}
		}
	}

	private bool IsAnyWarningActive()
	{
		if ((!(healthBarLowWarningImage != null) || !healthBarLowWarningImage.gameObject.activeSelf) && (!(foodBarLowWarningImage != null) || !foodBarLowWarningImage.gameObject.activeSelf))
		{
			if (waterBarLowWarningImage != null)
			{
				return waterBarLowWarningImage.gameObject.activeSelf;
			}
			return false;
		}
		return true;
	}

	public float RoundUpToNextDecimal(float value)
	{
		return Mathf.Ceil(value * 10f) / 10f;
	}

	public void ShowDamageEffect()
	{
		damageEffectImage.DOKill();
		damageEffectImage.DOFade(1f, damageEffectFadingTime).OnComplete(delegate
		{
			DOVirtual.DelayedCall(damageEffectShowingTime, delegate
			{
				damageEffectImage.DOFade(0f, damageEffectFadingTime);
			});
		});
	}
}
