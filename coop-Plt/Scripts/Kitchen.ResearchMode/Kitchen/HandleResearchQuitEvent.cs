using Unity.Entities;

namespace Kitchen
{
	public class HandleResearchQuitEvent : ResearchSystem
	{
		private EntityQuery Quits;

		protected override void Initialise()
		{
			base.Initialise();
			Quits = GetEntityQuery(typeof(CRequestQuitEvent));
			RequireForUpdate(Quits);
		}

		protected override void OnUpdate()
		{
			base.EntityManager.DestroyEntity(Quits);
			StartSceneTransition(SceneType.Franchise);
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
