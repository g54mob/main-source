using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkillNodeUI : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	[Header("Data")]
	public string skillID;

	public Skill skillData;

	[Header("UI References")]
	public Image iconImage;

	public Button skillButton;

	public TMP_Text costText;

	public TMP_Text levelText;

	public Image frameImage;

	public Image glowImage;

	public RectTransform shineEffect;

	public TMP_Text tierText;

	[Header("State Colors")]
	public Color upgradedColor = Color.blue;

	public Color availableColor = Color.yellow;

	public Color unaffordableColor = Color.red;

	public Color lockedColor = Color.gray;

	public Color maxedColor = new Color(0.5f, 0.9f, 1f);

	[Header("Hover Effect")]
	public float hoverScaleAmount = 1.02f;

	public float hoverScaleSpeed = 10f;

	public Shadow frameShadow;

	public Vector2 hoverShadowDistance = new Vector2(0f, -2f);

	private Vector2 initialShadowDistance;

	public float hoverAnimationDuration = 0.2f;

	private SkillTreePanel skillTreePanel;

	private Vector3 initialGlowScale;

	private Vector3 targetGlowScale;

	private bool isInitialized;

	private Vector3 initialNodeScale;

	public float gapMult = 1f;

	private CanvasGroup maxedCanvasGroup;

	[Header("Shake Settings")]
	public float shakeDuration = 0.25f;

	public float shakeStrength = 20f;

	public int shakeVibrato = 10;

	public float shakeScale = 0.12f;

	protected virtual void Awake()
	{
		upgradedColor = new Color(0.96f, 0.91f, 0.38f, 1f);
		availableColor = new Color(0.96f, 0.91f, 0.38f, 1f);
		unaffordableColor = new Color(0.83f, 0.295f, 0.295f, 1f);
		lockedColor = new Color(0.5f, 0.5f, 0.5f, 1f);
		maxedColor = new Color(0.48f, 0.82f, 0.28f);
		shakeDuration = 0.25f;
		shakeStrength = 20f;
		shakeVibrato = 10;
		shakeScale = 0.12f;
		maxedCanvasGroup = base.transform.Find("Maxed").GetComponent<CanvasGroup>();
	}

	protected virtual void Initialize()
	{
		if (!isInitialized)
		{
			if (glowImage != null)
			{
				initialGlowScale = glowImage.transform.localScale;
				targetGlowScale = initialGlowScale;
			}
			isInitialized = true;
			initialNodeScale = base.transform.localScale;
			if (frameShadow != null)
			{
				initialShadowDistance = frameShadow.effectDistance;
			}
			RectTransform component = GetComponent<RectTransform>();
			if (component != null)
			{
				component.anchoredPosition = new Vector2(component.anchoredPosition.x * gapMult, component.anchoredPosition.y * gapMult);
			}
		}
	}

	protected virtual void Update()
	{
		if (Application.isPlaying && glowImage != null && isInitialized)
		{
			glowImage.transform.localScale = Vector3.Lerp(glowImage.transform.localScale, targetGlowScale, Time.unscaledDeltaTime * hoverScaleSpeed);
		}
	}

	public virtual void Setup(SkillTreePanel panel)
	{
		skillTreePanel = panel;
		Initialize();
		if (string.IsNullOrEmpty(skillID))
		{
			return;
		}
		if (skillData == null)
		{
			skillData = Resources.Load<Skill>("Skills/" + skillID);
		}
		if (skillData != null)
		{
			if (iconImage != null)
			{
				iconImage.sprite = skillData.icon;
			}
			base.gameObject.name = "Node (" + skillData.skillName + ")";
			SkillTreePanel obj = skillTreePanel;
			obj.UpdateVisualsEvent = (Action)Delegate.Remove(obj.UpdateVisualsEvent, new Action(UpdateVisuals));
			SkillTreePanel obj2 = skillTreePanel;
			obj2.UpdateVisualsEvent = (Action)Delegate.Combine(obj2.UpdateVisualsEvent, new Action(UpdateVisuals));
			skillButton.onClick.RemoveAllListeners();
		}
		else
		{
			base.gameObject.SetActive(value: false);
		}
	}

	private void OnDestroy()
	{
		SkillTreePanel obj = skillTreePanel;
		obj.UpdateVisualsEvent = (Action)Delegate.Remove(obj.UpdateVisualsEvent, new Action(UpdateVisuals));
	}

	private void UpdateVisuals()
	{
		UpdateVisualState();
	}

	public virtual void OnSkillNodeClicked()
	{
		if (Application.isPlaying && skillData != null)
		{
			SkillTooltipManager.Instance.ShakeTooltip();
			if (skillTreePanel.AttemptUnlockSkill(this))
			{
				Shake();
			}
		}
	}

	public void Shake()
	{
		base.transform.DOKill(complete: true);
		base.transform.rotation = Quaternion.identity;
		base.transform.localScale = initialNodeScale;
		base.transform.DOPunchRotation(new Vector3(0f, 0f, shakeStrength), shakeDuration, shakeVibrato);
		base.transform.DOPunchScale(Vector3.one * shakeScale, shakeDuration, shakeVibrato);
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		if (!Application.isPlaying || skillData == null)
		{
			return;
		}
		SkillTooltipManager.Instance.ShowTooltip(skillData, base.transform);
		targetGlowScale = initialGlowScale * hoverScaleAmount;
		skillTreePanel.SetHoveredNode(this);
		base.transform.DOScale(hoverScaleAmount * initialNodeScale, hoverAnimationDuration).SetEase(Ease.OutBack);
		if (frameShadow != null)
		{
			DOTween.To(() => frameShadow.effectDistance, delegate(Vector2 x)
			{
				frameShadow.effectDistance = x;
			}, hoverShadowDistance, hoverAnimationDuration).SetEase(Ease.OutBack);
		}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		if (!Application.isPlaying)
		{
			return;
		}
		SkillTooltipManager.Instance.HideTooltip();
		targetGlowScale = initialGlowScale;
		skillTreePanel.SetHoveredNode(null);
		base.transform.DOScale(initialNodeScale, hoverAnimationDuration).SetEase(Ease.OutBack);
		if (frameShadow != null)
		{
			DOTween.To(() => frameShadow.effectDistance, delegate(Vector2 x)
			{
				frameShadow.effectDistance = x;
			}, initialShadowDistance, hoverAnimationDuration).SetEase(Ease.OutBack);
		}
	}

	public virtual void UpdateVisualState()
	{
		if (skillData == null || skillTreePanel == null)
		{
			return;
		}
		if (tierText != null)
		{
			string text = ConvertToRoman(skillData.tier);
			tierText.text = text;
			tierText.gameObject.SetActive(!string.IsNullOrEmpty(text));
		}
		if (!Application.isPlaying)
		{
			SetVisuals(lockedColor, lockedColor, "", isInteractable: false);
			if (levelText != null)
			{
				levelText.gameObject.SetActive(value: false);
			}
			return;
		}
		bool flag = SkillManager.Instance.IsSkillUnlocked(skillData.ID);
		int skillLevel = SkillManager.Instance.GetSkillLevel(skillData.ID);
		bool flag2 = skillLevel >= skillData.MaxLevel;
		if (skillTreePanel.enableFogOfWar)
		{
			bool flag3 = flag || skillData.prerequisites.Count == 0 || SkillManager.Instance.ArePrerequisitesMet(skillData);
			base.gameObject.SetActive(flag3);
			if (!flag3)
			{
				return;
			}
		}
		else
		{
			base.gameObject.SetActive(value: true);
		}
		if (levelText != null)
		{
			levelText.gameObject.SetActive(skillData.MaxLevel > 1);
			levelText.text = $"{skillLevel}/{skillData.MaxLevel}";
		}
		if (flag2)
		{
			if (maxedCanvasGroup.alpha < 0.1f)
			{
				maxedCanvasGroup.DOFade(1f, 0.3f).SetEase(Ease.OutBack);
			}
			SkillTreePanel obj = skillTreePanel;
			obj.UpdateVisualsEvent = (Action)Delegate.Remove(obj.UpdateVisualsEvent, new Action(UpdateVisuals));
			SetVisuals(maxedColor, Color.white, "MAX", isInteractable: false);
		}
		else if (SkillManager.Instance.ArePrerequisitesMet(skillData))
		{
			double num = SkillManager.Instance.CalculateUpgradeCost(skillData);
			bool flag4 = GameManager.Instance.totalMoney >= num;
			if (flag)
			{
				SetVisuals(flag4 ? upgradedColor : unaffordableColor, Color.white, $"{num}g", isInteractable: true);
			}
			else
			{
				SetVisuals(flag4 ? availableColor : unaffordableColor, Color.white, $"{num}g", isInteractable: true);
			}
		}
		else
		{
			SetVisuals(lockedColor, lockedColor, "", isInteractable: false);
		}
	}

	private void SetVisuals(Color frameAndGlowColor, Color iconTintColor, string costString, bool isInteractable)
	{
		frameImage.color = frameAndGlowColor;
		iconImage.color = iconTintColor;
		skillButton.interactable = isInteractable;
		skillButton.transition = Selectable.Transition.ColorTint;
		skillButton.targetGraphic = skillButton.transform.Find("bigButton").GetComponent<Image>();
		if (glowImage != null)
		{
			bool flag = Application.isPlaying && (isInteractable || SkillManager.Instance.GetSkillLevel(skillData.ID) >= skillData.MaxLevel);
			glowImage.gameObject.SetActive(flag);
			if (flag)
			{
				glowImage.color = frameAndGlowColor;
			}
		}
		if (costText != null)
		{
			costText.gameObject.SetActive(!string.IsNullOrEmpty(costString));
			costText.text = costString;
		}
	}

	public Tween GetUnlockShineAnimation()
	{
		if (shineEffect == null)
		{
			return null;
		}
		Sequence sequence = DOTween.Sequence();
		Vector2 startPos = new Vector2(-100f, 100f);
		Vector2 endValue = new Vector2(100f, -100f);
		sequence.AppendCallback(delegate
		{
			shineEffect.anchoredPosition = startPos;
			shineEffect.gameObject.SetActive(value: true);
		}).Append(shineEffect.DOAnchorPos(endValue, 0.6f).SetEase(Ease.InOutSine)).AppendCallback(delegate
		{
			shineEffect.gameObject.SetActive(value: false);
		});
		return sequence;
	}

	private string ConvertToRoman(int number)
	{
		if (number < 1 || number > 5)
		{
			return "";
		}
		return (new string[5] { "I", "II", "III", "IV", "V" })[number - 1];
	}
}
