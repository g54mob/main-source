using app.vis;
using haxe.lang;

namespace play.day.booth
{
	public class Body : HxObject
	{
		public Image bodyImage;

		public Image headImage;

		public Sprite bodySprite;

		public Sprite headSprite;

		public uint color;

		public Body(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public Body(uint color_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_day_booth_Body(Body __hx_this, uint color_)
		{
		}

		public virtual void setTraveler(Traveler traveler)
		{
		}

		public virtual void setAffine(AffineData bodyAffine, AffineData headAffine)
		{
		}

		public virtual void setAffineIdentity(double x, double y)
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
