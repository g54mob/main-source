using UnityEngine;

namespace FuryStudios.FurySDK.Utils.Attributes
{
	public class ListAssetsAttribute : PropertyAttribute
	{
		public string Folder { get; set; }

		public bool AllowNone { get; set; }

		public ListAssetsAttribute(string searchInFolder = "", bool allowNone = true)
		{
		}
	}
}
