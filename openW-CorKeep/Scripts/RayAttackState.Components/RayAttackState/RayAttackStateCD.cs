using Unity.Entities;
using Unity.NetCode;

namespace RayAttackState
{
	public struct RayAttackStateCD : IComponentData, IQueryTypeParameter
	{
		public enum State
		{
			Initializing = 0,
			Intro = 1,
			Active = 2,
			Ending = 3
		}

		[GhostField]
		public float startRadianAngle;

		[GhostField]
		public State state;

		[GhostField]
		public TickTimer stateTimer;

		public bool randomInitialAngle;

		public float rotateRadiansPerSecond;

		public float rayLength;

		public float offsetFromCenter;

		public int damage;

		public float attackTimeSeconds;

		public float rayRadius;

		public float expandTime;

		public float shrinkTime;

		public float introTimeSeconds;

		public float activeTimeSeconds;

		public float endingTimeSeconds;

		public bool isRanged;

		public bool isMagic;

		public TickTimer attackTimer;
	}
}
