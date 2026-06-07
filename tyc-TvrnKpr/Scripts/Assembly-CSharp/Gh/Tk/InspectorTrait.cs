namespace Gh.Tk
{
	public class InspectorTrait : ActorTrait
	{
		[PersistenceOptIn]
		public bool IsInspecting { get; set; }

		protected InspectorTrait()
		{
		}

		public InspectorTrait(Actor owner)
		{
		}
	}
}
