using app;
using data;
using haxe.lang;

namespace play.day
{
	public class Criminal : HxObject
	{
		public int index;

		public bool used;

		public string forTravelerId;

		public Face face;

		public FaceSpec faceSpec;

		public Criminal(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public Criminal(int index_, FaceSpec faceSpec_, string forTravelerId_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_day_Criminal(Criminal __hx_this, int index_, FaceSpec faceSpec_, string forTravelerId_)
		{
		}

		public static Criminal selectRandom(Rand rand, string forTravelerId, Array criminals, object forceGender, object male)
		{
			return null;
		}

		public virtual Face getFace(FaceLib faceLib)
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
