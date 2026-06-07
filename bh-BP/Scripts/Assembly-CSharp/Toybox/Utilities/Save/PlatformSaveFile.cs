using System;
using UnityEngine;

namespace Toybox.Utilities.Save
{
	[Serializable]
	public class PlatformSaveFile
	{
		[SerializeField]
		public string filePath;

		[SerializeField]
		public byte[] data;

		public PlatformSaveFile(string path)
		{
		}
	}
}
