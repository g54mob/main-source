using System;

[Serializable]
public class ErrorMessage : JsonSerializable
{
	public string message;

	public ErrorDetails details;
}
