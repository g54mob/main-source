using System.Collections.Generic;
using System.Linq;
using KitchenData;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	[UpdateBefore(typeof(CreateOffice))]
	public class GrantLevelUpgrades : FranchiseFirstFrameSystem
	{
		private EntityQuery GrantedRewards;

		[ReadOnly]
		private EntityQuery _SingletonEntityQuery_SPlayerLevel_5;

		protected override void Initialise()
		{
			base.Initialise();
			GrantedRewards = GetEntityQuery(typeof(CUpgrade));
			RequireSingletonForUpdate<SPlayerLevel>();
		}

		protected override void OnUpdate()
		{
			int level = _SingletonEntityQuery_SPlayerLevel_5.GetSingleton<SPlayerLevel>().Level;
			NativeArray<CUpgrade> nativeArray = GrantedRewards.ToComponentDataArray<CUpgrade>(Allocator.Temp);
			IEnumerable<int> enumerable = nativeArray.Select((CUpgrade e) => e.ID);
			nativeArray.Dispose();
			List<int> list = new List<int>();
			foreach (LevelUpgradeSet item in base.Data.Get<LevelUpgradeSet>().ToList())
			{
				int level2;
				for (level2 = 0; level2 < level; level2++)
				{
					foreach (LevelUpgrade item2 in item.Upgrades.Where((LevelUpgrade u) => u.Level == level2 + 1))
					{
						if (item2.Upgrade != null)
						{
							list.Add(item2.Upgrade.ID);
						}
					}
				}
			}
			foreach (int item3 in enumerable)
			{
				list.Remove(item3);
			}
			foreach (int item4 in list)
			{
				Debug.Log($"Granting {item4}");
				ProvideReward(item4);
			}
		}

		protected void ProvideReward(int upg)
		{
			Entity entity = base.EntityManager.CreateEntity();
			base.EntityManager.AddComponentData(entity, default(CPersistThroughSceneChanges));
			base.EntityManager.AddComponentData(entity, new CUpgrade
			{
				ID = upg,
				IsFromLevel = true
			});
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_SingletonEntityQuery_SPlayerLevel_5 = GetEntityQuery(ComponentType.ReadOnly<SPlayerLevel>());
		}
	}
}
