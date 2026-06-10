using System;

[Serializable]
public class DDSBundle
{
	public string displayName;

	public string description;

	public string languageCode;

	[NonSerialized]
	public string path;
}
