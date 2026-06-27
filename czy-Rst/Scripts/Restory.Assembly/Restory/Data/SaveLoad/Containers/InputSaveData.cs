using System;
using System.Collections.Generic;
using Restory.Remapping;
using Rewired;

namespace Restory.Data.SaveLoad.Containers
{
	[Serializable]
	public class InputSaveData
	{
		[Serializable]
		public class ControllerData
		{
			public Dictionary<InputButtonIdentifier, InputButtonData> InputButtons = new Dictionary<InputButtonIdentifier, InputButtonData>();
		}

		[Serializable]
		public class ControllersData
		{
			public Dictionary<int, ControllerData> Controllers = new Dictionary<int, ControllerData>();
		}

		[Serializable]
		public class PlayerData
		{
			public Dictionary<ControllerType, ControllersData> Controllers = new Dictionary<ControllerType, ControllersData>();
		}

		public Dictionary<int, PlayerData> Players = new Dictionary<int, PlayerData>();
	}
}
