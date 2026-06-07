using System;
using System.Collections.Generic;
using Data.Shapes;
using Newtonsoft.Json;
using SaveData.FactoryFloor.SaveStates;

namespace SaveData.FactoryFloor
{
	[Serializable]
	public class ExoportBehaviourSaveStateDto : BehaviourSaveStateDto
	{
		public int[] CollectedResourceIDs;

		public string[] CollectedShapeResourceHashes;

		public ExoportBehaviourSaveStateDto(int[] collectedResourceIDs, IReadOnlyCollection<ShapeHashPair> collectedShapeResourceHashes)
		{
			CollectedResourceIDs = collectedResourceIDs;
			CollectedShapeResourceHashes = new string[collectedShapeResourceHashes.Count];
			int num = 0;
			foreach (ShapeHashPair collectedShapeResourceHash in collectedShapeResourceHashes)
			{
				CollectedShapeResourceHashes[num] = collectedShapeResourceHash.ToString();
				num++;
			}
		}

		[JsonConstructor]
		public ExoportBehaviourSaveStateDto(int[] collectedResourceIDs, string[] collectedShapeResourceHashes)
		{
			CollectedResourceIDs = collectedResourceIDs;
			CollectedShapeResourceHashes = collectedShapeResourceHashes;
		}
	}
}
