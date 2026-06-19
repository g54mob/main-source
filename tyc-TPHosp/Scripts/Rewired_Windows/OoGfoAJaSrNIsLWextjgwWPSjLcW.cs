using System;

internal struct OoGfoAJaSrNIsLWextjgwWPSjLcW : IEquatable<OoGfoAJaSrNIsLWextjgwWPSjLcW>
{
	public static readonly OoGfoAJaSrNIsLWextjgwWPSjLcW dxogOPZTjJkMCZRqwHORwFHluia = new OoGfoAJaSrNIsLWextjgwWPSjLcW(0, 0);

	public static readonly OoGfoAJaSrNIsLWextjgwWPSjLcW SJrQUGUtdqpchWfNvrmkSxmfMhd = dxogOPZTjJkMCZRqwHORwFHluia;

	public int QIDJORADMNDkZNLUlhSScEskOfQ;

	public int apBqzPMqEBuPCuPyDzYnqmgbHni;

	public OoGfoAJaSrNIsLWextjgwWPSjLcW(int width, int height)
	{
		QIDJORADMNDkZNLUlhSScEskOfQ = width;
		apBqzPMqEBuPCuPyDzYnqmgbHni = height;
	}

	public bool Equals(OoGfoAJaSrNIsLWextjgwWPSjLcW other)
	{
		if (other.QIDJORADMNDkZNLUlhSScEskOfQ == QIDJORADMNDkZNLUlhSScEskOfQ)
		{
			return other.apBqzPMqEBuPCuPyDzYnqmgbHni == apBqzPMqEBuPCuPyDzYnqmgbHni;
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (object.ReferenceEquals(null, obj))
		{
			return false;
		}
		if ((object)obj.GetType() != typeof(OoGfoAJaSrNIsLWextjgwWPSjLcW))
		{
			return false;
		}
		return Equals((OoGfoAJaSrNIsLWextjgwWPSjLcW)obj);
	}

	public override int GetHashCode()
	{
		return (QIDJORADMNDkZNLUlhSScEskOfQ * 397) ^ apBqzPMqEBuPCuPyDzYnqmgbHni;
	}

	public static bool operator ==(OoGfoAJaSrNIsLWextjgwWPSjLcW left, OoGfoAJaSrNIsLWextjgwWPSjLcW right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(OoGfoAJaSrNIsLWextjgwWPSjLcW left, OoGfoAJaSrNIsLWextjgwWPSjLcW right)
	{
		return !left.Equals(right);
	}

	public override string ToString()
	{
		return $"({QIDJORADMNDkZNLUlhSScEskOfQ},{apBqzPMqEBuPCuPyDzYnqmgbHni})";
	}
}
