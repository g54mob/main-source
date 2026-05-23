using haxe.lang;

namespace data
{
	public class Op : Enum
	{
		protected static readonly string[] __hx_constructs;

		protected Op(int index)
			: base(0)
		{
		}

		public static Op SAY(string speechId)
		{
			return null;
		}

		public static Op REQUIREMENT(Array tokens)
		{
			return null;
		}

		public static Op ADDPAPER(string paperId)
		{
			return null;
		}

		public static Op REMOVEPAPER(string paperId)
		{
			return null;
		}

		public static Op INVALIDATEFACT(string factPath, Array ops)
		{
			return null;
		}

		public static Op VALIDATEFACT(string factPath)
		{
			return null;
		}

		public static Op SETFACT(string factPath, string value)
		{
			return null;
		}

		public static Op RUNSTEPS(string id, Array ops)
		{
			return null;
		}

		public static Op ENABLEBUTTON(string buttonId)
		{
			return null;
		}
	}
}
