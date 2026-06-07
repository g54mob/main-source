using UnityEngine;

namespace VoxelBusters.CoreLibrary
{
	public class FolderBrowserAttribute : PropertyAttribute
	{
		public bool UsesRelativePath { get; private set; }

		public FolderBrowserAttribute(bool usesRelativePath)
		{
		}
	}
}
