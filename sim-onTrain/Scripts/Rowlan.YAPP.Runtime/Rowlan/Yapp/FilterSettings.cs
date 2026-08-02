using System;
using System.Collections.Generic;

namespace Rowlan.Yapp
{
	[Serializable]
	public class FilterSettings
	{
		public bool layerFilterEnabled;

		public List<int> includes = new List<int>();

		public List<int> excludes = new List<int>();
	}
}
