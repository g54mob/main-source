using System.Text;
using UnityEngine;

namespace Kobold
{
	public class AtlasDefinition
	{
		public string Prefix;

		public int XSize;

		public int YSize;

		public string Compression;

		public bool Trim;

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("-atlasdef " + Prefix + " x:" + XSize + " y:" + YSize + " compression:" + Compression);
			return stringBuilder.ToString();
		}

		public exAtlas GenerateAtlas()
		{
			exAtlas obj = ScriptableObject.CreateInstance<exAtlas>();
			obj.width = XSize;
			obj.height = YSize;
			obj.useContourBleed = true;
			obj.usePaddingBleed = true;
			obj.trimElements = false;
			obj.trimThreshold = 1000;
			obj.customPadding = 3;
			return obj;
		}
	}
}
