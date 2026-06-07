using System;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.SensorParts;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel
{
	[Serializable]
	public class FactoryPartData : SensorPartData
	{
		public EFactoryStartState StartState;
	}
}
