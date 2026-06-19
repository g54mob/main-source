using UnityEngine;

public class CartographyTable : EntityMonoBehaviour
{
	private ShareMapClientSystem shareMapClientSystem;

	[ClearOnReload]
	private static float mapUpdateRequestTime;

	public override void OnOccupied()
	{
		shareMapClientSystem = base.world.GetExistingSystemManaged<ShareMapClientSystem>();
		base.OnOccupied();
	}

	public void Use()
	{
		if (!base.entityExist)
		{
			return;
		}
		PlayerController player = Manager.main.player;
		if (!(player != null))
		{
			return;
		}
		Manager.ui.OnMapToggle();
		if (mapUpdateRequestTime == 0f || Time.time - mapUpdateRequestTime > 30f)
		{
			mapUpdateRequestTime = Time.time;
			if (!player.guestMode)
			{
				shareMapClientSystem.TriggerExchangeWithServer();
			}
		}
	}
}
