namespace Gh.Tk
{
	public class OnFireTrait : GameObjectXTrait, IProgressTrait
	{
		private bool _isBigFire;

		public bool IsBigFire
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public float ProgressPercentage { get; private set; }

		protected OnFireTrait()
		{
		}

		private void UpdateDamage()
		{
		}

		public OnFireTrait(GameObjectX owner)
		{
		}

		public override void FirstInit()
		{
		}

		public override void OnRemoving()
		{
		}

		private static float GetDamagePerSecond(Flammability flammability)
		{
			return 0f;
		}

		public override bool ShouldAutoAddTo(GameObjectX gox)
		{
			return false;
		}

		public override void Update()
		{
		}
	}
}
