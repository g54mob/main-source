using UnityEngine;

namespace NSEipix
{
	public static class RectExtension
	{
		public static float Area(this Rect r1)
		{
			return r1.width * r1.height;
		}
	}
}
