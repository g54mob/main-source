using System;
using Platforms;

namespace Kitchen
{
	public class GetBestSpeedrun : FranchiseFirstFrameSystem
	{
		protected override async void OnUpdate()
		{
			EntityContext ctx = new EntityContext(base.EntityManager);
			if (!SpeedrunHelpers.IsStatsRoomUnlocked(ctx) || !Platform.Current.SupportsLeaderboards)
			{
				return;
			}
			(SBestSpeedrun, bool) obj = await SpeedrunHelpers.GetScore(ctx);
			var (data, _) = obj;
			if (!obj.Item2)
			{
				ctx.Destroy<SBestSpeedrun>();
				return;
			}
			try
			{
				if (!ctx.RequireEntity<SBestSpeedrun>(out var comp))
				{
					comp = ctx.CreateEntity();
					ctx.Add<SBestSpeedrun>(comp);
				}
				ctx.Ensure<CPersistThroughSceneChanges>(comp);
				ctx.Set(comp, data);
			}
			catch (ObjectDisposedException)
			{
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
