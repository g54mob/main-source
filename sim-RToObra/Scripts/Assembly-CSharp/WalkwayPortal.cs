using UnityEngine;

public class WalkwayPortal : MonoBehaviour
{
	public string fromWalkwayId;

	public string toWalkwayId;

	[WalkwayBuilt]
	public Walkway fromWalkway;

	[WalkwayBuilt]
	public Walkway toWalkway;

	[WalkwayBuilt]
	public Rect worldRect;

	private void OnEnable()
	{
	}

	private void Update()
	{
		if (Walkway.showDebugInGame)
		{
			DebugLiner.CallAndFlush(DrawDebug, false);
		}
	}

	public void DrawDebug(DebugLiner liner)
	{
		if (!(fromWalkway == null))
		{
			liner.color = Color.yellow;
			Vector2 v = new Vector2(worldRect.xMin, worldRect.yMin);
			Vector2 v2 = new Vector2(worldRect.xMax, worldRect.yMin);
			Vector2 v3 = new Vector2(worldRect.xMax, worldRect.yMax);
			Vector2 v4 = new Vector2(worldRect.xMin, worldRect.yMax);
			Vector3 center = worldRect.center.ToVector3XZ(fromWalkway.transform.position.y);
			liner.DrawText(fromWalkwayId + ">" + toWalkwayId, center, 0.07f);
			liner.matrix = fromWalkway.debugBaseMatrix;
			liner.DrawLine(v.ToVector3XZ(0f), v2.ToVector3XZ(0f));
			liner.DrawLine(v2.ToVector3XZ(0f), v3.ToVector3XZ(0f));
			liner.DrawLine(v3.ToVector3XZ(0f), v4.ToVector3XZ(0f));
			liner.DrawLine(v4.ToVector3XZ(0f), v.ToVector3XZ(0f));
		}
	}
}
