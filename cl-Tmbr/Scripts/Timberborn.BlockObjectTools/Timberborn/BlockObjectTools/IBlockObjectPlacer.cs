using System;
using Timberborn.BaseComponentSystem;
using Timberborn.BlockSystem;
using Timberborn.Coordinates;
using Timberborn.ToolSystemUI;

namespace Timberborn.BlockObjectTools
{
	public interface IBlockObjectPlacer
	{
		void Place(BlockObjectSpec template, Placement placement, Action<BaseComponent> placedCallback);

		void Describe(BlockObjectTool tool, ToolDescription.Builder builder, Preview preview);

		bool CanHandle(BlockObjectSpec template);
	}
}
