using System.Collections.Generic;

namespace Gh.Tk
{
	public class Sprinkler : GameObjectX
	{
		private List<GameObjectX> _targetGoxInMaxReach;

		private const float MaxReach = 5f;

		[PersistenceOptIn]
		[PersistenceObjectReference]
		public GameObjectX TargetGox { get; set; }

		protected override void UpdateInternal()
		{
		}

		public void SetDiameter(float diameter)
		{
		}

		public void RefreshGoxInReach()
		{
		}

		protected override void LateRestoreStateInternal(IDataStore data)
		{
		}
	}
}
