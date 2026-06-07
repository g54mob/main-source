using System.IO;
using System.Xml.Linq;
using Jundroo.Common;
using UnityEngine;

namespace Assets.Scripts.Storage
{
	public static class GameData
	{
		public static class Mods
		{
			public static string ModsPath => GetPath("Mods");

			public static string GetPath(string fileName)
			{
				return Path.Combine(PersistentDataPath, fileName);
			}
		}

		public static string PersistentDataPath { get; } = Project.PersistentDataPath;

		public static string GetPath(string relativePath)
		{
			return Path.Combine(PersistentDataPath, relativePath);
		}

		public static string GetPath(string relativePath1, string relativePath2)
		{
			return Path.Combine(PersistentDataPath, relativePath1, relativePath2);
		}

		public static string GetPath(string relativePath1, string relativePath2, string relativePath3)
		{
			return Path.Combine(PersistentDataPath, relativePath1, relativePath2, relativePath3);
		}

		public static Texture2D LoadTexture(string path, bool markNonReadable = false, bool throwFileNotFoundException = true)
		{
			if (!throwFileNotFoundException && !File.Exists(path))
			{
				return null;
			}
			byte[] data = File.ReadAllBytes(path);
			Texture2D texture2D = new Texture2D(2, 2);
			if (!texture2D.LoadImage(data, markNonReadable))
			{
				Object.Destroy(texture2D);
				texture2D = null;
			}
			return texture2D;
		}

		public static XDocument LoadXml(string path, bool throwFileNotFoundException = true)
		{
			if (!throwFileNotFoundException && !File.Exists(path))
			{
				return null;
			}
			return XDocument.Load(path);
		}

		public static void SaveXml(XDocument xmlDocument, string path)
		{
			xmlDocument.Save(path);
		}
	}
}
