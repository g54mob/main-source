using app;
using haxe.lang;

namespace data
{
	public class SoundDef : HxObject
	{
		public string id;

		public Array filenames;

		public bool loop;

		public double volScale;

		public double fade;

		public bool hasFade;

		public string room;

		public Rand rand;

		public ShuffledSequence shuffledSequence;

		public SoundDef(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public SoundDef(Rand rand_, Xml node)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_data_SoundDef(SoundDef __hx_this, Rand rand_, Xml node)
		{
		}

		public virtual string get_filename()
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
