using Unity.Entities;

namespace Kitchen
{
	public class AchievementPleaseWait : AchievementManager<AchievementPleaseWait.SState>
	{
		public struct SState : IComponentData
		{
			public Entity First;
		}

		private EntityQuery Groups;

		protected override string Identifier => "PLEASE_WAIT";

		protected override void Initialise()
		{
			base.Initialise();
			Groups = GetEntityQuery(typeof(CCustomerGroup));
		}

		protected override void HandleUpdate(ref SState data)
		{
			if (Has<SPracticeMode>())
			{
				return;
			}
			if (Has<SIsNightTime>())
			{
				data.First = default(Entity);
			}
			STime comp;
			if (data.First == default(Entity))
			{
				if (!Groups.IsEmpty)
				{
					data.First = Groups.First();
				}
			}
			else if (Require<STime>(out comp) && comp.TimeOfDayUnbounded >= 0.99f && Has<CGroupReadyToOrder>(data.First))
			{
				Unlock();
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
