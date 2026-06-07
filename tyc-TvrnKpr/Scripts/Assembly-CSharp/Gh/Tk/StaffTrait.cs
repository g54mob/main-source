using System;

namespace Gh.Tk
{
	public abstract class StaffTrait : ActorTrait
	{
		private static Type[] _staffTraits;

		[PersistenceOptIn]
		[PersistenceObjectReference]
		public new Staff Owner
		{
			get
			{
				return null;
			}
			protected set
			{
			}
		}

		protected StaffTrait()
		{
		}

		public StaffTrait(Staff owner)
		{
		}

		public virtual void OnHired()
		{
		}

		public virtual void OnFired()
		{
		}

		public static (Type, float)[] GetAllStaffTraitCandidates(Staff staff)
		{
			return null;
		}

		public static bool IsTraitAllowedForStaff(Type traitType, Staff staff)
		{
			return false;
		}

		public static Type[] GetIncompatibleTraits(Actor actor)
		{
			return null;
		}
	}
}
