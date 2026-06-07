using System.Collections.Generic;
using Data.FactoryFloor;
using Data.FactoryFloor.Maps;
using UnityEngine;

public class IslandDebugger : MonoBehaviour
{
	[SerializeField]
	private IslandLayer _islandLayer;

	[SerializeField]
	private FactoryLayer _factoryLayer;

	[SerializeField]
	private bool _showGizmos;

	[SerializeField]
	private int _fontSize = 40;

	private void OnDrawGizmos()
	{
		if (!Application.isPlaying || !_showGizmos)
		{
			return;
		}
		List<IslandObject> allIslands = _islandLayer.GetAllIslands();
		if (allIslands.Count >= 1)
		{
			for (int i = 0; i < allIslands.Count; i++)
			{
				IslandObject islandObject = allIslands[i];
				Vector3 vector = islandObject.IslandConfig.Position;
				Vector3 size = new Vector3(islandObject.IslandConfig.Size.x, 2f, islandObject.IslandConfig.Size.y);
				Gizmos.color = new Color(0f, 0.4f, 1f, 0.3f);
				Gizmos.DrawCube(vector, size);
				Gizmos.color = Color.Lerp(Color.green, new Color(0.7f, 0f, 0.2f, 1f), (float)i / (float)allIslands.Count);
				Gizmos.DrawWireSphere(vector, 4f);
				Gizmos.DrawLine(vector, vector + Vector3.up * 50f);
			}
		}
	}
}
