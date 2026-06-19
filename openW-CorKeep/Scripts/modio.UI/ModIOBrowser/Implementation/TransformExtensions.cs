using UnityEngine;

namespace ModIOBrowser.Implementation
{
	internal static class TransformExtensions
	{
		public static string FullPath(this Transform t)
		{
			Transform transform = t;
			string text = transform.name;
			while (transform != null)
			{
				if (transform.parent == null)
				{
					return text;
				}
				text = transform.parent.name + "\\" + text;
				transform = transform.parent;
			}
			return text;
		}
	}
}
