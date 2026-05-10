using UnityEngine;

[CreateAssetMenu]
public class SecurityGuardBehaviourData : ScriptableObject
{
	[Range(0f, 3f)]
	public int SpeedLevel;
}
