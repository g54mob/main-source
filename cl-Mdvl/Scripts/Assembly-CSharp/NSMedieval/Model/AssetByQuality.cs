using System;
using NSMedieval.State;
using UnityEngine;

namespace NSMedieval.Model
{
	[Serializable]
	public class AssetByQuality
	{
		[SerializeField]
		private string prefabID;

		[SerializeField]
		private string skinnedMeshID;

		[SerializeField]
		private string texturePath;

		[SerializeField]
		private ProductQuality quality;

		[SerializeField]
		private BodyType bodyType;

		public ProductQuality Quality => quality;

		public BodyType BodyType => bodyType;

		public string TexturePath => texturePath;

		public string PrefabID => prefabID;

		public string SkinnedMeshID => skinnedMeshID;

		public AssetByQuality(string prefabID)
		{
			this.prefabID = prefabID;
			quality = ProductQuality.None;
		}
	}
}
