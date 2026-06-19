public class NodeParameters
{
	public double position;

	public double length;

	public Spline spline;

	public float PosInSpline => (float)position;

	public float Length => (float)length;

	public NodeParameters(Spline spline, float position, float length)
	{
		this.position = position;
		this.length = length;
		this.spline = spline;
	}

	public void Reset()
	{
		position = 0.0;
		length = 0.0;
	}
}
