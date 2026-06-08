using System;
using Timberborn.BaseComponentSystem;
using Timberborn.BlockSystem;
using Timberborn.Coordinates;
using Timberborn.ToolSystemUI;

namespace Timberborn.BlockObjectTools
{
	public class DefaultBlockObjectPlacer : IBlockObjectPlacer
	{
		private readonly BlockObjectFactory _blockObjectFactory;

		public DefaultBlockObjectPlacer(BlockObjectFactory blockObjectFactory)
		{
			_blockObjectFactory = blockObjectFactory;
		}

		public void Place(BlockObjectSpec template, Placement placement, Action<BaseComponent> placedCallback)
		{
			BlockObject obj = _blockObjectFactory.CreateFinished(template, placement);
			placedCallback(obj);
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
