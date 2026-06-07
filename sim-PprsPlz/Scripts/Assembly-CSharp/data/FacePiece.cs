using app.vis;
using haxe.lang;

namespace data
{
	public class FacePiece : HxObject
	{
		public static uint kFaceColor0;

		public static uint kFaceColor1;

		public static uint kFaceColor2;

		public static uint kClothesColor0;

		public static uint kClothesColor1;

		public static uint kEyeKey0;

		public static uint kEyeKey1;

		public static uint kNoseMouthKey0;

		public static uint kNoseMouthKey1;

		public static uint kEyeNoseMouthKey;

		public static uint kHeadAndShouldersKey;

		public static uint kShouldersKey;

		public static uint kMarkKey;

		public static int kMarkNone;

		public static int kMarkEye;

		public static int kMarkNose;

		public static int kMarkMouth;

		public static int kMarkChin;

		public static int kMarkShoulder;

		public static int kDocFaceColor0;

		public static int kDocFaceColor1;

		public PointData nosePos;

		public PointData mouthPos;

		public PointData eyePos0;

		public PointData eyePos1;

		public PointData chinPos;

		public PointData shoulderPos0;

		public PointData shoulderPos1;

		public int width;

		public int height;

		public bool forDoc;

		public uint clearColor;

		public Image colorImage;

		public Image pieceImage;

		public uint faceColor0;

		public uint faceColor1;

		public uint faceColor2;

		public uint clothesColor0;

		public uint clothesColor1;

		static FacePiece()
		{
		}

		public FacePiece(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public FacePiece(Res res, bool male, int faceIndex, bool forDoc_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_data_FacePiece(FacePiece __hx_this, Res res, bool male, int faceIndex, bool forDoc_)
		{
		}

		public static PointData flipPointOnX(double centerX, PointData p)
		{
			return null;
		}

		public virtual FacePiece makeHead()
		{
			return null;
		}

		public virtual int addMark(int i)
		{
			return 0;
		}

		public virtual FacePiece makeEyes()
		{
			return null;
		}

		public virtual FacePiece makeNoseMouth()
		{
			return null;
		}

		public virtual FacePiece makeShoulders()
		{
			return null;
		}

		public virtual void flipOnX(double centerX)
		{
		}

		public virtual Image getImage()
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
