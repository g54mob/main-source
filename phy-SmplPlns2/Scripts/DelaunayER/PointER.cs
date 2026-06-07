public class PointER
{
	public float x;

	public float y;

	public float z;

	public PointER(float x, float y, float z)
	{
		this.x = x;
		this.y = y;
		this.z = z;
	}

	public override int GetHashCode()
	{
		int hashCode = x.ToString().GetHashCode();
		int hashCode2 = y.ToString().GetHashCode();
		int hashCode3 = z.ToString().GetHashCode();
		return hashCode ^ hashCode2 ^ hashCode3;
	}

	public override bool Equals(object obj)
	{
		return this == (PointER)obj;
	}

	public static bool operator ==(PointER left, PointER right)
	{
		if ((object)left == right)
		{
			return true;
		}
		if ((object)left == null || (object)right == null)
		{
			return false;
		}
		if (left.x != right.x)
		{
			return false;
		}
		if (left.y != right.y)
		{
			return false;
		}
		return true;
	}

	public static bool operator !=(PointER left, PointER right)
	{
		return !(left == right);
	}
}
