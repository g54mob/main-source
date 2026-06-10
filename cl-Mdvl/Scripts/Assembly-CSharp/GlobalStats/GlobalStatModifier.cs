using System;
using System.Linq;
using NSMedieval.Model;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using UnityEngine;

namespace GlobalStats
{
	[Serializable]
	public class GlobalStatModifier
	{
		[SerializeField]
		private string globalStat;

		[SerializeField]
		private float addValue;

		[SerializeField]
		private string[] friendliness;

		[NonSerialized]
		private FactionFriendliness[] friendlinessCache;

		[NonSerialized]
		private bool friendlinessCacheInitialized;

		public string GlobalStat => globalStat;

		public float AddValue => addValue;

		public FactionFriendliness[] Friendliness
		{
			get
			{
				if (!friendlinessCacheInitialized)
				{
					using PooledList<FactionFriendliness> pooledList = ListPool<FactionFriendliness>.GetJanitor();
					string[] array = friendliness;
					for (int i = 0; i < array.Length; i++)
					{
						if (Enum.TryParse<FactionFriendliness>(array[i], ignoreCase: true, out var result))
						{
							pooledList.Add(result);
						}
					}
					friendlinessCache = pooledList.ToArray();
					friendlinessCacheInitialized = true;
				}
				return friendlinessCache;
			}
		}
	}
}
