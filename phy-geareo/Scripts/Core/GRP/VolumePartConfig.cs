using System.Collections.Generic;
using Rhizomatic;

namespace GRP
{
	public class VolumePartConfig : PartConfig
	{
		public float maxSize;

		public string defaultStyle;

		public List<VolumeStyleConfig> styles;

		public override Thing CreateThing()
		{
			return null;
		}

		public VolumeStyleConfig GetStyle(string key)
		{
			return null;
		}
	}
}
