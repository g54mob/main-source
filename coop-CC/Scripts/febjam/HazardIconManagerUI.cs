using System.Collections.Generic;
using Aggro.Core;
using Unity.Mathematics;
using UnityEngine;

public class HazardIconManagerUI : EntityBehaviourBase
{
	public List<HazardIconUI> hazardIcons;

	public PlayerEffectContext testPlayerEffectContext;

	public RectTransform container;

	public Transform group;

	protected override void OnUpdatePresentationLate()
	{
		if (!GameUtil.TryGetLocalPlayer(out var player))
		{
			return;
		}
		PlayerStressVisual playerStressVisual = player.GetObject<PlayerStressVisual>();
		Vector3 vector = GameUtil.mainCamera.WorldToScreenPoint(playerStressVisual.playerUITransform.position);
		vector *= math.sign(vector.z) / Options.renderScale;
		RectTransformUtility.ScreenPointToLocalPointInRectangle(container, vector, GameUtil.uiCamera, out var localPoint);
		group.localPosition = localPoint;
		PlayerEffects playerEffects = player.GetObject<PlayerEffects>();
		foreach (HazardIconUI hazardIcon in hazardIcons)
		{
			UpdateIcon(playerEffects.context, hazardIcon);
		}
	}

	private void UpdateIcon(PlayerEffectContext checkContext, HazardIconUI icon)
	{
		if ((checkContext & icon.playerEffectContext) != PlayerEffectContext.None)
		{
			if (!icon.easeUI.visible && !icon.easeUI.transitioning)
			{
				icon.easeUI.EaseIn();
			}
		}
		else if (icon.easeUI.visible && !icon.easeUI.transitioning)
		{
			icon.easeUI.EaseOut();
		}
	}
}
