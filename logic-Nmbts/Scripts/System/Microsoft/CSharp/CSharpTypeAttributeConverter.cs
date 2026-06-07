using System.Reflection;
using System.Runtime.CompilerServices;

namespace Microsoft.CSharp
{
	internal sealed class CSharpTypeAttributeConverter : CSharpModifierAttributeConverter
	{
		[CompilerGenerated]
		private static readonly CSharpTypeAttributeConverter _003CDefault_003Ek__BackingField = new CSharpTypeAttributeConverter();

		[CompilerGenerated]
		private readonly string[] _003CNames_003Ek__BackingField = new string[2] { "Public", "Internal" };

		[CompilerGenerated]
		private readonly object[] _003CValues_003Ek__BackingField = new object[2]
		{
			TypeAttributes.Public,
			TypeAttributes.NotPublic
		};

		public static CSharpTypeAttributeConverter Default
		{
			[CompilerGenerated]
			get
			{
				return _003CDefault_003Ek__BackingField;
			}
		}

		protected override string[] Names
		{
			[CompilerGenerated]
			get
			{
				return _003CNames_003Ek__BackingField;
			}
		}

		protected override object[] Values
		{
			[CompilerGenerated]
			get
			{
				return _003CValues_003Ek__BackingField;
			}
		}

		protected override object DefaultValue
		{
			get
			{
				return TypeAttributes.NotPublic;
			}
		}

		private CSharpTypeAttributeConverter()
		{
		}
	}
}
