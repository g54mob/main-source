using System.Collections.Generic;
using Controllers;
using Kitchen.NetworkSupport;
using Unity.Collections;
using Unity.Entities;

namespace Kitchen
{
	public class RemoveDuplicatedPlayers : GenericSystemBase
	{
		private EntityQuery Players;

		private HashSet<int> SeenIDs = new HashSet<int>();

		protected override void Initialise()
		{
			base.Initialise();
			Players = GetEntityQuery(typeof(CPlayer));
		}

		protected override void OnUpdate()
		{
			using NativeArray<CPlayer> nativeArray = Players.ToComponentDataArray<CPlayer>(Allocator.Temp);
			using NativeArray<Entity> nativeArray2 = Players.ToEntityArray(Allocator.Temp);
			SeenIDs.Clear();
			for (int i = 0; i < nativeArray.Length; i++)
			{
				CPlayer cPlayer = nativeArray[i];
				if (SeenIDs.Contains(cPlayer.ID))
				{
					EventLog.Session.Report(SessionEvent.DuplicatePlayersFound, $"{cPlayer.ID}, local: {cPlayer.InputSource == InputSourceIdentifier.Identifier}");
					Entity entity = base.EntityManager.CreateEntity(typeof(CDisconnectPlayerEvent));
					base.EntityManager.SetComponentData(entity, new CDisconnectPlayerEvent
					{
						Player = nativeArray2[i]
					});
				}
				SeenIDs.Add(cPlayer.ID);
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
