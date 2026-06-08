using Unity.Entities;

namespace Kitchen
{
	[UpdateInGroup(typeof(TimeManagementGroup))]
	public class UpdateSpeedrunDuration : RestaurantSystem
	{
		private EntityQuery Popups;

		protected override void Initialise()
		{
			base.Initialise();
			Popups = GetEntityQuery(typeof(CPopup));
		}

		protected override void OnUpdate()
		{
			if (!Has<SGameOver>() && !Has<SPracticeMode>() && !base.Time.IsPaused && Popups.IsEmpty)
			{
				Require<SSpeedrunDuration>(out var comp);
				comp.Seconds += base.Time.DeltaTime;
				Set(comp);
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
