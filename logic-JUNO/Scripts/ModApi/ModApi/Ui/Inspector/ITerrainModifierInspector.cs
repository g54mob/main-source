using System;
using System.Collections.Generic;
using ModApi.Planet.Modifiers.VertexData;

namespace ModApi.Ui.Inspector
{
	public interface ITerrainModifierInspector
	{
		void UpdateVisualization(Action<List<DataSlotField>> getDataSlots);
	}
}
