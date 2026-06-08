using Unity.Entities;

namespace Kitchen
{
	[UpdateInGroup(typeof(GameTransitionsCleanupGroup))]
	[UpdateBefore(typeof(ClearScene))]
	public abstract class ResearchCleanupSystem : ResearchSystem
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
