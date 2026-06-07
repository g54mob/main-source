using UnityEngine;

public interface IDebugMapDataProvider
{
	DebugMapDataProviderType Type { get; }

	Vector2 Position { get; }

	GameObject ReturnDebugVisual(DebugMap debugMap);
}
