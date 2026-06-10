using System.Collections.Generic;

namespace NSMedieval.UI
{
	public class InfoPanelStockpile : SelectionExtraView
	{
		public List<IStorage> StorageObjects { get; }

		public InfoPanelStockpile(IStorage storageObject)
		{
			StorageObjects = new List<IStorage> { storageObject };
		}

		public InfoPanelStockpile(List<IStorage> storageObjects)
		{
			StorageObjects = storageObjects;
		}
	}
}
