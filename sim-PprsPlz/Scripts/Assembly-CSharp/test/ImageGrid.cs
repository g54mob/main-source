using app.vis;
using haxe.lang;

namespace test
{
	public class ImageGrid : HxObject
	{
		public Array images;

		public Array rowStarts;

		public ImageGrid(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public ImageGrid()
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_test_ImageGrid(ImageGrid __hx_this)
		{
		}

		public bool get_hasImages()
		{
			return false;
		}

		public virtual void add(Image image)
		{
		}

		public virtual void advanceRow()
		{
		}

		public virtual int calcHeightForWidth(int width)
		{
			return 0;
		}

		public virtual int findBestWidth()
		{
			return 0;
		}

		public virtual Image autoWrappedImage(object width)
		{
			return null;
		}

		public virtual Image manualWrappedImage(object maxWidth, Array outputRects)
		{
			return null;
		}

		public virtual Image horizontalImage()
		{
			return null;
		}

		public virtual Image verticalImage()
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
