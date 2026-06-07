using System;
using UnityEngine;

namespace VoxelBusters.CoreLibrary.NativePlugins.DemoKit
{
	public class DemoResources : PrivateSingletonBehaviour<DemoResources>
	{
		[SerializeField]
		private Texture2D[] m_images;

		[SerializeField]
		private string[] m_urls;

		[SerializeField]
		private string[] m_texts;

		public static Texture2D GetRandomImage()
		{
			return null;
		}

		public static string GetRandomURL()
		{
			return null;
		}

		public static string GetRandomText()
		{
			return null;
		}

		private static object GetRandomItem(Array array)
		{
			return null;
		}
	}
}
