using System;

namespace test.auto
{
	public sealed class AutoStepPlayer_WaitForScreen : AutoStepPlayer
	{
		public readonly System.Type gameScreenClass;

		public AutoStepPlayer_WaitForScreen(System.Type gameScreenClass)
			: base(0)
		{
		}

		public override Array getParams()
		{
			return null;
		}

		public override string getTag()
		{
			return null;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public override bool Equals(object other)
		{
			return false;
		}

		public override string toString()
		{
			return null;
		}
	}
}
