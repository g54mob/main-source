using UnityEngine;

namespace MalbersAnimations
{
	public class CreateScriptableAssetAttribute : PropertyAttribute
	{
		public bool isAsset = true;

		public CreateScriptableAssetAttribute(bool isAsset)
		{
			this.isAsset = isAsset;
		}

		public CreateScriptableAssetAttribute()
		{
			isAsset = true;
		}
	}
}
