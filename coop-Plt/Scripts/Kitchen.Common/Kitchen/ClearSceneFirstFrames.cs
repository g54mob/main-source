using Unity.Entities;

namespace Kitchen
{
	[UpdateInGroup(typeof(EndOfFrameGroup), OrderFirst = true)]
	[UpdateBefore(typeof(ManageTransitions))]
	public class ClearSceneFirstFrames : GenericSystemBase
	{
		private EntityQuery FirstFrameMarkers;

		protected override void Initialise()
		{
			base.Initialise();
			FirstFrameMarkers = GetEntityQuery(typeof(CSceneFirstFrame));
			RequireForUpdate(FirstFrameMarkers);
		}

		protected override void OnUpdate()
		{
			base.EntityManager.DestroyEntity(FirstFrameMarkers);
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
