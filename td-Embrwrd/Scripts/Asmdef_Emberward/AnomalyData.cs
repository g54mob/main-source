using System;
using System.Collections.Generic;

[Serializable]
public class AnomalyData
{
	public eItemType anomalyType;

	public List<int> extraData;

	public AnomalyData()
	{
	}

	public AnomalyData(eItemType anomalyType, List<int> extraData = null)
	{
	}
}
