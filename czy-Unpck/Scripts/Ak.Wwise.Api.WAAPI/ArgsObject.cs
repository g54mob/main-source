using System;

[Serializable]
public class ArgsObject : Args
{
	public string @object;

	public ArgsObject(string objectId)
	{
		@object = objectId;
	}
}
