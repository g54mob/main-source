using System.Collections.Generic;

namespace FluffyUnderware.Curvy.Generator
{
	public class SamplePointsMaterialGroup
	{
		public int MaterialID;

		public List<SamplePointsPatch> Patches;

		public int TriangleCount => 0;

		public int StartVertex => 0;

		public int EndVertex => 0;

		public int VertexCount => 0;

		public SamplePointsMaterialGroup(int materialID)
		{
		}

		public SamplePointsMaterialGroup(int materialID, List<SamplePointsPatch> patches)
		{
		}

		public void GetLengths(CGVolume volume, out float worldLength, out float uLength)
		{
			worldLength = default(float);
			uLength = default(float);
		}

		public SamplePointsMaterialGroup Clone()
		{
			return null;
		}
	}
}
