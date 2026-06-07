using System;
using System.Collections.Generic;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel
{
	[Serializable]
	public class SensorPartData : BindableDronePartData
	{
		public List<KeyBindingData> EventBindings { get; set; }
	}
}
