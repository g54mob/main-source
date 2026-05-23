using app;
using haxe.lang;

namespace data
{
	public class FaceSpec : HxObject
	{
		public static int kNumPalettes;

		public static int kNumSheetsMale;

		public static int kNumSheetsFemale;

		public static int kNumFacesPerSheet;

		public static int kPieceMaxMale;

		public static int kPieceMaxFemale;

		public static int kSizeInSheetX;

		public static int kSizeInSheetY;

		public bool male;

		public int shoulders;

		public int head;

		public int eyes;

		public int noseMouth;

		public int palette;

		public bool flip;

		static FaceSpec()
		{
		}

		public FaceSpec(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public FaceSpec()
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_data_FaceSpec(FaceSpec __hx_this)
		{
		}

		public static FaceSpec fromString(Rand rand, string str)
		{
			return null;
		}

		public static string getSheetId(bool male, int faceIndex)
		{
			return null;
		}

		public virtual string toString()
		{
			return null;
		}

		public virtual FaceSpec clone()
		{
			return null;
		}

		public virtual FaceSpec getInvalid(Rand rand)
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

		public override string ToString()
		{
			return null;
		}
	}
}
