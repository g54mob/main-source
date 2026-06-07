using System;
using System.Collections.Generic;
using DV.ThingTypes;

[Serializable]
public class ListTrainCarTypeWrapper
{
	public List<TrainCarLivery> liveries;

	public ListTrainCarTypeWrapper(List<TrainCarLivery> liveries)
	{
		this.liveries = liveries;
	}
}
