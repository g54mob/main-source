using Unity.Entities;

namespace Kitchen
{
	public class AchievementWhatAState : WatchCountAchievement<AchievementWhatAState.SState>
	{
		public struct SState : IComponentData, IAchievementSatisfied
		{
			public bool IsSatisfied { get; set; }
		}

		protected override string Identifier => "WHAT_A_STATE";

		protected override int RequiredCount { get; } = 10;

		protected override EntityQuery GetQuery()
		{
			return GetEntityQuery(typeof(CMess));
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
