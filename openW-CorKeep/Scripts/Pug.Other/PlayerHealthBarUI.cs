using Pug.UnityExtensions;
using Unity.Mathematics;
using UnityEngine;

public class PlayerHealthBarUI : UIelement
{
	public GameObject healthBarContainer;

	public PugText healthText;

	public PugText healthAmountText;

	public PugText barrierAmountText;

	public GameObject textContainer;

	public SpriteRenderer healthBar;

	public SpriteRenderer healthBarDivider;

	public SpriteRenderer maxHealthLimiter;

	public SpriteRenderer background;

	private int previousMaxHealth;

	private bool isHovering;

	private bool isAtLowHealth;

	public bool showDividersOutsideMaskInstead;

	public Transform textBottomPos;

	public Flashable flashableBar;

	public Flashable flashableBackground;

	public TimerSimple flashTimer;

	public SpriteRenderer screenborder;

	public int borderFlashesDone;

	public const int BORDER_FLASHES_MAX = 3;

	private const float FLASH_DURATION = 0.66f;

	private static readonly int _AmountOfRepeats = Shader.PropertyToID("_AmountOfRepeats");

	private static readonly int _NormalizedHealth = Shader.PropertyToID("_NormalizedHealth");

	private static readonly int _MaskRect = Shader.PropertyToID("_MaskRect");

	public PlayerController player => Manager.main.player;

	private void Awake()
	{
		screenborder.SetAlpha(0f);
		if (showDividersOutsideMaskInstead)
		{
			healthBarDivider.maskInteraction = SpriteMaskInteraction.VisibleOutsideMask;
		}
	}

	public void UpdateHealthBar()
	{
		LateUpdate();
	}

	protected override void LateUpdate()
	{
		healthBarContainer.transform.localScale = Manager.ui.CalcGameplayUITargetScaleMultiplier();
		base.LateUpdate();
		if (Manager.sceneHandler == null)
		{
			return;
		}
		if (Manager.sceneHandler.isInGame && player != null)
		{
			healthBarContainer.SetActive(value: true);
			if (player.guestMode)
			{
				healthBarContainer.SetActive(value: false);
			}
			int currentHealth = player.currentHealth;
			int maxHealth = player.GetMaxHealth();
			MagicBarrierCD componentData = EntityUtility.GetComponentData<MagicBarrierCD>(player.entity, player.world);
			int barrierHealth = componentData.barrierHealth;
			int barrierMaxHealth = componentData.barrierMaxHealth;
			bool showText = Manager.ui.isPlayerInventoryShowing || isHovering;
			UpdateHealthBar(currentHealth, maxHealth, barrierHealth, barrierMaxHealth, showText, onlyShowMaxHealth: false);
		}
		else
		{
			healthBarContainer.SetActive(value: false);
		}
	}

	private Vector4 GetMaskRect(Bounds bounds)
	{
		Vector3 min = bounds.min;
		Vector3 max = bounds.max;
		return new Vector4(min.x, min.y, max.x - min.x, max.y - min.y);
	}

	public void UpdateHealthBar(int currentHealth, int maxHealth, int currentMagicBarrier, int maxMagicBarrier, bool showText, bool onlyShowMaxHealth)
	{
		PlayerController playerController = Manager.main.player;
		float num = 0f;
		if (playerController != null)
		{
			num = math.abs((float)EntityUtility.GetConditionValue(ConditionID.StarvingHealthDecrease, playerController.entity, playerController.world) / 100f);
		}
		float num2 = 1f - num;
		background.size = new Vector2(6.375f * num2, background.size.y);
		background.transform.localPosition = new Vector3(-3.1875f * num, 0f, 0f);
		maxHealthLimiter.transform.localPosition = new Vector3(6.25f * (num2 - 0.5f), maxHealthLimiter.transform.localPosition.y, 0f);
		maxHealthLimiter.gameObject.SetActive(num > 0f);
		float num3 = Mathf.Clamp01((float)currentHealth / ((float)math.max(1, maxHealth) / num2));
		Vector4 vector = GetMaskRect(healthBar.bounds);
		vector.z *= num3;
		if (onlyShowMaxHealth)
		{
			vector = new Vector4(float.NegativeInfinity, float.NegativeInfinity, float.PositiveInfinity, float.PositiveInfinity);
		}
		healthBar.material.SetVector(_MaskRect, new Vector4(vector.x, vector.y, 1f / vector.z, 1f / vector.w));
		healthBarDivider.material.SetFloat(_NormalizedHealth, num3);
		textContainer.gameObject.SetActive(showText);
		if (showText)
		{
			string text = (onlyShowMaxHealth ? maxHealth.ToString() : (currentHealth + "/" + maxHealth));
			string text2 = ((onlyShowMaxHealth || maxMagicBarrier <= 0) ? "" : ("(" + currentMagicBarrier + "/" + maxMagicBarrier + ")"));
			healthAmountText.Render(text);
			barrierAmountText.Render(text2);
			float num4 = healthText.dimensions.size.y / 2f;
			num4 += num4 % 0.0625f;
			healthText.transform.localPosition = textBottomPos.localPosition + new Vector3(0f, num4, 0f);
		}
		UpdateDividers((int)((float)maxHealth / num2));
		isAtLowHealth = num3 < 0.25f;
		if (isAtLowHealth && !flashableBackground.isRunning)
		{
			flashableBackground.Flash(0.66f);
			if (flashTimer.isRunning && borderFlashesDone < 3)
			{
				borderFlashesDone++;
			}
			flashTimer.Stop();
			flashTimer.Start(0.66f);
		}
		else if (!isAtLowHealth && flashableBackground.isRunning)
		{
			flashableBackground.CancelAndStopEffect();
			borderFlashesDone = 0;
			screenborder.SetAlpha(0f);
			flashTimer.Stop();
		}
		if (flashTimer.isRunning && borderFlashesDone < 3)
		{
			float num5 = 0.66f;
			float elapsedTime = flashTimer.elapsedTime;
			float num6 = 0.05f;
			float a = ((currentHealth > 0) ? (num6 * (1f - math.abs((2f * elapsedTime - num5) / num5))) : 0f);
			screenborder.SetAlpha(a);
		}
	}

	private void UpdateDividers(int maxHealth)
	{
		maxHealth = math.clamp(maxHealth, 1, 1000);
		if (previousMaxHealth != maxHealth)
		{
			healthBarDivider.material.SetFloat(_AmountOfRepeats, math.clamp(math.lerp(3.95f, 50f, ((float)maxHealth - 100f) / 900f), 0f, 50f));
			previousMaxHealth = maxHealth;
		}
	}

	public override void OnSelected()
	{
		isHovering = true;
	}

	public override void OnDeselected(bool playEffect = true)
	{
		isHovering = false;
	}

	public override void OnLeftClicked(bool mod1, bool mod2)
	{
	}

	public override void OnRightClicked(bool mod1, bool mod2)
	{
	}

	public void FlashHealthBarWhite()
	{
		flashableBar.FlashLinearNoCurve(Color.white);
	}
}
