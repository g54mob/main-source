using Commands;
using Data.FactoryFloor.Maps;
using Events;
using Events.Generic;
using Logic.FactoryTools.IslandEditor;
using UnityEngine;

namespace Logic.FactoryTools.MapEditor
{
	[CreateAssetMenu(menuName = "Factory/Tools/Map/DeleteMapEditorTool", fileName = "DeleteMapEditorTool", order = 0)]
	public class DeleteMapEditorTool : MapEditorTool
	{
		[Header("Placement refs")]
		[SerializeField]
		private CommandManager _commandManager;

		[SerializeField]
		private IntEvent _deleteIslandEvent;

		[SerializeField]
		private IslandLayer _islandLayer;

		[SerializeField]
		private BaseEvent _generateGrass;

		public override void SelectTool(EmptyIslandEditorData emptyIslandEditorData = null)
		{
			base.SelectTool(emptyIslandEditorData);
		}

		public override void UpdateTool(Vector3Int position)
		{
		}

		public override void OnActionIntent(Vector3Int position)
		{
		}

		public override void DoAction(Vector3Int position)
		{
			if (!_islandLayer.CanPlaceIsland(position))
			{
				IslandObject islandAtGridPosition = _islandLayer.GetIslandAtGridPosition(position);
				_deleteIslandEvent.Fire(islandAtGridPosition.CreatedId);
				_islandLayer.RemoveIslandAtGridPosition(position);
				_generateGrass.Fire();
			}
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
	}
}
