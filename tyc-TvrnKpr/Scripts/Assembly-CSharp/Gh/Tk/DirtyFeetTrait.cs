namespace Gh.Tk
{
	public class DirtyFeetTrait : ActorTrait
	{
		[PersistenceOptIn]
		private float _currentDirtiness;

		[PersistenceOptIn]
		private int _displayPercentage;

		[PersistenceOptIn]
		private bool _isInside;

		[PersistenceOptIn]
		private IRng _rng;

		private const float _chancePerSecond = 0.6f;

		private float CurrentDirtiness
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		private int DisplayPercentage
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		private IRng rng => null;

		protected DirtyFeetTrait()
		{
		}

		public DirtyFeetTrait(Actor owner)
		{
		}

		public override bool ShouldAutoAddTo(GameObjectX gox)
		{
			return false;
		}

		private void SetActive()
		{
		}

		private void SetInactive()
		{
		}

		public bool IsDirty()
		{
			return false;
		}

		private void UpdateWhileOutside()
		{
		}

		private void IncreaseDirtiness(float factor)
		{
		}

		private void DecreaseDirtiness(float value)
		{
		}

		private void UpdateWhileInside(TileData tile)
		{
		}

		public override void Update()
		{
		}

		protected override string GetTooltipTextKey()
		{
			return null;
		}

		public void ModifyDirtiness(float factor)
		{
		}
	}
}
