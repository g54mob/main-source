using System.Collections.Generic;
using JetBrains.Annotations;
using ToolBuddy.ThirdParty.VectorGraphics;

namespace FluffyUnderware.Curvy.ImportExport
{
	public static class SplineSvgConverter
	{
		public static CurvySpline[] SvgToSplines(string svg, CurvySerializationSpace coordinatesSpace = CurvySerializationSpace.Global)
		{
			return null;
		}

		public static CurvySpline SvgToSpline(string svg, CurvySerializationSpace coordinatesSpace = CurvySerializationSpace.Global)
		{
			return null;
		}

		public static List<SerializedCurvySpline> SvgToSerializedSplines([NotNull] string svg, bool invertY = true)
		{
			return null;
		}

		private static void DrawNode(SceneNode node, Matrix2D rootTransform, List<SerializedCurvySpline> splines)
		{
		}
	}
}
