using UnityEngine;

[CreateAssetMenu(fileName = "Checkpoint_", menuName = "Project/Checkpoint")]
public class Checkpoint : ScriptableObject, ICheckpoint
{
	public string ID;

	public string CheckpointID => null;

	public void Unlock()
	{
	}

	public bool IsUnlocked()
	{
		return false;
	}
}
