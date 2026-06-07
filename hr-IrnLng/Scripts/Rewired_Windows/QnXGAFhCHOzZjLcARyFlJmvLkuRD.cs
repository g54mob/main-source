using System;

internal struct QnXGAFhCHOzZjLcARyFlJmvLkuRD : IEquatable<QnXGAFhCHOzZjLcARyFlJmvLkuRD>
{
	public static readonly QnXGAFhCHOzZjLcARyFlJmvLkuRD mlHwKYEqjUXizzlBBRzwZZoggsm = new QnXGAFhCHOzZjLcARyFlJmvLkuRD(0, 0);

	public int aKhnJLPlzQqMJcsXANqZDKcXdkvk;

	public int CfrGUAcJZiBIgrKhIOoWYteVjgS;

	public QnXGAFhCHOzZjLcARyFlJmvLkuRD(int x, int y)
	{
		aKhnJLPlzQqMJcsXANqZDKcXdkvk = x;
		CfrGUAcJZiBIgrKhIOoWYteVjgS = y;
	}

	public bool Equals(QnXGAFhCHOzZjLcARyFlJmvLkuRD other)
	{
		if (other.aKhnJLPlzQqMJcsXANqZDKcXdkvk == aKhnJLPlzQqMJcsXANqZDKcXdkvk)
		{
			return other.CfrGUAcJZiBIgrKhIOoWYteVjgS == CfrGUAcJZiBIgrKhIOoWYteVjgS;
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (object.ReferenceEquals(null, obj))
		{
			return false;
		}
		if ((object)obj.GetType() != typeof(QnXGAFhCHOzZjLcARyFlJmvLkuRD))
		{
			return false;
		}
		return Equals((QnXGAFhCHOzZjLcARyFlJmvLkuRD)obj);
	}

	public override int GetHashCode()
	{
		return (aKhnJLPlzQqMJcsXANqZDKcXdkvk * 397) ^ CfrGUAcJZiBIgrKhIOoWYteVjgS;
	}

	public static bool operator ==(QnXGAFhCHOzZjLcARyFlJmvLkuRD left, QnXGAFhCHOzZjLcARyFlJmvLkuRD right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(QnXGAFhCHOzZjLcARyFlJmvLkuRD left, QnXGAFhCHOzZjLcARyFlJmvLkuRD right)
	{
		return !left.Equals(right);
	}

	public override string ToString()
	{
		return $"({aKhnJLPlzQqMJcsXANqZDKcXdkvk},{CfrGUAcJZiBIgrKhIOoWYteVjgS})";
	}
}
