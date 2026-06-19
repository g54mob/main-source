using Unity.Mathematics;
using UnityEngine;

public class PlayerHungerBarUI : UIelement
{
	private enum VisibilityState
	{
		Hidden = 0,
		BelowManaBar = 1,
		BelowHealthBar = 2
	}

	public GameObject hungerBarContainer;

	public SpriteRenderer hungerBar;

	public SpriteRenderer hungerBarDivider;

	public Color starvingColor;

	public PugText hungerAmountText;

	public PugText hungerText;

	public Transform textTopPos;

	public GameObject textContainer;

	private int previousMaxHunger;

	private int previousCurrentHunger;

	private Vector3 previousScale = -Vector3.one;

	private bool previousIsShowing;

	private bool isHovering;

	private VisibilityState _visibilityState;

	public BoxCollider hoverBox;

	private static readonly int _AmountOfRepeats = Shader.PropertyToID("_AmountOfRepeats");

	private static readonly int _NormalizedHealth = Shader.PropertyToID("_NormalizedHealth");

	private static readonly int _MaskRect = Shader.PropertyToID("_MaskRect");

	public PlayerController player => Manager.main.player;

	private Vector4 GetMaskRect(Bounds bounds)
	{
		Vector3 min = bounds.min;
		Vector3 max = bounds.max;
		return new Vector4(min.x, min.y, max.x - min.x, max.y - min.y);
	}

	private void Update()
	{
		VisibilityState visibilityState = VisibilityState.Hidden;
		int num = 0;
		bool flag = false;
		int num2 = 100;
		if (Manager.sceneHandler.isInGame && player != null && !player.guestMode)
		{
			visibilityState = (player.ShouldShowManaBar() ? VisibilityState.BelowManaBar : VisibilityState.BelowHealthBar);
			EntityUtility.TryGetComponentData<HungerCD>(player.entity, base.world, out var value);
			num = value.hunger;
			flag = Manager.ui.isPlayerInventoryShowing || isHovering;
		}
		else
		{
			visibilityState = VisibilityState.Hidden;
		}
		if (visibilityState != _visibilityState || flag != previousIsShowing || num != previousCurrentHunger || num2 != previousMaxHunger || !(hungerBarContainer.transform.localScale == previousScale))
		{
			_visibilityState = visibilityState;
			switch (_visibilityState)
			{
			case VisibilityState.Hidden:
				hungerBarContainer.SetActive(value: false);
				break;
			case VisibilityState.BelowManaBar:
				hungerBarContainer.SetActive(value: true);
				hungerBarContainer.transform.localPosition = new Vector3(hungerBarContainer.transform.localPosition.x, 5.5625f, 10f);
				hoverBox.center = new Vector3(hoverBox.center.x, 5.625f, 10f);
				break;
			case VisibilityState.BelowHealthBar:
				hungerBarContainer.SetActive(value: true);
				hungerBarContainer.transform.localPosition = new Vector3(hungerBarContainer.transform.localPosition.x, 6.1875f, 10f);
				hoverBox.center = new Vector3(hoverBox.center.x, 6.3125f, 10f);
				break;
			}
			float num3 = Mathf.Clamp01((float)num / (float)num2);
			Vector4 maskRect = GetMaskRect(hungerBar.bounds);
			maskRect.z *= num3;
			previousCurrentHunger = num;
			previousScale = hungerBarContainer.transform.localScale;
			previousIsShowing = flag;
			hungerBar.material.SetVector(_MaskRect, new Vector4(maskRect.x, maskRect.y, 1f / maskRect.z, 1f / maskRect.w));
			hungerBar.color = ((num < 25) ? starvingColor : Color.white);
			hungerBarDivider.material.SetFloat(_NormalizedHealth, num3);
			textContainer.gameObject.SetActive(flag);
			if (flag)
			{
				string text = num + "/" + num2;
				hungerAmountText.Render(text);
			}
			float num4 = hungerText.dimensions.size.y / 2f;
			num4 -= num4 % 0.0625f;
			hungerText.transform.localPosition = textTopPos.localPosition - new Vector3(0f, num4, 0f);
			UpdateDividers(num2);
		}
	}

	private void UpdateDividers(int maxHunger)
	{
		if (previousMaxHunger != maxHunger)
		{
			hungerBarDivider.material.SetFloat(_AmountOfRepeats, math.clamp(math.lerp(3.95f, 50f, ((float)maxHunger - 100f) / 900f), 0f, 50f));
			previousMaxHunger = maxHunger;
		}
	}

	protected override void LateUpdate()
	{
		hungerBarContainer.transform.localScale = Manager.ui.CalcGameplayUITargetScaleMultiplier();
		base.LateUpdate();
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
}
