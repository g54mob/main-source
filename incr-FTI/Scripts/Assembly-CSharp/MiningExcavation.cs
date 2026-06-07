using DG.Tweening;
using UnityEngine;

public class MiningExcavation : MonoBehaviour
{
	public float debugScale;

	public float animationTimer;

	private const float scaleDuration = 1f;

	public MiningGemInstance gemInstance;

	private CanvasGroup canvasGroup;

	private bool hasTriggeredDisappearance;

	private Tweener moveTween;

	private void Awake()
	{
		canvasGroup = base.gameObject.AddComponent<CanvasGroup>();
		canvasGroup.blocksRaycasts = false;
		float num = 20f;
		base.transform.DOPunchRotation(new Vector3(num, num, num), 1f);
	}

	private void Update()
	{
		animationTimer += TimeManager.MenuDelta;
		float lifetimePercentage = Mathf.Clamp01(animationTimer);
		float num = (debugScale = DOVirtual.EasedValue(1f, 1.35f, lifetimePercentage, Ease.OutBack));
		base.transform.localScale = new Vector3(num, num, num);
		if (!hasTriggeredDisappearance && animationTimer > 1f)
		{
			hasTriggeredDisappearance = true;
			MenuManager.Instance.minigamePanelMining.AnimateBonus(this);
			moveTween = base.transform.DOLocalMove(base.transform.localPosition + new Vector3(0f, 20f, 0f), 1f);
			moveTween.OnKill(OnKill);
		}
		if (animationTimer > 1f)
		{
			canvasGroup.alpha = Mathf.InverseLerp(1.5f, 1f, animationTimer);
		}
	}

	private void OnKill()
	{
		Object.Destroy(base.gameObject);
	}
}
