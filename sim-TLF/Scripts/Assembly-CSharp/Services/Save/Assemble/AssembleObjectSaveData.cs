using System;
using System.Collections.Generic;

namespace Services.Save.Assemble
{
	[Serializable]
	public struct AssembleObjectSaveData
	{
		public Dictionary<string, PartSaveData> Parts;
	}
}
