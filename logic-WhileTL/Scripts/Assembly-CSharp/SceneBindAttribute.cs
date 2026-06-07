using System;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
public class SceneBindAttribute : Attribute
{
	public string Path { get; private set; }

	public bool CreateIfNotExist { get; private set; }

	public bool ForceToGlobalSearch { get; private set; }

	public Type Type { get; private set; }

	public SceneBindAttribute(Type type)
	{
		Type = type;
	}

	public SceneBindAttribute()
	{
		CreateIfNotExist = true;
	}

	public SceneBindAttribute(bool createIfNotExist)
	{
		CreateIfNotExist = createIfNotExist;
	}

	public SceneBindAttribute(string path)
	{
		Path = path;
	}

	public SceneBindAttribute(string path, bool createIfNotExist)
	{
		Path = path;
		CreateIfNotExist = createIfNotExist;
	}

	public SceneBindAttribute(string path, bool createIfNotExist, bool forceToGlobalSearch)
	{
		Path = path;
		CreateIfNotExist = createIfNotExist;
		ForceToGlobalSearch = forceToGlobalSearch;
	}
}
