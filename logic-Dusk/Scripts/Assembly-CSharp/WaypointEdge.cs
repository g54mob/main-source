public class WaypointEdge
{
	public Waypoint Start { get; private set; }

	public Waypoint Destination { get; private set; }

	public float Weight { get; private set; }

	public WaypointEdge(Waypoint start, Waypoint destination, float weight)
	{
		Start = start;
		Destination = destination;
		Weight = weight;
	}

	public override string ToString()
	{
		return string.Format("[WaypointEdge: Weight={0}, Start={1}, Destination={2}]", Weight, Start, Destination);
	}
}
