using CLanguage.Compiler;

namespace CLanguage.Types
{
	public abstract class CBasicType : CType
	{
		public static readonly CIntType ConstChar;

		public static readonly CIntType UnsignedChar;

		public static readonly CIntType SignedChar;

		public static readonly CIntType UnsignedShortInt;

		public static readonly CIntType SignedShortInt;

		public static readonly CIntType UnsignedInt;

		public static readonly CIntType SignedInt;

		public static readonly CIntType UnsignedLongInt;

		public static readonly CIntType SignedLongInt;

		public static readonly CIntType UnsignedLongLongInt;

		public static readonly CIntType SignedLongLongInt;

		public static readonly CFloatType Float;

		public static readonly CFloatType Double;

		public static readonly CBoolType Bool;

		public string Name { get; private set; }

		public Signedness Signedness { get; private set; }

		public string Size { get; private set; }

		public CBasicType(string name, Signedness signedness, string size)
		{
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public CBasicType IntegerPromote(EmitContext context)
		{
			return null;
		}

		public CBasicType ArithmeticConvert(CType otherType, EmitContext context)
		{
			return null;
		}

		private bool HasRankGreaterThan(CBasicType otherBasicType, EmitContext context)
		{
			return false;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
