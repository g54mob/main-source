using Unity.Entities;

namespace Kitchen
{
	[UpdateBefore(typeof(ClearScene))]
	[UpdateInGroup(typeof(GameTransitionsCleanupGroup))]
	public abstract class FranchiseBuilderCleanupSystem : FranchiseBuilderSystem
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
