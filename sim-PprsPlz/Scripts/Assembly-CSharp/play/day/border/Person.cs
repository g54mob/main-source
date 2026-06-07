using app;
using app.ent;
using app.vis;
using data;
using haxe.lang;

namespace play.day.border
{
	public class Person : HxObject
	{
		public Function whenEvent;

		public double distAlongPath;

		public string prefix;

		public string id;

		public Path path;

		public PointData footOffset;

		public double moveDelay;

		public int targetStop;

		public PathMode pathMode;

		public bool haveSentEndEvent;

		public Border border;

		public double idleFrameCountdown;

		public bool curAnimMovingHorizontal;

		public PointData curAnimOffset;

		public int numMotionlessFrames;

		public double holdCountdown;

		public EntEnv entEnv;

		public CustomTile customTile;

		public string curAnimId;

		public bool isDead;

		public string idleAnimSuffix;

		public string pathAltPrefix;

		public PointData pos;

		public PointData prevPos;

		public PointData workPoint;

		public Rand rand;

		public Person(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public Person(EntEnv entEnv_, Rand rand_, Atlas atlas_, string id_, string prefix_, string idleAnimSuffix_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_day_border_Person(Person __hx_this, EntEnv entEnv_, Rand rand_, Atlas atlas_, string id_, string prefix_, string idleAnimSuffix_)
		{
		}

		public double get_distAlongPath()
		{
			return 0.0;
		}

		public bool get_faceLeft()
		{
			return false;
		}

		public bool set_faceLeft(bool f)
		{
			return false;
		}

		public string get_pathId()
		{
			return null;
		}

		public bool get_isOffscreen()
		{
			return false;
		}

		public bool get_visible()
		{
			return false;
		}

		public bool set_visible(bool v)
		{
			return false;
		}

		public double get_centerX()
		{
			return 0.0;
		}

		public double get_centerY()
		{
			return 0.0;
		}

		public double get_footX()
		{
			return 0.0;
		}

		public double set_footX(double v)
		{
			return 0.0;
		}

		public double get_footY()
		{
			return 0.0;
		}

		public double set_footY(double v)
		{
			return 0.0;
		}

		public virtual void init()
		{
		}

		public virtual void initRandomIdle()
		{
		}

		public virtual Path getPath()
		{
			return null;
		}

		public virtual Person setPath(string pathId, object pathNumStops, object delay)
		{
			return null;
		}

		public virtual void setAnim(Anim anim, object movingHorizontal)
		{
		}

		public virtual void forceDirtyMatrixAndRecalculateSize()
		{
		}

		public virtual Person warpToStop(int stop)
		{
			return null;
		}

		public virtual void moveToStop(int stop, object delay)
		{
		}

		public virtual void onEnterFrame(double dt)
		{
		}

		public virtual void endPath()
		{
		}

		public virtual void initIdleFrameCountdown()
		{
		}

		public virtual bool hitTestPoint(PointData posInParent)
		{
			return false;
		}

		public double getDistTo(Person person)
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
