namespace Kitchen
{
	public abstract class FranchiseFirstFrameSystem : FranchiseSystem
	{
		protected override void Initialise()
		{
			base.Initialise();
			RequireSingletonForUpdate<CSceneFirstFrame>();
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
