using System;

internal struct dYYJxlUxNJicubyXxoDOlMElKaa : IEquatable<dYYJxlUxNJicubyXxoDOlMElKaa>
{
	public static readonly dYYJxlUxNJicubyXxoDOlMElKaa dxogOPZTjJkMCZRqwHORwFHluia = new dYYJxlUxNJicubyXxoDOlMElKaa(0f, 0f);

	public static readonly dYYJxlUxNJicubyXxoDOlMElKaa SJrQUGUtdqpchWfNvrmkSxmfMhd = dxogOPZTjJkMCZRqwHORwFHluia;

	public float QIDJORADMNDkZNLUlhSScEskOfQ;

	public float apBqzPMqEBuPCuPyDzYnqmgbHni;

	public dYYJxlUxNJicubyXxoDOlMElKaa(float width, float height)
	{
		QIDJORADMNDkZNLUlhSScEskOfQ = width;
		apBqzPMqEBuPCuPyDzYnqmgbHni = height;
	}

	public bool Equals(dYYJxlUxNJicubyXxoDOlMElKaa other)
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
		if ((object)obj.GetType() != typeof(dYYJxlUxNJicubyXxoDOlMElKaa))
		{
			return false;
		}
		return Equals((dYYJxlUxNJicubyXxoDOlMElKaa)obj);
	}

	public override int GetHashCode()
	{
		return (QIDJORADMNDkZNLUlhSScEskOfQ.GetHashCode() * 397) ^ apBqzPMqEBuPCuPyDzYnqmgbHni.GetHashCode();
	}

	public static bool operator ==(dYYJxlUxNJicubyXxoDOlMElKaa left, dYYJxlUxNJicubyXxoDOlMElKaa right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(dYYJxlUxNJicubyXxoDOlMElKaa left, dYYJxlUxNJicubyXxoDOlMElKaa right)
	{
		return !left.Equals(right);
	}

	public override string ToString()
	{
		return $"({QIDJORADMNDkZNLUlhSScEskOfQ},{apBqzPMqEBuPCuPyDzYnqmgbHni})";
	}
}
