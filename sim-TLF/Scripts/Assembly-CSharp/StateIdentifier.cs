public class StateIdentifier
{
	public string Name { get; }

	public StateIdentifier(string name)
	{
		Name = name;
	}

	public override bool Equals(object obj)
	{
		if (obj is StateIdentifier stateIdentifier)
		{
			return Name == stateIdentifier.Name;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return Name.GetHashCode();
	}
}
