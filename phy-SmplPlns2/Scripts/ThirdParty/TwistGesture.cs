public class TwistGesture : ContinuousGesture
{
	public float DeltaRotation { get; internal set; }

	public float TotalRotation { get; internal set; }

	public FingerGestures.Finger Pivot { get; internal set; }
}
