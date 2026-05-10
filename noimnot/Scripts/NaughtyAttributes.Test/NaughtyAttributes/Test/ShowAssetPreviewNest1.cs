using System;
using UnityEngine;

namespace NaughtyAttributes.Test
{
	[Serializable]
	public class ShowAssetPreviewNest1
	{
		[ShowAssetPreview(64, 64)]
		public Sprite sprite1;

		[ShowAssetPreview(96, 96)]
		public GameObject prefab1;

		public ShowAssetPreviewNest2 nest2;
	}
}
