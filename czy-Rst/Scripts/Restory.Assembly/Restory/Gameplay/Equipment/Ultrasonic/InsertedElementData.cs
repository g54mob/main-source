using System;
using Restory.Data.SaveLoad.Containers;
using Restory.Gameplay.Elements;

namespace Restory.Gameplay.Equipment.Ultrasonic
{
	[Serializable]
	public class InsertedElementData
	{
		public ElementData ElementData { get; set; }

		public SerializableTransform ElementTransform { get; set; }

		public ElementRescaleData RescaleData { get; set; }
	}
}
