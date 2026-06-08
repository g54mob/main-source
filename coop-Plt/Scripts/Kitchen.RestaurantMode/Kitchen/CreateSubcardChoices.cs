using System.Runtime.InteropServices;
using Unity.Entities;

namespace Kitchen
{
	[UpdateInGroup(typeof(EndOfDayProgressionGroup))]
	[UpdateAfter(typeof(CreateShopRequests))]
	[UpdateBefore(typeof(FindNewUnlocks))]
	[UpdateBefore(typeof(HandleNewShop))]
	public class CreateSubcardChoices : RestaurantSystem
	{
		[StructLayout(LayoutKind.Sequential, Size = 1)]
		private struct SHasRun : IComponentData
		{
		}

		private EntityQuery Choices;

		private EntityQuery CurrentOptions;

		protected override void Initialise()
		{
			base.Initialise();
			Choices = GetEntityQuery(typeof(CSubcardChoice));
			CurrentOptions = GetEntityQuery(typeof(CProgressionOption));
			RequireForUpdate(Choices);
		}

		protected override void OnUpdate()
		{
			if (CurrentOptions.IsEmpty)
			{
				Entity entity = Choices.First();
				CSubcardChoice cSubcardChoice = Choices.First<CSubcardChoice>();
				AddOption(cSubcardChoice.Choice1, cSubcardChoice.FromFranchise);
				AddOption(cSubcardChoice.Choice2, cSubcardChoice.FromFranchise);
				base.EntityManager.DestroyEntity(entity);
			}
		}

		private void AddOption(int id, bool from_franchise)
		{
			Entity entity = base.EntityManager.CreateEntity(typeof(CProgressionOption));
			Set(entity, new CUnlockSelectPopupType
			{
				RewardType = UnlockRewardType.Subcard
			});
			base.EntityManager.SetComponentData(entity, new CProgressionOption
			{
				ID = id,
				FromFranchise = from_franchise
			});
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
