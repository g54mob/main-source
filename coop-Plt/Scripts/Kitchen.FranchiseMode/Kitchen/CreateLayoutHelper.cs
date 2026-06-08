using Kitchen.Layouts;
using KitchenData;
using Platforms;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	public static class CreateLayoutHelper
	{
		public static int MapAttemptsMax = 100;

		public static Entity ConstructLayout(EntityManager em, LayoutProfile profile, RestaurantSetting setting, int seed)
		{
			Entity entity = em.CreateEntity(typeof(CStartingItem), typeof(CLayoutRoomTile), typeof(CLayoutFeature), typeof(CLayoutAppliancePlacement));
			LayoutDecorator layoutDecorator = null;
			LayoutBlueprint layoutBlueprint = null;
			bool flag = false;
			for (int i = 0; i < MapAttemptsMax; i++)
			{
				try
				{
					layoutBlueprint = profile.Graph.Build(seed + i);
					layoutDecorator = new LayoutDecorator(layoutBlueprint, profile, setting);
					layoutDecorator.AttemptDecoration();
					flag = true;
				}
				catch (LayoutFailureException arg)
				{
					if (PlatformSettings.IsDebugBuild)
					{
						Debug.Log($"Failed to build layout - {arg}");
					}
					continue;
				}
				break;
			}
			if (!flag || layoutDecorator?.Decorations == null)
			{
				Debug.LogError($"Giving up after {MapAttemptsMax} attempts");
				em.DestroyEntity(entity);
				return default(Entity);
			}
			layoutBlueprint.ToEntity(em, entity);
			DynamicBuffer<CLayoutAppliancePlacement> buffer = em.GetBuffer<CLayoutAppliancePlacement>(entity);
			foreach (CLayoutAppliancePlacement decoration in layoutDecorator.Decorations)
			{
				buffer.Add(decoration);
			}
			return entity;
		}
	}
}
