using Mirror;

namespace Aggro.Core
{
	[UpdateInGroup(typeof(PresentationLateSystemGroup), UpdatePriority.Normal)]
	public class NetworkClientSystem : EntitySystemBase
	{
		private ObjectQuery<NetworkIdentity> _query;

		protected override void OnCreateSystem()
		{
			_query = base.entityManager.CreateObjectQuery<NetworkIdentity>(EntityQueryFlags.All);
		}

		protected override void OnUpdateSystem()
		{
			if (!NetworkClient.active || NetworkServer.active)
			{
				return;
			}
			_query.Run();
			for (int i = 0; i < _query.count; i++)
			{
				_query.Get(i, out Entity entity, out NetworkIdentity obj);
				if (!obj.isClient)
				{
					base.entityManager.DestroyEntity(entity.key);
				}
			}
		}
	}
}
