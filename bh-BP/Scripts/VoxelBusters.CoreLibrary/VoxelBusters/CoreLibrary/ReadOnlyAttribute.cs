using UnityEngine;

namespace VoxelBusters.CoreLibrary
{
	public class ReadOnlyAttribute : PropertyAttribute
	{
		public string Message { get; private set; }

		public ReadOnlyAttribute(string message = null)
		{
		}
	}
}
