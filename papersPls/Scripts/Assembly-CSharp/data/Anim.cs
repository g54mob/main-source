using app.vis;
using haxe.lang;

namespace data
{
	public class Anim : HxObject
	{
		public string id;

		public string tileSuffixH;

		public string tileSuffixV;

		public bool loop;

		public double fpsH;

		public double fpsV;

		public string sound;

		public bool death;

		public PointData offset;

		public Anim(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public Anim(Xml node)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_data_Anim(Anim __hx_this, Xml node)
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

		public override void __hx_getFields(Array baseArr)
		{
		}
	}
}
