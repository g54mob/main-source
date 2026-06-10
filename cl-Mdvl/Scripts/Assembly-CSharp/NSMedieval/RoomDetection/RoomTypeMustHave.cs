using System;
using System.Collections.Generic;
using System.Linq;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using UnityEngine;

namespace NSMedieval.RoomDetection
{
	[Serializable]
	public class RoomTypeMustHave
	{
		[SerializeField]
		private List<string> buildings = new List<string>();

		[SerializeField]
		private List<string> otherContent = new List<string>();

		[SerializeField]
		private int minCount = 1;

		[SerializeField]
		private int maxCount = -1;

		[SerializeField]
		private List<string> textKey;

		[NonSerialized]
		private List<string> contentCache;

		[NonSerialized]
		private bool contentCacheInitialized;

		public List<string> Content
		{
			get
			{
				if (!contentCacheInitialized)
				{
					using PooledHashSet<string> pooledHashSet = HashSetPool<string>.GetJanitor();
					pooledHashSet.UnionWith(buildings);
					pooledHashSet.UnionWith(otherContent);
					contentCacheInitialized = true;
					contentCache = pooledHashSet.ToList();
				}
				return contentCache;
			}
		}

		public int MinCount => minCount;

		public int MaxCount => maxCount;

		public List<string> TextKeys => textKey;

		public List<string> Buildings => buildings;
	}
}
