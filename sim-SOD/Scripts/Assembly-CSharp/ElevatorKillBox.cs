using UnityEngine;

public class ElevatorKillBox : MonoBehaviour
{
	public enum CrushType
	{
		whenElevatorMovesDown = 0,
		whenElevatorMovesUp = 1,
		either = 2
	}

	public Elevator elevator;

	public CrushType crushType;

	private void OnTriggerEnter(Collider other)
	{
	}
}
