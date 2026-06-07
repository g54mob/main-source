using UnityEngine.Rendering;

namespace Linework.EdgeDetection
{
	internal static class Keyword
	{
		public static readonly GlobalKeyword ScreenSpaceOcclusion = GlobalKeyword.Create("_SCREEN_SPACE_OCCLUSION");

		public static readonly GlobalKeyword SectionPass = GlobalKeyword.Create("_SECTION_PASS");
	}
}
