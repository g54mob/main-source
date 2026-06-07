using haxe.ds;
using haxe.lang;

namespace haxe
{
	public class Serializer : HxObject
	{
		public static bool USE_CACHE;

		public static bool USE_ENUM_INDEX;

		public static string BASE64;

		public static object[] BASE64_CODES;

		public StringBuf buf;

		public Array cache;

		public StringMap shash;

		public int scount;

		public bool useCache;

		public bool useEnumIndex;

		static Serializer()
		{
		}

		public Serializer(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public Serializer()
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_haxe_Serializer(Serializer __hx_this)
		{
		}

		public static string run(object v)
		{
			return null;
		}

		public virtual string toString()
		{
			return null;
		}

		public virtual void serializeString(string s)
		{
		}

		public virtual bool serializeRef(object v)
		{
			return false;
		}

		public virtual void serializeFields(object v)
		{
		}

		public virtual void serialize(object v)
		{
		}

		public virtual void serializeException(object e)
		{
		}

		public override double __hx_setField_f(string field, int hash, double value, bool handleProperties)
		{
			return 0.0;
		}

		public override object __hx_setField(string field, int hash, object value, bool handleProperties)
		{
			return null;
		}

		public override object __hx_getField(string field, int hash, bool throwErrors, bool isCheck, bool handleProperties)
		{
			return null;
		}

		public override double __hx_getField_f(string field, int hash, bool throwErrors, bool handleProperties)
		{
			return 0.0;
		}

		public override object __hx_invokeField(string field, int hash, object[] dynargs)
		{
			return null;
		}

		public override void __hx_getFields(Array baseArr)
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
