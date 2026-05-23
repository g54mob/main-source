using haxe.ds;
using haxe.lang;

namespace play.stash
{
	public class StashedBooth : HxObject
	{
		public static int kGraceTime;

		public StashedBoothEngine engine;

		public List paperStates;

		public bool shutterOpen;

		public bool criminalPosterPinned;

		public double time;

		static StashedBooth()
		{
		}

		public StashedBooth(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public StashedBooth()
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_stash_StashedBooth(StashedBooth __hx_this)
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
