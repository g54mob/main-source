using UnityEngine;

public class StoryEventHandlers : MonoBehaviour
{
	public static StoryEventHandlers Instance;

	[SerializeField]
	public PanCamerEventHandler Panning;

	public void Initiate()
	{
	}
}
