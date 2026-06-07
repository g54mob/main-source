using PajamaLlama.Flotsam.Narrative;
using PajamaLlama.Flotsam.World;
using UnityEngine;

public interface IRegion
{
	WorldRegionType Type { get; }

	PollutionLevels PollutionLevel { get; }

	Rect Bounds { get; }

	ScenarioTriggerableBase EnterTriggerable => null;

	float ReturnSurface();

	float ReturnOverlap(Polygon2DBase polygon);

	bool ReturnContainsPosition(Vector2 position);

	Vector2 ReturnPositionInRegion();
}
