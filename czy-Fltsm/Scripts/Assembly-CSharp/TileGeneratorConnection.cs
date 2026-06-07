using System;
using UnityEngine;

public class TileGeneratorConnection : IDebugMapDataProvider
{
	public DebugMapDataProviderType Type => DebugMapDataProviderType.Connection;

	public Vector2 Position
	{
		get
		{
			throw new NotImplementedException();
		}
	}

	public TileGeneratorNode From { get; private set; }

	public TileGeneratorNode To { get; private set; }

	public Vector2 Vector { get; private set; }

	public Vector2 Direction { get; private set; }

	public float Distance { get; private set; }

	public int Tier { get; private set; }

	public Polygon Polygon { get; private set; }

	public TileGeneratorConnection(TileGeneratorNode from, TileGeneratorNode to, int tier)
	{
		From = from;
		To = to;
		Vector = To.Position - from.Position;
		Direction = Vector.normalized;
		Distance = Vector.magnitude;
		Tier = tier;
		Polygon = Polygon.ReturnFromLine(from.Position, to.Position, 500f);
	}

	public GameObject ReturnDebugVisual(DebugMap debugMap)
	{
		DebugMapConnection debugMapConnection = UnityEngine.Object.Instantiate(debugMap.ConnectionPrefab, debugMap.Ocean);
		debugMapConnection.Initialize(this);
		return debugMapConnection.gameObject;
	}
}
