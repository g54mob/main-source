using Aggro.Core;
using UnityEngine;
using UnityEngine.UI;

public class PlayerFloaterUI : EntityBehaviourBase
{
	public Entity playerEntity;

	public Image icon;

	public FloaterUI floaterUI;

	public float maxDistance = 30f;

	protected override void OnUpdatePresentation()
	{
		if (GameUtil.TryGetLocalPlayer(out var player))
		{
			float num = Vector3.Distance(player.transform.position, playerEntity.transform.position);
			floaterUI.alwaysVisible = num <= maxDistance;
		}
		PlayerCostumeManager playerCostumeManager = playerEntity.GetObject<PlayerCostumeManager>();
		PlayerColorManager playerColorManager = playerEntity.GetObject<PlayerColorManager>();
		icon.sprite = playerCostumeManager.GetCurrentCostume().costumeObject.costumeTextures[playerColorManager.activePlayerColorIndex];
	}
}
