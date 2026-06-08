namespace Kitchen
{
	public abstract class TutorialFirstFrameSystem : TutorialSystem
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
