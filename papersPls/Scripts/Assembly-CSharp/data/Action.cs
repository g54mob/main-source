using haxe.lang;

namespace data
{
	public class Action : HxObject
	{
		public string id;

		public int scoreDelta;

		public int scoreDeltaDelta;

		public int timeDelta;

		public bool endGame;

		public Action(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public Action(Xml node)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_data_Action(Action __hx_this, Xml node)
		{
		}

		public static int parseSigned(string str)
		{
			return 0;
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

		public override void __hx_getFields(Array baseArr)
		{
		}
	}
}
