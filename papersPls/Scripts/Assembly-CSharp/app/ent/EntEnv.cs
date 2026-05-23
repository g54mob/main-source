using app.aud;
using haxe.lang;
using play;

namespace app.ent
{
	public class EntEnv : HxObject
	{
		public Db db;

		public Res res;

		public Speaker speaker;

		public Clock clock;

		public Layout layout;

		public Unbug unbug;

		public Settings settings;

		public GameTransition gameTransition;

		public CommandLine commandLine;

		public Trunk trunk;

		public EntEnv(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public EntEnv(Db db_, Settings settings_, Layout layout_, Unbug unbug_, Speaker speaker_, GameTransition gameTransition_, CommandLine commandLine_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_app_ent_EntEnv(EntEnv __hx_this, Db db_, Settings settings_, Layout layout_, Unbug unbug_, Speaker speaker_, GameTransition gameTransition_, CommandLine commandLine_)
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

		public override void __hx_getFields(Array baseArr)
		{
		}
	}
}
