using System;
using System.Collections.Generic;
using System.Linq;
using NSEipix.Base;
using NSMedieval.Serialization;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;

namespace NSMedieval.State
{
	public static class FVSerializationExtensions
	{
		public static void WriteBlueprintIds<T>(this FVSerializer serializer, string key, IEnumerable<T> blueprints) where T : NSEipix.Base.Model
		{
			using PooledList<string> pooledList = ListPool<string>.GetJanitor();
			if (blueprints != null)
			{
				pooledList.AddRange(blueprints.Select((T b) => b.GetID()));
			}
			serializer.Write(key, pooledList);
		}

		public static List<T> ReadIdsToBlueprints<T>(this FVDeserializer deserializer, string key, Func<string, T> repositoryGetter, List<T> defaultValue = null) where T : NSEipix.Base.Model
		{
			List<string> list = deserializer.ReadStringList(key);
			if (list == null)
			{
				return defaultValue;
			}
			return list.Select(repositoryGetter).ToList();
		}
	}
}
