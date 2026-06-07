public struct InputBinding
{
	public enum Type
	{
		None = 0,
		Button = 1,
		Axis = 2
	}

	public enum Direction
	{
		Positive = 1,
		Negative = -1
	}

	public string name;

	public Direction direction;

	public static InputBinding None;

	public InputBinding(string name, Direction direction)
	{
		this.name = null;
		this.direction = default(Direction);
	}

	public static bool operator ==(InputBinding lhs, InputBinding rhs)
	{
		return false;
	}

	public static bool operator !=(InputBinding lhs, InputBinding rhs)
	{
		return false;
	}

	public override bool Equals(object obj)
	{
		return false;
	}

	public static string NameWithoutDirection(string name)
	{
		return null;
	}

	public static Direction DirectionFromName(string name)
	{
		return default(Direction);
	}
}
