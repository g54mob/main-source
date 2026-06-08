using System;

[Serializable]
public class ArgsRename : Args
{
	public string @object;

	public string value;

	public ArgsRename(string objectId, string value)
	{
		@object = objectId;
		this.value = value;
	}
}
