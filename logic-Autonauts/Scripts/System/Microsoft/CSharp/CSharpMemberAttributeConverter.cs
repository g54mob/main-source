using System.CodeDom;
using System.Runtime.CompilerServices;

namespace Microsoft.CSharp
{
	internal sealed class CSharpMemberAttributeConverter : CSharpModifierAttributeConverter
	{
		[CompilerGenerated]
		private static readonly CSharpMemberAttributeConverter _003CDefault_003Ek__BackingField = new CSharpMemberAttributeConverter();

		[CompilerGenerated]
		private readonly string[] _003CNames_003Ek__BackingField = new string[5] { "Public", "Protected", "Protected Internal", "Internal", "Private" };

		[CompilerGenerated]
		private readonly object[] _003CValues_003Ek__BackingField = new object[5]
		{
			MemberAttributes.Public,
			MemberAttributes.Family,
			MemberAttributes.FamilyOrAssembly,
			MemberAttributes.Assembly,
			MemberAttributes.Private
		};

		public static CSharpMemberAttributeConverter Default
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
				return MemberAttributes.Private;
			}
		}

		private CSharpMemberAttributeConverter()
		{
		}
	}
}
