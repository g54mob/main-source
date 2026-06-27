using System;
using System.Collections.Generic;
using Restory.Gameplay.InteractiveObjects;

namespace Restory.Data.SaveLoad.Containers
{
	[Serializable]
	public class PersonalBoxSaveData
	{
		public bool IsRemoved { get; set; }

		public List<ContainedInteractiveObject> BoxContent { get; set; } = new List<ContainedInteractiveObject>();

		public InteractiveObjectData InteractiveObjectData { get; set; }
	}
}
