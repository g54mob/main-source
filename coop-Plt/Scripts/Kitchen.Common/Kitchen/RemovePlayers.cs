using Unity.Collections;
using Unity.Entities;

namespace Kitchen
{
	public class RemovePlayers : GenericSystemBase
	{
		private EntityQuery DisconnectPlayers;

		protected override void Initialise()
		{
			base.Initialise();
			DisconnectPlayers = GetEntityQuery(typeof(CDisconnectPlayerEvent));
		}

		protected override void OnUpdate()
		{
			NativeArray<CDisconnectPlayerEvent> nativeArray = DisconnectPlayers.ToComponentDataArray<CDisconnectPlayerEvent>(Allocator.Temp);
			foreach (CDisconnectPlayerEvent item in nativeArray)
			{
				if (base.EntityManager.RequireComponent<CItemHolder>(item.Player, out var component) && HasComponent<CHeldBy>(component.HeldItem))
				{
					base.EntityManager.AddComponent<CReturnItem>(component.HeldItem);
				}
				base.EntityManager.DestroyEntity(item.Player);
			}
			base.EntityManager.DestroyEntity(DisconnectPlayers);
			nativeArray.Dispose();
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
