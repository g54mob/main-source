using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class LevelSettingsSO : ScriptableObject
{
	[Serializable]
	public class ObjectOnLevel
	{
		public ObjectSO objectSO;

		public int maxQuantity;

		public int scoreToUnlock;
	}

	public int scoreMax;

	public List<ObjectOnLevel> objectsOnLevel;
}
