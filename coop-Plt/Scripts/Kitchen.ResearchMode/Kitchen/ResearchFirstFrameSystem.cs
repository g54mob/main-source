namespace Kitchen
{
	public abstract class ResearchFirstFrameSystem : ResearchSystem
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
