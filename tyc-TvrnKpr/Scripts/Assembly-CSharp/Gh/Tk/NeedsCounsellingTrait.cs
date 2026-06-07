namespace Gh.Tk
{
	public class NeedsCounsellingTrait : ActorTrait
	{
		[PersistenceOptIn]
		public bool CounsellingWasDone { get; internal set; }

		protected NeedsCounsellingTrait()
		{
		}

		public NeedsCounsellingTrait(Patron owner)
		{
		}

		public override void Init()
		{
		}

		public override bool ShouldAutoAddTo(GameObjectX gox)
		{
			return false;
		}
	}
}
