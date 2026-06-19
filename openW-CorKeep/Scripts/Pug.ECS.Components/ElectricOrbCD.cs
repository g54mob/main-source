using Unity.Entities;

public struct ElectricOrbCD : IComponentData, IQueryTypeParameter
{
	public enum State
	{
		Uninitialized = 0,
		Starting = 1,
		Active = 2,
		Ending = 3,
		Ended = 4
	}

	public float startDuration;

	public float loopDuration;

	public float endDuration;

	public float hiddenEndDuration;

	public State state;

	public TickTimer stateTimer;

	public int movementPatternIndex;

	public TickTimer movementPatternTimer;

	public BlobAssetReference<BlobArray<ElectricOrbMovementPatternBlob>> movementPatterns;

	public int patternSign;

	public bool bounceOnWalls;

	public float speed;

	public float VisibleFullDuration => startDuration + loopDuration + endDuration;
}
