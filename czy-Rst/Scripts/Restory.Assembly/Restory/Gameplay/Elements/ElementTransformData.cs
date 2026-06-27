using System;
using Restory.Data.SaveLoad.Containers;

namespace Restory.Gameplay.Elements
{
	[Serializable]
	public class ElementTransformData
	{
		public ElementData ElementData;

		public SerializableTransform ElementTransform;
	}
}
