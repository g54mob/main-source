using Unity.Entities;

namespace Kitchen
{
	public class AchievementWorkHard : AchievementRequiresEndDay<AchievementWorkHard.SState>
	{
		public struct SState : IComponentData
		{
			public int Served;
		}

		public const float RequiredCustomerGroups = 30f;

		private EntityQuery ServedEvents;

		protected override string Identifier => "WORK_HARD";

		protected override void Initialise()
		{
			base.Initialise();
			ServedEvents = GetEntityQuery(typeof(CGroupServedEvent));
		}

		protected override bool IsSatisfied(SState data)
		{
			return (float)data.Served >= 30f;
		}

		protected override void Reset(ref SState data)
		{
			data.Served = 0;
		}

		protected override void Check(ref SState data)
		{
			data.Served += ServedEvents.CalculateEntityCount();
			base.EntityManager.DestroyEntity(ServedEvents);
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
