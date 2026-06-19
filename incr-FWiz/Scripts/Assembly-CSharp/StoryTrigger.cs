using UnityEngine;

public abstract class StoryTrigger : MonoBehaviour
{
	public const int StoryTriggerCallOnLoadOrder = 100;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	public void TryStartListening()
	{
	}

	public abstract void StartListening();

	public abstract void StopListening();
}
