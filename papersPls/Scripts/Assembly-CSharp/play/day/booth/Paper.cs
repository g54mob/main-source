using app.ent;
using app.vis;
using data;
using haxe.lang;
using play.stash;

namespace play.day.booth
{
	public class Paper : HxObject
	{
		public static int kRackSpriteShadowOffsetX;

		public string idWithIndex;

		public PaperDef def;

		public DeskItem deskItem;

		public Function whenUnhandledLinkClicked;

		public int pageIndex;

		public BoothEnv boothEnv;

		public EntEnv entEnv;

		public Array pageStack;

		public bool filerEnabled;

		public int multiPaperIndex;

		public double outerImageAngle;

		public PaperNav nav;

		static Paper()
		{
		}

		public Paper(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public Paper(Ent deskItemGroupEnt, Filer filer, PaperDef def_, BoothEnv boothEnv_, int multiPaperIndex_, TouchGlows touchGlows, object revealOnDeskIndex, Carousel carousel)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_day_booth_Paper(Paper __hx_this, Ent deskItemGroupEnt, Filer filer, PaperDef def_, BoothEnv boothEnv_, int multiPaperIndex_, TouchGlows touchGlows, object revealOnDeskIndex, Carousel carousel)
		{
		}

		public static string makeIdWithIndex(string paperId, int index)
		{
			return null;
		}

		public static object getIdAndIndex(string idWithIndex)
		{
			return null;
		}

		public string getMountPosFactPath()
		{
			return null;
		}

		public virtual PointData get_mountPos()
		{
			return null;
		}

		public virtual PointData set_mountPos(PointData p)
		{
			return null;
		}

		public virtual int getNextPageIndex()
		{
			return 0;
		}

		public virtual int getPrevPageIndex()
		{
			return 0;
		}

		public virtual void flipPageIfPossible(bool next)
		{
		}

		public virtual void goPrevPageIfPossible()
		{
		}

		public virtual int get_page()
		{
			return 0;
		}

		public virtual int set_page(int i)
		{
			return 0;
		}

		public virtual void setPage(int index_)
		{
		}

		public string get_pageId()
		{
			return null;
		}

		public virtual string getRemappedFactId(string factId)
		{
			return null;
		}

		public virtual Array getInspectables(PointData worldPos)
		{
			return null;
		}

		public virtual Inspectable getInspectable(Booth booth, PointData stagePos)
		{
			return null;
		}

		public virtual void onClick(Visual hitVisual)
		{
		}

		public virtual bool testHasLink(string innerHittableName)
		{
			return false;
		}

		public virtual Mark getMarkFromName(string name)
		{
			return null;
		}

		public virtual bool pressLinksWithStamp(Booth booth, PointData stampStagePos, PointData stampSize)
		{
			return false;
		}

		public virtual void followLink(string link, Rect boothRect)
		{
		}

		public virtual bool applyStampInk(Image inkImage, PointData stagePos)
		{
			return false;
		}

		public virtual void updatePage()
		{
		}

		public virtual StashedBoothPaperState makeStash()
		{
			return null;
		}

		public virtual void restoreFromStash(StashedBoothPaperState paperState, PointData mountPos)
		{
		}

		public virtual int autoGetSequentialPageIndex()
		{
			return 0;
		}

		public virtual void playSoundDragStart()
		{
		}

		public virtual void playSoundDragStop()
		{
		}

		public virtual void playSoundDrop()
		{
		}

		public virtual void playSoundToTop()
		{
		}

		public virtual void playSoundTurnPage()
		{
		}

		public virtual bool tutorIsOnLastPage()
		{
			return false;
		}

		public virtual int tutorGetSequentialPageIndex()
		{
			return 0;
		}

		public virtual Rect tutorGetInnerNavLinkRect(string linkId)
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
