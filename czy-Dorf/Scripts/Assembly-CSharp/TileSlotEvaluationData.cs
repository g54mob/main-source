using System;

[Serializable]
public class TileSlotEvaluationData
{
	public float score;

	public int perfectEdges;

	public int emptyEdges;

	public float questValue;

	public int questsFulfilled;

	public int questsFailed;

	public TileSlot tileSlot;

	public int rotation;
}
