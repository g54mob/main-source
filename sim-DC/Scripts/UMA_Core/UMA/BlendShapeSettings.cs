using System.Collections.Generic;

namespace UMA
{
	public class BlendShapeSettings
	{
		public bool ignoreBlendShapes;

		public bool loadAllFrames;

		public bool loadNormals;

		public bool loadTangents;

		public HashSet<string> filteredBlendshapes;

		public Dictionary<string, BlendShapeData> blendShapes;
	}
}
