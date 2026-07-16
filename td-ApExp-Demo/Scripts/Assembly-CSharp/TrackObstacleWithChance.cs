using System;
using UnityEngine;

[Serializable]
public class TrackObstacleWithChance
{
	public GameObject Prefab;

	public int RelativeChance;

	public bool LimitToArt;

	[NonSerialized]
	public Obstacle Obstacle;

	public TrackObstacleWithChance(GameObject p, int c)
	{
		Prefab = p;
		RelativeChance = c;
		Obstacle = Prefab.GetComponent<Obstacle>();
	}
}
