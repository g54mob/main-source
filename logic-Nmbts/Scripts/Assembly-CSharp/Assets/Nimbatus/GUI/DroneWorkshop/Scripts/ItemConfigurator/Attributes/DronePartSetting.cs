using System;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts;
using I2.Loc;

namespace Assets.Nimbatus.GUI.DroneWorkshop.Scripts.ItemConfigurator.Attributes
{
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Field)]
	public class DronePartSetting : Attribute
	{
		private readonly string _term;

		public UndoManager.EStoreReason StoreReason;

		public string Name
		{
			get
			{
				return LocalizationManager.GetTermTranslation(_term);
			}
		}

		public DronePartSetting(string term, UndoManager.EStoreReason storeReason)
		{
			_term = term;
			StoreReason = storeReason;
		}
	}
}
