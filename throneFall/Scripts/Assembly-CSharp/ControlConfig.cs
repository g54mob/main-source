using System;
using System.Collections.Generic;
using Rewired;

[Serializable]
public class ControlConfig
{
	[Serializable]
	public class ControllerData
	{
		public ControllerType controllerType;

		public int controllerId;

		public string jsonMap;

		public List<int> knownActionIds = new List<int>();

		public ControllerData(ControllerType controllerType, int controllerId, string jsonMap)
		{
			this.controllerType = controllerType;
			this.controllerId = controllerId;
			this.jsonMap = jsonMap;
			knownActionIds = ControlConfigSaveLoad.GetAllKnownActionIDs();
		}
	}

	public bool initialized;

	public List<ControllerData> controllerDataSet = new List<ControllerData>();

	public void Initialize(List<ControllerMap> maps)
	{
		controllerDataSet = new List<ControllerData>();
		foreach (ControllerMap map in maps)
		{
			controllerDataSet.Add(new ControllerData(map.controllerType, map.controllerId, map.ToJsonString()));
		}
		initialized = true;
	}
}
