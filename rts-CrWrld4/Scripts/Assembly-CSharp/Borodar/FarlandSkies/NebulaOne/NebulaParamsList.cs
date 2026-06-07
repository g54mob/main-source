using System;
using Borodar.FarlandSkies.Core.DotParams;

namespace Borodar.FarlandSkies.NebulaOne
{
	[Serializable]
	public class NebulaParamsList : SortedParamsList<NebulaParam>
	{
		public NebulaParam GetParamPerTime(float currentTime)
		{
			return null;
		}
	}
}
