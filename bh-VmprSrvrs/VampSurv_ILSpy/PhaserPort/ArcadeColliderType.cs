using UnityEngine;

public interface ArcadeColliderType
{
	bool isParent { get; }

	BaseBody body { get; }

	bool isTilemap { get; }

	GameObject gameObject { get; }
}
