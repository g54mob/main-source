using System;
using System.Collections.Generic;
using KitchenData;
using Unity.Collections;
using Unity.Entities;

namespace Kitchen
{
	public class SelectFishOfDay : StartOfDaySystem
	{
		public EntityQuery ItemSources;

		public EntityQuery MenuItems;

		public EntityQuery DisabledMenuItems;

		protected override void Initialise()
		{
			base.Initialise();
			MenuItems = GetEntityQuery(typeof(CMenuItem), typeof(CDynamicMenuItem));
			DisabledMenuItems = GetEntityQuery(typeof(CDisabledMenuItem), typeof(CDynamicMenuItem));
			ItemSources = GetEntityQuery(typeof(CItemProvider), typeof(CDynamicMenuProvider));
			RequireForUpdate(MenuItems);
		}

		protected override void OnUpdate()
		{
			base.EntityManager.RemoveComponent<CDisabledMenuItem>(DisabledMenuItems);
			NativeArray<Entity> nativeArray = MenuItems.ToEntityArray(Allocator.Temp);
			NativeArray<CDynamicMenuItem> nativeArray2 = MenuItems.ToComponentDataArray<CDynamicMenuItem>(Allocator.Temp);
			NativeArray<Entity> nativeArray3 = ItemSources.ToEntityArray(Allocator.Temp);
			NativeArray<CDynamicMenuProvider> nativeArray4 = ItemSources.ToComponentDataArray<CDynamicMenuProvider>(Allocator.Temp);
			foreach (DynamicMenuType value in Enum.GetValues(typeof(DynamicMenuType)))
			{
				List<Entity> list = new List<Entity>();
				List<Entity> list2 = new List<Entity>();
				for (int i = 0; i < nativeArray2.Length; i++)
				{
					if (nativeArray2[i].Type == value)
					{
						(nativeArray2[i].HasBeenProvided ? list : list2).Add(nativeArray[i]);
					}
				}
				List<Entity> list3 = new List<Entity>();
				for (int j = 0; j < nativeArray4.Length; j++)
				{
					if (nativeArray4[j].Type == value)
					{
						list3.Add(nativeArray3[j]);
					}
				}
				List<Entity> list4 = list.Shuffle();
				for (int k = 0; k < list2.Count + list4.Count; k++)
				{
					Entity entity = ((k < list2.Count) ? list2[k] : list4[k - list2.Count]);
					if (k < list3.Count)
					{
						CDynamicMenuItem componentData = base.EntityManager.GetComponentData<CDynamicMenuItem>(entity);
						CItemProvider componentData2 = base.EntityManager.GetComponentData<CItemProvider>(list3[k]);
						componentData2.SetAsItem(componentData.Ingredient);
						base.EntityManager.SetComponentData(list3[k], componentData2);
						componentData.HasBeenProvided = true;
						base.EntityManager.SetComponentData(entity, componentData);
					}
					else
					{
						base.EntityManager.AddComponent<CDisabledMenuItem>(entity);
					}
				}
			}
			nativeArray2.Dispose();
			nativeArray.Dispose();
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
