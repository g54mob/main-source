using System.Linq;
using System.Runtime.InteropServices;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	public class HandleLayoutRequests : FranchiseSystem
	{
		[StructLayout(LayoutKind.Sequential, Size = 1)]
		private struct CClearOnLayoutRequest : IComponentData
		{
		}

		public struct SLayoutRequest : IComponentData
		{
			public Entity Franchise;

			public bool HasBeenCreated;
		}

		private EntityQuery LayoutUpgrades;

		private EntityQuery LayoutSizeUpgrades;

		private EntityQuery Requests;

		private EntityQuery Slots;

		private EntityQuery MapItems;

		private EntityQuery SettingSelectors;

		public static bool Initialised { get; private set; }

		protected override void Initialise()
		{
			base.Initialise();
			LayoutUpgrades = GetEntityQuery(typeof(CLayoutUpgrade));
			LayoutSizeUpgrades = GetEntityQuery(typeof(CUpgradeExtraLayout));
			Requests = GetEntityQuery(typeof(SLayoutRequest));
			Slots = GetEntityQuery(typeof(CreateLayoutSlots.CLayoutSlot), typeof(CItemHolder));
			MapItems = GetEntityQuery(typeof(CItemLayoutMap), typeof(CClearOnLayoutRequest));
			SettingSelectors = GetEntityQuery(typeof(CSettingSelector));
			RequireForUpdate(Requests);
			RequireForUpdate(Slots);
		}

		protected override void OnUpdate()
		{
			if (!Require<SLayoutRequest>(out var comp) || comp.HasBeenCreated)
			{
				return;
			}
			base.EntityManager.DestroyEntity(MapItems);
			int setting_id = CSettingSelector.IDFromQuery(SettingSelectors);
			using NativeArray<CLayoutUpgrade> nativeArray = LayoutUpgrades.ToComponentDataArray<CLayoutUpgrade>(Allocator.Temp);
			int[] array = nativeArray.Select((CLayoutUpgrade x) => x.LayoutID).ToArray();
			using NativeArray<Entity> nativeArray2 = Slots.ToEntityArray(Allocator.Temp);
			foreach (Entity item in nativeArray2)
			{
				int source = Random.Range(int.MinValue, int.MaxValue);
				LayoutSeed ls = new LayoutSeed(source, array);
				if (array.Length > 1)
				{
					array = array.Where((int x) => x != ls.LayoutID).ToArray();
				}
				Entity entity = ls.GenerateMap(base.EntityManager, setting_id);
				base.EntityManager.AddComponent<CClearOnLayoutRequest>(entity);
				base.EntityManager.SetComponentData(item, (CItemHolder)entity);
				base.EntityManager.SetComponentData(entity, (CHeldBy)item);
				base.EntityManager.SetComponentData(entity, (CHome)item);
			}
			comp.HasBeenCreated = true;
			Set(comp);
			Initialised = true;
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
