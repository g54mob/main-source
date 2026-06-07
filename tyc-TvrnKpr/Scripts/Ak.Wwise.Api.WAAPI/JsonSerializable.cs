using System;

[Serializable]
public class JsonSerializable
{
	public static implicit operator string(JsonSerializable o)
	{
		return null;
	}
}
