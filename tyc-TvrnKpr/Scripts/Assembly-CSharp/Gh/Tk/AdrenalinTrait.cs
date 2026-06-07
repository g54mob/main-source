namespace Gh.Tk
{
	public class AdrenalinTrait : ActorTrait
	{
		[PersistenceOptIn]
		private float _startTime;

		private const float _gainPerHour = 50f;

		protected AdrenalinTrait()
		{
		}

		public AdrenalinTrait(Actor owner)
		{
		}

		public override void Init()
		{
		}

		private string GetModifierKey()
		{
			return null;
		}

		public override void OnRemoving()
		{
		}
	}
}
