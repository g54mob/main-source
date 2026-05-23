using app;
using haxe.lang;

namespace data
{
	public class FaceCycler : HxObject
	{
		public Rand rand;

		public Array piecesM;

		public Array piecesF;

		public ShuffledSequence palettes;

		public FaceCycler(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public FaceCycler(int seed)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_data_FaceCycler(FaceCycler __hx_this, int seed)
		{
		}

		public virtual FaceSpec getNextFaceSpec(bool male)
		{
			return null;
		}

		public virtual Array makePieces(int numSheets, int seed)
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
	}
}
