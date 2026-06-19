using Unity.Entities;

public class MusicSheetStand : Table
{
	private bool isWobbling;

	public override void OnOccupied()
	{
		base.OnOccupied();
		isWobbling = false;
		animator.SetTrigger(-1949102368);
	}

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		Entity value = base.entity;
		Entity? obj = Manager.main.player?.currentSheetStandBeingPlayedAt;
		bool flag = value == obj;
		if (flag != isWobbling)
		{
			if (flag)
			{
				animator.SetTrigger(1260321794);
			}
			else
			{
				animator.SetTrigger(-1949102368);
			}
			isWobbling = flag;
		}
	}
}
