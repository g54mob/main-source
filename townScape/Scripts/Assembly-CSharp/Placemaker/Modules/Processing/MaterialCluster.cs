using System;
using System.Collections.Generic;

namespace Placemaker.Modules.Processing
{
	[Serializable]
	public class MaterialCluster
	{
		public List<int> meshes;

		public List<int> corners;

		public bool cantTouchOtherColor;
	}
}
