using Kitchen.Layouts;
using Unity.Collections;
using Unity.Entities;

namespace Kitchen
{
	[UpdateInGroup(typeof(HighPriorityInteractionGroup))]
	[UpdateBefore(typeof(UpdateTakesDuration))]
	public class ApplyDecorationInteraction : InteractionSystem
	{
		private EntityQuery DecorChanges;

		private CPosition InteractorPosition;

		private CItemHolder ItemHolder;

		private CApplyDecor ApplyDecor;

		private CLayoutRoomTile Tile;

		private NativeArray<CChangeDecorEvent> ChangeDecorEvents;

		private NativeArray<Entity> ChangeDecorEntities;

		protected override InteractionMode RequiredMode => InteractionMode.Appliances;

		protected override void Initialise()
		{
			base.Initialise();
			DecorChanges = GetEntityQuery(typeof(CChangeDecorEvent));
		}

		protected override bool BeforeRun()
		{
			ChangeDecorEvents = DecorChanges.ToComponentDataArray<CChangeDecorEvent>(Allocator.Temp);
			ChangeDecorEntities = DecorChanges.ToEntityArray(Allocator.Temp);
			return true;
		}

		protected override void AfterRun()
		{
			base.AfterRun();
			ChangeDecorEvents.Dispose();
			ChangeDecorEntities.Dispose();
		}

		protected override bool IsPossible(ref InteractionData data)
		{
			if (!Require<CPosition>(data.Interactor, out InteractorPosition))
			{
				return false;
			}
			if (!Require<CItemHolder>(data.Interactor, out ItemHolder) || ItemHolder.HeldItem == default(Entity))
			{
				return false;
			}
			if (!Require<CApplyDecor>(ItemHolder.HeldItem, out ApplyDecor))
			{
				return false;
			}
			Tile = base.TileManager.GetTile(InteractorPosition);
			if (!LayoutHelpers.IsInside(Tile.Type))
			{
				return false;
			}
			return true;
		}

		protected override void Perform(ref InteractionData data)
		{
			CApplyDecor applyDecor = ApplyDecor;
			int num = 0;
			for (int i = 0; i < ChangeDecorEvents.Length; i++)
			{
				CChangeDecorEvent cChangeDecorEvent = ChangeDecorEvents[i];
				Entity entity = ChangeDecorEntities[i];
				if (cChangeDecorEvent.RoomID == Tile.RoomID && cChangeDecorEvent.Type == applyDecor.Type)
				{
					num = cChangeDecorEvent.DecorID;
					data.Context.Destroy(entity);
				}
			}
			Entity entity2 = data.Context.CreateEntity();
			data.Context.Set(entity2, new CChangeDecorEvent
			{
				RoomID = Tile.RoomID,
				DecorID = applyDecor.ID,
				Type = applyDecor.Type
			});
			if (num == 0)
			{
				data.Context.Destroy(ItemHolder.HeldItem);
				data.Context.Set(data.Interactor, default(CItemHolder));
				return;
			}
			data.Context.Set(ItemHolder.HeldItem, new CApplyDecor
			{
				Type = applyDecor.Type,
				ID = num
			});
			data.Context.Set(ItemHolder.HeldItem, new CDrawApplianceUsing
			{
				DrawApplianceID = num
			});
			data.Context.Remove<CLinkedView>(ItemHolder.HeldItem);
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
