using System.Collections.Generic;
using JetBrains.Annotations;

namespace FluffyUnderware.Curvy.ImportExport
{
	public static class SplineJsonConverter
	{
		public static string SplinesToJson(IEnumerable<CurvySpline> splines, CurvySerializationSpace coordinatesSpace = CurvySerializationSpace.Global, bool prettify = true)
		{
			return null;
		}

		public static string SplineToJson(CurvySpline spline, CurvySerializationSpace coordinatesSpace = CurvySerializationSpace.Global, bool prettify = true)
		{
			return null;
		}

		public static CurvySpline[] JsonToSplines(string json, CurvySerializationSpace coordinatesSpace = CurvySerializationSpace.Global)
		{
			return null;
		}

		public static CurvySpline JsonToSpline(string json, CurvySerializationSpace coordinatesSpace = CurvySerializationSpace.Global)
		{
			return null;
		}

		public static SerializedCurvySpline[] JsonToSerializedSplines([NotNull] string json)
		{
			return null;
		}
	}
}
