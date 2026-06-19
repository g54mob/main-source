using Unity.Mathematics;
using UnityEngine;

public class PlayerManaBarUI : UIelement
{
	public Transform manaBarMaskPivot;

	public GameObject manaBarContainer;

	public PugText manaAmountText;

	public PugText manaText;

	public Transform textTopPos;

	public GameObject textContainer;

	public SpriteRenderer manaBarDivider;

	public BoxCollider boxColl;

	private int previousMaxMana;

	private bool isHovering;

	private static readonly int AmountofRepeats = Shader.PropertyToID("_amountOfRepeats");

	public PlayerController player => Manager.main.player;

	private void Update()
	{
		if (Manager.sceneHandler.isInGame && player != null && player.ShouldShowManaBar())
		{
			boxColl.enabled = true;
			manaBarContainer.SetActive(value: true);
			if (player.guestMode)
			{
				manaBarContainer.SetActive(value: false);
			}
			if (EntityUtility.HasComponentData<ManaCD>(player.entity, base.world))
			{
				ManaCD componentData = EntityUtility.GetComponentData<ManaCD>(player.entity, player.world);
				int mana = componentData.mana;
				int maxMana = componentData.maxMana;
				float x = Mathf.Clamp01((float)mana / (float)maxMana);
				manaBarMaskPivot.localScale = new Vector3(x, 1f, 1f);
				bool flag = Manager.ui.isPlayerInventoryShowing || isHovering;
				textContainer.gameObject.SetActive(flag);
				if (flag)
				{
					string text = mana + "/" + maxMana;
					manaAmountText.Render(text);
				}
				float num = manaText.dimensions.size.y / 2f;
				num -= num % 0.0625f;
				manaText.transform.localPosition = textTopPos.localPosition - new Vector3(0f, num, 0f);
				UpdateDividers(maxMana);
			}
		}
		else
		{
			boxColl.enabled = false;
			manaBarContainer.SetActive(value: false);
		}
	}

	private void UpdateDividers(int maxMana)
	{
		if (previousMaxMana != maxMana)
		{
			manaBarDivider.material.SetFloat(AmountofRepeats, math.clamp(math.lerp(3.95f, 50f, ((float)maxMana - 100f) / 900f), 0f, 50f));
			previousMaxMana = maxMana;
		}
	}

	protected override void LateUpdate()
	{
		manaBarContainer.transform.localScale = Manager.ui.CalcGameplayUITargetScaleMultiplier();
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
