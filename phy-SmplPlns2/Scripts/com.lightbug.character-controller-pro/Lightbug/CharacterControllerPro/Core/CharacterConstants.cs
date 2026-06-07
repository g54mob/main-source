namespace Lightbug.CharacterControllerPro.Core
{
	public class CharacterConstants
	{
		public const float GroundTriggerOffset = 0.05f;

		public const float MaxUnstableGroundContactTime = 0.25f;

		public const float EdgeRaysSeparation = 0.005f;

		public const float EdgeRaysCastDistance = 2f;

		public const float SkinWidth = 0.005f;

		public const float ColliderMinBottomOffset = 0.1f;

		public const float MinEdgeAngle = 0.5f;

		public const float MaxEdgeAngle = 170f;

		public const float MinStepAngle = 85f;

		public const float MaxStepAngle = 95f;

		public const float GroundCheckDistance = 0.1f;

		public const int MaxSlideIterations = 3;

		public const int MaxPostSimulationSlideIterations = 2;

		public const float DefaultGravity = 9.8f;

		public const float HeadContactMinAngle = 100f;

		public const float WallContactAngleTolerance = 10f;

		public const float GroundPredictionDistance = 40f;
	}
}
