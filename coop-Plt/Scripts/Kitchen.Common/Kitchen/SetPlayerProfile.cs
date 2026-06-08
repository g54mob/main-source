using System.Collections.Generic;
using Unity.Collections;
using Unity.Entities;

namespace Kitchen
{
	public class SetPlayerProfile : GenericSystemBase
	{
		private EntityQuery SetPlayerProfiles;

		private EntityQuery Players;

		private HashSet<int> Seen = new HashSet<int>();

		protected override void Initialise()
		{
			base.Initialise();
			SetPlayerProfiles = GetEntityQuery(typeof(CSetPlayerProfile));
			Players = GetEntityQuery(typeof(CPlayer), typeof(CPlayerColour), typeof(CPlayerCosmetics));
			RequireForUpdate(SetPlayerProfiles);
		}

		protected override void OnUpdate()
		{
			using NativeArray<Entity> nativeArray = SetPlayerProfiles.ToEntityArray(Allocator.TempJob);
			using NativeArray<Entity> nativeArray2 = Players.ToEntityArray(Allocator.TempJob);
			Seen.Clear();
			foreach (Entity item in nativeArray)
			{
				if (!Require<CSetPlayerProfile>(item, out CSetPlayerProfile comp))
				{
					continue;
				}
				if (Seen.Contains(comp.PlayerID))
				{
					base.EntityManager.DestroyEntity(item);
					continue;
				}
				Seen.Add(comp.PlayerID);
				foreach (Entity item2 in nativeArray2)
				{
					if (!Require<CPlayer>(item2, out CPlayer comp2))
					{
						return;
					}
					if (comp.PlayerID == comp2.ID)
					{
						SetComponent(item2, new CPlayerColour
						{
							Color = comp.Colour
						});
						SetComponent(item2, new CPlayerCosmetics
						{
							Cosmetics = comp.Cosmetics
						});
						base.EntityManager.DestroyEntity(item);
						break;
					}
				}
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
