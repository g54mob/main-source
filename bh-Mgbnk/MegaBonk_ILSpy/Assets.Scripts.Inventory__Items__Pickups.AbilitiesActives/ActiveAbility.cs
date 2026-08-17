using Assets.Scripts.Utility;

namespace Assets.Scripts.Inventory__Items__Pickups.AbilitiesActives;

public abstract class ActiveAbility
{
	protected float readyAtTime;

	public void Use()
	{
		if (!(MyTime.time < readyAtTime))
		{
			float cooldown = GetCooldown();
			float num = MyTime.time + MyTime.time;
			readyAtTime = num;
			UseImplementation();
		}
	}

	public abstract void Tick();

	private bool IsReady()
	{
		bool flag = MyTime.time < readyAtTime;
		return !flag;
	}

	public abstract void Init();

	public abstract void Cleanup();

	public abstract void UseImplementation();

	public abstract float GetCooldown();
}
