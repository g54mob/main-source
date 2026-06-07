using UnityEngine;

namespace VoxelBusters.CoreLibrary
{
	public class FileBrowserAttribute : PropertyAttribute
	{
		public bool UsesRelativePath { get; private set; }

		public string Extension { get; private set; }

		public FileBrowserAttribute(bool usesRelativePath, string extension = null)
		{
		}
	}
}
