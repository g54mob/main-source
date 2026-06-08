using Unity.Entities;

namespace Kitchen
{
	[UpdateInGroup(typeof(PostResolveSatisfactionsGroup), OrderLast = true)]
	public class CleanAcceptances : GameSystemBase
	{
		private EntityQuery Acceptances;

		protected override void Initialise()
		{
			Acceptances = GetEntityQuery(new QueryHelper().Any(typeof(COrderAcceptance)).None(typeof(CItemTransferAccept)));
		}

		protected override void OnUpdate()
		{
			base.EntityManager.DestroyEntity(Acceptances);
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
