namespace Pug.ECS.Serialization
{
	public enum DeserializationStates
	{
		Invalid = 0,
		SaveFileCorrupt = 1,
		FileNotFound = 2,
		Patching = 3,
		Finished = 4
	}
}
