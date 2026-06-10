using System;
using System.Collections.Generic;
using UnityEngine;

namespace NSMedieval.RoomDetection
{
	[Serializable]
	public class RoomEffectors
	{
		[SerializeField]
		private string impressiveness;

		[SerializeField]
		private List<string> effectors;

		public string Impressiveness => impressiveness;

		public List<string> Effectors => effectors;

		public static void CheckCreateCache(ref RoomEffectors[] effectorsArray, ref Dictionary<string, RoomEffectors> cache)
		{
			if (cache == null)
			{
				cache = new Dictionary<string, RoomEffectors>();
				RoomEffectors[] array = effectorsArray;
				foreach (RoomEffectors roomEffectors in array)
				{
					cache.TryAdd(roomEffectors.Impressiveness, roomEffectors);
				}
			}
		}
	}
}
