using System;
using UnityEngine;

namespace MyBox
{
	public static class ImageStringConverter
	{
		public static Texture2D ImageFromString(string source, int width, int height)
		{
			byte[] data = Convert.FromBase64String(source);
			Texture2D texture2D = new Texture2D(width, height);
			texture2D.LoadImage(data);
			return texture2D;
		}
	}
}
