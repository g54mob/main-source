using NSEipix.Base;
using NSMedieval.Village.Map.Pathfinding;
using UnityEngine;

namespace NSMedieval.Village.Map
{
	public class MapPathDebugManager : MonoSingleton<MapPathDebugManager>
	{
		private const string PathRenderTag = "path_node_tag_";

		private const string NodesListTag = "node_list_tag";

		private const int MaxSimultaneousPaths = 3;

		private bool isShown;

		private int pathsCount;

		public void Show()
		{
			MonoSingleton<VisualDebugManager>.Instance.EnableType(VisualDebugType.Pathfinding);
			pathsCount = 0;
			isShown = true;
		}

		public void Hide()
		{
			MonoSingleton<VisualDebugManager>.Instance.DisableType(VisualDebugType.Pathfinding);
			isShown = false;
		}

		public void DrawPath(Path path)
		{
			if (isShown && path != null && path.State == PathState.Calculated)
			{
				string text = "path_node_tag_";
				if (pathsCount >= 3)
				{
					pathsCount = 0;
				}
				text += pathsCount;
				MonoSingleton<VisualDebugManager>.Instance.HideForTag(text);
				for (int i = 1; i < path.NodePath.Count; i++)
				{
					MapNode mapNode = path.NodePath[i];
					MapNode mapNode2 = path.NodePath[i - 1];
					MonoSingleton<VisualDebugManager>.Instance.DrawLine(VisualDebugType.Pathfinding, text, mapNode2.WorldPosition, mapNode.WorldPosition, Color.blue);
				}
				pathsCount++;
			}
		}
	}
}
