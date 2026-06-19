using Aggro.Core;

[UpdateInGroup(typeof(PresentationSystemGroup), -100)]
public class ProcessPresentationCoroutinesSystem : EntitySystemBase
{
	protected override void OnUpdateSystem()
	{
		base.world.presentationCoroutineManager.Update();
	}
}
