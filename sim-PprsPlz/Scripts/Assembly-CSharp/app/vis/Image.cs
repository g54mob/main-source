using haxe.io;
using haxe.lang;
using sys.thread;

namespace app.vis
{
	public class Image : HxObject
	{
		public static Bytes fillLineBytes;

		public static ArrayBufferViewImpl fillLineUints;

		public static Mutex fillLineMutex;

		public static uint nextGuid;

		public static int kOverlayAlphaThreshInt;

		public static int kRenderFixedShift;

		public static Image white1x1;

		public int width;

		public int height;

		public Bytes bytes;

		public uint guid;

		public uint generation;

		public ArrayBufferViewImpl uints;

		public Clipper clipper;

		public AffineData _workAffine;

		public PointData _workPoint;

		static Image()
		{
		}

		public Image(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public Image(int width_, int height_, Alloc alloc)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_app_vis_Image(Image __hx_this, int width_, int height_, Alloc alloc)
		{
		}

		public static Image fromPng(Bytes bytes)
		{
			return null;
		}

		public Image dirty()
		{
			return null;
		}

		public uint get(int x, int y)
		{
			return 0u;
		}

		public uint getClamped(int x, int y)
		{
			return 0u;
		}

		public void set_nodirty(int x, int y, uint color)
		{
		}

		public ArrayBufferViewImpl accessUInts()
		{
			return null;
		}

		public virtual Image tint(uint color)
		{
			return null;
		}

		public virtual void lockFillLine(int byteCount)
		{
		}

		public virtual void unlockFillLine()
		{
		}

		public virtual Image fill(uint color, Rect rect)
		{
			return null;
		}

		public virtual Image paste(Image srcImage, object dstX, object dstY, Rect srcRect, PasteMode pasteMode, ColorMode colorMode)
		{
			return null;
		}

		public virtual Image draw(Image image, AffineData affine)
		{
			return null;
		}

		public virtual void render(Quad quad, PasteMode pasteMode, object clipWidth, object clipHeight)
		{
		}

		public virtual Image transformed(double rotationInRadians, object scale)
		{
			return null;
		}

		public virtual Image rotatedLeft90()
		{
			return null;
		}

		public virtual Image rotatedRight90()
		{
			return null;
		}

		public virtual Image bordered(int thickness, ColorData color)
		{
			return null;
		}

		public virtual Image flipH()
		{
			return null;
		}

		public virtual Image flipV()
		{
			return null;
		}

		public virtual Image copy(Rect rect)
		{
			return null;
		}

		public virtual Image replace(uint replace, uint with)
		{
			return null;
		}

		public virtual Image replaceNonTransparent(uint with)
		{
			return null;
		}

		public virtual Image clone()
		{
			return null;
		}

		public PartData part(double x, double y, double w, double h)
		{
			return null;
		}

		public Image pixelSetter()
		{
			return null;
		}

		public virtual Image save(string filename)
		{
			return null;
		}

		public virtual string toString()
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
