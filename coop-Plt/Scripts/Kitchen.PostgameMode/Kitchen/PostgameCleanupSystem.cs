using Unity.Entities;

namespace Kitchen
{
	[UpdateInGroup(typeof(GameTransitionsCleanupGroup))]
	public abstract class PostgameCleanupSystem : PostgameSystemBase
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
