using haxe.lang;

namespace app.vis
{
	public class Quad : HxObject
	{
		public static float kAlphaThresh;

		public Image image;

		public bool valid;

		public float px;

		public float py;

		public float pr;

		public float pb;

		public float ux;

		public float uy;

		public float ur;

		public float ub;

		public float cr;

		public float cg;

		public float cb;

		public float ca;

		static Quad()
		{
		}

		public Quad(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public Quad()
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_app_vis_Quad(Quad __hx_this)
		{
		}

		public virtual void make(PointData visualPos, float hostPosX, float hostPosY, Rect clip, Tile tile)
		{
		}

		public void applyPostScale(float postScale)
		{
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
