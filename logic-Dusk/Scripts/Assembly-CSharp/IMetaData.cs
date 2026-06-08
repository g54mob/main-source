using System.Collections.Generic;

public interface IMetaData
{
	List<DesignedDungeonManager.MetaData> metaDataList { get; set; }

	string GetMetaData(string name);
}
