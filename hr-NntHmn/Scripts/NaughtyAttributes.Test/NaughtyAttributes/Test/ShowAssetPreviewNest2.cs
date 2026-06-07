using System;
using UnityEngine;

namespace NaughtyAttributes.Test
{
	[Serializable]
	public class ShowAssetPreviewNest2
	{
		[ShowAssetPreview(64, 64)]
		public Sprite sprite2;

		[ShowAssetPreview(96, 96)]
		public GameObject prefab2;
	}
}
