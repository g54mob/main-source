using UnityEngine;

[CreateAssetMenu(fileName = "SimpleSiege/BalancingParameters", menuName = "BalancingParameters")]
public class BalancingParameters : ScriptableObject
{
	public StringFloatSerializableDictionary parameters = new StringFloatSerializableDictionary();
}
