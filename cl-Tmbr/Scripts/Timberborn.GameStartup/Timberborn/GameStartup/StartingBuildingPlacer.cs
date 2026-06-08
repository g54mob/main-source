using System;
using Timberborn.BaseComponentSystem;
using Timberborn.BlockObjectTools;
using Timberborn.BlockSystem;
using Timberborn.Coordinates;
using Timberborn.SingletonSystem;
using Timberborn.ToolSystemUI;

namespace Timberborn.GameStartup
{
	internal class StartingBuildingPlacer : IBlockObjectPlacer
	{
		private readonly EventBus _eventBus;

		public StartingBuildingPlacer(EventBus eventBus)
		{
			_eventBus = eventBus;
		}

		public void Place(BlockObjectSpec template, Placement placement, Action<BaseComponent> placedCallback)
		{
			_eventBus.Post(new StartingBuildingPlacedEvent(placement));
		}

		public void Describe(BlockObjectTool tool, ToolDescription.Builder builder, Preview preview)
		{
		}

		public bool CanHandle(BlockObjectSpec template)
		{
			return true;
		}
	}
}
