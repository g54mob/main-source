using System;
using Borodar.FarlandSkies.Core.DotParams;

namespace Borodar.FarlandSkies.NebulaOne
{
	[Serializable]
	public class StarsParamsList : SortedParamsList<StarsParam>
	{
		public StarsParam GetParamPerTime(float currentTime)
		{
			return null;
		}
	}
}
