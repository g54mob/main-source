namespace MoonSharp.Interpreter.Interop.LuaStateInterop
{
	public class LuaBase
	{
		protected const int LUA_TNONE = -1;

		protected const int LUA_TNIL = 0;

		protected const int LUA_TBOOLEAN = 1;

		protected const int LUA_TLIGHTUSERDATA = 2;

		protected const int LUA_TNUMBER = 3;

		protected const int LUA_TSTRING = 4;

		protected const int LUA_TTABLE = 5;

		protected const int LUA_TFUNCTION = 6;

		protected const int LUA_TUSERDATA = 7;

		protected const int LUA_TTHREAD = 8;

		protected const int LUA_MULTRET = -1;

		protected const string LUA_INTFRMLEN = "l";

		protected static DynValue GetArgument(LuaState L, int pos)
		{
			return null;
		}

		protected static DynValue ArgAsType(LuaState L, int pos, DataType type, bool allowNil = false)
		{
			return null;
		}

		protected static int LuaType(LuaState L, int p)
		{
			return 0;
		}

		protected static string LuaLCheckLString(LuaState L, int argNum, out uint l)
		{
			l = default(uint);
			return null;
		}

		protected static void LuaPushInteger(LuaState L, int val)
		{
		}

		protected static int LuaToBoolean(LuaState L, int p)
		{
			return 0;
		}

		protected static string LuaToLString(LuaState luaState, int p, out uint l)
		{
			l = default(uint);
			return null;
		}

		protected static string LuaToString(LuaState luaState, int p)
		{
			return null;
		}

		protected static void LuaLAddValue(LuaLBuffer b)
		{
		}

		protected static void LuaLAddLString(LuaLBuffer b, CharPtr s, uint p)
		{
		}

		protected static void LuaLAddString(LuaLBuffer b, string s)
		{
		}

		protected static int LuaLOptInteger(LuaState L, int pos, int def)
		{
			return 0;
		}

		protected static int LuaLCheckInteger(LuaState L, int pos)
		{
			return 0;
		}

		protected static void LuaLArgCheck(LuaState L, bool condition, int argNum, string message)
		{
		}

		protected static int LuaLCheckInt(LuaState L, int argNum)
		{
			return 0;
		}

		protected static int LuaGetTop(LuaState L)
		{
			return 0;
		}

		protected static int LuaLError(LuaState luaState, string message, params object[] args)
		{
			return 0;
		}

		protected static void LuaLAddChar(LuaLBuffer b, char p)
		{
		}

		protected static void LuaLBuffInit(LuaState L, LuaLBuffer b)
		{
		}

		protected static void LuaPushLiteral(LuaState L, string literalString)
		{
		}

		protected static void LuaLPushResult(LuaLBuffer b)
		{
		}

		protected static void LuaPushLString(LuaState L, CharPtr s, uint len)
		{
		}

		protected static void LuaLCheckStack(LuaState L, int n, string message)
		{
		}

		protected static string LUA_QL(string p)
		{
			return null;
		}

		protected static void LuaPushNil(LuaState L)
		{
		}

		protected static void LuaAssert(bool p)
		{
		}

		protected static string LuaLTypeName(LuaState L, int p)
		{
			return null;
		}

		protected static int LuaIsString(LuaState L, int p)
		{
			return 0;
		}

		protected static void LuaPop(LuaState L, int p)
		{
		}

		protected static void LuaGetTable(LuaState L, int p)
		{
		}

		protected static int LuaLOptInt(LuaState L, int pos, int def)
		{
			return 0;
		}

		protected static CharPtr LuaLCheckString(LuaState L, int p)
		{
			return null;
		}

		protected static string LuaLCheckStringStr(LuaState L, int p)
		{
			return null;
		}

		protected static void LuaLArgError(LuaState L, int arg, string p)
		{
		}

		protected static double LuaLCheckNumber(LuaState L, int pos)
		{
			return 0.0;
		}

		protected static void LuaPushValue(LuaState L, int arg)
		{
		}

		protected static void LuaCall(LuaState L, int nargs, int nresults = -1)
		{
		}

		protected static int memcmp(CharPtr ptr1, CharPtr ptr2, uint size)
		{
			return 0;
		}

		protected static int memcmp(CharPtr ptr1, CharPtr ptr2, int size)
		{
			return 0;
		}

		protected static CharPtr memchr(CharPtr ptr, char c, uint count)
		{
			return null;
		}

		protected static CharPtr strpbrk(CharPtr str, CharPtr charset)
		{
			return null;
		}

		protected static bool isalpha(char c)
		{
			return false;
		}

		protected static bool iscntrl(char c)
		{
			return false;
		}

		protected static bool isdigit(char c)
		{
			return false;
		}

		protected static bool islower(char c)
		{
			return false;
		}

		protected static bool ispunct(char c)
		{
			return false;
		}

		protected static bool isspace(char c)
		{
			return false;
		}

		protected static bool isupper(char c)
		{
			return false;
		}

		protected static bool isalnum(char c)
		{
			return false;
		}

		protected static bool isxdigit(char c)
		{
			return false;
		}

		protected static bool isgraph(char c)
		{
			return false;
		}

		protected static bool isalpha(int c)
		{
			return false;
		}

		protected static bool iscntrl(int c)
		{
			return false;
		}

		protected static bool isdigit(int c)
		{
			return false;
		}

		protected static bool islower(int c)
		{
			return false;
		}

		protected static bool ispunct(int c)
		{
			return false;
		}

		protected static bool isspace(int c)
		{
			return false;
		}

		protected static bool isupper(int c)
		{
			return false;
		}

		protected static bool isalnum(int c)
		{
			return false;
		}

		protected static bool isgraph(int c)
		{
			return false;
		}

		protected static char tolower(char c)
		{
			return '\0';
		}

		protected static char toupper(char c)
		{
			return '\0';
		}

		protected static char tolower(int c)
		{
			return '\0';
		}

		protected static char toupper(int c)
		{
			return '\0';
		}

		protected static CharPtr strchr(CharPtr str, char c)
		{
			return null;
		}

		protected static CharPtr strcpy(CharPtr dst, CharPtr src)
		{
			return null;
		}

		protected static CharPtr strncpy(CharPtr dst, CharPtr src, int length)
		{
			return null;
		}

		protected static int strlen(CharPtr str)
		{
			return 0;
		}

		public static void sprintf(CharPtr buffer, CharPtr str, params object[] argv)
		{
		}
	}
}
