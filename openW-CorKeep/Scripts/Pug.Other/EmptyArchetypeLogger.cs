using UnityEngine;

public class EmptyArchetypeLogger : MonoBehaviour
{
	public enum WorldType
	{
		ServerWorld = 0,
		ClientWorld = 1,
		DefaultWorld = 2
	}

	public WorldType world;

	public bool includePrefabArchetypes;

	public bool printMatchingArchetypes;
}
