using System.Collections.Generic;
using Unity.Collections;
using Unity.Entities;

namespace Kitchen
{
	public class FindPartners : GameSystemBase
	{
		private EntityQuery PartnerSeekers;

		private HashSet<int> _Assigned = new HashSet<int>();

		private HashSet<PartnerType> _GroupTypes = new HashSet<PartnerType>();

		protected override void Initialise()
		{
			base.Initialise();
			PartnerSeekers = GetEntityQuery(typeof(CAutoPartner));
		}

		protected override void OnUpdate()
		{
			if (PartnerSeekers.IsEmpty)
			{
				return;
			}
			using NativeArray<Entity> nativeArray = PartnerSeekers.ToEntityArray(Allocator.Temp);
			using NativeArray<CAutoPartner> nativeArray2 = PartnerSeekers.ToComponentDataArray<CAutoPartner>(Allocator.Temp);
			_Assigned.Clear();
			_GroupTypes.Clear();
			foreach (CAutoPartner item in nativeArray2)
			{
				_Assigned.Add(item.GroupID);
				_GroupTypes.Add(item.Type);
			}
			foreach (PartnerType groupType in _GroupTypes)
			{
				Entity entity = default(Entity);
				foreach (Entity item2 in nativeArray)
				{
					if (!Require<CAutoPartner>(item2, out CAutoPartner comp) || comp.Type != groupType || comp.Target != default(Entity))
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
						if (!_Assigned.Contains(i))
						{
							groupID = i;
							break;
						}
					}
					Set(item2, new CAutoPartner
					{
						Type = comp.Type,
						Target = entity,
						GroupID = groupID
					});
					Set(entity, new CAutoPartner
					{
						Type = comp.Type,
						Target = item2,
						GroupID = groupID
					});
					return;
				}
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
