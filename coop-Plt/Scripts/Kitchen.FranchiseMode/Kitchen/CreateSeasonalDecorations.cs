using System.Collections.Generic;
using KitchenData;

namespace Kitchen
{
	public class CreateSeasonalDecorations : FranchiseFirstFrameSystem
	{
		protected override void OnUpdate()
		{
			IEnumerable<SeasonalDecorationLayout> enumerable = GameData.Main.Get<SeasonalDecorationLayout>();
			Season season = Seasons.GetSeason();
			foreach (SeasonalDecorationLayout item in enumerable)
			{
				if (item.SeasonActive != season)
				{
					continue;
				}
				foreach (SeasonalDecorationLayout.Decoration decoration in item.Decorations)
				{
					Create(decoration.Appliance, decoration.Position, decoration.Facing);
				}
				foreach (SeasonalDecorationLayout.DecorOverride decorOverride in item.DecorOverrides)
				{
					Set(base.EntityManager.CreateEntity(), new CChangeDecorEvent
					{
						RoomID = decorOverride.RoomID,
						DecorID = decorOverride.Decor.ID,
						Type = decorOverride.Decor.Type
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
