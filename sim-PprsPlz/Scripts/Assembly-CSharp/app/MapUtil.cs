using haxe.ds;
using haxe.lang;

namespace app
{
	public class MapUtil : HxObject
	{
		public MapUtil(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public MapUtil()
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_app_MapUtil(MapUtil __hx_this)
		{
		}

		public static bool getBool(StringMap hash, string key, object defaultVal)
		{
			return false;
		}

		public static int getInt(StringMap hash, string key, object defaultVal)
		{
			return 0;
		}

		public static double getFloat(StringMap hash, string key, object defaultVal)
		{
			return 0.0;
		}

		public static string getString(StringMap hash, string key, string defaultVal)
		{
			return null;
		}

		public static StringMap setBool(StringMap hash, string key, bool val)
		{
			return null;
		}

		public static StringMap setInt(StringMap hash, string key, int val)
		{
			return null;
		}

		public static StringMap setFloat(StringMap hash, string key, double val)
		{
			return null;
		}

		public static Array getStringArray(StringMap hash, string key, string separator)
		{
			return null;
		}

		public static void setStringArray(StringMap hash, string key, Array array, string separator)
		{
		}

		public static StringMap clone(StringMap hash)
		{
			return null;
		}

		public static StringMap combine(StringMap a, StringMap b)
		{
			return null;
		}

		public static void encode(StringMap hash, object obj, string prefix, Array fields)
		{
		}

		public static void decode(StringMap hash, object obj, string prefix, Array fields)
		{
		}

		public static string getSerializeKey(string prefix, bool properCase, string fieldName)
		{
			return null;
		}

		public static void serialize(StringMap hash, object obj, string prefix, bool properCase, Array fieldNames)
		{
		}

		public static void unserialize(StringMap hash, object obj, string prefix, bool properCase, Array fieldNames)
		{
		}

		public static Xml toXml(StringMap hash, string name)
		{
			return null;
		}

		public static StringMap fromXml(Xml xml)
		{
			return null;
		}

		public static string toSimpleString(StringMap hash, string separator)
		{
			return null;
		}

		public static StringMap fromSimpleString(string str, string separator)
		{
			return null;
		}
	}
}
