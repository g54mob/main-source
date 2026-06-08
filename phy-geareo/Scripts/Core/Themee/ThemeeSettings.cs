using Rhizomatic;
using UnityEngine;

namespace Themee
{
	[CreateAssetMenu(menuName = "Themee/ThemeeSettings", fileName = "ThemeeSettings")]
	[AssetCreator(typeof(ThemeeAssetCategory))]
	public class ThemeeSettings : ScriptableObject
	{
		public ThemeEntry theme;

		private static ThemeeSettings _config;

		public static ThemeeSettings config => null;
	}
}
