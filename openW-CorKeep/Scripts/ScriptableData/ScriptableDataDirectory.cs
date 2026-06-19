using UnityEngine;

[CreateAssetMenu(fileName = "Scriptable Data Directory", menuName = "Scriptable Data/Additional Data Directory", order = 0)]
public class ScriptableDataDirectory : ScriptableObject
{
	[Tooltip("Data blocks in this directory can overload other data blocks.")]
	public bool enableOverloading;
}
