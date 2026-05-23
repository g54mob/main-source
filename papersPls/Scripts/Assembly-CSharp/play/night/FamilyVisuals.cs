using app.vis;
using haxe.lang;
using play.day;

namespace play.night
{
	public class FamilyVisuals : HxObject
	{
		public static int kFamilyStatusColor;

		public static int kExtrasHeight;

		public static int kObristantFamilyStatusColor;

		public static Array imageTokenIds;

		public Array visuals;

		public PointData familyCenter0;

		public PointData familyStep;

		public PointData tokensPos0;

		public PointData tokensStep;

		public PointData apartmentPos;

		public PointData upgradesPos0;

		public PointData upgradesStep;

		public PointData passportPos;

		public Fill topDividerFill;

		static FamilyVisuals()
		{
		}

		public FamilyVisuals(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public FamilyVisuals(Db db, Layout layout, StoryState storyState, Family family, Summary daySummary)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_night_FamilyVisuals(FamilyVisuals __hx_this, Db db, Layout layout, StoryState storyState, Family family, Summary daySummary)
		{
		}

		public virtual void hideTopDivider()
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
