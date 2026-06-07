namespace FractureField.Rocks
{
	public struct RockLayerHitResult
	{
		public long RockId;

		public RockLayerType StartingLayerType;

		public RockLayerType RockLayerType;

		public RockHitType HitType;

		public float Damage;

		public bool IsCrit;

		public bool IsMegaCrit;

		public bool WasDestroyed;

		public bool DidTransition;

		public float ResourceMultiplier;

		public float ResourceRewardAmount;

		public float DustRewardAmount;

		public float DroneCoresRewardAmount;

		public float CoreFragmentsRewardAmount;
	}
}
