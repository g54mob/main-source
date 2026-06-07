using System;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts;

namespace Assets.Nimbatus.GUI.DroneWorkshop.Scripts.ItemConfigurator.Attributes
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
	public class EnumSetting : DronePartSetting
	{
		private readonly bool _customRows;

		private readonly int _rows;

		public int GetRows(object parentObject)
		{
			if (_customRows)
			{
				return _rows;
			}
			return -1;
		}

		public EnumSetting(string term, UndoManager.EStoreReason reason)
			: base(term, reason)
		{
		}

		public EnumSetting(string term, int rows, UndoManager.EStoreReason reason)
			: base(term, reason)
		{
			_rows = rows;
			_customRows = true;
		}
	}
}
