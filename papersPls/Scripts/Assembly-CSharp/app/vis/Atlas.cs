using haxe.ds;
using haxe.lang;

namespace app.vis
{
	public class Atlas : Visual
	{
		public double scale;

		public Image image;

		public Array sourceRects;

		public StringMap sequences;

		public Array chips;

		public Atlas(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public Atlas(Image image_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_app_vis_Atlas(Atlas __hx_this, Image image_)
		{
		}

		public virtual void addSource(string name, Rect rect)
		{
		}

		public virtual Array getSequence(string prefix)
		{
			return null;
		}

		public virtual Chip makeBasicChip(int sourceIndex)
		{
			return null;
		}

		public virtual Rect getSourceRect(int sourceIndex)
		{
			return null;
		}

		public override double width()
		{
			return 0.0;
		}

		public override double height()
		{
			return 0.0;
		}

		public override void buildTiles()
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

		public override object __hx_invokeField(string field, int hash, object[] dynargs)
		{
			return null;
		}

		public override void __hx_getFields(Array baseArr)
		{
		}
	}
}
