using app.vis;
using haxe.ds;
using haxe.lang;

namespace data
{
	public class FaceLib : HxObject
	{
		public StringMap metadatas;

		public Image paletteImage;

		public Res res;

		public FaceLib(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public FaceLib(Res res_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_data_FaceLib(FaceLib __hx_this, Res res_)
		{
		}

		public static void copyDecoration(StringMap src, StringMap dst, string type)
		{
		}

		public static string makeId(bool male, int faceIndex)
		{
			return null;
		}

		public virtual Face makeFace(FaceSpec spec, bool forDoc)
		{
			return null;
		}

		public virtual FaceMetadata getMetadata(FaceSpec spec)
		{
			return null;
		}

		public virtual void replaceColors(Image image, int paletteIndex)
		{
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
