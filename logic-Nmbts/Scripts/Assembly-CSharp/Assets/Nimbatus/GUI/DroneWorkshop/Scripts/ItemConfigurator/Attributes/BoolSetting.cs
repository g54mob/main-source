using System;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts;

namespace Assets.Nimbatus.GUI.DroneWorkshop.Scripts.ItemConfigurator.Attributes
{
	[AttributeUsage(AttributeTargets.Field)]
	public class BoolSetting : DronePartSetting
	{
		public BoolSetting(string term, UndoManager.EStoreReason reason)
			: base(term, reason)
		{
		}
	}
}
