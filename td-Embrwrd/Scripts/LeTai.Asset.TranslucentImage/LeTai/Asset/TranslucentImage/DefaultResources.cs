using UnityEngine;

namespace LeTai.Asset.TranslucentImage
{
	[CreateAssetMenu(menuName = "Translucent Image/Default Resources")]
	public class DefaultResources : ScriptableObject
	{
		private static DefaultResources instance;

		public Material material;

		public Material paraformMaterial;

		public static DefaultResources Instance => null;

		private static T MakeTempCopy<T>(T obj) where T : Object
		{
			return null;
		}
	}
}
