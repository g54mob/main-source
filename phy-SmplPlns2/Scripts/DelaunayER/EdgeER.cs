public class EdgeER
{
	public PointER StartPoint;

	public PointER EndPoint;

	public EdgeER(PointER startPoint, PointER endPoint)
	{
		StartPoint = startPoint;
		EndPoint = endPoint;
	}

	public override int GetHashCode()
	{
		return StartPoint.GetHashCode() ^ EndPoint.GetHashCode();
	}

	public override bool Equals(object obj)
	{
		return this == (EdgeER)obj;
	}

	public static bool operator ==(EdgeER left, EdgeER right)
	{
		if ((object)left == right)
		{
			return true;
		}
		if ((object)left == null || (object)right == null)
		{
			return false;
		}
		return (left.StartPoint == right.StartPoint && left.EndPoint == right.EndPoint) || (left.StartPoint == right.EndPoint && left.EndPoint == right.StartPoint);
	}

	public static bool operator !=(EdgeER left, EdgeER right)
	{
		return left != right;
	}
}
