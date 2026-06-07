using app;
using app.ent;
using app.vis;
using haxe.lang;

namespace play.day.booth
{
	public class PullChain : Ent
	{
		public static int kCount;

		public static int kChainSpritesPerNode;

		public static int kStretchDist;

		public Array nodes;

		public Sprite ringSprite;

		public Array chainSprites;

		public Array offscreenChainSprites;

		public bool firstFrame;

		public Rect ringWorldRect;

		public bool touching;

		public PointData touchingWorldPos;

		public double distToRingTip;

		public double distToRingLink;

		public PointData work;

		public PointData ringCenter;

		public CircleFinder circleFinder;

		public double ringRadius;

		public double chainLinkRadius;

		public Array debugSprites;

		public Stater stater;

		public double visibleT;

		public double baseY;

		public Function whenTriggered;

		public Rect clipRect;

		public int hangingFrame;

		public Rand jostleRand;

		public PointData offscreenChainBase;

		public double stretchingDist;

		public double jingleSoundLastPlayTime;

		public double clickSoundLastPlayTime;

		static PullChain()
		{
		}

		public PullChain(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public PullChain(Ent parent, double baseY_, Function whenTriggered_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_day_booth_PullChain(PullChain __hx_this, Ent parent, double baseY_, Function whenTriggered_)
		{
		}

		public virtual void hangAt(double worldX)
		{
		}

		public virtual void playSoundJingle()
		{
		}

		public virtual void playSoundClick()
		{
		}

		public virtual void playSoundDrop()
		{
		}

		public virtual void jostle()
		{
		}

		public virtual void updateHanging(object clampNodeHeight)
		{
		}

		public virtual PointData calcRingCenter()
		{
			return null;
		}

		public virtual void setHeldChainToTip(PointData p0, PointData p1)
		{
		}

		public virtual void setHeldChainToLink(PointData p0, PointData p1)
		{
		}

		public virtual void setDebugPos(int index, PointData pos, ColorData color)
		{
		}

		public override void update()
		{
		}

		public override void react(Input input)
		{
		}

		public override void draw(Drawer drawer)
		{
		}

		public virtual PointData tutorGetRingCenterInWorld()
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
