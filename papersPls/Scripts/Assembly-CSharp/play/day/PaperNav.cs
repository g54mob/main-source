using data;
using haxe.lang;

namespace play.day
{
	public class PaperNav : HxObject
	{
		public PaperDef paperDef;

		public BoothEnv boothEnv;

		public string pageMask;

		public PaperNav(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public PaperNav(BoothEnv boothEnv_, PaperDef paperDef_, string idWithIndex)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_day_PaperNav(PaperNav __hx_this, BoothEnv boothEnv_, PaperDef paperDef_, string idWithIndex)
		{
		}

		public virtual int getNextPageIndex(int curPageIndex)
		{
			return 0;
		}

		public virtual int getPrevPageIndex(int curPageIndex)
		{
			return 0;
		}

		public virtual bool hasPage(int pageIndex)
		{
			return false;
		}

		public virtual bool hasPageFromId(string pageId)
		{
			return false;
		}

		public virtual string getExistingPageId(string combinedPageIds)
		{
			return null;
		}

		public virtual int autoGetSequentialPageCount()
		{
			return 0;
		}

		public virtual string autoGetNavLink(int curPageIndex, bool next)
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
