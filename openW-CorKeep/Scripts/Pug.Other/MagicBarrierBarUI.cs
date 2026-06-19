using UnityEngine;

public class MagicBarrierBarUI : UIelement
{
	public Transform BarMaskPivot;

	public GameObject barrierBarContainer;

	public PlayerController player => Manager.main.player;

	private void Update()
	{
		if (!Manager.sceneHandler.isInGame || player == null)
		{
			barrierBarContainer.SetActive(value: false);
			return;
		}
		if (player.guestMode)
		{
			barrierBarContainer.SetActive(value: false);
			return;
		}
		if (!EntityUtility.HasComponentData<MagicBarrierCD>(player.entity, base.world))
		{
			barrierBarContainer.SetActive(value: false);
			return;
		}
		MagicBarrierCD componentData = EntityUtility.GetComponentData<MagicBarrierCD>(player.entity, player.world);
		if (componentData.barrierHealth <= 0)
		{
			barrierBarContainer.SetActive(value: false);
			return;
		}
		barrierBarContainer.SetActive(value: true);
		int barrierHealth = componentData.barrierHealth;
		int barrierMaxHealth = componentData.barrierMaxHealth;
		float x = ((barrierMaxHealth > 0) ? Mathf.Clamp01((float)barrierHealth / (float)barrierMaxHealth) : 0f);
		BarMaskPivot.localScale = new Vector3(x, 1f, 1f);
	}

	protected override void LateUpdate()
	{
		barrierBarContainer.transform.localScale = Manager.ui.CalcGameplayUITargetScaleMultiplier();
		base.LateUpdate();
	}

	public override void OnSelected()
	{
	}

	public override void OnDeselected(bool playEffect = true)
	{
	}

	public override void OnLeftClicked(bool mod1, bool mod2)
	{
	}

	public override void OnRightClicked(bool mod1, bool mod2)
	{
	}
}
