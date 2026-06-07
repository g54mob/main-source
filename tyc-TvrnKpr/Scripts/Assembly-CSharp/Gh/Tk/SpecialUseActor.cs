namespace Gh.Tk
{
	public class SpecialUseActor : Actor
	{
		[PersistenceOptIn]
		private SpecialUseActorData _actorData;

		public override void SetData(ActorData actorData)
		{
		}

		public override void RestoreState(IDataStore data)
		{
		}

		public override void Init()
		{
		}
	}
}
