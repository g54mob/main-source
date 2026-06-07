using System;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
public class JsonSerializableAttribute : Attribute
{
	public enum MergeStrategy
	{
		Max = 0,
		Min = 1,
		Latest = 2
	}

	public string serializedName;

	public MergeStrategy mergeStrategy;

	public JsonSerializableAttribute(string name, MergeStrategy strategy)
	{
		serializedName = name;
		mergeStrategy = strategy;
	}
}
