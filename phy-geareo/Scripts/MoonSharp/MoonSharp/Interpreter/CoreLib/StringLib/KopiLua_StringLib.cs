using MoonSharp.Interpreter.Interop.LuaStateInterop;

namespace MoonSharp.Interpreter.CoreLib.StringLib
{
	internal class KopiLua_StringLib : LuaBase
	{
		public class MatchState
		{
			public class capture_
			{
				public CharPtr init;

				public int len;
			}

			public int matchdepth;

			public CharPtr src_init;

			public CharPtr src_end;

			public LuaState L;

			public int level;

			public capture_[] capture;
		}

		private class GMatchAuxData
		{
			public CharPtr S;

			public CharPtr P;

			public uint LS;

			public uint POS;
		}

		public const int LUA_MAXCAPTURES = 32;

		public const int CAP_UNFINISHED = -1;

		public const int CAP_POSITION = -2;

		public const int MAXCCALLS = 200;

		public const char L_ESC = '%';

		public const string SPECIALS = "^$*+?.([%-";

		public const int MAX_ITEM = 512;

		public const string FLAGS = "-+ #0";

		public static readonly int MAX_FORMAT;

		private static int posrelat(int pos, uint len)
		{
			return 0;
		}

		private static int check_capture(MatchState ms, int l)
		{
			return 0;
		}

		private static int capture_to_close(MatchState ms)
		{
			return 0;
		}

		private static CharPtr classend(MatchState ms, CharPtr p)
		{
			return null;
		}

		private static int match_class(char c, char cl)
		{
			return 0;
		}

		private static int matchbracketclass(int c, CharPtr p, CharPtr ec)
		{
			return 0;
		}

		private static int singlematch(int c, CharPtr p, CharPtr ep)
		{
			return 0;
		}

		private static CharPtr matchbalance(MatchState ms, CharPtr s, CharPtr p)
		{
			return null;
		}

		private static CharPtr max_expand(MatchState ms, CharPtr s, CharPtr p, CharPtr ep)
		{
			return null;
		}

		private static CharPtr min_expand(MatchState ms, CharPtr s, CharPtr p, CharPtr ep)
		{
			return null;
		}

		private static CharPtr start_capture(MatchState ms, CharPtr s, CharPtr p, int what)
		{
			return null;
		}

		private static CharPtr end_capture(MatchState ms, CharPtr s, CharPtr p)
		{
			return null;
		}

		private static CharPtr match_capture(MatchState ms, CharPtr s, int l)
		{
			return null;
		}

		private static CharPtr match(MatchState ms, CharPtr s, CharPtr p)
		{
			return null;
		}

		private static CharPtr lmemfind(CharPtr s1, uint l1, CharPtr s2, uint l2)
		{
			return null;
		}

		private static void push_onecapture(MatchState ms, int i, CharPtr s, CharPtr e)
		{
		}

		private static int push_captures(MatchState ms, CharPtr s, CharPtr e)
		{
			return 0;
		}

		private static int str_find_aux(LuaState L, int find)
		{
			return 0;
		}

		public static int str_find(LuaState L)
		{
			return 0;
		}

		public static int str_match(LuaState L)
		{
			return 0;
		}

		private static int gmatch_aux(LuaState L, GMatchAuxData auxdata)
		{
			return 0;
		}

		private static DynValue gmatch_aux_2(ScriptExecutionContext executionContext, CallbackArguments args)
		{
			return null;
		}

		public static int str_gmatch(LuaState L)
		{
			return 0;
		}

		private static int gfind_nodef(LuaState L)
		{
			return 0;
		}

		private static void add_s(MatchState ms, LuaLBuffer b, CharPtr s, CharPtr e)
		{
		}

		private static void add_value(MatchState ms, LuaLBuffer b, CharPtr s, CharPtr e)
		{
		}

		public static int str_gsub(LuaState L)
		{
			return 0;
		}

		private static void addquoted(LuaState L, LuaLBuffer b, int arg)
		{
		}

		private static CharPtr scanformat(LuaState L, CharPtr strfrmt, CharPtr form)
		{
			return null;
		}

		private static void addintlen(CharPtr form)
		{
		}

		public static int str_format(LuaState L)
		{
			return 0;
		}

		private static string PatchPattern(string charPtr)
		{
			return null;
		}
	}
}
