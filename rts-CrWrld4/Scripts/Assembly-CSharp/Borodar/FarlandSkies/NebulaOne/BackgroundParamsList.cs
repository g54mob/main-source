using System;
using Borodar.FarlandSkies.Core.DotParams;

namespace Borodar.FarlandSkies.NebulaOne
{
	[Serializable]
	public class BackgroundParamsList : SortedParamsList<BackgroundParam>
	{
		public BackgroundParam GetParamPerTime(float currentTime)
		{
			return null;
		}
	}
}
