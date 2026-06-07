using System;
using System.Diagnostics;

namespace SaintsField
{
	[Conditional("UNITY_EDITOR")]
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
	public class AssetFolderAttribute : FolderAttribute
	{
		public AssetFolderAttribute(string folder = "Assets", string title = "Choose a folder inside assets", string groupBy = "")
			: base(folder, title, groupBy)
		{
		}
	}
}
