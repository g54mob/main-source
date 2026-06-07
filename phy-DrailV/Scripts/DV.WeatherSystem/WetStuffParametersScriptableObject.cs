using UnityEngine;

[CreateAssetMenu(fileName = "WetStuffParameters", menuName = "DV/WetStuff Parameters", order = 1)]
public class WetStuffParametersScriptableObject : ScriptableObject
{
	public float wallWetnessEffect;

	public float aoThreshold;

	public float aoTransition;

	public float aoEffect;

	public float smoothThreshold;

	public float smoothTransition;

	public float smoothEffect;
}
