using System;
using Restory.Data.InteractiveObjects;
using Restory.Gameplay.InteractiveObjects;

namespace Restory.Data.SaveLoad.Containers
{
	[Serializable]
	public class InteractiveObjectData
	{
		public InteractiveObjectInfo InteractiveObjectInfo;

		public SerializableTransform InteractiveObjectTransform;

		public InteractiveObjectState State;

		public string UniqueId;

		public bool HasChanged;

		public InteractiveObjectAdditionalProperties InteractiveObjectAdditionalProperties;
	}
}
