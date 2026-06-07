using System.Collections.Generic;

namespace ModApi.Planet.Modifiers.VertexData
{
	public interface IDataSlotConfiguration
	{
		void GetDataSlots(List<DataSlotField> dataSlots);
	}
}
