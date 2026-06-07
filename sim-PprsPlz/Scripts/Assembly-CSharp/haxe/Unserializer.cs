using System;
using haxe.lang;

namespace haxe
{
	public class Unserializer : HxObject
	{
		public static object DEFAULT_RESOLVER;

		public static string BASE64;

		public static Array CODES;

		public string buf;

		public int pos;

		public int length;

		public Array cache;

		public Array scache;

		public object resolver;

		static Unserializer()
		{
		}

		public Unserializer(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public Unserializer(string buf)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_haxe_Unserializer(Unserializer __hx_this, string buf)
		{
		}

		public static Array initCodes()
		{
			return null;
		}

		public static object run(string v)
		{
			return null;
		}

		public static int fastLength(string s)
		{
			return 0;
		}

		public static int fastCharCodeAt(string s, int pos)
		{
			return 0;
		}

		public static string fastCharAt(string s, int pos)
		{
			return null;
		}

		public static string fastSubstr(string s, int pos, int length)
		{
			return null;
		}

		public virtual void setResolver(object r)
		{
		}

		public virtual object getResolver()
		{
			return null;
		}

		public int get(int p)
		{
			return 0;
		}

		public virtual int readDigits()
		{
			return 0;
		}

		public virtual double readFloat()
		{
			return 0.0;
		}

		public virtual void unserializeObject(object o)
		{
		}

		public virtual object unserializeEnum(System.Type edecl, string tag)
		{
			return null;
		}

		public virtual object unserialize()
		{
			return null;
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
	}
}
