using System.IO;
using UnityEngine;

namespace TH20
{
	public static class Texture2DExtension
	{
		public static void SaveAsPNG(this Texture2D texture, string filename)
		{
			File.WriteAllBytes(filename, texture.EncodeToPNG());
		}
	}
}
