using Unity.Entities;

namespace Kitchen
{
	[UpdateBefore(typeof(ClearScene))]
	[UpdateInGroup(typeof(GameTransitionsCleanupGroup))]
	public abstract class TutorialCleanupSystem : TutorialSystem
	{
		protected override void Initialise()
		{
			base.Initialise();
			RequireSingletonForUpdate<SClearScene>();
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
