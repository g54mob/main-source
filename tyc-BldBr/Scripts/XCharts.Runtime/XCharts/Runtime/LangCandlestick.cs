using System;
using System.Collections.Generic;

namespace XCharts.Runtime
{
	[Serializable]
	public class LangCandlestick
	{
		public List<string> dimensionNames = new List<string> { "open", "close", "lowest", "highest" };
	}
}
