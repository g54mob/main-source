using Rhizomatic;
using UnityEngine;

namespace Themee
{
	[CreateAssetMenu(menuName = "Themee/ThemeEntry", fileName = "ThemeEntry")]
	[AssetCreator(typeof(ThemeeAssetCategory))]
	public class ThemeEntry : ScriptableObject
	{
		public Theme theme;
	}
}
