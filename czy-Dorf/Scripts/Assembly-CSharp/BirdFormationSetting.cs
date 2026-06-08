using System;

[Serializable]
public class BirdFormationSetting : IWeightedRandomizable
{
	public BirdFormation formation;

	public float probability;

	public float Probability => probability;
}
