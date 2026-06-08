using KitchenData;
using Platforms;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	public class CreateLocationsRoom : FranchiseFirstFrameSystem
	{
		protected override void OnUpdate()
		{
			if (PlatformSettings.DebugQuickLoadLobby)
			{
				return;
			}
			Entity e = Set<SSelectedLocation>();
			Set<CPersistThroughSceneChanges>(e);
			Set<CDoNotPersist>(e);
			float num = 1.1f;
			Create(AssetReference.FranchiseMap, new Vector3(-1f, 0f, 0f), Vector3.forward);
			bool flag = true;
			int num2 = 0;
			foreach (var item3 in Persistence.FullWorld.All())
			{
				World item = item3.Item1;
				SaveState item2 = item3.Item2;
				num2++;
				Entity entity = base.EntityManager.CreateEntity(typeof(CCreateAppliance), typeof(CPosition), typeof(CLocationChoice), typeof(CGenericInputIndicatorOffset));
				CLocationChoice cLocationChoice = new CLocationChoice
				{
					Slot = num2,
					State = item2
				};
				if (item2 == SaveState.Loaded)
				{
					EntityContext entityContext = new EntityContext(item.EntityManager);
					if (entityContext.RequireEntity<SLayout>(out var comp) && entityContext.Require<CSetting>(comp, out var comp2))
					{
						cLocationChoice.Setting = comp2.RestaurantSetting;
						cLocationChoice.Seed = comp2.FixedSeed;
						cLocationChoice.FranchiseTier = entityContext.GetOrDefault<CFranchiseTier>(comp).Tier;
						cLocationChoice.RestaurantName = (entityContext.Require<CRenameRestaurant>(out var comp3) ? comp3.Name : ((FixedString64)""));
						cLocationChoice.RestaurantSafeName = (entityContext.Require<SRestaurantStartingName>(out var comp4) ? comp4.Name : ((FixedString64)""));
						cLocationChoice.Day = (entityContext.Require<SDay>(out var comp5) ? comp5.Day : 0);
					}
					else
					{
						cLocationChoice.State = SaveState.Failed;
					}
				}
				Set(entity, new CGenericInputIndicatorOffset
				{
					Offset = new Vector3(0f, 2f, 0f)
				});
				switch (cLocationChoice.State)
				{
				case SaveState.Loaded:
					Set(entity, new CRequiresGenericInputIndicator
					{
						Message = InputIndicatorMessage.ReloadSave
					});
					break;
				case SaveState.Failed:
					Set(entity, new CRequiresGenericInputIndicator
					{
						Message = InputIndicatorMessage.AbandonSave
					});
					break;
				case SaveState.Empty:
					if (flag)
					{
						Set(e, new SSelectedLocation
						{
							Valid = true,
							Selected = cLocationChoice
						});
					}
					flag = false;
					break;
				}
				Vector3 vector = new Vector3(-1f + num * (float)(num2 - 3), 0f, -0.5f);
				Set(entity, new CCreateAppliance
				{
					ID = AssetReference.LocationLoader
				});
				Set(entity, new CPosition
				{
					Position = vector
				});
				Set(entity, cLocationChoice);
				Entity e2 = Create(GameData.Main.Get<Appliance>(AssetReference.InteractionProxy), vector + new Vector3(0f, 0f, 1f), Vector3.forward);
				Set(e2, new CInteractionProxy
				{
					Target = entity,
					IsActive = true
				});
			}
			if (flag)
			{
				Set(e, new SSelectedLocation
				{
					Valid = false
				});
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
