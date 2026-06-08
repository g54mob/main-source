using Unity.Entities;

namespace Kitchen
{
	public class ShowPlayers : PostgameCleanupSystem
	{
		private EntityQuery Players;

		protected override void Initialise()
		{
			base.Initialise();
			Players = GetEntityQuery(typeof(CPlayer), typeof(CHideView));
		}

		protected override void OnUpdate()
		{
			base.EntityManager.RemoveComponent<CHideView>(Players);
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
