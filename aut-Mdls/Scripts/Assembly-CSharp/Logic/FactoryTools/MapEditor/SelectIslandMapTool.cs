using Data.FactoryFloor.Maps;
using Events.FactoryFloor.Islands;
using Logic.FactoryTools.IslandEditor;
using UnityEngine;

namespace Logic.FactoryTools.MapEditor
{
	[CreateAssetMenu(menuName = "Factory/Tools/Map/SelectIslandMapTool", fileName = "SelectIslandMapTool", order = 0)]
	public class SelectIslandMapTool : MapEditorTool
	{
		[Space]
		[SerializeField]
		private IslandLayer _islandLayer;

		[SerializeField]
		private IslandObjectEvent _mapEditorSelectIslandObjectEvent;

		public override void UpdateTool(Vector3Int position)
		{
		}

		public override void OnActionIntent(Vector3Int position)
		{
		}

		public override void CancelAction()
		{
		}

		public override void Rotate(int angle)
		{
		}

		public override void Mirror()
		{
		}

		public override void DoAction(Vector3Int position)
		{
			if (_islandLayer.TryGetIslandAtGridPosition(position, out var islandObject))
			{
				_mapEditorSelectIslandObjectEvent.Fire(islandObject);
			}
		}
	}
}
