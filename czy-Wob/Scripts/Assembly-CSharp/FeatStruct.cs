public struct FeatStruct
{
	public string featText;

	public ulong? featOwnerUID;

	public FeatStruct(string newText, ulong? newOwner)
	{
		featText = newText;
		featOwnerUID = newOwner;
	}
}
