using app.plat;
using app.vis;
using haxe.io;
using haxe.lang;
using play;

namespace test
{
	public class Tester : HxObject
	{
		public string testDir;

		public string truthDir;

		public string guessDir;

		public string extraDir;

		public Platform platform;

		public Tester(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public Tester(string testDir_, Platform platform_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_test_Tester(Tester __hx_this, string testDir_, Platform platform_)
		{
		}

		public virtual void assertEqual_haxe_io_Bytes(Bytes a, Bytes b, object pos)
		{
		}

		public virtual bool isEqual_assertEqual_T(object a, object b, object pos)
		{
			return false;
		}

		public virtual bool isEqual_assertNotEqual_T(object a, object b, object pos)
		{
			return false;
		}

		public virtual Image loadTruthImage(string filename)
		{
			return null;
		}

		public virtual void saveGuessImage(Image image, string filename)
		{
		}

		public virtual void saveExtraImage(Image image, string filename)
		{
		}

		public virtual void saveGuessText(string text, string filename)
		{
		}

		public virtual void print(object d, object pos)
		{
		}

		public virtual void assertFilesMatch(string a, string b)
		{
		}

		public virtual void runBasicTest(string name, Function func)
		{
		}

		public virtual void runBasicTests()
		{
		}

		public virtual void runComplexTest(string name, Function func)
		{
		}

		public virtual void runComplexTests()
		{
		}

		public virtual Bootstrap makeBootstrap(object randomSeed)
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
