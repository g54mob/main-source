using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(menuName = "BBT/DLC/Save References Loader")]
	public class AssetLoaderSaveReferences : ScriptableLoader
	{
		[SerializeField]
		private AssetReferences[] _assetReferences;

		public override void Load()
		{
			AssetReferences[] assetReferences = _assetReferences;
			for (int i = 0; i < assetReferences.Length; i++)
			{
				AssetReferences.Add(assetReferences[i]);
			}
		}
	}
}
