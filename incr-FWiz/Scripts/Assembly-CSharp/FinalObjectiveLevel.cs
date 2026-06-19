using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class FinalObjectiveLevel
{
	public MapBarrierWall MapBarrier;

	public Checkpoint Checkpoint;

	public List<FinalObjectiveLevelPart> Parts;

	public List<GameObject> ActivateOnUnlock;
}
