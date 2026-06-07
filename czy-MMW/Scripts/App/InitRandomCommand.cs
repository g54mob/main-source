public class InitRandomCommand : AppCommand
{
	private uint _seed;

	public bool Configure(uint seed)
	{
		_seed = seed;
		return true;
	}

	public override void Reset()
	{
		_seed = 0u;
	}

	public override bool Execute(IApp receiver)
	{
		Random.SetSimulationSeed(_seed, receiver.Scope);
		return true;
	}
}
