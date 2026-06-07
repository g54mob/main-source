using System;

namespace Gh.Tk
{
	public class DamageStat : PropStat
	{
		public static float BrokenAt;

		public EventHandler<EventArgs<bool>> IsBrokenChanged;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		private bool _isBroken;

		public override float Value
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public bool IsBroken
		{
			get
			{
				return false;
			}
			private set
			{
			}
		}

		protected DamageStat()
		{
		}

		public DamageStat(Prop owner)
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
