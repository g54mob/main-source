namespace Gh.Tk
{
	public class InSandstormTrait : ActorTrait
	{
		[PersistenceOptIn]
		private bool _isAnimationStateSet;

		protected InSandstormTrait()
		{
		}

		public InSandstormTrait(Actor owner)
		{
		}

		public override void Init()
		{
		}

		public override void OnRemoving()
		{
		}

		private void SetActive(bool active)
		{
		}
	}
}
