using Aggro.Core;

[UpdateInGroup(typeof(SimulationUpdateSystemGroup), int.MinValue)]
public class TimeSystem : EntitySystemBase
{
	protected override void OnStartRunning()
	{
		TimeUtil.frame = -1;
		base.world.seed = Hash.Calculate(GameUtil.seed, TimeUtil.frame);
	}

	protected override void OnUpdateSystem()
	{
		TimeUtil.frame++;
		base.world.seed = Hash.Calculate(GameUtil.seed, TimeUtil.frame);
	}
}
