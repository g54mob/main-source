using Unity.Collections;
using Unity.Entities;
using Unity.NetCode;
using Unity.Physics;

namespace PlayerState
{
	public struct ChangePlayerStateShared
	{
		public PugDatabase.DatabaseBankCD databaseBankCD;

		public ConditionsTableCD conditionsTableCD;

		public NetworkTick currentTick;

		public uint tickRate;

		public TileAccessor tileAccessor;

		[ReadOnly]
		public PhysicsWorld physicsWorld;

		[ReadOnly]
		public PhysicsWorldHistorySingleton physicsWorldHistory;

		public EntityCommandBuffer ecb;

		public bool isFinalFullPredictionTick;

		public bool isPartialTick;
	}
}
