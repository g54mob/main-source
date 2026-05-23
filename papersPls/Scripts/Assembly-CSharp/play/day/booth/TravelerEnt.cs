using app;
using app.ent;
using app.vis;
using haxe.lang;

namespace play.day.booth
{
	public class TravelerEnt : Ent
	{
		public Position position;

		public double bodyLightT;

		public double shutterOpenT;

		public double walkT;

		public Traveler traveler;

		public PointData bodyOffset;

		public Sprite colorSprite;

		public Sprite rifleButtSprite;

		public Sprite rifleButtHeadSprite;

		public Sprite rifleButtBodySprite;

		public Body shutterBody;

		public Body shadowBody;

		public double travelerWidth;

		public double travelerHeight;

		public Position targetPosition;

		public double boothWidth;

		public Stater stater;

		public double breatheTime;

		public double breatheOffsetY;

		public bool shutterBodyVisible;

		public bool visible;

		public Image rifleButtImage;

		public PointData _bodyPosInWorld;

		public AffineData bodyAffine;

		public AffineData headAffine;

		public PointData bodyPivot;

		public PointData headPivot;

		public TravelerEnt(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public TravelerEnt(Ent parent, double boothWidth_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_day_booth_TravelerEnt(TravelerEnt __hx_this, Ent parent, double boothWidth_)
		{
		}

		public virtual bool get_walking()
		{
			return false;
		}

		public override void update()
		{
		}

		public PointData getBodyPosInWorld(PointData worldPos)
		{
			return null;
		}

		public override void draw(Drawer drawer)
		{
		}

		public virtual void drawInFrontOfShutterShadow(Drawer drawer)
		{
		}

		public virtual void setTraveler(Traveler traveler_)
		{
		}

		public virtual void reset()
		{
		}

		public virtual void walkToPosition(Position targetPosition_)
		{
		}

		public virtual void snapToPosition(Position targetPosition_)
		{
		}

		public virtual double set_shutterOpenT(double t)
		{
			return 0.0;
		}

		public virtual double set_bodyLightT(double t)
		{
			return 0.0;
		}

		public virtual double set_walkT(double u)
		{
			return 0.0;
		}

		public virtual void setRifleButtAnim(double u)
		{
		}

		public virtual double getBodyOffsetY()
		{
			return 0.0;
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
