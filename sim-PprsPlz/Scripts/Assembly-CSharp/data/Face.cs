using app;
using app.vis;
using haxe.lang;

namespace data
{
	public class Face : HxObject
	{
		public static double kHeightMetersMin;

		public static double kHeightMetersPerPixel;

		public static int kPalPhotoFront;

		public static int kPalPhotoBack;

		public static int kDocImageDefaultWidth;

		public static int kDocImageDefaultHeight;

		public static int kHeadColor;

		public Image image;

		public Image headOnlyImage;

		public PointData headOnlyChinPos;

		public FaceSpec spec;

		public int heightInPixels;

		public FaceMetadata meta;

		static Face()
		{
		}

		public Face(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public Face(Res res, FaceLib faceLib, FaceSpec spec_, bool forDoc)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_data_Face(Face __hx_this, Res res, FaceLib faceLib, FaceSpec spec_, bool forDoc)
		{
		}

		public virtual double get_heightInMeters()
		{
			return 0.0;
		}

		public virtual Image getDocImage(Rand rand, double scale, bool flipX, bool replaceColors, object textColor, object backColor)
		{
			return null;
		}

		public virtual Image getPhotoHeadImage(FaceLib faceLib, bool front)
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
