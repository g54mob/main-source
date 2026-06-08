using Unity.Entities;

namespace Kitchen
{
	public class HidePlayers : PostgameSystemBase
	{
		private EntityQuery VisiblePlayers;

		protected override void Initialise()
		{
			base.Initialise();
			VisiblePlayers = GetEntityQuery(new QueryHelper().All(typeof(CPlayer)).None(typeof(CHideView)));
		}

		protected override void OnUpdate()
		{
			base.EntityManager.AddComponent<CHideView>(VisiblePlayers);
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
