using haxe.ds;
using haxe.lang;

namespace data
{
	public class PaperDefLib : HxObject
	{
		public List defs;

		public StringMap soundsDefs;

		public StringMap inkDefs;

		public Array carouselGroups;

		public StringMap paperIdToCarouselGroup;

		public StringMap carouselForceOrders;

		public PaperDefLib(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public PaperDefLib(Res res, FactLib factLib)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_data_PaperDefLib(PaperDefLib __hx_this, Res res, FactLib factLib)
		{
		}

		public virtual PaperDef find(string id, string nation)
		{
			return null;
		}

		public virtual object getInkDef(string id)
		{
			return null;
		}

		public virtual SoundsDef getSoundsDef(string id)
		{
			return null;
		}

		public virtual int getCarouselForceSortOrder(string paperId)
		{
			return 0;
		}

		public virtual CarouselGroupDef getCarouselGroupDef(string paperId)
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
