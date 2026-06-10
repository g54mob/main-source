using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.Map;
using UnityEngine;

namespace NSMedieval.Village.Map
{
	public class MapNodeDebugManager : MonoSingleton<MapNodeDebugManager>
	{
		private bool isShown;

		private bool showAirNodes;

		private List<GameObject> nodeDebugObjects;

		public void Show(bool showAirNodes)
		{
			if (!isShown)
			{
				this.showAirNodes = showAirNodes;
				isShown = true;
				VisualDebugManager visualDebugManager = MonoSingleton<VisualDebugManager>.Instance;
				visualDebugManager.HideForType(VisualDebugType.GridNode);
				visualDebugManager.EnableType(VisualDebugType.GridNode);
				ShowGridNodes();
			}
		}

		public void Hide()
		{
			if (isShown)
			{
				isShown = false;
				nodeDebugObjects.Clear();
				MonoSingleton<VisualDebugManager>.Instance.HideForType(VisualDebugType.GridNode);
			}
		}

		private void ShowGridNodes(int level = -1)
		{
			VisualDebugManager visualDebugManager = MonoSingleton<VisualDebugManager>.Instance;
			if ((visualDebugManager.EnabledType & VisualDebugType.GridNode) == 0)
			{
				return;
			}
			VillageMap map = VillageManager.ActiveVillage.Map;
			MapNode[] gridSpaceData = map.GridSpaceData;
			if (nodeDebugObjects == null)
			{
				nodeDebugObjects = new List<GameObject>(gridSpaceData.Length);
			}
			if (nodeDebugObjects.Count == 0)
			{
				for (int i = 0; i < gridSpaceData.Length; i++)
				{
					nodeDebugObjects.Add(null);
				}
			}
			if (level < 0)
			{
				level = MonoSingleton<World>.Instance.ElevationLevel;
			}
			Vector3 scale = new Vector3(0.1f, 0.2f, 0.1f);
			for (int j = 0; j < gridSpaceData.Length; j++)
			{
				GameObject gameObject = null;
				MapNode mapNode = gridSpaceData[j];
				if (j < nodeDebugObjects.Count)
				{
					gameObject = nodeDebugObjects[j];
				}
				bool flag = false;
				if (!mapNode.IsWalkable && !showAirNodes && mapNode.Position.y != level)
				{
					flag = map.GetNode(mapNode.Position + Vec3Int.down)?.IsVoxelAir() ?? true;
				}
				flag |= mapNode.Position.y > level;
				if (!flag && !mapNode.IsWalkable && mapNode.Position.y != level)
				{
					bool flag2 = !(map.GetNode(mapNode.Position + Vec3Int.down)?.IsVoxelAir() ?? true);
					bool flag3 = !(map.GetNode(mapNode.Position + Vec3Int.up)?.IsVoxelAir() ?? true);
					if (flag2 && flag3)
					{
						flag = true;
					}
				}
				if (flag)
				{
					if (gameObject != null)
					{
						gameObject.SetActive(value: false);
					}
					continue;
				}
				Color color = (mapNode.IsWalkable ? Color.cyan : Color.red);
				if (gameObject == null)
				{
					gameObject = visualDebugManager.DrawRectFromCenter(VisualDebugType.GridNode, "tag", mapNode.WorldPosition, scale, color);
					nodeDebugObjects[j] = gameObject;
				}
				else
				{
					gameObject.SetActive(value: true);
					gameObject.GetComponent<Renderer>().material.color = color;
				}
			}
		}

		private void OnLayerChanged(float currentLevel, int maxLevel)
		{
			int num = Mathf.FloorToInt(currentLevel);
			int num2 = Mathf.CeilToInt(currentLevel);
			if (num == num2)
			{
				ShowGridNodes(num);
			}
		}

		private void Start()
		{
			MonoSingleton<World>.Instance.LayerChangeEvent += OnLayerChanged;
		}
	}
}
