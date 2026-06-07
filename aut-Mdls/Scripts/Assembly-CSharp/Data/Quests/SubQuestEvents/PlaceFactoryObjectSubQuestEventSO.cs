using System.Collections.Generic;
using Commands;
using Commands.ToolsCommands;
using Data.FactoryFloor;
using Data.Operator;
using Events.FactoryFloor;
using Events.Generic;
using Logic.Factory;
using Logic.Factory.Blueprint;
using Presentation.Locators;
using UnityEngine;

namespace Data.Quests.SubQuestEvents
{
	[CreateAssetMenu(menuName = "Quests/Events/Place Factory Object", fileName = "PlaceFactoryObject", order = 11)]
	public class PlaceFactoryObjectSubQuestEventSO : AbstractSubQuestEventSO
	{
		[SerializeField]
		private FactoryObjectData _factoryObjectData;

		[SerializeField]
		private Vector3Int _position;

		[SerializeField]
		private int _rotation;

		[SerializeField]
		private CurrentFactoryLayer _factoryLayer;

		[SerializeField]
		private FactoryLayer _terrainLayer;

		[SerializeField]
		private CreateFactoryObjectEvent _createFactoryObjectEvent;

		[SerializeField]
		private GridLocator _gridLocator;

		[SerializeField]
		private IntListEvent _factoryObjectsRemoveViewsEvent;

		[SerializeField]
		private AudioManagerLocator _audioManagerLocator;

		[SerializeField]
		private CommandManager _commandManager;

		public override void Execute()
		{
			BlueprintElement item = new BlueprintElement(_factoryObjectData.RelativePositions, _factoryObjectData, _rotation, mirrored: false);
			List<BlueprintElement> list = new List<BlueprintElement>();
			list.Add(item);
			Blueprint blueprint = new Blueprint(_position, _rotation, list);
			PlaceBlueprintCommand command = new PlaceBlueprintCommand(_factoryLayer.Value, _terrainLayer, _position, _rotation, blueprint, _createFactoryObjectEvent, _gridLocator, _factoryObjectsRemoveViewsEvent, _audioManagerLocator);
			_commandManager.DoCommand(command);
		}
	}
}
