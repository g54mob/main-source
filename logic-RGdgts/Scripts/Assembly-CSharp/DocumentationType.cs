using System;

public struct DocumentationType
{
	public string name;

	public string page;

	public DocumentationType(Data data)
	{
		name = null;
		page = null;
	}

	public DocumentationType(Type type)
	{
		name = null;
		page = null;
	}

	private void Init(Type type)
	{
	}

	public static string GetTypeString(Data data)
	{
		return null;
	}
}
