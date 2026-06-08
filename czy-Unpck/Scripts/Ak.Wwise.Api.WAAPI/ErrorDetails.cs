using System;

[Serializable]
public class ErrorDetails : JsonSerializable
{
	public string[] reasons;

	public string procedureUri;
}
