using Unity.Profiling;

public class CircleSpecificCollider : Collider
{
	private PhysicsGroup group1;

	private PhysicsGroup group2;

	private static readonly ProfilerMarker s_circleColliderMarker;

	private static readonly ProfilerMarker s_circleOverlapMarker;

	private static readonly ProfilerMarker s_circleVelocityMarker;

	private static readonly ProfilerMarker s_circlePositionMarker;

	public CircleSpecificCollider(World world, bool overlapOnly, ArcadeColliderType object1, ArcadeColliderType object2, ArcadePhysicsCallback collideCallback = null, ArcadePhysicsCallback processCallback = null, CallbackContext callbackContext = null)
		: base(null, overlapOnly: false, null, null, null, null, null)
	{
	}

	public override void update()
	{
	}

	private static void ComputeSeparations(BaseBody body1, BaseBody body2)
	{
	}
}
