using Unity.Entities;

namespace Kitchen
{
	public abstract class WatchCountAchievement<T> : AchievementRequiresEndDay<T> where T : struct, IComponentData, IAchievementSatisfied
	{
		private EntityQuery CountEnts;

		protected abstract int RequiredCount { get; }

		protected abstract EntityQuery GetQuery();

		protected override void Initialise()
		{
			base.Initialise();
			CountEnts = GetQuery();
		}

		protected override bool IsSatisfied(T data)
		{
			return data.IsSatisfied;
		}

		protected override void Reset(ref T data)
		{
		}

		protected override void Check(ref T data)
		{
			data.IsSatisfied = !CountEnts.IsEmpty && CountEnts.CalculateEntityCount() >= RequiredCount;
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
