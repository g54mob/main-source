using UnityEngine;

namespace Rhizomatic
{
	[CreateAssetMenu(menuName = "Rhizomatic/Assets/ReimportAsset", fileName = "ReimportAsset")]
	[AssetCreator(typeof(DefaultAssetCategory))]
	public class ReimportAsset : ScriptableObject
	{
		public Object asset;
	}
}
