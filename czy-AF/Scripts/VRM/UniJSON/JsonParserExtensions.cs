using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UniJSON
{
	public static class JsonParserExtensions
	{
		public static List<T> DeserializeList<T>(this ListTreeNode<JsonValue> jsonList)
		{
			return (from x in jsonList.ArrayItems()
				select JsonUtility.FromJson<T>(new Utf8String(x.Value.Bytes).ToString())).ToList();
		}
	}
}
