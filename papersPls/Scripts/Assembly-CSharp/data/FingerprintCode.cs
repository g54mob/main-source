using app;
using app.vis;
using haxe.lang;

namespace data
{
	public class FingerprintCode : HxObject
	{
		public static int kSrcCellSize;

		public static int kDstCellSizeY;

		public Array fingers;

		public Rand rand;

		static FingerprintCode()
		{
		}

		public FingerprintCode(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public FingerprintCode(Rand rand_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_data_FingerprintCode(FingerprintCode __hx_this, Rand rand_)
		{
		}

		public static int makeRandomSingle(Rand rand)
		{
			return 0;
		}

		public static FingerprintCode fromString(Rand rand, string str)
		{
			return null;
		}

		public virtual void randomize()
		{
		}

		public virtual string toString()
		{
			return null;
		}

		public virtual FingerprintCode makeInvalid(FingerprintCode valid)
		{
			return null;
		}

		public virtual Image getImage(Res res, uint color, object allFingers, object dstCellSizeX)
		{
			return null;
		}

		public override object __hx_setField(string field, int hash, object value, bool handleProperties)
		{
			return null;
		}

		public override object __hx_getField(string field, int hash, bool throwErrors, bool isCheck, bool handleProperties)
		{
			return null;
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
