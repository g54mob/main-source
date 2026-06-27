using System;

namespace Restory.Gameplay.RandomBallsPoolSystems
{
	[Serializable]
	public class RandomBallsPoolBall<TBallSourceObject>
	{
		public int BallSourceID;

		public TBallSourceObject TargetObject;
	}
}
