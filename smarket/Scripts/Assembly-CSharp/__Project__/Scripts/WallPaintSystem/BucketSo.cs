using MyBox;
using NaisuPorter.CommonScripts;
using UnityEngine;
using UnityEngine.Localization;

namespace __Project__.Scripts.WallPaintSystem
{
	[CreateAssetMenu(fileName = "New Bucket", menuName = "Scriptable Objects/Furniture/Bucket")]
	public class BucketSo : ScriptableObject
	{
		public BucketData bucketData;

		public int ID;

		[Separator("General Setup", false)]
		public LocalizedString LocalizedName;

		public BoxSize BoxSize;

		public Sprite BucketIcon;

		public int AtlasIndex;

		public SerializableVector2Int AtlasPosition;

		public PaintBucket BucketPrefab;

		[Separator("Purchase Info", false)]
		public float Cost;

		public string BucketName => null;
	}
}
