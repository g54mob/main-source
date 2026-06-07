using System;
using Dhs5.Utility.Databases;

namespace Simulator.GameWorld
{
	[Serializable]
	public class FurniturePicker : DataPicker<FurnitureDatabase>
	{
		public Furniture Get()
		{
			if (TryGetData<Furniture>(out var objOfTypeT))
			{
				return objOfTypeT;
			}
			return null;
		}
	}
}
