using System.Runtime.InteropServices;
using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	[UpdateInGroup(typeof(ChangeModeGroup))]
	[UpdateAfter(typeof(CreateNewKitchen))]
	public class CreateCardSetsFromSetting : GameSystemBase
	{
		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct SSettingUnlockPack : IComponentData
		{
		}

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct CHasCreated : IComponentData
		{
		}

		protected override void OnUpdate()
		{
			if (!Has<CHasCreated>() && RequireEntity<SLayout>(out var comp) && Require<CSetting>(comp, out CSetting comp2) && GameData.Main.TryGet<RestaurantSetting>(comp2.RestaurantSetting, out var output))
			{
				Set<CHasCreated>();
				if (output.UnlockPack != null)
				{
					Entity e = base.EntityManager.CreateEntity(typeof(SSettingUnlockPack), typeof(CUnlockPack));
					Set(e, new CUnlockPack
					{
						ActiveUnlockPack = output.UnlockPack.ID
					});
				}
				if (output.StartingUnlock != null)
				{
					Entity entity = base.EntityManager.CreateEntity(typeof(CProgressionOption));
					base.EntityManager.SetComponentData(entity, new CProgressionOption
					{
						ID = output.StartingUnlock.ID
					});
					Set(entity, new CUnlockSelectPopupType
					{
						RewardType = UnlockRewardType.Setting
					});
				}
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
