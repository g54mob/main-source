using UnityEngine;

namespace NaughtyAttributes.Test
{
	public class ShowAssetPreviewTest : MonoBehaviour
	{
		[ShowAssetPreview(64, 64)]
		public Sprite sprite0;

		[ShowAssetPreview(96, 96)]
		public GameObject prefab0;

		public ShowAssetPreviewNest1 nest1;
	}
}
