using System.Collections.Generic;
using NSEipix;
using NSEipix.Base;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using UnityEngine;

namespace NSMedieval
{
	public class DebugNodeUpdatesVisualizer : MonoSingleton<DebugNodeUpdatesVisualizer>
	{
		private Dictionary<Vector3, float> updatedNodes = new Dictionary<Vector3, float>();

		private const float VisualTime = 0.5f;

		public void OnDrawGizmos()
		{
			foreach (Vector3 key in updatedNodes.Keys)
			{
				Gizmos.color = Color.red;
				Gizmos.DrawSphere(key, 0.2f);
			}
			updatedNodes.RemoveAll((KeyValuePair<Vector3, float> pair) => pair.Value < Time.time);
		}

		private void NotifyAboutUpdate(MapNode updatedNode)
		{
			Vector3 worldPosition = updatedNode.WorldPosition;
			if (updatedNodes.ContainsKey(worldPosition))
			{
				updatedNodes[worldPosition] = Time.time + 0.5f;
			}
			else
			{
				updatedNodes.Add(worldPosition, Time.time + 0.5f);
			}
		}

		private void OnEnable()
		{
			MapNode[] gridSpaceData = VillageManager.ActiveVillage.Map.GridSpaceData;
			for (int i = 0; i < gridSpaceData.Length; i++)
			{
				gridSpaceData[i].OnMapNodeUpdatedEvent += NotifyAboutUpdate;
			}
		}

		private void OnDisable()
		{
			MapNode[] gridSpaceData = VillageManager.ActiveVillage.Map.GridSpaceData;
			for (int i = 0; i < gridSpaceData.Length; i++)
			{
				gridSpaceData[i].OnMapNodeUpdatedEvent -= NotifyAboutUpdate;
			}
		}
	}
}
