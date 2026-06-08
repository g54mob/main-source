using System;
using System.IO;
using UnityEngine;

namespace NatSuite.Recorders.Internal
{
	public static class Utility
	{
		private static string directory;

		public static string GetPath(string extension)
		{
			if (directory == null)
			{
				directory = ((Application.platform == RuntimePlatform.OSXEditor || Application.platform == RuntimePlatform.WindowsEditor) ? Directory.GetCurrentDirectory() : Application.persistentDataPath);
			}
			string text = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss_fff");
			string path = "recording_" + text + extension;
			return Path.Combine(directory, path);
		}
	}
}
