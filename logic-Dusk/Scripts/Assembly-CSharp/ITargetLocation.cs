using UnityEngine;

public interface ITargetLocation
{
	Vector3 Position { get; }

	Room CurrentRoom { get; set; }

	Corridor CurrentCorridor { get; set; }
}
