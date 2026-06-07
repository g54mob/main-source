using UnityEngine;

[SerializeField]
public class AIMovePauser
{
	public float duration;

	public int sourceID;

	public bool IsFinished => false;

	public AIMovePauser(float duration, int sourceID)
	{
	}

	public void UpdateTime(float deltaTime)
	{
	}
}
