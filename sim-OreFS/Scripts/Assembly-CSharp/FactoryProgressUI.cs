using System.Collections;
using System.Collections.Generic;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FactoryProgressUI : MonoBehaviour
{
	[Header("Money UI")]
	[SerializeField]
	private TextMeshProUGUI moneyText;

	[SerializeField]
	private string moneyFormat = "{0}";

	[Header("Level UI")]
	[SerializeField]
	private TextMeshProUGUI levelText;

	[Header("XP UI")]
	[SerializeField]
	private TextMeshProUGUI remainingXPText;

	[SerializeField]
	private string maxLevelText = "MAX";

	[Header("Progress Bar")]
	[SerializeField]
	private Image xpFillBar;

	[SerializeField]
	private float fillAnimationDuration = 0.1f;

	private FactoryManager _factoryManager;

	private Coroutine _fillAnimationCoroutine;

	private bool _isSubscribed;

	private void Start()
	{
		TrySubscribeToFactoryManager();
	}

	private void Update()
	{
		if (!_isSubscribed)
		{
			TrySubscribeToFactoryManager();
		}
	}

	private void OnDestroy()
	{
		UnsubscribeFromFactoryManager();
	}

	private void TrySubscribeToFactoryManager()
	{
		if (!_isSubscribed)
		{
			_factoryManager = FactoryManager.Instance;
			if (!(_factoryManager == null))
			{
				_factoryManager.onMoneyChanged.AddListener(OnMoneyChanged);
				_factoryManager.onXPChanged.AddListener(OnXPChanged);
				_factoryManager.onLevelChanged.AddListener(OnLevelChanged);
				_isSubscribed = true;
				RefreshAllUI();
			}
		}
	}

	private void UnsubscribeFromFactoryManager()
	{
		if (_factoryManager != null && _isSubscribed)
		{
			_factoryManager.onMoneyChanged.RemoveListener(OnMoneyChanged);
			_factoryManager.onXPChanged.RemoveListener(OnXPChanged);
			_factoryManager.onLevelChanged.RemoveListener(OnLevelChanged);
			_isSubscribed = false;
		}
	}

	private void OnMoneyChanged(int oldValue, int newValue)
	{
		UpdateMoneyUI(newValue);
	}

	private void OnXPChanged(int oldValue, int newValue)
	{
		UpdateXPUI();
	}

	private void OnLevelChanged(int oldValue, int newValue)
	{
		UpdateLevelUI(newValue);
		if (newValue > oldValue && xpFillBar != null)
		{
			if (_fillAnimationCoroutine != null)
			{
				StopCoroutine(_fillAnimationCoroutine);
				_fillAnimationCoroutine = null;
			}
			xpFillBar.fillAmount = 0f;
		}
		UpdateXPUI();
	}

	public void RefreshAllUI()
	{
		if (!(_factoryManager == null))
		{
			UpdateMoneyUI(_factoryManager.Money);
			UpdateLevelUI(_factoryManager.Level);
			if (xpFillBar != null)
			{
				xpFillBar.fillAmount = _factoryManager.XPProgress;
			}
			UpdateXPTextOnly();
		}
	}

	private void UpdateMoneyUI(int money)
	{
		if (moneyText != null)
		{
			moneyText.text = string.Format(moneyFormat, money);
		}
		LayoutRebuilder.ForceRebuildLayoutImmediate(GetComponent<RectTransform>());
	}

	private void UpdateLevelUI(int level)
	{
		if (levelText != null)
		{
			string translation = LocalizationManager.GetTranslation("Level");
			LocalizationManager.ApplyLocalizationParams(ref translation, new Dictionary<string, object> { 
			{
				"Number",
				level.ToString()
			} });
			levelText.text = translation;
		}
		LayoutRebuilder.ForceRebuildLayoutImmediate(GetComponent<RectTransform>());
	}

	private void UpdateXPUI()
	{
		if (!(_factoryManager == null))
		{
			UpdateXPTextOnly();
			AnimateFillBar();
		}
	}

	private void UpdateXPTextOnly()
	{
		if (_factoryManager == null)
		{
			return;
		}
		if (_factoryManager.IsMaxLevel)
		{
			if (remainingXPText != null)
			{
				remainingXPText.text = maxLevelText;
			}
		}
		else if (remainingXPText != null)
		{
			string format = "{0} " + LocalizationManager.GetTranslation("XP");
			remainingXPText.text = string.Format(format, _factoryManager.RemainingXPForNextLevel);
		}
	}

	private void AnimateFillBar()
	{
		if (!(xpFillBar == null) && !(_factoryManager == null) && base.gameObject.activeInHierarchy)
		{
			float targetFill = (_factoryManager.IsMaxLevel ? 1f : _factoryManager.XPProgress);
			if (_fillAnimationCoroutine != null)
			{
				StopCoroutine(_fillAnimationCoroutine);
				_fillAnimationCoroutine = null;
			}
			float fillAmount = xpFillBar.fillAmount;
			_fillAnimationCoroutine = StartCoroutine(AnimateFillCoroutine(fillAmount, targetFill));
		}
	}

	private IEnumerator AnimateFillCoroutine(float startFill, float targetFill)
	{
		float elapsed = 0f;
		while (elapsed < fillAnimationDuration)
		{
			elapsed += Time.unscaledDeltaTime;
			float num = Mathf.Clamp01(elapsed / fillAnimationDuration);
			float t = num * num * (3f - 2f * num);
			float fillAmount = Mathf.Lerp(startFill, targetFill, t);
			xpFillBar.fillAmount = fillAmount;
			yield return null;
		}
		xpFillBar.fillAmount = targetFill;
		_fillAnimationCoroutine = null;
	}

	public void SetFactoryManager(FactoryManager manager)
	{
		UnsubscribeFromFactoryManager();
		_factoryManager = manager;
		if (_factoryManager != null)
		{
			_factoryManager.onMoneyChanged.AddListener(OnMoneyChanged);
			_factoryManager.onXPChanged.AddListener(OnXPChanged);
			_factoryManager.onLevelChanged.AddListener(OnLevelChanged);
			_isSubscribed = true;
			RefreshAllUI();
		}
	}
}
