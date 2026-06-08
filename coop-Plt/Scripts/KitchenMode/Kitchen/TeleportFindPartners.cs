using System.Collections.Generic;
using Unity.Collections;
using Unity.Entities;

namespace Kitchen
{
	public class TeleportFindPartners : GameSystemBase
	{
		private EntityQuery Teleporters;

		private HashSet<int> TempAssigned = new HashSet<int>();

		protected override void Initialise()
		{
			base.Initialise();
			Teleporters = GetEntityQuery(typeof(CConveyTeleport), typeof(CItemHolder));
		}

		protected override void OnUpdate()
		{
			if (Teleporters.IsEmpty)
			{
				return;
			}
			using NativeArray<Entity> nativeArray = Teleporters.ToEntityArray(Allocator.Temp);
			using NativeArray<CConveyTeleport> nativeArray2 = Teleporters.ToComponentDataArray<CConveyTeleport>(Allocator.Temp);
			TempAssigned.Clear();
			foreach (CConveyTeleport item in nativeArray2)
			{
				TempAssigned.Add(item.GroupID);
			}
			Entity entity = default(Entity);
			foreach (Entity item2 in nativeArray)
			{
				if (!Require<CConveyTeleport>(item2, out CConveyTeleport comp) || comp.Target != default(Entity))
				{
					continue;
				}
				if (entity == default(Entity))
				{
					entity = item2;
					continue;
				}
				int groupID = 1;
				for (int i = 1; i < nativeArray2.Length; i++)
				{
					if (!TempAssigned.Contains(i))
					{
						groupID = i;
						break;
					}
				}
				Set(item2, new CConveyTeleport
				{
					Target = entity,
					GroupID = groupID
				});
				Set(entity, new CConveyTeleport
				{
					Target = item2,
					GroupID = groupID
				});
				break;
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
