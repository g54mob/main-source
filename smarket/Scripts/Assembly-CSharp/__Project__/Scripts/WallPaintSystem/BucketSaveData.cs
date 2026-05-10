using System;
using NaisuPorter.CommonScripts;
using UnityEngine;

namespace __Project__.Scripts.WallPaintSystem
{
	[Serializable]
	public class BucketSaveData
	{
		public BucketData bucketData;

		public SerializableVector3 position;

		public BucketSaveData(BucketData bucketData, Vector3 position)
		{
		}

		public BucketSaveData()
		{
		}
	}
}
