using System.Collections.Generic;

namespace Ink.Runtime
{
	public static class Json
	{
		private static string[] _controlCommandNames;

		public static List<T> JArrayToRuntimeObjList<T>(List<object> jArray, bool skipLast = false) where T : Object
		{
			return null;
		}

		public static List<Object> JArrayToRuntimeObjList(List<object> jArray, bool skipLast = false)
		{
			return null;
		}

		public static void WriteDictionaryRuntimeObjs(SimpleJson.Writer writer, Dictionary<string, Object> dictionary)
		{
		}

		public static void WriteListRuntimeObjs(SimpleJson.Writer writer, List<Object> list)
		{
		}

		public static void WriteIntDictionary(SimpleJson.Writer writer, Dictionary<string, int> dict)
		{
		}

		public static void WriteRuntimeObject(SimpleJson.Writer writer, Object obj)
		{
		}

		public static Dictionary<string, Object> JObjectToDictionaryRuntimeObjs(Dictionary<string, object> jObject)
		{
			return null;
		}

		public static Dictionary<string, int> JObjectToIntDictionary(Dictionary<string, object> jObject)
		{
			return null;
		}

		public static Object JTokenToRuntimeObject(object token)
		{
			return null;
		}

		public static void WriteRuntimeContainer(SimpleJson.Writer writer, Container container, bool withoutName = false)
		{
		}

		private static Container JArrayToContainer(List<object> jArray)
		{
			return null;
		}

		private static Choice JObjectToChoice(Dictionary<string, object> jObj)
		{
			return null;
		}

		public static void WriteChoice(SimpleJson.Writer writer, Choice choice)
		{
		}

		private static void WriteInkList(SimpleJson.Writer writer, ListValue listVal)
		{
		}

		public static ListDefinitionsOrigin JTokenToListDefinitions(object obj)
		{
			return null;
		}

		static Json()
		{
		}
	}
}
