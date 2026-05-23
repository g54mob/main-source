using app.ent;
using app.vis;
using haxe.lang;

namespace test.auto
{
	public class AutoAudit : HxObject
	{
		public Array kinds;

		public Trunk trunk;

		public Drawer drawer;

		public ImageGrid resultImageGrid;

		public SoftwareRenderer softwareRenderer;

		public AutoAudit(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public AutoAudit(Layout layout, Trunk trunk_, Array kinds_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_test_auto_AutoAudit(AutoAudit __hx_this, Layout layout, Trunk trunk_, Array kinds_)
		{
		}

		public virtual bool hasKind(AuditKind kind)
		{
			return false;
		}

		public virtual void addImage(Image image)
		{
		}

		public virtual void addScreenshot()
		{
		}

		public virtual void advanceRow()
		{
		}

		public virtual void save(string filename)
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
