using Unity.Entities;

namespace Kitchen
{
	[UpdateAfter(typeof(CreatePostgame))]
	[UpdateInGroup(typeof(ChangeModeGroup))]
	public abstract class PostgameInitialisationSystem : PostgameSystemBase
	{
		protected override void Initialise()
		{
			base.Initialise();
			RequireSingletonForUpdate<SPostgameFirstFrameMarker>();
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
