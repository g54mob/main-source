using System;
using System.Collections.Generic;

[Serializable]
public class TilePresetConfigurationSubCollection : IWeightedRandomizable
{
	public string name;

	public float subCollectionRawProbability = 10f;

	public float subCollectionProbability;

	public float _displayProbability;

	public List<TilePresetConfiguration> tilePresets;

	public float Probability => subCollectionRawProbability;
}
