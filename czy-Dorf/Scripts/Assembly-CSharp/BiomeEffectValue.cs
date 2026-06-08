using System;
using System.Collections.Generic;

[Serializable]
public class BiomeEffectValue
{
	public string key;

	public object value;

	public List<int> rendererIndices = new List<int>();

	public BiomeEffectValue(string key, object value)
	{
		this.key = key;
		this.value = value;
	}

	public BiomeEffectValue(string key, object value, List<int> rendererIndices)
	{
		this.key = key;
		this.value = value;
		this.rendererIndices = rendererIndices;
	}
}
