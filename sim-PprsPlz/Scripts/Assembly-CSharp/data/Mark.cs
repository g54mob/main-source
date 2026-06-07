using app;
using app.vis;
using haxe.lang;

namespace data
{
	public class Mark : HxObject
	{
		public MarkType type;

		public string text;

		public string imageName;

		public string fontName;

		public uint textColor;

		public uint backColor;

		public Align textAlignment;

		public int wrapWidth;

		public Flow flow;

		public int flowPad;

		public int markSide;

		public string link;

		public PointData forcePos;

		public PointData forcePos2;

		public double imageScale;

		public string emblemId;

		public Rect emblemRect;

		public bool inspectable;

		public string proxyFactId;

		public int clipHeight;

		public PointData stampLinkSize;

		public Mark(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public Mark(Xml markNode, Mark defaults)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_data_Mark(Mark __hx_this, Xml markNode, Mark defaults)
		{
		}

		public virtual string getFactId()
		{
			return null;
		}

		public virtual string getProxiedFactId()
		{
			return null;
		}

		public virtual bool isValid()
		{
			return false;
		}

		public virtual PointData getRandomForcePos(Rand rand)
		{
			return null;
		}

		public virtual Image getImage(Res res)
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
