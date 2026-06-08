using System;
using System.Collections.Generic;

[Serializable]
public class TilePresetConfigurationCollection : IWeightedRandomizable
{
	public string name;

	public float collectionRawProbability = 10f;

	public float collectionProbability;

	public float _displayProbability;

	public List<TilePresetConfiguration> tilePresets;

	public List<TilePresetConfigurationSubCollection> subCollections;

	public float Probability => collectionRawProbability;
}
