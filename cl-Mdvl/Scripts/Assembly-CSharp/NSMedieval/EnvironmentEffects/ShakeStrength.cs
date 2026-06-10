namespace NSMedieval.EnvironmentEffects
{
	public struct ShakeStrength
	{
		public float MaxCameraDistance;

		public float MinCameraDistance;

		public float MaxCameraShakeDuration;

		public float MaxCameraShake;

		public ShakeStrength(float maxCameraDistance, float minCameraDistance, float maxCameraShakeDuration, float maxCameraShake)
		{
			MaxCameraDistance = maxCameraDistance;
			MinCameraDistance = minCameraDistance;
			MaxCameraShakeDuration = maxCameraShakeDuration;
			MaxCameraShake = maxCameraShake;
		}
	}
}
