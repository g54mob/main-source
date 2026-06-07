using haxe.ds;
using haxe.lang;

namespace data
{
	public class SpeechLib : HxObject
	{
		public static StringMap responses;

		public static EReg genderRegM;

		public static EReg genderRegF;

		public static EReg genderRegX;

		static SpeechLib()
		{
		}

		public SpeechLib(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public SpeechLib(Res res)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_data_SpeechLib(SpeechLib __hx_this, Res res)
		{
		}

		public static string applyGenderSwitches(string str, Gender gender)
		{
			return null;
		}

		public virtual Response getResponse(string responseId)
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
	}
}
