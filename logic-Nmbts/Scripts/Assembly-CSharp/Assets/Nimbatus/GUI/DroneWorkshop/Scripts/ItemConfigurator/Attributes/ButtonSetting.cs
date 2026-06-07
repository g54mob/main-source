using System;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts;

namespace Assets.Nimbatus.GUI.DroneWorkshop.Scripts.ItemConfigurator.Attributes
{
	[AttributeUsage(AttributeTargets.Method)]
	public class ButtonSetting : DronePartSetting
	{
		public ButtonSetting(string term, UndoManager.EStoreReason reason)
			: base(term, reason)
		{
		}
	}
}
