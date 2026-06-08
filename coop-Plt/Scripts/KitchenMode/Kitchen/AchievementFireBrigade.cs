using Unity.Entities;

namespace Kitchen
{
	public class AchievementFireBrigade : WatchCountAchievement<AchievementFireBrigade.SState>
	{
		public struct SState : IComponentData, IAchievementSatisfied
		{
			public bool IsSatisfied { get; set; }
		}

		protected override int RequiredCount { get; } = 10;

		protected override string Identifier => "FIRE_BRIGADE";

		protected override EntityQuery GetQuery()
		{
			return GetEntityQuery(typeof(CFire));
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
