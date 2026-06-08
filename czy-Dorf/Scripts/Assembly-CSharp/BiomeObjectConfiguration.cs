using System.Collections.Generic;

public class BiomeObjectConfiguration
{
	public ElementVisual visual;

	public Dictionary<string, object> biomeValues = new Dictionary<string, object>();

	public List<BiomeEffectValue> biomeEffectValues = new List<BiomeEffectValue>();

	public Dictionary<Biome, float> biomeInfluence = new Dictionary<Biome, float>();

	public BiomeObjectConfiguration()
	{
	}

	public BiomeObjectConfiguration(BiomeObjectConfiguration configurationToCopy)
	{
		biomeValues = new Dictionary<string, object>(configurationToCopy.biomeValues);
		biomeEffectValues = new List<BiomeEffectValue>(configurationToCopy.biomeEffectValues);
		visual = configurationToCopy.visual;
	}

	public T GetEffectValue<T>(string targetKey)
	{
		foreach (BiomeEffectValue biomeEffectValue in biomeEffectValues)
		{
			if (biomeEffectValue.key == targetKey)
			{
				return (T)biomeEffectValue.value;
			}
		}
		return default(T);
	}

	public void Clear()
	{
		visual = null;
		biomeValues.Clear();
		biomeEffectValues.Clear();
	}
}
