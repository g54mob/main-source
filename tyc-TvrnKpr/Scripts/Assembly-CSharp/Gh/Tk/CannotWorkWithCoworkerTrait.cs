using System;

namespace Gh.Tk
{
	[TraitRarityConfig(0f, null)]
	public class CannotWorkWithCoworkerTrait : StaffTrait
	{
		[PersistenceOptIn]
		[PersistenceObjectReference]
		private HappinessStat _happinessStat;

		[PersistenceOptIn]
		[PersistenceObjectReference]
		public Staff Coworker { get; private set; }

		protected CannotWorkWithCoworkerTrait()
		{
		}

		public CannotWorkWithCoworkerTrait(Staff owner)
		{
		}

		public CannotWorkWithCoworkerTrait(Staff owner, Staff coworker)
		{
		}

		public override void FirstInit()
		{
		}

		public override void Init()
		{
		}

		private void OnStaffFired(object sender, EventArgs<Staff> e)
		{
		}

		public override void OnRemoving()
		{
		}

		private void OnOwnerDestroyed(object sender, EventArgs e)
		{
		}

		public override void Update()
		{
		}
	}
}
