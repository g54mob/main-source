using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public class ManageDishSelectionIndicators : PlayerSpecificUIIndicator<CDishSourceCabinet, CDishSelectionInfo>
	{
		private EntityQuery DishUpgrades;

		protected override ViewType ViewType => ViewType.DishSelectorUI;

		protected override void Initialise()
		{
			base.Initialise();
			DishUpgrades = GetEntityQuery(typeof(CDishUpgrade));
		}

		protected override CDishSelectionInfo GetInfo(Entity source, CDishSourceCabinet selector, CTriggerPlayerSpecificUI trigger, CPlayer player)
		{
			return new CDishSelectionInfo
			{
				Player = player,
				PlayerEntity = trigger.TriggerEntity
			};
		}

		protected override bool CheckIfIndicatorShouldBeCreated(Entity trigger)
		{
			if ((!Require<CItemHolder>(trigger, out CItemHolder comp) || comp.HeldItem != default(Entity)) && !IsReturnableItem(comp.HeldItem))
			{
				return false;
			}
			return true;
		}

		protected override bool ShouldDismiss(CDishSelectionInfo info)
		{
			if (info.Dish != 0)
			{
				GivePlayerDish(info.PlayerEntity, info.Dish);
				return true;
			}
			return base.ShouldDismiss(info);
		}

		private bool IsReturnableItem(Entity item)
		{
			if (Has<CIsFromCabinet>(item))
			{
				return true;
			}
			return false;
		}

		private void GivePlayerDish(Entity player, int dish)
		{
			EntityManager entityManager = base.EntityManager;
			if (!Require<CItemHolder>(player, out CItemHolder comp) || comp.HeldItem != default(Entity))
			{
				if (!IsReturnableItem(comp.HeldItem))
				{
					return;
				}
				entityManager.DestroyEntity(comp.HeldItem);
			}
			Entity entity = entityManager.CreateEntity(typeof(CCreateItem), typeof(CHeldBy), typeof(CHome));
			entityManager.SetComponentData(entity, new CCreateItem
			{
				ID = AssetReference.DishPaper
			});
			entityManager.SetComponentData(entity, new CHeldBy
			{
				Holder = player
			});
			entityManager.SetComponentData(player, new CItemHolder
			{
				HeldItem = entity
			});
			entityManager.AddComponentData(entity, new CDishChoice
			{
				Dish = dish
			});
			entityManager.AddComponentData(entity, default(CIsFromCabinet));
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
