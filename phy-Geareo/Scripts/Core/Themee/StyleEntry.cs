using Rhizomatic;
using UnityEngine;

namespace Themee
{
	[CreateAssetMenu(menuName = "Themee/StyleEntry", fileName = "StyleEntry")]
	[AssetCreator(typeof(ThemeeAssetCategory))]
	public class StyleEntry : ScriptableObject
	{
		public string path;
	}
}
