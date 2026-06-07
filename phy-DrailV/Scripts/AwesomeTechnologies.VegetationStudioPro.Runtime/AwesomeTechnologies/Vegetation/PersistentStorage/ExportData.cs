using System;
using System.Collections.Generic;

namespace AwesomeTechnologies.Vegetation.PersistentStorage
{
	[Serializable]
	public class ExportData
	{
		public List<PersistentVegetationCell> PersistentVegetationCellList;

		public List<PersistentVegetationInstanceInfo> PersistentVegetationInstanceInfoList;

		public List<byte> PersistentVegetationInstanceSourceList;
	}
}
