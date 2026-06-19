using Aggro.Core;

[UpdateInGroup(typeof(PresentationSystemGroup), 100)]
public class ProcessEventsSystem : EntitySystemBase
{
	protected override void OnUpdateSystem()
	{
		base.eventManager.ProcessEvents();
	}
}
