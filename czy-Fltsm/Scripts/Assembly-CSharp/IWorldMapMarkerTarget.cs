using UnityEngine;

public interface IWorldMapMarkerTarget
{
	Sprite Icon { get; }

	Vector3 LocalPosition { get; }
}
