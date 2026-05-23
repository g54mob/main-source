using app;
using app.vis;
using haxe.lang;

namespace data
{
	public class BodyLib : HxObject
	{
		public Res res;

		public Xml xmlRoot;

		public BodyLib(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public BodyLib(Res res_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_data_BodyLib(BodyLib __hx_this, Res res_)
		{
		}

		public static bool getTypeMatches(string wantTypes, string nodeType, string nodeFile)
		{
			return false;
		}

		public virtual string getBodyId(bool male, int bmi)
		{
			return null;
		}

		public virtual Image getBodyImage(string bodyId, bool nude)
		{
			return null;
		}

		public virtual Contraband getContraband(Rand rand, string bodyId, string types, string locs)
		{
			return null;
		}

		public virtual string getRandomNonBombContrabandType(Rand rand)
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
