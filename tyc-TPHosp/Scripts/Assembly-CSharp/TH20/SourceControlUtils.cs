using System.IO;
using UnityEngine;

namespace TH20
{
	public static class SourceControlUtils
	{
		public static bool Checkout(string path)
		{
			return false;
		}

		public static bool IsOpenForEdit(string path)
		{
			return !new FileInfo(path).IsReadOnly;
		}

		public static bool MarkAssetAsDirty(Object asset)
		{
			return false;
		}
	}
}
