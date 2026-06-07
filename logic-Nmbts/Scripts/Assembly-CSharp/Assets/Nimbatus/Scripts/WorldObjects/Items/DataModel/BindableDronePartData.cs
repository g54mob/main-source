using System;
using System.Collections.Generic;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel
{
	[Serializable]
	public class BindableDronePartData : DronePartData
	{
		public List<KeyBindingData> KeyBindings { get; set; }
	}
}
