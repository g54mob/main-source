using UnityEngine;

namespace STMTools.Links
{
	public struct CharInfo
	{
		public Bounds bounds;

		public int line;

		public int linkIndex;

		public int charIndex;

		public CharInfo(float xMin, float yMin, float xMax, float yMax, int line, int linkIndex, int charIndex)
		{
			this = default(CharInfo);
			bounds = default(Bounds);
			bounds.SetMinMax(new Vector3(xMin, yMin, 0f), new Vector3(xMax, yMax, 0f));
			this.line = line;
			this.linkIndex = linkIndex;
			this.charIndex = charIndex;
		}
	}
}
