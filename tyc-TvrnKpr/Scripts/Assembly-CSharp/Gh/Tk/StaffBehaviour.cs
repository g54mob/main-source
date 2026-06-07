namespace Gh.Tk
{
	public abstract class StaffBehaviour : ActorBehaviour
	{
		[PersistenceObjectReference]
		[PersistenceOptIn]
		protected new Staff Owner
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		protected StaffBehaviour()
		{
		}

		public StaffBehaviour(Staff owner, string name, int priority = 0)
		{
		}

		public override bool ShouldAutoAddTo(GameObjectX gox)
		{
			return false;
		}

		public override bool IsActive()
		{
			return false;
		}
	}
}
